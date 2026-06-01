using Crystallography.Controls;
using System.Windows.Forms;

namespace PDIndexer;

// 260601Cl 追加: GitHub Pages マニュアル用の --capture (GuiCapture) が拾う「コントロール単位クロップ」の対象を、
// Designer (.Designer.cs) を改変せず partial クラスのフィールドで指定する。
// CaptureExtender.IsCaptureEnabled は、対象コントロールの所有コンテナ (= このフォーム) の CaptureExtender フィールドを
// 反射で探して Capture フラグを判定するため、ここにフィールドを置けば Designer の Capture=true と同じ効果になる。
// GuiCapture は各フォームを Show した後・クロップ撮影の前に SetupCaptureTargets() を反射で呼ぶ (GuiCapture.PrepareSpecialCaptureState)。
// 粒度は ReciPro の docs と同程度 (groupBox / panel / tabPage 単位) を狙う。

partial class FormProfileSetting
{
    private CaptureExtender captureExtender;

    /// <summary>260601Cl 追加: Profile Parameter ウィンドウの処理ステップ (2θ offset / Mask / Smoothing / Bandpass / Background / Normalize) を個別クロップ対象にする。</summary>
    internal void SetupCaptureTargets()
    {
        if (captureExtender != null) return;
        captureExtender = new CaptureExtender();
        foreach (var c in new Control[]
                 {
                     panelTwoThetaOffset, panelMaskingMode, panelSmoothing, panelBandPassFilter,
                     panelBackgroundSubtraction, panelNormarizeIntensity,
                 })
            if (c != null) captureExtender.SetCapture(c, true);
    }
}

partial class FormEOS
{
    private CaptureExtender captureExtender;

    /// <summary>260601Cl 追加: Equation of States ウィンドウの代表的な物質グループ (Au / NaCl B1 / Periclase) を個別クロップ対象にする。</summary>
    internal void SetupCaptureTargets()
    {
        if (captureExtender != null) return;
        captureExtender = new CaptureExtender();
        foreach (var c in new Control[] { groupBoxGold, groupBoxNaClB1, groupBoxPericlase })
            if (c != null) captureExtender.SetCapture(c, true);
    }
}

partial class FormFitting
{
    private CaptureExtender captureExtender;

    /// <summary>260601Cl 追加: Fitting ウィンドウの主要グループ (各 groupBox) と Pattern Decomposition を個別クロップ対象にする。</summary>
    internal void SetupCaptureTargets()
    {
        if (captureExtender != null) return;
        captureExtender = new CaptureExtender();
        foreach (var c in new Control[]
                 {
                     groupBox1, groupBox2, groupBox3, groupBox4, groupBox5,
                     flowLayoutPanelPatternDecomposition,
                 })
            if (c != null) captureExtender.SetCapture(c, true);
    }
}

partial class FormSequentialAnalysis
{
    private CaptureExtender captureExtender;

    /// <summary>260601Cl 追加: Sequential Analysis の各出力タブ (2θ / d / FWHM / Intensity / Singh / Cell constants / Pressure) を個別クロップ対象にする (= 親 TabControl をタブ込みで撮る)。</summary>
    internal void SetupCaptureTargets()
    {
        if (captureExtender != null) return;
        captureExtender = new CaptureExtender();
        foreach (var c in new Control[]
                 {
                     tabPage2theta, tabPageDspacing, tabPageFWHM, tabPageIntensity,
                     tabPageSingh, tabPageCellConstants, tabPagePressure,
                 })
            if (c != null) captureExtender.SetCapture(c, true);
    }
}
