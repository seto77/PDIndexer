using System;

namespace PDIndexer
{
    partial class FormProfileSetting
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfileSetting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            dataGridViewProfile = new System.Windows.Forms.DataGridView();
            bindingSourceProfile = new System.Windows.Forms.BindingSource(components);
            dataSetProfile = new DataSet();
            groupBox3 = new System.Windows.Forms.GroupBox();
            textBoxComment = new System.Windows.Forms.TextBox();
            textBoxProfileName = new System.Windows.Forms.TextBox();
            colorControlLineColor = new Crystallography.Controls.ColorControl();
            numericUpDownLineWidth = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            numericUpDownSmoothingSavitzkyAndGolayN = new System.Windows.Forms.NumericUpDown();
            numericUpDownSmoothingSavitzkyAndGolayM = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            checkBoxShowBackgroundProfile = new System.Windows.Forms.CheckBox();
            panelBackgroundReferrence = new System.Windows.Forms.Panel();
            comboBoxBackgroundReferrence = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            numericUpDownBackgroundReferrenceScale = new System.Windows.Forms.NumericUpDown();
            panelBackgroundBSpline = new System.Windows.Forms.Panel();
            buttonBackgroundAutoDetectBG = new System.Windows.Forms.Button();
            label11 = new System.Windows.Forms.Label();
            numericUpDownBgPointsNumber = new System.Windows.Forms.NumericUpDown();
            radioButtonBackgroundReferrence = new System.Windows.Forms.RadioButton();
            radioButtonBagkgroundBSpline = new System.Windows.Forms.RadioButton();
            label1 = new System.Windows.Forms.Label();
            checkBoxSmoothing = new System.Windows.Forms.CheckBox();
            checkBoxBackgroundSubtraction = new System.Windows.Forms.CheckBox();
            buttonDeleteProfile = new System.Windows.Forms.Button();
            buttonUpper = new System.Windows.Forms.Button();
            buttonLower = new System.Windows.Forms.Button();
            numericUpDownNormarizeRangeHigh = new System.Windows.Forms.NumericUpDown();
            numericUpDownNormarizeRangeLow = new System.Windows.Forms.NumericUpDown();
            buttonChangeSourceXAxis = new System.Windows.Forms.Button();
            xAxisUserControl = new Crystallography.Controls.HorizontalAxisUserControl();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label12 = new System.Windows.Forms.Label();
            numericUpDownShiftHorizontalAxis = new System.Windows.Forms.NumericUpDown();
            checkBoxShiftHorizontalAxis = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            numericalTextBoxExposureTime = new Crystallography.Controls.NumericBox();
            label24 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            radioButtonNormarizeMaximum = new System.Windows.Forms.RadioButton();
            radioButtonNormarizeAverage = new System.Windows.Forms.RadioButton();
            numericUpDownNormarizeIntensity = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage2 = new System.Windows.Forms.TabPage();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            checkBoxTwoThetaOffset = new System.Windows.Forms.CheckBox();
            panelTwoThetaOffset = new System.Windows.Forms.Panel();
            numericBoxTwhoThetaOffsetCoeff2 = new Crystallography.Controls.NumericBox();
            numericBoxTwhoThetaOffsetCoeff0 = new Crystallography.Controls.NumericBox();
            buttonTwoThetaOffsetReset = new System.Windows.Forms.Button();
            buttonTwoThetaCalibration = new System.Windows.Forms.Button();
            numericBoxTwhoThetaOffsetCoeff1 = new Crystallography.Controls.NumericBox();
            label25 = new System.Windows.Forms.Label();
            checkBoxMaskingMode = new System.Windows.Forms.CheckBox();
            panelMaskingMode = new System.Windows.Forms.Panel();
            checkBoxShowMaskedRange = new System.Windows.Forms.CheckBox();
            numericUpDownInterpolationPoints = new System.Windows.Forms.NumericUpDown();
            label20 = new System.Windows.Forms.Label();
            listBoxMaskRanges = new System.Windows.Forms.ListBox();
            contextMenuStripMaskRange = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemSaveMaskingRange = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemReadMaskingRange = new System.Windows.Forms.ToolStripMenuItem();
            label21 = new System.Windows.Forms.Label();
            buttonDeleteAllMask = new System.Windows.Forms.Button();
            numericUpDownInterpolationOrder = new System.Windows.Forms.NumericUpDown();
            label19 = new System.Windows.Forms.Label();
            buttonDeleteMask = new System.Windows.Forms.Button();
            panelSmoothing = new System.Windows.Forms.Panel();
            checkBoxBandPassFilter = new System.Windows.Forms.CheckBox();
            panelBandPassFilter = new System.Windows.Forms.Panel();
            numericUpDownHighPass = new System.Windows.Forms.NumericUpDown();
            checkBoxLowPassFilter = new System.Windows.Forms.CheckBox();
            numericUpDownLowPass = new System.Windows.Forms.NumericUpDown();
            checkBoxHighPassFilter = new System.Windows.Forms.CheckBox();
            labelHighPass = new System.Windows.Forms.Label();
            labelLowPath = new System.Windows.Forms.Label();
            panel5 = new System.Windows.Forms.Panel();
            checkBoxRemoveKalpha2 = new System.Windows.Forms.CheckBox();
            panelBackgroundSubtraction = new System.Windows.Forms.Panel();
            checkBoxNormarizeIntensity = new System.Windows.Forms.CheckBox();
            panelNormarizeIntensity = new System.Windows.Forms.Panel();
            label14 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            buttonApplyAllProfiles = new System.Windows.Forms.Button();
            tabPage3 = new System.Windows.Forms.TabPage();
            tabPage1 = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            listBoxTwoProfiles1 = new System.Windows.Forms.ListBox();
            flowLayoutPanelFourCalculator = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonAddition = new System.Windows.Forms.RadioButton();
            radioButtonSubtraction = new System.Windows.Forms.RadioButton();
            radioButtonMutiplication = new System.Windows.Forms.RadioButton();
            radioButtonDivision = new System.Windows.Forms.RadioButton();
            numericalTextBoxTargetValue = new Crystallography.Controls.NumericBox();
            listBoxTwoProfiles2 = new System.Windows.Forms.ListBox();
            radioButtonAverage = new System.Windows.Forms.RadioButton();
            radioButtonProfileAndValue = new System.Windows.Forms.RadioButton();
            radioButtonTwoProfiles = new System.Windows.Forms.RadioButton();
            buttonCalculate = new System.Windows.Forms.Button();
            textBoxOutputFilename = new System.Windows.Forms.TextBox();
            label18 = new System.Windows.Forms.Label();
            toolTip = new System.Windows.Forms.ToolTip(components);
            checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            profileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataSetProfile).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSmoothingSavitzkyAndGolayN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSmoothingSavitzkyAndGolayM).BeginInit();
            panelBackgroundReferrence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBackgroundReferrenceScale).BeginInit();
            panelBackgroundBSpline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBgPointsNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNormarizeRangeHigh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNormarizeRangeLow).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownShiftHorizontalAxis).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNormarizeIntensity).BeginInit();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelTwoThetaOffset.SuspendLayout();
            panelMaskingMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInterpolationPoints).BeginInit();
            contextMenuStripMaskRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInterpolationOrder).BeginInit();
            panelSmoothing.SuspendLayout();
            panelBandPassFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHighPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLowPass).BeginInit();
            panelBackgroundSubtraction.SuspendLayout();
            panelNormarizeIntensity.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanelFourCalculator.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewProfile);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox3);
            // 
            // dataGridViewProfile
            // 
            dataGridViewProfile.AllowUserToAddRows = false;
            dataGridViewProfile.AllowUserToDeleteRows = false;
            dataGridViewProfile.AllowUserToResizeColumns = false;
            dataGridViewProfile.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewProfile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewProfile.AutoGenerateColumns = false;
            dataGridViewProfile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewProfile.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewProfile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewProfile.ColumnHeadersVisible = false;
            dataGridViewProfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { checkDataGridViewCheckBoxColumn, colorDataGridViewTextBoxColumn, profileDataGridViewTextBoxColumn });
            dataGridViewProfile.DataSource = bindingSourceProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewProfile.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(dataGridViewProfile, "dataGridViewProfile");
            dataGridViewProfile.MultiSelect = false;
            dataGridViewProfile.Name = "dataGridViewProfile";
            dataGridViewProfile.ReadOnly = true;
            dataGridViewProfile.RowHeadersVisible = false;
            dataGridViewProfile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewProfile.RowTemplate.Height = 21;
            dataGridViewProfile.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewProfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProfile.CellClick += dataGridViewProfile_CellClick;
            dataGridViewProfile.CellDoubleClick += dataGridViewProfile_CellClick;
            dataGridViewProfile.KeyDown += dataGridViewProfile_KeyDown;
            // 
            // bindingSourceProfile
            // 
            bindingSourceProfile.DataMember = "DataTableProfile";
            bindingSourceProfile.DataSource = dataSetProfile;
            bindingSourceProfile.CurrentChanged += bindingSource_CurrentChanged;
            bindingSourceProfile.ListChanged += bindingSource_ListChanged;
            // 
            // dataSetProfile
            // 
            dataSetProfile.DataSetName = "DataSet";
            dataSetProfile.Namespace = "http://tempuri.org/DataSet1.xsd";
            dataSetProfile.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxComment);
            groupBox3.Controls.Add(textBoxProfileName);
            groupBox3.Controls.Add(colorControlLineColor);
            groupBox3.Controls.Add(numericUpDownLineWidth);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label22);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label9);
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // textBoxComment
            // 
            resources.ApplyResources(textBoxComment, "textBoxComment");
            textBoxComment.Name = "textBoxComment";
            textBoxComment.TextChanged += textBoxComment_TextChanged;
            // 
            // textBoxProfileName
            // 
            resources.ApplyResources(textBoxProfileName, "textBoxProfileName");
            textBoxProfileName.Name = "textBoxProfileName";
            textBoxProfileName.TextChanged += textBoxProfileName_TextChanged;
            // 
            // colorControlLineColor
            // 
            colorControlLineColor.Argb = -986896;
            resources.ApplyResources(colorControlLineColor, "colorControlLineColor");
            colorControlLineColor.BackColor = System.Drawing.SystemColors.Control;
            colorControlLineColor.Blue = 240;
            colorControlLineColor.BlueF = 0.9411765F;
            colorControlLineColor.BoxSize = new System.Drawing.Size(20, 20);
            colorControlLineColor.Color = System.Drawing.Color.FromArgb(240, 240, 240);
            colorControlLineColor.Green = 240;
            colorControlLineColor.GreenF = 0.9411765F;
            colorControlLineColor.Name = "colorControlLineColor";
            colorControlLineColor.Red = 240;
            colorControlLineColor.RedF = 0.9411765F;
            colorControlLineColor.ColorChanged += colorControlLineColor_ColorChanged;
            // 
            // numericUpDownLineWidth
            // 
            numericUpDownLineWidth.DecimalPlaces = 1;
            resources.ApplyResources(numericUpDownLineWidth, "numericUpDownLineWidth");
            numericUpDownLineWidth.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericUpDownLineWidth.Name = "numericUpDownLineWidth";
            numericUpDownLineWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownLineWidth.ValueChanged += numericUpDownLineWidth_ValueChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // numericUpDownSmoothingSavitzkyAndGolayN
            // 
            resources.ApplyResources(numericUpDownSmoothingSavitzkyAndGolayN, "numericUpDownSmoothingSavitzkyAndGolayN");
            numericUpDownSmoothingSavitzkyAndGolayN.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownSmoothingSavitzkyAndGolayN.Name = "numericUpDownSmoothingSavitzkyAndGolayN";
            numericUpDownSmoothingSavitzkyAndGolayN.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownSmoothingSavitzkyAndGolayN.ValueChanged += checkBoxSmoothing_CheckedChanged;
            // 
            // numericUpDownSmoothingSavitzkyAndGolayM
            // 
            resources.ApplyResources(numericUpDownSmoothingSavitzkyAndGolayM, "numericUpDownSmoothingSavitzkyAndGolayM");
            numericUpDownSmoothingSavitzkyAndGolayM.Name = "numericUpDownSmoothingSavitzkyAndGolayM";
            numericUpDownSmoothingSavitzkyAndGolayM.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownSmoothingSavitzkyAndGolayM.ValueChanged += checkBoxSmoothing_CheckedChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // checkBoxShowBackgroundProfile
            // 
            resources.ApplyResources(checkBoxShowBackgroundProfile, "checkBoxShowBackgroundProfile");
            checkBoxShowBackgroundProfile.Name = "checkBoxShowBackgroundProfile";
            checkBoxShowBackgroundProfile.CheckedChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // panelBackgroundReferrence
            // 
            panelBackgroundReferrence.Controls.Add(comboBoxBackgroundReferrence);
            panelBackgroundReferrence.Controls.Add(label4);
            panelBackgroundReferrence.Controls.Add(numericUpDownBackgroundReferrenceScale);
            resources.ApplyResources(panelBackgroundReferrence, "panelBackgroundReferrence");
            panelBackgroundReferrence.Name = "panelBackgroundReferrence";
            // 
            // comboBoxBackgroundReferrence
            // 
            comboBoxBackgroundReferrence.DataSource = dataSetProfile;
            comboBoxBackgroundReferrence.DisplayMember = "DataTableProfile.Profile";
            comboBoxBackgroundReferrence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBoxBackgroundReferrence, "comboBoxBackgroundReferrence");
            comboBoxBackgroundReferrence.FormattingEnabled = true;
            comboBoxBackgroundReferrence.Name = "comboBoxBackgroundReferrence";
            comboBoxBackgroundReferrence.ValueMember = "DataTableProfile.Profile";
            comboBoxBackgroundReferrence.SelectedIndexChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // numericUpDownBackgroundReferrenceScale
            // 
            numericUpDownBackgroundReferrenceScale.DecimalPlaces = 4;
            resources.ApplyResources(numericUpDownBackgroundReferrenceScale, "numericUpDownBackgroundReferrenceScale");
            numericUpDownBackgroundReferrenceScale.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownBackgroundReferrenceScale.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDownBackgroundReferrenceScale.Name = "numericUpDownBackgroundReferrenceScale";
            numericUpDownBackgroundReferrenceScale.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownBackgroundReferrenceScale.ValueChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // panelBackgroundBSpline
            // 
            panelBackgroundBSpline.Controls.Add(buttonBackgroundAutoDetectBG);
            panelBackgroundBSpline.Controls.Add(label11);
            panelBackgroundBSpline.Controls.Add(numericUpDownBgPointsNumber);
            resources.ApplyResources(panelBackgroundBSpline, "panelBackgroundBSpline");
            panelBackgroundBSpline.Name = "panelBackgroundBSpline";
            // 
            // buttonBackgroundAutoDetectBG
            // 
            resources.ApplyResources(buttonBackgroundAutoDetectBG, "buttonBackgroundAutoDetectBG");
            buttonBackgroundAutoDetectBG.Name = "buttonBackgroundAutoDetectBG";
            buttonBackgroundAutoDetectBG.UseVisualStyleBackColor = true;
            buttonBackgroundAutoDetectBG.Click += buttonAutoDetectBG_Click;
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // numericUpDownBgPointsNumber
            // 
            resources.ApplyResources(numericUpDownBgPointsNumber, "numericUpDownBgPointsNumber");
            numericUpDownBgPointsNumber.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownBgPointsNumber.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownBgPointsNumber.Name = "numericUpDownBgPointsNumber";
            numericUpDownBgPointsNumber.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // radioButtonBackgroundReferrence
            // 
            resources.ApplyResources(radioButtonBackgroundReferrence, "radioButtonBackgroundReferrence");
            radioButtonBackgroundReferrence.Name = "radioButtonBackgroundReferrence";
            radioButtonBackgroundReferrence.UseVisualStyleBackColor = true;
            radioButtonBackgroundReferrence.CheckedChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // radioButtonBagkgroundBSpline
            // 
            resources.ApplyResources(radioButtonBagkgroundBSpline, "radioButtonBagkgroundBSpline");
            radioButtonBagkgroundBSpline.Checked = true;
            radioButtonBagkgroundBSpline.Name = "radioButtonBagkgroundBSpline";
            radioButtonBagkgroundBSpline.TabStop = true;
            radioButtonBagkgroundBSpline.UseVisualStyleBackColor = true;
            radioButtonBagkgroundBSpline.CheckedChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // checkBoxSmoothing
            // 
            resources.ApplyResources(checkBoxSmoothing, "checkBoxSmoothing");
            checkBoxSmoothing.Name = "checkBoxSmoothing";
            checkBoxSmoothing.UseVisualStyleBackColor = true;
            checkBoxSmoothing.CheckedChanged += checkBoxSmoothing_CheckedChanged;
            // 
            // checkBoxBackgroundSubtraction
            // 
            resources.ApplyResources(checkBoxBackgroundSubtraction, "checkBoxBackgroundSubtraction");
            checkBoxBackgroundSubtraction.Name = "checkBoxBackgroundSubtraction";
            checkBoxBackgroundSubtraction.UseVisualStyleBackColor = true;
            checkBoxBackgroundSubtraction.CheckedChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // buttonDeleteProfile
            // 
            resources.ApplyResources(buttonDeleteProfile, "buttonDeleteProfile");
            buttonDeleteProfile.BackColor = System.Drawing.Color.IndianRed;
            buttonDeleteProfile.ForeColor = System.Drawing.Color.White;
            buttonDeleteProfile.Name = "buttonDeleteProfile";
            buttonDeleteProfile.UseVisualStyleBackColor = false;
            buttonDeleteProfile.Click += buttonDeleteProfile_Click;
            // 
            // buttonUpper
            // 
            resources.ApplyResources(buttonUpper, "buttonUpper");
            buttonUpper.Name = "buttonUpper";
            buttonUpper.Click += buttonUpper_Click;
            // 
            // buttonLower
            // 
            resources.ApplyResources(buttonLower, "buttonLower");
            buttonLower.Name = "buttonLower";
            buttonLower.Click += buttonLower_Click;
            // 
            // numericUpDownNormarizeRangeHigh
            // 
            numericUpDownNormarizeRangeHigh.DecimalPlaces = 1;
            resources.ApplyResources(numericUpDownNormarizeRangeHigh, "numericUpDownNormarizeRangeHigh");
            numericUpDownNormarizeRangeHigh.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownNormarizeRangeHigh.Name = "numericUpDownNormarizeRangeHigh";
            numericUpDownNormarizeRangeHigh.Value = new decimal(new int[] { 180, 0, 0, 0 });
            numericUpDownNormarizeRangeHigh.ValueChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // numericUpDownNormarizeRangeLow
            // 
            numericUpDownNormarizeRangeLow.DecimalPlaces = 1;
            resources.ApplyResources(numericUpDownNormarizeRangeLow, "numericUpDownNormarizeRangeLow");
            numericUpDownNormarizeRangeLow.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownNormarizeRangeLow.Name = "numericUpDownNormarizeRangeLow";
            numericUpDownNormarizeRangeLow.ValueChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // buttonChangeSourceXAxis
            // 
            resources.ApplyResources(buttonChangeSourceXAxis, "buttonChangeSourceXAxis");
            buttonChangeSourceXAxis.Name = "buttonChangeSourceXAxis";
            buttonChangeSourceXAxis.UseVisualStyleBackColor = true;
            buttonChangeSourceXAxis.Click += buttonChangeSouceXAxis_Click;
            // 
            // xAxisUserControl
            // 
            resources.ApplyResources(xAxisUserControl, "xAxisUserControl");
            xAxisUserControl.AxisMode = Crystallography.HorizontalAxis.Angle;
            xAxisUserControl.DspacingUnit = Crystallography.LengthUnitEnum.Angstrom;
            xAxisUserControl.ElectronAccVol = 8.04151786D;
            xAxisUserControl.ElectronAccVoltageText = "8.04151786";
            xAxisUserControl.EnergyUnit = Crystallography.EnergyUnitEnum.eV;
            xAxisUserControl.HorizontalAxisProperty = (Crystallography.HorizontalAxisProperty)resources.GetObject("xAxisUserControl.HorizontalAxisProperty");
            xAxisUserControl.Name = "xAxisUserControl";
            xAxisUserControl.TakeoffAngle = 5.9872200000000051D;
            xAxisUserControl.TakeoffAngleText = "343.042437016317";
            xAxisUserControl.TofAngle = 1.5707963267948966D;
            xAxisUserControl.TofAngleText = "90";
            xAxisUserControl.TofLength = 42D;
            xAxisUserControl.TofTimeUnit = Crystallography.TimeUnitEnum.MicroSecond;
            xAxisUserControl.TwoThetaUnit = Crystallography.AngleUnitEnum.Degree;
            xAxisUserControl.WaveColor = Crystallography.WaveColor.Monochrome;
            xAxisUserControl.WaveLength = 0.15418D;
            xAxisUserControl.WaveLengthText = "1.5418";
            xAxisUserControl.WaveNumberUnit = Crystallography.LengthUnitEnum.AngstromInverse;
            xAxisUserControl.WaveSource = Crystallography.WaveSource.Xray;
            xAxisUserControl.XrayLine = Crystallography.XrayLine.Ka1;
            xAxisUserControl.XrayNumber = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(numericUpDownShiftHorizontalAxis);
            groupBox1.Controls.Add(checkBoxShiftHorizontalAxis);
            groupBox1.Controls.Add(xAxisUserControl);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            // 
            // numericUpDownShiftHorizontalAxis
            // 
            resources.ApplyResources(numericUpDownShiftHorizontalAxis, "numericUpDownShiftHorizontalAxis");
            numericUpDownShiftHorizontalAxis.DecimalPlaces = 3;
            numericUpDownShiftHorizontalAxis.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownShiftHorizontalAxis.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownShiftHorizontalAxis.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numericUpDownShiftHorizontalAxis.Name = "numericUpDownShiftHorizontalAxis";
            numericUpDownShiftHorizontalAxis.ValueChanged += checkBoxShiftHorizontalAxis_CheckedChanged;
            // 
            // checkBoxShiftHorizontalAxis
            // 
            resources.ApplyResources(checkBoxShiftHorizontalAxis, "checkBoxShiftHorizontalAxis");
            checkBoxShiftHorizontalAxis.Name = "checkBoxShiftHorizontalAxis";
            checkBoxShiftHorizontalAxis.UseVisualStyleBackColor = true;
            checkBoxShiftHorizontalAxis.CheckedChanged += checkBoxShiftHorizontalAxis_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numericalTextBoxExposureTime);
            groupBox2.Controls.Add(label24);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label1);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // numericalTextBoxExposureTime
            // 
            resources.ApplyResources(numericalTextBoxExposureTime, "numericalTextBoxExposureTime");
            numericalTextBoxExposureTime.BackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxExposureTime.FooterBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxExposureTime.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxExposureTime.Name = "numericalTextBoxExposureTime";
            numericalTextBoxExposureTime.SkipEventDuringInput = false;
            numericalTextBoxExposureTime.SmartIncrement = true;
            numericalTextBoxExposureTime.ThonsandsSeparator = true;
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            // 
            // radioButtonNormarizeMaximum
            // 
            resources.ApplyResources(radioButtonNormarizeMaximum, "radioButtonNormarizeMaximum");
            radioButtonNormarizeMaximum.Name = "radioButtonNormarizeMaximum";
            radioButtonNormarizeMaximum.UseVisualStyleBackColor = true;
            radioButtonNormarizeMaximum.CheckedChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // radioButtonNormarizeAverage
            // 
            resources.ApplyResources(radioButtonNormarizeAverage, "radioButtonNormarizeAverage");
            radioButtonNormarizeAverage.Checked = true;
            radioButtonNormarizeAverage.Name = "radioButtonNormarizeAverage";
            radioButtonNormarizeAverage.TabStop = true;
            radioButtonNormarizeAverage.UseVisualStyleBackColor = true;
            radioButtonNormarizeAverage.CheckedChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // numericUpDownNormarizeIntensity
            // 
            numericUpDownNormarizeIntensity.DecimalPlaces = 3;
            resources.ApplyResources(numericUpDownNormarizeIntensity, "numericUpDownNormarizeIntensity");
            numericUpDownNormarizeIntensity.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownNormarizeIntensity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownNormarizeIntensity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownNormarizeIntensity.Name = "numericUpDownNormarizeIntensity";
            numericUpDownNormarizeIntensity.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownNormarizeIntensity.ValueChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = System.Drawing.Color.DarkRed;
            button1.ForeColor = System.Drawing.Color.White;
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += buttonDeleteAllProfiles_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage1);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.HotTrack = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flowLayoutPanel1);
            tabPage2.Controls.Add(buttonApplyAllProfiles);
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanel1.Controls.Add(checkBoxTwoThetaOffset);
            flowLayoutPanel1.Controls.Add(panelTwoThetaOffset);
            flowLayoutPanel1.Controls.Add(checkBoxMaskingMode);
            flowLayoutPanel1.Controls.Add(panelMaskingMode);
            flowLayoutPanel1.Controls.Add(checkBoxSmoothing);
            flowLayoutPanel1.Controls.Add(panelSmoothing);
            flowLayoutPanel1.Controls.Add(checkBoxBandPassFilter);
            flowLayoutPanel1.Controls.Add(panelBandPassFilter);
            flowLayoutPanel1.Controls.Add(panel5);
            flowLayoutPanel1.Controls.Add(checkBoxRemoveKalpha2);
            flowLayoutPanel1.Controls.Add(checkBoxBackgroundSubtraction);
            flowLayoutPanel1.Controls.Add(panelBackgroundSubtraction);
            flowLayoutPanel1.Controls.Add(checkBoxNormarizeIntensity);
            flowLayoutPanel1.Controls.Add(panelNormarizeIntensity);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // checkBoxTwoThetaOffset
            // 
            resources.ApplyResources(checkBoxTwoThetaOffset, "checkBoxTwoThetaOffset");
            checkBoxTwoThetaOffset.Name = "checkBoxTwoThetaOffset";
            checkBoxTwoThetaOffset.UseVisualStyleBackColor = true;
            checkBoxTwoThetaOffset.CheckedChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // panelTwoThetaOffset
            // 
            panelTwoThetaOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelTwoThetaOffset.Controls.Add(numericBoxTwhoThetaOffsetCoeff2);
            panelTwoThetaOffset.Controls.Add(numericBoxTwhoThetaOffsetCoeff0);
            panelTwoThetaOffset.Controls.Add(buttonTwoThetaOffsetReset);
            panelTwoThetaOffset.Controls.Add(buttonTwoThetaCalibration);
            panelTwoThetaOffset.Controls.Add(numericBoxTwhoThetaOffsetCoeff1);
            panelTwoThetaOffset.Controls.Add(label25);
            resources.ApplyResources(panelTwoThetaOffset, "panelTwoThetaOffset");
            panelTwoThetaOffset.Name = "panelTwoThetaOffset";
            // 
            // numericBoxTwhoThetaOffsetCoeff2
            // 
            resources.ApplyResources(numericBoxTwhoThetaOffsetCoeff2, "numericBoxTwhoThetaOffsetCoeff2");
            numericBoxTwhoThetaOffsetCoeff2.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff2.DecimalPlaces = 5;
            numericBoxTwhoThetaOffsetCoeff2.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff2.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff2.Name = "numericBoxTwhoThetaOffsetCoeff2";
            numericBoxTwhoThetaOffsetCoeff2.SkipEventDuringInput = false;
            numericBoxTwhoThetaOffsetCoeff2.SmartIncrement = true;
            numericBoxTwhoThetaOffsetCoeff2.ThonsandsSeparator = true;
            numericBoxTwhoThetaOffsetCoeff2.ValueChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // numericBoxTwhoThetaOffsetCoeff0
            // 
            resources.ApplyResources(numericBoxTwhoThetaOffsetCoeff0, "numericBoxTwhoThetaOffsetCoeff0");
            numericBoxTwhoThetaOffsetCoeff0.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff0.DecimalPlaces = 5;
            numericBoxTwhoThetaOffsetCoeff0.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff0.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff0.Name = "numericBoxTwhoThetaOffsetCoeff0";
            numericBoxTwhoThetaOffsetCoeff0.SkipEventDuringInput = false;
            numericBoxTwhoThetaOffsetCoeff0.SmartIncrement = true;
            numericBoxTwhoThetaOffsetCoeff0.ThonsandsSeparator = true;
            numericBoxTwhoThetaOffsetCoeff0.ValueChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // buttonTwoThetaOffsetReset
            // 
            resources.ApplyResources(buttonTwoThetaOffsetReset, "buttonTwoThetaOffsetReset");
            buttonTwoThetaOffsetReset.Name = "buttonTwoThetaOffsetReset";
            buttonTwoThetaOffsetReset.UseVisualStyleBackColor = true;
            buttonTwoThetaOffsetReset.Click += buttonTwoThetaOffsetReset_Click;
            // 
            // buttonTwoThetaCalibration
            // 
            resources.ApplyResources(buttonTwoThetaCalibration, "buttonTwoThetaCalibration");
            buttonTwoThetaCalibration.Name = "buttonTwoThetaCalibration";
            buttonTwoThetaCalibration.UseVisualStyleBackColor = true;
            buttonTwoThetaCalibration.Click += buttonTwoThetaCalibration_Click;
            // 
            // numericBoxTwhoThetaOffsetCoeff1
            // 
            resources.ApplyResources(numericBoxTwhoThetaOffsetCoeff1, "numericBoxTwhoThetaOffsetCoeff1");
            numericBoxTwhoThetaOffsetCoeff1.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff1.DecimalPlaces = 5;
            numericBoxTwhoThetaOffsetCoeff1.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff1.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff1.Name = "numericBoxTwhoThetaOffsetCoeff1";
            numericBoxTwhoThetaOffsetCoeff1.SkipEventDuringInput = false;
            numericBoxTwhoThetaOffsetCoeff1.SmartIncrement = true;
            numericBoxTwhoThetaOffsetCoeff1.ThonsandsSeparator = true;
            numericBoxTwhoThetaOffsetCoeff1.ValueChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            // 
            // checkBoxMaskingMode
            // 
            resources.ApplyResources(checkBoxMaskingMode, "checkBoxMaskingMode");
            checkBoxMaskingMode.Name = "checkBoxMaskingMode";
            checkBoxMaskingMode.UseVisualStyleBackColor = true;
            checkBoxMaskingMode.CheckedChanged += checkBoxMaskingMode_CheckedChanged;
            // 
            // panelMaskingMode
            // 
            panelMaskingMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelMaskingMode.Controls.Add(checkBoxShowMaskedRange);
            panelMaskingMode.Controls.Add(numericUpDownInterpolationPoints);
            panelMaskingMode.Controls.Add(label20);
            panelMaskingMode.Controls.Add(listBoxMaskRanges);
            panelMaskingMode.Controls.Add(label21);
            panelMaskingMode.Controls.Add(buttonDeleteAllMask);
            panelMaskingMode.Controls.Add(numericUpDownInterpolationOrder);
            panelMaskingMode.Controls.Add(label19);
            panelMaskingMode.Controls.Add(buttonDeleteMask);
            resources.ApplyResources(panelMaskingMode, "panelMaskingMode");
            panelMaskingMode.Name = "panelMaskingMode";
            // 
            // checkBoxShowMaskedRange
            // 
            resources.ApplyResources(checkBoxShowMaskedRange, "checkBoxShowMaskedRange");
            checkBoxShowMaskedRange.Checked = true;
            checkBoxShowMaskedRange.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxShowMaskedRange.Name = "checkBoxShowMaskedRange";
            checkBoxShowMaskedRange.UseVisualStyleBackColor = true;
            checkBoxShowMaskedRange.CheckedChanged += checkBoxMaskingMode_CheckedChanged;
            // 
            // numericUpDownInterpolationPoints
            // 
            resources.ApplyResources(numericUpDownInterpolationPoints, "numericUpDownInterpolationPoints");
            numericUpDownInterpolationPoints.Name = "numericUpDownInterpolationPoints";
            toolTip.SetToolTip(numericUpDownInterpolationPoints, resources.GetString("numericUpDownInterpolationPoints.ToolTip"));
            numericUpDownInterpolationPoints.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownInterpolationPoints.ValueChanged += checkBoxMaskingMode_CheckedChanged;
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.Name = "label20";
            toolTip.SetToolTip(label20, resources.GetString("label20.ToolTip"));
            // 
            // listBoxMaskRanges
            // 
            listBoxMaskRanges.AllowDrop = true;
            listBoxMaskRanges.ContextMenuStrip = contextMenuStripMaskRange;
            resources.ApplyResources(listBoxMaskRanges, "listBoxMaskRanges");
            listBoxMaskRanges.FormattingEnabled = true;
            listBoxMaskRanges.Name = "listBoxMaskRanges";
            listBoxMaskRanges.SelectedIndexChanged += listBoxMaskRanges_SelectedIndexChanged;
            listBoxMaskRanges.DragDrop += listBoxMaskRanges_DragDrop;
            listBoxMaskRanges.DragEnter += listBoxMaskRanges_DragEnter;
            // 
            // contextMenuStripMaskRange
            // 
            contextMenuStripMaskRange.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemSaveMaskingRange, toolStripMenuItemReadMaskingRange });
            contextMenuStripMaskRange.Name = "contextMenuStripMaskRange";
            resources.ApplyResources(contextMenuStripMaskRange, "contextMenuStripMaskRange");
            // 
            // toolStripMenuItemSaveMaskingRange
            // 
            toolStripMenuItemSaveMaskingRange.Name = "toolStripMenuItemSaveMaskingRange";
            resources.ApplyResources(toolStripMenuItemSaveMaskingRange, "toolStripMenuItemSaveMaskingRange");
            toolStripMenuItemSaveMaskingRange.Click += toolStripMenuItemSaveMaskingRange_Click;
            // 
            // toolStripMenuItemReadMaskingRange
            // 
            toolStripMenuItemReadMaskingRange.Name = "toolStripMenuItemReadMaskingRange";
            resources.ApplyResources(toolStripMenuItemReadMaskingRange, "toolStripMenuItemReadMaskingRange");
            toolStripMenuItemReadMaskingRange.Click += toolStripMenuItemReadMaskingRange_Click;
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            toolTip.SetToolTip(label21, resources.GetString("label21.ToolTip"));
            // 
            // buttonDeleteAllMask
            // 
            resources.ApplyResources(buttonDeleteAllMask, "buttonDeleteAllMask");
            buttonDeleteAllMask.BackColor = System.Drawing.Color.DarkRed;
            buttonDeleteAllMask.ForeColor = System.Drawing.Color.White;
            buttonDeleteAllMask.Name = "buttonDeleteAllMask";
            buttonDeleteAllMask.UseVisualStyleBackColor = false;
            buttonDeleteAllMask.Click += buttonDeleteAllMask_Click;
            // 
            // numericUpDownInterpolationOrder
            // 
            resources.ApplyResources(numericUpDownInterpolationOrder, "numericUpDownInterpolationOrder");
            numericUpDownInterpolationOrder.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownInterpolationOrder.Name = "numericUpDownInterpolationOrder";
            numericUpDownInterpolationOrder.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownInterpolationOrder.ValueChanged += checkBoxMaskingMode_CheckedChanged;
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            // 
            // buttonDeleteMask
            // 
            resources.ApplyResources(buttonDeleteMask, "buttonDeleteMask");
            buttonDeleteMask.BackColor = System.Drawing.Color.IndianRed;
            buttonDeleteMask.ForeColor = System.Drawing.Color.White;
            buttonDeleteMask.Name = "buttonDeleteMask";
            buttonDeleteMask.UseVisualStyleBackColor = false;
            buttonDeleteMask.Click += buttonDeleteMask_Click;
            // 
            // panelSmoothing
            // 
            panelSmoothing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelSmoothing.Controls.Add(numericUpDownSmoothingSavitzkyAndGolayN);
            panelSmoothing.Controls.Add(label17);
            panelSmoothing.Controls.Add(numericUpDownSmoothingSavitzkyAndGolayM);
            panelSmoothing.Controls.Add(label10);
            panelSmoothing.Controls.Add(label5);
            resources.ApplyResources(panelSmoothing, "panelSmoothing");
            panelSmoothing.Name = "panelSmoothing";
            // 
            // checkBoxBandPassFilter
            // 
            resources.ApplyResources(checkBoxBandPassFilter, "checkBoxBandPassFilter");
            checkBoxBandPassFilter.Name = "checkBoxBandPassFilter";
            checkBoxBandPassFilter.UseVisualStyleBackColor = true;
            checkBoxBandPassFilter.CheckedChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // panelBandPassFilter
            // 
            panelBandPassFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelBandPassFilter.Controls.Add(numericUpDownHighPass);
            panelBandPassFilter.Controls.Add(checkBoxLowPassFilter);
            panelBandPassFilter.Controls.Add(numericUpDownLowPass);
            panelBandPassFilter.Controls.Add(checkBoxHighPassFilter);
            panelBandPassFilter.Controls.Add(labelHighPass);
            panelBandPassFilter.Controls.Add(labelLowPath);
            resources.ApplyResources(panelBandPassFilter, "panelBandPassFilter");
            panelBandPassFilter.Name = "panelBandPassFilter";
            // 
            // numericUpDownHighPass
            // 
            numericUpDownHighPass.DecimalPlaces = 2;
            resources.ApplyResources(numericUpDownHighPass, "numericUpDownHighPass");
            numericUpDownHighPass.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownHighPass.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownHighPass.Name = "numericUpDownHighPass";
            numericUpDownHighPass.ValueChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // checkBoxLowPassFilter
            // 
            resources.ApplyResources(checkBoxLowPassFilter, "checkBoxLowPassFilter");
            checkBoxLowPassFilter.Name = "checkBoxLowPassFilter";
            checkBoxLowPassFilter.UseVisualStyleBackColor = true;
            checkBoxLowPassFilter.CheckedChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // numericUpDownLowPass
            // 
            numericUpDownLowPass.DecimalPlaces = 2;
            resources.ApplyResources(numericUpDownLowPass, "numericUpDownLowPass");
            numericUpDownLowPass.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownLowPass.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownLowPass.Name = "numericUpDownLowPass";
            numericUpDownLowPass.ValueChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // checkBoxHighPassFilter
            // 
            resources.ApplyResources(checkBoxHighPassFilter, "checkBoxHighPassFilter");
            checkBoxHighPassFilter.Name = "checkBoxHighPassFilter";
            checkBoxHighPassFilter.UseVisualStyleBackColor = true;
            checkBoxHighPassFilter.CheckedChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // labelHighPass
            // 
            resources.ApplyResources(labelHighPass, "labelHighPass");
            labelHighPass.Name = "labelHighPass";
            // 
            // labelLowPath
            // 
            resources.ApplyResources(labelLowPath, "labelLowPath");
            labelLowPath.Name = "labelLowPath";
            // 
            // panel5
            // 
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            // 
            // checkBoxRemoveKalpha2
            // 
            resources.ApplyResources(checkBoxRemoveKalpha2, "checkBoxRemoveKalpha2");
            checkBoxRemoveKalpha2.Name = "checkBoxRemoveKalpha2";
            checkBoxRemoveKalpha2.UseVisualStyleBackColor = true;
            checkBoxRemoveKalpha2.CheckedChanged += checkBoxRemoveKalpha2_CheckedChanged;
            // 
            // panelBackgroundSubtraction
            // 
            panelBackgroundSubtraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelBackgroundSubtraction.Controls.Add(checkBoxShowBackgroundProfile);
            panelBackgroundSubtraction.Controls.Add(panelBackgroundReferrence);
            panelBackgroundSubtraction.Controls.Add(radioButtonBagkgroundBSpline);
            panelBackgroundSubtraction.Controls.Add(panelBackgroundBSpline);
            panelBackgroundSubtraction.Controls.Add(radioButtonBackgroundReferrence);
            resources.ApplyResources(panelBackgroundSubtraction, "panelBackgroundSubtraction");
            panelBackgroundSubtraction.Name = "panelBackgroundSubtraction";
            // 
            // checkBoxNormarizeIntensity
            // 
            resources.ApplyResources(checkBoxNormarizeIntensity, "checkBoxNormarizeIntensity");
            checkBoxNormarizeIntensity.Name = "checkBoxNormarizeIntensity";
            checkBoxNormarizeIntensity.UseVisualStyleBackColor = true;
            checkBoxNormarizeIntensity.CheckedChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // panelNormarizeIntensity
            // 
            panelNormarizeIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelNormarizeIntensity.Controls.Add(radioButtonNormarizeAverage);
            panelNormarizeIntensity.Controls.Add(label16);
            panelNormarizeIntensity.Controls.Add(numericUpDownNormarizeRangeLow);
            panelNormarizeIntensity.Controls.Add(numericUpDownNormarizeRangeHigh);
            panelNormarizeIntensity.Controls.Add(radioButtonNormarizeMaximum);
            panelNormarizeIntensity.Controls.Add(numericUpDownNormarizeIntensity);
            panelNormarizeIntensity.Controls.Add(label14);
            panelNormarizeIntensity.Controls.Add(label13);
            panelNormarizeIntensity.Controls.Add(label3);
            panelNormarizeIntensity.Controls.Add(label23);
            resources.ApplyResources(panelNormarizeIntensity, "panelNormarizeIntensity");
            panelNormarizeIntensity.Name = "panelNormarizeIntensity";
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            // 
            // buttonApplyAllProfiles
            // 
            resources.ApplyResources(buttonApplyAllProfiles, "buttonApplyAllProfiles");
            buttonApplyAllProfiles.Name = "buttonApplyAllProfiles";
            buttonApplyAllProfiles.UseVisualStyleBackColor = true;
            buttonApplyAllProfiles.Click += buttonApplyAllProfiles_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Controls.Add(buttonChangeSourceXAxis);
            tabPage3.Controls.Add(groupBox2);
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Name = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(radioButtonAverage);
            tabPage1.Controls.Add(radioButtonProfileAndValue);
            tabPage1.Controls.Add(radioButtonTwoProfiles);
            tabPage1.Controls.Add(buttonCalculate);
            tabPage1.Controls.Add(textBoxOutputFilename);
            tabPage1.Controls.Add(label18);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(listBoxTwoProfiles1);
            panel1.Controls.Add(flowLayoutPanelFourCalculator);
            panel1.Controls.Add(listBoxTwoProfiles2);
            panel1.Name = "panel1";
            // 
            // listBoxTwoProfiles1
            // 
            resources.ApplyResources(listBoxTwoProfiles1, "listBoxTwoProfiles1");
            listBoxTwoProfiles1.FormattingEnabled = true;
            listBoxTwoProfiles1.Name = "listBoxTwoProfiles1";
            listBoxTwoProfiles1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // flowLayoutPanelFourCalculator
            // 
            resources.ApplyResources(flowLayoutPanelFourCalculator, "flowLayoutPanelFourCalculator");
            flowLayoutPanelFourCalculator.Controls.Add(radioButtonAddition);
            flowLayoutPanelFourCalculator.Controls.Add(radioButtonSubtraction);
            flowLayoutPanelFourCalculator.Controls.Add(radioButtonMutiplication);
            flowLayoutPanelFourCalculator.Controls.Add(radioButtonDivision);
            flowLayoutPanelFourCalculator.Controls.Add(numericalTextBoxTargetValue);
            flowLayoutPanelFourCalculator.Name = "flowLayoutPanelFourCalculator";
            // 
            // radioButtonAddition
            // 
            resources.ApplyResources(radioButtonAddition, "radioButtonAddition");
            radioButtonAddition.Checked = true;
            radioButtonAddition.Name = "radioButtonAddition";
            radioButtonAddition.TabStop = true;
            radioButtonAddition.UseVisualStyleBackColor = true;
            // 
            // radioButtonSubtraction
            // 
            resources.ApplyResources(radioButtonSubtraction, "radioButtonSubtraction");
            radioButtonSubtraction.Name = "radioButtonSubtraction";
            radioButtonSubtraction.UseVisualStyleBackColor = true;
            // 
            // radioButtonMutiplication
            // 
            resources.ApplyResources(radioButtonMutiplication, "radioButtonMutiplication");
            radioButtonMutiplication.Name = "radioButtonMutiplication";
            radioButtonMutiplication.UseVisualStyleBackColor = true;
            // 
            // radioButtonDivision
            // 
            resources.ApplyResources(radioButtonDivision, "radioButtonDivision");
            radioButtonDivision.Name = "radioButtonDivision";
            radioButtonDivision.UseVisualStyleBackColor = true;
            // 
            // numericalTextBoxTargetValue
            // 
            resources.ApplyResources(numericalTextBoxTargetValue, "numericalTextBoxTargetValue");
            numericalTextBoxTargetValue.BackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxTargetValue.FooterBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxTargetValue.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxTargetValue.Name = "numericalTextBoxTargetValue";
            numericalTextBoxTargetValue.SkipEventDuringInput = false;
            numericalTextBoxTargetValue.SmartIncrement = true;
            numericalTextBoxTargetValue.ThonsandsSeparator = true;
            // 
            // listBoxTwoProfiles2
            // 
            resources.ApplyResources(listBoxTwoProfiles2, "listBoxTwoProfiles2");
            listBoxTwoProfiles2.FormattingEnabled = true;
            listBoxTwoProfiles2.Items.AddRange(new object[] { resources.GetString("listBoxTwoProfiles2.Items") });
            listBoxTwoProfiles2.Name = "listBoxTwoProfiles2";
            // 
            // radioButtonAverage
            // 
            resources.ApplyResources(radioButtonAverage, "radioButtonAverage");
            radioButtonAverage.Checked = true;
            radioButtonAverage.Name = "radioButtonAverage";
            radioButtonAverage.TabStop = true;
            radioButtonAverage.UseVisualStyleBackColor = true;
            radioButtonAverage.CheckedChanged += radioButtonAverage_CheckedChanged;
            // 
            // radioButtonProfileAndValue
            // 
            resources.ApplyResources(radioButtonProfileAndValue, "radioButtonProfileAndValue");
            radioButtonProfileAndValue.Name = "radioButtonProfileAndValue";
            radioButtonProfileAndValue.UseVisualStyleBackColor = true;
            radioButtonProfileAndValue.CheckedChanged += radioButtonAverage_CheckedChanged;
            // 
            // radioButtonTwoProfiles
            // 
            resources.ApplyResources(radioButtonTwoProfiles, "radioButtonTwoProfiles");
            radioButtonTwoProfiles.Name = "radioButtonTwoProfiles";
            radioButtonTwoProfiles.UseVisualStyleBackColor = true;
            radioButtonTwoProfiles.CheckedChanged += radioButtonAverage_CheckedChanged;
            // 
            // buttonCalculate
            // 
            resources.ApplyResources(buttonCalculate, "buttonCalculate");
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // textBoxOutputFilename
            // 
            resources.ApplyResources(textBoxOutputFilename, "textBoxOutputFilename");
            textBoxOutputFilename.Name = "textBoxOutputFilename";
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            resources.ApplyResources(checkDataGridViewCheckBoxColumn, "checkDataGridViewCheckBoxColumn");
            checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            checkDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            resources.ApplyResources(colorDataGridViewTextBoxColumn, "colorDataGridViewTextBoxColumn");
            colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            colorDataGridViewTextBoxColumn.ReadOnly = true;
            colorDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            colorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // profileDataGridViewTextBoxColumn
            // 
            profileDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            profileDataGridViewTextBoxColumn.DataPropertyName = "Profile";
            resources.ApplyResources(profileDataGridViewTextBoxColumn, "profileDataGridViewTextBoxColumn");
            profileDataGridViewTextBoxColumn.Name = "profileDataGridViewTextBoxColumn";
            profileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormProfileSetting
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(splitContainer1);
            Controls.Add(tabControl1);
            Controls.Add(button1);
            Controls.Add(buttonDeleteProfile);
            Controls.Add(buttonUpper);
            Controls.Add(buttonLower);
            Name = "FormProfileSetting";
            FormClosing += FormProfileSetting_FormClosing;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataSetProfile).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSmoothingSavitzkyAndGolayN).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSmoothingSavitzkyAndGolayM).EndInit();
            panelBackgroundReferrence.ResumeLayout(false);
            panelBackgroundReferrence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBackgroundReferrenceScale).EndInit();
            panelBackgroundBSpline.ResumeLayout(false);
            panelBackgroundBSpline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownBgPointsNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNormarizeRangeHigh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNormarizeRangeLow).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownShiftHorizontalAxis).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownNormarizeIntensity).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panelTwoThetaOffset.ResumeLayout(false);
            panelTwoThetaOffset.PerformLayout();
            panelMaskingMode.ResumeLayout(false);
            panelMaskingMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownInterpolationPoints).EndInit();
            contextMenuStripMaskRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownInterpolationOrder).EndInit();
            panelSmoothing.ResumeLayout(false);
            panelSmoothing.PerformLayout();
            panelBandPassFilter.ResumeLayout(false);
            panelBandPassFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownHighPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownLowPass).EndInit();
            panelBackgroundSubtraction.ResumeLayout(false);
            panelBackgroundSubtraction.PerformLayout();
            panelNormarizeIntensity.ResumeLayout(false);
            panelNormarizeIntensity.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanelFourCalculator.ResumeLayout(false);
            flowLayoutPanelFourCalculator.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDownSmoothingSavitzkyAndGolayN;
        private System.Windows.Forms.NumericUpDown numericUpDownSmoothingSavitzkyAndGolayM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxSmoothing;
        private System.Windows.Forms.CheckBox checkBoxBackgroundSubtraction;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox checkBoxShowBackgroundProfile;
        private System.Windows.Forms.NumericUpDown numericUpDownBgPointsNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpper;
        private System.Windows.Forms.Button buttonLower;
        private System.Windows.Forms.NumericUpDown numericUpDownNormarizeRangeHigh;
        private System.Windows.Forms.NumericUpDown numericUpDownNormarizeRangeLow;
        private Crystallography.Controls.HorizontalAxisUserControl xAxisUserControl;
        private System.Windows.Forms.Button buttonChangeSourceXAxis;
        private System.Windows.Forms.Button buttonBackgroundAutoDetectBG;
        private System.Windows.Forms.NumericUpDown numericUpDownLineWidth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Crystallography.Controls.NumericBox numericalTextBoxExposureTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxShiftHorizontalAxis;
        private System.Windows.Forms.NumericUpDown numericUpDownShiftHorizontalAxis;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonNormarizeAverage;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radioButtonNormarizeMaximum;
        private System.Windows.Forms.NumericUpDown numericUpDownNormarizeIntensity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonBackgroundReferrence;
        private System.Windows.Forms.RadioButton radioButtonBagkgroundBSpline;
        private System.Windows.Forms.Panel panelBackgroundBSpline;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panelBackgroundReferrence;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownBackgroundReferrenceScale;
        private System.Windows.Forms.Button buttonApplyAllProfiles;
        private System.Windows.Forms.CheckBox checkBoxBandPassFilter;
        private System.Windows.Forms.CheckBox checkBoxNormarizeIntensity;
        private System.Windows.Forms.CheckBox checkBoxLowPassFilter;
        private System.Windows.Forms.CheckBox checkBoxHighPassFilter;
        private System.Windows.Forms.NumericUpDown numericUpDownLowPass;
        private System.Windows.Forms.NumericUpDown numericUpDownHighPass;
        private System.Windows.Forms.Label labelHighPass;
        private System.Windows.Forms.Label labelLowPath;
        public System.Windows.Forms.ComboBox comboBoxBackgroundReferrence;
        public System.Windows.Forms.DataGridView dataGridViewProfile;
        public System.Windows.Forms.BindingSource bindingSourceProfile;
        public DataSet dataSetProfile;
        private Crystallography.Controls.ColorControl colorControlLineColor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.ListBox listBoxTwoProfiles1;
        public System.Windows.Forms.ListBox listBoxTwoProfiles2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFourCalculator;
        private Crystallography.Controls.NumericBox numericalTextBoxTargetValue;
        private System.Windows.Forms.CheckBox checkBoxMaskingMode;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NumericUpDown numericUpDownInterpolationPoints;
        private System.Windows.Forms.NumericUpDown numericUpDownInterpolationOrder;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListBox listBoxMaskRanges;
        private System.Windows.Forms.Button buttonDeleteMask;
        private System.Windows.Forms.Button buttonDeleteAllMask;
        public System.Windows.Forms.CheckBox checkBoxShowMaskedRange;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMaskRange;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveMaskingRange;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReadMaskingRange;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        public System.Windows.Forms.TextBox textBoxOutputFilename;
        public System.Windows.Forms.RadioButton radioButtonDivision;
        public System.Windows.Forms.RadioButton radioButtonMutiplication;
        public System.Windows.Forms.RadioButton radioButtonSubtraction;
        public System.Windows.Forms.RadioButton radioButtonAddition;
        public System.Windows.Forms.RadioButton radioButtonAverage;
        public System.Windows.Forms.RadioButton radioButtonProfileAndValue;
        public System.Windows.Forms.RadioButton radioButtonTwoProfiles;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonDeleteProfile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBoxRemoveKalpha2;
        private System.Windows.Forms.CheckBox checkBoxTwoThetaOffset;
        private Crystallography.Controls.NumericBox numericBoxTwhoThetaOffsetCoeff2;
        private System.Windows.Forms.Button buttonTwoThetaCalibration;
        private Crystallography.Controls.NumericBox numericBoxTwhoThetaOffsetCoeff1;
        private Crystallography.Controls.NumericBox numericBoxTwhoThetaOffsetCoeff0;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelMaskingMode;
        private System.Windows.Forms.Panel panelSmoothing;
        private System.Windows.Forms.Panel panelBandPassFilter;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelTwoThetaOffset;
        private System.Windows.Forms.Panel panelBackgroundSubtraction;
        private System.Windows.Forms.Panel panelNormarizeIntensity;
        private System.Windows.Forms.Button buttonTwoThetaOffsetReset;
        public System.Windows.Forms.TextBox textBoxComment;
        public System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileDataGridViewTextBoxColumn;
    }
}