using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using Crystallography;
using System.Collections.Generic;
using Crystallography.Controls;


namespace PDIndexer
{
    /// <summary>
    /// FormCrystal の概要の説明です。
    /// </summary>
    public partial class FormCrystal //260604Cl 基底クラスは FormCrystal.cs 側で FormBase に変更
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormCrystal));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            groupBox3 = new GroupBox();
            crystalControl = new CrystalControl();
            panel2 = new Panel();
            buttonChange = new Button();
            buttonAdd = new Button();
            groupBox1 = new GroupBox();
            dataGridViewCrystal = new DataGridView();
            checkDataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            PeakColor = new DataGridViewImageColumn();
            Crystal = new DataGridViewTextBoxColumn();
            bindingSource = new BindingSource(components);
            flowLayoutPanel3 = new FlowLayoutPanel();
            buttonUpper = new Button();
            buttonLower = new Button();
            buttonDelete = new Button();
            buttonAllClear = new Button();
            panel3 = new Panel();
            groupBox2 = new GroupBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            checkBoxShowPeakOverProfiles = new CheckBox();
            checkBoxCalculateIntensity = new CheckBox();
            checkBoxVariableRatioOfIntensity = new CheckBox();
            checkBoxShowPeakUnderProfile = new CheckBox();
            numericBoxHeightOfBottomPeak = new NumericBox();
            checkBoxInvisibleWeakPeak = new CheckBox();
            numericBoxThresholdIntesity = new NumericBox();
            checkBoxCombineSameDspacingPeaks = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            radioButtonAngleThreshold = new RadioButton();
            numericBoxAngleThreshold = new NumericBox();
            flowLayoutPanel6 = new FlowLayoutPanel();
            radioButtonEnergyThreshold = new RadioButton();
            numericBoxEnergyThreshold = new NumericBox();
            checkBoxShowPeakIndices = new CheckBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            radioButtonAllCheckedCrystals = new RadioButton();
            radioButtonOnlySelectedCrystal = new RadioButton();
            groupBox4 = new GroupBox();
            crystalDatabaseControl = new CrystalDatabaseControl();
            panel1 = new Panel();
            searchCrystalControl = new SearchCrystalControl();
            contextMenuStrip1 = new ContextMenuStrip(components);
            incrementToolStripMenuItem = new ToolStripMenuItem();
            checkDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            crystalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            toolTip = new ToolTip(components);
            dataGridViewImageColumn1 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn2 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn3 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox3.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)dataGridViewCrystal).BeginInit();
            ((ISupportInitialize)bindingSource).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox4.SuspendLayout();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox4);
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(crystalControl);
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // crystalControl
            // 
            crystalControl.AllowDrop = true;
            resources.ApplyResources(crystalControl, "crystalControl");
            crystalControl.Name = "crystalControl";
            crystalControl.VisibleBondsPolyhedraTab = false;
            crystalControl.VisibleElasticityTab = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonChange);
            panel2.Controls.Add(buttonAdd);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // buttonChange
            // 
            resources.ApplyResources(buttonChange, "buttonChange");
            buttonChange.BackColor = Color.SteelBlue;
            buttonChange.ForeColor = SystemColors.ControlLightLight;
            buttonChange.Name = "buttonChange";
            buttonChange.UseVisualStyleBackColor = false;
            buttonChange.Click += buttonChangeCrystal_Click;
            // 
            // buttonAdd
            // 
            resources.ApplyResources(buttonAdd, "buttonAdd");
            buttonAdd.BackColor = Color.SteelBlue;
            buttonAdd.ForeColor = SystemColors.ControlLightLight;
            buttonAdd.Name = "buttonAdd";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAddCrystal_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(dataGridViewCrystal);
            groupBox1.Controls.Add(flowLayoutPanel3);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // dataGridViewCrystal
            // 
            dataGridViewCrystal.AllowUserToAddRows = false;
            dataGridViewCrystal.AllowUserToDeleteRows = false;
            dataGridViewCrystal.AllowUserToResizeColumns = false;
            dataGridViewCrystal.AllowUserToResizeRows = false;
            dataGridViewCrystal.AutoGenerateColumns = false;
            dataGridViewCrystal.BorderStyle = BorderStyle.None;
            dataGridViewCrystal.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewCrystal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(dataGridViewCrystal, "dataGridViewCrystal");
            dataGridViewCrystal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCrystal.ColumnHeadersVisible = false;
            dataGridViewCrystal.Columns.AddRange(new DataGridViewColumn[] { checkDataGridViewCheckBoxColumn1, PeakColor, Crystal });
            dataGridViewCrystal.DataSource = bindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewCrystal.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCrystal.EnableHeadersVisualStyles = false;
            dataGridViewCrystal.MultiSelect = false;
            dataGridViewCrystal.Name = "dataGridViewCrystal";
            dataGridViewCrystal.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewCrystal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCrystal.RowHeadersVisible = false;
            dataGridViewCrystal.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCrystal.RowTemplate.Height = 21;
            dataGridViewCrystal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCrystal.CellMouseClick += dataGridViewCrystal_CellMouseClick;
            dataGridViewCrystal.CellMouseDoubleClick += dataGridViewCrystal_CellMouseClick;
            dataGridViewCrystal.KeyDown += dataGridViewCrystal_KeyDown;
            // 
            // checkDataGridViewCheckBoxColumn1
            // 
            checkDataGridViewCheckBoxColumn1.DataPropertyName = "Check";
            resources.ApplyResources(checkDataGridViewCheckBoxColumn1, "checkDataGridViewCheckBoxColumn1");
            checkDataGridViewCheckBoxColumn1.Name = "checkDataGridViewCheckBoxColumn1";
            checkDataGridViewCheckBoxColumn1.ReadOnly = true;
            checkDataGridViewCheckBoxColumn1.Resizable = DataGridViewTriState.False;
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
            // Crystal
            // 
            Crystal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Crystal.DataPropertyName = "Crystal";
            resources.ApplyResources(Crystal, "Crystal");
            Crystal.Name = "Crystal";
            Crystal.ReadOnly = true;
            Crystal.Resizable = DataGridViewTriState.False;
            // 
            // bindingSource
            // 
            bindingSource.AllowNew = true;
            bindingSource.DataMember = "DataTableCrystal";
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(flowLayoutPanel3, "flowLayoutPanel3");
            flowLayoutPanel3.Controls.Add(buttonUpper);
            flowLayoutPanel3.Controls.Add(buttonLower);
            flowLayoutPanel3.Controls.Add(buttonDelete);
            flowLayoutPanel3.Controls.Add(buttonAllClear);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
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
            // buttonDelete
            // 
            resources.ApplyResources(buttonDelete, "buttonDelete");
            buttonDelete.BackColor = Color.IndianRed;
            buttonDelete.ForeColor = Color.White;
            buttonDelete.Name = "buttonDelete";
            buttonDelete.UseVisualStyleBackColor = false;
            buttonDelete.Click += buttonDeleteCrystal_Click;
            // 
            // buttonAllClear
            // 
            resources.ApplyResources(buttonAllClear, "buttonAllClear");
            buttonAllClear.BackColor = Color.DarkRed;
            buttonAllClear.ForeColor = Color.White;
            buttonAllClear.Name = "buttonAllClear";
            buttonAllClear.UseVisualStyleBackColor = false;
            buttonAllClear.Click += buttonAllClear_Click;
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(flowLayoutPanel4);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(flowLayoutPanel4, "flowLayoutPanel4");
            flowLayoutPanel4.Controls.Add(checkBoxShowPeakOverProfiles);
            flowLayoutPanel4.Controls.Add(checkBoxCalculateIntensity);
            flowLayoutPanel4.Controls.Add(checkBoxVariableRatioOfIntensity);
            flowLayoutPanel4.Controls.Add(checkBoxShowPeakUnderProfile);
            flowLayoutPanel4.Controls.Add(numericBoxHeightOfBottomPeak);
            flowLayoutPanel4.Controls.Add(checkBoxInvisibleWeakPeak);
            flowLayoutPanel4.Controls.Add(numericBoxThresholdIntesity);
            flowLayoutPanel4.Controls.Add(checkBoxCombineSameDspacingPeaks);
            flowLayoutPanel4.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel4.Controls.Add(checkBoxShowPeakIndices);
            flowLayoutPanel4.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // checkBoxShowPeakOverProfiles
            // 
            resources.ApplyResources(checkBoxShowPeakOverProfiles, "checkBoxShowPeakOverProfiles");
            checkBoxShowPeakOverProfiles.Checked = true;
            checkBoxShowPeakOverProfiles.CheckState = CheckState.Checked;
            checkBoxShowPeakOverProfiles.Name = "checkBoxShowPeakOverProfiles";
            checkBoxShowPeakOverProfiles.UseVisualStyleBackColor = true;
            checkBoxShowPeakOverProfiles.CheckedChanged += checkBoxShowPeakOverProfiles_CheckedChanged;
            // 
            // checkBoxCalculateIntensity
            // 
            resources.ApplyResources(checkBoxCalculateIntensity, "checkBoxCalculateIntensity");
            checkBoxCalculateIntensity.Checked = true;
            checkBoxCalculateIntensity.CheckState = CheckState.Checked;
            checkBoxCalculateIntensity.Name = "checkBoxCalculateIntensity";
            toolTip.SetToolTip(checkBoxCalculateIntensity, resources.GetString("checkBoxCalculateIntensity.ToolTip"));
            checkBoxCalculateIntensity.UseVisualStyleBackColor = true;
            checkBoxCalculateIntensity.CheckedChanged += checkBoxCalculateIntensity_CheckedChanged;
            // 
            // checkBoxVariableRatioOfIntensity
            // 
            resources.ApplyResources(checkBoxVariableRatioOfIntensity, "checkBoxVariableRatioOfIntensity");
            checkBoxVariableRatioOfIntensity.Name = "checkBoxVariableRatioOfIntensity";
            toolTip.SetToolTip(checkBoxVariableRatioOfIntensity, resources.GetString("checkBoxVariableRatioOfIntensity.ToolTip"));
            checkBoxVariableRatioOfIntensity.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowPeakUnderProfile
            // 
            resources.ApplyResources(checkBoxShowPeakUnderProfile, "checkBoxShowPeakUnderProfile");
            checkBoxShowPeakUnderProfile.Name = "checkBoxShowPeakUnderProfile";
            checkBoxShowPeakUnderProfile.UseVisualStyleBackColor = true;
            checkBoxShowPeakUnderProfile.CheckedChanged += checkBoxShowPeakUnderProfile_CheckedChanged;
            // 
            // numericBoxHeightOfBottomPeak
            // 
            numericBoxHeightOfBottomPeak.BackColor = Color.Transparent;
            resources.ApplyResources(numericBoxHeightOfBottomPeak, "numericBoxHeightOfBottomPeak");
            numericBoxHeightOfBottomPeak.Maximum = 100D;
            numericBoxHeightOfBottomPeak.Minimum = 0D;
            numericBoxHeightOfBottomPeak.Name = "numericBoxHeightOfBottomPeak";
            numericBoxHeightOfBottomPeak.RadianValue = 0.087266462599716474D;
            numericBoxHeightOfBottomPeak.ShowUpDown = true;
            numericBoxHeightOfBottomPeak.SmartIncrement = true;
            numericBoxHeightOfBottomPeak.Value = 5D;
            numericBoxHeightOfBottomPeak.ValueBoxWidth = 30;
            numericBoxHeightOfBottomPeak.ValueChanged += checkBoxShowPeakUnderProfile_CheckedChanged;
            // 
            // checkBoxInvisibleWeakPeak
            // 
            resources.ApplyResources(checkBoxInvisibleWeakPeak, "checkBoxInvisibleWeakPeak");
            checkBoxInvisibleWeakPeak.Name = "checkBoxInvisibleWeakPeak";
            checkBoxInvisibleWeakPeak.UseVisualStyleBackColor = true;
            checkBoxInvisibleWeakPeak.CheckedChanged += checkBoxInvisibleWeakPeak_CheckedChanged;
            // 
            // numericBoxThresholdIntesity
            // 
            numericBoxThresholdIntesity.BackColor = Color.Transparent;
            numericBoxThresholdIntesity.DecimalPlaces = 1;
            resources.ApplyResources(numericBoxThresholdIntesity, "numericBoxThresholdIntesity");
            numericBoxThresholdIntesity.Maximum = 100D;
            numericBoxThresholdIntesity.Minimum = 0D;
            numericBoxThresholdIntesity.Name = "numericBoxThresholdIntesity";
            numericBoxThresholdIntesity.RadianValue = 0.017453292519943295D;
            numericBoxThresholdIntesity.ShowUpDown = true;
            numericBoxThresholdIntesity.SmartIncrement = true;
            numericBoxThresholdIntesity.Value = 1D;
            numericBoxThresholdIntesity.ValueBoxWidth = 30;
            numericBoxThresholdIntesity.ValueChanged += checkBoxInvisibleWeakPeak_CheckedChanged;
            // 
            // checkBoxCombineSameDspacingPeaks
            // 
            resources.ApplyResources(checkBoxCombineSameDspacingPeaks, "checkBoxCombineSameDspacingPeaks");
            checkBoxCombineSameDspacingPeaks.Name = "checkBoxCombineSameDspacingPeaks";
            checkBoxCombineSameDspacingPeaks.UseVisualStyleBackColor = true;
            checkBoxCombineSameDspacingPeaks.CheckedChanged += checkBoxCombineSameDspacingPeaks_CheckedChanged;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(flowLayoutPanel5);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // flowLayoutPanel5
            // 
            resources.ApplyResources(flowLayoutPanel5, "flowLayoutPanel5");
            flowLayoutPanel5.Controls.Add(radioButtonAngleThreshold);
            flowLayoutPanel5.Controls.Add(numericBoxAngleThreshold);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            // 
            // radioButtonAngleThreshold
            // 
            resources.ApplyResources(radioButtonAngleThreshold, "radioButtonAngleThreshold");
            radioButtonAngleThreshold.Checked = true;
            radioButtonAngleThreshold.Name = "radioButtonAngleThreshold";
            radioButtonAngleThreshold.TabStop = true;
            radioButtonAngleThreshold.UseVisualStyleBackColor = true;
            radioButtonAngleThreshold.CheckedChanged += checkBoxCombineSameDspacingPeaks_CheckedChanged;
            // 
            // numericBoxAngleThreshold
            // 
            numericBoxAngleThreshold.BackColor = Color.Transparent;
            numericBoxAngleThreshold.DecimalPlaces = 3;
            resources.ApplyResources(numericBoxAngleThreshold, "numericBoxAngleThreshold");
            numericBoxAngleThreshold.Maximum = 2D; // 260701Cl 旧numericUpDownAngleThreshold.Maximum(=2)を復元 (NumericBox移行時のコピー漏れ)
            numericBoxAngleThreshold.Minimum = 0D;
            numericBoxAngleThreshold.Name = "numericBoxAngleThreshold";
            numericBoxAngleThreshold.RadianValue = 0.00017453292519943296D;
            numericBoxAngleThreshold.ShowUpDown = true;
            numericBoxAngleThreshold.SmartIncrement = true;
            numericBoxAngleThreshold.Value = 0.01D;
            numericBoxAngleThreshold.ValueBoxWidth = 50;
            numericBoxAngleThreshold.ValueChanged += checkBoxShowPeakUnderProfile_CheckedChanged;
            // 
            // flowLayoutPanel6
            // 
            resources.ApplyResources(flowLayoutPanel6, "flowLayoutPanel6");
            flowLayoutPanel6.Controls.Add(radioButtonEnergyThreshold);
            flowLayoutPanel6.Controls.Add(numericBoxEnergyThreshold);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            // 
            // radioButtonEnergyThreshold
            // 
            resources.ApplyResources(radioButtonEnergyThreshold, "radioButtonEnergyThreshold");
            radioButtonEnergyThreshold.Name = "radioButtonEnergyThreshold";
            radioButtonEnergyThreshold.UseVisualStyleBackColor = true;
            // 
            // numericBoxEnergyThreshold
            // 
            numericBoxEnergyThreshold.BackColor = Color.Transparent;
            numericBoxEnergyThreshold.DecimalPlaces = 1;
            resources.ApplyResources(numericBoxEnergyThreshold, "numericBoxEnergyThreshold");
            numericBoxEnergyThreshold.Maximum = 1000D;
            numericBoxEnergyThreshold.Minimum = 0D; // 260701Cl 旧numericUpDownEnergyThreshold(Minimum未指定=既定値0)を復元 (NumericBox移行時のコピー漏れ)
            numericBoxEnergyThreshold.Name = "numericBoxEnergyThreshold";
            numericBoxEnergyThreshold.RadianValue = 0.087266462599716474D;
            numericBoxEnergyThreshold.ShowUpDown = true;
            numericBoxEnergyThreshold.SmartIncrement = true;
            numericBoxEnergyThreshold.Value = 5D;
            numericBoxEnergyThreshold.ValueBoxWidth = 50;
            numericBoxEnergyThreshold.ValueChanged += checkBoxShowPeakUnderProfile_CheckedChanged;
            // 
            // checkBoxShowPeakIndices
            // 
            resources.ApplyResources(checkBoxShowPeakIndices, "checkBoxShowPeakIndices");
            checkBoxShowPeakIndices.Checked = true;
            checkBoxShowPeakIndices.CheckState = CheckState.Checked;
            checkBoxShowPeakIndices.Name = "checkBoxShowPeakIndices";
            checkBoxShowPeakIndices.UseVisualStyleBackColor = true;
            checkBoxShowPeakIndices.CheckedChanged += checkBoxCombineSameDspacingPeaks_CheckedChanged;
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Controls.Add(radioButtonAllCheckedCrystals);
            flowLayoutPanel2.Controls.Add(radioButtonOnlySelectedCrystal);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // radioButtonAllCheckedCrystals
            // 
            resources.ApplyResources(radioButtonAllCheckedCrystals, "radioButtonAllCheckedCrystals");
            radioButtonAllCheckedCrystals.Checked = true;
            radioButtonAllCheckedCrystals.Name = "radioButtonAllCheckedCrystals";
            radioButtonAllCheckedCrystals.TabStop = true;
            radioButtonAllCheckedCrystals.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlySelectedCrystal
            // 
            resources.ApplyResources(radioButtonOnlySelectedCrystal, "radioButtonOnlySelectedCrystal");
            radioButtonOnlySelectedCrystal.Name = "radioButtonOnlySelectedCrystal";
            radioButtonOnlySelectedCrystal.UseVisualStyleBackColor = true;
            radioButtonOnlySelectedCrystal.CheckedChanged += radioButtonOnlySelectedCrystal_CheckedChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(crystalDatabaseControl);
            groupBox4.Controls.Add(panel1);
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            // 
            // crystalDatabaseControl
            // 
            crystalDatabaseControl.DatabaseSelection = true;
            resources.ApplyResources(crystalDatabaseControl, "crystalDatabaseControl");
            crystalDatabaseControl.Name = "crystalDatabaseControl";
            crystalDatabaseControl.ProgressChanged += crystalDatabaseControl_ProgressChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(searchCrystalControl);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // searchCrystalControl
            // 
            resources.ApplyResources(searchCrystalControl, "searchCrystalControl");
            searchCrystalControl.Name = "searchCrystalControl";
            searchCrystalControl.ProgressChanged += searchCrystalControl_ProgressChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { incrementToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.ShowImageMargin = false;
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            // 
            // incrementToolStripMenuItem
            // 
            incrementToolStripMenuItem.Name = "incrementToolStripMenuItem";
            resources.ApplyResources(incrementToolStripMenuItem, "incrementToolStripMenuItem");
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            resources.ApplyResources(checkDataGridViewCheckBoxColumn, "checkDataGridViewCheckBoxColumn");
            checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            checkDataGridViewCheckBoxColumn.Resizable = DataGridViewTriState.False;
            // 
            // crystalDataGridViewTextBoxColumn
            // 
            crystalDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            crystalDataGridViewTextBoxColumn.DataPropertyName = "Crystal";
            resources.ApplyResources(crystalDataGridViewTextBoxColumn, "crystalDataGridViewTextBoxColumn");
            crystalDataGridViewTextBoxColumn.Name = "crystalDataGridViewTextBoxColumn";
            crystalDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.False;
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 10000; // 260701Cl 追加: 長文ツールチップ表示のため他フォームと統一 (260531Ch決定)
            toolTip.IsBalloon = true;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewImageColumn1.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn1, "dataGridViewImageColumn1");
            dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            dataGridViewImageColumn1.ReadOnly = true;
            dataGridViewImageColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn1.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewImageColumn2.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn2, "dataGridViewImageColumn2");
            dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            dataGridViewImageColumn2.ReadOnly = true;
            dataGridViewImageColumn2.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn2.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn3
            // 
            dataGridViewImageColumn3.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn3, "dataGridViewImageColumn3");
            dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            dataGridViewImageColumn3.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Resizable = DataGridViewTriState.False;
            // 
            // statusStrip1
            // 
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1, toolStripStatusLabel1 });
            statusStrip1.Name = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // FormCrystal
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FormCrystal";
            Closed += FormCrystal_Closed;
            FormClosing += FormCrystal_FormClosing;
            Load += FormCrystal_Load;
            VisibleChanged += FormCrystal_VisibleChanged;
            KeyDown += FormCrystal_KeyDown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((ISupportInitialize)dataGridViewCrystal).EndInit();
            ((ISupportInitialize)bindingSource).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            groupBox4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.ComponentModel.IContainer components = null;
         private System.Windows.Forms.ToolTip toolTip;

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        public CheckBox checkBoxShowPeakUnderProfile;
        public CheckBox checkBoxCalculateIntensity;
        public CheckBox checkBoxShowPeakIndices;
        public RadioButton radioButtonOnlySelectedCrystal;
        public RadioButton radioButtonAllCheckedCrystals;
        public RadioButton radioButtonEnergyThreshold;
        public RadioButton radioButtonAngleThreshold; public CheckBox checkBoxShowPeakOverProfiles;
        public CheckBox checkBoxVariableRatioOfIntensity;
        public CheckBox checkBoxCombineSameDspacingPeaks;
        public CheckBox checkBoxInvisibleWeakPeak;
        private Button buttonUpper;
        private Button buttonLower;
        public Button buttonAllClear;
        public Button buttonDelete;
        public Button buttonChange;
        internal CrystalControl crystalControl; // 260414Cl public→internal
        public DataSet dataSet;
        public BindingSource bindingSource;
        public DataGridView dataGridViewCrystal;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem incrementToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel3;
        public Button buttonAdd;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn crystalDataGridViewTextBoxColumn;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private CrystalDatabaseControl crystalDatabaseControl;
        private SearchCrystalControl searchCrystalControl;
        private GroupBox groupBox4;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private Panel panel2;
        private Panel panel3;
        private DataGridViewImageColumn dataGridViewImageColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn1;
        private DataGridViewImageColumn PeakColor;
        private DataGridViewTextBoxColumn Crystal;
        private FlowLayoutPanel flowLayoutPanel4;
        public NumericBox numericBoxHeightOfBottomPeak;
        public NumericBox numericBoxThresholdIntesity;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel5;
        public NumericBox numericBoxAngleThreshold;
        public NumericBox numericBoxEnergyThreshold;
        private FlowLayoutPanel flowLayoutPanel6;
    }


}