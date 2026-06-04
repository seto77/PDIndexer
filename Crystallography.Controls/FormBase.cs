using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Crystallography.Controls;

[System.ComponentModel.ToolboxItem(false)]
public partial class FormBase : Form
{
    //260529Cl 追加: F1 キーで該当オンラインマニュアルを開く仕組み。
    //「どのアプリのどのマニュアルを開くか」はホストアプリ固有の知識なので、Controls には持たせない。
    //ホストアプリが起動時に HelpUrlResolver を 1 回登録し、各フォームには HelpPage(ページ識別子) を設定する。

    /// <summary>
    /// F1 押下時に開くマニュアル URL を解決するデリゲート。ホストアプリが起動時に 1 回設定する。
    /// 引数の FormBase (HelpPage 等) を見て URL 文字列を返す。null や空文字を返すと何も開かない。
    /// </summary>
    public static Func<FormBase, string> HelpUrlResolver { get; set; } //260529Cl 追加

    /// <summary>
    /// このフォームに対応するマニュアルのページ識別子。HelpUrlResolver が URL を組み立てる際に使う。
    /// 値の意味 (スラッグ/番号など) はホストアプリの解決ロジックに依存する。
    /// </summary>
    //260530Cl 追加: コードからのみ設定するプロパティなのでデザイナのシリアライズ対象外にする (WFO1000 回避)。
    //         Crystallography.Controls は WFO1000 をプロジェクト単位で抑止しない方針(260322Ch)のため、CommonDialog.cs と同じく個別属性で対応する。
    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public string HelpPage { get; set; } = ""; //260529Cl 追加

    //260604Cl 追加: F1 でヘルプを開けるフォームのタイトルに付ける案内文字列 (UI 言語で切替)。
    //【右寄せを断念した経緯】当初はキャプション右端 (最小化ボタン手前) へ右寄せしようとしたが、Windows/DWM は
    //キャプション文字を「titleLeft から一定幅 (実測 96dpi で ~862px) まで」しか描画しない上限があり、幅広フォームでは
    //ボタン手前まで文字を置けず右側から欠ける。上限値は環境依存で実行時取得APIも無いため、右寄せは原理的に不可能。
    //よって「タイトル直後に固定の空白を挟む」方式に確定 (上限を絶対に超えないので必ず表示される)。
    private const string HelpGap = "          ";    //260604Cl 追加: タイトルと案内の間隔 (空白10個)
    private const string HelpCoreEn = "(F1: Help)";  //260604Cl 追加
    private const string HelpCoreJa = "(F1: ヘルプ)"; //260604Cl 追加
    private bool isUpdatingHelpSuffix = false;       //260604Cl 追加: 自分の Text 書換で再入する TextChanged を弾くフラグ

    //260604Cl 追加: 現在の UI 言語に対応する案内文字列。言語判定は FormMain 等の他の分岐と同じ CurrentUICulture.Name == "ja"。
    private static string HelpSuffix =>
        HelpGap + (System.Globalization.CultureInfo.CurrentUICulture.Name == "ja" ? HelpCoreJa : HelpCoreEn);

    //260604Cl 追加: タイトルに F1 ヘルプ案内を付けるか。出したくない派生フォーム (CommonDialog 等) は override で false にする。
    protected virtual bool ShowHelpSuffix => true;

    protected FormBase()
    {
        InitializeComponent();
        HelpRequested += FormBase_HelpRequested; //260529Cl 追加: F1 キー (HelpRequested) を購読

        //260604Cl 追加: F1 でヘルプが開けるフォームは、タイトル末尾に案内 ("(F1: Help)" / 日本語 UI なら "(F1: ヘルプ)") を付けて存在を知らせる。
        //表示時点では HelpPage / HelpUrlResolver が確定しているので Shown で初回付与し、タイトルがランタイムで書き換わったら TextChanged で付け直す。
        Shown += (s, e) => AppendHelpSuffix();
        TextChanged += (s, e) => AppendHelpSuffix();
    }

    //260604Cl 追加: タイトル(Text)末尾に現在の UI 言語の案内文字列を付与する。
    //HelpUrlResolver が未登録/空 URL を返すフォーム (他ホストアプリや設計時) には付けない。
    private void AppendHelpSuffix()
    {
        if (isUpdatingHelpSuffix)
            return; //自分が起こした TextChanged の再入を弾く (無限ループ回避)
        if (!ShowHelpSuffix)
            return; //この派生フォームは案内を出さない (CommonDialog 等)
        if (string.IsNullOrEmpty(HelpUrlResolver?.Invoke(this)))
            return; //F1 で開くヘルプが無ければ付けない

        //既存の案内 (両言語) を取り除いた素のタイトルに、現在言語の案内を付け直す。
        //言語切替で逆言語の案内が残っていても二重化しない。
        var desired = StripHelpSuffix(Text) + HelpSuffix;
        if (Text == desired)
            return; //既に正しい状態 (再表示・連続更新時のちらつき防止)

        isUpdatingHelpSuffix = true;
        try { Text = desired; }
        finally { isUpdatingHelpSuffix = false; }
    }

    //260604Cl 追加: 既存の案内 (両言語) と直前のスペースを取り除いた素のタイトルを返す。
    private static string StripHelpSuffix(string text)
    {
        if (text.EndsWith(HelpCoreEn, StringComparison.Ordinal))
            return text.Substring(0, text.Length - HelpCoreEn.Length).TrimEnd(' ');
        if (text.EndsWith(HelpCoreJa, StringComparison.Ordinal))
            return text.Substring(0, text.Length - HelpCoreJa.Length).TrimEnd(' ');
        return text;
    }

    //260529Cl 追加: F1 押下時に HelpUrlResolver が返す URL を既定ブラウザで開く
    private void FormBase_HelpRequested(object sender, HelpEventArgs hlpevent)
    {
        var url = HelpUrlResolver?.Invoke(this);
        if (!string.IsNullOrEmpty(url))
        {
            try { Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
            catch { }
        }

        if (hlpevent != null)
            hlpevent.Handled = true;
    }
}
