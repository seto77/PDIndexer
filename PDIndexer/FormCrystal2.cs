using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using Crystallography;

namespace PDIndexer
{
    public partial class FormCrystal2 : Form
    {
        public FormCrystal2()
        {
            InitializeComponent();
        }




        private void FormStructure_Load(object sender, System.EventArgs e)
        {


            string str = "Label" + "\t" + "Element" + "\t" + "X" + "\t" + "Y" + "\t" + "Z" + "\t" + "Occ" + "\t" + "Multi." + "\t" + "WyckLet" + "\t" + "SiteSym";
            listBox1.Items.Add(str);
            str = "No.\tX\tY\tZ";
            listBox2.Items.Add(str);
            comboBoxAtom.SelectedIndex = 0;
            comboBoxCrystalSystem.SelectedIndex = 0;
        }

        private void textBox_TextChanged(object sender, System.EventArgs e)
        {
            SetCrystalFromForm();
        }

        bool IsComboBoxChangeEventSkip = false;
        private void comboBoxCrystalSystem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            IsComboBoxChangeEventSkip = true;
            comboBoxPointGroup.Items.Clear();
            comboBoxSpaceGroup.Items.Clear();
            Symmetry symmetry;
            for (int n = 0; n < Symmetry.BelongingNumberOfSymmetry[comboBoxCrystalSystem.SelectedIndex].Length; n++)
            {
                symmetry = Symmetry.Get_Symmetry(Symmetry.BelongingNumberOfSymmetry[comboBoxCrystalSystem.SelectedIndex][n][0]);
                if (symmetry.CrystalSystem == comboBoxCrystalSystem.Text)
                    if (comboBoxPointGroup.Items.Contains(symmetry.PointGroupHM) == false)
                        comboBoxPointGroup.Items.Add(symmetry.PointGroupHM);
            }
            IsComboBoxChangeEventSkip = false;
            comboBoxPointGroup.SelectedIndex = 0;
            comboBoxPointGroup_SelectedIndexChanged(new object(), new System.EventArgs());
        }

        private void comboBoxPointGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (IsComboBoxChangeEventSkip) return;
            IsComboBoxChangeEventSkip = true;
            comboBoxSpaceGroup.Items.Clear();
            Symmetry symmetry;
            for (int n = 0; n < Symmetry.BelongingNumberOfSymmetry[comboBoxCrystalSystem.SelectedIndex][comboBoxPointGroup.SelectedIndex].Length; n++)
            {
                symmetry = Symmetry.Get_Symmetry(Symmetry.BelongingNumberOfSymmetry[comboBoxCrystalSystem.SelectedIndex][comboBoxPointGroup.SelectedIndex][n]);
                if (symmetry.PointGroupHM == comboBoxPointGroup.Text)
                    comboBoxSpaceGroup.Items.Add(symmetry.SpaceGroupHM);
            }
            IsComboBoxChangeEventSkip = false;
            comboBoxSpaceGroup.SelectedIndex = 0;
            comboBoxSpaceGroup_SelectedIndexChanged(new object(), new System.EventArgs());
        }

        private void comboBoxSpaceGroup_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (IsComboBoxChangeEventSkip) return;

            SymmetrySeriesNumber = Symmetry.BelongingNumberOfSymmetry[comboBoxCrystalSystem.SelectedIndex][comboBoxPointGroup.SelectedIndex][comboBoxSpaceGroup.SelectedIndex];

            SetCrystalFromForm();
        }

        private void SetTextBox()
        {
            if (IsSkipChangeEvent) return;
            Symmetry tempSym = Symmetry.Get_Symmetry(SymmetrySeriesNumber);
            IsSkipChangeEvent = true;
            switch (tempSym.CrystalSystem)
            {
                case "Unknown": textBoxA.ReadOnly = false; textBoxB.ReadOnly = false; textBoxC.ReadOnly = false; textBoxAlfa.ReadOnly = false; textBoxBeta.ReadOnly = false; textBoxGamma.ReadOnly = false; break;
                case "triclinic": textBoxA.ReadOnly = false; textBoxB.ReadOnly = false; textBoxC.ReadOnly = false; textBoxAlfa.ReadOnly = false; textBoxBeta.ReadOnly = false; textBoxGamma.ReadOnly = false; break;
                case "monoclinic": textBoxA.ReadOnly = false; textBoxB.ReadOnly = false; textBoxC.ReadOnly = false;
                    switch (tempSym.MainAxis)
                    {
                        case "a": textBoxAlfa.ReadOnly = false; textBoxBeta.ReadOnly = true; textBoxGamma.ReadOnly = true; textBoxBeta.Text = "90"; textBoxGamma.Text = "90"; break;
                        case "b": textBoxAlfa.ReadOnly = true; textBoxBeta.ReadOnly = false; textBoxGamma.ReadOnly = true; textBoxAlfa.Text = "90"; textBoxGamma.Text = "90"; break;
                        case "c": textBoxAlfa.ReadOnly = true; textBoxBeta.ReadOnly = true; textBoxGamma.ReadOnly = false; textBoxAlfa.Text = "90"; textBoxBeta.Text = "90"; break;
                    } break;
                case "orthorhombic": textBoxA.ReadOnly = false; textBoxB.ReadOnly = false; textBoxC.ReadOnly = false; textBoxAlfa.ReadOnly = true; textBoxBeta.ReadOnly = true; textBoxGamma.ReadOnly = true; textBoxAlfa.Text = "90"; textBoxBeta.Text = "90"; textBoxGamma.Text = "90"; break;
                case "tetragonal": textBoxA.ReadOnly = false; textBoxB.ReadOnly = true; textBoxC.ReadOnly = false; textBoxB.Text = textBoxA.Text; textBoxAlfa.ReadOnly = true; textBoxBeta.ReadOnly = true; textBoxGamma.ReadOnly = true; textBoxAlfa.Text = "90"; textBoxBeta.Text = "90"; textBoxGamma.Text = "90"; break;
                case "trigonal":
                    switch (tempSym.SpaceGroupHM.IndexOf("Rho") >= 0 && tempSym.SpaceGroupHM.IndexOf("R") >= 0)
                    {
                        case false: textBoxA.ReadOnly = false; textBoxB.ReadOnly = true; textBoxC.ReadOnly = false; textBoxB.Text = textBoxA.Text; textBoxAlfa.ReadOnly = true; textBoxBeta.ReadOnly = true; textBoxGamma.ReadOnly = true; textBoxAlfa.Text = "90"; textBoxBeta.Text = "90"; textBoxGamma.Text = "120"; break;
                        case true: textBoxA.ReadOnly = false; textBoxB.ReadOnly = true; textBoxC.ReadOnly = true; textBoxB.Text = textBoxA.Text; textBoxC.Text = textBoxA.Text; textBoxAlfa.ReadOnly = false; textBoxBeta.ReadOnly = true; textBoxGamma.ReadOnly = true; textBoxBeta.Text = textBoxAlfa.Text; textBoxGamma.Text = textBoxAlfa.Text; break;
                    } break;
                case "hexagonal": textBoxA.ReadOnly = false; textBoxB.ReadOnly = true; textBoxC.ReadOnly = false; textBoxB.Text = textBoxA.Text; textBoxAlfa.ReadOnly = true; textBoxBeta.ReadOnly = true; textBoxGamma.ReadOnly = true; break;
                case "cubic": textBoxA.ReadOnly = false; textBoxB.ReadOnly = true; textBoxC.ReadOnly = true; textBoxB.Text = textBoxA.Text; textBoxC.Text = textBoxA.Text; textBoxAlfa.ReadOnly = true; textBoxBeta.ReadOnly = true; textBoxGamma.ReadOnly = true; textBoxAlfa.Text = "90"; textBoxBeta.Text = "90"; textBoxGamma.Text = "90"; break;
            }
            IsSkipChangeEvent = false;
        }

        /// <summary>
        /// 現在の入力情報からCrystalを生成する
        /// </summary>
        private void SetCrystalFromForm()
        {
            if (IsSkipChangeEvent) return;
            double a, b, c, alfa, beta, gamma;
            try
            {
                a = Convert.ToDouble(textBoxA.Text);
                b = Convert.ToDouble(textBoxB.Text);
                c = Convert.ToDouble(textBoxC.Text);
                alfa = Convert.ToDouble(textBoxAlfa.Text);
                beta = Convert.ToDouble(textBoxBeta.Text);
                gamma = Convert.ToDouble(textBoxGamma.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("数値を入力してください");
                return;
            }
            if (alfa < 0 || beta < 0 || gamma < 0 || alfa > 180 || beta > 180 || gamma > 180)
            {
                MessageBox.Show("0～180の範囲で入力してください");
                return;
            }

            ArrayList al = new ArrayList();

            for (int i = 0; i < listBoxAtoms.Items.Count; i++)
            {
                Atoms atom = (Atoms)listBoxAtoms.Items[i];
                Atoms temp = new Atoms(atom.label, atom.scatteringFactorNumber, atom.atom[0], atom.occ, Symmetry.Get_Symmetry(SymmetrySeriesNumber), atom.dsf);
                temp.str = atom.label + "\t" + atom.element + "\t" + GetStringFromDouble(temp.atom[0].X) + "\t" + GetStringFromDouble(temp.atom[0].Y) + "\t" + GetStringFromDouble(temp.atom[0].Z) + "\t" + GetStringFromDouble(temp.occ) + "\t" + temp.multi.ToString() + "\t" + temp.wyckLet + "\t" + temp.siteSym;
                listBoxAtoms.Items[i] = temp;
                al.Add(temp);
            }

            Atoms[] atoms = (Atoms[])al.ToArray(typeof(Atoms));
            string aurhor = textBoxAuthor.Text;
            presentCrystal = new Crystal(a / 10, b / 10, c / 10, alfa * Math.PI / 180, beta * Math.PI / 180, gamma * Math.PI / 180,
                SymmetrySeriesNumber, textBoxName.Text, textBoxMemo.Text, pictureBoxColor.BackColor,
                atoms, aurhor, textBoxJournal.Text, textBoxTitle.Text);
            SetFormFromCrystal(presentCrystal);
        }

        private void textBoxNumOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '.' || e.KeyChar > '9') && e.KeyChar != '\b')
                e.Handled = true;
        }


        /// <summary>
        /// 外部から結晶を変更されたとき
        /// </summary>
        /// <param name="crystal"></param>
        public void CrystalChanged(Crystal crystal)
        {
            presentCrystal = crystal;
            SetFormFromCrystal(presentCrystal);
        }

        public void SetFormFromCrystal(Crystal crystal)
        {
            if (IsSkipChangeEvent) return;
            IsSkipChangeEvent = true;
            int d = Environment.TickCount;

            pictureBoxColor.BackColor = crystal.color;
            textBoxName.Text = crystal.name;
            textBoxMemo.Text = crystal.note;

            textBoxAuthor.Text = "";
            if (crystal.publAuthorName != null)
                for (int i = 0; i < crystal.publAuthorName.Length; i++)
                    textBoxAuthor.Text += crystal.publAuthorName[i] + "\r\n";
            textBoxJournal.Text = crystal.journal;
            textBoxFormula.Text = crystal.chemicalFormula;
            textBoxTitle.Text = crystal.publSectionTitle;

            textBoxFormula.Text = crystal.chemicalFormula;
            textBoxDensity.Text = crystal.density.ToString("f5");

            textBoxA.Text = (crystal.a * 10).ToString("f5");
            textBoxB.Text = (crystal.b * 10).ToString("f5");
            textBoxC.Text = (crystal.c * 10).ToString("f5");
            textBoxAlfa.Text = (crystal.alfa * 180 / Math.PI).ToString();
            textBoxBeta.Text = (crystal.beta * 180 / Math.PI).ToString();
            textBoxGamma.Text = (crystal.gamma * 180 / Math.PI).ToString();

            //MessageBox.Show((Environment.TickCount - d).ToString());
            d = Environment.TickCount;

            comboBoxCrystalSystem.Text = crystal.symmetry.CrystalSystem;
            comboBoxPointGroup.Text = crystal.symmetry.PointGroupHM;
            comboBoxSpaceGroup.Text = crystal.symmetry.SpaceGroupHM;

            //MessageBox.Show((Environment.TickCount - d).ToString());
            d = Environment.TickCount;

            listBoxAtoms.Items.Clear();
            Atoms atoms;
            if (crystal.atoms != null)
                for (int i = 0; i < crystal.atoms.Length; i++)
                {
                    atoms = crystal.atoms[i];
                    atoms.str = atoms.label + "\t" + atoms.element + "\t" + GetStringFromDouble(atoms.atom[0].X) + "\t" + GetStringFromDouble(atoms.atom[0].Y) + "\t" + GetStringFromDouble(atoms.atom[0].Z) + "\t" + GetStringFromDouble(atoms.occ) + "\t" + atoms.multi.ToString() + "\t" + atoms.wyckLet + "\t" + atoms.siteSym;
                    listBoxAtoms.Items.Add(atoms);
                }
            IsSkipChangeEvent = false;
            SetTextBox();

            //MessageBox.Show((Environment.TickCount - d).ToString());
        }


        private void pictureBoxColor_Click(object sender, System.EventArgs e)
        {
            if (presentCrystal == null) return;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = presentCrystal.color;
            colorDialog.AllowFullOpen = true; colorDialog.AnyColor = true; colorDialog.SolidColorOnly = false; colorDialog.ShowHelp = true;
            colorDialog.ShowDialog();
            pictureBoxColor.BackColor = colorDialog.Color;
            SetCrystalFromForm();
        }

        private void buttonAddCrystal_Click(object sender, System.EventArgs e)
        {
            SetCrystalFromForm();
            if (presentCrystal != null) formMain.AddCrystal(presentCrystal);
        }

        private void buttonChangeCrystal_Click(object sender, System.EventArgs e)
        {
            SetCrystalFromForm();
            if (presentCrystal != null) formMain.ChangeCrystal(presentCrystal);
        }

        private void textBoxName_TextChanged(object sender, System.EventArgs e)
        {
            SetCrystalFromForm();
        }


        //等価位置原子リストボックス描画
        private void SetListBoxEachAtoms(Atoms atoms)
        {
            listBoxEachAtoms.Items.Clear();
            for (int i = 0; i < atoms.atom.Length; i++)
                listBoxEachAtoms.Items.Add((i + 1).ToString() + "\t" + GetStringFromDouble(atoms.atom[i].X) + "\t" + GetStringFromDouble(atoms.atom[i].Y) + "\t" + GetStringFromDouble(atoms.atom[i].Z));
        }

        //原子追加ボタン
        private void buttonAddAtom_Click(object sender, System.EventArgs e)
        {
            Atoms atoms = GetAtomsFromTextBox();
            listBoxAtoms.Items.Add(atoms);
            listBoxAtoms.SelectedIndex = listBoxAtoms.Items.Count - 1;
            SetListBoxEachAtoms(atoms);
            SetCrystalFromForm();
        }

        //原子変更ボタン
        private void buttonChangeAtom_Click(object sender, System.EventArgs e)
        {
            if (listBoxAtoms.SelectedIndex < 0) return;
            Atoms atoms = GetAtomsFromTextBox();
            int selectedIndex = listBoxAtoms.SelectedIndex;
            listBoxAtoms.Items.RemoveAt(selectedIndex);
            listBoxAtoms.Items.Insert(selectedIndex, atoms);
            listBoxAtoms.SelectedIndex = selectedIndex; ;
            SetListBoxEachAtoms(atoms);
            SetCrystalFromForm();
        }

        //原子削除ボタン
        private void buttonDeleteAtom_Click(object sender, System.EventArgs e)
        {
            if (listBoxAtoms.SelectedIndex < 0) return;
            else listBoxAtoms.Items.Remove(listBoxAtoms.SelectedItem);
            SetCrystalFromForm();
        }


        //テキストボックスの入力値からatomsを返す
        private Atoms GetAtomsFromTextBox()
        {
            double x, y, z, occ, Biso, B11, B22, B33, B12, B23, B31;
            x = y = z = occ = Biso = B11 = B22 = B33 = B12 = B23 = B31 = 0;

            x = GetDoubleFromString(this.textBoxX.Text);
            y = GetDoubleFromString(this.textBoxY.Text);
            z = GetDoubleFromString(this.textBoxZ.Text);
            try
            {
                occ = Convert.ToDouble(this.textBoxOcc.Text);
                Biso = Convert.ToDouble(this.textBoxBiso.Text);
                B11 = Convert.ToDouble(this.textBoxB11.Text);
                B22 = Convert.ToDouble(this.textBoxB22.Text);
                B33 = Convert.ToDouble(this.textBoxB33.Text);
                B12 = Convert.ToDouble(this.textBoxB12.Text);
                B23 = Convert.ToDouble(this.textBoxB23.Text);
                B31 = Convert.ToDouble(this.textBoxB13.Text);
            }
            catch
            {
                MessageBox.Show("数値を入力してください。"); return new Atoms();
            }
            DiffuseScatteringFactor dsf = new DiffuseScatteringFactor(radioButtonIsotoropy.Checked, Biso, B11, B22, B33, B12, B23, B31);
            Atoms atoms = new Atoms(textBoxLabel.Text, atomSeriesNum, new Vector3D(x, y, z), occ, Symmetry.Get_Symmetry(SymmetrySeriesNumber), dsf);
            atoms.str = atoms.label + "\t" + atoms.element + "\t" + GetStringFromDouble(atoms.atom[0].X) + "\t" + GetStringFromDouble(atoms.atom[0].Y) + "\t" + GetStringFromDouble(atoms.atom[0].Z) + "\t" + GetStringFromDouble(atoms.occ) + "\t" + atoms.multi.ToString() + "\t" + atoms.wyckLet + "\t" + atoms.siteSym;
            return atoms;
        }

        private void textBoxX_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '.' || e.KeyChar > '9') && e.KeyChar != '\b')
                e.Handled = true;
        }

        private string GetStringFromDouble(double d)
        {
            if (Math.Abs(d - 0.125) < 0.000000001) return "1/8";
            else if (Math.Abs(d - 0.375) < 0.000000001) return "3/8";
            else if (Math.Abs(d - 0.625) < 0.000000001) return "5/8";
            else if (Math.Abs(d - 0.875) < 0.000000001) return "7/8";
            else if (Math.Abs(d - 0.25) < 0.000000001) return "1/4";
            else if (Math.Abs(d - 0.75) < 0.000000001) return "3/4";
            else if (Math.Abs(d - 0.5) < 0.000000001) return "1/2";
            else if (Math.Abs(d - 1.0 / 3.0) < 0.000000001) return "1/3";
            else if (Math.Abs(d - 2.0 / 3.0) < 0.000000001) return "2/3";
            else if (Math.Abs(d - 1.0 / 6.0) < 0.000000001) return "1/6";
            else if (Math.Abs(d - 5.0 / 6.0) < 0.000000001) return "5/6";
            else return d.ToString("g6");
        }

        private double GetDoubleFromString(string s)
        {
            if (s == "1/8" || s == "1.0/8.0") return 1.0 / 8.0;
            else if (s == "3/8" || s == "3.0/8.0") return 3.0 / 8.0;
            else if (s == "5/8" || s == "5.0/8.0") return 5.0 / 8.0;
            else if (s == "7/8" || s == "7.0/8.0") return 7.0 / 8.0;
            else if (s == "1/4" || s == "1.0/4.0") return 1.0 / 4.0;
            else if (s == "3/4" || s == "3.0/4.0") return 3.0 / 4.0;
            else if (s == "1/2" || s == "1.0/2.0") return 1.0 / 2.0;
            else if (s == "1/3" || s == "1.0/3.0") return 1.0 / 3.0;
            else if (s == "2/3" || s == "2.0/3.0") return 2.0 / 3.0;
            else if (s == "1/6" || s == "1.0/6.0") return 1.0 / 6.0;
            else if (s == "5/6" || s == "5.0/6.0") return 5.0 / 6.0;
            else try { return Convert.ToDouble(s); }
                catch { MessageBox.Show("数値を入力してください"); return 0; }
        }


        //原子番号コンボ
        private void comboBoxAtom_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBoxAtom.SelectedIndex < 0) return;
            comboBoxAtomSub.Items.Clear();
            AtomicScatteringFactor asf;
            for (int n = 1; n <= 211; n++)
            {
                asf = AtomicScatteringFactor.GetCoefficient(n);
                if (asf.AtomicNumber == comboBoxAtom.SelectedIndex + 1)
                    comboBoxAtomSub.Items.Add(asf.NameSub);
            }
            comboBoxAtomSub.SelectedIndex = 0;
        }

        //散乱因子を選択変更されたら
        private void comboBoxAtomSub_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            AtomicScatteringFactor asf;
            for (int n = 1; n <= 211; n++)
            {
                asf = AtomicScatteringFactor.GetCoefficient(n);
                if (asf.NameSub == (string)comboBoxAtomSub.SelectedItem)
                    atomSeriesNum = n;
            }
        }

        //原子位置リストボックスを変更
        private void listBoxAtoms_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listBoxAtoms.SelectedIndex < 0) return;
            else
            {
                Atoms atoms = (Atoms)listBoxAtoms.SelectedItem;
                SetListBoxEachAtoms(atoms);
                SetTextBoxFromAtoms(atoms);
            }
        }

        //Atomsからテキストボックスを変更
        private void SetTextBoxFromAtoms(Atoms atoms)
        {
            textBoxLabel.Text = atoms.label;
            comboBoxAtom.SelectedIndex = atoms.asf.AtomicNumber - 1;
            comboBoxAtomSub.SelectedIndex = atoms.asf.AtomicNumberSub - 1;
            textBoxX.Text = atoms.atom[0].X.ToString();
            textBoxY.Text = atoms.atom[0].Y.ToString();
            textBoxZ.Text = atoms.atom[0].Z.ToString();
            textBoxOcc.Text = atoms.occ.ToString();
            textBoxBiso.Text = atoms.dsf.Biso.ToString();
            textBoxB11.Text = atoms.dsf.B11.ToString();
            textBoxB12.Text = atoms.dsf.B12.ToString();
            textBoxB13.Text = atoms.dsf.B31.ToString();
            textBoxB22.Text = atoms.dsf.B22.ToString();
            textBoxB23.Text = atoms.dsf.B23.ToString();
            textBoxB33.Text = atoms.dsf.B33.ToString();
            radioButtonIsotoropy.Checked = atoms.dsf.IsIso;
        }

        private void FormCrystal_Closed(object sender, System.EventArgs e)
        {
            if (formMain != null)
                formMain.checkBoxCrystal.Checked = false;
        }


        private void radioButtonIsotoropy_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButtonIsotoropy.Checked)
            {
                textBoxBiso.Enabled = true;
                textBoxB11.Enabled = false;
                textBoxB22.Enabled = false;
                textBoxB33.Enabled = false;
                textBoxB12.Enabled = false;
                textBoxB23.Enabled = false;
                textBoxB13.Enabled = false;
            }
            else
            {
                textBoxBiso.Enabled = false;
                textBoxB11.Enabled = true;
                textBoxB22.Enabled = true;
                textBoxB33.Enabled = true;
                textBoxB12.Enabled = true;
                textBoxB23.Enabled = true;
                textBoxB13.Enabled = true;
            }

        }

        private void textBoxSearch_TextChanged(object sender, System.EventArgs e)
        {
            comboBoxSearchResult.Items.Clear();
            comboBoxSearchResult.Enabled = false;
            char[] c;
            if (textBoxSearch.Text.Length == 0)
                return;
            else
                c = textBoxSearch.Text.ToCharArray();
            Symmetry sym;
            int startIndex = 0;
            int index;
            for (int n = 0; n <= 534; n++)
            {
                sym = Symmetry.Get_Symmetry(n);
                startIndex = -1;
                for (int i = 0; i < c.Length; i++)
                {
                    index = sym.SpaceGroupHM.IndexOf(c[i], startIndex + 1);
                    if (index >= 0)
                        startIndex = index;
                    else
                    {
                        startIndex = -1;
                        break;
                    }
                }
                if (startIndex >= 0)
                    comboBoxSearchResult.Items.Add(sym.SpaceGroupHM);
            }
            if (comboBoxSearchResult.Items.Count > 0)
                comboBoxSearchResult.Enabled = true;

        }

        private void comboBoxSearchResult_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Symmetry sym = Symmetry.Get_Symmetry(0);
            for (int n = 0; n <= 534; n++)
            {
                sym = Symmetry.Get_Symmetry(n);
                if (comboBoxSearchResult.Text == sym.SpaceGroupHM)
                    break;
            }
            comboBoxCrystalSystem.Text = sym.CrystalSystem;
            comboBoxPointGroup.Text = sym.PointGroupHM;
            comboBoxSpaceGroup.Text = sym.SpaceGroupHM;
        }


        private void FormCrystal_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            try
            {
                if (fileName[0].EndsWith("amc"))
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(fileName[0]);
                    ArrayList al = new ArrayList();
                    string str;
                    while ((str = reader.ReadLine()) != null)
                        al.Add(str);

                    string[] amc = (string[])al.ToArray(typeof(string));

                    Crystal c = ConvertCrystalData.ConvertFromAmc(amc);
                    reader.DiscardBufferedData();
                    reader.Close();
                    CrystalChanged(c);
                }
                else if (fileName[0].EndsWith("cif"))
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(fileName[0]);
                    ArrayList al = new ArrayList();
                    string str;
                    while ((str = reader.ReadLine()) != null)
                        al.Add(str);

                    string[] cif = (string[])al.ToArray(typeof(string));

                    Crystal c = ConvertCrystalData.ConvertFromCIF(cif);
                    reader.DiscardBufferedData();
                    reader.Close();
                    CrystalChanged(c);
                }
            }
            catch { return; }
        }

        private void FormCrystal_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetData(DataFormats.FileDrop) != null) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            string filter = "";
            if (checkBoxSearchName.Checked)
            {
                string[] str = textBoxSearchName.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 0)
                {
                    filter = "( ";
                    foreach (string s in str)
                        filter += "ColumnName LIKE '*" + s + "*' AND ";
                    filter = filter.Remove(filter.Length - 4, 3) + ") AND ";
                }
            }

            if (checkBoxSearchRefference.Checked)
            {
                string[] str = textBoxSearchRefference.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 0)
                {
                    filter += "( ";
                    foreach (string s in str)
                        filter +=
                              "( ColumnAuthor LIKE '*" + s + "*' OR "
                            + "ColumnTitle LIKE '*" + s + "*' OR "
                            + "ColumnJournal LIKE '*" + s + "*' ) AND ";
                    filter = filter.Remove(filter.Length - 4, 3) + " ) AND ";
                }
            }

            if (checkBoxSearchCrystalSystem.Checked)
                filter += " ColumnCrystalSystem = '" + comboBoxSearchCrystalSystem.Text + "' AND ";

            if (checkBoxSearchPointGroup.Checked)
                filter += " ColumnPointGroup = '" + comboBoxSearchPointGroup.Text + "' AND ";

            if (checkBoxSearchSpaceGroup.Checked)
                filter += " ColumnSpaceGroup = '" + comboBoxSpaceGroup.Text + "' AND ";

            if (checkBoxSearchIncludingElements.Checked)
            {
                string[] str = textBoxSearchIncludingElements.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 0)
                {
                    filter += "(";
                    foreach (string s in str)
                        filter += "ColumnFormula LIKE '*" + s + "*' AND ";
                    filter = filter.Remove(filter.Length - 4, 3) + ") AND ";
                }
            }

            if (checkBoxSearchExcludingElements.Checked)
            {
                string[] str = textBoxSearchExcludingElements.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 0)
                {
                    filter += "( ";
                    foreach (string s in str)
                        filter += "( NOT (ColumnFormula LIKE '*" + s + "*' ) ) AND ";
                    filter = filter.Remove(filter.Length - 4, 3) + ") AND ";
                }
            }
            if (filter != "")
                filter = filter.Remove(filter.Length - 4, 3);
            bindingSource.Filter = filter;
        }

        private void checkBoxSearch_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSearchAllField.Enabled = checkBoxSearchAllField.Checked ? true : false;
            textBoxSearchExcludingElements.Enabled = checkBoxSearchExcludingElements.Checked ? true : false;
            textBoxSearchIncludingElements.Enabled = checkBoxSearchIncludingElements.Checked ? true : false;
            textBoxSearchRefference.Enabled = checkBoxSearchRefference.Checked ? true : false;
            textBoxSearchName.Enabled = checkBoxSearchName.Checked ? true : false;
            comboBoxSearchCrystalSystem.Enabled = checkBoxSearchCrystalSystem.Checked ? true : false;
            comboBoxSearchPointGroup.Enabled = checkBoxSearchPointGroup.Checked ? true : false;
            comboBoxSearchSpaceGroup.Enabled = checkBoxSearchSpaceGroup.Checked ? true : false;
            groupBoxCellParameter.Enabled = checkBoxSearchCellParameter.Checked ? true : false;
        }

        System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection();
        System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
        OpenFileDialog dialog = new OpenFileDialog();
        OleDbDataAdapter OleDA;
        DataSet dtSet = new DataSet(" ");
        OleDbCommandBuilder odcb;
        private void readDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region
            /*OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Database File[*.cdb]|*.cdb;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    System.IO.FileStream fs = new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Open);//ファイルを開く
                    CrystalSimpleFormat[] c = (CrystalSimpleFormat[])bf.Deserialize(fs);//バイナリファイルから読み込み、逆シリアル化する
                    fs.Close();//閉じる

                    foreach (CrystalSimpleFormat crystal in c)
                        dataSet.Tables[0].Rows.Add(GetTabelRows(crystal));
                }
                catch
                { }
            }*/
            #endregion

            cn.Close();
            dialog.Filter = "Database File[*.mdb]|*.mdb;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //接続文字列の設定
                cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + dialog.FileName;
                cn.Open();
                odcb = new OleDbCommandBuilder(OleDA);
                OleDA = new OleDbDataAdapter();

                dtSet = new DataSet();
                dtSet.Tables.Add();
                dtSet.Tables.Add();
                dtSet.Tables.Add();

                OleDA.SelectCommand = new OleDbCommand("SELECT * FROM Main", cn);
                OleDA.Fill(dtSet.Tables[0]);//データセットのテーブル[0]にメインデータを取得する

                bindingSource.DataSource = dtSet;
                bindingSource.DataMember = dtSet.Tables[0].ToString();

                ColumnName.DataPropertyName = "Name";
                ColumnFormula.DataPropertyName = "Formula";
            }
        }


        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int n = (int)((System.Data.DataRowView)bindingSource.Current).Row[0];
                OleDA.SelectCommand = new OleDbCommand("SELECT * FROM Atom WHERE ID=" + n.ToString(), cn);
                dtSet.Tables[1].Rows.Clear();
                OleDA.Fill(dtSet.Tables[1]);//データセットにアトムデータを取得する
                CrystalChanged(GetCrystalFromDataSet(((System.Data.DataRowView)bindingSource.Current).Row, dtSet.Tables[1]));
            }
            catch { }

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            OleDA.Update(dtSet);
        }

        private Crystal GetCrystalFromDataSet(DataRow row, DataTable atomTable)
        {
            Crystal crystal = new Crystal((double)row[4], (double)row[5], (double)row[6], (double)row[7], (double)row[8], (double)row[9]
                , (int)row[10], row[1].ToString(), row[2].ToString(), Color.FromArgb((int)row[14]));
            crystal.publAuthorName = row[11].ToString();
            crystal.publSectionTitle = row[12].ToString();
            crystal.journal = row[13].ToString();

            foreach (DataRow r in atomTable.Rows)
                crystal.AddAtoms(new Atoms(r[1].ToString(), (int)r[2], new Vector3D((double)r[3], (double)r[4], (double)r[5]), (double)r[6], crystal.symmetry,
                    new DiffuseScatteringFactor((bool)r[7], (double)r[8], (double)r[9], (double)r[10], (double)r[11], (double)r[12], (double)r[13], (double)r[14])));
            return crystal;
        }

        private void GetDataSetFromCrystal(Crystal crystal, ref DataSet dataset)
        {
            DataTable temp = new DataTable();
            temp.Rows.Add(new object[]{
                null,crystal.name,crystal.note,crystal.chemicalFormula,crystal.a,crystal.b,crystal.c,crystal.alfa,crystal.beta,crystal.gamma,
                crystal.publAuthorName,crystal.publSectionTitle,crystal.journal,crystal.color.ToArgb()
            });
            row = temp.Rows[0];

            atomTable = new DataTable();
            foreach (Atoms atoms in crystal.atoms)
                atomTable.Rows.Add(new object[]{
                    atoms.label,atoms.scatteringFactorNumber,atoms.atom[0].X,atoms.atom[0].Y,atoms.atom[0].Z,atoms.occ,
                    atoms.dsf.IsIso,atoms.dsf.Biso,atoms.dsf.B11,atoms.dsf.B22,atoms.dsf.B33,atoms.dsf.B12,atoms.dsf.B23,atoms.dsf.B31
                });
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        //開発用
        private void button1_Click(object sender, EventArgs e)
        {
            #region
            /*//ここからAMCSD
            string fnAmc;
            string[] amc;
            ArrayList cry = new ArrayList();
            CrystalSimpleFormat temp;
            for (int n =1; n < 10000; n++)
            {
                fnAmc = @"D:\My Documents\Downloaded Files\amc\" + n.ToString("d5") + ".amc";
                if (System.IO.File.Exists(fnAmc))
                {
                    try
                    {
                        System.IO.StreamReader reader = new System.IO.StreamReader(fnAmc);
                        ArrayList al = new ArrayList();
                        string str;
                        while ((str = reader.ReadLine()) != null)
                            al.Add(str);

                        amc = (string[])al.ToArray(typeof(string));

                        temp=CrystalSimpleFormat.GetCrystalSimpleFormat( ConvertCrystalData.ConvertFromAmc(amc));
                        if (temp == null)
                            throw new FormatException();
                        else
                            cry.Add(temp);
                        reader.Close();
                    }
                    catch {
                        ;
                    }
                }
            }
            CrystalSimpleFormat[] c = (CrystalSimpleFormat[])cry.ToArray(typeof(CrystalSimpleFormat));
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.FileStream fs = new System.IO.FileStream("AMCSD.cdb", System.IO.FileMode.Create);
            bf.Serialize(fs, c);//シリアル化し、バイナリファイルに保存する
            fs.Close();//閉じる

            //ここからCOD
            string[] cif;
            cry = new ArrayList();
            
                System.IO.DirectoryInfo current = new System.IO.DirectoryInfo(@"D:\My Documents\Downloaded Files\cif\");

                System.Collections.Generic.List<string> fnCif = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> failedFile = new System.Collections.Generic.List<string>();
                foreach (System.IO.FileInfo file in current.GetFiles())            // ファイルの一覧表示
                    fnCif.Add(file.FullName);

                foreach (string filename in fnCif)
                {
                    try
                    {
                        System.IO.StreamReader reader = new System.IO.StreamReader(filename);
                        ArrayList al = new ArrayList();
                        string str;
                        while ((str = reader.ReadLine()) != null)
                            al.Add(str);

                        cif = (string[])al.ToArray(typeof(string));
                        
                        temp = CrystalSimpleFormat.GetCrystalSimpleFormat(ConvertCrystalData.ConvertFromCIF(cif));
                        if (temp == null)
                            throw new FormatException();
                        else
                            cry.Add(temp);
                        reader.Close();
                    }
                    catch{
                        failedFile.Add(filename);
                    }
            }
            
            c = (CrystalSimpleFormat[])cry.ToArray(typeof(CrystalSimpleFormat));
            bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            fs = new System.IO.FileStream("COD.cdb", System.IO.FileMode.Create);
            bf.Serialize(fs, c);//シリアル化し、バイナリファイルに保存する
            fs.Close();//閉じる*/
            #endregion

            string[] cif;
            Crystal temp;

            System.IO.DirectoryInfo current = new System.IO.DirectoryInfo(@"D:\My Documents\Downloaded Files\cif\");
            System.Collections.Generic.List<string> fnCif = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> failedFile = new System.Collections.Generic.List<string>();
            foreach (System.IO.FileInfo file in current.GetFiles())            // ファイルの一覧表示
                fnCif.Add(file.FullName);

            foreach (string filename in fnCif)
            {
                try
                {
                    System.IO.StreamReader reader = new System.IO.StreamReader(filename);
                    ArrayList al = new ArrayList();
                    string str;
                    while ((str = reader.ReadLine()) != null)
                        al.Add(str);

                    cif = (string[])al.ToArray(typeof(string));

                    temp = ConvertCrystalData.ConvertFromCIF(cif);

                    if (temp == null)
                        throw new FormatException();
                    else
                        GetDataSetFromCrystal(temp, ref dtSet);
                    reader.Close();
                }
                catch
                {
                    failedFile.Add(filename);
                }
            }
        }

    }






}