#region using
using System;
using System.Drawing;
using System.Windows.Forms;
using Crystallography;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.IO;
using System.Text;
#endregion

namespace PDIndexer;

/// <summary>
/// FormFitting の概要の説明です。
/// </summary>
public partial class FormFitting : Form
{
    #region フィールド、プロパティ
    public Crystal TargetCrystal
    {
        get
        {
            if (bindingSourceCrystals.Current != null)
                return (Crystal)((DataRowView)bindingSourceCrystals.Current).Row[1];
            else return null;
        }
    }
    
    public Profile TargetProfile = new Profile();

    public Crystal temp_crystal;
    public bool IsSkipChangeEvent;

    public bool IsDataGridViewChangeEventSkip;
    public bool IsRadioButtonChangeEventSkip;
    public bool IsCheckedListBoxSelectIndexChangeEventSkip;
    public FormMain formMain;

    public bool SkipFitting { get; set; } = false;

    private int selectedPlaneIndex = -1;
    public int SelectedPlaneIndex
    {
        set
        {
            selectedPlaneIndex = value;
            if (selectedPlaneIndex >= 0 && selectedPlaneIndex != bindingSourcePlanes.Position)
                bindingSourcePlanes.Position = selectedPlaneIndex;
        }
        get => selectedPlaneIndex;
    }

    public string RemovedProfileName { set => textBoxRemovedProfileName.Text = value; get => textBoxRemovedProfileName.Text; }

    /// <summary>
    /// Angleモード、Energyモード、d値モードのときにそれぞれSearchRangeにかける係数 (Angle:1, Energy:500, d:0.2)
    /// </summary>
    public double SerchRangeFactor = 1;

    public (double a, double b, double c, double alpha, double beta, double gamma, double volume) OptimizedCellConstants { get; set; }
    public (double a, double b, double c, double alpha, double beta, double gamma, double volume) OptimizedCellConstants_Err { get; set; }

    #endregion

    #region コンストラクタ、ロード、クローズ
    public FormFitting()
    {
        InitializeComponent();
        temp_crystal = new Crystal();
        IsSkipChangeEvent = true;
    }

    private void FormFitting_Closed(object sender, System.EventArgs e)
    {
        formMain.toolStripButtonFittingParameter.Checked = false;
    }
    private void FormFitting_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        formMain.toolStripButtonFittingParameter.Checked = false;
    }

    #endregion

    #region formMainから、結晶や格子定数が変更されたときに呼ばれる
    //メインフォームやFormCrystalで結晶の格子定数などが変更されたとき呼ばれる。選択列やチェック状態が変更されただけではよばれない
    public void ChangeCrystalFromMainForm(bool IsTargetCrystalChanged = false)
    {
        if (Visible)
        {
            SetPlanes(IsTargetCrystalChanged); //現在選択されている結晶の面をチェックリストボックスに加える
            Fitting();//Fittingをおこなう
        }
    }
    #endregion

    #region 結晶面リストの保存、コピー
    private string generateTableText(int index = -1)
    {
        if (TargetCrystal == null)
            return "";

        var sb = new StringBuilder();
        sb.Append("Checked\thkl\tCalculated X\tFunction\tObserved X\tObserved X err (1sigma)\tObserved FWHM\tObserved Intensity\tRwp (%)\r\n");

        for (int i = 0; i < TargetCrystal.Plane.Count; i++)
        {
            if (index == -1 || index == i)
            {
                var p = TargetCrystal.Plane[i];
                var func = p.peakFunction.Option switch
                {
                    PeakFunctionForm.Simple => "Simple",
                    PeakFunctionForm.PseudoVoigt => "Sym PV",
                    PeakFunctionForm.Peason => "Sym Pea",
                    PeakFunctionForm.SplitPseudoVoigt => "Spl PV",
                    _ => "Spl Pea",
                };

                sb.Append($"{p.IsFittingChecked.ToString()}\t{p.strHKL}\t{p.XCalc}\t");
                if (!double.IsNaN(p.XObs))
                    sb.Append($"{func}\t{p.XObs}\t{p.peakFunction.Xerr}\t{p.peakFunction.Hk}\t{p.observedIntensity}\t{p.peakFunction.Residual * 100}\r\n");
            }
        }
        return sb.ToString();
    }

    private void copyToClipboradToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var text = generateTableText(bindingSourcePlanes.Position);
        if (text != "")
            Clipboard.SetDataObject(text);
    }

    /// <summary>
    /// ボタン Clipboardにコピー
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonCopyToClipboard_Click(object sender, EventArgs e)
    {
        var text = generateTableText();
        if (text != "")
            Clipboard.SetDataObject(text);
    }
    /// <summary>
    /// ボタン CSVファイルに保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ButtonSaveTableAsCSV_Click(object sender, EventArgs e)
    {
        var text = generateTableText();
        if (text != "")
        {
            var dlg = new SaveFileDialog { Filter = "*.csv|*.csv" };
            if (dlg.ShowDialog() == DialogResult.OK)
                using (StreamWriter sw = new StreamWriter(dlg.FileName, false))
                    sw.Write(text.Replace("\t", ","));
        }
    }
    #endregion

    #region Drag & Dropイベント
    /// <summary>
    /// コントロールにCSVファイルがドロップされたとき
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FormFitting_DragDrop(object sender, DragEventArgs e)
    {
        string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        if (fileName.Length == 1 && fileName[0].ToLower().EndsWith("csv"))
        {
            using (var sr = new StreamReader(fileName[0]))
            {
                if (sr.ReadLine().StartsWith("Checked,hkl"))
                {
                    int n = 0;
                    while (sr.Peek() > -1)
                    {
                        var line = sr.ReadLine().Split(new[] { ',' }, StringSplitOptions.None);
                        if (line.Length > 2 && n < dataSet.DataTablePeakFitting.Rows.Count)
                        {
                            var dr = dataSet.DataTablePeakFitting.Rows[n] as DataSet.DataTablePeakFittingRow;
                            dr.Check = line[0] == "True";
                            dr.Function = line[3];
                            dr.X = Convert.ToDouble(line[4]);
                            dr.XErr = Convert.ToDouble(line[5]);
                            dr.FWHM = Convert.ToDouble(line[6]);
                            dr.Intensity = Convert.ToDouble(line[7]);
                            dr.R = Convert.ToDouble(line[8]);
                            if (n < TargetCrystal.Plane.Count)
                            {
                                TargetCrystal.Plane[n].IsFittingChecked = line[0] == "True";
                                TargetCrystal.Plane[n].peakFunction.Option = line[3] switch
                                {
                                    "Simple" => PeakFunctionForm.Simple,
                                    "Sym PV" => PeakFunctionForm.PseudoVoigt,
                                    "Sym Pea" => PeakFunctionForm.Peason,
                                    "Spl PV" => PeakFunctionForm.SplitPseudoVoigt,
                                    "Spl Pea" => PeakFunctionForm.SplitPseudoVoigt,
                                    _ => PeakFunctionForm.PseudoVoigt
                                };

                            }
                        }
                        n++;
                    }
                }
            }
        }
    }

    //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
    private void FormFitting_DragEnter(object sender, DragEventArgs e)
        => e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

    #endregion

    #region ピークフィッティング
    public void Fitting()
    {
        if (TargetCrystal == null || TargetCrystal.Plane == null || formMain == null || SkipFitting) return;

        DiffractionProfile dp;
        if (!(formMain.bindingSourceProfile.Position >= 0 && (dp = (DiffractionProfile)((DataRowView)formMain.bindingSourceProfile.Current).Row[1]) != null)) return;

        TargetProfile = dp.Profile;
        var sw = new Stopwatch();
        sw.Start();

        var checkedCrystals = formMain.dataSet.DataTableCrystal.CheckedItems;

        int groupIndex = 0;

        //初期化
        foreach (var c in checkedCrystals)
            foreach (var p in c.Plane.Where(e => e.IsFittingChecked))
            {
                p.XCalc = formMain.AxisMode switch
                {
                    HorizontalAxis.Angle => Math.Asin(formMain.WaveLength / p.d / 2) / Math.PI * 360,
                    HorizontalAxis.EnergyXray => HorizontalAxisConverter.DToXrayEnergy(p.d, formMain.TakeoffAngle),
                    HorizontalAxis.d => p.d * 10,
                    HorizontalAxis.NeutronTOF => HorizontalAxisConverter.DToTOF(p.d, formMain.TofAngle, formMain.TofLength),
                    HorizontalAxis.WaveNumber => HorizontalAxisConverter.DToWaveNumber(p.d * 10),
                    _ => p.XCalc
                };

                p.XObs = 0;
                p.observedIntensity = 0;
                p.DecompositionGroup = -1;
                p.peakFunction = new PeakFunction();
                p.peakFunction.X = p.XCalc;
                p.peakFunction.range = p.SerchRange * SerchRangeFactor; ;
                p.peakFunction.Hk = p.FWHM * SerchRangeFactor;
                p.peakFunction.Option = p.SerchOption;
                p.peakFunction.Color = Color.FromArgb(c.Argb);

                if (p.SerchOption == PeakFunctionForm.Simple) //Simpleもーどのときはここで処理
                {
                    p.simpleParameter = FittingPeak.FitPeakAsSimple(p.XCalc, p.SerchRange, TargetProfile.Pt.ToArray());
                    p.XObs = p.simpleParameter.X;
                    p.peakFunction.Xerr = TargetProfile.Pt[1].X - TargetProfile.Pt[0].X;
                }
                else
                    p.peakFunction.GroupIndex = groupIndex++;
            }

        if (!checkBoxPatternDecomposition.Checked)
        {
            #region ピーク分離モードではないとき

            foreach (var c in checkedCrystals)
                Parallel.ForEach(c.Plane.Where(p => p.IsFittingChecked && p.SerchOption != PeakFunctionForm.Simple), p =>
                FittingPeak.FitPeakThread(TargetProfile.Pt, true, 0, ref p.peakFunction)
            );
            #endregion
        }
        //ピーク分離フィッティングモードのとき
        else
        {
                #region すべてをまとめてフィッティング
                
                //全てのフィッティング対象ピークをいったん格納
                var pvpTemp2 = new List<PeakFunction>();
                for (int h = 0; h < checkedCrystals.Count; h++)
                    for (int i = 0; i < checkedCrystals[h].Plane.Count; i++)
                        if (checkedCrystals[h].Plane[i].IsFittingChecked && checkedCrystals[h].Plane[i].SerchOption != PeakFunctionForm.Simple)
                            pvpTemp2.Add(checkedCrystals[h].Plane[i].peakFunction);
                //並び替え
                pvpTemp2.Sort();

                //List<List<PeakFunction>> pvp = new List<List<PeakFunction>>();
                groupIndex = 0;
                for (int i = 0; i < pvpTemp2.Count; i++)
                {
                    if (i == 0 || (pvpTemp2[i - 1].X + pvpTemp2[i - 1].range > pvpTemp2[i].X - pvpTemp2[i].range))//もし前回のグループに属していたら
                        pvpTemp2[i].GroupIndex = groupIndex;
                    else
                        pvpTemp2[i].GroupIndex = ++groupIndex;
                }

                PeakFunction[][] pvpTemp = new PeakFunction[groupIndex + 1][];
                for (int i = 0; i < groupIndex + 1; i++)
                    pvpTemp[i] = pvpTemp2.Where(pvp => pvp.GroupIndex == i).ToArray();

                Parallel.For(0, pvpTemp.Length, i =>
                {
                   FittingPeak.FitMultiPeaksThread(TargetProfile.Pt, true, 0, ref pvpTemp[i]);
                });

                #endregion

        }//ピーク分離フィッティングモード終了

        foreach (var c in checkedCrystals)
            foreach (var p in c.Plane)
            {
                if (p.IsFittingChecked)
                {
                    if (p.peakFunction.Success)
                    {
                        if (p.SerchOption != PeakFunctionForm.Simple)
                        {
                            p.XObs = p.peakFunction.X;
                            p.observedIntensity = p.peakFunction.GetIntegral() / (dp.Profile.Pt[1].X - dp.Profile.Pt[0].X);
                        }

                        if (formMain.AxisMode == HorizontalAxis.Angle)
                        {
                            p.dObs = formMain.WaveLength / 2 / Math.Sin(p.XObs / 360 * Math.PI);
                            p.Weight = 1 / Math.Sin(p.XObs / 360 * Math.PI) / Math.Sin(p.XObs / 360 * Math.PI);
                        }
                        else if (formMain.AxisMode == HorizontalAxis.EnergyXray)
                        {
                            p.dObs = HorizontalAxisConverter.XrayEnergyToD(p.XObs, formMain.TakeoffAngle);
                            p.Weight = 1;
                        }
                        else if (formMain.AxisMode == HorizontalAxis.d)
                        {
                            p.dObs = p.XObs / 10;
                            p.Weight = 1;
                        }
                        else if (formMain.AxisMode == HorizontalAxis.NeutronTOF)
                        {
                            p.dObs = HorizontalAxisConverter.NeutronTofToD(p.XObs, formMain.TofAngle, formMain.TofLength);
                            p.Weight = 1;
                        }
                        else if (formMain.AxisMode == HorizontalAxis.WaveNumber)
                        {
                            p.dObs = HorizontalAxisConverter.WaveNumberToD(p.XObs * 10);
                            p.Weight = 1;
                        }
                    }
                    else
                    {
                        p.observedIntensity = double.NaN;
                        p.dObs = double.NaN;
                    }
                }
                else
                    p.dObs = double.NaN;
            }


        formMain.toolStripStatusLabelCalcTime.Text = "Calculating Time (Peak Fitting) : " + sw.ElapsedMilliseconds.ToString() + "ms";

        //フィッティング結果を

        try { FittingDiffraction(); }
        catch { }

        refleshTable();

        formMain.Draw();
    }
    #endregion

    #region 現在のチェック状況と空間群から最小２乗法による格子定数フィッティング
    public void FittingDiffraction()
    {
        var p = TargetCrystal.Plane.Where(e => e.IsFittingChecked).Where(e=>e.SerchOption== PeakFunctionForm.Simple || e.observedIntensity>0).ToList();

        Matrix<double> Q, A, W, C;
        double a, b, c, alfa, beta, gamma, V;
        double a_err, b_err, c_err, alpha_err, beta_err, gamma_err, V_err;
        a = b = c = alfa = beta = gamma = V = 0;
        a_err = b_err = c_err = alpha_err = beta_err = gamma_err = V_err = -1;
        int column = p.Count;

        Matrix<double> inv;

        //数学的な証明は良くわからんがサンプル数Nで誤差σiと偏差δiとの関係は、

        // N－P = Σ(δi/ σi)^2  かつ  S^2 Wi = 1 / σi^2　だから
        // S^2 = (N-P) / Σ(δi^2 Wi) 
        // σi^2 = 1/Wi/ S^2 = Σ(δi^2 Wi) / Wi / (N-P)
        //S[スケール因子] 
        //N[データ数]
        //P[パラメータ数]
        //δi [i番目のデータの偏差]
        //σi [i番目のデータの誤差]
        //Wi [i番目のデータの重み]
        Matrix<double> AlphaInverse;
        switch (TargetCrystal.Symmetry.CrystalSystemStr)
        {
            case "cubic":
                #region cubic
                Q = new DenseMatrix(column, 1);
                A = new DenseMatrix(column, 1);
                W = new DenseMatrix(column, column);
                for (int i = 0; i < column; i++)
                {
                    Q[i, 0] = p[i].h * p[i].h + p[i].k * p[i].k + p[i].l * p[i].l;
                    A[i, 0] = 1 / p[i].dObs / p[i].dObs;
                    W[i, i] = p[i].Weight;
                }

                if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                    break;
                C = inv * Q.Transpose() * W * A;

                a = b = c = Math.Sqrt(1 / C[0, 0]);
                alfa = beta = gamma = Math.PI / 2;
                V = a * a * a;
                if (p.Count - 1 > 0)//以下は誤差を計算する部分
                {
                    var Dev = A - Q * C;//偏差を縦成分にとったベクトル Devの成分の２乗和が ピーク数 - パラメータ数になるはず
                    double sum = 0;
                    for (int i = 0; i < column; i++)
                        sum += Dev[i, 0] * Dev[i, 0] * p[i].Weight;
                    //本当の重み行列は
                    for (int i = 0; i < column; i++)
                        W[i, i] = p[i].Weight * (p.Count - 1) / sum;
                    if (!(Q.Transpose() * W * Q).TryInverse(out AlphaInverse))//この行列の対角成分がパラメータCの誤差の２乗になる
                        break;

                    //最後にCの誤差を実格子の誤差に直す
                    a_err = Math.Sqrt(1 / 4.0 / C[0, 0] / C[0, 0] / C[0, 0] * AlphaInverse[0, 0]);

                    V_err = Math.Sqrt(3) * a * a_err;
                }
                break;
            #endregion
            case "tetragonal":
                #region tetragonal
                Q = new DenseMatrix(column, 2);
                A = new DenseMatrix(column, 1);
                W = new DenseMatrix(column, column);
                for (int i = 0; i < column; i++)
                {
                    Q[i, 0] = p[i].h * p[i].h + p[i].k * p[i].k;
                    Q[i, 1] = p[i].l * p[i].l;
                    A[i, 0] = 1 / p[i].dObs / p[i].dObs;
                    W[i, i] = p[i].Weight;
                }
                if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                    break;
                C = inv * Q.Transpose() * W * A;
                a = Math.Sqrt(1 / C[0, 0]);
                b = a;
                c = Math.Sqrt(1 / C[1, 0]);
                alfa = Math.PI / 2;
                beta = Math.PI / 2;
                gamma = Math.PI / 2;
                V = a * a * c;

                if (p.Count - 2 > 0)//以下は誤差を計算する部分
                {
                    var Dev = A - Q * C;//偏差を縦成分にとったベクトル Devの成分の２乗和が ピーク数 - パラメータ数になるはず
                    double sum = 0;
                    for (int i = 0; i < column; i++)
                        sum += Dev[i, 0] * Dev[i, 0] * p[i].Weight;
                    //本当の重み行列は
                    for (int i = 0; i < column; i++)
                        W[i, i] = p[i].Weight * (p.Count - 2) / sum;
                    if (!(Q.Transpose() * W * Q).TryInverse(out AlphaInverse))//この行列の対角成分がパラメータCの誤差の２乗になる
                        break;

                    //最後にCの誤差を実格子の誤差に直す
                    a_err = Math.Sqrt(1 / 4.0 / C[0, 0] / C[0, 0] / C[0, 0] * AlphaInverse[0, 0]);
                    c_err = Math.Sqrt(1 / 4.0 / C[1, 0] / C[1, 0] / C[1, 0] * AlphaInverse[1, 1]);

                    V_err = Math.Sqrt(2 * a * c * a_err * a_err + a * a * c_err * c_err);
                }
                break;
            #endregion
            case "hexagonal":
                #region hexagonal
                Q = new DenseMatrix(column, 2);
                A = new DenseMatrix(column, 1);
                W = new DenseMatrix(column, column);
                for (int i = 0; i < column; i++)
                {
                    Q[i, 0] = 4.0 / 3.0 * (p[i].h * p[i].h + p[i].k * p[i].k + p[i].h * p[i].k);
                    Q[i, 1] = p[i].l * p[i].l;
                    A[i, 0] = 1 / p[i].dObs / p[i].dObs;
                    W[i, i] = p[i].Weight;
                }
                if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                    break;
                C = inv * Q.Transpose() * W * A;
                a = Math.Sqrt(1 / C[0, 0]);
                b = a;
                c = Math.Sqrt(1 / C[1, 0]);
                alfa = Math.PI / 2;
                beta = Math.PI / 2;
                gamma = Math.PI / 1.5;

                V = a * a * c * Math.Sqrt(3) / 2;

                if (p.Count - 2 > 0)//以下は誤差を計算する部分
                {
                    var Dev = A - Q * C;//偏差を縦成分にとったベクトル Devの成分の２乗和が ピーク数 - パラメータ数になるはず
                    double sum = 0;
                    for (int i = 0; i < column; i++)
                        sum += Dev[i, 0] * Dev[i, 0] * p[i].Weight;
                    //本当の重み行列は
                    for (int i = 0; i < column; i++)
                        W[i, i] = p[i].Weight * (p.Count - 2) / sum;
                    if (!(Q.Transpose() * W * Q).TryInverse(out AlphaInverse))//この行列の対角成分がパラメータCの誤差の２乗になる
                        break;

                    //最後にCの誤差を実格子の誤差に直す
                    a_err = Math.Sqrt(1 / 4.0 / C[0, 0] / C[0, 0] / C[0, 0] * AlphaInverse[0, 0]);
                    c_err = Math.Sqrt(1 / 4.0 / C[1, 0] / C[1, 0] / C[1, 0] * AlphaInverse[1, 1]);

                    V_err = Math.Sqrt(2 * a * c * a_err * a_err + a * a * c_err * c_err) * Math.Sqrt(3) / 2; ;
                }

                break;
            #endregion
            case "trigonal":
                #region trigonal
                Q = new DenseMatrix(column, 2);
                A = new DenseMatrix(column, 1);
                W = new DenseMatrix(column, column);
                for (int i = 0; i < column; i++)
                {
                    Q[i, 0] = 4.0 / 3.0 * (p[i].h * p[i].h + p[i].k * p[i].k + p[i].h * p[i].k);
                    Q[i, 1] = p[i].l * p[i].l;
                    A[i, 0] = 1 / p[i].dObs / p[i].dObs;
                    W[i, i] = p[i].Weight;
                }
                if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                    break;
                C = inv * Q.Transpose() * W * A;
                a = Math.Sqrt(1 / C[0, 0]);
                b = a;
                c = Math.Sqrt(1 / C[1, 0]);
                alfa = Math.PI / 2;
                beta = Math.PI / 2;
                gamma = Math.PI / 1.5;

                V = a * a * c * Math.Sqrt(3) / 2;

                if (p.Count - 2 > 0)//以下は誤差を計算する部分
                {
                    var Dev = A - Q * C;//偏差を縦成分にとったベクトル Devの成分の２乗和が ピーク数 - パラメータ数になるはず
                    double sum = 0;
                    for (int i = 0; i < column; i++)
                        sum += Dev[i, 0] * Dev[i, 0] * p[i].Weight;
                    //本当の重み行列は
                    for (int i = 0; i < column; i++)
                        W[i, i] = p[i].Weight * (p.Count - 2) / sum;
                    if (!(Q.Transpose() * W * Q).TryInverse(out AlphaInverse))//この行列の対角成分がパラメータCの誤差の２乗になる
                        break;

                    //最後にCの誤差を実格子の誤差に直す
                    a_err = Math.Sqrt(1 / 4.0 / C[0, 0] / C[0, 0] / C[0, 0] * AlphaInverse[0, 0]);
                    c_err = Math.Sqrt(1 / 4.0 / C[1, 0] / C[1, 0] / C[1, 0] * AlphaInverse[1, 1]);

                    V_err = Math.Sqrt(2 * a * c * a_err * a_err + a * a * c_err * c_err) * Math.Sqrt(3) / 2;
                }

                break;
            #endregion
            case "orthorhombic":
                #region orthorhombic
                Q = new DenseMatrix(column, 3);
                A = new DenseMatrix(column, 1);
                W = new DenseMatrix(column, column);
                for (int i = 0; i < column; i++)
                {
                    Q[i, 0] = p[i].h * p[i].h;
                    Q[i, 1] = p[i].k * p[i].k;
                    Q[i, 2] = p[i].l * p[i].l;
                    A[i, 0] = 1 / p[i].dObs / p[i].dObs;
                    W[i, i] = p[i].Weight;
                }
                if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                    break;
                C = inv * Q.Transpose() * W * A;
                a = Math.Sqrt(1 / C[0, 0]);
                b = Math.Sqrt(1 / C[1, 0]);
                c = Math.Sqrt(1 / C[2, 0]);
                alfa = Math.PI / 2;
                beta = Math.PI / 2;
                gamma = Math.PI / 2;

                V = a * b * c;

                if (p.Count - 3 > 0)//以下は誤差を計算する部分
                {
                    var Dev = A - Q * C;//偏差を縦成分にとったベクトル Devの成分の２乗和が ピーク数 - パラメータ数になるはず
                    double sum = 0;
                    for (int i = 0; i < column; i++)
                        sum += Dev[i, 0] * Dev[i, 0] * p[i].Weight;
                    //本当の重み行列は
                    for (int i = 0; i < column; i++)
                        W[i, i] = p[i].Weight * (p.Count - 3) / sum;
                    if (!(Q.Transpose() * W * Q).TryInverse(out AlphaInverse))//この行列の対角成分がパラメータCの誤差の２乗になる
                        break;

                    //最後にCの誤差を実格子の誤差に直す
                    a_err = Math.Sqrt(1 / 4.0 / C[0, 0] / C[0, 0] / C[0, 0] * AlphaInverse[0, 0]);
                    b_err = Math.Sqrt(1 / 4.0 / C[1, 0] / C[1, 0] / C[1, 0] * AlphaInverse[1, 1]);
                    c_err = Math.Sqrt(1 / 4.0 / C[2, 0] / C[2, 0] / C[2, 0] * AlphaInverse[2, 2]);

                    V_err = Math.Sqrt(b * c * a_err * a_err + c * a * b_err * b_err + a * b * c_err * c_err);
                }
                break;
            #endregion
            case "monoclinic":
                #region monoclinic
                Q = new DenseMatrix(column, 4);
                A = new DenseMatrix(column, 1);
                W = new DenseMatrix(column, column);
                for (int i = 0; i < column; i++)
                {
                    Q[i, 0] = p[i].h * p[i].h;
                    Q[i, 1] = p[i].k * p[i].k;
                    Q[i, 2] = p[i].l * p[i].l;
                    A[i, 0] = 1 / p[i].dObs / p[i].dObs;
                    W[i, i] = p[i].Weight;
                }
                switch (TargetCrystal.Symmetry.MainAxis)
                {
                    case "a":
                        for (int i = 0; i < column; i++)
                            Q[i, 3] = p[i].k * p[i].l;
                        if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                            break;
                        C = inv * Q.Transpose() * W * A;

                        alfa = Math.Acos(-C[3, 0] / 2 / Math.Sqrt(C[1, 0] * C[2, 0]));
                        a = Math.Sqrt(1 / C[0, 0]);
                        b = Math.Sqrt(1 / C[1, 0]) / Math.Sin(alfa);
                        c = Math.Sqrt(1 / C[2, 0]) / Math.Sin(alfa);

                        V = a * b * c * Math.Sin(alfa);

                        beta = Math.PI / 2;
                        gamma = Math.PI / 2;

                        if (p.Count - 4 > 0)//以下は誤差を計算する部分
                        {
                            var Dev = A - Q * C;//偏差を縦成分にとったベクトル Devの成分の２乗和が ピーク数 - パラメータ数になるはず
                            double sum = 0;
                            for (int i = 0; i < column; i++)
                                sum += Dev[i, 0] * Dev[i, 0] * p[i].Weight;
                            //本当の重み行列は
                            for (int i = 0; i < column; i++)
                                W[i, i] = p[i].Weight * (p.Count - 4) / sum;
                            if (!(Q.Transpose() * W * Q).TryInverse(out AlphaInverse))//この行列の対角成分がパラメータCの誤差の２乗になる
                                break;

                            //最後にCの誤差を実格子の誤差に直す
                            alpha_err = Math.Sqrt(
                                C[3, 0] * C[3, 0] / (16 * C[1, 0] * C[1, 0] * C[1, 0] * C[2, 0] - 4 * C[1, 0] * C[1, 0] * C[3, 0] * C[3, 0]) * AlphaInverse[1, 1]
                            + C[3, 0] * C[3, 0] / (16 * C[1, 0] * C[2, 0] * C[2, 0] * C[2, 0] - 4 * C[2, 0] * C[2, 0] * C[3, 0] * C[3, 0]) * AlphaInverse[2, 2]
                            + 1 / (4 * C[1, 0] * C[2, 0] - C[3, 0] * C[3, 0]) * AlphaInverse[3, 3]
                                );

                            a_err = Math.Sqrt(1 / 4.0 / C[0, 0] / C[0, 0] / C[0, 0] * AlphaInverse[0, 0]);

                            b_err = Math.Sqrt(
                                1 / Math.Sin(alfa) * Math.Sin(alfa) / C[1, 0] / C[1, 0] / C[1, 0] * AlphaInverse[1, 1]
                                + 1 / (Math.Tan(alfa) * Math.Tan(alfa) * Math.Sin(alfa) * Math.Sin(alfa) * C[1, 0]) * alpha_err * alpha_err
                                );

                            c_err = Math.Sqrt(
                                1 / Math.Sin(alfa) * Math.Sin(alfa) / C[2, 0] / C[2, 0] / C[2, 0] * AlphaInverse[2, 2]
                                + 1 / (Math.Tan(alfa) * Math.Tan(alfa) * Math.Sin(alfa) * Math.Sin(alfa) * C[2, 0]) * alpha_err * alpha_err
                                );

                            V_err = Math.Sqrt(
                                  b * c * Math.Sin(alfa) * a_err * a_err
                                + c * a * Math.Sin(alfa) * b_err * b_err
                                + a * b * Math.Sin(alfa) * c_err * c_err
                                + a * b * c * Math.Cos(alfa) * alpha_err * alpha_err
                                );
                        }


                        break;
                    case "b":
                        for (int i = 0; i < column; i++)
                            Q[i, 3] = p[i].l * p[i].h;

                        if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                            break;
                        C = inv * Q.Transpose() * W * A;

                        beta = Math.Acos(-C[3, 0] / 2 / Math.Sqrt(C[0, 0] * C[2, 0]));
                        a = Math.Sqrt(1 / C[0, 0]) / Math.Sin(beta);
                        b = Math.Sqrt(1 / C[1, 0]);
                        c = Math.Sqrt(1 / C[2, 0]) / Math.Sin(beta);
                        alfa = Math.PI / 2;
                        gamma = Math.PI / 2;

                        V = a * b * c * Math.Sin(beta);

                        if (p.Count - 4 > 0)//以下は誤差を計算する部分
                        {
                            var Dev = A - Q * C;//偏差を縦成分にとったベクトル Devの成分の２乗和が ピーク数 - パラメータ数になるはず
                            double sum = 0;
                            for (int i = 0; i < column; i++)
                                sum += Dev[i, 0] * Dev[i, 0] * p[i].Weight;
                            //本当の重み行列は
                            for (int i = 0; i < column; i++)
                                W[i, i] = p[i].Weight * (p.Count - 4) / sum;
                            if (!(Q.Transpose() * W * Q).TryInverse(out AlphaInverse))//この行列の対角成分がパラメータCの誤差の２乗になる
                                break;

                            //最後にCの誤差を実格子の誤差に直す
                            beta_err = Math.Sqrt(
                                C[3, 0] * C[3, 0] / (16 * C[0, 0] * C[0, 0] * C[0, 0] * C[2, 0] - 4 * C[0, 0] * C[0, 0] * C[3, 0] * C[3, 0]) * AlphaInverse[0, 0]
                            + C[3, 0] * C[3, 0] / (16 * C[0, 0] * C[2, 0] * C[2, 0] * C[2, 0] - 4 * C[2, 0] * C[2, 0] * C[3, 0] * C[3, 0]) * AlphaInverse[2, 2]
                            + 1 / (4 * C[0, 0] * C[2, 0] - C[3, 0] * C[3, 0]) * AlphaInverse[3, 3]
                                );

                            a_err = Math.Sqrt(
                                1 / Math.Sin(alfa) * Math.Sin(alfa) / C[0, 0] / C[0, 0] / C[0, 0] * AlphaInverse[0, 0]
                                + 1 / (Math.Tan(alfa) * Math.Tan(alfa) * Math.Sin(alfa) * Math.Sin(alfa) * C[0, 0]) * beta_err * beta_err
                                );

                            b_err = Math.Sqrt(1 / 4.0 / C[1, 0] / C[1, 0] / C[1, 0] * AlphaInverse[1, 1]);

                            c_err = Math.Sqrt(
                                1 / Math.Sin(alfa) * Math.Sin(alfa) / C[2, 0] / C[2, 0] / C[2, 0] * AlphaInverse[2, 2]
                                + 1 / (Math.Tan(alfa) * Math.Tan(alfa) * Math.Sin(alfa) * Math.Sin(alfa) * C[2, 0]) * beta_err * beta_err
                                );

                            V_err = Math.Sqrt(
                                  b * c * Math.Sin(beta) * a_err * a_err
                                + c * a * Math.Sin(beta) * b_err * b_err
                                + a * b * Math.Sin(beta) * c_err * c_err
                                + a * b * c * Math.Cos(beta) * beta_err * beta_err
                                );
                        }

                        break;
                    case "c":
                        for (int i = 0; i < column; i++)
                        {
                            Q[i, 3] = p[i].h * p[i].k;
                        }
                        if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                            break;
                        C = inv * Q.Transpose() * W * A;
                        gamma = Math.Acos(-C[3, 0] / 2 / Math.Sqrt(C[0, 0] * C[1, 0]));
                        a = Math.Sqrt(1 / C[0, 0]) / Math.Sin(gamma);
                        b = Math.Sqrt(1 / C[1, 0]) / Math.Sin(gamma);
                        c = Math.Sqrt(1 / C[2, 0]);
                        alfa = Math.PI / 2;
                        beta = Math.PI / 2;

                        V = a * b * c * Math.Sin(gamma);

                        if (p.Count - 4 > 0)//以下は誤差を計算する部分
                        {
                            var Dev = A - Q * C;//偏差を縦成分にとったベクトル Devの成分の２乗和が ピーク数 - パラメータ数になるはず
                            double sum = 0;
                            for (int i = 0; i < column; i++)
                                sum += Dev[i, 0] * Dev[i, 0] * p[i].Weight;
                            //本当の重み行列は
                            for (int i = 0; i < column; i++)
                                W[i, i] = p[i].Weight * (p.Count - 4) / sum;
                            if (!(Q.Transpose() * W * Q).TryInverse(out AlphaInverse))//この行列の対角成分がパラメータCの誤差の２乗になる
                                break;

                            //最後にCの誤差を実格子の誤差に直す
                            gamma_err = Math.Sqrt(
                                C[3, 0] * C[3, 0] / (16 * C[0, 0] * C[0, 0] * C[0, 0] * C[1, 0] - 4 * C[0, 0] * C[0, 0] * C[3, 0] * C[3, 0]) * AlphaInverse[0, 0]
                            + C[3, 0] * C[3, 0] / (16 * C[0, 0] * C[1, 0] * C[1, 0] * C[1, 0] - 4 * C[1, 0] * C[1, 0] * C[3, 0] * C[3, 0]) * AlphaInverse[1, 1]
                            + 1 / (4 * C[0, 0] * C[1, 0] - C[3, 0] * C[3, 0]) * AlphaInverse[3, 3]
                                );

                            a_err = Math.Sqrt(
                                1 / Math.Sin(alfa) * Math.Sin(alfa) / C[0, 0] / C[0, 0] / C[0, 0] * AlphaInverse[0, 0]
                                + 1 / (Math.Tan(alfa) * Math.Tan(alfa) * Math.Sin(alfa) * Math.Sin(alfa) * C[0, 0]) * gamma_err * gamma_err
                                );

                            b_err = Math.Sqrt(
                                1 / Math.Sin(alfa) * Math.Sin(alfa) / C[1, 0] / C[1, 0] / C[1, 0] * AlphaInverse[1, 1]
                                + 1 / (Math.Tan(alfa) * Math.Tan(alfa) * Math.Sin(alfa) * Math.Sin(alfa) * C[1, 0]) * gamma_err * gamma_err
                                );

                            c_err = Math.Sqrt(1 / 4.0 / C[2, 0] / C[2, 0] / C[2, 0] * AlphaInverse[2, 2]);

                            V_err = Math.Sqrt(
                                  b * c * Math.Sin(gamma) * a_err * a_err
                                + c * a * Math.Sin(gamma) * b_err * b_err
                                + a * b * Math.Sin(gamma) * c_err * c_err
                                + a * b * c * Math.Cos(gamma) * gamma_err * gamma_err
                                );
                        }

                        break;
                }
                break;
            #endregion
            case "triclinic":
                #region triclinic

                var constants = CrystalGeometry.GetErrorTriclinic(p.ToArray());
                if (constants.Length != 0)
                {
                    a = constants[0];
                    b = constants[1];
                    c = constants[2];
                    alfa = constants[3];
                    beta = constants[4];
                    gamma = constants[5];
                    V = constants[6];
                    a_err = constants[7];
                    b_err = constants[8];
                    c_err = constants[9];
                    alpha_err = constants[10];
                    beta_err = constants[11];
                    gamma_err = constants[12];
                    V_err = constants[13];
                }
                /*
                Q = new Matrix(column, 6);
                A = new Matrix(column, 1);
                W = new Matrix(column, column);
                for (int i = 0; i < column; i++)
                {
                    Q[i, 0] = p[i].h * p[i].h;
                    Q[i, 1] = p[i].k * p[i].k;
                    Q[i, 2] = p[i].l * p[i].l;
                    Q[i, 3] = p[i].k * p[i].l;
                    Q[i, 4] = p[i].l * p[i].h;
                    Q[i, 5] = p[i].h * p[i].k;
                    A[i, 0] = 1 / p[i].dObs / p[i].dObs;
                    W[i, i] = p[i].Weight;
                }
                C = (Q.Trans() * W * Q).Inv() * Q.Trans() * W * A;
                if (C.E.GetLength(0) == 0 || double.IsNaN(C[0,0])) break;

                double _A = C[0, 0], _B = C[1, 0], _C = C[2, 0], _U = C[3, 0], _V = C[4, 0], _W = C[5, 0];

                double a_star = Math.Sqrt(_A);
                double b_star = Math.Sqrt(_B);
                double c_star = Math.Sqrt(_C);
                double CosAlf_star = _U / (2 * b_star * c_star);
                double CosBet_star = _V / (2 * c_star * a_star);
                double CosGam_star = _W / (2 * a_star * b_star);
                double Alf_star = Math.Acos(CosAlf_star);
                double Bet_star = Math.Acos(CosBet_star);
                double Gam_star = Math.Acos(CosGam_star);
                double V_star = a_star * b_star * c_star
                    * Math.Sqrt(1 - CosAlf_star * CosAlf_star - CosBet_star * CosBet_star - CosGam_star * CosGam_star + 2 * CosAlf_star * CosBet_star * CosGam_star);

                

                V_star = Math.Sqrt(4 * _A * _B * _C - _A * _U * _U - _B * _V * _V - _C * _W * _W + _U * _V * _W)/2;
                V = 1 / V_star;

              //  a = b_star * c_star * Math.Sin(Alf_star) / V_star;
                a = Math.Sqrt(4 * _B * _C - _U * _U) / V_star / 2;
                //b = c_star * a_star * Math.Sin(Bet_star) / V_star;
                b = Math.Sqrt(4 * _C * _A - _V * _V) / V_star / 2;
                //c = a_star * b_star * Math.Sin(Gam_star) / V_star;
                c = Math.Sqrt(4 * _A * _B - _W * _W) / V_star / 2;
                alfa = Math.Asin(a_star / b / c / V_star);
                //alfa = Math.Asin(V_star*4/(4 * _C * _A - _V * _V) /   (4 * _A * _B - _W * _W)     );
                beta = Math.Asin(b_star / c / a / V_star);
                gamma = Math.Asin(c_star / a / b / V_star);

                if (p.Count - 6 > 0)//以下は誤差を計算する部分
                {
                    Matrix Dev = A - Q * C;//偏差を縦成分にとったベクトル Devの成分の２乗和が ピーク数 - パラメータ数になるはず
                    double sum = 0;
                    for (int i = 0; i < column; i++)
                        sum += Dev[i, 0] * Dev[i, 0] * p[i].Weight;
                    //本当の重み行列は
                    for (int i = 0; i < column; i++)
                        W[i, i] = p[i].Weight * (p.Count - 6) / sum;
                    Matrix AlphaInverse = (Q.Trans() * W * Q).Inv();//この行列の対角成分がパラメータCの誤差の２乗になる

                    double _Av = AlphaInverse[0, 0], _Bv = AlphaInverse[1, 1], _Cv = AlphaInverse[2, 2], _Uv = AlphaInverse[3, 3], _Vv = AlphaInverse[4, 4], _Wv = AlphaInverse[5, 5];

                    //最後にCの誤差を実格子の誤差に直す
                    double a_star_err = Math.Sqrt(_Av / 4.0 / _A);// a* = _A^1/2   =>  　σ(a*)^2 =  ( σ(A)^2 /2/_A) 
                    double b_star_err = Math.Sqrt(_Bv / 4.0 / _B);
                    double c_star_err = Math.Sqrt(_Cv / 4.0 / _C );

                    double CosAlf_star_err = Math.Sqrt(
                          _Uv / (b_star * c_star) / (b_star * c_star)
                    + _U * _U / (b_star * b_star * c_star) / (b_star * b_star * c_star) * b_star_err * b_star_err
                    + _U * _U / (b_star * c_star * c_star) / (b_star * c_star * c_star) * c_star_err * c_star_err
                    );

                    double CosBet_star_err = Math.Sqrt(
                          _Vv / (c_star * a_star) / (c_star * a_star) 
                    + _V * _V / (c_star * c_star * a_star) / (c_star * c_star * a_star) * c_star_err * c_star_err
                    + _V * _V / (c_star * a_star * a_star) / (c_star * a_star * a_star) * a_star_err * a_star_err
                    );

                    double CosGam_star_err = Math.Sqrt(
                          _Wv / (a_star * b_star) / (a_star * b_star)
                    + _W * _W / (a_star * a_star * b_star) / (a_star * a_star * b_star) * a_star_err * a_star_err
                    + _W * _W / (a_star * b_star * b_star) / (a_star * b_star * b_star) * b_star_err * b_star_err
                    );

                    double Alf_star_err = 1 / Math.Sqrt(1 - CosAlf_star * CosAlf_star) * CosAlf_star_err;
                    double Bet_star_err = 1 / Math.Sqrt(1 - CosBet_star * CosBet_star) * CosBet_star_err;
                    double Gam_star_err = 1 / Math.Sqrt(1 - CosGam_star * CosGam_star) * CosGam_star_err;

                    double aa = a_star * a_star;
                    double bb = b_star * b_star;
                    double cc = c_star * c_star;
                    double CosAA = CosAlf_star * CosAlf_star;
                    double CosBB = CosBet_star * CosBet_star;
                    double CosGG = CosGam_star * CosGam_star;

                    double CosABG = CosAlf_star * CosBet_star * CosGam_star;
                    double VV = V_star * V_star;
                    double V_star_err = Math.Sqrt(
                        +bb * cc * (1 - CosAA - CosBB - CosGG + 2 * CosABG) * a_star_err * a_star_err
                        + aa * cc * (1 - CosAA - CosBB - CosGG + 2 * CosABG) * b_star_err * b_star_err
                        + bb * aa * (1 - CosAA - CosBB - CosGG + 2 * CosABG) * c_star_err * c_star_err

                        + aa * bb * cc * (CosAlf_star - CosBet_star * CosGam_star) * (CosAlf_star - CosBet_star * CosGam_star)
                        / (1 - CosAA - CosBB - CosGG + 2 * CosABG) * CosAlf_star_err * CosAlf_star_err

                        + aa * bb * cc * (CosBet_star - CosAlf_star * CosGam_star) * (CosBet_star - CosAlf_star * CosGam_star)
                        / (1 - CosAA - CosBB - CosGG + 2 * CosABG) * CosBet_star_err * CosBet_star_err

                        + aa * bb * cc * (CosGam_star - CosBet_star * CosAlf_star) * (CosGam_star - CosBet_star * CosAlf_star)
                        / (1 - CosAA - CosBB - CosGG + 2 * CosABG) * CosAlf_star_err * CosAlf_star_err
                    );
                    double SinAA = Math.Sin(Alf_star) * Math.Sin(Alf_star);
                    double SinBB = Math.Sin(Bet_star) * Math.Sin(Bet_star);
                    double SinGG = Math.Sin(Gam_star) * Math.Sin(Gam_star);

                    //ここより下の式は多分、間違い
                    a_err = Math.Sqrt(
                        cc * SinAA / VV * b_star_err * b_star_err
                       + bb * SinAA / VV * c_star_err * c_star_err
                       + bb * cc * CosAA / VV * Alf_star_err * Alf_star_err
                       + bb * cc * SinAA / VV / VV * V_star_err * V_star_err
                    );

                    b_err = Math.Sqrt(
                        cc * SinBB / VV * a_star_err * a_star_err
                       + aa * SinBB / VV * c_star_err * c_star_err
                       + aa * cc * CosBB / VV * Bet_star_err * Bet_star_err
                       + aa * cc * SinBB / VV / VV * V_star_err * V_star_err
                    );

                    c_err = Math.Sqrt(
                        cc * SinGG / VV * a_star_err * a_star_err
                       + aa * SinGG / VV * c_star_err * c_star_err
                       + aa * cc * CosGG / VV * Gam_star_err * Gam_star_err
                       + aa * cc * SinGG / VV / VV * V_star_err * V_star_err
                    );

                    //ここより下の式は、間違い
                    alpha_err = Math.Sqrt(
                        1 / (b * b * c * c * VV - aa) * a_star_err * a_star_err
                    + aa / (b * b * b * b * c * c * VV - b * b * aa) * b_err * b_err
                    + aa / (b * b * c * c * c * c * VV - c * c * aa) * c_err * c_err
                    + aa / (b * b * c * c * VV - aa) / VV * V_star_err * V_star_err);

                    beta_err = Math.Sqrt(
                        1 / (a * a * c * c * VV - aa) * a_star_err * a_star_err
                    + bb / (a * a * a * a * c * c * VV - a * a * bb) * a_err * a_err
                    + bb / (a * a * c * c * c * c * VV - c * c * bb) * c_err * c_err
                    + bb / (a * a * c * c * VV - aa) / VV * V_star_err * V_star_err);

                    gamma_err = Math.Sqrt(
                        1 / (b * b * a * a * VV - aa) * a_star_err * a_star_err
                    + cc / (b * b * b * b * a * a * VV - b * b * cc) * b_err * b_err
                    + cc / (b * b * a * a * a * a * VV - a * a * cc) * a_err * a_err
                    + cc / (b * b * a * a * VV - aa) / VV * V_star_err * V_star_err);

                    V_err = V_star_err / V_star / V_star;
                }

                if (Math.Abs(CosAlf_star - (Math.Cos(beta) * Math.Cos(gamma) - Math.Cos(alfa)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                    && Math.Abs(CosBet_star - (Math.Cos(gamma) * Math.Cos(alfa) - Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alfa))) < 0.0000000001
                    && Math.Abs(CosGam_star - (Math.Cos(alfa) * Math.Cos(beta) - Math.Cos(gamma)) / (Math.Sin(alfa) * Math.Sin(beta))) < 0.0000000001)
                {

                }
                else if (Math.Abs(CosAlf_star - (Math.Cos(beta) * Math.Cos(gamma) + Math.Cos(alfa)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                    && Math.Abs(CosBet_star - (-Math.Cos(gamma) * Math.Cos(alfa) - Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alfa))) < 0.0000000001
                    && Math.Abs(CosGam_star - (-Math.Cos(alfa) * Math.Cos(beta) - Math.Cos(gamma)) / (Math.Sin(alfa) * Math.Sin(beta))) < 0.0000000001)
                {
                    alfa = Math.PI - alfa;
                }
                else if (Math.Abs(CosAlf_star - (-Math.Cos(beta) * Math.Cos(gamma) - Math.Cos(alfa)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                    && Math.Abs(CosBet_star - (Math.Cos(gamma) * Math.Cos(alfa) + Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alfa))) < 0.0000000001
                    && Math.Abs(CosGam_star - (-Math.Cos(alfa) * Math.Cos(beta) - Math.Cos(gamma)) / (Math.Sin(alfa) * Math.Sin(beta))) < 0.0000000001)
                {
                    beta = Math.PI - beta;
                }
                else if (Math.Abs(CosAlf_star - (-Math.Cos(beta) * Math.Cos(gamma) - Math.Cos(alfa)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                    && Math.Abs(CosBet_star - (-Math.Cos(gamma) * Math.Cos(alfa) - Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alfa))) < 0.0000000001
                    && Math.Abs(CosGam_star - (Math.Cos(alfa) * Math.Cos(beta) + Math.Cos(gamma)) / (Math.Sin(alfa) * Math.Sin(beta))) < 0.0000000001)
                {
                    gamma = Math.PI - gamma;
                }
                else if (Math.Abs(CosAlf_star - (Math.Cos(beta) * Math.Cos(gamma) - Math.Cos(alfa)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                    && Math.Abs(CosBet_star - (-Math.Cos(gamma) * Math.Cos(alfa) + Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alfa))) < 0.0000000001
                    && Math.Abs(CosGam_star - (-Math.Cos(alfa) * Math.Cos(beta) + Math.Cos(gamma)) / (Math.Sin(alfa) * Math.Sin(beta))) < 0.0000000001)
                {
                    beta = Math.PI - beta; gamma = Math.PI - gamma;
                }
                else if (Math.Abs(CosAlf_star - (-Math.Cos(beta) * Math.Cos(gamma) + Math.Cos(alfa)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                    && Math.Abs(CosBet_star - (Math.Cos(gamma) * Math.Cos(alfa) - Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alfa))) < 0.0000000001
                    && Math.Abs(CosGam_star - (-Math.Cos(alfa) * Math.Cos(beta) + Math.Cos(gamma)) / (Math.Sin(alfa) * Math.Sin(beta))) < 0.0000000001)
                {
                    alfa = Math.PI - alfa; gamma = Math.PI - gamma;
                }
                else if (Math.Abs(CosAlf_star - (-Math.Cos(beta) * Math.Cos(gamma) + Math.Cos(alfa)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                    && Math.Abs(CosBet_star - (-Math.Cos(gamma) * Math.Cos(alfa) + Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alfa))) < 0.0000000001
                    && Math.Abs(CosGam_star - (Math.Cos(alfa) * Math.Cos(beta) - Math.Cos(gamma)) / (Math.Sin(alfa) * Math.Sin(beta))) < 0.0000000001)
                {
                    alfa = Math.PI - alfa; beta = Math.PI - beta;
                }
                else if (Math.Abs(CosAlf_star - (Math.Cos(beta) * Math.Cos(gamma) + Math.Cos(alfa)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                    && Math.Abs(CosBet_star - (Math.Cos(gamma) * Math.Cos(alfa) + Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alfa))) < 0.0000000001
                    && Math.Abs(CosGam_star - (Math.Cos(alfa) * Math.Cos(beta) + Math.Cos(gamma)) / (Math.Sin(alfa) * Math.Sin(beta))) < 0.0000000001)
                {
                    alfa = Math.PI - alfa; beta = Math.PI - beta; gamma = Math.PI - gamma;
                }*/
                break;
                #endregion
        }

        //解けなかった場合は、格子定数を定数倍したものを求める 2020/10/16
        if (a == 0 && p.Count > 0)
        {
            double coeff = p.Sum(e => e.Weight * e.d * e.dObs) / p.Sum(e => e.Weight * e.d * e.d);
            a = coeff * TargetCrystal.A;
            b = coeff * TargetCrystal.B;
            c = coeff * TargetCrystal.C;
            alfa = TargetCrystal.Alpha;
            beta = TargetCrystal.Beta;
            gamma = TargetCrystal.Gamma;
        }

        temp_crystal = new Crystal((a, b, c, alfa, beta, gamma), (a_err, b_err, c_err, alpha_err, beta_err, gamma_err), 0, "", Color.Black);
        temp_crystal.Volume_err = V_err;
        SetTextBox(temp_crystal);
    }
    #endregion

    # region Confirmを押したときの動作
    private void buttonConfirm_Click(object sender, EventArgs e) => Confirm(true);

    public void Confirm(bool copy = true)
    {
        if (double.IsNaN(temp_crystal.Volume) || double.IsInfinity(temp_crystal.Volume))
            return;

        TargetCrystal.A = temp_crystal.A;
        TargetCrystal.B = temp_crystal.B;
        TargetCrystal.C = temp_crystal.C;
        TargetCrystal.A_err = temp_crystal.A_err;
        TargetCrystal.B_err = temp_crystal.B_err;
        TargetCrystal.C_err = temp_crystal.C_err;

        TargetCrystal.Alpha = temp_crystal.Alpha;
        TargetCrystal.Beta = temp_crystal.Beta;
        TargetCrystal.Gamma = temp_crystal.Gamma;
        TargetCrystal.Alpha_err = temp_crystal.Alpha_err;
        TargetCrystal.Beta_err = temp_crystal.Beta_err;
        TargetCrystal.Gamma_err = temp_crystal.Gamma_err;

        TargetCrystal.SetAxis();
        TargetCrystal.Volume_err = temp_crystal.Volume_err;
        formMain.ChangeCrystalFromFitting();
        if (copy)
            CopyClipboard();
    }
    #endregion

    #region 最適格子定数をクリップボードコピー
    private void buttonCopyClipboard_Click(object sender, EventArgs e) => CopyClipboard();

    public void CopyClipboard()
    {
        //クリップボードに転送
        var sb = new StringBuilder();
        if (textBoxA.Text != "0.000000")
        {
            sb.Append(textBoxA.Text + "\t" + textBoxA_err.Text + "\t");
            sb.Append(textBoxB.Text + "\t" + textBoxB_err.Text + "\t");
            sb.Append(textBoxC.Text + "\t" + textBoxC_err.Text + "\t");
            sb.Append(textBoxAlpha.Text + "\t" + textBoxAlpha_err.Text + "\t");
            sb.Append(textBoxBeta.Text + "\t" + textBoxBeta_err.Text + "\t");
            sb.Append(textBoxGamma.Text + "\t" + textBoxGamma_err.Text + "\t");
            sb.Append(textBoxV.Text + "\t" + textBoxV_err.Text + "\t");
            try { Clipboard.SetDataObject(sb.ToString(), true); }
            catch { }
        }
    }
    #endregion

    #region dataGridViewPlanes関連のイベント

    /// <summary>
    /// 現在選択されている結晶の面をdataGridViewPlaneListに加える
    /// </summary>
    /// <param name="IsTargetCrystalChanged">
    /// ターゲットが変更された場合はTrue　このときはdataGridViewを全消去したあと、加える
    /// </param>
    public void SetPlanes(bool IsTargetCrystalChanged)
    {
        if (bindingSourceCrystals.Count == 0 || !(bool)((DataRowView)bindingSourceCrystals.Current).Row[0])
        {
            dataSet.DataTablePeakFitting.Clear();
            return;
        }
        IsCheckedListBoxSelectIndexChangeEventSkip = true;

        if (IsTargetCrystalChanged)
        {
            dataSet.DataTablePeakFitting.Clear();
            foreach (var p in TargetCrystal.Plane)
                dataSet.DataTablePeakFitting.Add(p);
        }
        else
        {
            if (TargetCrystal.FlexibleMode) //flexモードの時
            {
                for (int i = 0; i < TargetCrystal.Plane.Count; i++)
                {
                    if (dataSet.DataTablePeakFitting.Rows.Count >= i + 1)
                        dataSet.DataTablePeakFitting.Replace(i, TargetCrystal.Plane[i]);
                    else
                        dataSet.DataTablePeakFitting.Add(TargetCrystal.Plane[i]);
                }
                while (dataSet.DataTablePeakFitting.Rows.Count > TargetCrystal.Plane.Count)
                    dataSet.DataTablePeakFitting.RemoveAt(dataSet.DataTablePeakFitting.Rows.Count - 1);

            }
            else//通常結晶モードの時
            {
                //まず、チェックされている面指数をリストアップする
                var checkedItems = new List<string>();
                for (int i = 0; i < dataSet.DataTablePeakFitting.Rows.Count; i++)
                {
                    var r = dataSet.DataTablePeakFitting.GetRow(i);
                    if (r.Check)
                        checkedItems.Add(r.HKL);
                }

                for (int i = 0; i < TargetCrystal.Plane.Count; i++)
                {
                    if (dataSet.DataTablePeakFitting.Rows.Count >= i + 1)
                    {
                        //チェックされている面指数かどうかを判定して、IsFittingCheckedに反映させる
                        TargetCrystal.Plane[i].IsFittingChecked = checkedItems.Any(e => e == TargetCrystal.Plane[i].strHKL);
                        dataSet.DataTablePeakFitting.Replace(i, TargetCrystal.Plane[i]);
                    }
                    else
                        dataSet.DataTablePeakFitting.Add(TargetCrystal.Plane[i]);
                }
                while (dataSet.DataTablePeakFitting.Rows.Count > TargetCrystal.Plane.Count)
                    dataSet.DataTablePeakFitting.RemoveAt(dataSet.DataTablePeakFitting.Rows.Count - 1);
                Application.DoEvents();

            }
        }
        IsCheckedListBoxSelectIndexChangeEventSkip = false;
    }

    private void refleshTable()
    {
        dataGridViewPlaneList.DataSource = null;
        dataSet.DataTablePeakFitting.Refresh();
        dataGridViewPlaneList.DataSource = bindingSourcePlanes;
    }
    private void dataGridViewPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.RowIndex >= 0)
        {
            TargetCrystal.Plane[e.RowIndex].IsFittingChecked = (bool)((DataGridView)sender)[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
            Fitting();
        }

        dataGridViewPlaneList_SelectionChanged(new object(), new EventArgs());
    }

    public void dataGridViewPlaneList_SelectionChanged(object sender, EventArgs e)
    {
        if (IsCheckedListBoxSelectIndexChangeEventSkip || TargetCrystal == null) return;
        if (bindingSourcePlanes.Position >= 0)
        {
            var n = bindingSourcePlanes.Position;
            formMain.SelectedPlaneIndex = n;
            if (TargetCrystal.Plane.Count <= n)
                return;
            formMain.Draw();
            IsRadioButtonChangeEventSkip = true;
            switch (TargetCrystal.Plane[n].SerchOption)
            {
                case PeakFunctionForm.Simple: radioButtonSimple.Checked = true; break;
                case PeakFunctionForm.PseudoVoigt: radioButtonPseudoVoigt.Checked = true; break;
                case PeakFunctionForm.Peason: radioButtonSymmetricPearson.Checked = true; break;
                case PeakFunctionForm.SplitPearson: radioButtonSplitPearson.Checked = true; break;
                case PeakFunctionForm.SplitPseudoVoigt: radioButtonSplitPseudoVoigt.Checked = true; break;
            }
            IsRadioButtonChangeEventSkip = false;

            IsSkipChangeEvent = true;
            numericUpDownSearchRange.Value = (decimal)(TargetCrystal.Plane[n].SerchRange * SerchRangeFactor);
            numericUpDownInitialFWHM.Value = (decimal)(TargetCrystal.Plane[n].FWHM * SerchRangeFactor);
            IsSkipChangeEvent = false;
        }
    }
    #endregion

    #region dataGridViewCrystalsのイベント (formMainに転送)
    private void dataGridViewCrystals_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) => formMain.dataGridViewCrystals_CellMouseClick(sender, e);
    private void dataGridViewCrystals_KeyDown(object sender, KeyEventArgs e) => formMain.dataGridViewCrystals_KeyDown(sender, e);
    #endregion 

    #region 最適格子定数の設定
    private void SetTextBox(Crystal c)
    {
        OptimizedCellConstants = (c.A, c.B, c.C, c.Alpha, c.Beta, c.Gamma, c.Volume);
        OptimizedCellConstants_Err = (c.A_err, c.B_err, c.C_err, c.Alpha_err, c.Beta_err, c.Gamma_err, c.Volume_err);

        textBoxA.Text = (c.A * 10).ToString("f6");
        textBoxB.Text = (c.B * 10).ToString("f6");
        textBoxC.Text = (c.C * 10).ToString("f6");
        textBoxAlpha.Text = (c.Alpha * 180 / Math.PI).ToString("f5");
        textBoxBeta.Text = (c.Beta * 180 / Math.PI).ToString("f5");
        textBoxGamma.Text = (c.Gamma * 180 / Math.PI).ToString("f5");

        textBoxA_err.Text = (c.A_err > -1) ? (c.A_err * 10).ToString("f6") : "NA";
        textBoxB_err.Text = (c.B_err > -1) ? (c.B_err * 10).ToString("f6") : "NA";
        textBoxC_err.Text = (c.C_err > -1) ? (c.C_err * 10).ToString("f6") : "NA";
        textBoxAlpha_err.Text = (c.Alpha_err > -1) ? (c.Alpha_err * 180 / Math.PI).ToString("f5") : "NA";
        textBoxBeta_err.Text = (c.Beta_err > -1) ? (c.Beta_err * 180 / Math.PI).ToString("f5") : "NA";
        textBoxGamma_err.Text = (c.Gamma_err > -1) ? (c.Gamma_err * 180 / Math.PI).ToString("f5") : "NA";

        textBoxV.Text = (c.Volume * 1000).ToString("f6");
        textBoxV_err.Text = (c.Volume_err > -1) ? (c.Volume_err * 1000).ToString("f6") : "NA";
    }

    private void textBoxA_TextChanged(object sender, System.EventArgs e)
    {
        buttonConfirm.Enabled = buttonCopyCellConstantsToClipboard.Enabled = temp_crystal.A > 0;

        buttonResetTakeoffAngle.Enabled = temp_crystal.A > 0;
    }
    #endregion

    #region ピーク関数、半値幅、検索範囲などの設定
    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (IsRadioButtonChangeEventSkip) return;
        if (dataGridViewCrystals.RowCount > 0 && dataGridViewCrystals.SelectedRows[0].Index > -1 && ((System.Windows.Forms.RadioButton)sender).Checked)
        {
            int n = dataGridViewPlaneList.SelectedRows[0].Index;
            if (radioButtonSimple.Checked)
                TargetCrystal.Plane[n].SerchOption = TargetCrystal.Plane[n].peakFunction.Option = PeakFunctionForm.Simple;
            else if (radioButtonPseudoVoigt.Checked)
                TargetCrystal.Plane[n].SerchOption = TargetCrystal.Plane[n].peakFunction.Option = PeakFunctionForm.PseudoVoigt;
            else if (radioButtonSymmetricPearson.Checked)
                TargetCrystal.Plane[n].SerchOption = TargetCrystal.Plane[n].peakFunction.Option = PeakFunctionForm.Peason;
            else if (radioButtonSplitPseudoVoigt.Checked)
                TargetCrystal.Plane[n].SerchOption = TargetCrystal.Plane[n].peakFunction.Option = PeakFunctionForm.SplitPseudoVoigt;
            else if (radioButtonSplitPearson.Checked)
                TargetCrystal.Plane[n].SerchOption = TargetCrystal.Plane[n].peakFunction.Option = PeakFunctionForm.SplitPearson;

            Fitting();
            IsCheckedListBoxSelectIndexChangeEventSkip = true;
            dataGridViewPlaneList.Rows[n].Selected = true;
            IsCheckedListBoxSelectIndexChangeEventSkip = false;
            formMain.Draw();
        }
    }

    private void numericUpDownSearchRange_ValueChanged(object sender, EventArgs e)
    {
        if (IsSkipChangeEvent) return;
        if (dataGridViewPlaneList.SelectedRows[0].Index < 0) return;
        int n = dataGridViewPlaneList.SelectedRows[0].Index;
        TargetCrystal.Plane[n].SerchRange = (double)numericUpDownSearchRange.Value / SerchRangeFactor;
        if (checkBoxUseInitialFWHM.Checked)
            TargetCrystal.Plane[n].FWHM = (double)numericUpDownInitialFWHM.Value / SerchRangeFactor;
        else
            TargetCrystal.Plane[n].FWHM = TargetCrystal.Plane[n].SerchRange / 2.0;

        Fitting();
        IsCheckedListBoxSelectIndexChangeEventSkip = true;
        dataGridViewPlaneList.Rows[n].Selected = true;
        IsCheckedListBoxSelectIndexChangeEventSkip = false;
    }

    private void buttonApplyRangeToAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < TargetCrystal.Plane.Count; i++)
            TargetCrystal.Plane[i].SerchRange = (double)numericUpDownSearchRange.Value / SerchRangeFactor;
        Fitting();
    }

    private void buttonApplyFWHMToAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < TargetCrystal.Plane.Count; i++)
            TargetCrystal.Plane[i].FWHM = (double)numericUpDownInitialFWHM.Value / SerchRangeFactor;
        Fitting();
    }

    private void buttonApplyFunctionToAll_Click(object sender, EventArgs e)
    {
        PeakFunctionForm form;
        if (radioButtonSimple.Checked)
            form = PeakFunctionForm.Simple;
        else if (radioButtonPseudoVoigt.Checked)
            form = PeakFunctionForm.PseudoVoigt;
        else if (radioButtonSplitPseudoVoigt.Checked)
            form = PeakFunctionForm.SplitPseudoVoigt;
        else if (radioButtonSymmetricPearson.Checked)
            form = PeakFunctionForm.Peason;
        else
            form = PeakFunctionForm.SplitPearson;

        for (int i = 0; i < TargetCrystal.Plane.Count; i++)
            TargetCrystal.Plane[i].SerchOption = form;
        Fitting();
    }
    private void checkBoxPatternDecomposition_CheckedChanged(object sender, EventArgs e)
    {
        flowLayoutPanelPatternDecomposition.Enabled = checkBoxPatternDecomposition.Checked;
        Fitting();
    }

    private void radioButtonEachCrystal_CheckedChanged(object sender, EventArgs e) => Fitting();

    private void checkBoxUseInitialFWHM_CheckedChanged(object sender, EventArgs e)
    {
        panelFWHM.Enabled = checkBoxUseInitialFWHM.Checked;
        numericUpDownSearchRange_ValueChanged(sender, e);
    }

    #endregion

    #region その他イベント
    private void FormFitting_KeyDown(object sender, KeyEventArgs e) => formMain.FormMain_KeyDown(sender, e);
    private void FormFitting_VisibleChanged(object sender, EventArgs e)
    {
        if (Visible)
        {
            //dataGridViewの色の設定
            for (int i = 0; i < dataGridViewCrystals.Rows.Count; i++)
                dataGridViewCrystals.Rows[i].DefaultCellStyle = formMain.dataGridViewCrystals.Rows[i].DefaultCellStyle;
            SetPlanes(true);
        }
    }

    private void NumericBoxEffectiveDigit_ValueChanged(object sender, EventArgs e)
        => dataGridViewPlaneList.DefaultCellStyle.Format = $"g{numericBoxEffectiveDigit.ValueInteger.ToString()}";

    private void buttonResetTakeoffAngle_Click(object sender, EventArgs e)
    {
        if (formMain.AxisMode == HorizontalAxis.EnergyXray)
        {
            var dp = (DiffractionProfile)((DataRowView)formMain.bindingSourceProfile.Current).Row[1];
            //dp.SrcTakeoffAngle = xAxisUserControl.TakeoffAngle;
            formMain.horizontalAxisUserControl_AxisPropertyChanged();
        }
    }
    #endregion

    #region formMainから横軸単位が変更されたとき
    internal void ChangeHorizontalAxis()
    {
        if (formMain.AxisMode == HorizontalAxis.Angle)
            SerchRangeFactor = 1;
        else if (formMain.AxisMode == HorizontalAxis.EnergyXray)
            SerchRangeFactor = 5000;
        else if (formMain.AxisMode == HorizontalAxis.d)
            SerchRangeFactor = 0.2;
        else if (formMain.AxisMode == HorizontalAxis.NeutronTOF)
            SerchRangeFactor = 5000;
        else if (formMain.AxisMode == HorizontalAxis.WaveNumber)
            SerchRangeFactor = 0.2;

        numericUpDownInitialFWHM.Increment = (decimal)(SerchRangeFactor * 0.02);

        SetPlanes(false);
    }
    #endregion

    #region CellFinderに情報を転送
    private void buttonSendToCellFinder_Click(object sender, EventArgs e)
    {

        formMain.formCellFinder.dataSet1.Tables[0].Rows.Clear();
        formMain.formAtomicPositionFinder.dataSet.DataTableDiffractionData.Rows.Clear();
        for (int i = 0; i < TargetCrystal.Plane.Count; i++)
        {
            if (TargetCrystal.Plane[i].IsFittingChecked && TargetCrystal.Plane[i].SerchOption == PeakFunctionForm.Simple || TargetCrystal.Plane[i].observedIntensity > 0)
            {
                formMain.formCellFinder.dataSet1.Tables[0].Rows.Add(TargetCrystal.Plane[i].d * 10, "High", true, null, null, null, null, null, TargetCrystal.Plane[i].observedIntensity);
                formMain.formAtomicPositionFinder.dataSet.DataTableDiffractionData.Rows.Add(true, TargetCrystal.Plane[i].d * 10, TargetCrystal.Plane[i].observedIntensity);
            }
        }
        // dataSet1.Tables[0].Rows.Add(new object[] { numericalTextBox1.Value,comboBoxReliability.Text,true });
    }
    #endregion

    #region RemovePeaks機能

    private void buttonRemovePeaks_Click(object sender, EventArgs e)
    {
        if (TargetCrystal == null || TargetProfile == null) return;

        var p = new Profile();
        p.Pt.AddRange(TargetProfile.Pt.ToArray());
        if (TargetCrystal.Plane != null)
            foreach (Plane plane in TargetCrystal.Plane)
                if (plane.IsFittingChecked && plane.SerchOption != PeakFunctionForm.Simple)
                {
                    PeakFunction pvp = plane.peakFunction;
                    pvp.RenewParameter();
                    double startTheta = plane.XCalc - plane.SerchRange * SerchRangeFactor;
                    double endTheta = plane.XCalc + plane.SerchRange * SerchRangeFactor;
                    if (pvp.Hk != 0 && !double.IsNaN(pvp.X))
                        for (int k = 0; k < p.Pt.Count && p.Pt[k].X < endTheta; k++)
                            if (p.Pt[k].X > startTheta)
                                //p.Pt[k].Y  -= pvp.GetValue(p.Pt[k].X, false);
                                p.Pt[k] -= new PointD(0, pvp.GetValue(p.Pt[k].X, false));
                }


        var output = new DiffractionProfile
        {
            OriginalProfile = p,
            Name = RemovedProfileName,
            ColorARGB = formMain.generateRandomColor().ToArgb(),
            WaveSource = formMain.WaveSource,
            WaveColor = formMain.WaveColor,
            SrcAxisMode = formMain.AxisMode,
            XrayElementNumber = formMain.XraySourceElementNumber,
            XrayLine = formMain.XraySourceLine,
            SrcWaveLength = formMain.WaveLength,
            SrcTakeoffAngle = formMain.TakeoffAngle,
            SrcTofAngle = formMain.TakeoffAngle,
            SrcTofLength = formMain.TofLength
        };

        formMain.AddProfileToCheckedListBox(output, true, true);
    }
    #endregion
}
