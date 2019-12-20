namespace PDIndexer
{
    partial class FormTwoThetaCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTwoThetaCalibration));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCalibrate = new System.Windows.Forms.Button();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownOrder = new System.Windows.Forms.NumericUpDown();
            this.labelEquation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 126);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTwoThetaCalibration_MouseMove);
            // 
            // buttonCalibrate
            // 
            this.buttonCalibrate.AutoSize = true;
            this.buttonCalibrate.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalibrate.Location = new System.Drawing.Point(255, 177);
            this.buttonCalibrate.Name = "buttonCalibrate";
            this.buttonCalibrate.Size = new System.Drawing.Size(185, 31);
            this.buttonCalibrate.TabIndex = 1;
            this.buttonCalibrate.Text = "Calibrate";
            this.buttonCalibrate.UseVisualStyleBackColor = true;
            this.buttonCalibrate.Click += new System.EventHandler(this.buttonCalibrate_Click);
            this.buttonCalibrate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTwoThetaCalibration_MouseMove);
            // 
            // buttonRevert
            // 
            this.buttonRevert.AutoSize = true;
            this.buttonRevert.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRevert.Location = new System.Drawing.Point(446, 177);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(89, 31);
            this.buttonRevert.TabIndex = 1;
            this.buttonRevert.Text = "Revert";
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Click += new System.EventHandler(this.buttonRevert_Click);
            this.buttonRevert.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTwoThetaCalibration_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.label2.Location = new System.Drawing.Point(25, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order";
            // 
            // numericUpDownOrder
            // 
            this.numericUpDownOrder.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.numericUpDownOrder.Location = new System.Drawing.Point(77, 139);
            this.numericUpDownOrder.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownOrder.Name = "numericUpDownOrder";
            this.numericUpDownOrder.Size = new System.Drawing.Size(50, 29);
            this.numericUpDownOrder.TabIndex = 3;
            this.numericUpDownOrder.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownOrder.ValueChanged += new System.EventHandler(this.numericUpDownOrder_ValueChanged);
            // 
            // labelEquation
            // 
            this.labelEquation.AutoSize = true;
            this.labelEquation.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.labelEquation.Location = new System.Drawing.Point(133, 143);
            this.labelEquation.Name = "labelEquation";
            this.labelEquation.Size = new System.Drawing.Size(366, 21);
            this.labelEquation.TabIndex = 4;
            this.labelEquation.Text = "Shift function: Δ(2θ) = a1 + a2 tan(θ) + a3 tan^2(θ)";
            // 
            // FormTwoThetaCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(538, 211);
            this.Controls.Add(this.labelEquation);
            this.Controls.Add(this.numericUpDownOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRevert);
            this.Controls.Add(this.buttonCalibrate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTwoThetaCalibration";
            this.Text = "2θ Calibration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTwoThetaCalibration_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FormTwoThetaCalibration_VisibleChanged);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormTwoThetaCalibration_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCalibrate;
        private System.Windows.Forms.Button buttonRevert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownOrder;
        private System.Windows.Forms.Label labelEquation;
    }
}