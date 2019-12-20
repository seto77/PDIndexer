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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxNaClB1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxGold = new System.Windows.Forms.GroupBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBoxPericlase = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxNaClB2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxCorundum = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxAr = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBoxRe = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.checkBoxPlatinum = new System.Windows.Forms.CheckBox();
            this.checkBoxGold = new System.Windows.Forms.CheckBox();
            this.checkBoxNaClB1 = new System.Windows.Forms.CheckBox();
            this.checkBoxNaClB2 = new System.Windows.Forms.CheckBox();
            this.checkBoxPericlase = new System.Windows.Forms.CheckBox();
            this.checkBoxCorundum = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxAr = new System.Windows.Forms.CheckBox();
            this.checkBoxRe = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.numericalTextBoxTemperature = new Crystallography.Controls.NumericBox();
            this.numericBoxAuYokoo = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldJamieson = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldTsuchiya = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldSim = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldAnderson = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldA = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxGoldA0 = new Crystallography.Controls.NumericBox();
            this.numericBoxPtYokoo = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPtMatsui = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPtHolmes = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPtJamieson = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPtT0 = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPtA = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPtA0 = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB1Matsui = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB1Brown = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB1A = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB1A0 = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB2SakaiVinet = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB2SakaiBM = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB2Ueda = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB2SataMgO = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB2SataPt = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB2A = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxNaClB2A0 = new Crystallography.Controls.NumericBox();
            this.numericBoxMgOTangeBM = new Crystallography.Controls.NumericBox();
            this.numericBoxMgOTangeVinet = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxMgOAizawa = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxMgODewaele = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxMgOJacson = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxMgOA = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxMgOA0 = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxCorundumDubrovinsky = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxColundumV = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxColundumV0 = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxArRoss = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxArJephcoat = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxArA = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxArA0 = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxReZha = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxReV = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxReV0 = new Crystallography.Controls.NumericBox();
            this.groupBoxPlatinum.SuspendLayout();
            this.groupBoxNaClB1.SuspendLayout();
            this.groupBoxGold.SuspendLayout();
            this.groupBoxPericlase.SuspendLayout();
            this.groupBoxNaClB2.SuspendLayout();
            this.groupBoxCorundum.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxAr.SuspendLayout();
            this.groupBoxRe.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPlatinum
            // 
            this.groupBoxPlatinum.Controls.Add(this.numericBoxPtYokoo);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtMatsui);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtHolmes);
            this.groupBoxPlatinum.Controls.Add(this.label20);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtJamieson);
            this.groupBoxPlatinum.Controls.Add(this.label9);
            this.groupBoxPlatinum.Controls.Add(this.label8);
            this.groupBoxPlatinum.Controls.Add(this.label1);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtT0);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtA);
            this.groupBoxPlatinum.Controls.Add(this.numericalTextBoxPtA0);
            resources.ApplyResources(this.groupBoxPlatinum, "groupBoxPlatinum");
            this.groupBoxPlatinum.Name = "groupBoxPlatinum";
            this.groupBoxPlatinum.TabStop = false;
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
            // groupBoxGold
            // 
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
            resources.ApplyResources(this.groupBoxGold, "groupBoxGold");
            this.groupBoxGold.Name = "groupBoxGold";
            this.groupBoxGold.TabStop = false;
            // 
            // label49
            // 
            resources.ApplyResources(this.label49, "label49");
            this.label49.Name = "label49";
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
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
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
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
            // groupBoxRe
            // 
            this.groupBoxRe.Controls.Add(this.numericalTextBoxReZha);
            this.groupBoxRe.Controls.Add(this.numericalTextBoxReV);
            this.groupBoxRe.Controls.Add(this.label18);
            this.groupBoxRe.Controls.Add(this.numericalTextBoxReV0);
            resources.ApplyResources(this.groupBoxRe, "groupBoxRe");
            this.groupBoxRe.Name = "groupBoxRe";
            this.groupBoxRe.TabStop = false;
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
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
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxGold);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxPlatinum);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxNaClB1);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxNaClB2);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxPericlase);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxCorundum);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxAr);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxRe);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // checkBoxAr
            // 
            resources.ApplyResources(this.checkBoxAr, "checkBoxAr");
            this.checkBoxAr.Checked = true;
            this.checkBoxAr.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // numericalTextBoxTemperature
            // 
            resources.ApplyResources(this.numericalTextBoxTemperature, "numericalTextBoxTemperature");
            this.numericalTextBoxTemperature.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxTemperature.DecimalPlaces = -1;
            this.numericalTextBoxTemperature.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxTemperature.FooterText = "K";
            this.numericalTextBoxTemperature.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxTemperature.HeaderText = "Temperature";
            this.numericalTextBoxTemperature.Maximum = double.PositiveInfinity;
            this.numericalTextBoxTemperature.Minimum = double.NegativeInfinity;
            this.numericalTextBoxTemperature.Multiline = false;
            this.numericalTextBoxTemperature.Name = "numericalTextBoxTemperature";
            this.numericalTextBoxTemperature.RadianValue = 5.2359877559829888D;
            this.numericalTextBoxTemperature.ReadOnly = false;
            this.numericalTextBoxTemperature.RestrictLimitValue = true;
            this.numericalTextBoxTemperature.ShowFraction = false;
            this.numericalTextBoxTemperature.ShowPositiveSign = false;
            this.numericalTextBoxTemperature.ShowUpDown = false;
            this.numericalTextBoxTemperature.SkipEventDuringInput = false;
            this.numericalTextBoxTemperature.SmartIncrement = true;
            this.numericalTextBoxTemperature.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxTemperature.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxTemperature.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxTemperature.ThonsandsSeparator = true;
            this.numericalTextBoxTemperature.ToolTip = "";
            this.numericalTextBoxTemperature.UpDown_Increment = 1D;
            this.numericalTextBoxTemperature.Value = 300D;
            this.numericalTextBoxTemperature.WordWrap = true;
            this.numericalTextBoxTemperature.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericBoxAuYokoo
            // 
            resources.ApplyResources(this.numericBoxAuYokoo, "numericBoxAuYokoo");
            this.numericBoxAuYokoo.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAuYokoo.DecimalPlaces = 3;
            this.numericBoxAuYokoo.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxAuYokoo.FooterText = "GPa";
            this.numericBoxAuYokoo.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxAuYokoo.HeaderText = "";
            this.numericBoxAuYokoo.Maximum = double.PositiveInfinity;
            this.numericBoxAuYokoo.Minimum = double.NegativeInfinity;
            this.numericBoxAuYokoo.Multiline = false;
            this.numericBoxAuYokoo.Name = "numericBoxAuYokoo";
            this.numericBoxAuYokoo.RadianValue = 0D;
            this.numericBoxAuYokoo.ReadOnly = false;
            this.numericBoxAuYokoo.RestrictLimitValue = true;
            this.numericBoxAuYokoo.ShowFraction = false;
            this.numericBoxAuYokoo.ShowPositiveSign = false;
            this.numericBoxAuYokoo.ShowUpDown = false;
            this.numericBoxAuYokoo.SkipEventDuringInput = false;
            this.numericBoxAuYokoo.SmartIncrement = true;
            this.numericBoxAuYokoo.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxAuYokoo.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxAuYokoo.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericBoxAuYokoo.ThonsandsSeparator = true;
            this.numericBoxAuYokoo.ToolTip = "";
            this.numericBoxAuYokoo.UpDown_Increment = 1D;
            this.numericBoxAuYokoo.Value = 0D;
            this.numericBoxAuYokoo.WordWrap = true;
            // 
            // numericalTextBoxGoldJamieson
            // 
            resources.ApplyResources(this.numericalTextBoxGoldJamieson, "numericalTextBoxGoldJamieson");
            this.numericalTextBoxGoldJamieson.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldJamieson.DecimalPlaces = 3;
            this.numericalTextBoxGoldJamieson.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxGoldJamieson.FooterText = "GPa";
            this.numericalTextBoxGoldJamieson.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxGoldJamieson.HeaderText = "";
            this.numericalTextBoxGoldJamieson.Maximum = double.PositiveInfinity;
            this.numericalTextBoxGoldJamieson.Minimum = double.NegativeInfinity;
            this.numericalTextBoxGoldJamieson.Multiline = false;
            this.numericalTextBoxGoldJamieson.Name = "numericalTextBoxGoldJamieson";
            this.numericalTextBoxGoldJamieson.RadianValue = 0D;
            this.numericalTextBoxGoldJamieson.ReadOnly = false;
            this.numericalTextBoxGoldJamieson.RestrictLimitValue = true;
            this.numericalTextBoxGoldJamieson.ShowFraction = false;
            this.numericalTextBoxGoldJamieson.ShowPositiveSign = false;
            this.numericalTextBoxGoldJamieson.ShowUpDown = false;
            this.numericalTextBoxGoldJamieson.SkipEventDuringInput = false;
            this.numericalTextBoxGoldJamieson.SmartIncrement = true;
            this.numericalTextBoxGoldJamieson.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxGoldJamieson.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxGoldJamieson.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxGoldJamieson.ThonsandsSeparator = true;
            this.numericalTextBoxGoldJamieson.ToolTip = "";
            this.numericalTextBoxGoldJamieson.UpDown_Increment = 1D;
            this.numericalTextBoxGoldJamieson.Value = 0D;
            this.numericalTextBoxGoldJamieson.WordWrap = true;
            // 
            // numericalTextBoxGoldTsuchiya
            // 
            resources.ApplyResources(this.numericalTextBoxGoldTsuchiya, "numericalTextBoxGoldTsuchiya");
            this.numericalTextBoxGoldTsuchiya.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldTsuchiya.DecimalPlaces = 3;
            this.numericalTextBoxGoldTsuchiya.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxGoldTsuchiya.FooterText = "GPa";
            this.numericalTextBoxGoldTsuchiya.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxGoldTsuchiya.HeaderText = "";
            this.numericalTextBoxGoldTsuchiya.Maximum = double.PositiveInfinity;
            this.numericalTextBoxGoldTsuchiya.Minimum = double.NegativeInfinity;
            this.numericalTextBoxGoldTsuchiya.Multiline = false;
            this.numericalTextBoxGoldTsuchiya.Name = "numericalTextBoxGoldTsuchiya";
            this.numericalTextBoxGoldTsuchiya.RadianValue = 0D;
            this.numericalTextBoxGoldTsuchiya.ReadOnly = false;
            this.numericalTextBoxGoldTsuchiya.RestrictLimitValue = true;
            this.numericalTextBoxGoldTsuchiya.ShowFraction = false;
            this.numericalTextBoxGoldTsuchiya.ShowPositiveSign = false;
            this.numericalTextBoxGoldTsuchiya.ShowUpDown = false;
            this.numericalTextBoxGoldTsuchiya.SkipEventDuringInput = false;
            this.numericalTextBoxGoldTsuchiya.SmartIncrement = true;
            this.numericalTextBoxGoldTsuchiya.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxGoldTsuchiya.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxGoldTsuchiya.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxGoldTsuchiya.ThonsandsSeparator = true;
            this.numericalTextBoxGoldTsuchiya.ToolTip = "";
            this.numericalTextBoxGoldTsuchiya.UpDown_Increment = 1D;
            this.numericalTextBoxGoldTsuchiya.Value = 0D;
            this.numericalTextBoxGoldTsuchiya.WordWrap = true;
            // 
            // numericalTextBoxGoldSim
            // 
            resources.ApplyResources(this.numericalTextBoxGoldSim, "numericalTextBoxGoldSim");
            this.numericalTextBoxGoldSim.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldSim.DecimalPlaces = 3;
            this.numericalTextBoxGoldSim.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxGoldSim.FooterText = "GPa";
            this.numericalTextBoxGoldSim.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxGoldSim.HeaderText = "";
            this.numericalTextBoxGoldSim.Maximum = double.PositiveInfinity;
            this.numericalTextBoxGoldSim.Minimum = double.NegativeInfinity;
            this.numericalTextBoxGoldSim.Multiline = false;
            this.numericalTextBoxGoldSim.Name = "numericalTextBoxGoldSim";
            this.numericalTextBoxGoldSim.RadianValue = 0D;
            this.numericalTextBoxGoldSim.ReadOnly = false;
            this.numericalTextBoxGoldSim.RestrictLimitValue = true;
            this.numericalTextBoxGoldSim.ShowFraction = false;
            this.numericalTextBoxGoldSim.ShowPositiveSign = false;
            this.numericalTextBoxGoldSim.ShowUpDown = false;
            this.numericalTextBoxGoldSim.SkipEventDuringInput = false;
            this.numericalTextBoxGoldSim.SmartIncrement = true;
            this.numericalTextBoxGoldSim.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxGoldSim.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxGoldSim.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxGoldSim.ThonsandsSeparator = true;
            this.numericalTextBoxGoldSim.ToolTip = "";
            this.numericalTextBoxGoldSim.UpDown_Increment = 1D;
            this.numericalTextBoxGoldSim.Value = 0D;
            this.numericalTextBoxGoldSim.WordWrap = true;
            // 
            // numericalTextBoxGoldAnderson
            // 
            resources.ApplyResources(this.numericalTextBoxGoldAnderson, "numericalTextBoxGoldAnderson");
            this.numericalTextBoxGoldAnderson.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldAnderson.DecimalPlaces = 3;
            this.numericalTextBoxGoldAnderson.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxGoldAnderson.FooterText = "GPa";
            this.numericalTextBoxGoldAnderson.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxGoldAnderson.HeaderText = "";
            this.numericalTextBoxGoldAnderson.Maximum = double.PositiveInfinity;
            this.numericalTextBoxGoldAnderson.Minimum = double.NegativeInfinity;
            this.numericalTextBoxGoldAnderson.Multiline = false;
            this.numericalTextBoxGoldAnderson.Name = "numericalTextBoxGoldAnderson";
            this.numericalTextBoxGoldAnderson.RadianValue = 0D;
            this.numericalTextBoxGoldAnderson.ReadOnly = false;
            this.numericalTextBoxGoldAnderson.RestrictLimitValue = true;
            this.numericalTextBoxGoldAnderson.ShowFraction = false;
            this.numericalTextBoxGoldAnderson.ShowPositiveSign = false;
            this.numericalTextBoxGoldAnderson.ShowUpDown = false;
            this.numericalTextBoxGoldAnderson.SkipEventDuringInput = false;
            this.numericalTextBoxGoldAnderson.SmartIncrement = true;
            this.numericalTextBoxGoldAnderson.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxGoldAnderson.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxGoldAnderson.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxGoldAnderson.ThonsandsSeparator = true;
            this.numericalTextBoxGoldAnderson.ToolTip = "";
            this.numericalTextBoxGoldAnderson.UpDown_Increment = 1D;
            this.numericalTextBoxGoldAnderson.Value = 0D;
            this.numericalTextBoxGoldAnderson.WordWrap = true;
            // 
            // numericalTextBoxGoldA
            // 
            resources.ApplyResources(this.numericalTextBoxGoldA, "numericalTextBoxGoldA");
            this.numericalTextBoxGoldA.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldA.DecimalPlaces = -1;
            this.numericalTextBoxGoldA.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxGoldA.FooterText = "Å";
            this.numericalTextBoxGoldA.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxGoldA.HeaderText = "a ";
            this.numericalTextBoxGoldA.Maximum = double.PositiveInfinity;
            this.numericalTextBoxGoldA.Minimum = double.NegativeInfinity;
            this.numericalTextBoxGoldA.Multiline = false;
            this.numericalTextBoxGoldA.Name = "numericalTextBoxGoldA";
            this.numericalTextBoxGoldA.RadianValue = 0.071178890219458738D;
            this.numericalTextBoxGoldA.ReadOnly = false;
            this.numericalTextBoxGoldA.RestrictLimitValue = true;
            this.numericalTextBoxGoldA.ShowFraction = false;
            this.numericalTextBoxGoldA.ShowPositiveSign = false;
            this.numericalTextBoxGoldA.ShowUpDown = false;
            this.numericalTextBoxGoldA.SkipEventDuringInput = false;
            this.numericalTextBoxGoldA.SmartIncrement = true;
            this.numericalTextBoxGoldA.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxGoldA.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxGoldA.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxGoldA.ThonsandsSeparator = true;
            this.numericalTextBoxGoldA.ToolTip = "";
            this.numericalTextBoxGoldA.UpDown_Increment = 1D;
            this.numericalTextBoxGoldA.Value = 4.07825D;
            this.numericalTextBoxGoldA.WordWrap = true;
            this.numericalTextBoxGoldA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxGoldA0
            // 
            resources.ApplyResources(this.numericalTextBoxGoldA0, "numericalTextBoxGoldA0");
            this.numericalTextBoxGoldA0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxGoldA0.DecimalPlaces = -1;
            this.numericalTextBoxGoldA0.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxGoldA0.FooterText = "Å";
            this.numericalTextBoxGoldA0.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxGoldA0.HeaderText = "a0";
            this.numericalTextBoxGoldA0.Maximum = double.PositiveInfinity;
            this.numericalTextBoxGoldA0.Minimum = double.NegativeInfinity;
            this.numericalTextBoxGoldA0.Multiline = false;
            this.numericalTextBoxGoldA0.Name = "numericalTextBoxGoldA0";
            this.numericalTextBoxGoldA0.RadianValue = 0.071178890219458738D;
            this.numericalTextBoxGoldA0.ReadOnly = false;
            this.numericalTextBoxGoldA0.RestrictLimitValue = true;
            this.numericalTextBoxGoldA0.ShowFraction = false;
            this.numericalTextBoxGoldA0.ShowPositiveSign = false;
            this.numericalTextBoxGoldA0.ShowUpDown = false;
            this.numericalTextBoxGoldA0.SkipEventDuringInput = false;
            this.numericalTextBoxGoldA0.SmartIncrement = true;
            this.numericalTextBoxGoldA0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxGoldA0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxGoldA0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxGoldA0.ThonsandsSeparator = true;
            this.numericalTextBoxGoldA0.ToolTip = "";
            this.numericalTextBoxGoldA0.UpDown_Increment = 1D;
            this.numericalTextBoxGoldA0.Value = 4.07825D;
            this.numericalTextBoxGoldA0.WordWrap = true;
            this.numericalTextBoxGoldA0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            this.numericalTextBoxGoldA0.Load += new System.EventHandler(this.numericalTextBoxGoldA0_Load);
            // 
            // numericBoxPtYokoo
            // 
            resources.ApplyResources(this.numericBoxPtYokoo, "numericBoxPtYokoo");
            this.numericBoxPtYokoo.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPtYokoo.DecimalPlaces = 3;
            this.numericBoxPtYokoo.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxPtYokoo.FooterText = "GPa";
            this.numericBoxPtYokoo.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxPtYokoo.HeaderText = "";
            this.numericBoxPtYokoo.Maximum = double.PositiveInfinity;
            this.numericBoxPtYokoo.Minimum = double.NegativeInfinity;
            this.numericBoxPtYokoo.Multiline = false;
            this.numericBoxPtYokoo.Name = "numericBoxPtYokoo";
            this.numericBoxPtYokoo.RadianValue = 0D;
            this.numericBoxPtYokoo.ReadOnly = false;
            this.numericBoxPtYokoo.RestrictLimitValue = true;
            this.numericBoxPtYokoo.ShowFraction = false;
            this.numericBoxPtYokoo.ShowPositiveSign = false;
            this.numericBoxPtYokoo.ShowUpDown = false;
            this.numericBoxPtYokoo.SkipEventDuringInput = false;
            this.numericBoxPtYokoo.SmartIncrement = true;
            this.numericBoxPtYokoo.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxPtYokoo.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxPtYokoo.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericBoxPtYokoo.ThonsandsSeparator = true;
            this.numericBoxPtYokoo.ToolTip = "";
            this.numericBoxPtYokoo.UpDown_Increment = 1D;
            this.numericBoxPtYokoo.Value = 0D;
            this.numericBoxPtYokoo.WordWrap = true;
            // 
            // numericalTextBoxPtMatsui
            // 
            resources.ApplyResources(this.numericalTextBoxPtMatsui, "numericalTextBoxPtMatsui");
            this.numericalTextBoxPtMatsui.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtMatsui.DecimalPlaces = 3;
            this.numericalTextBoxPtMatsui.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxPtMatsui.FooterText = "GPa";
            this.numericalTextBoxPtMatsui.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxPtMatsui.HeaderText = "";
            this.numericalTextBoxPtMatsui.Maximum = double.PositiveInfinity;
            this.numericalTextBoxPtMatsui.Minimum = double.NegativeInfinity;
            this.numericalTextBoxPtMatsui.Multiline = false;
            this.numericalTextBoxPtMatsui.Name = "numericalTextBoxPtMatsui";
            this.numericalTextBoxPtMatsui.RadianValue = 0D;
            this.numericalTextBoxPtMatsui.ReadOnly = false;
            this.numericalTextBoxPtMatsui.RestrictLimitValue = true;
            this.numericalTextBoxPtMatsui.ShowFraction = false;
            this.numericalTextBoxPtMatsui.ShowPositiveSign = false;
            this.numericalTextBoxPtMatsui.ShowUpDown = false;
            this.numericalTextBoxPtMatsui.SkipEventDuringInput = false;
            this.numericalTextBoxPtMatsui.SmartIncrement = true;
            this.numericalTextBoxPtMatsui.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxPtMatsui.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxPtMatsui.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxPtMatsui.ThonsandsSeparator = true;
            this.numericalTextBoxPtMatsui.ToolTip = "";
            this.numericalTextBoxPtMatsui.UpDown_Increment = 1D;
            this.numericalTextBoxPtMatsui.Value = 0D;
            this.numericalTextBoxPtMatsui.WordWrap = true;
            // 
            // numericalTextBoxPtHolmes
            // 
            resources.ApplyResources(this.numericalTextBoxPtHolmes, "numericalTextBoxPtHolmes");
            this.numericalTextBoxPtHolmes.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtHolmes.DecimalPlaces = 3;
            this.numericalTextBoxPtHolmes.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxPtHolmes.FooterText = "GPa";
            this.numericalTextBoxPtHolmes.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxPtHolmes.HeaderText = "";
            this.numericalTextBoxPtHolmes.Maximum = double.PositiveInfinity;
            this.numericalTextBoxPtHolmes.Minimum = double.NegativeInfinity;
            this.numericalTextBoxPtHolmes.Multiline = false;
            this.numericalTextBoxPtHolmes.Name = "numericalTextBoxPtHolmes";
            this.numericalTextBoxPtHolmes.RadianValue = 0D;
            this.numericalTextBoxPtHolmes.ReadOnly = false;
            this.numericalTextBoxPtHolmes.RestrictLimitValue = true;
            this.numericalTextBoxPtHolmes.ShowFraction = false;
            this.numericalTextBoxPtHolmes.ShowPositiveSign = false;
            this.numericalTextBoxPtHolmes.ShowUpDown = false;
            this.numericalTextBoxPtHolmes.SkipEventDuringInput = false;
            this.numericalTextBoxPtHolmes.SmartIncrement = true;
            this.numericalTextBoxPtHolmes.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxPtHolmes.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxPtHolmes.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxPtHolmes.ThonsandsSeparator = true;
            this.numericalTextBoxPtHolmes.ToolTip = "";
            this.numericalTextBoxPtHolmes.UpDown_Increment = 1D;
            this.numericalTextBoxPtHolmes.Value = 0D;
            this.numericalTextBoxPtHolmes.WordWrap = true;
            // 
            // numericalTextBoxPtJamieson
            // 
            resources.ApplyResources(this.numericalTextBoxPtJamieson, "numericalTextBoxPtJamieson");
            this.numericalTextBoxPtJamieson.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtJamieson.DecimalPlaces = 3;
            this.numericalTextBoxPtJamieson.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxPtJamieson.FooterText = "GPa";
            this.numericalTextBoxPtJamieson.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxPtJamieson.HeaderText = "";
            this.numericalTextBoxPtJamieson.Maximum = double.PositiveInfinity;
            this.numericalTextBoxPtJamieson.Minimum = double.NegativeInfinity;
            this.numericalTextBoxPtJamieson.Multiline = false;
            this.numericalTextBoxPtJamieson.Name = "numericalTextBoxPtJamieson";
            this.numericalTextBoxPtJamieson.RadianValue = 0D;
            this.numericalTextBoxPtJamieson.ReadOnly = false;
            this.numericalTextBoxPtJamieson.RestrictLimitValue = true;
            this.numericalTextBoxPtJamieson.ShowFraction = false;
            this.numericalTextBoxPtJamieson.ShowPositiveSign = false;
            this.numericalTextBoxPtJamieson.ShowUpDown = false;
            this.numericalTextBoxPtJamieson.SkipEventDuringInput = false;
            this.numericalTextBoxPtJamieson.SmartIncrement = true;
            this.numericalTextBoxPtJamieson.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxPtJamieson.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxPtJamieson.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxPtJamieson.ThonsandsSeparator = true;
            this.numericalTextBoxPtJamieson.ToolTip = "";
            this.numericalTextBoxPtJamieson.UpDown_Increment = 1D;
            this.numericalTextBoxPtJamieson.Value = 0D;
            this.numericalTextBoxPtJamieson.WordWrap = true;
            // 
            // numericalTextBoxPtT0
            // 
            resources.ApplyResources(this.numericalTextBoxPtT0, "numericalTextBoxPtT0");
            this.numericalTextBoxPtT0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtT0.DecimalPlaces = -1;
            this.numericalTextBoxPtT0.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPtT0.FooterText = "K";
            this.numericalTextBoxPtT0.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPtT0.HeaderText = "T0";
            this.numericalTextBoxPtT0.Maximum = double.PositiveInfinity;
            this.numericalTextBoxPtT0.Minimum = double.NegativeInfinity;
            this.numericalTextBoxPtT0.Multiline = false;
            this.numericalTextBoxPtT0.Name = "numericalTextBoxPtT0";
            this.numericalTextBoxPtT0.RadianValue = 5.2359877559829888D;
            this.numericalTextBoxPtT0.ReadOnly = false;
            this.numericalTextBoxPtT0.RestrictLimitValue = true;
            this.numericalTextBoxPtT0.ShowFraction = false;
            this.numericalTextBoxPtT0.ShowPositiveSign = false;
            this.numericalTextBoxPtT0.ShowUpDown = false;
            this.numericalTextBoxPtT0.SkipEventDuringInput = false;
            this.numericalTextBoxPtT0.SmartIncrement = true;
            this.numericalTextBoxPtT0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxPtT0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxPtT0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPtT0.ThonsandsSeparator = true;
            this.numericalTextBoxPtT0.ToolTip = "";
            this.numericalTextBoxPtT0.UpDown_Increment = 1D;
            this.numericalTextBoxPtT0.Value = 300D;
            this.numericalTextBoxPtT0.WordWrap = true;
            this.numericalTextBoxPtT0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxPtA
            // 
            resources.ApplyResources(this.numericalTextBoxPtA, "numericalTextBoxPtA");
            this.numericalTextBoxPtA.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtA.DecimalPlaces = -1;
            this.numericalTextBoxPtA.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPtA.FooterText = "Å";
            this.numericalTextBoxPtA.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPtA.HeaderText = "a";
            this.numericalTextBoxPtA.Maximum = double.PositiveInfinity;
            this.numericalTextBoxPtA.Minimum = double.NegativeInfinity;
            this.numericalTextBoxPtA.Multiline = false;
            this.numericalTextBoxPtA.Name = "numericalTextBoxPtA";
            this.numericalTextBoxPtA.RadianValue = 0.068471011884989538D;
            this.numericalTextBoxPtA.ReadOnly = false;
            this.numericalTextBoxPtA.RestrictLimitValue = true;
            this.numericalTextBoxPtA.ShowFraction = false;
            this.numericalTextBoxPtA.ShowPositiveSign = false;
            this.numericalTextBoxPtA.ShowUpDown = false;
            this.numericalTextBoxPtA.SkipEventDuringInput = false;
            this.numericalTextBoxPtA.SmartIncrement = true;
            this.numericalTextBoxPtA.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxPtA.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxPtA.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPtA.ThonsandsSeparator = true;
            this.numericalTextBoxPtA.ToolTip = "";
            this.numericalTextBoxPtA.UpDown_Increment = 1D;
            this.numericalTextBoxPtA.Value = 3.9231D;
            this.numericalTextBoxPtA.WordWrap = true;
            this.numericalTextBoxPtA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxPtA0
            // 
            resources.ApplyResources(this.numericalTextBoxPtA0, "numericalTextBoxPtA0");
            this.numericalTextBoxPtA0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPtA0.DecimalPlaces = -1;
            this.numericalTextBoxPtA0.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPtA0.FooterText = "Å";
            this.numericalTextBoxPtA0.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPtA0.HeaderText = "a0";
            this.numericalTextBoxPtA0.Maximum = double.PositiveInfinity;
            this.numericalTextBoxPtA0.Minimum = double.NegativeInfinity;
            this.numericalTextBoxPtA0.Multiline = false;
            this.numericalTextBoxPtA0.Name = "numericalTextBoxPtA0";
            this.numericalTextBoxPtA0.RadianValue = 0.068471011884989538D;
            this.numericalTextBoxPtA0.ReadOnly = false;
            this.numericalTextBoxPtA0.RestrictLimitValue = true;
            this.numericalTextBoxPtA0.ShowFraction = false;
            this.numericalTextBoxPtA0.ShowPositiveSign = false;
            this.numericalTextBoxPtA0.ShowUpDown = false;
            this.numericalTextBoxPtA0.SkipEventDuringInput = false;
            this.numericalTextBoxPtA0.SmartIncrement = true;
            this.numericalTextBoxPtA0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxPtA0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxPtA0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPtA0.ThonsandsSeparator = true;
            this.numericalTextBoxPtA0.ToolTip = "";
            this.numericalTextBoxPtA0.UpDown_Increment = 1D;
            this.numericalTextBoxPtA0.Value = 3.9231D;
            this.numericalTextBoxPtA0.WordWrap = true;
            this.numericalTextBoxPtA0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxNaClB1Matsui
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB1Matsui, "numericalTextBoxNaClB1Matsui");
            this.numericalTextBoxNaClB1Matsui.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1Matsui.DecimalPlaces = 3;
            this.numericalTextBoxNaClB1Matsui.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB1Matsui.FooterText = "GPa";
            this.numericalTextBoxNaClB1Matsui.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB1Matsui.HeaderText = "";
            this.numericalTextBoxNaClB1Matsui.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB1Matsui.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB1Matsui.Multiline = false;
            this.numericalTextBoxNaClB1Matsui.Name = "numericalTextBoxNaClB1Matsui";
            this.numericalTextBoxNaClB1Matsui.RadianValue = 0D;
            this.numericalTextBoxNaClB1Matsui.ReadOnly = false;
            this.numericalTextBoxNaClB1Matsui.RestrictLimitValue = true;
            this.numericalTextBoxNaClB1Matsui.ShowFraction = false;
            this.numericalTextBoxNaClB1Matsui.ShowPositiveSign = false;
            this.numericalTextBoxNaClB1Matsui.ShowUpDown = false;
            this.numericalTextBoxNaClB1Matsui.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB1Matsui.SmartIncrement = true;
            this.numericalTextBoxNaClB1Matsui.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB1Matsui.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB1Matsui.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxNaClB1Matsui.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB1Matsui.ToolTip = "";
            this.numericalTextBoxNaClB1Matsui.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB1Matsui.Value = 0D;
            this.numericalTextBoxNaClB1Matsui.WordWrap = true;
            // 
            // numericalTextBoxNaClB1Brown
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB1Brown, "numericalTextBoxNaClB1Brown");
            this.numericalTextBoxNaClB1Brown.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1Brown.DecimalPlaces = 3;
            this.numericalTextBoxNaClB1Brown.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB1Brown.FooterText = "GPa";
            this.numericalTextBoxNaClB1Brown.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB1Brown.HeaderText = "";
            this.numericalTextBoxNaClB1Brown.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB1Brown.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB1Brown.Multiline = false;
            this.numericalTextBoxNaClB1Brown.Name = "numericalTextBoxNaClB1Brown";
            this.numericalTextBoxNaClB1Brown.RadianValue = 0D;
            this.numericalTextBoxNaClB1Brown.ReadOnly = false;
            this.numericalTextBoxNaClB1Brown.RestrictLimitValue = true;
            this.numericalTextBoxNaClB1Brown.ShowFraction = false;
            this.numericalTextBoxNaClB1Brown.ShowPositiveSign = false;
            this.numericalTextBoxNaClB1Brown.ShowUpDown = false;
            this.numericalTextBoxNaClB1Brown.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB1Brown.SmartIncrement = true;
            this.numericalTextBoxNaClB1Brown.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB1Brown.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB1Brown.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxNaClB1Brown.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB1Brown.ToolTip = "";
            this.numericalTextBoxNaClB1Brown.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB1Brown.Value = 0D;
            this.numericalTextBoxNaClB1Brown.WordWrap = true;
            // 
            // numericalTextBoxNaClB1A
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB1A, "numericalTextBoxNaClB1A");
            this.numericalTextBoxNaClB1A.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1A.DecimalPlaces = -1;
            this.numericalTextBoxNaClB1A.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB1A.FooterText = "Å";
            this.numericalTextBoxNaClB1A.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB1A.HeaderText = "a";
            this.numericalTextBoxNaClB1A.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB1A.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB1A.Multiline = false;
            this.numericalTextBoxNaClB1A.Name = "numericalTextBoxNaClB1A";
            this.numericalTextBoxNaClB1A.RadianValue = 0.098419116519960256D;
            this.numericalTextBoxNaClB1A.ReadOnly = false;
            this.numericalTextBoxNaClB1A.RestrictLimitValue = true;
            this.numericalTextBoxNaClB1A.ShowFraction = false;
            this.numericalTextBoxNaClB1A.ShowPositiveSign = false;
            this.numericalTextBoxNaClB1A.ShowUpDown = false;
            this.numericalTextBoxNaClB1A.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB1A.SmartIncrement = true;
            this.numericalTextBoxNaClB1A.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxNaClB1A.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxNaClB1A.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB1A.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB1A.ToolTip = "";
            this.numericalTextBoxNaClB1A.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB1A.Value = 5.639D;
            this.numericalTextBoxNaClB1A.WordWrap = true;
            this.numericalTextBoxNaClB1A.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxNaClB1A0
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB1A0, "numericalTextBoxNaClB1A0");
            this.numericalTextBoxNaClB1A0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB1A0.DecimalPlaces = -1;
            this.numericalTextBoxNaClB1A0.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB1A0.FooterText = "Å";
            this.numericalTextBoxNaClB1A0.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB1A0.HeaderText = "a0";
            this.numericalTextBoxNaClB1A0.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB1A0.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB1A0.Multiline = false;
            this.numericalTextBoxNaClB1A0.Name = "numericalTextBoxNaClB1A0";
            this.numericalTextBoxNaClB1A0.RadianValue = 0.098419116519960256D;
            this.numericalTextBoxNaClB1A0.ReadOnly = false;
            this.numericalTextBoxNaClB1A0.RestrictLimitValue = true;
            this.numericalTextBoxNaClB1A0.ShowFraction = false;
            this.numericalTextBoxNaClB1A0.ShowPositiveSign = false;
            this.numericalTextBoxNaClB1A0.ShowUpDown = false;
            this.numericalTextBoxNaClB1A0.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB1A0.SmartIncrement = true;
            this.numericalTextBoxNaClB1A0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxNaClB1A0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxNaClB1A0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB1A0.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB1A0.ToolTip = "";
            this.numericalTextBoxNaClB1A0.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB1A0.Value = 5.639D;
            this.numericalTextBoxNaClB1A0.WordWrap = true;
            this.numericalTextBoxNaClB1A0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxNaClB2SakaiVinet
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2SakaiVinet, "numericalTextBoxNaClB2SakaiVinet");
            this.numericalTextBoxNaClB2SakaiVinet.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SakaiVinet.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2SakaiVinet.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2SakaiVinet.FooterText = "GPa";
            this.numericalTextBoxNaClB2SakaiVinet.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2SakaiVinet.HeaderText = "";
            this.numericalTextBoxNaClB2SakaiVinet.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB2SakaiVinet.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB2SakaiVinet.Multiline = false;
            this.numericalTextBoxNaClB2SakaiVinet.Name = "numericalTextBoxNaClB2SakaiVinet";
            this.numericalTextBoxNaClB2SakaiVinet.RadianValue = 0D;
            this.numericalTextBoxNaClB2SakaiVinet.ReadOnly = false;
            this.numericalTextBoxNaClB2SakaiVinet.RestrictLimitValue = true;
            this.numericalTextBoxNaClB2SakaiVinet.ShowFraction = false;
            this.numericalTextBoxNaClB2SakaiVinet.ShowPositiveSign = false;
            this.numericalTextBoxNaClB2SakaiVinet.ShowUpDown = false;
            this.numericalTextBoxNaClB2SakaiVinet.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2SakaiVinet.SmartIncrement = true;
            this.numericalTextBoxNaClB2SakaiVinet.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2SakaiVinet.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2SakaiVinet.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxNaClB2SakaiVinet.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB2SakaiVinet.ToolTip = "";
            this.numericalTextBoxNaClB2SakaiVinet.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB2SakaiVinet.Value = 0D;
            this.numericalTextBoxNaClB2SakaiVinet.WordWrap = true;
            // 
            // numericalTextBoxNaClB2SakaiBM
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2SakaiBM, "numericalTextBoxNaClB2SakaiBM");
            this.numericalTextBoxNaClB2SakaiBM.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SakaiBM.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2SakaiBM.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2SakaiBM.FooterText = "GPa";
            this.numericalTextBoxNaClB2SakaiBM.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2SakaiBM.HeaderText = "";
            this.numericalTextBoxNaClB2SakaiBM.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB2SakaiBM.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB2SakaiBM.Multiline = false;
            this.numericalTextBoxNaClB2SakaiBM.Name = "numericalTextBoxNaClB2SakaiBM";
            this.numericalTextBoxNaClB2SakaiBM.RadianValue = 0D;
            this.numericalTextBoxNaClB2SakaiBM.ReadOnly = false;
            this.numericalTextBoxNaClB2SakaiBM.RestrictLimitValue = true;
            this.numericalTextBoxNaClB2SakaiBM.ShowFraction = false;
            this.numericalTextBoxNaClB2SakaiBM.ShowPositiveSign = false;
            this.numericalTextBoxNaClB2SakaiBM.ShowUpDown = false;
            this.numericalTextBoxNaClB2SakaiBM.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2SakaiBM.SmartIncrement = true;
            this.numericalTextBoxNaClB2SakaiBM.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2SakaiBM.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2SakaiBM.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxNaClB2SakaiBM.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB2SakaiBM.ToolTip = "";
            this.numericalTextBoxNaClB2SakaiBM.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB2SakaiBM.Value = 0D;
            this.numericalTextBoxNaClB2SakaiBM.WordWrap = true;
            // 
            // numericalTextBoxNaClB2Ueda
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2Ueda, "numericalTextBoxNaClB2Ueda");
            this.numericalTextBoxNaClB2Ueda.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2Ueda.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2Ueda.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2Ueda.FooterText = "GPa";
            this.numericalTextBoxNaClB2Ueda.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2Ueda.HeaderText = "";
            this.numericalTextBoxNaClB2Ueda.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB2Ueda.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB2Ueda.Multiline = false;
            this.numericalTextBoxNaClB2Ueda.Name = "numericalTextBoxNaClB2Ueda";
            this.numericalTextBoxNaClB2Ueda.RadianValue = 0D;
            this.numericalTextBoxNaClB2Ueda.ReadOnly = false;
            this.numericalTextBoxNaClB2Ueda.RestrictLimitValue = true;
            this.numericalTextBoxNaClB2Ueda.ShowFraction = false;
            this.numericalTextBoxNaClB2Ueda.ShowPositiveSign = false;
            this.numericalTextBoxNaClB2Ueda.ShowUpDown = false;
            this.numericalTextBoxNaClB2Ueda.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2Ueda.SmartIncrement = true;
            this.numericalTextBoxNaClB2Ueda.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2Ueda.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2Ueda.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxNaClB2Ueda.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB2Ueda.ToolTip = "";
            this.numericalTextBoxNaClB2Ueda.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB2Ueda.Value = 0D;
            this.numericalTextBoxNaClB2Ueda.WordWrap = true;
            // 
            // numericalTextBoxNaClB2SataMgO
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2SataMgO, "numericalTextBoxNaClB2SataMgO");
            this.numericalTextBoxNaClB2SataMgO.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SataMgO.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2SataMgO.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2SataMgO.FooterText = "GPa";
            this.numericalTextBoxNaClB2SataMgO.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2SataMgO.HeaderText = "";
            this.numericalTextBoxNaClB2SataMgO.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB2SataMgO.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB2SataMgO.Multiline = false;
            this.numericalTextBoxNaClB2SataMgO.Name = "numericalTextBoxNaClB2SataMgO";
            this.numericalTextBoxNaClB2SataMgO.RadianValue = 0D;
            this.numericalTextBoxNaClB2SataMgO.ReadOnly = false;
            this.numericalTextBoxNaClB2SataMgO.RestrictLimitValue = true;
            this.numericalTextBoxNaClB2SataMgO.ShowFraction = false;
            this.numericalTextBoxNaClB2SataMgO.ShowPositiveSign = false;
            this.numericalTextBoxNaClB2SataMgO.ShowUpDown = false;
            this.numericalTextBoxNaClB2SataMgO.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2SataMgO.SmartIncrement = true;
            this.numericalTextBoxNaClB2SataMgO.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2SataMgO.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2SataMgO.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxNaClB2SataMgO.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB2SataMgO.ToolTip = "";
            this.numericalTextBoxNaClB2SataMgO.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB2SataMgO.Value = 0D;
            this.numericalTextBoxNaClB2SataMgO.WordWrap = true;
            // 
            // numericalTextBoxNaClB2SataPt
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2SataPt, "numericalTextBoxNaClB2SataPt");
            this.numericalTextBoxNaClB2SataPt.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2SataPt.DecimalPlaces = 3;
            this.numericalTextBoxNaClB2SataPt.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2SataPt.FooterText = "GPa";
            this.numericalTextBoxNaClB2SataPt.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxNaClB2SataPt.HeaderText = "";
            this.numericalTextBoxNaClB2SataPt.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB2SataPt.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB2SataPt.Multiline = false;
            this.numericalTextBoxNaClB2SataPt.Name = "numericalTextBoxNaClB2SataPt";
            this.numericalTextBoxNaClB2SataPt.RadianValue = 0D;
            this.numericalTextBoxNaClB2SataPt.ReadOnly = false;
            this.numericalTextBoxNaClB2SataPt.RestrictLimitValue = true;
            this.numericalTextBoxNaClB2SataPt.ShowFraction = false;
            this.numericalTextBoxNaClB2SataPt.ShowPositiveSign = false;
            this.numericalTextBoxNaClB2SataPt.ShowUpDown = false;
            this.numericalTextBoxNaClB2SataPt.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2SataPt.SmartIncrement = true;
            this.numericalTextBoxNaClB2SataPt.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxNaClB2SataPt.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxNaClB2SataPt.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxNaClB2SataPt.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB2SataPt.ToolTip = "";
            this.numericalTextBoxNaClB2SataPt.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB2SataPt.Value = 0D;
            this.numericalTextBoxNaClB2SataPt.WordWrap = true;
            // 
            // numericalTextBoxNaClB2A
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2A, "numericalTextBoxNaClB2A");
            this.numericalTextBoxNaClB2A.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2A.DecimalPlaces = -1;
            this.numericalTextBoxNaClB2A.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB2A.FooterText = "Å";
            this.numericalTextBoxNaClB2A.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB2A.HeaderText = "a ";
            this.numericalTextBoxNaClB2A.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB2A.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB2A.Multiline = false;
            this.numericalTextBoxNaClB2A.Name = "numericalTextBoxNaClB2A";
            this.numericalTextBoxNaClB2A.RadianValue = 0.051138147083433859D;
            this.numericalTextBoxNaClB2A.ReadOnly = false;
            this.numericalTextBoxNaClB2A.RestrictLimitValue = true;
            this.numericalTextBoxNaClB2A.ShowFraction = false;
            this.numericalTextBoxNaClB2A.ShowPositiveSign = false;
            this.numericalTextBoxNaClB2A.ShowUpDown = false;
            this.numericalTextBoxNaClB2A.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2A.SmartIncrement = true;
            this.numericalTextBoxNaClB2A.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxNaClB2A.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxNaClB2A.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB2A.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB2A.ToolTip = "";
            this.numericalTextBoxNaClB2A.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB2A.Value = 2.93D;
            this.numericalTextBoxNaClB2A.WordWrap = true;
            this.numericalTextBoxNaClB2A.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxNaClB2A0
            // 
            resources.ApplyResources(this.numericalTextBoxNaClB2A0, "numericalTextBoxNaClB2A0");
            this.numericalTextBoxNaClB2A0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxNaClB2A0.DecimalPlaces = -1;
            this.numericalTextBoxNaClB2A0.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB2A0.FooterText = "Å";
            this.numericalTextBoxNaClB2A0.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB2A0.HeaderText = "a0";
            this.numericalTextBoxNaClB2A0.Maximum = double.PositiveInfinity;
            this.numericalTextBoxNaClB2A0.Minimum = double.NegativeInfinity;
            this.numericalTextBoxNaClB2A0.Multiline = false;
            this.numericalTextBoxNaClB2A0.Name = "numericalTextBoxNaClB2A0";
            this.numericalTextBoxNaClB2A0.RadianValue = 0D;
            this.numericalTextBoxNaClB2A0.ReadOnly = true;
            this.numericalTextBoxNaClB2A0.RestrictLimitValue = true;
            this.numericalTextBoxNaClB2A0.ShowFraction = false;
            this.numericalTextBoxNaClB2A0.ShowPositiveSign = false;
            this.numericalTextBoxNaClB2A0.ShowUpDown = false;
            this.numericalTextBoxNaClB2A0.SkipEventDuringInput = false;
            this.numericalTextBoxNaClB2A0.SmartIncrement = true;
            this.numericalTextBoxNaClB2A0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxNaClB2A0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxNaClB2A0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxNaClB2A0.ThonsandsSeparator = true;
            this.numericalTextBoxNaClB2A0.ToolTip = "";
            this.numericalTextBoxNaClB2A0.UpDown_Increment = 1D;
            this.numericalTextBoxNaClB2A0.Value = 0D;
            this.numericalTextBoxNaClB2A0.WordWrap = true;
            this.numericalTextBoxNaClB2A0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericBoxMgOTangeBM
            // 
            resources.ApplyResources(this.numericBoxMgOTangeBM, "numericBoxMgOTangeBM");
            this.numericBoxMgOTangeBM.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMgOTangeBM.DecimalPlaces = 3;
            this.numericBoxMgOTangeBM.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxMgOTangeBM.FooterText = "GPa";
            this.numericBoxMgOTangeBM.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxMgOTangeBM.HeaderText = "";
            this.numericBoxMgOTangeBM.Maximum = double.PositiveInfinity;
            this.numericBoxMgOTangeBM.Minimum = double.NegativeInfinity;
            this.numericBoxMgOTangeBM.Multiline = false;
            this.numericBoxMgOTangeBM.Name = "numericBoxMgOTangeBM";
            this.numericBoxMgOTangeBM.RadianValue = 0D;
            this.numericBoxMgOTangeBM.ReadOnly = false;
            this.numericBoxMgOTangeBM.RestrictLimitValue = true;
            this.numericBoxMgOTangeBM.ShowFraction = false;
            this.numericBoxMgOTangeBM.ShowPositiveSign = false;
            this.numericBoxMgOTangeBM.ShowUpDown = false;
            this.numericBoxMgOTangeBM.SkipEventDuringInput = false;
            this.numericBoxMgOTangeBM.SmartIncrement = true;
            this.numericBoxMgOTangeBM.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxMgOTangeBM.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxMgOTangeBM.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericBoxMgOTangeBM.ThonsandsSeparator = true;
            this.numericBoxMgOTangeBM.ToolTip = "";
            this.numericBoxMgOTangeBM.UpDown_Increment = 1D;
            this.numericBoxMgOTangeBM.Value = 0D;
            this.numericBoxMgOTangeBM.WordWrap = true;
            // 
            // numericBoxMgOTangeVinet
            // 
            resources.ApplyResources(this.numericBoxMgOTangeVinet, "numericBoxMgOTangeVinet");
            this.numericBoxMgOTangeVinet.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMgOTangeVinet.DecimalPlaces = 3;
            this.numericBoxMgOTangeVinet.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxMgOTangeVinet.FooterText = "GPa";
            this.numericBoxMgOTangeVinet.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxMgOTangeVinet.HeaderText = "";
            this.numericBoxMgOTangeVinet.Maximum = double.PositiveInfinity;
            this.numericBoxMgOTangeVinet.Minimum = double.NegativeInfinity;
            this.numericBoxMgOTangeVinet.Multiline = false;
            this.numericBoxMgOTangeVinet.Name = "numericBoxMgOTangeVinet";
            this.numericBoxMgOTangeVinet.RadianValue = 0D;
            this.numericBoxMgOTangeVinet.ReadOnly = false;
            this.numericBoxMgOTangeVinet.RestrictLimitValue = true;
            this.numericBoxMgOTangeVinet.ShowFraction = false;
            this.numericBoxMgOTangeVinet.ShowPositiveSign = false;
            this.numericBoxMgOTangeVinet.ShowUpDown = false;
            this.numericBoxMgOTangeVinet.SkipEventDuringInput = false;
            this.numericBoxMgOTangeVinet.SmartIncrement = true;
            this.numericBoxMgOTangeVinet.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericBoxMgOTangeVinet.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericBoxMgOTangeVinet.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericBoxMgOTangeVinet.ThonsandsSeparator = true;
            this.numericBoxMgOTangeVinet.ToolTip = "";
            this.numericBoxMgOTangeVinet.UpDown_Increment = 1D;
            this.numericBoxMgOTangeVinet.Value = 0D;
            this.numericBoxMgOTangeVinet.WordWrap = true;
            // 
            // numericalTextBoxMgOAizawa
            // 
            resources.ApplyResources(this.numericalTextBoxMgOAizawa, "numericalTextBoxMgOAizawa");
            this.numericalTextBoxMgOAizawa.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOAizawa.DecimalPlaces = 3;
            this.numericalTextBoxMgOAizawa.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxMgOAizawa.FooterText = "GPa";
            this.numericalTextBoxMgOAizawa.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxMgOAizawa.HeaderText = "";
            this.numericalTextBoxMgOAizawa.Maximum = double.PositiveInfinity;
            this.numericalTextBoxMgOAizawa.Minimum = double.NegativeInfinity;
            this.numericalTextBoxMgOAizawa.Multiline = false;
            this.numericalTextBoxMgOAizawa.Name = "numericalTextBoxMgOAizawa";
            this.numericalTextBoxMgOAizawa.RadianValue = 0D;
            this.numericalTextBoxMgOAizawa.ReadOnly = false;
            this.numericalTextBoxMgOAizawa.RestrictLimitValue = true;
            this.numericalTextBoxMgOAizawa.ShowFraction = false;
            this.numericalTextBoxMgOAizawa.ShowPositiveSign = false;
            this.numericalTextBoxMgOAizawa.ShowUpDown = false;
            this.numericalTextBoxMgOAizawa.SkipEventDuringInput = false;
            this.numericalTextBoxMgOAizawa.SmartIncrement = true;
            this.numericalTextBoxMgOAizawa.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxMgOAizawa.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxMgOAizawa.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxMgOAizawa.ThonsandsSeparator = true;
            this.numericalTextBoxMgOAizawa.ToolTip = "";
            this.numericalTextBoxMgOAizawa.UpDown_Increment = 1D;
            this.numericalTextBoxMgOAizawa.Value = 0D;
            this.numericalTextBoxMgOAizawa.WordWrap = true;
            // 
            // numericalTextBoxMgODewaele
            // 
            resources.ApplyResources(this.numericalTextBoxMgODewaele, "numericalTextBoxMgODewaele");
            this.numericalTextBoxMgODewaele.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgODewaele.DecimalPlaces = 3;
            this.numericalTextBoxMgODewaele.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxMgODewaele.FooterText = "GPa";
            this.numericalTextBoxMgODewaele.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxMgODewaele.HeaderText = "";
            this.numericalTextBoxMgODewaele.Maximum = double.PositiveInfinity;
            this.numericalTextBoxMgODewaele.Minimum = double.NegativeInfinity;
            this.numericalTextBoxMgODewaele.Multiline = false;
            this.numericalTextBoxMgODewaele.Name = "numericalTextBoxMgODewaele";
            this.numericalTextBoxMgODewaele.RadianValue = 0D;
            this.numericalTextBoxMgODewaele.ReadOnly = false;
            this.numericalTextBoxMgODewaele.RestrictLimitValue = true;
            this.numericalTextBoxMgODewaele.ShowFraction = false;
            this.numericalTextBoxMgODewaele.ShowPositiveSign = false;
            this.numericalTextBoxMgODewaele.ShowUpDown = false;
            this.numericalTextBoxMgODewaele.SkipEventDuringInput = false;
            this.numericalTextBoxMgODewaele.SmartIncrement = true;
            this.numericalTextBoxMgODewaele.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxMgODewaele.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxMgODewaele.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxMgODewaele.ThonsandsSeparator = true;
            this.numericalTextBoxMgODewaele.ToolTip = "";
            this.numericalTextBoxMgODewaele.UpDown_Increment = 1D;
            this.numericalTextBoxMgODewaele.Value = 0D;
            this.numericalTextBoxMgODewaele.WordWrap = true;
            // 
            // numericalTextBoxMgOJacson
            // 
            resources.ApplyResources(this.numericalTextBoxMgOJacson, "numericalTextBoxMgOJacson");
            this.numericalTextBoxMgOJacson.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOJacson.DecimalPlaces = 3;
            this.numericalTextBoxMgOJacson.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxMgOJacson.FooterText = "GPa";
            this.numericalTextBoxMgOJacson.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxMgOJacson.HeaderText = "";
            this.numericalTextBoxMgOJacson.Maximum = double.PositiveInfinity;
            this.numericalTextBoxMgOJacson.Minimum = double.NegativeInfinity;
            this.numericalTextBoxMgOJacson.Multiline = false;
            this.numericalTextBoxMgOJacson.Name = "numericalTextBoxMgOJacson";
            this.numericalTextBoxMgOJacson.RadianValue = 0D;
            this.numericalTextBoxMgOJacson.ReadOnly = false;
            this.numericalTextBoxMgOJacson.RestrictLimitValue = true;
            this.numericalTextBoxMgOJacson.ShowFraction = false;
            this.numericalTextBoxMgOJacson.ShowPositiveSign = false;
            this.numericalTextBoxMgOJacson.ShowUpDown = false;
            this.numericalTextBoxMgOJacson.SkipEventDuringInput = false;
            this.numericalTextBoxMgOJacson.SmartIncrement = true;
            this.numericalTextBoxMgOJacson.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxMgOJacson.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxMgOJacson.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxMgOJacson.ThonsandsSeparator = true;
            this.numericalTextBoxMgOJacson.ToolTip = "";
            this.numericalTextBoxMgOJacson.UpDown_Increment = 1D;
            this.numericalTextBoxMgOJacson.Value = 0D;
            this.numericalTextBoxMgOJacson.WordWrap = true;
            // 
            // numericalTextBoxMgOA
            // 
            resources.ApplyResources(this.numericalTextBoxMgOA, "numericalTextBoxMgOA");
            this.numericalTextBoxMgOA.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOA.DecimalPlaces = -1;
            this.numericalTextBoxMgOA.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxMgOA.FooterText = "Å";
            this.numericalTextBoxMgOA.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxMgOA.HeaderText = "a";
            this.numericalTextBoxMgOA.Maximum = double.PositiveInfinity;
            this.numericalTextBoxMgOA.Minimum = double.NegativeInfinity;
            this.numericalTextBoxMgOA.Multiline = false;
            this.numericalTextBoxMgOA.Name = "numericalTextBoxMgOA";
            this.numericalTextBoxMgOA.RadianValue = 0.0734993054599852D;
            this.numericalTextBoxMgOA.ReadOnly = false;
            this.numericalTextBoxMgOA.RestrictLimitValue = true;
            this.numericalTextBoxMgOA.ShowFraction = false;
            this.numericalTextBoxMgOA.ShowPositiveSign = false;
            this.numericalTextBoxMgOA.ShowUpDown = false;
            this.numericalTextBoxMgOA.SkipEventDuringInput = false;
            this.numericalTextBoxMgOA.SmartIncrement = true;
            this.numericalTextBoxMgOA.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxMgOA.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxMgOA.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxMgOA.ThonsandsSeparator = true;
            this.numericalTextBoxMgOA.ToolTip = "";
            this.numericalTextBoxMgOA.UpDown_Increment = 1D;
            this.numericalTextBoxMgOA.Value = 4.2112D;
            this.numericalTextBoxMgOA.WordWrap = true;
            this.numericalTextBoxMgOA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxMgOA0
            // 
            resources.ApplyResources(this.numericalTextBoxMgOA0, "numericalTextBoxMgOA0");
            this.numericalTextBoxMgOA0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxMgOA0.DecimalPlaces = -1;
            this.numericalTextBoxMgOA0.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxMgOA0.FooterText = "Å";
            this.numericalTextBoxMgOA0.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxMgOA0.HeaderText = "a0";
            this.numericalTextBoxMgOA0.Maximum = double.PositiveInfinity;
            this.numericalTextBoxMgOA0.Minimum = double.NegativeInfinity;
            this.numericalTextBoxMgOA0.Multiline = false;
            this.numericalTextBoxMgOA0.Name = "numericalTextBoxMgOA0";
            this.numericalTextBoxMgOA0.RadianValue = 0.0734993054599852D;
            this.numericalTextBoxMgOA0.ReadOnly = false;
            this.numericalTextBoxMgOA0.RestrictLimitValue = true;
            this.numericalTextBoxMgOA0.ShowFraction = false;
            this.numericalTextBoxMgOA0.ShowPositiveSign = false;
            this.numericalTextBoxMgOA0.ShowUpDown = false;
            this.numericalTextBoxMgOA0.SkipEventDuringInput = false;
            this.numericalTextBoxMgOA0.SmartIncrement = true;
            this.numericalTextBoxMgOA0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxMgOA0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxMgOA0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxMgOA0.ThonsandsSeparator = true;
            this.numericalTextBoxMgOA0.ToolTip = "";
            this.numericalTextBoxMgOA0.UpDown_Increment = 1D;
            this.numericalTextBoxMgOA0.Value = 4.2112D;
            this.numericalTextBoxMgOA0.WordWrap = true;
            this.numericalTextBoxMgOA0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxCorundumDubrovinsky
            // 
            resources.ApplyResources(this.numericalTextBoxCorundumDubrovinsky, "numericalTextBoxCorundumDubrovinsky");
            this.numericalTextBoxCorundumDubrovinsky.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxCorundumDubrovinsky.DecimalPlaces = 3;
            this.numericalTextBoxCorundumDubrovinsky.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxCorundumDubrovinsky.FooterText = "GPa";
            this.numericalTextBoxCorundumDubrovinsky.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxCorundumDubrovinsky.HeaderText = "";
            this.numericalTextBoxCorundumDubrovinsky.Maximum = double.PositiveInfinity;
            this.numericalTextBoxCorundumDubrovinsky.Minimum = double.NegativeInfinity;
            this.numericalTextBoxCorundumDubrovinsky.Multiline = false;
            this.numericalTextBoxCorundumDubrovinsky.Name = "numericalTextBoxCorundumDubrovinsky";
            this.numericalTextBoxCorundumDubrovinsky.RadianValue = 0D;
            this.numericalTextBoxCorundumDubrovinsky.ReadOnly = false;
            this.numericalTextBoxCorundumDubrovinsky.RestrictLimitValue = true;
            this.numericalTextBoxCorundumDubrovinsky.ShowFraction = false;
            this.numericalTextBoxCorundumDubrovinsky.ShowPositiveSign = false;
            this.numericalTextBoxCorundumDubrovinsky.ShowUpDown = false;
            this.numericalTextBoxCorundumDubrovinsky.SkipEventDuringInput = false;
            this.numericalTextBoxCorundumDubrovinsky.SmartIncrement = true;
            this.numericalTextBoxCorundumDubrovinsky.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxCorundumDubrovinsky.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxCorundumDubrovinsky.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxCorundumDubrovinsky.ThonsandsSeparator = true;
            this.numericalTextBoxCorundumDubrovinsky.ToolTip = "";
            this.numericalTextBoxCorundumDubrovinsky.UpDown_Increment = 1D;
            this.numericalTextBoxCorundumDubrovinsky.Value = 0D;
            this.numericalTextBoxCorundumDubrovinsky.WordWrap = true;
            // 
            // numericalTextBoxColundumV
            // 
            resources.ApplyResources(this.numericalTextBoxColundumV, "numericalTextBoxColundumV");
            this.numericalTextBoxColundumV.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxColundumV.DecimalPlaces = -1;
            this.numericalTextBoxColundumV.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxColundumV.FooterText = "Å^3";
            this.numericalTextBoxColundumV.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxColundumV.HeaderText = "V";
            this.numericalTextBoxColundumV.Maximum = double.PositiveInfinity;
            this.numericalTextBoxColundumV.Minimum = double.NegativeInfinity;
            this.numericalTextBoxColundumV.Multiline = false;
            this.numericalTextBoxColundumV.Name = "numericalTextBoxColundumV";
            this.numericalTextBoxColundumV.RadianValue = 4.4662054024689839D;
            this.numericalTextBoxColundumV.ReadOnly = false;
            this.numericalTextBoxColundumV.RestrictLimitValue = true;
            this.numericalTextBoxColundumV.ShowFraction = false;
            this.numericalTextBoxColundumV.ShowPositiveSign = false;
            this.numericalTextBoxColundumV.ShowUpDown = false;
            this.numericalTextBoxColundumV.SkipEventDuringInput = false;
            this.numericalTextBoxColundumV.SmartIncrement = true;
            this.numericalTextBoxColundumV.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxColundumV.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxColundumV.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxColundumV.ThonsandsSeparator = true;
            this.numericalTextBoxColundumV.ToolTip = "";
            this.numericalTextBoxColundumV.UpDown_Increment = 1D;
            this.numericalTextBoxColundumV.Value = 255.89472D;
            this.numericalTextBoxColundumV.WordWrap = true;
            this.numericalTextBoxColundumV.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxColundumV0
            // 
            resources.ApplyResources(this.numericalTextBoxColundumV0, "numericalTextBoxColundumV0");
            this.numericalTextBoxColundumV0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxColundumV0.DecimalPlaces = -1;
            this.numericalTextBoxColundumV0.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxColundumV0.FooterText = "Å^3";
            this.numericalTextBoxColundumV0.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxColundumV0.HeaderText = "V0";
            this.numericalTextBoxColundumV0.Maximum = double.PositiveInfinity;
            this.numericalTextBoxColundumV0.Minimum = double.NegativeInfinity;
            this.numericalTextBoxColundumV0.Multiline = false;
            this.numericalTextBoxColundumV0.Name = "numericalTextBoxColundumV0";
            this.numericalTextBoxColundumV0.RadianValue = 4.4662054024689839D;
            this.numericalTextBoxColundumV0.ReadOnly = false;
            this.numericalTextBoxColundumV0.RestrictLimitValue = true;
            this.numericalTextBoxColundumV0.ShowFraction = false;
            this.numericalTextBoxColundumV0.ShowPositiveSign = false;
            this.numericalTextBoxColundumV0.ShowUpDown = false;
            this.numericalTextBoxColundumV0.SkipEventDuringInput = false;
            this.numericalTextBoxColundumV0.SmartIncrement = true;
            this.numericalTextBoxColundumV0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxColundumV0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxColundumV0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxColundumV0.ThonsandsSeparator = true;
            this.numericalTextBoxColundumV0.ToolTip = "";
            this.numericalTextBoxColundumV0.UpDown_Increment = 1D;
            this.numericalTextBoxColundumV0.Value = 255.89472D;
            this.numericalTextBoxColundumV0.WordWrap = true;
            this.numericalTextBoxColundumV0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxArRoss
            // 
            resources.ApplyResources(this.numericalTextBoxArRoss, "numericalTextBoxArRoss");
            this.numericalTextBoxArRoss.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArRoss.DecimalPlaces = 3;
            this.numericalTextBoxArRoss.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxArRoss.FooterText = "GPa";
            this.numericalTextBoxArRoss.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxArRoss.HeaderText = "";
            this.numericalTextBoxArRoss.Maximum = double.PositiveInfinity;
            this.numericalTextBoxArRoss.Minimum = double.NegativeInfinity;
            this.numericalTextBoxArRoss.Multiline = false;
            this.numericalTextBoxArRoss.Name = "numericalTextBoxArRoss";
            this.numericalTextBoxArRoss.RadianValue = 0D;
            this.numericalTextBoxArRoss.ReadOnly = false;
            this.numericalTextBoxArRoss.RestrictLimitValue = true;
            this.numericalTextBoxArRoss.ShowFraction = false;
            this.numericalTextBoxArRoss.ShowPositiveSign = false;
            this.numericalTextBoxArRoss.ShowUpDown = false;
            this.numericalTextBoxArRoss.SkipEventDuringInput = false;
            this.numericalTextBoxArRoss.SmartIncrement = true;
            this.numericalTextBoxArRoss.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxArRoss.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxArRoss.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxArRoss.ThonsandsSeparator = true;
            this.numericalTextBoxArRoss.ToolTip = "";
            this.numericalTextBoxArRoss.UpDown_Increment = 1D;
            this.numericalTextBoxArRoss.Value = 0D;
            this.numericalTextBoxArRoss.WordWrap = true;
            // 
            // numericalTextBoxArJephcoat
            // 
            resources.ApplyResources(this.numericalTextBoxArJephcoat, "numericalTextBoxArJephcoat");
            this.numericalTextBoxArJephcoat.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArJephcoat.DecimalPlaces = 3;
            this.numericalTextBoxArJephcoat.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxArJephcoat.FooterText = "GPa";
            this.numericalTextBoxArJephcoat.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxArJephcoat.HeaderText = "";
            this.numericalTextBoxArJephcoat.Maximum = double.PositiveInfinity;
            this.numericalTextBoxArJephcoat.Minimum = double.NegativeInfinity;
            this.numericalTextBoxArJephcoat.Multiline = false;
            this.numericalTextBoxArJephcoat.Name = "numericalTextBoxArJephcoat";
            this.numericalTextBoxArJephcoat.RadianValue = 0D;
            this.numericalTextBoxArJephcoat.ReadOnly = false;
            this.numericalTextBoxArJephcoat.RestrictLimitValue = true;
            this.numericalTextBoxArJephcoat.ShowFraction = false;
            this.numericalTextBoxArJephcoat.ShowPositiveSign = false;
            this.numericalTextBoxArJephcoat.ShowUpDown = false;
            this.numericalTextBoxArJephcoat.SkipEventDuringInput = false;
            this.numericalTextBoxArJephcoat.SmartIncrement = true;
            this.numericalTextBoxArJephcoat.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxArJephcoat.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxArJephcoat.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxArJephcoat.ThonsandsSeparator = true;
            this.numericalTextBoxArJephcoat.ToolTip = "";
            this.numericalTextBoxArJephcoat.UpDown_Increment = 1D;
            this.numericalTextBoxArJephcoat.Value = 0D;
            this.numericalTextBoxArJephcoat.WordWrap = true;
            // 
            // numericalTextBoxArA
            // 
            resources.ApplyResources(this.numericalTextBoxArA, "numericalTextBoxArA");
            this.numericalTextBoxArA.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArA.DecimalPlaces = -1;
            this.numericalTextBoxArA.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxArA.FooterText = "Å";
            this.numericalTextBoxArA.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxArA.HeaderText = "a";
            this.numericalTextBoxArA.Maximum = double.PositiveInfinity;
            this.numericalTextBoxArA.Minimum = double.NegativeInfinity;
            this.numericalTextBoxArA.Multiline = false;
            this.numericalTextBoxArA.Name = "numericalTextBoxArA";
            this.numericalTextBoxArA.RadianValue = 0.071184998871840724D;
            this.numericalTextBoxArA.ReadOnly = false;
            this.numericalTextBoxArA.RestrictLimitValue = true;
            this.numericalTextBoxArA.ShowFraction = false;
            this.numericalTextBoxArA.ShowPositiveSign = false;
            this.numericalTextBoxArA.ShowUpDown = false;
            this.numericalTextBoxArA.SkipEventDuringInput = false;
            this.numericalTextBoxArA.SmartIncrement = true;
            this.numericalTextBoxArA.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxArA.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxArA.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxArA.ThonsandsSeparator = true;
            this.numericalTextBoxArA.ToolTip = "";
            this.numericalTextBoxArA.UpDown_Increment = 1D;
            this.numericalTextBoxArA.Value = 4.0786D;
            this.numericalTextBoxArA.WordWrap = true;
            this.numericalTextBoxArA.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxArA0
            // 
            resources.ApplyResources(this.numericalTextBoxArA0, "numericalTextBoxArA0");
            this.numericalTextBoxArA0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxArA0.DecimalPlaces = -1;
            this.numericalTextBoxArA0.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxArA0.FooterText = "Å";
            this.numericalTextBoxArA0.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxArA0.HeaderText = "a0";
            this.numericalTextBoxArA0.Maximum = double.PositiveInfinity;
            this.numericalTextBoxArA0.Minimum = double.NegativeInfinity;
            this.numericalTextBoxArA0.Multiline = false;
            this.numericalTextBoxArA0.Name = "numericalTextBoxArA0";
            this.numericalTextBoxArA0.RadianValue = 0D;
            this.numericalTextBoxArA0.ReadOnly = false;
            this.numericalTextBoxArA0.RestrictLimitValue = true;
            this.numericalTextBoxArA0.ShowFraction = false;
            this.numericalTextBoxArA0.ShowPositiveSign = false;
            this.numericalTextBoxArA0.ShowUpDown = false;
            this.numericalTextBoxArA0.SkipEventDuringInput = false;
            this.numericalTextBoxArA0.SmartIncrement = true;
            this.numericalTextBoxArA0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxArA0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxArA0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxArA0.ThonsandsSeparator = true;
            this.numericalTextBoxArA0.ToolTip = "";
            this.numericalTextBoxArA0.UpDown_Increment = 1D;
            this.numericalTextBoxArA0.Value = 0D;
            this.numericalTextBoxArA0.WordWrap = true;
            this.numericalTextBoxArA0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxReZha
            // 
            resources.ApplyResources(this.numericalTextBoxReZha, "numericalTextBoxReZha");
            this.numericalTextBoxReZha.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxReZha.DecimalPlaces = 3;
            this.numericalTextBoxReZha.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxReZha.FooterText = "GPa";
            this.numericalTextBoxReZha.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericalTextBoxReZha.HeaderText = "";
            this.numericalTextBoxReZha.Maximum = double.PositiveInfinity;
            this.numericalTextBoxReZha.Minimum = double.NegativeInfinity;
            this.numericalTextBoxReZha.Multiline = false;
            this.numericalTextBoxReZha.Name = "numericalTextBoxReZha";
            this.numericalTextBoxReZha.RadianValue = 0D;
            this.numericalTextBoxReZha.ReadOnly = false;
            this.numericalTextBoxReZha.RestrictLimitValue = true;
            this.numericalTextBoxReZha.ShowFraction = false;
            this.numericalTextBoxReZha.ShowPositiveSign = false;
            this.numericalTextBoxReZha.ShowUpDown = false;
            this.numericalTextBoxReZha.SkipEventDuringInput = false;
            this.numericalTextBoxReZha.SmartIncrement = true;
            this.numericalTextBoxReZha.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericalTextBoxReZha.TextBoxForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numericalTextBoxReZha.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxReZha.ThonsandsSeparator = true;
            this.numericalTextBoxReZha.ToolTip = "";
            this.numericalTextBoxReZha.UpDown_Increment = 1D;
            this.numericalTextBoxReZha.Value = 0D;
            this.numericalTextBoxReZha.WordWrap = true;
            // 
            // numericalTextBoxReV
            // 
            resources.ApplyResources(this.numericalTextBoxReV, "numericalTextBoxReV");
            this.numericalTextBoxReV.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxReV.DecimalPlaces = -1;
            this.numericalTextBoxReV.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxReV.FooterText = "Å^3";
            this.numericalTextBoxReV.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxReV.HeaderText = "V";
            this.numericalTextBoxReV.Maximum = double.PositiveInfinity;
            this.numericalTextBoxReV.Minimum = double.NegativeInfinity;
            this.numericalTextBoxReV.Multiline = false;
            this.numericalTextBoxReV.Name = "numericalTextBoxReV";
            this.numericalTextBoxReV.RadianValue = 0.51361461961226529D;
            this.numericalTextBoxReV.ReadOnly = false;
            this.numericalTextBoxReV.RestrictLimitValue = true;
            this.numericalTextBoxReV.ShowFraction = false;
            this.numericalTextBoxReV.ShowPositiveSign = false;
            this.numericalTextBoxReV.ShowUpDown = false;
            this.numericalTextBoxReV.SkipEventDuringInput = false;
            this.numericalTextBoxReV.SmartIncrement = true;
            this.numericalTextBoxReV.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxReV.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxReV.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxReV.ThonsandsSeparator = true;
            this.numericalTextBoxReV.ToolTip = "";
            this.numericalTextBoxReV.UpDown_Increment = 1D;
            this.numericalTextBoxReV.Value = 29.42795D;
            this.numericalTextBoxReV.WordWrap = true;
            this.numericalTextBoxReV.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // numericalTextBoxReV0
            // 
            resources.ApplyResources(this.numericalTextBoxReV0, "numericalTextBoxReV0");
            this.numericalTextBoxReV0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxReV0.DecimalPlaces = -1;
            this.numericalTextBoxReV0.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxReV0.FooterText = "Å^3";
            this.numericalTextBoxReV0.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxReV0.HeaderText = "V0";
            this.numericalTextBoxReV0.Maximum = double.PositiveInfinity;
            this.numericalTextBoxReV0.Minimum = double.NegativeInfinity;
            this.numericalTextBoxReV0.Multiline = false;
            this.numericalTextBoxReV0.Name = "numericalTextBoxReV0";
            this.numericalTextBoxReV0.RadianValue = 0.51361461961226529D;
            this.numericalTextBoxReV0.ReadOnly = false;
            this.numericalTextBoxReV0.RestrictLimitValue = true;
            this.numericalTextBoxReV0.ShowFraction = false;
            this.numericalTextBoxReV0.ShowPositiveSign = false;
            this.numericalTextBoxReV0.ShowUpDown = false;
            this.numericalTextBoxReV0.SkipEventDuringInput = false;
            this.numericalTextBoxReV0.SmartIncrement = true;
            this.numericalTextBoxReV0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxReV0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxReV0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxReV0.ThonsandsSeparator = true;
            this.numericalTextBoxReV0.ToolTip = "";
            this.numericalTextBoxReV0.UpDown_Increment = 1D;
            this.numericalTextBoxReV0.Value = 29.42795D;
            this.numericalTextBoxReV0.WordWrap = true;
            this.numericalTextBoxReV0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBox_ValueChanged);
            // 
            // FormEOS
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.numericalTextBoxTemperature);
            this.Controls.Add(this.tableLayoutPanel1);
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
        public Crystallography.Controls.NumericBox numericalTextBoxReV;
        private Label label18;
        private Crystallography.Controls.NumericBox numericalTextBoxReV0;
        private Crystallography.Controls.NumericBox numericBoxMgOTangeVinet;
        private Label label13;
        private Crystallography.Controls.NumericBox numericBoxMgOTangeBM;
        private Label label16;
        private Crystallography.Controls.NumericBox numericBoxAuYokoo;
        private Label label19;
        private Crystallography.Controls.NumericBox numericBoxPtYokoo;
        private Label label20;
    }


}