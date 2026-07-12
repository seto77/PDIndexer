using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PDIndexer;

/// <summary>
/// FormAboutMe の概要の説明です。
/// </summary>
public partial class FormAboutMe : FormBase //260604Cl Form→FormBase (F1ヘルプ対応)
{


    public FormAboutMe()
    {
        InitializeComponent();
        HelpPage = "appendix/runtime-and-installation"; //260604Cl 追加: F1で該当オンラインマニュアルを開く
    }

    private void buttonOK_Click(object sender, System.EventArgs e)
    {
        this.Close();
    }

    private void linkLabelMail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("mailto:" + linkLabelMail.Text) { UseShellExecute = true }); //260712Cl バグ修正: 旧 Process.Start(string)。.NET Core以降は UseShellExecute=false 既定でmailtoを開けず空catchで握り潰されていた (FormMain:4008と同方針)
        }
        catch { }
    }

    private void FormAboutMe_Load(object sender, System.EventArgs e)
    {
        labelVersion.Text = "PDIndexer   " + Version.VersionAndDate;

        // 260712Cl 記法近代化: 7回の str += 連結を string.Join 1式に集約
        textBoxReadMe.Text += string.Join("\r\n\r\n",
            Version.Introduction, Version.CopyRight, Version.Condition,
            Version.Exemption, Version.Adress, Version.Acknowledge, Version.History);//はじめに/著作権/実行条件/免責/連絡先/謝辞/履歴
    }

    private void linkLabelHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(linkLabelHomePage.Text) { UseShellExecute = true }); //260712Cl バグ修正: 旧 Process.Start(string) はURLを開けず無反応 (FormMain:4008と同方針)
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
