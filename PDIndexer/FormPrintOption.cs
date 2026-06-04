using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDIndexer
{
    public partial class FormPrintOption : FormBase //260604Cl Form→FormBase (F1ヘルプ対応)
    {
        public FormPrintOption()
        {
            InitializeComponent();
            HelpPage = "appendix/file-formats"; //260604Cl 追加: F1で該当オンラインマニュアルを開く
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxPrintProfileName_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Enabled = checkBoxPrintProfileName.Checked;
        }
    }
}
