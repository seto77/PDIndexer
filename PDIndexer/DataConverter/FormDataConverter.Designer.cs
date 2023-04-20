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
            groupBoxEDX = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            checkBoxLowEnergyCutoff = new System.Windows.Forms.CheckBox();
            numericBoxLowEnergyCutoff = new Crystallography.Controls.NumericBox();
            flowLayoutPanelEDX = new System.Windows.Forms.FlowLayoutPanel();
            label2 = new System.Windows.Forms.Label();
            textBox = new System.Windows.Forms.TextBox();
            buttonOK = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            label6 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            numericalTextBox1 = new Crystallography.Controls.NumericBox();
            horizontalAxisUserControl = new Crystallography.Controls.HorizontalAxisUserControl();
            groupBoxEDX.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxEDX
            // 
            resources.ApplyResources(groupBoxEDX, "groupBoxEDX");
            groupBoxEDX.Controls.Add(panel1);
            groupBoxEDX.Controls.Add(flowLayoutPanelEDX);
            groupBoxEDX.Controls.Add(label2);
            groupBoxEDX.Name = "groupBoxEDX";
            groupBoxEDX.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(checkBoxLowEnergyCutoff);
            panel1.Controls.Add(numericBoxLowEnergyCutoff);
            panel1.Name = "panel1";
            // 
            // checkBoxLowEnergyCutoff
            // 
            resources.ApplyResources(checkBoxLowEnergyCutoff, "checkBoxLowEnergyCutoff");
            checkBoxLowEnergyCutoff.Name = "checkBoxLowEnergyCutoff";
            checkBoxLowEnergyCutoff.UseVisualStyleBackColor = true;
            // 
            // numericBoxLowEnergyCutoff
            // 
            numericBoxLowEnergyCutoff.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(numericBoxLowEnergyCutoff, "numericBoxLowEnergyCutoff");
            numericBoxLowEnergyCutoff.Name = "numericBoxLowEnergyCutoff";
            numericBoxLowEnergyCutoff.RadianValue = 174.53292519943295D;
            numericBoxLowEnergyCutoff.RoundErrorAccuracy = -1;
            numericBoxLowEnergyCutoff.ShowUpDown = true;
            numericBoxLowEnergyCutoff.SmartIncrement = true;
            numericBoxLowEnergyCutoff.Value = 10000D;
            // 
            // flowLayoutPanelEDX
            // 
            resources.ApplyResources(flowLayoutPanelEDX, "flowLayoutPanelEDX");
            flowLayoutPanelEDX.Name = "flowLayoutPanelEDX";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // textBox
            // 
            resources.ApplyResources(textBox, "textBox");
            textBox.Name = "textBox";
            textBox.ReadOnly = true;
            // 
            // buttonOK
            // 
            resources.ApplyResources(buttonOK, "buttonOK");
            buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOK.Name = "buttonOK";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            resources.ApplyResources(buttonCancel, "buttonCancel");
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Name = "buttonCancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(buttonCancel);
            flowLayoutPanel1.Controls.Add(buttonOK);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numericalTextBox1);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // numericalTextBox1
            // 
            resources.ApplyResources(numericalTextBox1, "numericalTextBox1");
            numericalTextBox1.BackColor = System.Drawing.SystemColors.Control;
            numericalTextBox1.FooterBackColor = System.Drawing.SystemColors.Control;
            numericalTextBox1.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericalTextBox1.Name = "numericalTextBox1";
            numericalTextBox1.RadianValue = 0.017453292519943295D;
            numericalTextBox1.RoundErrorAccuracy = -1;
            numericalTextBox1.SkipEventDuringInput = false;
            numericalTextBox1.SmartIncrement = true;
            numericalTextBox1.ThonsandsSeparator = true;
            numericalTextBox1.Value = 1D;
            // 
            // horizontalAxisUserControl
            // 
            resources.ApplyResources(horizontalAxisUserControl, "horizontalAxisUserControl");
            horizontalAxisUserControl.AxisMode = Crystallography.HorizontalAxis.Angle;
            horizontalAxisUserControl.ElectronAccVoltage = 8.05091703D;
            horizontalAxisUserControl.ElectronAccVoltageText = "8.05091703";
            horizontalAxisUserControl.EnergyUnit = Crystallography.EnergyUnitEnum.eV;
            horizontalAxisUserControl.Name = "horizontalAxisUserControl";
            horizontalAxisUserControl.TakeoffAngle = 0.087266462599716474D;
            horizontalAxisUserControl.TakeoffAngleText = "5";
            horizontalAxisUserControl.TofAngle = 1.5707963267948966D;
            horizontalAxisUserControl.TofAngleText = "90";
            horizontalAxisUserControl.TofLength = 42D;
            horizontalAxisUserControl.WaveColor = Crystallography.WaveColor.Monochrome;
            horizontalAxisUserControl.WaveLength = 0.154D;
            horizontalAxisUserControl.WaveLengthText = "1.54";
            horizontalAxisUserControl.WaveSource = Crystallography.WaveSource.Xray;
            horizontalAxisUserControl.XrayWaveSourceElementNumber = 0;
            horizontalAxisUserControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka1;
            horizontalAxisUserControl.AxisPropertyChanged += horizontalAxisUserControl_AxisPropertyChanged;
            // 
            // FormDataConverter
            // 
            AcceptButton = buttonOK;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            CancelButton = buttonCancel;
            ControlBox = false;
            Controls.Add(textBox);
            Controls.Add(groupBox2);
            Controls.Add(groupBoxEDX);
            Controls.Add(groupBox1);
            Controls.Add(horizontalAxisUserControl);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "FormDataConverter";
            groupBoxEDX.ResumeLayout(false);
            groupBoxEDX.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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