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

    #region マクロサンプル集
    // 260415Cl 追加
    public override (string name, string body)[] SampleMacros =>
        Thread.CurrentThread.CurrentUICulture.Name == "ja" ? _sampleMacrosJa : _sampleMacrosEn;

    private static readonly (string nameEn, string bodyEn, string nameJa, string bodyJa)[] _sampleMacros =
    [
        (
            "01. Basic loop and if",
            """
            # Loop 10 times computing the squares. Inside the loop, an if/else classifies 'i' as "even" or "odd"
            # and an if adds a "big" flag once 'sq' exceeds 25. Run with "Step by step" mode and watch
            # 'i', 'sq', 'kind', 'big' change in the debug panel (print() is not available here).
            for i in range(10):
                sq = i * i
                if i % 2 == 0:
                    kind = "even"
                else:
                    kind = "odd"
                big = sq > 25
            """,
            "01. 基本的なループと条件分岐",
            """
            # 10 回ループして二乗を計算し、ループ内の if/else で 'i' を "even" / "odd" に分類しつつ、
            # 'sq' が 25 を超えたら 'big' フラグを立てます。「Step by step」モードで実行すると、デバッグ
            # パネルで i・sq・kind・big の値の変化を確認できます (print() は使えません)。
            for i in range(10):
                sq = i * i
                if i % 2 == 0:
                    kind = "even"
                else:
                    kind = "odd"
                big = sq > 25
            """
        ),
        (
            "02. Math functions",
            """
            # The math module is pre-imported, so you can use it directly without an explicit import statement.
            # This sample shows pi, trigonometric (sin/cos), sqrt, exponential (exp), and logarithm (log).
            # Run in Step mode to inspect each variable in the debug panel.
            r = 5.0
            area          = math.pi * r * r            # circle area
            circumference = 2 * math.pi * r            # circle circumference
            s   = math.sin(math.pi / 6)                # sin(30°) = 0.5
            c   = math.cos(math.pi / 3)                # cos(60°) = 0.5
            t   = math.tan(math.pi / 4)                # tan(45°) = 1.0
            rt2 = math.sqrt(2)                         # square root of 2
            e2  = math.exp(2)                          # e^2 ≈ 7.389
            ln  = math.log(math.e)                     # natural log of e = 1.0
            lg  = math.log10(1000)                     # base-10 log of 1000 = 3.0
            """,
            "02. 数学関数の使用",
            """
            # math モジュールはあらかじめ import 済みなので、明示的な import 文なしにそのまま使えます。
            # このサンプルでは pi, 三角関数 (sin/cos/tan), sqrt, 指数関数 (exp), 対数関数 (log) を扱います。
            # Step モードで実行して各変数の値をデバッグパネルで確認しましょう。
            r = 5.0
            area          = math.pi * r * r            # 円の面積
            circumference = 2 * math.pi * r            # 円周の長さ
            s   = math.sin(math.pi / 6)                # sin(30°) = 0.5
            c   = math.cos(math.pi / 3)                # cos(60°) = 0.5
            t   = math.tan(math.pi / 4)                # tan(45°) = 1.0
            rt2 = math.sqrt(2)                         # 2 の平方根
            e2  = math.exp(2)                          # e^2 ≒ 7.389
            ln  = math.log(math.e)                     # e の自然対数 = 1.0
            lg  = math.log10(1000)                     # 1000 の常用対数 = 3.0
            """
        ),
        (
            "03. Drawing view setup",
            """
            # Configure the X/Y axis view to zoom into a specific 2-theta range. SetBounds takes the four edges
            # (startX, endX, startY, endY). You can also read/write each edge individually via StartX/EndX/...
            PDI.Drawing.SetBounds(10, 40, 0, 5000)
            start_x = PDI.Drawing.StartX
            end_x   = PDI.Drawing.EndX
            """,
            "03. 描画範囲の設定",
            """
            # X/Y 軸の表示範囲を特定の 2θ 領域に絞り込みます。SetBounds は 4 辺 (startX, endX, startY, endY)
            # をまとめて指定できます。StartX/EndX などで個別に読み書きすることも可能です。
            PDI.Drawing.SetBounds(10, 40, 0, 5000)
            start_x = PDI.Drawing.StartX
            end_x   = PDI.Drawing.EndX
            """
        ),
        (
            "04. Load profiles and crystals",
            """
            # Load a profile file and a crystal list file via dialogs (pass a path to skip the dialog).
            # After loading, inspect how many items are in each list. Run in Step mode to watch the counts.
            PDI.File.ReadProfiles()
            PDI.File.ReadCrystals()
            n_profiles = PDI.ProfileList.Count
            n_crystals = PDI.CrystalList.Count
            """,
            "04. プロファイル・結晶データの読み込み",
            """
            # プロファイルファイルと結晶リストファイルをダイアログ経由で読み込みます (パス指定でダイアログ省略可)。
            # 読み込み後、それぞれのリスト件数を取得します。Step モードで件数の変化を確認できます。
            PDI.File.ReadProfiles()
            PDI.File.ReadCrystals()
            n_profiles = PDI.ProfileList.Count
            n_crystals = PDI.CrystalList.Count
            """
        ),
        (
            "05. Inspect crystal cell constants",
            """
            # Select the first crystal in the list and read its name, cell constants (Å / deg), and cell volume.
            # Also compute the pressure from the current EOS. Run in Step mode to see each value.
            PDI.CrystalList.SelectedIndex = 0
            name   = PDI.Crystal.Name
            a      = PDI.Crystal.CellA
            b      = PDI.Crystal.CellB
            c      = PDI.Crystal.CellC
            alpha  = PDI.Crystal.CellAlpha
            beta   = PDI.Crystal.CellBeta
            gamma  = PDI.Crystal.CellGamma
            volume = PDI.Crystal.CellVolume
            press  = PDI.Crystal.Pressure()
            """,
            "05. 結晶の格子定数を確認",
            """
            # リスト先頭の結晶を選択し、名前・格子定数 (Å / deg)・単位胞体積を取得します。
            # 現在の EOS から圧力も計算します。Step モードで各値を確認しましょう。
            PDI.CrystalList.SelectedIndex = 0
            name   = PDI.Crystal.Name
            a      = PDI.Crystal.CellA
            b      = PDI.Crystal.CellB
            c      = PDI.Crystal.CellC
            alpha  = PDI.Crystal.CellAlpha
            beta   = PDI.Crystal.CellBeta
            gamma  = PDI.Crystal.CellGamma
            volume = PDI.Crystal.CellVolume
            press  = PDI.Crystal.Pressure()
            """
        ),
        (
            "06. Scan crystal list",
            """
            # Iterate over every crystal in the list and collect names and volumes into Python lists.
            # Use CrystalList.Count to iterate the whole list safely. Step mode shows the lists growing.
            names   = []
            volumes = []
            for i in range(PDI.CrystalList.Count):
                PDI.CrystalList.SelectedIndex = i
                names.append(PDI.Crystal.Name)
                volumes.append(PDI.Crystal.CellVolume)
            """,
            "06. 結晶リストの走査",
            """
            # 結晶リスト全件を走査し、名前と単位胞体積を Python リストに収集します。
            # CrystalList.Count で全件を安全にループできます。Step モードでリストが増えていく様子を確認できます。
            names   = []
            volumes = []
            for i in range(PDI.CrystalList.Count):
                PDI.CrystalList.SelectedIndex = i
                names.append(PDI.Crystal.Name)
                volumes.append(PDI.Crystal.CellVolume)
            """
        ),
        (
            "07. Average multiple profiles",
            """
            # Compute the average of profiles #0, #1, #2, #3 and add it to the list as "averaged".
            # ProfileOperator also supports pair-wise Add/Subtract/Multiply/Divide.
            PDI.ProfileOperator.Average([0, 1, 2, 3], "averaged")
            # PDI.ProfileOperator.SubtractTwoProfiles(1, 0, "background-subtracted")
            """,
            "07. 複数プロファイルの平均",
            """
            # プロファイル #0, #1, #2, #3 の平均を計算し、"averaged" という名前でリストに追加します。
            # ProfileOperator には 2 本同士の加減乗除 (Add/Subtract/Multiply/Divide) もあります。
            PDI.ProfileOperator.Average([0, 1, 2, 3], "averaged")
            # PDI.ProfileOperator.SubtractTwoProfiles(1, 0, "background-subtracted")
            """
        ),
        (
            "08. Fitting workflow",
            """
            # Open the fitting window, set a peak-search range for the selected plane, run fitting,
            # and apply the optimized cell constants back to the crystal (equivalent to clicking 'Confirm').
            PDI.Fitting.Open()
            PDI.Fitting.SelectedIndex = 0
            PDI.Fitting.Range(0.2)
            PDI.Fitting.Apply()
            """,
            "08. フィッティング操作",
            """
            # フィッティングウィンドウを開き、選択中の面にピーク探索範囲を設定してフィッティングを実行し、
            # 最適化された格子定数を結晶に反映します ('Confirm' ボタン相当)。
            PDI.Fitting.Open()
            PDI.Fitting.SelectedIndex = 0
            PDI.Fitting.Range(0.2)
            PDI.Fitting.Apply()
            """
        ),
        (
            "09. Sequential analysis and export",
            """
            # Check all profiles, run sequential analysis, then obtain 2-theta / d-spacing / cell-constant /
            # pressure results as CSV strings and save each to a file. SaveText with no filename opens a dialog.
            PDI.ProfileList.CheckAll()
            PDI.Sequential.Open()
            PDI.Sequential.Execute()
            dir_path = PDI.File.GetDirectoryPath()
            PDI.File.SaveText(PDI.Sequential.GetCSV_2theta(),        dir_path + "seq_2theta.csv")
            PDI.File.SaveText(PDI.Sequential.GetCSV_D(),             dir_path + "seq_d.csv")
            PDI.File.SaveText(PDI.Sequential.GetCSV_CellConstants(), dir_path + "seq_cell.csv")
            PDI.File.SaveText(PDI.Sequential.GetCSV_Pressure(),      dir_path + "seq_pressure.csv")
            """,
            "09. 逐次解析と結果の保存",
            """
            # 全プロファイルにチェックを入れて逐次解析を実行し、2θ / 面間隔 / 格子定数 / 圧力の結果を
            # CSV 文字列として取得してそれぞれファイルに保存します。SaveText にファイル名なしで呼ぶとダイアログが開きます。
            PDI.ProfileList.CheckAll()
            PDI.Sequential.Open()
            PDI.Sequential.Execute()
            dir_path = PDI.File.GetDirectoryPath()
            PDI.File.SaveText(PDI.Sequential.GetCSV_2theta(),        dir_path + "seq_2theta.csv")
            PDI.File.SaveText(PDI.Sequential.GetCSV_D(),             dir_path + "seq_d.csv")
            PDI.File.SaveText(PDI.Sequential.GetCSV_CellConstants(), dir_path + "seq_cell.csv")
            PDI.File.SaveText(PDI.Sequential.GetCSV_Pressure(),      dir_path + "seq_pressure.csv")
            """
        ),
        (
            "10. Save metafile series per profile",
            """
            # For each profile in the list, make it the sole checked one and save the current plot as an EMF.
            # Useful for generating one image per profile for reports.
            dir_path = PDI.File.GetDirectoryPath()
            for i in range(PDI.ProfileList.Count):
                PDI.ProfileList.UncheckAll()
                PDI.ProfileList.Check(i, True)
                PDI.ProfileList.SelectedIndex = i
                fname = dir_path + "profile_" + str(i).zfill(3) + ".emf"
                PDI.File.SaveMetafile(fname)
            """,
            "10. プロファイル毎のメタファイル保存",
            """
            # リスト内の各プロファイルについて、その 1 本だけをチェック状態にして現在の描画を EMF として保存します。
            # レポート用にプロファイル毎の画像を一括生成するのに便利です。
            dir_path = PDI.File.GetDirectoryPath()
            for i in range(PDI.ProfileList.Count):
                PDI.ProfileList.UncheckAll()
                PDI.ProfileList.Check(i, True)
                PDI.ProfileList.SelectedIndex = i
                fname = dir_path + "profile_" + str(i).zfill(3) + ".emf"
                PDI.File.SaveMetafile(fname)
            """
        ),
    ];

    private static readonly (string name, string body)[] _sampleMacrosEn
        = Array.ConvertAll(_sampleMacros, m => (name: m.nameEn, body: m.bodyEn));

    private static readonly (string name, string body)[] _sampleMacrosJa
        = Array.ConvertAll(_sampleMacros, m => (name: m.nameJa, body: m.bodyJa));
    #endregion

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
