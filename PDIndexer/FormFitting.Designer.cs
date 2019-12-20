using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Crystallography;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
namespace PDIndexer
{
    /// <summary>
    /// FormFitting の概要の説明です。
    /// </summary>
    public partial class FormFitting : System.Windows.Forms.Form
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

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFitting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxGamma_err = new System.Windows.Forms.TextBox();
            this.textBoxAlpha_err = new System.Windows.Forms.TextBox();
            this.textBoxBeta_err = new System.Windows.Forms.TextBox();
            this.textBoxC_err = new System.Windows.Forms.TextBox();
            this.textBoxB_err = new System.Windows.Forms.TextBox();
            this.textBoxV = new System.Windows.Forms.TextBox();
            this.textBoxV_err = new System.Windows.Forms.TextBox();
            this.textBoxC = new System.Windows.Forms.TextBox();
            this.textBoxGamma = new System.Windows.Forms.TextBox();
            this.textBoxA_err = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.textBoxBeta = new System.Windows.Forms.TextBox();
            this.buttonCopyCellConstantsToClipboard = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonCopyTableToClipboard = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelPatternDecomposition = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonEachCrystal = new System.Windows.Forms.RadioButton();
            this.radioButtonBetweenCrystals = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonSymmetricPearson = new System.Windows.Forms.RadioButton();
            this.radioButtonPseudoVoigt = new System.Windows.Forms.RadioButton();
            this.radioButtonSplitPseudoVoigt = new System.Windows.Forms.RadioButton();
            this.radioButtonSimple = new System.Windows.Forms.RadioButton();
            this.radioButtonSplitPearson = new System.Windows.Forms.RadioButton();
            this.buttonApplyFunctionToAll = new System.Windows.Forms.Button();
            this.panelFWHM = new System.Windows.Forms.Panel();
            this.numericUpDownInitialFWHM = new System.Windows.Forms.NumericUpDown();
            this.buttonApplyFWHMToAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxUseInitialFWHM = new System.Windows.Forms.CheckBox();
            this.checkBoxPatternDecomposition = new System.Windows.Forms.CheckBox();
            this.numericUpDownSearchRange = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonApplyRangeToAll = new System.Windows.Forms.Button();
            this.dataGridViewCrystals = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSourceCrystals = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new PDIndexer.DataSet();
            this.dataGridViewPlaneList = new System.Windows.Forms.DataGridView();
            this.checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hKLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calcXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.functionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xErrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fWHMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intensityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboradToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSourcePlanes = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSendToCellFinder = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.useForCalcDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonRemovePeaks = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxRemovedProfileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSaveTableAsCSV = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonResetTakeoffAngle = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericBoxEffectiveDigit = new Crystallography.Controls.NumericBox();
            this.PeakColor = new System.Windows.Forms.DataGridViewImageColumn();
            this.crystalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanelPatternDecomposition.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelFWHM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialFWHM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCrystals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlaneList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePlanes)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.textBoxGamma_err);
            this.groupBox1.Controls.Add(this.textBoxAlpha_err);
            this.groupBox1.Controls.Add(this.textBoxBeta_err);
            this.groupBox1.Controls.Add(this.textBoxC_err);
            this.groupBox1.Controls.Add(this.textBoxB_err);
            this.groupBox1.Controls.Add(this.textBoxV);
            this.groupBox1.Controls.Add(this.textBoxV_err);
            this.groupBox1.Controls.Add(this.textBoxC);
            this.groupBox1.Controls.Add(this.textBoxGamma);
            this.groupBox1.Controls.Add(this.textBoxA_err);
            this.groupBox1.Controls.Add(this.textBoxA);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxB);
            this.groupBox1.Controls.Add(this.textBoxAlpha);
            this.groupBox1.Controls.Add(this.textBoxBeta);
            this.groupBox1.Controls.Add(this.buttonResetTakeoffAngle);
            this.groupBox1.Controls.Add(this.buttonCopyCellConstantsToClipboard);
            this.groupBox1.Controls.Add(this.buttonConfirm);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textBoxGamma_err
            // 
            resources.ApplyResources(this.textBoxGamma_err, "textBoxGamma_err");
            this.textBoxGamma_err.Name = "textBoxGamma_err";
            this.textBoxGamma_err.ReadOnly = true;
            // 
            // textBoxAlpha_err
            // 
            resources.ApplyResources(this.textBoxAlpha_err, "textBoxAlpha_err");
            this.textBoxAlpha_err.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxAlpha_err.Name = "textBoxAlpha_err";
            this.textBoxAlpha_err.ReadOnly = true;
            // 
            // textBoxBeta_err
            // 
            resources.ApplyResources(this.textBoxBeta_err, "textBoxBeta_err");
            this.textBoxBeta_err.Name = "textBoxBeta_err";
            this.textBoxBeta_err.ReadOnly = true;
            // 
            // textBoxC_err
            // 
            resources.ApplyResources(this.textBoxC_err, "textBoxC_err");
            this.textBoxC_err.Name = "textBoxC_err";
            this.textBoxC_err.ReadOnly = true;
            // 
            // textBoxB_err
            // 
            resources.ApplyResources(this.textBoxB_err, "textBoxB_err");
            this.textBoxB_err.Name = "textBoxB_err";
            this.textBoxB_err.ReadOnly = true;
            // 
            // textBoxV
            // 
            resources.ApplyResources(this.textBoxV, "textBoxV");
            this.textBoxV.Name = "textBoxV";
            this.textBoxV.ReadOnly = true;
            // 
            // textBoxV_err
            // 
            resources.ApplyResources(this.textBoxV_err, "textBoxV_err");
            this.textBoxV_err.Name = "textBoxV_err";
            this.textBoxV_err.ReadOnly = true;
            // 
            // textBoxC
            // 
            resources.ApplyResources(this.textBoxC, "textBoxC");
            this.textBoxC.Name = "textBoxC";
            this.textBoxC.ReadOnly = true;
            // 
            // textBoxGamma
            // 
            resources.ApplyResources(this.textBoxGamma, "textBoxGamma");
            this.textBoxGamma.Name = "textBoxGamma";
            this.textBoxGamma.ReadOnly = true;
            // 
            // textBoxA_err
            // 
            resources.ApplyResources(this.textBoxA_err, "textBoxA_err");
            this.textBoxA_err.Name = "textBoxA_err";
            this.textBoxA_err.ReadOnly = true;
            this.textBoxA_err.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // textBoxA
            // 
            resources.ApplyResources(this.textBoxA, "textBoxA");
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.ReadOnly = true;
            this.textBoxA.TextChanged += new System.EventHandler(this.textBoxA_TextChanged);
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // textBoxB
            // 
            resources.ApplyResources(this.textBoxB, "textBoxB");
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.ReadOnly = true;
            // 
            // textBoxAlpha
            // 
            resources.ApplyResources(this.textBoxAlpha, "textBoxAlpha");
            this.textBoxAlpha.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.ReadOnly = true;
            // 
            // textBoxBeta
            // 
            resources.ApplyResources(this.textBoxBeta, "textBoxBeta");
            this.textBoxBeta.Name = "textBoxBeta";
            this.textBoxBeta.ReadOnly = true;
            // 
            // buttonCopyCellConstantsToClipboard
            // 
            resources.ApplyResources(this.buttonCopyCellConstantsToClipboard, "buttonCopyCellConstantsToClipboard");
            this.buttonCopyCellConstantsToClipboard.Name = "buttonCopyCellConstantsToClipboard";
            this.buttonCopyCellConstantsToClipboard.Click += new System.EventHandler(this.buttonCopyClipboard_Click);
            // 
            // buttonConfirm
            // 
            resources.ApplyResources(this.buttonConfirm, "buttonConfirm");
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // buttonCopyTableToClipboard
            // 
            resources.ApplyResources(this.buttonCopyTableToClipboard, "buttonCopyTableToClipboard");
            this.buttonCopyTableToClipboard.Name = "buttonCopyTableToClipboard";
            this.toolTip.SetToolTip(this.buttonCopyTableToClipboard, resources.GetString("buttonCopyTableToClipboard.ToolTip"));
            this.buttonCopyTableToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyTableToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.flowLayoutPanelPatternDecomposition);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.panelFWHM);
            this.groupBox3.Controls.Add(this.checkBoxUseInitialFWHM);
            this.groupBox3.Controls.Add(this.checkBoxPatternDecomposition);
            this.groupBox3.Controls.Add(this.numericUpDownSearchRange);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.buttonApplyRangeToAll);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // flowLayoutPanelPatternDecomposition
            // 
            resources.ApplyResources(this.flowLayoutPanelPatternDecomposition, "flowLayoutPanelPatternDecomposition");
            this.flowLayoutPanelPatternDecomposition.Controls.Add(this.radioButtonEachCrystal);
            this.flowLayoutPanelPatternDecomposition.Controls.Add(this.radioButtonBetweenCrystals);
            this.flowLayoutPanelPatternDecomposition.Name = "flowLayoutPanelPatternDecomposition";
            // 
            // radioButtonEachCrystal
            // 
            resources.ApplyResources(this.radioButtonEachCrystal, "radioButtonEachCrystal");
            this.radioButtonEachCrystal.Checked = true;
            this.radioButtonEachCrystal.Name = "radioButtonEachCrystal";
            this.radioButtonEachCrystal.TabStop = true;
            this.radioButtonEachCrystal.UseVisualStyleBackColor = true;
            this.radioButtonEachCrystal.CheckedChanged += new System.EventHandler(this.radioButtonEachCrystal_CheckedChanged);
            // 
            // radioButtonBetweenCrystals
            // 
            resources.ApplyResources(this.radioButtonBetweenCrystals, "radioButtonBetweenCrystals");
            this.radioButtonBetweenCrystals.Name = "radioButtonBetweenCrystals";
            this.radioButtonBetweenCrystals.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonSymmetricPearson);
            this.groupBox2.Controls.Add(this.radioButtonPseudoVoigt);
            this.groupBox2.Controls.Add(this.radioButtonSplitPseudoVoigt);
            this.groupBox2.Controls.Add(this.radioButtonSimple);
            this.groupBox2.Controls.Add(this.radioButtonSplitPearson);
            this.groupBox2.Controls.Add(this.buttonApplyFunctionToAll);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // radioButtonSymmetricPearson
            // 
            resources.ApplyResources(this.radioButtonSymmetricPearson, "radioButtonSymmetricPearson");
            this.radioButtonSymmetricPearson.Name = "radioButtonSymmetricPearson";
            this.radioButtonSymmetricPearson.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonPseudoVoigt
            // 
            resources.ApplyResources(this.radioButtonPseudoVoigt, "radioButtonPseudoVoigt");
            this.radioButtonPseudoVoigt.Checked = true;
            this.radioButtonPseudoVoigt.Name = "radioButtonPseudoVoigt";
            this.radioButtonPseudoVoigt.TabStop = true;
            this.radioButtonPseudoVoigt.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonSplitPseudoVoigt
            // 
            resources.ApplyResources(this.radioButtonSplitPseudoVoigt, "radioButtonSplitPseudoVoigt");
            this.radioButtonSplitPseudoVoigt.Name = "radioButtonSplitPseudoVoigt";
            this.radioButtonSplitPseudoVoigt.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonSimple
            // 
            resources.ApplyResources(this.radioButtonSimple, "radioButtonSimple");
            this.radioButtonSimple.Name = "radioButtonSimple";
            this.radioButtonSimple.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonSplitPearson
            // 
            resources.ApplyResources(this.radioButtonSplitPearson, "radioButtonSplitPearson");
            this.radioButtonSplitPearson.Name = "radioButtonSplitPearson";
            this.radioButtonSplitPearson.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // buttonApplyFunctionToAll
            // 
            resources.ApplyResources(this.buttonApplyFunctionToAll, "buttonApplyFunctionToAll");
            this.buttonApplyFunctionToAll.Name = "buttonApplyFunctionToAll";
            this.buttonApplyFunctionToAll.Click += new System.EventHandler(this.buttonApplyFunctionToAll_Click);
            // 
            // panelFWHM
            // 
            this.panelFWHM.Controls.Add(this.numericUpDownInitialFWHM);
            this.panelFWHM.Controls.Add(this.buttonApplyFWHMToAll);
            this.panelFWHM.Controls.Add(this.label1);
            resources.ApplyResources(this.panelFWHM, "panelFWHM");
            this.panelFWHM.Name = "panelFWHM";
            // 
            // numericUpDownInitialFWHM
            // 
            this.numericUpDownInitialFWHM.DecimalPlaces = 3;
            this.numericUpDownInitialFWHM.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            resources.ApplyResources(this.numericUpDownInitialFWHM, "numericUpDownInitialFWHM");
            this.numericUpDownInitialFWHM.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownInitialFWHM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownInitialFWHM.Name = "numericUpDownInitialFWHM";
            this.numericUpDownInitialFWHM.Value = new decimal(new int[] {
            6,
            0,
            0,
            131072});
            this.numericUpDownInitialFWHM.ValueChanged += new System.EventHandler(this.numericUpDownSearchRange_ValueChanged);
            // 
            // buttonApplyFWHMToAll
            // 
            resources.ApplyResources(this.buttonApplyFWHMToAll, "buttonApplyFWHMToAll");
            this.buttonApplyFWHMToAll.Name = "buttonApplyFWHMToAll";
            this.buttonApplyFWHMToAll.Click += new System.EventHandler(this.buttonApplyFWHMToAll_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // checkBoxUseInitialFWHM
            // 
            resources.ApplyResources(this.checkBoxUseInitialFWHM, "checkBoxUseInitialFWHM");
            this.checkBoxUseInitialFWHM.Name = "checkBoxUseInitialFWHM";
            this.checkBoxUseInitialFWHM.UseVisualStyleBackColor = true;
            this.checkBoxUseInitialFWHM.CheckedChanged += new System.EventHandler(this.checkBoxUseInitialFWHM_CheckedChanged);
            // 
            // checkBoxPatternDecomposition
            // 
            resources.ApplyResources(this.checkBoxPatternDecomposition, "checkBoxPatternDecomposition");
            this.checkBoxPatternDecomposition.Name = "checkBoxPatternDecomposition";
            this.checkBoxPatternDecomposition.UseVisualStyleBackColor = true;
            this.checkBoxPatternDecomposition.CheckedChanged += new System.EventHandler(this.checkBoxPatternDecomposition_CheckedChanged);
            // 
            // numericUpDownSearchRange
            // 
            this.numericUpDownSearchRange.DecimalPlaces = 3;
            this.numericUpDownSearchRange.Increment = new decimal(new int[] {
            2,
            0,
            0,
            131072});
            resources.ApplyResources(this.numericUpDownSearchRange, "numericUpDownSearchRange");
            this.numericUpDownSearchRange.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownSearchRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownSearchRange.Name = "numericUpDownSearchRange";
            this.numericUpDownSearchRange.Value = new decimal(new int[] {
            6,
            0,
            0,
            131072});
            this.numericUpDownSearchRange.ValueChanged += new System.EventHandler(this.numericUpDownSearchRange_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // buttonApplyRangeToAll
            // 
            resources.ApplyResources(this.buttonApplyRangeToAll, "buttonApplyRangeToAll");
            this.buttonApplyRangeToAll.Name = "buttonApplyRangeToAll";
            this.buttonApplyRangeToAll.Click += new System.EventHandler(this.buttonApplyRangeToAll_Click);
            // 
            // dataGridViewCrystals
            // 
            this.dataGridViewCrystals.AllowUserToAddRows = false;
            this.dataGridViewCrystals.AllowUserToDeleteRows = false;
            this.dataGridViewCrystals.AllowUserToResizeColumns = false;
            this.dataGridViewCrystals.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridViewCrystals, "dataGridViewCrystals");
            this.dataGridViewCrystals.AutoGenerateColumns = false;
            this.dataGridViewCrystals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCrystals.ColumnHeadersVisible = false;
            this.dataGridViewCrystals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.PeakColor,
            this.crystalDataGridViewTextBoxColumn});
            this.dataGridViewCrystals.DataSource = this.bindingSourceCrystals;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCrystals.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCrystals.MultiSelect = false;
            this.dataGridViewCrystals.Name = "dataGridViewCrystals";
            this.dataGridViewCrystals.ReadOnly = true;
            this.dataGridViewCrystals.RowHeadersVisible = false;
            this.dataGridViewCrystals.RowTemplate.Height = 21;
            this.dataGridViewCrystals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCrystals.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCrystals_CellMouseClick);
            this.dataGridViewCrystals.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCrystals_CellMouseClick);
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            resources.ApplyResources(this.Check, "Check");
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            // 
            // bindingSourceCrystals
            // 
            this.bindingSourceCrystals.DataMember = "DataTableCrystal";
            this.bindingSourceCrystals.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewPlaneList
            // 
            this.dataGridViewPlaneList.AllowUserToAddRows = false;
            this.dataGridViewPlaneList.AllowUserToDeleteRows = false;
            this.dataGridViewPlaneList.AllowUserToResizeColumns = false;
            this.dataGridViewPlaneList.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridViewPlaneList, "dataGridViewPlaneList");
            this.dataGridViewPlaneList.AutoGenerateColumns = false;
            this.dataGridViewPlaneList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPlaneList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkDataGridViewCheckBoxColumn,
            this.hKLDataGridViewTextBoxColumn,
            this.calcXDataGridViewTextBoxColumn,
            this.functionDataGridViewTextBoxColumn,
            this.xDataGridViewTextBoxColumn,
            this.xErrDataGridViewTextBoxColumn,
            this.fWHMDataGridViewTextBoxColumn,
            this.intensityDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn,
            this.R});
            this.dataGridViewPlaneList.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewPlaneList.DataSource = this.bindingSourcePlanes;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Symbol", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Format = "G5";
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPlaneList.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewPlaneList.MultiSelect = false;
            this.dataGridViewPlaneList.Name = "dataGridViewPlaneList";
            this.dataGridViewPlaneList.RowHeadersVisible = false;
            this.dataGridViewPlaneList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewPlaneList.RowTemplate.Height = 21;
            this.dataGridViewPlaneList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPlaneList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridViewPlaneList.SelectionChanged += new System.EventHandler(this.dataGridViewPlaneList_SelectionChanged);
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            this.checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            resources.ApplyResources(this.checkDataGridViewCheckBoxColumn, "checkDataGridViewCheckBoxColumn");
            this.checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            // 
            // hKLDataGridViewTextBoxColumn
            // 
            this.hKLDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.hKLDataGridViewTextBoxColumn.DataPropertyName = "HKL";
            resources.ApplyResources(this.hKLDataGridViewTextBoxColumn, "hKLDataGridViewTextBoxColumn");
            this.hKLDataGridViewTextBoxColumn.Name = "hKLDataGridViewTextBoxColumn";
            this.hKLDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // calcXDataGridViewTextBoxColumn
            // 
            this.calcXDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.calcXDataGridViewTextBoxColumn.DataPropertyName = "CalcX";
            dataGridViewCellStyle2.NullValue = null;
            this.calcXDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.calcXDataGridViewTextBoxColumn, "calcXDataGridViewTextBoxColumn");
            this.calcXDataGridViewTextBoxColumn.Name = "calcXDataGridViewTextBoxColumn";
            this.calcXDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // functionDataGridViewTextBoxColumn
            // 
            this.functionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.functionDataGridViewTextBoxColumn.DataPropertyName = "Function";
            resources.ApplyResources(this.functionDataGridViewTextBoxColumn, "functionDataGridViewTextBoxColumn");
            this.functionDataGridViewTextBoxColumn.Name = "functionDataGridViewTextBoxColumn";
            this.functionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xDataGridViewTextBoxColumn
            // 
            this.xDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
            dataGridViewCellStyle3.NullValue = null;
            this.xDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.xDataGridViewTextBoxColumn, "xDataGridViewTextBoxColumn");
            this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            this.xDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xErrDataGridViewTextBoxColumn
            // 
            this.xErrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.xErrDataGridViewTextBoxColumn.DataPropertyName = "XErr";
            dataGridViewCellStyle4.NullValue = null;
            this.xErrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.xErrDataGridViewTextBoxColumn, "xErrDataGridViewTextBoxColumn");
            this.xErrDataGridViewTextBoxColumn.Name = "xErrDataGridViewTextBoxColumn";
            this.xErrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fWHMDataGridViewTextBoxColumn
            // 
            this.fWHMDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fWHMDataGridViewTextBoxColumn.DataPropertyName = "FWHM";
            dataGridViewCellStyle5.NullValue = null;
            this.fWHMDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.fWHMDataGridViewTextBoxColumn, "fWHMDataGridViewTextBoxColumn");
            this.fWHMDataGridViewTextBoxColumn.Name = "fWHMDataGridViewTextBoxColumn";
            this.fWHMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // intensityDataGridViewTextBoxColumn
            // 
            this.intensityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.intensityDataGridViewTextBoxColumn.DataPropertyName = "Intensity";
            dataGridViewCellStyle6.NullValue = null;
            this.intensityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.intensityDataGridViewTextBoxColumn, "intensityDataGridViewTextBoxColumn");
            this.intensityDataGridViewTextBoxColumn.Name = "intensityDataGridViewTextBoxColumn";
            this.intensityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            dataGridViewCellStyle7.NullValue = null;
            this.weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.weightDataGridViewTextBoxColumn, "weightDataGridViewTextBoxColumn");
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            this.weightDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // R
            // 
            this.R.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.R.DataPropertyName = "R";
            dataGridViewCellStyle8.NullValue = null;
            this.R.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.R, "R");
            this.R.Name = "R";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboradToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // copyToClipboradToolStripMenuItem
            // 
            this.copyToClipboradToolStripMenuItem.Name = "copyToClipboradToolStripMenuItem";
            resources.ApplyResources(this.copyToClipboradToolStripMenuItem, "copyToClipboradToolStripMenuItem");
            // 
            // bindingSourcePlanes
            // 
            this.bindingSourcePlanes.AllowNew = false;
            this.bindingSourcePlanes.DataMember = "DataTablePeakFitting";
            this.bindingSourcePlanes.DataSource = this.dataSet;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Plane";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // buttonSendToCellFinder
            // 
            resources.ApplyResources(this.buttonSendToCellFinder, "buttonSendToCellFinder");
            this.buttonSendToCellFinder.Name = "buttonSendToCellFinder";
            this.buttonSendToCellFinder.UseVisualStyleBackColor = true;
            this.buttonSendToCellFinder.Click += new System.EventHandler(this.buttonSendToCellFinder_Click);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Plane";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Plane";
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // useForCalcDataGridViewCheckBoxColumn
            // 
            this.useForCalcDataGridViewCheckBoxColumn.DataPropertyName = "Use for Calc.";
            resources.ApplyResources(this.useForCalcDataGridViewCheckBoxColumn, "useForCalcDataGridViewCheckBoxColumn");
            this.useForCalcDataGridViewCheckBoxColumn.Name = "useForCalcDataGridViewCheckBoxColumn";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // buttonRemovePeaks
            // 
            resources.ApplyResources(this.buttonRemovePeaks, "buttonRemovePeaks");
            this.buttonRemovePeaks.Name = "buttonRemovePeaks";
            this.toolTip.SetToolTip(this.buttonRemovePeaks, resources.GetString("buttonRemovePeaks.ToolTip"));
            this.buttonRemovePeaks.UseVisualStyleBackColor = true;
            this.buttonRemovePeaks.Click += new System.EventHandler(this.buttonRemovePeaks_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.textBoxRemovedProfileName);
            this.groupBox4.Controls.Add(this.buttonRemovePeaks);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // textBoxRemovedProfileName
            // 
            resources.ApplyResources(this.textBoxRemovedProfileName, "textBoxRemovedProfileName");
            this.textBoxRemovedProfileName.Name = "textBoxRemovedProfileName";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.buttonSendToCellFinder);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // buttonSaveTableAsCSV
            // 
            resources.ApplyResources(this.buttonSaveTableAsCSV, "buttonSaveTableAsCSV");
            this.buttonSaveTableAsCSV.Name = "buttonSaveTableAsCSV";
            this.toolTip.SetToolTip(this.buttonSaveTableAsCSV, resources.GetString("buttonSaveTableAsCSV.ToolTip"));
            this.buttonSaveTableAsCSV.UseVisualStyleBackColor = true;
            this.buttonSaveTableAsCSV.Click += new System.EventHandler(this.ButtonSaveTableAsCSV_Click);
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn16, "dataGridViewTextBoxColumn16");
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn17, "dataGridViewTextBoxColumn17");
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn2, "dataGridViewImageColumn2");
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn18, "dataGridViewTextBoxColumn18");
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn3, "dataGridViewImageColumn3");
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn19, "dataGridViewTextBoxColumn19");
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn20, "dataGridViewTextBoxColumn20");
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "PlaneObject";
            resources.ApplyResources(this.dataGridViewTextBoxColumn21, "dataGridViewTextBoxColumn21");
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn4, "dataGridViewImageColumn4");
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn5
            // 
            this.dataGridViewImageColumn5.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn5, "dataGridViewImageColumn5");
            this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
            this.dataGridViewImageColumn5.ReadOnly = true;
            this.dataGridViewImageColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn22, "dataGridViewTextBoxColumn22");
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewImageColumn6
            // 
            this.dataGridViewImageColumn6.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn6, "dataGridViewImageColumn6");
            this.dataGridViewImageColumn6.Name = "dataGridViewImageColumn6";
            this.dataGridViewImageColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn23, "dataGridViewTextBoxColumn23");
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // buttonResetTakeoffAngle
            // 
            resources.ApplyResources(this.buttonResetTakeoffAngle, "buttonResetTakeoffAngle");
            this.buttonResetTakeoffAngle.Name = "buttonResetTakeoffAngle";
            this.buttonResetTakeoffAngle.Click += new System.EventHandler(this.buttonResetTakeoffAngle_Click);
            // 
            // dataGridViewImageColumn7
            // 
            this.dataGridViewImageColumn7.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn7, "dataGridViewImageColumn7");
            this.dataGridViewImageColumn7.Name = "dataGridViewImageColumn7";
            this.dataGridViewImageColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn24, "dataGridViewTextBoxColumn24");
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            // 
            // numericBoxEffectiveDigit
            // 
            this.numericBoxEffectiveDigit.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxEffectiveDigit, "numericBoxEffectiveDigit");
            this.numericBoxEffectiveDigit.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxEffectiveDigit.DecimalPlaces = -2;
            this.numericBoxEffectiveDigit.Maximum = 16D;
            this.numericBoxEffectiveDigit.Minimum = 1D;
            this.numericBoxEffectiveDigit.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericBoxEffectiveDigit.MouseSpeed = 1D;
            this.numericBoxEffectiveDigit.Multiline = false;
            this.numericBoxEffectiveDigit.Name = "numericBoxEffectiveDigit";
            this.numericBoxEffectiveDigit.RadianValue = 0.087266462599716474D;
            this.numericBoxEffectiveDigit.ReadOnly = false;
            this.numericBoxEffectiveDigit.RestrictLimitValue = true;
            this.numericBoxEffectiveDigit.ShowFraction = false;
            this.numericBoxEffectiveDigit.ShowPositiveSign = false;
            this.numericBoxEffectiveDigit.ShowUpDown = true;
            this.numericBoxEffectiveDigit.SkipEventDuringInput = false;
            this.numericBoxEffectiveDigit.SmartIncrement = false;
            this.numericBoxEffectiveDigit.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxEffectiveDigit.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxEffectiveDigit.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F);
            this.numericBoxEffectiveDigit.ThonsandsSeparator = true;
            this.toolTip.SetToolTip(this.numericBoxEffectiveDigit, resources.GetString("numericBoxEffectiveDigit.ToolTip"));
            this.numericBoxEffectiveDigit.UpDown_Increment = 1D;
            this.numericBoxEffectiveDigit.Value = 5D;
            this.numericBoxEffectiveDigit.WordWrap = true;
            this.numericBoxEffectiveDigit.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.NumericBoxEffectiveDigit_ValueChanged);
            // 
            // PeakColor
            // 
            this.PeakColor.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.PeakColor, "PeakColor");
            this.PeakColor.Name = "PeakColor";
            this.PeakColor.ReadOnly = true;
            this.PeakColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PeakColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // crystalDataGridViewTextBoxColumn
            // 
            this.crystalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.crystalDataGridViewTextBoxColumn.DataPropertyName = "Crystal";
            resources.ApplyResources(this.crystalDataGridViewTextBoxColumn, "crystalDataGridViewTextBoxColumn");
            this.crystalDataGridViewTextBoxColumn.Name = "crystalDataGridViewTextBoxColumn";
            this.crystalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormFitting
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.numericBoxEffectiveDigit);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonSaveTableAsCSV);
            this.Controls.Add(this.buttonCopyTableToClipboard);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridViewPlaneList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewCrystals);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormFitting";
            this.Closed += new System.EventHandler(this.FormFitting_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFitting_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormFitting_VisibleChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormFitting_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormFitting_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFitting_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutPanelPatternDecomposition.ResumeLayout(false);
            this.flowLayoutPanelPatternDecomposition.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelFWHM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInitialFWHM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCrystals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlaneList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePlanes)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox textBoxC;
        public System.Windows.Forms.TextBox textBoxGamma;
        public System.Windows.Forms.TextBox textBoxA;
        public System.Windows.Forms.TextBox textBoxB;
        public System.Windows.Forms.TextBox textBoxAlpha;
        public System.Windows.Forms.TextBox textBoxBeta;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonSimple;
        private System.Windows.Forms.RadioButton radioButtonPseudoVoigt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label18;
        private Label label2;
        private NumericUpDown numericUpDownSearchRange;
        private CheckBox checkBoxPatternDecomposition;
        public TextBox textBoxC_err;
        public TextBox textBoxGamma_err;
        public TextBox textBoxA_err;
        private Label label21;
        private Label label10;
        private Label label20;
        private Label label19;
        private Label label17;
        private Label label11;
        private Label label9;
        public TextBox textBoxB_err;
        public TextBox textBoxAlpha_err;
        public TextBox textBoxBeta_err;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        public TextBox textBoxV_err;
        public TextBox textBoxV;
        private Label label29;
        private Label label27;
        private Label label28;
        private RadioButton radioButtonBetweenCrystals;
        private RadioButton radioButtonEachCrystal;
        private RadioButton radioButtonSplitPearson;
        private RadioButton radioButtonSymmetricPearson;
        private RadioButton radioButtonSplitPseudoVoigt;
        private Button buttonCopyTableToClipboard;
        private IContainer components;
        public BindingSource bindingSourceCrystals;
        public DataGridView dataGridViewCrystals;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Button buttonSendToCellFinder;
        public DataSet dataSet;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private Button buttonApplyRangeToAll;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private NumericUpDown numericUpDownInitialFWHM;
        private Button buttonApplyFWHMToAll;
        private CheckBox checkBoxUseInitialFWHM;
        private Panel panelFWHM;
        private Label label1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewCheckBoxColumn useForCalcDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private Button buttonRemovePeaks;
        private Label label3;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private TextBox textBoxRemovedProfileName;
        private Label label4;
        private GroupBox groupBox5;
        private ToolTip toolTip;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewCheckBoxColumn Check;
        private DataGridViewImageColumn PeakColor;
        private DataGridViewTextBoxColumn crystalDataGridViewTextBoxColumn;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyToClipboradToolStripMenuItem;
        private Button buttonCopyCellConstantsToClipboard;
        public BindingSource bindingSourcePlanes;
        private Button buttonApplyFunctionToAll;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private Button buttonSaveTableAsCSV;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewImageColumn dataGridViewImageColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private FlowLayoutPanel flowLayoutPanelPatternDecomposition;
        private DataGridViewTextBoxColumn peakObjectDataGridViewTextBoxColumn;
        private DataGridViewImageColumn dataGridViewImageColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        public DataGridView dataGridViewPlaneList;
        private DataGridViewImageColumn dataGridViewImageColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private Crystallography.Controls.NumericBox numericBoxEffectiveDigit;
        private DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn hKLDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn calcXDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn functionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xErrDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fWHMDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn intensityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn R;
        private DataGridViewImageColumn dataGridViewImageColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private Button buttonResetTakeoffAngle;
        private DataGridViewImageColumn dataGridViewImageColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
    }


}