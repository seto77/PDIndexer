using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PDIndexer;

/// <summary>
/// FormAboutMe の概要の説明です。
/// </summary>
public partial class FormAboutMe : System.Windows.Forms.Form
{


    public FormAboutMe()
    {
        InitializeComponent();
    }

    private void buttonOK_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void linkLabelMail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start("mailto:" + linkLabelMail.Text);
        }
        catch { }
    }

    private void FormAboutMe_Load(object sender, System.EventArgs e)
    {
        labelVersion.Text = "PDIndexer   " + Version.VersionAndDate;

        string str = "";

        str += Version.Introduction + "\r\n\r\n";//はじめに
        str += Version.CopyRight + "\r\n\r\n";//著作権
        str += Version.Condition + "\r\n\r\n";//実行条件
        str += Version.Exemption + "\r\n\r\n";//免責
        str += Version.Adress + "\r\n\r\n";//連絡先
        str += Version.Acknowledge + "\r\n\r\n";//謝辞
        str += Version.History;//履歴

        textBoxReadMe.Text += str;
    }

    private void linkLabelHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start(linkLabelHomePage.Text);
        }
        catch { }
    }

    int n;
    private void FormAboutMe_MouseDown(object sender, MouseEventArgs e)
    {
        if (n == 0 && e.Button == MouseButtons.Left)
            n++;
        else if (n == 1 && e.Button == MouseButtons.Left)
            n++;
        else if (n == 2 && e.Button == MouseButtons.Right)
            n++;
        else if (n == 3)
        {
            textBoxReadMe.Text = "隠しコメント\r\n";
            textBoxReadMe.Text += "このソフトはフリーですが、喜んで寄付も申し受けております。\r\nもしこのソフトを使って便利だなぁと感じた方、学会か何かの折にご飯をおごってください。";

            n = 0;

        }
    }
}
