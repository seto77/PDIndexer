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

    public partial class FormTwoThetaCalibration : Form
    {
        public FormMain formMain = new FormMain();

        double coeff0_old = double.NaN, coeff1_old = double.NaN, coeff2_old = double.NaN;

        public FormTwoThetaCalibration()
        {
            InitializeComponent();
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
            if (numericUpDownOrder.Value == 3)
                labelEquation.Text = "Shift function: Δ(2θ) = a1 + a2 tan(θ) + a3 tan^2(θ) ";
            else if (numericUpDownOrder.Value == 2)
                labelEquation.Text = "Shift function: Δ(2θ) = a1 + a2 tan(θ)";
            else
                labelEquation.Text = "Shift function: Δ(2θ) = a1";
        }

        private void buttonCalibrate_Click(object sender, EventArgs e)
        {
            //まず、現在のcoeffを保存
            DiffractionProfile dp = (DiffractionProfile)((DataRowView)formMain.bindingSourceProfile.Current).Row[1];
            coeff0_old = dp.TwoThetaOffsetCoeff0;
            coeff1_old = dp.TwoThetaOffsetCoeff1;
            coeff2_old = dp.TwoThetaOffsetCoeff2;

            buttonCalibrate.Text = "Now calibrationg...";
            this.Enabled = false;

            for (int n = 0; n < 8; n++)
            {
                formMain.formFitting.Fitting();

                List<double> twoThetaObs = new List<double>();
                List<double> twoThetaCalc = new List<double>();

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
                    for (int j = 0; j < order; j++)
                        X[i, j] = Math.Pow(tan, j);
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

            buttonCalibrate.Text = "Calibrate";
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
