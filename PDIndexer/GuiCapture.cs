using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PDIndexer;

/// <summary>
/// 260601Cl 追加: GitHub Pages マニュアル用に PDIndexer の全フォームを構築して PNG 一括保存する開発者向けツール。
/// 260820Cl: ReciPro からの移植コピー (GuiCapture.cs 731 行 + GuiCapture.Diagnose.cs 257 行) を廃し、
/// Crystallography.Controls の共通ハーネス <see cref="GuiCaptureHarness"/> の派生へ移行した。ここに残るのは PDIndexer 固有部のみ:
/// --capture 中フラグ (IsCapturing)・FormMain 所有の配線済み子フォームの列挙と可視状態の復元・代表プロファイルの読込・
/// GuiCaptureTargets.cs の SetupCaptureTargets 呼び出し・ToolStrip の再描画強制。
/// これにより ReciPro 側で入った修正 (メニューが閉じて背後が写る対策 260726 / DiagnoseWidget・DiagnoseContainer の
/// 複合コントロール診断 / 文字溢れ報告 / --capture-form) が PDIndexer でもそのまま使える。
/// 起動: <c>PDIndexer.exe --capture [出力ディレクトリ] [カルチャ]</c> / <c>--diagnose [カルチャ] [水増し%]</c> /
/// <c>--capture-form &lt;Type&gt; &lt;out.png&gt; [カルチャ]</c>。通常起動 (引数なし) では一切実行されない。
/// </summary>
// 旧: internal static partial class GuiCapture (Run / Diagnose は static。FormMain.cs は GuiCapture.ForcedUICulture / GuiCapture.IsCapturing を参照)
internal sealed class GuiCapture : GuiCaptureHarness
{
    /// <summary>
    /// 260601Cl 追加: --capture / --diagnose 実行中フラグ。FormMain_Load が起動時の初期ダイアログ (CommonDialog) を Show しないように
    /// 参照する。初期ダイアログは (0,0) に出て、--capture で (0,0) に置いた FormMain のメニュー/ツールバー左上を覆い、
    /// 閉じても再描画が間に合わずグレーで写り込むため、キャプチャ中はそもそも表示しない。
    /// 260820Cl: 旧 Run / Diagnose 冒頭の代入を、ハーネス派生のインスタンス生成時 (= Program.cs が各モードに入った時点) へ移した。
    /// </summary>
    public static bool IsCapturing;

    public GuiCapture() { IsCapturing = true; }

    protected override Type MainFormType => typeof(FormMain);

    /// <summary>
    /// FormMain が ctor 引数 (formMain) で配線して保持している子フォーム (toolbar のツール窓 + FormMacro)。
    /// これらは reflection 単独生成では formMain=null で正しく描画されないため、配線済みインスタンスを撮る。
    /// </summary>
    protected override IEnumerable<Form> EnumerateDependentForms(Form main) => ((FormMain)main).EnumerateCaptureDependentForms();

    // 子フォームは FormMain 所有なので閉じずに元の可視状態へ戻す (後続の撮影や FormMain の破棄を妨げない)。
    protected override bool CloseDependentFormAfterCapture => false;
    private readonly Dictionary<Form, bool> wasVisible = new();
    protected override void BeforeDependentFormCapture(Form child, Form main, Action<string> trace) => wasVisible[child] = child.Visible;
    protected override void AfterDependentFormCapture(Form child, Form main, Action<string> trace)
    {
        try { child.TopMost = false; if (wasVisible.TryGetValue(child, out var v) && !v) child.Visible = false; }
        catch { /* 可視状態復帰の例外は無視 */ }
    }

    /// <summary>撮影直前に menuStrip / toolStrip を確実に描画する (DoEvents だけだと FormMain 左上が未描画になる対策)。</summary>
    protected override void BeforeFullFormCapture(Form form, Action<string> trace) => ForceToolStripRepaint(form);

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

    /// <summary>
    /// 260601Cl: フォームを Show しただけではマニュアル用の代表状態にならない画面を、撮影直前に整える。
    /// FormMain は代表結晶を選択して回折線を描く。FormMacro (Controls 所有) は基底がサンプルマクロを表示する。
    /// </summary>
    // 旧: private static void PrepareSpecialCaptureState(Form form, Action<string> trace)
    protected override void PrepareCaptureState(Form form, Action<string> trace)
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
                    // 260626Cl: 代表プロファイル (references/FE01-03.pdi、作者指定の見栄えの良い fayalite 実測データ) を読み込み、
                    //   fayalite の回折線を重ねた状態で撮る。references/ は git 管理外なので、無ければ null → プロファイルなし (軸のみ＋回折線)。
                    //   260820Cl: 旧 RepresentativeProfilePath() → ハーネス共通の FindReferenceFile へ。
                    var selected = mainForm.PrepareCaptureRepresentativeState(FindReferenceFile("FE01-03.pdi"));
                    trace($"FormMain\tINFO\tcapture crystal={(selected ? mainForm.CurrentCrystal?.Name : "not set")}");
                    break;
                default:
                    base.PrepareCaptureState(form, trace); // 260820Cl: FormMacro 等 Controls 所有フォームは基底が扱う
                    break;
            }
        }
        catch (Exception ex)
        {
            trace($"{form.GetType().Name}\tWARN\tPrepareCapture: {ex.GetType().Name}: {ex.Message}");
        }
    }

    // 260820Cl 削除: 以下は GuiCaptureHarness (Crystallography.Controls) へ集約した (ReciPro 版と同一/旧版の複製だった)。
    //   Run / CaptureForm / BringToFront / Settle / CaptureScreen / GetWindowVisualBounds / GetScreenLocation / CaptureControlCrops /
    //   CaptureToolStripItemCrops / EnumerateToolStripItems / EnsureToolStripCaptureHostVisible / EnsureAncestorDropDownsVisible /
    //   CloseToolStripDropDowns / BuildToolStripItemCapturePath / EnsureAncestorTabsSelected / IsEffectivelyVisible / RenderHiddenControl /
    //   BuildCapturePath / SanitizeFileName / IsSolidColor / EnumerateControls / DefaultAutoCaptureDir (→ DefaultOutputDir) / RepoRoot /
    //   RepresentativeProfilePath (→ FindReferenceFile) / TryShowMacroSamples (→ FormMacro.PrepareCaptureForGuiAudit) /
    //   GuiCapture.Diagnose.cs の Diagnose 一式 (ハーネス版は DiagnoseWidget / DiagnoseContainer 等 260726Cl の拡張込み)
    //   挙動差: (1) --capture の順序が「FormMain → 依存子フォーム → 残りの単独フォーム」から「FormMain → 単独フォーム → 依存子フォーム」に
    //   なった (結果は同じ)。(2) 終了時に FormMain を Close() せず Dispose() だけにした (Close は FormClosing → レジストリ書込で
    //   --capture の強制カルチャを焼き付けるため)。
}
