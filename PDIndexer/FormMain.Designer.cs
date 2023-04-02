using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing.Drawing2D;
using Crystallography;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Reflection;

namespace PDIndexer
{
    /// <summary>
    /// PDIndexer の概要の説明です。
    /// </summary>
    /// 
    partial class FormMain : System.Windows.Forms.Form
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
            BmpMain.Dispose();
            base.Dispose(disposing);
        }
        private IContainer components = null;

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = (new global::System.ComponentModel.Container());
            global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::PDIndexer.FormMain));
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle66 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle73 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle74 = new global::System.Windows.Forms.DataGridViewCellStyle();
            global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle75 = new global::System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripContainer1 = (new global::System.Windows.Forms.ToolStripContainer());
            this.statusStrip1 = (new global::System.Windows.Forms.StatusStrip());
            this.toolStripProgressBar = (new global::System.Windows.Forms.ToolStripProgressBar());
            this.toolStripStatusLabelCalcTime = (new global::System.Windows.Forms.ToolStripStatusLabel());
            this.toolStripStatusLabel1 = (new global::System.Windows.Forms.ToolStripStatusLabel());
            this.toolStripStatusLabel2 = (new global::System.Windows.Forms.ToolStripStatusLabel());
            this.splitContainer1 = (new global::System.Windows.Forms.SplitContainer());
            this.tabControl = (new global::System.Windows.Forms.TabControl());
            this.tabPage1 = (new global::System.Windows.Forms.TabPage());
            this.horizontalAxisUserControl = (new global::Crystallography.Controls.HorizontalAxisUserControl());
            this.flowLayoutPanel4 = (new global::System.Windows.Forms.FlowLayoutPanel());
            this.checkBoxChangeHorizontalAppearance = (new global::System.Windows.Forms.CheckBox());
            this.tabPage2 = (new global::System.Windows.Forms.TabPage());
            this.groupBox4 = (new global::System.Windows.Forms.GroupBox());
            this.flowLayoutPanel2 = (new global::System.Windows.Forms.FlowLayoutPanel());
            this.radioButtonLinearity = (new global::System.Windows.Forms.RadioButton());
            this.radioButtonLogarithm = (new global::System.Windows.Forms.RadioButton());
            this.flowLayoutPanel1 = (new global::System.Windows.Forms.FlowLayoutPanel());
            this.radioButtonRawCounts = (new global::System.Windows.Forms.RadioButton());
            this.radioButtonCountsPerStep = (new global::System.Windows.Forms.RadioButton());
            this.groupBox3 = (new global::System.Windows.Forms.GroupBox());
            this.numericalTextBoxIncreasingPixels = (new global::Crystallography.Controls.NumericBox());
            this.numericUpDownIncreasingPixels = (new global::System.Windows.Forms.NumericUpDown());
            this.radioButtonMultiProfileMode = (new global::System.Windows.Forms.RadioButton());
            this.checkBoxChangeColor = (new global::System.Windows.Forms.CheckBox());
            this.radioButtonSingleProfileMode = (new global::System.Windows.Forms.RadioButton());
            this.label6 = (new global::System.Windows.Forms.Label());
            this.label1 = (new global::System.Windows.Forms.Label());
            this.groupBox2 = (new global::System.Windows.Forms.GroupBox());
            this.colorControlScaleText = (new global::Crystallography.Controls.ColorControl());
            this.colorControlScaleLine = (new global::Crystallography.Controls.ColorControl());
            this.colorControlBack = (new global::Crystallography.Controls.ColorControl());
            this.label5 = (new global::System.Windows.Forms.Label());
            this.label2 = (new global::System.Windows.Forms.Label());
            this.label4 = (new global::System.Windows.Forms.Label());
            this.checkBoxErrorBar = (new global::System.Windows.Forms.CheckBox());
            this.checkBoxShowScaleLine = (new global::System.Windows.Forms.CheckBox());
            this.tabControl1 = (new global::System.Windows.Forms.TabControl());
            this.tabPage3 = (new global::System.Windows.Forms.TabPage());
            this.numericUpDownMaxInt = (new global::System.Windows.Forms.NumericUpDown());
            this.label7 = (new global::System.Windows.Forms.Label());
            this.label21 = (new global::System.Windows.Forms.Label());
            this.numericUpDownMinInt = (new global::System.Windows.Forms.NumericUpDown());
            this.checkBoxShowUnrolledImage = (new global::System.Windows.Forms.CheckBox());
            this.label24 = (new global::System.Windows.Forms.Label());
            this.label23 = (new global::System.Windows.Forms.Label());
            this.label22 = (new global::System.Windows.Forms.Label());
            this.comboBoxGradient = (new global::System.Windows.Forms.ComboBox());
            this.comboBoxScale2 = (new global::System.Windows.Forms.ComboBox());
            this.comboBoxScale1 = (new global::System.Windows.Forms.ComboBox());
            this.graphControlFrequency = (new global::Crystallography.Controls.GraphControl());
            this.pictureBoxMain = (new global::System.Windows.Forms.PictureBox());
            this.panel1 = (new global::System.Windows.Forms.Panel());
            this.tableLayoutPanel2 = (new global::System.Windows.Forms.TableLayoutPanel());
            this.numericBoxUpperX = (new global::Crystallography.Controls.NumericBoxWithMenu());
            this.numericBoxUpperY = (new global::Crystallography.Controls.NumericBox());
            this.numericBoxLowerX = (new global::Crystallography.Controls.NumericBoxWithMenu());
            this.numericBoxLowerY = (new global::Crystallography.Controls.NumericBox());
            this.labelD = (new global::System.Windows.Forms.Label());
            this.labelTwoTheta = (new global::System.Windows.Forms.Label());
            this.label11 = (new global::System.Windows.Forms.Label());
            this.label10 = (new global::System.Windows.Forms.Label());
            this.labelX = (new global::System.Windows.Forms.Label());
            this.label9 = (new global::System.Windows.Forms.Label());
            this.labelIntensity = (new global::System.Windows.Forms.Label());
            this.labelQ = (new global::System.Windows.Forms.Label());
            this.splitContainer2 = (new global::System.Windows.Forms.SplitContainer());
            this.groupBox1 = (new global::System.Windows.Forms.GroupBox());
            this.dataGridViewProfiles = (new global::System.Windows.Forms.DataGridView());
            this.checkDataGridViewCheckBoxColumn2 = (new global::System.Windows.Forms.DataGridViewCheckBoxColumn());
            this.colorDataGridViewTextBoxColumn = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.profileDataGridViewTextBoxColumn = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.bindingSourceProfile = (new global::System.Windows.Forms.BindingSource(this.components));
            this.dataSet = (new global::PDIndexer.DataSet());
            this.checkBoxProfileParameter = (new global::System.Windows.Forms.CheckBox());
            this.checkBoxAll = (new global::System.Windows.Forms.CheckBox());
            this.groupBoxCrystalData = (new global::System.Windows.Forms.GroupBox());
            this.dataGridViewCrystals = (new global::System.Windows.Forms.DataGridView());
            this.checkDataGridViewCheckBoxColumn1 = (new global::System.Windows.Forms.DataGridViewCheckBoxColumn());
            this.PeakColor = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.Crystal = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.bindingSourceCrystal = (new global::System.Windows.Forms.BindingSource(this.components));
            this.checkBoxCrystalParameter = (new global::System.Windows.Forms.CheckBox());
            this.toolStrip2 = (new global::System.Windows.Forms.ToolStrip());
            this.toolStripButtonCrystalParameter = (new global::System.Windows.Forms.ToolStripButton());
            this.toolStripSeparator4 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.toolStripButtonProfileParameter = (new global::System.Windows.Forms.ToolStripButton());
            this.toolStripSeparator6 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.toolStripButtonEquationOfState = (new global::System.Windows.Forms.ToolStripButton());
            this.toolStripSeparator8 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.toolStripButtonFittingParameter = (new global::System.Windows.Forms.ToolStripButton());
            this.toolStripSeparator5 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.toolStripButtonCellFinder = (new global::System.Windows.Forms.ToolStripButton());
            this.toolStripSeparator11 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.toolStripButtonSequentialAnalysis = (new global::System.Windows.Forms.ToolStripButton());
            this.toolStripSeparator10 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.toolStripButtonAtomicPositonFinder = (new global::System.Windows.Forms.ToolStripButton());
            this.toolStripSeparator12 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.toolStripButtonLPO = (new global::System.Windows.Forms.ToolStripButton());
            this.menuStrip = (new global::System.Windows.Forms.MenuStrip());
            this.fileToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.readPatternProfileToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.savePatternProfileToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripMenuItemExportExcelFile = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.asCSVcommaSeperatedFileToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.asTSVtabSeparatedValuesFileToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.asGSASFileToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripSeparator1 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.readCrystalDataToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.readAndAddToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.saveCrystalDataToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripMenuItemImport = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripMenuItemExportCIF = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.resetInitialCrystalDataToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripSeparator3 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.toolStripMenuItemPageSetup = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripMenuItemPrintPreview = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.printToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripSeparator9 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.コピーToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.BitmapToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.copyAsMetafileToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripMenuItemSaveMetafile = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripSeparator2 = (new global::System.Windows.Forms.ToolStripSeparator());
            this.closeToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.optionToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolTipToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.watchReadClipboardToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.watchReadANewProfileToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.setDirectoryToTheWatchToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.toolStripTextBoxDirectoryToWatch = (new global::System.Windows.Forms.ToolStripTextBox());
            this.clearRegistryToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.automaticallySaveTheCrystalListToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.macroToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.editorToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.helpToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.aboutMeToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.programUpdatesToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.hintToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.helpwebToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.languageToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.englishToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.japaneseToolStripMenuItem = (new global::System.Windows.Forms.ToolStripMenuItem());
            this.button2 = (new global::System.Windows.Forms.Button());
            this.button3 = (new global::System.Windows.Forms.Button());
            this.buttonAu = (new global::System.Windows.Forms.Button());
            this.toolTip = (new global::System.Windows.Forms.ToolTip(this.components));
            this.pageSetupDialog1 = (new global::System.Windows.Forms.PageSetupDialog());
            this.printDialog1 = (new global::System.Windows.Forms.PrintDialog());
            this.dataGridViewTextBoxColumn1 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn2 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.checkDataGridViewCheckBoxColumn = (new global::System.Windows.Forms.DataGridViewCheckBoxColumn());
            this.Check = (new global::System.Windows.Forms.DataGridViewCheckBoxColumn());
            this.dataGridViewTextBoxColumn3 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn4 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn5 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn6 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn7 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn8 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn9 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn10 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn11 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn12 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn13 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn14 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn15 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn16 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn17 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn18 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn19 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn20 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn21 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn22 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn23 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn25 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn1 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn24 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn2 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn26 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn3 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn27 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewTextBoxColumn30 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn4 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn28 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn5 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn29 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn6 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn31 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn7 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn32 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn8 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn33 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn9 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn34 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn10 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn35 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn11 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn36 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn12 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn37 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn13 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn38 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn15 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn40 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn14 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn39 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn16 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn41 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn17 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn42 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn19 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn44 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn18 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn43 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn20 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn45 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn21 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn46 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn22 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn47 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn23 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn48 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn24 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn49 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn25 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn50 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn26 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn51 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn27 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn52 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn29 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn54 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn28 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn53 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn30 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn55 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn31 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn56 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn32 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn57 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn33 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn58 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn34 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn59 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn35 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn60 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn36 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn61 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn37 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn62 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn38 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn63 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn39 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn64 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn40 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn65 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn41 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn66 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn42 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn67 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn43 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn68 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn44 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn69 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn45 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn70 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn46 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn71 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn47 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn72 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn48 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn73 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn49 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn74 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.timerBlinkDiffraction = (new global::System.Windows.Forms.Timer(this.components));
            this.dataGridViewImageColumn51 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn76 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn52 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn77 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn50 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn75 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn53 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn78 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn54 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn79 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn55 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn80 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn56 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn81 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn57 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn82 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn58 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn83 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn59 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn84 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn60 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn85 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn61 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn86 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn62 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn87 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn63 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn88 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn64 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn89 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn65 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn90 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn66 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn91 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn67 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn92 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn68 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn93 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn69 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn94 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn70 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn95 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn71 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn96 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn72 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn97 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn73 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn98 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn74 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn99 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn75 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn100 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn76 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn101 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn77 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn102 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn78 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn103 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn79 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn104 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn80 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn105 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn82 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn107 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn81 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn106 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn83 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn108 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn84 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn109 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn85 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn110 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn86 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn111 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn87 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn112 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn88 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn113 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.dataGridViewImageColumn89 = (new global::System.Windows.Forms.DataGridViewImageColumn());
            this.dataGridViewTextBoxColumn114 = (new global::System.Windows.Forms.DataGridViewTextBoxColumn());
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.numericUpDownIncreasingPixels)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxInt)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.numericUpDownMinInt)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.dataGridViewProfiles)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.bindingSourceProfile)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.groupBoxCrystalData.SuspendLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystals)).BeginInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.bindingSourceCrystal)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = ("toolStripContainer1");
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip);
            resources.ApplyResources(this.toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = (new global::System.Drawing.Size(32, 32));
            this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.toolStripProgressBar, this.toolStripStatusLabelCalcTime, this.toolStripStatusLabel1, this.toolStripStatusLabel2 });
            this.statusStrip1.Name = ("statusStrip1");
            this.statusStrip1.RenderMode = (global::System.Windows.Forms.ToolStripRenderMode.Professional);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = ("toolStripProgressBar");
            resources.ApplyResources(this.toolStripProgressBar, "toolStripProgressBar");
            // 
            // toolStripStatusLabelCalcTime
            // 
            this.toolStripStatusLabelCalcTime.Name = ("toolStripStatusLabelCalcTime");
            resources.ApplyResources(this.toolStripStatusLabelCalcTime, "toolStripStatusLabelCalcTime");
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = ("toolStripStatusLabel1");
            // 
            // toolStripStatusLabel2
            // 
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.Name = ("toolStripStatusLabel2");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = ("splitContainer1");
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBoxMain);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.HotTrack = (true);
            this.tabControl.Name = ("tabControl");
            this.tabControl.SelectedIndex = (0);
            this.tabControl.Click += (this.tabControl_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.horizontalAxisUserControl);
            this.tabPage1.Controls.Add(this.flowLayoutPanel4);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = ("tabPage1");
            this.tabPage1.UseVisualStyleBackColor = (true);
            // 
            // horizontalAxisUserControl
            // 
            resources.ApplyResources(this.horizontalAxisUserControl, "horizontalAxisUserControl");
            this.horizontalAxisUserControl.AxisMode = (global::Crystallography.HorizontalAxis.Angle);
            this.horizontalAxisUserControl.ElectronAccVoltage = (8.04114721D);
            this.horizontalAxisUserControl.ElectronAccVoltageText = ("8.04114721");
            this.horizontalAxisUserControl.EnergyUnit = (global::Crystallography.EnergyUnitEnum.eV);
            this.horizontalAxisUserControl.Name = ("horizontalAxisUserControl");
            this.horizontalAxisUserControl.TakeoffAngle = (0D);
            this.horizontalAxisUserControl.TakeoffAngleText = ("0");
            this.horizontalAxisUserControl.TofAngle = (1.5707963267948966D);
            this.horizontalAxisUserControl.TofAngleText = ("90");
            this.horizontalAxisUserControl.TofLength = (90D);
            this.horizontalAxisUserControl.WaveColor = (global::Crystallography.WaveColor.Monochrome);
            this.horizontalAxisUserControl.WaveLength = (0.1541871066667D);
            this.horizontalAxisUserControl.WaveLengthText = ("1.541871066667");
            this.horizontalAxisUserControl.WaveSource = (global::Crystallography.WaveSource.Xray);
            this.horizontalAxisUserControl.XrayWaveSourceElementNumber = (29);
            this.horizontalAxisUserControl.XrayWaveSourceLine = (global::Crystallography.XrayLine.Ka);
            this.horizontalAxisUserControl.AxisPropertyChanged += (this.horizontalAxisUserControl_AxisPropertyChanged);
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(this.flowLayoutPanel4, "flowLayoutPanel4");
            this.flowLayoutPanel4.Controls.Add(this.checkBoxChangeHorizontalAppearance);
            this.flowLayoutPanel4.Name = ("flowLayoutPanel4");
            // 
            // checkBoxChangeHorizontalAppearance
            // 
            resources.ApplyResources(this.checkBoxChangeHorizontalAppearance, "checkBoxChangeHorizontalAppearance");
            this.checkBoxChangeHorizontalAppearance.Checked = (true);
            this.checkBoxChangeHorizontalAppearance.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.checkBoxChangeHorizontalAppearance.Name = ("checkBoxChangeHorizontalAppearance");
            this.toolTip.SetToolTip(this.checkBoxChangeHorizontalAppearance, resources.GetString("checkBoxChangeHorizontalAppearance.ToolTip"));
            this.checkBoxChangeHorizontalAppearance.UseVisualStyleBackColor = (true);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.checkBoxErrorBar);
            this.tabPage2.Controls.Add(this.checkBoxShowScaleLine);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = ("tabPage2");
            this.tabPage2.UseVisualStyleBackColor = (true);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel2);
            this.groupBox4.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = ("groupBox4");
            this.groupBox4.TabStop = (false);
            this.toolTip.SetToolTip(this.groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.radioButtonLinearity);
            this.flowLayoutPanel2.Controls.Add(this.radioButtonLogarithm);
            this.flowLayoutPanel2.Name = ("flowLayoutPanel2");
            // 
            // radioButtonLinearity
            // 
            resources.ApplyResources(this.radioButtonLinearity, "radioButtonLinearity");
            this.radioButtonLinearity.Checked = (true);
            this.radioButtonLinearity.Name = ("radioButtonLinearity");
            this.radioButtonLinearity.TabStop = (true);
            this.toolTip.SetToolTip(this.radioButtonLinearity, resources.GetString("radioButtonLinearity.ToolTip"));
            this.radioButtonLinearity.UseVisualStyleBackColor = (true);
            this.radioButtonLinearity.CheckedChanged += (this.radioButtonRawCounts_CheckedChanged);
            // 
            // radioButtonLogarithm
            // 
            resources.ApplyResources(this.radioButtonLogarithm, "radioButtonLogarithm");
            this.radioButtonLogarithm.Name = ("radioButtonLogarithm");
            this.toolTip.SetToolTip(this.radioButtonLogarithm, resources.GetString("radioButtonLogarithm.ToolTip"));
            this.radioButtonLogarithm.UseVisualStyleBackColor = (true);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.radioButtonRawCounts);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonCountsPerStep);
            this.flowLayoutPanel1.Name = ("flowLayoutPanel1");
            // 
            // radioButtonRawCounts
            // 
            resources.ApplyResources(this.radioButtonRawCounts, "radioButtonRawCounts");
            this.radioButtonRawCounts.Name = ("radioButtonRawCounts");
            this.toolTip.SetToolTip(this.radioButtonRawCounts, resources.GetString("radioButtonRawCounts.ToolTip"));
            this.radioButtonRawCounts.UseVisualStyleBackColor = (true);
            this.radioButtonRawCounts.CheckedChanged += (this.radioButtonRawCounts_CheckedChanged);
            // 
            // radioButtonCountsPerStep
            // 
            resources.ApplyResources(this.radioButtonCountsPerStep, "radioButtonCountsPerStep");
            this.radioButtonCountsPerStep.Checked = (true);
            this.radioButtonCountsPerStep.Name = ("radioButtonCountsPerStep");
            this.radioButtonCountsPerStep.TabStop = (true);
            this.toolTip.SetToolTip(this.radioButtonCountsPerStep, resources.GetString("radioButtonCountsPerStep.ToolTip"));
            this.radioButtonCountsPerStep.UseVisualStyleBackColor = (true);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericalTextBoxIncreasingPixels);
            this.groupBox3.Controls.Add(this.numericUpDownIncreasingPixels);
            this.groupBox3.Controls.Add(this.radioButtonMultiProfileMode);
            this.groupBox3.Controls.Add(this.checkBoxChangeColor);
            this.groupBox3.Controls.Add(this.radioButtonSingleProfileMode);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = ("groupBox3");
            this.groupBox3.TabStop = (false);
            // 
            // numericalTextBoxIncreasingPixels
            // 
            resources.ApplyResources(this.numericalTextBoxIncreasingPixels, "numericalTextBoxIncreasingPixels");
            this.numericalTextBoxIncreasingPixels.BackColor = (global::System.Drawing.SystemColors.Control);
            this.numericalTextBoxIncreasingPixels.FooterBackColor = (global::System.Drawing.SystemColors.Control);
            this.numericalTextBoxIncreasingPixels.HeaderBackColor = (global::System.Drawing.SystemColors.Control);
            this.numericalTextBoxIncreasingPixels.Name = ("numericalTextBoxIncreasingPixels");
            this.numericalTextBoxIncreasingPixels.RadianValue = (17.872171540421935D);
            this.numericalTextBoxIncreasingPixels.RestrictLimitValue = (false);
            this.numericalTextBoxIncreasingPixels.RoundErrorAccuracy = (-1);
            this.numericalTextBoxIncreasingPixels.SkipEventDuringInput = (false);
            this.numericalTextBoxIncreasingPixels.Value = (1024D);
            this.numericalTextBoxIncreasingPixels.ValueChanged += (this.radioButtonMultiProfileMode_CheckChanged);
            // 
            // numericUpDownIncreasingPixels
            // 
            resources.ApplyResources(this.numericUpDownIncreasingPixels, "numericUpDownIncreasingPixels");
            this.numericUpDownIncreasingPixels.Maximum = (new global::System.Decimal(new global::System.Int32[] { 24, 0, 0, 0 }));
            this.numericUpDownIncreasingPixels.Name = ("numericUpDownIncreasingPixels");
            this.numericUpDownIncreasingPixels.Value = (new global::System.Decimal(new global::System.Int32[] { 10, 0, 0, 0 }));
            this.numericUpDownIncreasingPixels.ValueChanged += (this.numericUpDownIncreasingPixels_ValueChanged);
            // 
            // radioButtonMultiProfileMode
            // 
            resources.ApplyResources(this.radioButtonMultiProfileMode, "radioButtonMultiProfileMode");
            this.radioButtonMultiProfileMode.Checked = (true);
            this.radioButtonMultiProfileMode.Name = ("radioButtonMultiProfileMode");
            this.radioButtonMultiProfileMode.TabStop = (true);
            this.radioButtonMultiProfileMode.UseVisualStyleBackColor = (true);
            // 
            // checkBoxChangeColor
            // 
            resources.ApplyResources(this.checkBoxChangeColor, "checkBoxChangeColor");
            this.checkBoxChangeColor.Checked = (true);
            this.checkBoxChangeColor.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.checkBoxChangeColor.Name = ("checkBoxChangeColor");
            this.toolTip.SetToolTip(this.checkBoxChangeColor, resources.GetString("checkBoxChangeColor.ToolTip"));
            this.checkBoxChangeColor.UseVisualStyleBackColor = (true);
            this.checkBoxChangeColor.CheckedChanged += (this.radioButtonMultiProfileMode_CheckChanged);
            // 
            // radioButtonSingleProfileMode
            // 
            resources.ApplyResources(this.radioButtonSingleProfileMode, "radioButtonSingleProfileMode");
            this.radioButtonSingleProfileMode.Name = ("radioButtonSingleProfileMode");
            this.radioButtonSingleProfileMode.UseVisualStyleBackColor = (true);
            this.radioButtonSingleProfileMode.CheckedChanged += (this.radioButtonMultiProfileMode_CheckChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = ("label6");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = ("label1");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colorControlScaleText);
            this.groupBox2.Controls.Add(this.colorControlScaleLine);
            this.groupBox2.Controls.Add(this.colorControlBack);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = ("groupBox2");
            this.groupBox2.TabStop = (false);
            // 
            // colorControlScaleText
            // 
            this.colorControlScaleText.Argb = (-16777216);
            resources.ApplyResources(this.colorControlScaleText, "colorControlScaleText");
            this.colorControlScaleText.Blue = (0);
            this.colorControlScaleText.BlueF = (0F);
            this.colorControlScaleText.BoxSize = (new global::System.Drawing.Size(20, 20));
            this.colorControlScaleText.Color = (global::System.Drawing.Color.FromArgb((global::System.Int32)((global::System.Byte)(0)), (global::System.Int32)((global::System.Byte)(0)), (global::System.Int32)((global::System.Byte)(0))));
            this.colorControlScaleText.FlowDirection = (global::System.Windows.Forms.FlowDirection.LeftToRight);
            this.colorControlScaleText.Green = (0);
            this.colorControlScaleText.GreenF = (0F);
            this.colorControlScaleText.Name = ("colorControlScaleText");
            this.colorControlScaleText.Red = (0);
            this.colorControlScaleText.RedF = (0F);
            this.toolTip.SetToolTip(this.colorControlScaleText, resources.GetString("colorControlScaleText.ToolTip"));
            this.colorControlScaleText.ColorChanged += (this.Draw);
            // 
            // colorControlScaleLine
            // 
            this.colorControlScaleLine.Argb = (-2894893);
            resources.ApplyResources(this.colorControlScaleLine, "colorControlScaleLine");
            this.colorControlScaleLine.Blue = (211);
            this.colorControlScaleLine.BlueF = (0.827451F);
            this.colorControlScaleLine.BoxSize = (new global::System.Drawing.Size(20, 20));
            this.colorControlScaleLine.Color = (global::System.Drawing.Color.FromArgb((global::System.Int32)((global::System.Byte)(211)), (global::System.Int32)((global::System.Byte)(211)), (global::System.Int32)((global::System.Byte)(211))));
            this.colorControlScaleLine.FlowDirection = (global::System.Windows.Forms.FlowDirection.LeftToRight);
            this.colorControlScaleLine.Green = (211);
            this.colorControlScaleLine.GreenF = (0.827451F);
            this.colorControlScaleLine.Name = ("colorControlScaleLine");
            this.colorControlScaleLine.Red = (211);
            this.colorControlScaleLine.RedF = (0.827451F);
            this.toolTip.SetToolTip(this.colorControlScaleLine, resources.GetString("colorControlScaleLine.ToolTip"));
            this.colorControlScaleLine.ColorChanged += (this.Draw);
            // 
            // colorControlBack
            // 
            this.colorControlBack.Argb = (-1);
            resources.ApplyResources(this.colorControlBack, "colorControlBack");
            this.colorControlBack.Blue = (255);
            this.colorControlBack.BlueF = (1F);
            this.colorControlBack.BoxSize = (new global::System.Drawing.Size(20, 20));
            this.colorControlBack.Color = (global::System.Drawing.Color.FromArgb((global::System.Int32)((global::System.Byte)(255)), (global::System.Int32)((global::System.Byte)(255)), (global::System.Int32)((global::System.Byte)(255))));
            this.colorControlBack.FlowDirection = (global::System.Windows.Forms.FlowDirection.LeftToRight);
            this.colorControlBack.Green = (255);
            this.colorControlBack.GreenF = (1F);
            this.colorControlBack.Name = ("colorControlBack");
            this.colorControlBack.Red = (255);
            this.colorControlBack.RedF = (1F);
            this.toolTip.SetToolTip(this.colorControlBack, resources.GetString("colorControlBack.ToolTip"));
            this.colorControlBack.ColorChanged += (this.Draw);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = ("label5");
            this.toolTip.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = ("label2");
            this.toolTip.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = ("label4");
            this.toolTip.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // checkBoxErrorBar
            // 
            resources.ApplyResources(this.checkBoxErrorBar, "checkBoxErrorBar");
            this.checkBoxErrorBar.Name = ("checkBoxErrorBar");
            this.toolTip.SetToolTip(this.checkBoxErrorBar, resources.GetString("checkBoxErrorBar.ToolTip"));
            this.checkBoxErrorBar.UseVisualStyleBackColor = (true);
            this.checkBoxErrorBar.CheckedChanged += (this.checkBoxShowScaleLine_CheckedChanged_1);
            // 
            // checkBoxShowScaleLine
            // 
            resources.ApplyResources(this.checkBoxShowScaleLine, "checkBoxShowScaleLine");
            this.checkBoxShowScaleLine.Name = ("checkBoxShowScaleLine");
            this.toolTip.SetToolTip(this.checkBoxShowScaleLine, resources.GetString("checkBoxShowScaleLine.ToolTip"));
            this.checkBoxShowScaleLine.UseVisualStyleBackColor = (true);
            this.checkBoxShowScaleLine.CheckedChanged += (this.checkBoxShowScaleLine_CheckedChanged_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.HotTrack = (true);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Multiline = (true);
            this.tabControl1.Name = ("tabControl1");
            this.tabControl1.SelectedIndex = (0);
            this.tabControl1.Click += (this.tabControl1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.numericUpDownMaxInt);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.numericUpDownMinInt);
            this.tabPage3.Controls.Add(this.checkBoxShowUnrolledImage);
            this.tabPage3.Controls.Add(this.label24);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.comboBoxGradient);
            this.tabPage3.Controls.Add(this.comboBoxScale2);
            this.tabPage3.Controls.Add(this.comboBoxScale1);
            this.tabPage3.Controls.Add(this.graphControlFrequency);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = ("tabPage3");
            this.tabPage3.UseVisualStyleBackColor = (true);
            // 
            // numericUpDownMaxInt
            // 
            resources.ApplyResources(this.numericUpDownMaxInt, "numericUpDownMaxInt");
            this.numericUpDownMaxInt.Increment = (new global::System.Decimal(new global::System.Int32[] { 10, 0, 0, 0 }));
            this.numericUpDownMaxInt.Maximum = (new global::System.Decimal(new global::System.Int32[] { 65535, 0, 0, 0 }));
            this.numericUpDownMaxInt.Minimum = (new global::System.Decimal(new global::System.Int32[] { 1, 0, 0, 0 }));
            this.numericUpDownMaxInt.Name = ("numericUpDownMaxInt");
            this.numericUpDownMaxInt.Value = (new global::System.Decimal(new global::System.Int32[] { 65535, 0, 0, 0 }));
            this.numericUpDownMaxInt.ValueChanged += (this.numericUpDownMaxInt_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = ("label7");
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = ("label21");
            // 
            // numericUpDownMinInt
            // 
            resources.ApplyResources(this.numericUpDownMinInt, "numericUpDownMinInt");
            this.numericUpDownMinInt.Increment = (new global::System.Decimal(new global::System.Int32[] { 10, 0, 0, 0 }));
            this.numericUpDownMinInt.Maximum = (new global::System.Decimal(new global::System.Int32[] { 65534, 0, 0, 0 }));
            this.numericUpDownMinInt.Name = ("numericUpDownMinInt");
            this.numericUpDownMinInt.ValueChanged += (this.numericUpDownMinInt_ValueChanged);
            // 
            // checkBoxShowUnrolledImage
            // 
            resources.ApplyResources(this.checkBoxShowUnrolledImage, "checkBoxShowUnrolledImage");
            this.checkBoxShowUnrolledImage.Checked = (true);
            this.checkBoxShowUnrolledImage.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.checkBoxShowUnrolledImage.Name = ("checkBoxShowUnrolledImage");
            this.checkBoxShowUnrolledImage.UseVisualStyleBackColor = (true);
            this.checkBoxShowUnrolledImage.CheckedChanged += (this.checkBoxShowUnrolledImage_CheckedChanged);
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = ("label24");
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = ("label23");
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = ("label22");
            // 
            // comboBoxGradient
            // 
            this.comboBoxGradient.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            resources.ApplyResources(this.comboBoxGradient, "comboBoxGradient");
            this.comboBoxGradient.FormattingEnabled = (true);
            this.comboBoxGradient.Items.AddRange(new global::System.Object[] { resources.GetString("comboBoxGradient.Items"), resources.GetString("comboBoxGradient.Items1") });
            this.comboBoxGradient.Name = ("comboBoxGradient");
            this.comboBoxGradient.SelectedIndexChanged += (this.toolStripComboBoxGradient_SelectedIndexChanged);
            // 
            // comboBoxScale2
            // 
            this.comboBoxScale2.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            resources.ApplyResources(this.comboBoxScale2, "comboBoxScale2");
            this.comboBoxScale2.FormattingEnabled = (true);
            this.comboBoxScale2.Items.AddRange(new global::System.Object[] { resources.GetString("comboBoxScale2.Items"), resources.GetString("comboBoxScale2.Items1") });
            this.comboBoxScale2.Name = ("comboBoxScale2");
            this.comboBoxScale2.SelectedIndexChanged += (this.toolStripComboBoxScale2_SelectedIndexChanged);
            // 
            // comboBoxScale1
            // 
            this.comboBoxScale1.DropDownStyle = (global::System.Windows.Forms.ComboBoxStyle.DropDownList);
            resources.ApplyResources(this.comboBoxScale1, "comboBoxScale1");
            this.comboBoxScale1.FormattingEnabled = (true);
            this.comboBoxScale1.Items.AddRange(new global::System.Object[] { resources.GetString("comboBoxScale1.Items"), resources.GetString("comboBoxScale1.Items1") });
            this.comboBoxScale1.Name = ("comboBoxScale1");
            this.comboBoxScale1.SelectedIndexChanged += (this.toolStripComboBoxScale_SelectedIndexChanged);
            // 
            // graphControlFrequency
            // 
            this.graphControlFrequency.AllowMouseOperation = (true);
            resources.ApplyResources(this.graphControlFrequency, "graphControlFrequency");
            this.graphControlFrequency.AxisLineColor = (global::System.Drawing.Color.Gray);
            this.graphControlFrequency.AxisTextColor = (global::System.Drawing.Color.Black);
            this.graphControlFrequency.AxisTextFont = (new global::System.Drawing.Font("Segoe UI", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.graphControlFrequency.AxisXTextVisible = (true);
            this.graphControlFrequency.AxisYTextVisible = (true);
            this.graphControlFrequency.BackgroundColor = (global::System.Drawing.Color.White);
            this.graphControlFrequency.BottomMargin = (0D);
            this.graphControlFrequency.DivisionLineColor = (global::System.Drawing.Color.Gray);
            this.graphControlFrequency.DivisionLineXVisible = (true);
            this.graphControlFrequency.DivisionLineYVisible = (true);
            this.graphControlFrequency.DrawingRange = ((global::Crystallography.RectangleD)(resources.GetObject("graphControlFrequency.DrawingRange")));
            this.graphControlFrequency.FixRangeHorizontal = (false);
            this.graphControlFrequency.FixRangeVertical = (false);
            this.graphControlFrequency.GraphTitle = ("");
            this.graphControlFrequency.Interpolation = (false);
            this.graphControlFrequency.IsIntegerX = (true);
            this.graphControlFrequency.IsIntegerY = (true);
            this.graphControlFrequency.LabelX = ("X:");
            this.graphControlFrequency.LabelY = ("Y:");
            this.graphControlFrequency.LeftMargin = (0F);
            this.graphControlFrequency.LineWidth = (1F);
            this.graphControlFrequency.LowerX = (0D);
            this.graphControlFrequency.LowerY = (0D);
            this.graphControlFrequency.MaximalX = (1D);
            this.graphControlFrequency.MaximalY = (1D);
            this.graphControlFrequency.MinimalX = (0D);
            this.graphControlFrequency.MinimalY = (0D);
            this.graphControlFrequency.Mode = (global::Crystallography.Controls.GraphControl.DrawingMode.Line);
            this.graphControlFrequency.MousePositionVisible = (true);
            this.graphControlFrequency.MousePositionXDigit = (-1);
            this.graphControlFrequency.MousePositionYDigit = (-1);
            this.graphControlFrequency.Name = ("graphControlFrequency");
            this.graphControlFrequency.OriginPosition = (new global::System.Drawing.Point(40, 20));
            this.graphControlFrequency.Profile = (null);
            this.graphControlFrequency.Smoothing = (false);
            this.graphControlFrequency.UnitX = ("");
            this.graphControlFrequency.UnitY = ("");
            this.graphControlFrequency.UpperPanelFont = (new global::System.Drawing.Font("Segoe UI Symbol", 9F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.graphControlFrequency.UpperPanelVisible = (true);
            this.graphControlFrequency.UpperX = (1D);
            this.graphControlFrequency.UpperY = (1D);
            this.graphControlFrequency.UseLineWidth = (true);
            this.graphControlFrequency.VerticalLineColor = (global::System.Drawing.Color.Red);
            this.graphControlFrequency.XLog = (true);
            this.graphControlFrequency.YLog = (true);
            this.graphControlFrequency.LinePositionChanged += (this.graphControlFrequency_LinePositionChanged);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = (global::System.Drawing.Color.White);
            this.pictureBoxMain.BorderStyle = (global::System.Windows.Forms.BorderStyle.Fixed3D);
            resources.ApplyResources(this.pictureBoxMain, "pictureBoxMain");
            this.pictureBoxMain.Name = ("pictureBoxMain");
            this.pictureBoxMain.TabStop = (false);
            this.toolTip.SetToolTip(this.pictureBoxMain, resources.GetString("pictureBoxMain.ToolTip"));
            this.pictureBoxMain.Paint += (this.pictureBoxMain_Paint);
            this.pictureBoxMain.MouseDown += (this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseMove += (this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += (this.pictureBoxMain_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = ("panel1");
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.numericBoxUpperX, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBoxUpperY, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBoxLowerX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBoxLowerY, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelD, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelTwoTheta, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelX, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelIntensity, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelQ, 10, 0);
            this.tableLayoutPanel2.Name = ("tableLayoutPanel2");
            // 
            // numericBoxUpperX
            // 
            this.numericBoxUpperX.AllowMouseControl = (false);
            this.numericBoxUpperX.BackColor = (global::System.Drawing.Color.Transparent);
            this.numericBoxUpperX.DecimalPlaces = (2);
            resources.ApplyResources(this.numericBoxUpperX, "numericBoxUpperX");
            this.numericBoxUpperX.Maximum = (30D);
            this.numericBoxUpperX.Minimum = (0D);
            this.numericBoxUpperX.MouseDirection = (global::Crystallography.VH_DirectionEnum.Vertical);
            this.numericBoxUpperX.MouseSpeed = (1D);
            this.numericBoxUpperX.Name = ("numericBoxUpperX");
            this.numericBoxUpperX.RadianValue = (0.52359877559829882D);
            this.numericBoxUpperX.RoundErrorAccuracy = (-1);
            this.numericBoxUpperX.ShowUpDown = (true);
            this.numericBoxUpperX.SmartIncrement = (true);
            this.numericBoxUpperX.ThonsandsSeparator = (true);
            this.toolTip.SetToolTip(this.numericBoxUpperX, resources.GetString("numericBoxUpperX.ToolTip"));
            this.numericBoxUpperX.Value = (30D);
            this.numericBoxUpperX.WordWrap = (false);
            this.numericBoxUpperX.LimitChanged += (this.numericBoxUpperX_LimitChanged);
            this.numericBoxUpperX.ValueChanged += (this.numericBox_ValueChanged);
            // 
            // numericBoxUpperY
            // 
            resources.ApplyResources(this.numericBoxUpperY, "numericBoxUpperY");
            this.numericBoxUpperY.BackColor = (global::System.Drawing.SystemColors.Control);
            this.numericBoxUpperY.DecimalPlaces = (2);
            this.numericBoxUpperY.FooterBackColor = (global::System.Drawing.SystemColors.Control);
            this.numericBoxUpperY.HeaderBackColor = (global::System.Drawing.SystemColors.Control);
            this.numericBoxUpperY.Maximum = (1000D);
            this.numericBoxUpperY.Minimum = (0D);
            this.numericBoxUpperY.Name = ("numericBoxUpperY");
            this.numericBoxUpperY.RadianValue = (17.453292519943293D);
            this.numericBoxUpperY.RoundErrorAccuracy = (-1);
            this.numericBoxUpperY.ShowUpDown = (true);
            this.numericBoxUpperY.SmartIncrement = (true);
            this.numericBoxUpperY.ThonsandsSeparator = (true);
            this.toolTip.SetToolTip(this.numericBoxUpperY, resources.GetString("numericBoxUpperY.ToolTip"));
            this.numericBoxUpperY.Value = (1000D);
            this.numericBoxUpperY.WordWrap = (false);
            this.numericBoxUpperY.ValueChanged += (this.numericBox_ValueChanged);
            // 
            // numericBoxLowerX
            // 
            this.numericBoxLowerX.AllowMouseControl = (false);
            this.numericBoxLowerX.BackColor = (global::System.Drawing.Color.Transparent);
            this.numericBoxLowerX.DecimalPlaces = (2);
            resources.ApplyResources(this.numericBoxLowerX, "numericBoxLowerX");
            this.numericBoxLowerX.Maximum = (30D);
            this.numericBoxLowerX.Minimum = (0D);
            this.numericBoxLowerX.MouseDirection = (global::Crystallography.VH_DirectionEnum.Vertical);
            this.numericBoxLowerX.MouseSpeed = (1D);
            this.numericBoxLowerX.Name = ("numericBoxLowerX");
            this.numericBoxLowerX.RoundErrorAccuracy = (-1);
            this.numericBoxLowerX.ShowUpDown = (true);
            this.numericBoxLowerX.SmartIncrement = (true);
            this.numericBoxLowerX.ThonsandsSeparator = (true);
            this.toolTip.SetToolTip(this.numericBoxLowerX, resources.GetString("numericBoxLowerX.ToolTip"));
            this.numericBoxLowerX.WordWrap = (false);
            this.numericBoxLowerX.LimitChanged += (this.numericBoxUpperX_LimitChanged);
            this.numericBoxLowerX.ValueChanged += (this.numericBox_ValueChanged);
            // 
            // numericBoxLowerY
            // 
            resources.ApplyResources(this.numericBoxLowerY, "numericBoxLowerY");
            this.numericBoxLowerY.BackColor = (global::System.Drawing.SystemColors.Control);
            this.numericBoxLowerY.DecimalPlaces = (2);
            this.numericBoxLowerY.FooterBackColor = (global::System.Drawing.SystemColors.Control);
            this.numericBoxLowerY.HeaderBackColor = (global::System.Drawing.SystemColors.Control);
            this.numericBoxLowerY.Maximum = (1000D);
            this.numericBoxLowerY.Minimum = (0D);
            this.numericBoxLowerY.Name = ("numericBoxLowerY");
            this.numericBoxLowerY.RoundErrorAccuracy = (-1);
            this.numericBoxLowerY.ShowUpDown = (true);
            this.numericBoxLowerY.SmartIncrement = (true);
            this.numericBoxLowerY.ThonsandsSeparator = (true);
            this.toolTip.SetToolTip(this.numericBoxLowerY, resources.GetString("numericBoxLowerY.ToolTip"));
            this.numericBoxLowerY.WordWrap = (false);
            this.numericBoxLowerY.ValueChanged += (this.numericBox_ValueChanged);
            // 
            // labelD
            // 
            resources.ApplyResources(this.labelD, "labelD");
            this.labelD.Name = ("labelD");
            // 
            // labelTwoTheta
            // 
            resources.ApplyResources(this.labelTwoTheta, "labelTwoTheta");
            this.labelTwoTheta.Name = ("labelTwoTheta");
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = ("label11");
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = ("label10");
            // 
            // labelX
            // 
            resources.ApplyResources(this.labelX, "labelX");
            this.labelX.Name = ("labelX");
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = ("label9");
            // 
            // labelIntensity
            // 
            resources.ApplyResources(this.labelIntensity, "labelIntensity");
            this.labelIntensity.Name = ("labelIntensity");
            // 
            // labelQ
            // 
            resources.ApplyResources(this.labelQ, "labelQ");
            this.labelQ.Name = ("labelQ");
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = ("splitContainer2");
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBoxCrystalData);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewProfiles);
            this.groupBox1.Controls.Add(this.checkBoxProfileParameter);
            this.groupBox1.Controls.Add(this.checkBoxAll);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = ("groupBox1");
            this.groupBox1.TabStop = (false);
            // 
            // dataGridViewProfiles
            // 
            this.dataGridViewProfiles.AllowUserToAddRows = (false);
            this.dataGridViewProfiles.AllowUserToDeleteRows = (false);
            this.dataGridViewProfiles.AllowUserToResizeColumns = (false);
            this.dataGridViewProfiles.AllowUserToResizeRows = (false);
            dataGridViewCellStyle1.BackColor = (global::System.Drawing.Color.White);
            dataGridViewCellStyle1.SelectionBackColor = (global::System.Drawing.Color.MidnightBlue);
            this.dataGridViewProfiles.AlternatingRowsDefaultCellStyle = (dataGridViewCellStyle1);
            this.dataGridViewProfiles.AutoGenerateColumns = (false);
            this.dataGridViewProfiles.BorderStyle = (global::System.Windows.Forms.BorderStyle.None);
            this.dataGridViewProfiles.CellBorderStyle = (global::System.Windows.Forms.DataGridViewCellBorderStyle.None);
            dataGridViewCellStyle2.Alignment = (global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft);
            dataGridViewCellStyle2.BackColor = (global::System.Drawing.SystemColors.Control);
            dataGridViewCellStyle2.Font = (new global::System.Drawing.Font("Segoe UI Symbol", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            dataGridViewCellStyle2.ForeColor = (global::System.Drawing.SystemColors.WindowText);
            dataGridViewCellStyle2.SelectionBackColor = (global::System.Drawing.Color.Blue);
            dataGridViewCellStyle2.SelectionForeColor = (global::System.Drawing.SystemColors.HighlightText);
            dataGridViewCellStyle2.WrapMode = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewProfiles.ColumnHeadersDefaultCellStyle = (dataGridViewCellStyle2);
            resources.ApplyResources(this.dataGridViewProfiles, "dataGridViewProfiles");
            this.dataGridViewProfiles.ColumnHeadersHeightSizeMode = (global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing);
            this.dataGridViewProfiles.ColumnHeadersVisible = (false);
            this.dataGridViewProfiles.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.checkDataGridViewCheckBoxColumn2, this.colorDataGridViewTextBoxColumn, this.profileDataGridViewTextBoxColumn });
            this.dataGridViewProfiles.DataSource = (this.bindingSourceProfile);
            dataGridViewCellStyle3.Alignment = (global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft);
            dataGridViewCellStyle3.BackColor = (global::System.Drawing.Color.White);
            dataGridViewCellStyle3.Font = (new global::System.Drawing.Font("Segoe UI Symbol", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            dataGridViewCellStyle3.ForeColor = (global::System.Drawing.SystemColors.ControlText);
            dataGridViewCellStyle3.SelectionBackColor = (global::System.Drawing.Color.MidnightBlue);
            dataGridViewCellStyle3.SelectionForeColor = (global::System.Drawing.SystemColors.HighlightText);
            dataGridViewCellStyle3.WrapMode = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewProfiles.DefaultCellStyle = (dataGridViewCellStyle3);
            this.dataGridViewProfiles.MultiSelect = (false);
            this.dataGridViewProfiles.Name = ("dataGridViewProfiles");
            this.dataGridViewProfiles.ReadOnly = (true);
            this.dataGridViewProfiles.RowHeadersVisible = (false);
            this.dataGridViewProfiles.RowHeadersWidthSizeMode = (global::System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing);
            this.dataGridViewProfiles.RowTemplate.Height = (21);
            this.dataGridViewProfiles.RowTemplate.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewProfiles.SelectionMode = (global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect);
            this.toolTip.SetToolTip(this.dataGridViewProfiles, resources.GetString("dataGridViewProfiles.ToolTip"));
            this.dataGridViewProfiles.VirtualMode = (true);
            this.dataGridViewProfiles.CellClick += (this.dataGridViewProfiles_CellClick);
            this.dataGridViewProfiles.CellDoubleClick += (this.dataGridViewProfiles_CellClick);
            this.dataGridViewProfiles.KeyDown += (this.dataGridViewProfiles_KeyDown);
            // 
            // checkDataGridViewCheckBoxColumn2
            // 
            this.checkDataGridViewCheckBoxColumn2.DataPropertyName = ("Check");
            resources.ApplyResources(this.checkDataGridViewCheckBoxColumn2, "checkDataGridViewCheckBoxColumn2");
            this.checkDataGridViewCheckBoxColumn2.Name = ("checkDataGridViewCheckBoxColumn2");
            this.checkDataGridViewCheckBoxColumn2.ReadOnly = (true);
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = ("Color");
            resources.ApplyResources(this.colorDataGridViewTextBoxColumn, "colorDataGridViewTextBoxColumn");
            this.colorDataGridViewTextBoxColumn.Name = ("colorDataGridViewTextBoxColumn");
            this.colorDataGridViewTextBoxColumn.ReadOnly = (true);
            this.colorDataGridViewTextBoxColumn.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.colorDataGridViewTextBoxColumn.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // profileDataGridViewTextBoxColumn
            // 
            this.profileDataGridViewTextBoxColumn.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.profileDataGridViewTextBoxColumn.DataPropertyName = ("Profile");
            resources.ApplyResources(this.profileDataGridViewTextBoxColumn, "profileDataGridViewTextBoxColumn");
            this.profileDataGridViewTextBoxColumn.Name = ("profileDataGridViewTextBoxColumn");
            this.profileDataGridViewTextBoxColumn.ReadOnly = (true);
            // 
            // bindingSourceProfile
            // 
            this.bindingSourceProfile.DataMember = ("DataTableProfile");
            this.bindingSourceProfile.DataSource = (this.dataSet);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = ("DataSet1");
            this.dataSet.Locale = (new global::System.Globalization.CultureInfo("ja"));
            this.dataSet.Namespace = ("http://tempuri.org/DataSet1.xsd");
            this.dataSet.SchemaSerializationMode = (global::System.Data.SchemaSerializationMode.IncludeSchema);
            // 
            // checkBoxProfileParameter
            // 
            resources.ApplyResources(this.checkBoxProfileParameter, "checkBoxProfileParameter");
            this.checkBoxProfileParameter.Name = ("checkBoxProfileParameter");
            this.toolTip.SetToolTip(this.checkBoxProfileParameter, resources.GetString("checkBoxProfileParameter.ToolTip"));
            this.checkBoxProfileParameter.CheckedChanged += (this.checkBoxProfileParameter_CheckedChanged);
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.Checked = (true);
            this.checkBoxAll.CheckState = (global::System.Windows.Forms.CheckState.Indeterminate);
            resources.ApplyResources(this.checkBoxAll, "checkBoxAll");
            this.checkBoxAll.Name = ("checkBoxAll");
            this.toolTip.SetToolTip(this.checkBoxAll, resources.GetString("checkBoxAll.ToolTip"));
            this.checkBoxAll.UseVisualStyleBackColor = (true);
            this.checkBoxAll.CheckedChanged += (this.checkBoxAll_CheckedChanged);
            // 
            // groupBoxCrystalData
            // 
            this.groupBoxCrystalData.Controls.Add(this.dataGridViewCrystals);
            this.groupBoxCrystalData.Controls.Add(this.checkBoxCrystalParameter);
            resources.ApplyResources(this.groupBoxCrystalData, "groupBoxCrystalData");
            this.groupBoxCrystalData.Name = ("groupBoxCrystalData");
            this.groupBoxCrystalData.TabStop = (false);
            // 
            // dataGridViewCrystals
            // 
            this.dataGridViewCrystals.AllowUserToAddRows = (false);
            this.dataGridViewCrystals.AllowUserToDeleteRows = (false);
            this.dataGridViewCrystals.AllowUserToResizeColumns = (false);
            this.dataGridViewCrystals.AllowUserToResizeRows = (false);
            dataGridViewCellStyle4.BackColor = (global::System.Drawing.Color.FromArgb((global::System.Int32)((global::System.Byte)(192)), (global::System.Int32)((global::System.Byte)(255)), (global::System.Int32)((global::System.Byte)(192))));
            dataGridViewCellStyle4.SelectionBackColor = (global::System.Drawing.Color.Blue);
            this.dataGridViewCrystals.AlternatingRowsDefaultCellStyle = (dataGridViewCellStyle4);
            this.dataGridViewCrystals.AutoGenerateColumns = (false);
            this.dataGridViewCrystals.BorderStyle = (global::System.Windows.Forms.BorderStyle.None);
            this.dataGridViewCrystals.CellBorderStyle = (global::System.Windows.Forms.DataGridViewCellBorderStyle.None);
            dataGridViewCellStyle5.Alignment = (global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft);
            dataGridViewCellStyle5.BackColor = (global::System.Drawing.SystemColors.Control);
            dataGridViewCellStyle5.Font = (new global::System.Drawing.Font("Segoe UI Symbol", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            dataGridViewCellStyle5.ForeColor = (global::System.Drawing.SystemColors.WindowText);
            dataGridViewCellStyle5.SelectionBackColor = (global::System.Drawing.Color.Blue);
            dataGridViewCellStyle5.SelectionForeColor = (global::System.Drawing.SystemColors.HighlightText);
            dataGridViewCellStyle5.WrapMode = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewCrystals.ColumnHeadersDefaultCellStyle = (dataGridViewCellStyle5);
            resources.ApplyResources(this.dataGridViewCrystals, "dataGridViewCrystals");
            this.dataGridViewCrystals.ColumnHeadersHeightSizeMode = (global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing);
            this.dataGridViewCrystals.ColumnHeadersVisible = (false);
            this.dataGridViewCrystals.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[] { this.checkDataGridViewCheckBoxColumn1, this.PeakColor, this.Crystal });
            this.dataGridViewCrystals.DataSource = (this.bindingSourceCrystal);
            dataGridViewCellStyle7.Alignment = (global::System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft);
            dataGridViewCellStyle7.BackColor = (global::System.Drawing.Color.FromArgb((global::System.Int32)((global::System.Byte)(192)), (global::System.Int32)((global::System.Byte)(255)), (global::System.Int32)((global::System.Byte)(192))));
            dataGridViewCellStyle7.Font = (new global::System.Drawing.Font("Segoe UI Symbol", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            dataGridViewCellStyle7.ForeColor = (global::System.Drawing.SystemColors.ControlText);
            dataGridViewCellStyle7.SelectionBackColor = (global::System.Drawing.Color.Blue);
            dataGridViewCellStyle7.SelectionForeColor = (global::System.Drawing.SystemColors.HighlightText);
            dataGridViewCellStyle7.WrapMode = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewCrystals.DefaultCellStyle = (dataGridViewCellStyle7);
            this.dataGridViewCrystals.MultiSelect = (false);
            this.dataGridViewCrystals.Name = ("dataGridViewCrystals");
            this.dataGridViewCrystals.ReadOnly = (true);
            this.dataGridViewCrystals.RowHeadersVisible = (false);
            this.dataGridViewCrystals.RowHeadersWidthSizeMode = (global::System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing);
            this.dataGridViewCrystals.RowTemplate.Height = (21);
            this.dataGridViewCrystals.RowTemplate.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewCrystals.SelectionMode = (global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect);
            this.toolTip.SetToolTip(this.dataGridViewCrystals, resources.GetString("dataGridViewCrystals.ToolTip"));
            this.dataGridViewCrystals.VirtualMode = (true);
            this.dataGridViewCrystals.CellMouseClick += (this.dataGridViewCrystals_CellMouseClick);
            this.dataGridViewCrystals.CellMouseDoubleClick += (this.dataGridViewCrystals_CellMouseClick);
            this.dataGridViewCrystals.KeyDown += (this.dataGridViewCrystals_KeyDown);
            // 
            // checkDataGridViewCheckBoxColumn1
            // 
            this.checkDataGridViewCheckBoxColumn1.DataPropertyName = ("Check");
            resources.ApplyResources(this.checkDataGridViewCheckBoxColumn1, "checkDataGridViewCheckBoxColumn1");
            this.checkDataGridViewCheckBoxColumn1.Name = ("checkDataGridViewCheckBoxColumn1");
            this.checkDataGridViewCheckBoxColumn1.ReadOnly = (true);
            this.checkDataGridViewCheckBoxColumn1.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // PeakColor
            // 
            this.PeakColor.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.PeakColor, "PeakColor");
            this.PeakColor.Name = ("PeakColor");
            this.PeakColor.ReadOnly = (true);
            this.PeakColor.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.PeakColor.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // Crystal
            // 
            this.Crystal.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.Crystal.DataPropertyName = ("Crystal");
            dataGridViewCellStyle6.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.Crystal.DefaultCellStyle = (dataGridViewCellStyle6);
            resources.ApplyResources(this.Crystal, "Crystal");
            this.Crystal.Name = ("Crystal");
            this.Crystal.ReadOnly = (true);
            this.Crystal.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // bindingSourceCrystal
            // 
            this.bindingSourceCrystal.DataMember = ("DataTableCrystal");
            this.bindingSourceCrystal.DataSource = (this.dataSet);
            // 
            // checkBoxCrystalParameter
            // 
            resources.ApplyResources(this.checkBoxCrystalParameter, "checkBoxCrystalParameter");
            this.checkBoxCrystalParameter.Name = ("checkBoxCrystalParameter");
            this.toolTip.SetToolTip(this.checkBoxCrystalParameter, resources.GetString("checkBoxCrystalParameter.ToolTip"));
            this.checkBoxCrystalParameter.CheckedChanged += (this.checkBoxCrystalParameter_CheckedChanged);
            // 
            // toolStrip2
            // 
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.ImageScalingSize = (new global::System.Drawing.Size(32, 32));
            this.toolStrip2.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.toolStripButtonCrystalParameter, this.toolStripSeparator4, this.toolStripButtonProfileParameter, this.toolStripSeparator6, this.toolStripButtonEquationOfState, this.toolStripSeparator8, this.toolStripButtonFittingParameter, this.toolStripSeparator5, this.toolStripButtonCellFinder, this.toolStripSeparator11, this.toolStripButtonSequentialAnalysis, this.toolStripSeparator10, this.toolStripButtonAtomicPositonFinder, this.toolStripSeparator12, this.toolStripButtonLPO });
            this.toolStrip2.Name = ("toolStrip2");
            // 
            // toolStripButtonCrystalParameter
            // 
            resources.ApplyResources(this.toolStripButtonCrystalParameter, "toolStripButtonCrystalParameter");
            this.toolStripButtonCrystalParameter.Name = ("toolStripButtonCrystalParameter");
            this.toolStripButtonCrystalParameter.Click += (this.toolStripButtonCrystalParameter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = ("toolStripSeparator4");
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripButtonProfileParameter
            // 
            resources.ApplyResources(this.toolStripButtonProfileParameter, "toolStripButtonProfileParameter");
            this.toolStripButtonProfileParameter.Name = ("toolStripButtonProfileParameter");
            this.toolStripButtonProfileParameter.Click += (this.toolStripButtonProfileParameter_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = ("toolStripSeparator6");
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // toolStripButtonEquationOfState
            // 
            this.toolStripButtonEquationOfState.CheckOnClick = (true);
            resources.ApplyResources(this.toolStripButtonEquationOfState, "toolStripButtonEquationOfState");
            this.toolStripButtonEquationOfState.Name = ("toolStripButtonEquationOfState");
            this.toolStripButtonEquationOfState.CheckedChanged += (this.toolStripButtonEquationOfState_CheckedChanged);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = ("toolStripSeparator8");
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // toolStripButtonFittingParameter
            // 
            this.toolStripButtonFittingParameter.CheckOnClick = (true);
            resources.ApplyResources(this.toolStripButtonFittingParameter, "toolStripButtonFittingParameter");
            this.toolStripButtonFittingParameter.Name = ("toolStripButtonFittingParameter");
            this.toolStripButtonFittingParameter.CheckedChanged += (this.toolStripButtonFittingParameter_CheckedChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = ("toolStripSeparator5");
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripButtonCellFinder
            // 
            this.toolStripButtonCellFinder.CheckOnClick = (true);
            this.toolStripButtonCellFinder.DisplayStyle = (global::System.Windows.Forms.ToolStripItemDisplayStyle.Text);
            resources.ApplyResources(this.toolStripButtonCellFinder, "toolStripButtonCellFinder");
            this.toolStripButtonCellFinder.Name = ("toolStripButtonCellFinder");
            this.toolStripButtonCellFinder.CheckedChanged += (this.toolStripButtonCellFinder_CheckedChanged);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = ("toolStripSeparator11");
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // toolStripButtonSequentialAnalysis
            // 
            this.toolStripButtonSequentialAnalysis.CheckOnClick = (true);
            this.toolStripButtonSequentialAnalysis.DisplayStyle = (global::System.Windows.Forms.ToolStripItemDisplayStyle.Text);
            this.toolStripButtonSequentialAnalysis.Name = ("toolStripButtonSequentialAnalysis");
            resources.ApplyResources(this.toolStripButtonSequentialAnalysis, "toolStripButtonSequentialAnalysis");
            this.toolStripButtonSequentialAnalysis.CheckedChanged += (this.toolStripButtonStressAnalysis_CheckedChanged);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = ("toolStripSeparator10");
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // toolStripButtonAtomicPositonFinder
            // 
            this.toolStripButtonAtomicPositonFinder.CheckOnClick = (true);
            this.toolStripButtonAtomicPositonFinder.DisplayStyle = (global::System.Windows.Forms.ToolStripItemDisplayStyle.Text);
            resources.ApplyResources(this.toolStripButtonAtomicPositonFinder, "toolStripButtonAtomicPositonFinder");
            this.toolStripButtonAtomicPositonFinder.Name = ("toolStripButtonAtomicPositonFinder");
            this.toolStripButtonAtomicPositonFinder.CheckedChanged += (this.toolStripButtonAtomicPositonFinder_CheckedChanged);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = ("toolStripSeparator12");
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // toolStripButtonLPO
            // 
            this.toolStripButtonLPO.CheckOnClick = (true);
            this.toolStripButtonLPO.DisplayStyle = (global::System.Windows.Forms.ToolStripItemDisplayStyle.Text);
            resources.ApplyResources(this.toolStripButtonLPO, "toolStripButtonLPO");
            this.toolStripButtonLPO.Name = ("toolStripButtonLPO");
            this.toolStripButtonLPO.CheckedChanged += (this.toolStripButtonLPO_CheckedChanged);
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = (new global::System.Drawing.Size(32, 32));
            this.menuStrip.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem, this.optionToolStripMenuItem, this.macroToolStripMenuItem, this.helpToolStripMenuItem, this.languageToolStripMenuItem });
            this.menuStrip.Name = ("menuStrip");
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.readPatternProfileToolStripMenuItem, this.savePatternProfileToolStripMenuItem, this.toolStripMenuItemExportExcelFile, this.toolStripSeparator1, this.readCrystalDataToolStripMenuItem, this.readAndAddToolStripMenuItem, this.saveCrystalDataToolStripMenuItem, this.toolStripMenuItemImport, this.toolStripMenuItemExportCIF, this.resetInitialCrystalDataToolStripMenuItem, this.toolStripSeparator3, this.toolStripMenuItemPageSetup, this.toolStripMenuItemPrintPreview, this.printToolStripMenuItem, this.toolStripSeparator9, this.コピーToolStripMenuItem, this.toolStripMenuItemSaveMetafile, this.toolStripSeparator2, this.closeToolStripMenuItem });
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.Name = ("fileToolStripMenuItem");
            // 
            // readPatternProfileToolStripMenuItem
            // 
            this.readPatternProfileToolStripMenuItem.Name = ("readPatternProfileToolStripMenuItem");
            resources.ApplyResources(this.readPatternProfileToolStripMenuItem, "readPatternProfileToolStripMenuItem");
            this.readPatternProfileToolStripMenuItem.Click += (this.menuItemFileRead_Click);
            // 
            // savePatternProfileToolStripMenuItem
            // 
            this.savePatternProfileToolStripMenuItem.Name = ("savePatternProfileToolStripMenuItem");
            resources.ApplyResources(this.savePatternProfileToolStripMenuItem, "savePatternProfileToolStripMenuItem");
            this.savePatternProfileToolStripMenuItem.Click += (this.savePatternProfileToolStripMenuItem_Click);
            // 
            // toolStripMenuItemExportExcelFile
            // 
            this.toolStripMenuItemExportExcelFile.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.asCSVcommaSeperatedFileToolStripMenuItem, this.asTSVtabSeparatedValuesFileToolStripMenuItem, this.asGSASFileToolStripMenuItem });
            this.toolStripMenuItemExportExcelFile.Name = ("toolStripMenuItemExportExcelFile");
            resources.ApplyResources(this.toolStripMenuItemExportExcelFile, "toolStripMenuItemExportExcelFile");
            // 
            // asCSVcommaSeperatedFileToolStripMenuItem
            // 
            this.asCSVcommaSeperatedFileToolStripMenuItem.Name = ("asCSVcommaSeperatedFileToolStripMenuItem");
            resources.ApplyResources(this.asCSVcommaSeperatedFileToolStripMenuItem, "asCSVcommaSeperatedFileToolStripMenuItem");
            this.asCSVcommaSeperatedFileToolStripMenuItem.Click += (this.toolStripMenuItemExportCSVFile_Click);
            // 
            // asTSVtabSeparatedValuesFileToolStripMenuItem
            // 
            this.asTSVtabSeparatedValuesFileToolStripMenuItem.Name = ("asTSVtabSeparatedValuesFileToolStripMenuItem");
            resources.ApplyResources(this.asTSVtabSeparatedValuesFileToolStripMenuItem, "asTSVtabSeparatedValuesFileToolStripMenuItem");
            this.asTSVtabSeparatedValuesFileToolStripMenuItem.Click += (this.toolStripMenuItemExportCSVFile_Click);
            // 
            // asGSASFileToolStripMenuItem
            // 
            this.asGSASFileToolStripMenuItem.Name = ("asGSASFileToolStripMenuItem");
            resources.ApplyResources(this.asGSASFileToolStripMenuItem, "asGSASFileToolStripMenuItem");
            this.asGSASFileToolStripMenuItem.Click += (this.exportGSASFormatToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = ("toolStripSeparator1");
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // readCrystalDataToolStripMenuItem
            // 
            this.readCrystalDataToolStripMenuItem.Name = ("readCrystalDataToolStripMenuItem");
            resources.ApplyResources(this.readCrystalDataToolStripMenuItem, "readCrystalDataToolStripMenuItem");
            this.readCrystalDataToolStripMenuItem.Click += (this.menuItemReadCrystalData_Click);
            // 
            // readAndAddToolStripMenuItem
            // 
            this.readAndAddToolStripMenuItem.Name = ("readAndAddToolStripMenuItem");
            resources.ApplyResources(this.readAndAddToolStripMenuItem, "readAndAddToolStripMenuItem");
            this.readAndAddToolStripMenuItem.Click += (this.readAndAddToolStripMenuItem_Click);
            // 
            // saveCrystalDataToolStripMenuItem
            // 
            this.saveCrystalDataToolStripMenuItem.Name = ("saveCrystalDataToolStripMenuItem");
            resources.ApplyResources(this.saveCrystalDataToolStripMenuItem, "saveCrystalDataToolStripMenuItem");
            this.saveCrystalDataToolStripMenuItem.Click += (this.menuItemSaveCrystalData_Click);
            // 
            // toolStripMenuItemImport
            // 
            this.toolStripMenuItemImport.Name = ("toolStripMenuItemImport");
            resources.ApplyResources(this.toolStripMenuItemImport, "toolStripMenuItemImport");
            this.toolStripMenuItemImport.Click += (this.toolStripMenuItemImport_Click);
            // 
            // toolStripMenuItemExportCIF
            // 
            this.toolStripMenuItemExportCIF.Name = ("toolStripMenuItemExportCIF");
            resources.ApplyResources(this.toolStripMenuItemExportCIF, "toolStripMenuItemExportCIF");
            this.toolStripMenuItemExportCIF.Click += (this.toolStripMenuItemExportCIF_Click);
            // 
            // resetInitialCrystalDataToolStripMenuItem
            // 
            this.resetInitialCrystalDataToolStripMenuItem.Name = ("resetInitialCrystalDataToolStripMenuItem");
            resources.ApplyResources(this.resetInitialCrystalDataToolStripMenuItem, "resetInitialCrystalDataToolStripMenuItem");
            this.resetInitialCrystalDataToolStripMenuItem.Click += (this.resetInitialCrystalDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = ("toolStripSeparator3");
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripMenuItemPageSetup
            // 
            this.toolStripMenuItemPageSetup.Name = ("toolStripMenuItemPageSetup");
            resources.ApplyResources(this.toolStripMenuItemPageSetup, "toolStripMenuItemPageSetup");
            this.toolStripMenuItemPageSetup.Click += (this.menuItemPrintPageSetup_Click);
            // 
            // toolStripMenuItemPrintPreview
            // 
            this.toolStripMenuItemPrintPreview.Name = ("toolStripMenuItemPrintPreview");
            resources.ApplyResources(this.toolStripMenuItemPrintPreview, "toolStripMenuItemPrintPreview");
            this.toolStripMenuItemPrintPreview.Click += (this.menuItemPrintPreview_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = ("printToolStripMenuItem");
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.Click += (this.menuItemPrint_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = ("toolStripSeparator9");
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // コピーToolStripMenuItem
            // 
            this.コピーToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.BitmapToolStripMenuItem, this.copyAsMetafileToolStripMenuItem });
            this.コピーToolStripMenuItem.Name = ("コピーToolStripMenuItem");
            resources.ApplyResources(this.コピーToolStripMenuItem, "コピーToolStripMenuItem");
            // 
            // BitmapToolStripMenuItem
            // 
            resources.ApplyResources(this.BitmapToolStripMenuItem, "BitmapToolStripMenuItem");
            this.BitmapToolStripMenuItem.Name = ("BitmapToolStripMenuItem");
            // 
            // copyAsMetafileToolStripMenuItem
            // 
            this.copyAsMetafileToolStripMenuItem.Name = ("copyAsMetafileToolStripMenuItem");
            resources.ApplyResources(this.copyAsMetafileToolStripMenuItem, "copyAsMetafileToolStripMenuItem");
            this.copyAsMetafileToolStripMenuItem.Click += (this.copyAsMetafileToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSaveMetafile
            // 
            this.toolStripMenuItemSaveMetafile.Name = ("toolStripMenuItemSaveMetafile");
            resources.ApplyResources(this.toolStripMenuItemSaveMetafile, "toolStripMenuItemSaveMetafile");
            this.toolStripMenuItemSaveMetafile.Click += (this.toolStripMenuItemSaveMetafile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = ("toolStripSeparator2");
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = ("closeToolStripMenuItem");
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Click += (this.menuItemClose_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DisplayStyle = (global::System.Windows.Forms.ToolStripItemDisplayStyle.Text);
            this.optionToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.toolTipToolStripMenuItem, this.watchReadClipboardToolStripMenuItem, this.watchReadANewProfileToolStripMenuItem, this.clearRegistryToolStripMenuItem, this.automaticallySaveTheCrystalListToolStripMenuItem });
            resources.ApplyResources(this.optionToolStripMenuItem, "optionToolStripMenuItem");
            this.optionToolStripMenuItem.Margin = (new global::System.Windows.Forms.Padding(4));
            this.optionToolStripMenuItem.Name = ("optionToolStripMenuItem");
            // 
            // toolTipToolStripMenuItem
            // 
            this.toolTipToolStripMenuItem.Checked = (true);
            this.toolTipToolStripMenuItem.CheckOnClick = (true);
            this.toolTipToolStripMenuItem.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            resources.ApplyResources(this.toolTipToolStripMenuItem, "toolTipToolStripMenuItem");
            this.toolTipToolStripMenuItem.Name = ("toolTipToolStripMenuItem");
            this.toolTipToolStripMenuItem.Click += (this.toolTipToolStripMenuItem_Click);
            // 
            // watchReadClipboardToolStripMenuItem
            // 
            this.watchReadClipboardToolStripMenuItem.Checked = (true);
            this.watchReadClipboardToolStripMenuItem.CheckOnClick = (true);
            this.watchReadClipboardToolStripMenuItem.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.watchReadClipboardToolStripMenuItem.Name = ("watchReadClipboardToolStripMenuItem");
            resources.ApplyResources(this.watchReadClipboardToolStripMenuItem, "watchReadClipboardToolStripMenuItem");
            this.watchReadClipboardToolStripMenuItem.CheckedChanged += (this.watchReadClipboardToolStripMenuItem_CheckedChanged);
            // 
            // watchReadANewProfileToolStripMenuItem
            // 
            this.watchReadANewProfileToolStripMenuItem.CheckOnClick = (true);
            this.watchReadANewProfileToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.setDirectoryToTheWatchToolStripMenuItem, this.toolStripTextBoxDirectoryToWatch });
            this.watchReadANewProfileToolStripMenuItem.Name = ("watchReadANewProfileToolStripMenuItem");
            resources.ApplyResources(this.watchReadANewProfileToolStripMenuItem, "watchReadANewProfileToolStripMenuItem");
            this.watchReadANewProfileToolStripMenuItem.CheckedChanged += (this.watchReadANewProfileToolStripMenuItem_CheckedChanged);
            // 
            // setDirectoryToTheWatchToolStripMenuItem
            // 
            this.setDirectoryToTheWatchToolStripMenuItem.Name = ("setDirectoryToTheWatchToolStripMenuItem");
            resources.ApplyResources(this.setDirectoryToTheWatchToolStripMenuItem, "setDirectoryToTheWatchToolStripMenuItem");
            this.setDirectoryToTheWatchToolStripMenuItem.Click += (this.setDirectoryToTheWatchToolStripMenuItem_Click);
            // 
            // toolStripTextBoxDirectoryToWatch
            // 
            this.toolStripTextBoxDirectoryToWatch.Name = ("toolStripTextBoxDirectoryToWatch");
            resources.ApplyResources(this.toolStripTextBoxDirectoryToWatch, "toolStripTextBoxDirectoryToWatch");
            this.toolStripTextBoxDirectoryToWatch.TextChanged += (this.toolStripTextBoxDirectoryToWatch_TextChanged);
            // 
            // clearRegistryToolStripMenuItem
            // 
            this.clearRegistryToolStripMenuItem.CheckOnClick = (true);
            this.clearRegistryToolStripMenuItem.Name = ("clearRegistryToolStripMenuItem");
            resources.ApplyResources(this.clearRegistryToolStripMenuItem, "clearRegistryToolStripMenuItem");
            // 
            // automaticallySaveTheCrystalListToolStripMenuItem
            // 
            this.automaticallySaveTheCrystalListToolStripMenuItem.Checked = (true);
            this.automaticallySaveTheCrystalListToolStripMenuItem.CheckOnClick = (true);
            this.automaticallySaveTheCrystalListToolStripMenuItem.CheckState = (global::System.Windows.Forms.CheckState.Checked);
            this.automaticallySaveTheCrystalListToolStripMenuItem.DisplayStyle = (global::System.Windows.Forms.ToolStripItemDisplayStyle.Text);
            this.automaticallySaveTheCrystalListToolStripMenuItem.Name = ("automaticallySaveTheCrystalListToolStripMenuItem");
            resources.ApplyResources(this.automaticallySaveTheCrystalListToolStripMenuItem, "automaticallySaveTheCrystalListToolStripMenuItem");
            // 
            // macroToolStripMenuItem
            // 
            this.macroToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.editorToolStripMenuItem });
            this.macroToolStripMenuItem.Name = ("macroToolStripMenuItem");
            resources.ApplyResources(this.macroToolStripMenuItem, "macroToolStripMenuItem");
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.Name = ("editorToolStripMenuItem");
            resources.ApplyResources(this.editorToolStripMenuItem, "editorToolStripMenuItem");
            this.editorToolStripMenuItem.Click += (this.editorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.aboutMeToolStripMenuItem, this.programUpdatesToolStripMenuItem, this.hintToolStripMenuItem, this.helpwebToolStripMenuItem });
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Name = ("helpToolStripMenuItem");
            // 
            // aboutMeToolStripMenuItem
            // 
            this.aboutMeToolStripMenuItem.Name = ("aboutMeToolStripMenuItem");
            resources.ApplyResources(this.aboutMeToolStripMenuItem, "aboutMeToolStripMenuItem");
            this.aboutMeToolStripMenuItem.Click += (this.aboutMeToolStripMenuItem_Click);
            // 
            // programUpdatesToolStripMenuItem
            // 
            this.programUpdatesToolStripMenuItem.Name = ("programUpdatesToolStripMenuItem");
            resources.ApplyResources(this.programUpdatesToolStripMenuItem, "programUpdatesToolStripMenuItem");
            this.programUpdatesToolStripMenuItem.Click += (this.programUpdatesToolStripMenuItem_Click);
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.Name = ("hintToolStripMenuItem");
            resources.ApplyResources(this.hintToolStripMenuItem, "hintToolStripMenuItem");
            this.hintToolStripMenuItem.Click += (this.hintToolStripMenuItem_Click);
            // 
            // helpwebToolStripMenuItem
            // 
            this.helpwebToolStripMenuItem.Name = ("helpwebToolStripMenuItem");
            resources.ApplyResources(this.helpwebToolStripMenuItem, "helpwebToolStripMenuItem");
            this.helpwebToolStripMenuItem.Click += (this.helpwebToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Alignment = (global::System.Windows.Forms.ToolStripItemAlignment.Right);
            this.languageToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.englishToolStripMenuItem, this.japaneseToolStripMenuItem });
            this.languageToolStripMenuItem.Name = ("languageToolStripMenuItem");
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = ("englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += (this.languageToolStripMenuItem_Click);
            // 
            // japaneseToolStripMenuItem
            // 
            resources.ApplyResources(this.japaneseToolStripMenuItem, "japaneseToolStripMenuItem");
            this.japaneseToolStripMenuItem.Name = ("japaneseToolStripMenuItem");
            this.japaneseToolStripMenuItem.Click += (this.languageToolStripMenuItem_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = ("button2");
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = ("button3");
            // 
            // buttonAu
            // 
            resources.ApplyResources(this.buttonAu, "buttonAu");
            this.buttonAu.Name = ("buttonAu");
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = (10000);
            this.toolTip.InitialDelay = (500);
            this.toolTip.IsBalloon = (true);
            this.toolTip.ReshowDelay = (100);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = (true);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn1.DataPropertyName = ("Crystal");
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = ("dataGridViewTextBoxColumn1");
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = ("Crystal");
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = ("dataGridViewTextBoxColumn2");
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            this.checkDataGridViewCheckBoxColumn.DataPropertyName = ("Check");
            resources.ApplyResources(this.checkDataGridViewCheckBoxColumn, "checkDataGridViewCheckBoxColumn");
            this.checkDataGridViewCheckBoxColumn.Name = ("checkDataGridViewCheckBoxColumn");
            // 
            // Check
            // 
            this.Check.DataPropertyName = ("Check");
            resources.ApplyResources(this.Check, "Check");
            this.Check.Name = ("Check");
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn3.DataPropertyName = ("Crystal");
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = ("dataGridViewTextBoxColumn3");
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn4.DataPropertyName = ("Crystal");
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = ("dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn5.DataPropertyName = ("Crystal");
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = ("dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn6.DataPropertyName = ("Crystal");
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = ("dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn7.DataPropertyName = ("Crystal");
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = ("dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn8.DataPropertyName = ("Crystal");
            resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.Name = ("dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn9.DataPropertyName = ("Crystal");
            resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
            this.dataGridViewTextBoxColumn9.Name = ("dataGridViewTextBoxColumn9");
            this.dataGridViewTextBoxColumn9.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn10.DataPropertyName = ("Crystal");
            dataGridViewCellStyle8.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = (dataGridViewCellStyle8);
            resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
            this.dataGridViewTextBoxColumn10.Name = ("dataGridViewTextBoxColumn10");
            this.dataGridViewTextBoxColumn10.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn11.DataPropertyName = ("Crystal");
            dataGridViewCellStyle9.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = (dataGridViewCellStyle9);
            resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
            this.dataGridViewTextBoxColumn11.Name = ("dataGridViewTextBoxColumn11");
            this.dataGridViewTextBoxColumn11.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn12.DataPropertyName = ("Crystal");
            dataGridViewCellStyle10.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = (dataGridViewCellStyle10);
            resources.ApplyResources(this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
            this.dataGridViewTextBoxColumn12.Name = ("dataGridViewTextBoxColumn12");
            this.dataGridViewTextBoxColumn12.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn13.DataPropertyName = ("Crystal");
            dataGridViewCellStyle11.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = (dataGridViewCellStyle11);
            resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
            this.dataGridViewTextBoxColumn13.Name = ("dataGridViewTextBoxColumn13");
            this.dataGridViewTextBoxColumn13.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn14.DataPropertyName = ("Crystal");
            dataGridViewCellStyle12.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = (dataGridViewCellStyle12);
            resources.ApplyResources(this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
            this.dataGridViewTextBoxColumn14.Name = ("dataGridViewTextBoxColumn14");
            this.dataGridViewTextBoxColumn14.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn15.DataPropertyName = ("Crystal");
            dataGridViewCellStyle13.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = (dataGridViewCellStyle13);
            resources.ApplyResources(this.dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
            this.dataGridViewTextBoxColumn15.Name = ("dataGridViewTextBoxColumn15");
            this.dataGridViewTextBoxColumn15.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn16.DataPropertyName = ("Crystal");
            dataGridViewCellStyle14.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = (dataGridViewCellStyle14);
            resources.ApplyResources(this.dataGridViewTextBoxColumn16, "dataGridViewTextBoxColumn16");
            this.dataGridViewTextBoxColumn16.Name = ("dataGridViewTextBoxColumn16");
            this.dataGridViewTextBoxColumn16.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn17.DataPropertyName = ("Crystal");
            dataGridViewCellStyle15.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = (dataGridViewCellStyle15);
            resources.ApplyResources(this.dataGridViewTextBoxColumn17, "dataGridViewTextBoxColumn17");
            this.dataGridViewTextBoxColumn17.Name = ("dataGridViewTextBoxColumn17");
            this.dataGridViewTextBoxColumn17.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn18.DataPropertyName = ("Crystal");
            dataGridViewCellStyle16.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = (dataGridViewCellStyle16);
            resources.ApplyResources(this.dataGridViewTextBoxColumn18, "dataGridViewTextBoxColumn18");
            this.dataGridViewTextBoxColumn18.Name = ("dataGridViewTextBoxColumn18");
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn19.DataPropertyName = ("Crystal");
            dataGridViewCellStyle17.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = (dataGridViewCellStyle17);
            resources.ApplyResources(this.dataGridViewTextBoxColumn19, "dataGridViewTextBoxColumn19");
            this.dataGridViewTextBoxColumn19.Name = ("dataGridViewTextBoxColumn19");
            this.dataGridViewTextBoxColumn19.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn20.DataPropertyName = ("Crystal");
            dataGridViewCellStyle18.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn20.DefaultCellStyle = (dataGridViewCellStyle18);
            resources.ApplyResources(this.dataGridViewTextBoxColumn20, "dataGridViewTextBoxColumn20");
            this.dataGridViewTextBoxColumn20.Name = ("dataGridViewTextBoxColumn20");
            this.dataGridViewTextBoxColumn20.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn21.DataPropertyName = ("Crystal");
            dataGridViewCellStyle19.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn21.DefaultCellStyle = (dataGridViewCellStyle19);
            resources.ApplyResources(this.dataGridViewTextBoxColumn21, "dataGridViewTextBoxColumn21");
            this.dataGridViewTextBoxColumn21.Name = ("dataGridViewTextBoxColumn21");
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn22.DataPropertyName = ("Crystal");
            dataGridViewCellStyle20.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn22.DefaultCellStyle = (dataGridViewCellStyle20);
            resources.ApplyResources(this.dataGridViewTextBoxColumn22, "dataGridViewTextBoxColumn22");
            this.dataGridViewTextBoxColumn22.Name = ("dataGridViewTextBoxColumn22");
            this.dataGridViewTextBoxColumn22.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn23.DataPropertyName = ("Crystal");
            dataGridViewCellStyle21.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = (dataGridViewCellStyle21);
            resources.ApplyResources(this.dataGridViewTextBoxColumn23, "dataGridViewTextBoxColumn23");
            this.dataGridViewTextBoxColumn23.Name = ("dataGridViewTextBoxColumn23");
            this.dataGridViewTextBoxColumn23.ReadOnly = (true);
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewTextBoxColumn25, "dataGridViewTextBoxColumn25");
            this.dataGridViewTextBoxColumn25.Name = ("dataGridViewTextBoxColumn25");
            this.dataGridViewTextBoxColumn25.ReadOnly = (true);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.Name = ("dataGridViewImageColumn1");
            this.dataGridViewImageColumn1.ReadOnly = (true);
            this.dataGridViewImageColumn1.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn1.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn24.DataPropertyName = ("Crystal");
            dataGridViewCellStyle22.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = (dataGridViewCellStyle22);
            resources.ApplyResources(this.dataGridViewTextBoxColumn24, "dataGridViewTextBoxColumn24");
            this.dataGridViewTextBoxColumn24.Name = ("dataGridViewTextBoxColumn24");
            this.dataGridViewTextBoxColumn24.ReadOnly = (true);
            this.dataGridViewTextBoxColumn24.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn2, "dataGridViewImageColumn2");
            this.dataGridViewImageColumn2.Name = ("dataGridViewImageColumn2");
            this.dataGridViewImageColumn2.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn2.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn26.DataPropertyName = ("Crystal");
            dataGridViewCellStyle23.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn26.DefaultCellStyle = (dataGridViewCellStyle23);
            resources.ApplyResources(this.dataGridViewTextBoxColumn26, "dataGridViewTextBoxColumn26");
            this.dataGridViewTextBoxColumn26.Name = ("dataGridViewTextBoxColumn26");
            this.dataGridViewTextBoxColumn26.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn3, "dataGridViewImageColumn3");
            this.dataGridViewImageColumn3.Name = ("dataGridViewImageColumn3");
            this.dataGridViewImageColumn3.ReadOnly = (true);
            this.dataGridViewImageColumn3.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn3.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn27.DataPropertyName = ("Crystal");
            dataGridViewCellStyle24.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn27.DefaultCellStyle = (dataGridViewCellStyle24);
            resources.ApplyResources(this.dataGridViewTextBoxColumn27, "dataGridViewTextBoxColumn27");
            this.dataGridViewTextBoxColumn27.Name = ("dataGridViewTextBoxColumn27");
            this.dataGridViewTextBoxColumn27.ReadOnly = (true);
            this.dataGridViewTextBoxColumn27.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn30.DataPropertyName = ("Crystal");
            dataGridViewCellStyle25.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn30.DefaultCellStyle = (dataGridViewCellStyle25);
            resources.ApplyResources(this.dataGridViewTextBoxColumn30, "dataGridViewTextBoxColumn30");
            this.dataGridViewTextBoxColumn30.Name = ("dataGridViewTextBoxColumn30");
            this.dataGridViewTextBoxColumn30.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn4, "dataGridViewImageColumn4");
            this.dataGridViewImageColumn4.Name = ("dataGridViewImageColumn4");
            this.dataGridViewImageColumn4.ReadOnly = (true);
            this.dataGridViewImageColumn4.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn4.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn28.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn28, "dataGridViewTextBoxColumn28");
            this.dataGridViewTextBoxColumn28.Name = ("dataGridViewTextBoxColumn28");
            this.dataGridViewTextBoxColumn28.ReadOnly = (true);
            // 
            // dataGridViewImageColumn5
            // 
            this.dataGridViewImageColumn5.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn5, "dataGridViewImageColumn5");
            this.dataGridViewImageColumn5.Name = ("dataGridViewImageColumn5");
            this.dataGridViewImageColumn5.ReadOnly = (true);
            this.dataGridViewImageColumn5.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn5.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn29.DataPropertyName = ("Color");
            dataGridViewCellStyle26.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn29.DefaultCellStyle = (dataGridViewCellStyle26);
            resources.ApplyResources(this.dataGridViewTextBoxColumn29, "dataGridViewTextBoxColumn29");
            this.dataGridViewTextBoxColumn29.Name = ("dataGridViewTextBoxColumn29");
            this.dataGridViewTextBoxColumn29.ReadOnly = (true);
            this.dataGridViewTextBoxColumn29.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn6
            // 
            this.dataGridViewImageColumn6.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn6, "dataGridViewImageColumn6");
            this.dataGridViewImageColumn6.Name = ("dataGridViewImageColumn6");
            this.dataGridViewImageColumn6.ReadOnly = (true);
            this.dataGridViewImageColumn6.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn6.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn31.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn31, "dataGridViewTextBoxColumn31");
            this.dataGridViewTextBoxColumn31.Name = ("dataGridViewTextBoxColumn31");
            this.dataGridViewTextBoxColumn31.ReadOnly = (true);
            // 
            // dataGridViewImageColumn7
            // 
            this.dataGridViewImageColumn7.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn7, "dataGridViewImageColumn7");
            this.dataGridViewImageColumn7.Name = ("dataGridViewImageColumn7");
            this.dataGridViewImageColumn7.ReadOnly = (true);
            this.dataGridViewImageColumn7.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn7.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn32.DataPropertyName = ("Crystal");
            dataGridViewCellStyle27.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn32.DefaultCellStyle = (dataGridViewCellStyle27);
            resources.ApplyResources(this.dataGridViewTextBoxColumn32, "dataGridViewTextBoxColumn32");
            this.dataGridViewTextBoxColumn32.Name = ("dataGridViewTextBoxColumn32");
            this.dataGridViewTextBoxColumn32.ReadOnly = (true);
            this.dataGridViewTextBoxColumn32.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn8
            // 
            this.dataGridViewImageColumn8.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn8, "dataGridViewImageColumn8");
            this.dataGridViewImageColumn8.Name = ("dataGridViewImageColumn8");
            this.dataGridViewImageColumn8.ReadOnly = (true);
            this.dataGridViewImageColumn8.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn8.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn33.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn33, "dataGridViewTextBoxColumn33");
            this.dataGridViewTextBoxColumn33.Name = ("dataGridViewTextBoxColumn33");
            this.dataGridViewTextBoxColumn33.ReadOnly = (true);
            // 
            // dataGridViewImageColumn9
            // 
            this.dataGridViewImageColumn9.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn9, "dataGridViewImageColumn9");
            this.dataGridViewImageColumn9.Name = ("dataGridViewImageColumn9");
            this.dataGridViewImageColumn9.ReadOnly = (true);
            this.dataGridViewImageColumn9.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn9.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn34.DataPropertyName = ("Crystal");
            dataGridViewCellStyle28.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn34.DefaultCellStyle = (dataGridViewCellStyle28);
            resources.ApplyResources(this.dataGridViewTextBoxColumn34, "dataGridViewTextBoxColumn34");
            this.dataGridViewTextBoxColumn34.Name = ("dataGridViewTextBoxColumn34");
            this.dataGridViewTextBoxColumn34.ReadOnly = (true);
            this.dataGridViewTextBoxColumn34.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn10
            // 
            this.dataGridViewImageColumn10.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn10, "dataGridViewImageColumn10");
            this.dataGridViewImageColumn10.Name = ("dataGridViewImageColumn10");
            this.dataGridViewImageColumn10.ReadOnly = (true);
            this.dataGridViewImageColumn10.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn10.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn35.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn35, "dataGridViewTextBoxColumn35");
            this.dataGridViewTextBoxColumn35.Name = ("dataGridViewTextBoxColumn35");
            this.dataGridViewTextBoxColumn35.ReadOnly = (true);
            // 
            // dataGridViewImageColumn11
            // 
            this.dataGridViewImageColumn11.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn11, "dataGridViewImageColumn11");
            this.dataGridViewImageColumn11.Name = ("dataGridViewImageColumn11");
            this.dataGridViewImageColumn11.ReadOnly = (true);
            this.dataGridViewImageColumn11.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn11.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn36.DataPropertyName = ("Crystal");
            dataGridViewCellStyle29.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn36.DefaultCellStyle = (dataGridViewCellStyle29);
            resources.ApplyResources(this.dataGridViewTextBoxColumn36, "dataGridViewTextBoxColumn36");
            this.dataGridViewTextBoxColumn36.Name = ("dataGridViewTextBoxColumn36");
            this.dataGridViewTextBoxColumn36.ReadOnly = (true);
            this.dataGridViewTextBoxColumn36.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn12
            // 
            this.dataGridViewImageColumn12.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn12, "dataGridViewImageColumn12");
            this.dataGridViewImageColumn12.Name = ("dataGridViewImageColumn12");
            this.dataGridViewImageColumn12.ReadOnly = (true);
            this.dataGridViewImageColumn12.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn12.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn37.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn37, "dataGridViewTextBoxColumn37");
            this.dataGridViewTextBoxColumn37.Name = ("dataGridViewTextBoxColumn37");
            this.dataGridViewTextBoxColumn37.ReadOnly = (true);
            // 
            // dataGridViewImageColumn13
            // 
            this.dataGridViewImageColumn13.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn13, "dataGridViewImageColumn13");
            this.dataGridViewImageColumn13.Name = ("dataGridViewImageColumn13");
            this.dataGridViewImageColumn13.ReadOnly = (true);
            this.dataGridViewImageColumn13.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn13.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn38.DataPropertyName = ("Crystal");
            dataGridViewCellStyle30.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn38.DefaultCellStyle = (dataGridViewCellStyle30);
            resources.ApplyResources(this.dataGridViewTextBoxColumn38, "dataGridViewTextBoxColumn38");
            this.dataGridViewTextBoxColumn38.Name = ("dataGridViewTextBoxColumn38");
            this.dataGridViewTextBoxColumn38.ReadOnly = (true);
            this.dataGridViewTextBoxColumn38.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn15
            // 
            this.dataGridViewImageColumn15.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn15, "dataGridViewImageColumn15");
            this.dataGridViewImageColumn15.Name = ("dataGridViewImageColumn15");
            this.dataGridViewImageColumn15.ReadOnly = (true);
            this.dataGridViewImageColumn15.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn15.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn40.DataPropertyName = ("Crystal");
            dataGridViewCellStyle31.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn40.DefaultCellStyle = (dataGridViewCellStyle31);
            resources.ApplyResources(this.dataGridViewTextBoxColumn40, "dataGridViewTextBoxColumn40");
            this.dataGridViewTextBoxColumn40.Name = ("dataGridViewTextBoxColumn40");
            this.dataGridViewTextBoxColumn40.ReadOnly = (true);
            this.dataGridViewTextBoxColumn40.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn14
            // 
            this.dataGridViewImageColumn14.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn14, "dataGridViewImageColumn14");
            this.dataGridViewImageColumn14.Name = ("dataGridViewImageColumn14");
            this.dataGridViewImageColumn14.ReadOnly = (true);
            this.dataGridViewImageColumn14.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn14.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn39.DataPropertyName = ("Profile");
            dataGridViewCellStyle32.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn39.DefaultCellStyle = (dataGridViewCellStyle32);
            resources.ApplyResources(this.dataGridViewTextBoxColumn39, "dataGridViewTextBoxColumn39");
            this.dataGridViewTextBoxColumn39.Name = ("dataGridViewTextBoxColumn39");
            this.dataGridViewTextBoxColumn39.ReadOnly = (true);
            this.dataGridViewTextBoxColumn39.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn16
            // 
            this.dataGridViewImageColumn16.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn16, "dataGridViewImageColumn16");
            this.dataGridViewImageColumn16.Name = ("dataGridViewImageColumn16");
            this.dataGridViewImageColumn16.ReadOnly = (true);
            this.dataGridViewImageColumn16.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn16.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn41.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn41, "dataGridViewTextBoxColumn41");
            this.dataGridViewTextBoxColumn41.Name = ("dataGridViewTextBoxColumn41");
            this.dataGridViewTextBoxColumn41.ReadOnly = (true);
            // 
            // dataGridViewImageColumn17
            // 
            this.dataGridViewImageColumn17.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn17, "dataGridViewImageColumn17");
            this.dataGridViewImageColumn17.Name = ("dataGridViewImageColumn17");
            this.dataGridViewImageColumn17.ReadOnly = (true);
            this.dataGridViewImageColumn17.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn17.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn42.DataPropertyName = ("Crystal");
            dataGridViewCellStyle33.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn42.DefaultCellStyle = (dataGridViewCellStyle33);
            resources.ApplyResources(this.dataGridViewTextBoxColumn42, "dataGridViewTextBoxColumn42");
            this.dataGridViewTextBoxColumn42.Name = ("dataGridViewTextBoxColumn42");
            this.dataGridViewTextBoxColumn42.ReadOnly = (true);
            this.dataGridViewTextBoxColumn42.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn19
            // 
            this.dataGridViewImageColumn19.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn19, "dataGridViewImageColumn19");
            this.dataGridViewImageColumn19.Name = ("dataGridViewImageColumn19");
            this.dataGridViewImageColumn19.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn19.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn44.DataPropertyName = ("Crystal");
            dataGridViewCellStyle34.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn44.DefaultCellStyle = (dataGridViewCellStyle34);
            resources.ApplyResources(this.dataGridViewTextBoxColumn44, "dataGridViewTextBoxColumn44");
            this.dataGridViewTextBoxColumn44.Name = ("dataGridViewTextBoxColumn44");
            this.dataGridViewTextBoxColumn44.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn18
            // 
            this.dataGridViewImageColumn18.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn18, "dataGridViewImageColumn18");
            this.dataGridViewImageColumn18.Name = ("dataGridViewImageColumn18");
            this.dataGridViewImageColumn18.ReadOnly = (true);
            this.dataGridViewImageColumn18.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn18.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn43.DataPropertyName = ("Profile");
            dataGridViewCellStyle35.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn43.DefaultCellStyle = (dataGridViewCellStyle35);
            resources.ApplyResources(this.dataGridViewTextBoxColumn43, "dataGridViewTextBoxColumn43");
            this.dataGridViewTextBoxColumn43.Name = ("dataGridViewTextBoxColumn43");
            this.dataGridViewTextBoxColumn43.ReadOnly = (true);
            this.dataGridViewTextBoxColumn43.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn20
            // 
            this.dataGridViewImageColumn20.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn20, "dataGridViewImageColumn20");
            this.dataGridViewImageColumn20.Name = ("dataGridViewImageColumn20");
            this.dataGridViewImageColumn20.ReadOnly = (true);
            this.dataGridViewImageColumn20.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn20.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn45.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn45, "dataGridViewTextBoxColumn45");
            this.dataGridViewTextBoxColumn45.Name = ("dataGridViewTextBoxColumn45");
            this.dataGridViewTextBoxColumn45.ReadOnly = (true);
            // 
            // dataGridViewImageColumn21
            // 
            this.dataGridViewImageColumn21.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn21, "dataGridViewImageColumn21");
            this.dataGridViewImageColumn21.Name = ("dataGridViewImageColumn21");
            this.dataGridViewImageColumn21.ReadOnly = (true);
            this.dataGridViewImageColumn21.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn21.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn46.DataPropertyName = ("Crystal");
            dataGridViewCellStyle36.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn46.DefaultCellStyle = (dataGridViewCellStyle36);
            resources.ApplyResources(this.dataGridViewTextBoxColumn46, "dataGridViewTextBoxColumn46");
            this.dataGridViewTextBoxColumn46.Name = ("dataGridViewTextBoxColumn46");
            this.dataGridViewTextBoxColumn46.ReadOnly = (true);
            this.dataGridViewTextBoxColumn46.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn22
            // 
            this.dataGridViewImageColumn22.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn22, "dataGridViewImageColumn22");
            this.dataGridViewImageColumn22.Name = ("dataGridViewImageColumn22");
            this.dataGridViewImageColumn22.ReadOnly = (true);
            this.dataGridViewImageColumn22.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn22.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn47.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn47, "dataGridViewTextBoxColumn47");
            this.dataGridViewTextBoxColumn47.Name = ("dataGridViewTextBoxColumn47");
            this.dataGridViewTextBoxColumn47.ReadOnly = (true);
            // 
            // dataGridViewImageColumn23
            // 
            this.dataGridViewImageColumn23.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn23, "dataGridViewImageColumn23");
            this.dataGridViewImageColumn23.Name = ("dataGridViewImageColumn23");
            this.dataGridViewImageColumn23.ReadOnly = (true);
            this.dataGridViewImageColumn23.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn23.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn48.DataPropertyName = ("Crystal");
            dataGridViewCellStyle37.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn48.DefaultCellStyle = (dataGridViewCellStyle37);
            resources.ApplyResources(this.dataGridViewTextBoxColumn48, "dataGridViewTextBoxColumn48");
            this.dataGridViewTextBoxColumn48.Name = ("dataGridViewTextBoxColumn48");
            this.dataGridViewTextBoxColumn48.ReadOnly = (true);
            this.dataGridViewTextBoxColumn48.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn24
            // 
            this.dataGridViewImageColumn24.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn24, "dataGridViewImageColumn24");
            this.dataGridViewImageColumn24.Name = ("dataGridViewImageColumn24");
            this.dataGridViewImageColumn24.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn24.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn49.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn49, "dataGridViewTextBoxColumn49");
            this.dataGridViewTextBoxColumn49.Name = ("dataGridViewTextBoxColumn49");
            // 
            // dataGridViewImageColumn25
            // 
            this.dataGridViewImageColumn25.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn25, "dataGridViewImageColumn25");
            this.dataGridViewImageColumn25.Name = ("dataGridViewImageColumn25");
            this.dataGridViewImageColumn25.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn25.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn50.DataPropertyName = ("Crystal");
            dataGridViewCellStyle38.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn50.DefaultCellStyle = (dataGridViewCellStyle38);
            resources.ApplyResources(this.dataGridViewTextBoxColumn50, "dataGridViewTextBoxColumn50");
            this.dataGridViewTextBoxColumn50.Name = ("dataGridViewTextBoxColumn50");
            this.dataGridViewTextBoxColumn50.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn26
            // 
            this.dataGridViewImageColumn26.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn26, "dataGridViewImageColumn26");
            this.dataGridViewImageColumn26.Name = ("dataGridViewImageColumn26");
            this.dataGridViewImageColumn26.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn26.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn51.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn51, "dataGridViewTextBoxColumn51");
            this.dataGridViewTextBoxColumn51.Name = ("dataGridViewTextBoxColumn51");
            // 
            // dataGridViewImageColumn27
            // 
            this.dataGridViewImageColumn27.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn27, "dataGridViewImageColumn27");
            this.dataGridViewImageColumn27.Name = ("dataGridViewImageColumn27");
            this.dataGridViewImageColumn27.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn27.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn52.DataPropertyName = ("Crystal");
            dataGridViewCellStyle39.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn52.DefaultCellStyle = (dataGridViewCellStyle39);
            resources.ApplyResources(this.dataGridViewTextBoxColumn52, "dataGridViewTextBoxColumn52");
            this.dataGridViewTextBoxColumn52.Name = ("dataGridViewTextBoxColumn52");
            this.dataGridViewTextBoxColumn52.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn29
            // 
            this.dataGridViewImageColumn29.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn29, "dataGridViewImageColumn29");
            this.dataGridViewImageColumn29.Name = ("dataGridViewImageColumn29");
            this.dataGridViewImageColumn29.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn29.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn54.DataPropertyName = ("Crystal");
            dataGridViewCellStyle40.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn54.DefaultCellStyle = (dataGridViewCellStyle40);
            resources.ApplyResources(this.dataGridViewTextBoxColumn54, "dataGridViewTextBoxColumn54");
            this.dataGridViewTextBoxColumn54.Name = ("dataGridViewTextBoxColumn54");
            this.dataGridViewTextBoxColumn54.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn28
            // 
            this.dataGridViewImageColumn28.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn28, "dataGridViewImageColumn28");
            this.dataGridViewImageColumn28.Name = ("dataGridViewImageColumn28");
            this.dataGridViewImageColumn28.ReadOnly = (true);
            this.dataGridViewImageColumn28.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn28.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn53.DataPropertyName = ("Profile");
            dataGridViewCellStyle41.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn53.DefaultCellStyle = (dataGridViewCellStyle41);
            resources.ApplyResources(this.dataGridViewTextBoxColumn53, "dataGridViewTextBoxColumn53");
            this.dataGridViewTextBoxColumn53.Name = ("dataGridViewTextBoxColumn53");
            this.dataGridViewTextBoxColumn53.ReadOnly = (true);
            this.dataGridViewTextBoxColumn53.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn30
            // 
            this.dataGridViewImageColumn30.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn30, "dataGridViewImageColumn30");
            this.dataGridViewImageColumn30.Name = ("dataGridViewImageColumn30");
            this.dataGridViewImageColumn30.ReadOnly = (true);
            this.dataGridViewImageColumn30.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn30.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn55
            // 
            this.dataGridViewTextBoxColumn55.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn55.DataPropertyName = ("Profile");
            dataGridViewCellStyle42.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn55.DefaultCellStyle = (dataGridViewCellStyle42);
            resources.ApplyResources(this.dataGridViewTextBoxColumn55, "dataGridViewTextBoxColumn55");
            this.dataGridViewTextBoxColumn55.Name = ("dataGridViewTextBoxColumn55");
            this.dataGridViewTextBoxColumn55.ReadOnly = (true);
            this.dataGridViewTextBoxColumn55.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn31
            // 
            this.dataGridViewImageColumn31.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn31, "dataGridViewImageColumn31");
            this.dataGridViewImageColumn31.Name = ("dataGridViewImageColumn31");
            this.dataGridViewImageColumn31.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn31.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn56
            // 
            this.dataGridViewTextBoxColumn56.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn56.DataPropertyName = ("Crystal");
            dataGridViewCellStyle43.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn56.DefaultCellStyle = (dataGridViewCellStyle43);
            resources.ApplyResources(this.dataGridViewTextBoxColumn56, "dataGridViewTextBoxColumn56");
            this.dataGridViewTextBoxColumn56.Name = ("dataGridViewTextBoxColumn56");
            this.dataGridViewTextBoxColumn56.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn32
            // 
            this.dataGridViewImageColumn32.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn32, "dataGridViewImageColumn32");
            this.dataGridViewImageColumn32.Name = ("dataGridViewImageColumn32");
            this.dataGridViewImageColumn32.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn32.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn57.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn57, "dataGridViewTextBoxColumn57");
            this.dataGridViewTextBoxColumn57.Name = ("dataGridViewTextBoxColumn57");
            // 
            // dataGridViewImageColumn33
            // 
            this.dataGridViewImageColumn33.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn33, "dataGridViewImageColumn33");
            this.dataGridViewImageColumn33.Name = ("dataGridViewImageColumn33");
            this.dataGridViewImageColumn33.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn33.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn58
            // 
            this.dataGridViewTextBoxColumn58.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn58.DataPropertyName = ("Crystal");
            dataGridViewCellStyle44.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn58.DefaultCellStyle = (dataGridViewCellStyle44);
            resources.ApplyResources(this.dataGridViewTextBoxColumn58, "dataGridViewTextBoxColumn58");
            this.dataGridViewTextBoxColumn58.Name = ("dataGridViewTextBoxColumn58");
            this.dataGridViewTextBoxColumn58.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn34
            // 
            this.dataGridViewImageColumn34.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn34, "dataGridViewImageColumn34");
            this.dataGridViewImageColumn34.Name = ("dataGridViewImageColumn34");
            this.dataGridViewImageColumn34.ReadOnly = (true);
            this.dataGridViewImageColumn34.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn34.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn59
            // 
            this.dataGridViewTextBoxColumn59.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn59.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn59, "dataGridViewTextBoxColumn59");
            this.dataGridViewTextBoxColumn59.Name = ("dataGridViewTextBoxColumn59");
            this.dataGridViewTextBoxColumn59.ReadOnly = (true);
            // 
            // dataGridViewImageColumn35
            // 
            this.dataGridViewImageColumn35.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn35, "dataGridViewImageColumn35");
            this.dataGridViewImageColumn35.Name = ("dataGridViewImageColumn35");
            this.dataGridViewImageColumn35.ReadOnly = (true);
            this.dataGridViewImageColumn35.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn35.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn60.DataPropertyName = ("Crystal");
            dataGridViewCellStyle45.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn60.DefaultCellStyle = (dataGridViewCellStyle45);
            resources.ApplyResources(this.dataGridViewTextBoxColumn60, "dataGridViewTextBoxColumn60");
            this.dataGridViewTextBoxColumn60.Name = ("dataGridViewTextBoxColumn60");
            this.dataGridViewTextBoxColumn60.ReadOnly = (true);
            this.dataGridViewTextBoxColumn60.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn36
            // 
            this.dataGridViewImageColumn36.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn36, "dataGridViewImageColumn36");
            this.dataGridViewImageColumn36.Name = ("dataGridViewImageColumn36");
            this.dataGridViewImageColumn36.ReadOnly = (true);
            this.dataGridViewImageColumn36.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn36.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn61
            // 
            this.dataGridViewTextBoxColumn61.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn61.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn61, "dataGridViewTextBoxColumn61");
            this.dataGridViewTextBoxColumn61.Name = ("dataGridViewTextBoxColumn61");
            this.dataGridViewTextBoxColumn61.ReadOnly = (true);
            // 
            // dataGridViewImageColumn37
            // 
            this.dataGridViewImageColumn37.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn37, "dataGridViewImageColumn37");
            this.dataGridViewImageColumn37.Name = ("dataGridViewImageColumn37");
            this.dataGridViewImageColumn37.ReadOnly = (true);
            this.dataGridViewImageColumn37.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn37.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn62
            // 
            this.dataGridViewTextBoxColumn62.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn62.DataPropertyName = ("Crystal");
            dataGridViewCellStyle46.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn62.DefaultCellStyle = (dataGridViewCellStyle46);
            resources.ApplyResources(this.dataGridViewTextBoxColumn62, "dataGridViewTextBoxColumn62");
            this.dataGridViewTextBoxColumn62.Name = ("dataGridViewTextBoxColumn62");
            this.dataGridViewTextBoxColumn62.ReadOnly = (true);
            this.dataGridViewTextBoxColumn62.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn38
            // 
            this.dataGridViewImageColumn38.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn38, "dataGridViewImageColumn38");
            this.dataGridViewImageColumn38.Name = ("dataGridViewImageColumn38");
            this.dataGridViewImageColumn38.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn38.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn63
            // 
            this.dataGridViewTextBoxColumn63.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn63.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn63, "dataGridViewTextBoxColumn63");
            this.dataGridViewTextBoxColumn63.Name = ("dataGridViewTextBoxColumn63");
            // 
            // dataGridViewImageColumn39
            // 
            this.dataGridViewImageColumn39.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn39, "dataGridViewImageColumn39");
            this.dataGridViewImageColumn39.Name = ("dataGridViewImageColumn39");
            this.dataGridViewImageColumn39.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn39.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn64
            // 
            this.dataGridViewTextBoxColumn64.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn64.DataPropertyName = ("Crystal");
            dataGridViewCellStyle47.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn64.DefaultCellStyle = (dataGridViewCellStyle47);
            resources.ApplyResources(this.dataGridViewTextBoxColumn64, "dataGridViewTextBoxColumn64");
            this.dataGridViewTextBoxColumn64.Name = ("dataGridViewTextBoxColumn64");
            this.dataGridViewTextBoxColumn64.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn40
            // 
            this.dataGridViewImageColumn40.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn40, "dataGridViewImageColumn40");
            this.dataGridViewImageColumn40.Name = ("dataGridViewImageColumn40");
            this.dataGridViewImageColumn40.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn40.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn65
            // 
            this.dataGridViewTextBoxColumn65.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn65.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn65, "dataGridViewTextBoxColumn65");
            this.dataGridViewTextBoxColumn65.Name = ("dataGridViewTextBoxColumn65");
            // 
            // dataGridViewImageColumn41
            // 
            this.dataGridViewImageColumn41.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn41, "dataGridViewImageColumn41");
            this.dataGridViewImageColumn41.Name = ("dataGridViewImageColumn41");
            this.dataGridViewImageColumn41.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn41.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn66
            // 
            this.dataGridViewTextBoxColumn66.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn66.DataPropertyName = ("Crystal");
            dataGridViewCellStyle48.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn66.DefaultCellStyle = (dataGridViewCellStyle48);
            resources.ApplyResources(this.dataGridViewTextBoxColumn66, "dataGridViewTextBoxColumn66");
            this.dataGridViewTextBoxColumn66.Name = ("dataGridViewTextBoxColumn66");
            this.dataGridViewTextBoxColumn66.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn42
            // 
            this.dataGridViewImageColumn42.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn42, "dataGridViewImageColumn42");
            this.dataGridViewImageColumn42.Name = ("dataGridViewImageColumn42");
            this.dataGridViewImageColumn42.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn42.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn67
            // 
            this.dataGridViewTextBoxColumn67.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn67.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn67, "dataGridViewTextBoxColumn67");
            this.dataGridViewTextBoxColumn67.Name = ("dataGridViewTextBoxColumn67");
            // 
            // dataGridViewImageColumn43
            // 
            this.dataGridViewImageColumn43.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn43, "dataGridViewImageColumn43");
            this.dataGridViewImageColumn43.Name = ("dataGridViewImageColumn43");
            this.dataGridViewImageColumn43.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn43.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn68
            // 
            this.dataGridViewTextBoxColumn68.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn68.DataPropertyName = ("Crystal");
            dataGridViewCellStyle49.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn68.DefaultCellStyle = (dataGridViewCellStyle49);
            resources.ApplyResources(this.dataGridViewTextBoxColumn68, "dataGridViewTextBoxColumn68");
            this.dataGridViewTextBoxColumn68.Name = ("dataGridViewTextBoxColumn68");
            this.dataGridViewTextBoxColumn68.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn44
            // 
            this.dataGridViewImageColumn44.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn44, "dataGridViewImageColumn44");
            this.dataGridViewImageColumn44.Name = ("dataGridViewImageColumn44");
            this.dataGridViewImageColumn44.ReadOnly = (true);
            this.dataGridViewImageColumn44.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn44.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn69
            // 
            this.dataGridViewTextBoxColumn69.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn69.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn69, "dataGridViewTextBoxColumn69");
            this.dataGridViewTextBoxColumn69.Name = ("dataGridViewTextBoxColumn69");
            this.dataGridViewTextBoxColumn69.ReadOnly = (true);
            // 
            // dataGridViewImageColumn45
            // 
            this.dataGridViewImageColumn45.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn45, "dataGridViewImageColumn45");
            this.dataGridViewImageColumn45.Name = ("dataGridViewImageColumn45");
            this.dataGridViewImageColumn45.ReadOnly = (true);
            this.dataGridViewImageColumn45.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn45.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn70
            // 
            this.dataGridViewTextBoxColumn70.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn70.DataPropertyName = ("Crystal");
            dataGridViewCellStyle50.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn70.DefaultCellStyle = (dataGridViewCellStyle50);
            resources.ApplyResources(this.dataGridViewTextBoxColumn70, "dataGridViewTextBoxColumn70");
            this.dataGridViewTextBoxColumn70.Name = ("dataGridViewTextBoxColumn70");
            this.dataGridViewTextBoxColumn70.ReadOnly = (true);
            this.dataGridViewTextBoxColumn70.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn46
            // 
            this.dataGridViewImageColumn46.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn46, "dataGridViewImageColumn46");
            this.dataGridViewImageColumn46.Name = ("dataGridViewImageColumn46");
            this.dataGridViewImageColumn46.ReadOnly = (true);
            this.dataGridViewImageColumn46.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn46.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn71
            // 
            this.dataGridViewTextBoxColumn71.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn71.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn71, "dataGridViewTextBoxColumn71");
            this.dataGridViewTextBoxColumn71.Name = ("dataGridViewTextBoxColumn71");
            this.dataGridViewTextBoxColumn71.ReadOnly = (true);
            // 
            // dataGridViewImageColumn47
            // 
            this.dataGridViewImageColumn47.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn47, "dataGridViewImageColumn47");
            this.dataGridViewImageColumn47.Name = ("dataGridViewImageColumn47");
            this.dataGridViewImageColumn47.ReadOnly = (true);
            this.dataGridViewImageColumn47.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn47.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn72
            // 
            this.dataGridViewTextBoxColumn72.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn72.DataPropertyName = ("Crystal");
            dataGridViewCellStyle51.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn72.DefaultCellStyle = (dataGridViewCellStyle51);
            resources.ApplyResources(this.dataGridViewTextBoxColumn72, "dataGridViewTextBoxColumn72");
            this.dataGridViewTextBoxColumn72.Name = ("dataGridViewTextBoxColumn72");
            this.dataGridViewTextBoxColumn72.ReadOnly = (true);
            this.dataGridViewTextBoxColumn72.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn48
            // 
            this.dataGridViewImageColumn48.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn48, "dataGridViewImageColumn48");
            this.dataGridViewImageColumn48.Name = ("dataGridViewImageColumn48");
            this.dataGridViewImageColumn48.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn48.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn73
            // 
            this.dataGridViewTextBoxColumn73.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn73.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn73, "dataGridViewTextBoxColumn73");
            this.dataGridViewTextBoxColumn73.Name = ("dataGridViewTextBoxColumn73");
            // 
            // dataGridViewImageColumn49
            // 
            this.dataGridViewImageColumn49.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn49, "dataGridViewImageColumn49");
            this.dataGridViewImageColumn49.Name = ("dataGridViewImageColumn49");
            this.dataGridViewImageColumn49.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn49.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn74
            // 
            this.dataGridViewTextBoxColumn74.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn74.DataPropertyName = ("Crystal");
            dataGridViewCellStyle52.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn74.DefaultCellStyle = (dataGridViewCellStyle52);
            resources.ApplyResources(this.dataGridViewTextBoxColumn74, "dataGridViewTextBoxColumn74");
            this.dataGridViewTextBoxColumn74.Name = ("dataGridViewTextBoxColumn74");
            this.dataGridViewTextBoxColumn74.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // timerBlinkDiffraction
            // 
            this.timerBlinkDiffraction.Interval = (400);
            this.timerBlinkDiffraction.Tick += (this.timerBlinkDiffraction_Tick);
            // 
            // dataGridViewImageColumn51
            // 
            this.dataGridViewImageColumn51.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn51, "dataGridViewImageColumn51");
            this.dataGridViewImageColumn51.Name = ("dataGridViewImageColumn51");
            this.dataGridViewImageColumn51.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn51.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn76
            // 
            this.dataGridViewTextBoxColumn76.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn76.DataPropertyName = ("Crystal");
            dataGridViewCellStyle53.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn76.DefaultCellStyle = (dataGridViewCellStyle53);
            resources.ApplyResources(this.dataGridViewTextBoxColumn76, "dataGridViewTextBoxColumn76");
            this.dataGridViewTextBoxColumn76.Name = ("dataGridViewTextBoxColumn76");
            this.dataGridViewTextBoxColumn76.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn52
            // 
            this.dataGridViewImageColumn52.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn52, "dataGridViewImageColumn52");
            this.dataGridViewImageColumn52.Name = ("dataGridViewImageColumn52");
            this.dataGridViewImageColumn52.ReadOnly = (true);
            this.dataGridViewImageColumn52.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn52.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn77
            // 
            this.dataGridViewTextBoxColumn77.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn77.DataPropertyName = ("Crystal");
            dataGridViewCellStyle54.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn77.DefaultCellStyle = (dataGridViewCellStyle54);
            resources.ApplyResources(this.dataGridViewTextBoxColumn77, "dataGridViewTextBoxColumn77");
            this.dataGridViewTextBoxColumn77.Name = ("dataGridViewTextBoxColumn77");
            this.dataGridViewTextBoxColumn77.ReadOnly = (true);
            this.dataGridViewTextBoxColumn77.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn50
            // 
            this.dataGridViewImageColumn50.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn50, "dataGridViewImageColumn50");
            this.dataGridViewImageColumn50.Name = ("dataGridViewImageColumn50");
            this.dataGridViewImageColumn50.ReadOnly = (true);
            this.dataGridViewImageColumn50.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn50.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn75
            // 
            this.dataGridViewTextBoxColumn75.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn75.DataPropertyName = ("Profile");
            dataGridViewCellStyle55.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn75.DefaultCellStyle = (dataGridViewCellStyle55);
            resources.ApplyResources(this.dataGridViewTextBoxColumn75, "dataGridViewTextBoxColumn75");
            this.dataGridViewTextBoxColumn75.Name = ("dataGridViewTextBoxColumn75");
            this.dataGridViewTextBoxColumn75.ReadOnly = (true);
            this.dataGridViewTextBoxColumn75.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn53
            // 
            this.dataGridViewImageColumn53.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn53, "dataGridViewImageColumn53");
            this.dataGridViewImageColumn53.Name = ("dataGridViewImageColumn53");
            this.dataGridViewImageColumn53.ReadOnly = (true);
            this.dataGridViewImageColumn53.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn53.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn78
            // 
            this.dataGridViewTextBoxColumn78.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn78.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn78, "dataGridViewTextBoxColumn78");
            this.dataGridViewTextBoxColumn78.Name = ("dataGridViewTextBoxColumn78");
            this.dataGridViewTextBoxColumn78.ReadOnly = (true);
            // 
            // dataGridViewImageColumn54
            // 
            this.dataGridViewImageColumn54.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn54, "dataGridViewImageColumn54");
            this.dataGridViewImageColumn54.Name = ("dataGridViewImageColumn54");
            this.dataGridViewImageColumn54.ReadOnly = (true);
            this.dataGridViewImageColumn54.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn54.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn79
            // 
            this.dataGridViewTextBoxColumn79.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn79.DataPropertyName = ("Crystal");
            dataGridViewCellStyle56.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn79.DefaultCellStyle = (dataGridViewCellStyle56);
            resources.ApplyResources(this.dataGridViewTextBoxColumn79, "dataGridViewTextBoxColumn79");
            this.dataGridViewTextBoxColumn79.Name = ("dataGridViewTextBoxColumn79");
            this.dataGridViewTextBoxColumn79.ReadOnly = (true);
            this.dataGridViewTextBoxColumn79.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn55
            // 
            this.dataGridViewImageColumn55.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn55, "dataGridViewImageColumn55");
            this.dataGridViewImageColumn55.Name = ("dataGridViewImageColumn55");
            this.dataGridViewImageColumn55.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn55.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn80
            // 
            this.dataGridViewTextBoxColumn80.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn80.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn80, "dataGridViewTextBoxColumn80");
            this.dataGridViewTextBoxColumn80.Name = ("dataGridViewTextBoxColumn80");
            // 
            // dataGridViewImageColumn56
            // 
            this.dataGridViewImageColumn56.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn56, "dataGridViewImageColumn56");
            this.dataGridViewImageColumn56.Name = ("dataGridViewImageColumn56");
            this.dataGridViewImageColumn56.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn56.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn81
            // 
            this.dataGridViewTextBoxColumn81.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn81.DataPropertyName = ("Crystal");
            dataGridViewCellStyle57.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn81.DefaultCellStyle = (dataGridViewCellStyle57);
            resources.ApplyResources(this.dataGridViewTextBoxColumn81, "dataGridViewTextBoxColumn81");
            this.dataGridViewTextBoxColumn81.Name = ("dataGridViewTextBoxColumn81");
            this.dataGridViewTextBoxColumn81.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn57
            // 
            this.dataGridViewImageColumn57.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn57, "dataGridViewImageColumn57");
            this.dataGridViewImageColumn57.Name = ("dataGridViewImageColumn57");
            this.dataGridViewImageColumn57.ReadOnly = (true);
            this.dataGridViewImageColumn57.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn57.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn82
            // 
            this.dataGridViewTextBoxColumn82.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn82.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn82, "dataGridViewTextBoxColumn82");
            this.dataGridViewTextBoxColumn82.Name = ("dataGridViewTextBoxColumn82");
            this.dataGridViewTextBoxColumn82.ReadOnly = (true);
            // 
            // dataGridViewImageColumn58
            // 
            this.dataGridViewImageColumn58.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn58, "dataGridViewImageColumn58");
            this.dataGridViewImageColumn58.Name = ("dataGridViewImageColumn58");
            this.dataGridViewImageColumn58.ReadOnly = (true);
            this.dataGridViewImageColumn58.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn58.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn83
            // 
            this.dataGridViewTextBoxColumn83.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn83.DataPropertyName = ("Crystal");
            dataGridViewCellStyle58.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn83.DefaultCellStyle = (dataGridViewCellStyle58);
            resources.ApplyResources(this.dataGridViewTextBoxColumn83, "dataGridViewTextBoxColumn83");
            this.dataGridViewTextBoxColumn83.Name = ("dataGridViewTextBoxColumn83");
            this.dataGridViewTextBoxColumn83.ReadOnly = (true);
            this.dataGridViewTextBoxColumn83.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn59
            // 
            this.dataGridViewImageColumn59.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn59, "dataGridViewImageColumn59");
            this.dataGridViewImageColumn59.Name = ("dataGridViewImageColumn59");
            this.dataGridViewImageColumn59.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn59.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn84
            // 
            this.dataGridViewTextBoxColumn84.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn84.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn84, "dataGridViewTextBoxColumn84");
            this.dataGridViewTextBoxColumn84.Name = ("dataGridViewTextBoxColumn84");
            // 
            // dataGridViewImageColumn60
            // 
            this.dataGridViewImageColumn60.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn60, "dataGridViewImageColumn60");
            this.dataGridViewImageColumn60.Name = ("dataGridViewImageColumn60");
            this.dataGridViewImageColumn60.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn60.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn85
            // 
            this.dataGridViewTextBoxColumn85.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn85.DataPropertyName = ("Crystal");
            dataGridViewCellStyle59.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn85.DefaultCellStyle = (dataGridViewCellStyle59);
            resources.ApplyResources(this.dataGridViewTextBoxColumn85, "dataGridViewTextBoxColumn85");
            this.dataGridViewTextBoxColumn85.Name = ("dataGridViewTextBoxColumn85");
            this.dataGridViewTextBoxColumn85.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn61
            // 
            this.dataGridViewImageColumn61.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn61, "dataGridViewImageColumn61");
            this.dataGridViewImageColumn61.Name = ("dataGridViewImageColumn61");
            this.dataGridViewImageColumn61.ReadOnly = (true);
            this.dataGridViewImageColumn61.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn61.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn86
            // 
            this.dataGridViewTextBoxColumn86.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn86.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn86, "dataGridViewTextBoxColumn86");
            this.dataGridViewTextBoxColumn86.Name = ("dataGridViewTextBoxColumn86");
            this.dataGridViewTextBoxColumn86.ReadOnly = (true);
            // 
            // dataGridViewImageColumn62
            // 
            this.dataGridViewImageColumn62.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn62, "dataGridViewImageColumn62");
            this.dataGridViewImageColumn62.Name = ("dataGridViewImageColumn62");
            this.dataGridViewImageColumn62.ReadOnly = (true);
            this.dataGridViewImageColumn62.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn62.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn87
            // 
            this.dataGridViewTextBoxColumn87.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn87.DataPropertyName = ("Crystal");
            dataGridViewCellStyle60.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn87.DefaultCellStyle = (dataGridViewCellStyle60);
            resources.ApplyResources(this.dataGridViewTextBoxColumn87, "dataGridViewTextBoxColumn87");
            this.dataGridViewTextBoxColumn87.Name = ("dataGridViewTextBoxColumn87");
            this.dataGridViewTextBoxColumn87.ReadOnly = (true);
            this.dataGridViewTextBoxColumn87.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn63
            // 
            this.dataGridViewImageColumn63.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn63, "dataGridViewImageColumn63");
            this.dataGridViewImageColumn63.Name = ("dataGridViewImageColumn63");
            this.dataGridViewImageColumn63.ReadOnly = (true);
            this.dataGridViewImageColumn63.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn63.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn88
            // 
            this.dataGridViewTextBoxColumn88.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn88.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn88, "dataGridViewTextBoxColumn88");
            this.dataGridViewTextBoxColumn88.Name = ("dataGridViewTextBoxColumn88");
            this.dataGridViewTextBoxColumn88.ReadOnly = (true);
            // 
            // dataGridViewImageColumn64
            // 
            this.dataGridViewImageColumn64.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn64, "dataGridViewImageColumn64");
            this.dataGridViewImageColumn64.Name = ("dataGridViewImageColumn64");
            this.dataGridViewImageColumn64.ReadOnly = (true);
            this.dataGridViewImageColumn64.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn64.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn89
            // 
            this.dataGridViewTextBoxColumn89.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn89.DataPropertyName = ("Crystal");
            dataGridViewCellStyle61.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn89.DefaultCellStyle = (dataGridViewCellStyle61);
            resources.ApplyResources(this.dataGridViewTextBoxColumn89, "dataGridViewTextBoxColumn89");
            this.dataGridViewTextBoxColumn89.Name = ("dataGridViewTextBoxColumn89");
            this.dataGridViewTextBoxColumn89.ReadOnly = (true);
            this.dataGridViewTextBoxColumn89.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn65
            // 
            this.dataGridViewImageColumn65.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn65, "dataGridViewImageColumn65");
            this.dataGridViewImageColumn65.Name = ("dataGridViewImageColumn65");
            this.dataGridViewImageColumn65.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn65.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn90
            // 
            this.dataGridViewTextBoxColumn90.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn90.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn90, "dataGridViewTextBoxColumn90");
            this.dataGridViewTextBoxColumn90.Name = ("dataGridViewTextBoxColumn90");
            // 
            // dataGridViewImageColumn66
            // 
            this.dataGridViewImageColumn66.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn66, "dataGridViewImageColumn66");
            this.dataGridViewImageColumn66.Name = ("dataGridViewImageColumn66");
            this.dataGridViewImageColumn66.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn66.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn91
            // 
            this.dataGridViewTextBoxColumn91.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn91.DataPropertyName = ("Crystal");
            dataGridViewCellStyle62.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn91.DefaultCellStyle = (dataGridViewCellStyle62);
            resources.ApplyResources(this.dataGridViewTextBoxColumn91, "dataGridViewTextBoxColumn91");
            this.dataGridViewTextBoxColumn91.Name = ("dataGridViewTextBoxColumn91");
            this.dataGridViewTextBoxColumn91.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn67
            // 
            this.dataGridViewImageColumn67.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn67, "dataGridViewImageColumn67");
            this.dataGridViewImageColumn67.Name = ("dataGridViewImageColumn67");
            this.dataGridViewImageColumn67.ReadOnly = (true);
            this.dataGridViewImageColumn67.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn67.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn92
            // 
            this.dataGridViewTextBoxColumn92.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn92.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn92, "dataGridViewTextBoxColumn92");
            this.dataGridViewTextBoxColumn92.Name = ("dataGridViewTextBoxColumn92");
            this.dataGridViewTextBoxColumn92.ReadOnly = (true);
            // 
            // dataGridViewImageColumn68
            // 
            this.dataGridViewImageColumn68.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn68, "dataGridViewImageColumn68");
            this.dataGridViewImageColumn68.Name = ("dataGridViewImageColumn68");
            this.dataGridViewImageColumn68.ReadOnly = (true);
            this.dataGridViewImageColumn68.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn68.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn93
            // 
            this.dataGridViewTextBoxColumn93.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn93.DataPropertyName = ("Crystal");
            dataGridViewCellStyle63.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn93.DefaultCellStyle = (dataGridViewCellStyle63);
            resources.ApplyResources(this.dataGridViewTextBoxColumn93, "dataGridViewTextBoxColumn93");
            this.dataGridViewTextBoxColumn93.Name = ("dataGridViewTextBoxColumn93");
            this.dataGridViewTextBoxColumn93.ReadOnly = (true);
            this.dataGridViewTextBoxColumn93.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn69
            // 
            this.dataGridViewImageColumn69.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn69, "dataGridViewImageColumn69");
            this.dataGridViewImageColumn69.Name = ("dataGridViewImageColumn69");
            this.dataGridViewImageColumn69.ReadOnly = (true);
            this.dataGridViewImageColumn69.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn69.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn94
            // 
            this.dataGridViewTextBoxColumn94.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn94.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn94, "dataGridViewTextBoxColumn94");
            this.dataGridViewTextBoxColumn94.Name = ("dataGridViewTextBoxColumn94");
            this.dataGridViewTextBoxColumn94.ReadOnly = (true);
            // 
            // dataGridViewImageColumn70
            // 
            this.dataGridViewImageColumn70.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn70, "dataGridViewImageColumn70");
            this.dataGridViewImageColumn70.Name = ("dataGridViewImageColumn70");
            this.dataGridViewImageColumn70.ReadOnly = (true);
            this.dataGridViewImageColumn70.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn70.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn95
            // 
            this.dataGridViewTextBoxColumn95.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn95.DataPropertyName = ("Crystal");
            dataGridViewCellStyle64.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn95.DefaultCellStyle = (dataGridViewCellStyle64);
            resources.ApplyResources(this.dataGridViewTextBoxColumn95, "dataGridViewTextBoxColumn95");
            this.dataGridViewTextBoxColumn95.Name = ("dataGridViewTextBoxColumn95");
            this.dataGridViewTextBoxColumn95.ReadOnly = (true);
            this.dataGridViewTextBoxColumn95.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn71
            // 
            this.dataGridViewImageColumn71.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn71, "dataGridViewImageColumn71");
            this.dataGridViewImageColumn71.Name = ("dataGridViewImageColumn71");
            this.dataGridViewImageColumn71.ReadOnly = (true);
            this.dataGridViewImageColumn71.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn71.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn96
            // 
            this.dataGridViewTextBoxColumn96.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn96.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn96, "dataGridViewTextBoxColumn96");
            this.dataGridViewTextBoxColumn96.Name = ("dataGridViewTextBoxColumn96");
            this.dataGridViewTextBoxColumn96.ReadOnly = (true);
            // 
            // dataGridViewImageColumn72
            // 
            this.dataGridViewImageColumn72.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn72, "dataGridViewImageColumn72");
            this.dataGridViewImageColumn72.Name = ("dataGridViewImageColumn72");
            this.dataGridViewImageColumn72.ReadOnly = (true);
            this.dataGridViewImageColumn72.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn72.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn97
            // 
            this.dataGridViewTextBoxColumn97.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn97.DataPropertyName = ("Crystal");
            dataGridViewCellStyle65.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn97.DefaultCellStyle = (dataGridViewCellStyle65);
            resources.ApplyResources(this.dataGridViewTextBoxColumn97, "dataGridViewTextBoxColumn97");
            this.dataGridViewTextBoxColumn97.Name = ("dataGridViewTextBoxColumn97");
            this.dataGridViewTextBoxColumn97.ReadOnly = (true);
            this.dataGridViewTextBoxColumn97.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn73
            // 
            this.dataGridViewImageColumn73.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn73, "dataGridViewImageColumn73");
            this.dataGridViewImageColumn73.Name = ("dataGridViewImageColumn73");
            this.dataGridViewImageColumn73.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn73.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn98
            // 
            this.dataGridViewTextBoxColumn98.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn98.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn98, "dataGridViewTextBoxColumn98");
            this.dataGridViewTextBoxColumn98.Name = ("dataGridViewTextBoxColumn98");
            // 
            // dataGridViewImageColumn74
            // 
            this.dataGridViewImageColumn74.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn74, "dataGridViewImageColumn74");
            this.dataGridViewImageColumn74.Name = ("dataGridViewImageColumn74");
            this.dataGridViewImageColumn74.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn74.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn99
            // 
            this.dataGridViewTextBoxColumn99.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn99.DataPropertyName = ("Crystal");
            dataGridViewCellStyle66.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn99.DefaultCellStyle = (dataGridViewCellStyle66);
            resources.ApplyResources(this.dataGridViewTextBoxColumn99, "dataGridViewTextBoxColumn99");
            this.dataGridViewTextBoxColumn99.Name = ("dataGridViewTextBoxColumn99");
            this.dataGridViewTextBoxColumn99.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn75
            // 
            this.dataGridViewImageColumn75.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn75, "dataGridViewImageColumn75");
            this.dataGridViewImageColumn75.Name = ("dataGridViewImageColumn75");
            this.dataGridViewImageColumn75.ReadOnly = (true);
            this.dataGridViewImageColumn75.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn75.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn100
            // 
            this.dataGridViewTextBoxColumn100.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn100.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn100, "dataGridViewTextBoxColumn100");
            this.dataGridViewTextBoxColumn100.Name = ("dataGridViewTextBoxColumn100");
            this.dataGridViewTextBoxColumn100.ReadOnly = (true);
            // 
            // dataGridViewImageColumn76
            // 
            this.dataGridViewImageColumn76.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn76, "dataGridViewImageColumn76");
            this.dataGridViewImageColumn76.Name = ("dataGridViewImageColumn76");
            this.dataGridViewImageColumn76.ReadOnly = (true);
            this.dataGridViewImageColumn76.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn76.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn101
            // 
            this.dataGridViewTextBoxColumn101.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn101.DataPropertyName = ("Crystal");
            dataGridViewCellStyle67.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn101.DefaultCellStyle = (dataGridViewCellStyle67);
            resources.ApplyResources(this.dataGridViewTextBoxColumn101, "dataGridViewTextBoxColumn101");
            this.dataGridViewTextBoxColumn101.Name = ("dataGridViewTextBoxColumn101");
            this.dataGridViewTextBoxColumn101.ReadOnly = (true);
            this.dataGridViewTextBoxColumn101.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn77
            // 
            this.dataGridViewImageColumn77.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn77, "dataGridViewImageColumn77");
            this.dataGridViewImageColumn77.Name = ("dataGridViewImageColumn77");
            this.dataGridViewImageColumn77.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn77.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn102
            // 
            this.dataGridViewTextBoxColumn102.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn102.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn102, "dataGridViewTextBoxColumn102");
            this.dataGridViewTextBoxColumn102.Name = ("dataGridViewTextBoxColumn102");
            // 
            // dataGridViewImageColumn78
            // 
            this.dataGridViewImageColumn78.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn78, "dataGridViewImageColumn78");
            this.dataGridViewImageColumn78.Name = ("dataGridViewImageColumn78");
            this.dataGridViewImageColumn78.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn78.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn103
            // 
            this.dataGridViewTextBoxColumn103.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn103.DataPropertyName = ("Crystal");
            dataGridViewCellStyle68.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn103.DefaultCellStyle = (dataGridViewCellStyle68);
            resources.ApplyResources(this.dataGridViewTextBoxColumn103, "dataGridViewTextBoxColumn103");
            this.dataGridViewTextBoxColumn103.Name = ("dataGridViewTextBoxColumn103");
            this.dataGridViewTextBoxColumn103.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn79
            // 
            this.dataGridViewImageColumn79.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn79, "dataGridViewImageColumn79");
            this.dataGridViewImageColumn79.Name = ("dataGridViewImageColumn79");
            this.dataGridViewImageColumn79.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn79.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn104
            // 
            this.dataGridViewTextBoxColumn104.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn104.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn104, "dataGridViewTextBoxColumn104");
            this.dataGridViewTextBoxColumn104.Name = ("dataGridViewTextBoxColumn104");
            // 
            // dataGridViewImageColumn80
            // 
            this.dataGridViewImageColumn80.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn80, "dataGridViewImageColumn80");
            this.dataGridViewImageColumn80.Name = ("dataGridViewImageColumn80");
            this.dataGridViewImageColumn80.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn80.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn105
            // 
            this.dataGridViewTextBoxColumn105.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn105.DataPropertyName = ("Crystal");
            dataGridViewCellStyle69.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn105.DefaultCellStyle = (dataGridViewCellStyle69);
            resources.ApplyResources(this.dataGridViewTextBoxColumn105, "dataGridViewTextBoxColumn105");
            this.dataGridViewTextBoxColumn105.Name = ("dataGridViewTextBoxColumn105");
            this.dataGridViewTextBoxColumn105.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn82
            // 
            this.dataGridViewImageColumn82.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn82, "dataGridViewImageColumn82");
            this.dataGridViewImageColumn82.Name = ("dataGridViewImageColumn82");
            this.dataGridViewImageColumn82.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn82.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn107
            // 
            this.dataGridViewTextBoxColumn107.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn107.DataPropertyName = ("Crystal");
            dataGridViewCellStyle70.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn107.DefaultCellStyle = (dataGridViewCellStyle70);
            resources.ApplyResources(this.dataGridViewTextBoxColumn107, "dataGridViewTextBoxColumn107");
            this.dataGridViewTextBoxColumn107.Name = ("dataGridViewTextBoxColumn107");
            this.dataGridViewTextBoxColumn107.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn81
            // 
            this.dataGridViewImageColumn81.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn81, "dataGridViewImageColumn81");
            this.dataGridViewImageColumn81.Name = ("dataGridViewImageColumn81");
            this.dataGridViewImageColumn81.ReadOnly = (true);
            this.dataGridViewImageColumn81.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn81.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn106
            // 
            this.dataGridViewTextBoxColumn106.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn106.DataPropertyName = ("Profile");
            dataGridViewCellStyle71.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn106.DefaultCellStyle = (dataGridViewCellStyle71);
            resources.ApplyResources(this.dataGridViewTextBoxColumn106, "dataGridViewTextBoxColumn106");
            this.dataGridViewTextBoxColumn106.Name = ("dataGridViewTextBoxColumn106");
            this.dataGridViewTextBoxColumn106.ReadOnly = (true);
            this.dataGridViewTextBoxColumn106.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn83
            // 
            this.dataGridViewImageColumn83.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn83, "dataGridViewImageColumn83");
            this.dataGridViewImageColumn83.Name = ("dataGridViewImageColumn83");
            this.dataGridViewImageColumn83.ReadOnly = (true);
            this.dataGridViewImageColumn83.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn83.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn108
            // 
            this.dataGridViewTextBoxColumn108.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn108.DataPropertyName = ("Crystal");
            dataGridViewCellStyle72.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn108.DefaultCellStyle = (dataGridViewCellStyle72);
            resources.ApplyResources(this.dataGridViewTextBoxColumn108, "dataGridViewTextBoxColumn108");
            this.dataGridViewTextBoxColumn108.Name = ("dataGridViewTextBoxColumn108");
            this.dataGridViewTextBoxColumn108.ReadOnly = (true);
            this.dataGridViewTextBoxColumn108.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn84
            // 
            this.dataGridViewImageColumn84.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn84, "dataGridViewImageColumn84");
            this.dataGridViewImageColumn84.Name = ("dataGridViewImageColumn84");
            this.dataGridViewImageColumn84.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn84.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn109
            // 
            this.dataGridViewTextBoxColumn109.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn109.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn109, "dataGridViewTextBoxColumn109");
            this.dataGridViewTextBoxColumn109.Name = ("dataGridViewTextBoxColumn109");
            // 
            // dataGridViewImageColumn85
            // 
            this.dataGridViewImageColumn85.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn85, "dataGridViewImageColumn85");
            this.dataGridViewImageColumn85.Name = ("dataGridViewImageColumn85");
            this.dataGridViewImageColumn85.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn85.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn110
            // 
            this.dataGridViewTextBoxColumn110.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn110.DataPropertyName = ("Crystal");
            dataGridViewCellStyle73.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn110.DefaultCellStyle = (dataGridViewCellStyle73);
            resources.ApplyResources(this.dataGridViewTextBoxColumn110, "dataGridViewTextBoxColumn110");
            this.dataGridViewTextBoxColumn110.Name = ("dataGridViewTextBoxColumn110");
            this.dataGridViewTextBoxColumn110.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn86
            // 
            this.dataGridViewImageColumn86.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn86, "dataGridViewImageColumn86");
            this.dataGridViewImageColumn86.Name = ("dataGridViewImageColumn86");
            this.dataGridViewImageColumn86.ReadOnly = (true);
            this.dataGridViewImageColumn86.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn86.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn111
            // 
            this.dataGridViewTextBoxColumn111.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn111.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn111, "dataGridViewTextBoxColumn111");
            this.dataGridViewTextBoxColumn111.Name = ("dataGridViewTextBoxColumn111");
            this.dataGridViewTextBoxColumn111.ReadOnly = (true);
            // 
            // dataGridViewImageColumn87
            // 
            this.dataGridViewImageColumn87.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn87, "dataGridViewImageColumn87");
            this.dataGridViewImageColumn87.Name = ("dataGridViewImageColumn87");
            this.dataGridViewImageColumn87.ReadOnly = (true);
            this.dataGridViewImageColumn87.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn87.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn112
            // 
            this.dataGridViewTextBoxColumn112.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn112.DataPropertyName = ("Crystal");
            dataGridViewCellStyle74.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn112.DefaultCellStyle = (dataGridViewCellStyle74);
            resources.ApplyResources(this.dataGridViewTextBoxColumn112, "dataGridViewTextBoxColumn112");
            this.dataGridViewTextBoxColumn112.Name = ("dataGridViewTextBoxColumn112");
            this.dataGridViewTextBoxColumn112.ReadOnly = (true);
            this.dataGridViewTextBoxColumn112.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // dataGridViewImageColumn88
            // 
            this.dataGridViewImageColumn88.DataPropertyName = ("Color");
            resources.ApplyResources(this.dataGridViewImageColumn88, "dataGridViewImageColumn88");
            this.dataGridViewImageColumn88.Name = ("dataGridViewImageColumn88");
            this.dataGridViewImageColumn88.Resizable = (global::System.Windows.Forms.DataGridViewTriState.True);
            this.dataGridViewImageColumn88.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn113
            // 
            this.dataGridViewTextBoxColumn113.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn113.DataPropertyName = ("Profile");
            resources.ApplyResources(this.dataGridViewTextBoxColumn113, "dataGridViewTextBoxColumn113");
            this.dataGridViewTextBoxColumn113.Name = ("dataGridViewTextBoxColumn113");
            // 
            // dataGridViewImageColumn89
            // 
            this.dataGridViewImageColumn89.DataPropertyName = ("PeakColor");
            resources.ApplyResources(this.dataGridViewImageColumn89, "dataGridViewImageColumn89");
            this.dataGridViewImageColumn89.Name = ("dataGridViewImageColumn89");
            this.dataGridViewImageColumn89.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            this.dataGridViewImageColumn89.SortMode = (global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic);
            // 
            // dataGridViewTextBoxColumn114
            // 
            this.dataGridViewTextBoxColumn114.AutoSizeMode = (global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill);
            this.dataGridViewTextBoxColumn114.DataPropertyName = ("Crystal");
            dataGridViewCellStyle75.Font = (new global::System.Drawing.Font("Arial", 9.75F, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point));
            this.dataGridViewTextBoxColumn114.DefaultCellStyle = (dataGridViewCellStyle75);
            resources.ApplyResources(this.dataGridViewTextBoxColumn114, "dataGridViewTextBoxColumn114");
            this.dataGridViewTextBoxColumn114.Name = ("dataGridViewTextBoxColumn114");
            this.dataGridViewTextBoxColumn114.Resizable = (global::System.Windows.Forms.DataGridViewTriState.False);
            // 
            // FormMain
            // 
            this.AllowDrop = (true);
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = (global::System.Windows.Forms.AutoScaleMode.Dpi);
            this.Controls.Add(this.toolStripContainer1);
            this.KeyPreview = (true);
            this.Name = ("FormMain");
            this.FormClosing += (this.FormMain_FormClosing);
            this.FormClosed += (this.FormMain_FormClosed);
            this.Load += (this.FormMain_Load);
            this.DragDrop += (this.FormMain_DragDrop);
            this.DragEnter += (this.FormMain_DragEnter);
            this.KeyDown += (this.FormMain_KeyDown);
            this.Resize += (this.Draw);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((global::System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.numericUpDownIncreasingPixels)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((global::System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxInt)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.numericUpDownMinInt)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((global::System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((global::System.ComponentModel.ISupportInitialize)(this.dataGridViewProfiles)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.bindingSourceProfile)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.groupBoxCrystalData.ResumeLayout(false);
            ((global::System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystals)).EndInit();
            ((global::System.ComponentModel.ISupportInitialize)(this.bindingSourceCrystal)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonAu;
        private System.Windows.Forms.GroupBox groupBoxCrystalData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem readPatternProfileToolStripMenuItem;
        private ToolStripMenuItem savePatternProfileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem readCrystalDataToolStripMenuItem;
        private ToolStripMenuItem saveCrystalDataToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutMeToolStripMenuItem;
        public StatusStrip statusStrip1;
        public ToolStripStatusLabel toolStripStatusLabelCalcTime;
        private ToolStripContainer toolStripContainer1;
        public ToolStrip toolStrip2;
        public ToolStripButton toolStripButtonEquationOfState;
        private ToolStripSeparator toolStripSeparator8;
        public ToolStripButton toolStripButtonFittingParameter;
        private GroupBox groupBox1;
        private PictureBox pictureBoxMain;
        public CheckBox checkBoxProfileParameter;
        public CheckBox checkBoxCrystalParameter;
        private Label labelTwoTheta;
        private Label labelIntensity;
        private Label labelD;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private ToolTip toolTip;
        private ToolStripMenuItem optionToolStripMenuItem;
        private ToolStripMenuItem toolTipToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        public ToolStripButton toolStripButtonLPO;
        private ToolStripMenuItem resetInitialCrystalDataToolStripMenuItem;
        private ToolStripMenuItem helpwebToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem toolStripMenuItemImport;
        private ToolStripMenuItem toolStripMenuItemPrintPreview;
        private PageSetupDialog pageSetupDialog1;
        private PrintDialog printDialog1;
        private ToolStripMenuItem toolStripMenuItemPageSetup;
        private ToolStripMenuItem watchReadANewProfileToolStripMenuItem;
        private ToolStripMenuItem watchReadClipboardToolStripMenuItem;
        private ToolStripMenuItem setDirectoryToTheWatchToolStripMenuItem;
        private ToolStripTextBox toolStripTextBoxDirectoryToWatch;
        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private RadioButton radioButtonSingleProfileMode;
        private RadioButton radioButtonMultiProfileMode;
        private NumericUpDown numericUpDownIncreasingPixels;
        private CheckBox checkBoxShowScaleLine;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private Label label4;
        private CheckBox checkBoxChangeColor;
        private Label label2;
        private Label label5;
        private Crystallography.Controls.NumericBox numericalTextBoxIncreasingPixels;
        private Label label6;
        private Crystallography.Controls.ColorControl colorControlScaleText;
        private Crystallography.Controls.ColorControl colorControlScaleLine;
        private Crystallography.Controls.ColorControl colorControlBack;
        private ToolStripMenuItem toolStripMenuItemExportExcelFile;
        private ToolStripButton toolStripButtonCrystalParameter;
        private ToolStripButton toolStripButtonProfileParameter;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem toolStripMenuItemSaveMetafile;
        private ToolStripMenuItem hintToolStripMenuItem;
        private ToolStripMenuItem readAndAddToolStripMenuItem;
        public ToolStripButton toolStripButtonCellFinder;
        private Crystallography.Controls.HorizontalAxisUserControl horizontalAxisUserControl;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        public BindingSource bindingSourceCrystal;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        public DataSet dataSet;
        private DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn Check;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        public DataGridView dataGridViewCrystals;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        public ToolStripButton toolStripButtonAtomicPositonFinder;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripSeparator toolStripSeparator10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private ToolStripMenuItem clearRegistryToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        public ToolStripButton toolStripButtonSequentialAnalysis;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private Label label24;
        private Label label23;
        public ComboBox comboBoxGradient;
        public ComboBox comboBoxScale1;
        private Crystallography.Controls.GraphControl graphControlFrequency;
        private CheckBox checkBoxShowUnrolledImage;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private Label label22;
        public ComboBox comboBoxScale2;
        private NumericUpDown numericUpDownMaxInt;
        private Label label7;
        private Label label21;
        private NumericUpDown numericUpDownMinInt;
        private TabControl tabControl1;
        private TabPage tabPage3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private CheckBox checkBoxChangeHorizontalAppearance;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewImageColumn PeakColor;
        private DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn Crystal;
        private GroupBox groupBox4;
        private RadioButton radioButtonCountsPerStep;
        private RadioButton radioButtonRawCounts;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private FlowLayoutPanel flowLayoutPanel2;
        private RadioButton radioButtonLinearity;
        private RadioButton radioButtonLogarithm;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridViewImageColumn dataGridViewImageColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private CheckBox checkBoxErrorBar;
        public DataGridView dataGridViewProfiles;
        public BindingSource bindingSourceProfile;
        private DataGridViewCheckBoxColumn checkDataGridViewCheckBoxColumn2;
        private DataGridViewImageColumn colorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn profileDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewImageColumn dataGridViewImageColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private DataGridViewImageColumn dataGridViewImageColumn5;
        private DataGridViewImageColumn dataGridViewImageColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private DataGridViewImageColumn dataGridViewImageColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private DataGridViewImageColumn dataGridViewImageColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewImageColumn dataGridViewImageColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private DataGridViewImageColumn dataGridViewImageColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private DataGridViewImageColumn dataGridViewImageColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private DataGridViewImageColumn dataGridViewImageColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private DataGridViewImageColumn dataGridViewImageColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private DataGridViewImageColumn dataGridViewImageColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private DataGridViewImageColumn dataGridViewImageColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private DataGridViewImageColumn dataGridViewImageColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private DataGridViewImageColumn dataGridViewImageColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private DataGridViewImageColumn dataGridViewImageColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private DataGridViewImageColumn dataGridViewImageColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private DataGridViewImageColumn dataGridViewImageColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private DataGridViewImageColumn dataGridViewImageColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private DataGridViewImageColumn dataGridViewImageColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private DataGridViewImageColumn dataGridViewImageColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private DataGridViewImageColumn dataGridViewImageColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private DataGridViewImageColumn dataGridViewImageColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private DataGridViewImageColumn dataGridViewImageColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private DataGridViewImageColumn dataGridViewImageColumn27;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private DataGridViewImageColumn dataGridViewImageColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private DataGridViewImageColumn dataGridViewImageColumn28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private DataGridViewImageColumn dataGridViewImageColumn30;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        private DataGridViewImageColumn dataGridViewImageColumn31;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
        private DataGridViewImageColumn dataGridViewImageColumn32;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        private DataGridViewImageColumn dataGridViewImageColumn33;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private DataGridViewImageColumn dataGridViewImageColumn34;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
        private DataGridViewImageColumn dataGridViewImageColumn35;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        private ToolStripMenuItem toolStripMenuItemExportCIF;
        private ToolStripMenuItem programUpdatesToolStripMenuItem;
        private DataGridViewImageColumn dataGridViewImageColumn36;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        private DataGridViewImageColumn dataGridViewImageColumn37;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
        private Panel panel1;
        private DataGridViewImageColumn dataGridViewImageColumn38;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
        private DataGridViewImageColumn dataGridViewImageColumn39;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
        public CheckBox checkBoxAll;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem japaneseToolStripMenuItem;
        private DataGridViewImageColumn dataGridViewImageColumn40;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;
        private DataGridViewImageColumn dataGridViewImageColumn41;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;
        private FlowLayoutPanel flowLayoutPanel4;
        private DataGridViewImageColumn dataGridViewImageColumn42;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
        private DataGridViewImageColumn dataGridViewImageColumn43;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private DataGridViewImageColumn dataGridViewImageColumn44;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;
        private DataGridViewImageColumn dataGridViewImageColumn45;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
        private DataGridViewImageColumn dataGridViewImageColumn46;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
        private DataGridViewImageColumn dataGridViewImageColumn47;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
        private ToolStripMenuItem コピーToolStripMenuItem;
        private ToolStripMenuItem BitmapToolStripMenuItem;
        private ToolStripMenuItem copyAsMetafileToolStripMenuItem;
        private ToolStripMenuItem asCSVcommaSeperatedFileToolStripMenuItem;
        private ToolStripMenuItem asTSVtabSeparatedValuesFileToolStripMenuItem;
        private ToolStripMenuItem asGSASFileToolStripMenuItem;
        private DataGridViewImageColumn dataGridViewImageColumn48;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
        private DataGridViewImageColumn dataGridViewImageColumn49;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
        private Timer timerBlinkDiffraction;
        private DataGridViewImageColumn dataGridViewImageColumn50;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;
        private DataGridViewImageColumn dataGridViewImageColumn51;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;
        private DataGridViewImageColumn dataGridViewImageColumn52;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;
        private DataGridViewImageColumn dataGridViewImageColumn53;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private DataGridViewImageColumn dataGridViewImageColumn54;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;
        private ToolStripButton toolStripButtonShowText;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridViewImageColumn dataGridViewImageColumn55;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
        private DataGridViewImageColumn dataGridViewImageColumn56;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;
        private ToolStripMenuItem macroToolStripMenuItem;
        private ToolStripMenuItem editorToolStripMenuItem;
        private DataGridViewImageColumn dataGridViewImageColumn57;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;
        private DataGridViewImageColumn dataGridViewImageColumn58;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn83;
        private DataGridViewImageColumn dataGridViewImageColumn59;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn84;
        private DataGridViewImageColumn dataGridViewImageColumn60;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;
        private DataGridViewImageColumn dataGridViewImageColumn61;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;
        private DataGridViewImageColumn dataGridViewImageColumn62;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;
        private DataGridViewImageColumn dataGridViewImageColumn63;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn88;
        private DataGridViewImageColumn dataGridViewImageColumn64;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn89;
        private Crystallography.Controls.NumericBox numericBoxUpperY;
        private Crystallography.Controls.NumericBox numericBoxLowerY;
        private DataGridViewImageColumn dataGridViewImageColumn65;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn90;
        private DataGridViewImageColumn dataGridViewImageColumn66;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn91;
        private DataGridViewImageColumn dataGridViewImageColumn67;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn92;
        private DataGridViewImageColumn dataGridViewImageColumn68;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn93;
        private DataGridViewImageColumn dataGridViewImageColumn69;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn94;
        private DataGridViewImageColumn dataGridViewImageColumn70;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn95;
        private DataGridViewImageColumn dataGridViewImageColumn71;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn96;
        private DataGridViewImageColumn dataGridViewImageColumn72;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn97;
        private DataGridViewImageColumn dataGridViewImageColumn73;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn98;
        private DataGridViewImageColumn dataGridViewImageColumn74;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn99;
        private DataGridViewImageColumn dataGridViewImageColumn75;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn100;
        private DataGridViewImageColumn dataGridViewImageColumn76;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn101;
        private DataGridViewImageColumn dataGridViewImageColumn77;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn102;
        private DataGridViewImageColumn dataGridViewImageColumn78;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn103;
        private DataGridViewImageColumn dataGridViewImageColumn79;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn104;
        private DataGridViewImageColumn dataGridViewImageColumn80;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn105;
        private ToolStripProgressBar toolStripProgressBar;
        private DataGridViewImageColumn dataGridViewImageColumn82;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn107;
        private DataGridViewImageColumn dataGridViewImageColumn81;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn106;
        private DataGridViewImageColumn dataGridViewImageColumn83;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn108;
        private Crystallography.Controls.NumericBoxWithMenu numericBoxLowerX;
        private DataGridViewImageColumn dataGridViewImageColumn84;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn109;
        private DataGridViewImageColumn dataGridViewImageColumn85;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn110;
        private Crystallography.Controls.NumericBoxWithMenu numericBoxUpperX;
        private DataGridViewImageColumn dataGridViewImageColumn86;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn111;
        private DataGridViewImageColumn dataGridViewImageColumn87;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn112;
        private ToolStripMenuItem automaticallySaveTheCrystalListToolStripMenuItem;
        private DataGridViewImageColumn dataGridViewImageColumn88;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn113;
        private DataGridViewImageColumn dataGridViewImageColumn89;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn114;
        private Label labelQ;
    }
}