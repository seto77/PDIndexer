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
            panel2 = new System.Windows.Forms.Panel();
            buttonLower = new System.Windows.Forms.Button();
            buttonUpper = new System.Windows.Forms.Button();
            buttonDeleteProfile = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            textBoxComment = new System.Windows.Forms.TextBox();
            label22 = new System.Windows.Forms.Label();
            textBoxProfileName = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            colorControlLineColor = new ColorControl();
            numericBoxLineWidth = new NumericBox();
            label17 = new System.Windows.Forms.Label();
            checkBoxShowBackgroundProfile = new System.Windows.Forms.CheckBox();
            comboBoxBackgroundReferrence = new System.Windows.Forms.ComboBox();
            buttonBackgroundAutoDetectBG = new System.Windows.Forms.Button();
            radioButtonBackgroundReferrence = new System.Windows.Forms.RadioButton();
            radioButtonBagkgroundBSpline = new System.Windows.Forms.RadioButton();
            checkBoxSmoothing = new System.Windows.Forms.CheckBox();
            checkBoxBackgroundSubtraction = new System.Windows.Forms.CheckBox();
            buttonChangeSourceXAxis = new System.Windows.Forms.Button();
            xAxisUserControl = new HorizontalAxisUserControl();
            groupBox1 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            checkBoxShiftHorizontalAxis = new System.Windows.Forms.CheckBox();
            numericBoxShiftHorizontalAxis = new NumericBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxExposureTime = new NumericBox();
            radioButtonNormarizeMaximum = new System.Windows.Forms.RadioButton();
            radioButtonNormarizeAverage = new System.Windows.Forms.RadioButton();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage2 = new System.Windows.Forms.TabPage();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            checkBoxTwoThetaOffset = new System.Windows.Forms.CheckBox();
            flowLayoutPanelTwoThetaOffset = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxTwhoThetaOffsetCoeff0 = new NumericBox();
            numericBoxTwhoThetaOffsetCoeff1 = new NumericBox();
            numericBoxTwhoThetaOffsetCoeff2 = new NumericBox();
            flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            buttonTwoThetaCalibration = new System.Windows.Forms.Button();
            buttonTwoThetaOffsetReset = new System.Windows.Forms.Button();
            checkBoxMaskingMode = new System.Windows.Forms.CheckBox();
            flowLayoutPanelMaskingMode = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
            checkBoxShowMaskedRange = new System.Windows.Forms.CheckBox();
            numericBoxInterpolationOrder = new NumericBox();
            numericBoxInterpolationPoints = new NumericBox();
            panel6 = new System.Windows.Forms.Panel();
            listBoxMaskRanges = new System.Windows.Forms.ListBox();
            contextMenuStripMaskRange = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemSaveMaskingRange = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemReadMaskingRange = new System.Windows.Forms.ToolStripMenuItem();
            flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
            buttonDeleteMask = new System.Windows.Forms.Button();
            buttonDeleteAllMask = new System.Windows.Forms.Button();
            flowLayoutPanelSmoothing = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxSmoothingSavitzkyAndGolayM = new NumericBox();
            numericBoxSmoothingSavitzkyAndGolayN = new NumericBox();
            checkBoxBandPassFilter = new System.Windows.Forms.CheckBox();
            panel5 = new System.Windows.Forms.Panel();
            flowLayoutPanelBandPassFilter = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            checkBoxLowPassFilter = new System.Windows.Forms.CheckBox();
            numericBoxLowPass = new NumericBox();
            labelLowPath = new System.Windows.Forms.Label();
            flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            checkBoxHighPassFilter = new System.Windows.Forms.CheckBox();
            numericBoxHighPass = new NumericBox();
            labelHighPass = new System.Windows.Forms.Label();
            checkBoxRemoveKalpha2 = new System.Windows.Forms.CheckBox();
            flowLayoutPanelBackgroundSubtraction = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanelBackgroundBSpline = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxBgPointsNumber = new NumericBox();
            flowLayoutPanelBackgroundReferrence = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxBackgroundReferrenceScale = new NumericBox();
            checkBoxNormarizeIntensity = new System.Windows.Forms.CheckBox();
            flowLayoutPanelNormarizeIntensity = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel17 = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            flowLayoutPanel18 = new System.Windows.Forms.FlowLayoutPanel();
            numericBoxNormarizeRangeLow = new NumericBox();
            numericBoxNormarizeRangeHigh = new NumericBox();
            numericBoxNormarizeIntensity = new NumericBox();
            buttonApplyAllProfiles = new System.Windows.Forms.Button();
            tabPage3 = new System.Windows.Forms.TabPage();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            panel3 = new System.Windows.Forms.Panel();
            tabPage1 = new System.Windows.Forms.TabPage();
            listBoxTwoProfiles1 = new System.Windows.Forms.ListBox();
            flowLayoutPanelFourCalculator = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonAddition = new System.Windows.Forms.RadioButton();
            radioButtonSubtraction = new System.Windows.Forms.RadioButton();
            radioButtonMutiplication = new System.Windows.Forms.RadioButton();
            radioButtonDivision = new System.Windows.Forms.RadioButton();
            numericalTextBoxTargetValue = new NumericBox();
            listBoxTwoProfiles2 = new System.Windows.Forms.ListBox();
            panel1 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            textBoxOutputFilename = new System.Windows.Forms.TextBox();
            buttonCalculate = new System.Windows.Forms.Button();
            label18 = new System.Windows.Forms.Label();
            flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            radioButtonAverage = new System.Windows.Forms.RadioButton();
            radioButtonProfileAndValue = new System.Windows.Forms.RadioButton();
            radioButtonTwoProfiles = new System.Windows.Forms.RadioButton();
            toolTip = new System.Windows.Forms.ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataSetProfile).BeginInit();
            panel2.SuspendLayout();
            groupBox3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanelTwoThetaOffset.SuspendLayout();
            flowLayoutPanel10.SuspendLayout();
            flowLayoutPanel9.SuspendLayout();
            flowLayoutPanelMaskingMode.SuspendLayout();
            flowLayoutPanel14.SuspendLayout();
            panel6.SuspendLayout();
            contextMenuStripMaskRange.SuspendLayout();
            flowLayoutPanel15.SuspendLayout();
            flowLayoutPanelSmoothing.SuspendLayout();
            flowLayoutPanelBandPassFilter.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel11.SuspendLayout();
            flowLayoutPanelBackgroundSubtraction.SuspendLayout();
            flowLayoutPanelBackgroundBSpline.SuspendLayout();
            flowLayoutPanelBackgroundReferrence.SuspendLayout();
            flowLayoutPanelNormarizeIntensity.SuspendLayout();
            flowLayoutPanel17.SuspendLayout();
            flowLayoutPanel18.SuspendLayout();
            tabPage3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            tabPage1.SuspendLayout();
            flowLayoutPanelFourCalculator.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(panel2);
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
            resources.ApplyResources(dataGridViewProfile, "dataGridViewProfile");
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
            // panel2
            // 
            panel2.Controls.Add(buttonLower);
            panel2.Controls.Add(buttonUpper);
            panel2.Controls.Add(buttonDeleteProfile);
            panel2.Controls.Add(button1);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // buttonLower
            // 
            resources.ApplyResources(buttonLower, "buttonLower");
            buttonLower.Name = "buttonLower";
            toolTip.SetToolTip(buttonLower, resources.GetString("buttonLower.ToolTip"));
            buttonLower.Click += buttonLower_Click;
            // 
            // buttonUpper
            // 
            resources.ApplyResources(buttonUpper, "buttonUpper");
            buttonUpper.Name = "buttonUpper";
            toolTip.SetToolTip(buttonUpper, resources.GetString("buttonUpper.ToolTip"));
            buttonUpper.Click += buttonUpper_Click;
            // 
            // buttonDeleteProfile
            // 
            buttonDeleteProfile.BackColor = System.Drawing.Color.IndianRed;
            resources.ApplyResources(buttonDeleteProfile, "buttonDeleteProfile");
            buttonDeleteProfile.ForeColor = System.Drawing.Color.White;
            buttonDeleteProfile.Name = "buttonDeleteProfile";
            toolTip.SetToolTip(buttonDeleteProfile, resources.GetString("buttonDeleteProfile.ToolTip"));
            buttonDeleteProfile.UseVisualStyleBackColor = false;
            buttonDeleteProfile.Click += buttonDeleteProfile_Click;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.DarkRed;
            resources.ApplyResources(button1, "button1");
            button1.ForeColor = System.Drawing.Color.White;
            button1.Name = "button1";
            toolTip.SetToolTip(button1, resources.GetString("button1.ToolTip"));
            button1.UseVisualStyleBackColor = false;
            button1.Click += buttonDeleteAllProfiles_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxComment);
            groupBox3.Controls.Add(label22);
            groupBox3.Controls.Add(textBoxProfileName);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(flowLayoutPanel2);
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // textBoxComment
            // 
            resources.ApplyResources(textBoxComment, "textBoxComment");
            textBoxComment.Name = "textBoxComment";
            toolTip.SetToolTip(textBoxComment, resources.GetString("textBoxComment.ToolTip"));
            textBoxComment.TextChanged += textBoxComment_TextChanged;
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            // 
            // textBoxProfileName
            // 
            resources.ApplyResources(textBoxProfileName, "textBoxProfileName");
            textBoxProfileName.Name = "textBoxProfileName";
            toolTip.SetToolTip(textBoxProfileName, resources.GetString("textBoxProfileName.ToolTip"));
            textBoxProfileName.TextChanged += textBoxProfileName_TextChanged;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Controls.Add(colorControlLineColor);
            flowLayoutPanel2.Controls.Add(numericBoxLineWidth);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // colorControlLineColor
            // 
            resources.ApplyResources(colorControlLineColor, "colorControlLineColor");
            colorControlLineColor.BackColor = System.Drawing.SystemColors.Control;
            colorControlLineColor.BoxSize = new System.Drawing.Size(20, 20);
            colorControlLineColor.Color = System.Drawing.Color.FromArgb(240, 240, 240);
            colorControlLineColor.Name = "colorControlLineColor";
            toolTip.SetToolTip(colorControlLineColor, resources.GetString("colorControlLineColor.ToolTip1"));
            colorControlLineColor.ColorChanged += colorControlLineColor_ColorChanged;
            // 
            // numericBoxLineWidth
            // 
            numericBoxLineWidth.BackColor = System.Drawing.Color.Transparent;
            numericBoxLineWidth.DecimalPlaces = 1;
            resources.ApplyResources(numericBoxLineWidth, "numericBoxLineWidth");
            numericBoxLineWidth.Maximum = 100D; // 260701Cl 旧numericUpDownLineWidth(Maximum未指定=既定値100)を復元 (NumericBox移行時のコピー漏れ)
            numericBoxLineWidth.Minimum = 0D;
            numericBoxLineWidth.Name = "numericBoxLineWidth";
            numericBoxLineWidth.RadianValue = 0.017453292519943295D;
            numericBoxLineWidth.ShowUpDown = true;
            numericBoxLineWidth.SmartIncrement = true;
            toolTip.SetToolTip(numericBoxLineWidth, resources.GetString("numericBoxLineWidth.ToolTip"));
            numericBoxLineWidth.Value = 1D;
            numericBoxLineWidth.ValueBoxWidth = 30;
            numericBoxLineWidth.ValueChanged += numericUpDownLineWidth_ValueChanged;
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            // 
            // checkBoxShowBackgroundProfile
            // 
            resources.ApplyResources(checkBoxShowBackgroundProfile, "checkBoxShowBackgroundProfile");
            checkBoxShowBackgroundProfile.Name = "checkBoxShowBackgroundProfile";
            toolTip.SetToolTip(checkBoxShowBackgroundProfile, resources.GetString("checkBoxShowBackgroundProfile.ToolTip"));
            checkBoxShowBackgroundProfile.CheckedChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // comboBoxBackgroundReferrence
            // 
            comboBoxBackgroundReferrence.DataSource = dataSetProfile;
            comboBoxBackgroundReferrence.DisplayMember = "DataTableProfile.Profile";
            comboBoxBackgroundReferrence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBoxBackgroundReferrence, "comboBoxBackgroundReferrence");
            comboBoxBackgroundReferrence.FormattingEnabled = true;
            comboBoxBackgroundReferrence.Name = "comboBoxBackgroundReferrence";
            toolTip.SetToolTip(comboBoxBackgroundReferrence, resources.GetString("comboBoxBackgroundReferrence.ToolTip"));
            comboBoxBackgroundReferrence.ValueMember = "DataTableProfile.Profile";
            comboBoxBackgroundReferrence.SelectedIndexChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // buttonBackgroundAutoDetectBG
            // 
            resources.ApplyResources(buttonBackgroundAutoDetectBG, "buttonBackgroundAutoDetectBG");
            buttonBackgroundAutoDetectBG.Name = "buttonBackgroundAutoDetectBG";
            toolTip.SetToolTip(buttonBackgroundAutoDetectBG, resources.GetString("buttonBackgroundAutoDetectBG.ToolTip"));
            buttonBackgroundAutoDetectBG.UseVisualStyleBackColor = true;
            buttonBackgroundAutoDetectBG.Click += buttonAutoDetectBG_Click;
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
            xAxisUserControl.ElectronAccVol = 8.04151786D;
            xAxisUserControl.ElectronAccVoltageText = "8.04151786";
            xAxisUserControl.Name = "xAxisUserControl";
            xAxisUserControl.TakeoffAngle = 5.9872200000000051D;
            xAxisUserControl.TakeoffAngleText = "343.042437016317";
            xAxisUserControl.TofAngleText = "90";
            toolTip.SetToolTip(xAxisUserControl, resources.GetString("xAxisUserControl.ToolTip"));
            xAxisUserControl.WaveLength = 0.15418D;
            xAxisUserControl.WaveLengthText = "1.5418";
            xAxisUserControl.XrayLine = Crystallography.XrayLine.Ka1;
            xAxisUserControl.XrayNumber = 0;
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(flowLayoutPanel3);
            groupBox1.Controls.Add(xAxisUserControl);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(flowLayoutPanel3, "flowLayoutPanel3");
            flowLayoutPanel3.Controls.Add(checkBoxShiftHorizontalAxis);
            flowLayoutPanel3.Controls.Add(numericBoxShiftHorizontalAxis);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // checkBoxShiftHorizontalAxis
            // 
            resources.ApplyResources(checkBoxShiftHorizontalAxis, "checkBoxShiftHorizontalAxis");
            checkBoxShiftHorizontalAxis.Name = "checkBoxShiftHorizontalAxis";
            toolTip.SetToolTip(checkBoxShiftHorizontalAxis, resources.GetString("checkBoxShiftHorizontalAxis.ToolTip"));
            checkBoxShiftHorizontalAxis.UseVisualStyleBackColor = true;
            checkBoxShiftHorizontalAxis.CheckedChanged += checkBoxShiftHorizontalAxis_CheckedChanged;
            // 
            // numericBoxShiftHorizontalAxis
            // 
            numericBoxShiftHorizontalAxis.BackColor = System.Drawing.Color.Transparent;
            numericBoxShiftHorizontalAxis.DecimalPlaces = 3;
            resources.ApplyResources(numericBoxShiftHorizontalAxis, "numericBoxShiftHorizontalAxis");
            numericBoxShiftHorizontalAxis.Maximum = 100000D;
            numericBoxShiftHorizontalAxis.Minimum = -100000D;
            numericBoxShiftHorizontalAxis.Name = "numericBoxShiftHorizontalAxis";
            numericBoxShiftHorizontalAxis.ShowUpDown = true;
            toolTip.SetToolTip(numericBoxShiftHorizontalAxis, resources.GetString("numericBoxShiftHorizontalAxis.ToolTip"));
            numericBoxShiftHorizontalAxis.UpDown_Increment = 0.01D;
            numericBoxShiftHorizontalAxis.ValueBoxWidth = 100;
            numericBoxShiftHorizontalAxis.ValueChanged += checkBoxShiftHorizontalAxis_CheckedChanged;
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(flowLayoutPanel5);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // flowLayoutPanel5
            // 
            resources.ApplyResources(flowLayoutPanel5, "flowLayoutPanel5");
            flowLayoutPanel5.Controls.Add(numericBoxExposureTime);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            // 
            // numericBoxExposureTime
            // 
            numericBoxExposureTime.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(numericBoxExposureTime, "numericBoxExposureTime");
            numericBoxExposureTime.Name = "numericBoxExposureTime";
            numericBoxExposureTime.SkipEventDuringInput = false;
            numericBoxExposureTime.SmartIncrement = true;
            numericBoxExposureTime.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxExposureTime, resources.GetString("numericBoxExposureTime.ToolTip"));
            numericBoxExposureTime.ValueBoxWidth = 50;
            numericBoxExposureTime.ValueFontSize = 9F;
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
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            flowLayoutPanel1.Controls.Add(checkBoxTwoThetaOffset);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelTwoThetaOffset);
            flowLayoutPanel1.Controls.Add(checkBoxMaskingMode);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelMaskingMode);
            flowLayoutPanel1.Controls.Add(checkBoxSmoothing);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelSmoothing);
            flowLayoutPanel1.Controls.Add(checkBoxBandPassFilter);
            flowLayoutPanel1.Controls.Add(panel5);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelBandPassFilter);
            flowLayoutPanel1.Controls.Add(checkBoxRemoveKalpha2);
            flowLayoutPanel1.Controls.Add(checkBoxBackgroundSubtraction);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelBackgroundSubtraction);
            flowLayoutPanel1.Controls.Add(checkBoxNormarizeIntensity);
            flowLayoutPanel1.Controls.Add(flowLayoutPanelNormarizeIntensity);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // checkBoxTwoThetaOffset
            // 
            resources.ApplyResources(checkBoxTwoThetaOffset, "checkBoxTwoThetaOffset");
            checkBoxTwoThetaOffset.Name = "checkBoxTwoThetaOffset";
            toolTip.SetToolTip(checkBoxTwoThetaOffset, resources.GetString("checkBoxTwoThetaOffset.ToolTip"));
            checkBoxTwoThetaOffset.UseVisualStyleBackColor = true;
            checkBoxTwoThetaOffset.CheckedChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // flowLayoutPanelTwoThetaOffset
            // 
            resources.ApplyResources(flowLayoutPanelTwoThetaOffset, "flowLayoutPanelTwoThetaOffset");
            flowLayoutPanelTwoThetaOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flowLayoutPanelTwoThetaOffset.Controls.Add(flowLayoutPanel10);
            flowLayoutPanelTwoThetaOffset.Controls.Add(flowLayoutPanel9);
            flowLayoutPanelTwoThetaOffset.Name = "flowLayoutPanelTwoThetaOffset";
            // 
            // flowLayoutPanel10
            // 
            resources.ApplyResources(flowLayoutPanel10, "flowLayoutPanel10");
            flowLayoutPanel10.Controls.Add(numericBoxTwhoThetaOffsetCoeff0);
            flowLayoutPanel10.Controls.Add(numericBoxTwhoThetaOffsetCoeff1);
            flowLayoutPanel10.Controls.Add(numericBoxTwhoThetaOffsetCoeff2);
            flowLayoutPanel10.Name = "flowLayoutPanel10";
            // 
            // numericBoxTwhoThetaOffsetCoeff0
            // 
            numericBoxTwhoThetaOffsetCoeff0.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff0.DecimalPlaces = 5;
            resources.ApplyResources(numericBoxTwhoThetaOffsetCoeff0, "numericBoxTwhoThetaOffsetCoeff0");
            numericBoxTwhoThetaOffsetCoeff0.Name = "numericBoxTwhoThetaOffsetCoeff0";
            numericBoxTwhoThetaOffsetCoeff0.SkipEventDuringInput = false;
            numericBoxTwhoThetaOffsetCoeff0.SmartIncrement = true;
            numericBoxTwhoThetaOffsetCoeff0.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxTwhoThetaOffsetCoeff0, resources.GetString("numericBoxTwhoThetaOffsetCoeff0.ToolTip"));
            numericBoxTwhoThetaOffsetCoeff0.ValueBoxWidth = 50;
            numericBoxTwhoThetaOffsetCoeff0.ValueFontSize = 9F;
            numericBoxTwhoThetaOffsetCoeff0.ValueChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // numericBoxTwhoThetaOffsetCoeff1
            // 
            numericBoxTwhoThetaOffsetCoeff1.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff1.DecimalPlaces = 5;
            resources.ApplyResources(numericBoxTwhoThetaOffsetCoeff1, "numericBoxTwhoThetaOffsetCoeff1");
            numericBoxTwhoThetaOffsetCoeff1.Name = "numericBoxTwhoThetaOffsetCoeff1";
            numericBoxTwhoThetaOffsetCoeff1.SkipEventDuringInput = false;
            numericBoxTwhoThetaOffsetCoeff1.SmartIncrement = true;
            numericBoxTwhoThetaOffsetCoeff1.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxTwhoThetaOffsetCoeff1, resources.GetString("numericBoxTwhoThetaOffsetCoeff1.ToolTip"));
            numericBoxTwhoThetaOffsetCoeff1.ValueFontSize = 9F;
            numericBoxTwhoThetaOffsetCoeff1.ValueChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // numericBoxTwhoThetaOffsetCoeff2
            // 
            numericBoxTwhoThetaOffsetCoeff2.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTwhoThetaOffsetCoeff2.DecimalPlaces = 5;
            resources.ApplyResources(numericBoxTwhoThetaOffsetCoeff2, "numericBoxTwhoThetaOffsetCoeff2");
            numericBoxTwhoThetaOffsetCoeff2.Name = "numericBoxTwhoThetaOffsetCoeff2";
            numericBoxTwhoThetaOffsetCoeff2.SkipEventDuringInput = false;
            numericBoxTwhoThetaOffsetCoeff2.SmartIncrement = true;
            numericBoxTwhoThetaOffsetCoeff2.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxTwhoThetaOffsetCoeff2, resources.GetString("numericBoxTwhoThetaOffsetCoeff2.ToolTip"));
            numericBoxTwhoThetaOffsetCoeff2.ValueFontSize = 9F;
            numericBoxTwhoThetaOffsetCoeff2.ValueChanged += checkBoxTwoThetaOffset_CheckedChanged;
            // 
            // flowLayoutPanel9
            // 
            resources.ApplyResources(flowLayoutPanel9, "flowLayoutPanel9");
            flowLayoutPanel9.Controls.Add(buttonTwoThetaCalibration);
            flowLayoutPanel9.Controls.Add(buttonTwoThetaOffsetReset);
            flowLayoutPanel9.Name = "flowLayoutPanel9";
            // 
            // buttonTwoThetaCalibration
            // 
            resources.ApplyResources(buttonTwoThetaCalibration, "buttonTwoThetaCalibration");
            buttonTwoThetaCalibration.Name = "buttonTwoThetaCalibration";
            toolTip.SetToolTip(buttonTwoThetaCalibration, resources.GetString("buttonTwoThetaCalibration.ToolTip"));
            buttonTwoThetaCalibration.UseVisualStyleBackColor = true;
            buttonTwoThetaCalibration.Click += buttonTwoThetaCalibration_Click;
            // 
            // buttonTwoThetaOffsetReset
            // 
            resources.ApplyResources(buttonTwoThetaOffsetReset, "buttonTwoThetaOffsetReset");
            buttonTwoThetaOffsetReset.Name = "buttonTwoThetaOffsetReset";
            toolTip.SetToolTip(buttonTwoThetaOffsetReset, resources.GetString("buttonTwoThetaOffsetReset.ToolTip"));
            buttonTwoThetaOffsetReset.UseVisualStyleBackColor = true;
            buttonTwoThetaOffsetReset.Click += buttonTwoThetaOffsetReset_Click;
            // 
            // checkBoxMaskingMode
            // 
            resources.ApplyResources(checkBoxMaskingMode, "checkBoxMaskingMode");
            checkBoxMaskingMode.Name = "checkBoxMaskingMode";
            toolTip.SetToolTip(checkBoxMaskingMode, resources.GetString("checkBoxMaskingMode.ToolTip"));
            checkBoxMaskingMode.UseVisualStyleBackColor = true;
            checkBoxMaskingMode.CheckedChanged += checkBoxMaskingMode_CheckedChanged;
            // 
            // flowLayoutPanelMaskingMode
            // 
            resources.ApplyResources(flowLayoutPanelMaskingMode, "flowLayoutPanelMaskingMode");
            flowLayoutPanelMaskingMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flowLayoutPanelMaskingMode.Controls.Add(flowLayoutPanel14);
            flowLayoutPanelMaskingMode.Controls.Add(panel6);
            flowLayoutPanelMaskingMode.Name = "flowLayoutPanelMaskingMode";
            // 
            // flowLayoutPanel14
            // 
            resources.ApplyResources(flowLayoutPanel14, "flowLayoutPanel14");
            flowLayoutPanel14.Controls.Add(checkBoxShowMaskedRange);
            flowLayoutPanel14.Controls.Add(numericBoxInterpolationOrder);
            flowLayoutPanel14.Controls.Add(numericBoxInterpolationPoints);
            flowLayoutPanel14.Name = "flowLayoutPanel14";
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
            // numericBoxInterpolationOrder
            // 
            numericBoxInterpolationOrder.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(numericBoxInterpolationOrder, "numericBoxInterpolationOrder");
            numericBoxInterpolationOrder.Maximum = 5D;
            numericBoxInterpolationOrder.Minimum = 0D; // 260701Cl 旧numericUpDownInterpolationOrder(Minimum未指定=既定値0)を復元 (NumericBox移行時のコピー漏れ)
            numericBoxInterpolationOrder.Name = "numericBoxInterpolationOrder";
            numericBoxInterpolationOrder.RadianValue = 0.052359877559829883D;
            numericBoxInterpolationOrder.ShowUpDown = true;
            toolTip.SetToolTip(numericBoxInterpolationOrder, resources.GetString("numericBoxInterpolationOrder.ToolTip"));
            numericBoxInterpolationOrder.Value = 3D;
            numericBoxInterpolationOrder.ValueBoxWidth = 25;
            numericBoxInterpolationOrder.ValueChanged += checkBoxMaskingMode_CheckedChanged;
            // 
            // numericBoxInterpolationPoints
            // 
            numericBoxInterpolationPoints.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(numericBoxInterpolationPoints, "numericBoxInterpolationPoints");
            numericBoxInterpolationPoints.Maximum = 100D;
            numericBoxInterpolationPoints.Minimum = 0D;
            numericBoxInterpolationPoints.Name = "numericBoxInterpolationPoints";
            numericBoxInterpolationPoints.RadianValue = 0.052359877559829883D;
            numericBoxInterpolationPoints.ShowUpDown = true;
            toolTip.SetToolTip(numericBoxInterpolationPoints, resources.GetString("numericBoxInterpolationPoints.ToolTip"));
            numericBoxInterpolationPoints.Value = 3D;
            numericBoxInterpolationPoints.ValueBoxWidth = 25;
            numericBoxInterpolationPoints.ValueChanged += checkBoxMaskingMode_CheckedChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(listBoxMaskRanges);
            panel6.Controls.Add(flowLayoutPanel15);
            resources.ApplyResources(panel6, "panel6");
            panel6.Name = "panel6";
            // 
            // listBoxMaskRanges
            // 
            listBoxMaskRanges.AllowDrop = true;
            listBoxMaskRanges.ContextMenuStrip = contextMenuStripMaskRange;
            resources.ApplyResources(listBoxMaskRanges, "listBoxMaskRanges");
            listBoxMaskRanges.FormattingEnabled = true;
            listBoxMaskRanges.Name = "listBoxMaskRanges";
            toolTip.SetToolTip(listBoxMaskRanges, resources.GetString("listBoxMaskRanges.ToolTip"));
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
            // flowLayoutPanel15
            // 
            resources.ApplyResources(flowLayoutPanel15, "flowLayoutPanel15");
            flowLayoutPanel15.Controls.Add(buttonDeleteMask);
            flowLayoutPanel15.Controls.Add(buttonDeleteAllMask);
            flowLayoutPanel15.Name = "flowLayoutPanel15";
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
            // flowLayoutPanelSmoothing
            // 
            resources.ApplyResources(flowLayoutPanelSmoothing, "flowLayoutPanelSmoothing");
            flowLayoutPanelSmoothing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flowLayoutPanelSmoothing.Controls.Add(label17);
            flowLayoutPanelSmoothing.Controls.Add(numericBoxSmoothingSavitzkyAndGolayM);
            flowLayoutPanelSmoothing.Controls.Add(numericBoxSmoothingSavitzkyAndGolayN);
            flowLayoutPanelSmoothing.Name = "flowLayoutPanelSmoothing";
            // 
            // numericBoxSmoothingSavitzkyAndGolayM
            // 
            numericBoxSmoothingSavitzkyAndGolayM.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(numericBoxSmoothingSavitzkyAndGolayM, "numericBoxSmoothingSavitzkyAndGolayM");
            numericBoxSmoothingSavitzkyAndGolayM.Maximum = 100D;
            numericBoxSmoothingSavitzkyAndGolayM.Minimum = 0D;
            numericBoxSmoothingSavitzkyAndGolayM.Name = "numericBoxSmoothingSavitzkyAndGolayM";
            numericBoxSmoothingSavitzkyAndGolayM.RadianValue = 0.052359877559829883D;
            numericBoxSmoothingSavitzkyAndGolayM.ShowUpDown = true;
            toolTip.SetToolTip(numericBoxSmoothingSavitzkyAndGolayM, resources.GetString("numericBoxSmoothingSavitzkyAndGolayM.ToolTip"));
            numericBoxSmoothingSavitzkyAndGolayM.Value = 3D;
            numericBoxSmoothingSavitzkyAndGolayM.ValueBoxWidth = 30;
            numericBoxSmoothingSavitzkyAndGolayM.ValueChanged += checkBoxSmoothing_CheckedChanged;
            // 
            // numericBoxSmoothingSavitzkyAndGolayN
            // 
            numericBoxSmoothingSavitzkyAndGolayN.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(numericBoxSmoothingSavitzkyAndGolayN, "numericBoxSmoothingSavitzkyAndGolayN");
            numericBoxSmoothingSavitzkyAndGolayN.Maximum = 5D;
            numericBoxSmoothingSavitzkyAndGolayN.Minimum = 0D;
            numericBoxSmoothingSavitzkyAndGolayN.Name = "numericBoxSmoothingSavitzkyAndGolayN";
            numericBoxSmoothingSavitzkyAndGolayN.RadianValue = 0.052359877559829883D;
            numericBoxSmoothingSavitzkyAndGolayN.ShowUpDown = true;
            toolTip.SetToolTip(numericBoxSmoothingSavitzkyAndGolayN, resources.GetString("numericBoxSmoothingSavitzkyAndGolayN.ToolTip"));
            numericBoxSmoothingSavitzkyAndGolayN.Value = 3D;
            numericBoxSmoothingSavitzkyAndGolayN.ValueBoxWidth = 30;
            numericBoxSmoothingSavitzkyAndGolayN.ValueChanged += checkBoxSmoothing_CheckedChanged;
            // 
            // checkBoxBandPassFilter
            // 
            resources.ApplyResources(checkBoxBandPassFilter, "checkBoxBandPassFilter");
            checkBoxBandPassFilter.Name = "checkBoxBandPassFilter";
            toolTip.SetToolTip(checkBoxBandPassFilter, resources.GetString("checkBoxBandPassFilter.ToolTip"));
            checkBoxBandPassFilter.UseVisualStyleBackColor = true;
            checkBoxBandPassFilter.CheckedChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // panel5
            // 
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            // 
            // flowLayoutPanelBandPassFilter
            // 
            resources.ApplyResources(flowLayoutPanelBandPassFilter, "flowLayoutPanelBandPassFilter");
            flowLayoutPanelBandPassFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flowLayoutPanelBandPassFilter.Controls.Add(flowLayoutPanel8);
            flowLayoutPanelBandPassFilter.Controls.Add(flowLayoutPanel11);
            flowLayoutPanelBandPassFilter.Name = "flowLayoutPanelBandPassFilter";
            // 
            // flowLayoutPanel8
            // 
            resources.ApplyResources(flowLayoutPanel8, "flowLayoutPanel8");
            flowLayoutPanel8.Controls.Add(checkBoxLowPassFilter);
            flowLayoutPanel8.Controls.Add(numericBoxLowPass);
            flowLayoutPanel8.Controls.Add(labelLowPath);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            // 
            // checkBoxLowPassFilter
            // 
            resources.ApplyResources(checkBoxLowPassFilter, "checkBoxLowPassFilter");
            checkBoxLowPassFilter.Name = "checkBoxLowPassFilter";
            toolTip.SetToolTip(checkBoxLowPassFilter, resources.GetString("checkBoxLowPassFilter.ToolTip"));
            checkBoxLowPassFilter.UseVisualStyleBackColor = true;
            checkBoxLowPassFilter.CheckedChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // numericBoxLowPass
            // 
            numericBoxLowPass.BackColor = System.Drawing.Color.Transparent;
            numericBoxLowPass.DecimalPlaces = 2;
            resources.ApplyResources(numericBoxLowPass, "numericBoxLowPass");
            numericBoxLowPass.Maximum = 10D;
            numericBoxLowPass.Minimum = 0D;
            numericBoxLowPass.Name = "numericBoxLowPass";
            numericBoxLowPass.ShowUpDown = true;
            toolTip.SetToolTip(numericBoxLowPass, resources.GetString("numericBoxLowPass.ToolTip"));
            numericBoxLowPass.UpDown_Increment = 0.01D;
            numericBoxLowPass.ValueChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // labelLowPath
            // 
            resources.ApplyResources(labelLowPath, "labelLowPath");
            labelLowPath.Name = "labelLowPath";
            // 
            // flowLayoutPanel11
            // 
            resources.ApplyResources(flowLayoutPanel11, "flowLayoutPanel11");
            flowLayoutPanel11.Controls.Add(checkBoxHighPassFilter);
            flowLayoutPanel11.Controls.Add(numericBoxHighPass);
            flowLayoutPanel11.Controls.Add(labelHighPass);
            flowLayoutPanel11.Name = "flowLayoutPanel11";
            // 
            // checkBoxHighPassFilter
            // 
            resources.ApplyResources(checkBoxHighPassFilter, "checkBoxHighPassFilter");
            checkBoxHighPassFilter.Name = "checkBoxHighPassFilter";
            toolTip.SetToolTip(checkBoxHighPassFilter, resources.GetString("checkBoxHighPassFilter.ToolTip"));
            checkBoxHighPassFilter.UseVisualStyleBackColor = true;
            checkBoxHighPassFilter.CheckedChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // numericBoxHighPass
            // 
            numericBoxHighPass.BackColor = System.Drawing.Color.Transparent;
            numericBoxHighPass.DecimalPlaces = 2;
            resources.ApplyResources(numericBoxHighPass, "numericBoxHighPass");
            numericBoxHighPass.Maximum = 10D;
            numericBoxHighPass.Minimum = 0D;
            numericBoxHighPass.Name = "numericBoxHighPass";
            numericBoxHighPass.ShowUpDown = true;
            toolTip.SetToolTip(numericBoxHighPass, resources.GetString("numericBoxHighPass.ToolTip"));
            numericBoxHighPass.UpDown_Increment = 0.01D;
            numericBoxHighPass.ValueChanged += checkBoxBandPassFilter_CheckedChanged;
            // 
            // labelHighPass
            // 
            resources.ApplyResources(labelHighPass, "labelHighPass");
            labelHighPass.Name = "labelHighPass";
            // 
            // checkBoxRemoveKalpha2
            // 
            resources.ApplyResources(checkBoxRemoveKalpha2, "checkBoxRemoveKalpha2");
            checkBoxRemoveKalpha2.Name = "checkBoxRemoveKalpha2";
            toolTip.SetToolTip(checkBoxRemoveKalpha2, resources.GetString("checkBoxRemoveKalpha2.ToolTip"));
            checkBoxRemoveKalpha2.UseVisualStyleBackColor = true;
            checkBoxRemoveKalpha2.CheckedChanged += checkBoxRemoveKalpha2_CheckedChanged;
            // 
            // flowLayoutPanelBackgroundSubtraction
            // 
            resources.ApplyResources(flowLayoutPanelBackgroundSubtraction, "flowLayoutPanelBackgroundSubtraction");
            flowLayoutPanelBackgroundSubtraction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flowLayoutPanelBackgroundSubtraction.Controls.Add(checkBoxShowBackgroundProfile);
            flowLayoutPanelBackgroundSubtraction.Controls.Add(radioButtonBagkgroundBSpline);
            flowLayoutPanelBackgroundSubtraction.Controls.Add(flowLayoutPanelBackgroundBSpline);
            flowLayoutPanelBackgroundSubtraction.Controls.Add(radioButtonBackgroundReferrence);
            flowLayoutPanelBackgroundSubtraction.Controls.Add(flowLayoutPanelBackgroundReferrence);
            flowLayoutPanelBackgroundSubtraction.Name = "flowLayoutPanelBackgroundSubtraction";
            // 
            // flowLayoutPanelBackgroundBSpline
            // 
            resources.ApplyResources(flowLayoutPanelBackgroundBSpline, "flowLayoutPanelBackgroundBSpline");
            flowLayoutPanelBackgroundBSpline.Controls.Add(buttonBackgroundAutoDetectBG);
            flowLayoutPanelBackgroundBSpline.Controls.Add(numericBoxBgPointsNumber);
            flowLayoutPanelBackgroundBSpline.Name = "flowLayoutPanelBackgroundBSpline";
            // 
            // numericBoxBgPointsNumber
            // 
            numericBoxBgPointsNumber.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(numericBoxBgPointsNumber, "numericBoxBgPointsNumber");
            numericBoxBgPointsNumber.Maximum = 50D;
            numericBoxBgPointsNumber.Minimum = 3D;
            numericBoxBgPointsNumber.Name = "numericBoxBgPointsNumber";
            numericBoxBgPointsNumber.RadianValue = 0.26179938779914941D;
            numericBoxBgPointsNumber.ShowUpDown = true;
            toolTip.SetToolTip(numericBoxBgPointsNumber, resources.GetString("numericBoxBgPointsNumber.ToolTip"));
            numericBoxBgPointsNumber.Value = 15D;
            numericBoxBgPointsNumber.ValueBoxWidth = 30;
            // 
            // flowLayoutPanelBackgroundReferrence
            // 
            resources.ApplyResources(flowLayoutPanelBackgroundReferrence, "flowLayoutPanelBackgroundReferrence");
            flowLayoutPanelBackgroundReferrence.Controls.Add(comboBoxBackgroundReferrence);
            flowLayoutPanelBackgroundReferrence.Controls.Add(numericBoxBackgroundReferrenceScale);
            flowLayoutPanelBackgroundReferrence.Name = "flowLayoutPanelBackgroundReferrence";
            // 
            // numericBoxBackgroundReferrenceScale
            // 
            numericBoxBackgroundReferrenceScale.BackColor = System.Drawing.Color.Transparent;
            numericBoxBackgroundReferrenceScale.DecimalPlaces = 4;
            resources.ApplyResources(numericBoxBackgroundReferrenceScale, "numericBoxBackgroundReferrenceScale");
            numericBoxBackgroundReferrenceScale.Maximum = 100D;
            numericBoxBackgroundReferrenceScale.Minimum = 0.0001D; // 260701Cl 旧numericUpDownBackgroundReferrenceScale.Minimum(=0.0001)を復元 (NumericBox移行時のコピー漏れ)
            numericBoxBackgroundReferrenceScale.Name = "numericBoxBackgroundReferrenceScale";
            numericBoxBackgroundReferrenceScale.RadianValue = 0.017453292519943295D;
            numericBoxBackgroundReferrenceScale.ShowUpDown = true;
            numericBoxBackgroundReferrenceScale.SmartIncrement = true; // 260701Cl 追加: 旧Increment(=0.01)相当。他の小数値NumericBox(LineWidth等)と同様SmartIncrementで代替 (NumericBox移行時のコピー漏れ)
            toolTip.SetToolTip(numericBoxBackgroundReferrenceScale, resources.GetString("numericBoxBackgroundReferrenceScale.ToolTip"));
            numericBoxBackgroundReferrenceScale.Value = 1D;
            numericBoxBackgroundReferrenceScale.ValueBoxWidth = 55;
            numericBoxBackgroundReferrenceScale.ValueChanged += checkBoxBackgroundSubtraction_CheckedChanged;
            // 
            // checkBoxNormarizeIntensity
            // 
            resources.ApplyResources(checkBoxNormarizeIntensity, "checkBoxNormarizeIntensity");
            checkBoxNormarizeIntensity.Name = "checkBoxNormarizeIntensity";
            toolTip.SetToolTip(checkBoxNormarizeIntensity, resources.GetString("checkBoxNormarizeIntensity.ToolTip"));
            checkBoxNormarizeIntensity.UseVisualStyleBackColor = true;
            checkBoxNormarizeIntensity.CheckedChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // flowLayoutPanelNormarizeIntensity
            // 
            resources.ApplyResources(flowLayoutPanelNormarizeIntensity, "flowLayoutPanelNormarizeIntensity");
            flowLayoutPanelNormarizeIntensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flowLayoutPanelNormarizeIntensity.Controls.Add(flowLayoutPanel17);
            flowLayoutPanelNormarizeIntensity.Controls.Add(flowLayoutPanel18);
            flowLayoutPanelNormarizeIntensity.Name = "flowLayoutPanelNormarizeIntensity";
            // 
            // flowLayoutPanel17
            // 
            resources.ApplyResources(flowLayoutPanel17, "flowLayoutPanel17");
            flowLayoutPanel17.Controls.Add(label1);
            flowLayoutPanel17.Controls.Add(radioButtonNormarizeAverage);
            flowLayoutPanel17.Controls.Add(radioButtonNormarizeMaximum);
            flowLayoutPanel17.Controls.Add(label2);
            flowLayoutPanel17.Name = "flowLayoutPanel17";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // flowLayoutPanel18
            // 
            resources.ApplyResources(flowLayoutPanel18, "flowLayoutPanel18");
            flowLayoutPanel18.Controls.Add(numericBoxNormarizeRangeLow);
            flowLayoutPanel18.Controls.Add(numericBoxNormarizeRangeHigh);
            flowLayoutPanel18.Controls.Add(numericBoxNormarizeIntensity);
            flowLayoutPanel18.Name = "flowLayoutPanel18";
            // 
            // numericBoxNormarizeRangeLow
            // 
            numericBoxNormarizeRangeLow.BackColor = System.Drawing.Color.Transparent;
            numericBoxNormarizeRangeLow.DecimalPlaces = 1;
            resources.ApplyResources(numericBoxNormarizeRangeLow, "numericBoxNormarizeRangeLow");
            numericBoxNormarizeRangeLow.Maximum = 1000000D;
            numericBoxNormarizeRangeLow.Minimum = 0D;
            numericBoxNormarizeRangeLow.Name = "numericBoxNormarizeRangeLow";
            numericBoxNormarizeRangeLow.ShowUpDown = true;
            numericBoxNormarizeRangeLow.SmartIncrement = true;
            toolTip.SetToolTip(numericBoxNormarizeRangeLow, resources.GetString("numericBoxNormarizeRangeLow.ToolTip"));
            numericBoxNormarizeRangeLow.ValueBoxWidth = 50;
            numericBoxNormarizeRangeLow.ValueChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // numericBoxNormarizeRangeHigh
            // 
            numericBoxNormarizeRangeHigh.BackColor = System.Drawing.Color.Transparent;
            numericBoxNormarizeRangeHigh.DecimalPlaces = 1;
            resources.ApplyResources(numericBoxNormarizeRangeHigh, "numericBoxNormarizeRangeHigh");
            numericBoxNormarizeRangeHigh.Maximum = 1000000D;
            numericBoxNormarizeRangeHigh.Minimum = 0D;
            numericBoxNormarizeRangeHigh.Name = "numericBoxNormarizeRangeHigh";
            numericBoxNormarizeRangeHigh.RadianValue = 3.1415926535897931D;
            numericBoxNormarizeRangeHigh.ShowUpDown = true;
            numericBoxNormarizeRangeHigh.SmartIncrement = true;
            toolTip.SetToolTip(numericBoxNormarizeRangeHigh, resources.GetString("numericBoxNormarizeRangeHigh.ToolTip"));
            numericBoxNormarizeRangeHigh.Value = 180D;
            numericBoxNormarizeRangeHigh.ValueBoxWidth = 50;
            numericBoxNormarizeRangeHigh.ValueChanged += checkBoxNormarizeIntensity_CheckStateChanged;
            // 
            // numericBoxNormarizeIntensity
            // 
            numericBoxNormarizeIntensity.BackColor = System.Drawing.Color.Transparent;
            numericBoxNormarizeIntensity.DecimalPlaces = 3;
            resources.ApplyResources(numericBoxNormarizeIntensity, "numericBoxNormarizeIntensity");
            numericBoxNormarizeIntensity.Maximum = 100000D;
            numericBoxNormarizeIntensity.Minimum = 1D;
            numericBoxNormarizeIntensity.Name = "numericBoxNormarizeIntensity";
            numericBoxNormarizeIntensity.RadianValue = 17.453292519943293D;
            numericBoxNormarizeIntensity.ShowUpDown = true;
            numericBoxNormarizeIntensity.SmartIncrement = true;
            toolTip.SetToolTip(numericBoxNormarizeIntensity, resources.GetString("numericBoxNormarizeIntensity.ToolTip"));
            numericBoxNormarizeIntensity.Value = 1000D;
            numericBoxNormarizeIntensity.ValueBoxWidth = 80;
            numericBoxNormarizeIntensity.ValueChanged += checkBoxNormarizeIntensity_CheckStateChanged;
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
            tabPage3.BackColor = System.Drawing.SystemColors.Control;
            tabPage3.Controls.Add(flowLayoutPanel4);
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Controls.Add(panel3);
            tabPage3.Controls.Add(groupBox1);
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Name = "tabPage3";
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(flowLayoutPanel4, "flowLayoutPanel4");
            flowLayoutPanel4.Controls.Add(buttonChangeSourceXAxis);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listBoxTwoProfiles1);
            tabPage1.Controls.Add(flowLayoutPanelFourCalculator);
            tabPage1.Controls.Add(listBoxTwoProfiles2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(flowLayoutPanel6);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
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
            numericalTextBoxTargetValue.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(numericalTextBoxTargetValue, "numericalTextBoxTargetValue");
            numericalTextBoxTargetValue.Name = "numericalTextBoxTargetValue";
            numericalTextBoxTargetValue.SkipEventDuringInput = false;
            numericalTextBoxTargetValue.SmartIncrement = true;
            numericalTextBoxTargetValue.ThousandsSeparator = true;
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
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label18);
            panel1.Name = "panel1";
            // 
            // panel4
            // 
            panel4.Controls.Add(textBoxOutputFilename);
            panel4.Controls.Add(buttonCalculate);
            resources.ApplyResources(panel4, "panel4");
            panel4.Name = "panel4";
            // 
            // textBoxOutputFilename
            // 
            resources.ApplyResources(textBoxOutputFilename, "textBoxOutputFilename");
            textBoxOutputFilename.Name = "textBoxOutputFilename";
            toolTip.SetToolTip(textBoxOutputFilename, resources.GetString("textBoxOutputFilename.ToolTip"));
            // 
            // buttonCalculate
            // 
            resources.ApplyResources(buttonCalculate, "buttonCalculate");
            buttonCalculate.Name = "buttonCalculate";
            toolTip.SetToolTip(buttonCalculate, resources.GetString("buttonCalculate.ToolTip"));
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            // 
            // flowLayoutPanel6
            // 
            resources.ApplyResources(flowLayoutPanel6, "flowLayoutPanel6");
            flowLayoutPanel6.Controls.Add(radioButtonAverage);
            flowLayoutPanel6.Controls.Add(radioButtonProfileAndValue);
            flowLayoutPanel6.Controls.Add(radioButtonTwoProfiles);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
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
            // toolTip
            // 
            toolTip.AutoPopDelay = 10000;
            toolTip.InitialDelay = 500;
            toolTip.IsBalloon = true;
            toolTip.ReshowDelay = 100;
            // 
            // FormProfileSetting
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(splitContainer1);
            Controls.Add(tabControl1);
            Name = "FormProfileSetting";
            FormClosing += FormProfileSetting_FormClosing;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataSetProfile).EndInit();
            panel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanelTwoThetaOffset.ResumeLayout(false);
            flowLayoutPanelTwoThetaOffset.PerformLayout();
            flowLayoutPanel10.ResumeLayout(false);
            flowLayoutPanel10.PerformLayout();
            flowLayoutPanel9.ResumeLayout(false);
            flowLayoutPanel9.PerformLayout();
            flowLayoutPanelMaskingMode.ResumeLayout(false);
            flowLayoutPanelMaskingMode.PerformLayout();
            flowLayoutPanel14.ResumeLayout(false);
            flowLayoutPanel14.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            contextMenuStripMaskRange.ResumeLayout(false);
            flowLayoutPanel15.ResumeLayout(false);
            flowLayoutPanel15.PerformLayout();
            flowLayoutPanelSmoothing.ResumeLayout(false);
            flowLayoutPanelSmoothing.PerformLayout();
            flowLayoutPanelBandPassFilter.ResumeLayout(false);
            flowLayoutPanelBandPassFilter.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel11.ResumeLayout(false);
            flowLayoutPanel11.PerformLayout();
            flowLayoutPanelBackgroundSubtraction.ResumeLayout(false);
            flowLayoutPanelBackgroundSubtraction.PerformLayout();
            flowLayoutPanelBackgroundBSpline.ResumeLayout(false);
            flowLayoutPanelBackgroundBSpline.PerformLayout();
            flowLayoutPanelBackgroundReferrence.ResumeLayout(false);
            flowLayoutPanelBackgroundReferrence.PerformLayout();
            flowLayoutPanelNormarizeIntensity.ResumeLayout(false);
            flowLayoutPanelNormarizeIntensity.PerformLayout();
            flowLayoutPanel17.ResumeLayout(false);
            flowLayoutPanel17.PerformLayout();
            flowLayoutPanel18.ResumeLayout(false);
            flowLayoutPanel18.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            flowLayoutPanelFourCalculator.ResumeLayout(false);
            flowLayoutPanelFourCalculator.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxSmoothing;
        private System.Windows.Forms.CheckBox checkBoxBackgroundSubtraction;
        public System.Windows.Forms.CheckBox checkBoxShowBackgroundProfile;
        private System.Windows.Forms.Button buttonUpper;
        private System.Windows.Forms.Button buttonLower;
        private Crystallography.Controls.HorizontalAxisUserControl xAxisUserControl;
        private System.Windows.Forms.Button buttonChangeSourceXAxis;
        private System.Windows.Forms.Button buttonBackgroundAutoDetectBG;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Crystallography.Controls.NumericBox numericBoxExposureTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxShiftHorizontalAxis;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonNormarizeAverage;
        private System.Windows.Forms.RadioButton radioButtonNormarizeMaximum;
        private System.Windows.Forms.RadioButton radioButtonBackgroundReferrence;
        private System.Windows.Forms.RadioButton radioButtonBagkgroundBSpline;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonApplyAllProfiles;
        private System.Windows.Forms.CheckBox checkBoxBandPassFilter;
        private System.Windows.Forms.CheckBox checkBoxNormarizeIntensity;
        private System.Windows.Forms.CheckBox checkBoxLowPassFilter;
        private System.Windows.Forms.CheckBox checkBoxHighPassFilter;
        private System.Windows.Forms.Label labelHighPass;
        private System.Windows.Forms.Label labelLowPath;
        public System.Windows.Forms.ComboBox comboBoxBackgroundReferrence;
        public System.Windows.Forms.DataGridView dataGridViewProfile;
        public System.Windows.Forms.BindingSource bindingSourceProfile;
        public DataSet dataSetProfile;
        private Crystallography.Controls.ColorControl colorControlLineColor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.ListBox listBoxTwoProfiles1; // 260414Cl public→internal
        internal System.Windows.Forms.ListBox listBoxTwoProfiles2; // 260414Cl public→internal
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFourCalculator;
        private Crystallography.Controls.NumericBox numericalTextBoxTargetValue;
        private System.Windows.Forms.CheckBox checkBoxMaskingMode;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ListBox listBoxMaskRanges;
        private System.Windows.Forms.Button buttonDeleteMask;
        private System.Windows.Forms.Button buttonDeleteAllMask;
        public System.Windows.Forms.CheckBox checkBoxShowMaskedRange;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMaskRange;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveMaskingRange;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReadMaskingRange;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox textBoxOutputFilename; // 260414Cl public→internal
        internal System.Windows.Forms.RadioButton radioButtonDivision; // 260414Cl public→internal
        internal System.Windows.Forms.RadioButton radioButtonMutiplication; // 260414Cl public→internal
        internal System.Windows.Forms.RadioButton radioButtonSubtraction; // 260414Cl public→internal
        internal System.Windows.Forms.RadioButton radioButtonAddition; // 260414Cl public→internal
        internal System.Windows.Forms.RadioButton radioButtonAverage; // 260414Cl public→internal
        public System.Windows.Forms.RadioButton radioButtonProfileAndValue;
        internal System.Windows.Forms.RadioButton radioButtonTwoProfiles; // 260414Cl public→internal
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonTwoThetaOffsetReset;
        internal System.Windows.Forms.TextBox textBoxComment; // 260414Cl public→internal
        internal System.Windows.Forms.TextBox textBoxProfileName; // 260414Cl public→internal
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileDataGridViewTextBoxColumn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private NumericBox numericBoxLineWidth;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private NumericBox numericBoxShiftHorizontalAxis;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTwoThetaOffset;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSmoothing;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBandPassFilter;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBackgroundSubtraction;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel14;
        private NumericBox numericBoxInterpolationOrder;
        private NumericBox numericBoxInterpolationPoints;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel15;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMaskingMode;
        private NumericBox numericBoxSmoothingSavitzkyAndGolayM;
        private NumericBox numericBoxSmoothingSavitzkyAndGolayN;
        private NumericBox numericBoxLowPass;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private NumericBox numericBoxHighPass;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBackgroundBSpline;
        private NumericBox numericBoxBgPointsNumber;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBackgroundReferrence;
        private NumericBox numericBoxBackgroundReferrenceScale;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNormarizeIntensity;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel17;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel18;
        private NumericBox numericBoxNormarizeRangeLow;
        private NumericBox numericBoxNormarizeIntensity;
        private NumericBox numericBoxNormarizeRangeHigh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
