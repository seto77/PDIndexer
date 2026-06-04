using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDIndexer
{
    public partial class FormLimitChanger : FormBase //260604Cl Form→FormBase (F1ヘルプ対応)
    {
        public FormLimitChanger()
        {
            InitializeComponent();
            HelpPage = "1-main-window"; //260604Cl 追加: F1で該当オンラインマニュアルを開く
        }

        private void FormLimitChanger_Load(object sender, EventArgs e)
        {

        }
    }
}
