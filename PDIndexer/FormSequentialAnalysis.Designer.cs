using System.Windows.Forms;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSequentialAnalysis));
            buttonExecute = new Button();
            textBox2theta = new TextBox();
            tabControl = new TabControl();
            tabPage2theta = new TabPage();
            checkBoxAutoSaveTwoTheta = new CheckBox();
            tabPageDspacing = new TabPage();
            textBoxDspacing = new TextBox();
            checkBoxAutoSaveD = new CheckBox();
            tabPageFWHM = new TabPage();
            textBoxFWHM = new TextBox();
            checkBoxAutoSaveFWHM = new CheckBox();
            tabPageIntensity = new TabPage();
            textBoxIntensity = new TextBox();
            checkBoxAutoSaveInt = new CheckBox();
            tabPageCellConstants = new TabPage();
            textBoxCellConstants = new TextBox();
            checkBoxAutoSaveCell = new CheckBox();
            tabPagePressure = new TabPage();
            textBoxPressure = new TextBox();
            checkBoxAutoSavePressure = new CheckBox();
            tabPageSingh = new TabPage();
            textBoxSingh = new TextBox();
            checkBoxAutoSaveSingh = new CheckBox();
            graphControl1 = new Crystallography.Controls.GraphControl();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            buttonCopy = new Button();
            buttonSave = new Button();
            textBoxDirectory = new TextBox();
            panel1 = new Panel();
            numericBoxToleranceFactor = new Crystallography.Controls.NumericBox();
            numericBoxStartNumber = new Crystallography.Controls.NumericBox();
            checkBoxLoop = new CheckBox();
            checkBoxToleranceFactor = new CheckBox();
            checkBoxStartNumber = new CheckBox();
            buttonSetDirectory = new Button();
            label1 = new Label();
            bindingSource1 = new BindingSource(components);
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
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
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
            tabControl.Controls.Add(tabPage2theta);
            tabControl.Controls.Add(tabPageDspacing);
            tabControl.Controls.Add(tabPageFWHM);
            tabControl.Controls.Add(tabPageIntensity);
            tabControl.Controls.Add(tabPageCellConstants);
            tabControl.Controls.Add(tabPagePressure);
            tabControl.Controls.Add(tabPageSingh);
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            // 
            // tabPage2theta
            // 
            tabPage2theta.Controls.Add(textBox2theta);
            tabPage2theta.Controls.Add(checkBoxAutoSaveTwoTheta);
            resources.ApplyResources(tabPage2theta, "tabPage2theta");
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
            tabPageDspacing.Controls.Add(textBoxDspacing);
            tabPageDspacing.Controls.Add(checkBoxAutoSaveD);
            resources.ApplyResources(tabPageDspacing, "tabPageDspacing");
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
            tabPageFWHM.Controls.Add(textBoxFWHM);
            tabPageFWHM.Controls.Add(checkBoxAutoSaveFWHM);
            resources.ApplyResources(tabPageFWHM, "tabPageFWHM");
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
            tabPageIntensity.Controls.Add(textBoxIntensity);
            tabPageIntensity.Controls.Add(checkBoxAutoSaveInt);
            resources.ApplyResources(tabPageIntensity, "tabPageIntensity");
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
            tabPageCellConstants.Controls.Add(textBoxCellConstants);
            tabPageCellConstants.Controls.Add(checkBoxAutoSaveCell);
            resources.ApplyResources(tabPageCellConstants, "tabPageCellConstants");
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
            tabPagePressure.Controls.Add(textBoxPressure);
            tabPagePressure.Controls.Add(checkBoxAutoSavePressure);
            resources.ApplyResources(tabPagePressure, "tabPagePressure");
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
            tabPageSingh.Controls.Add(textBoxSingh);
            tabPageSingh.Controls.Add(checkBoxAutoSaveSingh);
            tabPageSingh.Controls.Add(graphControl1);
            resources.ApplyResources(tabPageSingh, "tabPageSingh");
            tabPageSingh.Name = "tabPageSingh";
            tabPageSingh.UseVisualStyleBackColor = true;
            // 
            // textBoxSingh
            // 
            resources.ApplyResources(textBoxSingh, "textBoxSingh");
            textBoxSingh.Name = "textBoxSingh";
            // 
            // checkBoxAutoSaveSingh
            // 
            resources.ApplyResources(checkBoxAutoSaveSingh, "checkBoxAutoSaveSingh");
            checkBoxAutoSaveSingh.Name = "checkBoxAutoSaveSingh";
            checkBoxAutoSaveSingh.UseVisualStyleBackColor = true;
            // 
            // graphControl1
            // 
            graphControl1.AllowMouseOperation = true;
            graphControl1.BackgroundColor = System.Drawing.Color.White;
            graphControl1.BottomMargin = 0D;
            graphControl1.DivisionLineColor = System.Drawing.Color.Gray;
            resources.ApplyResources(graphControl1, "graphControl1");
            graphControl1.FixRangeHorizontal = false;
            graphControl1.FixRangeVertical = false;
            graphControl1.Interpolation = false;
            graphControl1.IsIntegerX = false;
            graphControl1.IsIntegerY = false;
            graphControl1.LabelX = "X:";
            graphControl1.LabelY = "Y:";
            graphControl1.LeftMargin = 0F;
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
            graphControl1.UnitX = "";
            graphControl1.UnitY = "";
            graphControl1.UpperX = 1D;
            graphControl1.UpperY = 1D;
            graphControl1.UseLineWidth = true;
            graphControl1.XLog = false;
            graphControl1.YLog = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            resources.ApplyResources(statusStrip1, "statusStrip1");
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
            // textBoxDirectory
            // 
            resources.ApplyResources(textBoxDirectory, "textBoxDirectory");
            textBoxDirectory.Name = "textBoxDirectory";
            textBoxDirectory.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(numericBoxToleranceFactor);
            panel1.Controls.Add(numericBoxStartNumber);
            panel1.Controls.Add(checkBoxLoop);
            panel1.Controls.Add(checkBoxToleranceFactor);
            panel1.Controls.Add(checkBoxStartNumber);
            panel1.Controls.Add(textBoxDirectory);
            panel1.Controls.Add(buttonSetDirectory);
            panel1.Controls.Add(buttonSave);
            panel1.Controls.Add(buttonCopy);
            panel1.Controls.Add(buttonExecute);
            panel1.Controls.Add(label1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // numericBoxToleranceFactor
            // 
            numericBoxToleranceFactor.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(numericBoxToleranceFactor, "numericBoxToleranceFactor");
            numericBoxToleranceFactor.Maximum = 100D;
            numericBoxToleranceFactor.Minimum = 0D;
            numericBoxToleranceFactor.Name = "numericBoxToleranceFactor";
            numericBoxToleranceFactor.RadianValue = 0.17453292519943295D;
            numericBoxToleranceFactor.RoundErrorAccuracy = -1;
            numericBoxToleranceFactor.ShowUpDown = true;
            numericBoxToleranceFactor.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxToleranceFactor.Value = 10D;
            // 
            // numericBoxStartNumber
            // 
            numericBoxStartNumber.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(numericBoxStartNumber, "numericBoxStartNumber");
            numericBoxStartNumber.Minimum = 1D;
            numericBoxStartNumber.Name = "numericBoxStartNumber";
            numericBoxStartNumber.RadianValue = 0.017453292519943295D;
            numericBoxStartNumber.RoundErrorAccuracy = -1;
            numericBoxStartNumber.ShowUpDown = true;
            numericBoxStartNumber.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericBoxStartNumber.Value = 1D;
            // 
            // checkBoxLoop
            // 
            resources.ApplyResources(checkBoxLoop, "checkBoxLoop");
            checkBoxLoop.Checked = true;
            checkBoxLoop.CheckState = CheckState.Checked;
            checkBoxLoop.Name = "checkBoxLoop";
            checkBoxLoop.UseVisualStyleBackColor = true;
            checkBoxLoop.CheckedChanged += checkBoxStartNumber_CheckedChanged;
            // 
            // checkBoxToleranceFactor
            // 
            resources.ApplyResources(checkBoxToleranceFactor, "checkBoxToleranceFactor");
            checkBoxToleranceFactor.Name = "checkBoxToleranceFactor";
            checkBoxToleranceFactor.UseVisualStyleBackColor = true;
            checkBoxToleranceFactor.CheckedChanged += checkBoxStartNumber_CheckedChanged;
            // 
            // checkBoxStartNumber
            // 
            resources.ApplyResources(checkBoxStartNumber, "checkBoxStartNumber");
            checkBoxStartNumber.Name = "checkBoxStartNumber";
            checkBoxStartNumber.UseVisualStyleBackColor = true;
            checkBoxStartNumber.CheckedChanged += checkBoxStartNumber_CheckedChanged;
            // 
            // buttonSetDirectory
            // 
            resources.ApplyResources(buttonSetDirectory, "buttonSetDirectory");
            buttonSetDirectory.Name = "buttonSetDirectory";
            buttonSetDirectory.UseVisualStyleBackColor = true;
            buttonSetDirectory.Click += buttonSetDirectory_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // FormSequentialAnalysis
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
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
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPageCellConstants;
        private System.Windows.Forms.TabPage tabPagePressure;
        private System.Windows.Forms.TextBox textBoxCellConstants;
        private System.Windows.Forms.TextBox textBoxPressure;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSetDirectory;
        private System.Windows.Forms.CheckBox checkBoxStartNumber;
        private Crystallography.Controls.NumericBox numericBoxStartNumber;
        private System.Windows.Forms.CheckBox checkBoxLoop;
        private Crystallography.Controls.NumericBox numericBoxToleranceFactor;
        private System.Windows.Forms.CheckBox checkBoxToleranceFactor;
        private System.Windows.Forms.BindingSource bindingSource1;
        public CheckBox checkBoxAutoSaveTwoTheta;
        public CheckBox checkBoxAutoSaveD;
        public CheckBox checkBoxAutoSaveFWHM;
        public CheckBox checkBoxAutoSaveInt;
        public CheckBox checkBoxAutoSaveCell;
        public CheckBox checkBoxAutoSavePressure;
        public CheckBox checkBoxAutoSaveSingh;
        public TextBox textBoxDirectory;
    }
}