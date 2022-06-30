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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEOS));
            this.groupBoxPlatinum = new System.Windows.Forms.GroupBox();
            this.numericBoxPtFratanduono = new Crystallography.Controls.NumericBox();
            this.numericBoxPtYokoo = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPtMatsui = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPtHolmes = new Crystallography.Controls.NumericBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericalTextBoxPtJamieson = new Crystallography.Controls.NumericBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericalTextBoxPtA = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPtA0 = new Crystallography.Controls.NumericBox();
            this.label30 = new System.Windows.Forms.Label();
            this.numericalTextBoxPtT0 = new Crystallography.Controls.NumericBox();
            this.groupBoxNaClB1 = new System.Windows.Forms.GroupBox();
            this.numericalTextBoxNaClB1Matsui = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB1Brown = new Crystallography.Controls.NumericBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericalTextBoxNaClB1A = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB1A0 = new Crystallography.Controls.NumericBox();
            this.groupBoxGold = new System.Windows.Forms.GroupBox();
            this.numericBoxAuFratanduono = new Crystallography.Controls.NumericBox();
            this.numericBoxAuYokoo = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldJamieson = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldTsuchiya = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldSim = new Crystallography.Controls.NumericBox();
            this.label19 = new System.Windows.Forms.Label();
            this.numericalTextBoxGoldAnderson = new Crystallography.Controls.NumericBox();
            this.label49 = new System.Windows.Forms.Label();
            this.numericalTextBoxGoldA = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldA0 = new Crystallography.Controls.NumericBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBoxPericlase = new System.Windows.Forms.GroupBox();
            this.numericBoxMgOTangeBM = new Crystallography.Controls.NumericBox();
            this.numericBoxMgOTangeVinet = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxMgOAizawa = new Crystallography.Controls.NumericBox();
            this.label16 = new System.Windows.Forms.Label();
            this.numericalTextBoxMgODewaele = new Crystallography.Controls.NumericBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericalTextBoxMgOJacson = new Crystallography.Controls.NumericBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.numericalTextBoxMgOA = new Crystallography.Controls.NumericBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericalTextBoxMgOA0 = new Crystallography.Controls.NumericBox();
            this.groupBoxNaClB2 = new System.Windows.Forms.GroupBox();
            this.numericalTextBoxNaClB2SakaiVinet = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB2SakaiBM = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB2Ueda = new Crystallography.Controls.NumericBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericalTextBoxNaClB2SataMgO = new Crystallography.Controls.NumericBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericalTextBoxNaClB2SataPt = new Crystallography.Controls.NumericBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericalTextBoxNaClB2A = new Crystallography.Controls.NumericBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericalTextBoxNaClB2A0 = new Crystallography.Controls.NumericBox();
            this.groupBoxCorundum = new System.Windows.Forms.GroupBox();
            this.numericalTextBoxCorundumDubrovinsky = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxColundumV = new Crystallography.Controls.NumericBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericalTextBoxColundumV0 = new Crystallography.Controls.NumericBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxAr = new System.Windows.Forms.GroupBox();
            this.numericalTextBoxArRoss = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxArJephcoat = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxArA = new Crystallography.Controls.NumericBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericalTextBoxArA0 = new Crystallography.Controls.NumericBox();
            this.groupBoxRe = new System.Windows.Forms.GroupBox();
            this.numericBoxReDub = new Crystallography.Controls.NumericBox();
            this.numericBoxReSakai = new Crystallography.Controls.NumericBox();
            this.label26 = new System.Windows.Forms.Label();
            this.numericBoxReAnz = new Crystallography.Controls.NumericBox();
            this.label25 = new System.Windows.Forms.Label();
            this.numericalTextBoxReZha = new Crystallography.Controls.NumericBox();
            this.label24 = new System.Windows.Forms.Label();
            this.numericBoxReV = new Crystallography.Controls.NumericBox();
            this.label18 = new System.Windows.Forms.Label();
            this.numerictBoxReV0 = new Crystallography.Controls.NumericBox();
            this.groupBoxMo = new System.Windows.Forms.GroupBox();
            this.numericBoxMoZhao = new Crystallography.Controls.NumericBox();
            this.numericBoxMoHuang = new Crystallography.Controls.NumericBox();
            this.label29 = new System.Windows.Forms.Label();
            this.numericBoxMoV = new Crystallography.Controls.NumericBox();
            this.label28 = new System.Windows.Forms.Label();
            this.numericBoxMoV0 = new Crystallography.Controls.NumericBox();
            this.groupBoxPb = new System.Windows.Forms.GroupBox();
            this.numericBoxPbStrassle = new Crystallography.Controls.NumericBox();
            this.numericBoxPbA = new Crystallography.Controls.NumericBox();
            this.label32 = new System.Windows.Forms.Label();
            this.numericBoxPbA0 = new Crystallography.Controls.NumericBox();
            this.checkBoxPlatinum = new System.Windows.Forms.CheckBox();
            this.checkBoxGold = new System.Windows.Forms.CheckBox();
            this.checkBoxNaClB1 = new System.Windows.Forms.CheckBox();
            this.checkBoxNaClB2 = new System.Windows.Forms.CheckBox();
            this.checkBoxPericlase = new System.Windows.Forms.CheckBox();
            this.checkBoxCorundum = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxAr = new System.Windows.Forms.CheckBox();
            this.checkBoxRe = new System.Windows.Forms.CheckBox();
            this.checkBoxMo = new System.Windows.Forms.CheckBox();
            this.checkBoxPb = new System.Windows.Forms.CheckBox();
            this.checkBoxHBN = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericalTextBoxTemperature = new Crystallography.Controls.NumericBox();
            this.groupBoxPlatinum.SuspendLayout();
            this.groupBoxNaClB1.SuspendLayout();
            this.groupBoxGold.SuspendLayout();
            this.groupBoxPericlase.SuspendLayout();
            this.groupBoxNaClB2.SuspendLayout();
            this.groupBoxCorundum.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxAr.SuspendLayout();
            this.groupBoxRe.SuspendLayout();
            this.groupBoxMo.SuspendLayout();
            this.groupBoxPb.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPlatinum
            // 
            this.groupBoxPlatinum.Controls.Add(this.numericBoxPtFratanduono);
            this.groupBoxPlatinum.Controls.Add(this.numericBoxPtYokoo);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtMatsui);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtHolmes);
            this.groupBoxPlatinum.Controls.Add(this.label20);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtJamieson);
            this.groupBoxPlatinum.Controls.Add(this.label9);
            this.groupBoxPlatinum.Controls.Add(this.label8);
            this.groupBoxPlatinum.Controls.Add(this.label1);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtA);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtA0);
            this.groupBoxPlatinum.Controls.Add(this.label30);
            resources.ApplyResources(this.groupBoxPlatinum, "groupBoxPlatinum");
            this.groupBoxPlatinum.Name = "groupBoxPlatinum";
            this.groupBoxPlatinum.TabStop = false;
            // 
            // numericBoxPtFratanduono
            // 
            resources.ApplyResources(this.numericBoxPtFratanduono, "numericBoxPtFratanduono");
            this.numericBoxPtFratanduono.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPtFratanduono.DecimalPlaces = 3;
            this.numericBoxPtFratanduono.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPtFratanduono.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPtFratanduono.Name = "numericBoxPtFratanduono";
            this.numericBoxPtFratanduono.RoundErrorAccuracy = -1;
            this.numericBoxPtFratanduono.SkipEventDuringInput = false;
            this.numericBoxPtFratanduono.SmartIncrement = true;
            this.numericBoxPtFratanduono.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxPtFratanduono.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxPtFratanduono.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxPtFratanduono.ThonsandsSeparator = true;
            // 
            // numericBoxPtYokoo
            // 
            resources.ApplyResources(this.numericBoxPtYokoo, "numericBoxPtYokoo");
            this.numericBoxPtYokoo.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPtYokoo.DecimalPlaces = 3;
            this.numericBoxPtYokoo.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPtYokoo.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPtYokoo.Name = "numericBoxPtYokoo";
            this.numericBoxPtYokoo.RoundErrorAccuracy = -1;
            this.numericBoxPtYokoo.SkipEventDuringInput = false;
            this.numericBoxPtYokoo.SmartIncrement = true;
            this.numericBoxPtYokoo.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxPtYokoo.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxPtYokoo.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxPtYokoo.ThonsandsSeparator = true;
            // 
            // numericalTextBoxPtMatsui
            // 
            resources.ApplyResources(this.numericalTextBoxPtMatsui, "numericalTextBoxPtMatsui");
            this.numericalTextBoxPtMatsui.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtMatsui.DecimalPlaces = 3;
            this.numericalTextBoxPtMatsui.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtMatsui.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtMatsui.Name = "numericalTextBoxPtMatsui";
            this.numericalTextBoxPtMatsui.RoundErrorAccuracy = -1;
            this.numericalTextBoxPtMatsui.SkipEventDuringInput = false;
            this.numericalTextBoxPtMatsui.SmartIncrement = true;
            this.numericalTextBoxPtMatsui.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxPtMatsui.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxPtMatsui.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPtMatsui.ThonsandsSeparator = true;
            // 
            // numericalTextBoxPtHolmes
            // 
            resources.ApplyResources(this.numericalTextBoxPtHolmes, "numericalTextBoxPtHolmes");
            this.numericalTextBoxPtHolmes.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtHolmes.DecimalPlaces = 3;
            this.numericalTextBoxPtHolmes.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtHolmes.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtHolmes.Name = "numericalTextBoxPtHolmes";
            this.numericalTextBoxPtHolmes.RoundErrorAccuracy = -1;
            this.numericalTextBoxPtHolmes.SkipEventDuringInput = false;
            this.numericalTextBoxPtHolmes.SmartIncrement = true;
            this.numericalTextBoxPtHolmes.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxPtHolmes.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxPtHolmes.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPtHolmes.ThonsandsSeparator = true;
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // numericalTextBoxPtJamieson
            // 
            resources.ApplyResources(this.numericalTextBoxPtJamieson, "numericalTextBoxPtJamieson");
            this.numericalTextBoxPtJamieson.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtJamieson.DecimalPlaces = 3;
            this.numericalTextBoxPtJamieson.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtJamieson.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtJamieson.Name = "numericalTextBoxPtJamieson";
            this.numericalTextBoxPtJamieson.RoundErrorAccuracy = -1;
            this.numericalTextBoxPtJamieson.SkipEventDuringInput = false;
            this.numericalTextBoxPtJamieson.SmartIncrement = true;
            this.numericalTextBoxPtJamieson.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxPtJamieson.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxPtJamieson.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPtJamieson.ThonsandsSeparator = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numericalTextBoxPtA
            // 
            resources.ApplyResources(this.numericalTextBoxPtA, "numericalTextBoxPtA");
            this.numericalTextBoxPtA.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtA.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtA.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtA.Name = "numericalTextBoxPtA";
            this.numericalTextBoxPtA.RadianValue = 0.068471011884989538D;
            this.numericalTextBoxPtA.RoundErrorAccuracy = -1;
            this.numericalTextBoxPtA.SkipEventDuringInput = false;
            this.numericalTextBoxPtA.SmartIncrement = true;
            this.numericalTextBoxPtA.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPtA.ThonsandsSeparator = true;
            this.numericalTextBoxPtA.Value = 3.9231D;
            this.numericalTextBoxPtA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxPtA0
            // 
            resources.ApplyResources(this.numericalTextBoxPtA0, "numericalTextBoxPtA0");
            this.numericalTextBoxPtA0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtA0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtA0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtA0.Name = "numericalTextBoxPtA0";
            this.numericalTextBoxPtA0.RadianValue = 0.068471011884989538D;
            this.numericalTextBoxPtA0.RoundErrorAccuracy = -1;
            this.numericalTextBoxPtA0.SkipEventDuringInput = false;
            this.numericalTextBoxPtA0.SmartIncrement = true;
            this.numericalTextBoxPtA0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPtA0.ThonsandsSeparator = true;
            this.numericalTextBoxPtA0.Value = 3.9231D;
            this.numericalTextBoxPtA0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // numericalTextBoxPtT0
            // 
            resources.ApplyResources(this.numericalTextBoxPtT0, "numericalTextBoxPtT0");
            this.numericalTextBoxPtT0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtT0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtT0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtT0.Name = "numericalTextBoxPtT0";
            this.numericalTextBoxPtT0.RadianValue = 5.2359877559829888D;
            this.numericalTextBoxPtT0.RoundErrorAccuracy = -1;
            this.numericalTextBoxPtT0.SkipEventDuringInput = false;
            this.numericalTextBoxPtT0.SmartIncrement = true;
            this.numericalTextBoxPtT0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPtT0.ThonsandsSeparator = true;
            this.numericalTextBoxPtT0.Value = 300D;
            this.numericalTextBoxPtT0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // groupBoxNaClB1
            // 
            this.groupBoxNaClB1.Controls.Add(this.numericalTextBoxNaClB1Matsui);
            this.groupBoxNaClB1.Controls.Add(this.numericalTextBoxNaClB1Brown);
            this.groupBoxNaClB1.Controls.Add(this.label4);
            this.groupBoxNaClB1.Controls.Add(this.label3);
            this.groupBoxNaClB1.Controls.Add(this.numericalTextBoxNaClB1A);
            this.groupBoxNaClB1.Controls.Add(this.numericalTextBoxNaClB1A0);
            resources.ApplyResources(this.groupBoxNaClB1, "groupBoxNaClB1");
            this.groupBoxNaClB1.Name = "groupBoxNaClB1";
            this.groupBoxNaClB1.TabStop = false;
            // 
            // numericalTextBoxNaClB1Matsui
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB1Matsui, "numericalTextBoxNaClB1Matsui");
            this.numericalTextBoxNaClB1Matsui.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1Matsui.DecimalPlaces = 3;
            this.numericalTextBoxNaClB1Matsui.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1Matsui.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1Matsui.Name = "numericalTextBoxNaClB1Matsui";
            this.numericalTextBoxNaClB1Matsui.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB1Matsui.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB1Matsui.SmartIncrement = true;
            this.numericalTextBoxNaClB1Matsui.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB1Matsui.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB1Matsui.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB1Matsui.ThonsandsSeparator = true;
            // 
            // numericalTextBoxNaClB1Brown
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB1Brown, "numericalTextBoxNaClB1Brown");
            this.numericalTextBoxNaClB1Brown.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1Brown.DecimalPlaces = 3;
            this.numericalTextBoxNaClB1Brown.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1Brown.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1Brown.Name = "numericalTextBoxNaClB1Brown";
            this.numericalTextBoxNaClB1Brown.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB1Brown.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB1Brown.SmartIncrement = true;
            this.numericalTextBoxNaClB1Brown.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB1Brown.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB1Brown.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB1Brown.ThonsandsSeparator = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // numericalTextBoxNaClB1A
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB1A, "numericalTextBoxNaClB1A");
            this.numericalTextBoxNaClB1A.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1A.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1A.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1A.Name = "numericalTextBoxNaClB1A";
            this.numericalTextBoxNaClB1A.RadianValue = 0.098419116519960256D;
            this.numericalTextBoxNaClB1A.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB1A.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB1A.SmartIncrement = true;
            this.numericalTextBoxNaClB1A.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB1A.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB1A.Value = 5.639D;
            this.numericalTextBoxNaClB1A.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxNaClB1A0
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB1A0, "numericalTextBoxNaClB1A0");
            this.numericalTextBoxNaClB1A0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1A0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1A0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1A0.Name = "numericalTextBoxNaClB1A0";
            this.numericalTextBoxNaClB1A0.RadianValue = 0.098419116519960256D;
            this.numericalTextBoxNaClB1A0.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB1A0.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB1A0.SmartIncrement = true;
            this.numericalTextBoxNaClB1A0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB1A0.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB1A0.Value = 5.639D;
            this.numericalTextBoxNaClB1A0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // groupBoxGold
            // 
            this.groupBoxGold.Controls.Add(this.numericBoxAuFratanduono);
            this.groupBoxGold.Controls.Add(this.numericBoxAuYokoo);
            this.groupBoxGold.Controls.Add(this.numericalTextBoxGoldJamieson);
            this.groupBoxGold.Controls.Add(this.numericalTextBoxGoldTsuchiya);
            this.groupBoxGold.Controls.Add(this.numericalTextBoxGoldSim);
            this.groupBoxGold.Controls.Add(this.label19);
            this.groupBoxGold.Controls.Add(this.numericalTextBoxGoldAnderson);
            this.groupBoxGold.Controls.Add(this.label49);
            this.groupBoxGold.Controls.Add(this.numericalTextBoxGoldA);
            this.groupBoxGold.Controls.Add(this.numericalTextBoxGoldA0);
            this.groupBoxGold.Controls.Add(this.label22);
            this.groupBoxGold.Controls.Add(this.label69);
            this.groupBoxGold.Controls.Add(this.label15);
            this.groupBoxGold.Controls.Add(this.label27);
            resources.ApplyResources(this.groupBoxGold, "groupBoxGold");
            this.groupBoxGold.Name = "groupBoxGold";
            this.groupBoxGold.TabStop = false;
            // 
            // numericBoxAuFratanduono
            // 
            resources.ApplyResources(this.numericBoxAuFratanduono, "numericBoxAuFratanduono");
            this.numericBoxAuFratanduono.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAuFratanduono.DecimalPlaces = 3;
            this.numericBoxAuFratanduono.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAuFratanduono.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAuFratanduono.Name = "numericBoxAuFratanduono";
            this.numericBoxAuFratanduono.RoundErrorAccuracy = -1;
            this.numericBoxAuFratanduono.SkipEventDuringInput = false;
            this.numericBoxAuFratanduono.SmartIncrement = true;
            this.numericBoxAuFratanduono.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxAuFratanduono.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxAuFratanduono.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxAuFratanduono.ThonsandsSeparator = true;
            // 
            // numericBoxAuYokoo
            // 
            resources.ApplyResources(this.numericBoxAuYokoo, "numericBoxAuYokoo");
            this.numericBoxAuYokoo.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAuYokoo.DecimalPlaces = 3;
            this.numericBoxAuYokoo.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAuYokoo.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAuYokoo.Name = "numericBoxAuYokoo";
            this.numericBoxAuYokoo.RoundErrorAccuracy = -1;
            this.numericBoxAuYokoo.SkipEventDuringInput = false;
            this.numericBoxAuYokoo.SmartIncrement = true;
            this.numericBoxAuYokoo.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxAuYokoo.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxAuYokoo.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxAuYokoo.ThonsandsSeparator = true;
            // 
            // numericalTextBoxGoldJamieson
            // 
            resources.ApplyResources(this.numericalTextBoxGoldJamieson, "numericalTextBoxGoldJamieson");
            this.numericalTextBoxGoldJamieson.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldJamieson.DecimalPlaces = 3;
            this.numericalTextBoxGoldJamieson.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldJamieson.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldJamieson.Name = "numericalTextBoxGoldJamieson";
            this.numericalTextBoxGoldJamieson.RoundErrorAccuracy = -1;
            this.numericalTextBoxGoldJamieson.SkipEventDuringInput = false;
            this.numericalTextBoxGoldJamieson.SmartIncrement = true;
            this.numericalTextBoxGoldJamieson.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxGoldJamieson.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxGoldJamieson.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxGoldJamieson.ThonsandsSeparator = true;
            // 
            // numericalTextBoxGoldTsuchiya
            // 
            resources.ApplyResources(this.numericalTextBoxGoldTsuchiya, "numericalTextBoxGoldTsuchiya");
            this.numericalTextBoxGoldTsuchiya.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldTsuchiya.DecimalPlaces = 3;
            this.numericalTextBoxGoldTsuchiya.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldTsuchiya.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldTsuchiya.Name = "numericalTextBoxGoldTsuchiya";
            this.numericalTextBoxGoldTsuchiya.RoundErrorAccuracy = -1;
            this.numericalTextBoxGoldTsuchiya.SkipEventDuringInput = false;
            this.numericalTextBoxGoldTsuchiya.SmartIncrement = true;
            this.numericalTextBoxGoldTsuchiya.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxGoldTsuchiya.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxGoldTsuchiya.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxGoldTsuchiya.ThonsandsSeparator = true;
            // 
            // numericalTextBoxGoldSim
            // 
            resources.ApplyResources(this.numericalTextBoxGoldSim, "numericalTextBoxGoldSim");
            this.numericalTextBoxGoldSim.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldSim.DecimalPlaces = 3;
            this.numericalTextBoxGoldSim.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldSim.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldSim.Name = "numericalTextBoxGoldSim";
            this.numericalTextBoxGoldSim.RoundErrorAccuracy = -1;
            this.numericalTextBoxGoldSim.SkipEventDuringInput = false;
            this.numericalTextBoxGoldSim.SmartIncrement = true;
            this.numericalTextBoxGoldSim.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxGoldSim.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxGoldSim.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxGoldSim.ThonsandsSeparator = true;
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // numericalTextBoxGoldAnderson
            // 
            resources.ApplyResources(this.numericalTextBoxGoldAnderson, "numericalTextBoxGoldAnderson");
            this.numericalTextBoxGoldAnderson.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldAnderson.DecimalPlaces = 3;
            this.numericalTextBoxGoldAnderson.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldAnderson.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldAnderson.Name = "numericalTextBoxGoldAnderson";
            this.numericalTextBoxGoldAnderson.RoundErrorAccuracy = -1;
            this.numericalTextBoxGoldAnderson.SkipEventDuringInput = false;
            this.numericalTextBoxGoldAnderson.SmartIncrement = true;
            this.numericalTextBoxGoldAnderson.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxGoldAnderson.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxGoldAnderson.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxGoldAnderson.ThonsandsSeparator = true;
            // 
            // label49
            // 
            resources.ApplyResources(this.label49, "label49");
            this.label49.Name = "label49";
            // 
            // numericalTextBoxGoldA
            // 
            resources.ApplyResources(this.numericalTextBoxGoldA, "numericalTextBoxGoldA");
            this.numericalTextBoxGoldA.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldA.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldA.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldA.Name = "numericalTextBoxGoldA";
            this.numericalTextBoxGoldA.RadianValue = 0.071178890219458738D;
            this.numericalTextBoxGoldA.RoundErrorAccuracy = -1;
            this.numericalTextBoxGoldA.SkipEventDuringInput = false;
            this.numericalTextBoxGoldA.SmartIncrement = true;
            this.numericalTextBoxGoldA.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxGoldA.ThonsandsSeparator = true;
            this.numericalTextBoxGoldA.Value = 4.07825D;
            this.numericalTextBoxGoldA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxGoldA0
            // 
            resources.ApplyResources(this.numericalTextBoxGoldA0, "numericalTextBoxGoldA0");
            this.numericalTextBoxGoldA0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldA0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldA0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldA0.Name = "numericalTextBoxGoldA0";
            this.numericalTextBoxGoldA0.RadianValue = 0.071178890219458738D;
            this.numericalTextBoxGoldA0.RoundErrorAccuracy = -1;
            this.numericalTextBoxGoldA0.SkipEventDuringInput = false;
            this.numericalTextBoxGoldA0.SmartIncrement = true;
            this.numericalTextBoxGoldA0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxGoldA0.ThonsandsSeparator = true;
            this.numericalTextBoxGoldA0.Value = 4.07825D;
            this.numericalTextBoxGoldA0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            this.numericalTextBoxGoldA0.Load += new System.EventHandler(this.numericalTextBoxGoldA0_Load);
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label69
            // 
            resources.ApplyResources(this.label69, "label69");
            this.label69.Name = "label69";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // groupBoxPericlase
            // 
            this.groupBoxPericlase.Controls.Add(this.numericBoxMgOTangeBM);
            this.groupBoxPericlase.Controls.Add(this.numericBoxMgOTangeVinet);
            this.groupBoxPericlase.Controls.Add(this.numericalTextBoxMgOAizawa);
            this.groupBoxPericlase.Controls.Add(this.label16);
            this.groupBoxPericlase.Controls.Add(this.numericalTextBoxMgODewaele);
            this.groupBoxPericlase.Controls.Add(this.label13);
            this.groupBoxPericlase.Controls.Add(this.numericalTextBoxMgOJacson);
            this.groupBoxPericlase.Controls.Add(this.label23);
            this.groupBoxPericlase.Controls.Add(this.label21);
            this.groupBoxPericlase.Controls.Add(this.numericalTextBoxMgOA);
            this.groupBoxPericlase.Controls.Add(this.label2);
            this.groupBoxPericlase.Controls.Add(this.numericalTextBoxMgOA0);
            resources.ApplyResources(this.groupBoxPericlase, "groupBoxPericlase");
            this.groupBoxPericlase.Name = "groupBoxPericlase";
            this.groupBoxPericlase.TabStop = false;
            // 
            // numericBoxMgOTangeBM
            // 
            resources.ApplyResources(this.numericBoxMgOTangeBM, "numericBoxMgOTangeBM");
            this.numericBoxMgOTangeBM.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMgOTangeBM.DecimalPlaces = 3;
            this.numericBoxMgOTangeBM.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMgOTangeBM.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMgOTangeBM.Name = "numericBoxMgOTangeBM";
            this.numericBoxMgOTangeBM.RoundErrorAccuracy = -1;
            this.numericBoxMgOTangeBM.SkipEventDuringInput = false;
            this.numericBoxMgOTangeBM.SmartIncrement = true;
            this.numericBoxMgOTangeBM.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxMgOTangeBM.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxMgOTangeBM.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxMgOTangeBM.ThonsandsSeparator = true;
            // 
            // numericBoxMgOTangeVinet
            // 
            resources.ApplyResources(this.numericBoxMgOTangeVinet, "numericBoxMgOTangeVinet");
            this.numericBoxMgOTangeVinet.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMgOTangeVinet.DecimalPlaces = 3;
            this.numericBoxMgOTangeVinet.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMgOTangeVinet.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMgOTangeVinet.Name = "numericBoxMgOTangeVinet";
            this.numericBoxMgOTangeVinet.RoundErrorAccuracy = -1;
            this.numericBoxMgOTangeVinet.SkipEventDuringInput = false;
            this.numericBoxMgOTangeVinet.SmartIncrement = true;
            this.numericBoxMgOTangeVinet.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxMgOTangeVinet.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxMgOTangeVinet.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxMgOTangeVinet.ThonsandsSeparator = true;
            // 
            // numericalTextBoxMgOAizawa
            // 
            resources.ApplyResources(this.numericalTextBoxMgOAizawa, "numericalTextBoxMgOAizawa");
            this.numericalTextBoxMgOAizawa.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOAizawa.DecimalPlaces = 3;
            this.numericalTextBoxMgOAizawa.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOAizawa.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOAizawa.Name = "numericalTextBoxMgOAizawa";
            this.numericalTextBoxMgOAizawa.RoundErrorAccuracy = -1;
            this.numericalTextBoxMgOAizawa.SkipEventDuringInput = false;
            this.numericalTextBoxMgOAizawa.SmartIncrement = true;
            this.numericalTextBoxMgOAizawa.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxMgOAizawa.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxMgOAizawa.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxMgOAizawa.ThonsandsSeparator = true;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // numericalTextBoxMgODewaele
            // 
            resources.ApplyResources(this.numericalTextBoxMgODewaele, "numericalTextBoxMgODewaele");
            this.numericalTextBoxMgODewaele.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgODewaele.DecimalPlaces = 3;
            this.numericalTextBoxMgODewaele.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgODewaele.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgODewaele.Name = "numericalTextBoxMgODewaele";
            this.numericalTextBoxMgODewaele.RoundErrorAccuracy = -1;
            this.numericalTextBoxMgODewaele.SkipEventDuringInput = false;
            this.numericalTextBoxMgODewaele.SmartIncrement = true;
            this.numericalTextBoxMgODewaele.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxMgODewaele.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxMgODewaele.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxMgODewaele.ThonsandsSeparator = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // numericalTextBoxMgOJacson
            // 
            resources.ApplyResources(this.numericalTextBoxMgOJacson, "numericalTextBoxMgOJacson");
            this.numericalTextBoxMgOJacson.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOJacson.DecimalPlaces = 3;
            this.numericalTextBoxMgOJacson.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOJacson.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOJacson.Name = "numericalTextBoxMgOJacson";
            this.numericalTextBoxMgOJacson.RoundErrorAccuracy = -1;
            this.numericalTextBoxMgOJacson.SkipEventDuringInput = false;
            this.numericalTextBoxMgOJacson.SmartIncrement = true;
            this.numericalTextBoxMgOJacson.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxMgOJacson.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxMgOJacson.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxMgOJacson.ThonsandsSeparator = true;
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // numericalTextBoxMgOA
            // 
            resources.ApplyResources(this.numericalTextBoxMgOA, "numericalTextBoxMgOA");
            this.numericalTextBoxMgOA.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOA.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOA.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOA.Name = "numericalTextBoxMgOA";
            this.numericalTextBoxMgOA.RadianValue = 0.0734993054599852D;
            this.numericalTextBoxMgOA.RoundErrorAccuracy = -1;
            this.numericalTextBoxMgOA.SkipEventDuringInput = false;
            this.numericalTextBoxMgOA.SmartIncrement = true;
            this.numericalTextBoxMgOA.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxMgOA.ThonsandsSeparator = true;
            this.numericalTextBoxMgOA.Value = 4.2112D;
            this.numericalTextBoxMgOA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // numericalTextBoxMgOA0
            // 
            resources.ApplyResources(this.numericalTextBoxMgOA0, "numericalTextBoxMgOA0");
            this.numericalTextBoxMgOA0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOA0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOA0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOA0.Name = "numericalTextBoxMgOA0";
            this.numericalTextBoxMgOA0.RadianValue = 0.0734993054599852D;
            this.numericalTextBoxMgOA0.RoundErrorAccuracy = -1;
            this.numericalTextBoxMgOA0.SkipEventDuringInput = false;
            this.numericalTextBoxMgOA0.SmartIncrement = true;
            this.numericalTextBoxMgOA0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxMgOA0.ThonsandsSeparator = true;
            this.numericalTextBoxMgOA0.Value = 4.2112D;
            this.numericalTextBoxMgOA0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // groupBoxNaClB2
            // 
            this.groupBoxNaClB2.Controls.Add(this.numericalTextBoxNaClB2SakaiVinet);
            this.groupBoxNaClB2.Controls.Add(this.numericalTextBoxNaClB2SakaiBM);
            this.groupBoxNaClB2.Controls.Add(this.numericalTextBoxNaClB2Ueda);
            this.groupBoxNaClB2.Controls.Add(this.label12);
            this.groupBoxNaClB2.Controls.Add(this.numericalTextBoxNaClB2SataMgO);
            this.groupBoxNaClB2.Controls.Add(this.label11);
            this.groupBoxNaClB2.Controls.Add(this.numericalTextBoxNaClB2SataPt);
            this.groupBoxNaClB2.Controls.Add(this.label10);
            this.groupBoxNaClB2.Controls.Add(this.label7);
            this.groupBoxNaClB2.Controls.Add(this.numericalTextBoxNaClB2A);
            this.groupBoxNaClB2.Controls.Add(this.label6);
            this.groupBoxNaClB2.Controls.Add(this.numericalTextBoxNaClB2A0);
            resources.ApplyResources(this.groupBoxNaClB2, "groupBoxNaClB2");
            this.groupBoxNaClB2.Name = "groupBoxNaClB2";
            this.groupBoxNaClB2.TabStop = false;
            // 
            // numericalTextBoxNaClB2SakaiVinet
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2SakaiVinet, "numericalTextBoxNaClB2SakaiVinet");
            this.numericalTextBoxNaClB2SakaiVinet.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SakaiVinet.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2SakaiVinet.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SakaiVinet.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SakaiVinet.Name = "numericalTextBoxNaClB2SakaiVinet";
            this.numericalTextBoxNaClB2SakaiVinet.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB2SakaiVinet.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2SakaiVinet.SmartIncrement = true;
            this.numericalTextBoxNaClB2SakaiVinet.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2SakaiVinet.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2SakaiVinet.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB2SakaiVinet.ThonsandsSeparator = true;
            // 
            // numericalTextBoxNaClB2SakaiBM
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2SakaiBM, "numericalTextBoxNaClB2SakaiBM");
            this.numericalTextBoxNaClB2SakaiBM.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SakaiBM.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2SakaiBM.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SakaiBM.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SakaiBM.Name = "numericalTextBoxNaClB2SakaiBM";
            this.numericalTextBoxNaClB2SakaiBM.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB2SakaiBM.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2SakaiBM.SmartIncrement = true;
            this.numericalTextBoxNaClB2SakaiBM.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2SakaiBM.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2SakaiBM.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB2SakaiBM.ThonsandsSeparator = true;
            // 
            // numericalTextBoxNaClB2Ueda
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2Ueda, "numericalTextBoxNaClB2Ueda");
            this.numericalTextBoxNaClB2Ueda.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2Ueda.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2Ueda.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2Ueda.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2Ueda.Name = "numericalTextBoxNaClB2Ueda";
            this.numericalTextBoxNaClB2Ueda.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB2Ueda.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2Ueda.SmartIncrement = true;
            this.numericalTextBoxNaClB2Ueda.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2Ueda.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2Ueda.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB2Ueda.ThonsandsSeparator = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // numericalTextBoxNaClB2SataMgO
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2SataMgO, "numericalTextBoxNaClB2SataMgO");
            this.numericalTextBoxNaClB2SataMgO.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SataMgO.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2SataMgO.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SataMgO.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SataMgO.Name = "numericalTextBoxNaClB2SataMgO";
            this.numericalTextBoxNaClB2SataMgO.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB2SataMgO.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2SataMgO.SmartIncrement = true;
            this.numericalTextBoxNaClB2SataMgO.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2SataMgO.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2SataMgO.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB2SataMgO.ThonsandsSeparator = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // numericalTextBoxNaClB2SataPt
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2SataPt, "numericalTextBoxNaClB2SataPt");
            this.numericalTextBoxNaClB2SataPt.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SataPt.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2SataPt.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SataPt.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SataPt.Name = "numericalTextBoxNaClB2SataPt";
            this.numericalTextBoxNaClB2SataPt.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB2SataPt.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2SataPt.SmartIncrement = true;
            this.numericalTextBoxNaClB2SataPt.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2SataPt.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2SataPt.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB2SataPt.ThonsandsSeparator = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // numericalTextBoxNaClB2A
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2A, "numericalTextBoxNaClB2A");
            this.numericalTextBoxNaClB2A.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2A.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2A.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2A.Name = "numericalTextBoxNaClB2A";
            this.numericalTextBoxNaClB2A.RadianValue = 0.051138147083433859D;
            this.numericalTextBoxNaClB2A.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB2A.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2A.SmartIncrement = true;
            this.numericalTextBoxNaClB2A.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB2A.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB2A.Value = 2.93D;
            this.numericalTextBoxNaClB2A.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // numericalTextBoxNaClB2A0
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2A0, "numericalTextBoxNaClB2A0");
            this.numericalTextBoxNaClB2A0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2A0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2A0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2A0.Name = "numericalTextBoxNaClB2A0";
            this.numericalTextBoxNaClB2A0.ReadOnly = true;
            this.numericalTextBoxNaClB2A0.RoundErrorAccuracy = -1;
            this.numericalTextBoxNaClB2A0.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2A0.SmartIncrement = true;
            this.numericalTextBoxNaClB2A0.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2A0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxNaClB2A0.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB2A0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // groupBoxCorundum
            // 
            this.groupBoxCorundum.Controls.Add(this.numericalTextBoxCorundumDubrovinsky);
            this.groupBoxCorundum.Controls.Add(this.numericalTextBoxColundumV);
            this.groupBoxCorundum.Controls.Add(this.label5);
            this.groupBoxCorundum.Controls.Add(this.numericalTextBoxColundumV0);
            resources.ApplyResources(this.groupBoxCorundum, "groupBoxCorundum");
            this.groupBoxCorundum.Name = "groupBoxCorundum";
            this.groupBoxCorundum.TabStop = false;
            // 
            // numericalTextBoxCorundumDubrovinsky
            // 
            resources.ApplyResources(this.numericalTextBoxCorundumDubrovinsky, "numericalTextBoxCorundumDubrovinsky");
            this.numericalTextBoxCorundumDubrovinsky.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxCorundumDubrovinsky.DecimalPlaces = 3;
            this.numericalTextBoxCorundumDubrovinsky.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxCorundumDubrovinsky.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxCorundumDubrovinsky.Name = "numericalTextBoxCorundumDubrovinsky";
            this.numericalTextBoxCorundumDubrovinsky.RoundErrorAccuracy = -1;
            this.numericalTextBoxCorundumDubrovinsky.SkipEventDuringInput = false;
            this.numericalTextBoxCorundumDubrovinsky.SmartIncrement = true;
            this.numericalTextBoxCorundumDubrovinsky.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxCorundumDubrovinsky.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxCorundumDubrovinsky.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxCorundumDubrovinsky.ThonsandsSeparator = true;
            // 
            // numericalTextBoxColundumV
            // 
            resources.ApplyResources(this.numericalTextBoxColundumV, "numericalTextBoxColundumV");
            this.numericalTextBoxColundumV.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxColundumV.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxColundumV.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxColundumV.Name = "numericalTextBoxColundumV";
            this.numericalTextBoxColundumV.RadianValue = 4.4662054024689839D;
            this.numericalTextBoxColundumV.RoundErrorAccuracy = -1;
            this.numericalTextBoxColundumV.SkipEventDuringInput = false;
            this.numericalTextBoxColundumV.SmartIncrement = true;
            this.numericalTextBoxColundumV.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxColundumV.ThonsandsSeparator = true;
            this.numericalTextBoxColundumV.Value = 255.89472D;
            this.numericalTextBoxColundumV.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // numericalTextBoxColundumV0
            // 
            resources.ApplyResources(this.numericalTextBoxColundumV0, "numericalTextBoxColundumV0");
            this.numericalTextBoxColundumV0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxColundumV0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxColundumV0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxColundumV0.Name = "numericalTextBoxColundumV0";
            this.numericalTextBoxColundumV0.RadianValue = 4.4662054024689839D;
            this.numericalTextBoxColundumV0.RoundErrorAccuracy = -1;
            this.numericalTextBoxColundumV0.SkipEventDuringInput = false;
            this.numericalTextBoxColundumV0.SmartIncrement = true;
            this.numericalTextBoxColundumV0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxColundumV0.ThonsandsSeparator = true;
            this.numericalTextBoxColundumV0.Value = 255.89472D;
            this.numericalTextBoxColundumV0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.groupBoxGold);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxPlatinum);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxNaClB1);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxNaClB2);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxPericlase);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxCorundum);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxAr);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxRe);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxMo);
            this.flowLayoutPanel1.Controls.Add(this.groupBoxPb);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // groupBoxAr
            // 
            this.groupBoxAr.Controls.Add(this.numericalTextBoxArRoss);
            this.groupBoxAr.Controls.Add(this.numericalTextBoxArJephcoat);
            this.groupBoxAr.Controls.Add(this.numericalTextBoxArA);
            this.groupBoxAr.Controls.Add(this.label17);
            this.groupBoxAr.Controls.Add(this.label14);
            this.groupBoxAr.Controls.Add(this.numericalTextBoxArA0);
            resources.ApplyResources(this.groupBoxAr, "groupBoxAr");
            this.groupBoxAr.Name = "groupBoxAr";
            this.groupBoxAr.TabStop = false;
            // 
            // numericalTextBoxArRoss
            // 
            resources.ApplyResources(this.numericalTextBoxArRoss, "numericalTextBoxArRoss");
            this.numericalTextBoxArRoss.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArRoss.DecimalPlaces = 3;
            this.numericalTextBoxArRoss.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArRoss.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArRoss.Name = "numericalTextBoxArRoss";
            this.numericalTextBoxArRoss.RoundErrorAccuracy = -1;
            this.numericalTextBoxArRoss.SkipEventDuringInput = false;
            this.numericalTextBoxArRoss.SmartIncrement = true;
            this.numericalTextBoxArRoss.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxArRoss.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxArRoss.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxArRoss.ThonsandsSeparator = true;
            // 
            // numericalTextBoxArJephcoat
            // 
            resources.ApplyResources(this.numericalTextBoxArJephcoat, "numericalTextBoxArJephcoat");
            this.numericalTextBoxArJephcoat.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArJephcoat.DecimalPlaces = 3;
            this.numericalTextBoxArJephcoat.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArJephcoat.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArJephcoat.Name = "numericalTextBoxArJephcoat";
            this.numericalTextBoxArJephcoat.RoundErrorAccuracy = -1;
            this.numericalTextBoxArJephcoat.SkipEventDuringInput = false;
            this.numericalTextBoxArJephcoat.SmartIncrement = true;
            this.numericalTextBoxArJephcoat.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxArJephcoat.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxArJephcoat.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxArJephcoat.ThonsandsSeparator = true;
            // 
            // numericalTextBoxArA
            // 
            resources.ApplyResources(this.numericalTextBoxArA, "numericalTextBoxArA");
            this.numericalTextBoxArA.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArA.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArA.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArA.Name = "numericalTextBoxArA";
            this.numericalTextBoxArA.RadianValue = 0.071184998871840724D;
            this.numericalTextBoxArA.RoundErrorAccuracy = -1;
            this.numericalTextBoxArA.SkipEventDuringInput = false;
            this.numericalTextBoxArA.SmartIncrement = true;
            this.numericalTextBoxArA.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxArA.ThonsandsSeparator = true;
            this.numericalTextBoxArA.Value = 4.0786D;
            this.numericalTextBoxArA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // numericalTextBoxArA0
            // 
            resources.ApplyResources(this.numericalTextBoxArA0, "numericalTextBoxArA0");
            this.numericalTextBoxArA0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArA0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArA0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArA0.Name = "numericalTextBoxArA0";
            this.numericalTextBoxArA0.RoundErrorAccuracy = -1;
            this.numericalTextBoxArA0.SkipEventDuringInput = false;
            this.numericalTextBoxArA0.SmartIncrement = true;
            this.numericalTextBoxArA0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxArA0.ThonsandsSeparator = true;
            this.numericalTextBoxArA0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // groupBoxRe
            // 
            this.groupBoxRe.Controls.Add(this.numericBoxReDub);
            this.groupBoxRe.Controls.Add(this.numericBoxReSakai);
            this.groupBoxRe.Controls.Add(this.label26);
            this.groupBoxRe.Controls.Add(this.numericBoxReAnz);
            this.groupBoxRe.Controls.Add(this.label25);
            this.groupBoxRe.Controls.Add(this.numericalTextBoxReZha);
            this.groupBoxRe.Controls.Add(this.label24);
            this.groupBoxRe.Controls.Add(this.numericBoxReV);
            this.groupBoxRe.Controls.Add(this.label18);
            this.groupBoxRe.Controls.Add(this.numerictBoxReV0);
            resources.ApplyResources(this.groupBoxRe, "groupBoxRe");
            this.groupBoxRe.Name = "groupBoxRe";
            this.groupBoxRe.TabStop = false;
            // 
            // numericBoxReDub
            // 
            resources.ApplyResources(this.numericBoxReDub, "numericBoxReDub");
            this.numericBoxReDub.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReDub.DecimalPlaces = 3;
            this.numericBoxReDub.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReDub.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReDub.Name = "numericBoxReDub";
            this.numericBoxReDub.RoundErrorAccuracy = -1;
            this.numericBoxReDub.SkipEventDuringInput = false;
            this.numericBoxReDub.SmartIncrement = true;
            this.numericBoxReDub.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxReDub.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxReDub.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxReDub.ThonsandsSeparator = true;
            // 
            // numericBoxReSakai
            // 
            resources.ApplyResources(this.numericBoxReSakai, "numericBoxReSakai");
            this.numericBoxReSakai.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReSakai.DecimalPlaces = 3;
            this.numericBoxReSakai.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReSakai.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReSakai.Name = "numericBoxReSakai";
            this.numericBoxReSakai.RoundErrorAccuracy = -1;
            this.numericBoxReSakai.SkipEventDuringInput = false;
            this.numericBoxReSakai.SmartIncrement = true;
            this.numericBoxReSakai.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxReSakai.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxReSakai.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxReSakai.ThonsandsSeparator = true;
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // numericBoxReAnz
            // 
            resources.ApplyResources(this.numericBoxReAnz, "numericBoxReAnz");
            this.numericBoxReAnz.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReAnz.DecimalPlaces = 3;
            this.numericBoxReAnz.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReAnz.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReAnz.Name = "numericBoxReAnz";
            this.numericBoxReAnz.RoundErrorAccuracy = -1;
            this.numericBoxReAnz.SkipEventDuringInput = false;
            this.numericBoxReAnz.SmartIncrement = true;
            this.numericBoxReAnz.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxReAnz.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxReAnz.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxReAnz.ThonsandsSeparator = true;
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // numericalTextBoxReZha
            // 
            resources.ApplyResources(this.numericalTextBoxReZha, "numericalTextBoxReZha");
            this.numericalTextBoxReZha.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxReZha.DecimalPlaces = 3;
            this.numericalTextBoxReZha.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxReZha.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxReZha.Name = "numericalTextBoxReZha";
            this.numericalTextBoxReZha.RoundErrorAccuracy = -1;
            this.numericalTextBoxReZha.SkipEventDuringInput = false;
            this.numericalTextBoxReZha.SmartIncrement = true;
            this.numericalTextBoxReZha.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxReZha.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxReZha.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxReZha.ThonsandsSeparator = true;
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // numericBoxReV
            // 
            resources.ApplyResources(this.numericBoxReV, "numericBoxReV");
            this.numericBoxReV.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReV.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReV.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxReV.Name = "numericBoxReV";
            this.numericBoxReV.RadianValue = 0.51361461961226529D;
            this.numericBoxReV.RoundErrorAccuracy = -1;
            this.numericBoxReV.SkipEventDuringInput = false;
            this.numericBoxReV.SmartIncrement = true;
            this.numericBoxReV.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxReV.ThonsandsSeparator = true;
            this.numericBoxReV.Value = 29.42795D;
            this.numericBoxReV.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // numerictBoxReV0
            // 
            resources.ApplyResources(this.numerictBoxReV0, "numerictBoxReV0");
            this.numerictBoxReV0.BackColor = System.Drawing.SystemColors.Control;
            this.numerictBoxReV0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numerictBoxReV0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numerictBoxReV0.Name = "numerictBoxReV0";
            this.numerictBoxReV0.RadianValue = 0.51361461961226529D;
            this.numerictBoxReV0.RoundErrorAccuracy = -1;
            this.numerictBoxReV0.SkipEventDuringInput = false;
            this.numerictBoxReV0.SmartIncrement = true;
            this.numerictBoxReV0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numerictBoxReV0.ThonsandsSeparator = true;
            this.numerictBoxReV0.Value = 29.42795D;
            this.numerictBoxReV0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // groupBoxMo
            // 
            this.groupBoxMo.Controls.Add(this.numericBoxMoZhao);
            this.groupBoxMo.Controls.Add(this.numericBoxMoHuang);
            this.groupBoxMo.Controls.Add(this.label29);
            this.groupBoxMo.Controls.Add(this.numericBoxMoV);
            this.groupBoxMo.Controls.Add(this.label28);
            this.groupBoxMo.Controls.Add(this.numericBoxMoV0);
            resources.ApplyResources(this.groupBoxMo, "groupBoxMo");
            this.groupBoxMo.Name = "groupBoxMo";
            this.groupBoxMo.TabStop = false;
            // 
            // numericBoxMoZhao
            // 
            resources.ApplyResources(this.numericBoxMoZhao, "numericBoxMoZhao");
            this.numericBoxMoZhao.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoZhao.DecimalPlaces = 3;
            this.numericBoxMoZhao.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoZhao.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoZhao.Name = "numericBoxMoZhao";
            this.numericBoxMoZhao.RoundErrorAccuracy = -1;
            this.numericBoxMoZhao.SkipEventDuringInput = false;
            this.numericBoxMoZhao.SmartIncrement = true;
            this.numericBoxMoZhao.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxMoZhao.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxMoZhao.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxMoZhao.ThonsandsSeparator = true;
            // 
            // numericBoxMoHuang
            // 
            resources.ApplyResources(this.numericBoxMoHuang, "numericBoxMoHuang");
            this.numericBoxMoHuang.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoHuang.DecimalPlaces = 3;
            this.numericBoxMoHuang.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoHuang.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoHuang.Name = "numericBoxMoHuang";
            this.numericBoxMoHuang.RoundErrorAccuracy = -1;
            this.numericBoxMoHuang.SkipEventDuringInput = false;
            this.numericBoxMoHuang.SmartIncrement = true;
            this.numericBoxMoHuang.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxMoHuang.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxMoHuang.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxMoHuang.ThonsandsSeparator = true;
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // numericBoxMoV
            // 
            resources.ApplyResources(this.numericBoxMoV, "numericBoxMoV");
            this.numericBoxMoV.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoV.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoV.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoV.Name = "numericBoxMoV";
            this.numericBoxMoV.RadianValue = 0.54349552907103427D;
            this.numericBoxMoV.RoundErrorAccuracy = -1;
            this.numericBoxMoV.SkipEventDuringInput = false;
            this.numericBoxMoV.SmartIncrement = true;
            this.numericBoxMoV.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxMoV.ThonsandsSeparator = true;
            this.numericBoxMoV.Value = 31.14D;
            this.numericBoxMoV.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // numericBoxMoV0
            // 
            resources.ApplyResources(this.numericBoxMoV0, "numericBoxMoV0");
            this.numericBoxMoV0.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoV0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoV0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMoV0.Name = "numericBoxMoV0";
            this.numericBoxMoV0.RadianValue = 0.54349552907103427D;
            this.numericBoxMoV0.RoundErrorAccuracy = -1;
            this.numericBoxMoV0.SkipEventDuringInput = false;
            this.numericBoxMoV0.SmartIncrement = true;
            this.numericBoxMoV0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxMoV0.ThonsandsSeparator = true;
            this.numericBoxMoV0.Value = 31.14D;
            this.numericBoxMoV0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // groupBoxPb
            // 
            this.groupBoxPb.Controls.Add(this.numericBoxPbStrassle);
            this.groupBoxPb.Controls.Add(this.numericBoxPbA);
            this.groupBoxPb.Controls.Add(this.label32);
            this.groupBoxPb.Controls.Add(this.numericBoxPbA0);
            resources.ApplyResources(this.groupBoxPb, "groupBoxPb");
            this.groupBoxPb.Name = "groupBoxPb";
            this.groupBoxPb.TabStop = false;
            // 
            // numericBoxPbStrassle
            // 
            resources.ApplyResources(this.numericBoxPbStrassle, "numericBoxPbStrassle");
            this.numericBoxPbStrassle.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPbStrassle.DecimalPlaces = 3;
            this.numericBoxPbStrassle.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPbStrassle.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPbStrassle.Name = "numericBoxPbStrassle";
            this.numericBoxPbStrassle.RoundErrorAccuracy = -1;
            this.numericBoxPbStrassle.SkipEventDuringInput = false;
            this.numericBoxPbStrassle.SmartIncrement = true;
            this.numericBoxPbStrassle.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxPbStrassle.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxPbStrassle.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numericBoxPbStrassle.ThonsandsSeparator = true;
            // 
            // numericBoxPbA
            // 
            resources.ApplyResources(this.numericBoxPbA, "numericBoxPbA");
            this.numericBoxPbA.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPbA.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPbA.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPbA.Name = "numericBoxPbA";
            this.numericBoxPbA.RadianValue = 0.086404095416306087D;
            this.numericBoxPbA.RoundErrorAccuracy = -1;
            this.numericBoxPbA.SkipEventDuringInput = false;
            this.numericBoxPbA.SmartIncrement = true;
            this.numericBoxPbA.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxPbA.ThonsandsSeparator = true;
            this.numericBoxPbA.Value = 4.95059D;
            this.numericBoxPbA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // numericBoxPbA0
            // 
            resources.ApplyResources(this.numericBoxPbA0, "numericBoxPbA0");
            this.numericBoxPbA0.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPbA0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPbA0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPbA0.Name = "numericBoxPbA0";
            this.numericBoxPbA0.RadianValue = 0.086404095416306087D;
            this.numericBoxPbA0.RoundErrorAccuracy = -1;
            this.numericBoxPbA0.SkipEventDuringInput = false;
            this.numericBoxPbA0.SmartIncrement = true;
            this.numericBoxPbA0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxPbA0.ThonsandsSeparator = true;
            this.numericBoxPbA0.Value = 4.95059D;
            this.numericBoxPbA0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // checkBoxPlatinum
            // 
            resources.ApplyResources(this.checkBoxPlatinum, "checkBoxPlatinum");
            this.checkBoxPlatinum.Checked = true;
            this.checkBoxPlatinum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPlatinum.Name = "checkBoxPlatinum";
            this.checkBoxPlatinum.UseVisualStyleBackColor = true;
            this.checkBoxPlatinum.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // checkBoxGold
            // 
            resources.ApplyResources(this.checkBoxGold, "checkBoxGold");
            this.checkBoxGold.Checked = true;
            this.checkBoxGold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGold.Name = "checkBoxGold";
            this.checkBoxGold.UseVisualStyleBackColor = true;
            this.checkBoxGold.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // checkBoxNaClB1
            // 
            resources.ApplyResources(this.checkBoxNaClB1, "checkBoxNaClB1");
            this.checkBoxNaClB1.Checked = true;
            this.checkBoxNaClB1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNaClB1.Name = "checkBoxNaClB1";
            this.checkBoxNaClB1.UseVisualStyleBackColor = true;
            this.checkBoxNaClB1.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // checkBoxNaClB2
            // 
            resources.ApplyResources(this.checkBoxNaClB2, "checkBoxNaClB2");
            this.checkBoxNaClB2.Checked = true;
            this.checkBoxNaClB2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNaClB2.Name = "checkBoxNaClB2";
            this.checkBoxNaClB2.UseVisualStyleBackColor = true;
            this.checkBoxNaClB2.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // checkBoxPericlase
            // 
            resources.ApplyResources(this.checkBoxPericlase, "checkBoxPericlase");
            this.checkBoxPericlase.Checked = true;
            this.checkBoxPericlase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPericlase.Name = "checkBoxPericlase";
            this.checkBoxPericlase.UseVisualStyleBackColor = true;
            this.checkBoxPericlase.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // checkBoxCorundum
            // 
            resources.ApplyResources(this.checkBoxCorundum, "checkBoxCorundum");
            this.checkBoxCorundum.Checked = true;
            this.checkBoxCorundum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCorundum.Name = "checkBoxCorundum";
            this.checkBoxCorundum.UseVisualStyleBackColor = true;
            this.checkBoxCorundum.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.checkBoxGold);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxPlatinum);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxNaClB1);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxNaClB2);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxPericlase);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxCorundum);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxAr);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxRe);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxMo);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxPb);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // checkBoxAr
            // 
            this.checkBoxAr.Checked = true;
            this.checkBoxAr.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.checkBoxAr, "checkBoxAr");
            this.checkBoxAr.Name = "checkBoxAr";
            this.checkBoxAr.UseVisualStyleBackColor = true;
            this.checkBoxAr.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // checkBoxRe
            // 
            resources.ApplyResources(this.checkBoxRe, "checkBoxRe");
            this.checkBoxRe.Checked = true;
            this.checkBoxRe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRe.Name = "checkBoxRe";
            this.checkBoxRe.UseVisualStyleBackColor = true;
            this.checkBoxRe.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // checkBoxMo
            // 
            resources.ApplyResources(this.checkBoxMo, "checkBoxMo");
            this.checkBoxMo.Checked = true;
            this.checkBoxMo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMo.Name = "checkBoxMo";
            this.checkBoxMo.UseVisualStyleBackColor = true;
            this.checkBoxMo.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // checkBoxPb
            // 
            resources.ApplyResources(this.checkBoxPb, "checkBoxPb");
            this.checkBoxPb.Checked = true;
            this.checkBoxPb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPb.Name = "checkBoxPb";
            this.checkBoxPb.UseVisualStyleBackColor = true;
            this.checkBoxPb.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // checkBoxHBN
            // 
            resources.ApplyResources(this.checkBoxHBN, "checkBoxHBN");
            this.checkBoxHBN.Checked = true;
            this.checkBoxHBN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHBN.Name = "checkBoxHBN";
            this.checkBoxHBN.UseVisualStyleBackColor = true;
            this.checkBoxHBN.CheckedChanged += new System.EventHandler(this.checkBoxGold_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // numericalTextBoxTemperature
            // 
            resources.ApplyResources(this.numericalTextBoxTemperature, "numericalTextBoxTemperature");
            this.numericalTextBoxTemperature.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxTemperature.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxTemperature.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxTemperature.Name = "numericalTextBoxTemperature";
            this.numericalTextBoxTemperature.RadianValue = 5.2359877559829888D;
            this.numericalTextBoxTemperature.RoundErrorAccuracy = -1;
            this.numericalTextBoxTemperature.SkipEventDuringInput = false;
            this.numericalTextBoxTemperature.SmartIncrement = true;
            this.numericalTextBoxTemperature.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxTemperature.ThonsandsSeparator = true;
            this.numericalTextBoxTemperature.Value = 300D;
            this.numericalTextBoxTemperature.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // FormEOS
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.numericalTextBoxTemperature);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.numericalTextBoxPtT0);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormEOS";
            this.Closed += new System.EventHandler(this.FormEOS_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEOS_FormClosing);
            this.Load += new System.EventHandler(this.FormEOS_Load);
            this.VisibleChanged += new System.EventHandler(this.FormEOS_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEOS_KeyDown);
            this.groupBoxPlatinum.ResumeLayout(false);
            this.groupBoxPlatinum.PerformLayout();
            this.groupBoxNaClB1.ResumeLayout(false);
            this.groupBoxNaClB1.PerformLayout();
            this.groupBoxGold.ResumeLayout(false);
            this.groupBoxGold.PerformLayout();
            this.groupBoxPericlase.ResumeLayout(false);
            this.groupBoxPericlase.PerformLayout();
            this.groupBoxNaClB2.ResumeLayout(false);
            this.groupBoxNaClB2.PerformLayout();
            this.groupBoxCorundum.ResumeLayout(false);
            this.groupBoxCorundum.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBoxAr.ResumeLayout(false);
            this.groupBoxAr.PerformLayout();
            this.groupBoxRe.ResumeLayout(false);
            this.groupBoxRe.PerformLayout();
            this.groupBoxMo.ResumeLayout(false);
            this.groupBoxMo.PerformLayout();
            this.groupBoxPb.ResumeLayout(false);
            this.groupBoxPb.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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
        private Crystallography.Controls.NumericBox numericalTextBoxGoldA0;
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
        private Crystallography.Controls.NumericBox numericalTextBoxPtT0;
        public Crystallography.Controls.NumericBox numericalTextBoxPtA;
        private Crystallography.Controls.NumericBox numericalTextBoxPtA0;
        private Crystallography.Controls.NumericBox numericalTextBoxTemperature;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB1Matsui;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB1Brown;
        private Label label4;
        private Label label3;
        public Crystallography.Controls.NumericBox numericalTextBoxNaClB1A;
        private Crystallography.Controls.NumericBox numericalTextBoxNaClB1A0;
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
        private Crystallography.Controls.NumericBox numericalTextBoxMgOA0;
        private Crystallography.Controls.NumericBox numericalTextBoxCorundumDubrovinsky;
        public Crystallography.Controls.NumericBox numericalTextBoxColundumV;
        private Label label5;
        private Crystallography.Controls.NumericBox numericalTextBoxColundumV0;
        private Crystallography.Controls.NumericBox numericalTextBoxArRoss;
        private Crystallography.Controls.NumericBox numericalTextBoxArJephcoat;
        public Crystallography.Controls.NumericBox numericalTextBoxArA;
        private Label label17;
        private Label label14;
        private Crystallography.Controls.NumericBox numericalTextBoxArA0;
        private Crystallography.Controls.NumericBox numericalTextBoxReZha;
        public Crystallography.Controls.NumericBox numericBoxReV;
        private Label label18;
        private Crystallography.Controls.NumericBox numerictBoxReV0;
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
        private Crystallography.Controls.NumericBox numericBoxMoV0;
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
        private Crystallography.Controls.NumericBox numericBoxPbA0;
        public CheckBox checkBoxPb;
    }


}