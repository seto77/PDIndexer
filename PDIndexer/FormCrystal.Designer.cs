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
    public partial class FormCrystal : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCrystal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.crystalControl = new Crystallography.Controls.CrystalControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCrystal = new System.Windows.Forms.DataGridView();
            this.checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PeakColor = new System.Windows.Forms.DataGridViewImageColumn();
            this.crystalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new PDIndexer.DataSet();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonUpper = new System.Windows.Forms.Button();
            this.buttonLower = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAllClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonAngleThreshold = new System.Windows.Forms.RadioButton();
            this.numericUpDownAngleThreshold = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.incrementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonEnergyThreshold = new System.Windows.Forms.RadioButton();
            this.numericUpDownEnergyThreshold = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxCombineSameDspacingPeaks = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonAllCheckedCrystals = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlySelectedCrystal = new System.Windows.Forms.RadioButton();
            this.numericUpDownThresholdIntesity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeightOfBottomPeak = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShowPeakOverProfiles = new System.Windows.Forms.CheckBox();
            this.checkBoxShowPeakIndices = new System.Windows.Forms.CheckBox();
            this.checkBoxInvisibleWeakPeak = new System.Windows.Forms.CheckBox();
            this.checkBoxVariableRatioOfIntensity = new System.Windows.Forms.CheckBox();
            this.checkBoxCalculateIntensity = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxShowPeakUnderProfile = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.crystalDatabaseControl = new Crystallography.Controls.CrystalDatabaseControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchCrystalControl = new Crystallography.Controls.SearchCrystalControl();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleThreshold)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnergyThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdIntesity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeightOfBottomPeak)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.toolTip.SetToolTip(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.toolTip.SetToolTip(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            this.toolTip.SetToolTip(this.splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.crystalControl);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // crystalControl
            // 
            resources.ApplyResources(this.crystalControl, "crystalControl");
            this.crystalControl.AllowDrop = true;
            this.crystalControl.CellConstants = ((System.ValueTuple<double, double, double, double, double, double>)(resources.GetObject("crystalControl.CellConstants")));
            this.crystalControl.Crystal = ((Crystallography.Crystal)(resources.GetObject("crystalControl.Crystal")));
            this.crystalControl.DefaultTabNumber = 0;
            this.crystalControl.Name = "crystalControl";
            this.crystalControl.ScatteringFactorVisible = false;
            this.crystalControl.SkipEvent = false;
            this.crystalControl.SymmetryInformationVisible = false;
            this.crystalControl.SymmetrySeriesNumber = 0;
            this.toolTip.SetToolTip(this.crystalControl, resources.GetString("crystalControl.ToolTip"));
            this.crystalControl.VisibleAtomTab = true;
            this.crystalControl.VisibleBasicInfoTab = true;
            this.crystalControl.VisibleBondsPolyhedraTab = false;
            this.crystalControl.VisibleBoundTab = false;
            this.crystalControl.VisibleElasticityTab = false;
            this.crystalControl.VisibleEOSTab = true;
            this.crystalControl.VisibleLatticePlaneTab = false;
            this.crystalControl.VisiblePolycrystallineTab = false;
            this.crystalControl.VisibleReferenceTab = true;
            this.crystalControl.VisibleStressStrainTab = false;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.buttonAdd);
            this.panel2.Controls.Add(this.buttonChange);
            this.panel2.Name = "panel2";
            this.toolTip.SetToolTip(this.panel2, resources.GetString("panel2.ToolTip"));
            // 
            // buttonAdd
            // 
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAdd.Name = "buttonAdd";
            this.toolTip.SetToolTip(this.buttonAdd, resources.GetString("buttonAdd.ToolTip"));
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddCrystal_Click);
            // 
            // buttonChange
            // 
            resources.ApplyResources(this.buttonChange, "buttonChange");
            this.buttonChange.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonChange.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonChange.Name = "buttonChange";
            this.toolTip.SetToolTip(this.buttonChange, resources.GetString("buttonChange.ToolTip"));
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChangeCrystal_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.dataGridViewCrystal);
            this.groupBox1.Controls.Add(this.flowLayoutPanel3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // dataGridViewCrystal
            // 
            resources.ApplyResources(this.dataGridViewCrystal, "dataGridViewCrystal");
            this.dataGridViewCrystal.AllowUserToAddRows = false;
            this.dataGridViewCrystal.AllowUserToDeleteRows = false;
            this.dataGridViewCrystal.AllowUserToResizeColumns = false;
            this.dataGridViewCrystal.AllowUserToResizeRows = false;
            this.dataGridViewCrystal.AutoGenerateColumns = false;
            this.dataGridViewCrystal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCrystal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewCrystal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCrystal.ColumnHeadersVisible = false;
            this.dataGridViewCrystal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkDataGridViewCheckBoxColumn,
            this.PeakColor,
            this.crystalDataGridViewTextBoxColumn});
            this.dataGridViewCrystal.DataSource = this.bindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCrystal.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCrystal.EnableHeadersVisualStyles = false;
            this.dataGridViewCrystal.MultiSelect = false;
            this.dataGridViewCrystal.Name = "dataGridViewCrystal";
            this.dataGridViewCrystal.ReadOnly = true;
            this.dataGridViewCrystal.RowHeadersVisible = false;
            this.dataGridViewCrystal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewCrystal.RowTemplate.Height = 21;
            this.dataGridViewCrystal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolTip.SetToolTip(this.dataGridViewCrystal, resources.GetString("dataGridViewCrystal.ToolTip"));
            this.dataGridViewCrystal.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCrystal_CellMouseClick);
            this.dataGridViewCrystal.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCrystal_CellMouseClick);
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            this.checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            resources.ApplyResources(this.checkDataGridViewCheckBoxColumn, "checkDataGridViewCheckBoxColumn");
            this.checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            this.checkDataGridViewCheckBoxColumn.ReadOnly = true;
            this.checkDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.crystalDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // bindingSource
            // 
            this.bindingSource.AllowNew = true;
            this.bindingSource.DataMember = "DataTableCrystal";
            this.bindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet1";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Controls.Add(this.buttonUpper);
            this.flowLayoutPanel3.Controls.Add(this.buttonLower);
            this.flowLayoutPanel3.Controls.Add(this.buttonDelete);
            this.flowLayoutPanel3.Controls.Add(this.buttonAllClear);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.toolTip.SetToolTip(this.flowLayoutPanel3, resources.GetString("flowLayoutPanel3.ToolTip"));
            // 
            // buttonUpper
            // 
            resources.ApplyResources(this.buttonUpper, "buttonUpper");
            this.buttonUpper.Name = "buttonUpper";
            this.toolTip.SetToolTip(this.buttonUpper, resources.GetString("buttonUpper.ToolTip"));
            this.buttonUpper.Click += new System.EventHandler(this.buttonUpper_Click);
            // 
            // buttonLower
            // 
            resources.ApplyResources(this.buttonLower, "buttonLower");
            this.buttonLower.Name = "buttonLower";
            this.toolTip.SetToolTip(this.buttonLower, resources.GetString("buttonLower.ToolTip"));
            this.buttonLower.Click += new System.EventHandler(this.buttonLower_Click);
            // 
            // buttonDelete
            // 
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.BackColor = System.Drawing.Color.IndianRed;
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Name = "buttonDelete";
            this.toolTip.SetToolTip(this.buttonDelete, resources.GetString("buttonDelete.ToolTip"));
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDeleteCrystal_Click);
            // 
            // buttonAllClear
            // 
            resources.ApplyResources(this.buttonAllClear, "buttonAllClear");
            this.buttonAllClear.BackColor = System.Drawing.Color.DarkRed;
            this.buttonAllClear.ForeColor = System.Drawing.Color.White;
            this.buttonAllClear.Name = "buttonAllClear";
            this.toolTip.SetToolTip(this.buttonAllClear, resources.GetString("buttonAllClear.ToolTip"));
            this.buttonAllClear.UseVisualStyleBackColor = false;
            this.buttonAllClear.Click += new System.EventHandler(this.buttonAllClear_Click);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            this.toolTip.SetToolTip(this.panel3, resources.GetString("panel3.ToolTip"));
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Controls.Add(this.checkBoxCombineSameDspacingPeaks);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.radioButtonAllCheckedCrystals);
            this.groupBox2.Controls.Add(this.radioButtonOnlySelectedCrystal);
            this.groupBox2.Controls.Add(this.numericUpDownThresholdIntesity);
            this.groupBox2.Controls.Add(this.numericUpDownHeightOfBottomPeak);
            this.groupBox2.Controls.Add(this.checkBoxShowPeakOverProfiles);
            this.groupBox2.Controls.Add(this.checkBoxShowPeakIndices);
            this.groupBox2.Controls.Add(this.checkBoxInvisibleWeakPeak);
            this.groupBox2.Controls.Add(this.checkBoxVariableRatioOfIntensity);
            this.groupBox2.Controls.Add(this.checkBoxCalculateIntensity);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.checkBoxShowPeakUnderProfile);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.radioButtonAngleThreshold);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownAngleThreshold);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonEnergyThreshold);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownEnergyThreshold);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.toolTip.SetToolTip(this.flowLayoutPanel1, resources.GetString("flowLayoutPanel1.ToolTip"));
            // 
            // radioButtonAngleThreshold
            // 
            resources.ApplyResources(this.radioButtonAngleThreshold, "radioButtonAngleThreshold");
            this.radioButtonAngleThreshold.Checked = true;
            this.radioButtonAngleThreshold.Name = "radioButtonAngleThreshold";
            this.radioButtonAngleThreshold.TabStop = true;
            this.toolTip.SetToolTip(this.radioButtonAngleThreshold, resources.GetString("radioButtonAngleThreshold.ToolTip"));
            this.radioButtonAngleThreshold.UseVisualStyleBackColor = true;
            // 
            // numericUpDownAngleThreshold
            // 
            resources.ApplyResources(this.numericUpDownAngleThreshold, "numericUpDownAngleThreshold");
            this.numericUpDownAngleThreshold.ContextMenuStrip = this.contextMenuStrip1;
            this.numericUpDownAngleThreshold.DecimalPlaces = 3;
            this.numericUpDownAngleThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownAngleThreshold.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownAngleThreshold.Name = "numericUpDownAngleThreshold";
            this.toolTip.SetToolTip(this.numericUpDownAngleThreshold, resources.GetString("numericUpDownAngleThreshold.ToolTip"));
            this.numericUpDownAngleThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownAngleThreshold.ValueChanged += new System.EventHandler(this.checkBoxShowPeakUnderProfile_CheckedChanged);
            this.numericUpDownAngleThreshold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numericUpDownThreshold_MouseDown);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incrementToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.toolTip.SetToolTip(this.contextMenuStrip1, resources.GetString("contextMenuStrip1.ToolTip"));
            // 
            // incrementToolStripMenuItem
            // 
            resources.ApplyResources(this.incrementToolStripMenuItem, "incrementToolStripMenuItem");
            this.incrementToolStripMenuItem.Name = "incrementToolStripMenuItem";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // radioButtonEnergyThreshold
            // 
            resources.ApplyResources(this.radioButtonEnergyThreshold, "radioButtonEnergyThreshold");
            this.radioButtonEnergyThreshold.Name = "radioButtonEnergyThreshold";
            this.toolTip.SetToolTip(this.radioButtonEnergyThreshold, resources.GetString("radioButtonEnergyThreshold.ToolTip"));
            this.radioButtonEnergyThreshold.UseVisualStyleBackColor = true;
            // 
            // numericUpDownEnergyThreshold
            // 
            resources.ApplyResources(this.numericUpDownEnergyThreshold, "numericUpDownEnergyThreshold");
            this.numericUpDownEnergyThreshold.DecimalPlaces = 1;
            this.numericUpDownEnergyThreshold.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEnergyThreshold.Name = "numericUpDownEnergyThreshold";
            this.toolTip.SetToolTip(this.numericUpDownEnergyThreshold, resources.GetString("numericUpDownEnergyThreshold.ToolTip"));
            this.numericUpDownEnergyThreshold.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownEnergyThreshold.ValueChanged += new System.EventHandler(this.checkBoxShowPeakUnderProfile_CheckedChanged);
            this.numericUpDownEnergyThreshold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numericUpDownThreshold_MouseDown);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // checkBoxCombineSameDspacingPeaks
            // 
            resources.ApplyResources(this.checkBoxCombineSameDspacingPeaks, "checkBoxCombineSameDspacingPeaks");
            this.checkBoxCombineSameDspacingPeaks.Checked = true;
            this.checkBoxCombineSameDspacingPeaks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCombineSameDspacingPeaks.Name = "checkBoxCombineSameDspacingPeaks";
            this.toolTip.SetToolTip(this.checkBoxCombineSameDspacingPeaks, resources.GetString("checkBoxCombineSameDspacingPeaks.ToolTip"));
            this.checkBoxCombineSameDspacingPeaks.UseVisualStyleBackColor = true;
            this.checkBoxCombineSameDspacingPeaks.CheckedChanged += new System.EventHandler(this.checkBoxCombineSameDspacingPeaks_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.toolTip.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // radioButtonAllCheckedCrystals
            // 
            resources.ApplyResources(this.radioButtonAllCheckedCrystals, "radioButtonAllCheckedCrystals");
            this.radioButtonAllCheckedCrystals.Checked = true;
            this.radioButtonAllCheckedCrystals.Name = "radioButtonAllCheckedCrystals";
            this.radioButtonAllCheckedCrystals.TabStop = true;
            this.toolTip.SetToolTip(this.radioButtonAllCheckedCrystals, resources.GetString("radioButtonAllCheckedCrystals.ToolTip"));
            this.radioButtonAllCheckedCrystals.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlySelectedCrystal
            // 
            resources.ApplyResources(this.radioButtonOnlySelectedCrystal, "radioButtonOnlySelectedCrystal");
            this.radioButtonOnlySelectedCrystal.Name = "radioButtonOnlySelectedCrystal";
            this.toolTip.SetToolTip(this.radioButtonOnlySelectedCrystal, resources.GetString("radioButtonOnlySelectedCrystal.ToolTip"));
            this.radioButtonOnlySelectedCrystal.UseVisualStyleBackColor = true;
            this.radioButtonOnlySelectedCrystal.CheckedChanged += new System.EventHandler(this.radioButtonOnlySelectedCrystal_CheckedChanged);
            // 
            // numericUpDownThresholdIntesity
            // 
            resources.ApplyResources(this.numericUpDownThresholdIntesity, "numericUpDownThresholdIntesity");
            this.numericUpDownThresholdIntesity.DecimalPlaces = 1;
            this.numericUpDownThresholdIntesity.Name = "numericUpDownThresholdIntesity";
            this.toolTip.SetToolTip(this.numericUpDownThresholdIntesity, resources.GetString("numericUpDownThresholdIntesity.ToolTip"));
            this.numericUpDownThresholdIntesity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThresholdIntesity.ValueChanged += new System.EventHandler(this.checkBoxShowPeakUnderProfile_CheckedChanged);
            this.numericUpDownThresholdIntesity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numericUpDownThreshold_MouseDown);
            // 
            // numericUpDownHeightOfBottomPeak
            // 
            resources.ApplyResources(this.numericUpDownHeightOfBottomPeak, "numericUpDownHeightOfBottomPeak");
            this.numericUpDownHeightOfBottomPeak.Name = "numericUpDownHeightOfBottomPeak";
            this.toolTip.SetToolTip(this.numericUpDownHeightOfBottomPeak, resources.GetString("numericUpDownHeightOfBottomPeak.ToolTip"));
            this.numericUpDownHeightOfBottomPeak.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownHeightOfBottomPeak.ValueChanged += new System.EventHandler(this.checkBoxShowPeakUnderProfile_CheckedChanged);
            this.numericUpDownHeightOfBottomPeak.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numericUpDownThreshold_MouseDown);
            // 
            // checkBoxShowPeakOverProfiles
            // 
            resources.ApplyResources(this.checkBoxShowPeakOverProfiles, "checkBoxShowPeakOverProfiles");
            this.checkBoxShowPeakOverProfiles.Checked = true;
            this.checkBoxShowPeakOverProfiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowPeakOverProfiles.Name = "checkBoxShowPeakOverProfiles";
            this.toolTip.SetToolTip(this.checkBoxShowPeakOverProfiles, resources.GetString("checkBoxShowPeakOverProfiles.ToolTip"));
            this.checkBoxShowPeakOverProfiles.UseVisualStyleBackColor = true;
            this.checkBoxShowPeakOverProfiles.CheckedChanged += new System.EventHandler(this.checkBoxShowPeakOverProfiles_CheckedChanged);
            // 
            // checkBoxShowPeakIndices
            // 
            resources.ApplyResources(this.checkBoxShowPeakIndices, "checkBoxShowPeakIndices");
            this.checkBoxShowPeakIndices.Checked = true;
            this.checkBoxShowPeakIndices.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowPeakIndices.Name = "checkBoxShowPeakIndices";
            this.toolTip.SetToolTip(this.checkBoxShowPeakIndices, resources.GetString("checkBoxShowPeakIndices.ToolTip"));
            this.checkBoxShowPeakIndices.UseVisualStyleBackColor = true;
            this.checkBoxShowPeakIndices.CheckedChanged += new System.EventHandler(this.checkBoxCombineSameDspacingPeaks_CheckedChanged);
            // 
            // checkBoxInvisibleWeakPeak
            // 
            resources.ApplyResources(this.checkBoxInvisibleWeakPeak, "checkBoxInvisibleWeakPeak");
            this.checkBoxInvisibleWeakPeak.Name = "checkBoxInvisibleWeakPeak";
            this.toolTip.SetToolTip(this.checkBoxInvisibleWeakPeak, resources.GetString("checkBoxInvisibleWeakPeak.ToolTip"));
            this.checkBoxInvisibleWeakPeak.UseVisualStyleBackColor = true;
            this.checkBoxInvisibleWeakPeak.CheckedChanged += new System.EventHandler(this.checkBoxInvisibleWeakPeak_CheckedChanged);
            // 
            // checkBoxVariableRatioOfIntensity
            // 
            resources.ApplyResources(this.checkBoxVariableRatioOfIntensity, "checkBoxVariableRatioOfIntensity");
            this.checkBoxVariableRatioOfIntensity.Name = "checkBoxVariableRatioOfIntensity";
            this.toolTip.SetToolTip(this.checkBoxVariableRatioOfIntensity, resources.GetString("checkBoxVariableRatioOfIntensity.ToolTip"));
            this.checkBoxVariableRatioOfIntensity.UseVisualStyleBackColor = true;
            // 
            // checkBoxCalculateIntensity
            // 
            resources.ApplyResources(this.checkBoxCalculateIntensity, "checkBoxCalculateIntensity");
            this.checkBoxCalculateIntensity.Checked = true;
            this.checkBoxCalculateIntensity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCalculateIntensity.Name = "checkBoxCalculateIntensity";
            this.toolTip.SetToolTip(this.checkBoxCalculateIntensity, resources.GetString("checkBoxCalculateIntensity.ToolTip"));
            this.checkBoxCalculateIntensity.UseVisualStyleBackColor = true;
            this.checkBoxCalculateIntensity.CheckedChanged += new System.EventHandler(this.checkBoxCalculateIntensity_CheckedChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            this.toolTip.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // checkBoxShowPeakUnderProfile
            // 
            resources.ApplyResources(this.checkBoxShowPeakUnderProfile, "checkBoxShowPeakUnderProfile");
            this.checkBoxShowPeakUnderProfile.Name = "checkBoxShowPeakUnderProfile";
            this.toolTip.SetToolTip(this.checkBoxShowPeakUnderProfile, resources.GetString("checkBoxShowPeakUnderProfile.ToolTip"));
            this.checkBoxShowPeakUnderProfile.UseVisualStyleBackColor = true;
            this.checkBoxShowPeakUnderProfile.CheckedChanged += new System.EventHandler(this.checkBoxShowPeakUnderProfile_CheckedChanged);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.crystalDatabaseControl);
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // crystalDatabaseControl
            // 
            resources.ApplyResources(this.crystalDatabaseControl, "crystalDatabaseControl");
            this.crystalDatabaseControl.Filter = null;
            this.crystalDatabaseControl.FontSize = 9.75F;
            this.crystalDatabaseControl.Name = "crystalDatabaseControl";
            this.toolTip.SetToolTip(this.crystalDatabaseControl, resources.GetString("crystalDatabaseControl.ToolTip"));
            this.crystalDatabaseControl.CrystalChanged += new System.EventHandler(this.crystalDatabaseControl_CrystalChanged);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.searchCrystalControl);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Name = "panel1";
            this.toolTip.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // searchCrystalControl
            // 
            resources.ApplyResources(this.searchCrystalControl, "searchCrystalControl");
            this.searchCrystalControl.Name = "searchCrystalControl";
            this.toolTip.SetToolTip(this.searchCrystalControl, resources.GetString("searchCrystalControl.ToolTip"));
            // 
            // buttonSearch
            // 
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.BackColor = System.Drawing.Color.Chocolate;
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Name = "buttonSearch";
            this.toolTip.SetToolTip(this.buttonSearch, resources.GetString("buttonSearch.ToolTip"));
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn2, "dataGridViewImageColumn2");
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FormCrystal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormCrystal";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Closed += new System.EventHandler(this.FormCrystal_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCrystal_FormClosing);
            this.Load += new System.EventHandler(this.FormCrystal_Load);
            this.VisibleChanged += new System.EventHandler(this.FormCrystal_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCrystal_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleThreshold)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnergyThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdIntesity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeightOfBottomPeak)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        public NumericUpDown numericUpDownHeightOfBottomPeak;
        public NumericUpDown numericUpDownAngleThreshold;
        public NumericUpDown numericUpDownEnergyThreshold;
        public NumericUpDown numericUpDownThresholdIntesity;
        public RadioButton radioButtonOnlySelectedCrystal;
        public RadioButton radioButtonAllCheckedCrystals;
        public RadioButton radioButtonEnergyThreshold;
        public RadioButton radioButtonAngleThreshold; public CheckBox checkBoxShowPeakOverProfiles;
        public CheckBox checkBoxVariableRatioOfIntensity;
        public CheckBox checkBoxCombineSameDspacingPeaks;
        public CheckBox checkBoxInvisibleWeakPeak;
        public Label label1;
        public Label label3;
        public Label label5;
        public Label label6;
        private Button buttonUpper;
        private Button buttonLower;
        public Button buttonAllClear;
        public Button buttonDelete;
        public Button buttonChange;
        public CrystalControl crystalControl;
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
        private DataGridViewImageColumn PeakColor;
        private DataGridViewTextBoxColumn crystalDataGridViewTextBoxColumn;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private CrystalDatabaseControl crystalDatabaseControl;
        private SearchCrystalControl searchCrystalControl;
        private GroupBox groupBox4;
        private Panel panel1;
        private Button buttonSearch;
        private SplitContainer splitContainer1;
        private Panel panel2;
        private Panel panel3;
    }


}