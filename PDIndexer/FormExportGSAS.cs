using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crystallography;
using System.IO;

namespace PDIndexer
{
   


    public partial class FormExportGSAS : FormBase //260604Cl Form→FormBase (F1ヘルプ対応)
    {
        public FormMain formMain;
        //private  DiffractionProfile2 profile; //260317Cl 未使用フィールドをコメントアウト
        private void FormExportGSAS_Load(object sender, EventArgs e)
        {
            setGsasFileContents();
        }
        public FormExportGSAS()
        {
            InitializeComponent();
            HelpPage = "appendix/file-formats"; //260604Cl 追加: F1で該当オンラインマニュアルを開く
        }

        private void setGsasFileContents()
        {
            double div = 100;
            if (formMain.AxisMode == HorizontalAxis.NeutronTOF)
                div = 1;

            DiffractionProfile2 dp = (DiffractionProfile2)((DataRowView)formMain.bindingSourceProfile.Current).Row[1];
            StringBuilder sb = new(dp.Profile.Pt.Count * 38 + 128); //260712Cl 初期容量指定 (1点=38文字×点数): 内部バッファの倍々再確保を回避

            //一行目
            string str = dp.Name;
            sb.Append(str + "\r\n");

            //二行目
            int ptCount = dp.Profile.Pt.Count;
            double startAngle = dp.Profile.Pt[0].X * div;
            double stepAngle = (dp.Profile.Pt[1].X - dp.Profile.Pt[0].X) * div;
            str = $"BANK 1 {ptCount} {ptCount} CONST {startAngle:f2} {stepAngle:f2} 0 0 FXYE"; //260317Cl 文字列連結 → 文字列補間
            sb.Append(str + "\r\n");
            str = "";
            bool validErr = false;
            if (dp.Profile.Err != null && dp.Profile.Err.Count == dp.Profile.Pt.Count)
                for (int i = 0; i < ptCount; i++)
                    if (dp.Profile.Err[i].IsNaN && dp.Profile.Err[i].Y != 0)
                    {
                        validErr = true;
                        break;
                    }
            var value = new string[3]; //260712Cl ループ外へ巻き上げ (毎周の配列割り当てを削減)
            for (int i = 0; i < ptCount; i++)
            {
                value[0] = (dp.Profile.Pt[i].X * div).ToString("g12");
                value[1] = dp.Profile.Pt[i].Y.ToString("g12");
                if (validErr)
                    value[2] = dp.Profile.Err[i].Y.ToString("g12");
                else
                    value[2] = Math.Sqrt(dp.Profile.Pt[i].Y).ToString("g12");

                string y = dp.Profile.Pt[i].Y.ToString("g7");

                for (int j = 0; j < value.Length; j++)
                {
                    if (value[j].Length > 11)
                        value[j] = value[j][..11]; //260712Cl 範囲演算子
                    if (value[j].EndsWith('.'))
                        value[j] = " " + y[..10]; //260712Cl
                    value[j] = value[j].PadLeft(11); //260712Cl while の逐次連結 (最大10回のstring生成) を一括パディングに
                }
                sb.Append(' ').Append(value[0]).Append(' ').Append(value[1]).Append(' ').Append(value[2]).Append("\r\n"); //260712Cl 中間文字列の生成を回避
                
            }
            richTextBoxGsa.Text = sb.ToString();
            #region
            /*         StringBuilder sb = new StringBuilder();
                     DiffractionProfile dp = (DiffractionProfile)((DataRowView)formMain.bindingSourceProfile.Current).Row[1]; ;

                     //一行目
                     string str = dp.Name;
                     while (str.Length < 80)
                         str += " ";
                     sb.Append(str+"\r\n");

                     //二行目
                     int ptCount = dp.Profile.Pt.Count;
                     double startAngle = dp.Profile.Pt[0].X * 100;
                     double stepAngle = (dp.Profile.Pt[1].X - dp.Profile.Pt[0].X) * 100;
                     str = $"BANK 1 {ptCount} {ptCount / 5} CONST {startAngle:f2} {stepAngle:f2} 0 0 ESD"; //260317Cl 文字列連結 → 文字列補間
                     while (str.Length < 80)
                         str += " ";
                     sb.Append(str + "\r\n");
                     str = "";
                     int n = 0;
                     for (int i = 0; i < ptCount; i++)
                     {
                         n++;
                         string y = dp.Profile.Pt[i].Y.ToString("g7");
                         string yErr = Math.Sqrt(dp.Profile.Pt[i].Y).ToString("g8");
                         if (y.Length > 7)
                             y = y.Substring(0, 7);
                         if (y.EndsWith("."))
                             y = " " + y.Substring(0, 6);
                         while (y.Length < 7)
                             y = " " + y;

                         if (yErr.Length > 7)
                             yErr = yErr.Substring(0, 7);
                         if (yErr.EndsWith("."))
                             yErr = " " + yErr.Substring(0, 6);
                         while (yErr.Length < 7)
                             yErr = " " + yErr;

                         str += " " + y + " " + yErr;
                         if (n == 5)
                         {
                             sb.Append(str + "\r\n");
                             str = "";
                             n = 0;
                         }
                         else if (i == ptCount - 1)
                         {
                             while (str.Length < 80)
                                 str += " ";
                             sb.Append(str + "\r\n");
                         }
                     }
                     richTextBoxGsa.Text = sb.ToString();*/
            #endregion
        }
 
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "*.exp|*.exp";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                textBoxExpFilePath.Text = dlg.FileName;
            else
                textBoxExpFilePath.Text = "";
        }

        private void textBoxExpFilePath_TextChanged(object sender, EventArgs e)
        {
            if(File.Exists(textBoxExpFilePath.Text))
            {
                using var sr = new StreamReader(textBoxExpFilePath.Text); //260712Cl ファイルハンドルリーク対策 (using 宣言)
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                   richTextBoxExp.AppendText(str+"\r\n");
                }
            }
        }


        private const string atmdat = "";


    }
}
