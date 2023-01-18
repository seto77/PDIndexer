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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSequentialAnalysis));
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
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.numericalTextBoxAlpha = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPsimax = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxD0 = new Crystallography.Controls.NumericBox();
            this.graphControl1 = new Crystallography.Controls.GraphControl();
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
            resources.ApplyResources(this.buttonExecute, "buttonExecute");
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // textBox2theta
            // 
            resources.ApplyResources(this.textBox2theta, "textBox2theta");
            this.textBox2theta.Name = "textBox2theta";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabPage2theta);
            this.tabControl.Controls.Add(this.tabPageDspacing);
            this.tabControl.Controls.Add(this.tabPageFWHM);
            this.tabControl.Controls.Add(this.tabPageIntensity);
            this.tabControl.Controls.Add(this.tabPageCellConstants);
            this.tabControl.Controls.Add(this.tabPagePressure);
            this.tabControl.Controls.Add(this.tabPageSingh);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPage2theta
            // 
            resources.ApplyResources(this.tabPage2theta, "tabPage2theta");
            this.tabPage2theta.Controls.Add(this.textBox2theta);
            this.tabPage2theta.Name = "tabPage2theta";
            this.tabPage2theta.UseVisualStyleBackColor = true;
            // 
            // tabPageDspacing
            // 
            resources.ApplyResources(this.tabPageDspacing, "tabPageDspacing");
            this.tabPageDspacing.Controls.Add(this.textBoxDspacing);
            this.tabPageDspacing.Name = "tabPageDspacing";
            this.tabPageDspacing.UseVisualStyleBackColor = true;
            // 
            // textBoxDspacing
            // 
            resources.ApplyResources(this.textBoxDspacing, "textBoxDspacing");
            this.textBoxDspacing.Name = "textBoxDspacing";
            // 
            // tabPageFWHM
            // 
            resources.ApplyResources(this.tabPageFWHM, "tabPageFWHM");
            this.tabPageFWHM.Controls.Add(this.textBoxFWHM);
            this.tabPageFWHM.Name = "tabPageFWHM";
            this.tabPageFWHM.UseVisualStyleBackColor = true;
            // 
            // textBoxFWHM
            // 
            resources.ApplyResources(this.textBoxFWHM, "textBoxFWHM");
            this.textBoxFWHM.Name = "textBoxFWHM";
            // 
            // tabPageIntensity
            // 
            resources.ApplyResources(this.tabPageIntensity, "tabPageIntensity");
            this.tabPageIntensity.Controls.Add(this.textBoxIntensity);
            this.tabPageIntensity.Name = "tabPageIntensity";
            this.tabPageIntensity.UseVisualStyleBackColor = true;
            // 
            // textBoxIntensity
            // 
            resources.ApplyResources(this.textBoxIntensity, "textBoxIntensity");
            this.textBoxIntensity.Name = "textBoxIntensity";
            // 
            // tabPageCellConstants
            // 
            resources.ApplyResources(this.tabPageCellConstants, "tabPageCellConstants");
            this.tabPageCellConstants.Controls.Add(this.textBoxCellConstants);
            this.tabPageCellConstants.Name = "tabPageCellConstants";
            this.tabPageCellConstants.UseVisualStyleBackColor = true;
            // 
            // textBoxCellConstants
            // 
            resources.ApplyResources(this.textBoxCellConstants, "textBoxCellConstants");
            this.textBoxCellConstants.Name = "textBoxCellConstants";
            // 
            // tabPagePressure
            // 
            resources.ApplyResources(this.tabPagePressure, "tabPagePressure");
            this.tabPagePressure.Controls.Add(this.textBoxPressure);
            this.tabPagePressure.Name = "tabPagePressure";
            this.tabPagePressure.UseVisualStyleBackColor = true;
            // 
            // textBoxPressure
            // 
            resources.ApplyResources(this.textBoxPressure, "textBoxPressure");
            this.textBoxPressure.Name = "textBoxPressure";
            // 
            // tabPageSingh
            // 
            resources.ApplyResources(this.tabPageSingh, "tabPageSingh");
            this.tabPageSingh.Controls.Add(this.textBoxResults);
            this.tabPageSingh.Controls.Add(this.numericalTextBoxAlpha);
            this.tabPageSingh.Controls.Add(this.numericalTextBoxPsimax);
            this.tabPageSingh.Controls.Add(this.numericalTextBoxD0);
            this.tabPageSingh.Controls.Add(this.graphControl1);
            this.tabPageSingh.Name = "tabPageSingh";
            this.tabPageSingh.UseVisualStyleBackColor = true;
            // 
            // textBoxResults
            // 
            resources.ApplyResources(this.textBoxResults, "textBoxResults");
            this.textBoxResults.Name = "textBoxResults";
            // 
            // numericalTextBoxAlpha
            // 
            resources.ApplyResources(this.numericalTextBoxAlpha, "numericalTextBoxAlpha");
            this.numericalTextBoxAlpha.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxAlpha.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxAlpha.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxAlpha.Name = "numericalTextBoxAlpha";
            this.numericalTextBoxAlpha.RoundErrorAccuracy = -1;
            this.numericalTextBoxAlpha.SkipEventDuringInput = false;
            this.numericalTextBoxAlpha.SmartIncrement = true;
            this.numericalTextBoxAlpha.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxAlpha.ThonsandsSeparator = true;
            this.numericalTextBoxAlpha.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBoxD0_ValueChanged);
            // 
            // numericalTextBoxPsimax
            // 
            resources.ApplyResources(this.numericalTextBoxPsimax, "numericalTextBoxPsimax");
            this.numericalTextBoxPsimax.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPsimax.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPsimax.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPsimax.Name = "numericalTextBoxPsimax";
            this.numericalTextBoxPsimax.RoundErrorAccuracy = -1;
            this.numericalTextBoxPsimax.SkipEventDuringInput = false;
            this.numericalTextBoxPsimax.SmartIncrement = true;
            this.numericalTextBoxPsimax.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPsimax.ThonsandsSeparator = true;
            this.numericalTextBoxPsimax.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBoxD0_ValueChanged);
            // 
            // numericalTextBoxD0
            // 
            resources.ApplyResources(this.numericalTextBoxD0, "numericalTextBoxD0");
            this.numericalTextBoxD0.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxD0.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxD0.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxD0.Name = "numericalTextBoxD0";
            this.numericalTextBoxD0.RoundErrorAccuracy = -1;
            this.numericalTextBoxD0.SkipEventDuringInput = false;
            this.numericalTextBoxD0.SmartIncrement = true;
            this.numericalTextBoxD0.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxD0.ThonsandsSeparator = true;
            this.numericalTextBoxD0.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericalTextBoxD0_ValueChanged);
            // 
            // graphControl1
            // 
            resources.ApplyResources(this.graphControl1, "graphControl1");
            this.graphControl1.AllowMouseOperation = true;
            this.graphControl1.BackgroundColor = System.Drawing.Color.White;
            this.graphControl1.BottomMargin = 0D;
            this.graphControl1.DivisionLineColor = System.Drawing.Color.Gray;
            this.graphControl1.DivisionSubLineColor = System.Drawing.Color.LightGray;
            this.graphControl1.FixRangeHorizontal = false;
            this.graphControl1.FixRangeVertical = false;
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
            this.graphControl1.Smoothing = false;
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
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.buttonExecute);
            this.flowLayoutPanel1.Controls.Add(this.buttonCopy);
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // buttonCopy
            // 
            resources.ApplyResources(this.buttonCopy, "buttonCopy");
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormSequentialAnalysis
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormSequentialAnalysis";
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