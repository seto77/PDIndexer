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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxLowEnergyCutoff = new System.Windows.Forms.CheckBox();
            this.numericBoxLowEnergyCutoff = new Crystallography.Controls.NumericBox();
            this.flowLayoutPanelEDX = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericalTextBox1 = new Crystallography.Controls.NumericBox();
            this.horizontalAxisUserControl = new Crystallography.Controls.HorizontalAxisUserControl();
            this.groupBoxEDX.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEDX
            // 
            resources.ApplyResources(this.groupBoxEDX, "groupBoxEDX");
            this.groupBoxEDX.Controls.Add(this.panel1);
            this.groupBoxEDX.Controls.Add(this.flowLayoutPanelEDX);
            this.groupBoxEDX.Controls.Add(this.label2);
            this.groupBoxEDX.Name = "groupBoxEDX";
            this.groupBoxEDX.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.checkBoxLowEnergyCutoff);
            this.panel1.Controls.Add(this.numericBoxLowEnergyCutoff);
            this.panel1.Name = "panel1";
            // 
            // checkBoxLowEnergyCutoff
            // 
            resources.ApplyResources(this.checkBoxLowEnergyCutoff, "checkBoxLowEnergyCutoff");
            this.checkBoxLowEnergyCutoff.Name = "checkBoxLowEnergyCutoff";
            this.checkBoxLowEnergyCutoff.UseVisualStyleBackColor = true;
            // 
            // numericBoxLowEnergyCutoff
            // 
            this.numericBoxLowEnergyCutoff.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.numericBoxLowEnergyCutoff, "numericBoxLowEnergyCutoff");
            this.numericBoxLowEnergyCutoff.Name = "numericBoxLowEnergyCutoff";
            this.numericBoxLowEnergyCutoff.RadianValue = 174.53292519943295D;
            this.numericBoxLowEnergyCutoff.ShowUpDown = true;
            this.numericBoxLowEnergyCutoff.SmartIncrement = true;
            this.numericBoxLowEnergyCutoff.Value = 10000D;
            // 
            // flowLayoutPanelEDX
            // 
            resources.ApplyResources(this.flowLayoutPanelEDX, "flowLayoutPanelEDX");
            this.flowLayoutPanelEDX.Name = "flowLayoutPanelEDX";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            resources.ApplyResources(this.numericalTextBox1, "numericalTextBox1");
            this.numericalTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBox1.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBox1.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBox1.Name = "numericalTextBox1";
            this.numericalTextBox1.RadianValue = 0.017453292519943295D;
            this.numericalTextBox1.SkipEventDuringInput = false;
            this.numericalTextBox1.SmartIncrement = true;
            this.numericalTextBox1.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBox1.ThonsandsSeparator = true;
            this.numericalTextBox1.Value = 1D;
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        public Crystallography.Controls.HorizontalAxisUserControl horizontalAxisUserControl;
        public System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Crystallography.Controls.NumericBox numericalTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Crystallography.Controls.NumericBox numericBoxLowEnergyCutoff;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEDX;
        private System.Windows.Forms.CheckBox checkBoxLowEnergyCutoff;
    }
}