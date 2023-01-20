#region Using
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crystallography;
using MathNet.Numerics.LinearAlgebra.Double;
#endregion

namespace PDIndexer;

public partial class FormSequentialAnalysis : Form
{
    #region プロパティ、フィールド、イベント
    public FormMain formMain;

    private readonly Stopwatch sw = new Stopwatch();
    #endregion

    #region コンストラクタ、オープン、クローズ
    public FormSequentialAnalysis()
    {
        InitializeComponent();
    }

    private void FormStressAnalysis_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        formMain.toolStripButtonSequentialAnalysis.Checked = false;
    }
    #endregion

    #region 解析
    private void buttonExecute_Click(object sender, EventArgs e)
    {
        if (formMain == null || formMain.formFitting == null || formMain.formFitting.Visible == false)
        {
            MessageBox.Show("Fitting Difraction Peak フォームを立ち上げ、解析したいピークをチェックした状態で実行してください.");
            return;
        }
        if (formMain.dataSet.DataTableProfile.Items.Count < 4)
            return;

        sw.Restart();
        var crystal = formMain.formFitting.TargetCrystal;
        double initA = crystal.A, initB = crystal.B, initC = crystal.C, initAlpha = crystal.Alpha, initBeta = crystal.Beta, initGamma = crystal.Gamma;

        //ストレス解析モードかどうか。
        var stressMode = formMain.dataSet.DataTableProfile.Rows[0][1].ToString().EndsWith("whole");

        var indexStr = new List<string>();
        var results = new List<List<PointD>>();

        var text = stressMode ? "Degree | Index" : "Profile Name | Index";
        var plane = formMain.formFitting.TargetCrystal.Plane.ToArray();

        int m = 0;
        foreach (var p in plane.Where(e => e.IsFittingChecked))
        {
            if (formMain.SelectedCrysatlIndex == 0)//flexible crystalを選択している場合
            {
                text += $"\tPeak No.{m}";
                indexStr.Add($"\tPeak No.{m++}");
            }
            else//一般の crystalを選択している場合
            {
                text += "\t" + p.strHKL;
                indexStr.Add(p.strHKL);
            }
            results.Add(new List<PointD>());
        }

        textBox2theta.Text = $"{text}\r\n";
        textBoxDspacing.Text = $"{text}\r\n";
        textBoxFWHM.Text = $"{text}\r\n";
        textBoxIntensity.Text = $"{text}\r\n";
        textBoxCellConstants.Text = (stressMode ? "Degree" : "Profile Name") + "\tV\tV_err\tA\tA_err\tB\tB_err\tC\tC_err\tAlpha\tAlpha_err\tBeta\tBeta_err\tGamma\tGamma_err\r\n";

        Func<(string Researcher, double Pressure)[]> eos = formMain.bindingSourceCrystal.Position switch
        {
            1 => formMain.formEOS.Gold,
            2 => formMain.formEOS.Pt,
            3 => formMain.formEOS.NaClB1,
            4 => formMain.formEOS.NaClB2,
            5 => formMain.formEOS.MgO,
            6 => formMain.formEOS.Corundum,
            7 => formMain.formEOS.Ar,
            8 => formMain.formEOS.Re,
            9 => formMain.formEOS.Mo,
            10 => formMain.formEOS.Pb,
            _ => null
        };

        if (eos == null)
            textBoxPressure.Text = (stressMode ? "Degree" : "Profile Name") + "\tPressure\r\n";
        else
        {
            textBoxPressure.Text = stressMode ? "Degree" : "Profile Name";
            foreach (var researcher in eos().Select(e => e.Researcher))
                textBoxPressure.AppendText("\t"+researcher);
            textBoxPressure.AppendText("\r\n");

            formMain.toolStripButtonEquationOfState.Checked = true;
        }

        int initialPosition = stressMode ? 1 : formMain.bindingSourceProfile.Position;

        var total = formMain.dataSet.DataTableProfile.Items.Count;

        //現在のプロファイルチェック状況を保存後、全てチェック外す
        var checkStates= new List<bool>();
        for (int i = 0; i < total; i++)
            checkStates.Add(formMain.dataSet.DataTableProfile.GetItemChecked(i));
        formMain.dataSet.DataTableProfile.AllUnchecked = true;

        formMain.Enabled = false;

        //ここから、メインのループ
        for (int i = initialPosition; i < total; i++)
        {
            formMain.SkipDrawing = true;//メイン画面の描画をキャンセル
            formMain.bindingSourceProfile.Position = i;

            formMain.dataSet.DataTableProfile.SetItemChecked(formMain.bindingSourceProfile.Position, true);

            //最小二乗法フィッティングを二回実行
            for (int n = 0; n < 2; n++)
            {
                formMain.formFitting.SkipFitting = false;
                formMain.formFitting.Fitting();
                formMain.formFitting.SkipFitting = true;
                if (formMain.formFitting.textBoxA.Text != "0.000000")//最小2乗法がうまくいった場合は
                    formMain.formFitting.Confirm(false);
                #region お蔵入り
                //else//もし最小2乗法がうまくいかない場合は
                //{
                //    if (formMain.SelectedCrysatlIndex == 0)//flexible crystalの場合
                //    {
                //        foreach (var p in plane.Where(e => e.IsFittingChecked && !double.IsNaN(e.peakFunction.X)))
                //            p.d = formMain.WaveLength / 2 / Math.Sin(p.XObs / 180.0 * Math.PI / 2);
                //    }
                //    else//普通crystalの場合
                //    {
                //        var tempRatio = new List<double>();
                //        foreach (var p in plane.Where(e => e.IsFittingChecked && !double.IsNaN(e.peakFunction.X) && e.peakFunction.Int!=0))
                //            tempRatio.Add(Math.Sin(p.XCalc / 180.0 * Math.PI / 2) / Math.Sin(p.peakFunction.X / 180.0 * Math.PI / 2));
                //        if (tempRatio.Count > 0)
                //        {
                //            var ratio = tempRatio.Average();
                //            formMain.formFitting.TargetCrystal.A *= ratio;
                //            formMain.formFitting.TargetCrystal.B *= ratio;
                //            formMain.formFitting.TargetCrystal.C *= ratio;
                //            formMain.formFitting.TargetCrystal.SetAxis();
                //            formMain.ChangeCrystalFromFitting();
                //        }
                //    }
                //}
                #endregion
            }

            formMain.SkipDrawing = false;
            formMain.Draw();

            var profileName = ((DiffractionProfile)((DataRowView)formMain.bindingSourceProfile.Current).Row[1]).Name;
            var angle = 0.0;
            if (stressMode)
            {
                profileName = profileName.Split('-')[^1];
                if (!double.TryParse(profileName, out angle))
                    return;
                angle = angle / 180 * Math.PI;
            }

            textBox2theta.AppendText(profileName);
            textBoxDspacing.AppendText(profileName);
            textBoxFWHM.AppendText(profileName);
            textBoxIntensity.AppendText(profileName);
            textBoxPressure.AppendText(profileName);
            textBoxCellConstants.AppendText(profileName);

            m = 0;
            StringBuilder sb2theta = new(), sbDspacing = new(), sbIntensity = new(), sbFWHM = new();
            foreach (var p in crystal.Plane.Where(e => e.IsFittingChecked))
            {
                sb2theta.Append($"\t{p.peakFunction.X:f10}");
                sbDspacing.Append($"\t{(formMain.WaveLength * 10 / 2 / Math.Sin(p.peakFunction.X / 180 * Math.PI / 2)):f10}");
                sbIntensity.Append($"\t{p.peakFunction.GetIntegral():g10}");
                sbFWHM.Append($"\t{p.peakFunction.Hk:f8}");
                if (stressMode)
                    results[m++].Add(new PointD(angle, formMain.WaveLength / 2 / Math.Sin(p.peakFunction.X / 180 * Math.PI / 2)));
            }
            textBox2theta.AppendText($"{sb2theta}\r\n");
            textBoxDspacing.AppendText($"{sbDspacing}\r\n");
            textBoxIntensity.AppendText($"{sbIntensity}\r\n");
            textBoxFWHM.AppendText($"{sbFWHM}\r\n");

            textBoxCellConstants.AppendText($"\t{crystal.Volume * 1000:f8}\t{crystal.Volume_err * 1000:f8}" +
                $"\t{crystal.A * 10:f10}\t{crystal.A_err * 10:f10}" +
                $"\t{crystal.B * 10:f10}\t{crystal.B_err * 10:f10}" +
                $"\t{crystal.C * 10:f10}\t{crystal.C_err * 10:f10}" +
                $"\t{crystal.Alpha / Math.PI * 180:g10}\t{crystal.Alpha_err / Math.PI * 180:g10}" +
                $"\t{crystal.Beta / Math.PI * 180:g10}\t{crystal.Beta_err / Math.PI * 180:g10}" +
                $"\t{crystal.Gamma / Math.PI * 180:g10}\t{crystal.Gamma_err / Math.PI * 180:g10}" +
                $"\r\n");

            if (eos != null)
            {
                foreach (var pressure in eos().Select(e => e.Pressure))
                    textBoxPressure.AppendText($"\t{pressure:f8}");
                textBoxPressure.AppendText("\r\n");
            }
            else
                textBoxPressure.AppendText($"\t{crystal.EOSCondition.GetPressure(crystal.Volume * 1000):f8}\r\n");

            formMain.dataSet.DataTableProfile.SetItemChecked(formMain.bindingSourceProfile.Position, false);//チェック状態を解除

            toolStripStatusLabel1.Text = $"{100.0 * i / total:f1} % completed.  Ellappsed time: {sw.ElapsedMilliseconds / 1000.0:f1} sec";
            Application.DoEvents();
        }

        for (int i = 0; i < total; i++)
            formMain.dataSet.DataTableProfile.SetItemChecked(i, checkStates[i]);

        Application.DoEvents();
        formMain.Enabled = true;
        formMain.formFitting.SkipFitting = false;

        Clipboard.SetDataObject(
            $"2theta\r\n{textBox2theta.Text}\r\n\r\n" +
            $"d-spacing\r\n{textBoxDspacing.Text}\r\n\r\n" +
            $"FWHM\r\n{textBoxFWHM.Text}\r\n\r\n" +
            $"Intensity\r\n{textBoxIntensity.Text}\r\n\r\n"
            );

        if (stressMode)
            RefineSinghEquation(indexStr, results);

        formMain.formFitting.TargetCrystal.A = initA;
        formMain.formFitting.TargetCrystal.B = initB;
        formMain.formFitting.TargetCrystal.C = initC;
        formMain.formFitting.TargetCrystal.SetAxis();
        formMain.bindingSourceProfile.Position = initialPosition;

        formMain.ChangeCrystalFromFitting();

        toolStripStatusLabel1.Text = $"100 % Completed!  Ellappsed time: {sw.ElapsedMilliseconds / 1000.0:f1} sec";
    }
    #endregion

    #region Singhの式の最適化
    private void RefineSinghEquation(List<string> indexStr, List<List<PointD>> results)
    {
        textBoxResults.Text = "";

        for (int i = 0; i < results.Count; i++)                //マルカールの方法でPseudoVoigtをとく。高速になるはず
        {
            List<PointD> d = results[i];
            double alpha = -0.5, d0 = 0, psiMax = 0;
            double alpha_New, d0_New, psiMax_New;
            //範囲内で一番d値が小さい点を見つける
            double minD = double.PositiveInfinity;
            double maxD = double.NegativeInfinity;
            for (int j = 0; j < d.Count/2; j++)
            {
                if (minD > d[j].Y)
                {
                    minD = d[j].Y;
                    psiMax = d[j].X;
                }
                maxD = Math.Max(d[j].Y, maxD);
            }
            d0 = (minD + maxD) / 2;

            double[,] diff = new double[3, d.Count];
            var Alpha = new DenseMatrix(3, 3);
           var Beta = new DenseMatrix(3, 1);
            double[] ResidualCurrent = new double[d.Count],ResidualNew = new double[d.Count];
            double ResidualSquareCurrent = 0, ResidualSquareNew = 0;
            int count = 0;

            //現在の残差を計算
            ResidualSquareCurrent = 0;
            for (int j = 0; j < d.Count; j++)
            {
                ResidualCurrent[j] = dValue(d0, alpha, d[j].X, psiMax, d0) - d[j].Y;
                ResidualSquareCurrent += ResidualCurrent[j] * ResidualCurrent[j];
            }

            double ramda = 1;
            double diff_D0 = 0.0001;
            double diff_alpha = 0.0001;
            double diff_psiMax = 0.0001;

            while (ramda < 1000000000 && count < 300)
            {
                count++;
                for (int j = 0; j < d.Count; j++)//偏微分を作る
                {
                    diff[0, j] = (dValue(d0 + diff_D0, alpha, d[j].X, psiMax, d0) - dValue(d0 - diff_D0, alpha, d[j].X, psiMax, d0)) / diff_D0 / 2;  //∂F/∂d0 
                    diff[1, j] = (dValue(d0, alpha + diff_alpha, d[j].X, psiMax, d0) - dValue(d0, alpha - diff_alpha, d[j].X, psiMax, d0)) / diff_alpha / 2;    //∂F/∂alpha 
                    diff[2, j] = (dValue(d0, alpha, d[j].X, psiMax + diff_psiMax, d0) - dValue(d0, alpha, d[j].X, psiMax - diff_psiMax, d0)) / diff_psiMax / 2;//∂F/∂psiMax
                }

                //行列Alpha, Betaを作る
                for (int k = 0; k < 3; k++)
                {
                    for (int l = 0; l < 3; l++)
                    {
                        Alpha[k, l] = 0;
                        for (int j = 0; j < d.Count; j++)
                            Alpha[k, l] += diff[k, j] * diff[l, j];
                        if (k == l)
                            Alpha[k, l] *= (1 + ramda);
                    }
                    Beta[k, 0] = 0;
                    for (int j = 0; j < d.Count; j++)
                        Beta[k, 0] += ResidualCurrent[j] * diff[k, j];
                }
                var alphaInv = Alpha.TryInverse();
                if (alphaInv == null)
                    break;
                var delta = alphaInv * Beta;

                d0_New = d0 - delta[0, 0];
                alpha_New = alpha - delta[1, 0];
                psiMax_New = psiMax - delta[2, 0];

                //あたらしいパラメータでの残差を計算
                ResidualSquareNew = 0;
                for (int j = 0; j < d.Count; j++)
                {
                    ResidualNew[j] = dValue(d0_New, alpha_New, d[j].X, psiMax_New, d0_New) - d[j].Y; ;
                    ResidualSquareNew += ResidualNew[j] * ResidualNew[j];
                }
                if (ResidualSquareCurrent > ResidualSquareNew)
                    if (Math.Abs(ResidualSquareCurrent - ResidualSquareNew) / ResidualSquareCurrent > 0.0000000001)
                    {
                        ResidualSquareCurrent = ResidualSquareNew;
                        ramda *= 0.2;
                        for (int j = 0; j < d.Count; j++)
                            ResidualCurrent[j] = ResidualNew[j];
                        alpha = alpha_New; d0 = d0_New; psiMax = psiMax_New;
                    }
                    else
                        break;
                else
                    ramda *= 5;
            }
            textBoxResults.Text += indexStr[i] + "\td0:\t" + (d0 * 10).ToString("g6") + "\tΨmax:\t" + (psiMax / Math.PI * 180).ToString("g6") + "\t t/6Ghkl:\t" + alpha.ToString("g6") + "\r\n";

           Profile  p2 = new Profile();
           // for (int j = 0; j < d.Count; j++)
           //     p1.Pt.Add(new PointD(d[j].X / Math.PI * 180, d[j].Y * 10));
            for (int j = 0; j < 360; j++)
                p2.Pt.Add(new PointD(j, 10*dValue(d0, alpha, j / 180.0 * Math.PI, psiMax, d0)));
          //  graphControl1.ClearProfile();
            
           // graphControl1.AddProfile(p1);
           // p2.Color = Color.Red;
            graphControl1.AddProfile(p2);

            

        }


    }

    /// <summary>
    /// RefineSinghEquationから呼ばれる関数
    /// </summary>
    /// <param name="d0"></param>
    /// <param name="alpha"></param>
    /// <param name="psi"></param>
    /// <param name="psiMax"></param>
    /// <param name="initD"></param>
    /// <returns></returns>
    private double dValue(double d0, double alpha, double psi, double psiMax, double initD)
    {
        double step = 0.1;
        double range = 1;

        double ramda2 = formMain.WaveLength*formMain.WaveLength;
        double cos = Math.Cos(psi - psiMax);

        double minDiv = double.PositiveInfinity;
        double bestD = initD;

        for (int n = 0; n < 30; n++)
        {
            for (double d = initD - range; d <= initD + range && d+step !=d; d += step)
            {
                double f = Math.Abs(d0 * (1 + alpha - 3 * alpha * (1 - ramda2 / 4 / d / d) * cos * cos) - d);
                if (f < minDiv)
                {
                   minDiv = f;
                    bestD = d;
                }
            }
            initD = bestD;

            if (Math.Abs(initD - bestD) < range * 0.5)
            {
                step *= 0.4;
                range *= 0.4;
            }
        }
        return bestD;
    }
    private void numericalTextBoxD0_ValueChanged(object sender, EventArgs e)
    {
        graphControl1.ClearProfile();
        Profile p2 = new Profile();
        for (int j = 0; j < 360; j++)
            p2.Pt.Add(new PointD(j, 10 * dValue(numericalTextBoxD0.Value * 0.1, numericalTextBoxAlpha.Value, j / 180.0 * Math.PI, numericalTextBoxPsimax.Value / 180 * Math.PI, numericalTextBoxD0.Value * 0.1)));
        graphControl1.ClearProfile();
        graphControl1.AddProfile(p2);
    }


    #endregion

    #region Copy, Save

    private void buttonCopy_Click(object sender, EventArgs e)
    {
        Clipboard.SetDataObject(GetText(false));
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        var dlg = new SaveFileDialog() { Filter="*.csv|*.csv"};
        if(dlg.ShowDialog() == DialogResult.OK) 
        {
            var sw = new StreamWriter(dlg.FileName);
            sw.Write(GetText());
            sw.Close();
        }
    }

    public void Save(string filename, bool CSV=true, int index=-1)
    {

    }

    /// <summary>
    /// 計算結果をタブ区切りあるいはカンマ区切りテキストとして得る。
    /// index = -1:アクティブなタブ, 0: 2θ, 1: d, 2: 半値幅, 3: 強度, 4: 格子定数, 5: 圧力, 6: Singh
    /// </summary>
    /// <param name="CSV"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public string GetText( bool CSV = true, int index = -1)
    {
        if (index == -1)
            index = tabControl.SelectedIndex;

        var txt = index switch
        {
            0 => textBox2theta.Text,
            1 => textBoxDspacing.Text,
            2 => textBoxFWHM.Text,
            3 => textBoxIntensity.Text,
            4 => textBoxCellConstants.Text,
            5 => textBoxPressure.Text,
            6 => textBoxResults.Text,
            _ => ""
        };

        return CSV ? txt.Replace('\t', ',') : txt;
    }

    #endregion


}
