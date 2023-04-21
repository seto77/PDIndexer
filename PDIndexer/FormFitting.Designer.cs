using System.ComponentModel;
using System.Windows.Forms;
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
            numericBoxSearchRange = new Crystallography.Controls.NumericBox();
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
            buttonApplyFWHMToAll = new Button();
            label1 = new Label();
            checkBoxUseInitialFWHM = new CheckBox();
            checkBoxPatternDecomposition = new CheckBox();
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
            buttonClearPeaks = new Button();
            numericBoxInitialFWHM = new Crystallography.Controls.NumericBox();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            flowLayoutPanelPatternDecomposition.SuspendLayout();
            groupBox2.SuspendLayout();
            panelFWHM.SuspendLayout();
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
            // 
            // textBoxGamma_err
            // 
            resources.ApplyResources(textBoxGamma_err, "textBoxGamma_err");
            textBoxGamma_err.Name = "textBoxGamma_err";
            textBoxGamma_err.ReadOnly = true;
            // 
            // textBoxAlpha_err
            // 
            resources.ApplyResources(textBoxAlpha_err, "textBoxAlpha_err");
            textBoxAlpha_err.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAlpha_err.Name = "textBoxAlpha_err";
            textBoxAlpha_err.ReadOnly = true;
            // 
            // textBoxBeta_err
            // 
            resources.ApplyResources(textBoxBeta_err, "textBoxBeta_err");
            textBoxBeta_err.Name = "textBoxBeta_err";
            textBoxBeta_err.ReadOnly = true;
            // 
            // textBoxC_err
            // 
            resources.ApplyResources(textBoxC_err, "textBoxC_err");
            textBoxC_err.Name = "textBoxC_err";
            textBoxC_err.ReadOnly = true;
            // 
            // textBoxB_err
            // 
            resources.ApplyResources(textBoxB_err, "textBoxB_err");
            textBoxB_err.Name = "textBoxB_err";
            textBoxB_err.ReadOnly = true;
            // 
            // textBoxV
            // 
            resources.ApplyResources(textBoxV, "textBoxV");
            textBoxV.Name = "textBoxV";
            textBoxV.ReadOnly = true;
            // 
            // textBoxV_err
            // 
            resources.ApplyResources(textBoxV_err, "textBoxV_err");
            textBoxV_err.Name = "textBoxV_err";
            textBoxV_err.ReadOnly = true;
            // 
            // textBoxC
            // 
            resources.ApplyResources(textBoxC, "textBoxC");
            textBoxC.Name = "textBoxC";
            textBoxC.ReadOnly = true;
            // 
            // textBoxGamma
            // 
            resources.ApplyResources(textBoxGamma, "textBoxGamma");
            textBoxGamma.Name = "textBoxGamma";
            textBoxGamma.ReadOnly = true;
            // 
            // textBoxA_err
            // 
            resources.ApplyResources(textBoxA_err, "textBoxA_err");
            textBoxA_err.Name = "textBoxA_err";
            textBoxA_err.ReadOnly = true;
            textBoxA_err.TextChanged += textBoxA_TextChanged;
            // 
            // textBoxA
            // 
            resources.ApplyResources(textBoxA, "textBoxA");
            textBoxA.Name = "textBoxA";
            textBoxA.ReadOnly = true;
            textBoxA.TextChanged += textBoxA_TextChanged;
            // 
            // label26
            // 
            resources.ApplyResources(label26, "label26");
            label26.Name = "label26";
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label29
            // 
            resources.ApplyResources(label29, "label29");
            label29.Name = "label29";
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.Name = "label20";
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            // 
            // label27
            // 
            resources.ApplyResources(label27, "label27");
            label27.Name = "label27";
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // textBoxB
            // 
            resources.ApplyResources(textBoxB, "textBoxB");
            textBoxB.Name = "textBoxB";
            textBoxB.ReadOnly = true;
            // 
            // textBoxAlpha
            // 
            resources.ApplyResources(textBoxAlpha, "textBoxAlpha");
            textBoxAlpha.ForeColor = System.Drawing.SystemColors.WindowText;
            textBoxAlpha.Name = "textBoxAlpha";
            textBoxAlpha.ReadOnly = true;
            // 
            // textBoxBeta
            // 
            resources.ApplyResources(textBoxBeta, "textBoxBeta");
            textBoxBeta.Name = "textBoxBeta";
            textBoxBeta.ReadOnly = true;
            // 
            // buttonResetTakeoffAngle
            // 
            resources.ApplyResources(buttonResetTakeoffAngle, "buttonResetTakeoffAngle");
            buttonResetTakeoffAngle.Name = "buttonResetTakeoffAngle";
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
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            // 
            // label28
            // 
            resources.ApplyResources(label28, "label28");
            label28.Name = "label28";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
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
            groupBox3.Controls.Add(numericBoxSearchRange);
            groupBox3.Controls.Add(flowLayoutPanelPatternDecomposition);
            groupBox3.Controls.Add(groupBox2);
            groupBox3.Controls.Add(panelFWHM);
            groupBox3.Controls.Add(checkBoxUseInitialFWHM);
            groupBox3.Controls.Add(checkBoxPatternDecomposition);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(buttonApplyRangeToAll);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // numericBoxSearchRange
            // 
            numericBoxSearchRange.BackColor = System.Drawing.Color.Transparent;
            numericBoxSearchRange.DecimalPlaces = 3;
            resources.ApplyResources(numericBoxSearchRange, "numericBoxSearchRange");
            numericBoxSearchRange.Minimum = 0D;
            numericBoxSearchRange.Name = "numericBoxSearchRange";
            numericBoxSearchRange.RadianValue = 0.0010471975511965976D;
            numericBoxSearchRange.RoundErrorAccuracy = -1;
            numericBoxSearchRange.ShowUpDown = true;
            numericBoxSearchRange.SmartIncrement = true;
            numericBoxSearchRange.Value = 0.06D;
            numericBoxSearchRange.ValueChanged += numericUpDownSearchRange_ValueChanged;
            // 
            // flowLayoutPanelPatternDecomposition
            // 
            resources.ApplyResources(flowLayoutPanelPatternDecomposition, "flowLayoutPanelPatternDecomposition");
            flowLayoutPanelPatternDecomposition.Controls.Add(radioButtonEachCrystal);
            flowLayoutPanelPatternDecomposition.Controls.Add(radioButtonBetweenCrystals);
            flowLayoutPanelPatternDecomposition.Name = "flowLayoutPanelPatternDecomposition";
            // 
            // radioButtonEachCrystal
            // 
            resources.ApplyResources(radioButtonEachCrystal, "radioButtonEachCrystal");
            radioButtonEachCrystal.Checked = true;
            radioButtonEachCrystal.Name = "radioButtonEachCrystal";
            radioButtonEachCrystal.TabStop = true;
            radioButtonEachCrystal.UseVisualStyleBackColor = true;
            radioButtonEachCrystal.CheckedChanged += radioButtonEachCrystal_CheckedChanged;
            // 
            // radioButtonBetweenCrystals
            // 
            resources.ApplyResources(radioButtonBetweenCrystals, "radioButtonBetweenCrystals");
            radioButtonBetweenCrystals.Name = "radioButtonBetweenCrystals";
            radioButtonBetweenCrystals.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButtonSymmetricPearson);
            groupBox2.Controls.Add(radioButtonPseudoVoigt);
            groupBox2.Controls.Add(radioButtonSplitPseudoVoigt);
            groupBox2.Controls.Add(radioButtonSimple);
            groupBox2.Controls.Add(radioButtonSplitPearson);
            groupBox2.Controls.Add(buttonApplyFunctionToAll);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // radioButtonSymmetricPearson
            // 
            resources.ApplyResources(radioButtonSymmetricPearson, "radioButtonSymmetricPearson");
            radioButtonSymmetricPearson.Name = "radioButtonSymmetricPearson";
            radioButtonSymmetricPearson.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonPseudoVoigt
            // 
            resources.ApplyResources(radioButtonPseudoVoigt, "radioButtonPseudoVoigt");
            radioButtonPseudoVoigt.Checked = true;
            radioButtonPseudoVoigt.Name = "radioButtonPseudoVoigt";
            radioButtonPseudoVoigt.TabStop = true;
            radioButtonPseudoVoigt.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonSplitPseudoVoigt
            // 
            resources.ApplyResources(radioButtonSplitPseudoVoigt, "radioButtonSplitPseudoVoigt");
            radioButtonSplitPseudoVoigt.Name = "radioButtonSplitPseudoVoigt";
            radioButtonSplitPseudoVoigt.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonSimple
            // 
            resources.ApplyResources(radioButtonSimple, "radioButtonSimple");
            radioButtonSimple.Name = "radioButtonSimple";
            radioButtonSimple.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonSplitPearson
            // 
            resources.ApplyResources(radioButtonSplitPearson, "radioButtonSplitPearson");
            radioButtonSplitPearson.Name = "radioButtonSplitPearson";
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
            panelFWHM.Controls.Add(numericBoxInitialFWHM);
            panelFWHM.Controls.Add(buttonApplyFWHMToAll);
            panelFWHM.Controls.Add(label1);
            resources.ApplyResources(panelFWHM, "panelFWHM");
            panelFWHM.Name = "panelFWHM";
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
            // 
            // checkBoxUseInitialFWHM
            // 
            resources.ApplyResources(checkBoxUseInitialFWHM, "checkBoxUseInitialFWHM");
            checkBoxUseInitialFWHM.Name = "checkBoxUseInitialFWHM";
            checkBoxUseInitialFWHM.UseVisualStyleBackColor = true;
            checkBoxUseInitialFWHM.CheckedChanged += checkBoxUseInitialFWHM_CheckedChanged;
            // 
            // checkBoxPatternDecomposition
            // 
            resources.ApplyResources(checkBoxPatternDecomposition, "checkBoxPatternDecomposition");
            checkBoxPatternDecomposition.Name = "checkBoxPatternDecomposition";
            checkBoxPatternDecomposition.UseVisualStyleBackColor = true;
            checkBoxPatternDecomposition.CheckedChanged += checkBoxPatternDecomposition_CheckedChanged;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
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
            dataGridViewCrystals.AllowUserToAddRows = false;
            dataGridViewCrystals.AllowUserToDeleteRows = false;
            dataGridViewCrystals.AllowUserToResizeColumns = false;
            dataGridViewCrystals.AllowUserToResizeRows = false;
            resources.ApplyResources(dataGridViewCrystals, "dataGridViewCrystals");
            dataGridViewCrystals.AutoGenerateColumns = false;
            dataGridViewCrystals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCrystals.ColumnHeadersVisible = false;
            dataGridViewCrystals.Columns.AddRange(new DataGridViewColumn[] { Check, PeakColor, crystalDataGridViewTextBoxColumn });
            dataGridViewCrystals.DataSource = bindingSourceCrystals;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewCrystals.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCrystals.MultiSelect = false;
            dataGridViewCrystals.Name = "dataGridViewCrystals";
            dataGridViewCrystals.ReadOnly = true;
            dataGridViewCrystals.RowHeadersVisible = false;
            dataGridViewCrystals.RowTemplate.Height = 21;
            dataGridViewCrystals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            dataGridViewPlaneList.AllowUserToAddRows = false;
            dataGridViewPlaneList.AllowUserToDeleteRows = false;
            dataGridViewPlaneList.AllowUserToResizeColumns = false;
            dataGridViewPlaneList.AllowUserToResizeRows = false;
            resources.ApplyResources(dataGridViewPlaneList, "dataGridViewPlaneList");
            dataGridViewPlaneList.AutoGenerateColumns = false;
            dataGridViewPlaneList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewPlaneList.Columns.AddRange(new DataGridViewColumn[] { checkDataGridViewCheckBoxColumn, hKLDataGridViewTextBoxColumn, calcXDataGridViewTextBoxColumn, functionDataGridViewTextBoxColumn, xDataGridViewTextBoxColumn, xErrDataGridViewTextBoxColumn, fWHMDataGridViewTextBoxColumn, intensityDataGridViewTextBoxColumn, weightDataGridViewTextBoxColumn, R });
            dataGridViewPlaneList.ContextMenuStrip = contextMenuStrip1;
            dataGridViewPlaneList.DataSource = bindingSourcePlanes;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Format = "G5";
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dataGridViewPlaneList.DefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewPlaneList.MultiSelect = false;
            dataGridViewPlaneList.Name = "dataGridViewPlaneList";
            dataGridViewPlaneList.RowHeadersVisible = false;
            dataGridViewPlaneList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewPlaneList.RowTemplate.Height = 21;
            dataGridViewPlaneList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { copyToClipboradToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            // 
            // copyToClipboradToolStripMenuItem
            // 
            copyToClipboradToolStripMenuItem.Name = "copyToClipboradToolStripMenuItem";
            resources.ApplyResources(copyToClipboradToolStripMenuItem, "copyToClipboradToolStripMenuItem");
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
            // 
            // textBoxRemovedProfileName
            // 
            resources.ApplyResources(textBoxRemovedProfileName, "textBoxRemovedProfileName");
            textBoxRemovedProfileName.Name = "textBoxRemovedProfileName";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // groupBox5
            // 
            resources.ApplyResources(groupBox5, "groupBox5");
            groupBox5.Controls.Add(buttonSendToCellFinder);
            groupBox5.Name = "groupBox5";
            groupBox5.TabStop = false;
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
            numericBoxEffectiveDigit.BackColor = System.Drawing.SystemColors.Control;
            numericBoxEffectiveDigit.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxEffectiveDigit.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxEffectiveDigit.Maximum = 16D;
            numericBoxEffectiveDigit.Minimum = 1D;
            numericBoxEffectiveDigit.Name = "numericBoxEffectiveDigit";
            numericBoxEffectiveDigit.RadianValue = 0.087266462599716474D;
            numericBoxEffectiveDigit.RoundErrorAccuracy = -1;
            numericBoxEffectiveDigit.ShowUpDown = true;
            numericBoxEffectiveDigit.SkipEventDuringInput = false;
            numericBoxEffectiveDigit.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxEffectiveDigit, resources.GetString("numericBoxEffectiveDigit.ToolTip"));
            numericBoxEffectiveDigit.Value = 5D;
            numericBoxEffectiveDigit.ValueChanged += NumericBoxEffectiveDigit_ValueChanged;
            // 
            // buttonClearPeaks
            // 
            resources.ApplyResources(buttonClearPeaks, "buttonClearPeaks");
            buttonClearPeaks.Name = "buttonClearPeaks";
            toolTip.SetToolTip(buttonClearPeaks, resources.GetString("buttonClearPeaks.ToolTip"));
            buttonClearPeaks.UseVisualStyleBackColor = true;
            buttonClearPeaks.Click += buttonClearPeaks_Click;
            // 
            // numericBoxInitialFWHM
            // 
            numericBoxInitialFWHM.BackColor = System.Drawing.Color.Transparent;
            numericBoxInitialFWHM.DecimalPlaces = 3;
            resources.ApplyResources(numericBoxInitialFWHM, "numericBoxInitialFWHM");
            numericBoxInitialFWHM.Minimum = 0D;
            numericBoxInitialFWHM.Name = "numericBoxInitialFWHM";
            numericBoxInitialFWHM.RadianValue = 0.0010471975511965976D;
            numericBoxInitialFWHM.RoundErrorAccuracy = -1;
            numericBoxInitialFWHM.ShowUpDown = true;
            numericBoxInitialFWHM.SmartIncrement = true;
            numericBoxInitialFWHM.Value = 0.06D;
            numericBoxInitialFWHM.ValueChanged += numericUpDownSearchRange_ValueChanged;
            // 
            // FormFitting
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(numericBoxEffectiveDigit);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(buttonClearPeaks);
            Controls.Add(buttonSaveTableAsCSV);
            Controls.Add(buttonCopyTableToClipboard);
            Controls.Add(groupBox3);
            Controls.Add(dataGridViewPlaneList);
            Controls.Add(groupBox1);
            Controls.Add(dataGridViewCrystals);
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FormFitting";
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
        private Button buttonClearPeaks;
        public Crystallography.Controls.NumericBox numericBoxSearchRange;
        public Crystallography.Controls.NumericBox numericBoxInitialFWHM;
    }


}