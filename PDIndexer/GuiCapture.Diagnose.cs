using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PDIndexer;

// 260625Cl 追加 (多言語化 Phase 3): 翻訳でテキスト長が変わったとき「ラベル/ボタンが切れる・重なる＝読めなくなる」
//   箇所を、目視でなく機械的に検出するオーバーフロー/重なり診断ツール。ReciPro の GuiCapture.Diagnose.cs を
//   PDIndexer のフォーム構造 (FormMain + 配線済み子フォーム + reflection 単独フォーム) へ適合させた移植。
//   各テキスト保持コントロールについて TextRenderer.MeasureText の必要幅/高さと実寸 (固定幅) を比較して切れを、
//   AutoSize は祖先右端/右隣兄弟との交差で重なりを検出し、TSV へ出力する。
//   疑似ローカライズ: inflate(例 1.4) で「実テキストが N 倍に伸びたら切れるか」を実翻訳が無くても先出しできる。
//   起動: Program.cs の --diagnose [culture] [inflate%] から。--capture と異なり CopyFromScreen を使わず画面外で測る。
internal static partial class GuiCapture
{
    // 切れ/はみ出しの許容誤差 (MeasureText とレンダラの差・丸め)。これ以下は無視。
    private const int OverflowTolerancePx = 2;
    // Warning と Error の境 (不足ピクセル)。「2px 以内=丸め、6px 超=error」。
    private const int OverflowErrorPx = 6;

    /// <summary>全フォームを画面外に構築してテキストの切れ/重なりを測り、TSV を outFile へ書き出す。</summary>
    public static void Diagnose(string outFile, double inflate = 1.0)
    {
        var culture = (ForcedUICulture ?? Thread.CurrentThread.CurrentUICulture).Name;
        var rows = new List<string>
        {
            // Actual/Needed は幅判定では px 幅、Label の折り返し判定では px 高さ (Reason に明記)。
            string.Join("\t", "Culture", "Form", "Control", "Type", "Text", "Font", "Actual", "Needed", "Deficit", "Severity", "Reason")
        };
        void Trace(string s) => Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}\t{s}");

        // フォーム Load/Show で投げられる例外を握りつぶす (未処理例外のモーダルダイアログでハングしないため)。
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => Trace($"ThreadException\t{e.Exception.GetType().Name}: {e.Exception.Message}");
        IsCapturing = true; // FormMain_Load の初期ダイアログ表示を抑止 (画面外診断には不要)
        Trace($"diagnose start (culture={culture}, inflate={inflate:0.00}) -> {outFile}");

        var diagnosed = new HashSet<Type>();
        FormMain main = null;
        try
        {
            if (ForcedUICulture != null) Thread.CurrentThread.CurrentUICulture = ForcedUICulture;
            main = new FormMain();
            ShowOffScreen(main, Trace);                  // Show で FormMain_Load が走り全子フォームが配線される
            PrepareSpecialCaptureState(main, Trace);     // 代表結晶を選択 (結晶依存の子フォーム供給に必須)
            Settle(main, 60);
            DiagnoseForm(main, nameof(FormMain), culture, inflate, rows);
            diagnosed.Add(typeof(FormMain));
        }
        catch (Exception ex) { Trace($"FormMain\tFAIL\t{ex.GetType().Name}: {ex.Message}"); }

        // FormMain が保持する配線済み子フォーム (ctor 引数 formMain で配線。reflection 単独生成では NRE するもの)。
        if (main != null)
        {
            foreach (var child in main.EnumerateCaptureDependentForms())
            {
                if (child == null || child.IsDisposed) continue;
                try
                {
                    ShowOffScreen(child, Trace);
                    Settle(child, 60);
                    DiagnoseForm(child, child.GetType().Name, culture, inflate, rows);
                    diagnosed.Add(child.GetType());
                    try { child.Hide(); } catch { /* FormMain が所有・破棄するので Hide のみ */ }
                }
                catch (Exception ex) { Trace($"{child.GetType().Name}\tFAIL\t{ex.GetType().Name}: {ex.Message}"); }
            }
        }

        // 残りの parameterless ctor 単独フォーム (FormAboutMe/FormPrintOption/FormExportGSAS/FormLimitChanger 等)。
        foreach (var type in typeof(FormMain).Assembly.GetTypes()
            .Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null && !diagnosed.Contains(t))
            .OrderBy(t => t.Name))
        {
            Form form = null;
            try
            {
                if (ForcedUICulture != null) Thread.CurrentThread.CurrentUICulture = ForcedUICulture;
                form = (Form)Activator.CreateInstance(type);
                ShowOffScreen(form, Trace);
                Settle(form, 60);
                DiagnoseForm(form, type.Name, culture, inflate, rows);
            }
            catch (Exception ex) { Trace($"{type.Name}\tFAIL\t{ex.GetType().Name}: {ex.Message}"); }
            finally { try { form?.Dispose(); } catch { /* 破棄時例外は無視 */ } }
        }

        try { main?.Close(); main?.Dispose(); } catch { /* 破棄時例外は無視 */ }

        var full = System.IO.Path.GetFullPath(outFile);
        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(full));
        System.IO.File.WriteAllLines(full, rows);
        int findings = rows.Count - 1;
        int errors = rows.Skip(1).Count(r => r.Contains("\tError\t"));
        Trace($"diagnose done: {findings} findings ({errors} error) -> {full}");
    }

    private static void ShowOffScreen(Form form, Action<string> trace)
    {
        form.StartPosition = FormStartPosition.Manual;
        form.ShowInTaskbar = false;
        form.Location = new Point(-32000, -32000); // 画面外 (診断は CopyFromScreen を使わないので可)
        try { form.Show(); } catch (Exception ex) { trace($"{form.GetType().Name}\tWARN Show\t{ex.GetType().Name}: {ex.Message}"); }
    }

    private static void DiagnoseForm(Form form, string name, string culture, double inflate, List<string> rows)
    {
        // 診断側で UiFont.Apply を冪等に再適用してフォント sweep を保証する (Load 失敗フォームでも実カルチャのフォントで測る)。
        try { Crystallography.Controls.UiFont.Apply(form); } catch { /* 部分構築フォームは測れる範囲で測る */ }
        try { form.PerformLayout(); } catch { /* レイアウト例外は無視 */ }
        foreach (var c in EnumerateControls(form))
            DiagnoseControl(c, name, culture, inflate, rows);
        foreach (var it in EnumerateToolStripItems(form))
            DiagnoseToolStripItem(it, name, culture, inflate, rows);
    }

    private static void DiagnoseControl(Control c, string form, string culture, double inflate, List<string> rows)
    {
        if (!c.Visible || string.IsNullOrWhiteSpace(c.Text)) return; // 空白のみのラベル (スペーサ) は対象外
        // テキストを表示する代表的なリーフ型のみ。ButtonBase=Button/CheckBox/RadioButton。
        if (c is not (Label or ButtonBase or GroupBox or LinkLabel)) return;
        // NumericBox/ColorControl/WaveLengthControl は自己管理する複合コントロール (内部 labelHeader 等を誤検出しない)。
        for (var a = c.Parent; a != null; a = a.Parent)
            if (a.GetType().Name.Contains("NumericBox") || a.GetType().Name.Contains("ColorControl") || a.GetType().Name.Contains("WaveLengthControl")) return;

        // 擬似ローカライズ (inflate>1) の伸長予測は「翻訳される語」にのみ意味がある。記号/単位/短いインデックスは対象外。
        if (inflate > 1.0 && !IsLikelyTranslatable(c.Text)) return;

        int glyph = c is CheckBox or RadioButton ? 18 : c is ButtonBase ? 12 : c is GroupBox ? 8 : 4; // グリフ/枠の余白概算

        if (c.AutoSize)
        {
            // AutoSize は文字に合わせて伸びるので自テキストには「切れ」ない。代わりに右隣衝突と祖先右端クリップを見る。
            var p = c.Parent;
            if (p == null) return;
            int growth = (int)Math.Ceiling(TextRenderer.MeasureText(c.Text, c.Font).Width * (inflate - 1.0));
            int grownRight = c.Right + growth;

            // (1) 右隣兄弟との衝突 (直親が再配置/成長しない場合のみ予測)。
            if (p is not FlowLayoutPanel and not TableLayoutPanel && !p.AutoSize)
            {
                Control nearest = null;
                foreach (Control s in p.Controls)
                {
                    if (ReferenceEquals(s, c) || !s.Visible || s.Width == 0) continue;
                    if (s.Left < c.Right - OverflowTolerancePx) continue;  // 右隣のみ
                    if (s.Bottom <= c.Top || s.Top >= c.Bottom) continue;  // 別の行は除外
                    if (nearest == null || s.Left < nearest.Left) nearest = s;
                }
                if (nearest != null)
                {
                    int deficit = grownRight - nearest.Left;
                    if (deficit > OverflowTolerancePx)
                    {
                        rows.Add(Row(culture, form, c.Name, c.GetType().Name, c.Text, c.Font, c.Width, c.Width + growth, deficit,
                            deficit > OverflowErrorPx ? "Error" : "Warning", $"WouldCollide:{nearest.Name}"));
                        return;
                    }
                }
            }

            // (2) 祖先のクライアント右端で切れるか。
            var (clipDeficit, clipper) = AncestorRightClip(c, grownRight);
            if (clipDeficit > OverflowTolerancePx)
                rows.Add(Row(culture, form, c.Name, c.GetType().Name, c.Text, c.Font, c.Width, c.Width + growth, clipDeficit,
                    clipDeficit > OverflowErrorPx ? "Error" : "Warning", $"ClippedByParent:{clipper}"));
        }
        else if (c is Label or LinkLabel)
        {
            // 固定サイズの Label は幅内で折り返す。「折り返した行数 × 行高 がラベル高さを超えるか」で切れを見る。
            if (!HasWrapOpportunity(c.Text)) return;
            var one = TextRenderer.MeasureText(c.Text, c.Font);
            int avail = Math.Max(1, c.Width);
            int lines = Math.Max(1, (int)Math.Ceiling(one.Width * inflate / avail));
            int neededH = lines * one.Height;
            int deficit = neededH - c.Height;
            if (deficit <= OverflowTolerancePx) return;
            rows.Add(Row(culture, form, c.Name, c.GetType().Name, c.Text, c.Font, c.Height, neededH, deficit,
                deficit > OverflowErrorPx ? "Error" : "Warning", $"WrapsBeyondHeight({lines}lines)"));
        }
        else
        {
            // 固定サイズの Button/CheckBox/RadioButton/GroupBox: 1 行テキストが幅に収まるか。
            int neededW = (int)Math.Ceiling(TextRenderer.MeasureText(c.Text, c.Font).Width * inflate) + glyph;
            int deficit = neededW - c.Width;
            if (deficit <= OverflowTolerancePx) return;
            rows.Add(Row(culture, form, c.Name, c.GetType().Name, c.Text, c.Font, c.Width, neededW, deficit,
                deficit > OverflowErrorPx ? "Error" : "Warning", "TextClipped"));
        }
    }

    private static void DiagnoseToolStripItem(ToolStripItem it, string form, string culture, double inflate, List<string> rows)
    {
        if (!it.Visible || string.IsNullOrWhiteSpace(it.Text) || it.Width <= 0) return;
        if (it.AutoSize) return; // auto-size 項目は内容に合わせるので切れない。固定幅 (status label 等) のみ対象。
        if (it.DisplayStyle is ToolStripItemDisplayStyle.Image or ToolStripItemDisplayStyle.None) return; // テキスト非表示

        int imageW = it.Image != null && it.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText ? it.Image.Width + 4 : 0;
        int neededW = (int)Math.Ceiling(TextRenderer.MeasureText(it.Text, it.Font).Width * inflate) + imageW + 12;
        int deficit = neededW - it.Width;
        if (deficit <= OverflowTolerancePx) return;
        rows.Add(Row(culture, form, it.Name, it.GetType().Name, it.Text, it.Font, it.Width, neededW, deficit,
            deficit > OverflowErrorPx ? "Error" : "Warning", "ToolStripTextClipped"));
    }

    // c の右端が、いずれかの祖先のクライアント右端で切れるか (＝親にクリップされるか) を遡って判定。
    private static (int deficit, string clipper) AncestorRightClip(Control c, int grownRight)
    {
        int right = grownRight;
        for (var p = c.Parent; p != null; p = p.Parent)
        {
            if (p is ScrollableControl { AutoScroll: true }) return (0, "");
            int deficit = right - p.ClientSize.Width;
            if (!p.AutoSize)
                return deficit > OverflowTolerancePx ? (deficit, p.Name) : (0, "");
            right += p.Left; // p は AutoSize で c を吸収。c 自身の右端を p の親座標へ変換して継続。
        }
        return (0, "");
    }

    // テキストが (幅不足時に) 複数行へ折り返せる改行機会を持つか。空白で可、CJK/かなは 2 文字以上で可。
    private static bool HasWrapOpportunity(string text)
    {
        if (string.IsNullOrEmpty(text)) return false;
        int cjk = 0;
        foreach (char ch in text)
        {
            if (char.IsWhiteSpace(ch)) return true;
            if (ch >= 0x3040) cjk++; // ひらがな以降 (かな/CJK 漢字/ハングル等) は文字間で折り返し可
        }
        return cjk >= 2;
    }

    // テキストが翻訳されうる語を含むか (擬似ローカライズの伸長予測の前提)。
    private static bool IsLikelyTranslatable(string text)
    {
        if (string.IsNullOrEmpty(text)) return false;
        int run = 0;
        foreach (char ch in text)
        {
            if (ch >= 0x3040) return true; // かな/CJK 漢字/ハングル等は短くても語
            if (char.IsLetter(ch)) { if (++run >= 3) return true; }
            else run = 0;
        }
        return false;
    }

    private static string Row(string culture, string form, string ctrl, string type, string text, Font font,
        int actualW, int neededW, int deficit, string severity, string reason)
        => string.Join("\t", culture, form, ctrl, type,
            (text ?? "").Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' '),
            $"{font.Name} {font.Size:0.##}pt", actualW, neededW, deficit, severity, reason);
}
