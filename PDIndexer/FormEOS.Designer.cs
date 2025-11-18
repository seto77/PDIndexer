using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Crystallography;
namespace PDIndexer
{
    /// <summary>
    /// FormEOS の概要の説明です。
    /// </summary>
   partial class FormEOS : System.Windows.Forms.Form
    {		
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormEOS));
            groupBoxPlatinum = new GroupBox();
            numericBoxPtFratanduono = new Crystallography.Controls.NumericBox();
            numericBoxPtYokoo = new Crystallography.Controls.NumericBox();
            numericalTextBoxPtMatsui = new Crystallography.Controls.NumericBox();
            numericalTextBoxPtHolmes = new Crystallography.Controls.NumericBox();
            label20 = new Label();
            numericalTextBoxPtJamieson = new Crystallography.Controls.NumericBox();
            label9 = new Label();
            label8 = new Label();
            label1 = new Label();
            numericalTextBoxPtA = new Crystallography.Controls.NumericBox();
            numericBoxPtA0 = new Crystallography.Controls.NumericBox();
            label30 = new Label();
            numericBoxTemperature0 = new Crystallography.Controls.NumericBox();
            groupBoxNaClB1 = new GroupBox();
            numericBoxNaClB1Skelton = new Crystallography.Controls.NumericBox();
            numericBoxNaClB1Matsui = new Crystallography.Controls.NumericBox();
            label31 = new Label();
            numericalTextBoxNaClB1Brown = new Crystallography.Controls.NumericBox();
            label4 = new Label();
            label3 = new Label();
            numericalTextBoxNaClB1A = new Crystallography.Controls.NumericBox();
            numericBoxNaClB1A0 = new Crystallography.Controls.NumericBox();
            groupBoxGold = new GroupBox();
            numericBoxAuFratanduono = new Crystallography.Controls.NumericBox();
            numericBoxAuYokoo = new Crystallography.Controls.NumericBox();
            numericalTextBoxGoldJamieson = new Crystallography.Controls.NumericBox();
            numericalTextBoxGoldTsuchiya = new Crystallography.Controls.NumericBox();
            numericalTextBoxGoldSim = new Crystallography.Controls.NumericBox();
            label19 = new Label();
            numericalTextBoxGoldAnderson = new Crystallography.Controls.NumericBox();
            label49 = new Label();
            numericalTextBoxGoldA = new Crystallography.Controls.NumericBox();
            numericBoxGoldA0 = new Crystallography.Controls.NumericBox();
            label22 = new Label();
            label69 = new Label();
            label15 = new Label();
            label27 = new Label();
            groupBoxPericlase = new GroupBox();
            numericBoxMgOTangeBM = new Crystallography.Controls.NumericBox();
            numericBoxMgOTangeVinet = new Crystallography.Controls.NumericBox();
            numericalTextBoxMgOAizawa = new Crystallography.Controls.NumericBox();
            label16 = new Label();
            numericalTextBoxMgODewaele = new Crystallography.Controls.NumericBox();
            label13 = new Label();
            numericalTextBoxMgOJacson = new Crystallography.Controls.NumericBox();
            label23 = new Label();
            label21 = new Label();
            numericalTextBoxMgOA = new Crystallography.Controls.NumericBox();
            label2 = new Label();
            numericBoxMgOA0 = new Crystallography.Controls.NumericBox();
            groupBoxNaClB2 = new GroupBox();
            numericalTextBoxNaClB2SakaiVinet = new Crystallography.Controls.NumericBox();
            numericalTextBoxNaClB2SakaiBM = new Crystallography.Controls.NumericBox();
            numericalTextBoxNaClB2Ueda = new Crystallography.Controls.NumericBox();
            label12 = new Label();
            numericalTextBoxNaClB2SataMgO = new Crystallography.Controls.NumericBox();
            label11 = new Label();
            numericalTextBoxNaClB2SataPt = new Crystallography.Controls.NumericBox();
            label10 = new Label();
            label7 = new Label();
            numericalTextBoxNaClB2A = new Crystallography.Controls.NumericBox();
            label6 = new Label();
            numericalTextBoxNaClB2A0 = new Crystallography.Controls.NumericBox();
            groupBoxCorundum = new GroupBox();
            numericBoxCorundumDubrovinsky = new Crystallography.Controls.NumericBox();
            numericalTextBoxColundumV = new Crystallography.Controls.NumericBox();
            label5 = new Label();
            numericBoxColundumV0 = new Crystallography.Controls.NumericBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBoxAr = new GroupBox();
            numericalTextBoxArRoss = new Crystallography.Controls.NumericBox();
            numericalTextBoxArJephcoat = new Crystallography.Controls.NumericBox();
            numericalTextBoxArA = new Crystallography.Controls.NumericBox();
            label17 = new Label();
            label14 = new Label();
            numericBoxArA0 = new Crystallography.Controls.NumericBox();
            groupBoxRe = new GroupBox();
            numericBoxReDub = new Crystallography.Controls.NumericBox();
            numericBoxReSakai = new Crystallography.Controls.NumericBox();
            label26 = new Label();
            numericBoxReAnz = new Crystallography.Controls.NumericBox();
            label25 = new Label();
            numericalTextBoxReZha = new Crystallography.Controls.NumericBox();
            label24 = new Label();
            numericBoxReV = new Crystallography.Controls.NumericBox();
            label18 = new Label();
            numerictBoxReV0 = new Crystallography.Controls.NumericBox();
            groupBoxMo = new GroupBox();
            numericBoxMoZhao = new Crystallography.Controls.NumericBox();
            numericBoxMoHuang = new Crystallography.Controls.NumericBox();
            label29 = new Label();
            numericBoxMoV = new Crystallography.Controls.NumericBox();
            label28 = new Label();
            numericBoxMoV0 = new Crystallography.Controls.NumericBox();
            groupBoxPb = new GroupBox();
            numericBoxPbStrassle = new Crystallography.Controls.NumericBox();
            numericBoxPbA = new Crystallography.Controls.NumericBox();
            label32 = new Label();
            numericBoxPbA0 = new Crystallography.Controls.NumericBox();
            checkBoxPlatinum = new CheckBox();
            checkBoxGold = new CheckBox();
            checkBoxNaClB1 = new CheckBox();
            checkBoxNaClB2 = new CheckBox();
            checkBoxPericlase = new CheckBox();
            checkBoxCorundum = new CheckBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            checkBoxAr = new CheckBox();
            checkBoxRe = new CheckBox();
            checkBoxMo = new CheckBox();
            checkBoxPb = new CheckBox();
            checkBoxHBN = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            numericBoxTemperature = new Crystallography.Controls.NumericBox();
            groupBoxPlatinum.SuspendLayout();
            groupBoxNaClB1.SuspendLayout();
            groupBoxGold.SuspendLayout();
            groupBoxPericlase.SuspendLayout();
            groupBoxNaClB2.SuspendLayout();
            groupBoxCorundum.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBoxAr.SuspendLayout();
            groupBoxRe.SuspendLayout();
            groupBoxMo.SuspendLayout();
            groupBoxPb.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxPlatinum
            // 
            groupBoxPlatinum.Controls.Add(numericBoxPtFratanduono);
            groupBoxPlatinum.Controls.Add(numericBoxPtYokoo);
            groupBoxPlatinum.Controls.Add(numericalTextBoxPtMatsui);
            groupBoxPlatinum.Controls.Add(numericalTextBoxPtHolmes);
            groupBoxPlatinum.Controls.Add(label20);
            groupBoxPlatinum.Controls.Add(numericalTextBoxPtJamieson);
            groupBoxPlatinum.Controls.Add(label9);
            groupBoxPlatinum.Controls.Add(label8);
            groupBoxPlatinum.Controls.Add(label1);
            groupBoxPlatinum.Controls.Add(numericalTextBoxPtA);
            groupBoxPlatinum.Controls.Add(numericBoxPtA0);
            groupBoxPlatinum.Controls.Add(label30);
            resources.ApplyResources(groupBoxPlatinum, "groupBoxPlatinum");
            groupBoxPlatinum.Name = "groupBoxPlatinum";
            groupBoxPlatinum.TabStop = false;
            // 
            // numericBoxPtFratanduono
            // 
            resources.ApplyResources(numericBoxPtFratanduono, "numericBoxPtFratanduono");
            numericBoxPtFratanduono.BackColor = SystemColors.Control;
            numericBoxPtFratanduono.DecimalPlaces = 3;
            numericBoxPtFratanduono.FooterBackColor = SystemColors.Control;
            numericBoxPtFratanduono.HeaderBackColor = SystemColors.Control;
            numericBoxPtFratanduono.Name = "numericBoxPtFratanduono";
            numericBoxPtFratanduono.SkipEventDuringInput = false;
            numericBoxPtFratanduono.SmartIncrement = true;
            numericBoxPtFratanduono.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxPtFratanduono.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxPtFratanduono.ThonsandsSeparator = true;
            // 
            // numericBoxPtYokoo
            // 
            resources.ApplyResources(numericBoxPtYokoo, "numericBoxPtYokoo");
            numericBoxPtYokoo.BackColor = SystemColors.Control;
            numericBoxPtYokoo.DecimalPlaces = 3;
            numericBoxPtYokoo.FooterBackColor = SystemColors.Control;
            numericBoxPtYokoo.HeaderBackColor = SystemColors.Control;
            numericBoxPtYokoo.Name = "numericBoxPtYokoo";
            numericBoxPtYokoo.SkipEventDuringInput = false;
            numericBoxPtYokoo.SmartIncrement = true;
            numericBoxPtYokoo.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxPtYokoo.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxPtYokoo.ThonsandsSeparator = true;
            // 
            // numericalTextBoxPtMatsui
            // 
            resources.ApplyResources(numericalTextBoxPtMatsui, "numericalTextBoxPtMatsui");
            numericalTextBoxPtMatsui.BackColor = SystemColors.Control;
            numericalTextBoxPtMatsui.DecimalPlaces = 3;
            numericalTextBoxPtMatsui.FooterBackColor = SystemColors.Control;
            numericalTextBoxPtMatsui.HeaderBackColor = SystemColors.Control;
            numericalTextBoxPtMatsui.Name = "numericalTextBoxPtMatsui";
            numericalTextBoxPtMatsui.SkipEventDuringInput = false;
            numericalTextBoxPtMatsui.SmartIncrement = true;
            numericalTextBoxPtMatsui.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxPtMatsui.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxPtMatsui.ThonsandsSeparator = true;
            // 
            // numericalTextBoxPtHolmes
            // 
            resources.ApplyResources(numericalTextBoxPtHolmes, "numericalTextBoxPtHolmes");
            numericalTextBoxPtHolmes.BackColor = SystemColors.Control;
            numericalTextBoxPtHolmes.DecimalPlaces = 3;
            numericalTextBoxPtHolmes.FooterBackColor = SystemColors.Control;
            numericalTextBoxPtHolmes.HeaderBackColor = SystemColors.Control;
            numericalTextBoxPtHolmes.Name = "numericalTextBoxPtHolmes";
            numericalTextBoxPtHolmes.SkipEventDuringInput = false;
            numericalTextBoxPtHolmes.SmartIncrement = true;
            numericalTextBoxPtHolmes.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxPtHolmes.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxPtHolmes.ThonsandsSeparator = true;
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.Name = "label20";
            // 
            // numericalTextBoxPtJamieson
            // 
            resources.ApplyResources(numericalTextBoxPtJamieson, "numericalTextBoxPtJamieson");
            numericalTextBoxPtJamieson.BackColor = SystemColors.Control;
            numericalTextBoxPtJamieson.DecimalPlaces = 3;
            numericalTextBoxPtJamieson.FooterBackColor = SystemColors.Control;
            numericalTextBoxPtJamieson.HeaderBackColor = SystemColors.Control;
            numericalTextBoxPtJamieson.Name = "numericalTextBoxPtJamieson";
            numericalTextBoxPtJamieson.SkipEventDuringInput = false;
            numericalTextBoxPtJamieson.SmartIncrement = true;
            numericalTextBoxPtJamieson.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxPtJamieson.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxPtJamieson.ThonsandsSeparator = true;
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // numericalTextBoxPtA
            // 
            resources.ApplyResources(numericalTextBoxPtA, "numericalTextBoxPtA");
            numericalTextBoxPtA.BackColor = SystemColors.Control;
            numericalTextBoxPtA.FooterBackColor = SystemColors.Control;
            numericalTextBoxPtA.HeaderBackColor = SystemColors.Control;
            numericalTextBoxPtA.Name = "numericalTextBoxPtA";
            numericalTextBoxPtA.RadianValue = 0.068471011884989538D;
            numericalTextBoxPtA.SkipEventDuringInput = false;
            numericalTextBoxPtA.SmartIncrement = true;
            numericalTextBoxPtA.ThonsandsSeparator = true;
            numericalTextBoxPtA.Value = 3.9231D;
            numericalTextBoxPtA.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // numericBoxPtA0
            // 
            resources.ApplyResources(numericBoxPtA0, "numericBoxPtA0");
            numericBoxPtA0.BackColor = SystemColors.Control;
            numericBoxPtA0.FooterBackColor = SystemColors.Control;
            numericBoxPtA0.HeaderBackColor = SystemColors.Control;
            numericBoxPtA0.Name = "numericBoxPtA0";
            numericBoxPtA0.RadianValue = 0.068471011884989538D;
            numericBoxPtA0.SkipEventDuringInput = false;
            numericBoxPtA0.SmartIncrement = true;
            numericBoxPtA0.ThonsandsSeparator = true;
            numericBoxPtA0.Value = 3.9231D;
            numericBoxPtA0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // label30
            // 
            resources.ApplyResources(label30, "label30");
            label30.Name = "label30";
            // 
            // numericBoxTemperature0
            // 
            resources.ApplyResources(numericBoxTemperature0, "numericBoxTemperature0");
            numericBoxTemperature0.BackColor = SystemColors.Control;
            numericBoxTemperature0.FooterBackColor = SystemColors.Control;
            numericBoxTemperature0.HeaderBackColor = SystemColors.Control;
            numericBoxTemperature0.Name = "numericBoxTemperature0";
            numericBoxTemperature0.RadianValue = 5.2359877559829888D;
            numericBoxTemperature0.SkipEventDuringInput = false;
            numericBoxTemperature0.SmartIncrement = true;
            numericBoxTemperature0.ThonsandsSeparator = true;
            numericBoxTemperature0.Value = 300D;
            numericBoxTemperature0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // groupBoxNaClB1
            // 
            groupBoxNaClB1.Controls.Add(numericBoxNaClB1Skelton);
            groupBoxNaClB1.Controls.Add(numericBoxNaClB1Matsui);
            groupBoxNaClB1.Controls.Add(label31);
            groupBoxNaClB1.Controls.Add(numericalTextBoxNaClB1Brown);
            groupBoxNaClB1.Controls.Add(label4);
            groupBoxNaClB1.Controls.Add(label3);
            groupBoxNaClB1.Controls.Add(numericalTextBoxNaClB1A);
            groupBoxNaClB1.Controls.Add(numericBoxNaClB1A0);
            resources.ApplyResources(groupBoxNaClB1, "groupBoxNaClB1");
            groupBoxNaClB1.Name = "groupBoxNaClB1";
            groupBoxNaClB1.TabStop = false;
            // 
            // numericBoxNaClB1Skelton
            // 
            resources.ApplyResources(numericBoxNaClB1Skelton, "numericBoxNaClB1Skelton");
            numericBoxNaClB1Skelton.BackColor = SystemColors.Control;
            numericBoxNaClB1Skelton.DecimalPlaces = 3;
            numericBoxNaClB1Skelton.FooterBackColor = SystemColors.Control;
            numericBoxNaClB1Skelton.HeaderBackColor = SystemColors.Control;
            numericBoxNaClB1Skelton.Name = "numericBoxNaClB1Skelton";
            numericBoxNaClB1Skelton.SkipEventDuringInput = false;
            numericBoxNaClB1Skelton.SmartIncrement = true;
            numericBoxNaClB1Skelton.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxNaClB1Skelton.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxNaClB1Skelton.ThonsandsSeparator = true;
            // 
            // numericBoxNaClB1Matsui
            // 
            resources.ApplyResources(numericBoxNaClB1Matsui, "numericBoxNaClB1Matsui");
            numericBoxNaClB1Matsui.BackColor = SystemColors.Control;
            numericBoxNaClB1Matsui.DecimalPlaces = 3;
            numericBoxNaClB1Matsui.FooterBackColor = SystemColors.Control;
            numericBoxNaClB1Matsui.HeaderBackColor = SystemColors.Control;
            numericBoxNaClB1Matsui.Name = "numericBoxNaClB1Matsui";
            numericBoxNaClB1Matsui.SkipEventDuringInput = false;
            numericBoxNaClB1Matsui.SmartIncrement = true;
            numericBoxNaClB1Matsui.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxNaClB1Matsui.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxNaClB1Matsui.ThonsandsSeparator = true;
            // 
            // label31
            // 
            resources.ApplyResources(label31, "label31");
            label31.Name = "label31";
            // 
            // numericalTextBoxNaClB1Brown
            // 
            resources.ApplyResources(numericalTextBoxNaClB1Brown, "numericalTextBoxNaClB1Brown");
            numericalTextBoxNaClB1Brown.BackColor = SystemColors.Control;
            numericalTextBoxNaClB1Brown.DecimalPlaces = 3;
            numericalTextBoxNaClB1Brown.FooterBackColor = SystemColors.Control;
            numericalTextBoxNaClB1Brown.HeaderBackColor = SystemColors.Control;
            numericalTextBoxNaClB1Brown.Name = "numericalTextBoxNaClB1Brown";
            numericalTextBoxNaClB1Brown.SkipEventDuringInput = false;
            numericalTextBoxNaClB1Brown.SmartIncrement = true;
            numericalTextBoxNaClB1Brown.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxNaClB1Brown.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxNaClB1Brown.ThonsandsSeparator = true;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // numericalTextBoxNaClB1A
            // 
            resources.ApplyResources(numericalTextBoxNaClB1A, "numericalTextBoxNaClB1A");
            numericalTextBoxNaClB1A.BackColor = SystemColors.Control;
            numericalTextBoxNaClB1A.FooterBackColor = SystemColors.Control;
            numericalTextBoxNaClB1A.HeaderBackColor = SystemColors.Control;
            numericalTextBoxNaClB1A.Name = "numericalTextBoxNaClB1A";
            numericalTextBoxNaClB1A.RadianValue = 0.098419116519960256D;
            numericalTextBoxNaClB1A.SkipEventDuringInput = false;
            numericalTextBoxNaClB1A.SmartIncrement = true;
            numericalTextBoxNaClB1A.ThonsandsSeparator = true;
            numericalTextBoxNaClB1A.Value = 5.639D;
            numericalTextBoxNaClB1A.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // numericBoxNaClB1A0
            // 
            resources.ApplyResources(numericBoxNaClB1A0, "numericBoxNaClB1A0");
            numericBoxNaClB1A0.BackColor = SystemColors.Control;
            numericBoxNaClB1A0.FooterBackColor = SystemColors.Control;
            numericBoxNaClB1A0.HeaderBackColor = SystemColors.Control;
            numericBoxNaClB1A0.Name = "numericBoxNaClB1A0";
            numericBoxNaClB1A0.RadianValue = 0.098419116519960256D;
            numericBoxNaClB1A0.SkipEventDuringInput = false;
            numericBoxNaClB1A0.SmartIncrement = true;
            numericBoxNaClB1A0.ThonsandsSeparator = true;
            numericBoxNaClB1A0.Value = 5.639D;
            numericBoxNaClB1A0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // groupBoxGold
            // 
            groupBoxGold.Controls.Add(numericBoxAuFratanduono);
            groupBoxGold.Controls.Add(numericBoxAuYokoo);
            groupBoxGold.Controls.Add(numericalTextBoxGoldJamieson);
            groupBoxGold.Controls.Add(numericalTextBoxGoldTsuchiya);
            groupBoxGold.Controls.Add(numericalTextBoxGoldSim);
            groupBoxGold.Controls.Add(label19);
            groupBoxGold.Controls.Add(numericalTextBoxGoldAnderson);
            groupBoxGold.Controls.Add(label49);
            groupBoxGold.Controls.Add(numericalTextBoxGoldA);
            groupBoxGold.Controls.Add(numericBoxGoldA0);
            groupBoxGold.Controls.Add(label22);
            groupBoxGold.Controls.Add(label69);
            groupBoxGold.Controls.Add(label15);
            groupBoxGold.Controls.Add(label27);
            resources.ApplyResources(groupBoxGold, "groupBoxGold");
            groupBoxGold.Name = "groupBoxGold";
            groupBoxGold.TabStop = false;
            // 
            // numericBoxAuFratanduono
            // 
            resources.ApplyResources(numericBoxAuFratanduono, "numericBoxAuFratanduono");
            numericBoxAuFratanduono.BackColor = SystemColors.Control;
            numericBoxAuFratanduono.DecimalPlaces = 3;
            numericBoxAuFratanduono.FooterBackColor = SystemColors.Control;
            numericBoxAuFratanduono.HeaderBackColor = SystemColors.Control;
            numericBoxAuFratanduono.Name = "numericBoxAuFratanduono";
            numericBoxAuFratanduono.SkipEventDuringInput = false;
            numericBoxAuFratanduono.SmartIncrement = true;
            numericBoxAuFratanduono.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxAuFratanduono.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxAuFratanduono.ThonsandsSeparator = true;
            // 
            // numericBoxAuYokoo
            // 
            resources.ApplyResources(numericBoxAuYokoo, "numericBoxAuYokoo");
            numericBoxAuYokoo.BackColor = SystemColors.Control;
            numericBoxAuYokoo.DecimalPlaces = 3;
            numericBoxAuYokoo.FooterBackColor = SystemColors.Control;
            numericBoxAuYokoo.HeaderBackColor = SystemColors.Control;
            numericBoxAuYokoo.Name = "numericBoxAuYokoo";
            numericBoxAuYokoo.SkipEventDuringInput = false;
            numericBoxAuYokoo.SmartIncrement = true;
            numericBoxAuYokoo.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxAuYokoo.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxAuYokoo.ThonsandsSeparator = true;
            // 
            // numericalTextBoxGoldJamieson
            // 
            resources.ApplyResources(numericalTextBoxGoldJamieson, "numericalTextBoxGoldJamieson");
            numericalTextBoxGoldJamieson.BackColor = SystemColors.Control;
            numericalTextBoxGoldJamieson.DecimalPlaces = 3;
            numericalTextBoxGoldJamieson.FooterBackColor = SystemColors.Control;
            numericalTextBoxGoldJamieson.HeaderBackColor = SystemColors.Control;
            numericalTextBoxGoldJamieson.Name = "numericalTextBoxGoldJamieson";
            numericalTextBoxGoldJamieson.SkipEventDuringInput = false;
            numericalTextBoxGoldJamieson.SmartIncrement = true;
            numericalTextBoxGoldJamieson.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxGoldJamieson.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxGoldJamieson.ThonsandsSeparator = true;
            // 
            // numericalTextBoxGoldTsuchiya
            // 
            resources.ApplyResources(numericalTextBoxGoldTsuchiya, "numericalTextBoxGoldTsuchiya");
            numericalTextBoxGoldTsuchiya.BackColor = SystemColors.Control;
            numericalTextBoxGoldTsuchiya.DecimalPlaces = 3;
            numericalTextBoxGoldTsuchiya.FooterBackColor = SystemColors.Control;
            numericalTextBoxGoldTsuchiya.HeaderBackColor = SystemColors.Control;
            numericalTextBoxGoldTsuchiya.Name = "numericalTextBoxGoldTsuchiya";
            numericalTextBoxGoldTsuchiya.SkipEventDuringInput = false;
            numericalTextBoxGoldTsuchiya.SmartIncrement = true;
            numericalTextBoxGoldTsuchiya.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxGoldTsuchiya.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxGoldTsuchiya.ThonsandsSeparator = true;
            // 
            // numericalTextBoxGoldSim
            // 
            resources.ApplyResources(numericalTextBoxGoldSim, "numericalTextBoxGoldSim");
            numericalTextBoxGoldSim.BackColor = SystemColors.Control;
            numericalTextBoxGoldSim.DecimalPlaces = 3;
            numericalTextBoxGoldSim.FooterBackColor = SystemColors.Control;
            numericalTextBoxGoldSim.HeaderBackColor = SystemColors.Control;
            numericalTextBoxGoldSim.Name = "numericalTextBoxGoldSim";
            numericalTextBoxGoldSim.SkipEventDuringInput = false;
            numericalTextBoxGoldSim.SmartIncrement = true;
            numericalTextBoxGoldSim.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxGoldSim.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxGoldSim.ThonsandsSeparator = true;
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            // 
            // numericalTextBoxGoldAnderson
            // 
            resources.ApplyResources(numericalTextBoxGoldAnderson, "numericalTextBoxGoldAnderson");
            numericalTextBoxGoldAnderson.BackColor = SystemColors.Control;
            numericalTextBoxGoldAnderson.DecimalPlaces = 3;
            numericalTextBoxGoldAnderson.FooterBackColor = SystemColors.Control;
            numericalTextBoxGoldAnderson.HeaderBackColor = SystemColors.Control;
            numericalTextBoxGoldAnderson.Name = "numericalTextBoxGoldAnderson";
            numericalTextBoxGoldAnderson.SkipEventDuringInput = false;
            numericalTextBoxGoldAnderson.SmartIncrement = true;
            numericalTextBoxGoldAnderson.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxGoldAnderson.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxGoldAnderson.ThonsandsSeparator = true;
            // 
            // label49
            // 
            resources.ApplyResources(label49, "label49");
            label49.Name = "label49";
            // 
            // numericalTextBoxGoldA
            // 
            resources.ApplyResources(numericalTextBoxGoldA, "numericalTextBoxGoldA");
            numericalTextBoxGoldA.BackColor = SystemColors.Control;
            numericalTextBoxGoldA.FooterBackColor = SystemColors.Control;
            numericalTextBoxGoldA.HeaderBackColor = SystemColors.Control;
            numericalTextBoxGoldA.Name = "numericalTextBoxGoldA";
            numericalTextBoxGoldA.RadianValue = 0.071178890219458738D;
            numericalTextBoxGoldA.SkipEventDuringInput = false;
            numericalTextBoxGoldA.SmartIncrement = true;
            numericalTextBoxGoldA.ThonsandsSeparator = true;
            numericalTextBoxGoldA.Value = 4.07825D;
            numericalTextBoxGoldA.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // numericBoxGoldA0
            // 
            resources.ApplyResources(numericBoxGoldA0, "numericBoxGoldA0");
            numericBoxGoldA0.BackColor = SystemColors.Control;
            numericBoxGoldA0.FooterBackColor = SystemColors.Control;
            numericBoxGoldA0.HeaderBackColor = SystemColors.Control;
            numericBoxGoldA0.Name = "numericBoxGoldA0";
            numericBoxGoldA0.RadianValue = 0.071178890219458738D;
            numericBoxGoldA0.SkipEventDuringInput = false;
            numericBoxGoldA0.SmartIncrement = true;
            numericBoxGoldA0.ThonsandsSeparator = true;
            numericBoxGoldA0.Value = 4.07825D;
            numericBoxGoldA0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            // 
            // label69
            // 
            resources.ApplyResources(label69, "label69");
            label69.Name = "label69";
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            // 
            // label27
            // 
            resources.ApplyResources(label27, "label27");
            label27.Name = "label27";
            // 
            // groupBoxPericlase
            // 
            groupBoxPericlase.Controls.Add(numericBoxMgOTangeBM);
            groupBoxPericlase.Controls.Add(numericBoxMgOTangeVinet);
            groupBoxPericlase.Controls.Add(numericalTextBoxMgOAizawa);
            groupBoxPericlase.Controls.Add(label16);
            groupBoxPericlase.Controls.Add(numericalTextBoxMgODewaele);
            groupBoxPericlase.Controls.Add(label13);
            groupBoxPericlase.Controls.Add(numericalTextBoxMgOJacson);
            groupBoxPericlase.Controls.Add(label23);
            groupBoxPericlase.Controls.Add(label21);
            groupBoxPericlase.Controls.Add(numericalTextBoxMgOA);
            groupBoxPericlase.Controls.Add(label2);
            groupBoxPericlase.Controls.Add(numericBoxMgOA0);
            resources.ApplyResources(groupBoxPericlase, "groupBoxPericlase");
            groupBoxPericlase.Name = "groupBoxPericlase";
            groupBoxPericlase.TabStop = false;
            // 
            // numericBoxMgOTangeBM
            // 
            resources.ApplyResources(numericBoxMgOTangeBM, "numericBoxMgOTangeBM");
            numericBoxMgOTangeBM.BackColor = SystemColors.Control;
            numericBoxMgOTangeBM.DecimalPlaces = 3;
            numericBoxMgOTangeBM.FooterBackColor = SystemColors.Control;
            numericBoxMgOTangeBM.HeaderBackColor = SystemColors.Control;
            numericBoxMgOTangeBM.Name = "numericBoxMgOTangeBM";
            numericBoxMgOTangeBM.SkipEventDuringInput = false;
            numericBoxMgOTangeBM.SmartIncrement = true;
            numericBoxMgOTangeBM.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxMgOTangeBM.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxMgOTangeBM.ThonsandsSeparator = true;
            // 
            // numericBoxMgOTangeVinet
            // 
            resources.ApplyResources(numericBoxMgOTangeVinet, "numericBoxMgOTangeVinet");
            numericBoxMgOTangeVinet.BackColor = SystemColors.Control;
            numericBoxMgOTangeVinet.DecimalPlaces = 3;
            numericBoxMgOTangeVinet.FooterBackColor = SystemColors.Control;
            numericBoxMgOTangeVinet.HeaderBackColor = SystemColors.Control;
            numericBoxMgOTangeVinet.Name = "numericBoxMgOTangeVinet";
            numericBoxMgOTangeVinet.SkipEventDuringInput = false;
            numericBoxMgOTangeVinet.SmartIncrement = true;
            numericBoxMgOTangeVinet.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxMgOTangeVinet.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxMgOTangeVinet.ThonsandsSeparator = true;
            // 
            // numericalTextBoxMgOAizawa
            // 
            resources.ApplyResources(numericalTextBoxMgOAizawa, "numericalTextBoxMgOAizawa");
            numericalTextBoxMgOAizawa.BackColor = SystemColors.Control;
            numericalTextBoxMgOAizawa.DecimalPlaces = 3;
            numericalTextBoxMgOAizawa.FooterBackColor = SystemColors.Control;
            numericalTextBoxMgOAizawa.HeaderBackColor = SystemColors.Control;
            numericalTextBoxMgOAizawa.Name = "numericalTextBoxMgOAizawa";
            numericalTextBoxMgOAizawa.SkipEventDuringInput = false;
            numericalTextBoxMgOAizawa.SmartIncrement = true;
            numericalTextBoxMgOAizawa.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxMgOAizawa.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxMgOAizawa.ThonsandsSeparator = true;
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            // 
            // numericalTextBoxMgODewaele
            // 
            resources.ApplyResources(numericalTextBoxMgODewaele, "numericalTextBoxMgODewaele");
            numericalTextBoxMgODewaele.BackColor = SystemColors.Control;
            numericalTextBoxMgODewaele.DecimalPlaces = 3;
            numericalTextBoxMgODewaele.FooterBackColor = SystemColors.Control;
            numericalTextBoxMgODewaele.HeaderBackColor = SystemColors.Control;
            numericalTextBoxMgODewaele.Name = "numericalTextBoxMgODewaele";
            numericalTextBoxMgODewaele.SkipEventDuringInput = false;
            numericalTextBoxMgODewaele.SmartIncrement = true;
            numericalTextBoxMgODewaele.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxMgODewaele.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxMgODewaele.ThonsandsSeparator = true;
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            // 
            // numericalTextBoxMgOJacson
            // 
            resources.ApplyResources(numericalTextBoxMgOJacson, "numericalTextBoxMgOJacson");
            numericalTextBoxMgOJacson.BackColor = SystemColors.Control;
            numericalTextBoxMgOJacson.DecimalPlaces = 3;
            numericalTextBoxMgOJacson.FooterBackColor = SystemColors.Control;
            numericalTextBoxMgOJacson.HeaderBackColor = SystemColors.Control;
            numericalTextBoxMgOJacson.Name = "numericalTextBoxMgOJacson";
            numericalTextBoxMgOJacson.SkipEventDuringInput = false;
            numericalTextBoxMgOJacson.SmartIncrement = true;
            numericalTextBoxMgOJacson.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxMgOJacson.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxMgOJacson.ThonsandsSeparator = true;
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            // 
            // numericalTextBoxMgOA
            // 
            resources.ApplyResources(numericalTextBoxMgOA, "numericalTextBoxMgOA");
            numericalTextBoxMgOA.BackColor = SystemColors.Control;
            numericalTextBoxMgOA.FooterBackColor = SystemColors.Control;
            numericalTextBoxMgOA.HeaderBackColor = SystemColors.Control;
            numericalTextBoxMgOA.Name = "numericalTextBoxMgOA";
            numericalTextBoxMgOA.RadianValue = 0.0734993054599852D;
            numericalTextBoxMgOA.SkipEventDuringInput = false;
            numericalTextBoxMgOA.SmartIncrement = true;
            numericalTextBoxMgOA.ThonsandsSeparator = true;
            numericalTextBoxMgOA.Value = 4.2112D;
            numericalTextBoxMgOA.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // numericBoxMgOA0
            // 
            resources.ApplyResources(numericBoxMgOA0, "numericBoxMgOA0");
            numericBoxMgOA0.BackColor = SystemColors.Control;
            numericBoxMgOA0.FooterBackColor = SystemColors.Control;
            numericBoxMgOA0.HeaderBackColor = SystemColors.Control;
            numericBoxMgOA0.Name = "numericBoxMgOA0";
            numericBoxMgOA0.RadianValue = 0.0734993054599852D;
            numericBoxMgOA0.SkipEventDuringInput = false;
            numericBoxMgOA0.SmartIncrement = true;
            numericBoxMgOA0.ThonsandsSeparator = true;
            numericBoxMgOA0.Value = 4.2112D;
            numericBoxMgOA0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // groupBoxNaClB2
            // 
            groupBoxNaClB2.Controls.Add(numericalTextBoxNaClB2SakaiVinet);
            groupBoxNaClB2.Controls.Add(numericalTextBoxNaClB2SakaiBM);
            groupBoxNaClB2.Controls.Add(numericalTextBoxNaClB2Ueda);
            groupBoxNaClB2.Controls.Add(label12);
            groupBoxNaClB2.Controls.Add(numericalTextBoxNaClB2SataMgO);
            groupBoxNaClB2.Controls.Add(label11);
            groupBoxNaClB2.Controls.Add(numericalTextBoxNaClB2SataPt);
            groupBoxNaClB2.Controls.Add(label10);
            groupBoxNaClB2.Controls.Add(label7);
            groupBoxNaClB2.Controls.Add(numericalTextBoxNaClB2A);
            groupBoxNaClB2.Controls.Add(label6);
            groupBoxNaClB2.Controls.Add(numericalTextBoxNaClB2A0);
            resources.ApplyResources(groupBoxNaClB2, "groupBoxNaClB2");
            groupBoxNaClB2.Name = "groupBoxNaClB2";
            groupBoxNaClB2.TabStop = false;
            // 
            // numericalTextBoxNaClB2SakaiVinet
            // 
            resources.ApplyResources(numericalTextBoxNaClB2SakaiVinet, "numericalTextBoxNaClB2SakaiVinet");
            numericalTextBoxNaClB2SakaiVinet.BackColor = SystemColors.Control;
            numericalTextBoxNaClB2SakaiVinet.DecimalPlaces = 3;
            numericalTextBoxNaClB2SakaiVinet.FooterBackColor = SystemColors.Control;
            numericalTextBoxNaClB2SakaiVinet.HeaderBackColor = SystemColors.Control;
            numericalTextBoxNaClB2SakaiVinet.Name = "numericalTextBoxNaClB2SakaiVinet";
            numericalTextBoxNaClB2SakaiVinet.SkipEventDuringInput = false;
            numericalTextBoxNaClB2SakaiVinet.SmartIncrement = true;
            numericalTextBoxNaClB2SakaiVinet.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxNaClB2SakaiVinet.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxNaClB2SakaiVinet.ThonsandsSeparator = true;
            // 
            // numericalTextBoxNaClB2SakaiBM
            // 
            resources.ApplyResources(numericalTextBoxNaClB2SakaiBM, "numericalTextBoxNaClB2SakaiBM");
            numericalTextBoxNaClB2SakaiBM.BackColor = SystemColors.Control;
            numericalTextBoxNaClB2SakaiBM.DecimalPlaces = 3;
            numericalTextBoxNaClB2SakaiBM.FooterBackColor = SystemColors.Control;
            numericalTextBoxNaClB2SakaiBM.HeaderBackColor = SystemColors.Control;
            numericalTextBoxNaClB2SakaiBM.Name = "numericalTextBoxNaClB2SakaiBM";
            numericalTextBoxNaClB2SakaiBM.SkipEventDuringInput = false;
            numericalTextBoxNaClB2SakaiBM.SmartIncrement = true;
            numericalTextBoxNaClB2SakaiBM.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxNaClB2SakaiBM.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxNaClB2SakaiBM.ThonsandsSeparator = true;
            // 
            // numericalTextBoxNaClB2Ueda
            // 
            resources.ApplyResources(numericalTextBoxNaClB2Ueda, "numericalTextBoxNaClB2Ueda");
            numericalTextBoxNaClB2Ueda.BackColor = SystemColors.Control;
            numericalTextBoxNaClB2Ueda.DecimalPlaces = 3;
            numericalTextBoxNaClB2Ueda.FooterBackColor = SystemColors.Control;
            numericalTextBoxNaClB2Ueda.HeaderBackColor = SystemColors.Control;
            numericalTextBoxNaClB2Ueda.Name = "numericalTextBoxNaClB2Ueda";
            numericalTextBoxNaClB2Ueda.SkipEventDuringInput = false;
            numericalTextBoxNaClB2Ueda.SmartIncrement = true;
            numericalTextBoxNaClB2Ueda.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxNaClB2Ueda.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxNaClB2Ueda.ThonsandsSeparator = true;
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            // 
            // numericalTextBoxNaClB2SataMgO
            // 
            resources.ApplyResources(numericalTextBoxNaClB2SataMgO, "numericalTextBoxNaClB2SataMgO");
            numericalTextBoxNaClB2SataMgO.BackColor = SystemColors.Control;
            numericalTextBoxNaClB2SataMgO.DecimalPlaces = 3;
            numericalTextBoxNaClB2SataMgO.FooterBackColor = SystemColors.Control;
            numericalTextBoxNaClB2SataMgO.HeaderBackColor = SystemColors.Control;
            numericalTextBoxNaClB2SataMgO.Name = "numericalTextBoxNaClB2SataMgO";
            numericalTextBoxNaClB2SataMgO.SkipEventDuringInput = false;
            numericalTextBoxNaClB2SataMgO.SmartIncrement = true;
            numericalTextBoxNaClB2SataMgO.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxNaClB2SataMgO.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxNaClB2SataMgO.ThonsandsSeparator = true;
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // numericalTextBoxNaClB2SataPt
            // 
            resources.ApplyResources(numericalTextBoxNaClB2SataPt, "numericalTextBoxNaClB2SataPt");
            numericalTextBoxNaClB2SataPt.BackColor = SystemColors.Control;
            numericalTextBoxNaClB2SataPt.DecimalPlaces = 3;
            numericalTextBoxNaClB2SataPt.FooterBackColor = SystemColors.Control;
            numericalTextBoxNaClB2SataPt.HeaderBackColor = SystemColors.Control;
            numericalTextBoxNaClB2SataPt.Name = "numericalTextBoxNaClB2SataPt";
            numericalTextBoxNaClB2SataPt.SkipEventDuringInput = false;
            numericalTextBoxNaClB2SataPt.SmartIncrement = true;
            numericalTextBoxNaClB2SataPt.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxNaClB2SataPt.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxNaClB2SataPt.ThonsandsSeparator = true;
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // numericalTextBoxNaClB2A
            // 
            resources.ApplyResources(numericalTextBoxNaClB2A, "numericalTextBoxNaClB2A");
            numericalTextBoxNaClB2A.BackColor = SystemColors.Control;
            numericalTextBoxNaClB2A.FooterBackColor = SystemColors.Control;
            numericalTextBoxNaClB2A.HeaderBackColor = SystemColors.Control;
            numericalTextBoxNaClB2A.Name = "numericalTextBoxNaClB2A";
            numericalTextBoxNaClB2A.RadianValue = 0.051138147083433859D;
            numericalTextBoxNaClB2A.SkipEventDuringInput = false;
            numericalTextBoxNaClB2A.SmartIncrement = true;
            numericalTextBoxNaClB2A.ThonsandsSeparator = true;
            numericalTextBoxNaClB2A.Value = 2.93D;
            numericalTextBoxNaClB2A.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // numericalTextBoxNaClB2A0
            // 
            resources.ApplyResources(numericalTextBoxNaClB2A0, "numericalTextBoxNaClB2A0");
            numericalTextBoxNaClB2A0.BackColor = SystemColors.Control;
            numericalTextBoxNaClB2A0.FooterBackColor = SystemColors.Control;
            numericalTextBoxNaClB2A0.HeaderBackColor = SystemColors.Control;
            numericalTextBoxNaClB2A0.Name = "numericalTextBoxNaClB2A0";
            numericalTextBoxNaClB2A0.ReadOnly = true;
            numericalTextBoxNaClB2A0.SkipEventDuringInput = false;
            numericalTextBoxNaClB2A0.SmartIncrement = true;
            numericalTextBoxNaClB2A0.TextBoxBackColor = SystemColors.Control;
            numericalTextBoxNaClB2A0.ThonsandsSeparator = true;
            numericalTextBoxNaClB2A0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // groupBoxCorundum
            // 
            groupBoxCorundum.Controls.Add(numericBoxCorundumDubrovinsky);
            groupBoxCorundum.Controls.Add(numericalTextBoxColundumV);
            groupBoxCorundum.Controls.Add(label5);
            groupBoxCorundum.Controls.Add(numericBoxColundumV0);
            resources.ApplyResources(groupBoxCorundum, "groupBoxCorundum");
            groupBoxCorundum.Name = "groupBoxCorundum";
            groupBoxCorundum.TabStop = false;
            // 
            // numericBoxCorundumDubrovinsky
            // 
            resources.ApplyResources(numericBoxCorundumDubrovinsky, "numericBoxCorundumDubrovinsky");
            numericBoxCorundumDubrovinsky.BackColor = SystemColors.Control;
            numericBoxCorundumDubrovinsky.DecimalPlaces = 3;
            numericBoxCorundumDubrovinsky.FooterBackColor = SystemColors.Control;
            numericBoxCorundumDubrovinsky.HeaderBackColor = SystemColors.Control;
            numericBoxCorundumDubrovinsky.Name = "numericBoxCorundumDubrovinsky";
            numericBoxCorundumDubrovinsky.SkipEventDuringInput = false;
            numericBoxCorundumDubrovinsky.SmartIncrement = true;
            numericBoxCorundumDubrovinsky.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxCorundumDubrovinsky.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxCorundumDubrovinsky.ThonsandsSeparator = true;
            // 
            // numericalTextBoxColundumV
            // 
            resources.ApplyResources(numericalTextBoxColundumV, "numericalTextBoxColundumV");
            numericalTextBoxColundumV.BackColor = SystemColors.Control;
            numericalTextBoxColundumV.FooterBackColor = SystemColors.Control;
            numericalTextBoxColundumV.HeaderBackColor = SystemColors.Control;
            numericalTextBoxColundumV.Name = "numericalTextBoxColundumV";
            numericalTextBoxColundumV.RadianValue = 4.4662054024689839D;
            numericalTextBoxColundumV.SkipEventDuringInput = false;
            numericalTextBoxColundumV.SmartIncrement = true;
            numericalTextBoxColundumV.ThonsandsSeparator = true;
            numericalTextBoxColundumV.Value = 255.89472D;
            numericalTextBoxColundumV.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // numericBoxColundumV0
            // 
            resources.ApplyResources(numericBoxColundumV0, "numericBoxColundumV0");
            numericBoxColundumV0.BackColor = SystemColors.Control;
            numericBoxColundumV0.FooterBackColor = SystemColors.Control;
            numericBoxColundumV0.HeaderBackColor = SystemColors.Control;
            numericBoxColundumV0.Name = "numericBoxColundumV0";
            numericBoxColundumV0.RadianValue = 4.4662054024689839D;
            numericBoxColundumV0.SkipEventDuringInput = false;
            numericBoxColundumV0.SmartIncrement = true;
            numericBoxColundumV0.ThonsandsSeparator = true;
            numericBoxColundumV0.Value = 255.89472D;
            numericBoxColundumV0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(groupBoxGold);
            flowLayoutPanel1.Controls.Add(groupBoxPlatinum);
            flowLayoutPanel1.Controls.Add(groupBoxNaClB1);
            flowLayoutPanel1.Controls.Add(groupBoxNaClB2);
            flowLayoutPanel1.Controls.Add(groupBoxPericlase);
            flowLayoutPanel1.Controls.Add(groupBoxCorundum);
            flowLayoutPanel1.Controls.Add(groupBoxAr);
            flowLayoutPanel1.Controls.Add(groupBoxRe);
            flowLayoutPanel1.Controls.Add(groupBoxMo);
            flowLayoutPanel1.Controls.Add(groupBoxPb);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // groupBoxAr
            // 
            groupBoxAr.Controls.Add(numericalTextBoxArRoss);
            groupBoxAr.Controls.Add(numericalTextBoxArJephcoat);
            groupBoxAr.Controls.Add(numericalTextBoxArA);
            groupBoxAr.Controls.Add(label17);
            groupBoxAr.Controls.Add(label14);
            groupBoxAr.Controls.Add(numericBoxArA0);
            resources.ApplyResources(groupBoxAr, "groupBoxAr");
            groupBoxAr.Name = "groupBoxAr";
            groupBoxAr.TabStop = false;
            // 
            // numericalTextBoxArRoss
            // 
            resources.ApplyResources(numericalTextBoxArRoss, "numericalTextBoxArRoss");
            numericalTextBoxArRoss.BackColor = SystemColors.Control;
            numericalTextBoxArRoss.DecimalPlaces = 3;
            numericalTextBoxArRoss.FooterBackColor = SystemColors.Control;
            numericalTextBoxArRoss.HeaderBackColor = SystemColors.Control;
            numericalTextBoxArRoss.Name = "numericalTextBoxArRoss";
            numericalTextBoxArRoss.SkipEventDuringInput = false;
            numericalTextBoxArRoss.SmartIncrement = true;
            numericalTextBoxArRoss.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxArRoss.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxArRoss.ThonsandsSeparator = true;
            // 
            // numericalTextBoxArJephcoat
            // 
            resources.ApplyResources(numericalTextBoxArJephcoat, "numericalTextBoxArJephcoat");
            numericalTextBoxArJephcoat.BackColor = SystemColors.Control;
            numericalTextBoxArJephcoat.DecimalPlaces = 3;
            numericalTextBoxArJephcoat.FooterBackColor = SystemColors.Control;
            numericalTextBoxArJephcoat.HeaderBackColor = SystemColors.Control;
            numericalTextBoxArJephcoat.Name = "numericalTextBoxArJephcoat";
            numericalTextBoxArJephcoat.SkipEventDuringInput = false;
            numericalTextBoxArJephcoat.SmartIncrement = true;
            numericalTextBoxArJephcoat.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxArJephcoat.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxArJephcoat.ThonsandsSeparator = true;
            // 
            // numericalTextBoxArA
            // 
            resources.ApplyResources(numericalTextBoxArA, "numericalTextBoxArA");
            numericalTextBoxArA.BackColor = SystemColors.Control;
            numericalTextBoxArA.FooterBackColor = SystemColors.Control;
            numericalTextBoxArA.HeaderBackColor = SystemColors.Control;
            numericalTextBoxArA.Name = "numericalTextBoxArA";
            numericalTextBoxArA.RadianValue = 0.071184998871840724D;
            numericalTextBoxArA.SkipEventDuringInput = false;
            numericalTextBoxArA.SmartIncrement = true;
            numericalTextBoxArA.ThonsandsSeparator = true;
            numericalTextBoxArA.Value = 4.0786D;
            numericalTextBoxArA.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            // 
            // numericBoxArA0
            // 
            resources.ApplyResources(numericBoxArA0, "numericBoxArA0");
            numericBoxArA0.BackColor = SystemColors.Control;
            numericBoxArA0.FooterBackColor = SystemColors.Control;
            numericBoxArA0.HeaderBackColor = SystemColors.Control;
            numericBoxArA0.Name = "numericBoxArA0";
            numericBoxArA0.SkipEventDuringInput = false;
            numericBoxArA0.SmartIncrement = true;
            numericBoxArA0.ThonsandsSeparator = true;
            numericBoxArA0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // groupBoxRe
            // 
            groupBoxRe.Controls.Add(numericBoxReDub);
            groupBoxRe.Controls.Add(numericBoxReSakai);
            groupBoxRe.Controls.Add(label26);
            groupBoxRe.Controls.Add(numericBoxReAnz);
            groupBoxRe.Controls.Add(label25);
            groupBoxRe.Controls.Add(numericalTextBoxReZha);
            groupBoxRe.Controls.Add(label24);
            groupBoxRe.Controls.Add(numericBoxReV);
            groupBoxRe.Controls.Add(label18);
            groupBoxRe.Controls.Add(numerictBoxReV0);
            resources.ApplyResources(groupBoxRe, "groupBoxRe");
            groupBoxRe.Name = "groupBoxRe";
            groupBoxRe.TabStop = false;
            // 
            // numericBoxReDub
            // 
            resources.ApplyResources(numericBoxReDub, "numericBoxReDub");
            numericBoxReDub.BackColor = SystemColors.Control;
            numericBoxReDub.DecimalPlaces = 3;
            numericBoxReDub.FooterBackColor = SystemColors.Control;
            numericBoxReDub.HeaderBackColor = SystemColors.Control;
            numericBoxReDub.Name = "numericBoxReDub";
            numericBoxReDub.SkipEventDuringInput = false;
            numericBoxReDub.SmartIncrement = true;
            numericBoxReDub.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxReDub.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxReDub.ThonsandsSeparator = true;
            // 
            // numericBoxReSakai
            // 
            resources.ApplyResources(numericBoxReSakai, "numericBoxReSakai");
            numericBoxReSakai.BackColor = SystemColors.Control;
            numericBoxReSakai.DecimalPlaces = 3;
            numericBoxReSakai.FooterBackColor = SystemColors.Control;
            numericBoxReSakai.HeaderBackColor = SystemColors.Control;
            numericBoxReSakai.Name = "numericBoxReSakai";
            numericBoxReSakai.SkipEventDuringInput = false;
            numericBoxReSakai.SmartIncrement = true;
            numericBoxReSakai.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxReSakai.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxReSakai.ThonsandsSeparator = true;
            // 
            // label26
            // 
            resources.ApplyResources(label26, "label26");
            label26.Name = "label26";
            // 
            // numericBoxReAnz
            // 
            resources.ApplyResources(numericBoxReAnz, "numericBoxReAnz");
            numericBoxReAnz.BackColor = SystemColors.Control;
            numericBoxReAnz.DecimalPlaces = 3;
            numericBoxReAnz.FooterBackColor = SystemColors.Control;
            numericBoxReAnz.HeaderBackColor = SystemColors.Control;
            numericBoxReAnz.Name = "numericBoxReAnz";
            numericBoxReAnz.SkipEventDuringInput = false;
            numericBoxReAnz.SmartIncrement = true;
            numericBoxReAnz.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxReAnz.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxReAnz.ThonsandsSeparator = true;
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            // 
            // numericalTextBoxReZha
            // 
            resources.ApplyResources(numericalTextBoxReZha, "numericalTextBoxReZha");
            numericalTextBoxReZha.BackColor = SystemColors.Control;
            numericalTextBoxReZha.DecimalPlaces = 3;
            numericalTextBoxReZha.FooterBackColor = SystemColors.Control;
            numericalTextBoxReZha.HeaderBackColor = SystemColors.Control;
            numericalTextBoxReZha.Name = "numericalTextBoxReZha";
            numericalTextBoxReZha.SkipEventDuringInput = false;
            numericalTextBoxReZha.SmartIncrement = true;
            numericalTextBoxReZha.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericalTextBoxReZha.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericalTextBoxReZha.ThonsandsSeparator = true;
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
            // 
            // numericBoxReV
            // 
            resources.ApplyResources(numericBoxReV, "numericBoxReV");
            numericBoxReV.BackColor = SystemColors.Control;
            numericBoxReV.FooterBackColor = SystemColors.Control;
            numericBoxReV.HeaderBackColor = SystemColors.Control;
            numericBoxReV.Name = "numericBoxReV";
            numericBoxReV.RadianValue = 0.51361461961226529D;
            numericBoxReV.SkipEventDuringInput = false;
            numericBoxReV.SmartIncrement = true;
            numericBoxReV.ThonsandsSeparator = true;
            numericBoxReV.Value = 29.42795D;
            numericBoxReV.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            // 
            // numerictBoxReV0
            // 
            resources.ApplyResources(numerictBoxReV0, "numerictBoxReV0");
            numerictBoxReV0.BackColor = SystemColors.Control;
            numerictBoxReV0.FooterBackColor = SystemColors.Control;
            numerictBoxReV0.HeaderBackColor = SystemColors.Control;
            numerictBoxReV0.Name = "numerictBoxReV0";
            numerictBoxReV0.RadianValue = 0.51361461961226529D;
            numerictBoxReV0.SkipEventDuringInput = false;
            numerictBoxReV0.SmartIncrement = true;
            numerictBoxReV0.ThonsandsSeparator = true;
            numerictBoxReV0.Value = 29.42795D;
            numerictBoxReV0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // groupBoxMo
            // 
            groupBoxMo.Controls.Add(numericBoxMoZhao);
            groupBoxMo.Controls.Add(numericBoxMoHuang);
            groupBoxMo.Controls.Add(label29);
            groupBoxMo.Controls.Add(numericBoxMoV);
            groupBoxMo.Controls.Add(label28);
            groupBoxMo.Controls.Add(numericBoxMoV0);
            resources.ApplyResources(groupBoxMo, "groupBoxMo");
            groupBoxMo.Name = "groupBoxMo";
            groupBoxMo.TabStop = false;
            // 
            // numericBoxMoZhao
            // 
            resources.ApplyResources(numericBoxMoZhao, "numericBoxMoZhao");
            numericBoxMoZhao.BackColor = SystemColors.Control;
            numericBoxMoZhao.DecimalPlaces = 3;
            numericBoxMoZhao.FooterBackColor = SystemColors.Control;
            numericBoxMoZhao.HeaderBackColor = SystemColors.Control;
            numericBoxMoZhao.Name = "numericBoxMoZhao";
            numericBoxMoZhao.SkipEventDuringInput = false;
            numericBoxMoZhao.SmartIncrement = true;
            numericBoxMoZhao.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxMoZhao.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxMoZhao.ThonsandsSeparator = true;
            // 
            // numericBoxMoHuang
            // 
            resources.ApplyResources(numericBoxMoHuang, "numericBoxMoHuang");
            numericBoxMoHuang.BackColor = SystemColors.Control;
            numericBoxMoHuang.DecimalPlaces = 3;
            numericBoxMoHuang.FooterBackColor = SystemColors.Control;
            numericBoxMoHuang.HeaderBackColor = SystemColors.Control;
            numericBoxMoHuang.Name = "numericBoxMoHuang";
            numericBoxMoHuang.SkipEventDuringInput = false;
            numericBoxMoHuang.SmartIncrement = true;
            numericBoxMoHuang.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxMoHuang.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxMoHuang.ThonsandsSeparator = true;
            // 
            // label29
            // 
            resources.ApplyResources(label29, "label29");
            label29.Name = "label29";
            // 
            // numericBoxMoV
            // 
            resources.ApplyResources(numericBoxMoV, "numericBoxMoV");
            numericBoxMoV.BackColor = SystemColors.Control;
            numericBoxMoV.FooterBackColor = SystemColors.Control;
            numericBoxMoV.HeaderBackColor = SystemColors.Control;
            numericBoxMoV.Name = "numericBoxMoV";
            numericBoxMoV.RadianValue = 0.54349552907103427D;
            numericBoxMoV.SkipEventDuringInput = false;
            numericBoxMoV.SmartIncrement = true;
            numericBoxMoV.ThonsandsSeparator = true;
            numericBoxMoV.Value = 31.14D;
            numericBoxMoV.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // label28
            // 
            resources.ApplyResources(label28, "label28");
            label28.Name = "label28";
            // 
            // numericBoxMoV0
            // 
            resources.ApplyResources(numericBoxMoV0, "numericBoxMoV0");
            numericBoxMoV0.BackColor = SystemColors.Control;
            numericBoxMoV0.FooterBackColor = SystemColors.Control;
            numericBoxMoV0.HeaderBackColor = SystemColors.Control;
            numericBoxMoV0.Name = "numericBoxMoV0";
            numericBoxMoV0.RadianValue = 0.54349552907103427D;
            numericBoxMoV0.SkipEventDuringInput = false;
            numericBoxMoV0.SmartIncrement = true;
            numericBoxMoV0.ThonsandsSeparator = true;
            numericBoxMoV0.Value = 31.14D;
            numericBoxMoV0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // groupBoxPb
            // 
            groupBoxPb.Controls.Add(numericBoxPbStrassle);
            groupBoxPb.Controls.Add(numericBoxPbA);
            groupBoxPb.Controls.Add(label32);
            groupBoxPb.Controls.Add(numericBoxPbA0);
            resources.ApplyResources(groupBoxPb, "groupBoxPb");
            groupBoxPb.Name = "groupBoxPb";
            groupBoxPb.TabStop = false;
            // 
            // numericBoxPbStrassle
            // 
            resources.ApplyResources(numericBoxPbStrassle, "numericBoxPbStrassle");
            numericBoxPbStrassle.BackColor = SystemColors.Control;
            numericBoxPbStrassle.DecimalPlaces = 3;
            numericBoxPbStrassle.FooterBackColor = SystemColors.Control;
            numericBoxPbStrassle.HeaderBackColor = SystemColors.Control;
            numericBoxPbStrassle.Name = "numericBoxPbStrassle";
            numericBoxPbStrassle.SkipEventDuringInput = false;
            numericBoxPbStrassle.SmartIncrement = true;
            numericBoxPbStrassle.TextBoxBackColor = Color.FromArgb(64, 64, 64);
            numericBoxPbStrassle.TextBoxForeColor = Color.FromArgb(192, 192, 255);
            numericBoxPbStrassle.ThonsandsSeparator = true;
            // 
            // numericBoxPbA
            // 
            resources.ApplyResources(numericBoxPbA, "numericBoxPbA");
            numericBoxPbA.BackColor = SystemColors.Control;
            numericBoxPbA.FooterBackColor = SystemColors.Control;
            numericBoxPbA.HeaderBackColor = SystemColors.Control;
            numericBoxPbA.Name = "numericBoxPbA";
            numericBoxPbA.RadianValue = 0.086404095416306087D;
            numericBoxPbA.SkipEventDuringInput = false;
            numericBoxPbA.SmartIncrement = true;
            numericBoxPbA.ThonsandsSeparator = true;
            numericBoxPbA.Value = 4.95059D;
            numericBoxPbA.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // label32
            // 
            resources.ApplyResources(label32, "label32");
            label32.Name = "label32";
            // 
            // numericBoxPbA0
            // 
            resources.ApplyResources(numericBoxPbA0, "numericBoxPbA0");
            numericBoxPbA0.BackColor = SystemColors.Control;
            numericBoxPbA0.FooterBackColor = SystemColors.Control;
            numericBoxPbA0.HeaderBackColor = SystemColors.Control;
            numericBoxPbA0.Name = "numericBoxPbA0";
            numericBoxPbA0.RadianValue = 0.086404095416306087D;
            numericBoxPbA0.SkipEventDuringInput = false;
            numericBoxPbA0.SmartIncrement = true;
            numericBoxPbA0.ThonsandsSeparator = true;
            numericBoxPbA0.Value = 4.95059D;
            numericBoxPbA0.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // checkBoxPlatinum
            // 
            resources.ApplyResources(checkBoxPlatinum, "checkBoxPlatinum");
            checkBoxPlatinum.Checked = true;
            checkBoxPlatinum.CheckState = CheckState.Checked;
            checkBoxPlatinum.Name = "checkBoxPlatinum";
            checkBoxPlatinum.UseVisualStyleBackColor = true;
            checkBoxPlatinum.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // checkBoxGold
            // 
            resources.ApplyResources(checkBoxGold, "checkBoxGold");
            checkBoxGold.Checked = true;
            checkBoxGold.CheckState = CheckState.Checked;
            checkBoxGold.Name = "checkBoxGold";
            checkBoxGold.UseVisualStyleBackColor = true;
            checkBoxGold.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // checkBoxNaClB1
            // 
            resources.ApplyResources(checkBoxNaClB1, "checkBoxNaClB1");
            checkBoxNaClB1.Checked = true;
            checkBoxNaClB1.CheckState = CheckState.Checked;
            checkBoxNaClB1.Name = "checkBoxNaClB1";
            checkBoxNaClB1.UseVisualStyleBackColor = true;
            checkBoxNaClB1.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // checkBoxNaClB2
            // 
            resources.ApplyResources(checkBoxNaClB2, "checkBoxNaClB2");
            checkBoxNaClB2.Checked = true;
            checkBoxNaClB2.CheckState = CheckState.Checked;
            checkBoxNaClB2.Name = "checkBoxNaClB2";
            checkBoxNaClB2.UseVisualStyleBackColor = true;
            checkBoxNaClB2.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // checkBoxPericlase
            // 
            resources.ApplyResources(checkBoxPericlase, "checkBoxPericlase");
            checkBoxPericlase.Checked = true;
            checkBoxPericlase.CheckState = CheckState.Checked;
            checkBoxPericlase.Name = "checkBoxPericlase";
            checkBoxPericlase.UseVisualStyleBackColor = true;
            checkBoxPericlase.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // checkBoxCorundum
            // 
            resources.ApplyResources(checkBoxCorundum, "checkBoxCorundum");
            checkBoxCorundum.Checked = true;
            checkBoxCorundum.CheckState = CheckState.Checked;
            checkBoxCorundum.Name = "checkBoxCorundum";
            checkBoxCorundum.UseVisualStyleBackColor = true;
            checkBoxCorundum.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Controls.Add(checkBoxGold);
            flowLayoutPanel2.Controls.Add(checkBoxPlatinum);
            flowLayoutPanel2.Controls.Add(checkBoxNaClB1);
            flowLayoutPanel2.Controls.Add(checkBoxNaClB2);
            flowLayoutPanel2.Controls.Add(checkBoxPericlase);
            flowLayoutPanel2.Controls.Add(checkBoxCorundum);
            flowLayoutPanel2.Controls.Add(checkBoxAr);
            flowLayoutPanel2.Controls.Add(checkBoxRe);
            flowLayoutPanel2.Controls.Add(checkBoxMo);
            flowLayoutPanel2.Controls.Add(checkBoxPb);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // checkBoxAr
            // 
            checkBoxAr.Checked = true;
            checkBoxAr.CheckState = CheckState.Checked;
            resources.ApplyResources(checkBoxAr, "checkBoxAr");
            checkBoxAr.Name = "checkBoxAr";
            checkBoxAr.UseVisualStyleBackColor = true;
            checkBoxAr.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // checkBoxRe
            // 
            resources.ApplyResources(checkBoxRe, "checkBoxRe");
            checkBoxRe.Checked = true;
            checkBoxRe.CheckState = CheckState.Checked;
            checkBoxRe.Name = "checkBoxRe";
            checkBoxRe.UseVisualStyleBackColor = true;
            checkBoxRe.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // checkBoxMo
            // 
            resources.ApplyResources(checkBoxMo, "checkBoxMo");
            checkBoxMo.Checked = true;
            checkBoxMo.CheckState = CheckState.Checked;
            checkBoxMo.Name = "checkBoxMo";
            checkBoxMo.UseVisualStyleBackColor = true;
            checkBoxMo.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // checkBoxPb
            // 
            resources.ApplyResources(checkBoxPb, "checkBoxPb");
            checkBoxPb.Checked = true;
            checkBoxPb.CheckState = CheckState.Checked;
            checkBoxPb.Name = "checkBoxPb";
            checkBoxPb.UseVisualStyleBackColor = true;
            checkBoxPb.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // checkBoxHBN
            // 
            resources.ApplyResources(checkBoxHBN, "checkBoxHBN");
            checkBoxHBN.Checked = true;
            checkBoxHBN.CheckState = CheckState.Checked;
            checkBoxHBN.Name = "checkBoxHBN";
            checkBoxHBN.UseVisualStyleBackColor = true;
            checkBoxHBN.CheckedChanged += checkBoxGold_CheckedChanged;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // numericBoxTemperature
            // 
            resources.ApplyResources(numericBoxTemperature, "numericBoxTemperature");
            numericBoxTemperature.BackColor = SystemColors.Control;
            numericBoxTemperature.FooterBackColor = SystemColors.Control;
            numericBoxTemperature.HeaderBackColor = SystemColors.Control;
            numericBoxTemperature.Name = "numericBoxTemperature";
            numericBoxTemperature.RadianValue = 5.2359877559829888D;
            numericBoxTemperature.SkipEventDuringInput = false;
            numericBoxTemperature.SmartIncrement = true;
            numericBoxTemperature.ThonsandsSeparator = true;
            numericBoxTemperature.Value = 300D;
            numericBoxTemperature.ValueChanged += numericalTextBox_ValueChanged;
            // 
            // FormEOS
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(numericBoxTemperature);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(numericBoxTemperature0);
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FormEOS";
            Closed += FormEOS_Closed;
            FormClosing += FormEOS_FormClosing;
            Load += FormEOS_Load;
            VisibleChanged += FormEOS_VisibleChanged;
            KeyDown += FormEOS_KeyDown;
            groupBoxPlatinum.ResumeLayout(false);
            groupBoxPlatinum.PerformLayout();
            groupBoxNaClB1.ResumeLayout(false);
            groupBoxNaClB1.PerformLayout();
            groupBoxGold.ResumeLayout(false);
            groupBoxGold.PerformLayout();
            groupBoxPericlase.ResumeLayout(false);
            groupBoxPericlase.PerformLayout();
            groupBoxNaClB2.ResumeLayout(false);
            groupBoxNaClB2.PerformLayout();
            groupBoxCorundum.ResumeLayout(false);
            groupBoxCorundum.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            groupBoxAr.ResumeLayout(false);
            groupBoxAr.PerformLayout();
            groupBoxRe.ResumeLayout(false);
            groupBoxRe.PerformLayout();
            groupBoxMo.ResumeLayout(false);
            groupBoxMo.PerformLayout();
            groupBoxPb.ResumeLayout(false);
            groupBoxPb.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox groupBoxPlatinum;
        private System.Windows.Forms.GroupBox groupBoxNaClB1;
        private System.Windows.Forms.GroupBox groupBoxGold;
        private GroupBox groupBoxPericlase;
        private GroupBox groupBoxNaClB2;
        private Label label22;
        private Label label15;
        private Label label69;
        private GroupBox groupBoxCorundum;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBoxAr;
        private GroupBox groupBoxRe;
        private Label label49;
        public CheckBox checkBoxPlatinum;
        public CheckBox checkBoxGold;
        public CheckBox checkBoxNaClB1;
        public CheckBox checkBoxNaClB2;
        public CheckBox checkBoxPericlase;
        public CheckBox checkBoxCorundum;
        public CheckBox checkBoxAr;
        public CheckBox checkBoxRe;
        public Crystallography.Controls.NumericBox numericalTextBoxGoldA;
        private Crystallography.Controls.NumericBox numericalTextBoxGoldJamieson;
        private Crystallography.Controls.NumericBox numericalTextBoxGoldAnderson;
        private Crystallography.Controls.NumericBox numericalTextBoxGoldTsuchiya;
        private Crystallography.Controls.NumericBox numericalTextBoxGoldSim;
        private Crystallography.Controls.NumericBox numericalTextBoxPtMatsui;
        private Crystallography.Controls.NumericBox numericalTextBoxPtHolmes;
        private Crystallography.Controls.NumericBox numericalTextBoxPtJamieson;
        private Label label9;
        private Label label8;
        private Label label1;
        public Crystallography.Controls.NumericBox numericalTextBoxPtA;
        private Crystallography.Controls.NumericBox numericBoxNaClB1Matsui;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB1Brown;
        private Label label4;
        private Label label3;
        public Crystallography.Controls.NumericBox numericalTextBoxNaClB1A;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB2SakaiVinet;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB2SakaiBM;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB2Ueda;
        private Label label12;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB2SataMgO;
        private Label label11;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB2SataPt;
        private Label label10;
        private Label label7;
        public Crystallography.Controls.NumericBox numericalTextBoxNaClB2A;
        private Label label6;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB2A0;
        private Crystallography.Controls.NumericBox numericalTextBoxMgOAizawa;
        private Crystallography.Controls.NumericBox numericalTextBoxMgODewaele;
        private Crystallography.Controls.NumericBox numericalTextBoxMgOJacson;
        private Label label23;
        private Label label21;
        public Crystallography.Controls.NumericBox numericalTextBoxMgOA;
        private Label label2;
        private Crystallography.Controls.NumericBox numericBoxCorundumDubrovinsky;
        public Crystallography.Controls.NumericBox numericalTextBoxColundumV;
        private Label label5;
        private Crystallography.Controls.NumericBox numericalTextBoxArRoss;
        private Crystallography.Controls.NumericBox numericalTextBoxArJephcoat;
        public Crystallography.Controls.NumericBox numericalTextBoxArA;
        private Label label17;
        private Label label14;
        private Crystallography.Controls.NumericBox numericalTextBoxReZha;
        public Crystallography.Controls.NumericBox numericBoxReV;
        private Label label18;
        private Crystallography.Controls.NumericBox numericBoxMgOTangeVinet;
        private Label label13;
        private Crystallography.Controls.NumericBox numericBoxMgOTangeBM;
        private Label label16;
        private Crystallography.Controls.NumericBox numericBoxAuYokoo;
        private Label label19;
        private Crystallography.Controls.NumericBox numericBoxPtYokoo;
        private Label label20;
        private Crystallography.Controls.NumericBox numericBoxReDub;
        private Crystallography.Controls.NumericBox numericBoxReSakai;
        private Label label26;
        private Crystallography.Controls.NumericBox numericBoxReAnz;
        private Label label25;
        private Label label24;
        private GroupBox groupBoxMo;
        private Crystallography.Controls.NumericBox numericBoxMoHuang;
        public Crystallography.Controls.NumericBox numericBoxMoV;
        private Label label28;
        public CheckBox checkBoxMo;
        public CheckBox checkBoxHBN;
        private Crystallography.Controls.NumericBox numericBoxMoZhao;
        private Label label29;
        private Crystallography.Controls.NumericBox numericBoxPtFratanduono;
        private Label label30;
        private Crystallography.Controls.NumericBox numericBoxAuFratanduono;
        private Label label27;
        private GroupBox groupBoxPb;
        private Crystallography.Controls.NumericBox numericBoxPbStrassle;
        public Crystallography.Controls.NumericBox numericBoxPbA;
        private Label label32;
        public CheckBox checkBoxPb;
        public Crystallography.Controls.NumericBox numericBoxGoldA0;
        public Crystallography.Controls.NumericBox numericBoxTemperature0;
        public Crystallography.Controls.NumericBox numericBoxPtA0;
        public Crystallography.Controls.NumericBox numericBoxNaClB1A0;
        public Crystallography.Controls.NumericBox numericBoxMgOA0;
        public Crystallography.Controls.NumericBox numericBoxColundumV0;
        public Crystallography.Controls.NumericBox numericBoxArA0;
        public Crystallography.Controls.NumericBox numerictBoxReV0;
        public Crystallography.Controls.NumericBox numericBoxMoV0;
        public Crystallography.Controls.NumericBox numericBoxPbA0;
        public Crystallography.Controls.NumericBox numericBoxTemperature;
        private Crystallography.Controls.NumericBox numericBoxNaClB1Skelton;
        private Label label31;
    }


}