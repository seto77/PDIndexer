﻿using System.Windows.Forms;

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
            if ((decimal)value * 10 > numericUpDownRadius.Maximum)
                numericUpDownRadius.Value = numericUpDownRadius.Maximum;
            else if ((decimal)value * 10 < numericUpDownRadius.Minimum)
                numericUpDownRadius.Value = numericUpDownRadius.Minimum;
            else
                numericUpDownRadius.Value = (decimal)value * 10;
        }
        get => (double)numericUpDownRadius.Value / 10;
    }

    public string Element { set => labelElement.Text = value; get => labelElement.Text; }

    private int atomicNumber = 0;
    public int AtomicNumber { set => atomicNumber = value; get => atomicNumber; }


}
