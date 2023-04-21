#region using, namespace
using Crystallography.Controls;
using Crystallography;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace PDIndexer;
#endregion

/// <summary>
/// PDIのマクロ操作を提供する
/// </summary>
public class Macro : MacroBase
{
    #region 基底クラス
    private readonly FormMain main;
    public DrawingClass Drawing;
    public ProfileListClass ProfileList;
    public ProfileClass Profile;
    public ProfileOperatorClass ProfileOperator;
    public FileClass File;
    public CrystalListClass CrystalList;
    public CrystalClass Crystal;
    public FittingClass Fitting;
    public SequentialClass Sequential;

    public Macro(FormMain _main) : base(_main, "PDI")
    {
        main = _main;
        Drawing = new DrawingClass(this);
        ProfileList = new ProfileListClass(this);
        Profile = new ProfileClass(this);
        ProfileOperator = new ProfileOperatorClass(this);
        File = new FileClass(this);
        CrystalList = new CrystalListClass(this);
        Crystal = new CrystalClass(this);
        Fitting = new FittingClass(this);

        Sequential = new SequentialClass(this);

        help.Add("PDI.Obj[] # Get object sent from other program.");
        help.Add("PDI.Sleep(int millisec) # Sleep.");
    }

    public static void Sleep(int millisec) => Thread.Sleep(millisec);
    public object[] Obj { get; set; }

    #endregion

    #region Fileクラス ファイル入出力関係

    /// <summary>
    /// ファイル入出力関係
    /// </summary>
    public class FileClass : MacroSub
    {
        private readonly Macro p;
        public FileClass(Macro _p) : base(_p.main)
        {
            this.p = _p;
            p.help.Add("PDI.File.GetFileName() # Get a file name.  \r\n Returned string is a full path of the selected file.");
            p.help.Add("PDI.File.GetFileNames() # Get file names.  \r\n Returned value is a string array, \r\n  each of which is a full path of selected files.");
            p.help.Add("PDI.File.GetDirectoryPath(string filename) # Get a directory path.\r\n Returned string is a full path to the filename.\r\n If filename is omitted, selection dialog will open.");

            p.help.Add("PDI.File.ReadProfiles(string filename) # Read profile data. \r\n If filename is omitted, selection dialog will open.");
            p.help.Add("PDI.File.SaveProfiles(string filename) # Save profile data. \r\n If filename is omitted, selection dialog will open.");
            p.help.Add("PDI.File.ReadCrystals(string filename) # Read crystal data. \r\n If filename is omitted, selection dialog will open.");
            p.help.Add("PDI.File.SaveCrystals(string filename) # Save crystal data. \r\n If filename is omitted, selection dialog will open.");
            p.help.Add("PDI.File.SaveMetafile(string filename) # Save metafile object. \r\n If filename is omitted, selection dialog will open.");

            p.help.Add("PDI.File.SaveText(string text, string filename) # Save textfile object. \r\n If filename is omitted, selection dialog will open.");
        }

        public string GetDirectoryPath(string filename = "") => Execute<string>(new Func<string>(() => getDirectoryPath(filename)));
        private static string getDirectoryPath(string filename = "")
        {
            string path = "";
            if (filename == "")
            {
                var dlg = new FolderBrowserDialog();
                path = dlg.ShowDialog() == DialogResult.OK ? dlg.SelectedPath : "";
            }
            else
                path = System.IO.Path.GetDirectoryName(filename);
            return path + "\\";
        }


        public string GetFileName() => Execute(() => getFileName());
        private static string getFileName()
        {
            var dlg = new OpenFileDialog();
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : "";
        }

        public string[] GetFileNames() => Execute<string[]>(new Func<string[]>(() => getFileNames()));
        private static string[] getFileNames()
        {
            var dlg = new OpenFileDialog() { Multiselect = true };
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileNames : Array.Empty<string>();
        }

        public void ReadProfiles(string fileName = "") => Execute(() => readProfiles(fileName));
        private void readProfiles(string fileName = "")
        {
            if (!System.IO.File.Exists(fileName))
                p.main.menuItemFileRead_Click(new object(), new EventArgs());
            else
                p.main.readProfile(fileName);
        }

        public void SaveProfiles(string filename = "") => Execute(new Action(() => saveProfiles(filename)));
        private void saveProfiles(string filename = "")
        {
            if (filename == "")
                p.main.savePatternProfileToolStripMenuItem_Click(new object(), new EventArgs());
            else
                p.main.SaveProfile(filename);
        }

        public void ReadCrystals(string filename = "") => Execute(new Action(() => readCrystals(filename)));
        private void readCrystals(string filename = "")
        {
            if (!System.IO.File.Exists(filename))
                p.main.menuItemReadCrystalData_Click(new object(), new EventArgs());
            else
                p.main.readCrystal(filename, false, true);
        }

        public void SaveCrystals(string filename = "") => Execute(new Action(() => saveCrystals(filename)));
        private void saveCrystals(string filename = "")
        {
            if (filename == "")
                p.main.menuItemSaveCrystalData_Click(new object(), new EventArgs());
            else
                p.main.saveCrystal(filename);
        }

        public void SaveMetafile(string filename = "") { Execute(new Action(() => saveMetafile(filename))); }
        private void saveMetafile(string filename = "")
        {
            if (filename == "")
                p.main.toolStripMenuItemSaveMetafile_Click(new object(), new EventArgs());
            else
                p.main.saveMetafile(filename);
        }

        public void SaveText(string text, string filename = "") { Execute(new Action(() => saveText(text, filename))); }
        private static void saveText(string text, string filename = "")
        {
            if (filename == "")
            {
                var dlg = new SaveFileDialog() { Filter = "*.txt|*.txt" };
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                filename = dlg.FileName;
            }
            var sw = new StreamWriter(filename);
            sw.Write(text);
            sw.Flush();
            sw.Close();
        }

    }

    #endregion

    #region Drawingクラス 描画関係
    public class DrawingClass : MacroSub
    {
        private readonly Macro p;
        public DrawingClass(Macro _p) : base(_p.main)
        {
            this.p = _p;
            p.help.Add("PDI.Drawing.SetBounds(int StartX, int EndX, int StartY, int EndY) # Set drawing bounds.");

            p.help.Add("PDI.Drawing.StartX # Set/get starting (left-side) value of X in drawing bounds.");
            p.help.Add("PDI.Drawing.EndX # Set/get ending (right-side) value of X in drawing bounds.");
            p.help.Add("PDI.Drawing.StartY # Set/get starting (top) value of Y in drawing bounds.");
            p.help.Add("PDI.Drawing.EndY # Set/get ending (bottom) value of Y in drawing bounds.");

            p.help.Add("PDI.Drawing.MaximumX #Set/get maximum value of X,  \r\n which is settable limit (not drawing bounds)");
            p.help.Add("PDI.Drawing.MaximumY #Set/get maximum value of Y,  \r\n which is settable limit (not drawing bounds)");
            p.help.Add("PDI.Drawing.MinimumX #Set/get minimum value of X,  \r\n which is settable limit (not drawing bounds)");
            p.help.Add("PDI.Drawing.MinimumY #Set/get minimum value of Y,  \r\n which is settable limit (not drawing bounds)");

        }

        public double MaxX { get => Execute(() => p.main.MaximalX); set => Execute(new Action(() => p.main.MaximalX = value)); }
        public double MinX { get => Execute(() => p.main.MinimalX); set => Execute(new Action(() => p.main.MinimalX = value)); }
        public double MaxY { get => Execute(() => p.main.MaximalY); set => Execute(new Action(() => p.main.MaximalY = value)); }
        public double MinY { get => Execute(() => p.main.MinimalY); set => Execute(new Action(() => p.main.MinimalY = value)); }

        public double EndX { get => Execute(() => p.main.UpperX); set => Execute(new Action(() => p.main.UpperX = value)); }
        public double StartX { get => Execute(() => p.main.LowerX); set => Execute(new Action(() => p.main.LowerX = value)); }
        public double EndY { get => Execute(() => p.main.UpperY); set { Execute(new Action(() => p.main.UpperY = value)); } }
        public double StartY { get => Execute(() => p.main.LowerY); set => Execute(new Action(() => p.main.LowerY = value)); }

        public void SetBounds(double xStart, double xEnd, double yStart, double yEnd)
        {
            StartX = xStart; EndX = xEnd; StartY = yStart; EndY = yEnd;
        }
    }
    #endregion

    #region Crystalクラス
    public class CrystalClass : MacroSub
    {
        private readonly Macro p;
        public CrystalClass(Macro _p) : base(_p.main)
        {
            p = _p;
            p.help.Add("PDI.Crystal.Name # Get/Set the name of the selected crystal.");
            p.help.Add("PDI.Crystal.CellVolume # Get the cell volume (Å^3) of the selected crystal.");
            p.help.Add("PDI.Crystal.Pressure(float volume) # Get the pressure (GPa) of the selected crystal by EOS.");
            p.help.Add("PDI.Crystal.CellA # Get/Set the cell constant a (Å) of the selected crystal.");
            p.help.Add("PDI.Crystal.CellB # Get/Set the cell constant b (Å) of the selected crystal.");
            p.help.Add("PDI.Crystal.CellC # Get/Set the cell constant c (Å) of the selected crystal.");
            p.help.Add("PDI.Crystal.CellAlpha # Get/Set the cell constant alpha (deg) of the selected crystal.");
            p.help.Add("PDI.Crystal.CellBeta # Get/Set the cell constant beta (deg) of the selected crystal.");
            p.help.Add("PDI.Crystal.CellGamma # Get/Set the cell constant gamma (deg) of the selected crystal.");
        }
        private Crystal SelectedCrystal => (Crystal)((DataRowView)p.main.bindingSourceCrystal.Current).Row[1];
        public double CellVolume => Execute(() => SelectedCrystal.Volume * 1000);
        public double Pressure(double volume = 0) => Execute<double>(new Func<double>(()
            => SelectedCrystal.EOSCondition.GetPressure(volume == 0 ? SelectedCrystal.Volume * 1000 : volume)));

        public string Name
        {
            get => Execute(() => SelectedCrystal.Name);
            set => Execute(new Action(() => p.main.formCrystal.crystalControl.Name = value));
        }

        #region 格子定数
        public double CellA
        {
            set => Execute(new Action(() => changeCellConstants(0, value)));
            get => Execute(() => SelectedCrystal.A * 10);
        }
        public double CellB
        {
            set => Execute(new Action(() => changeCellConstants(1, value)));
            get => Execute(() => SelectedCrystal.B * 10);
        }
        public double CellC
        {
            set => Execute(new Action(() => changeCellConstants(2, value)));
            get => Execute(() => SelectedCrystal.C * 10);
        }
        public double CellAlpha
        {
            set => Execute(new Action(() => changeCellConstants(3, value)));
            get => Execute(() => SelectedCrystal.Alpha / Math.PI * 180);
        }
        public double CellBeta
        {
            set => Execute(new Action(() => changeCellConstants(4, value)));
            get => Execute(() => SelectedCrystal.Beta / Math.PI * 180);
        }
        public double CellGamma
        {
            set => Execute(new Action(() => changeCellConstants(5, value)));
            get => Execute(() => SelectedCrystal.Gamma / Math.PI * 180);
        }

        private void changeCellConstants(int index, double val)
        {
            if (index == 0) SelectedCrystal.A = val / 10;
            if (index == 1) SelectedCrystal.B = val / 10;
            if (index == 2) SelectedCrystal.C = val / 10;
            if (index == 3) SelectedCrystal.Alpha = val / 180.0 * Math.PI;
            if (index == 4) SelectedCrystal.Beta = val / 180.0 * Math.PI;
            if (index == 5) SelectedCrystal.Gamma = val / 180.0 * Math.PI;

            SelectedCrystal.SetAxis();
            SelectedCrystal.SetPlanes();
            p.main.SetFormEOS();
            p.main.SetFormCrystal(true);
            p.main.InitializeCrystalPlane();
            p.main.Draw();
        }
        #endregion

    }
    #endregion

    #region CrystalListクラス
    public class CrystalListClass : MacroSub
    {
        private readonly Macro p;
        public CrystalListClass(Macro _p) : base(_p.main)
        {
            p = _p;
            p.help.Add("PDI.CrystalList.Open() # Open 'Crystal List' window'.");
            p.help.Add("PDI.CrystalList.Close() # Close 'Crystal List' window'.");
            p.help.Add("PDI.CrystalList.Count # Get total count of crystals.");
            p.help.Add("PDI.CrystalList.SelectedName # Get name of the selected crystal.");
            p.help.Add("PDI.CrystalList.SelectedIndex # Set/get index of the selected crystal.");
            p.help.Add("PDI.CrystalList.Select(int index) # Set index of a selected crystal.");
            p.help.Add("PDI.CrystalList.Check(int index) # Check a crystal assigned by 'index'. If index is omitted, the selected crystal will be checked.");
            p.help.Add("PDI.CrystalList.Uncheck(int index) # Uncheck a crystal assigned by 'index'. If index is omitted, the selected crystal will be unchecked.");

        }

        public void Open() => p.main.checkBoxCrystalParameter.Checked = true;
        public void Close() => p.main.checkBoxCrystalParameter.Checked = false;

        public int Count => Execute(() => p.main.bindingSourceCrystal.Count);
        public string SelectedName => Execute(() => (SelectedIndex >= 0) ? ((Crystal)((DataRowView)p.main.bindingSourceCrystal.Current).Row[1]).Name : "");
        public int SelectedIndex
        {
            set
            {
                Execute(new Action(() =>
                {
                    if (value >= 0 && value < p.main.bindingSourceCrystal.Count)
                        p.main.bindingSourceCrystal.Position = value;
                }));
            }
            get => Execute(() => p.main.bindingSourceCrystal.Position);
        }

        public void Select(int n) { Execute(() => select(n)); }
        private void select(int n)
        {
            if (n >= 0 && n < p.main.bindingSourceCrystal.Count)
                p.main.bindingSourceCrystal.Position = n;
        }

        public void Check() => Check(SelectedIndex, true);
        public void Check(int n) => Check(n, true);
        public void Uncheck() => Check(SelectedIndex, false);
        public void Uncheck(int n) => Check(n, false);

        public void Check(int n, bool checkState) => Execute(() => check(n, checkState));
        private void check(int n, bool checkState)
        {
            if (n >= 0 && n < p.main.bindingSourceCrystal.Count)
            {
                ((DataRowView)p.main.bindingSourceCrystal[n]).Row[0] = checkState;
                p.main.dataGridViewCrystals_CellMouseClick(new object(), new DataGridViewCellMouseEventArgs(-1, -1, 0, 0, new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, 0, 0, 0)));
            }
        }

        public double GetCellVolume => Execute(() => p.main.bindingSourceCrystal.Count);
    }
    #endregion

    #region Profileクラス
    public class ProfileClass : MacroSub
    {
        private readonly Macro p;
        public ProfileClass(Macro _p) : base(_p.main)
        {
            p = _p;
            p.help.Add("PDI.Profile.Comment #  Set/get the comment of the selected profile.");
            p.help.Add("PDI.Profile.Name #  Set/get the comment of the selected profile.");
        }

        public string Comment
        {
            get => Execute(() => p.main.formProfile.textBoxComment.Text);
            set => Execute(new Action(() => p.main.formProfile.textBoxComment.Text = value));
        }

        public string Name
        {
            get => Execute(() => p.main.formProfile.textBoxProfileName.Text);
            set => Execute(new Action(() => p.main.formProfile.textBoxProfileName.Text = value));
        }
    }
    #endregion

    #region ProfileOperatorクラス
    public class ProfileOperatorClass : MacroSub
    {
        private readonly Macro p;
        public ProfileOperatorClass(Macro _p) : base(_p.main)
        {
            p = _p;
            p.help.Add("PDI.ProfileOperator.Average(int[] indices, string output) # Get average profile. 'indices' is array of itegers (like iArray = 1,3,5,9),  \r\n and 'output' is the profile name of result");
            p.help.Add("PDI.ProfileOperator.AddTwoProfiles(int index1, int index2, string output)      # Calculate profile1 + profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result");
            p.help.Add("PDI.ProfileOperator.SubtractTwoProfiles(int index1, int index2, string output) # Calculate profile1 - profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result");
            p.help.Add("PDI.ProfileOperator.MultiplyTwoProfiles(int index1, int index2, string output) # Calculate profile1 * profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result");
            p.help.Add("PDI.ProfileOperator.DivideTwoProfiles(int index1, int index2, string output)   # Calculate profile1 / profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result");
            p.help.Add("PDI.ProfileOperator.AddValueToProfile(int index, double value, string output)   # Calculate profile + value. \r\n  Profile is assingned by index.  \r\n 'output' is the profile name of result");
            p.help.Add("PDI.ProfileOperator.MultiplyValueToProfile(int index, double value, string output)   # Calculate profile * value. \r\n  Profile is assingned by index (integer), and .  \r\n 'out' is the profile name of result");
        }

        public void Average(int[] intArray, string outputName = "") { Execute(() => average(intArray, outputName)); }
        private void average(int[] intArray, string outputName = "")
        {
            p.main.formProfile.radioButtonAverage.Checked = true;
            foreach (int i in intArray)
            {
                if (i >= 0 && i < p.main.formProfile.listBoxTwoProfiles1.Items.Count)
                    p.main.formProfile.listBoxTwoProfiles1.SelectedIndex = i;
            }
            if (outputName != "") p.main.formProfile.textBoxOutputFilename.Text = outputName;
            p.main.formProfile.buttonCalculate_Click(new object(), new EventArgs());
        }

        public void AddTwoProfiles(int index1, int index2, string outputName = "") { Execute(() => addTwoProfiles(index1, index2, outputName)); }
        private void addTwoProfiles(int index1, int index2, string outputName = "")
        {
            p.main.formProfile.radioButtonAddition.Checked = true;
            Arithmetic(index1, index2, outputName);
        }

        public void SubtractTwoProfiles(int index1, int index2, string outputName = "") { Execute(() => subtractTwoProfiles(index1, index2, outputName)); }
        private void subtractTwoProfiles(int index1, int index2, string outputName = "")
        {
            p.main.formProfile.radioButtonSubtraction.Checked = true;
            Arithmetic(index1, index2, outputName);
        }

        public void MultiplyTwoProfiles(int index1, int index2, string outputName = "") { Execute(() => multiplyTwoProfiles(index1, index2, outputName)); }
        private void multiplyTwoProfiles(int index1, int index2, string outputName = "")
        {
            p.main.formProfile.radioButtonMutiplication.Checked = true;
            Arithmetic(index1, index2, outputName);
        }

        public void DivideTwoProfiles(int index1, int index2, string outputName = "") { Execute(() => divideTwoProfiles(index1, index2, outputName)); }
        private void divideTwoProfiles(int index1, int index2, string outputName = "")
        {
            p.main.formProfile.radioButtonDivision.Checked = true;
            Arithmetic(index1, index2, outputName);
        }

        private void Arithmetic(int index1, int index2, string outputName = "")
        {
            p.main.formProfile.radioButtonTwoProfiles.Checked = true;
            if (Math.Min(index1, index2) >= 0 && Math.Max(index1, index2) < p.main.formProfile.listBoxTwoProfiles1.Items.Count)
            {
                p.main.formProfile.listBoxTwoProfiles1.SelectedIndex = index1;
                p.main.formProfile.listBoxTwoProfiles2.SelectedIndex = index2;
                if (outputName != "") p.main.formProfile.textBoxOutputFilename.Text = outputName;
                p.main.formProfile.buttonCalculate_Click(new object(), new EventArgs());
            }
        }
    }
    #endregion

    #region ProfileListクラス
    public class ProfileListClass : MacroSub
    {
        private readonly Macro p;
        public ProfileListClass(Macro _p) : base(_p.main)
        {
            p = _p;
            p.help.Add("PDI.ProfileList.Open() # Open 'Profile List' window'.");
            p.help.Add("PDI.ProfileList.Close() # Close 'Profile List' window'.");
            p.help.Add("PDI.ProfileList.Count # Get total count of profiles.");
            p.help.Add("PDI.ProfileList.SelectedName # Get name of a selected profile.");
            p.help.Add("PDI.ProfileList.SelectedIndex # Set/get index of a selected profile.");
            p.help.Add("PDI.ProfileList.Select(int index) # Set index of a selected profile.");
            p.help.Add("PDI.ProfileList.Check(int index) # Check a profile assigned by index. If index is omitted, the selected profile will be checked.");
            p.help.Add("PDI.ProfileList.Uncheck(int index) # Uncheck a profile assigned by index. If index is omitted, the selected profile will be unchecked.");
            p.help.Add("PDI.ProfileList.CheckAll() # Check all profiles.");
            p.help.Add("PDI.ProfileList.UncheckAll() # Uncheck all profiles.");
            p.help.Add("PDI.ProfileList.DeleteAll() # Delete all profiles.");
            p.help.Add("PDI.ProfileList.Delete(int index) # Delete a profile assigned by index.");
        }
        public void Open() => p.main.checkBoxProfileParameter.Checked = true;
        public void Close() => p.main.checkBoxProfileParameter.Checked = false;
        public void DeleteAll() => Execute(() => p.main.formProfile.DeleteAllProfiles(false));
        public void Delete(int n)
            => Execute(new Action(() =>
            {
                Select(n);
                p.main.formProfile.DeleteProfiles(n);
            }));

        public int Count => Execute(() => p.main.bindingSourceProfile.Count);

        public string SelectedName => Execute(() => (SelectedIndex >= 0) ? ((DiffractionProfile)((DataRowView)p.main.bindingSourceProfile.Current).Row[1]).Name : "");

        public int SelectedIndex
        {
            set
            {
                Execute(new Action(() =>
                {
                    if (value >= 0 && value < p.main.bindingSourceProfile.Count)
                        p.main.bindingSourceProfile.Position = value;
                }));
            }
            get => Execute(() => p.main.bindingSourceProfile.Position);
        }

        public void Select(int n)
        {
            Execute(new Action(() =>
            {
                if (n >= 0 && n < p.main.bindingSourceProfile.Count)
                    p.main.bindingSourceProfile.Position = n;
            }));
        }

        public void Check() => Execute(new Action(() => Check(SelectedIndex, true)));
        public void Check(int n) => Execute(new Action(() => Check(n, true)));
        public void Uncheck() => Execute(new Action(() => Check(SelectedIndex, false)));
        public void Uncheck(int n) => Execute(new Action(() => Check(n, false)));

        public void Check(int n, bool checkState) => Execute(() => check(n, checkState));
        private void check(int n, bool checkState)
        {
            if (n >= 0 && n < p.main.bindingSourceProfile.Count)
            {
                ((DataRowView)p.main.bindingSourceProfile[n]).Row[0] = checkState;
                p.main.dataGridViewProfiles_CellClick(new object(), new DataGridViewCellEventArgs(-1, -1));
            }
        }

        public void CheckAll() => Execute(new Action(() => p.main.checkBoxAll.Checked = true));

        public void UncheckAll() => Execute(new Action(() => p.main.checkBoxAll.Checked = false));

    }
    #endregion

    #region Fittingクラス
    public class FittingClass : MacroSub
    {
        private readonly Macro p;
        public FittingClass(Macro _p) : base(_p.main)
        {
            p = _p;
            p.help.Add("PDI.Fitting.Open() # Open 'Fitting peaks' window.");
            p.help.Add("PDI.Fitting.Close() # Close 'Fitting peaks' window.");

            p.help.Add("PDI.Fitting.Check(int index) # Check the lattice plane assigned by index.");
            p.help.Add("PDI.Fitting.Uncheck(int index) # Uncheck the lattice plane assigned by index.");
            p.help.Add("PDI.Fitting.Select(int index) # Select the lattice plane assigned by index.");
            p.help.Add("PDI.Fitting.SelectedIndex #Set/get the index of a lattice plane.");

            p.help.Add("PDI.Fitting.Apply() # Apply the optimized cell constants to the selected crystal.");

            p.help.Add("PDI.Fitting.Range(double value) # Set fitting range of the selected lattice plane.");

        }

        public void Open() => p.main.toolStripButtonFittingParameter.Checked = true;
        public void Close() => p.main.toolStripButtonFittingParameter.Checked = false;
        public void Apply() => Execute(() => p.main.formFitting.Confirm(true));
        public void Check() => Check(SelectedIndex, true);
        public void Check(int n) => Check(n, true);
        public void Uncheck(int n) => Check(n, false);
        public void Uncheck() => Check(SelectedIndex, false);
        private void Check(int n, bool checkState) { Execute(() => check(n, checkState)); }
        private void check(int n, bool checkState)
        {
            if (n >= 0 && n < p.main.formFitting.bindingSourcePlanes.Count)
            {
                p.main.formFitting.TargetCrystal.Plane[n].IsFittingChecked = checkState;
                ((DataRowView)p.main.formFitting.bindingSourcePlanes[n]).Row[0] = checkState;
                p.main.formFitting.dataGridViewPlaneList_SelectionChanged(new object(), new EventArgs());
            }
        }
        public void Select(int n) => SelectedIndex = n;

        public int SelectedIndex
        {
            set
            {
                Execute(new Action(() =>
                {
                    if (value >= 0 && value < p.main.formFitting.bindingSourcePlanes.Count)
                        p.main.formFitting.bindingSourcePlanes.Position = value;
                }));
            }
            get => Execute(() => p.main.formFitting.bindingSourcePlanes.Position);
        }

        public void Range(double r) => p.main.formFitting.numericBoxSearchRange.Value = r;
    }
    #endregion

    #region Sequentialクラス
    public class SequentialClass : MacroSub
    {
        private readonly Macro p;
        public SequentialClass(Macro _p) : base(_p.main)
        {
            p = _p;
            p.help.Add("PDI.Sequential.Open() # Open 'Sequential Analysis' window.");
            p.help.Add("PDI.Sequential.Close() # Close 'Sequential Analysis' window.");

            p.help.Add("PDI.Sequential.Execute() # Execute the sequential analysis.");

            p.help.Add("PDI.Sequential.GetCSV_2theta() # Get results of 2 theta in CSV format.");
            p.help.Add("PDI.Sequential.GetCSV_D() # Get results of d-spacing in CSV format.");
            p.help.Add("PDI.Sequential.GetCSV_FWHM() # Get results of FWHM in CSV format.");
            p.help.Add("PDI.Sequential.GetCSV_Intensity() # Get results of peak intensity in CSV format.");
            p.help.Add("PDI.Sequential.GetCSV_CellConstants() # Get results of cell constants in CSV format.");
            p.help.Add("PDI.Sequential.GetCSV_Pressure() # Get results of pressure in CSV format.");
            p.help.Add("PDI.Sequential.GetCSV_Singh() # Get results of Singh equation in CSV format.");

            p.help.Add("PDI.Sequential.Directory # Get/set the full directory path to be saved.");

            p.help.Add("PDI.Sequential.AutoSave2theta # Get/set True or False.");
            p.help.Add("PDI.Sequential.AutoSaveDspacing # Get/set True or False.");
            p.help.Add("PDI.Sequential.AutoSaveFWHM # Get/set True or False.");
            p.help.Add("PDI.Sequential.AutoSaveIntensity # Get/set True or False.");
            p.help.Add("PDI.Sequential.AutoSaveCellConstants # Get/set True or False.");
            p.help.Add("PDI.Sequential.AutoSavePressure # Get/set True or False.");
            p.help.Add("PDI.Sequential.AutoSaveSingh # Get/set True or False.");

        }
        public string Directory
        {
            get => p.main.formSequentialAnalysis.textBoxDirectory.Text;
            set => Execute(new Action(() => p.main.formSequentialAnalysis.textBoxDirectory.Text = value));
        }

        public void Open() => Execute(new Action(() => p.main.toolStripButtonSequentialAnalysis.Checked = true));
        public void Close() => Execute(new Action(() => p.main.toolStripButtonSequentialAnalysis.Checked = false));
        public void Execute() => Execute(() => p.main.formSequentialAnalysis.buttonExecute.PerformClick());

        public string GetCSV_2theta() => Execute(() => p.main.formSequentialAnalysis.GetText(true, 0));
        public string GetCSV_D() => Execute(() => p.main.formSequentialAnalysis.GetText(true, 1));
        public string GetCSV_FWHM() => Execute(() => p.main.formSequentialAnalysis.GetText(true, 2));
        public string GetCSV_Intensity() => Execute(() => p.main.formSequentialAnalysis.GetText(true, 3));
        public string GetCSV_CellConstants() => Execute(() => p.main.formSequentialAnalysis.GetText(true, 4));
        public string GetCSV_Pressure() => Execute(() => p.main.formSequentialAnalysis.GetText(true, 5));
        public string GetCSV_Singh() => Execute(() => p.main.formSequentialAnalysis.GetText(true, 6));

        public bool AutoSave2theta
        {
            get => p.main.formSequentialAnalysis.checkBoxAutoSaveTwoTheta.Checked;
            set => Execute(new Action(() => p.main.formSequentialAnalysis.checkBoxAutoSaveTwoTheta.Checked = value));
        }

        public bool AutoSaveDspacing
        {
            get => p.main.formSequentialAnalysis.checkBoxAutoSaveD.Checked;
            set => Execute(new Action(() => p.main.formSequentialAnalysis.checkBoxAutoSaveD.Checked = value));
        }

        public bool AutoSaveFWHM
        {
            get => p.main.formSequentialAnalysis.checkBoxAutoSaveFWHM.Checked;
            set => Execute(new Action(() => p.main.formSequentialAnalysis.checkBoxAutoSaveFWHM.Checked = value));
        }

        public bool AutoSaveIntensity
        {
            get => p.main.formSequentialAnalysis.checkBoxAutoSaveInt.Checked;
            set => Execute(new Action(() => p.main.formSequentialAnalysis.checkBoxAutoSaveInt.Checked = value));
        }

        public bool AutoSaveCellConstants
        {
            get => p.main.formSequentialAnalysis.checkBoxAutoSaveCell.Checked;
            set => Execute(new Action(() => p.main.formSequentialAnalysis.checkBoxAutoSaveCell.Checked = value));
        }

        public bool AutoSavePressure
        {
            get => p.main.formSequentialAnalysis.checkBoxAutoSavePressure.Checked;
            set => Execute(new Action(() => p.main.formSequentialAnalysis.checkBoxAutoSavePressure.Checked = value));
        }
        public bool AutoSaveSingh
        {
            get => p.main.formSequentialAnalysis.checkBoxAutoSaveSingh.Checked;
            set => Execute(new Action(() => p.main.formSequentialAnalysis.checkBoxAutoSaveSingh.Checked = value));
        }

    }
    #endregion
}
