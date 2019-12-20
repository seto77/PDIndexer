using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PDIndexer
{
    public partial class FormPrintOption : Form
    {
        public FormPrintOption()
        {
            InitializeComponent();
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
