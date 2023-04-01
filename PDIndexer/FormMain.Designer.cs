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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormMain));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle34 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle35 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle36 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle37 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle38 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle39 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle40 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle41 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle42 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle43 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle44 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle45 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle46 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle47 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle48 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle49 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle50 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle51 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle52 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle53 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle54 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle55 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle56 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle57 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle58 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle59 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle60 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle61 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle62 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle63 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle64 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle65 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle66 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle67 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle68 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle69 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle70 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle71 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle72 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle73 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle74 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle75 = new DataGridViewCellStyle();
            toolStripContainer1 = new ToolStripContainer();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar = new ToolStripProgressBar();
            toolStripStatusLabelCalcTime = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            horizontalAxisUserControl = new Crystallography.Controls.HorizontalAxisUserControl();
            flowLayoutPanel4 = new FlowLayoutPanel();
            checkBoxChangeHorizontalAppearance = new CheckBox();
            tabPage2 = new TabPage();
            groupBox4 = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            radioButtonLinearity = new RadioButton();
            radioButtonLogarithm = new RadioButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            radioButtonRawCounts = new RadioButton();
            radioButtonCountsPerStep = new RadioButton();
            groupBox3 = new GroupBox();
            numericalTextBoxIncreasingPixels = new Crystallography.Controls.NumericBox();
            numericUpDownIncreasingPixels = new NumericUpDown();
            radioButtonMultiProfileMode = new RadioButton();
            checkBoxChangeColor = new CheckBox();
            radioButtonSingleProfileMode = new RadioButton();
            label6 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            colorControlScaleText = new Crystallography.Controls.ColorControl();
            colorControlScaleLine = new Crystallography.Controls.ColorControl();
            colorControlBack = new Crystallography.Controls.ColorControl();
            label5 = new Label();
            label2 = new Label();
            label4 = new Label();
            checkBoxErrorBar = new CheckBox();
            checkBoxShowScaleLine = new CheckBox();
            tabControl1 = new TabControl();
            tabPage3 = new TabPage();
            numericUpDownMaxInt = new NumericUpDown();
            label7 = new Label();
            label21 = new Label();
            numericUpDownMinInt = new NumericUpDown();
            checkBoxShowUnrolledImage = new CheckBox();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            comboBoxGradient = new ComboBox();
            comboBoxScale2 = new ComboBox();
            comboBoxScale1 = new ComboBox();
            graphControlFrequency = new Crystallography.Controls.GraphControl();
            pictureBoxMain = new PictureBox();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            numericBoxUpperX = new Crystallography.Controls.NumericBoxWithMenu();
            numericBoxUpperY = new Crystallography.Controls.NumericBox();
            numericBoxLowerX = new Crystallography.Controls.NumericBoxWithMenu();
            numericBoxLowerY = new Crystallography.Controls.NumericBox();
            labelD = new Label();
            labelTwoTheta = new Label();
            label11 = new Label();
            label10 = new Label();
            labelX = new Label();
            label9 = new Label();
            labelIntensity = new Label();
            labelQ = new Label();
            splitContainer2 = new SplitContainer();
            groupBox1 = new GroupBox();
            dataGridViewProfiles = new DataGridView();
            checkDataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
            colorDataGridViewTextBoxColumn = new DataGridViewImageColumn();
            profileDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSourceProfile = new BindingSource(components);
            dataSet = new DataSet();
            checkBoxProfileParameter = new CheckBox();
            checkBoxAll = new CheckBox();
            groupBoxCrystalData = new GroupBox();
            dataGridViewCrystals = new DataGridView();
            checkDataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            PeakColor = new DataGridViewImageColumn();
            Crystal = new DataGridViewTextBoxColumn();
            bindingSourceCrystal = new BindingSource(components);
            checkBoxCrystalParameter = new CheckBox();
            toolStrip2 = new ToolStrip();
            toolStripButtonCrystalParameter = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButtonProfileParameter = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripButtonEquationOfState = new ToolStripButton();
            toolStripSeparator8 = new ToolStripSeparator();
            toolStripButtonFittingParameter = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripButtonCellFinder = new ToolStripButton();
            toolStripSeparator11 = new ToolStripSeparator();
            toolStripButtonSequentialAnalysis = new ToolStripButton();
            toolStripSeparator10 = new ToolStripSeparator();
            toolStripButtonAtomicPositonFinder = new ToolStripButton();
            toolStripSeparator12 = new ToolStripSeparator();
            toolStripButtonLPO = new ToolStripButton();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            readPatternProfileToolStripMenuItem = new ToolStripMenuItem();
            savePatternProfileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemExportExcelFile = new ToolStripMenuItem();
            asCSVcommaSeperatedFileToolStripMenuItem = new ToolStripMenuItem();
            asTSVtabSeparatedValuesFileToolStripMenuItem = new ToolStripMenuItem();
            asGSASFileToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            readCrystalDataToolStripMenuItem = new ToolStripMenuItem();
            readAndAddToolStripMenuItem = new ToolStripMenuItem();
            saveCrystalDataToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemImport = new ToolStripMenuItem();
            toolStripMenuItemExportCIF = new ToolStripMenuItem();
            resetInitialCrystalDataToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripMenuItemPageSetup = new ToolStripMenuItem();
            toolStripMenuItemPrintPreview = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            コピーToolStripMenuItem = new ToolStripMenuItem();
            BitmapToolStripMenuItem = new ToolStripMenuItem();
            copyAsMetafileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemSaveMetafile = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            closeToolStripMenuItem = new ToolStripMenuItem();
            optionToolStripMenuItem = new ToolStripMenuItem();
            toolTipToolStripMenuItem = new ToolStripMenuItem();
            watchReadClipboardToolStripMenuItem = new ToolStripMenuItem();
            watchReadANewProfileToolStripMenuItem = new ToolStripMenuItem();
            setDirectoryToTheWatchToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBoxDirectoryToWatch = new ToolStripTextBox();
            clearRegistryToolStripMenuItem = new ToolStripMenuItem();
            automaticallySaveTheCrystalListToolStripMenuItem = new ToolStripMenuItem();
            macroToolStripMenuItem = new ToolStripMenuItem();
            editorToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutMeToolStripMenuItem = new ToolStripMenuItem();
            programUpdatesToolStripMenuItem = new ToolStripMenuItem();
            hintToolStripMenuItem = new ToolStripMenuItem();
            helpwebToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            japaneseToolStripMenuItem = new ToolStripMenuItem();
            button2 = new Button();
            button3 = new Button();
            buttonAu = new Button();
            toolTip = new ToolTip(components);
            pageSetupDialog1 = new PageSetupDialog();
            printDialog1 = new PrintDialog();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            checkDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            Check = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn19 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn20 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn21 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn22 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn23 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn25 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn1 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn24 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn2 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn26 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn3 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn27 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn30 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn4 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn28 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn5 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn29 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn6 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn31 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn7 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn32 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn8 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn33 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn9 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn34 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn10 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn35 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn11 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn36 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn12 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn37 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn13 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn38 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn15 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn40 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn14 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn39 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn16 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn41 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn17 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn42 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn19 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn44 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn18 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn43 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn20 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn45 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn21 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn46 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn22 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn47 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn23 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn48 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn24 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn49 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn25 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn50 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn26 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn51 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn27 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn52 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn29 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn54 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn28 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn53 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn30 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn55 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn31 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn56 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn32 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn57 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn33 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn58 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn34 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn59 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn35 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn60 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn36 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn61 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn37 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn62 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn38 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn63 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn39 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn64 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn40 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn65 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn41 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn66 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn42 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn67 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn43 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn68 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn44 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn69 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn45 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn70 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn46 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn71 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn47 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn72 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn48 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn73 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn49 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn74 = new DataGridViewTextBoxColumn();
            timerBlinkDiffraction = new Timer(components);
            dataGridViewImageColumn51 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn76 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn52 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn77 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn50 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn75 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn53 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn78 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn54 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn79 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn55 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn80 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn56 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn81 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn57 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn82 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn58 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn83 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn59 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn84 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn60 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn85 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn61 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn86 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn62 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn87 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn63 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn88 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn64 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn89 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn65 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn90 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn66 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn91 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn67 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn92 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn68 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn93 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn69 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn94 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn70 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn95 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn71 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn96 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn72 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn97 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn73 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn98 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn74 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn99 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn75 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn100 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn76 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn101 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn77 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn102 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn78 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn103 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn79 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn104 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn80 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn105 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn82 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn107 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn81 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn106 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn83 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn108 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn84 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn109 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn85 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn110 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn86 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn111 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn87 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn112 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn88 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn113 = new DataGridViewTextBoxColumn();
            dataGridViewImageColumn89 = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn114 = new DataGridViewTextBoxColumn();
            toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox4.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((ISupportInitialize)numericUpDownIncreasingPixels).BeginInit();
            groupBox2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage3.SuspendLayout();
            ((ISupportInitialize)numericUpDownMaxInt).BeginInit();
            ((ISupportInitialize)numericUpDownMinInt).BeginInit();
            ((ISupportInitialize)pictureBoxMain).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((ISupportInitialize)dataGridViewProfiles).BeginInit();
            ((ISupportInitialize)bindingSourceProfile).BeginInit();
            ((ISupportInitialize)dataSet).BeginInit();
            groupBoxCrystalData.SuspendLayout();
            ((ISupportInitialize)dataGridViewCrystals).BeginInit();
            ((ISupportInitialize)bindingSourceCrystal).BeginInit();
            toolStrip2.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            toolStripContainer1.BottomToolStripPanel.Controls.Add(statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            toolStripContainer1.ContentPanel.Controls.Add(splitContainer1);
            resources.ApplyResources(toolStripContainer1, "toolStripContainer1");
            toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip2);
            toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip);
            resources.ApplyResources(toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            // 
            // statusStrip1
            // 
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar, toolStripStatusLabelCalcTime, toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.Name = "toolStripProgressBar";
            resources.ApplyResources(toolStripProgressBar, "toolStripProgressBar");
            // 
            // toolStripStatusLabelCalcTime
            // 
            toolStripStatusLabelCalcTime.Name = "toolStripStatusLabelCalcTime";
            resources.ApplyResources(toolStripStatusLabelCalcTime, "toolStripStatusLabelCalcTime");
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            resources.ApplyResources(toolStripStatusLabel2, "toolStripStatusLabel2");
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tabControl);
            splitContainer1.Panel1.Controls.Add(tabControl1);
            splitContainer1.Panel1.Controls.Add(pictureBoxMain);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.HotTrack = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Click += tabControl_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(horizontalAxisUserControl);
            tabPage1.Controls.Add(flowLayoutPanel4);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // horizontalAxisUserControl
            // 
            resources.ApplyResources(horizontalAxisUserControl, "horizontalAxisUserControl");
            horizontalAxisUserControl.AxisMode = HorizontalAxis.Angle;
            horizontalAxisUserControl.ElectronAccVoltage = 8.04114721D;
            horizontalAxisUserControl.ElectronAccVoltageText = "8.04114721";
            horizontalAxisUserControl.EnergyUnit = EnergyUnitEnum.eV;
            horizontalAxisUserControl.Name = "horizontalAxisUserControl";
            horizontalAxisUserControl.TakeoffAngle = 0D;
            horizontalAxisUserControl.TakeoffAngleText = "0";
            horizontalAxisUserControl.TofAngle = 1.5707963267948966D;
            horizontalAxisUserControl.TofAngleText = "90";
            horizontalAxisUserControl.TofLength = 90D;
            horizontalAxisUserControl.WaveColor = WaveColor.Monochrome;
            horizontalAxisUserControl.WaveLength = 0.1541871066667D;
            horizontalAxisUserControl.WaveLengthText = "1.541871066667";
            horizontalAxisUserControl.WaveSource = WaveSource.Xray;
            horizontalAxisUserControl.XrayWaveSourceElementNumber = 29;
            horizontalAxisUserControl.XrayWaveSourceLine = XrayLine.Ka;
            horizontalAxisUserControl.AxisPropertyChanged += horizontalAxisUserControl_AxisPropertyChanged;
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(flowLayoutPanel4, "flowLayoutPanel4");
            flowLayoutPanel4.Controls.Add(checkBoxChangeHorizontalAppearance);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // checkBoxChangeHorizontalAppearance
            // 
            resources.ApplyResources(checkBoxChangeHorizontalAppearance, "checkBoxChangeHorizontalAppearance");
            checkBoxChangeHorizontalAppearance.Checked = true;
            checkBoxChangeHorizontalAppearance.CheckState = CheckState.Checked;
            checkBoxChangeHorizontalAppearance.Name = "checkBoxChangeHorizontalAppearance";
            toolTip.SetToolTip(checkBoxChangeHorizontalAppearance, resources.GetString("checkBoxChangeHorizontalAppearance.ToolTip"));
            checkBoxChangeHorizontalAppearance.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox4);
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(checkBoxErrorBar);
            tabPage2.Controls.Add(checkBoxShowScaleLine);
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(flowLayoutPanel2);
            groupBox4.Controls.Add(flowLayoutPanel1);
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            toolTip.SetToolTip(groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Controls.Add(radioButtonLinearity);
            flowLayoutPanel2.Controls.Add(radioButtonLogarithm);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // radioButtonLinearity
            // 
            resources.ApplyResources(radioButtonLinearity, "radioButtonLinearity");
            radioButtonLinearity.Checked = true;
            radioButtonLinearity.Name = "radioButtonLinearity";
            radioButtonLinearity.TabStop = true;
            toolTip.SetToolTip(radioButtonLinearity, resources.GetString("radioButtonLinearity.ToolTip"));
            radioButtonLinearity.UseVisualStyleBackColor = true;
            radioButtonLinearity.CheckedChanged += radioButtonRawCounts_CheckedChanged;
            // 
            // radioButtonLogarithm
            // 
            resources.ApplyResources(radioButtonLogarithm, "radioButtonLogarithm");
            radioButtonLogarithm.Name = "radioButtonLogarithm";
            toolTip.SetToolTip(radioButtonLogarithm, resources.GetString("radioButtonLogarithm.ToolTip"));
            radioButtonLogarithm.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(radioButtonRawCounts);
            flowLayoutPanel1.Controls.Add(radioButtonCountsPerStep);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioButtonRawCounts
            // 
            resources.ApplyResources(radioButtonRawCounts, "radioButtonRawCounts");
            radioButtonRawCounts.Name = "radioButtonRawCounts";
            toolTip.SetToolTip(radioButtonRawCounts, resources.GetString("radioButtonRawCounts.ToolTip"));
            radioButtonRawCounts.UseVisualStyleBackColor = true;
            radioButtonRawCounts.CheckedChanged += radioButtonRawCounts_CheckedChanged;
            // 
            // radioButtonCountsPerStep
            // 
            resources.ApplyResources(radioButtonCountsPerStep, "radioButtonCountsPerStep");
            radioButtonCountsPerStep.Checked = true;
            radioButtonCountsPerStep.Name = "radioButtonCountsPerStep";
            radioButtonCountsPerStep.TabStop = true;
            toolTip.SetToolTip(radioButtonCountsPerStep, resources.GetString("radioButtonCountsPerStep.ToolTip"));
            radioButtonCountsPerStep.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(numericalTextBoxIncreasingPixels);
            groupBox3.Controls.Add(numericUpDownIncreasingPixels);
            groupBox3.Controls.Add(radioButtonMultiProfileMode);
            groupBox3.Controls.Add(checkBoxChangeColor);
            groupBox3.Controls.Add(radioButtonSingleProfileMode);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label1);
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // numericalTextBoxIncreasingPixels
            // 
            resources.ApplyResources(numericalTextBoxIncreasingPixels, "numericalTextBoxIncreasingPixels");
            numericalTextBoxIncreasingPixels.BackColor = SystemColors.Control;
            numericalTextBoxIncreasingPixels.FooterBackColor = SystemColors.Control;
            numericalTextBoxIncreasingPixels.HeaderBackColor = SystemColors.Control;
            numericalTextBoxIncreasingPixels.Name = "numericalTextBoxIncreasingPixels";
            numericalTextBoxIncreasingPixels.RadianValue = 17.872171540421935D;
            numericalTextBoxIncreasingPixels.RestrictLimitValue = false;
            numericalTextBoxIncreasingPixels.RoundErrorAccuracy = -1;
            numericalTextBoxIncreasingPixels.SkipEventDuringInput = false;
            numericalTextBoxIncreasingPixels.Value = 1024D;
            numericalTextBoxIncreasingPixels.ValueChanged += radioButtonMultiProfileMode_CheckChanged;
            // 
            // numericUpDownIncreasingPixels
            // 
            resources.ApplyResources(numericUpDownIncreasingPixels, "numericUpDownIncreasingPixels");
            numericUpDownIncreasingPixels.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericUpDownIncreasingPixels.Name = "numericUpDownIncreasingPixels";
            numericUpDownIncreasingPixels.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownIncreasingPixels.ValueChanged += numericUpDownIncreasingPixels_ValueChanged;
            // 
            // radioButtonMultiProfileMode
            // 
            resources.ApplyResources(radioButtonMultiProfileMode, "radioButtonMultiProfileMode");
            radioButtonMultiProfileMode.Checked = true;
            radioButtonMultiProfileMode.Name = "radioButtonMultiProfileMode";
            radioButtonMultiProfileMode.TabStop = true;
            radioButtonMultiProfileMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxChangeColor
            // 
            resources.ApplyResources(checkBoxChangeColor, "checkBoxChangeColor");
            checkBoxChangeColor.Checked = true;
            checkBoxChangeColor.CheckState = CheckState.Checked;
            checkBoxChangeColor.Name = "checkBoxChangeColor";
            toolTip.SetToolTip(checkBoxChangeColor, resources.GetString("checkBoxChangeColor.ToolTip"));
            checkBoxChangeColor.UseVisualStyleBackColor = true;
            checkBoxChangeColor.CheckedChanged += radioButtonMultiProfileMode_CheckChanged;
            // 
            // radioButtonSingleProfileMode
            // 
            resources.ApplyResources(radioButtonSingleProfileMode, "radioButtonSingleProfileMode");
            radioButtonSingleProfileMode.Name = "radioButtonSingleProfileMode";
            radioButtonSingleProfileMode.UseVisualStyleBackColor = true;
            radioButtonSingleProfileMode.CheckedChanged += radioButtonMultiProfileMode_CheckChanged;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(colorControlScaleText);
            groupBox2.Controls.Add(colorControlScaleLine);
            groupBox2.Controls.Add(colorControlBack);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label4);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // colorControlScaleText
            // 
            colorControlScaleText.Argb = -16777216;
            resources.ApplyResources(colorControlScaleText, "colorControlScaleText");
            colorControlScaleText.Blue = 0;
            colorControlScaleText.BlueF = 0F;
            colorControlScaleText.BoxSize = new Size(20, 20);
            colorControlScaleText.Color = Color.FromArgb(0, 0, 0);
            colorControlScaleText.FlowDirection = FlowDirection.LeftToRight;
            colorControlScaleText.Green = 0;
            colorControlScaleText.GreenF = 0F;
            colorControlScaleText.Name = "colorControlScaleText";
            colorControlScaleText.Red = 0;
            colorControlScaleText.RedF = 0F;
            toolTip.SetToolTip(colorControlScaleText, resources.GetString("colorControlScaleText.ToolTip"));
            colorControlScaleText.ColorChanged += Draw;
            // 
            // colorControlScaleLine
            // 
            colorControlScaleLine.Argb = -2894893;
            resources.ApplyResources(colorControlScaleLine, "colorControlScaleLine");
            colorControlScaleLine.Blue = 211;
            colorControlScaleLine.BlueF = 0.827451F;
            colorControlScaleLine.BoxSize = new Size(20, 20);
            colorControlScaleLine.Color = Color.FromArgb(211, 211, 211);
            colorControlScaleLine.FlowDirection = FlowDirection.LeftToRight;
            colorControlScaleLine.Green = 211;
            colorControlScaleLine.GreenF = 0.827451F;
            colorControlScaleLine.Name = "colorControlScaleLine";
            colorControlScaleLine.Red = 211;
            colorControlScaleLine.RedF = 0.827451F;
            toolTip.SetToolTip(colorControlScaleLine, resources.GetString("colorControlScaleLine.ToolTip"));
            colorControlScaleLine.ColorChanged += Draw;
            // 
            // colorControlBack
            // 
            colorControlBack.Argb = -1;
            resources.ApplyResources(colorControlBack, "colorControlBack");
            colorControlBack.Blue = 255;
            colorControlBack.BlueF = 1F;
            colorControlBack.BoxSize = new Size(20, 20);
            colorControlBack.Color = Color.FromArgb(255, 255, 255);
            colorControlBack.FlowDirection = FlowDirection.LeftToRight;
            colorControlBack.Green = 255;
            colorControlBack.GreenF = 1F;
            colorControlBack.Name = "colorControlBack";
            colorControlBack.Red = 255;
            colorControlBack.RedF = 1F;
            toolTip.SetToolTip(colorControlBack, resources.GetString("colorControlBack.ToolTip"));
            colorControlBack.ColorChanged += Draw;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            toolTip.SetToolTip(label5, resources.GetString("label5.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            toolTip.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // checkBoxErrorBar
            // 
            resources.ApplyResources(checkBoxErrorBar, "checkBoxErrorBar");
            checkBoxErrorBar.Name = "checkBoxErrorBar";
            toolTip.SetToolTip(checkBoxErrorBar, resources.GetString("checkBoxErrorBar.ToolTip"));
            checkBoxErrorBar.UseVisualStyleBackColor = true;
            checkBoxErrorBar.CheckedChanged += checkBoxShowScaleLine_CheckedChanged_1;
            // 
            // checkBoxShowScaleLine
            // 
            resources.ApplyResources(checkBoxShowScaleLine, "checkBoxShowScaleLine");
            checkBoxShowScaleLine.Name = "checkBoxShowScaleLine";
            toolTip.SetToolTip(checkBoxShowScaleLine, resources.GetString("checkBoxShowScaleLine.ToolTip"));
            checkBoxShowScaleLine.UseVisualStyleBackColor = true;
            checkBoxShowScaleLine.CheckedChanged += checkBoxShowScaleLine_CheckedChanged_1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage3);
            tabControl1.HotTrack = true;
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Click += tabControl1_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(numericUpDownMaxInt);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(label21);
            tabPage3.Controls.Add(numericUpDownMinInt);
            tabPage3.Controls.Add(checkBoxShowUnrolledImage);
            tabPage3.Controls.Add(label24);
            tabPage3.Controls.Add(label23);
            tabPage3.Controls.Add(label22);
            tabPage3.Controls.Add(comboBoxGradient);
            tabPage3.Controls.Add(comboBoxScale2);
            tabPage3.Controls.Add(comboBoxScale1);
            tabPage3.Controls.Add(graphControlFrequency);
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Name = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMaxInt
            // 
            resources.ApplyResources(numericUpDownMaxInt, "numericUpDownMaxInt");
            numericUpDownMaxInt.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownMaxInt.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUpDownMaxInt.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownMaxInt.Name = "numericUpDownMaxInt";
            numericUpDownMaxInt.Value = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUpDownMaxInt.ValueChanged += numericUpDownMaxInt_ValueChanged;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            // 
            // numericUpDownMinInt
            // 
            resources.ApplyResources(numericUpDownMinInt, "numericUpDownMinInt");
            numericUpDownMinInt.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownMinInt.Maximum = new decimal(new int[] { 65534, 0, 0, 0 });
            numericUpDownMinInt.Name = "numericUpDownMinInt";
            numericUpDownMinInt.ValueChanged += numericUpDownMinInt_ValueChanged;
            // 
            // checkBoxShowUnrolledImage
            // 
            resources.ApplyResources(checkBoxShowUnrolledImage, "checkBoxShowUnrolledImage");
            checkBoxShowUnrolledImage.Checked = true;
            checkBoxShowUnrolledImage.CheckState = CheckState.Checked;
            checkBoxShowUnrolledImage.Name = "checkBoxShowUnrolledImage";
            checkBoxShowUnrolledImage.UseVisualStyleBackColor = true;
            checkBoxShowUnrolledImage.CheckedChanged += checkBoxShowUnrolledImage_CheckedChanged;
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
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
            // comboBoxGradient
            // 
            comboBoxGradient.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBoxGradient, "comboBoxGradient");
            comboBoxGradient.FormattingEnabled = true;
            comboBoxGradient.Items.AddRange(new object[] { resources.GetString("comboBoxGradient.Items"), resources.GetString("comboBoxGradient.Items1") });
            comboBoxGradient.Name = "comboBoxGradient";
            comboBoxGradient.SelectedIndexChanged += toolStripComboBoxGradient_SelectedIndexChanged;
            // 
            // comboBoxScale2
            // 
            comboBoxScale2.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBoxScale2, "comboBoxScale2");
            comboBoxScale2.FormattingEnabled = true;
            comboBoxScale2.Items.AddRange(new object[] { resources.GetString("comboBoxScale2.Items"), resources.GetString("comboBoxScale2.Items1") });
            comboBoxScale2.Name = "comboBoxScale2";
            comboBoxScale2.SelectedIndexChanged += toolStripComboBoxScale2_SelectedIndexChanged;
            // 
            // comboBoxScale1
            // 
            comboBoxScale1.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBoxScale1, "comboBoxScale1");
            comboBoxScale1.FormattingEnabled = true;
            comboBoxScale1.Items.AddRange(new object[] { resources.GetString("comboBoxScale1.Items"), resources.GetString("comboBoxScale1.Items1") });
            comboBoxScale1.Name = "comboBoxScale1";
            comboBoxScale1.SelectedIndexChanged += toolStripComboBoxScale_SelectedIndexChanged;
            // 
            // graphControlFrequency
            // 
            graphControlFrequency.AllowMouseOperation = true;
            resources.ApplyResources(graphControlFrequency, "graphControlFrequency");
            graphControlFrequency.BackgroundColor = Color.White;
            graphControlFrequency.BottomMargin = 0D;
            graphControlFrequency.DivisionLineColor = Color.Gray;
            graphControlFrequency.FixRangeHorizontal = false;
            graphControlFrequency.FixRangeVertical = false;
            graphControlFrequency.Interpolation = false;
            graphControlFrequency.IsIntegerX = true;
            graphControlFrequency.IsIntegerY = true;
            graphControlFrequency.LabelX = "X:";
            graphControlFrequency.LabelY = "Y:";
            graphControlFrequency.LeftMargin = 0F;
            graphControlFrequency.LineWidth = 1F;
            graphControlFrequency.LowerX = 0D;
            graphControlFrequency.LowerY = 0D;
            graphControlFrequency.MaximalX = 1D;
            graphControlFrequency.MaximalY = 1D;
            graphControlFrequency.MinimalX = 0D;
            graphControlFrequency.MinimalY = 0D;
            graphControlFrequency.Mode = Crystallography.Controls.GraphControl.DrawingMode.Line;
            graphControlFrequency.MousePositionVisible = true;
            graphControlFrequency.Name = "graphControlFrequency";
            graphControlFrequency.OriginPosition = new Point(40, 20);
            graphControlFrequency.Smoothing = false;
            graphControlFrequency.UnitX = "";
            graphControlFrequency.UnitY = "";
            graphControlFrequency.UpperX = 1D;
            graphControlFrequency.UpperY = 1D;
            graphControlFrequency.UseLineWidth = true;
            graphControlFrequency.XLog = true;
            graphControlFrequency.YLog = true;
            graphControlFrequency.LinePositionChanged += graphControlFrequency_LinePositionChanged;
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.BackColor = Color.White;
            pictureBoxMain.BorderStyle = BorderStyle.Fixed3D;
            resources.ApplyResources(pictureBoxMain, "pictureBoxMain");
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.TabStop = false;
            toolTip.SetToolTip(pictureBoxMain, resources.GetString("pictureBoxMain.ToolTip"));
            pictureBoxMain.Paint += pictureBoxMain_Paint;
            pictureBoxMain.MouseDown += pictureBoxMain_MouseDown;
            pictureBoxMain.MouseMove += pictureBoxMain_MouseMove;
            pictureBoxMain.MouseUp += pictureBoxMain_MouseUp;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(tableLayoutPanel2, "tableLayoutPanel2");
            tableLayoutPanel2.Controls.Add(numericBoxUpperX, 3, 0);
            tableLayoutPanel2.Controls.Add(numericBoxUpperY, 7, 0);
            tableLayoutPanel2.Controls.Add(numericBoxLowerX, 1, 0);
            tableLayoutPanel2.Controls.Add(numericBoxLowerY, 5, 0);
            tableLayoutPanel2.Controls.Add(labelD, 9, 0);
            tableLayoutPanel2.Controls.Add(labelTwoTheta, 8, 0);
            tableLayoutPanel2.Controls.Add(label11, 6, 0);
            tableLayoutPanel2.Controls.Add(label10, 2, 0);
            tableLayoutPanel2.Controls.Add(labelX, 0, 0);
            tableLayoutPanel2.Controls.Add(label9, 4, 0);
            tableLayoutPanel2.Controls.Add(labelIntensity, 11, 0);
            tableLayoutPanel2.Controls.Add(labelQ, 10, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // numericBoxUpperX
            // 
            numericBoxUpperX.AllowMouseControl = false;
            numericBoxUpperX.BackColor = Color.Transparent;
            numericBoxUpperX.DecimalPlaces = 2;
            resources.ApplyResources(numericBoxUpperX, "numericBoxUpperX");
            numericBoxUpperX.Maximum = 30D;
            numericBoxUpperX.Minimum = 0D;
            numericBoxUpperX.MouseDirection = VH_DirectionEnum.Vertical;
            numericBoxUpperX.MouseSpeed = 1D;
            numericBoxUpperX.Name = "numericBoxUpperX";
            numericBoxUpperX.RadianValue = 0.52359877559829882D;
            numericBoxUpperX.RoundErrorAccuracy = -1;
            numericBoxUpperX.ShowUpDown = true;
            numericBoxUpperX.SmartIncrement = true;
            numericBoxUpperX.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxUpperX, resources.GetString("numericBoxUpperX.ToolTip"));
            numericBoxUpperX.Value = 30D;
            numericBoxUpperX.WordWrap = false;
            numericBoxUpperX.LimitChanged += numericBoxUpperX_LimitChanged;
            numericBoxUpperX.ValueChanged += numericBox_ValueChanged;
            // 
            // numericBoxUpperY
            // 
            resources.ApplyResources(numericBoxUpperY, "numericBoxUpperY");
            numericBoxUpperY.BackColor = SystemColors.Control;
            numericBoxUpperY.DecimalPlaces = 2;
            numericBoxUpperY.FooterBackColor = SystemColors.Control;
            numericBoxUpperY.HeaderBackColor = SystemColors.Control;
            numericBoxUpperY.Maximum = 1000D;
            numericBoxUpperY.Minimum = 0D;
            numericBoxUpperY.Name = "numericBoxUpperY";
            numericBoxUpperY.RadianValue = 17.453292519943293D;
            numericBoxUpperY.RoundErrorAccuracy = -1;
            numericBoxUpperY.ShowUpDown = true;
            numericBoxUpperY.SmartIncrement = true;
            numericBoxUpperY.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxUpperY, resources.GetString("numericBoxUpperY.ToolTip"));
            numericBoxUpperY.Value = 1000D;
            numericBoxUpperY.WordWrap = false;
            numericBoxUpperY.ValueChanged += numericBox_ValueChanged;
            // 
            // numericBoxLowerX
            // 
            numericBoxLowerX.AllowMouseControl = false;
            numericBoxLowerX.BackColor = Color.Transparent;
            numericBoxLowerX.DecimalPlaces = 2;
            resources.ApplyResources(numericBoxLowerX, "numericBoxLowerX");
            numericBoxLowerX.Maximum = 30D;
            numericBoxLowerX.Minimum = 0D;
            numericBoxLowerX.MouseDirection = VH_DirectionEnum.Vertical;
            numericBoxLowerX.MouseSpeed = 1D;
            numericBoxLowerX.Name = "numericBoxLowerX";
            numericBoxLowerX.RoundErrorAccuracy = -1;
            numericBoxLowerX.ShowUpDown = true;
            numericBoxLowerX.SmartIncrement = true;
            numericBoxLowerX.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxLowerX, resources.GetString("numericBoxLowerX.ToolTip"));
            numericBoxLowerX.WordWrap = false;
            numericBoxLowerX.LimitChanged += numericBoxUpperX_LimitChanged;
            numericBoxLowerX.ValueChanged += numericBox_ValueChanged;
            // 
            // numericBoxLowerY
            // 
            resources.ApplyResources(numericBoxLowerY, "numericBoxLowerY");
            numericBoxLowerY.BackColor = SystemColors.Control;
            numericBoxLowerY.DecimalPlaces = 2;
            numericBoxLowerY.FooterBackColor = SystemColors.Control;
            numericBoxLowerY.HeaderBackColor = SystemColors.Control;
            numericBoxLowerY.Maximum = 1000D;
            numericBoxLowerY.Minimum = 0D;
            numericBoxLowerY.Name = "numericBoxLowerY";
            numericBoxLowerY.RoundErrorAccuracy = -1;
            numericBoxLowerY.ShowUpDown = true;
            numericBoxLowerY.SmartIncrement = true;
            numericBoxLowerY.ThonsandsSeparator = true;
            toolTip.SetToolTip(numericBoxLowerY, resources.GetString("numericBoxLowerY.ToolTip"));
            numericBoxLowerY.WordWrap = false;
            numericBoxLowerY.ValueChanged += numericBox_ValueChanged;
            // 
            // labelD
            // 
            resources.ApplyResources(labelD, "labelD");
            labelD.Name = "labelD";
            // 
            // labelTwoTheta
            // 
            resources.ApplyResources(labelTwoTheta, "labelTwoTheta");
            labelTwoTheta.Name = "labelTwoTheta";
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // labelX
            // 
            resources.ApplyResources(labelX, "labelX");
            labelX.Name = "labelX";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // labelIntensity
            // 
            resources.ApplyResources(labelIntensity, "labelIntensity");
            labelIntensity.Name = "labelIntensity";
            // 
            // labelQ
            // 
            resources.ApplyResources(labelQ, "labelQ");
            labelQ.Name = "labelQ";
            // 
            // splitContainer2
            // 
            resources.ApplyResources(splitContainer2, "splitContainer2");
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBoxCrystalData);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridViewProfiles);
            groupBox1.Controls.Add(checkBoxProfileParameter);
            groupBox1.Controls.Add(checkBoxAll);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // dataGridViewProfiles
            // 
            dataGridViewProfiles.AllowUserToAddRows = false;
            dataGridViewProfiles.AllowUserToDeleteRows = false;
            dataGridViewProfiles.AllowUserToResizeColumns = false;
            dataGridViewProfiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.MidnightBlue;
            dataGridViewProfiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewProfiles.AutoGenerateColumns = false;
            dataGridViewProfiles.BorderStyle = BorderStyle.None;
            dataGridViewProfiles.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewProfiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(dataGridViewProfiles, "dataGridViewProfiles");
            dataGridViewProfiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewProfiles.ColumnHeadersVisible = false;
            dataGridViewProfiles.Columns.AddRange(new DataGridViewColumn[] { checkDataGridViewCheckBoxColumn2, colorDataGridViewTextBoxColumn, profileDataGridViewTextBoxColumn });
            dataGridViewProfiles.DataSource = bindingSourceProfile;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewProfiles.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewProfiles.MultiSelect = false;
            dataGridViewProfiles.Name = "dataGridViewProfiles";
            dataGridViewProfiles.ReadOnly = true;
            dataGridViewProfiles.RowHeadersVisible = false;
            dataGridViewProfiles.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewProfiles.RowTemplate.Height = 21;
            dataGridViewProfiles.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridViewProfiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            toolTip.SetToolTip(dataGridViewProfiles, resources.GetString("dataGridViewProfiles.ToolTip"));
            dataGridViewProfiles.VirtualMode = true;
            dataGridViewProfiles.CellClick += dataGridViewProfiles_CellClick;
            dataGridViewProfiles.CellDoubleClick += dataGridViewProfiles_CellClick;
            dataGridViewProfiles.KeyDown += dataGridViewProfiles_KeyDown;
            // 
            // checkDataGridViewCheckBoxColumn2
            // 
            checkDataGridViewCheckBoxColumn2.DataPropertyName = "Check";
            resources.ApplyResources(checkDataGridViewCheckBoxColumn2, "checkDataGridViewCheckBoxColumn2");
            checkDataGridViewCheckBoxColumn2.Name = "checkDataGridViewCheckBoxColumn2";
            checkDataGridViewCheckBoxColumn2.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            resources.ApplyResources(colorDataGridViewTextBoxColumn, "colorDataGridViewTextBoxColumn");
            colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            colorDataGridViewTextBoxColumn.ReadOnly = true;
            colorDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            colorDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // profileDataGridViewTextBoxColumn
            // 
            profileDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            profileDataGridViewTextBoxColumn.DataPropertyName = "Profile";
            resources.ApplyResources(profileDataGridViewTextBoxColumn, "profileDataGridViewTextBoxColumn");
            profileDataGridViewTextBoxColumn.Name = "profileDataGridViewTextBoxColumn";
            profileDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceProfile
            // 
            bindingSourceProfile.DataMember = "DataTableProfile";
            bindingSourceProfile.DataSource = dataSet;
            // 
            // dataSet
            // 
            dataSet.DataSetName = "DataSet1";
            dataSet.Locale = new System.Globalization.CultureInfo("ja");
            dataSet.Namespace = "http://tempuri.org/DataSet1.xsd";
            dataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            // 
            // checkBoxProfileParameter
            // 
            resources.ApplyResources(checkBoxProfileParameter, "checkBoxProfileParameter");
            checkBoxProfileParameter.Name = "checkBoxProfileParameter";
            toolTip.SetToolTip(checkBoxProfileParameter, resources.GetString("checkBoxProfileParameter.ToolTip"));
            checkBoxProfileParameter.CheckedChanged += checkBoxProfileParameter_CheckedChanged;
            // 
            // checkBoxAll
            // 
            checkBoxAll.Checked = true;
            checkBoxAll.CheckState = CheckState.Indeterminate;
            resources.ApplyResources(checkBoxAll, "checkBoxAll");
            checkBoxAll.Name = "checkBoxAll";
            toolTip.SetToolTip(checkBoxAll, resources.GetString("checkBoxAll.ToolTip"));
            checkBoxAll.UseVisualStyleBackColor = true;
            checkBoxAll.CheckedChanged += checkBoxAll_CheckedChanged;
            // 
            // groupBoxCrystalData
            // 
            groupBoxCrystalData.Controls.Add(dataGridViewCrystals);
            groupBoxCrystalData.Controls.Add(checkBoxCrystalParameter);
            resources.ApplyResources(groupBoxCrystalData, "groupBoxCrystalData");
            groupBoxCrystalData.Name = "groupBoxCrystalData";
            groupBoxCrystalData.TabStop = false;
            // 
            // dataGridViewCrystals
            // 
            dataGridViewCrystals.AllowUserToAddRows = false;
            dataGridViewCrystals.AllowUserToDeleteRows = false;
            dataGridViewCrystals.AllowUserToResizeColumns = false;
            dataGridViewCrystals.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle4.SelectionBackColor = Color.Blue;
            dataGridViewCrystals.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCrystals.AutoGenerateColumns = false;
            dataGridViewCrystals.BorderStyle = BorderStyle.None;
            dataGridViewCrystals.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridViewCrystals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(dataGridViewCrystals, "dataGridViewCrystals");
            dataGridViewCrystals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCrystals.ColumnHeadersVisible = false;
            dataGridViewCrystals.Columns.AddRange(new DataGridViewColumn[] { checkDataGridViewCheckBoxColumn1, PeakColor, Crystal });
            dataGridViewCrystals.DataSource = bindingSourceCrystal;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle7.Font = new Font("Segoe UI Symbol", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.False;
            dataGridViewCrystals.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCrystals.MultiSelect = false;
            dataGridViewCrystals.Name = "dataGridViewCrystals";
            dataGridViewCrystals.ReadOnly = true;
            dataGridViewCrystals.RowHeadersVisible = false;
            dataGridViewCrystals.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCrystals.RowTemplate.Height = 21;
            dataGridViewCrystals.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridViewCrystals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            toolTip.SetToolTip(dataGridViewCrystals, resources.GetString("dataGridViewCrystals.ToolTip"));
            dataGridViewCrystals.VirtualMode = true;
            dataGridViewCrystals.CellMouseClick += dataGridViewCrystals_CellMouseClick;
            dataGridViewCrystals.CellMouseDoubleClick += dataGridViewCrystals_CellMouseClick;
            dataGridViewCrystals.KeyDown += dataGridViewCrystals_KeyDown;
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
            PeakColor.Resizable = DataGridViewTriState.False;
            PeakColor.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Crystal
            // 
            Crystal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Crystal.DataPropertyName = "Crystal";
            dataGridViewCellStyle6.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Crystal.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(Crystal, "Crystal");
            Crystal.Name = "Crystal";
            Crystal.ReadOnly = true;
            Crystal.Resizable = DataGridViewTriState.False;
            // 
            // bindingSourceCrystal
            // 
            bindingSourceCrystal.DataMember = "DataTableCrystal";
            bindingSourceCrystal.DataSource = dataSet;
            // 
            // checkBoxCrystalParameter
            // 
            resources.ApplyResources(checkBoxCrystalParameter, "checkBoxCrystalParameter");
            checkBoxCrystalParameter.Name = "checkBoxCrystalParameter";
            toolTip.SetToolTip(checkBoxCrystalParameter, resources.GetString("checkBoxCrystalParameter.ToolTip"));
            checkBoxCrystalParameter.CheckedChanged += checkBoxCrystalParameter_CheckedChanged;
            // 
            // toolStrip2
            // 
            resources.ApplyResources(toolStrip2, "toolStrip2");
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButtonCrystalParameter, toolStripSeparator4, toolStripButtonProfileParameter, toolStripSeparator6, toolStripButtonEquationOfState, toolStripSeparator8, toolStripButtonFittingParameter, toolStripSeparator5, toolStripButtonCellFinder, toolStripSeparator11, toolStripButtonSequentialAnalysis, toolStripSeparator10, toolStripButtonAtomicPositonFinder, toolStripSeparator12, toolStripButtonLPO });
            toolStrip2.Name = "toolStrip2";
            // 
            // toolStripButtonCrystalParameter
            // 
            resources.ApplyResources(toolStripButtonCrystalParameter, "toolStripButtonCrystalParameter");
            toolStripButtonCrystalParameter.Name = "toolStripButtonCrystalParameter";
            toolStripButtonCrystalParameter.Click += toolStripButtonCrystalParameter_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
            // 
            // toolStripButtonProfileParameter
            // 
            resources.ApplyResources(toolStripButtonProfileParameter, "toolStripButtonProfileParameter");
            toolStripButtonProfileParameter.Name = "toolStripButtonProfileParameter";
            toolStripButtonProfileParameter.Click += toolStripButtonProfileParameter_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(toolStripSeparator6, "toolStripSeparator6");
            // 
            // toolStripButtonEquationOfState
            // 
            toolStripButtonEquationOfState.CheckOnClick = true;
            resources.ApplyResources(toolStripButtonEquationOfState, "toolStripButtonEquationOfState");
            toolStripButtonEquationOfState.Name = "toolStripButtonEquationOfState";
            toolStripButtonEquationOfState.CheckedChanged += toolStripButtonEquationOfState_CheckedChanged;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(toolStripSeparator8, "toolStripSeparator8");
            // 
            // toolStripButtonFittingParameter
            // 
            toolStripButtonFittingParameter.CheckOnClick = true;
            resources.ApplyResources(toolStripButtonFittingParameter, "toolStripButtonFittingParameter");
            toolStripButtonFittingParameter.Name = "toolStripButtonFittingParameter";
            toolStripButtonFittingParameter.CheckedChanged += toolStripButtonFittingParameter_CheckedChanged;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripButtonCellFinder
            // 
            toolStripButtonCellFinder.CheckOnClick = true;
            toolStripButtonCellFinder.DisplayStyle = ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(toolStripButtonCellFinder, "toolStripButtonCellFinder");
            toolStripButtonCellFinder.Name = "toolStripButtonCellFinder";
            toolStripButtonCellFinder.CheckedChanged += toolStripButtonCellFinder_CheckedChanged;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(toolStripSeparator11, "toolStripSeparator11");
            // 
            // toolStripButtonSequentialAnalysis
            // 
            toolStripButtonSequentialAnalysis.CheckOnClick = true;
            toolStripButtonSequentialAnalysis.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonSequentialAnalysis.Name = "toolStripButtonSequentialAnalysis";
            resources.ApplyResources(toolStripButtonSequentialAnalysis, "toolStripButtonSequentialAnalysis");
            toolStripButtonSequentialAnalysis.CheckedChanged += toolStripButtonStressAnalysis_CheckedChanged;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(toolStripSeparator10, "toolStripSeparator10");
            // 
            // toolStripButtonAtomicPositonFinder
            // 
            toolStripButtonAtomicPositonFinder.CheckOnClick = true;
            toolStripButtonAtomicPositonFinder.DisplayStyle = ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(toolStripButtonAtomicPositonFinder, "toolStripButtonAtomicPositonFinder");
            toolStripButtonAtomicPositonFinder.Name = "toolStripButtonAtomicPositonFinder";
            toolStripButtonAtomicPositonFinder.CheckedChanged += toolStripButtonAtomicPositonFinder_CheckedChanged;
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(toolStripSeparator12, "toolStripSeparator12");
            // 
            // toolStripButtonLPO
            // 
            toolStripButtonLPO.CheckOnClick = true;
            toolStripButtonLPO.DisplayStyle = ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(toolStripButtonLPO, "toolStripButtonLPO");
            toolStripButtonLPO.Name = "toolStripButtonLPO";
            toolStripButtonLPO.CheckedChanged += toolStripButtonLPO_CheckedChanged;
            // 
            // menuStrip
            // 
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.ImageScalingSize = new Size(32, 32);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionToolStripMenuItem, macroToolStripMenuItem, helpToolStripMenuItem, languageToolStripMenuItem });
            menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { readPatternProfileToolStripMenuItem, savePatternProfileToolStripMenuItem, toolStripMenuItemExportExcelFile, toolStripSeparator1, readCrystalDataToolStripMenuItem, readAndAddToolStripMenuItem, saveCrystalDataToolStripMenuItem, toolStripMenuItemImport, toolStripMenuItemExportCIF, resetInitialCrystalDataToolStripMenuItem, toolStripSeparator3, toolStripMenuItemPageSetup, toolStripMenuItemPrintPreview, printToolStripMenuItem, toolStripSeparator9, コピーToolStripMenuItem, toolStripMenuItemSaveMetafile, toolStripSeparator2, closeToolStripMenuItem });
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // readPatternProfileToolStripMenuItem
            // 
            readPatternProfileToolStripMenuItem.Name = "readPatternProfileToolStripMenuItem";
            resources.ApplyResources(readPatternProfileToolStripMenuItem, "readPatternProfileToolStripMenuItem");
            readPatternProfileToolStripMenuItem.Click += menuItemFileRead_Click;
            // 
            // savePatternProfileToolStripMenuItem
            // 
            savePatternProfileToolStripMenuItem.Name = "savePatternProfileToolStripMenuItem";
            resources.ApplyResources(savePatternProfileToolStripMenuItem, "savePatternProfileToolStripMenuItem");
            savePatternProfileToolStripMenuItem.Click += savePatternProfileToolStripMenuItem_Click;
            // 
            // toolStripMenuItemExportExcelFile
            // 
            toolStripMenuItemExportExcelFile.DropDownItems.AddRange(new ToolStripItem[] { asCSVcommaSeperatedFileToolStripMenuItem, asTSVtabSeparatedValuesFileToolStripMenuItem, asGSASFileToolStripMenuItem });
            toolStripMenuItemExportExcelFile.Name = "toolStripMenuItemExportExcelFile";
            resources.ApplyResources(toolStripMenuItemExportExcelFile, "toolStripMenuItemExportExcelFile");
            // 
            // asCSVcommaSeperatedFileToolStripMenuItem
            // 
            asCSVcommaSeperatedFileToolStripMenuItem.Name = "asCSVcommaSeperatedFileToolStripMenuItem";
            resources.ApplyResources(asCSVcommaSeperatedFileToolStripMenuItem, "asCSVcommaSeperatedFileToolStripMenuItem");
            asCSVcommaSeperatedFileToolStripMenuItem.Click += toolStripMenuItemExportCSVFile_Click;
            // 
            // asTSVtabSeparatedValuesFileToolStripMenuItem
            // 
            asTSVtabSeparatedValuesFileToolStripMenuItem.Name = "asTSVtabSeparatedValuesFileToolStripMenuItem";
            resources.ApplyResources(asTSVtabSeparatedValuesFileToolStripMenuItem, "asTSVtabSeparatedValuesFileToolStripMenuItem");
            asTSVtabSeparatedValuesFileToolStripMenuItem.Click += toolStripMenuItemExportCSVFile_Click;
            // 
            // asGSASFileToolStripMenuItem
            // 
            asGSASFileToolStripMenuItem.Name = "asGSASFileToolStripMenuItem";
            resources.ApplyResources(asGSASFileToolStripMenuItem, "asGSASFileToolStripMenuItem");
            asGSASFileToolStripMenuItem.Click += exportGSASFormatToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // readCrystalDataToolStripMenuItem
            // 
            readCrystalDataToolStripMenuItem.Name = "readCrystalDataToolStripMenuItem";
            resources.ApplyResources(readCrystalDataToolStripMenuItem, "readCrystalDataToolStripMenuItem");
            readCrystalDataToolStripMenuItem.Click += menuItemReadCrystalData_Click;
            // 
            // readAndAddToolStripMenuItem
            // 
            readAndAddToolStripMenuItem.Name = "readAndAddToolStripMenuItem";
            resources.ApplyResources(readAndAddToolStripMenuItem, "readAndAddToolStripMenuItem");
            readAndAddToolStripMenuItem.Click += readAndAddToolStripMenuItem_Click;
            // 
            // saveCrystalDataToolStripMenuItem
            // 
            saveCrystalDataToolStripMenuItem.Name = "saveCrystalDataToolStripMenuItem";
            resources.ApplyResources(saveCrystalDataToolStripMenuItem, "saveCrystalDataToolStripMenuItem");
            saveCrystalDataToolStripMenuItem.Click += menuItemSaveCrystalData_Click;
            // 
            // toolStripMenuItemImport
            // 
            toolStripMenuItemImport.Name = "toolStripMenuItemImport";
            resources.ApplyResources(toolStripMenuItemImport, "toolStripMenuItemImport");
            toolStripMenuItemImport.Click += toolStripMenuItemImport_Click;
            // 
            // toolStripMenuItemExportCIF
            // 
            toolStripMenuItemExportCIF.Name = "toolStripMenuItemExportCIF";
            resources.ApplyResources(toolStripMenuItemExportCIF, "toolStripMenuItemExportCIF");
            toolStripMenuItemExportCIF.Click += toolStripMenuItemExportCIF_Click;
            // 
            // resetInitialCrystalDataToolStripMenuItem
            // 
            resetInitialCrystalDataToolStripMenuItem.Name = "resetInitialCrystalDataToolStripMenuItem";
            resources.ApplyResources(resetInitialCrystalDataToolStripMenuItem, "resetInitialCrystalDataToolStripMenuItem");
            resetInitialCrystalDataToolStripMenuItem.Click += resetInitialCrystalDataToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripMenuItemPageSetup
            // 
            toolStripMenuItemPageSetup.Name = "toolStripMenuItemPageSetup";
            resources.ApplyResources(toolStripMenuItemPageSetup, "toolStripMenuItemPageSetup");
            toolStripMenuItemPageSetup.Click += menuItemPrintPageSetup_Click;
            // 
            // toolStripMenuItemPrintPreview
            // 
            toolStripMenuItemPrintPreview.Name = "toolStripMenuItemPrintPreview";
            resources.ApplyResources(toolStripMenuItemPrintPreview, "toolStripMenuItemPrintPreview");
            toolStripMenuItemPrintPreview.Click += menuItemPrintPreview_Click;
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(printToolStripMenuItem, "printToolStripMenuItem");
            printToolStripMenuItem.Click += menuItemPrint_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(toolStripSeparator9, "toolStripSeparator9");
            // 
            // コピーToolStripMenuItem
            // 
            コピーToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { BitmapToolStripMenuItem, copyAsMetafileToolStripMenuItem });
            コピーToolStripMenuItem.Name = "コピーToolStripMenuItem";
            resources.ApplyResources(コピーToolStripMenuItem, "コピーToolStripMenuItem");
            // 
            // BitmapToolStripMenuItem
            // 
            resources.ApplyResources(BitmapToolStripMenuItem, "BitmapToolStripMenuItem");
            BitmapToolStripMenuItem.Name = "BitmapToolStripMenuItem";
            // 
            // copyAsMetafileToolStripMenuItem
            // 
            copyAsMetafileToolStripMenuItem.Name = "copyAsMetafileToolStripMenuItem";
            resources.ApplyResources(copyAsMetafileToolStripMenuItem, "copyAsMetafileToolStripMenuItem");
            copyAsMetafileToolStripMenuItem.Click += copyAsMetafileToolStripMenuItem_Click;
            // 
            // toolStripMenuItemSaveMetafile
            // 
            toolStripMenuItemSaveMetafile.Name = "toolStripMenuItemSaveMetafile";
            resources.ApplyResources(toolStripMenuItemSaveMetafile, "toolStripMenuItemSaveMetafile");
            toolStripMenuItemSaveMetafile.Click += toolStripMenuItemSaveMetafile_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            resources.ApplyResources(closeToolStripMenuItem, "closeToolStripMenuItem");
            closeToolStripMenuItem.Click += menuItemClose_Click;
            // 
            // optionToolStripMenuItem
            // 
            optionToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            optionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolTipToolStripMenuItem, watchReadClipboardToolStripMenuItem, watchReadANewProfileToolStripMenuItem, clearRegistryToolStripMenuItem, automaticallySaveTheCrystalListToolStripMenuItem });
            resources.ApplyResources(optionToolStripMenuItem, "optionToolStripMenuItem");
            optionToolStripMenuItem.Margin = new Padding(4);
            optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            // 
            // toolTipToolStripMenuItem
            // 
            toolTipToolStripMenuItem.Checked = true;
            toolTipToolStripMenuItem.CheckOnClick = true;
            toolTipToolStripMenuItem.CheckState = CheckState.Checked;
            resources.ApplyResources(toolTipToolStripMenuItem, "toolTipToolStripMenuItem");
            toolTipToolStripMenuItem.Name = "toolTipToolStripMenuItem";
            toolTipToolStripMenuItem.Click += toolTipToolStripMenuItem_Click;
            // 
            // watchReadClipboardToolStripMenuItem
            // 
            watchReadClipboardToolStripMenuItem.Checked = true;
            watchReadClipboardToolStripMenuItem.CheckOnClick = true;
            watchReadClipboardToolStripMenuItem.CheckState = CheckState.Checked;
            watchReadClipboardToolStripMenuItem.Name = "watchReadClipboardToolStripMenuItem";
            resources.ApplyResources(watchReadClipboardToolStripMenuItem, "watchReadClipboardToolStripMenuItem");
            watchReadClipboardToolStripMenuItem.CheckedChanged += watchReadClipboardToolStripMenuItem_CheckedChanged;
            // 
            // watchReadANewProfileToolStripMenuItem
            // 
            watchReadANewProfileToolStripMenuItem.CheckOnClick = true;
            watchReadANewProfileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setDirectoryToTheWatchToolStripMenuItem, toolStripTextBoxDirectoryToWatch });
            watchReadANewProfileToolStripMenuItem.Name = "watchReadANewProfileToolStripMenuItem";
            resources.ApplyResources(watchReadANewProfileToolStripMenuItem, "watchReadANewProfileToolStripMenuItem");
            watchReadANewProfileToolStripMenuItem.CheckedChanged += watchReadANewProfileToolStripMenuItem_CheckedChanged;
            // 
            // setDirectoryToTheWatchToolStripMenuItem
            // 
            setDirectoryToTheWatchToolStripMenuItem.Name = "setDirectoryToTheWatchToolStripMenuItem";
            resources.ApplyResources(setDirectoryToTheWatchToolStripMenuItem, "setDirectoryToTheWatchToolStripMenuItem");
            setDirectoryToTheWatchToolStripMenuItem.Click += setDirectoryToTheWatchToolStripMenuItem_Click;
            // 
            // toolStripTextBoxDirectoryToWatch
            // 
            toolStripTextBoxDirectoryToWatch.Name = "toolStripTextBoxDirectoryToWatch";
            resources.ApplyResources(toolStripTextBoxDirectoryToWatch, "toolStripTextBoxDirectoryToWatch");
            toolStripTextBoxDirectoryToWatch.TextChanged += toolStripTextBoxDirectoryToWatch_TextChanged;
            // 
            // clearRegistryToolStripMenuItem
            // 
            clearRegistryToolStripMenuItem.CheckOnClick = true;
            clearRegistryToolStripMenuItem.Name = "clearRegistryToolStripMenuItem";
            resources.ApplyResources(clearRegistryToolStripMenuItem, "clearRegistryToolStripMenuItem");
            // 
            // automaticallySaveTheCrystalListToolStripMenuItem
            // 
            automaticallySaveTheCrystalListToolStripMenuItem.Checked = true;
            automaticallySaveTheCrystalListToolStripMenuItem.CheckOnClick = true;
            automaticallySaveTheCrystalListToolStripMenuItem.CheckState = CheckState.Checked;
            automaticallySaveTheCrystalListToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            automaticallySaveTheCrystalListToolStripMenuItem.Name = "automaticallySaveTheCrystalListToolStripMenuItem";
            resources.ApplyResources(automaticallySaveTheCrystalListToolStripMenuItem, "automaticallySaveTheCrystalListToolStripMenuItem");
            // 
            // macroToolStripMenuItem
            // 
            macroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editorToolStripMenuItem });
            macroToolStripMenuItem.Name = "macroToolStripMenuItem";
            resources.ApplyResources(macroToolStripMenuItem, "macroToolStripMenuItem");
            // 
            // editorToolStripMenuItem
            // 
            editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            resources.ApplyResources(editorToolStripMenuItem, "editorToolStripMenuItem");
            editorToolStripMenuItem.Click += editorToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutMeToolStripMenuItem, programUpdatesToolStripMenuItem, hintToolStripMenuItem, helpwebToolStripMenuItem });
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // aboutMeToolStripMenuItem
            // 
            aboutMeToolStripMenuItem.Name = "aboutMeToolStripMenuItem";
            resources.ApplyResources(aboutMeToolStripMenuItem, "aboutMeToolStripMenuItem");
            aboutMeToolStripMenuItem.Click += aboutMeToolStripMenuItem_Click;
            // 
            // programUpdatesToolStripMenuItem
            // 
            programUpdatesToolStripMenuItem.Name = "programUpdatesToolStripMenuItem";
            resources.ApplyResources(programUpdatesToolStripMenuItem, "programUpdatesToolStripMenuItem");
            programUpdatesToolStripMenuItem.Click += programUpdatesToolStripMenuItem_Click;
            // 
            // hintToolStripMenuItem
            // 
            hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            resources.ApplyResources(hintToolStripMenuItem, "hintToolStripMenuItem");
            hintToolStripMenuItem.Click += hintToolStripMenuItem_Click;
            // 
            // helpwebToolStripMenuItem
            // 
            helpwebToolStripMenuItem.Name = "helpwebToolStripMenuItem";
            resources.ApplyResources(helpwebToolStripMenuItem, "helpwebToolStripMenuItem");
            helpwebToolStripMenuItem.Click += helpwebToolStripMenuItem_Click;
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { englishToolStripMenuItem, japaneseToolStripMenuItem });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(englishToolStripMenuItem, "englishToolStripMenuItem");
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            englishToolStripMenuItem.Click += languageToolStripMenuItem_Click;
            // 
            // japaneseToolStripMenuItem
            // 
            resources.ApplyResources(japaneseToolStripMenuItem, "japaneseToolStripMenuItem");
            japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            japaneseToolStripMenuItem.Click += languageToolStripMenuItem_Click;
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            // 
            // button3
            // 
            resources.ApplyResources(button3, "button3");
            button3.Name = "button3";
            // 
            // buttonAu
            // 
            resources.ApplyResources(buttonAu, "buttonAu");
            buttonAu.Name = "buttonAu";
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 10000;
            toolTip.InitialDelay = 500;
            toolTip.IsBalloon = true;
            toolTip.ReshowDelay = 100;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // checkDataGridViewCheckBoxColumn
            // 
            checkDataGridViewCheckBoxColumn.DataPropertyName = "Check";
            resources.ApplyResources(checkDataGridViewCheckBoxColumn, "checkDataGridViewCheckBoxColumn");
            checkDataGridViewCheckBoxColumn.Name = "checkDataGridViewCheckBoxColumn";
            // 
            // Check
            // 
            Check.DataPropertyName = "Check";
            resources.ApplyResources(Check, "Check");
            Check.Name = "Check";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn3.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn5.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn6.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn7.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn8.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn9.DataPropertyName = "Crystal";
            resources.ApplyResources(dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn10.DataPropertyName = "Crystal";
            dataGridViewCellStyle8.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn11.DataPropertyName = "Crystal";
            dataGridViewCellStyle9.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn12.DataPropertyName = "Crystal";
            dataGridViewCellStyle10.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle10;
            resources.ApplyResources(dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn13.DataPropertyName = "Crystal";
            dataGridViewCellStyle11.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn14.DataPropertyName = "Crystal";
            dataGridViewCellStyle12.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn15.DataPropertyName = "Crystal";
            dataGridViewCellStyle13.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle13;
            resources.ApplyResources(dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn16.DataPropertyName = "Crystal";
            dataGridViewCellStyle14.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle14;
            resources.ApplyResources(dataGridViewTextBoxColumn16, "dataGridViewTextBoxColumn16");
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn17.DataPropertyName = "Crystal";
            dataGridViewCellStyle15.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle15;
            resources.ApplyResources(dataGridViewTextBoxColumn17, "dataGridViewTextBoxColumn17");
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            dataGridViewTextBoxColumn18.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn18.DataPropertyName = "Crystal";
            dataGridViewCellStyle16.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle16;
            resources.ApplyResources(dataGridViewTextBoxColumn18, "dataGridViewTextBoxColumn18");
            dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            dataGridViewTextBoxColumn19.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn19.DataPropertyName = "Crystal";
            dataGridViewCellStyle17.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle17;
            resources.ApplyResources(dataGridViewTextBoxColumn19, "dataGridViewTextBoxColumn19");
            dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            dataGridViewTextBoxColumn20.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn20.DataPropertyName = "Crystal";
            dataGridViewCellStyle18.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle18;
            resources.ApplyResources(dataGridViewTextBoxColumn20, "dataGridViewTextBoxColumn20");
            dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            dataGridViewTextBoxColumn21.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn21.DataPropertyName = "Crystal";
            dataGridViewCellStyle19.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle19;
            resources.ApplyResources(dataGridViewTextBoxColumn21, "dataGridViewTextBoxColumn21");
            dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn22
            // 
            dataGridViewTextBoxColumn22.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn22.DataPropertyName = "Crystal";
            dataGridViewCellStyle20.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle20;
            resources.ApplyResources(dataGridViewTextBoxColumn22, "dataGridViewTextBoxColumn22");
            dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            dataGridViewTextBoxColumn23.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn23.DataPropertyName = "Crystal";
            dataGridViewCellStyle21.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle21;
            resources.ApplyResources(dataGridViewTextBoxColumn23, "dataGridViewTextBoxColumn23");
            dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn25
            // 
            dataGridViewTextBoxColumn25.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewTextBoxColumn25, "dataGridViewTextBoxColumn25");
            dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            dataGridViewTextBoxColumn25.ReadOnly = true;
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
            // dataGridViewTextBoxColumn24
            // 
            dataGridViewTextBoxColumn24.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn24.DataPropertyName = "Crystal";
            dataGridViewCellStyle22.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle22;
            resources.ApplyResources(dataGridViewTextBoxColumn24, "dataGridViewTextBoxColumn24");
            dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            dataGridViewTextBoxColumn24.ReadOnly = true;
            dataGridViewTextBoxColumn24.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn2
            // 
            dataGridViewImageColumn2.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn2, "dataGridViewImageColumn2");
            dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            dataGridViewImageColumn2.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn2.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn26
            // 
            dataGridViewTextBoxColumn26.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn26.DataPropertyName = "Crystal";
            dataGridViewCellStyle23.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle23;
            resources.ApplyResources(dataGridViewTextBoxColumn26, "dataGridViewTextBoxColumn26");
            dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            dataGridViewTextBoxColumn26.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn3
            // 
            dataGridViewImageColumn3.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn3, "dataGridViewImageColumn3");
            dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            dataGridViewImageColumn3.ReadOnly = true;
            dataGridViewImageColumn3.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn3.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn27
            // 
            dataGridViewTextBoxColumn27.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn27.DataPropertyName = "Crystal";
            dataGridViewCellStyle24.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn27.DefaultCellStyle = dataGridViewCellStyle24;
            resources.ApplyResources(dataGridViewTextBoxColumn27, "dataGridViewTextBoxColumn27");
            dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            dataGridViewTextBoxColumn27.ReadOnly = true;
            dataGridViewTextBoxColumn27.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn30
            // 
            dataGridViewTextBoxColumn30.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn30.DataPropertyName = "Crystal";
            dataGridViewCellStyle25.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle25;
            resources.ApplyResources(dataGridViewTextBoxColumn30, "dataGridViewTextBoxColumn30");
            dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            dataGridViewTextBoxColumn30.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn4
            // 
            dataGridViewImageColumn4.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn4, "dataGridViewImageColumn4");
            dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            dataGridViewImageColumn4.ReadOnly = true;
            dataGridViewImageColumn4.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn4.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn28
            // 
            dataGridViewTextBoxColumn28.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn28.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn28, "dataGridViewTextBoxColumn28");
            dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // dataGridViewImageColumn5
            // 
            dataGridViewImageColumn5.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn5, "dataGridViewImageColumn5");
            dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
            dataGridViewImageColumn5.ReadOnly = true;
            dataGridViewImageColumn5.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn5.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn29
            // 
            dataGridViewTextBoxColumn29.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn29.DataPropertyName = "Color";
            dataGridViewCellStyle26.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle26;
            resources.ApplyResources(dataGridViewTextBoxColumn29, "dataGridViewTextBoxColumn29");
            dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            dataGridViewTextBoxColumn29.ReadOnly = true;
            dataGridViewTextBoxColumn29.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn6
            // 
            dataGridViewImageColumn6.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn6, "dataGridViewImageColumn6");
            dataGridViewImageColumn6.Name = "dataGridViewImageColumn6";
            dataGridViewImageColumn6.ReadOnly = true;
            dataGridViewImageColumn6.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn6.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn31
            // 
            dataGridViewTextBoxColumn31.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn31.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn31, "dataGridViewTextBoxColumn31");
            dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            dataGridViewTextBoxColumn31.ReadOnly = true;
            // 
            // dataGridViewImageColumn7
            // 
            dataGridViewImageColumn7.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn7, "dataGridViewImageColumn7");
            dataGridViewImageColumn7.Name = "dataGridViewImageColumn7";
            dataGridViewImageColumn7.ReadOnly = true;
            dataGridViewImageColumn7.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn7.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn32
            // 
            dataGridViewTextBoxColumn32.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn32.DataPropertyName = "Crystal";
            dataGridViewCellStyle27.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle27;
            resources.ApplyResources(dataGridViewTextBoxColumn32, "dataGridViewTextBoxColumn32");
            dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            dataGridViewTextBoxColumn32.ReadOnly = true;
            dataGridViewTextBoxColumn32.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn8
            // 
            dataGridViewImageColumn8.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn8, "dataGridViewImageColumn8");
            dataGridViewImageColumn8.Name = "dataGridViewImageColumn8";
            dataGridViewImageColumn8.ReadOnly = true;
            dataGridViewImageColumn8.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn8.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn33
            // 
            dataGridViewTextBoxColumn33.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn33.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn33, "dataGridViewTextBoxColumn33");
            dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            dataGridViewTextBoxColumn33.ReadOnly = true;
            // 
            // dataGridViewImageColumn9
            // 
            dataGridViewImageColumn9.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn9, "dataGridViewImageColumn9");
            dataGridViewImageColumn9.Name = "dataGridViewImageColumn9";
            dataGridViewImageColumn9.ReadOnly = true;
            dataGridViewImageColumn9.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn9.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn34
            // 
            dataGridViewTextBoxColumn34.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn34.DataPropertyName = "Crystal";
            dataGridViewCellStyle28.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn34.DefaultCellStyle = dataGridViewCellStyle28;
            resources.ApplyResources(dataGridViewTextBoxColumn34, "dataGridViewTextBoxColumn34");
            dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            dataGridViewTextBoxColumn34.ReadOnly = true;
            dataGridViewTextBoxColumn34.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn10
            // 
            dataGridViewImageColumn10.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn10, "dataGridViewImageColumn10");
            dataGridViewImageColumn10.Name = "dataGridViewImageColumn10";
            dataGridViewImageColumn10.ReadOnly = true;
            dataGridViewImageColumn10.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn10.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn35
            // 
            dataGridViewTextBoxColumn35.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn35.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn35, "dataGridViewTextBoxColumn35");
            dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            dataGridViewTextBoxColumn35.ReadOnly = true;
            // 
            // dataGridViewImageColumn11
            // 
            dataGridViewImageColumn11.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn11, "dataGridViewImageColumn11");
            dataGridViewImageColumn11.Name = "dataGridViewImageColumn11";
            dataGridViewImageColumn11.ReadOnly = true;
            dataGridViewImageColumn11.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn11.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn36
            // 
            dataGridViewTextBoxColumn36.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn36.DataPropertyName = "Crystal";
            dataGridViewCellStyle29.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn36.DefaultCellStyle = dataGridViewCellStyle29;
            resources.ApplyResources(dataGridViewTextBoxColumn36, "dataGridViewTextBoxColumn36");
            dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            dataGridViewTextBoxColumn36.ReadOnly = true;
            dataGridViewTextBoxColumn36.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn12
            // 
            dataGridViewImageColumn12.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn12, "dataGridViewImageColumn12");
            dataGridViewImageColumn12.Name = "dataGridViewImageColumn12";
            dataGridViewImageColumn12.ReadOnly = true;
            dataGridViewImageColumn12.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn12.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn37
            // 
            dataGridViewTextBoxColumn37.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn37.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn37, "dataGridViewTextBoxColumn37");
            dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            dataGridViewTextBoxColumn37.ReadOnly = true;
            // 
            // dataGridViewImageColumn13
            // 
            dataGridViewImageColumn13.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn13, "dataGridViewImageColumn13");
            dataGridViewImageColumn13.Name = "dataGridViewImageColumn13";
            dataGridViewImageColumn13.ReadOnly = true;
            dataGridViewImageColumn13.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn13.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn38
            // 
            dataGridViewTextBoxColumn38.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn38.DataPropertyName = "Crystal";
            dataGridViewCellStyle30.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle30;
            resources.ApplyResources(dataGridViewTextBoxColumn38, "dataGridViewTextBoxColumn38");
            dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            dataGridViewTextBoxColumn38.ReadOnly = true;
            dataGridViewTextBoxColumn38.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn15
            // 
            dataGridViewImageColumn15.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn15, "dataGridViewImageColumn15");
            dataGridViewImageColumn15.Name = "dataGridViewImageColumn15";
            dataGridViewImageColumn15.ReadOnly = true;
            dataGridViewImageColumn15.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn15.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn40
            // 
            dataGridViewTextBoxColumn40.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn40.DataPropertyName = "Crystal";
            dataGridViewCellStyle31.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn40.DefaultCellStyle = dataGridViewCellStyle31;
            resources.ApplyResources(dataGridViewTextBoxColumn40, "dataGridViewTextBoxColumn40");
            dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            dataGridViewTextBoxColumn40.ReadOnly = true;
            dataGridViewTextBoxColumn40.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn14
            // 
            dataGridViewImageColumn14.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn14, "dataGridViewImageColumn14");
            dataGridViewImageColumn14.Name = "dataGridViewImageColumn14";
            dataGridViewImageColumn14.ReadOnly = true;
            dataGridViewImageColumn14.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn14.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn39
            // 
            dataGridViewTextBoxColumn39.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn39.DataPropertyName = "Profile";
            dataGridViewCellStyle32.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle32;
            resources.ApplyResources(dataGridViewTextBoxColumn39, "dataGridViewTextBoxColumn39");
            dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            dataGridViewTextBoxColumn39.ReadOnly = true;
            dataGridViewTextBoxColumn39.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn16
            // 
            dataGridViewImageColumn16.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn16, "dataGridViewImageColumn16");
            dataGridViewImageColumn16.Name = "dataGridViewImageColumn16";
            dataGridViewImageColumn16.ReadOnly = true;
            dataGridViewImageColumn16.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn16.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn41
            // 
            dataGridViewTextBoxColumn41.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn41.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn41, "dataGridViewTextBoxColumn41");
            dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            dataGridViewTextBoxColumn41.ReadOnly = true;
            // 
            // dataGridViewImageColumn17
            // 
            dataGridViewImageColumn17.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn17, "dataGridViewImageColumn17");
            dataGridViewImageColumn17.Name = "dataGridViewImageColumn17";
            dataGridViewImageColumn17.ReadOnly = true;
            dataGridViewImageColumn17.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn17.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn42
            // 
            dataGridViewTextBoxColumn42.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn42.DataPropertyName = "Crystal";
            dataGridViewCellStyle33.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn42.DefaultCellStyle = dataGridViewCellStyle33;
            resources.ApplyResources(dataGridViewTextBoxColumn42, "dataGridViewTextBoxColumn42");
            dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            dataGridViewTextBoxColumn42.ReadOnly = true;
            dataGridViewTextBoxColumn42.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn19
            // 
            dataGridViewImageColumn19.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn19, "dataGridViewImageColumn19");
            dataGridViewImageColumn19.Name = "dataGridViewImageColumn19";
            dataGridViewImageColumn19.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn19.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn44
            // 
            dataGridViewTextBoxColumn44.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn44.DataPropertyName = "Crystal";
            dataGridViewCellStyle34.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn44.DefaultCellStyle = dataGridViewCellStyle34;
            resources.ApplyResources(dataGridViewTextBoxColumn44, "dataGridViewTextBoxColumn44");
            dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            dataGridViewTextBoxColumn44.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn18
            // 
            dataGridViewImageColumn18.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn18, "dataGridViewImageColumn18");
            dataGridViewImageColumn18.Name = "dataGridViewImageColumn18";
            dataGridViewImageColumn18.ReadOnly = true;
            dataGridViewImageColumn18.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn18.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn43
            // 
            dataGridViewTextBoxColumn43.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn43.DataPropertyName = "Profile";
            dataGridViewCellStyle35.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn43.DefaultCellStyle = dataGridViewCellStyle35;
            resources.ApplyResources(dataGridViewTextBoxColumn43, "dataGridViewTextBoxColumn43");
            dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            dataGridViewTextBoxColumn43.ReadOnly = true;
            dataGridViewTextBoxColumn43.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn20
            // 
            dataGridViewImageColumn20.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn20, "dataGridViewImageColumn20");
            dataGridViewImageColumn20.Name = "dataGridViewImageColumn20";
            dataGridViewImageColumn20.ReadOnly = true;
            dataGridViewImageColumn20.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn20.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn45
            // 
            dataGridViewTextBoxColumn45.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn45.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn45, "dataGridViewTextBoxColumn45");
            dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            dataGridViewTextBoxColumn45.ReadOnly = true;
            // 
            // dataGridViewImageColumn21
            // 
            dataGridViewImageColumn21.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn21, "dataGridViewImageColumn21");
            dataGridViewImageColumn21.Name = "dataGridViewImageColumn21";
            dataGridViewImageColumn21.ReadOnly = true;
            dataGridViewImageColumn21.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn21.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn46
            // 
            dataGridViewTextBoxColumn46.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn46.DataPropertyName = "Crystal";
            dataGridViewCellStyle36.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn46.DefaultCellStyle = dataGridViewCellStyle36;
            resources.ApplyResources(dataGridViewTextBoxColumn46, "dataGridViewTextBoxColumn46");
            dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            dataGridViewTextBoxColumn46.ReadOnly = true;
            dataGridViewTextBoxColumn46.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn22
            // 
            dataGridViewImageColumn22.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn22, "dataGridViewImageColumn22");
            dataGridViewImageColumn22.Name = "dataGridViewImageColumn22";
            dataGridViewImageColumn22.ReadOnly = true;
            dataGridViewImageColumn22.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn22.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn47
            // 
            dataGridViewTextBoxColumn47.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn47.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn47, "dataGridViewTextBoxColumn47");
            dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            dataGridViewTextBoxColumn47.ReadOnly = true;
            // 
            // dataGridViewImageColumn23
            // 
            dataGridViewImageColumn23.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn23, "dataGridViewImageColumn23");
            dataGridViewImageColumn23.Name = "dataGridViewImageColumn23";
            dataGridViewImageColumn23.ReadOnly = true;
            dataGridViewImageColumn23.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn23.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn48
            // 
            dataGridViewTextBoxColumn48.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn48.DataPropertyName = "Crystal";
            dataGridViewCellStyle37.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn48.DefaultCellStyle = dataGridViewCellStyle37;
            resources.ApplyResources(dataGridViewTextBoxColumn48, "dataGridViewTextBoxColumn48");
            dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            dataGridViewTextBoxColumn48.ReadOnly = true;
            dataGridViewTextBoxColumn48.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn24
            // 
            dataGridViewImageColumn24.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn24, "dataGridViewImageColumn24");
            dataGridViewImageColumn24.Name = "dataGridViewImageColumn24";
            dataGridViewImageColumn24.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn24.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn49
            // 
            dataGridViewTextBoxColumn49.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn49.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn49, "dataGridViewTextBoxColumn49");
            dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            // 
            // dataGridViewImageColumn25
            // 
            dataGridViewImageColumn25.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn25, "dataGridViewImageColumn25");
            dataGridViewImageColumn25.Name = "dataGridViewImageColumn25";
            dataGridViewImageColumn25.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn25.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn50
            // 
            dataGridViewTextBoxColumn50.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn50.DataPropertyName = "Crystal";
            dataGridViewCellStyle38.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn50.DefaultCellStyle = dataGridViewCellStyle38;
            resources.ApplyResources(dataGridViewTextBoxColumn50, "dataGridViewTextBoxColumn50");
            dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            dataGridViewTextBoxColumn50.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn26
            // 
            dataGridViewImageColumn26.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn26, "dataGridViewImageColumn26");
            dataGridViewImageColumn26.Name = "dataGridViewImageColumn26";
            dataGridViewImageColumn26.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn26.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn51
            // 
            dataGridViewTextBoxColumn51.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn51.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn51, "dataGridViewTextBoxColumn51");
            dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            // 
            // dataGridViewImageColumn27
            // 
            dataGridViewImageColumn27.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn27, "dataGridViewImageColumn27");
            dataGridViewImageColumn27.Name = "dataGridViewImageColumn27";
            dataGridViewImageColumn27.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn27.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn52
            // 
            dataGridViewTextBoxColumn52.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn52.DataPropertyName = "Crystal";
            dataGridViewCellStyle39.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn52.DefaultCellStyle = dataGridViewCellStyle39;
            resources.ApplyResources(dataGridViewTextBoxColumn52, "dataGridViewTextBoxColumn52");
            dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            dataGridViewTextBoxColumn52.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn29
            // 
            dataGridViewImageColumn29.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn29, "dataGridViewImageColumn29");
            dataGridViewImageColumn29.Name = "dataGridViewImageColumn29";
            dataGridViewImageColumn29.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn29.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn54
            // 
            dataGridViewTextBoxColumn54.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn54.DataPropertyName = "Crystal";
            dataGridViewCellStyle40.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn54.DefaultCellStyle = dataGridViewCellStyle40;
            resources.ApplyResources(dataGridViewTextBoxColumn54, "dataGridViewTextBoxColumn54");
            dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            dataGridViewTextBoxColumn54.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn28
            // 
            dataGridViewImageColumn28.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn28, "dataGridViewImageColumn28");
            dataGridViewImageColumn28.Name = "dataGridViewImageColumn28";
            dataGridViewImageColumn28.ReadOnly = true;
            dataGridViewImageColumn28.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn28.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn53
            // 
            dataGridViewTextBoxColumn53.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn53.DataPropertyName = "Profile";
            dataGridViewCellStyle41.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn53.DefaultCellStyle = dataGridViewCellStyle41;
            resources.ApplyResources(dataGridViewTextBoxColumn53, "dataGridViewTextBoxColumn53");
            dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            dataGridViewTextBoxColumn53.ReadOnly = true;
            dataGridViewTextBoxColumn53.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn30
            // 
            dataGridViewImageColumn30.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn30, "dataGridViewImageColumn30");
            dataGridViewImageColumn30.Name = "dataGridViewImageColumn30";
            dataGridViewImageColumn30.ReadOnly = true;
            dataGridViewImageColumn30.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn30.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn55
            // 
            dataGridViewTextBoxColumn55.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn55.DataPropertyName = "Profile";
            dataGridViewCellStyle42.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn55.DefaultCellStyle = dataGridViewCellStyle42;
            resources.ApplyResources(dataGridViewTextBoxColumn55, "dataGridViewTextBoxColumn55");
            dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            dataGridViewTextBoxColumn55.ReadOnly = true;
            dataGridViewTextBoxColumn55.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn31
            // 
            dataGridViewImageColumn31.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn31, "dataGridViewImageColumn31");
            dataGridViewImageColumn31.Name = "dataGridViewImageColumn31";
            dataGridViewImageColumn31.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn31.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn56
            // 
            dataGridViewTextBoxColumn56.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn56.DataPropertyName = "Crystal";
            dataGridViewCellStyle43.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn56.DefaultCellStyle = dataGridViewCellStyle43;
            resources.ApplyResources(dataGridViewTextBoxColumn56, "dataGridViewTextBoxColumn56");
            dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
            dataGridViewTextBoxColumn56.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn32
            // 
            dataGridViewImageColumn32.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn32, "dataGridViewImageColumn32");
            dataGridViewImageColumn32.Name = "dataGridViewImageColumn32";
            dataGridViewImageColumn32.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn32.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn57
            // 
            dataGridViewTextBoxColumn57.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn57.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn57, "dataGridViewTextBoxColumn57");
            dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            // 
            // dataGridViewImageColumn33
            // 
            dataGridViewImageColumn33.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn33, "dataGridViewImageColumn33");
            dataGridViewImageColumn33.Name = "dataGridViewImageColumn33";
            dataGridViewImageColumn33.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn33.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn58
            // 
            dataGridViewTextBoxColumn58.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn58.DataPropertyName = "Crystal";
            dataGridViewCellStyle44.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn58.DefaultCellStyle = dataGridViewCellStyle44;
            resources.ApplyResources(dataGridViewTextBoxColumn58, "dataGridViewTextBoxColumn58");
            dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
            dataGridViewTextBoxColumn58.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn34
            // 
            dataGridViewImageColumn34.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn34, "dataGridViewImageColumn34");
            dataGridViewImageColumn34.Name = "dataGridViewImageColumn34";
            dataGridViewImageColumn34.ReadOnly = true;
            dataGridViewImageColumn34.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn34.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn59
            // 
            dataGridViewTextBoxColumn59.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn59.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn59, "dataGridViewTextBoxColumn59");
            dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
            dataGridViewTextBoxColumn59.ReadOnly = true;
            // 
            // dataGridViewImageColumn35
            // 
            dataGridViewImageColumn35.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn35, "dataGridViewImageColumn35");
            dataGridViewImageColumn35.Name = "dataGridViewImageColumn35";
            dataGridViewImageColumn35.ReadOnly = true;
            dataGridViewImageColumn35.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn35.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn60
            // 
            dataGridViewTextBoxColumn60.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn60.DataPropertyName = "Crystal";
            dataGridViewCellStyle45.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn60.DefaultCellStyle = dataGridViewCellStyle45;
            resources.ApplyResources(dataGridViewTextBoxColumn60, "dataGridViewTextBoxColumn60");
            dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
            dataGridViewTextBoxColumn60.ReadOnly = true;
            dataGridViewTextBoxColumn60.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn36
            // 
            dataGridViewImageColumn36.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn36, "dataGridViewImageColumn36");
            dataGridViewImageColumn36.Name = "dataGridViewImageColumn36";
            dataGridViewImageColumn36.ReadOnly = true;
            dataGridViewImageColumn36.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn36.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn61
            // 
            dataGridViewTextBoxColumn61.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn61.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn61, "dataGridViewTextBoxColumn61");
            dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
            dataGridViewTextBoxColumn61.ReadOnly = true;
            // 
            // dataGridViewImageColumn37
            // 
            dataGridViewImageColumn37.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn37, "dataGridViewImageColumn37");
            dataGridViewImageColumn37.Name = "dataGridViewImageColumn37";
            dataGridViewImageColumn37.ReadOnly = true;
            dataGridViewImageColumn37.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn37.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn62
            // 
            dataGridViewTextBoxColumn62.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn62.DataPropertyName = "Crystal";
            dataGridViewCellStyle46.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn62.DefaultCellStyle = dataGridViewCellStyle46;
            resources.ApplyResources(dataGridViewTextBoxColumn62, "dataGridViewTextBoxColumn62");
            dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
            dataGridViewTextBoxColumn62.ReadOnly = true;
            dataGridViewTextBoxColumn62.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn38
            // 
            dataGridViewImageColumn38.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn38, "dataGridViewImageColumn38");
            dataGridViewImageColumn38.Name = "dataGridViewImageColumn38";
            dataGridViewImageColumn38.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn38.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn63
            // 
            dataGridViewTextBoxColumn63.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn63.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn63, "dataGridViewTextBoxColumn63");
            dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
            // 
            // dataGridViewImageColumn39
            // 
            dataGridViewImageColumn39.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn39, "dataGridViewImageColumn39");
            dataGridViewImageColumn39.Name = "dataGridViewImageColumn39";
            dataGridViewImageColumn39.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn39.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn64
            // 
            dataGridViewTextBoxColumn64.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn64.DataPropertyName = "Crystal";
            dataGridViewCellStyle47.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn64.DefaultCellStyle = dataGridViewCellStyle47;
            resources.ApplyResources(dataGridViewTextBoxColumn64, "dataGridViewTextBoxColumn64");
            dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
            dataGridViewTextBoxColumn64.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn40
            // 
            dataGridViewImageColumn40.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn40, "dataGridViewImageColumn40");
            dataGridViewImageColumn40.Name = "dataGridViewImageColumn40";
            dataGridViewImageColumn40.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn40.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn65
            // 
            dataGridViewTextBoxColumn65.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn65.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn65, "dataGridViewTextBoxColumn65");
            dataGridViewTextBoxColumn65.Name = "dataGridViewTextBoxColumn65";
            // 
            // dataGridViewImageColumn41
            // 
            dataGridViewImageColumn41.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn41, "dataGridViewImageColumn41");
            dataGridViewImageColumn41.Name = "dataGridViewImageColumn41";
            dataGridViewImageColumn41.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn41.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn66
            // 
            dataGridViewTextBoxColumn66.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn66.DataPropertyName = "Crystal";
            dataGridViewCellStyle48.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn66.DefaultCellStyle = dataGridViewCellStyle48;
            resources.ApplyResources(dataGridViewTextBoxColumn66, "dataGridViewTextBoxColumn66");
            dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
            dataGridViewTextBoxColumn66.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn42
            // 
            dataGridViewImageColumn42.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn42, "dataGridViewImageColumn42");
            dataGridViewImageColumn42.Name = "dataGridViewImageColumn42";
            dataGridViewImageColumn42.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn42.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn67
            // 
            dataGridViewTextBoxColumn67.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn67.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn67, "dataGridViewTextBoxColumn67");
            dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
            // 
            // dataGridViewImageColumn43
            // 
            dataGridViewImageColumn43.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn43, "dataGridViewImageColumn43");
            dataGridViewImageColumn43.Name = "dataGridViewImageColumn43";
            dataGridViewImageColumn43.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn43.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn68
            // 
            dataGridViewTextBoxColumn68.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn68.DataPropertyName = "Crystal";
            dataGridViewCellStyle49.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn68.DefaultCellStyle = dataGridViewCellStyle49;
            resources.ApplyResources(dataGridViewTextBoxColumn68, "dataGridViewTextBoxColumn68");
            dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
            dataGridViewTextBoxColumn68.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn44
            // 
            dataGridViewImageColumn44.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn44, "dataGridViewImageColumn44");
            dataGridViewImageColumn44.Name = "dataGridViewImageColumn44";
            dataGridViewImageColumn44.ReadOnly = true;
            dataGridViewImageColumn44.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn44.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn69
            // 
            dataGridViewTextBoxColumn69.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn69.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn69, "dataGridViewTextBoxColumn69");
            dataGridViewTextBoxColumn69.Name = "dataGridViewTextBoxColumn69";
            dataGridViewTextBoxColumn69.ReadOnly = true;
            // 
            // dataGridViewImageColumn45
            // 
            dataGridViewImageColumn45.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn45, "dataGridViewImageColumn45");
            dataGridViewImageColumn45.Name = "dataGridViewImageColumn45";
            dataGridViewImageColumn45.ReadOnly = true;
            dataGridViewImageColumn45.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn45.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn70
            // 
            dataGridViewTextBoxColumn70.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn70.DataPropertyName = "Crystal";
            dataGridViewCellStyle50.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn70.DefaultCellStyle = dataGridViewCellStyle50;
            resources.ApplyResources(dataGridViewTextBoxColumn70, "dataGridViewTextBoxColumn70");
            dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
            dataGridViewTextBoxColumn70.ReadOnly = true;
            dataGridViewTextBoxColumn70.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn46
            // 
            dataGridViewImageColumn46.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn46, "dataGridViewImageColumn46");
            dataGridViewImageColumn46.Name = "dataGridViewImageColumn46";
            dataGridViewImageColumn46.ReadOnly = true;
            dataGridViewImageColumn46.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn46.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn71
            // 
            dataGridViewTextBoxColumn71.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn71.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn71, "dataGridViewTextBoxColumn71");
            dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
            dataGridViewTextBoxColumn71.ReadOnly = true;
            // 
            // dataGridViewImageColumn47
            // 
            dataGridViewImageColumn47.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn47, "dataGridViewImageColumn47");
            dataGridViewImageColumn47.Name = "dataGridViewImageColumn47";
            dataGridViewImageColumn47.ReadOnly = true;
            dataGridViewImageColumn47.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn47.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn72
            // 
            dataGridViewTextBoxColumn72.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn72.DataPropertyName = "Crystal";
            dataGridViewCellStyle51.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn72.DefaultCellStyle = dataGridViewCellStyle51;
            resources.ApplyResources(dataGridViewTextBoxColumn72, "dataGridViewTextBoxColumn72");
            dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
            dataGridViewTextBoxColumn72.ReadOnly = true;
            dataGridViewTextBoxColumn72.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn48
            // 
            dataGridViewImageColumn48.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn48, "dataGridViewImageColumn48");
            dataGridViewImageColumn48.Name = "dataGridViewImageColumn48";
            dataGridViewImageColumn48.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn48.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn73
            // 
            dataGridViewTextBoxColumn73.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn73.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn73, "dataGridViewTextBoxColumn73");
            dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
            // 
            // dataGridViewImageColumn49
            // 
            dataGridViewImageColumn49.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn49, "dataGridViewImageColumn49");
            dataGridViewImageColumn49.Name = "dataGridViewImageColumn49";
            dataGridViewImageColumn49.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn49.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn74
            // 
            dataGridViewTextBoxColumn74.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn74.DataPropertyName = "Crystal";
            dataGridViewCellStyle52.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn74.DefaultCellStyle = dataGridViewCellStyle52;
            resources.ApplyResources(dataGridViewTextBoxColumn74, "dataGridViewTextBoxColumn74");
            dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
            dataGridViewTextBoxColumn74.Resizable = DataGridViewTriState.False;
            // 
            // timerBlinkDiffraction
            // 
            timerBlinkDiffraction.Interval = 400;
            timerBlinkDiffraction.Tick += timerBlinkDiffraction_Tick;
            // 
            // dataGridViewImageColumn51
            // 
            dataGridViewImageColumn51.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn51, "dataGridViewImageColumn51");
            dataGridViewImageColumn51.Name = "dataGridViewImageColumn51";
            dataGridViewImageColumn51.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn51.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn76
            // 
            dataGridViewTextBoxColumn76.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn76.DataPropertyName = "Crystal";
            dataGridViewCellStyle53.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn76.DefaultCellStyle = dataGridViewCellStyle53;
            resources.ApplyResources(dataGridViewTextBoxColumn76, "dataGridViewTextBoxColumn76");
            dataGridViewTextBoxColumn76.Name = "dataGridViewTextBoxColumn76";
            dataGridViewTextBoxColumn76.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn52
            // 
            dataGridViewImageColumn52.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn52, "dataGridViewImageColumn52");
            dataGridViewImageColumn52.Name = "dataGridViewImageColumn52";
            dataGridViewImageColumn52.ReadOnly = true;
            dataGridViewImageColumn52.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn52.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn77
            // 
            dataGridViewTextBoxColumn77.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn77.DataPropertyName = "Crystal";
            dataGridViewCellStyle54.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn77.DefaultCellStyle = dataGridViewCellStyle54;
            resources.ApplyResources(dataGridViewTextBoxColumn77, "dataGridViewTextBoxColumn77");
            dataGridViewTextBoxColumn77.Name = "dataGridViewTextBoxColumn77";
            dataGridViewTextBoxColumn77.ReadOnly = true;
            dataGridViewTextBoxColumn77.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn50
            // 
            dataGridViewImageColumn50.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn50, "dataGridViewImageColumn50");
            dataGridViewImageColumn50.Name = "dataGridViewImageColumn50";
            dataGridViewImageColumn50.ReadOnly = true;
            dataGridViewImageColumn50.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn50.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn75
            // 
            dataGridViewTextBoxColumn75.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn75.DataPropertyName = "Profile";
            dataGridViewCellStyle55.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn75.DefaultCellStyle = dataGridViewCellStyle55;
            resources.ApplyResources(dataGridViewTextBoxColumn75, "dataGridViewTextBoxColumn75");
            dataGridViewTextBoxColumn75.Name = "dataGridViewTextBoxColumn75";
            dataGridViewTextBoxColumn75.ReadOnly = true;
            dataGridViewTextBoxColumn75.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn53
            // 
            dataGridViewImageColumn53.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn53, "dataGridViewImageColumn53");
            dataGridViewImageColumn53.Name = "dataGridViewImageColumn53";
            dataGridViewImageColumn53.ReadOnly = true;
            dataGridViewImageColumn53.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn53.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn78
            // 
            dataGridViewTextBoxColumn78.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn78.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn78, "dataGridViewTextBoxColumn78");
            dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
            dataGridViewTextBoxColumn78.ReadOnly = true;
            // 
            // dataGridViewImageColumn54
            // 
            dataGridViewImageColumn54.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn54, "dataGridViewImageColumn54");
            dataGridViewImageColumn54.Name = "dataGridViewImageColumn54";
            dataGridViewImageColumn54.ReadOnly = true;
            dataGridViewImageColumn54.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn54.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn79
            // 
            dataGridViewTextBoxColumn79.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn79.DataPropertyName = "Crystal";
            dataGridViewCellStyle56.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn79.DefaultCellStyle = dataGridViewCellStyle56;
            resources.ApplyResources(dataGridViewTextBoxColumn79, "dataGridViewTextBoxColumn79");
            dataGridViewTextBoxColumn79.Name = "dataGridViewTextBoxColumn79";
            dataGridViewTextBoxColumn79.ReadOnly = true;
            dataGridViewTextBoxColumn79.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn55
            // 
            dataGridViewImageColumn55.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn55, "dataGridViewImageColumn55");
            dataGridViewImageColumn55.Name = "dataGridViewImageColumn55";
            dataGridViewImageColumn55.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn55.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn80
            // 
            dataGridViewTextBoxColumn80.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn80.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn80, "dataGridViewTextBoxColumn80");
            dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
            // 
            // dataGridViewImageColumn56
            // 
            dataGridViewImageColumn56.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn56, "dataGridViewImageColumn56");
            dataGridViewImageColumn56.Name = "dataGridViewImageColumn56";
            dataGridViewImageColumn56.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn56.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn81
            // 
            dataGridViewTextBoxColumn81.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn81.DataPropertyName = "Crystal";
            dataGridViewCellStyle57.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn81.DefaultCellStyle = dataGridViewCellStyle57;
            resources.ApplyResources(dataGridViewTextBoxColumn81, "dataGridViewTextBoxColumn81");
            dataGridViewTextBoxColumn81.Name = "dataGridViewTextBoxColumn81";
            dataGridViewTextBoxColumn81.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn57
            // 
            dataGridViewImageColumn57.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn57, "dataGridViewImageColumn57");
            dataGridViewImageColumn57.Name = "dataGridViewImageColumn57";
            dataGridViewImageColumn57.ReadOnly = true;
            dataGridViewImageColumn57.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn57.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn82
            // 
            dataGridViewTextBoxColumn82.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn82.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn82, "dataGridViewTextBoxColumn82");
            dataGridViewTextBoxColumn82.Name = "dataGridViewTextBoxColumn82";
            dataGridViewTextBoxColumn82.ReadOnly = true;
            // 
            // dataGridViewImageColumn58
            // 
            dataGridViewImageColumn58.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn58, "dataGridViewImageColumn58");
            dataGridViewImageColumn58.Name = "dataGridViewImageColumn58";
            dataGridViewImageColumn58.ReadOnly = true;
            dataGridViewImageColumn58.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn58.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn83
            // 
            dataGridViewTextBoxColumn83.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn83.DataPropertyName = "Crystal";
            dataGridViewCellStyle58.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn83.DefaultCellStyle = dataGridViewCellStyle58;
            resources.ApplyResources(dataGridViewTextBoxColumn83, "dataGridViewTextBoxColumn83");
            dataGridViewTextBoxColumn83.Name = "dataGridViewTextBoxColumn83";
            dataGridViewTextBoxColumn83.ReadOnly = true;
            dataGridViewTextBoxColumn83.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn59
            // 
            dataGridViewImageColumn59.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn59, "dataGridViewImageColumn59");
            dataGridViewImageColumn59.Name = "dataGridViewImageColumn59";
            dataGridViewImageColumn59.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn59.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn84
            // 
            dataGridViewTextBoxColumn84.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn84.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn84, "dataGridViewTextBoxColumn84");
            dataGridViewTextBoxColumn84.Name = "dataGridViewTextBoxColumn84";
            // 
            // dataGridViewImageColumn60
            // 
            dataGridViewImageColumn60.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn60, "dataGridViewImageColumn60");
            dataGridViewImageColumn60.Name = "dataGridViewImageColumn60";
            dataGridViewImageColumn60.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn60.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn85
            // 
            dataGridViewTextBoxColumn85.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn85.DataPropertyName = "Crystal";
            dataGridViewCellStyle59.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn85.DefaultCellStyle = dataGridViewCellStyle59;
            resources.ApplyResources(dataGridViewTextBoxColumn85, "dataGridViewTextBoxColumn85");
            dataGridViewTextBoxColumn85.Name = "dataGridViewTextBoxColumn85";
            dataGridViewTextBoxColumn85.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn61
            // 
            dataGridViewImageColumn61.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn61, "dataGridViewImageColumn61");
            dataGridViewImageColumn61.Name = "dataGridViewImageColumn61";
            dataGridViewImageColumn61.ReadOnly = true;
            dataGridViewImageColumn61.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn61.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn86
            // 
            dataGridViewTextBoxColumn86.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn86.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn86, "dataGridViewTextBoxColumn86");
            dataGridViewTextBoxColumn86.Name = "dataGridViewTextBoxColumn86";
            dataGridViewTextBoxColumn86.ReadOnly = true;
            // 
            // dataGridViewImageColumn62
            // 
            dataGridViewImageColumn62.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn62, "dataGridViewImageColumn62");
            dataGridViewImageColumn62.Name = "dataGridViewImageColumn62";
            dataGridViewImageColumn62.ReadOnly = true;
            dataGridViewImageColumn62.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn62.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn87
            // 
            dataGridViewTextBoxColumn87.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn87.DataPropertyName = "Crystal";
            dataGridViewCellStyle60.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn87.DefaultCellStyle = dataGridViewCellStyle60;
            resources.ApplyResources(dataGridViewTextBoxColumn87, "dataGridViewTextBoxColumn87");
            dataGridViewTextBoxColumn87.Name = "dataGridViewTextBoxColumn87";
            dataGridViewTextBoxColumn87.ReadOnly = true;
            dataGridViewTextBoxColumn87.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn63
            // 
            dataGridViewImageColumn63.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn63, "dataGridViewImageColumn63");
            dataGridViewImageColumn63.Name = "dataGridViewImageColumn63";
            dataGridViewImageColumn63.ReadOnly = true;
            dataGridViewImageColumn63.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn63.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn88
            // 
            dataGridViewTextBoxColumn88.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn88.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn88, "dataGridViewTextBoxColumn88");
            dataGridViewTextBoxColumn88.Name = "dataGridViewTextBoxColumn88";
            dataGridViewTextBoxColumn88.ReadOnly = true;
            // 
            // dataGridViewImageColumn64
            // 
            dataGridViewImageColumn64.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn64, "dataGridViewImageColumn64");
            dataGridViewImageColumn64.Name = "dataGridViewImageColumn64";
            dataGridViewImageColumn64.ReadOnly = true;
            dataGridViewImageColumn64.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn64.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn89
            // 
            dataGridViewTextBoxColumn89.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn89.DataPropertyName = "Crystal";
            dataGridViewCellStyle61.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn89.DefaultCellStyle = dataGridViewCellStyle61;
            resources.ApplyResources(dataGridViewTextBoxColumn89, "dataGridViewTextBoxColumn89");
            dataGridViewTextBoxColumn89.Name = "dataGridViewTextBoxColumn89";
            dataGridViewTextBoxColumn89.ReadOnly = true;
            dataGridViewTextBoxColumn89.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn65
            // 
            dataGridViewImageColumn65.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn65, "dataGridViewImageColumn65");
            dataGridViewImageColumn65.Name = "dataGridViewImageColumn65";
            dataGridViewImageColumn65.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn65.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn90
            // 
            dataGridViewTextBoxColumn90.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn90.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn90, "dataGridViewTextBoxColumn90");
            dataGridViewTextBoxColumn90.Name = "dataGridViewTextBoxColumn90";
            // 
            // dataGridViewImageColumn66
            // 
            dataGridViewImageColumn66.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn66, "dataGridViewImageColumn66");
            dataGridViewImageColumn66.Name = "dataGridViewImageColumn66";
            dataGridViewImageColumn66.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn66.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn91
            // 
            dataGridViewTextBoxColumn91.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn91.DataPropertyName = "Crystal";
            dataGridViewCellStyle62.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn91.DefaultCellStyle = dataGridViewCellStyle62;
            resources.ApplyResources(dataGridViewTextBoxColumn91, "dataGridViewTextBoxColumn91");
            dataGridViewTextBoxColumn91.Name = "dataGridViewTextBoxColumn91";
            dataGridViewTextBoxColumn91.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn67
            // 
            dataGridViewImageColumn67.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn67, "dataGridViewImageColumn67");
            dataGridViewImageColumn67.Name = "dataGridViewImageColumn67";
            dataGridViewImageColumn67.ReadOnly = true;
            dataGridViewImageColumn67.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn67.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn92
            // 
            dataGridViewTextBoxColumn92.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn92.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn92, "dataGridViewTextBoxColumn92");
            dataGridViewTextBoxColumn92.Name = "dataGridViewTextBoxColumn92";
            dataGridViewTextBoxColumn92.ReadOnly = true;
            // 
            // dataGridViewImageColumn68
            // 
            dataGridViewImageColumn68.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn68, "dataGridViewImageColumn68");
            dataGridViewImageColumn68.Name = "dataGridViewImageColumn68";
            dataGridViewImageColumn68.ReadOnly = true;
            dataGridViewImageColumn68.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn68.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn93
            // 
            dataGridViewTextBoxColumn93.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn93.DataPropertyName = "Crystal";
            dataGridViewCellStyle63.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn93.DefaultCellStyle = dataGridViewCellStyle63;
            resources.ApplyResources(dataGridViewTextBoxColumn93, "dataGridViewTextBoxColumn93");
            dataGridViewTextBoxColumn93.Name = "dataGridViewTextBoxColumn93";
            dataGridViewTextBoxColumn93.ReadOnly = true;
            dataGridViewTextBoxColumn93.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn69
            // 
            dataGridViewImageColumn69.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn69, "dataGridViewImageColumn69");
            dataGridViewImageColumn69.Name = "dataGridViewImageColumn69";
            dataGridViewImageColumn69.ReadOnly = true;
            dataGridViewImageColumn69.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn69.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn94
            // 
            dataGridViewTextBoxColumn94.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn94.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn94, "dataGridViewTextBoxColumn94");
            dataGridViewTextBoxColumn94.Name = "dataGridViewTextBoxColumn94";
            dataGridViewTextBoxColumn94.ReadOnly = true;
            // 
            // dataGridViewImageColumn70
            // 
            dataGridViewImageColumn70.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn70, "dataGridViewImageColumn70");
            dataGridViewImageColumn70.Name = "dataGridViewImageColumn70";
            dataGridViewImageColumn70.ReadOnly = true;
            dataGridViewImageColumn70.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn70.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn95
            // 
            dataGridViewTextBoxColumn95.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn95.DataPropertyName = "Crystal";
            dataGridViewCellStyle64.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn95.DefaultCellStyle = dataGridViewCellStyle64;
            resources.ApplyResources(dataGridViewTextBoxColumn95, "dataGridViewTextBoxColumn95");
            dataGridViewTextBoxColumn95.Name = "dataGridViewTextBoxColumn95";
            dataGridViewTextBoxColumn95.ReadOnly = true;
            dataGridViewTextBoxColumn95.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn71
            // 
            dataGridViewImageColumn71.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn71, "dataGridViewImageColumn71");
            dataGridViewImageColumn71.Name = "dataGridViewImageColumn71";
            dataGridViewImageColumn71.ReadOnly = true;
            dataGridViewImageColumn71.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn71.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn96
            // 
            dataGridViewTextBoxColumn96.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn96.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn96, "dataGridViewTextBoxColumn96");
            dataGridViewTextBoxColumn96.Name = "dataGridViewTextBoxColumn96";
            dataGridViewTextBoxColumn96.ReadOnly = true;
            // 
            // dataGridViewImageColumn72
            // 
            dataGridViewImageColumn72.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn72, "dataGridViewImageColumn72");
            dataGridViewImageColumn72.Name = "dataGridViewImageColumn72";
            dataGridViewImageColumn72.ReadOnly = true;
            dataGridViewImageColumn72.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn72.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn97
            // 
            dataGridViewTextBoxColumn97.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn97.DataPropertyName = "Crystal";
            dataGridViewCellStyle65.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn97.DefaultCellStyle = dataGridViewCellStyle65;
            resources.ApplyResources(dataGridViewTextBoxColumn97, "dataGridViewTextBoxColumn97");
            dataGridViewTextBoxColumn97.Name = "dataGridViewTextBoxColumn97";
            dataGridViewTextBoxColumn97.ReadOnly = true;
            dataGridViewTextBoxColumn97.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn73
            // 
            dataGridViewImageColumn73.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn73, "dataGridViewImageColumn73");
            dataGridViewImageColumn73.Name = "dataGridViewImageColumn73";
            dataGridViewImageColumn73.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn73.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn98
            // 
            dataGridViewTextBoxColumn98.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn98.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn98, "dataGridViewTextBoxColumn98");
            dataGridViewTextBoxColumn98.Name = "dataGridViewTextBoxColumn98";
            // 
            // dataGridViewImageColumn74
            // 
            dataGridViewImageColumn74.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn74, "dataGridViewImageColumn74");
            dataGridViewImageColumn74.Name = "dataGridViewImageColumn74";
            dataGridViewImageColumn74.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn74.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn99
            // 
            dataGridViewTextBoxColumn99.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn99.DataPropertyName = "Crystal";
            dataGridViewCellStyle66.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn99.DefaultCellStyle = dataGridViewCellStyle66;
            resources.ApplyResources(dataGridViewTextBoxColumn99, "dataGridViewTextBoxColumn99");
            dataGridViewTextBoxColumn99.Name = "dataGridViewTextBoxColumn99";
            dataGridViewTextBoxColumn99.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn75
            // 
            dataGridViewImageColumn75.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn75, "dataGridViewImageColumn75");
            dataGridViewImageColumn75.Name = "dataGridViewImageColumn75";
            dataGridViewImageColumn75.ReadOnly = true;
            dataGridViewImageColumn75.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn75.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn100
            // 
            dataGridViewTextBoxColumn100.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn100.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn100, "dataGridViewTextBoxColumn100");
            dataGridViewTextBoxColumn100.Name = "dataGridViewTextBoxColumn100";
            dataGridViewTextBoxColumn100.ReadOnly = true;
            // 
            // dataGridViewImageColumn76
            // 
            dataGridViewImageColumn76.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn76, "dataGridViewImageColumn76");
            dataGridViewImageColumn76.Name = "dataGridViewImageColumn76";
            dataGridViewImageColumn76.ReadOnly = true;
            dataGridViewImageColumn76.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn76.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn101
            // 
            dataGridViewTextBoxColumn101.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn101.DataPropertyName = "Crystal";
            dataGridViewCellStyle67.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn101.DefaultCellStyle = dataGridViewCellStyle67;
            resources.ApplyResources(dataGridViewTextBoxColumn101, "dataGridViewTextBoxColumn101");
            dataGridViewTextBoxColumn101.Name = "dataGridViewTextBoxColumn101";
            dataGridViewTextBoxColumn101.ReadOnly = true;
            dataGridViewTextBoxColumn101.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn77
            // 
            dataGridViewImageColumn77.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn77, "dataGridViewImageColumn77");
            dataGridViewImageColumn77.Name = "dataGridViewImageColumn77";
            dataGridViewImageColumn77.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn77.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn102
            // 
            dataGridViewTextBoxColumn102.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn102.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn102, "dataGridViewTextBoxColumn102");
            dataGridViewTextBoxColumn102.Name = "dataGridViewTextBoxColumn102";
            // 
            // dataGridViewImageColumn78
            // 
            dataGridViewImageColumn78.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn78, "dataGridViewImageColumn78");
            dataGridViewImageColumn78.Name = "dataGridViewImageColumn78";
            dataGridViewImageColumn78.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn78.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn103
            // 
            dataGridViewTextBoxColumn103.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn103.DataPropertyName = "Crystal";
            dataGridViewCellStyle68.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn103.DefaultCellStyle = dataGridViewCellStyle68;
            resources.ApplyResources(dataGridViewTextBoxColumn103, "dataGridViewTextBoxColumn103");
            dataGridViewTextBoxColumn103.Name = "dataGridViewTextBoxColumn103";
            dataGridViewTextBoxColumn103.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn79
            // 
            dataGridViewImageColumn79.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn79, "dataGridViewImageColumn79");
            dataGridViewImageColumn79.Name = "dataGridViewImageColumn79";
            dataGridViewImageColumn79.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn79.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn104
            // 
            dataGridViewTextBoxColumn104.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn104.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn104, "dataGridViewTextBoxColumn104");
            dataGridViewTextBoxColumn104.Name = "dataGridViewTextBoxColumn104";
            // 
            // dataGridViewImageColumn80
            // 
            dataGridViewImageColumn80.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn80, "dataGridViewImageColumn80");
            dataGridViewImageColumn80.Name = "dataGridViewImageColumn80";
            dataGridViewImageColumn80.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn80.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn105
            // 
            dataGridViewTextBoxColumn105.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn105.DataPropertyName = "Crystal";
            dataGridViewCellStyle69.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn105.DefaultCellStyle = dataGridViewCellStyle69;
            resources.ApplyResources(dataGridViewTextBoxColumn105, "dataGridViewTextBoxColumn105");
            dataGridViewTextBoxColumn105.Name = "dataGridViewTextBoxColumn105";
            dataGridViewTextBoxColumn105.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn82
            // 
            dataGridViewImageColumn82.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn82, "dataGridViewImageColumn82");
            dataGridViewImageColumn82.Name = "dataGridViewImageColumn82";
            dataGridViewImageColumn82.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn82.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn107
            // 
            dataGridViewTextBoxColumn107.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn107.DataPropertyName = "Crystal";
            dataGridViewCellStyle70.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn107.DefaultCellStyle = dataGridViewCellStyle70;
            resources.ApplyResources(dataGridViewTextBoxColumn107, "dataGridViewTextBoxColumn107");
            dataGridViewTextBoxColumn107.Name = "dataGridViewTextBoxColumn107";
            dataGridViewTextBoxColumn107.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn81
            // 
            dataGridViewImageColumn81.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn81, "dataGridViewImageColumn81");
            dataGridViewImageColumn81.Name = "dataGridViewImageColumn81";
            dataGridViewImageColumn81.ReadOnly = true;
            dataGridViewImageColumn81.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn81.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn106
            // 
            dataGridViewTextBoxColumn106.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn106.DataPropertyName = "Profile";
            dataGridViewCellStyle71.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn106.DefaultCellStyle = dataGridViewCellStyle71;
            resources.ApplyResources(dataGridViewTextBoxColumn106, "dataGridViewTextBoxColumn106");
            dataGridViewTextBoxColumn106.Name = "dataGridViewTextBoxColumn106";
            dataGridViewTextBoxColumn106.ReadOnly = true;
            dataGridViewTextBoxColumn106.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn83
            // 
            dataGridViewImageColumn83.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn83, "dataGridViewImageColumn83");
            dataGridViewImageColumn83.Name = "dataGridViewImageColumn83";
            dataGridViewImageColumn83.ReadOnly = true;
            dataGridViewImageColumn83.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn83.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn108
            // 
            dataGridViewTextBoxColumn108.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn108.DataPropertyName = "Crystal";
            dataGridViewCellStyle72.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn108.DefaultCellStyle = dataGridViewCellStyle72;
            resources.ApplyResources(dataGridViewTextBoxColumn108, "dataGridViewTextBoxColumn108");
            dataGridViewTextBoxColumn108.Name = "dataGridViewTextBoxColumn108";
            dataGridViewTextBoxColumn108.ReadOnly = true;
            dataGridViewTextBoxColumn108.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn84
            // 
            dataGridViewImageColumn84.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn84, "dataGridViewImageColumn84");
            dataGridViewImageColumn84.Name = "dataGridViewImageColumn84";
            dataGridViewImageColumn84.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn84.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn109
            // 
            dataGridViewTextBoxColumn109.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn109.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn109, "dataGridViewTextBoxColumn109");
            dataGridViewTextBoxColumn109.Name = "dataGridViewTextBoxColumn109";
            // 
            // dataGridViewImageColumn85
            // 
            dataGridViewImageColumn85.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn85, "dataGridViewImageColumn85");
            dataGridViewImageColumn85.Name = "dataGridViewImageColumn85";
            dataGridViewImageColumn85.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn85.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn110
            // 
            dataGridViewTextBoxColumn110.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn110.DataPropertyName = "Crystal";
            dataGridViewCellStyle73.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn110.DefaultCellStyle = dataGridViewCellStyle73;
            resources.ApplyResources(dataGridViewTextBoxColumn110, "dataGridViewTextBoxColumn110");
            dataGridViewTextBoxColumn110.Name = "dataGridViewTextBoxColumn110";
            dataGridViewTextBoxColumn110.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn86
            // 
            dataGridViewImageColumn86.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn86, "dataGridViewImageColumn86");
            dataGridViewImageColumn86.Name = "dataGridViewImageColumn86";
            dataGridViewImageColumn86.ReadOnly = true;
            dataGridViewImageColumn86.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn86.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn111
            // 
            dataGridViewTextBoxColumn111.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn111.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn111, "dataGridViewTextBoxColumn111");
            dataGridViewTextBoxColumn111.Name = "dataGridViewTextBoxColumn111";
            dataGridViewTextBoxColumn111.ReadOnly = true;
            // 
            // dataGridViewImageColumn87
            // 
            dataGridViewImageColumn87.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn87, "dataGridViewImageColumn87");
            dataGridViewImageColumn87.Name = "dataGridViewImageColumn87";
            dataGridViewImageColumn87.ReadOnly = true;
            dataGridViewImageColumn87.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn87.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn112
            // 
            dataGridViewTextBoxColumn112.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn112.DataPropertyName = "Crystal";
            dataGridViewCellStyle74.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn112.DefaultCellStyle = dataGridViewCellStyle74;
            resources.ApplyResources(dataGridViewTextBoxColumn112, "dataGridViewTextBoxColumn112");
            dataGridViewTextBoxColumn112.Name = "dataGridViewTextBoxColumn112";
            dataGridViewTextBoxColumn112.ReadOnly = true;
            dataGridViewTextBoxColumn112.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewImageColumn88
            // 
            dataGridViewImageColumn88.DataPropertyName = "Color";
            resources.ApplyResources(dataGridViewImageColumn88, "dataGridViewImageColumn88");
            dataGridViewImageColumn88.Name = "dataGridViewImageColumn88";
            dataGridViewImageColumn88.Resizable = DataGridViewTriState.True;
            dataGridViewImageColumn88.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn113
            // 
            dataGridViewTextBoxColumn113.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn113.DataPropertyName = "Profile";
            resources.ApplyResources(dataGridViewTextBoxColumn113, "dataGridViewTextBoxColumn113");
            dataGridViewTextBoxColumn113.Name = "dataGridViewTextBoxColumn113";
            // 
            // dataGridViewImageColumn89
            // 
            dataGridViewImageColumn89.DataPropertyName = "PeakColor";
            resources.ApplyResources(dataGridViewImageColumn89, "dataGridViewImageColumn89");
            dataGridViewImageColumn89.Name = "dataGridViewImageColumn89";
            dataGridViewImageColumn89.Resizable = DataGridViewTriState.False;
            dataGridViewImageColumn89.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn114
            // 
            dataGridViewTextBoxColumn114.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn114.DataPropertyName = "Crystal";
            dataGridViewCellStyle75.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewTextBoxColumn114.DefaultCellStyle = dataGridViewCellStyle75;
            resources.ApplyResources(dataGridViewTextBoxColumn114, "dataGridViewTextBoxColumn114");
            dataGridViewTextBoxColumn114.Name = "dataGridViewTextBoxColumn114";
            dataGridViewTextBoxColumn114.Resizable = DataGridViewTriState.False;
            // 
            // FormMain
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(toolStripContainer1);
            KeyPreview = true;
            Name = "FormMain";
            FormClosing += FormMain_FormClosing;
            FormClosed += FormMain_FormClosed;
            Load += FormMain_Load;
            DragDrop += FormMain_DragDrop;
            DragEnter += FormMain_DragEnter;
            KeyDown += FormMain_KeyDown;
            Resize += Draw;
            toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((ISupportInitialize)numericUpDownIncreasingPixels).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((ISupportInitialize)numericUpDownMaxInt).EndInit();
            ((ISupportInitialize)numericUpDownMinInt).EndInit();
            ((ISupportInitialize)pictureBoxMain).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((ISupportInitialize)dataGridViewProfiles).EndInit();
            ((ISupportInitialize)bindingSourceProfile).EndInit();
            ((ISupportInitialize)dataSet).EndInit();
            groupBoxCrystalData.ResumeLayout(false);
            ((ISupportInitialize)dataGridViewCrystals).EndInit();
            ((ISupportInitialize)bindingSourceCrystal).EndInit();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
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