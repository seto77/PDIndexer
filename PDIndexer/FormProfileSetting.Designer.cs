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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            dataGridViewProfile = new System.Windows.Forms.DataGridView();
            checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            profileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            resources.ApplyResources(splitContainer1.Panel1, "splitContainer1.Panel1");
            splitContainer1.Panel1.Controls.Add(dataGridViewProfile);
            toolTip.SetToolTip(splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(splitContainer1.Panel2, "splitContainer1.Panel2");
            splitContainer1.Panel2.Controls.Add(groupBox3);
            toolTip.SetToolTip(splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            toolTip.SetToolTip(splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            // 
            // dataGridViewProfile
            // 
            resources.ApplyResources(dataGridViewProfile, "dataGridViewProfile");
            dataGridViewProfile.AllowUserToAddRows = false;
            dataGridViewProfile.AllowUserToDeleteRows = false;
            dataGridViewProfile.AllowUserToResizeColumns = false;
            dataGridViewProfile.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewProfile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewProfile.AutoGenerateColumns = false;
            dataGridViewProfile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewProfile.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridViewProfile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewProfile.ColumnHeadersVisible = false;
            dataGridViewProfile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { checkDataGridViewCheckBoxColumn, colorDataGridViewTextBoxColumn, profileDataGridViewTextBoxColumn });
            dataGridViewProfile.DataSource = bindingSourceProfile;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewProfile.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewProfile.MultiSelect = false;
            dataGridViewProfile.Name = "dataGridViewProfile";
            dataGridViewProfile.ReadOnly = true;
            dataGridViewProfile.RowHeadersVisible = false;
            dataGridViewProfile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewProfile.RowTemplate.Height = 21;
            dataGridViewProfile.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dataGridViewProfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            toolTip.SetToolTip(dataGridViewProfile, resources.GetString("dataGridViewProfile.ToolTip"));
            dataGridViewProfile.CellClick += dataGridViewProfile_CellClick;
            dataGridViewProfile.CellDoubleClick += dataGridViewProfile_CellClick;
            dataGridViewProfile.KeyDown += dataGridViewProfile_KeyDown;
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
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(textBoxComment);
            groupBox3.Controls.Add(textBoxProfileName);
            groupBox3.Controls.Add(colorControlLineColor);
            groupBox3.Controls.Add(numericUpDownLineWidth);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label22);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label9);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            toolTip.SetToolTip(groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // textBoxComment
            // 
            resources.ApplyResources(textBoxComment, "textBoxComment");
            textBoxComment.Name = "textBoxComment";
            toolTip.SetToolTip(textBoxComment, resources.GetString("textBoxComment.ToolTip"));
            textBoxComment.TextChanged += textBoxComment_TextChanged;
            // 
            // textBoxProfileName
            // 
            resources.ApplyResources(textBoxProfileName, "textBoxProfileName");
            textBoxProfileName.Name = "textBoxProfileName";
            toolTip.SetToolTip(textBoxProfileName, resources.GetString("textBoxProfileName.ToolTip"));
            textBoxProfileName.TextChanged += textBoxProfileName_TextChanged;
            // 
            // colorControlLineColor
            // 
            resources.ApplyResources(colorControlLineColor, "colorControlLineColor");
            colorControlLineColor.Argb = -986896;
            colorControlLineColor.Blue = 240;
            colorControlLineColor.BlueF = 0.9411765F;
            colorControlLineColor.BoxSize = new System.Drawing.Size(20, 20);
            colorControlLineColor.Color = System.Drawing.Color.FromArgb(240, 240, 240);
            colorControlLineColor.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            colorControlLineColor.Green = 240;
            colorControlLineColor.GreenF = 0.9411765F;
            colorControlLineColor.Name = "colorControlLineColor";
            colorControlLineColor.Red = 240;
            colorControlLineColor.RedF = 0.9411765F;
            toolTip.SetToolTip(colorControlLineColor, resources.GetString("colorControlLineColor.ToolTip"));
            colorControlLineColor.ColorChanged += colorControlLineColor_ColorChanged;
            // 
            // numericUpDownLineWidth
            // 
            resources.ApplyResources(numericUpDownLineWidth, "numericUpDownLineWidth");
            numericUpDownLineWidth.DecimalPlaces = 1;
            numericUpDownLineWidth.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numericUpDownLineWidth.Name = "numericUpDownLineWidth";
            toolTip.SetToolTip(numericUpDownLineWidth, resources.GetString("numericUpDownLineWidth.ToolTip"));
            numericUpDownLineWidth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownLineWidth.ValueChanged += numericUpDownLineWidth_ValueChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            toolTip.SetToolTip(label7, resources.GetString("label7.ToolTip"));
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            toolTip.SetToolTip(label22, resources.GetString("label22.ToolTip"));
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            toolTip.SetToolTip(label8, resources.GetString("label8.ToolTip"));
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            toolTip.SetToolTip(label9, resources.GetString("label9.ToolTip"));
            // 
            // numericUpDownSmoothingSavitzkyAndGolayN
            // 
            resources.ApplyResources(numericUpDownSmoothingSavitzkyAndGolayN, "numericUpDownSmoothingSavitzkyAndGolayN");
            numericUpDownSmoothingSavitzkyAndGolayN.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownSmoothingSavitzkyAndGolayN.Name = "numericUpDownSmoothingSavitzkyAndGolayN";
            toolTip.SetToolTip(numericUpDownSmoothingSavitzkyAndGolayN, resources.GetString("numericUpDownSmoothingSavitzkyAndGolayN.ToolTip"));
            numericUpDownSmoothingSavitzkyAndGolayN.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownSmoothingSavitzkyAndGolayN.ValueChanged += checkBoxSmoothing_CheckedChanged;
            // 
            // numericUpDownSmoothingSavitzkyAndGolayM
            // 
            resources.ApplyResources(numericUpDownSmoothingSavitzkyAndGolayM, "numericUpDownSmoothingSavitzkyAndGolayM");
            numericUpDownSmoothingSavitzkyAndGolayM.Name = "numericUpDownSmoothingSavitzkyAndGolayM";
            toolTip.SetToolTip(numericUpDownSmoothingSavitzkyAndGolayM, resources.GetString("numericUpDownSmoothingSavitzkyAndGolayM.ToolTip"));
            numericUpDownSmoothingSavitzkyAndGolayM.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownSmoothingSavitzkyAndGolayM.ValueChanged += checkBoxSmoothing_CheckedChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            toolTip.SetToolTip(label5, resources.GetString("label5.ToolTip"));
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            toolTip.SetToolTip(label17, resources.GetString("label17.ToolTip"));
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            toolTip.SetToolTip(label10, resources.GetString("label10.ToolTip"));
            // 
            // checkBoxShowBackgroundProfile
            // 
            resources.ApplyResources(checkBoxShowBackgroundProfile, "checkBoxShowBackgroundProfile");
            checkBoxShowBackgroundProfile.Name = "checkBoxShowBackgroundProfile";
            toolTip.SetToolTip(checkBoxShowBackgroundProfile, resources.GetString("checkBoxShowBackgroundProfile.ToolTip"));
            checkBoxShowBackgroundProfile.CheckedChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // panelBackgroundReferrence
            // 
            resources.ApplyResources(panelBackgroundReferrence, "panelBackgroundReferrence");
            panelBackgroundReferrence.Controls.Add(comboBoxBackgroundReferrence);
            panelBackgroundReferrence.Controls.Add(label4);
            panelBackgroundReferrence.Controls.Add(numericUpDownBackgroundReferrenceScale);
            panelBackgroundReferrence.Name = "panelBackgroundReferrence";
            toolTip.SetToolTip(panelBackgroundReferrence, resources.GetString("panelBackgroundReferrence.ToolTip"));
            // 
            // comboBoxBackgroundReferrence
            // 
            resources.ApplyResources(comboBoxBackgroundReferrence, "comboBoxBackgroundReferrence");
            comboBoxBackgroundReferrence.DataSource = dataSetProfile;
            comboBoxBackgroundReferrence.DisplayMember = "DataTableProfile.Profile";
            comboBoxBackgroundReferrence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxBackgroundReferrence.FormattingEnabled = true;
            comboBoxBackgroundReferrence.Name = "comboBoxBackgroundReferrence";
            toolTip.SetToolTip(comboBoxBackgroundReferrence, resources.GetString("comboBoxBackgroundReferrence.ToolTip"));
            comboBoxBackgroundReferrence.ValueMember = "DataTableProfile.Profile";
            comboBoxBackgroundReferrence.SelectedIndexChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            toolTip.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // numericUpDownBackgroundReferrenceScale
            // 
            resources.ApplyResources(numericUpDownBackgroundReferrenceScale, "numericUpDownBackgroundReferrenceScale");
            numericUpDownBackgroundReferrenceScale.DecimalPlaces = 4;
            numericUpDownBackgroundReferrenceScale.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownBackgroundReferrenceScale.Minimum = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDownBackgroundReferrenceScale.Name = "numericUpDownBackgroundReferrenceScale";
            toolTip.SetToolTip(numericUpDownBackgroundReferrenceScale, resources.GetString("numericUpDownBackgroundReferrenceScale.ToolTip"));
            numericUpDownBackgroundReferrenceScale.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownBackgroundReferrenceScale.ValueChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // panelBackgroundBSpline
            // 
            resources.ApplyResources(panelBackgroundBSpline, "panelBackgroundBSpline");
            panelBackgroundBSpline.Controls.Add(buttonBackgroundAutoDetectBG);
            panelBackgroundBSpline.Controls.Add(label11);
            panelBackgroundBSpline.Controls.Add(numericUpDownBgPointsNumber);
            panelBackgroundBSpline.Name = "panelBackgroundBSpline";
            toolTip.SetToolTip(panelBackgroundBSpline, resources.GetString("panelBackgroundBSpline.ToolTip"));
            // 
            // buttonBackgroundAutoDetectBG
            // 
            resources.ApplyResources(buttonBackgroundAutoDetectBG, "buttonBackgroundAutoDetectBG");
            buttonBackgroundAutoDetectBG.Name = "buttonBackgroundAutoDetectBG";
            toolTip.SetToolTip(buttonBackgroundAutoDetectBG, resources.GetString("buttonBackgroundAutoDetectBG.ToolTip"));
            buttonBackgroundAutoDetectBG.UseVisualStyleBackColor = true;
            buttonBackgroundAutoDetectBG.Click += buttonAutoDetectBG_Click;
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            toolTip.SetToolTip(label11, resources.GetString("label11.ToolTip"));
            // 
            // numericUpDownBgPointsNumber
            // 
            resources.ApplyResources(numericUpDownBgPointsNumber, "numericUpDownBgPointsNumber");
            numericUpDownBgPointsNumber.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownBgPointsNumber.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownBgPointsNumber.Name = "numericUpDownBgPointsNumber";
            toolTip.SetToolTip(numericUpDownBgPointsNumber, resources.GetString("numericUpDownBgPointsNumber.ToolTip"));
            numericUpDownBgPointsNumber.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // radioButtonBackgroundReferrence
            // 
            resources.ApplyResources(radioButtonBackgroundReferrence, "radioButtonBackgroundReferrence");
            radioButtonBackgroundReferrence.Name = "radioButtonBackgroundReferrence";
            toolTip.SetToolTip(radioButtonBackgroundReferrence, resources.GetString("radioButtonBackgroundReferrence.ToolTip"));
            radioButtonBackgroundReferrence.UseVisualStyleBackColor = true;
            radioButtonBackgroundReferrence.CheckedChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // radioButtonBagkgroundBSpline
            // 
            resources.ApplyResources(radioButtonBagkgroundBSpline, "radioButtonBagkgroundBSpline");
            radioButtonBagkgroundBSpline.Checked = true;
            radioButtonBagkgroundBSpline.Name = "radioButtonBagkgroundBSpline";
            radioButtonBagkgroundBSpline.TabStop = true;
            toolTip.SetToolTip(radioButtonBagkgroundBSpline, resources.GetString("radioButtonBagkgroundBSpline.ToolTip"));
            radioButtonBagkgroundBSpline.UseVisualStyleBackColor = true;
            radioButtonBagkgroundBSpline.CheckedChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            toolTip.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            // 
            // checkBoxSmoothing
            // 
            resources.ApplyResources(checkBoxSmoothing, "checkBoxSmoothing");
            checkBoxSmoothing.Name = "checkBoxSmoothing";
            toolTip.SetToolTip(checkBoxSmoothing, resources.GetString("checkBoxSmoothing.ToolTip"));
            checkBoxSmoothing.UseVisualStyleBackColor = true;
            checkBoxSmoothing.CheckedChanged += checkBoxSmoothing_CheckedChanged;
            // 
            // checkBoxBackgroundSubtraction
            // 
            resources.ApplyResources(checkBoxBackgroundSubtraction, "checkBoxBackgroundSubtraction");
            checkBoxBackgroundSubtraction.Name = "checkBoxBackgroundSubtraction";
            toolTip.SetToolTip(checkBoxBackgroundSubtraction, resources.GetString("checkBoxBackgroundSubtraction.ToolTip"));
            checkBoxBackgroundSubtraction.UseVisualStyleBackColor = true;
            checkBoxBackgroundSubtraction.CheckedChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // buttonDeleteProfile
            // 
            resources.ApplyResources(buttonDeleteProfile, "buttonDeleteProfile");
            buttonDeleteProfile.BackColor = System.Drawing.Color.IndianRed;
            buttonDeleteProfile.ForeColor = System.Drawing.Color.White;
            buttonDeleteProfile.Name = "buttonDeleteProfile";
            toolTip.SetToolTip(buttonDeleteProfile, resources.GetString("buttonDeleteProfile.ToolTip"));
            buttonDeleteProfile.UseVisualStyleBackColor = false;
            buttonDeleteProfile.Click += buttonDeleteProfile_Click;
            // 
            // buttonUpper
            // 
            resources.ApplyResources(buttonUpper, "buttonUpper");
            buttonUpper.Name = "buttonUpper";
            toolTip.SetToolTip(buttonUpper, resources.GetString("buttonUpper.ToolTip"));
            buttonUpper.Click += buttonUpper_Click;
            // 
            // buttonLower
            // 
            resources.ApplyResources(buttonLower, "buttonLower");
            buttonLower.Name = "buttonLower";
            toolTip.SetToolTip(buttonLower, resources.GetString("buttonLower.ToolTip"));
            buttonLower.Click += buttonLower_Click;
            // 
            // numericUpDownNormarizeRangeHigh
            // 
            resources.ApplyResources(numericUpDownNormarizeRangeHigh, "numericUpDownNormarizeRangeHigh");
            numericUpDownNormarizeRangeHigh.DecimalPlaces = 1;
            numericUpDownNormarizeRangeHigh.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownNormarizeRangeHigh.Name = "numericUpDownNormarizeRangeHigh";
            toolTip.SetToolTip(numericUpDownNormarizeRangeHigh, resources.GetString("numericUpDownNormarizeRangeHigh.ToolTip"));
            numericUpDownNormarizeRangeHigh.Value = new decimal(new int[] { 180, 0, 0, 0 });
            numericUpDownNormarizeRangeHigh.ValueChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // numericUpDownNormarizeRangeLow
            // 
            resources.ApplyResources(numericUpDownNormarizeRangeLow, "numericUpDownNormarizeRangeLow");
            numericUpDownNormarizeRangeLow.DecimalPlaces = 1;
            numericUpDownNormarizeRangeLow.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownNormarizeRangeLow.Name = "numericUpDownNormarizeRangeLow";
            toolTip.SetToolTip(numericUpDownNormarizeRangeLow, resources.GetString("numericUpDownNormarizeRangeLow.ToolTip"));
            numericUpDownNormarizeRangeLow.ValueChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // buttonChangeSourceXAxis
            // 
            resources.ApplyResources(buttonChangeSourceXAxis, "buttonChangeSourceXAxis");
            buttonChangeSourceXAxis.Name = "buttonChangeSourceXAxis";
            toolTip.SetToolTip(buttonChangeSourceXAxis, resources.GetString("buttonChangeSourceXAxis.ToolTip"));
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
            toolTip.SetToolTip(xAxisUserControl, resources.GetString("xAxisUserControl.ToolTip"));
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
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(numericUpDownShiftHorizontalAxis);
            groupBox1.Controls.Add(checkBoxShiftHorizontalAxis);
            groupBox1.Controls.Add(xAxisUserControl);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            toolTip.SetToolTip(groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            toolTip.SetToolTip(label12, resources.GetString("label12.ToolTip"));
            // 
            // numericUpDownShiftHorizontalAxis
            // 
            resources.ApplyResources(numericUpDownShiftHorizontalAxis, "numericUpDownShiftHorizontalAxis");
            numericUpDownShiftHorizontalAxis.DecimalPlaces = 3;
            numericUpDownShiftHorizontalAxis.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownShiftHorizontalAxis.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownShiftHorizontalAxis.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numericUpDownShiftHorizontalAxis.Name = "numericUpDownShiftHorizontalAxis";
            toolTip.SetToolTip(numericUpDownShiftHorizontalAxis, resources.GetString("numericUpDownShiftHorizontalAxis.ToolTip"));
            numericUpDownShiftHorizontalAxis.ValueChanged += checkBoxShiftHorizontalAxis_CheckedChanged;
            // 
            // checkBoxShiftHorizontalAxis
            // 
            resources.ApplyResources(checkBoxShiftHorizontalAxis, "checkBoxShiftHorizontalAxis");
            checkBoxShiftHorizontalAxis.Name = "checkBoxShiftHorizontalAxis";
            toolTip.SetToolTip(checkBoxShiftHorizontalAxis, resources.GetString("checkBoxShiftHorizontalAxis.ToolTip"));
            checkBoxShiftHorizontalAxis.UseVisualStyleBackColor = true;
            checkBoxShiftHorizontalAxis.CheckedChanged += checkBoxShiftHorizontalAxis_CheckedChanged;
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(numericalTextBoxExposureTime);
            groupBox2.Controls.Add(label24);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label1);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            toolTip.SetToolTip(groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // numericalTextBoxExposureTime
            // 
            resources.ApplyResources(numericalTextBoxExposureTime, "numericalTextBoxExposureTime");
            numericalTextBoxExposureTime.BackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxExposureTime.FooterBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxExposureTime.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxExposureTime.Name = "numericalTextBoxExposureTime";
            numericalTextBoxExposureTime.RoundErrorAccuracy = -1;
            numericalTextBoxExposureTime.SkipEventDuringInput = false;
            numericalTextBoxExposureTime.SmartIncrement = true;
            numericalTextBoxExposureTime.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericalTextBoxExposureTime, resources.GetString("numericalTextBoxExposureTime.ToolTip"));
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
            toolTip.SetToolTip(label24, resources.GetString("label24.ToolTip"));
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            toolTip.SetToolTip(label6, resources.GetString("label6.ToolTip"));
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            toolTip.SetToolTip(label16, resources.GetString("label16.ToolTip"));
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            toolTip.SetToolTip(label13, resources.GetString("label13.ToolTip"));
            // 
            // radioButtonNormarizeMaximum
            // 
            resources.ApplyResources(radioButtonNormarizeMaximum, "radioButtonNormarizeMaximum");
            radioButtonNormarizeMaximum.Name = "radioButtonNormarizeMaximum";
            toolTip.SetToolTip(radioButtonNormarizeMaximum, resources.GetString("radioButtonNormarizeMaximum.ToolTip"));
            radioButtonNormarizeMaximum.UseVisualStyleBackColor = true;
            radioButtonNormarizeMaximum.CheckedChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // radioButtonNormarizeAverage
            // 
            resources.ApplyResources(radioButtonNormarizeAverage, "radioButtonNormarizeAverage");
            radioButtonNormarizeAverage.Checked = true;
            radioButtonNormarizeAverage.Name = "radioButtonNormarizeAverage";
            radioButtonNormarizeAverage.TabStop = true;
            toolTip.SetToolTip(radioButtonNormarizeAverage, resources.GetString("radioButtonNormarizeAverage.ToolTip"));
            radioButtonNormarizeAverage.UseVisualStyleBackColor = true;
            radioButtonNormarizeAverage.CheckedChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // numericUpDownNormarizeIntensity
            // 
            resources.ApplyResources(numericUpDownNormarizeIntensity, "numericUpDownNormarizeIntensity");
            numericUpDownNormarizeIntensity.DecimalPlaces = 3;
            numericUpDownNormarizeIntensity.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownNormarizeIntensity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownNormarizeIntensity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownNormarizeIntensity.Name = "numericUpDownNormarizeIntensity";
            toolTip.SetToolTip(numericUpDownNormarizeIntensity, resources.GetString("numericUpDownNormarizeIntensity.ToolTip"));
            numericUpDownNormarizeIntensity.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownNormarizeIntensity.ValueChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            toolTip.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.BackColor = System.Drawing.Color.DarkRed;
            button1.ForeColor = System.Drawing.Color.White;
            button1.Name = "button1";
            toolTip.SetToolTip(button1, resources.GetString("button1.ToolTip"));
            button1.UseVisualStyleBackColor = false;
            button1.Click += buttonDeleteAllProfiles_Click;
            // 
            // tabControl1
            // 
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.HotTrack = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            toolTip.SetToolTip(tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // tabPage2
            // 
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Controls.Add(flowLayoutPanel1);
            tabPage2.Controls.Add(buttonApplyAllProfiles);
            tabPage2.Name = "tabPage2";
            toolTip.SetToolTip(tabPage2, resources.GetString("tabPage2.ToolTip"));
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
            toolTip.SetToolTip(flowLayoutPanel1, resources.GetString("flowLayoutPanel1.ToolTip"));
            // 
            // checkBoxTwoThetaOffset
            // 
            resources.ApplyResources(checkBoxTwoThetaOffset, "checkBoxTwoThetaOffset");
            checkBoxTwoThetaOffset.Name = "checkBoxTwoThetaOffset";
            toolTip.SetToolTip(checkBoxTwoThetaOffset, resources.GetString("checkBoxTwoThetaOffset.ToolTip"));
            checkBoxTwoThetaOffset.UseVisualStyleBackColor = true;
            checkBoxTwoThetaOffset.CheckedChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // panelTwoThetaOffset
            // 
            resources.ApplyResources(panelTwoThetaOffset, "panelTwoThetaOffset");
            panelTwoThetaOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelTwoThetaOffset.Controls.Add(numericBoxTwhoThetaOffsetCoeff2);
            panelTwoThetaOffset.Controls.Add(numericBoxTwhoThetaOffsetCoeff0);
            panelTwoThetaOffset.Controls.Add(buttonTwoThetaOffsetReset);
            panelTwoThetaOffset.Controls.Add(buttonTwoThetaCalibration);
            panelTwoThetaOffset.Controls.Add(numericBoxTwhoThetaOffsetCoeff1);
            panelTwoThetaOffset.Controls.Add(label25);
            panelTwoThetaOffset.Name = "panelTwoThetaOffset";
            toolTip.SetToolTip(panelTwoThetaOffset, resources.GetString("panelTwoThetaOffset.ToolTip"));
            // 
            // numericBoxTwhoThetaOffsetCoeff2
            // 
            resources.ApplyResources(numericBoxTwhoThetaOffsetCoeff2, "numericBoxTwhoThetaOffsetCoeff2");
            numericBoxTwhoThetaOffsetCoeff2.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff2.DecimalPlaces = 5;
            numericBoxTwhoThetaOffsetCoeff2.FooterBackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff2.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff2.Name = "numericBoxTwhoThetaOffsetCoeff2";
            numericBoxTwhoThetaOffsetCoeff2.RoundErrorAccuracy = -1;
            numericBoxTwhoThetaOffsetCoeff2.SkipEventDuringInput = false;
            numericBoxTwhoThetaOffsetCoeff2.SmartIncrement = true;
            numericBoxTwhoThetaOffsetCoeff2.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxTwhoThetaOffsetCoeff2, resources.GetString("numericBoxTwhoThetaOffsetCoeff2.ToolTip"));
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
            numericBoxTwhoThetaOffsetCoeff0.RoundErrorAccuracy = -1;
            numericBoxTwhoThetaOffsetCoeff0.SkipEventDuringInput = false;
            numericBoxTwhoThetaOffsetCoeff0.SmartIncrement = true;
            numericBoxTwhoThetaOffsetCoeff0.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxTwhoThetaOffsetCoeff0, resources.GetString("numericBoxTwhoThetaOffsetCoeff0.ToolTip"));
            numericBoxTwhoThetaOffsetCoeff0.ValueChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // buttonTwoThetaOffsetReset
            // 
            resources.ApplyResources(buttonTwoThetaOffsetReset, "buttonTwoThetaOffsetReset");
            buttonTwoThetaOffsetReset.Name = "buttonTwoThetaOffsetReset";
            toolTip.SetToolTip(buttonTwoThetaOffsetReset, resources.GetString("buttonTwoThetaOffsetReset.ToolTip"));
            buttonTwoThetaOffsetReset.UseVisualStyleBackColor = true;
            buttonTwoThetaOffsetReset.Click += buttonTwoThetaOffsetReset_Click;
            // 
            // buttonTwoThetaCalibration
            // 
            resources.ApplyResources(buttonTwoThetaCalibration, "buttonTwoThetaCalibration");
            buttonTwoThetaCalibration.Name = "buttonTwoThetaCalibration";
            toolTip.SetToolTip(buttonTwoThetaCalibration, resources.GetString("buttonTwoThetaCalibration.ToolTip"));
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
            numericBoxTwhoThetaOffsetCoeff1.RoundErrorAccuracy = -1;
            numericBoxTwhoThetaOffsetCoeff1.SkipEventDuringInput = false;
            numericBoxTwhoThetaOffsetCoeff1.SmartIncrement = true;
            numericBoxTwhoThetaOffsetCoeff1.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxTwhoThetaOffsetCoeff1, resources.GetString("numericBoxTwhoThetaOffsetCoeff1.ToolTip"));
            numericBoxTwhoThetaOffsetCoeff1.ValueChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            toolTip.SetToolTip(label25, resources.GetString("label25.ToolTip"));
            // 
            // checkBoxMaskingMode
            // 
            resources.ApplyResources(checkBoxMaskingMode, "checkBoxMaskingMode");
            checkBoxMaskingMode.Name = "checkBoxMaskingMode";
            toolTip.SetToolTip(checkBoxMaskingMode, resources.GetString("checkBoxMaskingMode.ToolTip"));
            checkBoxMaskingMode.UseVisualStyleBackColor = true;
            checkBoxMaskingMode.CheckedChanged += checkBoxMaskingMode_CheckedChanged;
            // 
            // panelMaskingMode
            // 
            resources.ApplyResources(panelMaskingMode, "panelMaskingMode");
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
            panelMaskingMode.Name = "panelMaskingMode";
            toolTip.SetToolTip(panelMaskingMode, resources.GetString("panelMaskingMode.ToolTip"));
            // 
            // checkBoxShowMaskedRange
            // 
            resources.ApplyResources(checkBoxShowMaskedRange, "checkBoxShowMaskedRange");
            checkBoxShowMaskedRange.Checked = true;
            checkBoxShowMaskedRange.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxShowMaskedRange.Name = "checkBoxShowMaskedRange";
            toolTip.SetToolTip(checkBoxShowMaskedRange, resources.GetString("checkBoxShowMaskedRange.ToolTip"));
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
            resources.ApplyResources(listBoxMaskRanges, "listBoxMaskRanges");
            listBoxMaskRanges.AllowDrop = true;
            listBoxMaskRanges.ContextMenuStrip = contextMenuStripMaskRange;
            listBoxMaskRanges.FormattingEnabled = true;
            listBoxMaskRanges.Name = "listBoxMaskRanges";
            toolTip.SetToolTip(listBoxMaskRanges, resources.GetString("listBoxMaskRanges.ToolTip"));
            listBoxMaskRanges.SelectedIndexChanged += listBoxMaskRanges_SelectedIndexChanged;
            listBoxMaskRanges.DragDrop += listBoxMaskRanges_DragDrop;
            listBoxMaskRanges.DragEnter += listBoxMaskRanges_DragEnter;
            // 
            // contextMenuStripMaskRange
            // 
            resources.ApplyResources(contextMenuStripMaskRange, "contextMenuStripMaskRange");
            contextMenuStripMaskRange.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemSaveMaskingRange, toolStripMenuItemReadMaskingRange });
            contextMenuStripMaskRange.Name = "contextMenuStripMaskRange";
            toolTip.SetToolTip(contextMenuStripMaskRange, resources.GetString("contextMenuStripMaskRange.ToolTip"));
            // 
            // toolStripMenuItemSaveMaskingRange
            // 
            resources.ApplyResources(toolStripMenuItemSaveMaskingRange, "toolStripMenuItemSaveMaskingRange");
            toolStripMenuItemSaveMaskingRange.Name = "toolStripMenuItemSaveMaskingRange";
            toolStripMenuItemSaveMaskingRange.Click += toolStripMenuItemSaveMaskingRange_Click;
            // 
            // toolStripMenuItemReadMaskingRange
            // 
            resources.ApplyResources(toolStripMenuItemReadMaskingRange, "toolStripMenuItemReadMaskingRange");
            toolStripMenuItemReadMaskingRange.Name = "toolStripMenuItemReadMaskingRange";
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
            toolTip.SetToolTip(buttonDeleteAllMask, resources.GetString("buttonDeleteAllMask.ToolTip"));
            buttonDeleteAllMask.UseVisualStyleBackColor = false;
            buttonDeleteAllMask.Click += buttonDeleteAllMask_Click;
            // 
            // numericUpDownInterpolationOrder
            // 
            resources.ApplyResources(numericUpDownInterpolationOrder, "numericUpDownInterpolationOrder");
            numericUpDownInterpolationOrder.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownInterpolationOrder.Name = "numericUpDownInterpolationOrder";
            toolTip.SetToolTip(numericUpDownInterpolationOrder, resources.GetString("numericUpDownInterpolationOrder.ToolTip"));
            numericUpDownInterpolationOrder.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownInterpolationOrder.ValueChanged += checkBoxMaskingMode_CheckedChanged;
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            toolTip.SetToolTip(label19, resources.GetString("label19.ToolTip"));
            // 
            // buttonDeleteMask
            // 
            resources.ApplyResources(buttonDeleteMask, "buttonDeleteMask");
            buttonDeleteMask.BackColor = System.Drawing.Color.IndianRed;
            buttonDeleteMask.ForeColor = System.Drawing.Color.White;
            buttonDeleteMask.Name = "buttonDeleteMask";
            toolTip.SetToolTip(buttonDeleteMask, resources.GetString("buttonDeleteMask.ToolTip"));
            buttonDeleteMask.UseVisualStyleBackColor = false;
            buttonDeleteMask.Click += buttonDeleteMask_Click;
            // 
            // panelSmoothing
            // 
            resources.ApplyResources(panelSmoothing, "panelSmoothing");
            panelSmoothing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelSmoothing.Controls.Add(numericUpDownSmoothingSavitzkyAndGolayN);
            panelSmoothing.Controls.Add(label17);
            panelSmoothing.Controls.Add(numericUpDownSmoothingSavitzkyAndGolayM);
            panelSmoothing.Controls.Add(label10);
            panelSmoothing.Controls.Add(label5);
            panelSmoothing.Name = "panelSmoothing";
            toolTip.SetToolTip(panelSmoothing, resources.GetString("panelSmoothing.ToolTip"));
            // 
            // checkBoxBandPassFilter
            // 
            resources.ApplyResources(checkBoxBandPassFilter, "checkBoxBandPassFilter");
            checkBoxBandPassFilter.Name = "checkBoxBandPassFilter";
            toolTip.SetToolTip(checkBoxBandPassFilter, resources.GetString("checkBoxBandPassFilter.ToolTip"));
            checkBoxBandPassFilter.UseVisualStyleBackColor = true;
            checkBoxBandPassFilter.CheckedChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // panelBandPassFilter
            // 
            resources.ApplyResources(panelBandPassFilter, "panelBandPassFilter");
            panelBandPassFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelBandPassFilter.Controls.Add(numericUpDownHighPass);
            panelBandPassFilter.Controls.Add(checkBoxLowPassFilter);
            panelBandPassFilter.Controls.Add(numericUpDownLowPass);
            panelBandPassFilter.Controls.Add(checkBoxHighPassFilter);
            panelBandPassFilter.Controls.Add(labelHighPass);
            panelBandPassFilter.Controls.Add(labelLowPath);
            panelBandPassFilter.Name = "panelBandPassFilter";
            toolTip.SetToolTip(panelBandPassFilter, resources.GetString("panelBandPassFilter.ToolTip"));
            // 
            // numericUpDownHighPass
            // 
            resources.ApplyResources(numericUpDownHighPass, "numericUpDownHighPass");
            numericUpDownHighPass.DecimalPlaces = 2;
            numericUpDownHighPass.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownHighPass.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownHighPass.Name = "numericUpDownHighPass";
            toolTip.SetToolTip(numericUpDownHighPass, resources.GetString("numericUpDownHighPass.ToolTip"));
            numericUpDownHighPass.ValueChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // checkBoxLowPassFilter
            // 
            resources.ApplyResources(checkBoxLowPassFilter, "checkBoxLowPassFilter");
            checkBoxLowPassFilter.Name = "checkBoxLowPassFilter";
            toolTip.SetToolTip(checkBoxLowPassFilter, resources.GetString("checkBoxLowPassFilter.ToolTip"));
            checkBoxLowPassFilter.UseVisualStyleBackColor = true;
            checkBoxLowPassFilter.CheckedChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // numericUpDownLowPass
            // 
            resources.ApplyResources(numericUpDownLowPass, "numericUpDownLowPass");
            numericUpDownLowPass.DecimalPlaces = 2;
            numericUpDownLowPass.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownLowPass.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownLowPass.Name = "numericUpDownLowPass";
            toolTip.SetToolTip(numericUpDownLowPass, resources.GetString("numericUpDownLowPass.ToolTip"));
            numericUpDownLowPass.ValueChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // checkBoxHighPassFilter
            // 
            resources.ApplyResources(checkBoxHighPassFilter, "checkBoxHighPassFilter");
            checkBoxHighPassFilter.Name = "checkBoxHighPassFilter";
            toolTip.SetToolTip(checkBoxHighPassFilter, resources.GetString("checkBoxHighPassFilter.ToolTip"));
            checkBoxHighPassFilter.UseVisualStyleBackColor = true;
            checkBoxHighPassFilter.CheckedChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // labelHighPass
            // 
            resources.ApplyResources(labelHighPass, "labelHighPass");
            labelHighPass.Name = "labelHighPass";
            toolTip.SetToolTip(labelHighPass, resources.GetString("labelHighPass.ToolTip"));
            // 
            // labelLowPath
            // 
            resources.ApplyResources(labelLowPath, "labelLowPath");
            labelLowPath.Name = "labelLowPath";
            toolTip.SetToolTip(labelLowPath, resources.GetString("labelLowPath.ToolTip"));
            // 
            // panel5
            // 
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            toolTip.SetToolTip(panel5, resources.GetString("panel5.ToolTip"));
            // 
            // checkBoxRemoveKalpha2
            // 
            resources.ApplyResources(checkBoxRemoveKalpha2, "checkBoxRemoveKalpha2");
            checkBoxRemoveKalpha2.Name = "checkBoxRemoveKalpha2";
            toolTip.SetToolTip(checkBoxRemoveKalpha2, resources.GetString("checkBoxRemoveKalpha2.ToolTip"));
            checkBoxRemoveKalpha2.UseVisualStyleBackColor = true;
            checkBoxRemoveKalpha2.CheckedChanged += checkBoxRemoveKalpha2_CheckedChanged;
            // 
            // panelBackgroundSubtraction
            // 
            resources.ApplyResources(panelBackgroundSubtraction, "panelBackgroundSubtraction");
            panelBackgroundSubtraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelBackgroundSubtraction.Controls.Add(checkBoxShowBackgroundProfile);
            panelBackgroundSubtraction.Controls.Add(panelBackgroundReferrence);
            panelBackgroundSubtraction.Controls.Add(radioButtonBagkgroundBSpline);
            panelBackgroundSubtraction.Controls.Add(panelBackgroundBSpline);
            panelBackgroundSubtraction.Controls.Add(radioButtonBackgroundReferrence);
            panelBackgroundSubtraction.Name = "panelBackgroundSubtraction";
            toolTip.SetToolTip(panelBackgroundSubtraction, resources.GetString("panelBackgroundSubtraction.ToolTip"));
            // 
            // checkBoxNormarizeIntensity
            // 
            resources.ApplyResources(checkBoxNormarizeIntensity, "checkBoxNormarizeIntensity");
            checkBoxNormarizeIntensity.Name = "checkBoxNormarizeIntensity";
            toolTip.SetToolTip(checkBoxNormarizeIntensity, resources.GetString("checkBoxNormarizeIntensity.ToolTip"));
            checkBoxNormarizeIntensity.UseVisualStyleBackColor = true;
            checkBoxNormarizeIntensity.CheckedChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // panelNormarizeIntensity
            // 
            resources.ApplyResources(panelNormarizeIntensity, "panelNormarizeIntensity");
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
            panelNormarizeIntensity.Name = "panelNormarizeIntensity";
            toolTip.SetToolTip(panelNormarizeIntensity, resources.GetString("panelNormarizeIntensity.ToolTip"));
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            toolTip.SetToolTip(label14, resources.GetString("label14.ToolTip"));
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            toolTip.SetToolTip(label23, resources.GetString("label23.ToolTip"));
            // 
            // buttonApplyAllProfiles
            // 
            resources.ApplyResources(buttonApplyAllProfiles, "buttonApplyAllProfiles");
            buttonApplyAllProfiles.Name = "buttonApplyAllProfiles";
            toolTip.SetToolTip(buttonApplyAllProfiles, resources.GetString("buttonApplyAllProfiles.ToolTip"));
            buttonApplyAllProfiles.UseVisualStyleBackColor = true;
            buttonApplyAllProfiles.Click += buttonApplyAllProfiles_Click;
            // 
            // tabPage3
            // 
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Controls.Add(buttonChangeSourceXAxis);
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Name = "tabPage3";
            toolTip.SetToolTip(tabPage3, resources.GetString("tabPage3.ToolTip"));
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(radioButtonAverage);
            tabPage1.Controls.Add(radioButtonProfileAndValue);
            tabPage1.Controls.Add(radioButtonTwoProfiles);
            tabPage1.Controls.Add(buttonCalculate);
            tabPage1.Controls.Add(textBoxOutputFilename);
            tabPage1.Controls.Add(label18);
            tabPage1.Name = "tabPage1";
            toolTip.SetToolTip(tabPage1, resources.GetString("tabPage1.ToolTip"));
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(listBoxTwoProfiles1);
            panel1.Controls.Add(flowLayoutPanelFourCalculator);
            panel1.Controls.Add(listBoxTwoProfiles2);
            panel1.Name = "panel1";
            toolTip.SetToolTip(panel1, resources.GetString("panel1.ToolTip"));
            // 
            // listBoxTwoProfiles1
            // 
            resources.ApplyResources(listBoxTwoProfiles1, "listBoxTwoProfiles1");
            listBoxTwoProfiles1.FormattingEnabled = true;
            listBoxTwoProfiles1.Name = "listBoxTwoProfiles1";
            listBoxTwoProfiles1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            toolTip.SetToolTip(listBoxTwoProfiles1, resources.GetString("listBoxTwoProfiles1.ToolTip"));
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
            toolTip.SetToolTip(flowLayoutPanelFourCalculator, resources.GetString("flowLayoutPanelFourCalculator.ToolTip"));
            // 
            // radioButtonAddition
            // 
            resources.ApplyResources(radioButtonAddition, "radioButtonAddition");
            radioButtonAddition.Checked = true;
            radioButtonAddition.Name = "radioButtonAddition";
            radioButtonAddition.TabStop = true;
            toolTip.SetToolTip(radioButtonAddition, resources.GetString("radioButtonAddition.ToolTip"));
            radioButtonAddition.UseVisualStyleBackColor = true;
            // 
            // radioButtonSubtraction
            // 
            resources.ApplyResources(radioButtonSubtraction, "radioButtonSubtraction");
            radioButtonSubtraction.Name = "radioButtonSubtraction";
            toolTip.SetToolTip(radioButtonSubtraction, resources.GetString("radioButtonSubtraction.ToolTip"));
            radioButtonSubtraction.UseVisualStyleBackColor = true;
            // 
            // radioButtonMutiplication
            // 
            resources.ApplyResources(radioButtonMutiplication, "radioButtonMutiplication");
            radioButtonMutiplication.Name = "radioButtonMutiplication";
            toolTip.SetToolTip(radioButtonMutiplication, resources.GetString("radioButtonMutiplication.ToolTip"));
            radioButtonMutiplication.UseVisualStyleBackColor = true;
            // 
            // radioButtonDivision
            // 
            resources.ApplyResources(radioButtonDivision, "radioButtonDivision");
            radioButtonDivision.Name = "radioButtonDivision";
            toolTip.SetToolTip(radioButtonDivision, resources.GetString("radioButtonDivision.ToolTip"));
            radioButtonDivision.UseVisualStyleBackColor = true;
            // 
            // numericalTextBoxTargetValue
            // 
            resources.ApplyResources(numericalTextBoxTargetValue, "numericalTextBoxTargetValue");
            numericalTextBoxTargetValue.BackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxTargetValue.FooterBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxTargetValue.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxTargetValue.Name = "numericalTextBoxTargetValue";
            numericalTextBoxTargetValue.RoundErrorAccuracy = -1;
            numericalTextBoxTargetValue.SkipEventDuringInput = false;
            numericalTextBoxTargetValue.SmartIncrement = true;
            numericalTextBoxTargetValue.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericalTextBoxTargetValue, resources.GetString("numericalTextBoxTargetValue.ToolTip"));
            // 
            // listBoxTwoProfiles2
            // 
            resources.ApplyResources(listBoxTwoProfiles2, "listBoxTwoProfiles2");
            listBoxTwoProfiles2.FormattingEnabled = true;
            listBoxTwoProfiles2.Items.AddRange(new object[] { resources.GetString("listBoxTwoProfiles2.Items") });
            listBoxTwoProfiles2.Name = "listBoxTwoProfiles2";
            toolTip.SetToolTip(listBoxTwoProfiles2, resources.GetString("listBoxTwoProfiles2.ToolTip"));
            // 
            // radioButtonAverage
            // 
            resources.ApplyResources(radioButtonAverage, "radioButtonAverage");
            radioButtonAverage.Checked = true;
            radioButtonAverage.Name = "radioButtonAverage";
            radioButtonAverage.TabStop = true;
            toolTip.SetToolTip(radioButtonAverage, resources.GetString("radioButtonAverage.ToolTip"));
            radioButtonAverage.UseVisualStyleBackColor = true;
            radioButtonAverage.CheckedChanged += radioButtonAverage_CheckedChanged;
            // 
            // radioButtonProfileAndValue
            // 
            resources.ApplyResources(radioButtonProfileAndValue, "radioButtonProfileAndValue");
            radioButtonProfileAndValue.Name = "radioButtonProfileAndValue";
            toolTip.SetToolTip(radioButtonProfileAndValue, resources.GetString("radioButtonProfileAndValue.ToolTip"));
            radioButtonProfileAndValue.UseVisualStyleBackColor = true;
            radioButtonProfileAndValue.CheckedChanged += radioButtonAverage_CheckedChanged;
            // 
            // radioButtonTwoProfiles
            // 
            resources.ApplyResources(radioButtonTwoProfiles, "radioButtonTwoProfiles");
            radioButtonTwoProfiles.Name = "radioButtonTwoProfiles";
            toolTip.SetToolTip(radioButtonTwoProfiles, resources.GetString("radioButtonTwoProfiles.ToolTip"));
            radioButtonTwoProfiles.UseVisualStyleBackColor = true;
            radioButtonTwoProfiles.CheckedChanged += radioButtonAverage_CheckedChanged;
            // 
            // buttonCalculate
            // 
            resources.ApplyResources(buttonCalculate, "buttonCalculate");
            buttonCalculate.Name = "buttonCalculate";
            toolTip.SetToolTip(buttonCalculate, resources.GetString("buttonCalculate.ToolTip"));
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // textBoxOutputFilename
            // 
            resources.ApplyResources(textBoxOutputFilename, "textBoxOutputFilename");
            textBoxOutputFilename.Name = "textBoxOutputFilename";
            toolTip.SetToolTip(textBoxOutputFilename, resources.GetString("textBoxOutputFilename.ToolTip"));
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            toolTip.SetToolTip(label18, resources.GetString("label18.ToolTip"));
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
            toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
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