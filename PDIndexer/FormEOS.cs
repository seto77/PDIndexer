using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Crystallography;
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
            temperature = numericalTextBoxTemperature.Value;
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

        }



        private void Gold()
        {
            double a = numericalTextBoxGoldA.Value, v = a * a * a;
            double a0 = numericalTextBoxGoldA0.Value, v0 = a0 * a0 * a0;
            double t = numericalTextBoxTemperature.Value;
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
        }

        private void Ar()
        {
            double a = numericalTextBoxArA.Value, v = a * a * a;
            double a0 = numericalTextBoxArA0.Value, v0 = a0 * a0 * a0;
            double t = numericalTextBoxTemperature.Value;
            //Jephcoat
            numericalTextBoxArJephcoat.Value = EOS.Ar_Jephcoat(a / 10, t);
            //Ross
            numericalTextBoxArRoss.Value = EOS.Ar_Ross(a / 10);
        }


        private void MgO()
        {
            double a = numericalTextBoxMgOA.Value, v = a * a * a;
            double a0 = numericalTextBoxMgOA0.Value, v0 = a0 * a0 * a0;
            double t = numericalTextBoxTemperature.Value;
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
            double t = numericalTextBoxTemperature.Value;
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
            double a0 = numericalTextBoxNaClB1A0.Value;
            double t = numericalTextBoxTemperature.Value;
            //Brown
            numericalTextBoxNaClB1Brown.Value = EOS.NaCl_Brown(a / 10, a0 / 10, t);
            //Matsui
            numericalTextBoxNaClB1Matsui.Value = EOS.NaClB1_Matsui(a0, a, t);
        }

        private void Pt()
        {

            double a = numericalTextBoxPtA.Value;
            double a0 = numericalTextBoxPtA0.Value;
            double t0 = numericalTextBoxPtT0.Value;
            double t = numericalTextBoxTemperature.Value;

            //Holmes
            numericalTextBoxPtHolmes.Value = EOS.Pt_Holmez(t, a / 10, a0 / 10);
            //Jamieson
            numericalTextBoxPtJamieson.Value = EOS.Pt_Jamieson(a / 10, a0 / 10, t);
            //Matsui
            numericalTextBoxPtMatsui.Value = EOS.Pt_Matsui(t, t0, a / 10, a0 / 10);
            //Yokoo
            numericBoxPtYokoo.Value = EOS.PtYokoo(a0 * a0 * a0, a * a * a, t);
        }


	
        private void Corundum()
        {
            double v = numericalTextBoxColundumV.Value;
            double v0 = numericalTextBoxColundumV0.Value;
            double t = numericalTextBoxTemperature.Value;

            //Dubrovinsky
            numericalTextBoxCorundumDubrovinsky.Value = EOS.Corundum_Dubrovinsky(v0,v,t);
        }

        private void Re()
        {
            double v = numericBoxReV.Value;
            double v0 = numerictBoxReV0.Value;
            double t = numericalTextBoxTemperature.Value;
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
            double t = numericalTextBoxTemperature.Value;

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
