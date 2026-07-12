using System; //260712Cl Math.Clamp用
using System.Windows.Forms;

namespace PDIndexer;

public partial class UserControlIonicRadius : UserControl
{
    public UserControlIonicRadius()
    {
        InitializeComponent();
    }


    public double Radius
    {
        set
        {
            numericUpDownRadius.Value = Math.Clamp((decimal)value * 10, numericUpDownRadius.Minimum, numericUpDownRadius.Maximum); //260712Cl Math.Clampでクランプ
        }
        get => (double)numericUpDownRadius.Value / 10;
    }

    public string Element { set => labelElement.Text = value; get => labelElement.Text; }

    public int AtomicNumber { get; set; } //260712Cl 自動プロパティ化


}
