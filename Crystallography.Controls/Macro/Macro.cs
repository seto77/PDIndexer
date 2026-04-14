using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace Crystallography.Controls;

// 注: クラス名 "MacroTriger" は typo ("Trigger") だが、IPAnalyzer 等から
// `new MacroTriger("PDI", ...)` で参照されているため改名不可。
//
// 260414Cl 全面改修:
//  旧版は [Serializable] + Clipboard.SetDataObject(triger) で送信していたが、
//  .NET 9 以降 WinForms Clipboard の BinaryFormatter ベース経路が廃止されサイレント
//  失敗していた (csproj の EnableUnsafeBinaryFormatterSerialization は .NET 9 以降 no-op)。
//
//  対策: DataObject を継承し、コンストラクタ内で自身を JSON シリアライズして byte[] を
//  format=typeof(MacroTriger).FullName で SetData する。これにより呼び出し側
//  (IPAnalyzer など) は従来通り `Clipboard.SetDataObject(new MacroTriger(...))` だけで
//  済み、IPAnalyzer 本体のコードを 1 行も触らずに済む。
//
//  受信側 (PDIndexer) は GetData(typeof(MacroTriger)) で byte[] を受け取って
//  MacroTriger.Deserialize(byte[]) で復元する (旧版は MacroTriger インスタンスを
//  そのまま受け取っていたが、現在は byte[] 経由になる)。
public class MacroTriger : DataObject
{
    public string Target { get; set; }
    public bool Debug { get; set; }
    public string MacroName { get; set; }
    public object[] Obj { get; set; }

    // 260414Cl JSON デシリアライズ用 parameterless ctor
    public MacroTriger() { }

    public MacroTriger(string target, bool debug, object[] obj, string macroName = "")
    {
        Target = target;
        Debug = debug;
        Obj = obj;
        MacroName = macroName;

        // 自身を JSON 化して byte[] として登録。
        // クリップボード経由の cross-process 転送で受信側はこの byte[] を受け取る。
        SetData(typeof(MacroTriger), Serialize());
    }

    private static readonly JsonSerializerOptions JsonOpts = new() { WriteIndented = false };

    /// <summary>JSON シリアライズ。クリップボード SetData の中身として使う。</summary>
    public byte[] Serialize() => JsonSerializer.SerializeToUtf8Bytes(this, JsonOpts);

    /// <summary>
    /// JSON byte[] から <see cref="MacroTriger"/> を復元する。
    /// JSON で復元すると <see cref="Obj"/> 配列要素は <see cref="JsonElement"/> になるため
    /// プリミティブ型へ戻す。
    /// </summary>
    public static MacroTriger Deserialize(byte[] json)
    {
        var t = JsonSerializer.Deserialize<MacroTriger>(json, JsonOpts);
        if (t?.Obj != null)
        {
            for (int i = 0; i < t.Obj.Length; i++)
            {
                if (t.Obj[i] is JsonElement e)
                {
                    t.Obj[i] = e.ValueKind switch
                    {
                        JsonValueKind.Number => e.TryGetInt64(out var l) ? l : e.GetDouble(),
                        JsonValueKind.String => e.GetString(),
                        JsonValueKind.True => true,
                        JsonValueKind.False => false,
                        JsonValueKind.Null => null,
                        _ => e.ToString()
                    };
                }
            }
        }
        return t;
    }
}

[Serializable]
public class MacroBase
{
    // mainObject は派生クラス側 (PDIndexer / ReciPro / IPAnalyzer の Macro) から
    // FormMain インスタンスを保持するために使われる。dynamic は scope object 経由で
    // SetMacroToMenu を呼ぶための簡易ディスパッチ用。完全 typed 化はスコープ外。
    public dynamic mainObject;
    public string ScopeName = "";
    public List<string> help = [];
    public string[] Help => [.. help];

    public MacroBase(dynamic _main, string scopeName)
    {
        mainObject = _main;
        ScopeName = scopeName;
    }

    // 260414Cl virtual 化 (旧: 非 virtual)。FormMacro.obj が MacroBase 型に
    // なったあとも、IPAnalyzer 側 Macro が override で固有処理を維持できるように。
    public virtual void SetMacroToMenu(string[] name) => mainObject.SetMacroToMenu(name);
}

[Serializable]
public class MacroSub(Control _context)
{
    private readonly Control context = _context;

    // 260414Cl 全面整理:
    // 旧: Execute<Type>(Expression<Func<Type>>), Execute(Expression<Action>),
    //     Execute<Type>(Delegate), Execute(Delegate), 静的バリアント, params 付き等
    //     計 8 オーバーロードを定義していたが、実際に呼ばれていたのは Expression 版のみ。
    //     Func<T> / Action 版を併存させると lambda 引数で CS0121 曖昧性エラーになるため、
    //     Expression 版を撤去し以下 2 つに集約する。

    public T Execute<T>(Func<T> func)
        => context.InvokeRequired ? (T)context.Invoke(func) : func();

    public void Execute(Action action)
    {
        if (context.InvokeRequired)
            context.Invoke(action);
        else
            action();
    }
}

#region HelpAttribute

[AttributeUsage(AttributeTargets.All)]
public class HelpAttribute(string text, string arg = "") : Attribute
{
    public string Text = text;
    public string Argument = arg;

    public static List<string> GenerateHelpText(Type type, string name)
    {
        var strList = new List<string>();

        // 260414Cl name が null/空 の場合 "PDI..MethodName" のような空セクションが
        // 出ないよう連結を調整。root クラス自身に対しても呼べるようになった。
        var ns = type.Namespace ?? "";
        if (ns.Contains("PDIndexer")) ns = ns.Replace("PDIndexer", "PDI");
        if (ns.Contains("IPAnalyzer")) ns = ns.Replace("IPAnalyzer", "IPA");
        var header = string.IsNullOrEmpty(name) ? ns + "." : ns + "." + name + ".";

        foreach (var p in type.GetProperties().Where(e => e.GetCustomAttribute<HelpAttribute>() != null))
            strList.Add(header + p.Name + "#" + p.GetCustomAttribute<HelpAttribute>().Text);
        foreach (var m in type.GetMethods().Where(e => e.GetCustomAttribute<HelpAttribute>() != null && !e.IsSpecialName))
            strList.Add(header + m.Name + "(" + m.GetCustomAttribute<HelpAttribute>().Argument + ")#" + m.GetCustomAttribute<HelpAttribute>().Text);

        return strList;
    }
}

#endregion
