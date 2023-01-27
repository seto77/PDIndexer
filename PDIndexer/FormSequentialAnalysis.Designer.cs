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
            // textBoxDirectory
            // 
            resources.ApplyResources(textBoxDirectory, "textBoxDirectory");
            textBoxDirectory.Name = "textBoxDirectory";
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