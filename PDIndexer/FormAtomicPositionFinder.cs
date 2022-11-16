using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Crystallography;
using Crystallography.Controls;
using System.Diagnostics;

namespace PDIndexer
{
    public partial class FormAtomicPositionFinder : Form
    {
        public int Step = 0;

        public FormMain formMain;

        public List<NumericBox> numericTexBox = new List<NumericBox>();
        public List<Label> label = new List<Label>();

        public FormAtomicPositionFinder()
        {
            InitializeComponent();

            #region 化学組成タブのコントロール類を配置する
            int startX = 0;
            int startY = 20;
            int intervalX = 49;
            int intervalY = 20;
            labelLanthanoid1.Font = labelLanthanoid2.Font = labelActinoid1.Font = labelActinoid2.Font =
                new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            for (int i = 0; i < 112; i++)
            {
                numericTexBox.Add(new NumericBox());
                label.Add(new Label());
                numericTexBox[i].Size = new Size(29, 20);
                label[i].Size = new Size(22, 20);
                label[i].ForeColor = Color.Blue; ;
                numericTexBox[i].Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label[i].Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label[i].TextAlign = ContentAlignment.MiddleRight;

                if (i != 0)
                {
                    this.tabPage2.Controls.Add(numericTexBox[i]);
                    this.tabPage2.Controls.Add(label[i]);
                    numericTexBox[i].ValueChanged += new NumericBox.MyEventHandler(numerictextBoxElement_ValueChanged);
                }
            }

            label[1].Location = new Point(startX, startY);//H
            label[2].Location = new Point(startX + intervalX * 17, startY);//He
            label[3].Location = new Point(startX, startY + intervalY);//Li
            label[4].Location = new Point(intervalX, startY + intervalY);//Be
            for (int i = 05; i <= 10; i++) label[i].Location = new Point(startX + (i + 7) * intervalX, startY + intervalY);//B~Ne
            for (int i = 11; i <= 12; i++) label[i].Location = new Point(startX + (i - 11) * intervalX, startY + intervalY * 2);//Na~Mg
            for (int i = 13; i <= 18; i++) label[i].Location = new Point(startX + (i - 1) * intervalX, startY + intervalY * 2);//Al~Ar
            for (int i = 19; i <= 36; i++) label[i].Location = new Point(startX + (i - 19) * intervalX, startY + intervalY * 3);//K~Kr
            for (int i = 37; i <= 54; i++) label[i].Location = new Point(startX + (i - 37) * intervalX, startY + intervalY * 4);//Rb~Xe
            for (int i = 55; i <= 56; i++) label[i].Location = new Point(startX + (i - 55) * intervalX, startY + intervalY * 5);//Cs~Ba
            labelLanthanoid1.Location = new Point(startX + (int)(intervalX * 2.5), startY + intervalY * 5);
            for (int i = 72; i <= 86; i++) label[i].Location = new Point(startX + (i - 69) * intervalX, startY + intervalY * 5);//Hf~Rn
            for (int i = 87; i <= 88; i++) label[i].Location = new Point(startX + (i - 87) * intervalX, startY + intervalY * 6);//Fr~Ra
            labelActinoid1.Location = new Point(startX + (int)(intervalX * 2.5), startY + intervalY * 6);
            for (int i = 104; i <= 111; i++) label[i].Location = new Point(startX + (i - 101) * intervalX, startY + intervalY * 6);//Rf~Rg

            labelLanthanoid2.Location = new Point(startX + (int)(intervalX * 1.5), startY + intervalY * 7 + 5);
            for (int i = 57; i <= 71; i++) label[i].Location = new Point(startX + (i - 54) * intervalX, startY + intervalY * 7 + 5);//La~Lu
            labelActinoid2.Location = new Point(startX + (int)(intervalX * 1.5), startY + intervalY * 8 + 5);
            for (int i = 89; i <= 103; i++) label[i].Location = new Point(startX + (i - 86) * intervalX, startY + intervalY * 8 + 5);//Ac~Lr

            for (int i = 0; i <= 111; i++)
                numericTexBox[i].Location = new Point(label[i].Location.X + label[i].Width + 2, label[i].Location.Y);

            #region テキストの設定
            label[1].Text = "H";
            label[2].Text = "He";
            label[3].Text = "Li";
            label[4].Text = "Be";
            label[5].Text = "B";
            label[6].Text = "C";
            label[7].Text = "N";
            label[8].Text = "O";
            label[9].Text = "F";
            label[10].Text = "Ne";
            label[11].Text = "Na";
            label[12].Text = "Mg";
            label[13].Text = "Al";
            label[14].Text = "Si";
            label[15].Text = "P";
            label[16].Text = "S";
            label[17].Text = "Cl";
            label[18].Text = "Ar";
            label[19].Text = "K";
            label[20].Text = "Ca";
            label[21].Text = "Sc";
            label[22].Text = "Ti";
            label[23].Text = "V";
            label[24].Text = "Cr";
            label[25].Text = "Mn";
            label[26].Text = "Fe";
            label[27].Text = "Co";
            label[28].Text = "Ni";
            label[29].Text = "Cu";
            label[30].Text = "Zn";
            label[31].Text = "Ga";
            label[32].Text = "Ge";
            label[33].Text = "As";
            label[34].Text = "Se";
            label[35].Text = "Br";
            label[36].Text = "Kr";
            label[37].Text = "Rb";
            label[38].Text = "Sr";
            label[39].Text = "Y";
            label[40].Text = "Zr";
            label[41].Text = "Nb";
            label[42].Text = "Mo";
            label[43].Text = "Tc";
            label[44].Text = "Ru";
            label[45].Text = "Rh";
            label[46].Text = "Pd";
            label[47].Text = "Ag";
            label[48].Text = "Cd";
            label[49].Text = "In";
            label[50].Text = "Sn";
            label[51].Text = "Sb";
            label[52].Text = "Te";
            label[53].Text = "I";
            label[54].Text = "Xe";
            label[55].Text = "Cs";
            label[56].Text = "Ba";
            label[57].Text = "La";
            label[58].Text = "Ce";
            label[59].Text = "Pr";
            label[60].Text = "Nd";
            label[61].Text = "Pm";
            label[62].Text = "Sm";
            label[63].Text = "Eu";
            label[64].Text = "Gd";
            label[65].Text = "Tb";
            label[66].Text = "Dy";
            label[67].Text = "Ho";
            label[68].Text = "Er";
            label[69].Text = "Tm";
            label[70].Text = "Yb";
            label[71].Text = "Lu";
            label[72].Text = "Hf";
            label[73].Text = "Ta";
            label[74].Text = "W";
            label[75].Text = "Re";
            label[76].Text = "Os";
            label[77].Text = "Ir";
            label[78].Text = "Pt";
            label[79].Text = "Au";
            label[80].Text = "Hg";
            label[81].Text = "Tl";
            label[82].Text = "Pb";
            label[83].Text = "Bi";
            label[84].Text = "Po";
            label[85].Text = "At";
            label[86].Text = "Rn";
            label[87].Text = "Fr";
            label[88].Text = "Ra";
            label[89].Text = "Ac";
            label[90].Text = "Th";
            label[91].Text = "Pa";
            label[92].Text = "U";
            label[93].Text = "Np";
            label[94].Text = "Pu";
            label[95].Text = "Am";
            label[96].Text = "Cm";
            label[97].Text = "Bk";
            label[98].Text = "Cf";
            label[99].Text = "Es";
            label[100].Text = "Fm";
            label[101].Text = "Md";
            label[102].Text = "No";
            label[103].Text = "Lr";
            label[104].Text = "Rf";
            label[105].Text = "Db";
            label[106].Text = "Sg";
            label[107].Text = "Bh";
            label[108].Text = "Hs";
            label[109].Text = "Mt";
            label[110].Text = "Ds";
            label[111].Text = "Rg";

            #endregion

            #endregion

            graphControl1.ClearProfile();
            top1.Color = Color.Red;
            graphControl1.AddProfile(top1);
            top10.Color = Color.Blue;
            graphControl1.AddProfile(top10);
            top100.Color = Color.Green;
            graphControl1.AddProfile(top100);
        }


        #region 化学組成入力テキストボックスが変更されたとき
        bool stopCycling = false;
        //原子の数を指定するテキストボックスが変更されたとき
        void numerictextBoxElement_ValueChanged(object sender, EventArgs e)
        {
            if (stopCycling) return;
            stopCycling = true;

            List<int> constituentsList = new List<int>();
            double max = 0;
            for (int i = 0; i < numericTexBox.Count; i++)
                if (numericTexBox[i].Value != 0)
                {
                    constituentsList.Add(i);
                    max = Math.Max(max, numericTexBox[i].Value);
                }

            int z = 1;
            for (int i = (int)max; i >= 2; i--)
            {
                bool reducible = true;
                for (int j = 0; j < constituentsList.Count; j++)
                    if (numericTexBox[constituentsList[j]].Value % i != 0)
                        reducible = false;
                if (reducible)
                {
                    z = i;
                    break;
                }
            }

            string formula = "";
            string formulaInUnitCell = "";
            for (int i = 0; i < constituentsList.Count; i++)
            {

                if (formula != "") formula += " ";
                if (numericTexBox[constituentsList[i]].Value / z == 1)
                    formula += label[constituentsList[i]].Text;
                else
                    formula += label[constituentsList[i]].Text + (numericTexBox[constituentsList[i]].Value / z).ToString();

                if (formulaInUnitCell != "") formulaInUnitCell += " ";
                if (numericTexBox[constituentsList[i]].Value == 1)
                    formulaInUnitCell += label[constituentsList[i]].Text;
                else
                    formulaInUnitCell += label[constituentsList[i]].Text + (numericTexBox[constituentsList[i]].Value).ToString();


            }
            textBoxInputFormula.Text = formula;
            textBoxFormula.Text = formulaInUnitCell;
            numericUpDownZ.Value = (decimal)z;
            stopCycling = false;

        }


        private void textBoxInputFormula_TextChanged(object sender, EventArgs e)
        {
            if (stopCycling) return;
            stopCycling = true;

            //入力された文字列から化学組成を割り出す

            //まず数字と原子の間にスペースをいれる
            string inputFormula = textBoxInputFormula.Text;
            for (int i = 0; i < inputFormula.Length - 1; i++)
                if ('0' <= inputFormula[i] && '9' >= inputFormula[i] && 'A' <= inputFormula[i + 1] && 'z' >= inputFormula[i + 1])
                    inputFormula = inputFormula.Insert(i + 1, " ");//数字とアルファベットが並んでいたらスペースを挿入

            //スペース区切りで分割
            List<string> dividedFormula = new List<string>(inputFormula.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            List<object> temp2 = new List<object>();

            //文字列が2つ以上の元素名で構成されていたら分割
            for (int i = 0; i < dividedFormula.Count; i++)
            {
                if ('A' <= dividedFormula[i][0] && 'z' >= dividedFormula[i][0])//最初がアルファベットで始まっていたら
                {
                    bool flag = false;
                    for (int j = dividedFormula[i].Length; j > 0 && flag == false; j--)
                        for (int k = 0; k < label.Count; k++)
                            if (dividedFormula[i].Substring(0, j).ToLower() == label[k].Text.ToLower())
                            {
                                temp2.Add(k);
                                flag = true;
                                if (j != dividedFormula[i].Length)
                                {
                                    dividedFormula.Insert(i, dividedFormula[i].Substring(0, j));
                                    dividedFormula[i + 1] = dividedFormula[i + 1].Substring(j);
                                }
                                break;
                            }
                    if (flag == false)
                        dividedFormula.RemoveAt(i--);
                }
                else
                {
                    try
                    {
                        double d = Convert.ToDouble(dividedFormula[i]);
                        temp2.Add(d);
                    }
                    catch { }
                }
            }

            for (int i = 0; i < numericTexBox.Count; i++)
                numericTexBox[i].Value = 0;

            string formulaInUnitCell = "";
            for (int i = 0; i < temp2.Count; i++)
            {
                while (i < temp2.Count && temp2[i].GetType() != typeof(int))
                    temp2.RemoveAt(i);

                if (i < temp2.Count - 1 && temp2[i + 1].GetType() == typeof(double))//次が数字のときは
                {
                    numericTexBox[(int)temp2[i]].Value += (double)temp2[i + 1] * (double)numericUpDownZ.Value;

                    if (formulaInUnitCell != "") formulaInUnitCell += " ";
                    if (numericTexBox[(int)temp2[i]].Value == 1)
                        formulaInUnitCell += label[(int)temp2[i]].Text;
                    else
                        formulaInUnitCell += label[(int)temp2[i]].Text + (numericTexBox[(int)temp2[i]].Value).ToString();
                    i++;
                }
                else if ((i < temp2.Count - 1 && temp2[i + 1].GetType() == typeof(int)) || i == temp2.Count - 1)//次が元素のとき、あるいは次がないとき
                {
                    numericTexBox[(int)temp2[i]].Value += 1.0 * (double)numericUpDownZ.Value;

                    if (formulaInUnitCell != "") formulaInUnitCell += " ";
                    if (numericTexBox[(int)temp2[i]].Value == 1)
                        formulaInUnitCell += label[(int)temp2[i]].Text;
                    else
                        formulaInUnitCell += label[(int)temp2[i]].Text + (numericTexBox[(int)temp2[i]].Value).ToString();
                }
            }
            textBoxFormula.Text = formulaInUnitCell;
            stopCycling = false;
        }


        //イオン半径入力コントロールの配置
        public List<UserControlIonicRadius> ionicRadius = new List<UserControlIonicRadius>();

        private void textBoxFormula_TextChanged(object sender, EventArgs e)
        {
            ionicRadius.Clear();
            for (int i = 1; i < numericTexBox.Count; i++)
                if (numericTexBox[i].Value > 0)
                {
                    ionicRadius.Add(new UserControlIonicRadius());
                    ionicRadius[^1].Element = label[i].Text;
                    ionicRadius[^1].AtomicNumber = i;

                    ionicRadius[^1].Radius = getIonRadius(i);
                }
            //既に配置済みのものがあれば回収する
            for (int i = 0; i < flowLayoutPanelIonicRadius.Controls.Count; i++)
                for (int j = 0; j < ionicRadius.Count; j++)
                    if (((UserControlIonicRadius)flowLayoutPanelIonicRadius.Controls[i]).Element == ionicRadius[j].Element)
                        ionicRadius[j].Radius = ((UserControlIonicRadius)flowLayoutPanelIonicRadius.Controls[i]).Radius;
            flowLayoutPanelIonicRadius.Controls.Clear();
            for (int j = 0; j < ionicRadius.Count; j++)
                flowLayoutPanelIonicRadius.Controls.Add(ionicRadius[j]);
        }

        #region イオン半径　スイッチ　いずれちゃんと作りなおそう
        private double getIonRadius(int atomicNumber)
        {
            return atomicNumber switch
            {
                1 => 0.001,
                2 => 0.01,
                3 => 0.076,
                4 => 0.027,
                5 => 0.011,
                6 => 0.015,
                7 => 0.016,
                8 => 0.142,
                9 => 0.133,
                10 => 0.001,
                11 => 0.118,
                12 => 0.089,
                13 => 0.039,
                14 => 0.026,
                15 => 0.029,
                16 => 0.184,
                17 => 0.181,
                18 => 0.01,
                19 => 0.151,
                20 => 0.112,
                21 => 0.087,
                22 => 0.042,
                23 => 0.058,
                24 => 0.0615,
                25 => 0.058,
                26 => 0.055,
                27 => 0.061,
                28 => 0.06,
                29 => 0.057,
                30 => 0.074,
                31 => 0.062,
                32 => 0.053,
                33 => 0.046,
                34 => 0.198,
                35 => 0.196,
                36 => 0.01,
                37 => 0.161,
                38 => 0.126,
                39 => 0.09,
                40 => 0.072,
                41 => 0.064,
                42 => 0.059,
                43 => 0.06,
                44 => 0.036,
                45 => 0.055,
                46 => 0.0615,
                47 => 0.094,
                48 => 0.095,
                49 => 0.08,
                50 => 0.069,
                51 => 0.076,
                52 => 0.097,
                53 => 0.22,
                54 => 0.04,
                55 => 0.174,
                56 => 0.142,
                57 => 0.116,
                58 => 0.1143,
                59 => 0.1126,
                60 => 0.0983,
                61 => 0.1093,
                62 => 0.0958,
                63 => 0.125,
                64 => 0.1053,
                65 => 0.104,
                66 => 0.097,
                67 => 0.1015,
                68 => 0.1004,
                69 => 0.0994,
                70 => 0.0868,
                71 => 0.0861,
                72 => 0.071,
                73 => 0.068,
                74 => 0.042,
                75 => 0.055,
                76 => 0.049,
                77 => 0.0625,
                78 => 0.0625,
                79 => 0.085,
                80 => 0.096,
                81 => 0.075,
                82 => 0.129,
                83 => 0.103,
                84 => 0.067,
                85 => 0.062,
                86 => 0.01,
                87 => 0.18,
                88 => 0.17,
                89 => 0.112,
                90 => 0.105,
                91 => 0.09,
                92 => 0.073,
                93 => 0.098,
                94 => 0.096,
                95 => 0.085,
                96 => 0.085,
                97 => 0.083,
                98 => 0.0821,
                _ => 0,
            };
        }

        # endregion

        #endregion


        private void FormAtomicPositionFinder_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker.CancelAsync();
            e.Cancel = true;
            formMain.toolStripButtonAtomicPositonFinder.Checked = false;
        }

        private void numericTextBoxCellDimension_ValueChanged(object sender, EventArgs e)
        {
            setnumericTextBoxState();
        }

        private void setnumericTextBoxState()
        {
            numericBoxA.ReadOnly = numericBoxB.ReadOnly = numericBoxC.ReadOnly = numericBoxAlpha.ReadOnly = numericBoxBeta.ReadOnly = numericBoxGamma.ReadOnly = false;
            switch (comboBoxCrystalSystem.SelectedIndex)
            {
                case 0: break;
                case 1:
                    numericBoxAlpha.ReadOnly = numericBoxGamma.ReadOnly = true;
                    numericBoxAlpha.Value = numericBoxGamma.Value = 90;
                    break;

                case 2:
                    numericBoxAlpha.ReadOnly = numericBoxBeta.ReadOnly = numericBoxGamma.ReadOnly = true;
                    numericBoxAlpha.Value = numericBoxBeta.Value = numericBoxGamma.Value = 90;

                    break;
                case 3:
                    numericBoxB.ReadOnly = true;
                    numericBoxB.Value = numericBoxA.Value;
                    numericBoxAlpha.ReadOnly = numericBoxBeta.ReadOnly = numericBoxGamma.ReadOnly = true;
                    numericBoxAlpha.Value = numericBoxBeta.Value = numericBoxGamma.Value = 90;
                    break;
                case 4:
                    numericBoxB.ReadOnly = true;
                    numericBoxB.Value = numericBoxA.Value;
                    numericBoxAlpha.ReadOnly = numericBoxBeta.ReadOnly = numericBoxGamma.ReadOnly = true;
                    numericBoxAlpha.Value = numericBoxBeta.Value = 90; numericBoxGamma.Value = 120;
                    break;
                case 5:
                    numericBoxB.ReadOnly = true;
                    numericBoxB.Value = numericBoxA.Value;
                    numericBoxAlpha.ReadOnly = numericBoxBeta.ReadOnly = numericBoxGamma.ReadOnly = true;
                    numericBoxAlpha.Value = numericBoxBeta.Value = 90; numericBoxGamma.Value = 120;
                    break;
                case 6:
                    numericBoxB.ReadOnly = numericBoxC.ReadOnly = true;
                    numericBoxC.Value = numericBoxB.Value = numericBoxA.Value;
                    numericBoxAlpha.ReadOnly = numericBoxBeta.ReadOnly = numericBoxGamma.ReadOnly = true;
                    numericBoxAlpha.Value = numericBoxBeta.Value = numericBoxGamma.Value = 90;
                    break;
            }

        }

        private void comboBoxCrystalSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            setnumericTextBoxState();

            listBoxSpaceGroupCandidate.Items.Clear();

            for (int i = 0; i < SymmetryStatic.TotalSpaceGroupNumber; i++)
            {
                Symmetry s = SymmetryStatic.Symmetries[i];
                if (s.CrystalSystemNumber == comboBoxCrystalSystem.SelectedIndex + 1)
                {
                    string str = "";
                    str += s.SpaceGroupNumber.ToString() + "." + s.SpaceGroupSubNumber.ToString();
                    str += ": ";
                    str += s.SpaceGroupHMStr;
                    if (str.IndexOf("=") > 0)
                        str = str.Substring(0, str.IndexOf("="));
                    if (str.IndexOf("(") > 0)
                        str = str.Substring(0, str.IndexOf("("));
                    if (str.IndexOf("Hex") > 0)
                        str = str.Substring(0, str.IndexOf("Hex"));
                    str = str.TrimEnd(new char[] { ' ' });
                    listBoxSpaceGroupCandidate.Items.Add(str);
                }
            }

        }

        #region 空間群選択のlistBoxのオーナードロー
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string txt = ((ListBox)sender).Items[e.Index].ToString();

            //下付き文字用フォント
            Font sub = new Font("Times New Roman", 8f, FontStyle.Regular);
            //斜体
            Font italic = new Font("Times New Roman", 11f, FontStyle.Italic);
            //普通
            Font regular = new Font("Times New Roman", 11f, FontStyle.Regular);

            Font bold = new Font("Times New Roman", 10f, FontStyle.Bold);

            float xPos = e.Bounds.Left;
            Brush b = null;

            if ((e.State & DrawItemState.Selected) != DrawItemState.Selected)
                b = new SolidBrush(Color.Black);
            else
                b = new SolidBrush(Color.White);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            //最初に数値を書く
            e.Graphics.DrawString(txt.Substring(0, txt.IndexOf(':')), bold, b, xPos, e.Bounds.Y + 1);
            xPos += e.Graphics.MeasureString(txt.Substring(0, txt.IndexOf(':')), bold).Width - 3;

            txt = txt.Substring(txt.IndexOf(':'));

            while (txt.Length > 0)
            {
                if (txt.StartsWith(" "))
                    xPos += 0;
                else if (txt.StartsWith("sub"))//subで始まる時は
                {
                    xPos -= 1;
                    txt = txt.Substring(3, txt.Length - 3);
                    e.Graphics.DrawString(txt[0].ToString(), sub, b, xPos, e.Bounds.Y + 3);
                    xPos += e.Graphics.MeasureString(txt[0].ToString(), sub).Width - 2;
                }

                else if (txt.StartsWith("-"))//-で始まる時は
                {
                    float x = e.Graphics.MeasureString(txt[1].ToString(), regular).Width;
                    e.Graphics.DrawLine(new Pen(b, 1), new PointF(xPos + 2f, e.Bounds.Y + 1), new PointF(x + xPos - 3f, e.Bounds.Y + 1));
                }
                else if (txt[0] == '/')
                {
                    xPos -= 1;
                    e.Graphics.DrawString(txt[0].ToString(), regular, b, xPos, e.Bounds.Y);
                    xPos += e.Graphics.MeasureString(txt[0].ToString(), regular).Width - 5;
                }
                else if (('0' <= txt[0] && '9' >= txt[0]) || txt[0] == ':')
                {
                    e.Graphics.DrawString(txt[0].ToString(), regular, b, xPos, e.Bounds.Y);
                    xPos += e.Graphics.MeasureString(txt[0].ToString(), regular).Width - 2;
                }
                else
                {
                    e.Graphics.DrawString(txt[0].ToString(), italic, b, xPos, e.Bounds.Y);
                    xPos += e.Graphics.MeasureString(txt[0].ToString(), italic).Width - 2;
                }
                txt = txt.Substring(1);
            }

            b.Dispose();


        }
        #endregion

        private void FormAtomicPositionFinder_Load(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Index
            if (e.RowIndex > -1 && dataSet.DataTableDiffractionData.Rows.Count > e.RowIndex && e.ColumnIndex == 1)
            {
                DataRow dr = dataSet.DataTableDiffractionData.Rows[e.RowIndex];
                double d = (double)dr["d"];

                //結晶の格子定数がきちんと入力されているかどうかをチェック
                if (numericBoxA.Value * numericBoxB.Value * numericBoxC.Value != 0 && numericBoxAlpha.Value * numericBoxBeta.Value * numericBoxGamma.Value != 0)
                {
                    //dの値に近い指数をさがす
                }
            }
        }


        private FindCondition getFindingCondition()
        {
            //空間群が選択されていない、あるいはピークが一つもない、あるいは化学式がないときはそのまま帰る
            if (dataSet.DataTableDiffractionData.Rows.Count < 1 || listBoxSpaceGroupCandidate.SelectedItems.Count < 1 || textBoxFormula.Text == "") return null;

            //ユニットセルあたりの原子の種類、数を求める
            List<int> atomSpecies = new List<int>();
            List<int> atomNumber = new List<int>();
            for (int i = 0; i < numericTexBox.Count; i++)
                if (numericTexBox[i].Value != 0)
                {
                    atomSpecies.Add(i);
                    atomNumber.Add((int)numericTexBox[i].Value);
                }

            //DatagridView DiffractionPeakをまず整列
            List<Peak> peak = new List<Peak>();
            for (int i = 0; i < dataSet.DataTableDiffractionData.Rows.Count; i++)
                peak.Add(new Peak((bool)dataSet.DataTableDiffractionData.Rows[i][0], (double)dataSet.DataTableDiffractionData.Rows[i][1] * 0.1, (double)dataSet.DataTableDiffractionData.Rows[i][2]));
            peak.Sort();
            dataSet.DataTableDiffractionData.Rows.Clear();
            double max = 0;
            for (int i = 0; i < peak.Count; i++)
            {
                max = Math.Max(peak[i].Intensity, max);
                dataSet.DataTableDiffractionData.Rows.Add(peak[i].Check, peak[i].D * 10, peak[i].Intensity, "");
            }
            if (max <= 0) return null;

            //ディフラクションピークを読み取り、peaks配列に格納
            List<PointD> peaks = new List<PointD>();
            for (int i = 0; i < dataSet.DataTableDiffractionData.Rows.Count; i++)
                if ((bool)dataSet.DataTableDiffractionData.Rows[i][0])
                    peaks.Add(new PointD((double)dataSet.DataTableDiffractionData.Rows[i][1] * 0.1, (double)dataSet.DataTableDiffractionData.Rows[i][2] / max));

            double[] observedIntensity = new double[peaks.Count];
            for (int i = 0; i < peaks.Count; i++)
                observedIntensity[i] = peaks[i].Y;

            //候補となる空間群に属する結晶リストを作成する
            List<Crystal> crystal = new List<Crystal>();
            for (int i = 0; i < listBoxSpaceGroupCandidate.SelectedItems.Count; i++)
            {
                string tempstr = ((string)listBoxSpaceGroupCandidate.SelectedItems[i]).Split(new char[] { ':' })[0];
                int sg_num = Convert.ToInt32(tempstr.Split(new char[] { '.' })[0]);
                int sg_sub_num = Convert.ToInt32(tempstr.Split(new char[] { '.' })[1]);
                for (int j = 0; j < SymmetryStatic.TotalSpaceGroupNumber; j++)
                {
                    var s = SymmetryStatic.Symmetries[j];
                    if (s.SpaceGroupNumber == sg_num && s.SpaceGroupSubNumber == sg_sub_num)
                        crystal.Add(new Crystal(
                            (numericBoxA.Value / 10.0, numericBoxB.Value / 10.0, numericBoxC.Value / 10.0, numericBoxAlpha.RadianValue, numericBoxBeta.RadianValue, numericBoxGamma.RadianValue)
                            , s.SeriesNumber, "", Color.Black));
                }
            }

            //結晶面の計算
            for (int i = 0; i < crystal.Count; i++)
                //if (radioButtonAngleThreshold.Checked)
                {
                    crystal[i].SetPlanes(double.MaxValue, peaks[^1].X * 0.8, true, true, false, true,HorizontalAxis.Angle,
                        (double)numericUpDownAngleThreshold.Value / 180.0 * Math.PI, waveLengthControl1.WaveLength);
                }
                //else if (radioButtonAngleThreshold.Checked)
                //{
                //    crystal[i].SetPlanes(peaks[peaks.Count - 1].X * 0.8, true, true, false, true, HorizontalAxis.Angle,
                //        (double)numericUpDownAngleThreshold.Value / 180.0 * Math.PI, waveLengthControl1.WaveLength);
                //}

            //ピークの対応表を作る。int[i][j]は、 i番目の空間群候補について、j番目のpeaksと対応する結晶面のindex
            int[][] correspondingPeakList = new int[crystal.Count][];
            for (int i = 0; i < crystal.Count; i++)
            {
                correspondingPeakList[i] = new int[peaks.Count];

                for (int j = 0; j < peaks.Count; j++)
                {
                    double minDif = double.PositiveInfinity;
                    for (int k = 0; k < crystal[i].Plane.Count; k++)
                        if (minDif > Math.Abs(peaks[j].X - crystal[i].Plane[k].d))
                        {
                            minDif = Math.Abs(peaks[j].X - crystal[i].Plane[k].d);
                            correspondingPeakList[i][j] = k;
                        }
                }
                //この対応表にのらないピーク以外のd値をマイナスにして
                for (int k = 0; k < crystal[i].Plane.Count; k++)
                {
                    bool flag = true;
                    for (int j = 0; j < peaks.Count; j++)
                        if (correspondingPeakList[i][j] == k)
                            flag = false;
                    if (flag)
                        crystal[i].Plane[k].d = -1;
                }
                //マイナスのものをけしてしまう
                for (int j = 0; j < crystal[i].Plane.Count; j++)
                    if (crystal[i].Plane[j].d < 0)
                    {
                        crystal[i].Plane.RemoveAt(j);
                        j--;
                    }
            }

            for (int i = 0; i < crystal.Count; i++)
                if (crystal[i].Plane.Count != observedIntensity.Length)
                    crystal.RemoveAt(i--);

            //dataGridにIndexを表示する
            for (int i = 0; i < dataSet.DataTableDiffractionData.Rows.Count && crystal.Count>0 && i < crystal[0].Plane.Count; i++)
                dataSet.DataTableDiffractionData.Rows[i][3] = crystal[0].Plane[i].strHKL;

           
            //dataGridViewDiffractionPeaks. =  crystal[0].Plane[i].strHKL;

            //結晶リストごとに候補となるワイコフ位置リストを作成する
            //candidate[i][j][k][l]はi番目の空間群候補の、j番目のワイコフ配列候補の、k番目の原子がl番目のワイコフ位置に収まる数
            List<int[][][]> candidate = new List<int[][][]>();
            for (int i = 0; i < crystal.Count; i++)
                candidate.Add(GenerateWyckoff(crystal[i].Symmetry.SeriesNumber, atomNumber.ToArray()).ToArray());

            #region test code
            /*
            string str = "";
            StringBuilder strb = new StringBuilder();
            
            for (int i = 0; i < candidate.Length; i++)
            {
                strb.Append( "空間群" + crystal[i].Symmetry.SpaceGroupHM + "\r\n");
                for (int j = 0; j < candidate[i].Length; j++)
                {
                    strb.Append("  " + (j + 1).ToString() + "番目の候補\r\n");
                    for (int k = 0; k < candidate[i][j].Length; k++)
                    {
                        strb.Append( "    " + label[atomSpecies[k]].Text + ": ");
                        for (int l = 0; l < candidate[i][j][k].Length; l++)
                            if (candidate[i][j][k][l] != 0)
                                strb.Append("        " + SymmetryStatic.WyckoffPositions[crystal[i].Symmetry.SeriesNumber][l].WyckoffLetter + ":" + candidate[i][j][k][l].ToString());
                        strb.Append("\r\n");
                    }
                }
            }
           // MessageBox.Show(strb.ToString());

            Clipboard.SetDataObject(strb.ToString());
            */
            #endregion

            //ワイコフ位置だけが決まっている（原子位置は決まっていない)結晶候補リストを作成
            List<Crystal[]> crystalTemplates = new List<Crystal[]>();
            for (int i = 0; i < candidate.Count; i++)
            {
                crystalTemplates.Add(new Crystal[candidate[i].Length]);
                for (int j = 0; j < candidate[i].Length; j++)
                {
                    crystalTemplates[i][j] = generateCrystalTemplates((Crystal)crystal[i].Clone(), candidate[i][j], atomSpecies.ToArray());
                    ConvertCrystalData.SetOpenGL_property(crystalTemplates[i][j]);//描画用のプロパティをセット

                    for (int k = 0; k < crystalTemplates[i][j].Atoms.Length; k++)
                        for (int l = 0; l < ionicRadius.Count; l++)
                            if (ionicRadius[l].AtomicNumber == crystalTemplates[i][j].Atoms[k].AtomicNumber)
                                crystalTemplates[i][j].Atoms[k].Z_err = ionicRadius[l].Radius;//便宜的にイオン半径をZ_errにセット
                }
            }

            for (int i = 0; i < crystalTemplates.Count; i++)
                if (crystalTemplates[i].Length == 0)
                    crystalTemplates.RemoveAt(i--);




            randomizeProb = (double)numericUpDownRandomization.Value * 0.01;
            hybridizeProb = (double)numericUpDownHybridization.Value * 0.01;
            shakingProb = (double)numericUpDownShaking.Value * 0.01;
            radiusAllowance = (double)numericUpDownIonRadiusThreshold.Value * 0.01;

            return new FindCondition(crystalTemplates.ToArray(), observedIntensity);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (buttonStart.Text == "Stop!")
            {
                buttonStart.Text = "Start";
                buttonResume.Enabled = true;
                backgroundWorker.CancelAsync();
                return;
            }
            FindCondition fc = getFindingCondition();
            if (fc != null)
            {
                top1.Clear();
                top10.Clear();
                top100.Clear();
                graphControl1.Draw(true);

                dataSet.DataTableCrystalCandidates.Rows.Clear();
              fc.Candidates =null;
                

                buttonStart.Text = "Stop!";
                buttonResume.Enabled = false;

                Step = 0;

                sw.Reset();
                sw.Start();
                backgroundWorker.RunWorkerAsync(fc);
                //ここから検索ルーチンに入る
            }
        }


        private void buttonResume_Click(object sender, EventArgs e)
        {
            FindCondition fc = getFindingCondition();
            if (fc != null)
            {
                List<Crystal> candidates = new List<Crystal>();
                for (int i = 0; i < dataSet.DataTableCrystalCandidates.Rows.Count; i++)
                    candidates.Add((Crystal)dataSet.DataTableCrystalCandidates.Rows[i][0]);
                buttonStart.Text = "Stop!";
                fc.Candidates = candidates.ToArray();
                sw.Reset();
                sw.Start();
                backgroundWorker.RunWorkerAsync(fc);
                //ここから検索ルーチンに入る
            }
        }


        public class FindCondition
        {
            public Crystal[] Candidates;
            public Crystal[][] CrystalTemplates;
            public double[] ObservedIntensity;
            public FindCondition(Crystal[][] crystalTemplates, double[] observedIntensity)
            {
                this.CrystalTemplates = crystalTemplates;
                this.ObservedIntensity = observedIntensity;
            }
        }

        private double[] getIntensityArray(Crystal c)
        {
            double[] intensity = new double[c.Plane.Count];
            for (int k = 0; k < c.Plane.Count; k++)
                intensity[k] = c.Plane[k].Intensity;
            return intensity;
        }


        delegate Crystal[] GenerateCrystalsDelegate(int tryNumber, List<Crystal> crystalCandidate);

        int threadTotal = 8;
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            Crystal[][] crystalTemplates = ((FindCondition)e.Argument).CrystalTemplates;
            if (crystalTemplates.Length == 0) return;
            double[] observedIntensity = ((FindCondition)e.Argument).ObservedIntensity;
            List<Crystal> allCandidate = new List<Crystal>();
            if (((FindCondition)e.Argument).Candidates != null)
                allCandidate.AddRange(((FindCondition)e.Argument).Candidates);

            //ここから匿名メソッドの作成
            GenerateCrystalsDelegate[] generateCrystal = new GenerateCrystalsDelegate[(int)numericUpDownThreadTotal.Maximum];

            for (int thread = 0; thread < numericUpDownThreadTotal.Maximum; thread++)
                generateCrystal[thread] = (tryNumber, candidates) =>
                {
                    Random r = new Random();
                    for (int count = 0; count < tryNumber; count++)
                    {
                        double rnd = r.NextDouble();
                        if (rnd < randomizeProb)//通常のランダム原子位置結晶作成
                        {
                            int i = r.Next(0, crystalTemplates.Length), j = r.Next(0, crystalTemplates[i].Length);
                            Crystal tempCrystal = (Crystal)crystalTemplates[i][j].Clone();
                            tempCrystal.RandomizeAllAtomicPositionKeepingWykoff(r);
                            if (checkAtomicPosition(tempCrystal))
                            {
                                tempCrystal.SetPeakIntensity(WaveSource.Xray, WaveColor.Monochrome, waveLengthControl1.WaveLength,null);
                                tempCrystal.Residual = GetResidualValue(observedIntensity, getIntensityArray(tempCrystal));
                                candidates.Add(tempCrystal);
                            }
                        }
                        else if (candidates.Count > 0)
                        {
                            int i = r.Next(r.Next(r.Next(candidates.Count)));
                            if (rnd < randomizeProb + hybridizeProb)//遺伝アルゴリズム リスト中の掛け合わせ
                            {
                                Crystal tempCrystal = hybridizeCrystals(new Crystal[] { candidates[i], candidates[r.Next(i)] });
                                if (checkAtomicPosition(tempCrystal))//原子位置に重なりがなければ
                                {
                                    tempCrystal.SetPeakIntensity(WaveSource.Xray, WaveColor.Monochrome, waveLengthControl1.WaveLength, null);

                                    tempCrystal.Residual = GetResidualValue(observedIntensity, getIntensityArray(tempCrystal));
                                    if (tempCrystal.Residual < candidates[i].Residual)
                                    {
                                        bool flag = candidates[i].Atoms.Length == tempCrystal.Atoms.Length;
                                        if (flag)
                                            for (int j = 0; j < tempCrystal.Atoms.Length; j++)
                                                if (candidates[i].Atoms[j].WyckoffLeter != tempCrystal.Atoms[j].WyckoffLeter)
                                                    flag = false;
                                        if (flag)//ワイコフ位置まで完全に一致する片親とは。。。
                                            candidates[i] = tempCrystal;//入れ替える
                                        else
                                            candidates.Add(tempCrystal);//ワイコフ位置が一致しない場合は入れ替えない
                                    }
                                }
                            }//遺伝アルゴリズム ここまで

                            else //Shaking 原子位置を微妙に変化させる
                            {
                                Crystal tempCrystal = (Crystal)candidates[i].Clone();
                                tempCrystal.Atoms[r.Next(tempCrystal.Atoms.Length)].ShakeKeepingWykoff(0.3, r);
                                if (checkAtomicPosition(tempCrystal))
                                {
                                    tempCrystal.SetPeakIntensity(WaveSource.Xray, WaveColor.Monochrome, waveLengthControl1.WaveLength, null);

                                    tempCrystal.Residual = GetResidualValue(observedIntensity, getIntensityArray(tempCrystal));
                                    if (tempCrystal.Residual < candidates[i].Residual)
                                        candidates[i] = tempCrystal;
                                }
                            }//Shakingここまで
                        }
                        if (count % 10 == 0)
                            candidates.Sort();
                    }
                    return candidates.ToArray();
                };
            //匿名メソッドここまで


            
            while (!backgroundWorker.CancellationPending)
            {
                Random r = new Random();

                radiusAllowance = (double)numericUpDownIonRadiusThreshold.Value * 0.01;
                threadTotal = (int)numericUpDownThreadTotal.Value;

                List<Crystal>[] candidates = new List<Crystal>[threadTotal];
                for (int thread = 0; thread < threadTotal; thread++)
                    candidates[thread] = new List<Crystal>();
                for (int i = 0; i < allCandidate.Count; i++)
                    candidates[r.Next(threadTotal)].Add((Crystal)allCandidate[i].Clone());

                IAsyncResult[] ar = new IAsyncResult[threadTotal];
                for (int thread = 0; thread < threadTotal; thread++)
                    ar[thread] = generateCrystal[thread].BeginInvoke(aggregateStep / threadTotal, candidates[thread], null, null);
                allCandidate.Clear();
                for (int thread = 0; thread < threadTotal; thread++)
                    allCandidate.AddRange(generateCrystal[thread].EndInvoke(ar[thread]));


                allCandidate.Sort();
                if (allCandidate.Count > maxCandidate)
                    allCandidate.RemoveRange(maxCandidate, allCandidate.Count - maxCandidate);
                for (int i = 0; i < allCandidate.Count; i++)
                {
                    while (i < allCandidate.Count && double.IsNaN(allCandidate[i].Residual))
                        allCandidate.RemoveAt(i);

                    allCandidate[i].ReCoordinateAtom();

                    allCandidate[i].Note = allCandidate[i].Symmetry.SpaceGroupHMStr + ", ";
                    for (int j = 0; j < allCandidate[i].Atoms.Length; j++)
                    {
                        allCandidate[i].Note +=
                            allCandidate[i].Atoms[j].Label + "  " + allCandidate[i].Atoms[j].WyckoffLeter + ": " +
                            allCandidate[i].Atoms[j].X.ToString("f3") + "," + allCandidate[i].Atoms[j].Y.ToString("f3") + "," + allCandidate[i].Atoms[j].Z.ToString("f3") + "; ";
                    }

                    if (i > 0 && allCandidate[i - 1].Note == allCandidate[i].Note)
                        allCandidate.RemoveAt(i--);
                }

                List<Crystal> candidatesTemp = new List<Crystal>();
                for (int i = 0; i < allCandidate.Count; i++)
                    candidatesTemp.Add((Crystal)allCandidate[i].Clone());

                backgroundWorker.ReportProgress(Step++ * aggregateStep, candidatesTemp);
            }
           
        }

        private Crystal hybridizeCrystals(Crystal[] crystals)
        {
            if (crystals == null || crystals.Length <= 1) return null;
            if (crystals[0].SymmetrySeriesNumber != crystals[1].SymmetrySeriesNumber) return null;

            //まずcrystal2から原子を一つ選ぶ
            Random r = new Random();
            List<int> elementList = new List<int>();
            for (int i = 0; i < crystals[0].Atoms.Length; i++)
                if (!elementList.Contains(crystals[0].Atoms[i].AtomicNumber))
                    elementList.Add(crystals[0].Atoms[i].AtomicNumber);

            List<Atoms> atomsList = new List<Atoms>();
            for (int i = 0; i < elementList.Count; i++)
            {
                int j = r.Next(crystals.Length);
                for (int k = 0; k < crystals[j].Atoms.Length; k++)
                    if (crystals[j].Atoms[k].AtomicNumber == elementList[i])
                        atomsList.Add((Atoms)crystals[j].Atoms[k].Clone());
            }
            Crystal crystal = (Crystal)crystals[0].Clone();
            crystal.Atoms = atomsList.ToArray();
            return crystal;
        }

        private bool checkAtomicPosition(Crystal c)
        {
            if (c == null || c.Atoms == null || c.Atoms.Length < 1) return false;

            List<Vector3DBase> v = new List<Vector3DBase>();
            List<double> r = new List<double>();
            for (int i = 0; i < c.Atoms.Length; i++)
            {
                Vector3DBase temp = (c.Atoms[i].Atom[0].X * c.A_Axis + c.Atoms[i].Atom[0].Y * c.B_Axis + c.Atoms[i].Atom[0].Z * c.C_Axis);
                for (int j = 0; j < v.Count; j++)
                    if ((v[j] - temp).Length2 < (r[j] + c.Atoms[i].Z_err) * (r[j] + c.Atoms[i].Z_err) * radiusAllowance * radiusAllowance)
                        return false;
                v.Add(temp);
                r.Add(c.Atoms[i].Z_err);//Z_errに格納されていたイオン半径をrに代入
            }
            
            for (int i = 0; i < c.Atoms.Length; i++)
                for (int j = 0; j < c.Atoms[i].Atom.Length; j++)
                     for (int xx = c.Atoms[i].Atom[0].X > 0.5 ? -1 : 0; xx <= (c.Atoms[i].Atom[0].X > 0.5 ? 0 : 1); xx++)
                             for (int yy = c.Atoms[i].Atom[0].Y > 0.5 ? -1 : 0; yy <= (c.Atoms[i].Atom[0].Y > 0.5 ? 0 : 1); yy++)
                                 for (int zz = c.Atoms[i].Atom[0].Z > 0.5 ? -1 : 0; zz <= (c.Atoms[i].Atom[0].Z > 0.5 ? 0 : 1); zz++)
                                     if (j != 0 || xx != 0 || yy != 0 || zz != 0)
                                     {
                                         Vector3DBase temp = (c.Atoms[i].Atom[j].X + xx) * c.A_Axis + (c.Atoms[i].Atom[j].Y + yy) * c.B_Axis + (c.Atoms[i].Atom[j].Z + zz) * c.C_Axis;
                                         for (int k = 0; k < v.Count; k++)
                                             if ((v[k] - temp).Length2 < (r[k] + c.Atoms[i].Z_err) * (r[k] + c.Atoms[i].Z_err) * radiusAllowance * radiusAllowance)
                                                 return false;
                                     }
            return true;
        }

        Stopwatch sw = new Stopwatch();
        double hybridizeProb, randomizeProb, shakingProb;
        double radiusAllowance;

        int maxCandidate = 1000;
        int aggregateStep = 10000;
        Profile top1 = new Profile();
        Profile top10 = new Profile();
        Profile top100 = new Profile();

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            List<Crystal> candidates = (List<Crystal>)e.UserState;
            if (candidates.Count < 100 && e.ProgressPercentage % (aggregateStep * 10) != 0) return;
            if (candidates.Count < 2) return;

            for (int i = 0; i < candidates.Count; i++)
            {
                if (i < dataSet.DataTableCrystalCandidates.Rows.Count)
                {
                    dataSet.DataTableCrystalCandidates.Rows[i][0] = candidates[i].Clone();
                    dataSet.DataTableCrystalCandidates.Rows[i][1] = candidates[i].Residual.ToString();
                    dataSet.DataTableCrystalCandidates.Rows[i][2] = candidates[i].Note;
                }
                else
                    dataSet.DataTableCrystalCandidates.Rows.Add(candidates[i].Clone(), candidates[i].Residual.ToString(), candidates[i].Note);
            }
            if (candidates.Count < dataSet.DataTableCrystalCandidates.Rows.Count)
                for (int i = candidates.Count; i < dataSet.DataTableCrystalCandidates.Rows.Count; )
                    dataSet.DataTableCrystalCandidates.Rows.RemoveAt(i);

            double average1 = candidates[0].Residual, average10 = 0, average100 = 0;

            top1.Pt.Add(new PointD(e.ProgressPercentage, average1));

            if (candidates.Count > 10)
            {
                for (int i = 0; i < 10; i++)
                    average10 += candidates[i].Residual / 10.0;
                top10.Pt.Add(new PointD(e.ProgressPercentage, average10));
            }
            if (candidates.Count > 100)
            {
                for (int i = 0; i < 100; i++)
                    average100 += candidates[i].Residual / 100.0;
                top100.Pt.Add(new PointD(e.ProgressPercentage, average100));
            }

            //1000ポイントを超えたら直近の800ポイントを1/10に間引く
            if (top100.Pt.Count > 1000)
                for (int i = top100.Pt.Count - 1; i >= 200; i--)
                    if (i % 10 != 0)
                    {
                        top1.Pt.RemoveAt(i);
                        top10.Pt.RemoveAt(i);
                        top100.Pt.RemoveAt(i);
                    }

            graphControl1.Draw(true);

            toolStripStatusLabelCounter.Text = "total:" + (e.ProgressPercentage).ToString("g6") + " step" + ",  " + (e.ProgressPercentage / (double)sw.ElapsedMilliseconds).ToString("f3") + " step/ms";

            randomizeProb = (double)numericUpDownRandomization.Value * 0.01;
            hybridizeProb = (double)numericUpDownHybridization.Value * 0.01;
            shakingProb = (double)numericUpDownShaking.Value * 0.01;
            radiusAllowance = (double)numericUpDownIonRadiusThreshold.Value * 0.01;

            Application.DoEvents();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonStart.Text = "Start";
            buttonResume.Enabled = true;
        }

        public double GetResidualValue(double[] observedIntensity, double[] calculatedIntensity)
        {
            double sum1 = 0, sum2 = 0;
            for (int i = 0; i < observedIntensity.Length; i++)
            {
                sum1 += calculatedIntensity[i] * calculatedIntensity[i];
                sum2 += observedIntensity[i] * calculatedIntensity[i];
            }
            double A = sum2 / sum1;
            double residual = 0;
            for (int i = 0; i < observedIntensity.Length; i++)
                residual += (A * calculatedIntensity[i] - observedIntensity[i]) * (A * calculatedIntensity[i] - observedIntensity[i]);
            return residual / observedIntensity.Length*1000;
        }


        public Crystal generateCrystalTemplates(Crystal crystal, int[][] wykcoffCandidate, int[] atomSpecies)
        {
            var atoms = new List<Atoms>();
            var wyk = SymmetryStatic.WyckoffPositions[crystal.SymmetrySeriesNumber];
            for (int i = 0; i < wykcoffCandidate.Length; i++)
                for (int j = 0; j < wykcoffCandidate[i].Length; j++)
                    for (int k = 0; k < wykcoffCandidate[i][j]; k++)
                        atoms.Add(new Atoms(wyk[j], AtomStatic.AtomicName(atomSpecies[i]), atomSpecies[i], 0, 0,null, 1, new DiffuseScatteringFactor()));
            crystal.Atoms = atoms.ToArray();
            return crystal;
        }

        #region ワイコフ位置検索ルーチン

        /// <summary>
        /// 原子をワイフポジションに割り当てる
        /// </summary>
        /// <param name="spaceGroupNumber"></param>
        /// <param name="atomNumber"></param>
        /// <returns>int[i][j][k] i番目のワイコフ配列候補の、j番目の原子がk番目のワイコフ位置に何個あるか</returns>
        public List<int[][]> GenerateWyckoff(int spaceGroupNumber, int[] atomNumber)
        {
            var wyk = SymmetryStatic.WyckoffPositions[spaceGroupNumber];

            int[] multiplicity = new int[wyk.Length];
            bool[] freedom = new bool[multiplicity.Length];
            for (int i = 0; i < multiplicity.Length; i++)
            {
                multiplicity[i] = wyk[i].Multiplicity;
                freedom[i] = wyk[i].Free.X || wyk[i].Free.Y || wyk[i].Free.Z;
            }
            return GenerateWyckoff(atomNumber, multiplicity, freedom);
        }

        /// <summary>
        /// 原子の数をワイコフポジションに割り当てる
        /// </summary>
        /// <param name="atom">原子の数</param>
        /// <param name="multiplicity">ワイコフ位置の多重度</param>
        /// <param name="freedom">自由度があるかどうか (x,y,z などの変数があるか)</param>
        /// <returns>int[i][j][k] i番目のワイコフ配列候補の、j番目の原子がk番目のワイコフ位置に何個あるか</returns>
        public List<int[][]> GenerateWyckoff(int[] atom, int[] multiplicity, bool[] freedom)
        {
            int[][] housingAtom = new int[atom.Length][];
            for (int i = 0; i < atom.Length; i++)
            {
                housingAtom[i] = new int[multiplicity.Length];
                for (int j = 0; j < housingAtom[i].Length; j++)
                    housingAtom[i][j] = 0;
            }
            return GenerateWyckoff(atom, multiplicity, housingAtom, freedom);
        }

        /// <summary>
        /// 原子の数をワイコフポジションに割り当てる
        /// </summary>
        /// <param name="residualAtom">残り原子の数</param>
        /// <param name="multiplicity">ワイコフ位置の多重度</param>
        /// <param name="housingAtom">housingAtom[i][j] : i番目の原子がj番目のワイコフ位置にすでに収納されている数</param>
        /// <param name="freedom">自由度があるかどうか (x,y,z などの変数があるか)</param>
        /// <returns></returns>
        public List<int[][]> GenerateWyckoff(int[] residualAtom, int[] multiplicity, int[][] housingAtom, bool[] freedom)
        {
            //検索対象とする原子のインデックス
            int targetAtom = 0;
            for (int j = 0; j < residualAtom.Length; j++)
                if (residualAtom[j] != 0)
                {
                    targetAtom = j;
                    break;
                }

            //検索対象の原子が、既に入力されている位置を調べて、その位置から検索する　(a+bとb+aの重複を避ける)
            int startPosition = 0;
            for (int j = 0; j < multiplicity.Length; j++)
                if (housingAtom[targetAtom][j] != 0)
                    startPosition = j;

            bool[] tempFlag = new bool[freedom.Length];
            for (int i = 0; i < tempFlag.Length; i++)
                tempFlag[i] = true;
            for (int i = 0; i < housingAtom.Length; i++)
                for (int j = 0; j < housingAtom[i].Length; j++)
                    if (freedom[j] == false && housingAtom[i][j] != 0)
                        tempFlag[j] = false;

            List<int[][]> answer = new List<int[][]>();
            for (int i = startPosition; i < multiplicity.Length; i++)
            {
                if (tempFlag[i])
                {
                    int[][] tempHousingAtom = new int[residualAtom.Length][];
                    for (int j = 0; j < tempHousingAtom.Length; j++)
                    {
                        tempHousingAtom[j] = new int[multiplicity.Length];
                        for (int k = 0; k < tempHousingAtom[j].Length; k++)
                            tempHousingAtom[j][k] = housingAtom[j][k];
                    }
                    tempHousingAtom[targetAtom][i] += 1;

                    int[] tempResidualAtom = new int[residualAtom.Length];
                    residualAtom.CopyTo(tempResidualAtom, 0);
                    tempResidualAtom[targetAtom] -= multiplicity[i];

                    if (targetAtom == tempResidualAtom.Length - 1 && tempResidualAtom[targetAtom] == 0)
                        answer.Add(tempHousingAtom);
                    else if (tempResidualAtom[targetAtom] >= 0)
                    {
                        List<int[][]> answerList = GenerateWyckoff(tempResidualAtom, multiplicity, tempHousingAtom, freedom);
                        if (answerList.Count > 0)
                            answer.AddRange(answerList.ToArray());
                    }
                }
            }
            return answer;
        }

        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "Delete")
                dgv.Rows.RemoveAt(e.RowIndex);
        }

        #region ファイル入出力

        private void readFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(AtomicPositionFinderIO));
                System.IO.FileStream fs = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Open);
                try
                {
                    AtomicPositionFinderIO a = (AtomicPositionFinderIO)serializer.Deserialize(fs);
                    fs.Close();

                    //化学情報
                    textBoxInputFormula.Text = a.chemicalFormulae;
                    numericUpDownZ.Value = (decimal)a.Znumber;

                    //対称性
                    comboBoxCrystalSystem.SelectedIndex = a.CrystalSystem;
                    numericBoxA.Value = a.A; ;
                    numericBoxB.Value = a.B; ;
                    numericBoxC.Value = a.C;
                    numericBoxAlpha.Value = a.Alpha;
                    numericBoxBeta.Value = a.Beta;
                    numericBoxGamma.Value = a.Gamma;

                    for (int i = 0; i < a.SpaceGroupList.Length; i++)
                        listBoxSpaceGroupCandidate.SelectedIndex = a.SpaceGroupList[i];

                    //ピーク情報

                    waveLengthControl1.WaveSource = a.Source;
                    waveLengthControl1.WaveLength = a.WaveLength;

                    dataSet.DataTableDiffractionData.Rows.Clear();
                    for (int i = 0; i < a.PeakList.Length; i++)
                        dataSet.DataTableDiffractionData.Rows.Add(a.PeakList[i].Check, a.PeakList[i].D * 10, a.PeakList[i].Intensity, a.PeakList[i].Index);

                    if (a.Candidates != null)
                        for (int i = 0; i < a.Candidates.Length; i++)
                        {
                            double residual = a.Candidates[i].Residual;
                            a.Candidates[i] = Crystal2.GetCrystal(a.Candidates[i].ToCrystal2());
                            a.Candidates[i].Plane = new List<Plane>();
                            a.Candidates[i].Residual = residual;
                            if (a.Planes != null)
                                a.Candidates[i].Plane.AddRange(a.Planes[i]);
                        }

                    dataSet.DataTableCrystalCandidates.Rows.Clear();
                    if (a.Candidates != null)
                        for (int i = 0; i < a.Candidates.Length; i++)
                            dataSet.DataTableCrystalCandidates.Rows.Add(a.Candidates[i], a.Candidates[i].Residual.ToString(), a.Candidates[i].Note);
                    if (a.IonRadius != null)
                        for (int i = 0; i < a.IonRadius.Length && i < ionicRadius.Count; i++)
                            ionicRadius[i].Radius = a.IonRadius[i];

                    numericUpDownIonRadiusThreshold.Value = (decimal)a.IonRadiusAllowance;

                    numericUpDownAngleThreshold.Value = (decimal)a.AngleThreshold;
                    numericUpDownEnergyThreshold.Value = (decimal)a.EnergyThreshold;
                    if (a.Top1 != null && a.Top1.Pt != null) top1.Pt = a.Top1.Pt;
                    if (a.Top10 != null && a.Top10.Pt != null) top10.Pt = a.Top10.Pt;
                    if (a.Top100 != null && a.Top100.Pt != null) top100.Pt = a.Top100.Pt;


                    Step = a.Step;

                    graphControl1.Draw(true);
                }
                catch { }

            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtomicPositionFinderIO a = new AtomicPositionFinderIO();
            //化学情報
            a.chemicalFormulae = textBoxInputFormula.Text;
            a.Znumber = (int)numericUpDownZ.Value;

            //対称性
            a.CrystalSystem = comboBoxCrystalSystem.SelectedIndex;
            a.A = numericBoxA.Value;
            a.B = numericBoxB.Value;
            a.C = numericBoxC.Value;
            a.Alpha = numericBoxAlpha.Value;
            a.Beta = numericBoxBeta.Value;
            a.Gamma = numericBoxGamma.Value;

            List<int> sg = new List<int>();
            for (int i = 0; i < listBoxSpaceGroupCandidate.SelectedIndices.Count; i++)
                sg.Add(listBoxSpaceGroupCandidate.SelectedIndices[i]);
            a.SpaceGroupList = sg.ToArray();

            //ピーク情報
            a.Source = waveLengthControl1.WaveSource;
            a.WaveLength = waveLengthControl1.WaveLength;

            List<Peak> peaks = new List<Peak>();
            for (int i = 0; i < dataSet.DataTableDiffractionData.Rows.Count; i++)
                peaks.Add(new Peak((bool)dataSet.DataTableDiffractionData.Rows[i][0], (double)dataSet.DataTableDiffractionData.Rows[i][1] * 0.1, (double)dataSet.DataTableDiffractionData.Rows[i][2]));
            a.PeakList = peaks.ToArray();

            List<Crystal> cry = new List<Crystal>();
            for (int i = 0; i < dataSet.DataTableCrystalCandidates.Rows.Count; i++)
                cry.Add((Crystal)dataSet.DataTableCrystalCandidates.Rows[i][0]);
            a.Candidates = cry.ToArray();

            a.Planes = new Plane[cry.Count][];
            for (int i = 0; i < cry.Count; i++)
                a.Planes[i] = cry[i].Plane.ToArray();

            List<double> radius = new List<double>();
            for (int i = 0; i < ionicRadius.Count; i++)
                radius.Add(ionicRadius[i].Radius);
            a.IonRadius = radius.ToArray();

            a.IonRadiusAllowance = (double)numericUpDownIonRadiusThreshold.Value;

            a.AngleThreshold = (double)numericUpDownAngleThreshold.Value;
            a.EnergyThreshold = (double)numericUpDownEnergyThreshold.Value;

            a.Top1 = top1;
            a.Top10 = top10;
            a.Top100 = top100;
            a.Step = Step;

            //ここからシリアライズ

            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(AtomicPositionFinderIO));
                System.IO.FileStream fs = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Create);
                serializer.Serialize(fs, a);
                fs.Close();
            }
        }

        #endregion

        #region 確立numericUpDownを変更したとき

        bool eventSkip = false;

        private void numericUpDownRandomization_ValueChanged(object sender, EventArgs e)
        {
            if (eventSkip) return;
            eventSkip = true;
            if (numericUpDownHybridization.Value == 0 && numericUpDownShaking.Value == 0)
            {
                numericUpDownHybridization.Value = (100 - numericUpDownRandomization.Value) / 2;
                numericUpDownShaking.Value = (100 - numericUpDownRandomization.Value) / 2;

            }
            else
            {
                numericUpDownHybridization.Value = (100 - numericUpDownRandomization.Value) * numericUpDownHybridization.Value / (numericUpDownHybridization.Value + numericUpDownShaking.Value);
                numericUpDownShaking.Value = 100 - numericUpDownRandomization.Value - numericUpDownHybridization.Value;
            }
            eventSkip = false;

        }

        private void numericUpDownHybridization_ValueChanged(object sender, EventArgs e)
        {
            if (eventSkip) return;
            eventSkip = true;
            if (numericUpDownShaking.Value == 0 && numericUpDownRandomization.Value == 0)
            {
                numericUpDownShaking.Value = (100 - numericUpDownHybridization.Value) / 2;
                numericUpDownRandomization.Value = (100 - numericUpDownHybridization.Value) / 2;
            }
            else
            {
                numericUpDownShaking.Value = (100 - numericUpDownHybridization.Value) * numericUpDownShaking.Value / (numericUpDownRandomization.Value + numericUpDownShaking.Value);
                numericUpDownRandomization.Value = 100 - numericUpDownShaking.Value - numericUpDownHybridization.Value;
            }
            eventSkip = false;
        }

        private void numericUpDownShaking_ValueChanged(object sender, EventArgs e)
        {
            if (eventSkip) return;
            eventSkip = true;
            if (numericUpDownRandomization.Value == 0 && numericUpDownHybridization.Value == 0)
            {
                numericUpDownRandomization.Value = (100 - numericUpDownShaking.Value) / 2;
                numericUpDownHybridization.Value = (100 - numericUpDownShaking.Value) / 2;
            }
            else
            {
                numericUpDownRandomization.Value = (100 - numericUpDownShaking.Value) * numericUpDownRandomization.Value / (numericUpDownHybridization.Value + numericUpDownRandomization.Value);
                numericUpDownHybridization.Value = 100 - numericUpDownRandomization.Value - numericUpDownShaking.Value;
            }
            eventSkip = false;
        }

        #endregion

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            formMain.formCrystal.crystalControl.Crystal = (Crystal)((DataRowView)bindingSourceCrysatalCandidates.Current).Row[0];
            formMain.formCrystal.crystalControl.GenerateFromInterface();
            Clipboard.SetDataObject(formMain.formCrystal.crystalControl.Crystal);
        }

        private void buttonAddPeak_Click(object sender, EventArgs e)
        {

            dataGridViewDiffractionPeaks.Sort(dataGridViewTextBoxColumn6, ListSortDirection.Descending);

            dataSet.DataTableDiffractionData.Rows.Add(true, numericalTextBoxDspacing.Value, numericalTextBoxIntensity.Value, "");

            getFindingCondition();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            getFindingCondition();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                IDataObject data = Clipboard.GetDataObject();
                String str = (String)data.GetData(typeof(String));
                String[] strList = str.Split(new string[] { "\r\n" },  StringSplitOptions.RemoveEmptyEntries);
                dataSet.DataTableDiffractionData.Rows.Clear();
                if (strList != null)
                {
                    for (int i = 0; i < strList.Length; i++)
                    {
                        String[] temp = strList[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                        dataSet.DataTableDiffractionData.Rows.Add(true, Convert.ToDouble(temp[0]), Convert.ToDouble(temp[4]));
                    }
                }
            }
            catch
            {
            }
        }













    }

    public class AtomicPositionFinderIO
    {
        public string chemicalFormulae;
        public int Znumber;
        public WaveSource Source;
        public double WaveLength;
        public PointD[] Peaks;
        public Peak[] PeakList;
        public int CrystalSystem;
        public int[] SpaceGroupList;
        public double A, B, C, Alpha, Beta, Gamma;
        public double[] IonRadius;
        public double IonRadiusAllowance;
        public Crystal[] Candidates;
        public Plane[][] Planes;
        public Profile Top1, Top10, Top100;
        public double EnergyThreshold;
        public double AngleThreshold;
        public int Step;


    }

    public class Peak : IComparable<Peak>
    {
        public bool Check;
        public double D;
        public double Intensity;
        public string Index;
        public Peak()
        {
            Check = false; D = Intensity = 0; Index = "";
        }
        public Peak(bool check, double d, double intensity)
        {
            D = d; Check = check; Intensity = intensity;
        }

        public int CompareTo(Peak obj)
        {
            return -D.CompareTo(obj.D);
        }
    }

}
