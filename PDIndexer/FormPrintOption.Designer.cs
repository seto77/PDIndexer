namespace PDIndexer
{
    partial class FormPrintOption
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBoxPrintProfileName = new System.Windows.Forms.CheckBox();
            this.radioButtonUpperLeft = new System.Windows.Forms.RadioButton();
            this.radioButtonUpperRight = new System.Windows.Forms.RadioButton();
            this.radioButtonLowerLeft = new System.Windows.Forms.RadioButton();
            this.radioButtonLowerRight = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxPrintProfile = new System.Windows.Forms.CheckBox();
            this.checkBoxPrintDiffractionPeak = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(35, 145);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(128, 145);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 0;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrintProfileName
            // 
            this.checkBoxPrintProfileName.AutoSize = true;
            this.checkBoxPrintProfileName.Checked = true;
            this.checkBoxPrintProfileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrintProfileName.Location = new System.Drawing.Point(12, 37);
            this.checkBoxPrintProfileName.Name = "checkBoxPrintProfileName";
            this.checkBoxPrintProfileName.Size = new System.Drawing.Size(126, 19);
            this.checkBoxPrintProfileName.TabIndex = 1;
            this.checkBoxPrintProfileName.Text = "Print Profile Name";
            this.checkBoxPrintProfileName.UseVisualStyleBackColor = true;
            this.checkBoxPrintProfileName.CheckedChanged += new System.EventHandler(this.checkBoxPrintProfileName_CheckedChanged);
            // 
            // radioButtonUpperLeft
            // 
            this.radioButtonUpperLeft.AutoSize = true;
            this.radioButtonUpperLeft.Location = new System.Drawing.Point(3, 3);
            this.radioButtonUpperLeft.Name = "radioButtonUpperLeft";
            this.radioButtonUpperLeft.Size = new System.Drawing.Size(82, 19);
            this.radioButtonUpperLeft.TabIndex = 2;
            this.radioButtonUpperLeft.Text = "Upper Left";
            this.radioButtonUpperLeft.UseVisualStyleBackColor = true;
            // 
            // radioButtonUpperRight
            // 
            this.radioButtonUpperRight.AutoSize = true;
            this.radioButtonUpperRight.Checked = true;
            this.radioButtonUpperRight.Location = new System.Drawing.Point(91, 3);
            this.radioButtonUpperRight.Name = "radioButtonUpperRight";
            this.radioButtonUpperRight.Size = new System.Drawing.Size(91, 19);
            this.radioButtonUpperRight.TabIndex = 2;
            this.radioButtonUpperRight.TabStop = true;
            this.radioButtonUpperRight.Text = "Upper Right";
            this.radioButtonUpperRight.UseVisualStyleBackColor = true;
            this.radioButtonUpperRight.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonLowerLeft
            // 
            this.radioButtonLowerLeft.AutoSize = true;
            this.radioButtonLowerLeft.Location = new System.Drawing.Point(3, 28);
            this.radioButtonLowerLeft.Name = "radioButtonLowerLeft";
            this.radioButtonLowerLeft.Size = new System.Drawing.Size(82, 19);
            this.radioButtonLowerLeft.TabIndex = 2;
            this.radioButtonLowerLeft.Text = "Lower Left";
            this.radioButtonLowerLeft.UseVisualStyleBackColor = true;
            // 
            // radioButtonLowerRight
            // 
            this.radioButtonLowerRight.AutoSize = true;
            this.radioButtonLowerRight.Location = new System.Drawing.Point(91, 28);
            this.radioButtonLowerRight.Name = "radioButtonLowerRight";
            this.radioButtonLowerRight.Size = new System.Drawing.Size(91, 19);
            this.radioButtonLowerRight.TabIndex = 2;
            this.radioButtonLowerRight.Text = "Lower Right";
            this.radioButtonLowerRight.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButtonUpperLeft);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonUpperRight);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonLowerLeft);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonLowerRight);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(53, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(206, 52);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // checkBoxPrintProfile
            // 
            this.checkBoxPrintProfile.AutoSize = true;
            this.checkBoxPrintProfile.Checked = true;
            this.checkBoxPrintProfile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrintProfile.Location = new System.Drawing.Point(12, 12);
            this.checkBoxPrintProfile.Name = "checkBoxPrintProfile";
            this.checkBoxPrintProfile.Size = new System.Drawing.Size(89, 19);
            this.checkBoxPrintProfile.TabIndex = 1;
            this.checkBoxPrintProfile.Text = "Print Profile";
            this.checkBoxPrintProfile.UseVisualStyleBackColor = true;
            this.checkBoxPrintProfile.CheckedChanged += new System.EventHandler(this.checkBoxPrintProfileName_CheckedChanged);
            // 
            // checkBoxPrintDiffractionPeak
            // 
            this.checkBoxPrintDiffractionPeak.AutoSize = true;
            this.checkBoxPrintDiffractionPeak.Checked = true;
            this.checkBoxPrintDiffractionPeak.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrintDiffractionPeak.Location = new System.Drawing.Point(12, 112);
            this.checkBoxPrintDiffractionPeak.Name = "checkBoxPrintDiffractionPeak";
            this.checkBoxPrintDiffractionPeak.Size = new System.Drawing.Size(140, 19);
            this.checkBoxPrintDiffractionPeak.TabIndex = 1;
            this.checkBoxPrintDiffractionPeak.Text = "Print Diffraction Peak";
            this.checkBoxPrintDiffractionPeak.UseVisualStyleBackColor = true;
            this.checkBoxPrintDiffractionPeak.CheckedChanged += new System.EventHandler(this.checkBoxPrintProfileName_CheckedChanged);
            // 
            // FormPrintOption
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(261, 177);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.checkBoxPrintDiffractionPeak);
            this.Controls.Add(this.checkBoxPrintProfile);
            this.Controls.Add(this.checkBoxPrintProfileName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormPrintOption";
            this.Text = "Print Option";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.RadioButton radioButtonUpperLeft;
        public System.Windows.Forms.RadioButton radioButtonUpperRight;
        public System.Windows.Forms.RadioButton radioButtonLowerLeft;
        public System.Windows.Forms.RadioButton radioButtonLowerRight;
        public System.Windows.Forms.CheckBox checkBoxPrintProfile;
        public System.Windows.Forms.CheckBox checkBoxPrintDiffractionPeak;
        public System.Windows.Forms.CheckBox checkBoxPrintProfileName;
    }
}