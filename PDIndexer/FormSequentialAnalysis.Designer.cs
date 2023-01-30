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
            this.checkBoxAutoSaveTwoTheta = new System.Windows.Forms.CheckBox();
            this.tabPageDspacing = new System.Windows.Forms.TabPage();
            this.textBoxDspacing = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSaveD = new System.Windows.Forms.CheckBox();
            this.tabPageFWHM = new System.Windows.Forms.TabPage();
            this.textBoxFWHM = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSaveFWHM = new System.Windows.Forms.CheckBox();
            this.tabPageIntensity = new System.Windows.Forms.TabPage();
            this.textBoxIntensity = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSaveInt = new System.Windows.Forms.CheckBox();
            this.tabPageCellConstants = new System.Windows.Forms.TabPage();
            this.textBoxCellConstants = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSaveCell = new System.Windows.Forms.CheckBox();
            this.tabPagePressure = new System.Windows.Forms.TabPage();
            this.textBoxPressure = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSavePressure = new System.Windows.Forms.CheckBox();
            this.tabPageSingh = new System.Windows.Forms.TabPage();
            this.textBoxSingh = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSaveSingh = new System.Windows.Forms.CheckBox();
            this.graphControl1 = new Crystallography.Controls.GraphControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxDirectory = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericBoxStartNumber = new Crystallography.Controls.NumericBox();
            this.checkBoxStartNumber = new System.Windows.Forms.CheckBox();
            this.buttonSetDirectory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage2theta.SuspendLayout();
            this.tabPageDspacing.SuspendLayout();
            this.tabPageFWHM.SuspendLayout();
            this.tabPageIntensity.SuspendLayout();
            this.tabPageCellConstants.SuspendLayout();
            this.tabPagePressure.SuspendLayout();
            this.tabPageSingh.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabControl.Controls.Add(this.tabPage2theta);
            this.tabControl.Controls.Add(this.tabPageDspacing);
            this.tabControl.Controls.Add(this.tabPageFWHM);
            this.tabControl.Controls.Add(this.tabPageIntensity);
            this.tabControl.Controls.Add(this.tabPageCellConstants);
            this.tabControl.Controls.Add(this.tabPagePressure);
            this.tabControl.Controls.Add(this.tabPageSingh);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPage2theta
            // 
            this.tabPage2theta.Controls.Add(this.textBox2theta);
            this.tabPage2theta.Controls.Add(this.checkBoxAutoSaveTwoTheta);
            resources.ApplyResources(this.tabPage2theta, "tabPage2theta");
            this.tabPage2theta.Name = "tabPage2theta";
            this.tabPage2theta.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoSaveTwoTheta
            // 
            resources.ApplyResources(this.checkBoxAutoSaveTwoTheta, "checkBoxAutoSaveTwoTheta");
            this.checkBoxAutoSaveTwoTheta.Name = "checkBoxAutoSaveTwoTheta";
            this.checkBoxAutoSaveTwoTheta.UseVisualStyleBackColor = true;
            // 
            // tabPageDspacing
            // 
            this.tabPageDspacing.Controls.Add(this.textBoxDspacing);
            this.tabPageDspacing.Controls.Add(this.checkBoxAutoSaveD);
            resources.ApplyResources(this.tabPageDspacing, "tabPageDspacing");
            this.tabPageDspacing.Name = "tabPageDspacing";
            this.tabPageDspacing.UseVisualStyleBackColor = true;
            // 
            // textBoxDspacing
            // 
            resources.ApplyResources(this.textBoxDspacing, "textBoxDspacing");
            this.textBoxDspacing.Name = "textBoxDspacing";
            // 
            // checkBoxAutoSaveD
            // 
            resources.ApplyResources(this.checkBoxAutoSaveD, "checkBoxAutoSaveD");
            this.checkBoxAutoSaveD.Name = "checkBoxAutoSaveD";
            this.checkBoxAutoSaveD.UseVisualStyleBackColor = true;
            // 
            // tabPageFWHM
            // 
            this.tabPageFWHM.Controls.Add(this.textBoxFWHM);
            this.tabPageFWHM.Controls.Add(this.checkBoxAutoSaveFWHM);
            resources.ApplyResources(this.tabPageFWHM, "tabPageFWHM");
            this.tabPageFWHM.Name = "tabPageFWHM";
            this.tabPageFWHM.UseVisualStyleBackColor = true;
            // 
            // textBoxFWHM
            // 
            resources.ApplyResources(this.textBoxFWHM, "textBoxFWHM");
            this.textBoxFWHM.Name = "textBoxFWHM";
            // 
            // checkBoxAutoSaveFWHM
            // 
            resources.ApplyResources(this.checkBoxAutoSaveFWHM, "checkBoxAutoSaveFWHM");
            this.checkBoxAutoSaveFWHM.Name = "checkBoxAutoSaveFWHM";
            this.checkBoxAutoSaveFWHM.UseVisualStyleBackColor = true;
            // 
            // tabPageIntensity
            // 
            this.tabPageIntensity.Controls.Add(this.textBoxIntensity);
            this.tabPageIntensity.Controls.Add(this.checkBoxAutoSaveInt);
            resources.ApplyResources(this.tabPageIntensity, "tabPageIntensity");
            this.tabPageIntensity.Name = "tabPageIntensity";
            this.tabPageIntensity.UseVisualStyleBackColor = true;
            // 
            // textBoxIntensity
            // 
            resources.ApplyResources(this.textBoxIntensity, "textBoxIntensity");
            this.textBoxIntensity.Name = "textBoxIntensity";
            // 
            // checkBoxAutoSaveInt
            // 
            resources.ApplyResources(this.checkBoxAutoSaveInt, "checkBoxAutoSaveInt");
            this.checkBoxAutoSaveInt.Name = "checkBoxAutoSaveInt";
            this.checkBoxAutoSaveInt.UseVisualStyleBackColor = true;
            // 
            // tabPageCellConstants
            // 
            this.tabPageCellConstants.Controls.Add(this.textBoxCellConstants);
            this.tabPageCellConstants.Controls.Add(this.checkBoxAutoSaveCell);
            resources.ApplyResources(this.tabPageCellConstants, "tabPageCellConstants");
            this.tabPageCellConstants.Name = "tabPageCellConstants";
            this.tabPageCellConstants.UseVisualStyleBackColor = true;
            // 
            // textBoxCellConstants
            // 
            resources.ApplyResources(this.textBoxCellConstants, "textBoxCellConstants");
            this.textBoxCellConstants.Name = "textBoxCellConstants";
            // 
            // checkBoxAutoSaveCell
            // 
            resources.ApplyResources(this.checkBoxAutoSaveCell, "checkBoxAutoSaveCell");
            this.checkBoxAutoSaveCell.Name = "checkBoxAutoSaveCell";
            this.checkBoxAutoSaveCell.UseVisualStyleBackColor = true;
            // 
            // tabPagePressure
            // 
            this.tabPagePressure.Controls.Add(this.textBoxPressure);
            this.tabPagePressure.Controls.Add(this.checkBoxAutoSavePressure);
            resources.ApplyResources(this.tabPagePressure, "tabPagePressure");
            this.tabPagePressure.Name = "tabPagePressure";
            this.tabPagePressure.UseVisualStyleBackColor = true;
            // 
            // textBoxPressure
            // 
            resources.ApplyResources(this.textBoxPressure, "textBoxPressure");
            this.textBoxPressure.Name = "textBoxPressure";
            // 
            // checkBoxAutoSavePressure
            // 
            resources.ApplyResources(this.checkBoxAutoSavePressure, "checkBoxAutoSavePressure");
            this.checkBoxAutoSavePressure.Name = "checkBoxAutoSavePressure";
            this.checkBoxAutoSavePressure.UseVisualStyleBackColor = true;
            // 
            // tabPageSingh
            // 
            this.tabPageSingh.Controls.Add(this.textBoxSingh);
            this.tabPageSingh.Controls.Add(this.checkBoxAutoSaveSingh);
            this.tabPageSingh.Controls.Add(this.graphControl1);
            resources.ApplyResources(this.tabPageSingh, "tabPageSingh");
            this.tabPageSingh.Name = "tabPageSingh";
            this.tabPageSingh.UseVisualStyleBackColor = true;
            // 
            // textBoxSingh
            // 
            resources.ApplyResources(this.textBoxSingh, "textBoxSingh");
            this.textBoxSingh.Name = "textBoxSingh";
            // 
            // checkBoxAutoSaveSingh
            // 
            resources.ApplyResources(this.checkBoxAutoSaveSingh, "checkBoxAutoSaveSingh");
            this.checkBoxAutoSaveSingh.Name = "checkBoxAutoSaveSingh";
            this.checkBoxAutoSaveSingh.UseVisualStyleBackColor = true;
            // 
            // graphControl1
            // 
            this.graphControl1.AllowMouseOperation = true;
            this.graphControl1.BackgroundColor = System.Drawing.Color.White;
            this.graphControl1.BottomMargin = 0D;
            this.graphControl1.DivisionLineColor = System.Drawing.Color.Gray;
            this.graphControl1.DivisionSubLineColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.graphControl1, "graphControl1");
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
            this.graphControl1.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
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
            // textBoxDirectory
            // 
            resources.ApplyResources(this.textBoxDirectory, "textBoxDirectory");
            this.textBoxDirectory.Name = "textBoxDirectory";
            this.textBoxDirectory.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericBoxStartNumber);
            this.panel1.Controls.Add(this.checkBoxStartNumber);
            this.panel1.Controls.Add(this.textBoxDirectory);
            this.panel1.Controls.Add(this.buttonSetDirectory);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.buttonCopy);
            this.panel1.Controls.Add(this.buttonExecute);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // numericBoxStartNumber
            // 
            this.numericBoxStartNumber.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.numericBoxStartNumber, "numericBoxStartNumber");
            this.numericBoxStartNumber.Minimum = 1D;
            this.numericBoxStartNumber.Name = "numericBoxStartNumber";
            this.numericBoxStartNumber.RadianValue = 0.017453292519943295D;
            this.numericBoxStartNumber.RoundErrorAccuracy = -1;
            this.numericBoxStartNumber.ShowUpDown = true;
            this.numericBoxStartNumber.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxStartNumber.Value = 1D;
            // 
            // checkBoxStartNumber
            // 
            resources.ApplyResources(this.checkBoxStartNumber, "checkBoxStartNumber");
            this.checkBoxStartNumber.Name = "checkBoxStartNumber";
            this.checkBoxStartNumber.UseVisualStyleBackColor = true;
            this.checkBoxStartNumber.CheckedChanged += new System.EventHandler(this.checkBoxStartNumber_CheckedChanged);
            // 
            // buttonSetDirectory
            // 
            resources.ApplyResources(this.buttonSetDirectory, "buttonSetDirectory");
            this.buttonSetDirectory.Name = "buttonSetDirectory";
            this.buttonSetDirectory.UseVisualStyleBackColor = true;
            this.buttonSetDirectory.Click += new System.EventHandler(this.buttonSetDirectory_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // FormSequentialAnalysis
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormSequentialAnalysis";
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.CheckBox checkBoxStartNumber;
        private Crystallography.Controls.NumericBox numericBoxStartNumber;
    }
}