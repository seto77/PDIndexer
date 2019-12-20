namespace PDIndexer
{
    partial class FormDataConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataConverter));
            this.groupBoxEDX = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownLowEnergyCutoff = new System.Windows.Forms.NumericUpDown();
            this.numericBoxEGC2 = new Crystallography.Controls.NumericBox();
            this.numericBoxEGC1 = new Crystallography.Controls.NumericBox();
            this.numericBoxEGC0 = new Crystallography.Controls.NumericBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxRemoveKalpha2 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericalTextBox1 = new Crystallography.Controls.NumericBox();
            this.horizontalAxisUserControl = new Crystallography.Controls.HorizontalAxisUserControl();
            this.groupBoxEDX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowEnergyCutoff)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEDX
            // 
            this.groupBoxEDX.Controls.Add(this.label2);
            this.groupBoxEDX.Controls.Add(this.numericUpDownLowEnergyCutoff);
            this.groupBoxEDX.Controls.Add(this.numericBoxEGC2);
            this.groupBoxEDX.Controls.Add(this.numericBoxEGC1);
            this.groupBoxEDX.Controls.Add(this.numericBoxEGC0);
            this.groupBoxEDX.Controls.Add(this.label4);
            this.groupBoxEDX.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBoxEDX, "groupBoxEDX");
            this.groupBoxEDX.Name = "groupBoxEDX";
            this.groupBoxEDX.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // numericUpDownLowEnergyCutoff
            // 
            this.numericUpDownLowEnergyCutoff.DecimalPlaces = 1;
            resources.ApplyResources(this.numericUpDownLowEnergyCutoff, "numericUpDownLowEnergyCutoff");
            this.numericUpDownLowEnergyCutoff.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownLowEnergyCutoff.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownLowEnergyCutoff.Name = "numericUpDownLowEnergyCutoff";
            this.numericUpDownLowEnergyCutoff.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // numericBoxEGC2
            // 
            this.numericBoxEGC2.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxEGC2, "numericBoxEGC2");
            this.numericBoxEGC2.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxEGC2.DecimalPlaces = -1;
            this.numericBoxEGC2.Maximum = double.PositiveInfinity;
            this.numericBoxEGC2.Minimum = double.NegativeInfinity;
            this.numericBoxEGC2.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericBoxEGC2.MouseSpeed = 1D;
            this.numericBoxEGC2.Multiline = false;
            this.numericBoxEGC2.Name = "numericBoxEGC2";
            this.numericBoxEGC2.RadianValue = 0.00058855993035752778D;
            this.numericBoxEGC2.ReadOnly = false;
            this.numericBoxEGC2.RestrictLimitValue = true;
            this.numericBoxEGC2.ShowFraction = false;
            this.numericBoxEGC2.ShowPositiveSign = false;
            this.numericBoxEGC2.ShowUpDown = false;
            this.numericBoxEGC2.SkipEventDuringInput = false;
            this.numericBoxEGC2.SmartIncrement = true;
            this.numericBoxEGC2.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxEGC2.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxEGC2.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxEGC2.ThonsandsSeparator = true;
            this.numericBoxEGC2.UpDown_Increment = 1D;
            this.numericBoxEGC2.Value = 0.033722D;
            this.numericBoxEGC2.WordWrap = true;
            // 
            // numericBoxEGC1
            // 
            this.numericBoxEGC1.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxEGC1, "numericBoxEGC1");
            this.numericBoxEGC1.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxEGC1.DecimalPlaces = -1;
            this.numericBoxEGC1.Maximum = double.PositiveInfinity;
            this.numericBoxEGC1.Minimum = double.NegativeInfinity;
            this.numericBoxEGC1.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericBoxEGC1.MouseSpeed = 1D;
            this.numericBoxEGC1.Multiline = false;
            this.numericBoxEGC1.Name = "numericBoxEGC1";
            this.numericBoxEGC1.RadianValue = 0.00058855993035752778D;
            this.numericBoxEGC1.ReadOnly = false;
            this.numericBoxEGC1.RestrictLimitValue = true;
            this.numericBoxEGC1.ShowFraction = false;
            this.numericBoxEGC1.ShowPositiveSign = false;
            this.numericBoxEGC1.ShowUpDown = false;
            this.numericBoxEGC1.SkipEventDuringInput = false;
            this.numericBoxEGC1.SmartIncrement = true;
            this.numericBoxEGC1.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxEGC1.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxEGC1.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxEGC1.ThonsandsSeparator = true;
            this.numericBoxEGC1.UpDown_Increment = 1D;
            this.numericBoxEGC1.Value = 0.033722D;
            this.numericBoxEGC1.WordWrap = true;
            // 
            // numericBoxEGC0
            // 
            this.numericBoxEGC0.AllowMouseControl = false;
            resources.ApplyResources(this.numericBoxEGC0, "numericBoxEGC0");
            this.numericBoxEGC0.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxEGC0.DecimalPlaces = -1;
            this.numericBoxEGC0.Maximum = double.PositiveInfinity;
            this.numericBoxEGC0.Minimum = double.NegativeInfinity;
            this.numericBoxEGC0.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericBoxEGC0.MouseSpeed = 1D;
            this.numericBoxEGC0.Multiline = false;
            this.numericBoxEGC0.Name = "numericBoxEGC0";
            this.numericBoxEGC0.RadianValue = -0.02005191324323765D;
            this.numericBoxEGC0.ReadOnly = false;
            this.numericBoxEGC0.RestrictLimitValue = true;
            this.numericBoxEGC0.ShowFraction = false;
            this.numericBoxEGC0.ShowPositiveSign = false;
            this.numericBoxEGC0.ShowUpDown = false;
            this.numericBoxEGC0.SkipEventDuringInput = false;
            this.numericBoxEGC0.SmartIncrement = true;
            this.numericBoxEGC0.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxEGC0.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxEGC0.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxEGC0.ThonsandsSeparator = true;
            this.numericBoxEGC0.UpDown_Increment = 1D;
            this.numericBoxEGC0.Value = -1.14889D;
            this.numericBoxEGC0.WordWrap = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textBox
            // 
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonOK);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBoxRemoveKalpha2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // checkBoxRemoveKalpha2
            // 
            resources.ApplyResources(this.checkBoxRemoveKalpha2, "checkBoxRemoveKalpha2");
            this.checkBoxRemoveKalpha2.Name = "checkBoxRemoveKalpha2";
            this.checkBoxRemoveKalpha2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericalTextBox1);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // numericalTextBox1
            // 
            this.numericalTextBox1.AllowMouseControl = false;
            resources.ApplyResources(this.numericalTextBox1, "numericalTextBox1");
            this.numericalTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBox1.DecimalPlaces = -1;
            this.numericalTextBox1.Maximum = double.PositiveInfinity;
            this.numericalTextBox1.Minimum = double.NegativeInfinity;
            this.numericalTextBox1.MouseDirection = Crystallography.VH_DirectionEnum.Vertical;
            this.numericalTextBox1.MouseSpeed = 1D;
            this.numericalTextBox1.Multiline = false;
            this.numericalTextBox1.Name = "numericalTextBox1";
            this.numericalTextBox1.RadianValue = 0.017453292519943295D;
            this.numericalTextBox1.ReadOnly = false;
            this.numericalTextBox1.RestrictLimitValue = true;
            this.numericalTextBox1.ShowFraction = false;
            this.numericalTextBox1.ShowPositiveSign = false;
            this.numericalTextBox1.ShowUpDown = false;
            this.numericalTextBox1.SkipEventDuringInput = false;
            this.numericalTextBox1.SmartIncrement = true;
            this.numericalTextBox1.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBox1.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBox1.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBox1.ThonsandsSeparator = true;
            this.numericalTextBox1.UpDown_Increment = 1D;
            this.numericalTextBox1.Value = 1D;
            this.numericalTextBox1.WordWrap = true;
            // 
            // horizontalAxisUserControl
            // 
            resources.ApplyResources(this.horizontalAxisUserControl, "horizontalAxisUserControl");
            this.horizontalAxisUserControl.AxisMode = Crystallography.HorizontalAxis.Angle;
            this.horizontalAxisUserControl.ElectronAccVoltage = 8.05091703289645D;
            this.horizontalAxisUserControl.ElectronAccVoltageText = "8.05091703289645";
            this.horizontalAxisUserControl.EnergyUnit = Crystallography.EnergyUnitEnum.eV;
            this.horizontalAxisUserControl.Name = "horizontalAxisUserControl";
            this.horizontalAxisUserControl.TakeoffAngle = 0.087266462599716474D;
            this.horizontalAxisUserControl.TakeoffAngleText = "5";
            this.horizontalAxisUserControl.TofAngle = 1.5707963267948966D;
            this.horizontalAxisUserControl.TofAngleText = "90";
            this.horizontalAxisUserControl.TofLength = 42D;
            this.horizontalAxisUserControl.WaveColor = Crystallography.WaveColor.Monochrome;
            this.horizontalAxisUserControl.WaveLength = 0.154D;
            this.horizontalAxisUserControl.WaveLengthText = "1.54";
            this.horizontalAxisUserControl.WaveSource = Crystallography.WaveSource.Xray;
            this.horizontalAxisUserControl.XrayWaveSourceElementNumber = 0;
            this.horizontalAxisUserControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka1;
            this.horizontalAxisUserControl.AxisPropertyChanged += new Crystallography.Controls.HorizontalAxisUserControl.MyEventHandler(this.horizontalAxisUserControl_AxisPropertyChanged);
            // 
            // FormDataConverter
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.buttonCancel;
            this.ControlBox = false;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxEDX);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.horizontalAxisUserControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDataConverter";
            this.ShowInTaskbar = false;
            this.groupBoxEDX.ResumeLayout(false);
            this.groupBoxEDX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLowEnergyCutoff)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxEDX;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private Crystallography.Controls.NumericBox numericBoxEGC1;
        private Crystallography.Controls.NumericBox numericBoxEGC0;
        public Crystallography.Controls.HorizontalAxisUserControl horizontalAxisUserControl;
        public System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.NumericUpDown numericUpDownLowEnergyCutoff;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Crystallography.Controls.NumericBox numericalTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxRemoveKalpha2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Crystallography.Controls.NumericBox numericBoxEGC2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}