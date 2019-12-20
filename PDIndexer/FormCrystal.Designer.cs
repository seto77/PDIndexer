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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCrystal = new System.Windows.Forms.DataGridView();
            this.checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.crystalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new PDIndexer.DataSet();
            this.buttonUpper = new System.Windows.Forms.Button();
            this.buttonLower = new System.Windows.Forms.Button();
            this.buttonAllClear = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.crystalControl = new Crystallography.Controls.CrystalControl();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxVariableRatioOfIntensity = new System.Windows.Forms.CheckBox();
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
            this.checkBoxCalculateIntensity = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxShowPeakUnderProfile = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleThreshold)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnergyThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdIntesity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeightOfBottomPeak)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonAdd);
            this.splitContainer1.Panel2.Controls.Add(this.buttonChange);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.dataGridViewCrystal);
            this.groupBox1.Controls.Add(this.buttonUpper);
            this.groupBox1.Controls.Add(this.buttonLower);
            this.groupBox1.Controls.Add(this.buttonAllClear);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewCrystal
            // 
            this.dataGridViewCrystal.AllowUserToAddRows = false;
            this.dataGridViewCrystal.AllowUserToDeleteRows = false;
            this.dataGridViewCrystal.AllowUserToResizeColumns = false;
            this.dataGridViewCrystal.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dataGridViewCrystal, "dataGridViewCrystal");
            this.dataGridViewCrystal.AutoGenerateColumns = false;
            this.dataGridViewCrystal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCrystal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewCrystal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCrystal.ColumnHeadersVisible = false;
            this.dataGridViewCrystal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkDataGridViewCheckBoxColumn,
            this.Column1,
            this.crystalDataGridViewTextBoxColumn});
            this.dataGridViewCrystal.DataSource = this.bindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
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
            // Column1
            // 
            this.Column1.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // buttonAllClear
            // 
            resources.ApplyResources(this.buttonAllClear, "buttonAllClear");
            this.buttonAllClear.BackColor = System.Drawing.Color.DarkRed;
            this.buttonAllClear.ForeColor = System.Drawing.Color.White;
            this.buttonAllClear.Name = "buttonAllClear";
            this.buttonAllClear.UseVisualStyleBackColor = false;
            this.buttonAllClear.Click += new System.EventHandler(this.buttonAllClear_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.BackColor = System.Drawing.Color.IndianRed;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.buttonDeleteCrystal_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAddCrystal_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.buttonChange, "buttonChange");
            this.buttonChange.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChangeCrystal_Click);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.crystalControl);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // crystalControl
            // 
            this.crystalControl.AllowDrop = true;
            resources.ApplyResources(this.crystalControl, "crystalControl");
            this.crystalControl.Crystal = null;
            this.crystalControl.DefaultTabNumber = 0;
            this.crystalControl.Name = "crystalControl";
            this.crystalControl.ScatteringFactorVisible = false;
            this.crystalControl.SymmetryInformationVisible = false;
            this.crystalControl.VisibleAtomAdvancedTab = false;
            this.crystalControl.VisibleAtomTab = true;
            this.crystalControl.VisibleBasicInfoTab = true;
            this.crystalControl.VisibleBondsPolyhedraTab = false;
            this.crystalControl.VisibleElasticityTab = false;
            this.crystalControl.VisibleEOSTab = true;
            this.crystalControl.VisiblePolycrystallineTab = false;
            this.crystalControl.VisibleReferenceTab = true;
            this.crystalControl.VisibleStressStrainTab = false;
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // checkBoxVariableRatioOfIntensity
            // 
            resources.ApplyResources(this.checkBoxVariableRatioOfIntensity, "checkBoxVariableRatioOfIntensity");
            this.checkBoxVariableRatioOfIntensity.Name = "checkBoxVariableRatioOfIntensity";
            this.toolTip.SetToolTip(this.checkBoxVariableRatioOfIntensity, resources.GetString("checkBoxVariableRatioOfIntensity.ToolTip"));
            this.checkBoxVariableRatioOfIntensity.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
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
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButtonAngleThreshold);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownAngleThreshold);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonEnergyThreshold);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownEnergyThreshold);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioButtonAngleThreshold
            // 
            resources.ApplyResources(this.radioButtonAngleThreshold, "radioButtonAngleThreshold");
            this.radioButtonAngleThreshold.Checked = true;
            this.radioButtonAngleThreshold.Name = "radioButtonAngleThreshold";
            this.radioButtonAngleThreshold.TabStop = true;
            this.radioButtonAngleThreshold.UseVisualStyleBackColor = true;
            // 
            // numericUpDownAngleThreshold
            // 
            this.numericUpDownAngleThreshold.ContextMenuStrip = this.contextMenuStrip1;
            this.numericUpDownAngleThreshold.DecimalPlaces = 3;
            resources.ApplyResources(this.numericUpDownAngleThreshold, "numericUpDownAngleThreshold");
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
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incrementToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // incrementToolStripMenuItem
            // 
            this.incrementToolStripMenuItem.Name = "incrementToolStripMenuItem";
            resources.ApplyResources(this.incrementToolStripMenuItem, "incrementToolStripMenuItem");
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // radioButtonEnergyThreshold
            // 
            resources.ApplyResources(this.radioButtonEnergyThreshold, "radioButtonEnergyThreshold");
            this.radioButtonEnergyThreshold.Name = "radioButtonEnergyThreshold";
            this.radioButtonEnergyThreshold.UseVisualStyleBackColor = true;
            // 
            // numericUpDownEnergyThreshold
            // 
            this.numericUpDownEnergyThreshold.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownEnergyThreshold, "numericUpDownEnergyThreshold");
            this.numericUpDownEnergyThreshold.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEnergyThreshold.Name = "numericUpDownEnergyThreshold";
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
            // 
            // checkBoxCombineSameDspacingPeaks
            // 
            resources.ApplyResources(this.checkBoxCombineSameDspacingPeaks, "checkBoxCombineSameDspacingPeaks");
            this.checkBoxCombineSameDspacingPeaks.Checked = true;
            this.checkBoxCombineSameDspacingPeaks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCombineSameDspacingPeaks.Name = "checkBoxCombineSameDspacingPeaks";
            this.checkBoxCombineSameDspacingPeaks.UseVisualStyleBackColor = true;
            this.checkBoxCombineSameDspacingPeaks.CheckedChanged += new System.EventHandler(this.checkBoxCombineSameDspacingPeaks_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // radioButtonAllCheckedCrystals
            // 
            resources.ApplyResources(this.radioButtonAllCheckedCrystals, "radioButtonAllCheckedCrystals");
            this.radioButtonAllCheckedCrystals.Checked = true;
            this.radioButtonAllCheckedCrystals.Name = "radioButtonAllCheckedCrystals";
            this.radioButtonAllCheckedCrystals.TabStop = true;
            this.radioButtonAllCheckedCrystals.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnlySelectedCrystal
            // 
            resources.ApplyResources(this.radioButtonOnlySelectedCrystal, "radioButtonOnlySelectedCrystal");
            this.radioButtonOnlySelectedCrystal.Name = "radioButtonOnlySelectedCrystal";
            this.radioButtonOnlySelectedCrystal.UseVisualStyleBackColor = true;
            this.radioButtonOnlySelectedCrystal.CheckedChanged += new System.EventHandler(this.radioButtonOnlySelectedCrystal_CheckedChanged);
            // 
            // numericUpDownThresholdIntesity
            // 
            this.numericUpDownThresholdIntesity.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownThresholdIntesity, "numericUpDownThresholdIntesity");
            this.numericUpDownThresholdIntesity.Name = "numericUpDownThresholdIntesity";
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
            this.checkBoxShowPeakOverProfiles.UseVisualStyleBackColor = true;
            this.checkBoxShowPeakOverProfiles.CheckedChanged += new System.EventHandler(this.checkBoxShowPeakOverProfiles_CheckedChanged);
            // 
            // checkBoxShowPeakIndices
            // 
            this.checkBoxShowPeakIndices.Checked = true;
            this.checkBoxShowPeakIndices.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.checkBoxShowPeakIndices, "checkBoxShowPeakIndices");
            this.checkBoxShowPeakIndices.Name = "checkBoxShowPeakIndices";
            this.checkBoxShowPeakIndices.UseVisualStyleBackColor = true;
            this.checkBoxShowPeakIndices.CheckedChanged += new System.EventHandler(this.checkBoxCombineSameDspacingPeaks_CheckedChanged);
            // 
            // checkBoxInvisibleWeakPeak
            // 
            resources.ApplyResources(this.checkBoxInvisibleWeakPeak, "checkBoxInvisibleWeakPeak");
            this.checkBoxInvisibleWeakPeak.Name = "checkBoxInvisibleWeakPeak";
            this.checkBoxInvisibleWeakPeak.UseVisualStyleBackColor = true;
            this.checkBoxInvisibleWeakPeak.CheckedChanged += new System.EventHandler(this.checkBoxInvisibleWeakPeak_CheckedChanged);
            // 
            // checkBoxCalculateIntensity
            // 
            resources.ApplyResources(this.checkBoxCalculateIntensity, "checkBoxCalculateIntensity");
            this.checkBoxCalculateIntensity.Checked = true;
            this.checkBoxCalculateIntensity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCalculateIntensity.Name = "checkBoxCalculateIntensity";
            this.checkBoxCalculateIntensity.UseVisualStyleBackColor = true;
            this.checkBoxCalculateIntensity.CheckedChanged += new System.EventHandler(this.checkBoxCalculateIntensity_CheckedChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // checkBoxShowPeakUnderProfile
            // 
            resources.ApplyResources(this.checkBoxShowPeakUnderProfile, "checkBoxShowPeakUnderProfile");
            this.checkBoxShowPeakUnderProfile.Name = "checkBoxShowPeakUnderProfile";
            this.checkBoxShowPeakUnderProfile.UseVisualStyleBackColor = true;
            this.checkBoxShowPeakUnderProfile.CheckedChanged += new System.EventHandler(this.checkBoxShowPeakUnderProfile_CheckedChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn16, "dataGridViewTextBoxColumn16");
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn17, "dataGridViewTextBoxColumn17");
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn18, "dataGridViewTextBoxColumn18");
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn19, "dataGridViewTextBoxColumn19");
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn20, "dataGridViewTextBoxColumn20");
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn21, "dataGridViewTextBoxColumn21");
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn22, "dataGridViewTextBoxColumn22");
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn23, "dataGridViewTextBoxColumn23");
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn24, "dataGridViewTextBoxColumn24");
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "ColumnCrystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn25, "dataGridViewTextBoxColumn25");
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn26, "dataGridViewTextBoxColumn26");
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn27, "dataGridViewTextBoxColumn27");
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn28.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn28, "dataGridViewTextBoxColumn28");
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn29.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn29, "dataGridViewTextBoxColumn29");
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn30.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn30, "dataGridViewTextBoxColumn30");
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn31.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn31, "dataGridViewTextBoxColumn31");
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn32.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn32, "dataGridViewTextBoxColumn32");
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn33, "dataGridViewTextBoxColumn33");
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn34.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn34, "dataGridViewTextBoxColumn34");
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn35.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn35, "dataGridViewTextBoxColumn35");
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn36.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn36, "dataGridViewTextBoxColumn36");
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn37.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn37, "dataGridViewTextBoxColumn37");
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn38.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn38, "dataGridViewTextBoxColumn38");
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn39.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn39, "dataGridViewTextBoxColumn39");
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn40.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn40, "dataGridViewTextBoxColumn40");
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn41.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn41, "dataGridViewTextBoxColumn41");
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn42.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn42, "dataGridViewTextBoxColumn42");
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn2, "dataGridViewImageColumn2");
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn43.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn43, "dataGridViewTextBoxColumn43");
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn3, "dataGridViewImageColumn3");
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn44.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn44, "dataGridViewTextBoxColumn44");
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            this.dataGridViewTextBoxColumn44.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn4, "dataGridViewImageColumn4");
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn45.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn45, "dataGridViewTextBoxColumn45");
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn5
            // 
            this.dataGridViewImageColumn5.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn5, "dataGridViewImageColumn5");
            this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
            this.dataGridViewImageColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn46.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn46, "dataGridViewTextBoxColumn46");
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn6
            // 
            this.dataGridViewImageColumn6.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn6, "dataGridViewImageColumn6");
            this.dataGridViewImageColumn6.Name = "dataGridViewImageColumn6";
            this.dataGridViewImageColumn6.ReadOnly = true;
            this.dataGridViewImageColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn47.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn47, "dataGridViewTextBoxColumn47");
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.ReadOnly = true;
            this.dataGridViewTextBoxColumn47.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn7
            // 
            this.dataGridViewImageColumn7.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn7, "dataGridViewImageColumn7");
            this.dataGridViewImageColumn7.Name = "dataGridViewImageColumn7";
            this.dataGridViewImageColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn48.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn48, "dataGridViewTextBoxColumn48");
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn8
            // 
            this.dataGridViewImageColumn8.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn8, "dataGridViewImageColumn8");
            this.dataGridViewImageColumn8.Name = "dataGridViewImageColumn8";
            this.dataGridViewImageColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn49.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn49, "dataGridViewTextBoxColumn49");
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FormCrystal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormCrystal";
            this.Closed += new System.EventHandler(this.FormCrystal_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCrystal_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormCrystal_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormCrystal_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngleThreshold)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnergyThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdIntesity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeightOfBottomPeak)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components = null;
        public Button buttonChange;
        private System.Windows.Forms.ToolTip toolTip;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private GroupBox groupBox1;
        public Button button4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private GroupBox groupBox2;
        public CheckBox checkBoxShowPeakUnderProfile;
        public CheckBox checkBoxCalculateIntensity;
        public NumericUpDown numericUpDownHeightOfBottomPeak;
        public RadioButton radioButtonOnlySelectedCrystal;
        public RadioButton radioButtonAllCheckedCrystals;
        public Label label3;
        public CheckBox checkBoxShowPeakOverProfiles;
        public CheckBox checkBoxVariableRatioOfIntensity;
        public CheckBox checkBoxCombineSameDspacingPeaks;
        public Label label5;
        public NumericUpDown numericUpDownAngleThreshold;
        public CheckBox checkBoxInvisibleWeakPeak;
        public Label label6;
        public NumericUpDown numericUpDownThresholdIntesity;
        private Button buttonUpper;
        private Button buttonLower;
        public CrystalControl crystalControl;
        public Button buttonAdd;
        private SplitContainer splitContainer1;
        private GroupBox groupBox3;
        public Button buttonAllClear;
        public CheckBox checkBoxShowPeakIndices;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        public DataSet dataSet;
        public BindingSource bindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        public DataGridView dataGridViewCrystal;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem incrementToolStripMenuItem;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        public RadioButton radioButtonEnergyThreshold;
        public RadioButton radioButtonAngleThreshold;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        public NumericUpDown numericUpDownEnergyThreshold;
        public Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewImageColumn Column1;
        private DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn crystalDataGridViewTextBoxColumn;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private DataGridViewImageColumn dataGridViewImageColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private DataGridViewImageColumn dataGridViewImageColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private DataGridViewImageColumn dataGridViewImageColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private DataGridViewImageColumn dataGridViewImageColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private DataGridViewImageColumn dataGridViewImageColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private DataGridViewImageColumn dataGridViewImageColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
   
    }


}