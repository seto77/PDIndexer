#region using, namespace
using Crystallography;
using Crystallography.Controls;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static IronPython.Modules._ast;
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
        HelpAttribute.GenerateHelpText(Drawing.GetType(), nameof(Drawing)).ForEach(s => help.Add(s));

        ProfileList = new ProfileListClass(this);
        HelpAttribute.GenerateHelpText(ProfileList.GetType(), nameof(ProfileList)).ForEach(s => help.Add(s));

        Profile = new ProfileClass(this);
        HelpAttribute.GenerateHelpText(Profile.GetType(), nameof(Profile)).ForEach(s => help.Add(s));


        ProfileOperator = new ProfileOperatorClass(this);
        HelpAttribute.GenerateHelpText(ProfileOperator.GetType(), nameof(ProfileOperator)).ForEach(s => help.Add(s));


        File = new FileClass(this);
        HelpAttribute.GenerateHelpText(File.GetType(), nameof(File)).ForEach(s => help.Add(s));

        CrystalList = new CrystalListClass(this);
        HelpAttribute.GenerateHelpText(CrystalList.GetType(), nameof(CrystalList)).ForEach(s => help.Add(s));

        Crystal = new CrystalClass(this);
        HelpAttribute.GenerateHelpText(Crystal.GetType(), nameof(Crystal)).ForEach(s => help.Add(s));

        Fitting = new FittingClass(this);
        HelpAttribute.GenerateHelpText(Fitting.GetType(), nameof(Fitting)).ForEach(s => help.Add(s));

        Sequential = new SequentialClass(this);
        HelpAttribute.GenerateHelpText(Sequential.GetType(), nameof(Sequential)).ForEach(s => help.Add(s));

    }

    [Help("PDI.Sleep(int millisec) # Sleep.")]
    public static void Sleep(int millisec) => Thread.Sleep(millisec);

    [Help("Get object sent from other program.")]

    public object[] Obj { get; set; }

    #endregion

    #region Fileクラス ファイル入出力関係

    /// <summary>
    /// ファイル入出力関係
    /// </summary>
    public class FileClass(Macro _p) : MacroSub(_p.main)
    {
        //private readonly Macro p = _p;
        private FormMain main => _p.main;

        [Help("Get a directory path.\r\n Returned string is a full path to the filename.\r\n If filename is omitted, selection dialog will open.", "string filename")]
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

        [Help("Get a file name. \r\n Returned string is a full path of the selected file.")]
        public string GetFileName() => Execute(() => getFileName());
        private static string getFileName()
        {
            var dlg = new OpenFileDialog();
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : "";
        }

        [Help("Get file names. \r\n Returned value is a string array, \r\n  each of which is a full path of selected files.")]
        public string[] GetFileNames() => Execute<string[]>(new Func<string[]>(() => getFileNames()));
        private static string[] getFileNames()
        {
            var dlg = new OpenFileDialog() { Multiselect = true };
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileNames : [];
        }

       [Help("Read profile data. \r\n If filename is omitted, selection dialog will open.","string filename")]

        public void ReadProfiles(string fileName = "") => Execute(() => readProfiles(fileName));
        private void readProfiles(string fileName = "")
        {
            if (!System.IO.File.Exists(fileName))
                main.menuItemFileRead_Click(new object(), new EventArgs());
            else
                main.readProfile(fileName);
        }

        [Help("Save profile data. \r\n If filename is omitted, selection dialog will open.", "string filename")]
        public void SaveProfiles(string filename = "") => Execute(new Action(() => saveProfiles(filename)));
        private void saveProfiles(string filename = "")
        {
            if (filename == "")
                main.savePatternProfileToolStripMenuItem_Click(new object(), new EventArgs());
            else
                main.SaveProfile(filename);
        }

        [Help("Read crystal data. \r\n If filename is omitted, selection dialog will open.", "string filename")]
        public void ReadCrystals(string filename = "") => Execute(new Action(() => readCrystals(filename)));
        private void readCrystals(string filename = "")
        {
            if (!System.IO.File.Exists(filename))
                main.menuItemReadCrystalData_Click(new object(), new EventArgs());
            else
                main.readCrystal(filename, false, true);
        }

        [He:p("Save crystal data. \r\n If filename is omitted, selection dialog will open.", "string filename")]
        public void SaveCrystals(string filename = "") => Execute(new Action(() => saveCrystals(filename)));
        private void saveCrystals(string filename = "")
        {
            if (filename == "")
                main.menuItemSaveCrystalData_Click(new object(), new EventArgs());
            else
                main.saveCrystal(filename);
        }

        [Help("Save metafile object. \r\n If filename is omitted, selection dialog will open.", "string filename")]
        public void SaveMetafile(string filename = "") { Execute(new Action(() => saveMetafile(filename))); }
        private void saveMetafile(string filename = "")
        {
            if (filename == "")
                main.toolStripMenuItemSaveMetafile_Click(new object(), new EventArgs());
            else
                main.saveMetafile(filename);
        }

        [Help("Save textfile object. \r\n If filename is omitted, selection dialog will open.", "string text, string filename")]
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
    public class DrawingClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        [Help("Set/get maximum value of X,  \r\n which is settable limit (not drawing bounds)")]
        public double MaxX { get => Execute(() => main.MaximalX); set => Execute(new Action(() => main.MaximalX = value)); }
        [Help("Set/get minimum value of X,  \r\n which is settable limit (not drawing bounds)")]
        public double MinX { get => Execute(() => main.MinimalX); set => Execute(new Action(() => main.MinimalX = value)); }
        [Help("Set/get maximum value of Y,  \r\n which is settable limit (not drawing bounds)")]
        public double MaxY { get => Execute(() => main.MaximalY); set => Execute(new Action(() => main.MaximalY = value)); }
        [Help("Set/get minimum value of Y,  \r\n which is settable limit (not drawing bounds)")]
        public double MinY { get => Execute(() => main.MinimalY); set => Execute(new Action(() => main.MinimalY = value)); }

        [Help("Set/get ending (right-side) value of X in drawing bounds.")]
        public double EndX { get => Execute(() => main.UpperX); set => Execute(new Action(() => main.UpperX = value)); }
        [Help("Set/get starting (left-side) value of X in drawing bounds.")]
        public double StartX { get => Execute(() => main.LowerX); set => Execute(new Action(() => main.LowerX = value)); }
        [Help("Set/get ending (bottom) value of Y in drawing bounds.")]
        public double EndY { get => Execute(() => main.UpperY); set { Execute(new Action(() => main.UpperY = value)); } }
        [Help("Set/get starting (top) value of Y in drawing bounds.")]
        public double StartY { get => Execute(() => main.LowerY); set => Execute(new Action(() => main.LowerY = value)); }
     
        [Help("PDI.Drawing.SetBounds() # Set drawing bounds.","int StartX, int EndX, int StartY, int EndY")]
        public void SetBounds(double xStart, double xEnd, double yStart, double yEnd)
        {
            StartX = xStart; EndX = xEnd; StartY = yStart; EndY = yEnd;
        }
    }
    #endregion

    #region Crystalクラス
    public class CrystalClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        private Crystal SelectedCrystal => (Crystal)((DataRowView)main.bindingSourceCrystal.Current).Row[1];


        [Help("Get the cell volume (Å^3) of the selected crystal.")]
        public double CellVolume => Execute(() => SelectedCrystal.Volume * 1000);
        [Help("Get the pressure (GPa) of the selected crystal by EOS.", "float volume")]
        public double Pressure(double volume = 0) => Execute<double>(new Func<double>(()
            => SelectedCrystal.EOSCondition.GetPressure(volume == 0 ? SelectedCrystal.Volume * 1000 : volume)));

        [Help("Get/Set the name of the selected crystal.")]
        public string Name
        {
            get => Execute(() => SelectedCrystal.Name);
            set => Execute(new Action(() => main.formCrystal.crystalControl.Name = value));
        }

        #region 格子定数
        [Help("Get/Set the cell constant a (Å) of the selected crystal.")]
        public double CellA
        {
            set => Execute(new Action(() => changeCellConstants(0, value)));
            get => Execute(() => SelectedCrystal.A * 10);
        }
        [Help("Get/Set the cell constant b (Å) of the selected crystal.")]
        public double CellB
        {
            set => Execute(new Action(() => changeCellConstants(1, value)));
            get => Execute(() => SelectedCrystal.B * 10);
        }
        [Help("Get/Set the cell constant c (Å) of the selected crystal.")]
        public double CellC
        {
            set => Execute(new Action(() => changeCellConstants(2, value)));
            get => Execute(() => SelectedCrystal.C * 10);
        }
        [Help("Get/Set the cell constant alpha (deg) of the selected crystal.")]
        public double CellAlpha
        {
            set => Execute(new Action(() => changeCellConstants(3, value)));
            get => Execute(() => SelectedCrystal.Alpha / Math.PI * 180);
        }
        [Help("Get/Set the cell constant beta (deg) of the selected crystal.")]
        public double CellBeta
        {
            set => Execute(new Action(() => changeCellConstants(4, value)));
            get => Execute(() => SelectedCrystal.Beta / Math.PI * 180);
        }
        [Help("Get/Set the cell constant gamma (deg) of the selected crystal.")]
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
            main.SetFormEOS();
            main.SetFormCrystal(true);
            main.InitializeCrystalPlane();
            main.Draw();
        }
        #endregion

    }
    #endregion

    #region CrystalListクラス
    public class CrystalListClass(Macro _p) : MacroSub(_p.main)
    {
        //public CrystalListClass(Macro _p) : base(_p.main) => p = _p;

        private FormMain main => _p.main;


        [Help("Open 'Crystal List' window'.")]
        public void Open() => main.checkBoxCrystalParameter.Checked = true;
        [Help("Close 'Crystal List' window'.")]
        public void Close() => main.checkBoxCrystalParameter.Checked = false;

        [Help("Get total count of crystals.")]
        public int Count => Execute(() => main.bindingSourceCrystal.Count);
      
        [Help("Get name of the selected crystal.")]
        public string SelectedName => Execute(() => (SelectedIndex >= 0) ? ((Crystal)((DataRowView)main.bindingSourceCrystal.Current).Row[1]).Name : "");
       
        [Help("Set/get index of the selected crystal.")]
        public int SelectedIndex
        {
            set
            {
                Execute(new Action(() =>
                {
                    if (value >= 0 && value < main.bindingSourceCrystal.Count)
                        main.bindingSourceCrystal.Position = value;
                }));
            }
            get => Execute(() => main.bindingSourceCrystal.Position);
        }

        [Help("Set index of a selected crystal.", "int index")]
        public void Select(int n) { Execute(() => select(n)); }
        private void select(int n)
        {
            if (n >= 0 && n < main.bindingSourceCrystal.Count)
                main.bindingSourceCrystal.Position = n;
        }

        [Help("Check a crystal assigned by 'index'. If index is omitted, the selected crystal will be checked.", "int index")]
        public void Check() => Check(SelectedIndex, true);
        public void Check(int n) => Check(n, true);

        [Help("Uncheck a crystal assigned by 'index'. If index is omitted, the selected crystal will be unchecked.", "int index")]
        public void Uncheck() => Check(SelectedIndex, false);
        public void Uncheck(int n) => Check(n, false);

        [Help("Check/uncheck a crystal assigned by 'index'.", "int indexm bool state")]
        public void Check(int n, bool checkState) => Execute(() => check(n, checkState));
        private void check(int n, bool checkState)
        {
            if (n >= 0 && n < main.bindingSourceCrystal.Count)
            {
                ((DataRowView)main.bindingSourceCrystal[n]).Row[0] = checkState;
                main.dataGridViewCrystals_CellMouseClick(new object(), new DataGridViewCellMouseEventArgs(-1, -1, 0, 0, new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, 0, 0, 0)));
            }
        }

        public double GetCellVolume => Execute(() => main.bindingSourceCrystal.Count);
    }
    #endregion

    #region Profileクラス
    public class ProfileClass : MacroSub
    {
        private readonly Macro p;
        public ProfileClass(Macro _p) : base(_p.main)
        {
            p = _p;
        }

        [Help("Set/get the comment of the selected profile.")]
        public string Comment
        {
            get => Execute(() => p.main.formProfile.textBoxComment.Text);
            set => Execute(new Action(() => p.main.formProfile.textBoxComment.Text = value));
        }

        [Help("Set/get the comment of the selected profile.")]
        public string Name
        {
            get => Execute(() => p.main.formProfile.textBoxProfileName.Text);
            set => Execute(new Action(() => p.main.formProfile.textBoxProfileName.Text = value));
        }
    }
    #endregion

    #region ProfileOperatorクラス
    public class ProfileOperatorClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        // [Help("PDI.ProfileOperator.AddValueToProfile(int index, double value, string output)   # Calculate profile + value. \r\n  Profile is assingned by index.  \r\n 'output' is the profile name of result")]
        // [Help("PDI.ProfileOperator.MultiplyValueToProfile(int index, double value, string output)   # Calculate profile * value. \r\n  Profile is assingned by index (integer), and .  \r\n 'out' is the profile name of result")]

        [Help("Get average profile. 'indices' is array of itegers (like iArray = 1,3,5,9),  \r\n and 'output' is the profile name of result", "int[] indices, string output")]
        public void Average(int[] intArray, string outputName = "") { Execute(() => average(intArray, outputName)); }
        private void average(int[] intArray, string outputName = "")
        {
            main.formProfile.radioButtonAverage.Checked = true;
            foreach (int i in intArray)
            {
                if (i >= 0 && i < main.formProfile.listBoxTwoProfiles1.Items.Count)
                    main.formProfile.listBoxTwoProfiles1.SelectedIndex = i;
            }
            if (outputName != "") main.formProfile.textBoxOutputFilename.Text = outputName;
            main.formProfile.buttonCalculate_Click(new object(), new EventArgs());
        }

        [Help("Calculate profile1 + profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result", "int index1, int index2, string output")]
        public void AddTwoProfiles(int index1, int index2, string outputName = "") { Execute(() => addTwoProfiles(index1, index2, outputName)); }
        private void addTwoProfiles(int index1, int index2, string outputName = "")
        {
            main.formProfile.radioButtonAddition.Checked = true;
            Arithmetic(index1, index2, outputName);
        }

        [Help("Calculate profile1 - profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result", "int index1, int index2, string output")]
        public void SubtractTwoProfiles(int index1, int index2, string outputName = "") { Execute(() => subtractTwoProfiles(index1, index2, outputName)); }
        private void subtractTwoProfiles(int index1, int index2, string outputName = "")
        {
            main.formProfile.radioButtonSubtraction.Checked = true;
            Arithmetic(index1, index2, outputName);
        }

        [Help("Calculate profile1 * profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result", "int index1, int index2, string output")]
        public void MultiplyTwoProfiles(int index1, int index2, string outputName = "") { Execute(() => multiplyTwoProfiles(index1, index2, outputName)); }
        private void multiplyTwoProfiles(int index1, int index2, string outputName = "")
        {
            main.formProfile.radioButtonMutiplication.Checked = true;
            Arithmetic(index1, index2, outputName);
        }

        [Help("Calculate profile1 / profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result", "int index1, int index2, string output")]
        public void DivideTwoProfiles(int index1, int index2, string outputName = "") { Execute(() => divideTwoProfiles(index1, index2, outputName)); }
        private void divideTwoProfiles(int index1, int index2, string outputName = "")
        {
            main.formProfile.radioButtonDivision.Checked = true;
            Arithmetic(index1, index2, outputName);
        }

        private void Arithmetic(int index1, int index2, string outputName = "")
        {
            main.formProfile.radioButtonTwoProfiles.Checked = true;
            if (Math.Min(index1, index2) >= 0 && Math.Max(index1, index2) < main.formProfile.listBoxTwoProfiles1.Items.Count)
            {
                main.formProfile.listBoxTwoProfiles1.SelectedIndex = index1;
                main.formProfile.listBoxTwoProfiles2.SelectedIndex = index2;
                if (outputName != "") main.formProfile.textBoxOutputFilename.Text = outputName;
                main.formProfile.buttonCalculate_Click(new object(), new EventArgs());
            }
        }
    }
    #endregion

    #region ProfileListクラス
    public class ProfileListClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        [Help("Open 'Profile List' window'.")]
        public void Open() => main.checkBoxProfileParameter.Checked = true;
        
        [Help("Close 'Profile List' window'.")]
        public void Close() => main.checkBoxProfileParameter.Checked = false;
        
        [Help("Delete all profiles.")]
        public void DeleteAll() => Execute(() => main.formProfile.DeleteAllProfiles(false));
        
        [Help("Delete a profile assigned by index.", "int index")]
        public void Delete(int n)
        => Execute(new Action(() =>
        {
            Select(n);
            main.formProfile.DeleteProfiles(n);
        }));

        [Help("Get total count of profiles.")]
        public int Count => Execute(() => main.bindingSourceProfile.Count);

        [Help("Get name of a selected profile.")]
        public string SelectedName => Execute(() => (SelectedIndex >= 0) ? ((DiffractionProfile2)((DataRowView)main.bindingSourceProfile.Current).Row[1]).Name : "");

        [Help("Set/get index of a selected profile.")]
        public int SelectedIndex
        {
            set
            {
                Execute(new Action(() =>
                {
                    if (value >= 0 && value < main.bindingSourceProfile.Count)
                        main.bindingSourceProfile.Position = value;
                }));
            }
            get => Execute(() => main.bindingSourceProfile.Position);
        }

        [Help("Set index of a selected profile.", "int index")]
        public void Select(int n)
        {
            Execute(new Action(() =>
            {
                if (n >= 0 && n < main.bindingSourceProfile.Count)
                    main.bindingSourceProfile.Position = n;
            }));
        }

        [Help("Check the profile assigned by index. If index is omitted, the selected profile will be checked.", "int index")]
        public void Check() => Execute(new Action(() => Check(SelectedIndex, true)));
        public void Check(int n) => Execute(new Action(() => Check(n, true)));
        
        [Help("Uncheck the profile assigned by index. If index is omitted, the selected profile will be unchecked.", "int index")]
        public void Uncheck() => Execute(new Action(() => Check(SelectedIndex, false)));
        public void Uncheck(int n) => Execute(new Action(() => Check(n, false)));

        [Help("Check/uncheck the profile assigned by index.", "int index, bool state")]
        public void Check(int n, bool checkState) => Execute(() => check(n, checkState));
        private void check(int n, bool checkState)
        {
            if (n >= 0 && n < main.bindingSourceProfile.Count)
            {
                ((DataRowView)main.bindingSourceProfile[n]).Row[0] = checkState;
                main.dataGridViewProfiles_CellClick(new object(), new DataGridViewCellEventArgs(-1, -1));
            }
        }

        [Help("PDI.ProfileList.CheckAll() # Check all profiles.")]
        public void CheckAll() => Execute(new Action(() => main.checkBoxAll.Checked = true));

        [Help("PDI.ProfileList.UncheckAll() # Uncheck all profiles.")]
        public void UncheckAll() => Execute(new Action(() => main.checkBoxAll.Checked = false));

    }
    #endregion

    #region Fittingクラス
    public class FittingClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        [Help("Open 'Fitting peaks' window.")]
        public void Open() => main.toolStripButtonFittingParameter.Checked = true;
        
        [Help("Close 'Fitting peaks' window.")]
        public void Close() => main.toolStripButtonFittingParameter.Checked = false;
        
        [Help("Apply the optimized cell constants to the selected crystal.")]
        public void Apply() => Execute(() => main.formFitting.Confirm(true));
        

        [Help("Check the lattice plane assigned by index.", "int index")]
        public void Check(int n) => Check(n, true);
        public void Check() => Check(SelectedIndex, true);

        [Help("Uncheck the lattice plane assigned by index.", "int index")]
        public void Uncheck(int n) => Check(n, false);
        public void Uncheck() => Check(SelectedIndex, false);

        [Help("Check/uncheck the lattice plane assigned by index.", "int index, bool state")]
        private void Check(int n, bool checkState) { Execute(() => check(n, checkState)); }
        private void check(int n, bool checkState)
        {
            if (n >= 0 && n < main.formFitting.bindingSourcePlanes.Count)
            {
                main.formFitting.TargetCrystal.Plane[n].IsFittingChecked = checkState;
                ((DataRowView)main.formFitting.bindingSourcePlanes[n]).Row[0] = checkState;
                main.formFitting.dataGridViewPlaneList_SelectionChanged(new object(), new EventArgs());
            }
        }

        [Help("Select the lattice plane assigned by index.", "int index")]
        public void Select(int n) => SelectedIndex = n;

        [Help("Set/get the index of a lattice plane.", "int index")]
        public int SelectedIndex
        {
            set
            {
                Execute(new Action(() =>
                {
                    if (value >= 0 && value < main.formFitting.bindingSourcePlanes.Count)
                        main.formFitting.bindingSourcePlanes.Position = value;
                }));
            }
            get => Execute(() => main.formFitting.bindingSourcePlanes.Position);
        }

        [Help(" Set fitting range of the selected lattice plane.", "double range")]
        public void Range(double r) => main.formFitting.numericBoxSearchRange.Value = r;
    }
    #endregion

    #region Sequentialクラス
    public class SequentialClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        [Help("Get/set the full directory path to be saved.")]
        public string Directory
        {
            get => main.formSequentialAnalysis.textBoxDirectory.Text;
            set => Execute(new Action(() => main.formSequentialAnalysis.textBoxDirectory.Text = value));
        }

        [Help("Open 'Sequential Analysis' window.")]
        public void Open() => Execute(new Action(() => main.toolStripButtonSequentialAnalysis.Checked = true));

        [Help("Close 'Sequential Analysis' window.")]
        public void Close() => Execute(new Action(() => main.toolStripButtonSequentialAnalysis.Checked = false));

        [Help("Execute the sequential analysis.")]
        public void Execute() => Execute(() => main.formSequentialAnalysis.buttonExecute.PerformClick());

        [Help("Get results of 2 theta in CSV format.")]
        public string GetCSV_2theta() => Execute(() => main.formSequentialAnalysis.GetText(true, 0));

        [Help("Get results of d-spacing in CSV format.")]
        public string GetCSV_D() => Execute(() => main.formSequentialAnalysis.GetText(true, 1));
        [Help("Get results of FWHM in CSV format.")]
        public string GetCSV_FWHM() => Execute(() => main.formSequentialAnalysis.GetText(true, 2));
        [Help("Get results of peak intensity in CSV format.")]
        public string GetCSV_Intensity() => Execute(() => main.formSequentialAnalysis.GetText(true, 3));
        [Help("Get results of cell constants in CSV format.")]
        public string GetCSV_CellConstants() => Execute(() => main.formSequentialAnalysis.GetText(true, 4));
        [Help("Get results of pressure in CSV format.")]
        public string GetCSV_Pressure() => Execute(() => main.formSequentialAnalysis.GetText(true, 5));
        [Help("Get results of Singh equation in CSV format.")]
        public string GetCSV_Singh() => Execute(() => main.formSequentialAnalysis.GetText(true, 6));

        [Help("Get/set True or False.")]
        public bool AutoSave2theta
        {
            get => main.formSequentialAnalysis.checkBoxAutoSaveTwoTheta.Checked;
            set => Execute(new Action(() => main.formSequentialAnalysis.checkBoxAutoSaveTwoTheta.Checked = value));
        }

        [Help("Get/set True or False.")]
        public bool AutoSaveDspacing
        {
            get => main.formSequentialAnalysis.checkBoxAutoSaveD.Checked;
            set => Execute(new Action(() => main.formSequentialAnalysis.checkBoxAutoSaveD.Checked = value));
        }

        [Help("Get/set True or False.")]
        public bool AutoSaveFWHM
        {
            get => main.formSequentialAnalysis.checkBoxAutoSaveFWHM.Checked;
            set => Execute(new Action(() => main.formSequentialAnalysis.checkBoxAutoSaveFWHM.Checked = value));
        }

        [Help("Get/set True or False.")]
        public bool AutoSaveIntensity
        {
            get => main.formSequentialAnalysis.checkBoxAutoSaveInt.Checked;
            set => Execute(new Action(() => main.formSequentialAnalysis.checkBoxAutoSaveInt.Checked = value));
        }

        [Help("Get/set True or False.")]
        public bool AutoSaveCellConstants
        {
            get => main.formSequentialAnalysis.checkBoxAutoSaveCell.Checked;
            set => Execute(new Action(() => main.formSequentialAnalysis.checkBoxAutoSaveCell.Checked = value));
        }

        [Help("Get/set True or False.")]
        public bool AutoSavePressure
        {
            get => main.formSequentialAnalysis.checkBoxAutoSavePressure.Checked;
            set => Execute(new Action(() => main.formSequentialAnalysis.checkBoxAutoSavePressure.Checked = value));
        }

        [Help("Get/set True or False.")]
        public bool AutoSaveSingh
        {
            get => main.formSequentialAnalysis.checkBoxAutoSaveSingh.Checked;
            set => Execute(new Action(() => main.formSequentialAnalysis.checkBoxAutoSaveSingh.Checked = value));
        }

    }
    #endregion
}
