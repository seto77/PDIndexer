namespace PDIndexer
{
    partial class FormStressAnalysis
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
            this.textBox2theta = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxDspacing = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxFWHM = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBoxIntensity = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.numericalTextBoxAlpha = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPsimax = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxD0 = new Crystallography.Controls.NumericBox();
            this.graphControl1 = new Crystallography.Controls.GraphControl();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2theta
            // 
            this.textBox2theta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2theta.Location = new System.Drawing.Point(4, 5);
            this.textBox2theta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2theta.Multiline = true;
            this.textBox2theta.Name = "textBox2theta";
            this.textBox2theta.Size = new System.Drawing.Size(975, 330);
            this.textBox2theta.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(991, 373);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox2theta);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(983, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "2theta (deree)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxDspacing);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(983, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "d-spacing (Å)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxDspacing
            // 
            this.textBoxDspacing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDspacing.Location = new System.Drawing.Point(4, 5);
            this.textBoxDspacing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDspacing.Multiline = true;
            this.textBoxDspacing.Name = "textBoxDspacing";
            this.textBoxDspacing.Size = new System.Drawing.Size(975, 322);
            this.textBoxDspacing.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBoxFWHM);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(983, 332);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "FWHM (degree)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxFWHM
            // 
            this.textBoxFWHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFWHM.Location = new System.Drawing.Point(0, 0);
            this.textBoxFWHM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFWHM.Multiline = true;
            this.textBoxFWHM.Name = "textBoxFWHM";
            this.textBoxFWHM.Size = new System.Drawing.Size(983, 332);
            this.textBoxFWHM.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBoxIntensity);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(983, 332);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Intensity";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBoxIntensity
            // 
            this.textBoxIntensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIntensity.Location = new System.Drawing.Point(0, 0);
            this.textBoxIntensity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxIntensity.Multiline = true;
            this.textBoxIntensity.Name = "textBoxIntensity";
            this.textBoxIntensity.Size = new System.Drawing.Size(983, 332);
            this.textBoxIntensity.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.numericalTextBoxAlpha);
            this.tabPage5.Controls.Add(this.numericalTextBoxPsimax);
            this.tabPage5.Controls.Add(this.numericalTextBoxD0);
            this.tabPage5.Controls.Add(this.graphControl1);
            this.tabPage5.Controls.Add(this.textBoxResults);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(983, 332);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Analyze Singh equation";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // numericalTextBoxAlpha
            // 
            this.numericalTextBoxAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericalTextBoxAlpha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.numericalTextBoxAlpha.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxAlpha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxAlpha.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxAlpha.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxAlpha.Location = new System.Drawing.Point(937, 305);
            this.numericalTextBoxAlpha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericalTextBoxAlpha.MaximumSize = new System.Drawing.Size(1000, 24);
            this.numericalTextBoxAlpha.MinimumSize = new System.Drawing.Size(1, 22);
            this.numericalTextBoxAlpha.Name = "numericalTextBoxAlpha";
            this.numericalTextBoxAlpha.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.numericalTextBoxAlpha.Size = new System.Drawing.Size(43, 24);
            this.numericalTextBoxAlpha.SkipEventDuringInput = false;
            this.numericalTextBoxAlpha.SmartIncrement = true;
            this.numericalTextBoxAlpha.TabIndex = 5;
            this.numericalTextBoxAlpha.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxAlpha.ThonsandsSeparator = true;
            this.numericalTextBoxAlpha.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBoxD0_ValueChanged);
            // 
            // numericalTextBoxPsimax
            // 
            this.numericalTextBoxPsimax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericalTextBoxPsimax.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.numericalTextBoxPsimax.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPsimax.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxPsimax.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPsimax.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPsimax.Location = new System.Drawing.Point(891, 305);
            this.numericalTextBoxPsimax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericalTextBoxPsimax.MaximumSize = new System.Drawing.Size(1000, 24);
            this.numericalTextBoxPsimax.MinimumSize = new System.Drawing.Size(1, 22);
            this.numericalTextBoxPsimax.Name = "numericalTextBoxPsimax";
            this.numericalTextBoxPsimax.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.numericalTextBoxPsimax.Size = new System.Drawing.Size(40, 24);
            this.numericalTextBoxPsimax.SkipEventDuringInput = false;
            this.numericalTextBoxPsimax.SmartIncrement = true;
            this.numericalTextBoxPsimax.TabIndex = 5;
            this.numericalTextBoxPsimax.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxPsimax.ThonsandsSeparator = true;
            this.numericalTextBoxPsimax.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBoxD0_ValueChanged);
            // 
            // numericalTextBoxD0
            // 
            this.numericalTextBoxD0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericalTextBoxD0.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.numericalTextBoxD0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxD0.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxD0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxD0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxD0.Location = new System.Drawing.Point(818, 305);
            this.numericalTextBoxD0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericalTextBoxD0.MaximumSize = new System.Drawing.Size(1000, 24);
            this.numericalTextBoxD0.MinimumSize = new System.Drawing.Size(1, 22);
            this.numericalTextBoxD0.Name = "numericalTextBoxD0";
            this.numericalTextBoxD0.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.numericalTextBoxD0.Size = new System.Drawing.Size(67, 24);
            this.numericalTextBoxD0.SkipEventDuringInput = false;
            this.numericalTextBoxD0.SmartIncrement = true;
            this.numericalTextBoxD0.TabIndex = 5;
            this.numericalTextBoxD0.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericalTextBoxD0.ThonsandsSeparator = true;
            this.numericalTextBoxD0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBoxD0_ValueChanged);
            this.numericalTextBoxD0.Load += new System.EventHandler(this.numericalTextBoxD0_Load);
            // 
            // graphControl1
            // 
            this.graphControl1.AllowMouseOperation = true;
            this.graphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphControl1.BackgroundColor = System.Drawing.Color.White;
            this.graphControl1.BottomMargin = 0D;
            this.graphControl1.DivisionLineColor = System.Drawing.Color.Gray;
            this.graphControl1.DivisionSubLineColor = System.Drawing.Color.LightGray;
            this.graphControl1.FixRangeHorizontal = false;
            this.graphControl1.FixRangeVertical = false;
            this.graphControl1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphControl1.GraphName = "";
            this.graphControl1.HorizontalGradiationTextVisivle = true;
            this.graphControl1.Interpolation = false;
            this.graphControl1.IsIntegerX = false;
            this.graphControl1.IsIntegerY = false;
            this.graphControl1.LabelX = "X:";
            this.graphControl1.LabelY = "Y:";
            this.graphControl1.LeftMargin = 0F;
            this.graphControl1.LineColor = System.Drawing.Color.Red;
            this.graphControl1.LineWidth = 1F;
            this.graphControl1.Location = new System.Drawing.Point(626, 8);
            this.graphControl1.LowerX = 0D;
            this.graphControl1.LowerY = 0D;
            this.graphControl1.MaximalX = 1D;
            this.graphControl1.MaximalY = 1D;
            this.graphControl1.MinimalX = 0D;
            this.graphControl1.MinimalY = 0D;
            this.graphControl1.Mode = Crystallography.Controls.GraphControl.DrawingMode.Line;
            this.graphControl1.MousePositionVisible = true;
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.OriginPosition = new System.Drawing.Point(40, 20);
            this.graphControl1.Size = new System.Drawing.Size(349, 283);
            this.graphControl1.Smoothing = false;
            this.graphControl1.TabIndex = 4;
            this.graphControl1.TextFont = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.graphControl1.UnitX = "";
            this.graphControl1.UnitY = "";
            this.graphControl1.UpperText = "";
            this.graphControl1.UpperTextVisible = true;
            this.graphControl1.UpperX = 1D;
            this.graphControl1.UpperY = 1D;
            this.graphControl1.UseLineWidth = true;
            this.graphControl1.VerticalGradiationTextVisivle = true;
            this.graphControl1.XLog = false;
            this.graphControl1.XScaleLineVisible = true;
            this.graphControl1.YLog = false;
            this.graphControl1.YScaleLineVisible = true;
            // 
            // textBoxResults
            // 
            this.textBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResults.Location = new System.Drawing.Point(8, 8);
            this.textBoxResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxResults.Multiline = true;
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(611, 319);
            this.textBoxResults.TabIndex = 3;
            // 
            // FormStressAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(991, 401);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormStressAnalysis";
            this.Text = "FormStressAnalysis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStressAnalysis_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2theta;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBoxDspacing;
        private System.Windows.Forms.TextBox textBoxFWHM;
        private System.Windows.Forms.TextBox textBoxIntensity;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox textBoxResults;
        private Crystallography.Controls.GraphControl graphControl1;
        private Crystallography.Controls.NumericBox numericalTextBoxAlpha;
        private Crystallography.Controls.NumericBox numericalTextBoxPsimax;
        private Crystallography.Controls.NumericBox numericalTextBoxD0;
    }
}