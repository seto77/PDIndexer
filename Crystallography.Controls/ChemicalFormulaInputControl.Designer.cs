﻿namespace Crystallography.Controls
{
    partial class ChemicalFormulaInputControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxElement = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericBoxValence = new Crystallography.Controls.NumericBox();
            this.checkBoxCompound = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanelOxide = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxCompound = new System.Windows.Forms.ComboBox();
            this.textBoxCompoundForm = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelComposition = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelWeight = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.numericBoxWeight = new Crystallography.Controls.NumericBox();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanelMolarRatio = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.numericBoxMolarRatio = new Crystallography.Controls.NumericBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelOxide.SuspendLayout();
            this.flowLayoutPanelComposition.SuspendLayout();
            this.flowLayoutPanelWeight.SuspendLayout();
            this.flowLayoutPanelMolarRatio.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxElement);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.numericBoxValence);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxCompound);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(319, 34);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Element";
            // 
            // comboBoxElement
            // 
            this.comboBoxElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxElement.FormattingEnabled = true;
            this.comboBoxElement.Items.AddRange(new object[] {
            "01:  H",
            "02:  He",
            "03:  Li",
            "04:  Be",
            "05:  B",
            "06:  C",
            "07:  N",
            "08:  O",
            "09:  F",
            "10:  Ne",
            "11:  Na",
            "12:  Mg",
            "13:  Al",
            "14:  Si",
            "15:  P",
            "16:  S",
            "17:  Cl",
            "18:  Ar",
            "19:  K",
            "20:  Ca",
            "21:  Sc",
            "22:  Ti",
            "23:  V",
            "24:  Cr",
            "25:  Mn",
            "26:  Fe",
            "27:  Co",
            "28:  Ni",
            "29:  Cu",
            "30:  Zn",
            "31:  Ga",
            "32:  Ge",
            "33:  As",
            "34:  Se",
            "35:  Br",
            "36:  Kr",
            "37:  Rb",
            "38:  Sr",
            "39:  Y",
            "40:  Zr",
            "41:  Nb",
            "42:  Mo",
            "43:  Tc",
            "44:  Ru",
            "45:  Rh",
            "46:  Pd",
            "47:  Ag",
            "48:  Cd",
            "49:  In",
            "50:  Sn",
            "51:  Sb",
            "52:  Te",
            "53:  I",
            "54:  Xe",
            "55:  Cs",
            "56:  Ba",
            "57:  La",
            "58:  Ce",
            "59:  Pr",
            "60:  Nd",
            "61:  Pm",
            "62:  Sm",
            "63:  Eu",
            "64:  Gd",
            "65:  Tb",
            "66:  Dy",
            "67:  Ho",
            "68:  Er",
            "69:  Tm",
            "70:  Yb",
            "71:  Lu",
            "72:  Hf",
            "73:  Ta",
            "74:  W",
            "75:  Re",
            "76:  Os",
            "77:  Ir",
            "78:  Pt",
            "79:  Au",
            "80:  Hg",
            "81:  Tl",
            "82:  Pb",
            "83:  Bi",
            "84:  Po",
            "85:  At",
            "86:  Rn",
            "87:  Fr",
            "88:  Ra",
            "89:  Ac",
            "90:  Th",
            "91:  Pa",
            "92:  U",
            "93:  Np",
            "94:  Pu",
            "95:  Am",
            "96:  Cm",
            "97:  Bk"});
            this.comboBoxElement.Location = new System.Drawing.Point(65, 4);
            this.comboBoxElement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxElement.Name = "comboBoxElement";
            this.comboBoxElement.Size = new System.Drawing.Size(102, 26);
            this.comboBoxElement.TabIndex = 6;
            this.comboBoxElement.SelectedIndexChanged += new System.EventHandler(this.comboBoxElement_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Valence";
            // 
            // numericBoxValence
            // 
            this.numericBoxValence.AutoSize = true;
            this.numericBoxValence.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxValence.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxValence.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxValence.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxValence.Location = new System.Drawing.Point(222, 4);
            this.numericBoxValence.Margin = new System.Windows.Forms.Padding(0, 4, 1, 2);
            this.numericBoxValence.MaximumSize = new System.Drawing.Size(1000, 25);
            this.numericBoxValence.MinimumSize = new System.Drawing.Size(1, 25);
            this.numericBoxValence.Name = "numericBoxValence";
            this.numericBoxValence.RoundErrorAccuracy = -1;
            this.numericBoxValence.ShowPositiveSign = true;
            this.numericBoxValence.Size = new System.Drawing.Size(1, 25);
            this.numericBoxValence.TabIndex = 8;
            this.numericBoxValence.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxValence.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxValence_ValueChanged);
            // 
            // checkBoxCompound
            // 
            this.checkBoxCompound.AutoSize = true;
            this.checkBoxCompound.Checked = true;
            this.checkBoxCompound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCompound.Location = new System.Drawing.Point(230, 6);
            this.checkBoxCompound.Margin = new System.Windows.Forms.Padding(6, 6, 0, 4);
            this.checkBoxCompound.Name = "checkBoxCompound";
            this.checkBoxCompound.Size = new System.Drawing.Size(89, 22);
            this.checkBoxCompound.TabIndex = 7;
            this.checkBoxCompound.Text = "Compound";
            this.checkBoxCompound.UseVisualStyleBackColor = true;
            this.checkBoxCompound.CheckedChanged += new System.EventHandler(this.checkBoxIsCompound_CheckedChanged);
            // 
            // flowLayoutPanelOxide
            // 
            this.flowLayoutPanelOxide.AutoSize = true;
            this.flowLayoutPanelOxide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelOxide.Controls.Add(this.comboBoxCompound);
            this.flowLayoutPanelOxide.Controls.Add(this.textBoxCompoundForm);
            this.flowLayoutPanelOxide.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelOxide.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelOxide.Name = "flowLayoutPanelOxide";
            this.flowLayoutPanelOxide.Size = new System.Drawing.Size(203, 34);
            this.flowLayoutPanelOxide.TabIndex = 5;
            // 
            // comboBoxCompound
            // 
            this.comboBoxCompound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompound.FormattingEnabled = true;
            this.comboBoxCompound.Items.AddRange(new object[] {
            "O 2-",
            "OH 1-",
            "Cl 1-",
            "F 1-",
            "CO3 2-",
            "BO3 3-",
            "SO4 2-",
            "PO4 2-",
            "Custom"});
            this.comboBoxCompound.Location = new System.Drawing.Point(3, 4);
            this.comboBoxCompound.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxCompound.Name = "comboBoxCompound";
            this.comboBoxCompound.Size = new System.Drawing.Size(79, 26);
            this.comboBoxCompound.TabIndex = 6;
            this.comboBoxCompound.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompound_SelectedIndexChanged);
            // 
            // textBoxCompoundForm
            // 
            this.textBoxCompoundForm.Location = new System.Drawing.Point(88, 4);
            this.textBoxCompoundForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCompoundForm.Name = "textBoxCompoundForm";
            this.textBoxCompoundForm.ReadOnly = true;
            this.textBoxCompoundForm.Size = new System.Drawing.Size(112, 25);
            this.textBoxCompoundForm.TabIndex = 5;
            // 
            // flowLayoutPanelComposition
            // 
            this.flowLayoutPanelComposition.AutoSize = true;
            this.flowLayoutPanelComposition.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelComposition.Controls.Add(this.flowLayoutPanelWeight);
            this.flowLayoutPanelComposition.Controls.Add(this.flowLayoutPanelMolarRatio);
            this.flowLayoutPanelComposition.Location = new System.Drawing.Point(0, 68);
            this.flowLayoutPanelComposition.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelComposition.Name = "flowLayoutPanelComposition";
            this.flowLayoutPanelComposition.Size = new System.Drawing.Size(266, 33);
            this.flowLayoutPanelComposition.TabIndex = 7;
            // 
            // flowLayoutPanelWeight
            // 
            this.flowLayoutPanelWeight.AutoSize = true;
            this.flowLayoutPanelWeight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelWeight.Controls.Add(this.label6);
            this.flowLayoutPanelWeight.Controls.Add(this.numericBoxWeight);
            this.flowLayoutPanelWeight.Controls.Add(this.label9);
            this.flowLayoutPanelWeight.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelWeight.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelWeight.Name = "flowLayoutPanelWeight";
            this.flowLayoutPanelWeight.Size = new System.Drawing.Size(145, 31);
            this.flowLayoutPanelWeight.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 8, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Weight";
            // 
            // numericBoxWeight
            // 
            this.numericBoxWeight.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxWeight.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxWeight.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxWeight.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxWeight.Location = new System.Drawing.Point(51, 4);
            this.numericBoxWeight.Margin = new System.Windows.Forms.Padding(0, 4, 1, 0);
            this.numericBoxWeight.MaximumSize = new System.Drawing.Size(1000, 27);
            this.numericBoxWeight.MinimumSize = new System.Drawing.Size(1, 25);
            this.numericBoxWeight.Name = "numericBoxWeight";
            this.numericBoxWeight.RoundErrorAccuracy = -1;
            this.numericBoxWeight.Size = new System.Drawing.Size(73, 27);
            this.numericBoxWeight.TabIndex = 8;
            this.numericBoxWeight.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(125, 8);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 18);
            this.label9.TabIndex = 1;
            this.label9.Text = "%";
            // 
            // flowLayoutPanelMolarRatio
            // 
            this.flowLayoutPanelMolarRatio.AutoSize = true;
            this.flowLayoutPanelMolarRatio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMolarRatio.Controls.Add(this.label7);
            this.flowLayoutPanelMolarRatio.Controls.Add(this.numericBoxMolarRatio);
            this.flowLayoutPanelMolarRatio.Location = new System.Drawing.Point(145, 0);
            this.flowLayoutPanelMolarRatio.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelMolarRatio.Name = "flowLayoutPanelMolarRatio";
            this.flowLayoutPanelMolarRatio.Size = new System.Drawing.Size(121, 33);
            this.flowLayoutPanelMolarRatio.TabIndex = 5;
            this.flowLayoutPanelMolarRatio.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Molar ratio";
            // 
            // numericBoxMolarRatio
            // 
            this.numericBoxMolarRatio.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMolarRatio.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxMolarRatio.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMolarRatio.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxMolarRatio.Location = new System.Drawing.Point(77, 4);
            this.numericBoxMolarRatio.Margin = new System.Windows.Forms.Padding(0, 4, 1, 2);
            this.numericBoxMolarRatio.MaximumSize = new System.Drawing.Size(1000, 27);
            this.numericBoxMolarRatio.MinimumSize = new System.Drawing.Size(1, 25);
            this.numericBoxMolarRatio.Name = "numericBoxMolarRatio";
            this.numericBoxMolarRatio.RoundErrorAccuracy = -1;
            this.numericBoxMolarRatio.Size = new System.Drawing.Size(43, 27);
            this.numericBoxMolarRatio.TabIndex = 8;
            this.numericBoxMolarRatio.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanelComposition);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(319, 101);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanelOxide);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 34);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(203, 34);
            this.flowLayoutPanel4.TabIndex = 6;
            // 
            // ChemicalFormulaInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanel3);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChemicalFormulaInputControl";
            this.Size = new System.Drawing.Size(325, 107);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanelOxide.ResumeLayout(false);
            this.flowLayoutPanelOxide.PerformLayout();
            this.flowLayoutPanelComposition.ResumeLayout(false);
            this.flowLayoutPanelComposition.PerformLayout();
            this.flowLayoutPanelWeight.ResumeLayout(false);
            this.flowLayoutPanelWeight.PerformLayout();
            this.flowLayoutPanelMolarRatio.ResumeLayout(false);
            this.flowLayoutPanelMolarRatio.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxElement;
        private System.Windows.Forms.Label label5;
        private NumericBox numericBoxValence;
        private System.Windows.Forms.CheckBox checkBoxCompound;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOxide;
        private System.Windows.Forms.ComboBox comboBoxCompound;
        private System.Windows.Forms.TextBox textBoxCompoundForm;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelComposition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelWeight;
        private System.Windows.Forms.Label label6;
        private NumericBox numericBoxWeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMolarRatio;
        private System.Windows.Forms.Label label7;
        private NumericBox numericBoxMolarRatio;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    }
}
