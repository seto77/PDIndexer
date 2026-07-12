using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crystallography;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;


namespace PDIndexer
{

    public partial class FormTwoThetaCalibration : FormBase //260604Cl Form→FormBase (F1ヘルプ対応)
    {
        //public FormMain formMain = new FormMain(); // (260624Ch) 旧: 子フォーム生成時に不要な FormMain を生成していた
        public FormMain formMain; // (260624Ch)

        double coeff0_old = double.NaN, coeff1_old = double.NaN, coeff2_old = double.NaN;

        public FormTwoThetaCalibration()
        {
            InitializeComponent();
            HelpPage = "4-profile-parameter"; //260604Cl 追加: F1で該当オンラインマニュアルを開く
            //260625Cl 追加: 動的ラベルの初期表示を現 UI カルチャ訳で確定 (buttonCalibrate は実行中 NowCalibrating にトグル)。
            buttonCalibrate.Text = PdiText.Calibrate;
            numericUpDownOrder_ValueChanged(this, EventArgs.Empty); // labelEquation を現在の次数で初期化
        }

        private void FormTwoThetaCalibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void FormTwoThetaCalibration_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void FormTwoThetaCalibration_MouseMove(object sender, MouseEventArgs e)
        {
           buttonCalibrate.Enabled = formMain.formFitting.Visible;
        }

        private void numericUpDownOrder_ValueChanged(object sender, EventArgs e)
        {
            labelEquation.Text = string.Format(PdiText.ShiftFunction, numericUpDownOrder.Value switch //260712Cl switch式に集約 (式は不変、"Shift function:" のみ訳)
            {
                3 => "Δ(2θ) = a1 + a2 tan(θ) + a3 tan^2(θ) ",
                2 => "Δ(2θ) = a1 + a2 tan(θ)",
                _ => "Δ(2θ) = a1",
            });
        }

        private void buttonCalibrate_Click(object sender, EventArgs e)
        {
            //まず、現在のcoeffを保存
            DiffractionProfile2 dp = (DiffractionProfile2)((DataRowView)formMain.bindingSourceProfile.Current).Row[1];
            coeff0_old = dp.TwoThetaOffsetCoeff0;
            coeff1_old = dp.TwoThetaOffsetCoeff1;
            coeff2_old = dp.TwoThetaOffsetCoeff2;

            buttonCalibrate.Text = PdiText.NowCalibrating; //260625Cl 多言語化(旧 "Now calibrationg..." typo修正)
            this.Enabled = false;

            for (int n = 0; n < 8; n++)
            {
                formMain.formFitting.Fitting();

                List<double> twoThetaObs = []; //260317Cl new List<double>() → []
                List<double> twoThetaCalc = []; //260317Cl new List<double>() → []

                foreach (var p in formMain.formFitting.TargetCrystal.Plane)
                    if (p.IsFittingChecked && !double.IsNaN(p.XObs) && !double.IsNaN(p.XCalc))
                    {
                        twoThetaObs.Add(p.XObs);
                        twoThetaCalc.Add(p.XCalc);
                    }
                int count = twoThetaCalc.Count;
                if (count == 0) return;

                int order = Math.Min((int)numericUpDownOrder.Value, count);

                var X = new DenseMatrix(count, order);
                var Y = new DenseMatrix(count, 1);
                for (int i = 0; i < count; i++)
                {
                    double tan = Math.Tan(twoThetaCalc[i] / 360.0 * Math.PI);
                    double pow = 1; //260712Cl Math.Pow(tan, j) を逐次乗算に (Pow は指数を double 扱いで低速)
                    for (int j = 0; j < order; j++, pow *= tan)
                        X[i, j] = pow;
                    Y[i, 0] = Math.Tan(twoThetaCalc[i] - twoThetaObs[i]);
                }
                var inv = (X.Transpose() * X).TryInverse();
                if (inv != null)
                {
                    var A = inv * X.Transpose() * Y;
                    if (order > 0)
                        formMain.formProfile.TwoThetaOffsetCoeff0 += A[0, 0] * 0.9;
                    else
                        formMain.formProfile.TwoThetaOffsetCoeff0 = 0;
                    if (order > 1)
                        formMain.formProfile.TwoThetaOffsetCoeff1 += A[1, 0] * 0.9;
                    else
                        formMain.formProfile.TwoThetaOffsetCoeff1 = 0;

                    if (order > 2)
                        formMain.formProfile.TwoThetaOffsetCoeff2 += A[2, 0] * 0.9;
                    else
                        formMain.formProfile.TwoThetaOffsetCoeff2 = 0;
                }
            }

            buttonCalibrate.Text = PdiText.Calibrate; //260625Cl 多言語化(旧 "Calibrate")
            this.Enabled = true;
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            if (!double.IsNaN(coeff0_old))
            {
                formMain.formProfile.TwoThetaOffsetCoeff0 = coeff0_old;
                formMain.formProfile.TwoThetaOffsetCoeff1 = coeff1_old;
                formMain.formProfile.TwoThetaOffsetCoeff2 = coeff2_old;
            }
        }




    }
}
