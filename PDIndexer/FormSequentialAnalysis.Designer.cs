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
            buttonExecute = new System.Windows.Forms.Button();
            textBox2theta = new System.Windows.Forms.TextBox();
            tabControl = new System.Windows.Forms.TabControl();
            tabPage2theta = new System.Windows.Forms.TabPage();
            checkBoxAutoSaveTwoTheta = new System.Windows.Forms.CheckBox();
            tabPageDspacing = new System.Windows.Forms.TabPage();
            textBoxDspacing = new System.Windows.Forms.TextBox();
            checkBoxAutoSaveD = new System.Windows.Forms.CheckBox();
            tabPageFWHM = new System.Windows.Forms.TabPage();
            textBoxFWHM = new System.Windows.Forms.TextBox();
            checkBoxAutoSaveFWHM = new System.Windows.Forms.CheckBox();
            tabPageIntensity = new System.Windows.Forms.TabPage();
            textBoxIntensity = new System.Windows.Forms.TextBox();
            checkBoxAutoSaveInt = new System.Windows.Forms.CheckBox();
            tabPageCellConstants = new System.Windows.Forms.TabPage();
            textBoxCellConstants = new System.Windows.Forms.TextBox();
            checkBoxAutoSaveCell = new System.Windows.Forms.CheckBox();
            tabPagePressure = new System.Windows.Forms.TabPage();
            textBoxPressure = new System.Windows.Forms.TextBox();
            checkBoxAutoSavePressure = new System.Windows.Forms.CheckBox();
            tabPageSingh = new System.Windows.Forms.TabPage();
            textBoxSingh = new System.Windows.Forms.TextBox();
            checkBoxAutoSaveSingh = new System.Windows.Forms.CheckBox();
            numericalTextBoxAlpha = new Crystallography.Controls.NumericBox();
            numericalTextBoxPsimax = new Crystallography.Controls.NumericBox();
            numericalTextBoxD0 = new Crystallography.Controls.NumericBox();
            graphControl1 = new Crystallography.Controls.GraphControl();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            buttonCopy = new System.Windows.Forms.Button();
            buttonSave = new System.Windows.Forms.Button();
            textBoxDirectory = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            buttonSetDirectory = new System.Windows.Forms.Button();
            tabControl.SuspendLayout();
            tabPage2theta.SuspendLayout();
            tabPageDspacing.SuspendLayout();
            tabPageFWHM.SuspendLayout();
            tabPageIntensity.SuspendLayout();
            tabPageCellConstants.SuspendLayout();
            tabPagePressure.SuspendLayout();
            tabPageSingh.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonExecute
            // 
            resources.ApplyResources(buttonExecute, "buttonExecute");
            buttonExecute.Name = "buttonExecute";
            buttonExecute.UseVisualStyleBackColor = true;
            buttonExecute.Click += buttonExecute_Click;
            // 
            // textBox2theta
            // 
            resources.ApplyResources(textBox2theta, "textBox2theta");
            textBox2theta.Name = "textBox2theta";
            // 
            // tabControl
            // 
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.Controls.Add(tabPage2theta);
            tabControl.Controls.Add(tabPageDspacing);
            tabControl.Controls.Add(tabPageFWHM);
            tabControl.Controls.Add(tabPageIntensity);
            tabControl.Controls.Add(tabPageCellConstants);
            tabControl.Controls.Add(tabPagePressure);
            tabControl.Controls.Add(tabPageSingh);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            // 
            // tabPage2theta
            // 
            resources.ApplyResources(tabPage2theta, "tabPage2theta");
            tabPage2theta.Controls.Add(textBox2theta);
            tabPage2theta.Controls.Add(checkBoxAutoSaveTwoTheta);
            tabPage2theta.Name = "tabPage2theta";
            tabPage2theta.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoSaveTwoTheta
            // 
            resources.ApplyResources(checkBoxAutoSaveTwoTheta, "checkBoxAutoSaveTwoTheta");
            checkBoxAutoSaveTwoTheta.Name = "checkBoxAutoSaveTwoTheta";
            checkBoxAutoSaveTwoTheta.UseVisualStyleBackColor = true;
            // 
            // tabPageDspacing
            // 
            resources.ApplyResources(tabPageDspacing, "tabPageDspacing");
            tabPageDspacing.Controls.Add(textBoxDspacing);
            tabPageDspacing.Controls.Add(checkBoxAutoSaveD);
            tabPageDspacing.Name = "tabPageDspacing";
            tabPageDspacing.UseVisualStyleBackColor = true;
            // 
            // textBoxDspacing
            // 
            resources.ApplyResources(textBoxDspacing, "textBoxDspacing");
            textBoxDspacing.Name = "textBoxDspacing";
            // 
            // checkBoxAutoSaveD
            // 
            resources.ApplyResources(checkBoxAutoSaveD, "checkBoxAutoSaveD");
            checkBoxAutoSaveD.Name = "checkBoxAutoSaveD";
            checkBoxAutoSaveD.UseVisualStyleBackColor = true;
            // 
            // tabPageFWHM
            // 
            resources.ApplyResources(tabPageFWHM, "tabPageFWHM");
            tabPageFWHM.Controls.Add(textBoxFWHM);
            tabPageFWHM.Controls.Add(checkBoxAutoSaveFWHM);
            tabPageFWHM.Name = "tabPageFWHM";
            tabPageFWHM.UseVisualStyleBackColor = true;
            // 
            // textBoxFWHM
            // 
            resources.ApplyResources(textBoxFWHM, "textBoxFWHM");
            textBoxFWHM.Name = "textBoxFWHM";
            // 
            // checkBoxAutoSaveFWHM
            // 
            resources.ApplyResources(checkBoxAutoSaveFWHM, "checkBoxAutoSaveFWHM");
            checkBoxAutoSaveFWHM.Name = "checkBoxAutoSaveFWHM";
            checkBoxAutoSaveFWHM.UseVisualStyleBackColor = true;
            // 
            // tabPageIntensity
            // 
            resources.ApplyResources(tabPageIntensity, "tabPageIntensity");
            tabPageIntensity.Controls.Add(textBoxIntensity);
            tabPageIntensity.Controls.Add(checkBoxAutoSaveInt);
            tabPageIntensity.Name = "tabPageIntensity";
            tabPageIntensity.UseVisualStyleBackColor = true;
            // 
            // textBoxIntensity
            // 
            resources.ApplyResources(textBoxIntensity, "textBoxIntensity");
            textBoxIntensity.Name = "textBoxIntensity";
            // 
            // checkBoxAutoSaveInt
            // 
            resources.ApplyResources(checkBoxAutoSaveInt, "checkBoxAutoSaveInt");
            checkBoxAutoSaveInt.Name = "checkBoxAutoSaveInt";
            checkBoxAutoSaveInt.UseVisualStyleBackColor = true;
            // 
            // tabPageCellConstants
            // 
            resources.ApplyResources(tabPageCellConstants, "tabPageCellConstants");
            tabPageCellConstants.Controls.Add(textBoxCellConstants);
            tabPageCellConstants.Controls.Add(checkBoxAutoSaveCell);
            tabPageCellConstants.Name = "tabPageCellConstants";
            tabPageCellConstants.UseVisualStyleBackColor = true;
            // 
            // textBoxCellConstants
            // 
            resources.ApplyResources(textBoxCellConstants, "textBoxCellConstants");
            textBoxCellConstants.Name = "textBoxCellConstants";
            // 
            // checkBoxAutoSaveCell
            // 
            resources.ApplyResources(checkBoxAutoSaveCell, "checkBoxAutoSaveCell");
            checkBoxAutoSaveCell.Name = "checkBoxAutoSaveCell";
            checkBoxAutoSaveCell.UseVisualStyleBackColor = true;
            // 
            // tabPagePressure
            // 
            resources.ApplyResources(tabPagePressure, "tabPagePressure");
            tabPagePressure.Controls.Add(textBoxPressure);
            tabPagePressure.Controls.Add(checkBoxAutoSavePressure);
            tabPagePressure.Name = "tabPagePressure";
            tabPagePressure.UseVisualStyleBackColor = true;
            // 
            // textBoxPressure
            // 
            resources.ApplyResources(textBoxPressure, "textBoxPressure");
            textBoxPressure.Name = "textBoxPressure";
            // 
            // checkBoxAutoSavePressure
            // 
            resources.ApplyResources(checkBoxAutoSavePressure, "checkBoxAutoSavePressure");
            checkBoxAutoSavePressure.Name = "checkBoxAutoSavePressure";
            checkBoxAutoSavePressure.UseVisualStyleBackColor = true;
            // 
            // tabPageSingh
            // 
            resources.ApplyResources(tabPageSingh, "tabPageSingh");
            tabPageSingh.Controls.Add(textBoxSingh);
            tabPageSingh.Controls.Add(checkBoxAutoSaveSingh);
            tabPageSingh.Controls.Add(numericalTextBoxAlpha);
            tabPageSingh.Controls.Add(numericalTextBoxPsimax);
            tabPageSingh.Controls.Add(numericalTextBoxD0);
            tabPageSingh.Controls.Add(graphControl1);
            tabPageSingh.Name = "tabPageSingh";
            tabPageSingh.UseVisualStyleBackColor = true;
            // 
            // textBoxResults
            // 
            resources.ApplyResources(textBoxSingh, "textBoxResults");
            textBoxSingh.Name = "textBoxResults";
            // 
            // checkBoxAutoSaveSingh
            // 
            resources.ApplyResources(checkBoxAutoSaveSingh, "checkBoxAutoSaveSingh");
            checkBoxAutoSaveSingh.Name = "checkBoxAutoSaveSingh";
            checkBoxAutoSaveSingh.UseVisualStyleBackColor = true;
            // 
            // numericalTextBoxAlpha
            // 
            resources.ApplyResources(numericalTextBoxAlpha, "numericalTextBoxAlpha");
            numericalTextBoxAlpha.BackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxAlpha.FooterBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxAlpha.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxAlpha.Name = "numericalTextBoxAlpha";
            numericalTextBoxAlpha.RoundErrorAccuracy = -1;
            numericalTextBoxAlpha.SkipEventDuringInput = false;
            numericalTextBoxAlpha.SmartIncrement = true;
            numericalTextBoxAlpha.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericalTextBoxAlpha.ThonsandsSeparator = true;
            numericalTextBoxAlpha.ValueChanged += numericalTextBoxD0_ValueChanged;
            // 
            // numericalTextBoxPsimax
            // 
            resources.ApplyResources(numericalTextBoxPsimax, "numericalTextBoxPsimax");
            numericalTextBoxPsimax.BackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxPsimax.FooterBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxPsimax.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxPsimax.Name = "numericalTextBoxPsimax";
            numericalTextBoxPsimax.RoundErrorAccuracy = -1;
            numericalTextBoxPsimax.SkipEventDuringInput = false;
            numericalTextBoxPsimax.SmartIncrement = true;
            numericalTextBoxPsimax.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericalTextBoxPsimax.ThonsandsSeparator = true;
            numericalTextBoxPsimax.ValueChanged += numericalTextBoxD0_ValueChanged;
            // 
            // numericalTextBoxD0
            // 
            resources.ApplyResources(numericalTextBoxD0, "numericalTextBoxD0");
            numericalTextBoxD0.BackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxD0.FooterBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxD0.HeaderBackColor = System.Drawing.SystemColors.Control;
            numericalTextBoxD0.Name = "numericalTextBoxD0";
            numericalTextBoxD0.RoundErrorAccuracy = -1;
            numericalTextBoxD0.SkipEventDuringInput = false;
            numericalTextBoxD0.SmartIncrement = true;
            numericalTextBoxD0.TextFont = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericalTextBoxD0.ThonsandsSeparator = true;
            numericalTextBoxD0.ValueChanged += numericalTextBoxD0_ValueChanged;
            // 
            // graphControl1
            // 
            resources.ApplyResources(graphControl1, "graphControl1");
            graphControl1.AllowMouseOperation = true;
            graphControl1.BackgroundColor = System.Drawing.Color.White;
            graphControl1.BottomMargin = 0D;
            graphControl1.DivisionLineColor = System.Drawing.Color.Gray;
            graphControl1.DivisionSubLineColor = System.Drawing.Color.LightGray;
            graphControl1.FixRangeHorizontal = false;
            graphControl1.FixRangeVertical = false;
            graphControl1.GraphName = "";
            graphControl1.HorizontalGradiationTextVisivle = true;
            graphControl1.Interpolation = false;
            graphControl1.IsIntegerX = false;
            graphControl1.IsIntegerY = false;
            graphControl1.LabelX = "X:";
            graphControl1.LabelY = "Y:";
            graphControl1.LeftMargin = 0F;
            graphControl1.LineColor = System.Drawing.Color.Red;
            graphControl1.LineWidth = 1F;
            graphControl1.LowerX = 0D;
            graphControl1.LowerY = 0D;
            graphControl1.MaximalX = 1D;
            graphControl1.MaximalY = 1D;
            graphControl1.MinimalX = 0D;
            graphControl1.MinimalY = 0D;
            graphControl1.Mode = Crystallography.Controls.GraphControl.DrawingMode.Line;
            graphControl1.MousePositionVisible = true;
            graphControl1.Name = "graphControl1";
            graphControl1.OriginPosition = new System.Drawing.Point(40, 20);
            graphControl1.Smoothing = false;
            graphControl1.TextFont = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            graphControl1.UnitX = "";
            graphControl1.UnitY = "";
            graphControl1.UpperText = "";
            graphControl1.UpperTextVisible = true;
            graphControl1.UpperX = 1D;
            graphControl1.UpperY = 1D;
            graphControl1.UseLineWidth = true;
            graphControl1.VerticalGradiationTextVisivle = true;
            graphControl1.XLog = false;
            graphControl1.XScaleLineVisible = true;
            graphControl1.YLog = false;
            graphControl1.YScaleLineVisible = true;
            // 
            // statusStrip1
            // 
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // buttonCopy
            // 
            resources.ApplyResources(buttonCopy, "buttonCopy");
            buttonCopy.Name = "buttonCopy";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // buttonSave
            // 
            resources.ApplyResources(buttonSave, "buttonSave");
            buttonSave.Name = "buttonSave";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // textBox1
            // 
            resources.ApplyResources(textBoxDirectory, "textBox1");
            textBoxDirectory.Name = "textBox1";
            textBoxDirectory.ReadOnly = true;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxDirectory);
            panel1.Controls.Add(buttonSetDirectory);
            panel1.Controls.Add(buttonSave);
            panel1.Controls.Add(buttonCopy);
            panel1.Controls.Add(buttonExecute);
            panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // buttonSetDirectory
            // 
            resources.ApplyResources(buttonSetDirectory, "buttonSetDirectory");
            buttonSetDirectory.Name = "buttonSetDirectory";
            buttonSetDirectory.UseVisualStyleBackColor = true;
            buttonSetDirectory.Click += buttonSetDirectory_Click;
            // 
            // FormSequentialAnalysis
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Name = "FormSequentialAnalysis";
            FormClosing += FormStressAnalysis_FormClosing;
            tabControl.ResumeLayout(false);
            tabPage2theta.ResumeLayout(false);
            tabPage2theta.PerformLayout();
            tabPageDspacing.ResumeLayout(false);
            tabPageDspacing.PerformLayout();
            tabPageFWHM.ResumeLayout(false);
            tabPageFWHM.PerformLayout();
            tabPageIntensity.ResumeLayout(false);
            tabPageIntensity.PerformLayout();
            tabPageCellConstants.ResumeLayout(false);
            tabPageCellConstants.PerformLayout();
            tabPagePressure.ResumeLayout(false);
            tabPagePressure.PerformLayout();
            tabPageSingh.ResumeLayout(false);
            tabPageSingh.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxSingh;
        private Crystallography.Controls.GraphControl graphControl1;
        private Crystallography.Controls.NumericBox numericalTextBoxAlpha;
        private Crystallography.Controls.NumericBox numericalTextBoxPsimax;
        private Crystallography.Controls.NumericBox numericalTextBoxD0;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPageCellConstants;
        private System.Windows.Forms.TabPage tabPagePressure;
        private System.Windows.Forms.TextBox textBoxCellConstants;
        private System.Windows.Forms.TextBox textBoxPressure;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.CheckBox checkBoxAutoSaveTwoTheta;
        private System.Windows.Forms.CheckBox checkBoxAutoSaveD;
        private System.Windows.Forms.CheckBox checkBoxAutoSaveFWHM;
        private System.Windows.Forms.CheckBox checkBoxAutoSaveInt;
        private System.Windows.Forms.CheckBox checkBoxAutoSaveCell;
        private System.Windows.Forms.CheckBox checkBoxAutoSavePressure;
        private System.Windows.Forms.CheckBox checkBoxAutoSaveSingh;
        private System.Windows.Forms.TextBox textBoxDirectory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSetDirectory;
    }
}