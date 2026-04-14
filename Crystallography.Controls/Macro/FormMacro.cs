using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Crystallography.Controls;

public partial class FormMacro : CaptureFormBase
{
    #region フィールド、プロパティ

    // 260414Cl Task / RunSynchronously は不要だったので削除。
    // CancellationTokenSource は OnTraceback の待機解除用に保持する
    // (IronPython 自体はトークンを尊重しないので Cancel ボタンはステップ実行時のみ有効)。
    private CancellationTokenSource _cancelSource;
    public bool stepByStepMode;

    private readonly MacroBase obj; // 260414Cl 旧: dynamic obj
    private readonly ScriptEngine Engine;
    private readonly ScriptScope Scope;
    private readonly string ScopeName;

    // 260414Cl OnTraceback で生成しないようキャッシュ。
    private readonly IronPython.Runtime.Exceptions.TracebackDelegate _tracebackDelegate;

    #endregion

    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public string[] HelpItems
    {
        set
        {
            var autoCompleteItems = new List<string>();
            var toolTipItems = new List<string>();
            for (int i = 0; i < value.Length; i++)
            {
                string[] temp = value[i].Split('#', true);

                for (int j = 0; j < temp.Length; j++)
                    temp[j] = temp[j].Trim().TrimEnd();

                autoCompleteItems.Add(temp[0]);
                toolTipItems.Add(temp.Length == 2 ? temp[1] : "");

                dataGridView.Rows.Add(temp);
            }
            exRichTextBox.AutoCompleteItems = [.. autoCompleteItems];
            exRichTextBox.ToolTipItems = [.. toolTipItems];
        }
    }

    public FormMacro(ScriptEngine engine, object scopeObject)
    {
        InitializeComponent();

        Engine = engine;
        // 260414Cl scopeObject を MacroBase 型へ。3 アプリすべて MacroBase 派生を渡している。
        obj = (MacroBase)scopeObject;

        Scope = Engine.CreateScope();
        ScopeName = obj.ScopeName;
        Scope.SetVariable(ScopeName, scopeObject);
        HelpItems = obj.Help;

        _tracebackDelegate = OnTraceback;

        splitContainer2.SplitterDistance = splitContainer2.Width;
    }

    private void FormMacro_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        this.Visible = false;
    }

    // 260414Cl NoRichTextChange / SendMessage P/Invoke / IMF_DUALFONT 等の定数を削除。
    // 元コードはどこからも呼ばれていない死コードだった。

    private IronPython.Runtime.Exceptions.TracebackDelegate OnTraceback(IronPython.Runtime.Exceptions.TraceBackFrame frame, string result, object payload)
    {
        if (stepByStepMode)
            setDebugInfo(frame, result);

        // スクリプトは UI スレッド上で同期実行されているため、Wait + Sleep だけだと
        // UI が固まってボタンが押せない。Application.DoEvents で短いポンプを行いつつ
        // 50ms ごとにキャンセル要求をチェックする。本格的に消すには別スレッド実行への
        // 全面切り替えが必要だが、互換性確保のため現状維持。
        while (stepByStepMode && nextStepFlag == false)
        {
            try
            {
                _cancelSource.Token.ThrowIfCancellationRequested();
                Application.DoEvents();
            }
            catch { }
            Thread.Sleep(50);
        }
        nextStepFlag = false;
        return _tracebackDelegate;
    }

    private void setDebugInfo(IronPython.Runtime.Exceptions.TraceBackFrame frame, string result)
    {
        if (this.InvokeRequired)
        {
            // 260414Cl 旧: setDebugInfoCallBack delegate を経由していた。
            this.Invoke((Action)(() => setDebugInfo(frame, result)));
            return;
        }
        if (!stepByStepMode)
            return;

        this.Focus();
        int i = (int)frame.f_lineno;
        dataGridViewDebug.Rows.Clear();
        if (i > 0 && result != "exception")
        {
            exRichTextBox.HideSelection = false;
            int start = 0;
            for (int j = 0; j < i - 1; j++)
                start += exRichTextBox.TextLines[j].Length + 1;
            exRichTextBox.SelectionStart = start;
            exRichTextBox.SelectionLength = exRichTextBox.TextLines[i - 1].Length;

            foreach (object o in (IronPython.Runtime.PythonDictionary)frame.f_locals)
            {
                try
                {
                    var kv = (KeyValuePair<object, object>)o;
                    var key = (string)kv.Key;
                    if (!(key.StartsWith("__") && key.EndsWith("__")) && key != ScopeName)
                    {
                        var value = kv.Value.ToString();
                        if (kv.Value is int[] v && v.Length != 0)
                        {
                            value = "";
                            foreach (int n in v)
                                value += n + ", ";
                        }
                        dataGridViewDebug.Rows.Add([key, value]);
                    }
                }
                catch { }
            }
        }
    }

    private bool nextStepFlag = false;

    private void buttonNextStep_Click(object sender, EventArgs e) => nextStepFlag = true;

    private void buttonCancelStep_Click(object sender, EventArgs e)
    {
        // 260414Cl 旧: task != null && task.Status == TaskStatus.Running を見ていた。
        // Task を撤去したので _cancelSource の有無だけで判定する。
        // 注: ステップ実行の待機解除にしか効かない (IronPython 実行自体は中断不能)。
        _cancelSource?.Cancel(true);
    }

    private void buttonRunMacro_Click(object sender, EventArgs e)
    {
        stepByStepMode = false;

        buttonStepByStep.Visible = buttonRunMacro.Visible = false;
        RunMacro(exRichTextBox.Text);
        buttonCancelStep.Visible = false;
        buttonStepByStep.Visible = buttonRunMacro.Visible = true;
    }

    private void buttonStepByStep_Click(object sender, EventArgs e)
    {
        stepByStepMode = true;

        buttonNextStep.Visible = true;
        buttonStepByStep.Visible = buttonRunMacro.Visible = false;
        try { RunMacro(exRichTextBox.Text); }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        buttonCancelStep.Visible = buttonNextStep.Visible = false;
        buttonStepByStep.Visible = buttonRunMacro.Visible = true;
    }

    public void SelectMacro(string macroName)
    {
        var match = listBoxMacro.Items.Cast<MacroEntry>().FirstOrDefault(m => m.Name == macroName);
        if (match.Name != null)
            listBoxMacro.SelectedIndex = listBoxMacro.Items.IndexOf(match);
    }

    public void RunMacroName(string macroName, bool _stepByStepMode = false)
    {
        stepByStepMode = _stepByStepMode;
        var match = listBoxMacro.Items.Cast<MacroEntry>().FirstOrDefault(m => m.Name == macroName);
        if (match.Name == null)
        {
            MessageBox.Show("The macro name is not found");
            return;
        }
        RunMacro(match.Body);
    }

    public void RunMacro() => RunMacro(exRichTextBox.Text);
    public void RunMacro(bool _stepByStepMode)
    {
        stepByStepMode = _stepByStepMode;
        RunMacro(exRichTextBox.Text);
    }
    public void RunMacro(string srcCode)
    {
        try
        {
            // 構文チェックのみ先に走らせて SyntaxErrorException を分離キャッチ。
            Engine.CreateScriptSourceFromString(srcCode).Compile();

            dataGridViewDebug.Rows.Clear();

            if (stepByStepMode)
            {
                splitContainer2.SplitterDistance = splitContainer2.Width - 220;
                IronPython.Hosting.Python.SetTrace(Engine, _tracebackDelegate);
            }

            _cancelSource = new CancellationTokenSource();
            // 260414Cl 旧: new Task(...).RunSynchronously() で同期実行していたが、
            // RunSynchronously は呼び出しスレッド (UI スレッド) で動くだけで Task の
            // 意味が無く、CancellationToken も IronPython 側で尊重されないので撤去。
            Engine.CreateScriptSourceFromString(srcCode).Execute(Scope);
        }
        catch (Microsoft.Scripting.ArgumentTypeException ex) { MessageBox.Show(ex.Message); }
        catch (Microsoft.Scripting.SyntaxErrorException ex) { MessageBox.Show("Syntax error in line " + ex.Line.ToString()); }
        catch (MissingMemberException ex) { MessageBox.Show(ex.Message); }
        catch (Exception e) { MessageBox.Show(e.Message); }
        splitContainer2.SplitterDistance = splitContainer2.Width;
    }

    #region マクロファイルを読み込み・書き込み
    private void FormMacro_DragDrop(object sender, DragEventArgs e)
    {
        // 260414Cl null チェックを追加 (旧: 直接キャストで NRE 可能性)。
        if (e.Data.GetData(DataFormats.FileDrop) is string[] files
            && files.Length == 1
            && files[0].EndsWith(".mcr"))
        {
            ReadMacroFile(files[0]);
        }
    }

    private void FormMacro_DragEnter(object sender, DragEventArgs e)
        => e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

    private void readToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var dlg = new OpenFileDialog { Filter = "*.mcr|*.mcr" };
        if (dlg.ShowDialog() == DialogResult.OK)
            ReadMacroFile(dlg.FileName);
    }

    public void ReadMacroFile(string filename)
    {
        // 260414Cl 旧: StreamReader を手で Close。File.ReadLines は遅延読み込みで
        // \r\n / \n 両方の改行を吸収するので、元の StreamReader.ReadLine と同等。
        exRichTextBox.Text = "";
        foreach (var line in File.ReadLines(filename, Encoding.UTF8))
            exRichTextBox.AppendText(line + "\n");
        textBoxMacroName.Text = Path.GetFileNameWithoutExtension(filename);
        buttonAddMacro_Click(new object(), new EventArgs());
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var dlg = new SaveFileDialog
        {
            Filter = "*.mcr|*.mcr",
            FileName = textBoxMacroName.Text + ".mcr"
        };
        if (dlg.ShowDialog() != DialogResult.OK)
            return;
        // 260414Cl 旧: StreamWriter を手で Close していた。
        File.WriteAllLines(dlg.FileName, exRichTextBox.TextLines, Encoding.UTF8);
    }
    #endregion

    private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            string str = (string)dataGridView.Rows[e.RowIndex].Cells[0].Value;

            int selectionStart = exRichTextBox.SelectionStart;
            exRichTextBox.Text = exRichTextBox.Text.Remove(selectionStart, exRichTextBox.SelectionLength);
            exRichTextBox.Text = exRichTextBox.Text.Insert(selectionStart, str);
        }
    }

    // 260414Cl 削除: saveAsMenuItemToolStripMenuItem_Click / readFromMenuItemToolStripMenuItem_Click
    // どちらも Designer から配線されていない死コード。obj.SaveToMenuItem / obj.ReadFromMenuItem も
    // どのリポジトリにも実装が無く、呼ぶと RuntimeBinderException で必ず落ちる潜在バグだった。

    #region リストボックス操作
    private void buttonAddMacro_Click(object sender, EventArgs e)
    {
        var m = new MacroEntry(textBoxMacroName.Text, exRichTextBox.Text);
        var items = listBoxMacro.Items;
        if (m.Name.Length == 0)
        {
            MessageBox.Show("Please input macro name", "Alert");
            return;
        }
        if (items.Cast<MacroEntry>().Any(o => o.Name == m.Name))
        {
            if (MessageBox.Show("The name already exists. Do you replace the macro?", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
                items[items.IndexOf(items.Cast<MacroEntry>().First(item => item.Name == m.Name))] = m;
            setMenuItemOfMain();
        }
        else
        {
            items.Add(m);
            setMenuItemOfMain();
        }
    }

    private void buttonChangeMacro_Click(object sender, EventArgs e)
    {
        if (listBoxMacro.SelectedIndex >= 0)
        {
            listBoxMacro.Items[listBoxMacro.SelectedIndex] = new MacroEntry(textBoxMacroName.Text, exRichTextBox.Text);
            setMenuItemOfMain();
        }
    }

    private void buttonDeleteMacro_Click(object sender, EventArgs e)
    {
        int n = listBoxMacro.SelectedIndex;
        if (n >= 0)
        {
            listBoxMacro.Items.RemoveAt(n);
            if (n < listBoxMacro.Items.Count)
                listBoxMacro.SelectedIndex = n;
            else if (n - 1 < listBoxMacro.Items.Count)
                listBoxMacro.SelectedIndex = n - 1;
        }
    }

    private void listBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        buttonChange.Enabled = buttonDeleteProfile.Enabled = listBoxMacro.SelectedIndex >= 0;

        buttonLower.Enabled = listBoxMacro.SelectedIndex >= 0 && listBoxMacro.SelectedIndex < listBoxMacro.Items.Count - 1;
        buttonUpper.Enabled = listBoxMacro.SelectedIndex >= 1;

        if (listBoxMacro.SelectedIndex < 0)
            return;

        var value = (MacroEntry)listBoxMacro.SelectedItem;
        if (textBoxMacroName.Text != value.Name)
            textBoxMacroName.Text = value.Name;
        if (exRichTextBox.Text != value.Body)
            exRichTextBox.Text = value.Body;

        setMenuItemOfMain();
    }

    private void buttonUpper_Click(object sender, EventArgs e)
    {
        int n = listBoxMacro.SelectedIndex;
        if (n < 1) return;
        var item = listBoxMacro.SelectedItem;
        listBoxMacro.Items.RemoveAt(n);
        listBoxMacro.Items.Insert(n - 1, item);
        listBoxMacro.SelectedIndex = n - 1;
        setMenuItemOfMain();
    }

    private void buttonLower_Click(object sender, EventArgs e)
    {
        int n = listBoxMacro.SelectedIndex;
        if (n < 0 || n >= listBoxMacro.Items.Count - 1) return;
        var item = listBoxMacro.SelectedItem;
        listBoxMacro.Items.RemoveAt(n);
        listBoxMacro.Items.Insert(n + 1, item);
        listBoxMacro.SelectedIndex = n + 1;
        setMenuItemOfMain();
    }

    #endregion

    #region KeyDownイベント
    private void FormMacro_KeyDown(object sender, KeyEventArgs e)
    {
        // 260414Cl 旧: e.Modifiers == Keys.Control & e.KeyCode == Keys.S (ビット AND)
        if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
        {
            if (listBoxMacro.SelectedIndex >= 0 && textBoxMacroName.Text == ((MacroEntry)listBoxMacro.SelectedItem).Name)
                listBoxMacro.Items[listBoxMacro.SelectedIndex] = new MacroEntry(textBoxMacroName.Text, exRichTextBox.Text);
        }
        // F10 次のステップに進む
        if (e.KeyCode == Keys.F10 && buttonNextStep.Visible)
            buttonNextStep_Click(sender, new EventArgs());
    }
    #endregion

    private void setMenuItemOfMain()
    {
        var list = new List<string>();
        for (int i = 0; i < listBoxMacro.Items.Count; i++)
            list.Add(((MacroEntry)listBoxMacro.Items[i]).Name);
        obj.SetMacroToMenu(list.ToArray());
    }

    public void SetMacroList(KeyValuePair<string, string>[] list)
    {
        listBoxMacro.Items.Clear();
        for (int i = 0; i < list.Length; i++)
            listBoxMacro.Items.Add(new MacroEntry(list[i].Key, list[i].Value));
    }

    [System.ComponentModel.Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public byte[] ZippedMacros
    {
        get
        {
            var strList = new List<string>();
            for (int i = 0; i < listBoxMacro.Items.Count; i++)
            {
                var m = (MacroEntry)listBoxMacro.Items[i];
                strList.Add(m.Name);
                strList.Add(m.Body);
            }

            // 260414Cl using で確実に Dispose。
            using var ms = new MemoryStream();
            using (var ds = new DeflateStream(ms, CompressionMode.Compress, true))
            {
                var serializer = new XmlSerializer(typeof(List<string>));
                serializer.Serialize(ds, strList);
            }
            return ms.ToArray();
        }
        set
        {
            if (value == null || value.Length == 0) return;

            using var ms = new MemoryStream(value);
            using var ds = new DeflateStream(ms, CompressionMode.Decompress, true);
            var serializer = new XmlSerializer(typeof(List<string>));
            var strList = (List<string>)serializer.Deserialize(ds);

            listBoxMacro.Items.Clear();
            for (int i = 0; i < strList.Count; i += 2)
                listBoxMacro.Items.Add(new MacroEntry(strList[i], strList[i + 1]));
            if (listBoxMacro.Items.Count > 0)
                setMenuItemOfMain();
        }
    }

    // 260414Cl 旧名 "Macro" を "MacroEntry" に改名 (private struct なので外部影響なし)。
    // public な Macro 派生クラスと紛らわしかったため。
    private struct MacroEntry(string name, string body)
    {
        public string Name = name;
        public string Body = body;

        public override string ToString() => Name;
    }
}
