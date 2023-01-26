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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormFitting));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            textBoxGamma_err = new TextBox();
            textBoxAlpha_err = new TextBox();
            textBoxBeta_err = new TextBox();
            textBoxC_err = new TextBox();
            textBoxB_err = new TextBox();
            textBoxV = new TextBox();
            textBoxV_err = new TextBox();
            textBoxC = new TextBox();
            textBoxGamma = new TextBox();
            textBoxA_err = new TextBox();
            textBoxA = new TextBox();
            label26 = new Label();
            label25 = new Label();
            label24 = new Label();
            label3 = new Label();
            label29 = new Label();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            label10 = new Label();
            label20 = new Label();
            label19 = new Label();
            label17 = new Label();
            label27 = new Label();
            label11 = new Label();
            label9 = new Label();
            textBoxB = new TextBox();
            textBoxAlpha = new TextBox();
            textBoxBeta = new TextBox();
            buttonResetTakeoffAngle = new Button();
            buttonCopyCellConstantsToClipboard = new Button();
            buttonConfirm = new Button();
            label8 = new Label();
            label12 = new Label();
            label28 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            buttonCopyTableToClipboard = new Button();
            groupBox3 = new GroupBox();
            flowLayoutPanelPatternDecomposition = new FlowLayoutPanel();
            radioButtonEachCrystal = new RadioButton();
            radioButtonBetweenCrystals = new RadioButton();
            groupBox2 = new GroupBox();
            radioButtonSymmetricPearson = new RadioButton();
            radioButtonPseudoVoigt = new RadioButton();
            radioButtonSplitPseudoVoigt = new RadioButton();
            radioButtonSimple = new RadioButton();
            radioButtonSplitPearson = new RadioButton();
            buttonApplyFunctionToAll = new Button();
            panelFWHM = new Panel();
            numericUpDownInitialFWHM = new NumericUpDown();
            buttonApplyFWHMToAll = new Button();
            label1 = new Label();
            checkBoxUseInitialFWHM = new CheckBox();
            checkBoxPatternDecomposition = new CheckBox();
            numericUpDownSearchRange = new NumericUpDown();
            label7 = new Label();
            label2 = new Label();
            label18 = new Label();
            buttonApplyRangeToAll = new Button();
            dataGridViewCrystals = new DataGridView();
            Check = new DataGridViewCheckBoxColumn();
            PeakColor = new DataGridViewImageColumn();
            crystalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSourceCrystals = new BindingSource(components);
            dataSet = new DataSet();
            dataGridViewPlaneList = new DataGridView();
            checkDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            hKLDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            calcXDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            functionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            xDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            xErrDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fWHMDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            intensityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            weightDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            R = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            copyToClipboradToolStripMenuItem = new ToolStripMenuItem();
            bindingSourcePlanes = new BindingSource(components);
            buttonSendToCellFinder = new Button();
            useForCalcDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            buttonRemovePeaks = new Button();
            groupBox4 = new GroupBox();
            textBoxRemovedProfileName = new TextBox();
            label4 = new Label();
            groupBox5 = new GroupBox();
            toolTip = new ToolTip(components);
            buttonSaveTableAsCSV = new Button();
            numericBoxEffectiveDigit = new Crystallography.Controls.NumericBox();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            flowLayoutPanelPatternDecomposition.SuspendLayout();
            groupBox2.SuspendLayout();
            panelFWHM.SuspendLayout();
            ((ISupportInitialize)numericUpDownInitialFWHM).BeginInit();
            ((ISupportInitialize)numericUpDownSearchRange).BeginInit();
            ((ISupportInitialize)dataGridViewCrystals).BeginInit();
            ((ISupportInitialize)bindingSourceCrystals).BeginInit();
            ((ISupportInitialize)dataSet).BeginInit();
            ((ISupportInitialize)dataGridViewPlaneList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((ISupportInitialize)bindingSourcePlanes).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(textBoxGamma_err);
            groupBox1.Controls.Add(textBoxAlpha_err);
            groupBox1.Controls.Add(textBoxBeta_err);
            groupBox1.Controls.Add(textBoxC_err);
            groupBox1.Controls.Add(textBoxB_err);
            groupBox1.Controls.Add(textBoxV);
            groupBox1.Controls.Add(textBoxV_err);
            groupBox1.Controls.Add(textBoxC);
            groupBox1.Controls.Add(textBoxGamma);
            groupBox1.Controls.Add(textBoxA_err);
            groupBox1.Controls.Add(textBoxA);
            groupBox1.Controls.Add(label26);
            groupBox1.Controls.Add(label25);
            groupBox1.Controls.Add(label24);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label29);
            groupBox1.Controls.Add(label23);
            groupBox1.Controls.Add(label22);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(label27);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(textBoxB);
            groupBox1.Controls.Add(textBoxAlpha);
            groupBox1.Controls.Add(textBoxBeta);
            groupBox1.Controls.Add(buttonResetTakeoffAngle);
            groupBox1.Controls.Add(buttonCopyCellConstantsToClipboard);
            groupBox1.Controls.Add(buttonConfirm);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label28);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label16);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            toolTip.SetToolTip(groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // textBoxGamma_err
            // 
            resources.ApplyResources(textBoxGamma_err, "textBoxGamma_err");
            textBoxGamma_err.Name = "textBoxGamma_err";
            textBoxGamma_err.ReadOnly = true;
            toolTip.SetToolTip(textBoxGamma_err, resources.GetString("textBoxGamma_err.ToolTip"));
            // 
            // textBoxAlpha_err
            // 
            resources.ApplyResources(textBoxAlpha_err, "textBoxAlpha_err");
            textBoxAlpha_err.ForeColor = SystemColors.WindowText;
            textBoxAlpha_err.Name = "textBoxAlpha_err";
            textBoxAlpha_err.ReadOnly = true;
            toolTip.SetToolTip(textBoxAlpha_err, resources.GetString("textBoxAlpha_err.ToolTip"));
            // 
            // textBoxBeta_err
            // 
            resources.ApplyResources(textBoxBeta_err, "textBoxBeta_err");
            textBoxBeta_err.Name = "textBoxBeta_err";
            textBoxBeta_err.ReadOnly = true;
            toolTip.SetToolTip(textBoxBeta_err, resources.GetString("textBoxBeta_err.ToolTip"));
            // 
            // textBoxC_err
            // 
            resources.ApplyResources(textBoxC_err, "textBoxC_err");
            textBoxC_err.Name = "textBoxC_err";
            textBoxC_err.ReadOnly = true;
            toolTip.SetToolTip(textBoxC_err, resources.GetString("textBoxC_err.ToolTip"));
            // 
            // textBoxB_err
            // 
            resources.ApplyResources(textBoxB_err, "textBoxB_err");
            textBoxB_err.Name = "textBoxB_err";
            textBoxB_err.ReadOnly = true;
            toolTip.SetToolTip(textBoxB_err, resources.GetString("textBoxB_err.ToolTip"));
            // 
            // textBoxV
            // 
            resources.ApplyResources(textBoxV, "textBoxV");
            textBoxV.Name = "textBoxV";
            textBoxV.ReadOnly = true;
            toolTip.SetToolTip(textBoxV, resources.GetString("textBoxV.ToolTip"));
            // 
            // textBoxV_err
            // 
            resources.ApplyResources(textBoxV_err, "textBoxV_err");
            textBoxV_err.Name = "textBoxV_err";
            textBoxV_err.ReadOnly = true;
            toolTip.SetToolTip(textBoxV_err, resources.GetString("textBoxV_err.ToolTip"));
            // 
            // textBoxC
            // 
            resources.ApplyResources(textBoxC, "textBoxC");
            textBoxC.Name = "textBoxC";
            textBoxC.ReadOnly = true;
            toolTip.SetToolTip(textBoxC, resources.GetString("textBoxC.ToolTip"));
            // 
            // textBoxGamma
            // 
            resources.ApplyResources(textBoxGamma, "textBoxGamma");
            textBoxGamma.Name = "textBoxGamma";
            textBoxGamma.ReadOnly = true;
            toolTip.SetToolTip(textBoxGamma, resources.GetString("textBoxGamma.ToolTip"));
            // 
            // textBoxA_err
            // 
            resources.ApplyResources(textBoxA_err, "textBoxA_err");
            textBoxA_err.Name = "textBoxA_err";
            textBoxA_err.ReadOnly = true;
            toolTip.SetToolTip(textBoxA_err, resources.GetString("textBoxA_err.ToolTip"));
            textBoxA_err.TextChanged += textBoxA_TextChanged;
            // 
            // textBoxA
            // 
            resources.ApplyResources(textBoxA, "textBoxA");
            textBoxA.Name = "textBoxA";
            textBoxA.ReadOnly = true;
            toolTip.SetToolTip(textBoxA, resources.GetString("textBoxA.ToolTip"));
            textBoxA.TextChanged += textBoxA_TextChanged;
            // 
            // label26
            // 
            resources.ApplyResources(label26, "label26");
            label26.Name = "label26";
            toolTip.SetToolTip(label26, resources.GetString("label26.ToolTip"));
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            toolTip.SetToolTip(label25, resources.GetString("label25.ToolTip"));
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
            toolTip.SetToolTip(label24, resources.GetString("label24.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            toolTip.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // label29
            // 
            resources.ApplyResources(label29, "label29");
            label29.Name = "label29";
            toolTip.SetToolTip(label29, resources.GetString("label29.ToolTip"));
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            toolTip.SetToolTip(label23, resources.GetString("label23.ToolTip"));
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            toolTip.SetToolTip(label22, resources.GetString("label22.ToolTip"));
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            toolTip.SetToolTip(label21, resources.GetString("label21.ToolTip"));
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            toolTip.SetToolTip(label10, resources.GetString("label10.ToolTip"));
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.Name = "label20";
            toolTip.SetToolTip(label20, resources.GetString("label20.ToolTip"));
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            toolTip.SetToolTip(label19, resources.GetString("label19.ToolTip"));
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            toolTip.SetToolTip(label17, resources.GetString("label17.ToolTip"));
            // 
            // label27
            // 
            resources.ApplyResources(label27, "label27");
            label27.Name = "label27";
            toolTip.SetToolTip(label27, resources.GetString("label27.ToolTip"));
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            toolTip.SetToolTip(label11, resources.GetString("label11.ToolTip"));
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            toolTip.SetToolTip(label9, resources.GetString("label9.ToolTip"));
            // 
            // textBoxB
            // 
            resources.ApplyResources(textBoxB, "textBoxB");
            textBoxB.Name = "textBoxB";
            textBoxB.ReadOnly = true;
            toolTip.SetToolTip(textBoxB, resources.GetString("textBoxB.ToolTip"));
            // 
            // textBoxAlpha
            // 
            resources.ApplyResources(textBoxAlpha, "textBoxAlpha");
            textBoxAlpha.ForeColor = SystemColors.WindowText;
            textBoxAlpha.Name = "textBoxAlpha";
            textBoxAlpha.ReadOnly = true;
            toolTip.SetToolTip(textBoxAlpha, resources.GetString("textBoxAlpha.ToolTip"));
            // 
            // textBoxBeta
            // 
            resources.ApplyResources(textBoxBeta, "textBoxBeta");
            textBoxBeta.Name = "textBoxBeta";
            textBoxBeta.ReadOnly = true;
            toolTip.SetToolTip(textBoxBeta, resources.GetString("textBoxBeta.ToolTip"));
            // 
            // buttonResetTakeoffAngle
            // 
            resources.ApplyResources(buttonResetTakeoffAngle, "buttonResetTakeoffAngle");
            buttonResetTakeoffAngle.Name = "buttonResetTakeoffAngle";
            toolTip.SetToolTip(buttonResetTakeoffAngle, resources.GetString("buttonResetTakeoffAngle.ToolTip"));
            buttonResetTakeoffAngle.Click += buttonResetTakeoffAngle_Click;
            // 
            // buttonCopyCellConstantsToClipboard
            // 
            resources.ApplyResources(buttonCopyCellConstantsToClipboard, "buttonCopyCellConstantsToClipboard");
            buttonCopyCellConstantsToClipboard.Name = "buttonCopyCellConstantsToClipboard";
            toolTip.SetToolTip(buttonCopyCellConstantsToClipboard, resources.GetString("buttonCopyCellConstantsToClipboard.ToolTip"));
            buttonCopyCellConstantsToClipboard.Click += buttonCopyClipboard_Click;
            // 
            // buttonConfirm
            // 
            resources.ApplyResources(buttonConfirm, "buttonConfirm");
            buttonConfirm.Name = "buttonConfirm";
            toolTip.SetToolTip(buttonConfirm, resources.GetString("buttonConfirm.ToolTip"));
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            toolTip.SetToolTip(label8, resources.GetString("label8.ToolTip"));
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            toolTip.SetToolTip(label12, resources.GetString("label12.ToolTip"));
            // 
            // label28
            // 
            resources.ApplyResources(label28, "label28");
            label28.Name = "label28";
            toolTip.SetToolTip(label28, resources.GetString("label28.ToolTip"));
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            toolTip.SetToolTip(label13, resources.GetString("label13.ToolTip"));
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            toolTip.SetToolTip(label14, resources.GetString("label14.ToolTip"));
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            toolTip.SetToolTip(label15, resources.GetString("label15.ToolTip"));
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            toolTip.SetToolTip(label16, resources.GetString("label16.ToolTip"));
            // 
            // buttonCopyTableToClipboard
            // 
            resources.ApplyResources(buttonCopyTableToClipboard, "buttonCopyTableToClipboard");
            buttonCopyTableToClipboard.Name = "buttonCopyTableToClipboard";
            toolTip.SetToolTip(buttonCopyTableToClipboard, resources.GetString("buttonCopyTableToClipboard.ToolTip"));
            buttonCopyTableToClipboard.UseVisualStyleBackColor = true;
            buttonCopyTableToClipboard.Click += buttonCopyToClipboard_Click;
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(flowLayoutPanelPatternDecomposition);
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Controls.Add(panelFWHM);
            groupBox3.Controls.Add(checkBoxUseInitialFWHM);
            groupBox3.Controls.Add(checkBoxPatternDecomposition);
            groupBox3.Controls.Add(numericUpDownSearchRange);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(buttonApplyRangeToAll);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            toolTip.SetToolTip(groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // flowLayoutPanelPatternDecomposition
            // 
            resources.ApplyResources(flowLayoutPanelPatternDecomposition, "flowLayoutPanelPatternDecomposition");
            flowLayoutPanelPatternDecomposition.Controls.Add(radioButtonEachCrystal);
            flowLayoutPanelPatternDecomposition.Controls.Add(radioButtonBetweenCrystals);
            flowLayoutPanelPatternDecomposition.Name = "flowLayoutPanelPatternDecomposition";
            toolTip.SetToolTip(flowLayoutPanelPatternDecomposition, resources.GetString("flowLayoutPanelPatternDecomposition.ToolTip"));
            // 
            // radioButtonEachCrystal
            // 
            resources.ApplyResources(radioButtonEachCrystal, "radioButtonEachCrystal");
            radioButtonEachCrystal.Checked = true;
            radioButtonEachCrystal.Name = "radioButtonEachCrystal";
            radioButtonEachCrystal.TabStop = true;
            toolTip.SetToolTip(radioButtonEachCrystal, resources.GetString("radioButtonEachCrystal.ToolTip"));
            radioButtonEachCrystal.UseVisualStyleBackColor = true;
            radioButtonEachCrystal.CheckedChanged += radioButtonEachCrystal_CheckedChanged;
            // 
            // radioButtonBetweenCrystals
            // 
            resources.ApplyResources(radioButtonBetweenCrystals, "radioButtonBetweenCrystals");
            radioButtonBetweenCrystals.Name = "radioButtonBetweenCrystals";
            toolTip.SetToolTip(radioButtonBetweenCrystals, resources.GetString("radioButtonBetweenCrystals.ToolTip"));
            radioButtonBetweenCrystals.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(radioButtonSymmetricPearson);
            groupBox2.Controls.Add(radioButtonPseudoVoigt);
            groupBox2.Controls.Add(radioButtonSplitPseudoVoigt);
            groupBox2.Controls.Add(radioButtonSimple);
            groupBox2.Controls.Add(radioButtonSplitPearson);
            groupBox2.Controls.Add(buttonApplyFunctionToAll);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            toolTip.SetToolTip(groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // radioButtonSymmetricPearson
            // 
            resources.ApplyResources(radioButtonSymmetricPearson, "radioButtonSymmetricPearson");
            radioButtonSymmetricPearson.Name = "radioButtonSymmetricPearson";
            toolTip.SetToolTip(radioButtonSymmetricPearson, resources.GetString("radioButtonSymmetricPearson.ToolTip"));
            radioButtonSymmetricPearson.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonPseudoVoigt
            // 
            resources.ApplyResources(radioButtonPseudoVoigt, "radioButtonPseudoVoigt");
            radioButtonPseudoVoigt.Checked = true;
            radioButtonPseudoVoigt.Name = "radioButtonPseudoVoigt";
            radioButtonPseudoVoigt.TabStop = true;
            toolTip.SetToolTip(radioButtonPseudoVoigt, resources.GetString("radioButtonPseudoVoigt.ToolTip"));
            radioButtonPseudoVoigt.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonSplitPseudoVoigt
            // 
            resources.ApplyResources(radioButtonSplitPseudoVoigt, "radioButtonSplitPseudoVoigt");
            radioButtonSplitPseudoVoigt.Name = "radioButtonSplitPseudoVoigt";
            toolTip.SetToolTip(radioButtonSplitPseudoVoigt, resources.GetString("radioButtonSplitPseudoVoigt.ToolTip"));
            radioButtonSplitPseudoVoigt.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonSimple
            // 
            resources.ApplyResources(radioButtonSimple, "radioButtonSimple");
            radioButtonSimple.Name = "radioButtonSimple";
            toolTip.SetToolTip(radioButtonSimple, resources.GetString("radioButtonSimple.ToolTip"));
            radioButtonSimple.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonSplitPearson
            // 
            resources.ApplyResources(radioButtonSplitPearson, "radioButtonSplitPearson");
            radioButtonSplitPearson.Name = "radioButtonSplitPearson";
            toolTip.SetToolTip(radioButtonSplitPearson, resources.GetString("radioButtonSplitPearson.ToolTip"));
            radioButtonSplitPearson.CheckedChanged += radioButton_CheckedChanged;
            // 
            // buttonApplyFunctionToAll
            // 
            resources.ApplyResources(buttonApplyFunctionToAll, "buttonApplyFunctionToAll");
            buttonApplyFunctionToAll.Name = "buttonApplyFunctionToAll";
            toolTip.SetToolTip(buttonApplyFunctionToAll, resources.GetString("buttonApplyFunctionToAll.ToolTip"));
            buttonApplyFunctionToAll.Click += buttonApplyFunctionToAll_Click;
            // 
            // panelFWHM
            // 
            resources.ApplyResources(panelFWHM, "panelFWHM");
            panelFWHM.Controls.Add(numericUpDownInitialFWHM);
            panelFWHM.Controls.Add(buttonApplyFWHMToAll);
            panelFWHM.Controls.Add(label1);
            panelFWHM.Name = "panelFWHM";
            toolTip.SetToolTip(panelFWHM, resources.GetString("panelFWHM.ToolTip"));
            // 
            // numericUpDownInitialFWHM
            // 
            resources.ApplyResources(numericUpDownInitialFWHM, "numericUpDownInitialFWHM");
            numericUpDownInitialFWHM.DecimalPlaces = 3;
            numericUpDownInitialFWHM.Increment = new decimal(new int[] { 2, 0, 0, 131072 });
            numericUpDownInitialFWHM.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownInitialFWHM.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownInitialFWHM.Name = "numericUpDownInitialFWHM";
            toolTip.SetToolTip(numericUpDownInitialFWHM, resources.GetString("numericUpDownInitialFWHM.ToolTip"));
            numericUpDownInitialFWHM.Value = new decimal(new int[] { 6, 0, 0, 131072 });
            numericUpDownInitialFWHM.ValueChanged += numericUpDownSearchRange_ValueChanged;
            // 
            // buttonApplyFWHMToAll
            // 
            resources.ApplyResources(buttonApplyFWHMToAll, "buttonApplyFWHMToAll");
            buttonApplyFWHMToAll.Name = "buttonApplyFWHMToAll";
            toolTip.SetToolTip(buttonApplyFWHMToAll, resources.GetString("buttonApplyFWHMToAll.ToolTip"));
            buttonApplyFWHMToAll.Click += buttonApplyFWHMToAll_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            toolTip.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            // 
            // checkBoxUseInitialFWHM
            // 
            resources.ApplyResources(checkBoxUseInitialFWHM, "checkBoxUseInitialFWHM");
            checkBoxUseInitialFWHM.Name = "checkBoxUseInitialFWHM";
            toolTip.SetToolTip(checkBoxUseInitialFWHM, resources.GetString("checkBoxUseInitialFWHM.ToolTip"));
            checkBoxUseInitialFWHM.UseVisualStyleBackColor = true;
            checkBoxUseInitialFWHM.CheckedChanged += checkBoxUseInitialFWHM_CheckedChanged;
            // 
            // checkBoxPatternDecomposition
            // 
            resources.ApplyResources(checkBoxPatternDecomposition, "checkBoxPatternDecomposition");
            checkBoxPatternDecomposition.Name = "checkBoxPatternDecomposition";
            toolTip.SetToolTip(checkBoxPatternDecomposition, resources.GetString("checkBoxPatternDecomposition.ToolTip"));
            checkBoxPatternDecomposition.UseVisualStyleBackColor = true;
            checkBoxPatternDecomposition.CheckedChanged += checkBoxPatternDecomposition_CheckedChanged;
            // 
            // numericUpDownSearchRange
            // 
            resources.ApplyResources(numericUpDownSearchRange, "numericUpDownSearchRange");
            numericUpDownSearchRange.DecimalPlaces = 3;
            numericUpDownSearchRange.Increment = new decimal(new int[] { 2, 0, 0, 131072 });
            numericUpDownSearchRange.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownSearchRange.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownSearchRange.Name = "numericUpDownSearchRange";
            toolTip.SetToolTip(numericUpDownSearchRange, resources.GetString("numericUpDownSearchRange.ToolTip"));
            numericUpDownSearchRange.Value = new decimal(new int[] { 6, 0, 0, 131072 });
            numericUpDownSearchRange.ValueChanged += numericUpDownSearchRange_ValueChanged;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            toolTip.SetToolTip(label7, resources.GetString("label7.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            toolTip.SetToolTip(label18, resources.GetString("label18.ToolTip"));
            // 
            // buttonApplyRangeToAll
            // 
            resources.ApplyResources(buttonApplyRangeToAll, "buttonApplyRangeToAll");
            buttonApplyRangeToAll.Name = "buttonApplyRangeToAll";
            toolTip.SetToolTip(buttonApplyRangeToAll, resources.GetString("buttonApplyRangeToAll.ToolTip"));
            buttonApplyRangeToAll.Click += buttonApplyRangeToAll_Click;
            // 
            // dataGridViewCrystals
            // 
            resources.ApplyResources(dataGridViewCrystals, "dataGridViewCrystals");
            dataGridViewCrystals.AllowUserToAddRows = false;
            dataGridViewCrystals.AllowUserToDeleteRows = false;
            dataGridViewCrystals.AllowUserToResizeColumns = false;
            dataGridViewCrystals.AllowUserToResizeRows = false;
            dataGridViewCrystals.AutoGenerateColumns = false;
            dataGridViewCrystals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCrystals.ColumnHeadersVisible = false;
            dataGridViewCrystals.Columns.AddRange(new DataGridViewColumn[] { Check, PeakColor, crystalDataGridViewTextBoxColumn });
            dataGridViewCrystals.DataSource = bindingSourceCrystals;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewCrystals.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCrystals.MultiSelect = false;
            dataGridViewCrystals.Name = "dataGridViewCrystals";
            dataGridViewCrystals.ReadOnly = true;
            dataGridViewCrystals.RowHeadersVisible = false;
            dataGridViewCrystals.RowTemplate.Height = 21;
            dataGridViewCrystals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            toolTip.SetToolTip(dataGridViewCrystals, resources.GetString("dataGridViewCrystals.ToolTip"));
            dataGridViewCrystals.CellMouseClick += dataGridViewCrystals_CellMouseClick;
            dataGridViewCrystals.CellMouseDoubleClick += dataGridViewCrystals_CellMouseClick;
            dataGridViewCrystals.KeyDown += dataGridViewCrystals_KeyDown;
            // 
            // Check
            // 
            Check.DataPropertyName = "Check";
            resources.ApplyResources(Check, "Check");
            Check.Name = "Check";
            Check.ReadOnly = true;
            // 
            // PeakColor
            // 
            PeakColor.DataPropertyName = "PeakColor";
            resources.ApplyResources(PeakColor, "PeakColor");
            PeakColor.Name = "PeakColor";
            PeakColor.ReadOnly = true;
            PeakColor.Resizable = DataGridViewTriState.True;
            PeakColor.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // crystalDataGridViewTextBoxColumn
            // 
            crystalDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            crystalDataGridViewTextBoxColumn.DataPropertyName = "Crystal";
            resources.ApplyResources(crystalDataGridViewTextBoxColumn, "crystalDataGridViewTextBoxColumn");
            crystalDataGridViewTextBoxColumn.Name = "crystalDataGridViewTextBoxColumn";
            crystalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceCrystals
            // 
            bindingSourceCrystals.DataMember = "DataTableCrystal";
            bindingSourceCrystals.DataSource = dataSet;
            // 
            // dataSet
            // 
            dataSet.DataSetName = "DataSet";
            dataSet.Namespace = "http://tempuri.org/DataSet1.xsd";
            dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewPlaneList
            // 
            resources.ApplyResources(dataGridViewPlaneList, "dataGridViewPlaneList");
            dataGridViewPlaneList.AllowUserToAddRows = false;
            dataGridViewPlaneList.AllowUserToDeleteRows = false;
            dataGridViewPlaneList.AllowUserToResizeColumns = false;
            dataGridViewPlaneList.AllowUserToResizeRows = false;
            dataGridViewPlaneList.AutoGenerateColumns = false;
            dataGridViewPlaneList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewPlaneList.Columns.AddRange(new DataGridViewColumn[] { checkDataGridViewCheckBoxColumn, hKLDataGridViewTextBoxColumn, calcXDataGridViewTextBoxColumn, functionDataGridViewTextBoxColumn, xDataGridViewTextBoxColumn, xErrDataGridViewTextBoxColumn, fWHMDataGridViewTextBoxColumn, intensityDataGridViewTextBoxColumn, weightDataGridViewTextBoxColumn, R });
            dataGridViewPlaneList.ContextMenuStrip = contextMenuStrip1;
            dataGridViewPlaneList.DataSource = bindingSourcePlanes;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.Format = "G5";
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dataGridViewPlaneList.DefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewPlaneList.MultiSelect = false;
            dataGridViewPlaneList.Name = "dataGridViewPlaneList";
            dataGridViewPlaneList.RowHeadersVisible = false;
            dataGridViewPlaneList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewPlaneList.RowTemplate.Height = 21;
            dataGridViewPlaneList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            toolTip.SetToolTip(dataGridViewPlaneList, resources.GetString("dataGridViewPlaneList.ToolTip"));
            dataGridViewPlaneList.CellContentClick += dataGridViewPlanes_CellContentClick;
            dataGridViewPlaneList.SelectionChanged += dataGridViewPlaneList_SelectionChanged;
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            resources.ApplyResources(checkDataGridViewCheckBoxColumn, "checkDataGridViewCheckBoxColumn");
            checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            // 
            // hKLDataGridViewTextBoxColumn
            // 
            hKLDataGridViewTextBoxColumn.DataPropertyName = "HKL";
            resources.ApplyResources(hKLDataGridViewTextBoxColumn, "hKLDataGridViewTextBoxColumn");
            hKLDataGridViewTextBoxColumn.Name = "hKLDataGridViewTextBoxColumn";
            hKLDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // calcXDataGridViewTextBoxColumn
            // 
            calcXDataGridViewTextBoxColumn.DataPropertyName = "CalcX";
            dataGridViewCellStyle2.NullValue = null;
            calcXDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(calcXDataGridViewTextBoxColumn, "calcXDataGridViewTextBoxColumn");
            calcXDataGridViewTextBoxColumn.Name = "calcXDataGridViewTextBoxColumn";
            calcXDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // functionDataGridViewTextBoxColumn
            // 
            functionDataGridViewTextBoxColumn.DataPropertyName = "Function";
            resources.ApplyResources(functionDataGridViewTextBoxColumn, "functionDataGridViewTextBoxColumn");
            functionDataGridViewTextBoxColumn.Name = "functionDataGridViewTextBoxColumn";
            functionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xDataGridViewTextBoxColumn
            // 
            xDataGridViewTextBoxColumn.DataPropertyName = "X";
            dataGridViewCellStyle3.NullValue = null;
            xDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(xDataGridViewTextBoxColumn, "xDataGridViewTextBoxColumn");
            xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
            xDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xErrDataGridViewTextBoxColumn
            // 
            xErrDataGridViewTextBoxColumn.DataPropertyName = "XErr";
            dataGridViewCellStyle4.NullValue = null;
            xErrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(xErrDataGridViewTextBoxColumn, "xErrDataGridViewTextBoxColumn");
            xErrDataGridViewTextBoxColumn.Name = "xErrDataGridViewTextBoxColumn";
            xErrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fWHMDataGridViewTextBoxColumn
            // 
            fWHMDataGridViewTextBoxColumn.DataPropertyName = "FWHM";
            dataGridViewCellStyle5.NullValue = null;
            fWHMDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(fWHMDataGridViewTextBoxColumn, "fWHMDataGridViewTextBoxColumn");
            fWHMDataGridViewTextBoxColumn.Name = "fWHMDataGridViewTextBoxColumn";
            fWHMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // intensityDataGridViewTextBoxColumn
            // 
            intensityDataGridViewTextBoxColumn.DataPropertyName = "Intensity";
            dataGridViewCellStyle6.NullValue = null;
            intensityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(intensityDataGridViewTextBoxColumn, "intensityDataGridViewTextBoxColumn");
            intensityDataGridViewTextBoxColumn.Name = "intensityDataGridViewTextBoxColumn";
            intensityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // weightDataGridViewTextBoxColumn
            // 
            weightDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            dataGridViewCellStyle7.NullValue = null;
            weightDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(weightDataGridViewTextBoxColumn, "weightDataGridViewTextBoxColumn");
            weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            weightDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // R
            // 
            R.DataPropertyName = "R";
            dataGridViewCellStyle8.NullValue = null;
            R.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(R, "R");
            R.Name = "R";
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { copyToClipboradToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            toolTip.SetToolTip(contextMenuStrip1, resources.GetString("contextMenuStrip1.ToolTip"));
            // 
            // copyToClipboradToolStripMenuItem
            // 
            resources.ApplyResources(copyToClipboradToolStripMenuItem, "copyToClipboradToolStripMenuItem");
            copyToClipboradToolStripMenuItem.Name = "copyToClipboradToolStripMenuItem";
            copyToClipboradToolStripMenuItem.Click += copyToClipboradToolStripMenuItem_Click;
            // 
            // bindingSourcePlanes
            // 
            bindingSourcePlanes.AllowNew = false;
            bindingSourcePlanes.DataMember = "DataTablePeakFitting";
            bindingSourcePlanes.DataSource = dataSet;
            // 
            // buttonSendToCellFinder
            // 
            resources.ApplyResources(buttonSendToCellFinder, "buttonSendToCellFinder");
            buttonSendToCellFinder.Name = "buttonSendToCellFinder";
            toolTip.SetToolTip(buttonSendToCellFinder, resources.GetString("buttonSendToCellFinder.ToolTip"));
            buttonSendToCellFinder.UseVisualStyleBackColor = true;
            buttonSendToCellFinder.Click += buttonSendToCellFinder_Click;
            // 
            // useForCalcDataGridViewCheckBoxColumn
            // 
            useForCalcDataGridViewCheckBoxColumn.DataPropertyName = "Use for Calc.";
            resources.ApplyResources(useForCalcDataGridViewCheckBoxColumn, "useForCalcDataGridViewCheckBoxColumn");
            useForCalcDataGridViewCheckBoxColumn.Name = "useForCalcDataGridViewCheckBoxColumn";
            // 
            // buttonRemovePeaks
            // 
            resources.ApplyResources(buttonRemovePeaks, "buttonRemovePeaks");
            buttonRemovePeaks.Name = "buttonRemovePeaks";
            toolTip.SetToolTip(buttonRemovePeaks, resources.GetString("buttonRemovePeaks.ToolTip"));
            buttonRemovePeaks.UseVisualStyleBackColor = true;
            buttonRemovePeaks.Click += buttonRemovePeaks_Click;
            // 
            // groupBox4
            // 
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Controls.Add(textBoxRemovedProfileName);
            groupBox4.Controls.Add(buttonRemovePeaks);
            groupBox4.Controls.Add(label4);
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            toolTip.SetToolTip(groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // textBoxRemovedProfileName
            // 
            resources.ApplyResources(textBoxRemovedProfileName, "textBoxRemovedProfileName");
            textBoxRemovedProfileName.Name = "textBoxRemovedProfileName";
            toolTip.SetToolTip(textBoxRemovedProfileName, resources.GetString("textBoxRemovedProfileName.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            toolTip.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // groupBox5
            // 
            resources.ApplyResources(groupBox5, "groupBox5");
            groupBox5.Controls.Add(buttonSendToCellFinder);
            groupBox5.Name = "groupBox5";
            groupBox5.TabStop = false;
            toolTip.SetToolTip(groupBox5, resources.GetString("groupBox5.ToolTip"));
            // 
            // buttonSaveTableAsCSV
            // 
            resources.ApplyResources(buttonSaveTableAsCSV, "buttonSaveTableAsCSV");
            buttonSaveTableAsCSV.Name = "buttonSaveTableAsCSV";
            toolTip.SetToolTip(buttonSaveTableAsCSV, resources.GetString("buttonSaveTableAsCSV.ToolTip"));
            buttonSaveTableAsCSV.UseVisualStyleBackColor = true;
            buttonSaveTableAsCSV.Click += ButtonSaveTableAsCSV_Click;
            // 
            // numericBoxEffectiveDigit
            // 
            resources.ApplyResources(numericBoxEffectiveDigit, "numericBoxEffectiveDigit");
            numericBoxEffectiveDigit.BackColor = SystemColors.Control;
            numericBoxEffectiveDigit.FooterBackColor = SystemColors.Control;
            numericBoxEffectiveDigit.HeaderBackColor = SystemColors.Control;
            numericBoxEffectiveDigit.Maximum = 16D;
            numericBoxEffectiveDigit.Minimum = 1D;
            numericBoxEffectiveDigit.Name = "numericBoxEffectiveDigit";
            numericBoxEffectiveDigit.RadianValue = 0.087266462599716474D;
            numericBoxEffectiveDigit.RoundErrorAccuracy = -1;
            numericBoxEffectiveDigit.ShowUpDown = true;
            numericBoxEffectiveDigit.SkipEventDuringInput = false;
            numericBoxEffectiveDigit.TextFont = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericBoxEffectiveDigit.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxEffectiveDigit, resources.GetString("numericBoxEffectiveDigit.ToolTip"));
            numericBoxEffectiveDigit.Value = 5D;
            numericBoxEffectiveDigit.ValueChanged += NumericBoxEffectiveDigit_ValueChanged;
            // 
            // FormFitting
            // 
            resources.ApplyResources(this, "$this");
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(numericBoxEffectiveDigit);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(buttonSaveTableAsCSV);
            Controls.Add(buttonCopyTableToClipboard);
            Controls.Add(groupBox3);
            Controls.Add(dataGridViewPlaneList);
            Controls.Add(groupBox1);
            Controls.Add(dataGridViewCrystals);
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FormFitting";
            toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            Closed += FormFitting_Closed;
            FormClosing += FormFitting_FormClosing;
            VisibleChanged += FormFitting_VisibleChanged;
            DragDrop += FormFitting_DragDrop;
            DragEnter += FormFitting_DragEnter;
            KeyDown += FormFitting_KeyDown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            flowLayoutPanelPatternDecomposition.ResumeLayout(false);
            flowLayoutPanelPatternDecomposition.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panelFWHM.ResumeLayout(false);
            panelFWHM.PerformLayout();
            ((ISupportInitialize)numericUpDownInitialFWHM).EndInit();
            ((ISupportInitialize)numericUpDownSearchRange).EndInit();
            ((ISupportInitialize)dataGridViewCrystals).EndInit();
            ((ISupportInitialize)bindingSourceCrystals).EndInit();
            ((ISupportInitialize)dataSet).EndInit();
            ((ISupportInitialize)dataGridViewPlaneList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((ISupportInitialize)bindingSourcePlanes).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private Button buttonSendToCellFinder;
        public DataSet dataSet;
        private Button buttonApplyRangeToAll;
        private NumericUpDown numericUpDownInitialFWHM;
        private Button buttonApplyFWHMToAll;
        private CheckBox checkBoxUseInitialFWHM;
        private Panel panelFWHM;
        private Label label1;
        private DataGridViewCheckBoxColumn useForCalcDataGridViewCheckBoxColumn;
        private Button buttonRemovePeaks;
        private Label label3;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private TextBox textBoxRemovedProfileName;
        private Label label4;
        private GroupBox groupBox5;
        private ToolTip toolTip;
        private DataGridViewCheckBoxColumn Check;
        private DataGridViewImageColumn PeakColor;
        private DataGridViewTextBoxColumn crystalDataGridViewTextBoxColumn;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem copyToClipboradToolStripMenuItem;
        private Button buttonCopyCellConstantsToClipboard;
        public BindingSource bindingSourcePlanes;
        private Button buttonApplyFunctionToAll;
        private Button buttonSaveTableAsCSV;
        private FlowLayoutPanel flowLayoutPanelPatternDecomposition;
        private DataGridViewTextBoxColumn peakObjectDataGridViewTextBoxColumn;
        public DataGridView dataGridViewPlaneList;
        private Crystallography.Controls.NumericBox numericBoxEffectiveDigit;
        private Button buttonResetTakeoffAngle;
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
        public NumericUpDown numericUpDownSearchRange;
    }


}