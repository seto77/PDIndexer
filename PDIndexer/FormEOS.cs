using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Crystallography;
using MathNet.Numerics;
using System.Linq;

namespace PDIndexer
{
	/// <summary>
	/// FormEOS ÇÃäTóvÇÃê‡ñæÇ≈Ç∑ÅB
	/// </summary>
	public partial class FormEOS : System.Windows.Forms.Form
	{
        public double temperature = 300;
		public FormMain formMain;
		
		public FormEOS()
		{
			InitializeComponent();
		}

        void crystalControl_CrystalChanged(object sender, EventArgs e)
        {
        }

        private void FormEOS_Load(object sender, System.EventArgs e)
        {
            formMain.formCrystal.crystalControl.CrystalChanged += new EventHandler(crystalControl_CrystalChanged);
        }

	    public bool skipTextChangeEvent = false;

        public void numericalTextBox_ValueChanged(object sender, EventArgs e)
        {
            if (skipTextChangeEvent) return;
            temperature = numericBoxTemperature.Value;
            if (groupBoxGold.Visible)
                Gold();
            if (groupBoxPlatinum.Visible)
                Pt();
            if (groupBoxNaClB1.Visible)
                NaClB1();
            if (groupBoxNaClB2.Visible)
                NaClB2();
            if (groupBoxPericlase.Visible)
                MgO();
            if (groupBoxCorundum.Visible)
                Corundum();
            if (groupBoxAr.Visible)
                Ar();
            if (groupBoxRe.Visible)
                Re();
            if (groupBoxMo.Visible)
                Mo();
            if (groupBoxPb.Visible)
                Pb();
        }



        private void Gold()
        {
            double a = numericalTextBoxGoldA.Value, v = a * a * a;
            double a0 = numericBoxGoldA0.Value, v0 = a0 * a0 * a0;
            double t = numericBoxTemperature.Value;
            //Jamieson
            numericalTextBoxGoldJamieson.Value = EOS.Au_Jamieson(a / 10, a0 / 10, t);
            //Sim
            numericalTextBoxGoldSim.Value = EOS.BirchMurnaghan3rd(167, 5.0, v0, v) + EOS.MieGruneisen(4, 1, 170, 2.97, 1.0, 300, v0, t, v);
            //Anderson
            numericalTextBoxGoldAnderson.Value = EOS.Au_Anderson(t, a / 10, a0 / 10);
            //Tsuchiya
            numericalTextBoxGoldTsuchiya.Value = EOS.Au_Tsuchiya(a / 10, a0 / 10, t);
            //Yokoo
            numericBoxAuYokoo.Value = EOS.AuYokoo(v0, v, t);
            //Fratanduono
            numericBoxAuFratanduono.Value = EOS.Au_Fratanduono_Vinet(v0, v);
        }

        private void Ar()
        {
            double a = numericalTextBoxArA.Value, v = a * a * a;
            double a0 = numericBoxArA0.Value, v0 = a0 * a0 * a0;
            double t = numericBoxTemperature.Value;
            //Jephcoat
            numericalTextBoxArJephcoat.Value = EOS.Ar_Jephcoat(a / 10, t);
            //Ross
            numericalTextBoxArRoss.Value = EOS.Ar_Ross(a / 10);
        }


        private void MgO()
        {
            double a = numericalTextBoxMgOA.Value, v = a * a * a;
            double a0 = numericBoxMgOA0.Value, v0 = a0 * a0 * a0;
            double t = numericBoxTemperature.Value;
            //Aizawa
            numericalTextBoxMgOAizawa.Value = EOS.BirchMurnaghan3rd(160, 4.15, v0, v) + EOS.MieGruneisen(4, 2, 773, 1.41, 0.7, 300, v0, t, v);
            //Dewaele
            numericalTextBoxMgODewaele.Value = EOS.BirchMurnaghan3rd(161, 3.94, v0, v) + EOS.MieGruneisen(4, 2, 800, 1.45, 0.8, 300, v0, t, v);
            //Jacson
            numericalTextBoxMgOJacson.Value = EOS.BirchMurnaghan3rd(162.5, 4.13, v0, v) + EOS.MieGruneisen(4, 2, 673, 1.41, 1.3, 300, v0, t, v);
            numericBoxMgOTangeVinet.Value = EOS.MgO_Tange_Vinet(t, v0, v);
            numericBoxMgOTangeBM.Value = EOS.MgO_Tange_BM(t, v0, v);
            
        }

        public void NaClB2()
        {
            double a = numericalTextBoxNaClB2A.Value, v = a * a * a;
            double a0 = numericalTextBoxNaClB2A0.Value, v0 = a0 * a0 * a0;
            double t = numericBoxTemperature.Value;
            //Sata Pt
            numericalTextBoxNaClB2SataPt.Value = EOS.NaClB2_Sata(a, 31.14, 143.5);
            //Sata MgO
            numericalTextBoxNaClB2SataMgO.Value = EOS.NaClB2_Sata(a, 32.15, 141.0);
            //Ueda
            numericalTextBoxNaClB2Ueda.Value = EOS.NaClB2_Ueda(a, t);
            //Sakai BM
            numericalTextBoxNaClB2SakaiBM.Value = EOS.NaClB2_SakaiBM(a);
            //Sakai Vinet
            numericalTextBoxNaClB2SakaiVinet.Value = EOS.NaClB2_SakaiVinet(a);

        }
	
        private void NaClB1()
        {

            double a = numericalTextBoxNaClB1A.Value;
            double a0 = numericBoxNaClB1A0.Value;
            double t = numericBoxTemperature.Value;
            //Brown
            numericalTextBoxNaClB1Brown.Value = EOS.NaCl_Brown(a / 10, a0 / 10, t);
            //Matsui
            numericalTextBoxNaClB1Matsui.Value = EOS.NaClB1_Matsui(a0, a, t);
        }

        private void Pt()
        {
            double a = numericalTextBoxPtA.Value;
            var v = a * a * a;
            double a0 = numericBoxPtA0.Value;
            var v0 = a0 * a0 * a0;
            double t0 = numericBoxTemperature0.Value;
            double t = numericBoxTemperature.Value;

            //Holmes
            numericalTextBoxPtHolmes.Value = EOS.Pt_Holmez(t, a / 10, a0 / 10);
            //Jamieson
            numericalTextBoxPtJamieson.Value = EOS.Pt_Jamieson(a / 10, a0 / 10, t);
            //Matsui
            numericalTextBoxPtMatsui.Value = EOS.Pt_Matsui(t, t0, a / 10, a0 / 10);
            //Yokoo
            numericBoxPtYokoo.Value = EOS.PtYokoo(v0, v, t);
            //Fratanduono
            numericBoxPtFratanduono.Value = EOS.Pt_Fratanduono_Vinet(v0, v);
        }



        private void Corundum()
        {
            double v = numericalTextBoxColundumV.Value;
            double v0 = numericBoxColundumV0.Value;
            double t = numericBoxTemperature.Value;

            //Dubrovinsky
            numericalTextBoxCorundumDubrovinsky.Value = EOS.Corundum_Dubrovinsky(v0,v,t);
        }

        private void Re()
        {
            double v = numericBoxReV.Value;
            double v0 = numerictBoxReV0.Value;
            double t = numericBoxTemperature.Value;
            //Zha
            numericalTextBoxReZha.Value = EOS.Re_Zha(v0, v, t);

            numericBoxReAnz.Value = EOS.Vinet(352.6, 4.56, 29.467, v);
            numericBoxReSakai.Value = EOS.Vinet(358, 4.8, 29.47, v);
            numericBoxReDub.Value = EOS.BirchMurnaghan4th(342,6.15,-0.029, 29.46/v);
        }

        private void Mo()
        {
            double v = numericBoxMoV.Value;
            double v0 = numericBoxMoV0.Value;
            double t = numericBoxTemperature.Value;

            //Huang+16
            numericBoxMoHuang.Value = EOS.BirchMurnaghan3rd(255, 4.25, v0 / v) + EOS.MieGruneisen(2, 1, 470, 2.01, 0.6, 300, v0, t, v);
            //Zhao+00

            numericBoxMoZhao.Value =
            new EOS()
            {
                Z = 2,
                K0 = 268,
                Kp0 = 3.81,
                Kpp0 = -1.41E-2,
                KperT = -2.13E-2,
                A = 1.31,
                B = 11.2,
                T0 = 300,
                Temperature = t,
                CellVolume0 = v0,
                ThermalPressureApproach = ThermalPressure.T_dependence_BM,
                IsothermalPressureApproach =  IsothermalPressure.BM4
            }.GetPressure(v);

            //EOS.BirchMurnaghan3rd(266, 4.1, v0 / v) + EOS.MieGruneisen(2, 1, 470, 2.01, 0.6, 300, v0, t, v);
        }


        (double T, double B, double Bp)[] PbVinet = new (double T, double B, double Bprime)[] {
            #region
            (0,     48.3298,    5.4511),
            (20,    48.2387,    5.4542),
            (40,    47.9462,    5.4644),
            (60,    47.5019,    5.4801),
            (80,    47.0000,    5.4979),
            (100,   46.4875 ,   5.5165),
            (120,   45.9743 ,   5.5353),
            (140,   45.4578 ,   5.5545),
            (160,   44.9356 ,   5.5742),
            (180,   44.4073 ,   5.5945),
            (200,   43.8743 ,   5.6152),
            (220,   43.3386 ,   5.6364),
            (240,   42.8019 ,   5.6580),
            (260,   42.2659 ,   5.6799),
            (280,   41.7317 ,   5.7021),
            (300,   41.2000 ,   5.7245),
            #endregion
        };

        (double T, double A0)[] PbA0 = new (double T, double A0)[]
        {
            #region
            (   0   ,   4.91366 ),
(   5   ,   4.91370 ),
(   10  ,   4.91378 ),
(   15  ,   4.91391 ),
(   20  ,   4.91410 ),
(   25  ,   4.91436 ),
(   30  ,   4.91469 ),
(   35  ,   4.91508 ),
(   40  ,   4.91552 ),
(   45  ,   4.91601 ),
(   50  ,   4.91654 ),
(   55  ,   4.91710 ),
(   60  ,   4.91768 ),
(   65  ,   4.91828 ),
(   70  ,   4.91890 ),
(   75  ,   4.91952 ),
(   80  ,   4.92014 ),
(   85  ,   4.92077 ),
(   90  ,   4.92140 ),
(   95  ,   4.92203 ),
(   100 ,   4.92267 ),
(   105 ,   4.92330 ),
(   110 ,   4.92394 ),
(   115 ,   4.92457 ),
(   120 ,   4.92521 ),
(   125 ,   4.92585 ),
(   130 ,   4.92650 ),
(   135 ,   4.92714 ),
(   140 ,   4.92779 ),
(   145 ,   4.92844 ),
(   150 ,   4.92909 ),
(   155 ,   4.92975 ),
(   160 ,   4.93041 ),
(   165 ,   4.93108 ),
(   170 ,   4.93174 ),
(   175 ,   4.93241 ),
(   180 ,   4.93308 ),
(   185 ,   4.93376 ),
(   190 ,   4.93444 ),
(   195 ,   4.93511 ),
(   200 ,   4.93580 ),
(   205 ,   4.93648 ),
(   210 ,   4.93717 ),
(   215 ,   4.93785 ),
(   220 ,   4.93854 ),
(   225 ,   4.93923 ),
(   230 ,   4.93993 ),
(   235 ,   4.94062 ),
(   240 ,   4.94131 ),
(   245 ,   4.94201 ),
(   250 ,   4.94270 ),
(   255 ,   4.94340 ),
(   260 ,   4.94410 ),
(   265 ,   4.94480 ),
(   270 ,   4.94550 ),
(   275 ,   4.94619 ),
(   280 ,   4.94689 ),
(   285 ,   4.94760 ),
(   290 ,   4.94830 ),
(   295 ,   4.94900 ),
(   300 ,   4.94970 ),
(   305 ,   4.95040 ),
(   310 ,   4.95110 ),
            #endregion
        };

        MathNet.Numerics.Interpolation.IInterpolation PbInterA0, PbInterB, PbInterBp;
        private void Pb()
        {
            if (PbInterA0 == null)
            {
                PbInterA0 = Interpolate.Linear(PbA0.Select(e => e.T).ToArray(), PbA0.Select(e => e.A0));
                PbInterB = Interpolate.Linear(PbVinet.Select(e => e.T).ToArray(), PbVinet.Select(e => e.B));
                PbInterBp = Interpolate.Linear(PbVinet.Select(e => e.T).ToArray(), PbVinet.Select(e => e.Bp));
            }
            var a = numericBoxPbA.Value;
            var a0 = numericBoxPbA0.Value;
            var t = numericBoxTemperature.Value;
            var t0 = numericBoxTemperature0.Value;

            var scale = a0 / PbInterA0.Interpolate(t0);
            var a0atT = scale * PbInterA0.Interpolate(t);

            var x = a / a0atT;

            var B = PbInterB.Interpolate(t);
            var Bp = PbInterBp.Interpolate(t);

            numericBoxPbStrassle.Value = 3 * B * (1 - x) / x / x * Math.Exp(1.5 * (Bp - 1) * (1 - x)); ;
        }


        private void FormEOS_Closed(object sender, System.EventArgs e) {
			formMain.toolStripButtonEquationOfState.Checked=false;
		}

        private void FormEOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            formMain.toolStripButtonEquationOfState.Checked = false;
        }

        private void FormEOS_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                formMain.SetFormEOS();
        }
                
        private void checkBoxGold_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxGold.Visible = checkBoxGold.Checked;
            groupBoxNaClB1.Visible = checkBoxNaClB1.Checked;
            groupBoxNaClB2.Visible = checkBoxNaClB2.Checked;
            groupBoxPericlase.Visible = checkBoxPericlase.Checked;
            groupBoxPlatinum.Visible = checkBoxPlatinum.Checked;
            groupBoxCorundum.Visible = checkBoxCorundum.Checked;
            groupBoxAr.Visible = checkBoxAr.Checked;
            groupBoxRe.Visible = checkBoxRe.Checked;
            groupBoxMo.Visible = checkBoxMo.Checked;
            groupBoxPb.Visible = checkBoxPb.Checked;

        }

        private void FormEOS_KeyDown(object sender, KeyEventArgs e)
        {
            formMain.FormMain_KeyDown(sender, e);
        }

        private void numericalTextBoxGoldA0_Load(object sender, EventArgs e)
        {

        }

    




	}
}
