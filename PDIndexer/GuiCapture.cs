using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PDIndexer;

/// <summary>
/// 260601Cl 追加: GitHub Pages マニュアル用に PDIndexer の全フォームを構築して PNG 一括保存する開発者向けツール。
/// ReciPro の GuiCapture と同じ思想・同じ呼び出し方・同じ命名規則で実装している (PDIndexer は OpenGL を使わないため GL 描画待ちは除去)。
/// 起動:
///   <c>PDIndexer.exe --capture [出力ディレクトリ] [カルチャ(en/ja)]</c>   (出力先を明示)
///   <c>PDIndexer.exe --capture [カルチャ(en/ja)]</c>                      (出力先省略=既定の docs/src/assets/cap-*-auto)
/// 各フォームを画面内 (0,0) に最前面表示し、<see cref="Graphics.CopyFromScreen(Point, Point, Size)"/> で実描画をそのまま撮る。
/// 通常起動 (引数なし) では一切実行されない。
/// </summary>
internal static partial class GuiCapture //260625Cl partial 化: --diagnose を GuiCapture.Diagnose.cs に分割 (多言語化 Phase 3)
{
    /// <summary>
    /// 260601Cl: --capture で言語を強制指定 (en/ja) した場合のカルチャ。
    /// FormMain ctor がレジストリ値で CurrentUICulture を上書きするため、フォーム構築前に Program 側で再設定する。
    /// </summary>
    public static System.Globalization.CultureInfo ForcedUICulture;

    /// <summary>
    /// 260601Cl 追加: --capture 実行中フラグ。FormMain_Load が起動時の初期ダイアログ (CommonDialog) を Show しないように
    /// 参照する。初期ダイアログは (0,0) に出て、--capture で (0,0) に置いた FormMain のメニュー/ツールバー左上を覆い、
    /// 閉じても再描画が間に合わずグレーで写り込むため、キャプチャ中はそもそも表示しない。
    /// </summary>
    public static bool IsCapturing;

    // 260601Cl: CopyFromScreen 方式の待機時間。--capture は Application.Run を回さず DoEvents で描画を進めるため、
    // Show / タブ切替 / 結晶選択の後に「描画が画面へ反映される」まで明示的に待ってから撮る必要がある。
    private const int FirstPaintSettleMs = 350; // 初回表示後、フォーム全体が描画されるまでの待ち
    private const int PrepareSettleMs = 450;    // 代表状態 (結晶チェック→再描画) の反映待ち
    private const int TabSwitchSettleMs = 180;  // クロップ時にタブを切り替えた後の再描画待ち

    /// <summary>260626Cl 追加: 実行ファイル (bin/...) からリポルート (...\PDIndexer、docs/ や references/ を持つ) を辿る。辿れなければ null。</summary>
    private static DirectoryInfo RepoRoot()
    {
        var dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        while (dir != null && dir.Name != "bin")
            dir = dir.Parent;
        return dir?.Parent?.Parent;  // bin → ...\PDIndexer\PDIndexer → ...\PDIndexer (リポルート)
    }

    /// <summary>260626Cl 追加: --capture 時に読み込む代表プロファイル (references/FE01-03.pdi、作者指定の見栄えの良い fayalite 実測データ)。
    /// references/ は git 管理外なので、存在しなければ null を返し、呼び出し側 (FormMain.PrepareCaptureRepresentativeState) は
    /// プロファイルなし (軸のみ＋fayalite 回折線) で撮る。</summary>
    private static string RepresentativeProfilePath()
    {
        var root = RepoRoot();
        if (root == null) return null;
        var path = Path.Combine(root.FullName, "references", "FE01-03.pdi");
        return File.Exists(path) ? path : null;
    }

    /// <summary>260601Cl: --capture の出力先を省略したときの既定ディレクトリ (docs/src/assets/cap-{culture}-auto)。
    /// 実行ファイル (bin/...) からリポルート (...\PDIndexer) を辿れなければ temp にフォールバックする。</summary>
    private static string DefaultAutoCaptureDir()
    {
        var culture = ForcedUICulture ?? System.Threading.Thread.CurrentThread.CurrentUICulture;
        // 260625Cl 変更: en/ja 固定から SupportedCultures 駆動の cap-{culture}-auto へ (多言語化 Phase 0、ReciPro と同命名)。
        //   旧: var langDir = culture.Name == "ja" ? "cap-ja-auto" : "cap-en-auto";
        var langDir = $"cap-{Crystallography.SupportedCultures.Resolve(culture.Name).Name}-auto";
        var repoRoot = RepoRoot();  // 260626Cl: bin→リポルート探索を RepoRoot() に集約
        return repoRoot != null
            ? Path.Combine(repoRoot.FullName, "docs", "src", "assets", langDir)
            : Path.Combine(Path.GetTempPath(), $"pdindexer-capture-{DateTime.Now:yyyyMMdd-HHmmss}-{langDir}"); //260712Cl 補間文字列化
    }

    /// <summary>
    /// --capture の本体。FormMain を構築・表示して代表状態にし、FormMain と FormMain が保持する配線済み子フォーム
    /// (Crystal Parameter / Profile Parameter / EOS / Fitting / Sequential Analysis ... と FormMacro) をフォーム単位の PNG で保存する。
    /// 子フォームは ctor 引数 (formMain) で配線されるため reflection 単独生成では撮れない。FormMain 経由で配線済みインスタンスを撮る。
    /// </summary>
    public static void Run(string outDir)
    {
        IsCapturing = true; // FormMain_Load に初期ダイアログを出させない (FormMain 左上の覆い込み防止)
        outDir ??= DefaultAutoCaptureDir();
        Directory.CreateDirectory(outDir);

        var log = new List<string>();
        void Trace(string s)
        {
            var line = $"{DateTime.Now:HH:mm:ss.fff}\t{s}";
            log.Add(line);
            Console.WriteLine(line);
        }

        // フォームの Load / VisibleChanged 等で投げられた例外を握りつぶす (未処理例外のモーダルダイアログでハングしないため)。
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => Trace($"\tThreadException\t{e.Exception.GetType().Name}: {e.Exception.Message}");

        Trace($"capture start -> {outDir}");
        Trace("==================================================================================");
        Trace("[CAUTION] Capture uses CopyFromScreen. Keep the screen VISIBLE and FOCUSED until done.");
        Trace("          Over Remote Desktop (RDP): keep the RDP window in the foreground, and do NOT");
        Trace("          minimize or disconnect. A hidden/minimized session yields blank/failed shots.");
        Trace("[注意] 画面キャプチャ中はウィンドウを前面・表示のまま保ってください。RDP の場合は RDP ウィンドウを");
        Trace("       前面に出したまま最小化・切断しないでください (非表示だと撮影が失敗/真っ黒になります)。");
        Trace("==================================================================================");

        // 起動時に画面が取得可能か 8x8 で試し、不可ならその場で警告する (全フォーム失敗の前に気付けるように)。
        using (var probe = CaptureScreen(new Rectangle(0, 0, 8, 8), null, Trace, "screen-probe"))
            if (probe == null)
                Trace("[CAUTION] Screen capture is currently UNAVAILABLE. Bring the (RDP) session to the foreground now.");

        int ok = 0, fail = 0;
        var capturedTypes = new HashSet<Type>();

        // FormMain を構築・表示 (Show で FormMain_Load が走り、全子フォームが配線される)。代表状態 (結晶チェック) は CaptureForm 内で行う。
        FormMain main = null;
        try
        {
            if (ForcedUICulture != null)
                System.Threading.Thread.CurrentThread.CurrentUICulture = ForcedUICulture;
            main = new FormMain();
            CaptureForm(main, nameof(FormMain), outDir, Trace, closeAfterCapture: false);
            capturedTypes.Add(typeof(FormMain));
            ok++;
        }
        catch (Exception ex)
        {
            fail++;
            Trace($"FormMain\tFAIL\t{ex.GetType().Name}: {ex.Message}");
        }

        // FormMain が保持する配線済み子フォーム (toolbar のツール窓 + FormMacro) を撮る。
        if (main != null)
        {
            foreach (var child in main.EnumerateCaptureDependentForms())
            {
                if (child == null || child.IsDisposed)
                    continue;
                try
                {
                    var wasVisible = child.Visible;
                    CaptureForm(child, child.GetType().Name, outDir, Trace, closeAfterCapture: false);
                    capturedTypes.Add(child.GetType());
                    ok++;
                    // 子フォームは FormMain 所有なので閉じずに元の可視状態へ戻す (後続の撮影や FormMain.Close を妨げない)。
                    try { child.TopMost = false; if (!wasVisible) child.Visible = false; } catch { /* 可視状態復帰の例外は無視 */ }
                }
                catch (Exception ex)
                {
                    fail++;
                    Trace($"{child.GetType().Name}\tFAIL\t{ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // 追加で、parameterless ctor を持ち、かつまだ撮っていない単独フォーム (FormAboutMe 等) を reflection で撮る。
        // FormMain 所有の子フォーム型は capturedTypes 済みなので重複・空生成での上書きを避けられる。
        foreach (var type in typeof(FormMain).Assembly.GetTypes()
                     .Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract
                                 && t.GetConstructor(Type.EmptyTypes) != null && !capturedTypes.Contains(t))
                     .OrderBy(t => t.Name))
        {
            Form form = null;
            try
            {
                if (ForcedUICulture != null)
                    System.Threading.Thread.CurrentThread.CurrentUICulture = ForcedUICulture;
                form = (Form)Activator.CreateInstance(type);
                CaptureForm(form, type.Name, outDir, Trace, closeAfterCapture: true);
                ok++;
            }
            catch (Exception ex)
            {
                fail++;
                Trace($"{type.Name}\tFAIL\t{ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                try { form?.Dispose(); } catch { /* 破棄時例外は無視 */ }
            }
        }

        try { main?.Close(); main?.Dispose(); } catch { /* 破棄時例外は無視 */ }

        Trace($"done: ok={ok} fail={fail}");
        File.WriteAllLines(Path.Combine(outDir, "_capture-log.tsv"), log);
    }

    /// <summary>
    /// 1 つの Form を画面内に最前面表示して撮影する。Show → 最前面化 → 描画待ち → 代表状態準備 → 再描画待ち の後、
    /// ウィンドウ全体を CopyFromScreen で撮り、続けて Capture=true のコントロール/メニュー単位クロップを撮る。
    /// </summary>
    private static void CaptureForm(Form form, string name, string outDir, Action<string> trace, bool closeAfterCapture = true)
    {
        form.StartPosition = FormStartPosition.Manual;
        form.ShowInTaskbar = false;
        form.Location = new Point(0, 0); // CopyFromScreen で実描画を撮るため画面内に表示する
        try { form.Show(); }
        catch (Exception ex) { trace($"{name}\tWARN\tShow: {ex.GetType().Name}: {ex.Message}"); }

        BringToFront(form);
        Settle(form, FirstPaintSettleMs);
        PrepareSpecialCaptureState(form, trace); // FormMain は代表結晶を選択、FormMacro はサンプル表示
        Settle(form, PrepareSettleMs);

        // prepare 中に DoEvents で他アプリ (IDE 等) が前面を奪うことがあるので撮影直前に再度最前面化する。
        BringToFront(form);
        Settle(form, TabSwitchSettleMs);

        ForceToolStripRepaint(form); // 撮影直前に menuStrip/toolStrip を確実に描画する (DoEvents だけだと FormMain 左上が未描画になる対策)

        var bounds = GetWindowVisualBounds(form); // タイトルバー等の非クライアント領域も含むウィンドウ全体 (影は除く)
        var bmp = CaptureScreen(bounds, form, trace, name, retryIfSolid: true);
        var captured = bmp != null;
        if (captured)
            using (bmp) bmp.Save(Path.Combine(outDir, name + ".png"), ImageFormat.Png);
        else
            trace($"{name}\tWARN\tfull-form capture failed (RDP screen hidden/minimized?)");
        var cropCount = CaptureControlCrops(form, name, outDir, trace);
        var menuCount = CaptureToolStripItemCrops(form, name, outDir, trace);
        trace($"{name}\t{(captured ? "OK" : "PARTIAL")}\t{bounds.Width}x{bounds.Height}\tCrops={cropCount}\tMenus={menuCount}");

        if (closeAfterCapture)
        {
            form.TopMost = false; // 後続フォームの最前面化を妨げないよう閉じる前に解除
            form.Close();
        }
    }

    /// <summary>
    /// 260601Cl: 撮影直前に menuStrip / toolStrip を確実に描画する。--capture は Application.Run を回さず DoEvents だけで
    /// 進めるため、ToolStripPanel 上の menuStrip / toolStrip が初回描画されず左上がグレーで写ることがある (FormMain で顕著)。
    /// ウィンドウサイズを 1px 変えて戻す (WM_SIZE で ToolStripPanel が再レイアウト・再描画される) → 各 ToolStrip を Refresh する。
    /// </summary>
    private static void ForceToolStripRepaint(Form form)
    {
        try
        {
            var toolStrips = EnumerateControls(form).OfType<ToolStrip>().ToList();
            if (toolStrips.Count == 0) return; // ToolStrip を持たないフォームは何もしない

            // 注: TopToolStripPanel 上の menuStrip / 先頭 ToolStripButton (FormMain) は、ウィンドウが真にフォアグラウンドで
            // フォーカスを持つ実セッションでないと描画されないことがある (ヘッドレス/非フォアグラウンドだとグレーになる)。
            // GuiCapture は本来「画面を前面・表示のまま」実行する開発者ツール (Run 冒頭の CAUTION 参照) なので、実機では描画される。
            // ここではフォアグラウンドの実機向けに、サイズ変更で WM_SIZE 再レイアウトを促し ToolStrip を Refresh しておく。
            var sz = form.Size;
            form.Size = new Size(sz.Width, sz.Height + 1);
            Application.DoEvents();
            form.Size = sz;
            Application.DoEvents();

            foreach (var ts in toolStrips)
            {
                ts.PerformLayout();
                ts.Refresh();
            }
            form.Update();
            Application.DoEvents();
            System.Threading.Thread.Sleep(60);
            Application.DoEvents();
        }
        catch { /* 撮影直前の再描画失敗は無視 (最善努力) */ }
    }

    /// <summary>260601Cl: CopyFromScreen の前に対象フォームを通常表示・最前面・アクティブ化する。</summary>
    private static void BringToFront(Form form)
    {
        try
        {
            if (form.WindowState != FormWindowState.Normal)
                form.WindowState = FormWindowState.Normal;
            form.TopMost = true; // 無人実行中に他ウィンドウが被って映り込むのを防ぐ
            form.BringToFront();
            form.Activate();
            if (form.IsHandleCreated)
                SetForegroundWindow(form.Handle); // RDP でフォーカスが他へ移っても撮影対象を前面へ取り戻す
        }
        catch { /* 表示状態変更時の例外は無視 (撮影は後段で最善努力) */ }
    }

    /// <summary>260601Cl: 指定ミリ秒のあいだ DoEvents を回して描画を画面へ反映させる (--capture は Application.Run を回さないため)。</summary>
    private static void Settle(Form form, int ms)
    {
        try { form.Refresh(); } catch { /* Refresh 時例外は無視 */ }
        var until = Environment.TickCount + Math.Max(ms, 0);
        do
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(15);
        } while (Environment.TickCount < until);
    }

    private const int CaptureMaxAttempts = 5; // CopyFromScreen 失敗時の最大試行回数

    /// <summary>
    /// 260601Cl: 画面上の指定矩形を CopyFromScreen で撮ってビットマップ化する。RDP セッションが非表示・最小化・フォーカス喪失だと
    /// CopyFromScreen は例外を投げたり全面単色を返したりするので、失敗時は foregroundForm を取り直して数回まで再試行する。
    /// 最終的に撮れなければ null を返す (1 枚の失敗で全体を止めない)。
    /// </summary>
    private static Bitmap CaptureScreen(Rectangle screenRect, Form foregroundForm = null, Action<string> trace = null, string label = null, bool retryIfSolid = false)
    {
        int w = Math.Max(screenRect.Width, 1), h = Math.Max(screenRect.Height, 1);
        for (int attempt = 1; attempt <= CaptureMaxAttempts; attempt++)
        {
            Bitmap bmp = null;
            try
            {
                bmp = new Bitmap(w, h);
                using (var g = Graphics.FromImage(bmp))
                    g.CopyFromScreen(screenRect.Location, Point.Empty, new Size(w, h));

                if (!retryIfSolid || !IsSolidColor(bmp))
                    return bmp; // 成功

                bmp.Dispose(); // 全面単色 = RDP で実描画が読めていない可能性。破棄して再試行。
                trace?.Invoke($"{label}\tWARN\tCopyFromScreen blank attempt {attempt}/{CaptureMaxAttempts}");
            }
            catch (Exception ex)
            {
                bmp?.Dispose();
                trace?.Invoke($"{label}\tWARN\tCopyFromScreen attempt {attempt}/{CaptureMaxAttempts}: {ex.GetType().Name}: {ex.Message}");
            }

            if (attempt == CaptureMaxAttempts)
                break;
            if (foregroundForm != null)
                BringToFront(foregroundForm);
            System.Threading.Thread.Sleep(400 * attempt); // 線形バックオフ
            Application.DoEvents();
        }
        return null;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    private struct RECT { public int Left, Top, Right, Bottom; }

    [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
    private static extern int DwmGetWindowAttribute(IntPtr hwnd, int attr, out RECT rect, int size);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    private const int DWMWA_EXTENDED_FRAME_BOUNDS = 9;

    /// <summary>
    /// 260601Cl: CopyFromScreen で撮るウィンドウ全体の矩形を求める。WinForms の Bounds は Win10/11 の不可視リサイズ枠を含むため、
    /// DWM の実視覚矩形 (DWMWA_EXTENDED_FRAME_BOUNDS、影は除く) が取れればそれを使い、失敗時のみ Bounds に戻す。
    /// </summary>
    private static Rectangle GetWindowVisualBounds(Form form)
    {
        try
        {
            if (form.IsHandleCreated
                && DwmGetWindowAttribute(form.Handle, DWMWA_EXTENDED_FRAME_BOUNDS, out var r, System.Runtime.InteropServices.Marshal.SizeOf<RECT>()) == 0
                && r.Right > r.Left && r.Bottom > r.Top)
                return new Rectangle(r.Left, r.Top, r.Right - r.Left, r.Bottom - r.Top);
        }
        catch { /* P/Invoke 失敗時は Bounds にフォールバック */ }
        return form.Bounds;
    }

    /// <summary>260601Cl: コントロールの実際の左上スクリーン座標を求める。</summary>
    private static Point GetScreenLocation(Control control)
        => control is Form ? control.Bounds.Location
         : control.Parent != null ? control.Parent.PointToScreen(control.Location)
         : control.PointToScreen(Point.Empty);

    /// <summary>
    /// 260601Cl: Designer で <c>Capture=true</c> を付けたコントロール単位のクロップを、対話 UI を出さずに生成する。
    /// 命名は手動キャプチャと同じ規則 (form.Name 起点、SplitterPanel/ToolStripPanel/無名は除外)。
    /// Capture フラグ判定だけ <see cref="Crystallography.Controls.CaptureExtender.IsCaptureEnabled"/> に依存する。
    /// </summary>
    private static int CaptureControlCrops(Form form, string name, string outDir, Action<string> trace)
    {
        var count = 0;
        foreach (var control in EnumerateControls(form))
        {
            if (control is Form || string.IsNullOrEmpty(control.Name) || control.IsDisposed || control.Width <= 0 || control.Height <= 0)
                continue;
            if (!Crystallography.Controls.CaptureExtender.IsCaptureEnabled(control))
                continue;

            try
            {
                if (EnsureAncestorTabsSelected(control))
                    Settle(form, TabSwitchSettleMs);

                Bitmap crop;
                if (!IsEffectivelyVisible(form, control))
                {
                    crop = RenderHiddenControl(form, control, trace);
                    if (crop == null)
                        continue;
                }
                else
                {
                    var region = control is TabPage { Parent: TabControl tabControl } ? (Control)tabControl : control; //260712Cl プロパティパターン化
                    region.Refresh();
                    Settle(form, TabSwitchSettleMs);
                    crop = CaptureScreen(new Rectangle(GetScreenLocation(region), region.Size), form, trace, $"{name}.{control.Name}", retryIfSolid: true);
                    if (crop == null)
                        continue;
                }

                using (crop)
                {
                    if (IsSolidColor(crop))
                        continue;

                    var fileName = SanitizeFileName(BuildCapturePath(form, control)) + ".png";
                    crop.Save(Path.Combine(outDir, fileName), ImageFormat.Png);
                    count++;
                }
            }
            catch (Exception ex)
            {
                trace($"{name}\tWARN\tcrop {control.Name}: {ex.GetType().Name}: {ex.Message}");
            }
        }
        return count;
    }

    /// <summary>
    /// 260601Cl: Designer で <c>Capture=true</c> を付けた ToolStripItem (メニュー項目等) のドロップダウンを非対話で撮る。
    /// 祖先含めて ShowDropDown し、開いた DropDown / ContextMenuStrip / Owner ToolStrip を CopyFromScreen する。
    /// </summary>
    private static int CaptureToolStripItemCrops(Form form, string name, string outDir, Action<string> trace)
    {
        var count = 0;
        foreach (var item in EnumerateToolStripItems(form))
        {
            if (string.IsNullOrEmpty(item.Name) || !Crystallography.Controls.CaptureExtender.IsCaptureEnabled(item))
                continue;

            try
            {
                var host = EnsureToolStripCaptureHostVisible(item);
                if (host == null || host.IsDisposed || host.Width <= 0 || host.Height <= 0)
                    continue;

                host.Refresh();
                Application.DoEvents();
                System.Threading.Thread.Sleep(150);

                var crop = CaptureScreen(new Rectangle(host.PointToScreen(Point.Empty), host.Size), form, trace, $"{name}.{item.Name}");
                if (crop != null)
                    using (crop)
                        if (!IsSolidColor(crop))
                        {
                            var fileName = SanitizeFileName(BuildToolStripItemCapturePath(form, item)) + ".png";
                            crop.Save(Path.Combine(outDir, fileName), ImageFormat.Png);
                            count++;
                        }
            }
            catch (Exception ex)
            {
                trace($"{name}\tWARN\tmenu-crop {item.Name}: {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                try { CloseToolStripDropDowns(item); } catch { /* ドロップダウンのクローズ失敗は無視 */ }
            }
        }
        return count;
    }

    /// <summary>260601Cl: フォーム内の全 ToolStripItem を列挙する (Controls 配下の ToolStrip + designer field の ContextMenuStrip 等。ドロップダウン項目も再帰)。</summary>
    private static IEnumerable<ToolStripItem> EnumerateToolStripItems(Form form)
    {
        // 260712Cl 記法近代化: new + foreach + Add を ToHashSet() へ集約
        var toolStrips = EnumerateControls(form).OfType<ToolStrip>().ToHashSet();
        for (var type = form.GetType(); type != null; type = type.BaseType)
            foreach (var field in type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.DeclaredOnly))
                if (typeof(ToolStrip).IsAssignableFrom(field.FieldType) && field.GetValue(form) is ToolStrip ownedToolStrip)
                    toolStrips.Add(ownedToolStrip);

        var visited = new HashSet<ToolStripItem>();
        foreach (var toolStrip in toolStrips)
            foreach (var item in EnumerateToolStripItems(toolStrip.Items, visited))
                yield return item;
    }

    private static IEnumerable<ToolStripItem> EnumerateToolStripItems(ToolStripItemCollection items, HashSet<ToolStripItem> visited)
    {
        foreach (ToolStripItem item in items)
        {
            if (!visited.Add(item)) continue;
            yield return item;
            if (item is ToolStripDropDownItem dropDownItem && dropDownItem.HasDropDownItems)
                foreach (var child in EnumerateToolStripItems(dropDownItem.DropDownItems, visited))
                    yield return child;
        }
    }

    /// <summary>260601Cl: 対象項目を撮るためのホスト (開いた DropDown / ContextMenuStrip / Owner ToolStrip) を可視化して返す。</summary>
    private static ToolStrip EnsureToolStripCaptureHostVisible(ToolStripItem item)
    {
        EnsureAncestorDropDownsVisible(item);

        if (item is ToolStripDropDownItem dropDownItem && dropDownItem.HasDropDownItems)
        {
            if (!dropDownItem.DropDown.Visible)
            {
                dropDownItem.ShowDropDown();
                dropDownItem.DropDown.Refresh();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }
            return dropDownItem.DropDown;
        }

        if (item.Owner is ContextMenuStrip contextMenuStrip)
        {
            if (!contextMenuStrip.Visible && contextMenuStrip.SourceControl != null)
            {
                contextMenuStrip.Show(contextMenuStrip.SourceControl, new Point(0, contextMenuStrip.SourceControl.Height));
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }
            return contextMenuStrip;
        }

        return item.Owner is ToolStripDropDown toolStripDropDown ? toolStripDropDown : item.Owner;
    }

    /// <summary>260601Cl: 対象項目の祖先ドロップダウンを順に開く (ネストしたサブメニュー対応)。</summary>
    private static void EnsureAncestorDropDownsVisible(ToolStripItem item)
    {
        if (item.OwnerItem is not ToolStripDropDownItem ownerItem) return;
        EnsureAncestorDropDownsVisible(ownerItem);
        if (!ownerItem.DropDown.Visible)
        {
            ownerItem.ShowDropDown();
            ownerItem.DropDown.Refresh();
            Application.DoEvents();
            System.Threading.Thread.Sleep(200);
        }
    }

    /// <summary>260601Cl: 撮影のために開いたドロップダウンを子→親の順に閉じる。</summary>
    private static void CloseToolStripDropDowns(ToolStripItem item)
    {
        for (var current = item; current != null; current = current.OwnerItem)
            if (current is ToolStripDropDownItem dropDownItem && dropDownItem.HasDropDownItems && dropDownItem.DropDown.Visible)
                dropDownItem.HideDropDown();
        Application.DoEvents();
    }

    /// <summary>260601Cl: ToolStripItem のキャプチャ用パス (= クロップのファイル名 stem)。owner ToolStrip までの Control パスに、項目の OwnerItem 連鎖の名前を "." 連結する。</summary>
    private static string BuildToolStripItemCapturePath(Form form, ToolStripItem item)
    {
        var segments = new List<string>();
        for (var current = item; current != null; current = current.OwnerItem)
            segments.Add(string.IsNullOrEmpty(current.Name) ? current.GetType().Name : current.Name);
        segments.Reverse();

        var top = item;
        while (top.OwnerItem != null)
            top = top.OwnerItem;
        var prefix = top.Owner != null ? BuildCapturePath(form, top.Owner) : form.Name;
        return prefix + "." + string.Join(".", segments);
    }

    /// <summary>260601Cl: コントロールの祖先 TabPage を順に選択し、クロップ時に可視化する。いずれかのタブ選択を変更したら true。</summary>
    private static bool EnsureAncestorTabsSelected(Control control)
    {
        var changed = false;
        for (var c = control; c != null; c = c.Parent)
        {
            if (c is TabPage tabPage && tabPage.Parent is TabControl tabControl)
            {
                if (tabControl.SelectedTab != tabPage)
                {
                    tabControl.SelectedTab = tabPage;
                    changed = true;
                }
                tabControl.BringToFront();
                tabControl.Refresh();
            }
        }
        return changed;
    }

    /// <summary>260601Cl: control から form まで全て Visible なら true。</summary>
    private static bool IsEffectivelyVisible(Form form, Control control)
    {
        for (var c = control; c != null && !ReferenceEquals(c, form); c = c.Parent)
            if (!c.Visible)
                return false;
        return true;
    }

    /// <summary>260601Cl: 既定で非表示の Capture=true コントロールを撮るため、自身と非表示の祖先を一時的に Visible=true・最前面にして撮り、撮影後に元の可視状態へ戻す。</summary>
    private static Bitmap RenderHiddenControl(Form form, Control control, Action<string> trace)
    {
        var toggled = new List<Control>();
        for (var c = control; c != null && c is not Form; c = c.Parent)
            if (!c.Visible) { c.Visible = true; toggled.Add(c); }
        try
        {
            control.BringToFront();
            control.PerformLayout();
            Settle(form, TabSwitchSettleMs);
            return CaptureScreen(new Rectangle(GetScreenLocation(control), control.Size), form, trace, control.Name);
        }
        finally
        {
            for (var i = toggled.Count - 1; i >= 0; i--)
                toggled[i].Visible = false;
            Application.DoEvents();
        }
    }

    /// <summary>260601Cl: コントロールのキャプチャ用パス (= クロップのファイル名 stem)。form.Name を起点に名前付き祖先の Name を "." で連結する (入れ物パネル/無名は除外)。</summary>
    private static string BuildCapturePath(Form form, Control control)
    {
        var segments = new List<string>();
        for (var c = control; c != null && !ReferenceEquals(c, form); c = c.Parent)
        {
            if (string.IsNullOrEmpty(c.Name) || c is SplitterPanel || c is ToolStripPanel || c is ToolStripContentPanel)
                continue;
            segments.Add(c.Name);
        }
        segments.Add(form.Name);
        segments.Reverse();
        return string.Join(".", segments);
    }

    /// <summary>260601Cl: ファイル名に使えない文字を '_' へ置換する。</summary>
    private static string SanitizeFileName(string name)
    {
        foreach (var ch in Path.GetInvalidFileNameChars())
            name = name.Replace(ch, '_');
        return name;
    }

    /// <summary>260601Cl: クロップ内側 (上下左右 5px 除外) が一様色なら true。Visible=false のパネル等で単色になったクロップの保存を防ぐ。</summary>
    private static bool IsSolidColor(Bitmap bmp)
    {
        const int margin = 5;
        int x0 = margin, y0 = margin, x1 = bmp.Width - margin, y1 = bmp.Height - margin;
        if (x1 <= x0 || y1 <= y0)
            return true;

        var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        try
        {
            var row = new int[bmp.Width];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0 + y0 * data.Stride, row, 0, bmp.Width);
            int first = row[x0];
            for (int y = y0; y < y1; y++)
            {
                System.Runtime.InteropServices.Marshal.Copy(data.Scan0 + y * data.Stride, row, 0, bmp.Width);
                for (int x = x0; x < x1; x++)
                    if (row[x] != first)
                        return false;
            }
            return true;
        }
        finally
        {
            bmp.UnlockBits(data);
        }
    }

    /// <summary>
    /// 260601Cl: フォームを Show しただけではマニュアル用の代表状態にならない画面を、撮影直前に整える。
    /// FormMain は代表結晶を選択して回折線を描き、FormMacro はサンプルマクロを表示する。
    /// </summary>
    private static void PrepareSpecialCaptureState(Form form, Action<string> trace)
    {
        // 260601Cl: Designer (.Designer.cs) を改変せず partial クラスで Capture 対象を宣言したフォーム (GuiCaptureTargets.cs) は、
        // 公開していない SetupCaptureTargets() を持つ。Show 後・クロップ前のここで反射呼び出しして対象を登録する。
        try
        {
            form.GetType().GetMethod("SetupCaptureTargets",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)
                ?.Invoke(form, null);
        }
        catch (Exception ex)
        {
            trace($"{form.GetType().Name}\tWARN\tSetupCaptureTargets: {ex.GetType().Name}: {ex.Message}");
        }

        try
        {
            switch (form)
            {
                case FormMain mainForm:
                    // 260626Cl: 代表プロファイル (references/FE01-03.pdi) を読み込み、fayalite の回折線を重ねた状態で撮る。
                    var selected = mainForm.PrepareCaptureRepresentativeState(RepresentativeProfilePath());
                    trace($"FormMain\tINFO\tcapture crystal={(selected ? mainForm.CurrentCrystal?.Name : "not set")}");
                    break;
                case Crystallography.Controls.FormMacro macroForm:
                    TryShowMacroSamples(macroForm, trace);
                    Application.DoEvents();
                    trace($"FormMacro\tINFO\tprepared macro editor (samples)");
                    break;
            }
        }
        catch (Exception ex)
        {
            trace($"{form.GetType().Name}\tWARN\tPrepareCapture: {ex.GetType().Name}: {ex.Message}");
        }
    }

    /// <summary>260601Cl: マクロエディタ (Crystallography.Controls.FormMacro) を「サンプルマクロ表示」状態にする (private な checkBoxSamples を reflection でトグル)。</summary>
    private static void TryShowMacroSamples(Form macroForm, Action<string> trace)
    {
        try
        {
            var field = macroForm.GetType().GetField("checkBoxSamples",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            if (field?.GetValue(macroForm) is CheckBox cb && cb.Visible && !cb.Checked)
                cb.Checked = true;
        }
        catch (Exception ex)
        {
            trace($"{macroForm.Name}\tWARN\tmacro samples toggle: {ex.GetType().Name}: {ex.Message}");
        }
    }

    /// <summary>260601Cl: フォーム配下の全コントロールを深さ優先で列挙する (Panel / SplitContainer / TabPage の奥のコントロールも拾う)。</summary>
    private static IEnumerable<Control> EnumerateControls(Control root)
    {
        yield return root;
        foreach (Control child in root.Controls)
            foreach (var descendant in EnumerateControls(child))
                yield return descendant;
    }
}
