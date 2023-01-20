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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfileSetting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewProfile = new System.Windows.Forms.DataGridView();
            this.checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.profileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceProfile = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetProfile = new PDIndexer.DataSet();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.colorControlLineColor = new Crystallography.Controls.ColorControl();
            this.numericUpDownLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownSmoothingSavitzkyAndGolayN = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSmoothingSavitzkyAndGolayM = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxShowBackgroundProfile = new System.Windows.Forms.CheckBox();
            this.panelBackgroundReferrence = new System.Windows.Forms.Panel();
            this.comboBoxBackgroundReferrence = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownBackgroundReferrenceScale = new System.Windows.Forms.NumericUpDown();
            this.panelBackgroundBSpline = new System.Windows.Forms.Panel();
            this.buttonBackgroundAutoDetectBG = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDownBgPointsNumber = new System.Windows.Forms.NumericUpDown();
            this.radioButtonBackgroundReferrence = new System.Windows.Forms.RadioButton();
            this.radioButtonBagkgroundBSpline = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxSmoothing = new System.Windows.Forms.CheckBox();
            this.checkBoxBackgroundSubtraction = new System.Windows.Forms.CheckBox();
            this.buttonDeleteProfile = new System.Windows.Forms.Button();
            this.buttonUpper = new System.Windows.Forms.Button();
            this.buttonLower = new System.Windows.Forms.Button();
            this.numericUpDownNormarizeRangeHigh = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNormarizeRangeLow = new System.Windows.Forms.NumericUpDown();
            this.buttonChangeSourceXAxis = new System.Windows.Forms.Button();
            this.xAxisUserControl = new Crystallography.Controls.HorizontalAxisUserControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownShiftHorizontalAxis = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShiftHorizontalAxis = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericalTextBoxExposureTime = new Crystallography.Controls.NumericBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.radioButtonNormarizeMaximum = new System.Windows.Forms.RadioButton();
            this.radioButtonNormarizeAverage = new System.Windows.Forms.RadioButton();
            this.numericUpDownNormarizeIntensity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxTwoThetaOffset = new System.Windows.Forms.CheckBox();
            this.panelTwoThetaOffset = new System.Windows.Forms.Panel();
            this.numericBoxTwhoThetaOffsetCoeff2 = new Crystallography.Controls.NumericBox();
            this.numericBoxTwhoThetaOffsetCoeff0 = new Crystallography.Controls.NumericBox();
            this.buttonTwoThetaOffsetReset = new System.Windows.Forms.Button();
            this.buttonTwoThetaCalibration = new System.Windows.Forms.Button();
            this.numericBoxTwhoThetaOffsetCoeff1 = new Crystallography.Controls.NumericBox();
            this.label25 = new System.Windows.Forms.Label();
            this.checkBoxMaskingMode = new System.Windows.Forms.CheckBox();
            this.panelMaskingMode = new System.Windows.Forms.Panel();
            this.checkBoxShowMaskedRange = new System.Windows.Forms.CheckBox();
            this.numericUpDownInterpolationPoints = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.listBoxMaskRanges = new System.Windows.Forms.ListBox();
            this.contextMenuStripMaskRange = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSaveMaskingRange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReadMaskingRange = new System.Windows.Forms.ToolStripMenuItem();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonDeleteAllMask = new System.Windows.Forms.Button();
            this.numericUpDownInterpolationOrder = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonDeleteMask = new System.Windows.Forms.Button();
            this.panelSmoothing = new System.Windows.Forms.Panel();
            this.checkBoxBandPassFilter = new System.Windows.Forms.CheckBox();
            this.panelBandPassFilter = new System.Windows.Forms.Panel();
            this.numericUpDownHighPass = new System.Windows.Forms.NumericUpDown();
            this.checkBoxLowPassFilter = new System.Windows.Forms.CheckBox();
            this.numericUpDownLowPass = new System.Windows.Forms.NumericUpDown();
            this.checkBoxHighPassFilter = new System.Windows.Forms.CheckBox();
            this.labelHighPass = new System.Windows.Forms.Label();
            this.labelLowPath = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBoxRemoveKalpha2 = new System.Windows.Forms.CheckBox();
            this.panelBackgroundSubtraction = new System.Windows.Forms.Panel();
            this.checkBoxNormarizeIntensity = new System.Windows.Forms.CheckBox();
            this.panelNormarizeIntensity = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.buttonApplyAllProfiles = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBoxTwoProfiles1 = new System.Windows.Forms.ListBox();
            this.flowLayoutPanelFourCalculator = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonAddition = new System.Windows.Forms.RadioButton();
            this.radioButtonSubtraction = new System.Windows.Forms.RadioButton();
            this.radioButtonMutiplication = new System.Windows.Forms.RadioButton();
            this.radioButtonDivision = new System.Windows.Forms.RadioButton();
            this.numericalTextBoxTargetValue = new Crystallography.Controls.NumericBox();
            this.listBoxTwoProfiles2 = new System.Windows.Forms.ListBox();
            this.radioButtonAverage = new System.Windows.Forms.RadioButton();
            this.radioButtonProfileAndValue = new System.Windows.Forms.RadioButton();
            this.radioButtonTwoProfiles = new System.Windows.Forms.RadioButton();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.textBoxOutputFilename = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProfile)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmoothingSavitzkyAndGolayN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmoothingSavitzkyAndGolayM)).BeginInit();
            this.panelBackgroundReferrence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBackgroundReferrenceScale)).BeginInit();
            this.panelBackgroundBSpline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBgPointsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormarizeRangeHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormarizeRangeLow)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftHorizontalAxis)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormarizeIntensity)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelTwoThetaOffset.SuspendLayout();
            this.panelMaskingMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationPoints)).BeginInit();
            this.contextMenuStripMaskRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationOrder)).BeginInit();
            this.panelSmoothing.SuspendLayout();
            this.panelBandPassFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowPass)).BeginInit();
            this.panelBackgroundSubtraction.SuspendLayout();
            this.panelNormarizeIntensity.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelFourCalculator.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewProfile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            // 
            // dataGridViewProfile
            // 
            this.dataGridViewProfile.AllowUserToAddRows = false;
            this.dataGridViewProfile.AllowUserToDeleteRows = false;
            this.dataGridViewProfile.AllowUserToResizeColumns = false;
            this.dataGridViewProfile.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            this.dataGridViewProfile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProfile.AutoGenerateColumns = false;
            this.dataGridViewProfile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProfile.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProfile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProfile.ColumnHeadersVisible = false;
            this.dataGridViewProfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkDataGridViewCheckBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.profileDataGridViewTextBoxColumn});
            this.dataGridViewProfile.DataSource = this.bindingSourceProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProfile.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dataGridViewProfile, "dataGridViewProfile");
            this.dataGridViewProfile.MultiSelect = false;
            this.dataGridViewProfile.Name = "dataGridViewProfile";
            this.dataGridViewProfile.ReadOnly = true;
            this.dataGridViewProfile.RowHeadersVisible = false;
            this.dataGridViewProfile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewProfile.RowTemplate.Height = 21;
            this.dataGridViewProfile.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProfile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProfile_CellClick);
            this.dataGridViewProfile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProfile_CellClick);
            this.dataGridViewProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewProfile_KeyDown);
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            this.checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            resources.ApplyResources(this.checkDataGridViewCheckBoxColumn, "checkDataGridViewCheckBoxColumn");
            this.checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            this.checkDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            resources.ApplyResources(this.colorDataGridViewTextBoxColumn, "colorDataGridViewTextBoxColumn");
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            this.colorDataGridViewTextBoxColumn.ReadOnly = true;
            this.colorDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // profileDataGridViewTextBoxColumn
            // 
            this.profileDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.profileDataGridViewTextBoxColumn.DataPropertyName = "Profile";
            resources.ApplyResources(this.profileDataGridViewTextBoxColumn, "profileDataGridViewTextBoxColumn");
            this.profileDataGridViewTextBoxColumn.Name = "profileDataGridViewTextBoxColumn";
            this.profileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceProfile
            // 
            this.bindingSourceProfile.DataMember = "DataTableProfile";
            this.bindingSourceProfile.DataSource = this.dataSetProfile;
            this.bindingSourceProfile.CurrentChanged += new System.EventHandler(this.bindingSource_CurrentChanged);
            this.bindingSourceProfile.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
            // 
            // dataSetProfile
            // 
            this.dataSetProfile.DataSetName = "DataSet";
            this.dataSetProfile.Namespace = "http://tempuri.org/DataSet1.xsd";
            this.dataSetProfile.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxComment);
            this.groupBox3.Controls.Add(this.textBoxProfileName);
            this.groupBox3.Controls.Add(this.colorControlLineColor);
            this.groupBox3.Controls.Add(this.numericUpDownLineWidth);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // textBoxComment
            // 
            resources.ApplyResources(this.textBoxComment, "textBoxComment");
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.TextChanged += new System.EventHandler(this.textBoxComment_TextChanged);
            // 
            // textBoxProfileName
            // 
            resources.ApplyResources(this.textBoxProfileName, "textBoxProfileName");
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.TextChanged += new System.EventHandler(this.textBoxProfileName_TextChanged);
            // 
            // colorControlLineColor
            // 
            this.colorControlLineColor.Argb = -986896;
            resources.ApplyResources(this.colorControlLineColor, "colorControlLineColor");
            this.colorControlLineColor.Blue = 240;
            this.colorControlLineColor.BlueF = 0.9411765F;
            this.colorControlLineColor.BoxSize = new System.Drawing.Size(20, 20);
            this.colorControlLineColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.colorControlLineColor.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.colorControlLineColor.Green = 240;
            this.colorControlLineColor.GreenF = 0.9411765F;
            this.colorControlLineColor.Name = "colorControlLineColor";
            this.colorControlLineColor.Red = 240;
            this.colorControlLineColor.RedF = 0.9411765F;
            this.colorControlLineColor.ColorChanged += new System.EventHandler(this.colorControlLineColor_ColorChanged);
            // 
            // numericUpDownLineWidth
            // 
            this.numericUpDownLineWidth.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownLineWidth, "numericUpDownLineWidth");
            this.numericUpDownLineWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownLineWidth.Name = "numericUpDownLineWidth";
            this.numericUpDownLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLineWidth.ValueChanged += new System.EventHandler(this.numericUpDownLineWidth_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // numericUpDownSmoothingSavitzkyAndGolayN
            // 
            resources.ApplyResources(this.numericUpDownSmoothingSavitzkyAndGolayN, "numericUpDownSmoothingSavitzkyAndGolayN");
            this.numericUpDownSmoothingSavitzkyAndGolayN.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSmoothingSavitzkyAndGolayN.Name = "numericUpDownSmoothingSavitzkyAndGolayN";
            this.numericUpDownSmoothingSavitzkyAndGolayN.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownSmoothingSavitzkyAndGolayN.ValueChanged += new System.EventHandler(this.checkBoxSmoothing_CheckedChanged);
            // 
            // numericUpDownSmoothingSavitzkyAndGolayM
            // 
            resources.ApplyResources(this.numericUpDownSmoothingSavitzkyAndGolayM, "numericUpDownSmoothingSavitzkyAndGolayM");
            this.numericUpDownSmoothingSavitzkyAndGolayM.Name = "numericUpDownSmoothingSavitzkyAndGolayM";
            this.numericUpDownSmoothingSavitzkyAndGolayM.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownSmoothingSavitzkyAndGolayM.ValueChanged += new System.EventHandler(this.checkBoxSmoothing_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // checkBoxShowBackgroundProfile
            // 
            resources.ApplyResources(this.checkBoxShowBackgroundProfile, "checkBoxShowBackgroundProfile");
            this.checkBoxShowBackgroundProfile.Name = "checkBoxShowBackgroundProfile";
            this.checkBoxShowBackgroundProfile.CheckedChanged += new System.EventHandler(this.checkBoxBackgroundSubtraction_CheckedChanged);
            // 
            // panelBackgroundReferrence
            // 
            this.panelBackgroundReferrence.Controls.Add(this.comboBoxBackgroundReferrence);
            this.panelBackgroundReferrence.Controls.Add(this.label4);
            this.panelBackgroundReferrence.Controls.Add(this.numericUpDownBackgroundReferrenceScale);
            resources.ApplyResources(this.panelBackgroundReferrence, "panelBackgroundReferrence");
            this.panelBackgroundReferrence.Name = "panelBackgroundReferrence";
            // 
            // comboBoxBackgroundReferrence
            // 
            this.comboBoxBackgroundReferrence.DataSource = this.dataSetProfile;
            this.comboBoxBackgroundReferrence.DisplayMember = "DataTableProfile.Profile";
            this.comboBoxBackgroundReferrence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxBackgroundReferrence, "comboBoxBackgroundReferrence");
            this.comboBoxBackgroundReferrence.FormattingEnabled = true;
            this.comboBoxBackgroundReferrence.Name = "comboBoxBackgroundReferrence";
            this.comboBoxBackgroundReferrence.ValueMember = "DataTableProfile.Profile";
            this.comboBoxBackgroundReferrence.SelectedIndexChanged += new System.EventHandler(this.checkBoxBackgroundSubtraction_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // numericUpDownBackgroundReferrenceScale
            // 
            this.numericUpDownBackgroundReferrenceScale.DecimalPlaces = 4;
            resources.ApplyResources(this.numericUpDownBackgroundReferrenceScale, "numericUpDownBackgroundReferrenceScale");
            this.numericUpDownBackgroundReferrenceScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownBackgroundReferrenceScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDownBackgroundReferrenceScale.Name = "numericUpDownBackgroundReferrenceScale";
            this.numericUpDownBackgroundReferrenceScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBackgroundReferrenceScale.ValueChanged += new System.EventHandler(this.checkBoxBackgroundSubtraction_CheckedChanged);
            // 
            // panelBackgroundBSpline
            // 
            this.panelBackgroundBSpline.Controls.Add(this.buttonBackgroundAutoDetectBG);
            this.panelBackgroundBSpline.Controls.Add(this.label11);
            this.panelBackgroundBSpline.Controls.Add(this.numericUpDownBgPointsNumber);
            resources.ApplyResources(this.panelBackgroundBSpline, "panelBackgroundBSpline");
            this.panelBackgroundBSpline.Name = "panelBackgroundBSpline";
            // 
            // buttonBackgroundAutoDetectBG
            // 
            resources.ApplyResources(this.buttonBackgroundAutoDetectBG, "buttonBackgroundAutoDetectBG");
            this.buttonBackgroundAutoDetectBG.Name = "buttonBackgroundAutoDetectBG";
            this.buttonBackgroundAutoDetectBG.UseVisualStyleBackColor = true;
            this.buttonBackgroundAutoDetectBG.Click += new System.EventHandler(this.buttonAutoDetectBG_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // numericUpDownBgPointsNumber
            // 
            resources.ApplyResources(this.numericUpDownBgPointsNumber, "numericUpDownBgPointsNumber");
            this.numericUpDownBgPointsNumber.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBgPointsNumber.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownBgPointsNumber.Name = "numericUpDownBgPointsNumber";
            this.numericUpDownBgPointsNumber.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // radioButtonBackgroundReferrence
            // 
            resources.ApplyResources(this.radioButtonBackgroundReferrence, "radioButtonBackgroundReferrence");
            this.radioButtonBackgroundReferrence.Name = "radioButtonBackgroundReferrence";
            this.radioButtonBackgroundReferrence.UseVisualStyleBackColor = true;
            this.radioButtonBackgroundReferrence.CheckedChanged += new System.EventHandler(this.checkBoxBackgroundSubtraction_CheckedChanged);
            // 
            // radioButtonBagkgroundBSpline
            // 
            resources.ApplyResources(this.radioButtonBagkgroundBSpline, "radioButtonBagkgroundBSpline");
            this.radioButtonBagkgroundBSpline.Checked = true;
            this.radioButtonBagkgroundBSpline.Name = "radioButtonBagkgroundBSpline";
            this.radioButtonBagkgroundBSpline.TabStop = true;
            this.radioButtonBagkgroundBSpline.UseVisualStyleBackColor = true;
            this.radioButtonBagkgroundBSpline.CheckedChanged += new System.EventHandler(this.checkBoxBackgroundSubtraction_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // checkBoxSmoothing
            // 
            resources.ApplyResources(this.checkBoxSmoothing, "checkBoxSmoothing");
            this.checkBoxSmoothing.Name = "checkBoxSmoothing";
            this.checkBoxSmoothing.UseVisualStyleBackColor = true;
            this.checkBoxSmoothing.CheckedChanged += new System.EventHandler(this.checkBoxSmoothing_CheckedChanged);
            // 
            // checkBoxBackgroundSubtraction
            // 
            resources.ApplyResources(this.checkBoxBackgroundSubtraction, "checkBoxBackgroundSubtraction");
            this.checkBoxBackgroundSubtraction.Name = "checkBoxBackgroundSubtraction";
            this.checkBoxBackgroundSubtraction.UseVisualStyleBackColor = true;
            this.checkBoxBackgroundSubtraction.CheckedChanged += new System.EventHandler(this.checkBoxBackgroundSubtraction_CheckedChanged);
            // 
            // buttonDeleteProfile
            // 
            resources.ApplyResources(this.buttonDeleteProfile, "buttonDeleteProfile");
            this.buttonDeleteProfile.BackColor = System.Drawing.Color.IndianRed;
            this.buttonDeleteProfile.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteProfile.Name = "buttonDeleteProfile";
            this.buttonDeleteProfile.UseVisualStyleBackColor = false;
            this.buttonDeleteProfile.Click += new System.EventHandler(this.buttonDeleteProfile_Click);
            // 
            // buttonUpper
            // 
            resources.ApplyResources(this.buttonUpper, "buttonUpper");
            this.buttonUpper.Name = "buttonUpper";
            this.buttonUpper.Click += new System.EventHandler(this.buttonUpper_Click);
            // 
            // buttonLower
            // 
            resources.ApplyResources(this.buttonLower, "buttonLower");
            this.buttonLower.Name = "buttonLower";
            this.buttonLower.Click += new System.EventHandler(this.buttonLower_Click);
            // 
            // numericUpDownNormarizeRangeHigh
            // 
            this.numericUpDownNormarizeRangeHigh.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownNormarizeRangeHigh, "numericUpDownNormarizeRangeHigh");
            this.numericUpDownNormarizeRangeHigh.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownNormarizeRangeHigh.Name = "numericUpDownNormarizeRangeHigh";
            this.numericUpDownNormarizeRangeHigh.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDownNormarizeRangeHigh.ValueChanged += new System.EventHandler(this.checkBoxNormarizeIntensity_CheckStateChanged);
            // 
            // numericUpDownNormarizeRangeLow
            // 
            this.numericUpDownNormarizeRangeLow.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownNormarizeRangeLow, "numericUpDownNormarizeRangeLow");
            this.numericUpDownNormarizeRangeLow.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownNormarizeRangeLow.Name = "numericUpDownNormarizeRangeLow";
            this.numericUpDownNormarizeRangeLow.ValueChanged += new System.EventHandler(this.checkBoxNormarizeIntensity_CheckStateChanged);
            // 
            // buttonChangeSourceXAxis
            // 
            resources.ApplyResources(this.buttonChangeSourceXAxis, "buttonChangeSourceXAxis");
            this.buttonChangeSourceXAxis.Name = "buttonChangeSourceXAxis";
            this.buttonChangeSourceXAxis.UseVisualStyleBackColor = true;
            this.buttonChangeSourceXAxis.Click += new System.EventHandler(this.buttonChangeSouceXAxis_Click);
            // 
            // xAxisUserControl
            // 
            resources.ApplyResources(this.xAxisUserControl, "xAxisUserControl");
            this.xAxisUserControl.AxisMode = Crystallography.HorizontalAxis.Angle;
            this.xAxisUserControl.ElectronAccVoltage = 8.04151786D;
            this.xAxisUserControl.ElectronAccVoltageText = "8.04151786";
            this.xAxisUserControl.EnergyUnit = Crystallography.EnergyUnitEnum.eV;
            this.xAxisUserControl.Name = "xAxisUserControl";
            this.xAxisUserControl.TakeoffAngle = 5.9872200000000051D;
            this.xAxisUserControl.TakeoffAngleText = "343.042437016317";
            this.xAxisUserControl.TofAngle = 1.5707963267948966D;
            this.xAxisUserControl.TofAngleText = "90";
            this.xAxisUserControl.TofLength = 42D;
            this.xAxisUserControl.WaveColor = Crystallography.WaveColor.Monochrome;
            this.xAxisUserControl.WaveLength = 0.15418D;
            this.xAxisUserControl.WaveLengthText = "1.5418";
            this.xAxisUserControl.WaveSource = Crystallography.WaveSource.Xray;
            this.xAxisUserControl.XrayWaveSourceElementNumber = 0;
            this.xAxisUserControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.numericUpDownShiftHorizontalAxis);
            this.groupBox1.Controls.Add(this.checkBoxShiftHorizontalAxis);
            this.groupBox1.Controls.Add(this.xAxisUserControl);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // numericUpDownShiftHorizontalAxis
            // 
            resources.ApplyResources(this.numericUpDownShiftHorizontalAxis, "numericUpDownShiftHorizontalAxis");
            this.numericUpDownShiftHorizontalAxis.DecimalPlaces = 3;
            this.numericUpDownShiftHorizontalAxis.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownShiftHorizontalAxis.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownShiftHorizontalAxis.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numericUpDownShiftHorizontalAxis.Name = "numericUpDownShiftHorizontalAxis";
            this.numericUpDownShiftHorizontalAxis.ValueChanged += new System.EventHandler(this.checkBoxShiftHorizontalAxis_CheckedChanged);
            // 
            // checkBoxShiftHorizontalAxis
            // 
            resources.ApplyResources(this.checkBoxShiftHorizontalAxis, "checkBoxShiftHorizontalAxis");
            this.checkBoxShiftHorizontalAxis.Name = "checkBoxShiftHorizontalAxis";
            this.checkBoxShiftHorizontalAxis.UseVisualStyleBackColor = true;
            this.checkBoxShiftHorizontalAxis.CheckedChanged += new System.EventHandler(this.checkBoxShiftHorizontalAxis_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericalTextBoxExposureTime);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // numericalTextBoxExposureTime
            // 
            resources.ApplyResources(this.numericalTextBoxExposureTime, "numericalTextBoxExposureTime");
            this.numericalTextBoxExposureTime.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxExposureTime.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxExposureTime.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxExposureTime.Name = "numericalTextBoxExposureTime";
            this.numericalTextBoxExposureTime.RoundErrorAccuracy = -1;
            this.numericalTextBoxExposureTime.SkipEventDuringInput = false;
            this.numericalTextBoxExposureTime.SmartIncrement = true;
            this.numericalTextBoxExposureTime.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxExposureTime.ThonsandsSeparator = true;
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // radioButtonNormarizeMaximum
            // 
            resources.ApplyResources(this.radioButtonNormarizeMaximum, "radioButtonNormarizeMaximum");
            this.radioButtonNormarizeMaximum.Name = "radioButtonNormarizeMaximum";
            this.radioButtonNormarizeMaximum.UseVisualStyleBackColor = true;
            this.radioButtonNormarizeMaximum.CheckedChanged += new System.EventHandler(this.checkBoxNormarizeIntensity_CheckStateChanged);
            // 
            // radioButtonNormarizeAverage
            // 
            resources.ApplyResources(this.radioButtonNormarizeAverage, "radioButtonNormarizeAverage");
            this.radioButtonNormarizeAverage.Checked = true;
            this.radioButtonNormarizeAverage.Name = "radioButtonNormarizeAverage";
            this.radioButtonNormarizeAverage.TabStop = true;
            this.radioButtonNormarizeAverage.UseVisualStyleBackColor = true;
            this.radioButtonNormarizeAverage.CheckedChanged += new System.EventHandler(this.checkBoxNormarizeIntensity_CheckStateChanged);
            // 
            // numericUpDownNormarizeIntensity
            // 
            this.numericUpDownNormarizeIntensity.DecimalPlaces = 3;
            resources.ApplyResources(this.numericUpDownNormarizeIntensity, "numericUpDownNormarizeIntensity");
            this.numericUpDownNormarizeIntensity.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownNormarizeIntensity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownNormarizeIntensity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNormarizeIntensity.Name = "numericUpDownNormarizeIntensity";
            this.numericUpDownNormarizeIntensity.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNormarizeIntensity.ValueChanged += new System.EventHandler(this.checkBoxNormarizeIntensity_CheckStateChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonDeleteAllProfiles_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.HotTrack = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Controls.Add(this.buttonApplyAllProfiles);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.checkBoxTwoThetaOffset);
            this.flowLayoutPanel1.Controls.Add(this.panelTwoThetaOffset);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxMaskingMode);
            this.flowLayoutPanel1.Controls.Add(this.panelMaskingMode);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxSmoothing);
            this.flowLayoutPanel1.Controls.Add(this.panelSmoothing);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxBandPassFilter);
            this.flowLayoutPanel1.Controls.Add(this.panelBandPassFilter);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxRemoveKalpha2);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxBackgroundSubtraction);
            this.flowLayoutPanel1.Controls.Add(this.panelBackgroundSubtraction);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxNormarizeIntensity);
            this.flowLayoutPanel1.Controls.Add(this.panelNormarizeIntensity);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // checkBoxTwoThetaOffset
            // 
            resources.ApplyResources(this.checkBoxTwoThetaOffset, "checkBoxTwoThetaOffset");
            this.checkBoxTwoThetaOffset.Name = "checkBoxTwoThetaOffset";
            this.checkBoxTwoThetaOffset.UseVisualStyleBackColor = true;
            this.checkBoxTwoThetaOffset.CheckedChanged += new System.EventHandler(this.checkBoxTwoThetaOffset_CheckedChanged);
            // 
            // panelTwoThetaOffset
            // 
            this.panelTwoThetaOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTwoThetaOffset.Controls.Add(this.numericBoxTwhoThetaOffsetCoeff2);
            this.panelTwoThetaOffset.Controls.Add(this.numericBoxTwhoThetaOffsetCoeff0);
            this.panelTwoThetaOffset.Controls.Add(this.buttonTwoThetaOffsetReset);
            this.panelTwoThetaOffset.Controls.Add(this.buttonTwoThetaCalibration);
            this.panelTwoThetaOffset.Controls.Add(this.numericBoxTwhoThetaOffsetCoeff1);
            this.panelTwoThetaOffset.Controls.Add(this.label25);
            resources.ApplyResources(this.panelTwoThetaOffset, "panelTwoThetaOffset");
            this.panelTwoThetaOffset.Name = "panelTwoThetaOffset";
            // 
            // numericBoxTwhoThetaOffsetCoeff2
            // 
            resources.ApplyResources(this.numericBoxTwhoThetaOffsetCoeff2, "numericBoxTwhoThetaOffsetCoeff2");
            this.numericBoxTwhoThetaOffsetCoeff2.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTwhoThetaOffsetCoeff2.DecimalPlaces = 5;
            this.numericBoxTwhoThetaOffsetCoeff2.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTwhoThetaOffsetCoeff2.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTwhoThetaOffsetCoeff2.Name = "numericBoxTwhoThetaOffsetCoeff2";
            this.numericBoxTwhoThetaOffsetCoeff2.RoundErrorAccuracy = -1;
            this.numericBoxTwhoThetaOffsetCoeff2.SkipEventDuringInput = false;
            this.numericBoxTwhoThetaOffsetCoeff2.SmartIncrement = true;
            this.numericBoxTwhoThetaOffsetCoeff2.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxTwhoThetaOffsetCoeff2.ThonsandsSeparator = true;
            this.numericBoxTwhoThetaOffsetCoeff2.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.checkBoxTwoThetaOffset_CheckedChanged);
            // 
            // numericBoxTwhoThetaOffsetCoeff0
            // 
            resources.ApplyResources(this.numericBoxTwhoThetaOffsetCoeff0, "numericBoxTwhoThetaOffsetCoeff0");
            this.numericBoxTwhoThetaOffsetCoeff0.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTwhoThetaOffsetCoeff0.DecimalPlaces = 5;
            this.numericBoxTwhoThetaOffsetCoeff0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTwhoThetaOffsetCoeff0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTwhoThetaOffsetCoeff0.Name = "numericBoxTwhoThetaOffsetCoeff0";
            this.numericBoxTwhoThetaOffsetCoeff0.RoundErrorAccuracy = -1;
            this.numericBoxTwhoThetaOffsetCoeff0.SkipEventDuringInput = false;
            this.numericBoxTwhoThetaOffsetCoeff0.SmartIncrement = true;
            this.numericBoxTwhoThetaOffsetCoeff0.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxTwhoThetaOffsetCoeff0.ThonsandsSeparator = true;
            this.numericBoxTwhoThetaOffsetCoeff0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.checkBoxTwoThetaOffset_CheckedChanged);
            // 
            // buttonTwoThetaOffsetReset
            // 
            resources.ApplyResources(this.buttonTwoThetaOffsetReset, "buttonTwoThetaOffsetReset");
            this.buttonTwoThetaOffsetReset.Name = "buttonTwoThetaOffsetReset";
            this.buttonTwoThetaOffsetReset.UseVisualStyleBackColor = true;
            this.buttonTwoThetaOffsetReset.Click += new System.EventHandler(this.buttonTwoThetaOffsetReset_Click);
            // 
            // buttonTwoThetaCalibration
            // 
            resources.ApplyResources(this.buttonTwoThetaCalibration, "buttonTwoThetaCalibration");
            this.buttonTwoThetaCalibration.Name = "buttonTwoThetaCalibration";
            this.buttonTwoThetaCalibration.UseVisualStyleBackColor = true;
            this.buttonTwoThetaCalibration.Click += new System.EventHandler(this.buttonTwoThetaCalibration_Click);
            // 
            // numericBoxTwhoThetaOffsetCoeff1
            // 
            resources.ApplyResources(this.numericBoxTwhoThetaOffsetCoeff1, "numericBoxTwhoThetaOffsetCoeff1");
            this.numericBoxTwhoThetaOffsetCoeff1.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTwhoThetaOffsetCoeff1.DecimalPlaces = 5;
            this.numericBoxTwhoThetaOffsetCoeff1.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTwhoThetaOffsetCoeff1.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTwhoThetaOffsetCoeff1.Name = "numericBoxTwhoThetaOffsetCoeff1";
            this.numericBoxTwhoThetaOffsetCoeff1.RoundErrorAccuracy = -1;
            this.numericBoxTwhoThetaOffsetCoeff1.SkipEventDuringInput = false;
            this.numericBoxTwhoThetaOffsetCoeff1.SmartIncrement = true;
            this.numericBoxTwhoThetaOffsetCoeff1.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxTwhoThetaOffsetCoeff1.ThonsandsSeparator = true;
            this.numericBoxTwhoThetaOffsetCoeff1.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.checkBoxTwoThetaOffset_CheckedChanged);
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // checkBoxMaskingMode
            // 
            resources.ApplyResources(this.checkBoxMaskingMode, "checkBoxMaskingMode");
            this.checkBoxMaskingMode.Name = "checkBoxMaskingMode";
            this.checkBoxMaskingMode.UseVisualStyleBackColor = true;
            this.checkBoxMaskingMode.CheckedChanged += new System.EventHandler(this.checkBoxMaskingMode_CheckedChanged);
            // 
            // panelMaskingMode
            // 
            this.panelMaskingMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMaskingMode.Controls.Add(this.checkBoxShowMaskedRange);
            this.panelMaskingMode.Controls.Add(this.numericUpDownInterpolationPoints);
            this.panelMaskingMode.Controls.Add(this.label20);
            this.panelMaskingMode.Controls.Add(this.listBoxMaskRanges);
            this.panelMaskingMode.Controls.Add(this.label21);
            this.panelMaskingMode.Controls.Add(this.buttonDeleteAllMask);
            this.panelMaskingMode.Controls.Add(this.numericUpDownInterpolationOrder);
            this.panelMaskingMode.Controls.Add(this.label19);
            this.panelMaskingMode.Controls.Add(this.buttonDeleteMask);
            resources.ApplyResources(this.panelMaskingMode, "panelMaskingMode");
            this.panelMaskingMode.Name = "panelMaskingMode";
            // 
            // checkBoxShowMaskedRange
            // 
            resources.ApplyResources(this.checkBoxShowMaskedRange, "checkBoxShowMaskedRange");
            this.checkBoxShowMaskedRange.Checked = true;
            this.checkBoxShowMaskedRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowMaskedRange.Name = "checkBoxShowMaskedRange";
            this.checkBoxShowMaskedRange.UseVisualStyleBackColor = true;
            this.checkBoxShowMaskedRange.CheckedChanged += new System.EventHandler(this.checkBoxMaskingMode_CheckedChanged);
            // 
            // numericUpDownInterpolationPoints
            // 
            resources.ApplyResources(this.numericUpDownInterpolationPoints, "numericUpDownInterpolationPoints");
            this.numericUpDownInterpolationPoints.Name = "numericUpDownInterpolationPoints";
            this.toolTip.SetToolTip(this.numericUpDownInterpolationPoints, resources.GetString("numericUpDownInterpolationPoints.ToolTip"));
            this.numericUpDownInterpolationPoints.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownInterpolationPoints.ValueChanged += new System.EventHandler(this.checkBoxMaskingMode_CheckedChanged);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            this.toolTip.SetToolTip(this.label20, resources.GetString("label20.ToolTip"));
            // 
            // listBoxMaskRanges
            // 
            this.listBoxMaskRanges.AllowDrop = true;
            this.listBoxMaskRanges.ContextMenuStrip = this.contextMenuStripMaskRange;
            resources.ApplyResources(this.listBoxMaskRanges, "listBoxMaskRanges");
            this.listBoxMaskRanges.FormattingEnabled = true;
            this.listBoxMaskRanges.Name = "listBoxMaskRanges";
            this.listBoxMaskRanges.SelectedIndexChanged += new System.EventHandler(this.listBoxMaskRanges_SelectedIndexChanged);
            this.listBoxMaskRanges.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxMaskRanges_DragDrop);
            this.listBoxMaskRanges.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxMaskRanges_DragEnter);
            // 
            // contextMenuStripMaskRange
            // 
            this.contextMenuStripMaskRange.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSaveMaskingRange,
            this.toolStripMenuItemReadMaskingRange});
            this.contextMenuStripMaskRange.Name = "contextMenuStripMaskRange";
            resources.ApplyResources(this.contextMenuStripMaskRange, "contextMenuStripMaskRange");
            // 
            // toolStripMenuItemSaveMaskingRange
            // 
            this.toolStripMenuItemSaveMaskingRange.Name = "toolStripMenuItemSaveMaskingRange";
            resources.ApplyResources(this.toolStripMenuItemSaveMaskingRange, "toolStripMenuItemSaveMaskingRange");
            this.toolStripMenuItemSaveMaskingRange.Click += new System.EventHandler(this.toolStripMenuItemSaveMaskingRange_Click);
            // 
            // toolStripMenuItemReadMaskingRange
            // 
            this.toolStripMenuItemReadMaskingRange.Name = "toolStripMenuItemReadMaskingRange";
            resources.ApplyResources(this.toolStripMenuItemReadMaskingRange, "toolStripMenuItemReadMaskingRange");
            this.toolStripMenuItemReadMaskingRange.Click += new System.EventHandler(this.toolStripMenuItemReadMaskingRange_Click);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            this.toolTip.SetToolTip(this.label21, resources.GetString("label21.ToolTip"));
            // 
            // buttonDeleteAllMask
            // 
            resources.ApplyResources(this.buttonDeleteAllMask, "buttonDeleteAllMask");
            this.buttonDeleteAllMask.BackColor = System.Drawing.Color.DarkRed;
            this.buttonDeleteAllMask.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteAllMask.Name = "buttonDeleteAllMask";
            this.buttonDeleteAllMask.UseVisualStyleBackColor = false;
            this.buttonDeleteAllMask.Click += new System.EventHandler(this.buttonDeleteAllMask_Click);
            // 
            // numericUpDownInterpolationOrder
            // 
            resources.ApplyResources(this.numericUpDownInterpolationOrder, "numericUpDownInterpolationOrder");
            this.numericUpDownInterpolationOrder.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownInterpolationOrder.Name = "numericUpDownInterpolationOrder";
            this.numericUpDownInterpolationOrder.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownInterpolationOrder.ValueChanged += new System.EventHandler(this.checkBoxMaskingMode_CheckedChanged);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // buttonDeleteMask
            // 
            resources.ApplyResources(this.buttonDeleteMask, "buttonDeleteMask");
            this.buttonDeleteMask.BackColor = System.Drawing.Color.IndianRed;
            this.buttonDeleteMask.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteMask.Name = "buttonDeleteMask";
            this.buttonDeleteMask.UseVisualStyleBackColor = false;
            this.buttonDeleteMask.Click += new System.EventHandler(this.buttonDeleteMask_Click);
            // 
            // panelSmoothing
            // 
            this.panelSmoothing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSmoothing.Controls.Add(this.numericUpDownSmoothingSavitzkyAndGolayN);
            this.panelSmoothing.Controls.Add(this.label17);
            this.panelSmoothing.Controls.Add(this.numericUpDownSmoothingSavitzkyAndGolayM);
            this.panelSmoothing.Controls.Add(this.label10);
            this.panelSmoothing.Controls.Add(this.label5);
            resources.ApplyResources(this.panelSmoothing, "panelSmoothing");
            this.panelSmoothing.Name = "panelSmoothing";
            // 
            // checkBoxBandPassFilter
            // 
            resources.ApplyResources(this.checkBoxBandPassFilter, "checkBoxBandPassFilter");
            this.checkBoxBandPassFilter.Name = "checkBoxBandPassFilter";
            this.checkBoxBandPassFilter.UseVisualStyleBackColor = true;
            this.checkBoxBandPassFilter.CheckedChanged += new System.EventHandler(this.checkBoxBandPassFilter_CheckedChanged);
            // 
            // panelBandPassFilter
            // 
            this.panelBandPassFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBandPassFilter.Controls.Add(this.numericUpDownHighPass);
            this.panelBandPassFilter.Controls.Add(this.checkBoxLowPassFilter);
            this.panelBandPassFilter.Controls.Add(this.numericUpDownLowPass);
            this.panelBandPassFilter.Controls.Add(this.checkBoxHighPassFilter);
            this.panelBandPassFilter.Controls.Add(this.labelHighPass);
            this.panelBandPassFilter.Controls.Add(this.labelLowPath);
            resources.ApplyResources(this.panelBandPassFilter, "panelBandPassFilter");
            this.panelBandPassFilter.Name = "panelBandPassFilter";
            // 
            // numericUpDownHighPass
            // 
            this.numericUpDownHighPass.DecimalPlaces = 2;
            resources.ApplyResources(this.numericUpDownHighPass, "numericUpDownHighPass");
            this.numericUpDownHighPass.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownHighPass.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHighPass.Name = "numericUpDownHighPass";
            this.numericUpDownHighPass.ValueChanged += new System.EventHandler(this.checkBoxBandPassFilter_CheckedChanged);
            // 
            // checkBoxLowPassFilter
            // 
            resources.ApplyResources(this.checkBoxLowPassFilter, "checkBoxLowPassFilter");
            this.checkBoxLowPassFilter.Name = "checkBoxLowPassFilter";
            this.checkBoxLowPassFilter.UseVisualStyleBackColor = true;
            this.checkBoxLowPassFilter.CheckedChanged += new System.EventHandler(this.checkBoxBandPassFilter_CheckedChanged);
            // 
            // numericUpDownLowPass
            // 
            this.numericUpDownLowPass.DecimalPlaces = 2;
            resources.ApplyResources(this.numericUpDownLowPass, "numericUpDownLowPass");
            this.numericUpDownLowPass.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownLowPass.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLowPass.Name = "numericUpDownLowPass";
            this.numericUpDownLowPass.ValueChanged += new System.EventHandler(this.checkBoxBandPassFilter_CheckedChanged);
            // 
            // checkBoxHighPassFilter
            // 
            resources.ApplyResources(this.checkBoxHighPassFilter, "checkBoxHighPassFilter");
            this.checkBoxHighPassFilter.Name = "checkBoxHighPassFilter";
            this.checkBoxHighPassFilter.UseVisualStyleBackColor = true;
            this.checkBoxHighPassFilter.CheckedChanged += new System.EventHandler(this.checkBoxBandPassFilter_CheckedChanged);
            // 
            // labelHighPass
            // 
            resources.ApplyResources(this.labelHighPass, "labelHighPass");
            this.labelHighPass.Name = "labelHighPass";
            // 
            // labelLowPath
            // 
            resources.ApplyResources(this.labelLowPath, "labelLowPath");
            this.labelLowPath.Name = "labelLowPath";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // checkBoxRemoveKalpha2
            // 
            resources.ApplyResources(this.checkBoxRemoveKalpha2, "checkBoxRemoveKalpha2");
            this.checkBoxRemoveKalpha2.Name = "checkBoxRemoveKalpha2";
            this.checkBoxRemoveKalpha2.UseVisualStyleBackColor = true;
            this.checkBoxRemoveKalpha2.CheckedChanged += new System.EventHandler(this.checkBoxRemoveKalpha2_CheckedChanged);
            // 
            // panelBackgroundSubtraction
            // 
            this.panelBackgroundSubtraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBackgroundSubtraction.Controls.Add(this.checkBoxShowBackgroundProfile);
            this.panelBackgroundSubtraction.Controls.Add(this.panelBackgroundReferrence);
            this.panelBackgroundSubtraction.Controls.Add(this.radioButtonBagkgroundBSpline);
            this.panelBackgroundSubtraction.Controls.Add(this.panelBackgroundBSpline);
            this.panelBackgroundSubtraction.Controls.Add(this.radioButtonBackgroundReferrence);
            resources.ApplyResources(this.panelBackgroundSubtraction, "panelBackgroundSubtraction");
            this.panelBackgroundSubtraction.Name = "panelBackgroundSubtraction";
            // 
            // checkBoxNormarizeIntensity
            // 
            resources.ApplyResources(this.checkBoxNormarizeIntensity, "checkBoxNormarizeIntensity");
            this.checkBoxNormarizeIntensity.Name = "checkBoxNormarizeIntensity";
            this.checkBoxNormarizeIntensity.UseVisualStyleBackColor = true;
            this.checkBoxNormarizeIntensity.CheckedChanged += new System.EventHandler(this.checkBoxNormarizeIntensity_CheckStateChanged);
            // 
            // panelNormarizeIntensity
            // 
            this.panelNormarizeIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNormarizeIntensity.Controls.Add(this.radioButtonNormarizeAverage);
            this.panelNormarizeIntensity.Controls.Add(this.label16);
            this.panelNormarizeIntensity.Controls.Add(this.numericUpDownNormarizeRangeLow);
            this.panelNormarizeIntensity.Controls.Add(this.numericUpDownNormarizeRangeHigh);
            this.panelNormarizeIntensity.Controls.Add(this.radioButtonNormarizeMaximum);
            this.panelNormarizeIntensity.Controls.Add(this.numericUpDownNormarizeIntensity);
            this.panelNormarizeIntensity.Controls.Add(this.label14);
            this.panelNormarizeIntensity.Controls.Add(this.label13);
            this.panelNormarizeIntensity.Controls.Add(this.label3);
            this.panelNormarizeIntensity.Controls.Add(this.label23);
            resources.ApplyResources(this.panelNormarizeIntensity, "panelNormarizeIntensity");
            this.panelNormarizeIntensity.Name = "panelNormarizeIntensity";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // buttonApplyAllProfiles
            // 
            resources.ApplyResources(this.buttonApplyAllProfiles, "buttonApplyAllProfiles");
            this.buttonApplyAllProfiles.Name = "buttonApplyAllProfiles";
            this.buttonApplyAllProfiles.UseVisualStyleBackColor = true;
            this.buttonApplyAllProfiles.Click += new System.EventHandler(this.buttonApplyAllProfiles_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.buttonChangeSourceXAxis);
            this.tabPage3.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.radioButtonAverage);
            this.tabPage1.Controls.Add(this.radioButtonProfileAndValue);
            this.tabPage1.Controls.Add(this.radioButtonTwoProfiles);
            this.tabPage1.Controls.Add(this.buttonCalculate);
            this.tabPage1.Controls.Add(this.textBoxOutputFilename);
            this.tabPage1.Controls.Add(this.label18);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.listBoxTwoProfiles1);
            this.panel1.Controls.Add(this.flowLayoutPanelFourCalculator);
            this.panel1.Controls.Add(this.listBoxTwoProfiles2);
            this.panel1.Name = "panel1";
            // 
            // listBoxTwoProfiles1
            // 
            resources.ApplyResources(this.listBoxTwoProfiles1, "listBoxTwoProfiles1");
            this.listBoxTwoProfiles1.FormattingEnabled = true;
            this.listBoxTwoProfiles1.Name = "listBoxTwoProfiles1";
            this.listBoxTwoProfiles1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // flowLayoutPanelFourCalculator
            // 
            resources.ApplyResources(this.flowLayoutPanelFourCalculator, "flowLayoutPanelFourCalculator");
            this.flowLayoutPanelFourCalculator.Controls.Add(this.radioButtonAddition);
            this.flowLayoutPanelFourCalculator.Controls.Add(this.radioButtonSubtraction);
            this.flowLayoutPanelFourCalculator.Controls.Add(this.radioButtonMutiplication);
            this.flowLayoutPanelFourCalculator.Controls.Add(this.radioButtonDivision);
            this.flowLayoutPanelFourCalculator.Controls.Add(this.numericalTextBoxTargetValue);
            this.flowLayoutPanelFourCalculator.Name = "flowLayoutPanelFourCalculator";
            // 
            // radioButtonAddition
            // 
            resources.ApplyResources(this.radioButtonAddition, "radioButtonAddition");
            this.radioButtonAddition.Checked = true;
            this.radioButtonAddition.Name = "radioButtonAddition";
            this.radioButtonAddition.TabStop = true;
            this.radioButtonAddition.UseVisualStyleBackColor = true;
            // 
            // radioButtonSubtraction
            // 
            resources.ApplyResources(this.radioButtonSubtraction, "radioButtonSubtraction");
            this.radioButtonSubtraction.Name = "radioButtonSubtraction";
            this.radioButtonSubtraction.UseVisualStyleBackColor = true;
            // 
            // radioButtonMutiplication
            // 
            resources.ApplyResources(this.radioButtonMutiplication, "radioButtonMutiplication");
            this.radioButtonMutiplication.Name = "radioButtonMutiplication";
            this.radioButtonMutiplication.UseVisualStyleBackColor = true;
            // 
            // radioButtonDivision
            // 
            resources.ApplyResources(this.radioButtonDivision, "radioButtonDivision");
            this.radioButtonDivision.Name = "radioButtonDivision";
            this.radioButtonDivision.UseVisualStyleBackColor = true;
            // 
            // numericalTextBoxTargetValue
            // 
            resources.ApplyResources(this.numericalTextBoxTargetValue, "numericalTextBoxTargetValue");
            this.numericalTextBoxTargetValue.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxTargetValue.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxTargetValue.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxTargetValue.Name = "numericalTextBoxTargetValue";
            this.numericalTextBoxTargetValue.RoundErrorAccuracy = -1;
            this.numericalTextBoxTargetValue.SkipEventDuringInput = false;
            this.numericalTextBoxTargetValue.SmartIncrement = true;
            this.numericalTextBoxTargetValue.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxTargetValue.ThonsandsSeparator = true;
            // 
            // listBoxTwoProfiles2
            // 
            resources.ApplyResources(this.listBoxTwoProfiles2, "listBoxTwoProfiles2");
            this.listBoxTwoProfiles2.FormattingEnabled = true;
            this.listBoxTwoProfiles2.Items.AddRange(new object[] {
            resources.GetString("listBoxTwoProfiles2.Items")});
            this.listBoxTwoProfiles2.Name = "listBoxTwoProfiles2";
            // 
            // radioButtonAverage
            // 
            resources.ApplyResources(this.radioButtonAverage, "radioButtonAverage");
            this.radioButtonAverage.Checked = true;
            this.radioButtonAverage.Name = "radioButtonAverage";
            this.radioButtonAverage.TabStop = true;
            this.radioButtonAverage.UseVisualStyleBackColor = true;
            this.radioButtonAverage.CheckedChanged += new System.EventHandler(this.radioButtonAverage_CheckedChanged);
            // 
            // radioButtonProfileAndValue
            // 
            resources.ApplyResources(this.radioButtonProfileAndValue, "radioButtonProfileAndValue");
            this.radioButtonProfileAndValue.Name = "radioButtonProfileAndValue";
            this.radioButtonProfileAndValue.UseVisualStyleBackColor = true;
            this.radioButtonProfileAndValue.CheckedChanged += new System.EventHandler(this.radioButtonAverage_CheckedChanged);
            // 
            // radioButtonTwoProfiles
            // 
            resources.ApplyResources(this.radioButtonTwoProfiles, "radioButtonTwoProfiles");
            this.radioButtonTwoProfiles.Name = "radioButtonTwoProfiles";
            this.radioButtonTwoProfiles.UseVisualStyleBackColor = true;
            this.radioButtonTwoProfiles.CheckedChanged += new System.EventHandler(this.radioButtonAverage_CheckedChanged);
            // 
            // buttonCalculate
            // 
            resources.ApplyResources(this.buttonCalculate, "buttonCalculate");
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // textBoxOutputFilename
            // 
            resources.ApplyResources(this.textBoxOutputFilename, "textBoxOutputFilename");
            this.textBoxOutputFilename.Name = "textBoxOutputFilename";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // FormProfileSetting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDeleteProfile);
            this.Controls.Add(this.buttonUpper);
            this.Controls.Add(this.buttonLower);
            this.Name = "FormProfileSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProfileSetting_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProfile)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmoothingSavitzkyAndGolayN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSmoothingSavitzkyAndGolayM)).EndInit();
            this.panelBackgroundReferrence.ResumeLayout(false);
            this.panelBackgroundReferrence.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBackgroundReferrenceScale)).EndInit();
            this.panelBackgroundBSpline.ResumeLayout(false);
            this.panelBackgroundBSpline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBgPointsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormarizeRangeHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormarizeRangeLow)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownShiftHorizontalAxis)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNormarizeIntensity)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelTwoThetaOffset.ResumeLayout(false);
            this.panelTwoThetaOffset.PerformLayout();
            this.panelMaskingMode.ResumeLayout(false);
            this.panelMaskingMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationPoints)).EndInit();
            this.contextMenuStripMaskRange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterpolationOrder)).EndInit();
            this.panelSmoothing.ResumeLayout(false);
            this.panelSmoothing.PerformLayout();
            this.panelBandPassFilter.ResumeLayout(false);
            this.panelBandPassFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowPass)).EndInit();
            this.panelBackgroundSubtraction.ResumeLayout(false);
            this.panelBackgroundSubtraction.PerformLayout();
            this.panelNormarizeIntensity.ResumeLayout(false);
            this.panelNormarizeIntensity.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanelFourCalculator.ResumeLayout(false);
            this.flowLayoutPanelFourCalculator.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileDataGridViewTextBoxColumn;
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
    }
}