using Crystallography.Controls;
using System.Windows.Forms;

namespace PDIndexer;

// 260601Cl 追加: GitHub Pages マニュアル用の --capture (GuiCapture) が拾う「コントロール単位クロップ」の対象を、
// Designer (.Designer.cs) を改変せず partial クラスの SetupCaptureTargets() で指定する。
// CaptureExtender.IsCaptureEnabled は、対象コントロールの所有コンテナ (= このフォーム) の CaptureExtender フィールドを
// 反射で探して Capture フラグを判定する。260605Cl: FormBase が protected captureExtender を持つようになったため、各フォームはそれに登録する (旧: フォーム毎に private フィールドを宣言していた)。
// GuiCapture は各フォームを Show した後・クロップ撮影の前に SetupCaptureTargets() を反射で呼ぶ (GuiCapture.PrepareSpecialCaptureState)。
// 粒度は ReciPro の docs と同程度 (groupBox / panel / tabPage 単位) を狙う。

partial class FormProfileSetting
{
    /// <summary>260601Cl 追加: Profile Parameter ウィンドウの処理ステップ (2θ offset / Mask / Smoothing / Bandpass / Background / Normalize) を個別クロップ対象にする。</summary>
    internal void SetupCaptureTargets()
    {
        //260605Cl: FormBase 継承で得た共通 captureExtender (protected) を使う (旧: フォーム毎に private 宣言+new していたが CS0108 衝突のため廃止)
        foreach (var c in new Control[]
                 {
                     flowLayoutPanelTwoThetaOffset, flowLayoutPanelMaskingMode, flowLayoutPanelSmoothing, flowLayoutPanelBandPassFilter,
                     flowLayoutPanelBackgroundSubtraction, flowLayoutPanelNormarizeIntensity,
                 })
            if (c != null) captureExtender.SetCapture(c, true);
    }
}

partial class FormEOS
{
    /// <summary>260601Cl 追加: Equation of States ウィンドウの代表的な物質グループ (Au / NaCl B1 / Periclase) を個別クロップ対象にする。</summary>
    internal void SetupCaptureTargets()
    {
        //260605Cl: FormBase 継承で得た共通 captureExtender (protected) を使う (旧: フォーム毎に private 宣言+new していたが CS0108 衝突のため廃止)
        foreach (var c in new Control[] { groupBoxGold, groupBoxNaClB1, groupBoxPericlase })
            if (c != null) captureExtender.SetCapture(c, true);
    }
}

partial class FormFitting
{
    /// <summary>260601Cl 追加: Fitting ウィンドウの主要グループ (各 groupBox) と Pattern Decomposition を個別クロップ対象にする。</summary>
    internal void SetupCaptureTargets()
    {
        //260605Cl: FormBase 継承で得た共通 captureExtender (protected) を使う (旧: フォーム毎に private 宣言+new していたが CS0108 衝突のため廃止)
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
    /// <summary>260601Cl 追加: Sequential Analysis の各出力タブ (2θ / d / FWHM / Intensity / Singh / Cell constants / Pressure) を個別クロップ対象にする (= 親 TabControl をタブ込みで撮る)。</summary>
    internal void SetupCaptureTargets()
    {
        //260605Cl: FormBase 継承で得た共通 captureExtender (protected) を使う (旧: フォーム毎に private 宣言+new していたが CS0108 衝突のため廃止)
        foreach (var c in new Control[]
                 {
                     tabPage2theta, tabPageDspacing, tabPageFWHM, tabPageIntensity,
                     tabPageSingh, tabPageCellConstants, tabPagePressure,
                 })
            if (c != null) captureExtender.SetCapture(c, true);
    }
}
