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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle73 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle74 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle76 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle75 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle77 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle78 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle89 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle90 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle91 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle92 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle93 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle94 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle95 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle96 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle97 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle98 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle99 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle100 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle101 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle102 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle103 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle104 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle105 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle106 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle107 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle108 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle109 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle110 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle111 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle112 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle113 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle114 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle115 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle116 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle117 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle118 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle119 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle120 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle121 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle122 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle123 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle124 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle125 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle126 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle127 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle128 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle129 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle130 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle131 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle132 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle133 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle134 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle135 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle136 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle137 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle138 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelCalcTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.horizontalAxisUserControl = new Crystallography.Controls.HorizontalAxisUserControl();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxChangeHorizontalAppearance = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonLinearity = new System.Windows.Forms.RadioButton();
            this.radioButtonLogarithm = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonRawCounts = new System.Windows.Forms.RadioButton();
            this.radioButtonCountsPerStep = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericalTextBoxIncreasingPixels = new Crystallography.Controls.NumericBox();
            this.numericUpDownIncreasingPixels = new System.Windows.Forms.NumericUpDown();
            this.radioButtonMultiProfileMode = new System.Windows.Forms.RadioButton();
            this.checkBoxChangeColor = new System.Windows.Forms.CheckBox();
            this.radioButtonSingleProfileMode = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorControlScaleText = new Crystallography.Controls.ColorControl();
            this.colorControlScaleLine = new Crystallography.Controls.ColorControl();
            this.colorControlBack = new Crystallography.Controls.ColorControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxErrorBar = new System.Windows.Forms.CheckBox();
            this.checkBoxShowScaleLine = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.numericUpDownMaxInt = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDownMinInt = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShowUnrolledImage = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBoxGradient = new System.Windows.Forms.ComboBox();
            this.comboBoxScale2 = new System.Windows.Forms.ComboBox();
            this.comboBoxScale1 = new System.Windows.Forms.ComboBox();
            this.graphControlFrequency = new Crystallography.Controls.GraphControl();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericBoxUpperY = new Crystallography.Controls.NumericBox();
            this.labelIntensity = new System.Windows.Forms.Label();
            this.numericBoxLowerY = new Crystallography.Controls.NumericBox();
            this.labelD = new System.Windows.Forms.Label();
            this.numericBoxUpperX = new Crystallography.Controls.NumericBox();
            this.labelTwoTheta = new System.Windows.Forms.Label();
            this.numericBoxLowerX = new Crystallography.Controls.NumericBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewProfiles = new System.Windows.Forms.DataGridView();
            this.checkDataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.profileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceProfile = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new PDIndexer.DataSet();
            this.checkBoxProfileParameter = new System.Windows.Forms.CheckBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.groupBoxCrystalData = new System.Windows.Forms.GroupBox();
            this.dataGridViewCrystals = new System.Windows.Forms.DataGridView();
            this.checkDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PeakColor = new System.Windows.Forms.DataGridViewImageColumn();
            this.Crystal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceCrystal = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxCrystalParameter = new System.Windows.Forms.CheckBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readPatternProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePatternProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExportExcelFile = new System.Windows.Forms.ToolStripMenuItem();
            this.asCSVcommaSeperatedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asTSVtabSeparatedValuesFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asGSASFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.readCrystalDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readAndAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCrystalDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExportCIF = new System.Windows.Forms.ToolStripMenuItem();
            this.resetInitialCrystalDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemPageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.コピーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAsMetafileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveMetafile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchReadClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchReadANewProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDirectoryToTheWatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxDirectoryToWatch = new System.Windows.Forms.ToolStripTextBox();
            this.clearRegistryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ngenCompileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpwebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCrystalParameter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonProfileParameter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEquationOfState = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFittingParameter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCellFinder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAtomicPositonFinder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonStressAnalysis = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLPO = new System.Windows.Forms.ToolStripButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonAu = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn8 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn9 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn10 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn11 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn12 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn13 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn15 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn14 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn16 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn17 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn19 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn18 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn20 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn21 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn22 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn23 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn24 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn25 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn26 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn27 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn29 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn28 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn30 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn31 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn32 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn33 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn34 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn35 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn36 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn37 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn38 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn39 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn40 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn41 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn66 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn42 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn67 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn43 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn68 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn44 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn69 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn45 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn46 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn47 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn48 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn49 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerBlinkDiffraction = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewImageColumn51 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn76 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn52 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn77 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn50 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn53 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn54 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn79 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn55 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn56 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn81 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn57 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn82 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn58 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn83 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn59 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn84 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn60 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn85 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn61 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn86 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn62 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn87 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn63 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn88 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn64 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn89 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn65 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn90 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn66 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn91 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn67 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn92 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn68 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn93 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn69 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn94 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn70 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn95 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn71 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn96 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn72 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn97 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn73 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn98 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn74 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn99 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn75 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn76 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn101 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn77 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn102 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn78 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn103 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn79 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn104 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn80 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn105 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIncreasingPixels)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinInt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.groupBoxCrystalData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCrystal)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolStrip2.SuspendLayout();
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
            this.toolStripContainer1.Name = "toolStripContainer1";
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
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabelCalcTime,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            resources.ApplyResources(this.toolStripProgressBar, "toolStripProgressBar");
            // 
            // toolStripStatusLabelCalcTime
            // 
            this.toolStripStatusLabelCalcTime.Name = "toolStripStatusLabelCalcTime";
            resources.ApplyResources(this.toolStripStatusLabelCalcTime, "toolStripStatusLabelCalcTime");
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
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
            this.tabControl.HotTrack = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.horizontalAxisUserControl);
            this.tabPage1.Controls.Add(this.flowLayoutPanel4);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // horizontalAxisUserControl
            // 
            resources.ApplyResources(this.horizontalAxisUserControl, "horizontalAxisUserControl");
            this.horizontalAxisUserControl.AxisMode = Crystallography.HorizontalAxis.Angle;
            this.horizontalAxisUserControl.ElectronAccVoltage = 8.04114721308336D;
            this.horizontalAxisUserControl.ElectronAccVoltageText = "8.04114721308336";
            this.horizontalAxisUserControl.EnergyUnit = Crystallography.EnergyUnitEnum.eV;
            this.horizontalAxisUserControl.Name = "horizontalAxisUserControl";
            this.horizontalAxisUserControl.TakeoffAngle = 0D;
            this.horizontalAxisUserControl.TakeoffAngleText = "0";
            this.horizontalAxisUserControl.TofAngle = 1.5707963267948966D;
            this.horizontalAxisUserControl.TofAngleText = "90";
            this.horizontalAxisUserControl.TofLength = 90D;
            this.horizontalAxisUserControl.WaveColor = Crystallography.WaveColor.Monochrome;
            this.horizontalAxisUserControl.WaveLength = 0.15418710666666666D;
            this.horizontalAxisUserControl.WaveLengthText = "1.54187106666667";
            this.horizontalAxisUserControl.WaveSource = Crystallography.WaveSource.Xray;
            this.horizontalAxisUserControl.XrayWaveSourceElementNumber = 29;
            this.horizontalAxisUserControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka;
            this.horizontalAxisUserControl.AxisPropertyChanged += new Crystallography.Controls.HorizontalAxisUserControl.MyEventHandler(this.horizontalAxisUserControl_AxisPropertyChanged);
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(this.flowLayoutPanel4, "flowLayoutPanel4");
            this.flowLayoutPanel4.Controls.Add(this.checkBoxChangeHorizontalAppearance);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // checkBoxChangeHorizontalAppearance
            // 
            resources.ApplyResources(this.checkBoxChangeHorizontalAppearance, "checkBoxChangeHorizontalAppearance");
            this.checkBoxChangeHorizontalAppearance.Checked = true;
            this.checkBoxChangeHorizontalAppearance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChangeHorizontalAppearance.Name = "checkBoxChangeHorizontalAppearance";
            this.toolTip.SetToolTip(this.checkBoxChangeHorizontalAppearance, resources.GetString("checkBoxChangeHorizontalAppearance.ToolTip"));
            this.checkBoxChangeHorizontalAppearance.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.checkBoxErrorBar);
            this.tabPage2.Controls.Add(this.checkBoxShowScaleLine);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel2);
            this.groupBox4.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.toolTip.SetToolTip(this.groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.radioButtonLinearity);
            this.flowLayoutPanel2.Controls.Add(this.radioButtonLogarithm);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // radioButtonLinearity
            // 
            resources.ApplyResources(this.radioButtonLinearity, "radioButtonLinearity");
            this.radioButtonLinearity.Checked = true;
            this.radioButtonLinearity.Name = "radioButtonLinearity";
            this.radioButtonLinearity.TabStop = true;
            this.toolTip.SetToolTip(this.radioButtonLinearity, resources.GetString("radioButtonLinearity.ToolTip"));
            this.radioButtonLinearity.UseVisualStyleBackColor = true;
            this.radioButtonLinearity.CheckedChanged += new System.EventHandler(this.radioButtonRawCounts_CheckedChanged);
            // 
            // radioButtonLogarithm
            // 
            resources.ApplyResources(this.radioButtonLogarithm, "radioButtonLogarithm");
            this.radioButtonLogarithm.Name = "radioButtonLogarithm";
            this.toolTip.SetToolTip(this.radioButtonLogarithm, resources.GetString("radioButtonLogarithm.ToolTip"));
            this.radioButtonLogarithm.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.radioButtonRawCounts);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonCountsPerStep);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioButtonRawCounts
            // 
            resources.ApplyResources(this.radioButtonRawCounts, "radioButtonRawCounts");
            this.radioButtonRawCounts.Name = "radioButtonRawCounts";
            this.toolTip.SetToolTip(this.radioButtonRawCounts, resources.GetString("radioButtonRawCounts.ToolTip"));
            this.radioButtonRawCounts.UseVisualStyleBackColor = true;
            this.radioButtonRawCounts.CheckedChanged += new System.EventHandler(this.radioButtonRawCounts_CheckedChanged);
            // 
            // radioButtonCountsPerStep
            // 
            resources.ApplyResources(this.radioButtonCountsPerStep, "radioButtonCountsPerStep");
            this.radioButtonCountsPerStep.Checked = true;
            this.radioButtonCountsPerStep.Name = "radioButtonCountsPerStep";
            this.radioButtonCountsPerStep.TabStop = true;
            this.toolTip.SetToolTip(this.radioButtonCountsPerStep, resources.GetString("radioButtonCountsPerStep.ToolTip"));
            this.radioButtonCountsPerStep.UseVisualStyleBackColor = true;
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
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // numericalTextBoxIncreasingPixels
            // 
            this.numericalTextBoxIncreasingPixels.AllowMouseControl = false;
            resources.ApplyResources(this.numericalTextBoxIncreasingPixels, "numericalTextBoxIncreasingPixels");
            this.numericalTextBoxIncreasingPixels.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxIncreasingPixels.DecimalPlaces = -1;
            this.numericalTextBoxIncreasingPixels.Maximum = double.PositiveInfinity;
            this.numericalTextBoxIncreasingPixels.Minimum = double.NegativeInfinity;
            this.numericalTextBoxIncreasingPixels.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericalTextBoxIncreasingPixels.MouseSpeed = 1D;
            this.numericalTextBoxIncreasingPixels.Multiline = false;
            this.numericalTextBoxIncreasingPixels.Name = "numericalTextBoxIncreasingPixels";
            this.numericalTextBoxIncreasingPixels.RadianValue = 17.872171540421935D;
            this.numericalTextBoxIncreasingPixels.ReadOnly = false;
            this.numericalTextBoxIncreasingPixels.RestrictLimitValue = false;
            this.numericalTextBoxIncreasingPixels.ShowFraction = false;
            this.numericalTextBoxIncreasingPixels.ShowPositiveSign = false;
            this.numericalTextBoxIncreasingPixels.ShowUpDown = false;
            this.numericalTextBoxIncreasingPixels.SkipEventDuringInput = false;
            this.numericalTextBoxIncreasingPixels.SmartIncrement = false;
            this.numericalTextBoxIncreasingPixels.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxIncreasingPixels.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxIncreasingPixels.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxIncreasingPixels.ThonsandsSeparator = false;
            this.numericalTextBoxIncreasingPixels.UpDown_Increment = 1D;
            this.numericalTextBoxIncreasingPixels.Value = 1024D;
            this.numericalTextBoxIncreasingPixels.WordWrap = true;
            this.numericalTextBoxIncreasingPixels.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.radioButtonMultiProfileMode_CheckChanged);
            // 
            // numericUpDownIncreasingPixels
            // 
            resources.ApplyResources(this.numericUpDownIncreasingPixels, "numericUpDownIncreasingPixels");
            this.numericUpDownIncreasingPixels.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownIncreasingPixels.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericUpDownIncreasingPixels.Name = "numericUpDownIncreasingPixels";
            this.numericUpDownIncreasingPixels.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownIncreasingPixels.ValueChanged += new System.EventHandler(this.numericUpDownIncreasingPixels_ValueChanged);
            // 
            // radioButtonMultiProfileMode
            // 
            resources.ApplyResources(this.radioButtonMultiProfileMode, "radioButtonMultiProfileMode");
            this.radioButtonMultiProfileMode.Checked = true;
            this.radioButtonMultiProfileMode.Name = "radioButtonMultiProfileMode";
            this.radioButtonMultiProfileMode.TabStop = true;
            this.radioButtonMultiProfileMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxChangeColor
            // 
            resources.ApplyResources(this.checkBoxChangeColor, "checkBoxChangeColor");
            this.checkBoxChangeColor.Checked = true;
            this.checkBoxChangeColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChangeColor.Name = "checkBoxChangeColor";
            this.checkBoxChangeColor.UseVisualStyleBackColor = true;
            this.checkBoxChangeColor.CheckedChanged += new System.EventHandler(this.radioButtonMultiProfileMode_CheckChanged);
            // 
            // radioButtonSingleProfileMode
            // 
            resources.ApplyResources(this.radioButtonSingleProfileMode, "radioButtonSingleProfileMode");
            this.radioButtonSingleProfileMode.Name = "radioButtonSingleProfileMode";
            this.radioButtonSingleProfileMode.UseVisualStyleBackColor = true;
            this.radioButtonSingleProfileMode.CheckedChanged += new System.EventHandler(this.radioButtonMultiProfileMode_CheckChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // colorControlScaleText
            // 
            this.colorControlScaleText.Argb = -16777216;
            resources.ApplyResources(this.colorControlScaleText, "colorControlScaleText");
            this.colorControlScaleText.Blue = 0;
            this.colorControlScaleText.BlueF = 0F;
            this.colorControlScaleText.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorControlScaleText.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorControlScaleText.FooterText = "";
            this.colorControlScaleText.Green = 0;
            this.colorControlScaleText.GreenF = 0F;
            this.colorControlScaleText.Name = "colorControlScaleText";
            this.colorControlScaleText.Red = 0;
            this.colorControlScaleText.RedF = 0F;
            this.colorControlScaleText.ToolTip = "Choose the scale-text\'s color";
            this.toolTip.SetToolTip(this.colorControlScaleText, resources.GetString("colorControlScaleText.ToolTip"));
            this.colorControlScaleText.ColorChanged += new Crystallography.Controls.ColorControl.MyEventHandler(this.Draw);
            // 
            // colorControlScaleLine
            // 
            this.colorControlScaleLine.Argb = -2894893;
            resources.ApplyResources(this.colorControlScaleLine, "colorControlScaleLine");
            this.colorControlScaleLine.Blue = 211;
            this.colorControlScaleLine.BlueF = 0.827451F;
            this.colorControlScaleLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.colorControlScaleLine.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorControlScaleLine.FooterText = "";
            this.colorControlScaleLine.Green = 211;
            this.colorControlScaleLine.GreenF = 0.827451F;
            this.colorControlScaleLine.Name = "colorControlScaleLine";
            this.colorControlScaleLine.Red = 211;
            this.colorControlScaleLine.RedF = 0.827451F;
            this.colorControlScaleLine.ToolTip = "Choose the scale-line\'s color";
            this.toolTip.SetToolTip(this.colorControlScaleLine, resources.GetString("colorControlScaleLine.ToolTip"));
            this.colorControlScaleLine.ColorChanged += new Crystallography.Controls.ColorControl.MyEventHandler(this.Draw);
            // 
            // colorControlBack
            // 
            this.colorControlBack.Argb = -1;
            resources.ApplyResources(this.colorControlBack, "colorControlBack");
            this.colorControlBack.Blue = 255;
            this.colorControlBack.BlueF = 1F;
            this.colorControlBack.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.colorControlBack.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorControlBack.FooterText = "";
            this.colorControlBack.Green = 255;
            this.colorControlBack.GreenF = 1F;
            this.colorControlBack.Name = "colorControlBack";
            this.colorControlBack.Red = 255;
            this.colorControlBack.RedF = 1F;
            this.colorControlBack.ToolTip = "Choose the background color";
            this.toolTip.SetToolTip(this.colorControlBack, resources.GetString("colorControlBack.ToolTip"));
            this.colorControlBack.ColorChanged += new Crystallography.Controls.ColorControl.MyEventHandler(this.Draw);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.toolTip.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.toolTip.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // checkBoxErrorBar
            // 
            resources.ApplyResources(this.checkBoxErrorBar, "checkBoxErrorBar");
            this.checkBoxErrorBar.Name = "checkBoxErrorBar";
            this.toolTip.SetToolTip(this.checkBoxErrorBar, resources.GetString("checkBoxErrorBar.ToolTip"));
            this.checkBoxErrorBar.UseVisualStyleBackColor = true;
            this.checkBoxErrorBar.CheckedChanged += new System.EventHandler(this.checkBoxShowScaleLine_CheckedChanged_1);
            // 
            // checkBoxShowScaleLine
            // 
            resources.ApplyResources(this.checkBoxShowScaleLine, "checkBoxShowScaleLine");
            this.checkBoxShowScaleLine.Name = "checkBoxShowScaleLine";
            this.toolTip.SetToolTip(this.checkBoxShowScaleLine, resources.GetString("checkBoxShowScaleLine.ToolTip"));
            this.checkBoxShowScaleLine.UseVisualStyleBackColor = true;
            this.checkBoxShowScaleLine.CheckedChanged += new System.EventHandler(this.checkBoxShowScaleLine_CheckedChanged_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.HotTrack = true;
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
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
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMaxInt
            // 
            resources.ApplyResources(this.numericUpDownMaxInt, "numericUpDownMaxInt");
            this.numericUpDownMaxInt.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMaxInt.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownMaxInt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMaxInt.Name = "numericUpDownMaxInt";
            this.numericUpDownMaxInt.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownMaxInt.ValueChanged += new System.EventHandler(this.numericUpDownMaxInt_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // numericUpDownMinInt
            // 
            resources.ApplyResources(this.numericUpDownMinInt, "numericUpDownMinInt");
            this.numericUpDownMinInt.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownMinInt.Maximum = new decimal(new int[] {
            65534,
            0,
            0,
            0});
            this.numericUpDownMinInt.Name = "numericUpDownMinInt";
            this.numericUpDownMinInt.ValueChanged += new System.EventHandler(this.numericUpDownMinInt_ValueChanged);
            // 
            // checkBoxShowUnrolledImage
            // 
            resources.ApplyResources(this.checkBoxShowUnrolledImage, "checkBoxShowUnrolledImage");
            this.checkBoxShowUnrolledImage.Checked = true;
            this.checkBoxShowUnrolledImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowUnrolledImage.Name = "checkBoxShowUnrolledImage";
            this.checkBoxShowUnrolledImage.UseVisualStyleBackColor = true;
            this.checkBoxShowUnrolledImage.CheckedChanged += new System.EventHandler(this.checkBoxShowUnrolledImage_CheckedChanged);
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // comboBoxGradient
            // 
            this.comboBoxGradient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxGradient, "comboBoxGradient");
            this.comboBoxGradient.FormattingEnabled = true;
            this.comboBoxGradient.Items.AddRange(new object[] {
            resources.GetString("comboBoxGradient.Items"),
            resources.GetString("comboBoxGradient.Items1")});
            this.comboBoxGradient.Name = "comboBoxGradient";
            this.comboBoxGradient.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxGradient_SelectedIndexChanged);
            // 
            // comboBoxScale2
            // 
            this.comboBoxScale2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxScale2, "comboBoxScale2");
            this.comboBoxScale2.FormattingEnabled = true;
            this.comboBoxScale2.Items.AddRange(new object[] {
            resources.GetString("comboBoxScale2.Items"),
            resources.GetString("comboBoxScale2.Items1")});
            this.comboBoxScale2.Name = "comboBoxScale2";
            this.comboBoxScale2.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxScale2_SelectedIndexChanged);
            // 
            // comboBoxScale1
            // 
            this.comboBoxScale1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxScale1, "comboBoxScale1");
            this.comboBoxScale1.FormattingEnabled = true;
            this.comboBoxScale1.Items.AddRange(new object[] {
            resources.GetString("comboBoxScale1.Items"),
            resources.GetString("comboBoxScale1.Items1")});
            this.comboBoxScale1.Name = "comboBoxScale1";
            this.comboBoxScale1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxScale_SelectedIndexChanged);
            // 
            // graphControlFrequency
            // 
            this.graphControlFrequency.AllowMouseOperation = true;
            resources.ApplyResources(this.graphControlFrequency, "graphControlFrequency");
            this.graphControlFrequency.BackgroundColor = System.Drawing.Color.White;
            this.graphControlFrequency.BottomMargin = 0D;
            this.graphControlFrequency.DivisionLineColor = System.Drawing.Color.Gray;
            this.graphControlFrequency.DivisionSubLineColor = System.Drawing.Color.LightGray;
            this.graphControlFrequency.FixRangeHorizontal = false;
            this.graphControlFrequency.FixRangeVertical = false;
            this.graphControlFrequency.GraphName = "";
            this.graphControlFrequency.HorizontalGradiationTextVisivle = true;
            this.graphControlFrequency.Interpolation = false;
            this.graphControlFrequency.IsIntegerX = true;
            this.graphControlFrequency.IsIntegerY = true;
            this.graphControlFrequency.LabelX = "X:";
            this.graphControlFrequency.LabelY = "Y:";
            this.graphControlFrequency.LeftMargin = 0F;
            this.graphControlFrequency.LineColor = System.Drawing.Color.Red;
            this.graphControlFrequency.LineWidth = 1F;
            this.graphControlFrequency.LowerX = 0D;
            this.graphControlFrequency.LowerY = 0D;
            this.graphControlFrequency.MaximalX = 1D;
            this.graphControlFrequency.MaximalY = 1D;
            this.graphControlFrequency.MinimalX = 0D;
            this.graphControlFrequency.MinimalY = 0D;
            this.graphControlFrequency.Mode = Crystallography.Controls.GraphControl.DrawingMode.Line;
            this.graphControlFrequency.MousePositionVisible = true;
            this.graphControlFrequency.Name = "graphControlFrequency";
            this.graphControlFrequency.OriginPosition = new System.Drawing.Point(40, 20);
            this.graphControlFrequency.Smoothing = false;
            this.graphControlFrequency.TextFont = new System.Drawing.Font("Arial", 9F);
            this.graphControlFrequency.UnitX = "";
            this.graphControlFrequency.UnitY = "";
            this.graphControlFrequency.UpperText = "";
            this.graphControlFrequency.UpperTextVisible = true;
            this.graphControlFrequency.UpperX = 1D;
            this.graphControlFrequency.UpperY = 1D;
            this.graphControlFrequency.UseLineWidth = true;
            this.graphControlFrequency.VerticalGradiationTextVisivle = true;
            this.graphControlFrequency.XLog = true;
            this.graphControlFrequency.XScaleLineVisible = true;
            this.graphControlFrequency.YLog = true;
            this.graphControlFrequency.YScaleLineVisible = true;
            this.graphControlFrequency.LinePositionChanged += new Crystallography.Controls.GraphControl.LinePositionChengedEventHandler(this.graphControlFrequency_LinePositionChanged);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.White;
            this.pictureBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxMain, "pictureBoxMain");
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBoxMain, resources.GetString("pictureBoxMain.ToolTip"));
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.numericBoxUpperY, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelIntensity, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBoxLowerY, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelD, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBoxUpperX, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelTwoTheta, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericBoxLowerX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelX, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // numericBoxUpperY
            // 
            this.numericBoxUpperY.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxUpperY, "numericBoxUpperY");
            this.numericBoxUpperY.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxUpperY.DecimalPlaces = 2;
            this.numericBoxUpperY.Maximum = 1000D;
            this.numericBoxUpperY.Minimum = 0D;
            this.numericBoxUpperY.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericBoxUpperY.MouseSpeed = 1D;
            this.numericBoxUpperY.Multiline = false;
            this.numericBoxUpperY.Name = "numericBoxUpperY";
            this.numericBoxUpperY.RadianValue = 17.453292519943293D;
            this.numericBoxUpperY.ReadOnly = false;
            this.numericBoxUpperY.RestrictLimitValue = true;
            this.numericBoxUpperY.ShowFraction = false;
            this.numericBoxUpperY.ShowPositiveSign = false;
            this.numericBoxUpperY.ShowUpDown = true;
            this.numericBoxUpperY.SkipEventDuringInput = true;
            this.numericBoxUpperY.SmartIncrement = true;
            this.numericBoxUpperY.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxUpperY.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxUpperY.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxUpperY.ThonsandsSeparator = true;
            this.numericBoxUpperY.UpDown_Increment = 1D;
            this.numericBoxUpperY.Value = 1000D;
            this.numericBoxUpperY.WordWrap = false;
            this.numericBoxUpperY.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBox_ValueChanged);
            this.numericBoxUpperY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numericUpDownLimitChange_MouseDown);
            // 
            // labelIntensity
            // 
            resources.ApplyResources(this.labelIntensity, "labelIntensity");
            this.labelIntensity.Name = "labelIntensity";
            // 
            // numericBoxLowerY
            // 
            this.numericBoxLowerY.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxLowerY, "numericBoxLowerY");
            this.numericBoxLowerY.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxLowerY.DecimalPlaces = 2;
            this.numericBoxLowerY.Maximum = 1000D;
            this.numericBoxLowerY.Minimum = 0D;
            this.numericBoxLowerY.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericBoxLowerY.MouseSpeed = 1D;
            this.numericBoxLowerY.Multiline = false;
            this.numericBoxLowerY.Name = "numericBoxLowerY";
            this.numericBoxLowerY.RadianValue = 0D;
            this.numericBoxLowerY.ReadOnly = false;
            this.numericBoxLowerY.RestrictLimitValue = true;
            this.numericBoxLowerY.ShowFraction = false;
            this.numericBoxLowerY.ShowPositiveSign = false;
            this.numericBoxLowerY.ShowUpDown = true;
            this.numericBoxLowerY.SkipEventDuringInput = true;
            this.numericBoxLowerY.SmartIncrement = true;
            this.numericBoxLowerY.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxLowerY.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxLowerY.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxLowerY.ThonsandsSeparator = true;
            this.numericBoxLowerY.UpDown_Increment = 1D;
            this.numericBoxLowerY.Value = 0D;
            this.numericBoxLowerY.WordWrap = false;
            this.numericBoxLowerY.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBox_ValueChanged);
            this.numericBoxLowerY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numericUpDownLimitChange_MouseDown);
            // 
            // labelD
            // 
            resources.ApplyResources(this.labelD, "labelD");
            this.labelD.Name = "labelD";
            // 
            // numericBoxUpperX
            // 
            this.numericBoxUpperX.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxUpperX, "numericBoxUpperX");
            this.numericBoxUpperX.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxUpperX.DecimalPlaces = 2;
            this.numericBoxUpperX.Maximum = 30D;
            this.numericBoxUpperX.Minimum = 0D;
            this.numericBoxUpperX.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericBoxUpperX.MouseSpeed = 1D;
            this.numericBoxUpperX.Multiline = false;
            this.numericBoxUpperX.Name = "numericBoxUpperX";
            this.numericBoxUpperX.RadianValue = 0.52359877559829882D;
            this.numericBoxUpperX.ReadOnly = false;
            this.numericBoxUpperX.RestrictLimitValue = true;
            this.numericBoxUpperX.ShowFraction = false;
            this.numericBoxUpperX.ShowPositiveSign = false;
            this.numericBoxUpperX.ShowUpDown = true;
            this.numericBoxUpperX.SkipEventDuringInput = true;
            this.numericBoxUpperX.SmartIncrement = true;
            this.numericBoxUpperX.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxUpperX.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxUpperX.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxUpperX.ThonsandsSeparator = true;
            this.numericBoxUpperX.UpDown_Increment = 1D;
            this.numericBoxUpperX.Value = 30D;
            this.numericBoxUpperX.WordWrap = false;
            this.numericBoxUpperX.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBox_ValueChanged);
            this.numericBoxUpperX.LimitChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxUpperX_LimitChanged);
            this.numericBoxUpperX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numericUpDownLimitChange_MouseDown);
            // 
            // labelTwoTheta
            // 
            resources.ApplyResources(this.labelTwoTheta, "labelTwoTheta");
            this.labelTwoTheta.Name = "labelTwoTheta";
            // 
            // numericBoxLowerX
            // 
            this.numericBoxLowerX.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxLowerX, "numericBoxLowerX");
            this.numericBoxLowerX.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxLowerX.DecimalPlaces = 2;
            this.numericBoxLowerX.Maximum = 30D;
            this.numericBoxLowerX.Minimum = 0D;
            this.numericBoxLowerX.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericBoxLowerX.MouseSpeed = 1D;
            this.numericBoxLowerX.Multiline = false;
            this.numericBoxLowerX.Name = "numericBoxLowerX";
            this.numericBoxLowerX.RadianValue = 0D;
            this.numericBoxLowerX.ReadOnly = false;
            this.numericBoxLowerX.RestrictLimitValue = true;
            this.numericBoxLowerX.ShowFraction = false;
            this.numericBoxLowerX.ShowPositiveSign = false;
            this.numericBoxLowerX.ShowUpDown = true;
            this.numericBoxLowerX.SkipEventDuringInput = true;
            this.numericBoxLowerX.SmartIncrement = true;
            this.numericBoxLowerX.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxLowerX.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxLowerX.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxLowerX.ThonsandsSeparator = true;
            this.numericBoxLowerX.UpDown_Increment = 1D;
            this.numericBoxLowerX.Value = 0D;
            this.numericBoxLowerX.WordWrap = false;
            this.numericBoxLowerX.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBox_ValueChanged);
            this.numericBoxLowerX.LimitChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxUpperX_LimitChanged);
            this.numericBoxLowerX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numericUpDownLimitChange_MouseDown);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // labelX
            // 
            resources.ApplyResources(this.labelX, "labelX");
            this.labelX.Name = "labelX";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
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
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewProfiles
            // 
            this.dataGridViewProfiles.AllowUserToAddRows = false;
            this.dataGridViewProfiles.AllowUserToDeleteRows = false;
            this.dataGridViewProfiles.AllowUserToResizeColumns = false;
            this.dataGridViewProfiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle70.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle70.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            this.dataGridViewProfiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle70;
            this.dataGridViewProfiles.AutoGenerateColumns = false;
            this.dataGridViewProfiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProfiles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle71.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle71.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle71.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle71.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle71.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProfiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle71;
            resources.ApplyResources(this.dataGridViewProfiles, "dataGridViewProfiles");
            this.dataGridViewProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProfiles.ColumnHeadersVisible = false;
            this.dataGridViewProfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkDataGridViewCheckBoxColumn2,
            this.colorDataGridViewTextBoxColumn,
            this.profileDataGridViewTextBoxColumn});
            this.dataGridViewProfiles.DataSource = this.bindingSourceProfile;
            dataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle72.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle72.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle72.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle72.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle72.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle72.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProfiles.DefaultCellStyle = dataGridViewCellStyle72;
            this.dataGridViewProfiles.MultiSelect = false;
            this.dataGridViewProfiles.Name = "dataGridViewProfiles";
            this.dataGridViewProfiles.ReadOnly = true;
            this.dataGridViewProfiles.RowHeadersVisible = false;
            this.dataGridViewProfiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewProfiles.RowTemplate.Height = 21;
            this.dataGridViewProfiles.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolTip.SetToolTip(this.dataGridViewProfiles, resources.GetString("dataGridViewProfiles.ToolTip"));
            this.dataGridViewProfiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProfiles_CellClick);
            this.dataGridViewProfiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProfiles_CellClick);
            this.dataGridViewProfiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewCrystals_KeyUp);
            // 
            // checkDataGridViewCheckBoxColumn2
            // 
            this.checkDataGridViewCheckBoxColumn2.DataPropertyName = "Check";
            resources.ApplyResources(this.checkDataGridViewCheckBoxColumn2, "checkDataGridViewCheckBoxColumn2");
            this.checkDataGridViewCheckBoxColumn2.Name = "checkDataGridViewCheckBoxColumn2";
            this.checkDataGridViewCheckBoxColumn2.ReadOnly = true;
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
            this.bindingSourceProfile.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet1";
            this.dataSet.Locale = new System.Globalization.CultureInfo("ja");
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkBoxProfileParameter
            // 
            resources.ApplyResources(this.checkBoxProfileParameter, "checkBoxProfileParameter");
            this.checkBoxProfileParameter.Name = "checkBoxProfileParameter";
            this.toolTip.SetToolTip(this.checkBoxProfileParameter, resources.GetString("checkBoxProfileParameter.ToolTip"));
            this.checkBoxProfileParameter.CheckedChanged += new System.EventHandler(this.checkBoxProfileParameter_CheckedChanged);
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.Checked = true;
            this.checkBoxAll.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            resources.ApplyResources(this.checkBoxAll, "checkBoxAll");
            this.checkBoxAll.Name = "checkBoxAll";
            this.toolTip.SetToolTip(this.checkBoxAll, resources.GetString("checkBoxAll.ToolTip"));
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // groupBoxCrystalData
            // 
            this.groupBoxCrystalData.Controls.Add(this.dataGridViewCrystals);
            this.groupBoxCrystalData.Controls.Add(this.checkBoxCrystalParameter);
            resources.ApplyResources(this.groupBoxCrystalData, "groupBoxCrystalData");
            this.groupBoxCrystalData.Name = "groupBoxCrystalData";
            this.groupBoxCrystalData.TabStop = false;
            // 
            // dataGridViewCrystals
            // 
            this.dataGridViewCrystals.AllowUserToAddRows = false;
            this.dataGridViewCrystals.AllowUserToDeleteRows = false;
            this.dataGridViewCrystals.AllowUserToResizeColumns = false;
            this.dataGridViewCrystals.AllowUserToResizeRows = false;
            dataGridViewCellStyle73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle73.SelectionBackColor = System.Drawing.Color.Blue;
            this.dataGridViewCrystals.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle73;
            this.dataGridViewCrystals.AutoGenerateColumns = false;
            this.dataGridViewCrystals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCrystals.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle74.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle74.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle74.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle74.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle74.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle74.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCrystals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle74;
            resources.ApplyResources(this.dataGridViewCrystals, "dataGridViewCrystals");
            this.dataGridViewCrystals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCrystals.ColumnHeadersVisible = false;
            this.dataGridViewCrystals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkDataGridViewCheckBoxColumn1,
            this.PeakColor,
            this.Crystal});
            this.dataGridViewCrystals.DataSource = this.bindingSourceCrystal;
            dataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle76.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            dataGridViewCellStyle76.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle76.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle76.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle76.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCrystals.DefaultCellStyle = dataGridViewCellStyle76;
            this.dataGridViewCrystals.MultiSelect = false;
            this.dataGridViewCrystals.Name = "dataGridViewCrystals";
            this.dataGridViewCrystals.ReadOnly = true;
            this.dataGridViewCrystals.RowHeadersVisible = false;
            this.dataGridViewCrystals.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewCrystals.RowTemplate.Height = 21;
            this.dataGridViewCrystals.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCrystals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolTip.SetToolTip(this.dataGridViewCrystals, resources.GetString("dataGridViewCrystals.ToolTip"));
            this.dataGridViewCrystals.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCrystals_CellMouseClick);
            this.dataGridViewCrystals.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCrystals_CellMouseClick);
            this.dataGridViewCrystals.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewCrystals_KeyUp);
            // 
            // checkDataGridViewCheckBoxColumn1
            // 
            this.checkDataGridViewCheckBoxColumn1.DataPropertyName = "Check";
            resources.ApplyResources(this.checkDataGridViewCheckBoxColumn1, "checkDataGridViewCheckBoxColumn1");
            this.checkDataGridViewCheckBoxColumn1.Name = "checkDataGridViewCheckBoxColumn1";
            this.checkDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.checkDataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PeakColor
            // 
            this.PeakColor.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.PeakColor, "PeakColor");
            this.PeakColor.Name = "PeakColor";
            this.PeakColor.ReadOnly = true;
            this.PeakColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PeakColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Crystal
            // 
            this.Crystal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Crystal.DataPropertyName = "Crystal";
            dataGridViewCellStyle75.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Crystal.DefaultCellStyle = dataGridViewCellStyle75;
            resources.ApplyResources(this.Crystal, "Crystal");
            this.Crystal.Name = "Crystal";
            this.Crystal.ReadOnly = true;
            this.Crystal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // bindingSourceCrystal
            // 
            this.bindingSourceCrystal.DataMember = "DataTableCrystal";
            this.bindingSourceCrystal.DataSource = this.dataSet;
            // 
            // checkBoxCrystalParameter
            // 
            resources.ApplyResources(this.checkBoxCrystalParameter, "checkBoxCrystalParameter");
            this.checkBoxCrystalParameter.Name = "checkBoxCrystalParameter";
            this.toolTip.SetToolTip(this.checkBoxCrystalParameter, resources.GetString("checkBoxCrystalParameter.ToolTip"));
            this.checkBoxCrystalParameter.CheckedChanged += new System.EventHandler(this.checkBoxCrystalParameter_CheckedChanged);
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.macroToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readPatternProfileToolStripMenuItem,
            this.savePatternProfileToolStripMenuItem,
            this.toolStripMenuItemExportExcelFile,
            this.toolStripSeparator1,
            this.readCrystalDataToolStripMenuItem,
            this.readAndAddToolStripMenuItem,
            this.toolStripMenuItemImport,
            this.saveCrystalDataToolStripMenuItem,
            this.toolStripMenuItemExportCIF,
            this.resetInitialCrystalDataToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItemPageSetup,
            this.toolStripMenuItemPrintPreview,
            this.printToolStripMenuItem,
            this.toolStripSeparator9,
            this.コピーToolStripMenuItem,
            this.toolStripMenuItemSaveMetafile,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // readPatternProfileToolStripMenuItem
            // 
            this.readPatternProfileToolStripMenuItem.Name = "readPatternProfileToolStripMenuItem";
            resources.ApplyResources(this.readPatternProfileToolStripMenuItem, "readPatternProfileToolStripMenuItem");
            this.readPatternProfileToolStripMenuItem.Click += new System.EventHandler(this.menuItemFileRead_Click);
            // 
            // savePatternProfileToolStripMenuItem
            // 
            this.savePatternProfileToolStripMenuItem.Name = "savePatternProfileToolStripMenuItem";
            resources.ApplyResources(this.savePatternProfileToolStripMenuItem, "savePatternProfileToolStripMenuItem");
            this.savePatternProfileToolStripMenuItem.Click += new System.EventHandler(this.savePatternProfileToolStripMenuItem_Click);
            // 
            // toolStripMenuItemExportExcelFile
            // 
            this.toolStripMenuItemExportExcelFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asCSVcommaSeperatedFileToolStripMenuItem,
            this.asTSVtabSeparatedValuesFileToolStripMenuItem,
            this.asGSASFileToolStripMenuItem});
            this.toolStripMenuItemExportExcelFile.Name = "toolStripMenuItemExportExcelFile";
            resources.ApplyResources(this.toolStripMenuItemExportExcelFile, "toolStripMenuItemExportExcelFile");
            // 
            // asCSVcommaSeperatedFileToolStripMenuItem
            // 
            this.asCSVcommaSeperatedFileToolStripMenuItem.Name = "asCSVcommaSeperatedFileToolStripMenuItem";
            resources.ApplyResources(this.asCSVcommaSeperatedFileToolStripMenuItem, "asCSVcommaSeperatedFileToolStripMenuItem");
            this.asCSVcommaSeperatedFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemExportCSVFile_Click);
            // 
            // asTSVtabSeparatedValuesFileToolStripMenuItem
            // 
            this.asTSVtabSeparatedValuesFileToolStripMenuItem.Name = "asTSVtabSeparatedValuesFileToolStripMenuItem";
            resources.ApplyResources(this.asTSVtabSeparatedValuesFileToolStripMenuItem, "asTSVtabSeparatedValuesFileToolStripMenuItem");
            this.asTSVtabSeparatedValuesFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemExportCSVFile_Click);
            // 
            // asGSASFileToolStripMenuItem
            // 
            this.asGSASFileToolStripMenuItem.Name = "asGSASFileToolStripMenuItem";
            resources.ApplyResources(this.asGSASFileToolStripMenuItem, "asGSASFileToolStripMenuItem");
            this.asGSASFileToolStripMenuItem.Click += new System.EventHandler(this.exportGSASFormatToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // readCrystalDataToolStripMenuItem
            // 
            this.readCrystalDataToolStripMenuItem.Name = "readCrystalDataToolStripMenuItem";
            resources.ApplyResources(this.readCrystalDataToolStripMenuItem, "readCrystalDataToolStripMenuItem");
            this.readCrystalDataToolStripMenuItem.Click += new System.EventHandler(this.menuItemReadCrystalData_Click);
            // 
            // readAndAddToolStripMenuItem
            // 
            this.readAndAddToolStripMenuItem.Name = "readAndAddToolStripMenuItem";
            resources.ApplyResources(this.readAndAddToolStripMenuItem, "readAndAddToolStripMenuItem");
            this.readAndAddToolStripMenuItem.Click += new System.EventHandler(this.readAndAddToolStripMenuItem_Click);
            // 
            // toolStripMenuItemImport
            // 
            this.toolStripMenuItemImport.Name = "toolStripMenuItemImport";
            resources.ApplyResources(this.toolStripMenuItemImport, "toolStripMenuItemImport");
            this.toolStripMenuItemImport.Click += new System.EventHandler(this.toolStripMenuItemImport_Click);
            // 
            // saveCrystalDataToolStripMenuItem
            // 
            this.saveCrystalDataToolStripMenuItem.Name = "saveCrystalDataToolStripMenuItem";
            resources.ApplyResources(this.saveCrystalDataToolStripMenuItem, "saveCrystalDataToolStripMenuItem");
            this.saveCrystalDataToolStripMenuItem.Click += new System.EventHandler(this.menuItemSaveCrystalData_Click);
            // 
            // toolStripMenuItemExportCIF
            // 
            this.toolStripMenuItemExportCIF.Name = "toolStripMenuItemExportCIF";
            resources.ApplyResources(this.toolStripMenuItemExportCIF, "toolStripMenuItemExportCIF");
            this.toolStripMenuItemExportCIF.Click += new System.EventHandler(this.toolStripMenuItemExportCIF_Click);
            // 
            // resetInitialCrystalDataToolStripMenuItem
            // 
            this.resetInitialCrystalDataToolStripMenuItem.Name = "resetInitialCrystalDataToolStripMenuItem";
            resources.ApplyResources(this.resetInitialCrystalDataToolStripMenuItem, "resetInitialCrystalDataToolStripMenuItem");
            this.resetInitialCrystalDataToolStripMenuItem.Click += new System.EventHandler(this.resetInitialCrystalDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripMenuItemPageSetup
            // 
            this.toolStripMenuItemPageSetup.Name = "toolStripMenuItemPageSetup";
            resources.ApplyResources(this.toolStripMenuItemPageSetup, "toolStripMenuItemPageSetup");
            this.toolStripMenuItemPageSetup.Click += new System.EventHandler(this.menuItemPrintPageSetup_Click);
            // 
            // toolStripMenuItemPrintPreview
            // 
            this.toolStripMenuItemPrintPreview.Name = "toolStripMenuItemPrintPreview";
            resources.ApplyResources(this.toolStripMenuItemPrintPreview, "toolStripMenuItemPrintPreview");
            this.toolStripMenuItemPrintPreview.Click += new System.EventHandler(this.menuItemPrintPreview_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.Click += new System.EventHandler(this.menuItemPrint_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // コピーToolStripMenuItem
            // 
            this.コピーToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BitmapToolStripMenuItem,
            this.copyAsMetafileToolStripMenuItem});
            this.コピーToolStripMenuItem.Name = "コピーToolStripMenuItem";
            resources.ApplyResources(this.コピーToolStripMenuItem, "コピーToolStripMenuItem");
            // 
            // BitmapToolStripMenuItem
            // 
            resources.ApplyResources(this.BitmapToolStripMenuItem, "BitmapToolStripMenuItem");
            this.BitmapToolStripMenuItem.Name = "BitmapToolStripMenuItem";
            // 
            // copyAsMetafileToolStripMenuItem
            // 
            this.copyAsMetafileToolStripMenuItem.Name = "copyAsMetafileToolStripMenuItem";
            resources.ApplyResources(this.copyAsMetafileToolStripMenuItem, "copyAsMetafileToolStripMenuItem");
            this.copyAsMetafileToolStripMenuItem.Click += new System.EventHandler(this.copyAsMetafileToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSaveMetafile
            // 
            this.toolStripMenuItemSaveMetafile.Name = "toolStripMenuItemSaveMetafile";
            resources.ApplyResources(this.toolStripMenuItemSaveMetafile, "toolStripMenuItemSaveMetafile");
            this.toolStripMenuItemSaveMetafile.Click += new System.EventHandler(this.toolStripMenuItemSaveMetafile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            resources.ApplyResources(this.closeToolStripMenuItem, "closeToolStripMenuItem");
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.menuItemClose_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTipToolStripMenuItem,
            this.watchReadClipboardToolStripMenuItem,
            this.watchReadANewProfileToolStripMenuItem,
            this.clearRegistryToolStripMenuItem,
            this.toolStripSeparator7,
            this.ngenCompileToolStripMenuItem});
            resources.ApplyResources(this.optionToolStripMenuItem, "optionToolStripMenuItem");
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            // 
            // toolTipToolStripMenuItem
            // 
            this.toolTipToolStripMenuItem.Checked = true;
            this.toolTipToolStripMenuItem.CheckOnClick = true;
            this.toolTipToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolTipToolStripMenuItem.Name = "toolTipToolStripMenuItem";
            resources.ApplyResources(this.toolTipToolStripMenuItem, "toolTipToolStripMenuItem");
            this.toolTipToolStripMenuItem.Click += new System.EventHandler(this.toolTipToolStripMenuItem_Click);
            // 
            // watchReadClipboardToolStripMenuItem
            // 
            this.watchReadClipboardToolStripMenuItem.Checked = true;
            this.watchReadClipboardToolStripMenuItem.CheckOnClick = true;
            this.watchReadClipboardToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.watchReadClipboardToolStripMenuItem.Name = "watchReadClipboardToolStripMenuItem";
            resources.ApplyResources(this.watchReadClipboardToolStripMenuItem, "watchReadClipboardToolStripMenuItem");
            this.watchReadClipboardToolStripMenuItem.CheckedChanged += new System.EventHandler(this.watchReadClipboardToolStripMenuItem_CheckedChanged);
            // 
            // watchReadANewProfileToolStripMenuItem
            // 
            this.watchReadANewProfileToolStripMenuItem.CheckOnClick = true;
            this.watchReadANewProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDirectoryToTheWatchToolStripMenuItem,
            this.toolStripTextBoxDirectoryToWatch});
            this.watchReadANewProfileToolStripMenuItem.Name = "watchReadANewProfileToolStripMenuItem";
            resources.ApplyResources(this.watchReadANewProfileToolStripMenuItem, "watchReadANewProfileToolStripMenuItem");
            this.watchReadANewProfileToolStripMenuItem.CheckedChanged += new System.EventHandler(this.watchReadANewProfileToolStripMenuItem_CheckedChanged);
            // 
            // setDirectoryToTheWatchToolStripMenuItem
            // 
            this.setDirectoryToTheWatchToolStripMenuItem.Name = "setDirectoryToTheWatchToolStripMenuItem";
            resources.ApplyResources(this.setDirectoryToTheWatchToolStripMenuItem, "setDirectoryToTheWatchToolStripMenuItem");
            this.setDirectoryToTheWatchToolStripMenuItem.Click += new System.EventHandler(this.setDirectoryToTheWatchToolStripMenuItem_Click);
            // 
            // toolStripTextBoxDirectoryToWatch
            // 
            resources.ApplyResources(this.toolStripTextBoxDirectoryToWatch, "toolStripTextBoxDirectoryToWatch");
            this.toolStripTextBoxDirectoryToWatch.Name = "toolStripTextBoxDirectoryToWatch";
            this.toolStripTextBoxDirectoryToWatch.TextChanged += new System.EventHandler(this.toolStripTextBoxDirectoryToWatch_TextChanged);
            // 
            // clearRegistryToolStripMenuItem
            // 
            this.clearRegistryToolStripMenuItem.Name = "clearRegistryToolStripMenuItem";
            resources.ApplyResources(this.clearRegistryToolStripMenuItem, "clearRegistryToolStripMenuItem");
            this.clearRegistryToolStripMenuItem.Click += new System.EventHandler(this.clearRegistryToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // ngenCompileToolStripMenuItem
            // 
            this.ngenCompileToolStripMenuItem.Name = "ngenCompileToolStripMenuItem";
            resources.ApplyResources(this.ngenCompileToolStripMenuItem, "ngenCompileToolStripMenuItem");
            this.ngenCompileToolStripMenuItem.Click += new System.EventHandler(this.ngenCompileToolStripMenuItem_Click);
            // 
            // macroToolStripMenuItem
            // 
            this.macroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolStripMenuItem});
            this.macroToolStripMenuItem.Name = "macroToolStripMenuItem";
            resources.ApplyResources(this.macroToolStripMenuItem, "macroToolStripMenuItem");
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            resources.ApplyResources(this.editorToolStripMenuItem, "editorToolStripMenuItem");
            this.editorToolStripMenuItem.Click += new System.EventHandler(this.editorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMeToolStripMenuItem,
            this.programUpdatesToolStripMenuItem,
            this.hintToolStripMenuItem,
            this.helpwebToolStripMenuItem});
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // aboutMeToolStripMenuItem
            // 
            this.aboutMeToolStripMenuItem.Name = "aboutMeToolStripMenuItem";
            resources.ApplyResources(this.aboutMeToolStripMenuItem, "aboutMeToolStripMenuItem");
            this.aboutMeToolStripMenuItem.Click += new System.EventHandler(this.aboutMeToolStripMenuItem_Click);
            // 
            // programUpdatesToolStripMenuItem
            // 
            this.programUpdatesToolStripMenuItem.Name = "programUpdatesToolStripMenuItem";
            resources.ApplyResources(this.programUpdatesToolStripMenuItem, "programUpdatesToolStripMenuItem");
            this.programUpdatesToolStripMenuItem.Click += new System.EventHandler(this.programUpdatesToolStripMenuItem_Click);
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            resources.ApplyResources(this.hintToolStripMenuItem, "hintToolStripMenuItem");
            this.hintToolStripMenuItem.Click += new System.EventHandler(this.hintToolStripMenuItem_Click);
            // 
            // helpwebToolStripMenuItem
            // 
            this.helpwebToolStripMenuItem.Name = "helpwebToolStripMenuItem";
            resources.ApplyResources(this.helpwebToolStripMenuItem, "helpwebToolStripMenuItem");
            this.helpwebToolStripMenuItem.Click += new System.EventHandler(this.helpwebToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.japaneseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // japaneseToolStripMenuItem
            // 
            resources.ApplyResources(this.japaneseToolStripMenuItem, "japaneseToolStripMenuItem");
            this.japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            this.japaneseToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // toolStrip2
            // 
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCrystalParameter,
            this.toolStripSeparator4,
            this.toolStripButtonProfileParameter,
            this.toolStripSeparator6,
            this.toolStripButtonEquationOfState,
            this.toolStripSeparator8,
            this.toolStripButtonFittingParameter,
            this.toolStripSeparator5,
            this.toolStripButtonCellFinder,
            this.toolStripSeparator11,
            this.toolStripButtonStressAnalysis,
            this.toolStripButtonAtomicPositonFinder,
            this.toolStripSeparator10,
            this.toolStripSeparator12,
            this.toolStripButtonLPO});
            this.toolStrip2.Name = "toolStrip2";
            // 
            // toolStripButtonCrystalParameter
            // 
            resources.ApplyResources(this.toolStripButtonCrystalParameter, "toolStripButtonCrystalParameter");
            this.toolStripButtonCrystalParameter.Name = "toolStripButtonCrystalParameter";
            this.toolStripButtonCrystalParameter.Click += new System.EventHandler(this.toolStripButtonCrystalParameter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripButtonProfileParameter
            // 
            resources.ApplyResources(this.toolStripButtonProfileParameter, "toolStripButtonProfileParameter");
            this.toolStripButtonProfileParameter.Name = "toolStripButtonProfileParameter";
            this.toolStripButtonProfileParameter.Click += new System.EventHandler(this.toolStripButtonProfileParameter_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // toolStripButtonEquationOfState
            // 
            this.toolStripButtonEquationOfState.CheckOnClick = true;
            resources.ApplyResources(this.toolStripButtonEquationOfState, "toolStripButtonEquationOfState");
            this.toolStripButtonEquationOfState.Name = "toolStripButtonEquationOfState";
            this.toolStripButtonEquationOfState.CheckedChanged += new System.EventHandler(this.toolStripButtonEquationOfState_CheckedChanged);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // toolStripButtonFittingParameter
            // 
            this.toolStripButtonFittingParameter.CheckOnClick = true;
            resources.ApplyResources(this.toolStripButtonFittingParameter, "toolStripButtonFittingParameter");
            this.toolStripButtonFittingParameter.Name = "toolStripButtonFittingParameter";
            this.toolStripButtonFittingParameter.CheckedChanged += new System.EventHandler(this.toolStripButtonFittingParameter_CheckedChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripButtonCellFinder
            // 
            this.toolStripButtonCellFinder.CheckOnClick = true;
            this.toolStripButtonCellFinder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonCellFinder, "toolStripButtonCellFinder");
            this.toolStripButtonCellFinder.Name = "toolStripButtonCellFinder";
            this.toolStripButtonCellFinder.CheckedChanged += new System.EventHandler(this.toolStripButtonCellFinder_CheckedChanged);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // toolStripButtonAtomicPositonFinder
            // 
            this.toolStripButtonAtomicPositonFinder.CheckOnClick = true;
            this.toolStripButtonAtomicPositonFinder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonAtomicPositonFinder, "toolStripButtonAtomicPositonFinder");
            this.toolStripButtonAtomicPositonFinder.Name = "toolStripButtonAtomicPositonFinder";
            this.toolStripButtonAtomicPositonFinder.CheckedChanged += new System.EventHandler(this.toolStripButtonAtomicPositonFinder_CheckedChanged);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // toolStripButtonStressAnalysis
            // 
            this.toolStripButtonStressAnalysis.CheckOnClick = true;
            this.toolStripButtonStressAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonStressAnalysis, "toolStripButtonStressAnalysis");
            this.toolStripButtonStressAnalysis.Name = "toolStripButtonStressAnalysis";
            this.toolStripButtonStressAnalysis.CheckedChanged += new System.EventHandler(this.toolStripButtonStressAnalysis_CheckedChanged);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // toolStripButtonLPO
            // 
            this.toolStripButtonLPO.CheckOnClick = true;
            this.toolStripButtonLPO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonLPO, "toolStripButtonLPO");
            this.toolStripButtonLPO.Name = "toolStripButtonLPO";
            this.toolStripButtonLPO.CheckedChanged += new System.EventHandler(this.toolStripButtonLPO_CheckedChanged);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            // 
            // buttonAu
            // 
            resources.ApplyResources(this.buttonAu, "buttonAu");
            this.buttonAu.Name = "buttonAu";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            this.checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            resources.ApplyResources(this.checkDataGridViewCheckBoxColumn, "checkDataGridViewCheckBoxColumn");
            this.checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            resources.ApplyResources(this.Check, "Check");
            this.Check.Name = "Check";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Crystal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Crystal";
            dataGridViewCellStyle77.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle77;
            resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Crystal";
            dataGridViewCellStyle78.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle78;
            resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Crystal";
            dataGridViewCellStyle79.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle79;
            resources.ApplyResources(this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Crystal";
            dataGridViewCellStyle80.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle80;
            resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Crystal";
            dataGridViewCellStyle81.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle81;
            resources.ApplyResources(this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Crystal";
            dataGridViewCellStyle82.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle82;
            resources.ApplyResources(this.dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Crystal";
            dataGridViewCellStyle83.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle83;
            resources.ApplyResources(this.dataGridViewTextBoxColumn16, "dataGridViewTextBoxColumn16");
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Crystal";
            dataGridViewCellStyle84.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle84;
            resources.ApplyResources(this.dataGridViewTextBoxColumn17, "dataGridViewTextBoxColumn17");
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Crystal";
            dataGridViewCellStyle85.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle85;
            resources.ApplyResources(this.dataGridViewTextBoxColumn18, "dataGridViewTextBoxColumn18");
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Crystal";
            dataGridViewCellStyle86.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle86;
            resources.ApplyResources(this.dataGridViewTextBoxColumn19, "dataGridViewTextBoxColumn19");
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Crystal";
            dataGridViewCellStyle87.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle87;
            resources.ApplyResources(this.dataGridViewTextBoxColumn20, "dataGridViewTextBoxColumn20");
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Crystal";
            dataGridViewCellStyle88.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle88;
            resources.ApplyResources(this.dataGridViewTextBoxColumn21, "dataGridViewTextBoxColumn21");
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Crystal";
            dataGridViewCellStyle89.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle89;
            resources.ApplyResources(this.dataGridViewTextBoxColumn22, "dataGridViewTextBoxColumn22");
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Crystal";
            dataGridViewCellStyle90.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle90;
            resources.ApplyResources(this.dataGridViewTextBoxColumn23, "dataGridViewTextBoxColumn23");
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewTextBoxColumn25, "dataGridViewTextBoxColumn25");
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
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
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Crystal";
            dataGridViewCellStyle91.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle91;
            resources.ApplyResources(this.dataGridViewTextBoxColumn24, "dataGridViewTextBoxColumn24");
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn2, "dataGridViewImageColumn2");
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn26.DataPropertyName = "Crystal";
            dataGridViewCellStyle92.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle92;
            resources.ApplyResources(this.dataGridViewTextBoxColumn26, "dataGridViewTextBoxColumn26");
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn3, "dataGridViewImageColumn3");
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn27.DataPropertyName = "Crystal";
            dataGridViewCellStyle93.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn27.DefaultCellStyle = dataGridViewCellStyle93;
            resources.ApplyResources(this.dataGridViewTextBoxColumn27, "dataGridViewTextBoxColumn27");
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            this.dataGridViewTextBoxColumn27.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn30.DataPropertyName = "Crystal";
            dataGridViewCellStyle94.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle94;
            resources.ApplyResources(this.dataGridViewTextBoxColumn30, "dataGridViewTextBoxColumn30");
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn4, "dataGridViewImageColumn4");
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn28.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn28, "dataGridViewTextBoxColumn28");
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // dataGridViewImageColumn5
            // 
            this.dataGridViewImageColumn5.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn5, "dataGridViewImageColumn5");
            this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
            this.dataGridViewImageColumn5.ReadOnly = true;
            this.dataGridViewImageColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn29.DataPropertyName = "Color";
            dataGridViewCellStyle95.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle95;
            resources.ApplyResources(this.dataGridViewTextBoxColumn29, "dataGridViewTextBoxColumn29");
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn6
            // 
            this.dataGridViewImageColumn6.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn6, "dataGridViewImageColumn6");
            this.dataGridViewImageColumn6.Name = "dataGridViewImageColumn6";
            this.dataGridViewImageColumn6.ReadOnly = true;
            this.dataGridViewImageColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn31.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn31, "dataGridViewTextBoxColumn31");
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            // 
            // dataGridViewImageColumn7
            // 
            this.dataGridViewImageColumn7.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn7, "dataGridViewImageColumn7");
            this.dataGridViewImageColumn7.Name = "dataGridViewImageColumn7";
            this.dataGridViewImageColumn7.ReadOnly = true;
            this.dataGridViewImageColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn32.DataPropertyName = "Crystal";
            dataGridViewCellStyle96.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle96;
            resources.ApplyResources(this.dataGridViewTextBoxColumn32, "dataGridViewTextBoxColumn32");
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn8
            // 
            this.dataGridViewImageColumn8.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn8, "dataGridViewImageColumn8");
            this.dataGridViewImageColumn8.Name = "dataGridViewImageColumn8";
            this.dataGridViewImageColumn8.ReadOnly = true;
            this.dataGridViewImageColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn33, "dataGridViewTextBoxColumn33");
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            // 
            // dataGridViewImageColumn9
            // 
            this.dataGridViewImageColumn9.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn9, "dataGridViewImageColumn9");
            this.dataGridViewImageColumn9.Name = "dataGridViewImageColumn9";
            this.dataGridViewImageColumn9.ReadOnly = true;
            this.dataGridViewImageColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn34.DataPropertyName = "Crystal";
            dataGridViewCellStyle97.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn34.DefaultCellStyle = dataGridViewCellStyle97;
            resources.ApplyResources(this.dataGridViewTextBoxColumn34, "dataGridViewTextBoxColumn34");
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn10
            // 
            this.dataGridViewImageColumn10.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn10, "dataGridViewImageColumn10");
            this.dataGridViewImageColumn10.Name = "dataGridViewImageColumn10";
            this.dataGridViewImageColumn10.ReadOnly = true;
            this.dataGridViewImageColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn35.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn35, "dataGridViewTextBoxColumn35");
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            // 
            // dataGridViewImageColumn11
            // 
            this.dataGridViewImageColumn11.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn11, "dataGridViewImageColumn11");
            this.dataGridViewImageColumn11.Name = "dataGridViewImageColumn11";
            this.dataGridViewImageColumn11.ReadOnly = true;
            this.dataGridViewImageColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn36.DataPropertyName = "Crystal";
            dataGridViewCellStyle98.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn36.DefaultCellStyle = dataGridViewCellStyle98;
            resources.ApplyResources(this.dataGridViewTextBoxColumn36, "dataGridViewTextBoxColumn36");
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn12
            // 
            this.dataGridViewImageColumn12.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn12, "dataGridViewImageColumn12");
            this.dataGridViewImageColumn12.Name = "dataGridViewImageColumn12";
            this.dataGridViewImageColumn12.ReadOnly = true;
            this.dataGridViewImageColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn37.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn37, "dataGridViewTextBoxColumn37");
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            // 
            // dataGridViewImageColumn13
            // 
            this.dataGridViewImageColumn13.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn13, "dataGridViewImageColumn13");
            this.dataGridViewImageColumn13.Name = "dataGridViewImageColumn13";
            this.dataGridViewImageColumn13.ReadOnly = true;
            this.dataGridViewImageColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn38.DataPropertyName = "Crystal";
            dataGridViewCellStyle99.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle99;
            resources.ApplyResources(this.dataGridViewTextBoxColumn38, "dataGridViewTextBoxColumn38");
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn15
            // 
            this.dataGridViewImageColumn15.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn15, "dataGridViewImageColumn15");
            this.dataGridViewImageColumn15.Name = "dataGridViewImageColumn15";
            this.dataGridViewImageColumn15.ReadOnly = true;
            this.dataGridViewImageColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn40.DataPropertyName = "Crystal";
            dataGridViewCellStyle100.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn40.DefaultCellStyle = dataGridViewCellStyle100;
            resources.ApplyResources(this.dataGridViewTextBoxColumn40, "dataGridViewTextBoxColumn40");
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn14
            // 
            this.dataGridViewImageColumn14.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn14, "dataGridViewImageColumn14");
            this.dataGridViewImageColumn14.Name = "dataGridViewImageColumn14";
            this.dataGridViewImageColumn14.ReadOnly = true;
            this.dataGridViewImageColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn39.DataPropertyName = "Profile";
            dataGridViewCellStyle101.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle101;
            resources.ApplyResources(this.dataGridViewTextBoxColumn39, "dataGridViewTextBoxColumn39");
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn16
            // 
            this.dataGridViewImageColumn16.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn16, "dataGridViewImageColumn16");
            this.dataGridViewImageColumn16.Name = "dataGridViewImageColumn16";
            this.dataGridViewImageColumn16.ReadOnly = true;
            this.dataGridViewImageColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn41.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn41, "dataGridViewTextBoxColumn41");
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            // 
            // dataGridViewImageColumn17
            // 
            this.dataGridViewImageColumn17.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn17, "dataGridViewImageColumn17");
            this.dataGridViewImageColumn17.Name = "dataGridViewImageColumn17";
            this.dataGridViewImageColumn17.ReadOnly = true;
            this.dataGridViewImageColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn42.DataPropertyName = "Crystal";
            dataGridViewCellStyle102.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn42.DefaultCellStyle = dataGridViewCellStyle102;
            resources.ApplyResources(this.dataGridViewTextBoxColumn42, "dataGridViewTextBoxColumn42");
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn19
            // 
            this.dataGridViewImageColumn19.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn19, "dataGridViewImageColumn19");
            this.dataGridViewImageColumn19.Name = "dataGridViewImageColumn19";
            this.dataGridViewImageColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn44.DataPropertyName = "Crystal";
            dataGridViewCellStyle103.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn44.DefaultCellStyle = dataGridViewCellStyle103;
            resources.ApplyResources(this.dataGridViewTextBoxColumn44, "dataGridViewTextBoxColumn44");
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn18
            // 
            this.dataGridViewImageColumn18.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn18, "dataGridViewImageColumn18");
            this.dataGridViewImageColumn18.Name = "dataGridViewImageColumn18";
            this.dataGridViewImageColumn18.ReadOnly = true;
            this.dataGridViewImageColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn43.DataPropertyName = "Profile";
            dataGridViewCellStyle104.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn43.DefaultCellStyle = dataGridViewCellStyle104;
            resources.ApplyResources(this.dataGridViewTextBoxColumn43, "dataGridViewTextBoxColumn43");
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            this.dataGridViewTextBoxColumn43.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn20
            // 
            this.dataGridViewImageColumn20.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn20, "dataGridViewImageColumn20");
            this.dataGridViewImageColumn20.Name = "dataGridViewImageColumn20";
            this.dataGridViewImageColumn20.ReadOnly = true;
            this.dataGridViewImageColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn45.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn45, "dataGridViewTextBoxColumn45");
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            // 
            // dataGridViewImageColumn21
            // 
            this.dataGridViewImageColumn21.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn21, "dataGridViewImageColumn21");
            this.dataGridViewImageColumn21.Name = "dataGridViewImageColumn21";
            this.dataGridViewImageColumn21.ReadOnly = true;
            this.dataGridViewImageColumn21.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn46.DataPropertyName = "Crystal";
            dataGridViewCellStyle105.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn46.DefaultCellStyle = dataGridViewCellStyle105;
            resources.ApplyResources(this.dataGridViewTextBoxColumn46, "dataGridViewTextBoxColumn46");
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            this.dataGridViewTextBoxColumn46.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn22
            // 
            this.dataGridViewImageColumn22.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn22, "dataGridViewImageColumn22");
            this.dataGridViewImageColumn22.Name = "dataGridViewImageColumn22";
            this.dataGridViewImageColumn22.ReadOnly = true;
            this.dataGridViewImageColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn47.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn47, "dataGridViewTextBoxColumn47");
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.ReadOnly = true;
            // 
            // dataGridViewImageColumn23
            // 
            this.dataGridViewImageColumn23.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn23, "dataGridViewImageColumn23");
            this.dataGridViewImageColumn23.Name = "dataGridViewImageColumn23";
            this.dataGridViewImageColumn23.ReadOnly = true;
            this.dataGridViewImageColumn23.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn48.DataPropertyName = "Crystal";
            dataGridViewCellStyle106.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn48.DefaultCellStyle = dataGridViewCellStyle106;
            resources.ApplyResources(this.dataGridViewTextBoxColumn48, "dataGridViewTextBoxColumn48");
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.ReadOnly = true;
            this.dataGridViewTextBoxColumn48.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn24
            // 
            this.dataGridViewImageColumn24.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn24, "dataGridViewImageColumn24");
            this.dataGridViewImageColumn24.Name = "dataGridViewImageColumn24";
            this.dataGridViewImageColumn24.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn49.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn49, "dataGridViewTextBoxColumn49");
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            // 
            // dataGridViewImageColumn25
            // 
            this.dataGridViewImageColumn25.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn25, "dataGridViewImageColumn25");
            this.dataGridViewImageColumn25.Name = "dataGridViewImageColumn25";
            this.dataGridViewImageColumn25.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn50.DataPropertyName = "Crystal";
            dataGridViewCellStyle107.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn50.DefaultCellStyle = dataGridViewCellStyle107;
            resources.ApplyResources(this.dataGridViewTextBoxColumn50, "dataGridViewTextBoxColumn50");
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn26
            // 
            this.dataGridViewImageColumn26.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn26, "dataGridViewImageColumn26");
            this.dataGridViewImageColumn26.Name = "dataGridViewImageColumn26";
            this.dataGridViewImageColumn26.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn51.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn51, "dataGridViewTextBoxColumn51");
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            // 
            // dataGridViewImageColumn27
            // 
            this.dataGridViewImageColumn27.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn27, "dataGridViewImageColumn27");
            this.dataGridViewImageColumn27.Name = "dataGridViewImageColumn27";
            this.dataGridViewImageColumn27.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn52.DataPropertyName = "Crystal";
            dataGridViewCellStyle108.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn52.DefaultCellStyle = dataGridViewCellStyle108;
            resources.ApplyResources(this.dataGridViewTextBoxColumn52, "dataGridViewTextBoxColumn52");
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn29
            // 
            this.dataGridViewImageColumn29.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn29, "dataGridViewImageColumn29");
            this.dataGridViewImageColumn29.Name = "dataGridViewImageColumn29";
            this.dataGridViewImageColumn29.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn54.DataPropertyName = "Crystal";
            dataGridViewCellStyle109.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn54.DefaultCellStyle = dataGridViewCellStyle109;
            resources.ApplyResources(this.dataGridViewTextBoxColumn54, "dataGridViewTextBoxColumn54");
            this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            this.dataGridViewTextBoxColumn54.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn28
            // 
            this.dataGridViewImageColumn28.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn28, "dataGridViewImageColumn28");
            this.dataGridViewImageColumn28.Name = "dataGridViewImageColumn28";
            this.dataGridViewImageColumn28.ReadOnly = true;
            this.dataGridViewImageColumn28.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn53.DataPropertyName = "Profile";
            dataGridViewCellStyle110.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn53.DefaultCellStyle = dataGridViewCellStyle110;
            resources.ApplyResources(this.dataGridViewTextBoxColumn53, "dataGridViewTextBoxColumn53");
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.ReadOnly = true;
            this.dataGridViewTextBoxColumn53.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn30
            // 
            this.dataGridViewImageColumn30.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn30, "dataGridViewImageColumn30");
            this.dataGridViewImageColumn30.Name = "dataGridViewImageColumn30";
            this.dataGridViewImageColumn30.ReadOnly = true;
            this.dataGridViewImageColumn30.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn55
            // 
            this.dataGridViewTextBoxColumn55.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn55.DataPropertyName = "Profile";
            dataGridViewCellStyle111.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn55.DefaultCellStyle = dataGridViewCellStyle111;
            resources.ApplyResources(this.dataGridViewTextBoxColumn55, "dataGridViewTextBoxColumn55");
            this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            this.dataGridViewTextBoxColumn55.ReadOnly = true;
            this.dataGridViewTextBoxColumn55.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn31
            // 
            this.dataGridViewImageColumn31.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn31, "dataGridViewImageColumn31");
            this.dataGridViewImageColumn31.Name = "dataGridViewImageColumn31";
            this.dataGridViewImageColumn31.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn56
            // 
            this.dataGridViewTextBoxColumn56.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn56.DataPropertyName = "Crystal";
            dataGridViewCellStyle112.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn56.DefaultCellStyle = dataGridViewCellStyle112;
            resources.ApplyResources(this.dataGridViewTextBoxColumn56, "dataGridViewTextBoxColumn56");
            this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
            this.dataGridViewTextBoxColumn56.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn32
            // 
            this.dataGridViewImageColumn32.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn32, "dataGridViewImageColumn32");
            this.dataGridViewImageColumn32.Name = "dataGridViewImageColumn32";
            this.dataGridViewImageColumn32.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn57.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn57, "dataGridViewTextBoxColumn57");
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            // 
            // dataGridViewImageColumn33
            // 
            this.dataGridViewImageColumn33.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn33, "dataGridViewImageColumn33");
            this.dataGridViewImageColumn33.Name = "dataGridViewImageColumn33";
            this.dataGridViewImageColumn33.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn58
            // 
            this.dataGridViewTextBoxColumn58.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn58.DataPropertyName = "Crystal";
            dataGridViewCellStyle113.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn58.DefaultCellStyle = dataGridViewCellStyle113;
            resources.ApplyResources(this.dataGridViewTextBoxColumn58, "dataGridViewTextBoxColumn58");
            this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
            this.dataGridViewTextBoxColumn58.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn34
            // 
            this.dataGridViewImageColumn34.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn34, "dataGridViewImageColumn34");
            this.dataGridViewImageColumn34.Name = "dataGridViewImageColumn34";
            this.dataGridViewImageColumn34.ReadOnly = true;
            this.dataGridViewImageColumn34.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn59
            // 
            this.dataGridViewTextBoxColumn59.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn59.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn59, "dataGridViewTextBoxColumn59");
            this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
            this.dataGridViewTextBoxColumn59.ReadOnly = true;
            // 
            // dataGridViewImageColumn35
            // 
            this.dataGridViewImageColumn35.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn35, "dataGridViewImageColumn35");
            this.dataGridViewImageColumn35.Name = "dataGridViewImageColumn35";
            this.dataGridViewImageColumn35.ReadOnly = true;
            this.dataGridViewImageColumn35.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn35.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn60.DataPropertyName = "Crystal";
            dataGridViewCellStyle114.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn60.DefaultCellStyle = dataGridViewCellStyle114;
            resources.ApplyResources(this.dataGridViewTextBoxColumn60, "dataGridViewTextBoxColumn60");
            this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
            this.dataGridViewTextBoxColumn60.ReadOnly = true;
            this.dataGridViewTextBoxColumn60.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn36
            // 
            this.dataGridViewImageColumn36.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn36, "dataGridViewImageColumn36");
            this.dataGridViewImageColumn36.Name = "dataGridViewImageColumn36";
            this.dataGridViewImageColumn36.ReadOnly = true;
            this.dataGridViewImageColumn36.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn61
            // 
            this.dataGridViewTextBoxColumn61.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn61.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn61, "dataGridViewTextBoxColumn61");
            this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
            this.dataGridViewTextBoxColumn61.ReadOnly = true;
            // 
            // dataGridViewImageColumn37
            // 
            this.dataGridViewImageColumn37.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn37, "dataGridViewImageColumn37");
            this.dataGridViewImageColumn37.Name = "dataGridViewImageColumn37";
            this.dataGridViewImageColumn37.ReadOnly = true;
            this.dataGridViewImageColumn37.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn37.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn62
            // 
            this.dataGridViewTextBoxColumn62.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn62.DataPropertyName = "Crystal";
            dataGridViewCellStyle115.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn62.DefaultCellStyle = dataGridViewCellStyle115;
            resources.ApplyResources(this.dataGridViewTextBoxColumn62, "dataGridViewTextBoxColumn62");
            this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
            this.dataGridViewTextBoxColumn62.ReadOnly = true;
            this.dataGridViewTextBoxColumn62.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn38
            // 
            this.dataGridViewImageColumn38.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn38, "dataGridViewImageColumn38");
            this.dataGridViewImageColumn38.Name = "dataGridViewImageColumn38";
            this.dataGridViewImageColumn38.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn38.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn63
            // 
            this.dataGridViewTextBoxColumn63.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn63.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn63, "dataGridViewTextBoxColumn63");
            this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
            // 
            // dataGridViewImageColumn39
            // 
            this.dataGridViewImageColumn39.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn39, "dataGridViewImageColumn39");
            this.dataGridViewImageColumn39.Name = "dataGridViewImageColumn39";
            this.dataGridViewImageColumn39.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn39.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn64
            // 
            this.dataGridViewTextBoxColumn64.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn64.DataPropertyName = "Crystal";
            dataGridViewCellStyle116.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn64.DefaultCellStyle = dataGridViewCellStyle116;
            resources.ApplyResources(this.dataGridViewTextBoxColumn64, "dataGridViewTextBoxColumn64");
            this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
            this.dataGridViewTextBoxColumn64.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn40
            // 
            this.dataGridViewImageColumn40.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn40, "dataGridViewImageColumn40");
            this.dataGridViewImageColumn40.Name = "dataGridViewImageColumn40";
            this.dataGridViewImageColumn40.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn40.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn65
            // 
            this.dataGridViewTextBoxColumn65.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn65.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn65, "dataGridViewTextBoxColumn65");
            this.dataGridViewTextBoxColumn65.Name = "dataGridViewTextBoxColumn65";
            // 
            // dataGridViewImageColumn41
            // 
            this.dataGridViewImageColumn41.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn41, "dataGridViewImageColumn41");
            this.dataGridViewImageColumn41.Name = "dataGridViewImageColumn41";
            this.dataGridViewImageColumn41.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn41.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn66
            // 
            this.dataGridViewTextBoxColumn66.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn66.DataPropertyName = "Crystal";
            dataGridViewCellStyle117.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn66.DefaultCellStyle = dataGridViewCellStyle117;
            resources.ApplyResources(this.dataGridViewTextBoxColumn66, "dataGridViewTextBoxColumn66");
            this.dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
            this.dataGridViewTextBoxColumn66.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn42
            // 
            this.dataGridViewImageColumn42.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn42, "dataGridViewImageColumn42");
            this.dataGridViewImageColumn42.Name = "dataGridViewImageColumn42";
            this.dataGridViewImageColumn42.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn42.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn67
            // 
            this.dataGridViewTextBoxColumn67.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn67.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn67, "dataGridViewTextBoxColumn67");
            this.dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
            // 
            // dataGridViewImageColumn43
            // 
            this.dataGridViewImageColumn43.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn43, "dataGridViewImageColumn43");
            this.dataGridViewImageColumn43.Name = "dataGridViewImageColumn43";
            this.dataGridViewImageColumn43.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn43.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn68
            // 
            this.dataGridViewTextBoxColumn68.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn68.DataPropertyName = "Crystal";
            dataGridViewCellStyle118.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn68.DefaultCellStyle = dataGridViewCellStyle118;
            resources.ApplyResources(this.dataGridViewTextBoxColumn68, "dataGridViewTextBoxColumn68");
            this.dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
            this.dataGridViewTextBoxColumn68.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn44
            // 
            this.dataGridViewImageColumn44.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn44, "dataGridViewImageColumn44");
            this.dataGridViewImageColumn44.Name = "dataGridViewImageColumn44";
            this.dataGridViewImageColumn44.ReadOnly = true;
            this.dataGridViewImageColumn44.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn44.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn69
            // 
            this.dataGridViewTextBoxColumn69.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn69.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn69, "dataGridViewTextBoxColumn69");
            this.dataGridViewTextBoxColumn69.Name = "dataGridViewTextBoxColumn69";
            this.dataGridViewTextBoxColumn69.ReadOnly = true;
            // 
            // dataGridViewImageColumn45
            // 
            this.dataGridViewImageColumn45.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn45, "dataGridViewImageColumn45");
            this.dataGridViewImageColumn45.Name = "dataGridViewImageColumn45";
            this.dataGridViewImageColumn45.ReadOnly = true;
            this.dataGridViewImageColumn45.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn45.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn70
            // 
            this.dataGridViewTextBoxColumn70.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn70.DataPropertyName = "Crystal";
            dataGridViewCellStyle119.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn70.DefaultCellStyle = dataGridViewCellStyle119;
            resources.ApplyResources(this.dataGridViewTextBoxColumn70, "dataGridViewTextBoxColumn70");
            this.dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
            this.dataGridViewTextBoxColumn70.ReadOnly = true;
            this.dataGridViewTextBoxColumn70.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn46
            // 
            this.dataGridViewImageColumn46.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn46, "dataGridViewImageColumn46");
            this.dataGridViewImageColumn46.Name = "dataGridViewImageColumn46";
            this.dataGridViewImageColumn46.ReadOnly = true;
            this.dataGridViewImageColumn46.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn46.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn71
            // 
            this.dataGridViewTextBoxColumn71.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn71.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn71, "dataGridViewTextBoxColumn71");
            this.dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
            this.dataGridViewTextBoxColumn71.ReadOnly = true;
            // 
            // dataGridViewImageColumn47
            // 
            this.dataGridViewImageColumn47.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn47, "dataGridViewImageColumn47");
            this.dataGridViewImageColumn47.Name = "dataGridViewImageColumn47";
            this.dataGridViewImageColumn47.ReadOnly = true;
            this.dataGridViewImageColumn47.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn47.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn72
            // 
            this.dataGridViewTextBoxColumn72.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn72.DataPropertyName = "Crystal";
            dataGridViewCellStyle120.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn72.DefaultCellStyle = dataGridViewCellStyle120;
            resources.ApplyResources(this.dataGridViewTextBoxColumn72, "dataGridViewTextBoxColumn72");
            this.dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
            this.dataGridViewTextBoxColumn72.ReadOnly = true;
            this.dataGridViewTextBoxColumn72.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn48
            // 
            this.dataGridViewImageColumn48.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn48, "dataGridViewImageColumn48");
            this.dataGridViewImageColumn48.Name = "dataGridViewImageColumn48";
            this.dataGridViewImageColumn48.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn48.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn73
            // 
            this.dataGridViewTextBoxColumn73.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn73.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn73, "dataGridViewTextBoxColumn73");
            this.dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
            // 
            // dataGridViewImageColumn49
            // 
            this.dataGridViewImageColumn49.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn49, "dataGridViewImageColumn49");
            this.dataGridViewImageColumn49.Name = "dataGridViewImageColumn49";
            this.dataGridViewImageColumn49.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn49.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn74
            // 
            this.dataGridViewTextBoxColumn74.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn74.DataPropertyName = "Crystal";
            dataGridViewCellStyle121.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn74.DefaultCellStyle = dataGridViewCellStyle121;
            resources.ApplyResources(this.dataGridViewTextBoxColumn74, "dataGridViewTextBoxColumn74");
            this.dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
            this.dataGridViewTextBoxColumn74.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // timerBlinkDiffraction
            // 
            this.timerBlinkDiffraction.Interval = 400;
            this.timerBlinkDiffraction.Tick += new System.EventHandler(this.timerBlinkDiffraction_Tick);
            // 
            // dataGridViewImageColumn51
            // 
            this.dataGridViewImageColumn51.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn51, "dataGridViewImageColumn51");
            this.dataGridViewImageColumn51.Name = "dataGridViewImageColumn51";
            this.dataGridViewImageColumn51.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn51.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn76
            // 
            this.dataGridViewTextBoxColumn76.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn76.DataPropertyName = "Crystal";
            dataGridViewCellStyle122.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn76.DefaultCellStyle = dataGridViewCellStyle122;
            resources.ApplyResources(this.dataGridViewTextBoxColumn76, "dataGridViewTextBoxColumn76");
            this.dataGridViewTextBoxColumn76.Name = "dataGridViewTextBoxColumn76";
            this.dataGridViewTextBoxColumn76.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn52
            // 
            this.dataGridViewImageColumn52.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn52, "dataGridViewImageColumn52");
            this.dataGridViewImageColumn52.Name = "dataGridViewImageColumn52";
            this.dataGridViewImageColumn52.ReadOnly = true;
            this.dataGridViewImageColumn52.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn52.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn77
            // 
            this.dataGridViewTextBoxColumn77.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn77.DataPropertyName = "Crystal";
            dataGridViewCellStyle123.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn77.DefaultCellStyle = dataGridViewCellStyle123;
            resources.ApplyResources(this.dataGridViewTextBoxColumn77, "dataGridViewTextBoxColumn77");
            this.dataGridViewTextBoxColumn77.Name = "dataGridViewTextBoxColumn77";
            this.dataGridViewTextBoxColumn77.ReadOnly = true;
            this.dataGridViewTextBoxColumn77.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn50
            // 
            this.dataGridViewImageColumn50.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn50, "dataGridViewImageColumn50");
            this.dataGridViewImageColumn50.Name = "dataGridViewImageColumn50";
            this.dataGridViewImageColumn50.ReadOnly = true;
            this.dataGridViewImageColumn50.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn50.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn75
            // 
            this.dataGridViewTextBoxColumn75.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn75.DataPropertyName = "Profile";
            dataGridViewCellStyle124.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn75.DefaultCellStyle = dataGridViewCellStyle124;
            resources.ApplyResources(this.dataGridViewTextBoxColumn75, "dataGridViewTextBoxColumn75");
            this.dataGridViewTextBoxColumn75.Name = "dataGridViewTextBoxColumn75";
            this.dataGridViewTextBoxColumn75.ReadOnly = true;
            this.dataGridViewTextBoxColumn75.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn53
            // 
            this.dataGridViewImageColumn53.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn53, "dataGridViewImageColumn53");
            this.dataGridViewImageColumn53.Name = "dataGridViewImageColumn53";
            this.dataGridViewImageColumn53.ReadOnly = true;
            this.dataGridViewImageColumn53.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn53.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn78
            // 
            this.dataGridViewTextBoxColumn78.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn78.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn78, "dataGridViewTextBoxColumn78");
            this.dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
            this.dataGridViewTextBoxColumn78.ReadOnly = true;
            // 
            // dataGridViewImageColumn54
            // 
            this.dataGridViewImageColumn54.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn54, "dataGridViewImageColumn54");
            this.dataGridViewImageColumn54.Name = "dataGridViewImageColumn54";
            this.dataGridViewImageColumn54.ReadOnly = true;
            this.dataGridViewImageColumn54.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn54.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn79
            // 
            this.dataGridViewTextBoxColumn79.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn79.DataPropertyName = "Crystal";
            dataGridViewCellStyle125.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn79.DefaultCellStyle = dataGridViewCellStyle125;
            resources.ApplyResources(this.dataGridViewTextBoxColumn79, "dataGridViewTextBoxColumn79");
            this.dataGridViewTextBoxColumn79.Name = "dataGridViewTextBoxColumn79";
            this.dataGridViewTextBoxColumn79.ReadOnly = true;
            this.dataGridViewTextBoxColumn79.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn55
            // 
            this.dataGridViewImageColumn55.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn55, "dataGridViewImageColumn55");
            this.dataGridViewImageColumn55.Name = "dataGridViewImageColumn55";
            this.dataGridViewImageColumn55.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn55.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn80
            // 
            this.dataGridViewTextBoxColumn80.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn80.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn80, "dataGridViewTextBoxColumn80");
            this.dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
            // 
            // dataGridViewImageColumn56
            // 
            this.dataGridViewImageColumn56.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn56, "dataGridViewImageColumn56");
            this.dataGridViewImageColumn56.Name = "dataGridViewImageColumn56";
            this.dataGridViewImageColumn56.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn56.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn81
            // 
            this.dataGridViewTextBoxColumn81.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn81.DataPropertyName = "Crystal";
            dataGridViewCellStyle126.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn81.DefaultCellStyle = dataGridViewCellStyle126;
            resources.ApplyResources(this.dataGridViewTextBoxColumn81, "dataGridViewTextBoxColumn81");
            this.dataGridViewTextBoxColumn81.Name = "dataGridViewTextBoxColumn81";
            this.dataGridViewTextBoxColumn81.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn57
            // 
            this.dataGridViewImageColumn57.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn57, "dataGridViewImageColumn57");
            this.dataGridViewImageColumn57.Name = "dataGridViewImageColumn57";
            this.dataGridViewImageColumn57.ReadOnly = true;
            this.dataGridViewImageColumn57.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn57.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn82
            // 
            this.dataGridViewTextBoxColumn82.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn82.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn82, "dataGridViewTextBoxColumn82");
            this.dataGridViewTextBoxColumn82.Name = "dataGridViewTextBoxColumn82";
            this.dataGridViewTextBoxColumn82.ReadOnly = true;
            // 
            // dataGridViewImageColumn58
            // 
            this.dataGridViewImageColumn58.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn58, "dataGridViewImageColumn58");
            this.dataGridViewImageColumn58.Name = "dataGridViewImageColumn58";
            this.dataGridViewImageColumn58.ReadOnly = true;
            this.dataGridViewImageColumn58.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn58.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn83
            // 
            this.dataGridViewTextBoxColumn83.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn83.DataPropertyName = "Crystal";
            dataGridViewCellStyle127.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn83.DefaultCellStyle = dataGridViewCellStyle127;
            resources.ApplyResources(this.dataGridViewTextBoxColumn83, "dataGridViewTextBoxColumn83");
            this.dataGridViewTextBoxColumn83.Name = "dataGridViewTextBoxColumn83";
            this.dataGridViewTextBoxColumn83.ReadOnly = true;
            this.dataGridViewTextBoxColumn83.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn59
            // 
            this.dataGridViewImageColumn59.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn59, "dataGridViewImageColumn59");
            this.dataGridViewImageColumn59.Name = "dataGridViewImageColumn59";
            this.dataGridViewImageColumn59.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn59.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn84
            // 
            this.dataGridViewTextBoxColumn84.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn84.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn84, "dataGridViewTextBoxColumn84");
            this.dataGridViewTextBoxColumn84.Name = "dataGridViewTextBoxColumn84";
            // 
            // dataGridViewImageColumn60
            // 
            this.dataGridViewImageColumn60.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn60, "dataGridViewImageColumn60");
            this.dataGridViewImageColumn60.Name = "dataGridViewImageColumn60";
            this.dataGridViewImageColumn60.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn60.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn85
            // 
            this.dataGridViewTextBoxColumn85.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn85.DataPropertyName = "Crystal";
            dataGridViewCellStyle128.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn85.DefaultCellStyle = dataGridViewCellStyle128;
            resources.ApplyResources(this.dataGridViewTextBoxColumn85, "dataGridViewTextBoxColumn85");
            this.dataGridViewTextBoxColumn85.Name = "dataGridViewTextBoxColumn85";
            this.dataGridViewTextBoxColumn85.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn61
            // 
            this.dataGridViewImageColumn61.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn61, "dataGridViewImageColumn61");
            this.dataGridViewImageColumn61.Name = "dataGridViewImageColumn61";
            this.dataGridViewImageColumn61.ReadOnly = true;
            this.dataGridViewImageColumn61.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn61.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn86
            // 
            this.dataGridViewTextBoxColumn86.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn86.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn86, "dataGridViewTextBoxColumn86");
            this.dataGridViewTextBoxColumn86.Name = "dataGridViewTextBoxColumn86";
            this.dataGridViewTextBoxColumn86.ReadOnly = true;
            // 
            // dataGridViewImageColumn62
            // 
            this.dataGridViewImageColumn62.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn62, "dataGridViewImageColumn62");
            this.dataGridViewImageColumn62.Name = "dataGridViewImageColumn62";
            this.dataGridViewImageColumn62.ReadOnly = true;
            this.dataGridViewImageColumn62.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn62.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn87
            // 
            this.dataGridViewTextBoxColumn87.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn87.DataPropertyName = "Crystal";
            dataGridViewCellStyle129.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn87.DefaultCellStyle = dataGridViewCellStyle129;
            resources.ApplyResources(this.dataGridViewTextBoxColumn87, "dataGridViewTextBoxColumn87");
            this.dataGridViewTextBoxColumn87.Name = "dataGridViewTextBoxColumn87";
            this.dataGridViewTextBoxColumn87.ReadOnly = true;
            this.dataGridViewTextBoxColumn87.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn63
            // 
            this.dataGridViewImageColumn63.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn63, "dataGridViewImageColumn63");
            this.dataGridViewImageColumn63.Name = "dataGridViewImageColumn63";
            this.dataGridViewImageColumn63.ReadOnly = true;
            this.dataGridViewImageColumn63.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn63.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn88
            // 
            this.dataGridViewTextBoxColumn88.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn88.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn88, "dataGridViewTextBoxColumn88");
            this.dataGridViewTextBoxColumn88.Name = "dataGridViewTextBoxColumn88";
            this.dataGridViewTextBoxColumn88.ReadOnly = true;
            // 
            // dataGridViewImageColumn64
            // 
            this.dataGridViewImageColumn64.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn64, "dataGridViewImageColumn64");
            this.dataGridViewImageColumn64.Name = "dataGridViewImageColumn64";
            this.dataGridViewImageColumn64.ReadOnly = true;
            this.dataGridViewImageColumn64.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn64.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn89
            // 
            this.dataGridViewTextBoxColumn89.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn89.DataPropertyName = "Crystal";
            dataGridViewCellStyle130.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn89.DefaultCellStyle = dataGridViewCellStyle130;
            resources.ApplyResources(this.dataGridViewTextBoxColumn89, "dataGridViewTextBoxColumn89");
            this.dataGridViewTextBoxColumn89.Name = "dataGridViewTextBoxColumn89";
            this.dataGridViewTextBoxColumn89.ReadOnly = true;
            this.dataGridViewTextBoxColumn89.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn65
            // 
            this.dataGridViewImageColumn65.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn65, "dataGridViewImageColumn65");
            this.dataGridViewImageColumn65.Name = "dataGridViewImageColumn65";
            this.dataGridViewImageColumn65.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn65.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn90
            // 
            this.dataGridViewTextBoxColumn90.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn90.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn90, "dataGridViewTextBoxColumn90");
            this.dataGridViewTextBoxColumn90.Name = "dataGridViewTextBoxColumn90";
            // 
            // dataGridViewImageColumn66
            // 
            this.dataGridViewImageColumn66.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn66, "dataGridViewImageColumn66");
            this.dataGridViewImageColumn66.Name = "dataGridViewImageColumn66";
            this.dataGridViewImageColumn66.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn66.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn91
            // 
            this.dataGridViewTextBoxColumn91.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn91.DataPropertyName = "Crystal";
            dataGridViewCellStyle131.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn91.DefaultCellStyle = dataGridViewCellStyle131;
            resources.ApplyResources(this.dataGridViewTextBoxColumn91, "dataGridViewTextBoxColumn91");
            this.dataGridViewTextBoxColumn91.Name = "dataGridViewTextBoxColumn91";
            this.dataGridViewTextBoxColumn91.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn67
            // 
            this.dataGridViewImageColumn67.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn67, "dataGridViewImageColumn67");
            this.dataGridViewImageColumn67.Name = "dataGridViewImageColumn67";
            this.dataGridViewImageColumn67.ReadOnly = true;
            this.dataGridViewImageColumn67.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn67.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn92
            // 
            this.dataGridViewTextBoxColumn92.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn92.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn92, "dataGridViewTextBoxColumn92");
            this.dataGridViewTextBoxColumn92.Name = "dataGridViewTextBoxColumn92";
            this.dataGridViewTextBoxColumn92.ReadOnly = true;
            // 
            // dataGridViewImageColumn68
            // 
            this.dataGridViewImageColumn68.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn68, "dataGridViewImageColumn68");
            this.dataGridViewImageColumn68.Name = "dataGridViewImageColumn68";
            this.dataGridViewImageColumn68.ReadOnly = true;
            this.dataGridViewImageColumn68.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn68.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn93
            // 
            this.dataGridViewTextBoxColumn93.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn93.DataPropertyName = "Crystal";
            dataGridViewCellStyle132.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn93.DefaultCellStyle = dataGridViewCellStyle132;
            resources.ApplyResources(this.dataGridViewTextBoxColumn93, "dataGridViewTextBoxColumn93");
            this.dataGridViewTextBoxColumn93.Name = "dataGridViewTextBoxColumn93";
            this.dataGridViewTextBoxColumn93.ReadOnly = true;
            this.dataGridViewTextBoxColumn93.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn69
            // 
            this.dataGridViewImageColumn69.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn69, "dataGridViewImageColumn69");
            this.dataGridViewImageColumn69.Name = "dataGridViewImageColumn69";
            this.dataGridViewImageColumn69.ReadOnly = true;
            this.dataGridViewImageColumn69.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn69.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn94
            // 
            this.dataGridViewTextBoxColumn94.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn94.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn94, "dataGridViewTextBoxColumn94");
            this.dataGridViewTextBoxColumn94.Name = "dataGridViewTextBoxColumn94";
            this.dataGridViewTextBoxColumn94.ReadOnly = true;
            // 
            // dataGridViewImageColumn70
            // 
            this.dataGridViewImageColumn70.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn70, "dataGridViewImageColumn70");
            this.dataGridViewImageColumn70.Name = "dataGridViewImageColumn70";
            this.dataGridViewImageColumn70.ReadOnly = true;
            this.dataGridViewImageColumn70.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn70.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn95
            // 
            this.dataGridViewTextBoxColumn95.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn95.DataPropertyName = "Crystal";
            dataGridViewCellStyle133.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn95.DefaultCellStyle = dataGridViewCellStyle133;
            resources.ApplyResources(this.dataGridViewTextBoxColumn95, "dataGridViewTextBoxColumn95");
            this.dataGridViewTextBoxColumn95.Name = "dataGridViewTextBoxColumn95";
            this.dataGridViewTextBoxColumn95.ReadOnly = true;
            this.dataGridViewTextBoxColumn95.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn71
            // 
            this.dataGridViewImageColumn71.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn71, "dataGridViewImageColumn71");
            this.dataGridViewImageColumn71.Name = "dataGridViewImageColumn71";
            this.dataGridViewImageColumn71.ReadOnly = true;
            this.dataGridViewImageColumn71.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn71.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn96
            // 
            this.dataGridViewTextBoxColumn96.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn96.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn96, "dataGridViewTextBoxColumn96");
            this.dataGridViewTextBoxColumn96.Name = "dataGridViewTextBoxColumn96";
            this.dataGridViewTextBoxColumn96.ReadOnly = true;
            // 
            // dataGridViewImageColumn72
            // 
            this.dataGridViewImageColumn72.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn72, "dataGridViewImageColumn72");
            this.dataGridViewImageColumn72.Name = "dataGridViewImageColumn72";
            this.dataGridViewImageColumn72.ReadOnly = true;
            this.dataGridViewImageColumn72.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn72.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn97
            // 
            this.dataGridViewTextBoxColumn97.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn97.DataPropertyName = "Crystal";
            dataGridViewCellStyle134.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn97.DefaultCellStyle = dataGridViewCellStyle134;
            resources.ApplyResources(this.dataGridViewTextBoxColumn97, "dataGridViewTextBoxColumn97");
            this.dataGridViewTextBoxColumn97.Name = "dataGridViewTextBoxColumn97";
            this.dataGridViewTextBoxColumn97.ReadOnly = true;
            this.dataGridViewTextBoxColumn97.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn73
            // 
            this.dataGridViewImageColumn73.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn73, "dataGridViewImageColumn73");
            this.dataGridViewImageColumn73.Name = "dataGridViewImageColumn73";
            this.dataGridViewImageColumn73.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn73.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn98
            // 
            this.dataGridViewTextBoxColumn98.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn98.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn98, "dataGridViewTextBoxColumn98");
            this.dataGridViewTextBoxColumn98.Name = "dataGridViewTextBoxColumn98";
            // 
            // dataGridViewImageColumn74
            // 
            this.dataGridViewImageColumn74.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn74, "dataGridViewImageColumn74");
            this.dataGridViewImageColumn74.Name = "dataGridViewImageColumn74";
            this.dataGridViewImageColumn74.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn74.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn99
            // 
            this.dataGridViewTextBoxColumn99.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn99.DataPropertyName = "Crystal";
            dataGridViewCellStyle135.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn99.DefaultCellStyle = dataGridViewCellStyle135;
            resources.ApplyResources(this.dataGridViewTextBoxColumn99, "dataGridViewTextBoxColumn99");
            this.dataGridViewTextBoxColumn99.Name = "dataGridViewTextBoxColumn99";
            this.dataGridViewTextBoxColumn99.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn75
            // 
            this.dataGridViewImageColumn75.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn75, "dataGridViewImageColumn75");
            this.dataGridViewImageColumn75.Name = "dataGridViewImageColumn75";
            this.dataGridViewImageColumn75.ReadOnly = true;
            this.dataGridViewImageColumn75.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn75.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn100
            // 
            this.dataGridViewTextBoxColumn100.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn100.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn100, "dataGridViewTextBoxColumn100");
            this.dataGridViewTextBoxColumn100.Name = "dataGridViewTextBoxColumn100";
            this.dataGridViewTextBoxColumn100.ReadOnly = true;
            // 
            // dataGridViewImageColumn76
            // 
            this.dataGridViewImageColumn76.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn76, "dataGridViewImageColumn76");
            this.dataGridViewImageColumn76.Name = "dataGridViewImageColumn76";
            this.dataGridViewImageColumn76.ReadOnly = true;
            this.dataGridViewImageColumn76.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn76.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn101
            // 
            this.dataGridViewTextBoxColumn101.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn101.DataPropertyName = "Crystal";
            dataGridViewCellStyle136.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn101.DefaultCellStyle = dataGridViewCellStyle136;
            resources.ApplyResources(this.dataGridViewTextBoxColumn101, "dataGridViewTextBoxColumn101");
            this.dataGridViewTextBoxColumn101.Name = "dataGridViewTextBoxColumn101";
            this.dataGridViewTextBoxColumn101.ReadOnly = true;
            this.dataGridViewTextBoxColumn101.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn77
            // 
            this.dataGridViewImageColumn77.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn77, "dataGridViewImageColumn77");
            this.dataGridViewImageColumn77.Name = "dataGridViewImageColumn77";
            this.dataGridViewImageColumn77.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn77.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn102
            // 
            this.dataGridViewTextBoxColumn102.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn102.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn102, "dataGridViewTextBoxColumn102");
            this.dataGridViewTextBoxColumn102.Name = "dataGridViewTextBoxColumn102";
            // 
            // dataGridViewImageColumn78
            // 
            this.dataGridViewImageColumn78.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn78, "dataGridViewImageColumn78");
            this.dataGridViewImageColumn78.Name = "dataGridViewImageColumn78";
            this.dataGridViewImageColumn78.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn78.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn103
            // 
            this.dataGridViewTextBoxColumn103.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn103.DataPropertyName = "Crystal";
            dataGridViewCellStyle137.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn103.DefaultCellStyle = dataGridViewCellStyle137;
            resources.ApplyResources(this.dataGridViewTextBoxColumn103, "dataGridViewTextBoxColumn103");
            this.dataGridViewTextBoxColumn103.Name = "dataGridViewTextBoxColumn103";
            this.dataGridViewTextBoxColumn103.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn79
            // 
            this.dataGridViewImageColumn79.DataPropertyName = "Color";
            resources.ApplyResources(this.dataGridViewImageColumn79, "dataGridViewImageColumn79");
            this.dataGridViewImageColumn79.Name = "dataGridViewImageColumn79";
            this.dataGridViewImageColumn79.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn79.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn104
            // 
            this.dataGridViewTextBoxColumn104.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn104.DataPropertyName = "Profile";
            resources.ApplyResources(this.dataGridViewTextBoxColumn104, "dataGridViewTextBoxColumn104");
            this.dataGridViewTextBoxColumn104.Name = "dataGridViewTextBoxColumn104";
            // 
            // dataGridViewImageColumn80
            // 
            this.dataGridViewImageColumn80.DataPropertyName = "PeakColor";
            resources.ApplyResources(this.dataGridViewImageColumn80, "dataGridViewImageColumn80");
            this.dataGridViewImageColumn80.Name = "dataGridViewImageColumn80";
            this.dataGridViewImageColumn80.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn80.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn105
            // 
            this.dataGridViewTextBoxColumn105.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn105.DataPropertyName = "Crystal";
            dataGridViewCellStyle138.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn105.DefaultCellStyle = dataGridViewCellStyle138;
            resources.ApplyResources(this.dataGridViewTextBoxColumn105, "dataGridViewTextBoxColumn105");
            this.dataGridViewTextBoxColumn105.Name = "dataGridViewTextBoxColumn105";
            this.dataGridViewTextBoxColumn105.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.toolStripContainer1);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.Resize += new System.EventHandler(this.Draw);
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIncreasingPixels)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxInt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinInt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.groupBoxCrystalData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCrystals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCrystal)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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
        public ToolStripButton toolStripButtonStressAnalysis;
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
        private Crystallography.Controls.NumericBox numericBoxLowerX;
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
        private Crystallography.Controls.NumericBox numericBoxUpperX;
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
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem ngenCompileToolStripMenuItem;
        private DataGridViewImageColumn dataGridViewImageColumn77;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn102;
        private DataGridViewImageColumn dataGridViewImageColumn78;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn103;
        private DataGridViewImageColumn dataGridViewImageColumn79;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn104;
        private DataGridViewImageColumn dataGridViewImageColumn80;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn105;
        private ToolStripProgressBar toolStripProgressBar;
    }
}