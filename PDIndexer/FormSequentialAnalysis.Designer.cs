namespace PDIndexer
{
    partial class FormSequentialAnalysis
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
            this.buttonExecute = new System.Windows.Forms.Button();
            this.textBox2theta = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2theta = new System.Windows.Forms.TabPage();
            this.tabPageDspacing = new System.Windows.Forms.TabPage();
            this.textBoxDspacing = new System.Windows.Forms.TextBox();
            this.tabPageFWHM = new System.Windows.Forms.TabPage();
            this.textBoxFWHM = new System.Windows.Forms.TextBox();
            this.tabPageIntensity = new System.Windows.Forms.TabPage();
            this.textBoxIntensity = new System.Windows.Forms.TextBox();
            this.tabPageCellConstants = new System.Windows.Forms.TabPage();
            this.textBoxCellConstants = new System.Windows.Forms.TextBox();
            this.tabPagePressure = new System.Windows.Forms.TabPage();
            this.textBoxPressure = new System.Windows.Forms.TextBox();
            this.tabPageSingh = new System.Windows.Forms.TabPage();
            this.numericalTextBoxAlpha = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPsimax = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxD0 = new Crystallography.Controls.NumericBox();
            this.graphControl1 = new Crystallography.Controls.GraphControl();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage2theta.SuspendLayout();
            this.tabPageDspacing.SuspendLayout();
            this.tabPageFWHM.SuspendLayout();
            this.tabPageIntensity.SuspendLayout();
            this.tabPageCellConstants.SuspendLayout();
            this.tabPagePressure.SuspendLayout();
            this.tabPageSingh.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExecute
            // 
            this.buttonExecute.AutoSize = true;
            this.buttonExecute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonExecute.Location = new System.Drawing.Point(2, 2);
            this.buttonExecute.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(62, 27);
            this.buttonExecute.TabIndex = 0;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // textBox2theta
            // 
            this.textBox2theta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2theta.Location = new System.Drawing.Point(0, 0);
            this.textBox2theta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2theta.Multiline = true;
            this.textBox2theta.Name = "textBox2theta";
            this.textBox2theta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2theta.Size = new System.Drawing.Size(734, 273);
            this.textBox2theta.TabIndex = 1;
            this.textBox2theta.WordWrap = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage2theta);
            this.tabControl.Controls.Add(this.tabPageDspacing);
            this.tabControl.Controls.Add(this.tabPageFWHM);
            this.tabControl.Controls.Add(this.tabPageIntensity);
            this.tabControl.Controls.Add(this.tabPageCellConstants);
            this.tabControl.Controls.Add(this.tabPagePressure);
            this.tabControl.Controls.Add(this.tabPageSingh);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 33);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(742, 303);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage2theta
            // 
            this.tabPage2theta.Controls.Add(this.textBox2theta);
            this.tabPage2theta.Location = new System.Drawing.Point(4, 26);
            this.tabPage2theta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2theta.Name = "tabPage2theta";
            this.tabPage2theta.Size = new System.Drawing.Size(734, 273);
            this.tabPage2theta.TabIndex = 0;
            this.tabPage2theta.Text = "2theta (deg.)";
            this.tabPage2theta.UseVisualStyleBackColor = true;
            // 
            // tabPageDspacing
            // 
            this.tabPageDspacing.Controls.Add(this.textBoxDspacing);
            this.tabPageDspacing.Location = new System.Drawing.Point(4, 26);
            this.tabPageDspacing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageDspacing.Name = "tabPageDspacing";
            this.tabPageDspacing.Size = new System.Drawing.Size(720, 270);
            this.tabPageDspacing.TabIndex = 1;
            this.tabPageDspacing.Text = "d-spacing (Å)";
            this.tabPageDspacing.UseVisualStyleBackColor = true;
            // 
            // textBoxDspacing
            // 
            this.textBoxDspacing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDspacing.Location = new System.Drawing.Point(0, 0);
            this.textBoxDspacing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDspacing.Multiline = true;
            this.textBoxDspacing.Name = "textBoxDspacing";
            this.textBoxDspacing.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDspacing.Size = new System.Drawing.Size(720, 270);
            this.textBoxDspacing.TabIndex = 2;
            this.textBoxDspacing.WordWrap = false;
            // 
            // tabPageFWHM
            // 
            this.tabPageFWHM.Controls.Add(this.textBoxFWHM);
            this.tabPageFWHM.Location = new System.Drawing.Point(4, 26);
            this.tabPageFWHM.Name = "tabPageFWHM";
            this.tabPageFWHM.Size = new System.Drawing.Size(720, 270);
            this.tabPageFWHM.TabIndex = 2;
            this.tabPageFWHM.Text = "FWHM (deg.)";
            this.tabPageFWHM.UseVisualStyleBackColor = true;
            // 
            // textBoxFWHM
            // 
            this.textBoxFWHM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFWHM.Location = new System.Drawing.Point(0, 0);
            this.textBoxFWHM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFWHM.Multiline = true;
            this.textBoxFWHM.Name = "textBoxFWHM";
            this.textBoxFWHM.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxFWHM.Size = new System.Drawing.Size(720, 270);
            this.textBoxFWHM.TabIndex = 2;
            this.textBoxFWHM.WordWrap = false;
            // 
            // tabPageIntensity
            // 
            this.tabPageIntensity.Controls.Add(this.textBoxIntensity);
            this.tabPageIntensity.Location = new System.Drawing.Point(4, 26);
            this.tabPageIntensity.Name = "tabPageIntensity";
            this.tabPageIntensity.Size = new System.Drawing.Size(720, 270);
            this.tabPageIntensity.TabIndex = 3;
            this.tabPageIntensity.Text = "Intensity";
            this.tabPageIntensity.UseVisualStyleBackColor = true;
            // 
            // textBoxIntensity
            // 
            this.textBoxIntensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIntensity.Location = new System.Drawing.Point(0, 0);
            this.textBoxIntensity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxIntensity.Multiline = true;
            this.textBoxIntensity.Name = "textBoxIntensity";
            this.textBoxIntensity.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxIntensity.Size = new System.Drawing.Size(720, 270);
            this.textBoxIntensity.TabIndex = 2;
            this.textBoxIntensity.WordWrap = false;
            // 
            // tabPageCellConstants
            // 
            this.tabPageCellConstants.Controls.Add(this.textBoxCellConstants);
            this.tabPageCellConstants.Location = new System.Drawing.Point(4, 26);
            this.tabPageCellConstants.Name = "tabPageCellConstants";
            this.tabPageCellConstants.Size = new System.Drawing.Size(720, 270);
            this.tabPageCellConstants.TabIndex = 5;
            this.tabPageCellConstants.Text = "Cell constants (Å, deg))";
            this.tabPageCellConstants.UseVisualStyleBackColor = true;
            // 
            // textBoxCellConstants
            // 
            this.textBoxCellConstants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCellConstants.Location = new System.Drawing.Point(0, 0);
            this.textBoxCellConstants.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCellConstants.Multiline = true;
            this.textBoxCellConstants.Name = "textBoxCellConstants";
            this.textBoxCellConstants.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCellConstants.Size = new System.Drawing.Size(720, 270);
            this.textBoxCellConstants.TabIndex = 3;
            this.textBoxCellConstants.WordWrap = false;
            // 
            // tabPagePressure
            // 
            this.tabPagePressure.Controls.Add(this.textBoxPressure);
            this.tabPagePressure.Location = new System.Drawing.Point(4, 26);
            this.tabPagePressure.Name = "tabPagePressure";
            this.tabPagePressure.Size = new System.Drawing.Size(720, 270);
            this.tabPagePressure.TabIndex = 6;
            this.tabPagePressure.Text = "Pressure (GPa)";
            this.tabPagePressure.UseVisualStyleBackColor = true;
            // 
            // textBoxPressure
            // 
            this.textBoxPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPressure.Location = new System.Drawing.Point(0, 0);
            this.textBoxPressure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPressure.Multiline = true;
            this.textBoxPressure.Name = "textBoxPressure";
            this.textBoxPressure.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPressure.Size = new System.Drawing.Size(720, 270);
            this.textBoxPressure.TabIndex = 3;
            this.textBoxPressure.WordWrap = false;
            // 
            // tabPageSingh
            // 
            this.tabPageSingh.Controls.Add(this.textBoxResults);
            this.tabPageSingh.Controls.Add(this.numericalTextBoxAlpha);
            this.tabPageSingh.Controls.Add(this.numericalTextBoxPsimax);
            this.tabPageSingh.Controls.Add(this.numericalTextBoxD0);
            this.tabPageSingh.Controls.Add(this.graphControl1);
            this.tabPageSingh.Location = new System.Drawing.Point(4, 26);
            this.tabPageSingh.Name = "tabPageSingh";
            this.tabPageSingh.Size = new System.Drawing.Size(734, 273);
            this.tabPageSingh.TabIndex = 4;
            this.tabPageSingh.Text = "Analyze Singh equation";
            this.tabPageSingh.UseVisualStyleBackColor = true;
            // 
            // numericalTextBoxAlpha
            // 
            this.numericalTextBoxAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericalTextBoxAlpha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.numericalTextBoxAlpha.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxAlpha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxAlpha.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxAlpha.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxAlpha.Location = new System.Drawing.Point(688, 242);
            this.numericalTextBoxAlpha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericalTextBoxAlpha.MaximumSize = new System.Drawing.Size(1000, 24);
            this.numericalTextBoxAlpha.MinimumSize = new System.Drawing.Size(1, 22);
            this.numericalTextBoxAlpha.Name = "numericalTextBoxAlpha";
            this.numericalTextBoxAlpha.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.numericalTextBoxAlpha.RoundErrorAccuracy = -1;
            this.numericalTextBoxAlpha.Size = new System.Drawing.Size(43, 24);
            this.numericalTextBoxAlpha.SkipEventDuringInput = false;
            this.numericalTextBoxAlpha.SmartIncrement = true;
            this.numericalTextBoxAlpha.TabIndex = 5;
            this.numericalTextBoxAlpha.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxAlpha.ThonsandsSeparator = true;
            this.numericalTextBoxAlpha.Visible = false;
            this.numericalTextBoxAlpha.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBoxD0_ValueChanged);
            // 
            // numericalTextBoxPsimax
            // 
            this.numericalTextBoxPsimax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericalTextBoxPsimax.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.numericalTextBoxPsimax.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPsimax.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPsimax.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPsimax.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPsimax.Location = new System.Drawing.Point(642, 242);
            this.numericalTextBoxPsimax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericalTextBoxPsimax.MaximumSize = new System.Drawing.Size(1000, 24);
            this.numericalTextBoxPsimax.MinimumSize = new System.Drawing.Size(1, 22);
            this.numericalTextBoxPsimax.Name = "numericalTextBoxPsimax";
            this.numericalTextBoxPsimax.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.numericalTextBoxPsimax.RoundErrorAccuracy = -1;
            this.numericalTextBoxPsimax.Size = new System.Drawing.Size(40, 24);
            this.numericalTextBoxPsimax.SkipEventDuringInput = false;
            this.numericalTextBoxPsimax.SmartIncrement = true;
            this.numericalTextBoxPsimax.TabIndex = 5;
            this.numericalTextBoxPsimax.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPsimax.ThonsandsSeparator = true;
            this.numericalTextBoxPsimax.Visible = false;
            this.numericalTextBoxPsimax.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBoxD0_ValueChanged);
            // 
            // numericalTextBoxD0
            // 
            this.numericalTextBoxD0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericalTextBoxD0.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.numericalTextBoxD0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxD0.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxD0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxD0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxD0.Location = new System.Drawing.Point(569, 242);
            this.numericalTextBoxD0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericalTextBoxD0.MaximumSize = new System.Drawing.Size(1000, 24);
            this.numericalTextBoxD0.MinimumSize = new System.Drawing.Size(1, 22);
            this.numericalTextBoxD0.Name = "numericalTextBoxD0";
            this.numericalTextBoxD0.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.numericalTextBoxD0.RoundErrorAccuracy = -1;
            this.numericalTextBoxD0.Size = new System.Drawing.Size(67, 24);
            this.numericalTextBoxD0.SkipEventDuringInput = false;
            this.numericalTextBoxD0.SmartIncrement = true;
            this.numericalTextBoxD0.TabIndex = 5;
            this.numericalTextBoxD0.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxD0.ThonsandsSeparator = true;
            this.numericalTextBoxD0.Visible = false;
            this.numericalTextBoxD0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBoxD0_ValueChanged);
            // 
            // graphControl1
            // 
            this.graphControl1.AllowMouseOperation = true;
            this.graphControl1.BackgroundColor = System.Drawing.Color.White;
            this.graphControl1.BottomMargin = 0D;
            this.graphControl1.DivisionLineColor = System.Drawing.Color.Gray;
            this.graphControl1.DivisionSubLineColor = System.Drawing.Color.LightGray;
            this.graphControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.graphControl1.FixRangeHorizontal = false;
            this.graphControl1.FixRangeVertical = false;
            this.graphControl1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.graphControl1.Location = new System.Drawing.Point(385, 0);
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
            this.graphControl1.Size = new System.Drawing.Size(349, 273);
            this.graphControl1.Smoothing = false;
            this.graphControl1.TabIndex = 4;
            this.graphControl1.TextFont = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.textBoxResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResults.Location = new System.Drawing.Point(0, 0);
            this.textBoxResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxResults.Multiline = true;
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.Size = new System.Drawing.Size(385, 273);
            this.textBoxResults.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 336);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(742, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = " ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.buttonExecute);
            this.flowLayoutPanel1.Controls.Add(this.buttonCopy);
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(742, 33);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // buttonCopy
            // 
            this.buttonCopy.AutoSize = true;
            this.buttonCopy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCopy.Location = new System.Drawing.Point(69, 3);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(48, 27);
            this.buttonCopy.TabIndex = 1;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSize = true;
            this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSave.Location = new System.Drawing.Point(123, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(45, 27);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormSequentialAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(742, 358);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormSequentialAnalysis";
            this.Text = "Sequential Analysis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStressAnalysis_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPage2theta.ResumeLayout(false);
            this.tabPage2theta.PerformLayout();
            this.tabPageDspacing.ResumeLayout(false);
            this.tabPageDspacing.PerformLayout();
            this.tabPageFWHM.ResumeLayout(false);
            this.tabPageFWHM.PerformLayout();
            this.tabPageIntensity.ResumeLayout(false);
            this.tabPageIntensity.PerformLayout();
            this.tabPageCellConstants.ResumeLayout(false);
            this.tabPageCellConstants.PerformLayout();
            this.tabPagePressure.ResumeLayout(false);
            this.tabPagePressure.PerformLayout();
            this.tabPageSingh.ResumeLayout(false);
            this.tabPageSingh.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2theta;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage2theta;
        private System.Windows.Forms.TabPage tabPageDspacing;
        private System.Windows.Forms.TabPage tabPageFWHM;
        private System.Windows.Forms.TabPage tabPageIntensity;
        private System.Windows.Forms.TextBox textBoxDspacing;
        private System.Windows.Forms.TextBox textBoxFWHM;
        private System.Windows.Forms.TextBox textBoxIntensity;
        private System.Windows.Forms.TabPage tabPageSingh;
        private System.Windows.Forms.TextBox textBoxResults;
        private Crystallography.Controls.GraphControl graphControl1;
        private Crystallography.Controls.NumericBox numericalTextBoxAlpha;
        private Crystallography.Controls.NumericBox numericalTextBoxPsimax;
        private Crystallography.Controls.NumericBox numericalTextBoxD0;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabPage tabPageCellConstants;
        private System.Windows.Forms.TabPage tabPagePressure;
        private System.Windows.Forms.TextBox textBoxCellConstants;
        private System.Windows.Forms.TextBox textBoxPressure;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.Button buttonExecute;
    }
}