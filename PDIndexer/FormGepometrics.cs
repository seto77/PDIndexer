using System;
using System.Drawing;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Crystallography;

namespace PDIndexer {
	/// <summary>
	/// FormGeometrics の概要の説明です。
	/// </summary>
	public class FormGeometrics : System.Windows.Forms.Form {
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.NumericUpDown numericUpDownH1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownK1;
		private System.Windows.Forms.NumericUpDown numericUpDownL1;
		private System.Windows.Forms.NumericUpDown numericUpDownH2;
		private System.Windows.Forms.NumericUpDown numericUpDownK2;
		private System.Windows.Forms.NumericUpDown numericUpDownL2;
		private System.Windows.Forms.NumericUpDown numericUpDownU1;
		private System.Windows.Forms.NumericUpDown numericUpDownV1;
		private System.Windows.Forms.NumericUpDown numericUpDownW2;
		private System.Windows.Forms.NumericUpDown numericUpDownW1;
		private System.Windows.Forms.NumericUpDown numericUpDownU2;
		private System.Windows.Forms.NumericUpDown numericUpDownV2;
		private System.Windows.Forms.TextBox textBoxAnglePlanes;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox textBoxLengthPlane1;
		private System.Windows.Forms.TextBox textBoxLengthPlane2;
		private System.Windows.Forms.TextBox textBoxLengthAxis1;
		private System.Windows.Forms.TextBox textBoxAngleAxes;
		private System.Windows.Forms.TextBox textBoxLengthAxis2;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox textBoxAnglePlaneAxis1;
		private System.Windows.Forms.TextBox textBoxAnglePlaneAxis2;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox textBoxZoneAxis;
		private System.Windows.Forms.TextBox textBoxZonePlane;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.CheckBox checkBoxEquivalentPlane;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RichTextBox richTextBoxSG_Num;
		private System.Windows.Forms.RichTextBox richTextBoxSG_HM;
		private System.Windows.Forms.RichTextBox richTextBoxSG_HM_full;
		private System.Windows.Forms.RichTextBox richTextBoxSG_SF;
		private System.Windows.Forms.RichTextBox richTextBoxPG_HM;
		private System.Windows.Forms.RichTextBox richTextBoxPG_SF;
		private System.Windows.Forms.RichTextBox richTextBoxLG;
		private System.Windows.Forms.RichTextBox richTextBoxCS;
		private System.Windows.Forms.RichTextBox richTextBoxSG_Hall;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.RichTextBox richTextBoxExtinctionRule;
		private System.Data.DataSet dataSet;
		private System.Data.DataTable dataTable;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Windows.Forms.DataGrid dataGrid;
		private System.Data.DataColumn dataColumn4;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Data.DataColumn dataColumn5;
		private System.Data.DataColumn dataColumn6;
		private System.Data.DataColumn dataColumn7;
		private System.Data.DataColumn dataColumn8;
		private System.Windows.Forms.CheckBox checkBoxExtinctionRule;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnH;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnK;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnL;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnD;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnEH;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnEK;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnEL;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnCondition;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Data.DataTable dataTableWyckoff;
		private System.Data.DataColumn dataColumn9;
		private System.Data.DataColumn dataColumn10;
		private System.Data.DataColumn dataColumn11;
		private System.Data.DataColumn dataColumn12;
		private System.Data.DataColumn dataColumn13;
		private System.Data.DataColumn dataColumn14;
		private System.Data.DataColumn dataColumn15;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnMultiplicity;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnWyckoffLetter;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnSiteSymmetry;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnCoordinates1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnCoordinates2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnCoordinates3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumnCoordinates4;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		public FormMain formMain;

		public FormGeometrics() {
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormGeometrics));
			this.textBoxAnglePlanes = new System.Windows.Forms.TextBox();
			this.numericUpDownH1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownK1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownL1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownH2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownK2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownL2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownU1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownV1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownW2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownW1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownU2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownV2 = new System.Windows.Forms.NumericUpDown();
			this.textBoxLengthPlane1 = new System.Windows.Forms.TextBox();
			this.textBoxLengthPlane2 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBoxLengthAxis1 = new System.Windows.Forms.TextBox();
			this.textBoxAngleAxes = new System.Windows.Forms.TextBox();
			this.textBoxLengthAxis2 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.textBoxAnglePlaneAxis1 = new System.Windows.Forms.TextBox();
			this.textBoxAnglePlaneAxis2 = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.textBoxZoneAxis = new System.Windows.Forms.TextBox();
			this.textBoxZonePlane = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.dataSet = new System.Data.DataSet();
			this.dataTable = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.dataColumn3 = new System.Data.DataColumn();
			this.dataColumn4 = new System.Data.DataColumn();
			this.dataColumn5 = new System.Data.DataColumn();
			this.dataColumn6 = new System.Data.DataColumn();
			this.dataColumn7 = new System.Data.DataColumn();
			this.dataColumn8 = new System.Data.DataColumn();
			this.dataTableWyckoff = new System.Data.DataTable();
			this.dataColumn9 = new System.Data.DataColumn();
			this.dataColumn10 = new System.Data.DataColumn();
			this.dataColumn11 = new System.Data.DataColumn();
			this.dataColumn12 = new System.Data.DataColumn();
			this.dataColumn13 = new System.Data.DataColumn();
			this.dataColumn14 = new System.Data.DataColumn();
			this.dataColumn15 = new System.Data.DataColumn();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumnH = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnK = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnL = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnD = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnEH = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnEK = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnEL = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnCondition = new System.Windows.Forms.DataGridTextBoxColumn();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.checkBoxEquivalentPlane = new System.Windows.Forms.CheckBox();
			this.label41 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.checkBoxExtinctionRule = new System.Windows.Forms.CheckBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.label52 = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.richTextBoxSG_Num = new System.Windows.Forms.RichTextBox();
			this.richTextBoxSG_HM = new System.Windows.Forms.RichTextBox();
			this.richTextBoxSG_HM_full = new System.Windows.Forms.RichTextBox();
			this.richTextBoxSG_SF = new System.Windows.Forms.RichTextBox();
			this.richTextBoxPG_HM = new System.Windows.Forms.RichTextBox();
			this.richTextBoxPG_SF = new System.Windows.Forms.RichTextBox();
			this.richTextBoxLG = new System.Windows.Forms.RichTextBox();
			this.richTextBoxCS = new System.Windows.Forms.RichTextBox();
			this.richTextBoxSG_Hall = new System.Windows.Forms.RichTextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label49 = new System.Windows.Forms.Label();
			this.richTextBoxExtinctionRule = new System.Windows.Forms.RichTextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumnMultiplicity = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnWyckoffLetter = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnSiteSymmetry = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnCoordinates1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnCoordinates2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnCoordinates3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumnCoordinates4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownH1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownK1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownL1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownH2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownK2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownL2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownU1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownV1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownW2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownW1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownU2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownV2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTableWyckoff)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxAnglePlanes
			// 
			this.textBoxAnglePlanes.AutoSize = false;
			this.textBoxAnglePlanes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxAnglePlanes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxAnglePlanes.Location = new System.Drawing.Point(220, 56);
			this.textBoxAnglePlanes.Name = "textBoxAnglePlanes";
			this.textBoxAnglePlanes.ReadOnly = true;
			this.textBoxAnglePlanes.Size = new System.Drawing.Size(64, 16);
			this.textBoxAnglePlanes.TabIndex = 4;
			this.textBoxAnglePlanes.Text = "";
			this.textBoxAnglePlanes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// numericUpDownH1
			// 
			this.numericUpDownH1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
			this.numericUpDownH1.Location = new System.Drawing.Point(72, 24);
			this.numericUpDownH1.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownH1.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownH1.Name = "numericUpDownH1";
			this.numericUpDownH1.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownH1.TabIndex = 5;
			this.numericUpDownH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownH1.ValueChanged += new System.EventHandler(this.numericUpDownH1_ValueChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(220, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 16);
			this.label1.TabIndex = 6;
			this.label1.Text = "二面間の角度";
			// 
			// numericUpDownK1
			// 
			this.numericUpDownK1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.numericUpDownK1.Location = new System.Drawing.Point(108, 24);
			this.numericUpDownK1.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownK1.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownK1.Name = "numericUpDownK1";
			this.numericUpDownK1.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownK1.TabIndex = 5;
			this.numericUpDownK1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownK1.ValueChanged += new System.EventHandler(this.numericUpDownK1_ValueChanged);
			// 
			// numericUpDownL1
			// 
			this.numericUpDownL1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.numericUpDownL1.Location = new System.Drawing.Point(144, 24);
			this.numericUpDownL1.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownL1.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownL1.Name = "numericUpDownL1";
			this.numericUpDownL1.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownL1.TabIndex = 5;
			this.numericUpDownL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownL1.ValueChanged += new System.EventHandler(this.numericUpDownL1_ValueChanged);
			// 
			// numericUpDownH2
			// 
			this.numericUpDownH2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.numericUpDownH2.Location = new System.Drawing.Point(364, 24);
			this.numericUpDownH2.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownH2.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownH2.Name = "numericUpDownH2";
			this.numericUpDownH2.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownH2.TabIndex = 5;
			this.numericUpDownH2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownH2.ValueChanged += new System.EventHandler(this.numericUpDownH2_ValueChanged);
			// 
			// numericUpDownK2
			// 
			this.numericUpDownK2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
			this.numericUpDownK2.Location = new System.Drawing.Point(400, 24);
			this.numericUpDownK2.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownK2.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownK2.Name = "numericUpDownK2";
			this.numericUpDownK2.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownK2.TabIndex = 5;
			this.numericUpDownK2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownK2.ValueChanged += new System.EventHandler(this.numericUpDownK2_ValueChanged);
			// 
			// numericUpDownL2
			// 
			this.numericUpDownL2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.numericUpDownL2.Location = new System.Drawing.Point(436, 24);
			this.numericUpDownL2.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownL2.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownL2.Name = "numericUpDownL2";
			this.numericUpDownL2.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownL2.TabIndex = 5;
			this.numericUpDownL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownL2.ValueChanged += new System.EventHandler(this.numericUpDownL2_ValueChanged);
			// 
			// numericUpDownU1
			// 
			this.numericUpDownU1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
			this.numericUpDownU1.Location = new System.Drawing.Point(76, 112);
			this.numericUpDownU1.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownU1.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownU1.Name = "numericUpDownU1";
			this.numericUpDownU1.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownU1.TabIndex = 5;
			this.numericUpDownU1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownU1.ValueChanged += new System.EventHandler(this.numericUpDownU1_ValueChanged);
			// 
			// numericUpDownV1
			// 
			this.numericUpDownV1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
			this.numericUpDownV1.Location = new System.Drawing.Point(112, 112);
			this.numericUpDownV1.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownV1.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownV1.Name = "numericUpDownV1";
			this.numericUpDownV1.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownV1.TabIndex = 5;
			this.numericUpDownV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownV1.ValueChanged += new System.EventHandler(this.numericUpDownV1_ValueChanged);
			// 
			// numericUpDownW2
			// 
			this.numericUpDownW2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
			this.numericUpDownW2.Location = new System.Drawing.Point(440, 112);
			this.numericUpDownW2.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownW2.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownW2.Name = "numericUpDownW2";
			this.numericUpDownW2.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownW2.TabIndex = 5;
			this.numericUpDownW2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownW2.ValueChanged += new System.EventHandler(this.numericUpDownW2_ValueChanged);
			// 
			// numericUpDownW1
			// 
			this.numericUpDownW1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
			this.numericUpDownW1.Location = new System.Drawing.Point(148, 112);
			this.numericUpDownW1.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownW1.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownW1.Name = "numericUpDownW1";
			this.numericUpDownW1.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownW1.TabIndex = 5;
			this.numericUpDownW1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownW1.ValueChanged += new System.EventHandler(this.numericUpDownW1_ValueChanged);
			// 
			// numericUpDownU2
			// 
			this.numericUpDownU2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
			this.numericUpDownU2.Location = new System.Drawing.Point(368, 112);
			this.numericUpDownU2.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownU2.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownU2.Name = "numericUpDownU2";
			this.numericUpDownU2.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownU2.TabIndex = 5;
			this.numericUpDownU2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownU2.ValueChanged += new System.EventHandler(this.numericUpDownU2_ValueChanged);
			// 
			// numericUpDownV2
			// 
			this.numericUpDownV2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F);
			this.numericUpDownV2.Location = new System.Drawing.Point(404, 112);
			this.numericUpDownV2.Maximum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		0});
			this.numericUpDownV2.Minimum = new System.Decimal(new int[] {
																																		20,
																																		0,
																																		0,
																																		-2147483648});
			this.numericUpDownV2.Name = "numericUpDownV2";
			this.numericUpDownV2.Size = new System.Drawing.Size(36, 22);
			this.numericUpDownV2.TabIndex = 5;
			this.numericUpDownV2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownV2.ValueChanged += new System.EventHandler(this.numericUpDownV2_ValueChanged);
			// 
			// textBoxLengthPlane1
			// 
			this.textBoxLengthPlane1.AutoSize = false;
			this.textBoxLengthPlane1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxLengthPlane1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxLengthPlane1.Location = new System.Drawing.Point(104, 8);
			this.textBoxLengthPlane1.Name = "textBoxLengthPlane1";
			this.textBoxLengthPlane1.ReadOnly = true;
			this.textBoxLengthPlane1.Size = new System.Drawing.Size(52, 16);
			this.textBoxLengthPlane1.TabIndex = 4;
			this.textBoxLengthPlane1.Text = "";
			this.textBoxLengthPlane1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxLengthPlane2
			// 
			this.textBoxLengthPlane2.AutoSize = false;
			this.textBoxLengthPlane2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxLengthPlane2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxLengthPlane2.Location = new System.Drawing.Point(392, 8);
			this.textBoxLengthPlane2.Name = "textBoxLengthPlane2";
			this.textBoxLengthPlane2.ReadOnly = true;
			this.textBoxLengthPlane2.Size = new System.Drawing.Size(52, 16);
			this.textBoxLengthPlane2.TabIndex = 4;
			this.textBoxLengthPlane2.Text = "";
			this.textBoxLengthPlane2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(344, 8);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(44, 16);
			this.label13.TabIndex = 6;
			this.label13.Text = "面間隔";
			// 
			// textBoxLengthAxis1
			// 
			this.textBoxLengthAxis1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxLengthAxis1.Font = new System.Drawing.Font("Arial", 11.25F);
			this.textBoxLengthAxis1.Location = new System.Drawing.Point(100, 136);
			this.textBoxLengthAxis1.Name = "textBoxLengthAxis1";
			this.textBoxLengthAxis1.ReadOnly = true;
			this.textBoxLengthAxis1.Size = new System.Drawing.Size(52, 18);
			this.textBoxLengthAxis1.TabIndex = 4;
			this.textBoxLengthAxis1.Text = "";
			this.textBoxLengthAxis1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxAngleAxes
			// 
			this.textBoxAngleAxes.AutoSize = false;
			this.textBoxAngleAxes.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxAngleAxes.Font = new System.Drawing.Font("Arial", 11.25F);
			this.textBoxAngleAxes.Location = new System.Drawing.Point(224, 108);
			this.textBoxAngleAxes.Name = "textBoxAngleAxes";
			this.textBoxAngleAxes.ReadOnly = true;
			this.textBoxAngleAxes.Size = new System.Drawing.Size(60, 16);
			this.textBoxAngleAxes.TabIndex = 4;
			this.textBoxAngleAxes.Text = "";
			this.textBoxAngleAxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxLengthAxis2
			// 
			this.textBoxLengthAxis2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxLengthAxis2.Font = new System.Drawing.Font("Arial", 11.25F);
			this.textBoxLengthAxis2.Location = new System.Drawing.Point(392, 136);
			this.textBoxLengthAxis2.Name = "textBoxLengthAxis2";
			this.textBoxLengthAxis2.ReadOnly = true;
			this.textBoxLengthAxis2.Size = new System.Drawing.Size(52, 18);
			this.textBoxLengthAxis2.TabIndex = 4;
			this.textBoxLengthAxis2.Text = "";
			this.textBoxLengthAxis2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(224, 92);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(76, 16);
			this.label15.TabIndex = 6;
			this.label15.Text = "二軸間の角度";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(56, 140);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(44, 16);
			this.label16.TabIndex = 6;
			this.label16.Text = "軸周期";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(348, 140);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(44, 16);
			this.label14.TabIndex = 6;
			this.label14.Text = "軸周期";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(76, 44);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(20, 16);
			this.label17.TabIndex = 6;
			this.label17.Text = "h1";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(108, 44);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(20, 16);
			this.label18.TabIndex = 6;
			this.label18.Text = "k1";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(144, 44);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(20, 16);
			this.label19.TabIndex = 6;
			this.label19.Text = "l1";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(364, 44);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(20, 16);
			this.label20.TabIndex = 6;
			this.label20.Text = "h2";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(400, 44);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(20, 16);
			this.label21.TabIndex = 6;
			this.label21.Text = "k2";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(436, 44);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(20, 16);
			this.label22.TabIndex = 6;
			this.label22.Text = "l2";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(16, 24);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(44, 16);
			this.label29.TabIndex = 6;
			this.label29.Text = "面指数";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(20, 112);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(44, 16);
			this.label30.TabIndex = 6;
			this.label30.Text = "軸指数";
			// 
			// textBoxAnglePlaneAxis1
			// 
			this.textBoxAnglePlaneAxis1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxAnglePlaneAxis1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxAnglePlaneAxis1.Location = new System.Drawing.Point(80, 64);
			this.textBoxAnglePlaneAxis1.Name = "textBoxAnglePlaneAxis1";
			this.textBoxAnglePlaneAxis1.ReadOnly = true;
			this.textBoxAnglePlaneAxis1.Size = new System.Drawing.Size(52, 18);
			this.textBoxAnglePlaneAxis1.TabIndex = 4;
			this.textBoxAnglePlaneAxis1.Text = "";
			this.textBoxAnglePlaneAxis1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxAnglePlaneAxis2
			// 
			this.textBoxAnglePlaneAxis2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxAnglePlaneAxis2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxAnglePlaneAxis2.Location = new System.Drawing.Point(392, 64);
			this.textBoxAnglePlaneAxis2.Name = "textBoxAnglePlaneAxis2";
			this.textBoxAnglePlaneAxis2.ReadOnly = true;
			this.textBoxAnglePlaneAxis2.Size = new System.Drawing.Size(52, 18);
			this.textBoxAnglePlaneAxis2.TabIndex = 4;
			this.textBoxAnglePlaneAxis2.Text = "";
			this.textBoxAnglePlaneAxis2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(320, 68);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(68, 16);
			this.label31.TabIndex = 6;
			this.label31.Text = "面軸間角度";
			// 
			// label33
			// 
			this.label33.Font = new System.Drawing.Font("MS UI Gothic", 11F);
			this.label33.Location = new System.Drawing.Point(444, 8);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(24, 16);
			this.label33.TabIndex = 6;
			this.label33.Text = "nm";
			// 
			// label36
			// 
			this.label36.Font = new System.Drawing.Font("MS UI Gothic", 11F);
			this.label36.Location = new System.Drawing.Point(284, 52);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(12, 12);
			this.label36.TabIndex = 6;
			this.label36.Text = "°";
			// 
			// label37
			// 
			this.label37.Font = new System.Drawing.Font("MS UI Gothic", 11F);
			this.label37.Location = new System.Drawing.Point(444, 68);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(12, 16);
			this.label37.TabIndex = 6;
			this.label37.Text = "°";
			// 
			// label38
			// 
			this.label38.Font = new System.Drawing.Font("MS UI Gothic", 11F);
			this.label38.Location = new System.Drawing.Point(132, 68);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(12, 16);
			this.label38.TabIndex = 6;
			this.label38.Text = "°";
			// 
			// label39
			// 
			this.label39.Font = new System.Drawing.Font("MS UI Gothic", 11F);
			this.label39.Location = new System.Drawing.Point(284, 108);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(12, 16);
			this.label39.TabIndex = 6;
			this.label39.Text = "°";
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(220, 8);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(76, 16);
			this.label40.TabIndex = 6;
			this.label40.Text = "二面の晶帯軸";
			// 
			// textBoxZoneAxis
			// 
			this.textBoxZoneAxis.AutoSize = false;
			this.textBoxZoneAxis.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxZoneAxis.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxZoneAxis.Location = new System.Drawing.Point(220, 24);
			this.textBoxZoneAxis.Name = "textBoxZoneAxis";
			this.textBoxZoneAxis.ReadOnly = true;
			this.textBoxZoneAxis.Size = new System.Drawing.Size(72, 16);
			this.textBoxZoneAxis.TabIndex = 4;
			this.textBoxZoneAxis.Text = "";
			this.textBoxZoneAxis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxZonePlane
			// 
			this.textBoxZonePlane.AutoSize = false;
			this.textBoxZonePlane.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxZonePlane.Font = new System.Drawing.Font("Arial", 11.25F);
			this.textBoxZonePlane.Location = new System.Drawing.Point(224, 140);
			this.textBoxZonePlane.Name = "textBoxZonePlane";
			this.textBoxZonePlane.ReadOnly = true;
			this.textBoxZonePlane.Size = new System.Drawing.Size(72, 16);
			this.textBoxZonePlane.TabIndex = 4;
			this.textBoxZonePlane.Text = "";
			this.textBoxZonePlane.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(220, 124);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(76, 16);
			this.label42.TabIndex = 6;
			this.label42.Text = "二軸を含む面";
			// 
			// dataGrid
			// 
			this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid.CaptionVisible = false;
			this.dataGrid.DataMember = "Table";
			this.dataGrid.DataSource = this.dataSet;
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(164, 4);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.Size = new System.Drawing.Size(368, 148);
			this.dataGrid.TabIndex = 48;
			this.dataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																																												 this.dataGridTableStyle1});
			// 
			// dataSet
			// 
			this.dataSet.DataSetName = "NewDataSet";
			this.dataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
			this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
																																 this.dataTable,
																																 this.dataTableWyckoff});
			// 
			// dataTable
			// 
			this.dataTable.Columns.AddRange(new System.Data.DataColumn[] {
																																		 this.dataColumn1,
																																		 this.dataColumn2,
																																		 this.dataColumn3,
																																		 this.dataColumn4,
																																		 this.dataColumn5,
																																		 this.dataColumn6,
																																		 this.dataColumn7,
																																		 this.dataColumn8});
			this.dataTable.TableName = "Table";
			// 
			// dataColumn1
			// 
			this.dataColumn1.Caption = "h";
			this.dataColumn1.ColumnName = "h";
			this.dataColumn1.DataType = typeof(int);
			// 
			// dataColumn2
			// 
			this.dataColumn2.Caption = "k";
			this.dataColumn2.ColumnName = "k";
			this.dataColumn2.DataType = typeof(int);
			// 
			// dataColumn3
			// 
			this.dataColumn3.Caption = "l";
			this.dataColumn3.ColumnName = "l";
			this.dataColumn3.DataType = typeof(int);
			// 
			// dataColumn4
			// 
			this.dataColumn4.Caption = "d (nm)";
			this.dataColumn4.ColumnName = "d";
			this.dataColumn4.DataType = typeof(System.Double);
			// 
			// dataColumn5
			// 
			this.dataColumn5.Caption = "h†";
			this.dataColumn5.ColumnName = "eh";
			// 
			// dataColumn6
			// 
			this.dataColumn6.Caption = "k†";
			this.dataColumn6.ColumnName = "ek";
			// 
			// dataColumn7
			// 
			this.dataColumn7.Caption = "l†";
			this.dataColumn7.ColumnName = "el";
			// 
			// dataColumn8
			// 
			this.dataColumn8.ColumnName = "Condition";
			// 
			// dataTableWyckoff
			// 
			this.dataTableWyckoff.Columns.AddRange(new System.Data.DataColumn[] {
																																						this.dataColumn9,
																																						this.dataColumn10,
																																						this.dataColumn11,
																																						this.dataColumn12,
																																						this.dataColumn13,
																																						this.dataColumn14,
																																						this.dataColumn15});
			this.dataTableWyckoff.TableName = "TableWyckoff";
			// 
			// dataColumn9
			// 
			this.dataColumn9.ColumnName = "ColumnMultiplicity";
			this.dataColumn9.ReadOnly = true;
			// 
			// dataColumn10
			// 
			this.dataColumn10.ColumnName = "ColumnWyckoffLetter";
			this.dataColumn10.ReadOnly = true;
			// 
			// dataColumn11
			// 
			this.dataColumn11.ColumnName = "ColumnSiteSymmetry";
			this.dataColumn11.ReadOnly = true;
			// 
			// dataColumn12
			// 
			this.dataColumn12.ColumnName = "ColumnCoordinates1";
			this.dataColumn12.ReadOnly = true;
			// 
			// dataColumn13
			// 
			this.dataColumn13.ColumnName = "ColumnCoordinates2";
			this.dataColumn13.ReadOnly = true;
			// 
			// dataColumn14
			// 
			this.dataColumn14.ColumnName = "ColumnCoordinates3";
			this.dataColumn14.ReadOnly = true;
			// 
			// dataColumn15
			// 
			this.dataColumn15.ColumnName = "ColumnCoordinates4";
			this.dataColumn15.ReadOnly = true;
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dataGrid;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																																																					this.dataGridTextBoxColumnH,
																																																					this.dataGridTextBoxColumnK,
																																																					this.dataGridTextBoxColumnL,
																																																					this.dataGridTextBoxColumnD,
																																																					this.dataGridTextBoxColumnEH,
																																																					this.dataGridTextBoxColumnEK,
																																																					this.dataGridTextBoxColumnEL,
																																																					this.dataGridTextBoxColumnCondition});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "Table";
			this.dataGridTableStyle1.PreferredColumnWidth = 30;
			this.dataGridTableStyle1.ReadOnly = true;
			this.dataGridTableStyle1.RowHeadersVisible = false;
			// 
			// dataGridTextBoxColumnH
			// 
			this.dataGridTextBoxColumnH.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnH.Format = "";
			this.dataGridTextBoxColumnH.FormatInfo = null;
			this.dataGridTextBoxColumnH.HeaderText = "h";
			this.dataGridTextBoxColumnH.MappingName = "h";
			this.dataGridTextBoxColumnH.ReadOnly = true;
			this.dataGridTextBoxColumnH.Width = 20;
			// 
			// dataGridTextBoxColumnK
			// 
			this.dataGridTextBoxColumnK.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnK.Format = "";
			this.dataGridTextBoxColumnK.FormatInfo = null;
			this.dataGridTextBoxColumnK.HeaderText = "k";
			this.dataGridTextBoxColumnK.MappingName = "k";
			this.dataGridTextBoxColumnK.ReadOnly = true;
			this.dataGridTextBoxColumnK.Width = 20;
			// 
			// dataGridTextBoxColumnL
			// 
			this.dataGridTextBoxColumnL.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnL.Format = "";
			this.dataGridTextBoxColumnL.FormatInfo = null;
			this.dataGridTextBoxColumnL.HeaderText = "l";
			this.dataGridTextBoxColumnL.MappingName = "l";
			this.dataGridTextBoxColumnL.ReadOnly = true;
			this.dataGridTextBoxColumnL.Width = 20;
			// 
			// dataGridTextBoxColumnD
			// 
			this.dataGridTextBoxColumnD.Format = "";
			this.dataGridTextBoxColumnD.FormatInfo = null;
			this.dataGridTextBoxColumnD.HeaderText = "d (nm)";
			this.dataGridTextBoxColumnD.MappingName = "d";
			this.dataGridTextBoxColumnD.ReadOnly = true;
			this.dataGridTextBoxColumnD.Width = 75;
			// 
			// dataGridTextBoxColumnEH
			// 
			this.dataGridTextBoxColumnEH.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnEH.Format = "";
			this.dataGridTextBoxColumnEH.FormatInfo = null;
			this.dataGridTextBoxColumnEH.HeaderText = "h†";
			this.dataGridTextBoxColumnEH.MappingName = "eh";
			this.dataGridTextBoxColumnEH.ReadOnly = true;
			this.dataGridTextBoxColumnEH.Width = 20;
			// 
			// dataGridTextBoxColumnEK
			// 
			this.dataGridTextBoxColumnEK.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnEK.Format = "";
			this.dataGridTextBoxColumnEK.FormatInfo = null;
			this.dataGridTextBoxColumnEK.HeaderText = "k†";
			this.dataGridTextBoxColumnEK.MappingName = "ek";
			this.dataGridTextBoxColumnEK.ReadOnly = true;
			this.dataGridTextBoxColumnEK.Width = 20;
			// 
			// dataGridTextBoxColumnEL
			// 
			this.dataGridTextBoxColumnEL.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnEL.Format = "";
			this.dataGridTextBoxColumnEL.FormatInfo = null;
			this.dataGridTextBoxColumnEL.HeaderText = "l†";
			this.dataGridTextBoxColumnEL.MappingName = "el";
			this.dataGridTextBoxColumnEL.ReadOnly = true;
			this.dataGridTextBoxColumnEL.Width = 20;
			// 
			// dataGridTextBoxColumnCondition
			// 
			this.dataGridTextBoxColumnCondition.Format = "";
			this.dataGridTextBoxColumnCondition.FormatInfo = null;
			this.dataGridTextBoxColumnCondition.HeaderText = "Condition";
			this.dataGridTextBoxColumnCondition.MappingName = "Condition";
			this.dataGridTextBoxColumnCondition.ReadOnly = true;
			this.dataGridTextBoxColumnCondition.Width = 175;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.numericUpDown1.Location = new System.Drawing.Point(20, 36);
			this.numericUpDown1.Maximum = new System.Decimal(new int[] {
																																	 15,
																																	 0,
																																	 0,
																																	 0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(36, 20);
			this.numericUpDown1.TabIndex = 47;
			this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.toolTip.SetToolTip(this.numericUpDown1, "計算する面指数の上限を入力してください");
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																																 2,
																																 0,
																																 0,
																																 0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.numericUpDown2.Location = new System.Drawing.Point(68, 36);
			this.numericUpDown2.Maximum = new System.Decimal(new int[] {
																																	 15,
																																	 0,
																																	 0,
																																	 0});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(36, 20);
			this.numericUpDown2.TabIndex = 46;
			this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.toolTip.SetToolTip(this.numericUpDown2, "計算する面指数の上限を入力してください");
			this.numericUpDown2.Value = new System.Decimal(new int[] {
																																 2,
																																 0,
																																 0,
																																 0});
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.numericUpDown3.Location = new System.Drawing.Point(116, 36);
			this.numericUpDown3.Maximum = new System.Decimal(new int[] {
																																	 15,
																																	 0,
																																	 0,
																																	 0});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(36, 20);
			this.numericUpDown3.TabIndex = 45;
			this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.toolTip.SetToolTip(this.numericUpDown3, "計算する面指数の上限を入力してください");
			this.numericUpDown3.Value = new System.Decimal(new int[] {
																																 2,
																																 0,
																																 0,
																																 0});
			this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
			// 
			// checkBoxEquivalentPlane
			// 
			this.checkBoxEquivalentPlane.Checked = true;
			this.checkBoxEquivalentPlane.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxEquivalentPlane.Location = new System.Drawing.Point(8, 68);
			this.checkBoxEquivalentPlane.Name = "checkBoxEquivalentPlane";
			this.checkBoxEquivalentPlane.Size = new System.Drawing.Size(136, 20);
			this.checkBoxEquivalentPlane.TabIndex = 8;
			this.checkBoxEquivalentPlane.Text = "等価な面は表示しない";
			this.toolTip.SetToolTip(this.checkBoxEquivalentPlane, "結晶学的に等価な面の重複表示をしない場合はチェックしてください");
			this.checkBoxEquivalentPlane.CheckedChanged += new System.EventHandler(this.checkBoxEquivalentPlane_CheckedChanged);
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(368, 96);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(20, 16);
			this.label41.TabIndex = 6;
			this.label41.Text = "u2";
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(80, 96);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(20, 16);
			this.label43.TabIndex = 6;
			this.label43.Text = "u1";
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(404, 96);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(20, 16);
			this.label44.TabIndex = 6;
			this.label44.Text = "v2";
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(148, 96);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(20, 16);
			this.label45.TabIndex = 6;
			this.label45.Text = "w1";
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(112, 96);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(20, 16);
			this.label46.TabIndex = 6;
			this.label46.Text = "v1";
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(440, 96);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(20, 16);
			this.label47.TabIndex = 6;
			this.label47.Text = "w2";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(64, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "面間隔";
			// 
			// checkBoxExtinctionRule
			// 
			this.checkBoxExtinctionRule.Location = new System.Drawing.Point(8, 92);
			this.checkBoxExtinctionRule.Name = "checkBoxExtinctionRule";
			this.checkBoxExtinctionRule.Size = new System.Drawing.Size(116, 32);
			this.checkBoxExtinctionRule.TabIndex = 8;
			this.checkBoxExtinctionRule.Text = "消滅側に抵触する面は表示しない";
			this.toolTip.SetToolTip(this.checkBoxExtinctionRule, "消滅則に抵触する結晶面を表示したくない場合はチェックしてください");
			this.checkBoxExtinctionRule.CheckedChanged += new System.EventHandler(this.checkBoxExtinctionRule_CheckedChanged);
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(44, 8);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(80, 16);
			this.label23.TabIndex = 6;
			this.label23.Text = "検索指数範囲";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label3.Location = new System.Drawing.Point(468, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(8, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = ")";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label7.Location = new System.Drawing.Point(176, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(8, 16);
			this.label7.TabIndex = 6;
			this.label7.Text = ")";
			// 
			// label24
			// 
			this.label24.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label24.Location = new System.Drawing.Point(352, 24);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(8, 16);
			this.label24.TabIndex = 6;
			this.label24.Text = "(";
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label25.Location = new System.Drawing.Point(60, 24);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(8, 16);
			this.label25.TabIndex = 6;
			this.label25.Text = "(";
			// 
			// label26
			// 
			this.label26.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label26.Location = new System.Drawing.Point(64, 112);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(8, 16);
			this.label26.TabIndex = 6;
			this.label26.Text = "[";
			// 
			// label27
			// 
			this.label27.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label27.Location = new System.Drawing.Point(356, 112);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(8, 16);
			this.label27.TabIndex = 6;
			this.label27.Text = "[";
			// 
			// label28
			// 
			this.label28.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label28.Location = new System.Drawing.Point(180, 112);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(8, 16);
			this.label28.TabIndex = 6;
			this.label28.Text = "]";
			// 
			// label48
			// 
			this.label48.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label48.Location = new System.Drawing.Point(472, 112);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(8, 16);
			this.label48.TabIndex = 6;
			this.label48.Text = "]";
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(8, 40);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(16, 16);
			this.label50.TabIndex = 6;
			this.label50.Text = "±";
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(56, 40);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(16, 16);
			this.label51.TabIndex = 6;
			this.label51.Text = "±";
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(104, 40);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(16, 16);
			this.label52.TabIndex = 6;
			this.label52.Text = "±";
			// 
			// label53
			// 
			this.label53.Location = new System.Drawing.Point(28, 24);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(12, 16);
			this.label53.TabIndex = 6;
			this.label53.Text = "h";
			// 
			// label54
			// 
			this.label54.Location = new System.Drawing.Point(76, 24);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(12, 16);
			this.label54.TabIndex = 6;
			this.label54.Text = "k";
			// 
			// label55
			// 
			this.label55.Location = new System.Drawing.Point(124, 24);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(12, 16);
			this.label55.TabIndex = 6;
			this.label55.Text = "l";
			// 
			// label32
			// 
			this.label32.Font = new System.Drawing.Font("MS UI Gothic", 11F);
			this.label32.Location = new System.Drawing.Point(156, 8);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(24, 16);
			this.label32.TabIndex = 6;
			this.label32.Text = "nm";
			// 
			// label34
			// 
			this.label34.Font = new System.Drawing.Font("MS UI Gothic", 11F);
			this.label34.Location = new System.Drawing.Point(152, 136);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(24, 16);
			this.label34.TabIndex = 6;
			this.label34.Text = "nm";
			// 
			// label35
			// 
			this.label35.Font = new System.Drawing.Font("MS UI Gothic", 11F);
			this.label35.Location = new System.Drawing.Point(444, 136);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(24, 16);
			this.label35.TabIndex = 6;
			this.label35.Text = "nm";
			// 
			// label
			// 
			this.label.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label.Location = new System.Drawing.Point(292, 136);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(92, 16);
			this.label.TabIndex = 1;
			this.label.Text = "Crystal System";
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label5.Location = new System.Drawing.Point(12, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "HM symbol:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label6.Location = new System.Drawing.Point(4, 44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 1;
			this.label6.Text = "Full notation:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label8.Location = new System.Drawing.Point(12, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 16);
			this.label8.TabIndex = 1;
			this.label8.Text = "SF symbol:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label9.Location = new System.Drawing.Point(8, 96);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(68, 16);
			this.label9.TabIndex = 1;
			this.label9.Text = "Hall symbol:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label10.Location = new System.Drawing.Point(4, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(70, 12);
			this.label10.TabIndex = 1;
			this.label10.Text = "HM symbol:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label11.Location = new System.Drawing.Point(4, 46);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(68, 16);
			this.label11.TabIndex = 1;
			this.label11.Text = "SF symbol:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label12.Location = new System.Drawing.Point(80, 136);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(76, 16);
			this.label12.TabIndex = 1;
			this.label12.Text = "Laue Group";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Number";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// richTextBoxSG_Num
			// 
			this.richTextBoxSG_Num.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxSG_Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxSG_Num.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.richTextBoxSG_Num.Location = new System.Drawing.Point(8, 28);
			this.richTextBoxSG_Num.Name = "richTextBoxSG_Num";
			this.richTextBoxSG_Num.ReadOnly = true;
			this.richTextBoxSG_Num.Size = new System.Drawing.Size(56, 24);
			this.richTextBoxSG_Num.TabIndex = 3;
			this.richTextBoxSG_Num.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxSG_Num, "空間群番号");
			// 
			// richTextBoxSG_HM
			// 
			this.richTextBoxSG_HM.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxSG_HM.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxSG_HM.Font = new System.Drawing.Font("Times New Roman", 15F);
			this.richTextBoxSG_HM.Location = new System.Drawing.Point(80, 16);
			this.richTextBoxSG_HM.Name = "richTextBoxSG_HM";
			this.richTextBoxSG_HM.ReadOnly = true;
			this.richTextBoxSG_HM.Size = new System.Drawing.Size(252, 24);
			this.richTextBoxSG_HM.TabIndex = 3;
			this.richTextBoxSG_HM.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxSG_HM, "ヘルマン・モーガン記号による空間群表記");
			// 
			// richTextBoxSG_HM_full
			// 
			this.richTextBoxSG_HM_full.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxSG_HM_full.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxSG_HM_full.Font = new System.Drawing.Font("Times New Roman", 15F);
			this.richTextBoxSG_HM_full.Location = new System.Drawing.Point(80, 40);
			this.richTextBoxSG_HM_full.Name = "richTextBoxSG_HM_full";
			this.richTextBoxSG_HM_full.ReadOnly = true;
			this.richTextBoxSG_HM_full.Size = new System.Drawing.Size(252, 24);
			this.richTextBoxSG_HM_full.TabIndex = 3;
			this.richTextBoxSG_HM_full.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxSG_HM_full, "ヘルマン・モーガン記号による空間群の完全表記");
			// 
			// richTextBoxSG_SF
			// 
			this.richTextBoxSG_SF.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxSG_SF.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxSG_SF.Font = new System.Drawing.Font("Times New Roman", 15F);
			this.richTextBoxSG_SF.Location = new System.Drawing.Point(80, 68);
			this.richTextBoxSG_SF.Name = "richTextBoxSG_SF";
			this.richTextBoxSG_SF.ReadOnly = true;
			this.richTextBoxSG_SF.Size = new System.Drawing.Size(252, 25);
			this.richTextBoxSG_SF.TabIndex = 3;
			this.richTextBoxSG_SF.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxSG_SF, "シェーンフリースによる空間群表記");
			// 
			// richTextBoxPG_HM
			// 
			this.richTextBoxPG_HM.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxPG_HM.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxPG_HM.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.richTextBoxPG_HM.Location = new System.Drawing.Point(76, 16);
			this.richTextBoxPG_HM.Name = "richTextBoxPG_HM";
			this.richTextBoxPG_HM.ReadOnly = true;
			this.richTextBoxPG_HM.Size = new System.Drawing.Size(112, 24);
			this.richTextBoxPG_HM.TabIndex = 3;
			this.richTextBoxPG_HM.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxPG_HM, "ヘルマン・モーガン記号による点群表記");
			// 
			// richTextBoxPG_SF
			// 
			this.richTextBoxPG_SF.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxPG_SF.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxPG_SF.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.richTextBoxPG_SF.Location = new System.Drawing.Point(76, 44);
			this.richTextBoxPG_SF.Name = "richTextBoxPG_SF";
			this.richTextBoxPG_SF.ReadOnly = true;
			this.richTextBoxPG_SF.Size = new System.Drawing.Size(112, 24);
			this.richTextBoxPG_SF.TabIndex = 3;
			this.richTextBoxPG_SF.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxPG_SF, "シェーンフリース記号による点群表記");
			// 
			// richTextBoxLG
			// 
			this.richTextBoxLG.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxLG.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxLG.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.richTextBoxLG.Location = new System.Drawing.Point(168, 132);
			this.richTextBoxLG.Name = "richTextBoxLG";
			this.richTextBoxLG.ReadOnly = true;
			this.richTextBoxLG.Size = new System.Drawing.Size(112, 24);
			this.richTextBoxLG.TabIndex = 3;
			this.richTextBoxLG.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxLG, "ラウエ群");
			// 
			// richTextBoxCS
			// 
			this.richTextBoxCS.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxCS.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxCS.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.richTextBoxCS.Location = new System.Drawing.Point(392, 132);
			this.richTextBoxCS.Name = "richTextBoxCS";
			this.richTextBoxCS.ReadOnly = true;
			this.richTextBoxCS.Size = new System.Drawing.Size(112, 24);
			this.richTextBoxCS.TabIndex = 3;
			this.richTextBoxCS.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxCS, "結晶系");
			// 
			// richTextBoxSG_Hall
			// 
			this.richTextBoxSG_Hall.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxSG_Hall.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxSG_Hall.Font = new System.Drawing.Font("Times New Roman", 15F);
			this.richTextBoxSG_Hall.Location = new System.Drawing.Point(80, 96);
			this.richTextBoxSG_Hall.Name = "richTextBoxSG_Hall";
			this.richTextBoxSG_Hall.ReadOnly = true;
			this.richTextBoxSG_Hall.Size = new System.Drawing.Size(252, 24);
			this.richTextBoxSG_Hall.TabIndex = 3;
			this.richTextBoxSG_Hall.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxSG_Hall, "ホール記号による空間群表記");
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Location = new System.Drawing.Point(64, 104);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(628, 184);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.richTextBoxLG);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.label);
			this.tabPage1.Controls.Add(this.richTextBoxCS);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.richTextBoxSG_Num);
			this.tabPage1.Location = new System.Drawing.Point(4, 21);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(644, 159);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Group Info";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.richTextBoxSG_Hall);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.richTextBoxSG_HM);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.richTextBoxSG_SF);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.richTextBoxSG_HM_full);
			this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.groupBox2.Location = new System.Drawing.Point(76, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(336, 128);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Space Group";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.richTextBoxPG_HM);
			this.groupBox1.Controls.Add(this.richTextBoxPG_SF);
			this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.groupBox1.Location = new System.Drawing.Point(416, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 76);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Point Group";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label49);
			this.tabPage2.Controls.Add(this.richTextBoxExtinctionRule);
			this.tabPage2.Location = new System.Drawing.Point(4, 21);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(644, 159);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Conditions";
			// 
			// label49
			// 
			this.label49.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label49.Location = new System.Drawing.Point(6, 6);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(202, 16);
			this.label49.TabIndex = 7;
			this.label49.Text = "Conditions limiting possible reflections";
			// 
			// richTextBoxExtinctionRule
			// 
			this.richTextBoxExtinctionRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxExtinctionRule.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBoxExtinctionRule.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxExtinctionRule.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.richTextBoxExtinctionRule.Location = new System.Drawing.Point(6, 24);
			this.richTextBoxExtinctionRule.Name = "richTextBoxExtinctionRule";
			this.richTextBoxExtinctionRule.ReadOnly = true;
			this.richTextBoxExtinctionRule.Size = new System.Drawing.Size(634, 134);
			this.richTextBoxExtinctionRule.TabIndex = 6;
			this.richTextBoxExtinctionRule.Text = "";
			this.toolTip.SetToolTip(this.richTextBoxExtinctionRule, "逆格子点の出現測と対応する並進要素");
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.dataGrid1);
			this.tabPage3.Location = new System.Drawing.Point(4, 21);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(644, 159);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Wyckoff Positions";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "TableWyckoff";
			this.dataGrid1.DataSource = this.dataSet;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsVisible = false;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeadersVisible = false;
			this.dataGrid1.Size = new System.Drawing.Size(644, 160);
			this.dataGrid1.TabIndex = 9;
			this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																																													this.dataGridTableStyle2});
			// 
			// dataGridTableStyle2
			// 
			this.dataGridTableStyle2.DataGrid = this.dataGrid1;
			this.dataGridTableStyle2.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																																																					this.dataGridTextBoxColumnMultiplicity,
																																																					this.dataGridTextBoxColumnWyckoffLetter,
																																																					this.dataGridTextBoxColumnSiteSymmetry,
																																																					this.dataGridTextBoxColumnCoordinates1,
																																																					this.dataGridTextBoxColumnCoordinates2,
																																																					this.dataGridTextBoxColumnCoordinates3,
																																																					this.dataGridTextBoxColumnCoordinates4});
			this.dataGridTableStyle2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle2.MappingName = "TableWyckoff";
			this.dataGridTableStyle2.ReadOnly = true;
			this.dataGridTableStyle2.RowHeadersVisible = false;
			// 
			// dataGridTextBoxColumnMultiplicity
			// 
			this.dataGridTextBoxColumnMultiplicity.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnMultiplicity.Format = "";
			this.dataGridTextBoxColumnMultiplicity.FormatInfo = null;
			this.dataGridTextBoxColumnMultiplicity.HeaderText = "Multiplicity";
			this.dataGridTextBoxColumnMultiplicity.MappingName = "ColumnMultiplicity";
			this.dataGridTextBoxColumnMultiplicity.ReadOnly = true;
			this.dataGridTextBoxColumnMultiplicity.Width = 60;
			// 
			// dataGridTextBoxColumnWyckoffLetter
			// 
			this.dataGridTextBoxColumnWyckoffLetter.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnWyckoffLetter.Format = "";
			this.dataGridTextBoxColumnWyckoffLetter.FormatInfo = null;
			this.dataGridTextBoxColumnWyckoffLetter.HeaderText = "Wyckoff Letter";
			this.dataGridTextBoxColumnWyckoffLetter.MappingName = "ColumnWyckoffLetter";
			this.dataGridTextBoxColumnWyckoffLetter.ReadOnly = true;
			this.dataGridTextBoxColumnWyckoffLetter.Width = 70;
			// 
			// dataGridTextBoxColumnSiteSymmetry
			// 
			this.dataGridTextBoxColumnSiteSymmetry.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnSiteSymmetry.Format = "";
			this.dataGridTextBoxColumnSiteSymmetry.FormatInfo = null;
			this.dataGridTextBoxColumnSiteSymmetry.HeaderText = "Site Symmetry";
			this.dataGridTextBoxColumnSiteSymmetry.MappingName = "ColumnSiteSymmetry";
			this.dataGridTextBoxColumnSiteSymmetry.ReadOnly = true;
			this.dataGridTextBoxColumnSiteSymmetry.Width = 70;
			// 
			// dataGridTextBoxColumnCoordinates1
			// 
			this.dataGridTextBoxColumnCoordinates1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnCoordinates1.Format = "";
			this.dataGridTextBoxColumnCoordinates1.FormatInfo = null;
			this.dataGridTextBoxColumnCoordinates1.HeaderText = "Coordinates";
			this.dataGridTextBoxColumnCoordinates1.MappingName = "ColumnCoordinates1";
			this.dataGridTextBoxColumnCoordinates1.ReadOnly = true;
			this.dataGridTextBoxColumnCoordinates1.Width = 80;
			// 
			// dataGridTextBoxColumnCoordinates2
			// 
			this.dataGridTextBoxColumnCoordinates2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnCoordinates2.Format = "";
			this.dataGridTextBoxColumnCoordinates2.FormatInfo = null;
			this.dataGridTextBoxColumnCoordinates2.MappingName = "ColumnCoordinates2";
			this.dataGridTextBoxColumnCoordinates2.ReadOnly = true;
			this.dataGridTextBoxColumnCoordinates2.Width = 80;
			// 
			// dataGridTextBoxColumnCoordinates3
			// 
			this.dataGridTextBoxColumnCoordinates3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnCoordinates3.Format = "";
			this.dataGridTextBoxColumnCoordinates3.FormatInfo = null;
			this.dataGridTextBoxColumnCoordinates3.MappingName = "ColumnCoordinates3";
			this.dataGridTextBoxColumnCoordinates3.ReadOnly = true;
			this.dataGridTextBoxColumnCoordinates3.Width = 80;
			// 
			// dataGridTextBoxColumnCoordinates4
			// 
			this.dataGridTextBoxColumnCoordinates4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.dataGridTextBoxColumnCoordinates4.Format = "";
			this.dataGridTextBoxColumnCoordinates4.FormatInfo = null;
			this.dataGridTextBoxColumnCoordinates4.MappingName = "ColumnCoordinates4";
			this.dataGridTextBoxColumnCoordinates4.ReadOnly = true;
			this.dataGridTextBoxColumnCoordinates4.Width = 80;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.label40);
			this.tabPage4.Controls.Add(this.textBoxZoneAxis);
			this.tabPage4.Controls.Add(this.label36);
			this.tabPage4.Controls.Add(this.textBoxAnglePlanes);
			this.tabPage4.Controls.Add(this.label1);
			this.tabPage4.Controls.Add(this.label13);
			this.tabPage4.Controls.Add(this.label2);
			this.tabPage4.Controls.Add(this.textBoxLengthPlane2);
			this.tabPage4.Controls.Add(this.label32);
			this.tabPage4.Controls.Add(this.textBoxLengthPlane1);
			this.tabPage4.Controls.Add(this.label33);
			this.tabPage4.Controls.Add(this.label21);
			this.tabPage4.Controls.Add(this.label20);
			this.tabPage4.Controls.Add(this.label19);
			this.tabPage4.Controls.Add(this.label18);
			this.tabPage4.Controls.Add(this.label17);
			this.tabPage4.Controls.Add(this.label3);
			this.tabPage4.Controls.Add(this.label7);
			this.tabPage4.Controls.Add(this.label37);
			this.tabPage4.Controls.Add(this.label25);
			this.tabPage4.Controls.Add(this.label38);
			this.tabPage4.Controls.Add(this.label24);
			this.tabPage4.Controls.Add(this.numericUpDownL2);
			this.tabPage4.Controls.Add(this.numericUpDownK2);
			this.tabPage4.Controls.Add(this.numericUpDownH2);
			this.tabPage4.Controls.Add(this.numericUpDownL1);
			this.tabPage4.Controls.Add(this.numericUpDownK1);
			this.tabPage4.Controls.Add(this.numericUpDownH1);
			this.tabPage4.Controls.Add(this.label31);
			this.tabPage4.Controls.Add(this.textBoxAnglePlaneAxis2);
			this.tabPage4.Controls.Add(this.textBoxAnglePlaneAxis1);
			this.tabPage4.Controls.Add(this.label29);
			this.tabPage4.Controls.Add(this.label22);
			this.tabPage4.Controls.Add(this.label45);
			this.tabPage4.Controls.Add(this.label47);
			this.tabPage4.Controls.Add(this.label46);
			this.tabPage4.Controls.Add(this.label14);
			this.tabPage4.Controls.Add(this.label16);
			this.tabPage4.Controls.Add(this.textBoxLengthAxis2);
			this.tabPage4.Controls.Add(this.label26);
			this.tabPage4.Controls.Add(this.label27);
			this.tabPage4.Controls.Add(this.label28);
			this.tabPage4.Controls.Add(this.textBoxLengthAxis1);
			this.tabPage4.Controls.Add(this.label48);
			this.tabPage4.Controls.Add(this.numericUpDownV2);
			this.tabPage4.Controls.Add(this.numericUpDownU2);
			this.tabPage4.Controls.Add(this.numericUpDownW1);
			this.tabPage4.Controls.Add(this.numericUpDownW2);
			this.tabPage4.Controls.Add(this.numericUpDownV1);
			this.tabPage4.Controls.Add(this.numericUpDownU1);
			this.tabPage4.Controls.Add(this.label35);
			this.tabPage4.Controls.Add(this.label34);
			this.tabPage4.Controls.Add(this.label41);
			this.tabPage4.Controls.Add(this.label30);
			this.tabPage4.Controls.Add(this.label44);
			this.tabPage4.Controls.Add(this.label43);
			this.tabPage4.Controls.Add(this.label15);
			this.tabPage4.Controls.Add(this.textBoxAngleAxes);
			this.tabPage4.Controls.Add(this.label39);
			this.tabPage4.Controls.Add(this.label42);
			this.tabPage4.Controls.Add(this.textBoxZonePlane);
			this.tabPage4.Location = new System.Drawing.Point(4, 21);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(620, 159);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Angle, Length, etc.";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.numericUpDown1);
			this.tabPage5.Controls.Add(this.numericUpDown2);
			this.tabPage5.Controls.Add(this.numericUpDown3);
			this.tabPage5.Controls.Add(this.checkBoxEquivalentPlane);
			this.tabPage5.Controls.Add(this.checkBoxExtinctionRule);
			this.tabPage5.Controls.Add(this.label23);
			this.tabPage5.Controls.Add(this.label50);
			this.tabPage5.Controls.Add(this.label51);
			this.tabPage5.Controls.Add(this.label52);
			this.tabPage5.Controls.Add(this.label53);
			this.tabPage5.Controls.Add(this.label54);
			this.tabPage5.Controls.Add(this.label55);
			this.tabPage5.Controls.Add(this.dataGrid);
			this.tabPage5.Location = new System.Drawing.Point(4, 21);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(620, 159);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Planes";
			// 
			// FormGeometrics
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(842, 493);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormGeometrics";
			this.Text = "Geometrics";
			this.Load += new System.EventHandler(this.FormGeometrics_Load);
			this.Closed += new System.EventHandler(this.FormGeometrics_Closed);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormGeometrics_Paint);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownH1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownK1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownL1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownH2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownK2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownL2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownU1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownV1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownW2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownW1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownU2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownV2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTableWyckoff)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormGeometrics_Load(object sender, System.EventArgs e) {
			groupBoxSymmetryInformation.Select();
			FormRenew();
		}


		private void ConvertRichTextBox1(ref RichTextBox rTB) {
			
			ConvertRichTextBoxOffsetSub(ref rTB,"sub1",12);ConvertRichTextBoxOffsetSub(ref rTB,"sub2",12);ConvertRichTextBoxOffsetSub(ref rTB,"sub3",12);
			ConvertRichTextBoxOffsetSub(ref rTB,"sub4",12);ConvertRichTextBoxOffsetSub(ref rTB,"sub5",12);
			
			ConvertRichTextBoxItalic(ref rTB,"P",14);ConvertRichTextBoxItalic(ref rTB,"A",14);ConvertRichTextBoxItalic(ref rTB,"B",14);
			ConvertRichTextBoxItalic(ref rTB,"C",14);ConvertRichTextBoxItalic(ref rTB,"F",14);ConvertRichTextBoxItalic(ref rTB,"I",14);
			ConvertRichTextBoxItalic(ref rTB,"a",14);ConvertRichTextBoxItalic(ref rTB,"b",14);ConvertRichTextBoxItalic(ref rTB,"c",14);
			ConvertRichTextBoxItalic(ref rTB,"n",14);ConvertRichTextBoxItalic(ref rTB,"d",14);ConvertRichTextBoxItalic(ref rTB,"m",14);
			ConvertRichTextBoxItalic(ref rTB,"u",14);ConvertRichTextBoxItalic(ref rTB,"v",14);ConvertRichTextBoxItalic(ref rTB,"w",14);
			ConvertRichTextBoxItalic(ref rTB,"x",14);ConvertRichTextBoxItalic(ref rTB,"y",14);ConvertRichTextBoxItalic(ref rTB,"z",14);
		}

		private void ConvertRichTextBox2(ref RichTextBox rTB) {
			
			rTB.SelectAll();
			rTB.SelectionFont = new Font("Times New Roman", 12, FontStyle.Regular);
			rTB.SelectionCharOffset = -3;
			
			ConvertRichTextBoxItalic(ref rTB,"C",12);ConvertRichTextBoxItalic(ref rTB,"D",12);ConvertRichTextBoxItalic(ref rTB,"S",12);
			ConvertRichTextBoxItalic(ref rTB,"T",12);ConvertRichTextBoxItalic(ref rTB,"O",12);

			ConvertRichTextBoxItalicSub(ref rTB,"i",12);ConvertRichTextBoxItalicSub(ref rTB,"s",12);ConvertRichTextBoxItalicSub(ref rTB,"h",12);
			ConvertRichTextBoxItalicSub(ref rTB,"v",12);ConvertRichTextBoxItalicSub(ref rTB,"d",12);
			for(int n=30 ; n >0 ; n--) {
				string s="^"+n.ToString();
				ConvertRichTextBoxOffsetSup(ref rTB, s,12);
			}
			
		}

		private void ConvertRichTextBox3(ref RichTextBox rTB) {
			
			rTB.SelectAll();
			rTB.SelectionFont = new Font("Times New Roman", 13, FontStyle.Regular);
			if(rTB.Text=="No Condition")return;
			ConvertRichTextBoxOffsetSub(ref rTB,"sub1",10);ConvertRichTextBoxOffsetSub(ref rTB,"sub2",10);ConvertRichTextBoxOffsetSub(ref rTB,"sub3",10);
			ConvertRichTextBoxOffsetSub(ref rTB,"sub4",10);ConvertRichTextBoxOffsetSub(ref rTB,"sub5",10);

			ConvertRichTextBoxItalic(ref rTB,"A",12);ConvertRichTextBoxItalic(ref rTB,"B",12);ConvertRichTextBoxItalic(ref rTB,"C",12);
			ConvertRichTextBoxItalic(ref rTB,"I",12);ConvertRichTextBoxItalic(ref rTB,"F",12);ConvertRichTextBoxItalic(ref rTB,"R",12);
			ConvertRichTextBoxItalic(ref rTB,"h",12);ConvertRichTextBoxItalic(ref rTB,"k",12);ConvertRichTextBoxItalic(ref rTB,"l",12);
			ConvertRichTextBoxItalic(ref rTB,"a",12);ConvertRichTextBoxItalic(ref rTB,"b",12);ConvertRichTextBoxItalic(ref rTB,"c",12);
			ConvertRichTextBoxItalic(ref rTB,"d",12);ConvertRichTextBoxItalic(ref rTB," n",12);
		}



		private void ConvertRichTextBoxItalic(ref RichTextBox rTB, string s, int size) {
			int n=-1;
			while(rTB.Find(s,n+1,RichTextBoxFinds.MatchCase) > n) {
				rTB.SelectionCharOffset = 0;
				rTB.SelectionFont = new Font("Times New Roman", size, FontStyle.Italic);
				n = rTB.Find(s,n+1,RichTextBoxFinds.MatchCase);
			}
		}

		private void ConvertRichTextBoxItalicSub(ref RichTextBox rTB, string s, int size) {
			int n=-1;
			while(rTB.Find(s,n+1,RichTextBoxFinds.MatchCase) > n) {
				rTB.SelectionCharOffset = -3;
				rTB.SelectionFont = new Font("Times New Roman", size, FontStyle.Italic);
				n = rTB.Find(s,n+1,RichTextBoxFinds.MatchCase);
			}
		}


		private void ConvertRichTextBoxOffsetSub(ref RichTextBox rTB, string s, int size) {
			
			if(rTB.Find(s,0,RichTextBoxFinds.MatchCase) > -1) {
				int n=-1;
				while(rTB.Find(s,n+1,RichTextBoxFinds.MatchCase) > n) {
					rTB.SelectionFont = new Font("Times New Roman", size, FontStyle.Regular);
					rTB.SelectionCharOffset = -3;
					n = rTB.Find(s,n+1,RichTextBoxFinds.MatchCase);
					rTB.Rtf=rTB.Rtf.Remove(rTB.Rtf.IndexOf(s),3);
				}
				
			}
			
		}


		private void ConvertRichTextBoxOffsetSup(ref RichTextBox rTB, string s, int size) {
			
			if(rTB.Find(s,0,RichTextBoxFinds.MatchCase) > -1) {
				int n=-1;
				while(rTB.Find(s,n+1,RichTextBoxFinds.MatchCase) > n) {
					rTB.SelectionFont = new Font("Times New Roman", size, FontStyle.Regular);
					rTB.SelectionCharOffset = +3;
					n = rTB.Find(s,n+1,RichTextBoxFinds.MatchCase);
					rTB.Rtf=rTB.Rtf.Remove(rTB.Rtf.IndexOf("^"),1);
				}
				
			}
			
		}

		private void ConvertRichTextBoxReset(ref RichTextBox rTB) {		
			rTB.SelectAll();
			rTB.SelectionFont=new Font("Times New Roman", 14, FontStyle.Regular);
		}


		public void FormRenew() {
			SetAngleAndLength();
			SetSortedPlane();
			SetWyckoffPosition();

			ConvertRichTextBoxReset(ref richTextBoxSG_HM);
			ConvertRichTextBoxReset(ref richTextBoxSG_HM_full);
			ConvertRichTextBoxReset(ref richTextBoxSG_SF);
			ConvertRichTextBoxReset(ref richTextBoxSG_Hall);
			ConvertRichTextBoxReset(ref richTextBoxPG_HM);
			ConvertRichTextBoxReset(ref richTextBoxPG_SF);
			ConvertRichTextBoxReset(ref richTextBoxLG);
			ConvertRichTextBoxReset(ref richTextBoxCS);
			ConvertRichTextBoxReset(ref richTextBoxExtinctionRule);

			richTextBoxSG_Num.Text = formMain.crystal.symmetry.numSG.ToString() + ": " + formMain.crystal.symmetry.numSGsub.ToString();
			richTextBoxSG_HM.Text=formMain.crystal.symmetry.strSG_HM;
			richTextBoxSG_HM_full.Text=formMain.crystal.symmetry.strSG_HM_full;			
			richTextBoxSG_SF.Text=formMain.crystal.symmetry.strSG_SF;			
			richTextBoxSG_Hall.Text=formMain.crystal.symmetry.strSG_Hall;			
			richTextBoxPG_HM.Text=formMain.crystal.symmetry.strPG_HM;			
			richTextBoxPG_SF.Text=formMain.crystal.symmetry.strPG_SF;			
			richTextBoxLG.Text=formMain.crystal.symmetry.strLG;		
			richTextBoxCS.Text=formMain.crystal.symmetry.strCS;
			richTextBoxExtinctionRule.Text="";
			for(int n=0 ; n < (Symmetry.ExtinctionRule(formMain.crystal.symmetry)).Length ; n++)
				richTextBoxExtinctionRule.Text +=(Symmetry.ExtinctionRule(formMain.crystal.symmetry))[n]+"\r\n";
			if(richTextBoxExtinctionRule.Text=="")
				richTextBoxExtinctionRule.Text="No Condition";
			ConvertRichTextBox3(ref richTextBoxExtinctionRule);


			if(formMain.crystal.symmetry.numSeries!=0) {
				ConvertRichTextBox1(ref richTextBoxSG_HM);
				ConvertRichTextBox1(ref richTextBoxSG_HM_full);
				ConvertRichTextBox2(ref richTextBoxSG_SF);
				ConvertRichTextBox1(ref richTextBoxSG_Hall);
				ConvertRichTextBox1(ref richTextBoxPG_HM);
				ConvertRichTextBox2(ref richTextBoxPG_SF);
				ConvertRichTextBox1(ref richTextBoxLG);
				
				richTextBoxCS.SelectAll();
				richTextBoxCS.SelectionFont = new Font("Times New Roman", 15,FontStyle.Regular);
			}
			
		}


		private void FormGeometrics_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			richTextBoxSG_Num.Text=formMain.crystal.symmetry.numSG.ToString() + ": " + formMain.crystal.symmetry.numSGsub.ToString();
		}

		private void numericUpDownH1_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownK1_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownL1_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownH2_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownK2_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownL2_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownU1_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownV1_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownW1_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownU2_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownV2_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}

		private void numericUpDownW2_ValueChanged(object sender, System.EventArgs e) {
			SetAngleAndLength();
		}


		private void SetAngleAndLength() {
			int h1 = (int)numericUpDownH1.Value;
			int k1 = (int)numericUpDownK1.Value;
			int l1 = (int)numericUpDownL1.Value;
			int h2 = (int)numericUpDownH2.Value;
			int k2 = (int)numericUpDownK2.Value;
			int l2 = (int)numericUpDownL2.Value;
			int u1 = (int)numericUpDownU1.Value;
			int v1 = (int)numericUpDownV1.Value;
			int w1 = (int)numericUpDownW1.Value;
			int u2 = (int)numericUpDownU2.Value;
			int v2 = (int)numericUpDownV2.Value;
			int w2 = (int)numericUpDownW2.Value;

			textBoxLengthPlane1.Text=formMain.crystal.GetLengthPlane(h1,k1,l1).ToString("f4");
			textBoxLengthPlane2.Text=formMain.crystal.GetLengthPlane(h2,k2,l2).ToString("f4");
			textBoxLengthAxis1.Text=formMain.crystal.GetLengthAxis(u1,v1,w1).ToString("f4");
			textBoxLengthAxis2.Text=formMain.crystal.GetLengthAxis(u2,v2,w2).ToString("f4");

			textBoxAnglePlanes.Text=(formMain.crystal.GetAnglePlanes(h1,k1,l1,h2,k2,l2)*180/Math.PI).ToString("f4");
			textBoxAngleAxes.Text=(formMain.crystal.GetAngleAxes(u1,v1,w1,u2,v2,w2)*180/Math.PI).ToString("f4");
			textBoxAnglePlaneAxis1.Text=(formMain.crystal.GetAnglePlaneAxis(h1,k1,l1,u1,v1,w1)*180/Math.PI).ToString("f4");
			textBoxAnglePlaneAxis2.Text=(formMain.crystal.GetAnglePlaneAxis(h2,k2,l2,u2,v2,w2)*180/Math.PI).ToString("f4");

			textBoxZoneAxis.Text ="["+ formMain.crystal.GetZoneAxis(h1,k1,l1,h2,k2,l2)+" ]";
			textBoxZonePlane.Text ="("+ formMain.crystal.GetZoneAxis(u1,v1,w1,u2,v2,w2)+" )";
		}

		


		private void SetTextBoxSortedPlanes() {
			this.dataGridTableStyle1.GridColumnStyles.Clear();
			if(!checkBoxEquivalentPlane.Checked && !checkBoxExtinctionRule.Checked)
				this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
						dataGridTextBoxColumnH,dataGridTextBoxColumnK,dataGridTextBoxColumnL,
						dataGridTextBoxColumnD,
						dataGridTextBoxColumnEH,dataGridTextBoxColumnEK,dataGridTextBoxColumnEL,
						this.dataGridTextBoxColumnCondition});

			else if(checkBoxEquivalentPlane.Checked && !checkBoxExtinctionRule.Checked)
				this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
						dataGridTextBoxColumnH,dataGridTextBoxColumnK,dataGridTextBoxColumnL,
						dataGridTextBoxColumnD,
						this.dataGridTextBoxColumnCondition});

			else if(!checkBoxEquivalentPlane.Checked && checkBoxExtinctionRule.Checked)
				this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
						dataGridTextBoxColumnH,dataGridTextBoxColumnK,dataGridTextBoxColumnL,
						dataGridTextBoxColumnD,
						dataGridTextBoxColumnEH,dataGridTextBoxColumnEK,dataGridTextBoxColumnEL});
			else if(checkBoxEquivalentPlane.Checked && checkBoxExtinctionRule.Checked)
				this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
						dataGridTextBoxColumnH,dataGridTextBoxColumnK,dataGridTextBoxColumnL,
						dataGridTextBoxColumnD});
			

			
			Plane[] plane=formMain.crystal.plane;
			
			dataTable.Clear();
			string str;
			for(int n= 0 ; n<plane.Length ; n++) {
				str ="";
				for(int m=0 ; m<plane[n].strCondition.Length ; m++)
					str += plane[n].strCondition[m]+"   ";

				if(checkBoxEquivalentPlane.Checked) {
					if(plane[n].h==plane[n].eH &&plane[n].k==plane[n].eK && plane[n].l==plane[n].eL) {//等価な面は書かない
						if(this.checkBoxExtinctionRule.Checked) {//消滅側に引っかかるやつは書かない
							if(str=="")
								dataTable.Rows.Add(new object[] {plane[n].h,plane[n].k,plane[n].l,plane[n].d,plane[n].eH,plane[n].eK,plane[n].eL,str});
						}
						else
							dataTable.Rows.Add(new object[] {plane[n].h,plane[n].k,plane[n].l,plane[n].d,plane[n].eH,plane[n].eK,plane[n].eL,str});
					}
				}
				else {
					if(this.checkBoxExtinctionRule.Checked) {//消滅側に引っかかるやつは書かない
						if(str=="")
							dataTable.Rows.Add(new object[] {plane[n].h,plane[n].k,plane[n].l,plane[n].d,plane[n].eH,plane[n].eK,plane[n].eL,str});
					}
					else
						dataTable.Rows.Add(new object[] {plane[n].h,plane[n].k,plane[n].l,plane[n].d,plane[n].eH,plane[n].eK,plane[n].eL,str});
					
				}
			}

		}

		private void SetWyckoffPosition() {	
			dataTableWyckoff.Clear();
			if(formMain.crystal.symmetry.strLattice=="P")
				dataTableWyckoff.Rows.Add(new object[] {"-","-","-","(0,0,0)+","","",""});
			else if(formMain.crystal.symmetry.strLattice=="A")
				dataTableWyckoff.Rows.Add(new object[] {"-","-","-","(0,0,0)+","(0,1/2,1/2)+","",""});
			else if(formMain.crystal.symmetry.strLattice=="B")
				dataTableWyckoff.Rows.Add(new object[] {"-","-","-","(0,0,0)+","(1/2,0,1/2)+","",""});
			else if(formMain.crystal.symmetry.strLattice=="C")
				dataTableWyckoff.Rows.Add(new object[] {"-","-","-","(0,0,0)+","(1/2,1/2,0)+","",""});
			else if(formMain.crystal.symmetry.strLattice=="F")
				dataTableWyckoff.Rows.Add(new object[] {"-","-","-","(0,0,0)+","(0,1/2,1/2)+","(1/2,0,1/2)+","(1/2,0,1/2)+"});
			else if(formMain.crystal.symmetry.strLattice=="I")
				dataTableWyckoff.Rows.Add(new object[] {"-","-","-","(0,0,0)+","(1/2,1/2,1/2)+","",""});
			else if(formMain.crystal.symmetry.strLattice=="H")
				dataTableWyckoff.Rows.Add(new object[] {"-","-","-","(0,0,0)+","(1/3,2/3,2/3)+","(2/3,1/3,1/3)+",""});


			for(int i=0; i<formMain.crystal.symmetry.strWyckPos.Length ; i+=7)
				dataTableWyckoff.Rows.Add(new object[] {formMain.crystal.symmetry.strWyckPos[i+0],formMain.crystal.symmetry.strWyckPos[i+1],
																								 formMain.crystal.symmetry.strWyckPos[i+2],formMain.crystal.symmetry.strWyckPos[i+3],
																								 formMain.crystal.symmetry.strWyckPos[i+4],formMain.crystal.symmetry.strWyckPos[i+5],
																								 formMain.crystal.symmetry.strWyckPos[i+6]});

		}

		private void checkBoxEquivalentPlane_CheckedChanged(object sender, System.EventArgs e) {
			SetTextBoxSortedPlanes();			
		}

		private void checkBoxExtinctionRule_CheckedChanged(object sender, System.EventArgs e) {
			SetTextBoxSortedPlanes();	
		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e) {
			SetSortedPlane();		
		}

		private void numericUpDown2_ValueChanged(object sender, System.EventArgs e) {
			SetSortedPlane();		
		}

		private void numericUpDown3_ValueChanged(object sender, System.EventArgs e) {
			SetSortedPlane();		
		}

		public void SetSortedPlane() {
			formMain.crystal.SetPlanes((int)numericUpDown1.Value,(int)numericUpDown2.Value,(int)numericUpDown3.Value);
			SetTextBoxSortedPlanes();
		}

		private void FormGeometrics_Closed(object sender, System.EventArgs e) {
			formMain.toolBarButtonGeometrics.Pushed=false;
		}

		




	}
}
