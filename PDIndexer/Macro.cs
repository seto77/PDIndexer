using Crystallography.Controls;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
// 260414Cl 削除: using Crystallography;   (Crystal 型を直接名前で触らなくなったので不要)
// 260414Cl 削除: using System.Data;       (DataRowView を Macro 側で扱わなくなったので不要)
// 260414Cl 削除: using static IronPython.Modules._ast; (どこからも使われていない異物)

namespace PDIndexer;

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
        help.AddRange(HelpAttribute.GenerateHelpText(Drawing.GetType(), nameof(Drawing)));

        ProfileList = new ProfileListClass(this);
        help.AddRange(HelpAttribute.GenerateHelpText(ProfileList.GetType(), nameof(ProfileList)));

        Profile = new ProfileClass(this);
        help.AddRange(HelpAttribute.GenerateHelpText(Profile.GetType(), nameof(Profile)));

        ProfileOperator = new ProfileOperatorClass(this);
        help.AddRange(HelpAttribute.GenerateHelpText(ProfileOperator.GetType(), nameof(ProfileOperator)));

        File = new FileClass(this);
        help.AddRange(HelpAttribute.GenerateHelpText(File.GetType(), nameof(File)));

        CrystalList = new CrystalListClass(this);
        help.AddRange(HelpAttribute.GenerateHelpText(CrystalList.GetType(), nameof(CrystalList)));

        Crystal = new CrystalClass(this);
        help.AddRange(HelpAttribute.GenerateHelpText(Crystal.GetType(), nameof(Crystal)));

        Fitting = new FittingClass(this);
        help.AddRange(HelpAttribute.GenerateHelpText(Fitting.GetType(), nameof(Fitting)));

        Sequential = new SequentialClass(this);
        help.AddRange(HelpAttribute.GenerateHelpText(Sequential.GetType(), nameof(Sequential)));

        // 260414Cl 追加: root クラス (Macro) 自身の Help (PDI.Sleep / PDI.Obj) も登録。
        // 旧版は GenerateHelpText を root に対して呼んでいなかったため死コードだった。
        help.AddRange(HelpAttribute.GenerateHelpText(GetType(), null));
    }

    [Help("Pause the macro execution for the given milliseconds.", "int millisec")]
    public static void Sleep(int millisec) => Thread.Sleep(millisec);

    [Help("Get/Set objects passed in from another program (inter-process arguments).")]
    public object[] Obj { get; set; }

    #endregion

    #region Fileクラス ファイル入出力関係

    /// <summary>
    /// ファイル入出力関係
    /// </summary>
    public class FileClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        [Help("Get a directory path (with trailing backslash).\r\n If 'filename' is omitted, a folder selection dialog opens.\r\n Otherwise the directory part of 'filename' is returned.", "string filename")]
        public string GetDirectoryPath(string filename = "") => Execute(() =>
        {
            // 260414Cl private helper getDirectoryPath をインライン化。
            if (filename == "")
            {
                using var dlg = new FolderBrowserDialog();
                return dlg.ShowDialog() == DialogResult.OK ? dlg.SelectedPath + "\\" : "\\";
            }
            return Path.GetDirectoryName(filename) + "\\";
        });

        [Help("Open a file selection dialog and return the full path of the chosen file.\r\n Returns an empty string if the user cancels.")]
        public string GetFileName() => Execute(() =>
        {
            // 260414Cl private helper getFileName をインライン化。
            using var dlg = new OpenFileDialog();
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : "";
        });

        [Help("Open a multi-select file dialog and return the full paths of the chosen files.\r\n Returns an empty array if the user cancels.")]
        public string[] GetFileNames() => Execute(() =>
        {
            // 260414Cl private helper getFileNames をインライン化。
            using var dlg = new OpenFileDialog { Multiselect = true };
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileNames : [];
        });

        [Help("Read profile data from the given file.\r\n If 'filename' is omitted (or does not exist), a file selection dialog will open.", "string filename")]
        public void ReadProfiles(string fileName = "") => Execute(() =>
        {
            if (!System.IO.File.Exists(fileName))
                main.menuItemFileRead_Click(new object(), new EventArgs());
            else
                main.readProfile(fileName);
        });

        [Help("Save profile data to the given file.\r\n If 'filename' is omitted, a save dialog will open.", "string filename")]
        public void SaveProfiles(string filename = "") => Execute(() =>
        {
            if (filename == "")
                main.savePatternProfileToolStripMenuItem_Click(new object(), new EventArgs());
            else
                main.SaveProfile(filename);
        });

        [Help("Read crystal data from the given file.\r\n If 'filename' is omitted (or does not exist), a file selection dialog will open.", "string filename")]
        public void ReadCrystals(string filename = "") => Execute(() =>
        {
            if (!System.IO.File.Exists(filename))
                main.menuItemReadCrystalData_Click(new object(), new EventArgs());
            else
                main.readCrystal(filename, false, true);
        });

        [Help("Save crystal data to the given file.\r\n If 'filename' is omitted, a save dialog will open.", "string filename")]
        public void SaveCrystals(string filename = "") => Execute(() =>
        {
            if (filename == "")
                main.menuItemSaveCrystalData_Click(new object(), new EventArgs());
            else
                main.saveCrystal(filename);
        });

        [Help("Save the current pattern as a Windows Metafile (.emf).\r\n If 'filename' is omitted, a save dialog will open.", "string filename")]
        public void SaveMetafile(string filename = "") => Execute(() =>
        {
            if (filename == "")
                main.toolStripMenuItemSaveMetafile_Click(new object(), new EventArgs());
            else
                main.saveMetafile(filename);
        });

        [Help("Save the given text content to a .txt file.\r\n If 'filename' is omitted, a save dialog will open.", "string text, string filename")]
        public void SaveText(string text, string filename = "") => Execute(() =>
        {
            // 260414Cl private helper saveText をインライン化。
            if (filename == "")
            {
                using var dlg = new SaveFileDialog { Filter = "*.txt|*.txt" };
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                filename = dlg.FileName;
            }
            System.IO.File.WriteAllText(filename, text);
        });
    }

    #endregion

    #region Drawingクラス 描画関係
    public class DrawingClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        [Help("Get/Set the upper limit of the X axis (the largest value the axis can take, not the current view).")]
        public double MaxX { get => Execute(() => main.MaximalX); set => Execute(() => main.MaximalX = value); }
        [Help("Get/Set the lower limit of the X axis (the smallest value the axis can take, not the current view).")]
        public double MinX { get => Execute(() => main.MinimalX); set => Execute(() => main.MinimalX = value); }
        [Help("Get/Set the upper limit of the Y axis (the largest value the axis can take, not the current view).")]
        public double MaxY { get => Execute(() => main.MaximalY); set => Execute(() => main.MaximalY = value); }
        [Help("Get/Set the lower limit of the Y axis (the smallest value the axis can take, not the current view).")]
        public double MinY { get => Execute(() => main.MinimalY); set => Execute(() => main.MinimalY = value); }

        [Help("Get/Set the right edge (end) of the X axis in the current drawing view.")]
        public double EndX { get => Execute(() => main.UpperX); set => Execute(() => main.UpperX = value); }
        [Help("Get/Set the left edge (start) of the X axis in the current drawing view.")]
        public double StartX { get => Execute(() => main.LowerX); set => Execute(() => main.LowerX = value); }
        [Help("Get/Set the top edge (end) of the Y axis in the current drawing view.")]
        public double EndY { get => Execute(() => main.UpperY); set => Execute(() => main.UpperY = value); }
        [Help("Get/Set the bottom edge (start) of the Y axis in the current drawing view.")]
        public double StartY { get => Execute(() => main.LowerY); set => Execute(() => main.LowerY = value); }

        [Help("Set the drawing view by giving the four edges (StartX, EndX, StartY, EndY).", "double startX, double endX, double startY, double endY")]
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

        // 260414Cl Macro 用公開 API 経由に変更: 旧版は main.bindingSourceCrystal.Current を直接叩いていた。
        // main.CurrentCrystal が同等の null 安全アクセスを提供する。

        [Help("Get the cell volume (Å^3) of the selected crystal.\r\n Returns 0 if no crystal is selected.")]
        public double CellVolume => Execute(() => main.CurrentCrystal?.Volume * 1000 ?? 0.0);

        [Help("Get the pressure (GPa) of the selected crystal calculated from its EOS.\r\n If 'volume' is 0 (default), the current cell volume is used.", "double volume")]
        public double Pressure(double volume = 0) => Execute(() =>
        {
            var c = main.CurrentCrystal;
            return c?.EOSCondition.GetPressure(volume == 0 ? c.Volume * 1000 : volume) ?? 0.0;
        });

        [Help("Get/Set the name of the selected crystal.")]
        public string Name
        {
            get => Execute(() => main.CurrentCrystal?.Name ?? "");
            // 260414Cl main.formCrystal.crystalControl.Name → main.SelectedCrystalDisplayName
            set => Execute(() => main.SelectedCrystalDisplayName = value);
        }

        #region 格子定数
        [Help("Get/Set the cell constant a (Å) of the selected crystal.")]
        public double CellA
        {
            set => Execute(() => changeCellConstants(0, value));
            get => Execute(() => main.CurrentCrystal?.A * 10 ?? 0.0);
        }
        [Help("Get/Set the cell constant b (Å) of the selected crystal.")]
        public double CellB
        {
            set => Execute(() => changeCellConstants(1, value));
            get => Execute(() => main.CurrentCrystal?.B * 10 ?? 0.0);
        }
        [Help("Get/Set the cell constant c (Å) of the selected crystal.")]
        public double CellC
        {
            set => Execute(() => changeCellConstants(2, value));
            get => Execute(() => main.CurrentCrystal?.C * 10 ?? 0.0);
        }
        [Help("Get/Set the cell constant alpha (deg) of the selected crystal.")]
        public double CellAlpha
        {
            set => Execute(() => changeCellConstants(3, value));
            get => Execute(() => main.CurrentCrystal?.Alpha / Math.PI * 180 ?? 0.0);
        }
        [Help("Get/Set the cell constant beta (deg) of the selected crystal.")]
        public double CellBeta
        {
            set => Execute(() => changeCellConstants(4, value));
            get => Execute(() => main.CurrentCrystal?.Beta / Math.PI * 180 ?? 0.0);
        }
        [Help("Get/Set the cell constant gamma (deg) of the selected crystal.")]
        public double CellGamma
        {
            set => Execute(() => changeCellConstants(5, value));
            get => Execute(() => main.CurrentCrystal?.Gamma / Math.PI * 180 ?? 0.0);
        }

        private void changeCellConstants(int index, double val)
        {
            var c = main.CurrentCrystal;
            if (c == null) return;
            if (index == 0) c.A = val / 10;
            if (index == 1) c.B = val / 10;
            if (index == 2) c.C = val / 10;
            if (index == 3) c.Alpha = val / 180.0 * Math.PI;
            if (index == 4) c.Beta = val / 180.0 * Math.PI;
            if (index == 5) c.Gamma = val / 180.0 * Math.PI;

            c.SetAxis();
            c.SetPlanes();
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
        private FormMain main => _p.main;

        // 260414Cl 以下、すべて FormMain の Macro 用公開 API 経由に変更。
        // 旧版は main.checkBoxCrystalParameter / main.bindingSourceCrystal / main.dataGridViewCrystals_CellMouseClick
        // を直接叩いていた。

        [Help("Open the 'Crystal List' window.")]
        public void Open() => main.CrystalListVisible = true;
        [Help("Close the 'Crystal List' window.")]
        public void Close() => main.CrystalListVisible = false;

        [Help("Get the total number of crystals in the list.")]
        public int Count => Execute(() => main.CrystalCount);

        [Help("Get the name of the currently selected crystal.\r\n Returns an empty string if no crystal is selected.")]
        public string SelectedName => Execute(() => main.CurrentCrystal?.Name ?? "");

        [Help("Get/Set the index of the currently selected crystal.")]
        public int SelectedIndex
        {
            set => Execute(() => main.CrystalListPosition = value);
            get => Execute(() => main.CrystalListPosition);
        }

        [Help("Select the crystal at the given index.", "int index")]
        public void Select(int n) => Execute(() => main.CrystalListPosition = n);

        [Help("Check or uncheck the crystal at the given index.\r\n If 'index' is -1, the currently selected crystal is targeted.", "int index, bool state")]
        public void Check(int n = -1, bool checkState = true) => Execute(() =>
        {
            if (n == -1) n = main.CrystalListPosition;
            main.SetCrystalChecked(n, checkState);
        });

        [Help("Uncheck the crystal at the given index.\r\n If 'index' is -1, the currently selected crystal will be unchecked.", "int index")]
        public void Uncheck(int n = -1) => Check(n, false);

        [Help("Get the cell volume (Å^3) of the selected crystal.\r\n Same as PDI.Crystal.CellVolume; kept for backward compatibility.")]
        public double GetCellVolume => Execute(() => main.CurrentCrystal?.Volume * 1000 ?? 0.0);
    }
    #endregion

    #region Profileクラス
    public class ProfileClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        // 260414Cl main.formProfile.textBoxXxx.Text を FormMain 公開プロパティ経由に変更

        [Help("Get/Set the comment text of the currently selected profile.")]
        public string Comment
        {
            get => Execute(() => main.SelectedProfileComment);
            set => Execute(() => main.SelectedProfileComment = value);
        }

        [Help("Get/Set the display name of the currently selected profile.")]
        public string Name
        {
            get => Execute(() => main.SelectedProfileDisplayName);
            set => Execute(() => main.SelectedProfileDisplayName = value);
        }
    }
    #endregion

    #region ProfileOperatorクラス
    public class ProfileOperatorClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        // 260414Cl FormMain 公開 API (RunProfileAverage / RunProfileAddition / ...) に委譲するだけに変更。
        // 旧版は main.formProfile.radioButton*.Checked と listBoxTwoProfiles1/2 を直接触り、
        // private void arithmetic() ヘルパを持っていたが FormMain 側の runProfileArithmetic に集約済み。

        [Help("Calculate the average of the profiles whose indices are listed in 'indices' (e.g. [1,3,5,9]).\r\n 'output' is the name given to the resulting profile.", "int[] indices, string output")]
        public void Average(int[] intArray, string outputName = "")
            => Execute(() => main.RunProfileAverage(intArray, outputName));

        [Help("Calculate profile1 + profile2.\r\n Each profile is specified by its index.\r\n 'output' is the name given to the resulting profile.", "int index1, int index2, string output")]
        public void AddTwoProfiles(int index1, int index2, string outputName = "")
            => Execute(() => main.RunProfileAddition(index1, index2, outputName));

        [Help("Calculate profile1 - profile2.\r\n Each profile is specified by its index.\r\n 'output' is the name given to the resulting profile.", "int index1, int index2, string output")]
        public void SubtractTwoProfiles(int index1, int index2, string outputName = "")
            => Execute(() => main.RunProfileSubtraction(index1, index2, outputName));

        [Help("Calculate profile1 * profile2.\r\n Each profile is specified by its index.\r\n 'output' is the name given to the resulting profile.", "int index1, int index2, string output")]
        public void MultiplyTwoProfiles(int index1, int index2, string outputName = "")
            => Execute(() => main.RunProfileMultiplication(index1, index2, outputName));

        [Help("Calculate profile1 / profile2.\r\n Each profile is specified by its index.\r\n 'output' is the name given to the resulting profile.", "int index1, int index2, string output")]
        public void DivideTwoProfiles(int index1, int index2, string outputName = "")
            => Execute(() => main.RunProfileDivision(index1, index2, outputName));
    }
    #endregion

    #region ProfileListクラス
    public class ProfileListClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        // 260414Cl 全て FormMain 公開 API 経由に変更。
        // 旧版は main.checkBoxProfileParameter / main.bindingSourceProfile / main.checkBoxAll /
        // main.formProfile.DeleteXxxProfiles / main.dataGridViewProfiles_CellClick を直接叩いていた。

        [Help("Open the 'Profile List' window.")]
        public void Open() => main.ProfileListVisible = true;

        [Help("Close the 'Profile List' window.")]
        public void Close() => main.ProfileListVisible = false;

        [Help("Delete all profiles from the list (no confirmation dialog).")]
        public void DeleteAll() => Execute(() => main.DeleteAllProfilesFromMacro(false));

        [Help("Delete the profile at the given index.", "int index")]
        public void Delete(int n) => Execute(() =>
        {
            Select(n);
            main.DeleteProfileFromMacro(n);
        });

        [Help("Get the total number of profiles in the list.")]
        public int Count => Execute(() => main.ProfileCount);

        [Help("Get the name of the currently selected profile.\r\n Returns an empty string if no profile is selected.")]
        public string SelectedName => Execute(() => main.CurrentProfile?.Name ?? "");

        [Help("Get/Set the index of the currently selected profile.")]
        public int SelectedIndex
        {
            set => Execute(() => main.ProfileListPosition = value);
            get => Execute(() => main.ProfileListPosition);
        }

        [Help("Select the profile at the given index.", "int index")]
        public void Select(int n) => Execute(() => main.ProfileListPosition = n);

        [Help("Check or uncheck the profile at the given index.\r\n If 'index' is -1, the currently selected profile is targeted.", "int index, bool state")]
        public void Check(int n = -1, bool checkState = true) => Execute(() =>
        {
            if (n == -1) n = main.ProfileListPosition;
            main.SetProfileChecked(n, checkState);
        });

        [Help("Uncheck the profile at the given index.\r\n If 'index' is -1, the currently selected profile will be unchecked.", "int index")]
        public void Uncheck(int n = -1) => Check(n, false);

        [Help("Check every profile in the list.")]
        public void CheckAll() => Execute(() => main.AllProfilesChecked = true);

        [Help("Uncheck every profile in the list.")]
        public void UncheckAll() => Execute(() => main.AllProfilesChecked = false);
    }
    #endregion

    #region Fittingクラス
    public class FittingClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        // 260414Cl FormMain 公開 API 経由に変更。旧版は main.toolStripButtonFittingParameter /
        // main.formFitting.bindingSourcePlanes / main.formFitting.numericBoxSearchRange /
        // main.formFitting.TargetCrystal / main.formFitting.dataGridViewPlaneList_SelectionChanged を直接叩いていた。

        [Help("Open the 'Fitting peaks' window.")]
        public void Open() => main.FittingWindowVisible = true;

        [Help("Close the 'Fitting peaks' window.")]
        public void Close() => main.FittingWindowVisible = false;

        [Help("Apply the optimized cell constants to the selected crystal\r\n (equivalent to clicking the 'Confirm' button on the fitting window).")]
        public void Apply() => Execute(() => main.ConfirmFitting(true));

        [Help("Check or uncheck the lattice plane at the given index.\r\n If 'index' is -1, the currently selected plane is targeted.", "int index, bool state")]
        public void Check(int n = -1, bool checkState = true) => Execute(() =>
        {
            if (n == -1) n = main.SelectedFittingPlaneIndex;
            main.SetFittingPlaneChecked(n, checkState);
        });

        [Help("Uncheck the lattice plane at the given index.\r\n If 'index' is -1, the currently selected plane will be unchecked.", "int index")]
        public void Uncheck(int n = -1) => Check(n, false);

        [Help("Select the lattice plane at the given index.", "int index")]
        public void Select(int n) => SelectedIndex = n;

        [Help("Get/Set the index of the currently selected lattice plane.")]
        public int SelectedIndex
        {
            set => Execute(() => main.SelectedFittingPlaneIndex = value);
            get => Execute(() => main.SelectedFittingPlaneIndex);
        }

        [Help("Set the peak search range for the currently selected lattice plane\r\n (in the same unit as the X axis).", "double range")]
        public void Range(double r) => Execute(() => main.FittingSearchRange = r);
    }
    #endregion

    #region Sequentialクラス
    public class SequentialClass(Macro _p) : MacroSub(_p.main)
    {
        private FormMain main => _p.main;

        // 260414Cl FormMain 公開 API (SequentialDirectory / SequentialWindowVisible /
        // RunSequentialAnalysis / GetSequentialCsv / SeqAutoSaveXxx) 経由に変更。

        [Help("Get/Set the full directory path where sequential analysis results are saved.")]
        public string Directory
        {
            get => Execute(() => main.SequentialDirectory);
            set => Execute(() => main.SequentialDirectory = value);
        }

        [Help("Open the 'Sequential Analysis' window.")]
        public void Open() => Execute(() => main.SequentialWindowVisible = true);

        [Help("Close the 'Sequential Analysis' window.")]
        public void Close() => Execute(() => main.SequentialWindowVisible = false);

        // 260414Cl 外部スクリプトから PDI.Sequential.Execute() で呼ばれるためリネーム不可。
        // MacroSub.Execute(Action) とは引数数が違うのでシャドーは発生せず、`new` / `base.` とも不要。
        [Help("Run the sequential analysis on all checked profiles.")]
        public void Execute() => Execute(main.RunSequentialAnalysis);

        [Help("Get the 2-theta results of the latest sequential analysis as a CSV string.")]
        public string GetCSV_2theta() => Execute(() => main.GetSequentialCsv(0));

        [Help("Get the d-spacing results of the latest sequential analysis as a CSV string.")]
        public string GetCSV_D() => Execute(() => main.GetSequentialCsv(1));
        [Help("Get the FWHM results of the latest sequential analysis as a CSV string.")]
        public string GetCSV_FWHM() => Execute(() => main.GetSequentialCsv(2));
        [Help("Get the peak intensity results of the latest sequential analysis as a CSV string.")]
        public string GetCSV_Intensity() => Execute(() => main.GetSequentialCsv(3));
        [Help("Get the cell constant results of the latest sequential analysis as a CSV string.")]
        public string GetCSV_CellConstants() => Execute(() => main.GetSequentialCsv(4));
        [Help("Get the pressure results of the latest sequential analysis as a CSV string.")]
        public string GetCSV_Pressure() => Execute(() => main.GetSequentialCsv(5));
        [Help("Get the Singh-equation results of the latest sequential analysis as a CSV string.")]
        public string GetCSV_Singh() => Execute(() => main.GetSequentialCsv(6));

        [Help("Get/Set whether 2-theta results are auto-saved after each sequential analysis run.")]
        public bool AutoSave2theta
        {
            get => Execute(() => main.SeqAutoSaveTwoTheta);
            set => Execute(() => main.SeqAutoSaveTwoTheta = value);
        }

        [Help("Get/Set whether d-spacing results are auto-saved after each sequential analysis run.")]
        public bool AutoSaveDspacing
        {
            get => Execute(() => main.SeqAutoSaveD);
            set => Execute(() => main.SeqAutoSaveD = value);
        }

        [Help("Get/Set whether FWHM results are auto-saved after each sequential analysis run.")]
        public bool AutoSaveFWHM
        {
            get => Execute(() => main.SeqAutoSaveFWHM);
            set => Execute(() => main.SeqAutoSaveFWHM = value);
        }

        [Help("Get/Set whether peak intensity results are auto-saved after each sequential analysis run.")]
        public bool AutoSaveIntensity
        {
            get => Execute(() => main.SeqAutoSaveIntensity);
            set => Execute(() => main.SeqAutoSaveIntensity = value);
        }

        [Help("Get/Set whether cell constant results are auto-saved after each sequential analysis run.")]
        public bool AutoSaveCellConstants
        {
            get => Execute(() => main.SeqAutoSaveCellConstants);
            set => Execute(() => main.SeqAutoSaveCellConstants = value);
        }

        [Help("Get/Set whether pressure results are auto-saved after each sequential analysis run.")]
        public bool AutoSavePressure
        {
            get => Execute(() => main.SeqAutoSavePressure);
            set => Execute(() => main.SeqAutoSavePressure = value);
        }

        [Help("Get/Set whether Singh-equation results are auto-saved after each sequential analysis run.")]
        public bool AutoSaveSingh
        {
            get => Execute(() => main.SeqAutoSaveSingh);
            set => Execute(() => main.SeqAutoSaveSingh = value);
        }
    }
    #endregion
}
