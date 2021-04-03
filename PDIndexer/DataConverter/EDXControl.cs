using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDIndexer
{
    public partial class EDXControl : UserControl
    {

        public double[] EGC
        {
            get => new[] { numericBoxEGC0.Value, numericBoxEGC1.Value, numericBoxEGC2.Value };
            set
            {
                if (value != null && value.Length == 3)
                {
                    numericBoxEGC0.Value = value[0];
                    numericBoxEGC1.Value = value[1];
                    numericBoxEGC2.Value = value[2];
                }
            }
        }

        public bool Valid { get => checkBox1.Checked; set => checkBox1.Checked = value; }

        public string DetectorName { get => checkBox1.Text; set => checkBox1.Text = value; }

        public bool CheckBoxVisible { get => checkBox1.Visible; set => checkBox1.Visible = value; }

        public EDXControl()
        {
            InitializeComponent();
        }
    }
}
