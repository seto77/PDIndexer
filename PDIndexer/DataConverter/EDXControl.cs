using System.Windows.Forms;
using System.ComponentModel;

namespace PDIndexer
{
    public partial class EDXControl : UserControl
    {

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Valid { get => checkBox1.Checked; set => checkBox1.Checked = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DetectorName { get => checkBox1.Text; set => checkBox1.Text = value; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CheckBoxVisible { get => checkBox1.Visible; set => checkBox1.Visible = value; }

        public EDXControl()
        {
            InitializeComponent();
        }
    }
}
