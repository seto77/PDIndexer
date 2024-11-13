#region using

using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing.Drawing2D;
using Crystallography;
using Crystallography.Controls;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using IronPython.Hosting;
using System.Net;
using System.Threading.Tasks;
using MemoryPack;
using System.CodeDom;

#endregion

namespace PDIndexer;

#region FilePropertyクラス
[MemoryPackable]
public partial record struct FileProperty
{
    public bool Valid = false;
    public HorizontalAxisProperty HorizontalAxisProperty;

    public double ExposureTime=1;

    /// <summary>
    /// EDX detector用の変換係数 E  = (a₀ + a₁ n + a₂ n²) * 10³　多チャンネルを考慮して配列として用意しておく
    /// </summary>
    public double[][] EGC = [[0.0, 0.0, 0.0]];
    [MemoryPackConstructor]
    public FileProperty()
    { }
}
#endregion

public partial class FormMain : Form
{
    #region enum
    public enum FileType
    {
        CSV,
        RAS,
        NXS,
        CHI,
        XBM,
        RPT,
        NPD,
        TOF,
        XY,
        OTHRES,
    }
    #endregion

    #region プロパティ

    public FileProperty[] FileProperties { get; set; } = new FileProperty[Enum.GetValues(typeof(FileType)).Length];

    public FormCrystal formCrystal;
    public FormEOS formEOS;
    public FormFitting formFitting;
    public FormProfileSetting formProfile;
    public FormLPO formLPO;
    public FormCellFinder formCellFinder;
    public FormAtomicPositionFinder formAtomicPositionFinder;
    public FormSequentialAnalysis formSequentialAnalysis;
    public FormMacro FormMacro;
    public FormTwoThetaCalibration formTwoThetaCalibration;

    Crystallography.Controls.CommonDialog initialDialog;

    public bool BackGroundPointSelectMode { get; set; } = false;
    public int[] SelectedMaskingBoundaryIndex { set; get; } = [-1, -1];

    public bool MaskingMode { get; set; } = false;

    private Point mouseRangeStart, mouseRangeEnd;

    public bool MouseRangingMode { set; get; } = false;

    private PointD mouseMovingStartPt;
    public bool MouseMovingMode { set; get; } = false;

    public bool ShowBackgroundProfile = false;


    public FormDataConverter formDataConverter;

    public bool IsSkipCheckedListBoxEvent = false;

    public int SelectedCrystalIndex { set; get; } = -1;

    public int SelectedPlaneIndex { set; get; } = -1;

    public bool IsPlaneSelected { get; set; } = false;

    public DiffractionProfile2 defaultDP = new();
    public int FilterIndex { get; set; }
    public string InitialDirectory { get; set; } = "";

    public double LowerX
    {
        set
        {
            numericBoxLowerX.Value = value;
            if (UpperX <= LowerX)
                UpperX++;
        }
        get { return numericBoxLowerX.Value; }
    }
    public double UpperX { set { numericBoxUpperX.Value = value; if (UpperX <= LowerX) LowerX++; } get => numericBoxUpperX.Value; }
    public double LowerY { set { numericBoxLowerY.Value = value; if (UpperY <= LowerY) UpperY++; } get => numericBoxLowerY.Value; }
    public double UpperY { set { numericBoxUpperY.Value = value; if (UpperY <= LowerY) LowerY--; } get { return numericBoxUpperY.Value; } }

    public double MaximalX
    {
        set
        {
            if (numericBoxUpperX.Minimum > value)
                numericBoxUpperX.Minimum = numericBoxLowerX.Minimum = value - 1;

            numericBoxUpperX.Maximum = numericBoxLowerX.Maximum = value;
        }
        get => numericBoxUpperX.Maximum;
    }
    public double MinimalX
    {
        set
        {
            if (numericBoxUpperX.Maximum < value)
                numericBoxUpperX.Maximum = numericBoxLowerX.Maximum = value + 1;

            numericBoxUpperX.Minimum = numericBoxLowerX.Minimum = value;
        }
        get => numericBoxLowerX.Minimum;
    }
    public double MaximalY
    {
        set
        {
            if (numericBoxUpperY.Minimum > value)
                numericBoxUpperY.Minimum = numericBoxLowerY.Minimum = value - 1;

            numericBoxUpperY.Maximum = numericBoxLowerY.Maximum = value;
        }
        get => numericBoxUpperY.Maximum;
    }
    public double MinimalY
    {
        set
        {
            if (numericBoxUpperY.Maximum < value)
                numericBoxUpperY.Maximum = numericBoxLowerY.Maximum = value + 1;

            numericBoxUpperY.Minimum = numericBoxLowerY.Minimum = value;
        }
        get => numericBoxLowerY.Minimum;
    }

    public Bitmap BmpMain, BmpIntensity, BmpAngle;
    public Graphics gMain, gAngle, gIntensity;
    public HorizontalAxisProperty HorizontalAxisProperty
    {
        set
        {
            if (value != HorizontalAxisProperty)
                horizontalAxisUserControl.HorizontalAxisProperty = value;
        }
        get => horizontalAxisUserControl.HorizontalAxisProperty;
    }

    /// <summary>
    /// 入射線の種類
    /// </summary>
    public WaveSource WaveSource
    {
        set
        {
            if (horizontalAxisUserControl.WaveSource != value)
                horizontalAxisUserControl.WaveSource = value;
        }
        get => horizontalAxisUserControl.WaveSource;
    }
    /// <summary>
    /// 入射線の色
    /// </summary>
    public WaveColor WaveColor
    {
        set
        {
            if (horizontalAxisUserControl.WaveColor != value)
                horizontalAxisUserControl.WaveColor = value;
        }
        get => horizontalAxisUserControl.WaveColor;
    }

    /// <summary>
    /// 入射線の波長
    /// </summary>
    public double WaveLength
    {
        set
        {
            if (horizontalAxisUserControl.WaveLength != value)
                horizontalAxisUserControl.WaveLength = value;
        }
        get => horizontalAxisUserControl.WaveLength;
    }
    //X線の元素
    public int XraySourceElementNumber
    {
        set
        {
            if (horizontalAxisUserControl.XrayNumber != value)
                horizontalAxisUserControl.XrayNumber = value;
        }
        get => horizontalAxisUserControl.XrayNumber;
    }
    //X線の元素
    public XrayLine XraySourceLine
    {
        set
        {
            if (horizontalAxisUserControl.XrayLine != value)
                horizontalAxisUserControl.XrayLine = value;
        }
        get => horizontalAxisUserControl.XrayLine;
    }

    //EDX取り出し角
    public double TakeoffAngle
    {
        set
        {
            if (horizontalAxisUserControl.TakeoffAngle != value)
                horizontalAxisUserControl.TakeoffAngle = value;
        }
        get => horizontalAxisUserControl.TakeoffAngle;
    }

    //TOF取り出し角
    public double TofAngle
    {
        set
        {
            if (horizontalAxisUserControl.TofAngle != value)
                horizontalAxisUserControl.TofAngle = value;
        }
        get => horizontalAxisUserControl.TofAngle;
    }

    //TOF取り出し距離
    public double TofLength
    {
        set
        {
            if (horizontalAxisUserControl.TofLength != value)
                horizontalAxisUserControl.TofLength = value;
        }
        get => horizontalAxisUserControl.TofLength;
    }

    //横軸の種類
    public HorizontalAxis AxisMode
    {
        set
        {
            if (horizontalAxisUserControl.AxisMode != value)
                horizontalAxisUserControl.AxisMode = value;
        }
        get => horizontalAxisUserControl.AxisMode;
    }

    //横軸の状態
    public HorizontalAxisProperty AxisProperty
    {
        set
        {
            if (horizontalAxisUserControl.HorizontalAxisProperty != value)
                horizontalAxisUserControl.HorizontalAxisProperty = value;
        }
        get => horizontalAxisUserControl.HorizontalAxisProperty;
    }


    private Stopwatch stopwatch { get; set; } = new Stopwatch();


    #endregion

    #region フィールド
    public bool IsBgPtSelected = false;
    public int SelectedBgPtIndex = -1;
    public int SelectedProfileIndex = -1;

    public bool IsSkipTextBoxChange = false;

    Point OriginPos = new(40, 24); //原点の位置
    public float IntervalOfProfiles = 0;
    public float HeightOfBottomPeaks = 0;
    public float BottomMargin = 0;

    public DataGridViewCellStyle cellStyle1 = new();
    public DataGridViewCellStyle cellStyle2 = new();
    public DataGridViewCellStyle cellStyleBlink = new();

    public bool IsLoaded = false;
    private IntPtr NextHandle;
    private const int WM_DRAWCLIPBOARD = 0x0308;

    private const int WM_CHANGECBCHAIN = 0x030D;
    [DllImport("user32")]
    public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
    [DllImport("user32")]
    public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
    [DllImport("user32", CharSet = CharSet.Auto)]
    public extern static int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

    private PrintDocument printDocument;
    private PrintPreviewDialog printPreviewDialog;

    private Macro macro;
    readonly IProgress<(long, long, long, string)> ip;//IReport

    public string UserAppDataPath = new DirectoryInfo(Application.UserAppDataPath).Parent.FullName + @"\";


    #endregion

    #region クリップボードおよびディレクトリの監視
    protected override void WndProc(ref Message msg)
    {
        switch (msg.Msg)
        {
            case WM_DRAWCLIPBOARD:

                using (var mutex = new Mutex(false, "PDIndexer"))
                {
                    if (mutex.WaitOne(5000, false))
                    {
                        try
                        {
                            if (Clipboard.GetDataObject().GetDataPresent(typeof(DiffractionProfile2)))
                            {
                                var data = Clipboard.GetDataObject();
                                var dp = (DiffractionProfile2)data.GetData(typeof(DiffractionProfile2));

                                if (dp != null)
                                    AddProfileToCheckedListBox(dp, true, true);
                            }
                            else if (Clipboard.GetDataObject().GetDataPresent(typeof(DiffractionProfile2[])))
                            {
                                var dataObject = Clipboard.GetDataObject();
                                var data = dataObject;
                                var dp = (DiffractionProfile2[])data.GetData(typeof(DiffractionProfile2[]));

                                if (dp != null && dp.Length >= 1)
                                {
                                    if (dp[0].Name != null && dp[0].Name.EndsWith("whole"))
                                    {
                                        radioButtonMultiProfileMode.Checked = false;
                                        radioButtonMultiProfileMode_CheckChanged(new object(), new EventArgs());
                                        AddProfileToCheckedListBox(dp[0], true, true);
                                        radioButtonMultiProfileMode.Checked = true;
                                        radioButtonMultiProfileMode_CheckChanged(new object(), new EventArgs());
                                        for (int i = 1; i < dp.Length; i++)
                                            AddProfileToCheckedListBox(dp[i], false, true);
                                        bindingSourceProfile.Position = 0;
                                    }
                                    else
                                    {
                                        if (dp.Length == 1)
                                            AddProfileToCheckedListBox(dp[0], true, true);
                                        else
                                        {
                                            skipAxisPropertyChangedEvent = true;
                                            for (int i = 0; i < dp.Length - 1; i++)
                                                AddProfileToCheckedListBox(dp[i], false, false);
                                            skipAxisPropertyChangedEvent = false;
                                            AddProfileToCheckedListBox(dp[^1], false, true);
                                            horizontalAxisUserControl_AxisPropertyChanged();
                                        }
                                    }
                                }
                            }

                            else if (Clipboard.GetDataObject().GetDataPresent(typeof(Crystal2)) && formCrystal.Visible)
                            {
                                IDataObject data = Clipboard.GetDataObject();
                                var c2 = (Crystal2)data.GetData(typeof(Crystal2));
                                formCrystal.crystalControl.Crystal = Crystal2.GetCrystal(c2);
                            }
                            else if ((Clipboard.GetDataObject()).GetDataPresent(typeof(MacroTriger)))
                            {
                                MacroTriger trigger = (MacroTriger)Clipboard.GetDataObject().GetData(typeof(MacroTriger));

                                if (trigger.Target == "PDI")
                                {
                                    macro.Obj = trigger.Obj;
                                    FormMacro.Visible = true;
                                    if (trigger.MacroName == "")
                                        FormMacro.RunMacro(trigger.Debug);
                                    else
                                        FormMacro.RunMacroName(trigger.MacroName, trigger.Debug);
                                }
                            }
                            else if ((Clipboard.GetDataObject()).GetDataPresent(typeof(string)))
                            {
                                if ((string)Clipboard.GetDataObject().GetData(typeof(string)) == "IPAnalyzer")
                                    resetClipboardViewer();
                            }
                        }
                        catch { MessageBox.Show("Failed to read clipboard information. Sorry."); }
                        finally { mutex.ReleaseMutex(); }

                        if ((int)NextHandle != 0)
                            SendMessage(NextHandle, msg.Msg, msg.WParam, msg.LParam);
                    }
                    else//mutexを取るのに失敗していたら
                    {
                        resetClipboardViewer();
                    }
                    mutex.Close();
                }
                break;

            case WM_CHANGECBCHAIN:
                if (msg.WParam == NextHandle)
                    NextHandle = (IntPtr)msg.LParam;
                else if ((int)NextHandle != 0)
                    SendMessage(NextHandle, msg.Msg, msg.WParam, msg.LParam);
                break;
        }
        base.WndProc(ref msg);
    }

    //ファイル更新監視ウォッチャー
    FileSystemWatcher watcher;
    void watcher_Created(object sender, System.IO.FileSystemEventArgs e)
    {
        if (e.FullPath.EndsWith("pdi"))
        {
            watcher.EnableRaisingEvents = false;
            do
            {
                try
                {
                    var fs = File.Open(e.FullPath, FileMode.Open);
                    fs.Close();
                    break;
                }
                catch { Thread.Sleep(100); }
            }
            while (true);

            readProfile(e.FullPath);
            watcher.EnableRaisingEvents = true;
        }
    }
    #endregion

    #region コンストラクタ、ロード、クローズ
    public FormMain()
    {
        //カルチャーを決めるため、レジストリ読込
        if (!DesignMode)
        {
            var key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\PDIndexer");
            if (4.440 > Convert.ToDouble(key.GetValue("Version", "0")))
                ClearRegistry();
            Registry(Reg.Mode.Read);
        }

        InitializeComponent();

        if (DesignMode) return;

        //MainWindowの場所を読み込むため (InitializeComponentの後にに読み込む)
        Registry(Reg.Mode.Read);

        stopwatch.Start();

        ip = new Progress<(long, long, long, string)>(o => reportProgress(o));//IReport

        setScale();

        typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dataGridViewCrystals, true, null);
        typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dataGridViewProfiles, true, null);
    }

    //メインがロードされたときに実行
    private void FormMain_Load(object sender, System.EventArgs e)
    {
        if (DesignMode) return;

        englishToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name != "ja";
        japaneseToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name == "ja";

        initialDialog = new Crystallography.Controls.CommonDialog()
        {
            Owner = this,
            DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.Initialize,
            VersionAndDate = Version.VersionAndDate,
            Hint = Version.HintEn,
            Software = Version.Software,
            History = Version.History,

            Location = new Point(this.Location.X, this.Location.Y),
            Width=580,
        };

        initialDialog.Show();
        Application.DoEvents();

        initialDialog.Text = "Now Loading... Initializing 'Profile Parameter' form.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.1);
        formProfile = new FormProfileSetting { formMain = this, Visible = false, Owner = this };


        initialDialog.Text = "Now Loading... Initializing 'Crystal Parameter' form.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.25);
        formCrystal = new FormCrystal { formMain = this, Visible = false, Owner = this };


        initialDialog.Text = "Now Loading... Initializing 'Equation of States' form.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.4);

        formEOS = new FormEOS { formMain = this, Visible = false, Owner = this };
        formEOS.numericalTextBox_ValueChanged(new object(), new EventArgs());

        initialDialog.Text = "Now Loading... Initializing 'Peak Fitting' form.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.45);

        formFitting = new FormFitting { formMain = this, Opacity = 0, Visible = true, Owner = this };
        formFitting.Visible = false;
        formFitting.Opacity = 1;

        initialDialog.Text = "Now Loading... Initializing 'LPO' form.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.55);
        formLPO = new FormLPO { formMain = this, Visible = false, Owner = this };

        initialDialog.Text = "Now Loading... Initializing 'Cell Finder' form.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.65);
        formCellFinder = new FormCellFinder { formMain = this, Visible = false, Owner = this };

        initialDialog.Text = "Now Loading... Initializing 'Atomic Position Finder' form.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.75);
        formAtomicPositionFinder = new FormAtomicPositionFinder { formMain = this, Visible = false, Owner = this };

        initialDialog.Text = "Now Loading... Initializing 'Sequential Analysis' form.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.85);
        formSequentialAnalysis = new FormSequentialAnalysis { formMain = this, Visible = false, Owner = this };

        initialDialog.Text = "Now Loading... Initializing '2θ calibration' form.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.87);
        formTwoThetaCalibration = new FormTwoThetaCalibration { formMain = this, Visible = false, Owner = this };


        initialDialog.Text = "Now Loading... Initializing 'Data Converter' form.";
        formDataConverter = new FormDataConverter();

        initialDialog.Text = "Now Loading... Initializing macro functions.";
        macro = new Macro(this);
        FormMacro = new FormMacro(Python.CreateEngine(), macro) { Visible = false };

        this.Text = "PDIndexer   " + Version.VersionAndDate;
#if DEBUG
        this.Text += "(debug)";
#endif

        initialDialog.Text = "Now Loading... Reading default crystal lists.";
        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.90);

        //ユーザーパスにxmlファイルをコピー
        var appPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\";
        if (File.Exists(appPath + "default.xml"))
            File.Copy(appPath + "default.xml", UserAppDataPath + "initial.xml", true);
        if (!File.Exists(UserAppDataPath + "default.xml") || new FileInfo(UserAppDataPath + "default.xml").Length < 200)
            File.Copy(appPath + "default.xml", UserAppDataPath + "default.xml", true);

        if (!File.Exists(UserAppDataPath + "PDIndexerSetup.msi"))
            File.Delete(UserAppDataPath + "PDIndexerSetup.msi");

        //StdDbをコピー
        File.Copy(appPath + "StdDb.cdb3", UserAppDataPath + "StdDb.cdb3", true);

        //UserAppDataPathに空フォルダがあったら削除
        foreach (var dir in Directory.GetDirectories(UserAppDataPath))
            if (!Directory.EnumerateFileSystemEntries(dir).Any())
                Directory.Delete(dir);


        //結晶ファイル読み込み
        try
        {
            if (automaticallySaveTheCrystalListToolStripMenuItem.Checked)
                readCrystal(UserAppDataPath + "default.Xml", false, true);
            else
                readCrystal(UserAppDataPath + "initial.Xml", false, true);

            if (bindingSourceCrystal.Count == 0)
                readCrystal(UserAppDataPath + "initial.Xml", false, true);
        }
        catch
        {
            readCrystal(UserAppDataPath + "initial.Xml", false, true);
        }


        initialDialog.Text = "Now Loading... Binding dataset between forms.";
        //formCrystalとの連携
        formCrystal.dataSet = this.dataSet;
        formCrystal.bindingSource = this.bindingSourceCrystal;
        formCrystal.bindingSource.DataSource = this.dataSet;
        formCrystal.bindingSource.DataMember = "DataTableCrystal";
        formCrystal.dataGridViewCrystal.DataSource = this.bindingSourceCrystal;

        //formProfileとの連携
        formProfile.dataSetProfile = this.dataSet;
        formProfile.bindingSourceProfile = this.bindingSourceProfile;
        formProfile.bindingSourceProfile.DataSource = this.dataSet;
        formProfile.bindingSourceProfile.DataMember = "DataTableProfile";
        formProfile.dataGridViewProfile.DataSource = this.bindingSourceProfile;
        formProfile.comboBoxBackgroundReferrence.DataSource = this.dataSet;
        formProfile.bindingSourceProfile.ListChanged += new ListChangedEventHandler(formProfile.bindingSource_ListChanged);
        formProfile.bindingSourceProfile.CurrentChanged += new EventHandler(formProfile.bindingSource_CurrentChanged);

        //formFittingとの連携
        formFitting.dataSet = this.dataSet;
        formFitting.bindingSourceCrystals = this.bindingSourceCrystal;
        formFitting.bindingSourceCrystals.DataSource = this.dataSet;
        formFitting.bindingSourceCrystals.DataMember = "DataTableCrystal";
        formFitting.dataGridViewCrystals.DataSource = this.bindingSourceCrystal;

        formFitting.bindingSourcePlanes.DataSource = this.dataSet;
        formFitting.bindingSourcePlanes.DataMember = "DataTablePeakFitting";
        formFitting.dataGridViewPlaneList.DataSource = formFitting.bindingSourcePlanes;


        //dataGridViewの色の設定
        cellStyle1.BackColor = Color.LightBlue;
        cellStyle2.BackColor = Color.LightPink;
        cellStyleBlink.BackColor = Color.White;


        initialDialog.Text = "Now Loading... Initializing file system watcher.";
        //ファイル更新監視
        watcher = new FileSystemWatcher { IncludeSubdirectories = true };
        watcher.Created += new System.IO.FileSystemEventHandler(watcher_Created);
        watcher.Path = "";
        watcher.EnableRaisingEvents = false;

        initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 1.0);

        //SetRangeTextBox();

        initialDialog.Text = "Now Loading... Generating 'ReadMe.txt'.";

        initialDialog.Text = "Now Loading... Initializing print function.";
        //プリント関係  
        printDocument = new System.Drawing.Printing.PrintDocument();
        printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);

        // PrintPreviewDialogオブジェクトの生成
        printPreviewDialog = new PrintPreviewDialog { Document = printDocument };

        initialDialog.Text = "Now Loading... Starting clipboard wather.";
        //クリップボード監視
        NextHandle = SetClipboardViewer(this.Handle);

        initialDialog.Text = "Now Loading... Bringing the main form to front.";
        pictureBoxMain.BringToFront();

        initialDialog.Text = "Now Loading... Reading registry.";
        Registry(Reg.Mode.Read);

        numericBoxUpperX.Value = 30;

        initialDialog.Text = "Now Loading... Reading registry.";
        if (dataGridViewCrystals.Columns.Count > 0)
        {
            //dataGridViewCrystals_CellMouseClick(new object(), 
            //    new DataGridViewCellMouseEventArgs(1, 2, 0, 0,new MouseEventArgs(MouseButtons.Left,1,0,0,0)));
            //dataGridViewCrystals_CellContentClick(new object(), new DataGridViewCellEventArgs(1, 2));
        }

        //unrolled image関連
        comboBoxGradient.SelectedIndex = 1;
        comboBoxScale1.SelectedIndex = 1;
        comboBoxScale2.SelectedIndex = 0;

        initialDialog.Text = "Now Loading... Trying dummy mouse operation.";
        initialDialog.Text = "Initializing has been finished successfully. You can close this window.";
        if (initialDialog.AutomaticallyClose)
            initialDialog.Visible = false;

        toolStripStatusLabelCalcTime.Text = "Initial loading time: " + stopwatch.ElapsedMilliseconds + " ms.";

    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        timerBlinkDiffraction.Stop();
        //formFitting.Close();
        //formCrystal.Close();
        //formProfile.Close();
        //formEOS.Close();
        dataSet.DataTableProfile.Clear();

        e.Cancel = false;

        if (automaticallySaveTheCrystalListToolStripMenuItem.Checked)
        {
            var cry = new List<Crystal>();
            for (int i = 0; i < dataSet.DataTableCrystal.Count; i++)

                cry.Add(dataSet.DataTableCrystal.Items[i]);
            ConvertCrystalData.SaveCrystalListXml([.. cry], UserAppDataPath + "default.xml");
        }
    }
    //フォームクローズ時
    private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
    {
        //クリップボードを切る
        ChangeClipboardChain(this.Handle, NextHandle);
        if (!clearRegistryToolStripMenuItem.Checked)//Flagが立っていなければレジストリに書き込み
            Registry(Reg.Mode.Write);
        else
            ClearRegistry();
    }
    #endregion

    #region レジストリ操作

    private static void ClearRegistry()
    {
        try { Microsoft.Win32.Registry.CurrentUser.DeleteSubKey("Software\\Crystallography\\PDIndexer"); }
        catch { }

    }

    private void Registry(Reg.Mode mode)
    {
        var key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\PDIndexer");
        if (key == null) return;

        if (mode == Reg.Mode.Write)
            key.SetValue("Version", Version.VersionValue);

        Reg.RW<string>(key, mode, Thread.CurrentThread.CurrentUICulture, "Name");
                
        Reg.RW<Rectangle>(key, mode, this, "Bounds");
        WindowLocation.Adjust(this);

        if (initialDialog == null)
            return;

        Reg.RW<bool>(key, mode, initialDialog, "AutomaticallyClose");

        if (formEOS == null) return;

        Reg.RW<Rectangle>(key, mode, formEOS, "Bounds");
        Reg.RW<Rectangle>(key, mode, formCrystal, "Bounds");
        Reg.RW<Rectangle>(key, mode, formFitting, "Bounds");
        Reg.RW<Rectangle>(key, mode, formProfile, "Bounds");

        #region FormMain
        Reg.RW<HorizontalAxisProperty>(key, mode, this, "HorizontalAxisProperty");

        Reg.RW<string>(key, mode, this.numeriBoxIncreasingPixels, "Text");

        Reg.RW<bool>(key, mode, this.automaticallySaveTheCrystalListToolStripMenuItem, "Checked");

        Reg.RW<string>(key, mode, this, "InitialDirectory");
        Reg.RW<int>(key, mode, this, "FilterIndex");
        #endregion

        #region FormCrystal

        Reg.RW<bool>(key, mode, formCrystal.checkBoxShowPeakOverProfiles, "Checked");
        Reg.RW<bool>(key, mode, formCrystal.checkBoxCalculateIntensity, "Checked");
        Reg.RW<bool>(key, mode, formCrystal.checkBoxVariableRatioOfIntensity, "Checked");
        Reg.RW<bool>(key, mode, formCrystal.checkBoxShowPeakUnderProfile, "Checked");
        Reg.RW<bool>(key, mode, formCrystal.radioButtonAllCheckedCrystals, "Checked");
        Reg.RW<decimal>(key, mode, formCrystal.numericUpDownHeightOfBottomPeak, "Value");
        #endregion

        #region マクロ

        if (mode == Reg.Mode.Read)
            FormMacro.ZippedMacros = (byte[])key.GetValue("Macro", Array.Empty<byte>());
        else
            key.SetValue("Macro", FormMacro.ZippedMacros);
        #endregion

        #region ファイルタイプごとのパラメータ

        Reg.RW<FileProperty[]>(key, mode, this, "FileProperties");

        #region  レジストリが無効な場合には、初期化
        if (mode == Reg.Mode.Read)
        {
            //RAS
            if (!FileProperties[(int)FileType.RAS].Valid)

                FileProperties[(int)FileType.RAS] = new FileProperty
                {
                    Valid = true,
                    HorizontalAxisProperty = new HorizontalAxisProperty(29, XrayLine.Ka1, AngleUnitEnum.Degree)
                };

            //CSVの場合
            if (!FileProperties[(int)FileType.CSV].Valid)
                FileProperties[(int)FileType.CSV] = new FileProperty
                {
                    Valid = true,
                    HorizontalAxisProperty = new HorizontalAxisProperty(WaveSource.Xray, 0.4, AngleUnitEnum.Degree)
                };

            //NXS
            if (!FileProperties[(int)FileType.NXS].Valid)
                FileProperties[(int)FileType.NXS] = new FileProperty
                {
                    Valid = true,
                    HorizontalAxisProperty = new HorizontalAxisProperty(WaveSource.Xray, 4.95 / 180 * Math.PI, EnergyUnitEnum.KeV),
                    EGC = [[0, 0, 66.6, 0.0]]
                };

            //CHI
            if (!FileProperties[(int)FileType.CHI].Valid)
                FileProperties[(int)FileType.CHI] = new FileProperty
                {
                    Valid = true,
                    HorizontalAxisProperty = new HorizontalAxisProperty(WaveSource.Xray, 0.4, AngleUnitEnum.Degree)
                };

            //XBM
            if (!FileProperties[(int)FileType.XBM].Valid)
                FileProperties[(int)FileType.XBM] = new FileProperty
                {
                    Valid = true,
                    HorizontalAxisProperty = new HorizontalAxisProperty(WaveSource.Xray, 5 / 180 * Math.PI, EnergyUnitEnum.KeV),
                };
            //RPT
            if (!FileProperties[(int)FileType.RPT].Valid)
                FileProperties[(int)FileType.RPT] = new FileProperty
                {
                    Valid = true,
                    HorizontalAxisProperty = new HorizontalAxisProperty(WaveSource.Xray, 5 / 180 * Math.PI, EnergyUnitEnum.KeV),
                };

            //NPD
            if (!FileProperties[(int)FileType.NPD].Valid)
                FileProperties[(int)FileType.NPD] = new FileProperty
                {
                    Valid = true,
                    HorizontalAxisProperty = new HorizontalAxisProperty(WaveSource.Xray, 5 / 180 * Math.PI, EnergyUnitEnum.KeV),
                };

            //TOF
            if (!FileProperties[(int)FileType.TOF].Valid)
                FileProperties[(int)FileType.TOF] = new FileProperty
                {
                    Valid = true,
                    HorizontalAxisProperty = new HorizontalAxisProperty(90.0 / 180.0 * Math.PI, 26.5, TimeUnitEnum.MicroSecond)
                };

            //MISC
            if (!FileProperties[(int)FileType.OTHRES].Valid)
                FileProperties[(int)FileType.OTHRES] = new FileProperty
                {
                    Valid = true,
                    HorizontalAxisProperty = new HorizontalAxisProperty(WaveSource.Xray, 0.4, AngleUnitEnum.Degree)
                };
        }
        #endregion

        #endregion

        #region FormEOS
        Reg.RW<double>(key, mode, formEOS, "Ar_a0");
        Reg.RW<double>(key, mode, formEOS, "Al2O3_v0");
        Reg.RW<double>(key, mode, formEOS, "Au_a0");
        Reg.RW<double>(key, mode, formEOS, "MgO_a0");
        Reg.RW<double>(key, mode, formEOS, "NaCl_a0");
        Reg.RW<double>(key, mode, formEOS, "Pt_a0");
        Reg.RW<double>(key, mode, formEOS, "Mo_v0");
        Reg.RW<double>(key, mode, formEOS, "Re_v0");
        Reg.RW<double>(key, mode, formEOS, "Pb_a0");
        Reg.RW<double>(key, mode, formEOS, "Temperature0");
        Reg.RW<double>(key, mode, formEOS, "Temperature");
        #endregion
        key.Close();
    }

    #endregion

    #region 描画範囲の設定をする関数

    /// <summary>
    /// 現在のプロファイルから描画範囲の上限、下限値を設定　描画範囲は変更しない
    /// </summary>
    public void SetDrawRangeLimit()
    {
        if (dataSet.DataTableProfile.Items.Count == 0) return;
        double minimalX = double.PositiveInfinity;
        double maximalX = double.NegativeInfinity;
        double minimalY = double.PositiveInfinity;
        double maximalY = double.NegativeInfinity;
        for (int n = 0; n < dataSet.DataTableProfile.Items.Count; n++)
        {
            var diffProf = (DiffractionProfile2)dataSet.DataTableProfile.Items[n];
            if (diffProf.Profile.Pt.Count > 2)
            {
                if (minimalX > diffProf.Profile.Pt[0].X)
                    minimalX = diffProf.Profile.Pt[0].X;
                if (maximalX < diffProf.Profile.Pt[^1].X)
                    maximalX = diffProf.Profile.Pt[^1].X;
                for (int i = 0; i < diffProf.Profile.Pt.Count; i++)
                {
                    minimalY = Math.Min(minimalY, diffProf.Profile.Pt[i].Y + n * IntervalOfProfiles);
                    maximalY = Math.Max(maximalY, diffProf.Profile.Pt[i].Y + n * IntervalOfProfiles);
                }
            }
        }
        if (double.IsInfinity(MinimalX)) return;

        if (minimalX < 0)
            minimalX = 0;

        MinimalX = minimalX;//MinimalXが直近のMaximalXより大きかった場合、正常に更新できない。そのため、2行下でもう一回更新。
        MaximalX = maximalX;
        MinimalX = minimalX;//2行上のコメント参照
        MinimalY = Math.Min(0, minimalY);
        MaximalY = maximalY * 1.1;
    }

    /// <summary>
    /// 描画範囲をMaximal,Minimalに設定する
    /// </summary>
    public void ResetDrawRange()
    {
        IsSkipTextBoxChange = true;
        numericBoxLowerX.Value = numericBoxLowerX.Minimum;
        numericBoxLowerY.Value = numericBoxLowerY.Minimum;
        numericBoxUpperX.Value = numericBoxUpperX.Maximum;
        numericBoxUpperY.Value = numericBoxUpperY.Maximum;
        IsSkipTextBoxChange = false;
    }


    /// <summary>
    /// numetricUpDownによって描画範囲が変更されたときに呼ばれる
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numericBox_ValueChanged(object sender, EventArgs e)
    {
        if (IsSkipTextBoxChange) return;

        if (numericBoxLowerX.Value >= numericBoxUpperX.Value || numericBoxLowerY.Value >= numericBoxUpperY.Value)
        {
            string name = ((NumericBox)sender).Name;
            if (name.Contains("LowerX") && numericBoxLowerX.Value >= numericBoxUpperX.Value)
                numericBoxLowerX.Value = Math.Max(numericBoxLowerX.Minimum, numericBoxUpperX.Value - numericBoxUpperX.MinimalStep);

            if (name.Contains("UpperX") && numericBoxLowerX.Value >= numericBoxUpperX.Value)
                numericBoxUpperX.Value = Math.Min(numericBoxUpperX.Maximum, numericBoxLowerX.Value + numericBoxLowerX.MinimalStep);

            if (name.Contains("LowerY") && numericBoxLowerY.Value >= numericBoxUpperY.Value)
                numericBoxLowerY.Value = Math.Max(numericBoxLowerY.Minimum, numericBoxUpperY.Value - numericBoxUpperY.MinimalStep);

            if (name.Contains("UpperY") && numericBoxLowerY.Value >= numericBoxUpperY.Value)
                numericBoxUpperY.Value = Math.Min(numericBoxUpperY.Maximum, numericBoxLowerY.Value + numericBoxLowerY.MinimalStep);

            return;
        }

        Draw();
    }

    /// <summary>
    /// numetricUpDownの上限/下限値が手動で変更(contextMenu)したとき、呼ばれる
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numericBoxUpperX_LimitChanged(object sender, EventArgs e)
    {
        InitializeCrystalPlane();
    }
    #endregion

    #region 描画関係の関数
    //メインウィンドウ全体の描画

    public void Draw(object sender, System.EventArgs e)
    {
        Draw();
    }

    public bool SkipDrawing = false;

    public void Draw()
    {
        if (SkipDrawing)
            return;
        if (pictureBoxMain.Width <= 0 || pictureBoxMain.Height <= 0) return;
        BmpMain = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
        gMain = Graphics.FromImage(BmpMain);
        gMain.Clear(colorControlBack.Color);
        gMain.SmoothingMode = SmoothingMode.AntiAlias;
        this.DoubleBuffered = true;

        DrawPictureBoxes();
    }

    //プリント描画
    public void DrawPrint(ref System.Drawing.Printing.PrintPageEventArgs e)
    {
        if (pictureBoxMain.Width <= 0 || pictureBoxMain.Height <= 0)
        {
            e.Cancel = true;
            return;
        }

        var formPrintOption = new FormPrintOption();

        if (formPrintOption.ShowDialog() == DialogResult.OK)
        {
            gMain = e.Graphics;
            gMain.Clear(colorControlBack.Color);

            DrawGradiation();
            if (formPrintOption.checkBoxPrintProfile.Checked)
            {
                DrawProfile();
                DrawProfile_Bg();
                if (formPrintOption.checkBoxPrintProfileName.Checked)
                {
                    var font = new Font("Tahoma", 8);
                    //まず字の最大長さ(pixel)を求める
                    var maxSizeF = new SizeF(0, 0);
                    for (int i = dataSet.DataTableProfile.CheckedItems.Count - 1; i >= 0; i--)
                    {
                        maxSizeF.Width = Math.Max(maxSizeF.Width, gMain.MeasureString(dataSet.DataTableProfile.CheckedItems[i].ToString(), font).Width);
                        maxSizeF.Height = Math.Max(maxSizeF.Height, gMain.MeasureString(dataSet.DataTableProfile.CheckedItems[i].ToString(), font).Height);
                    }
                    var startPosition = new PointF(0, 0);
                    if (formPrintOption.radioButtonLowerLeft.Checked)
                        startPosition = new PointF(5 + OriginPos.X, BmpMain.Height - OriginPos.Y - maxSizeF.Height * dataSet.DataTableProfile.CheckedItems.Count);
                    else if (formPrintOption.radioButtonLowerRight.Checked)
                        startPosition = new PointF(BmpMain.Width - maxSizeF.Width - 1, BmpMain.Height - OriginPos.Y - maxSizeF.Height * dataSet.DataTableProfile.CheckedItems.Count);

                    else if (formPrintOption.radioButtonUpperLeft.Checked)
                        startPosition = new PointF(5 + OriginPos.X, 5);

                    else if (formPrintOption.radioButtonUpperRight.Checked)
                        startPosition = new PointF(BmpMain.Width - maxSizeF.Width - 1, 5);

                    for (int i = dataSet.DataTableProfile.CheckedItems.Count - 1; i >= 0; i--)
                    {
                        gMain.DrawString(dataSet.DataTableProfile.CheckedItems[i].ToString(),
                            font, new SolidBrush(Color.FromArgb(((DiffractionProfile2)dataSet.DataTableProfile.CheckedItems[i]).ColorARGB.Value)),
                            new PointF(startPosition.X, startPosition.Y + (dataSet.DataTableProfile.CheckedItems.Count - 1 - i) * maxSizeF.Height));
                    }
                }
            }
            if (formPrintOption.checkBoxPrintDiffractionPeak.Checked)
            {
                DrawProfile_diffraction();//各種ピーク位置描画
                DrawProfile_Fitting();//フィッティング
            }
        }
        else
        {
            e.Cancel = true;
            return;
        }
    }

    //MetaFileに描画
    public void DrawMetafile(Metafile mf)
    {
        if (pictureBoxMain.Width <= 0 || pictureBoxMain.Height <= 0) return;
        gMain = Graphics.FromImage(mf);
        //gMain.Clear(colorControlBack.Color);
        //gMain.SmoothingMode = SmoothingMode.AntiAlias;
        //this.DoubleBuffered = true;
        gMain.FillRectangle(new SolidBrush(colorControlBack.Color), new Rectangle(0, 0, pictureBoxMain.Width, pictureBoxMain.Height));
        //gMain.Clear(colorControlBack.Color);
        DrawPictureBoxes();
        gMain.Dispose();
    }

    //ピクチャーボックスの描画
    private void DrawPictureBoxes()
    {

        DrawUnrolledImage();
        DrawGradiation();//目盛りの描画
        DrawMaskedRange();
        DrawProfile();//オリジナルプロファイル
        DrawProfile_Bg();//バックグラウンド描画
        DrawProfile_diffraction();//各種ピーク位置描画
        DrawProfile_Fitting();//フィッティング

        pictureBoxMain.Image = BmpMain;
    }

    private unsafe void DrawUnrolledImage()
    {
        if (checkBoxShowUnrolledImage.Checked)
            if (bindingSourceProfile.Position > -1 && dataSet.DataTableProfile.GetItemChecked(bindingSourceProfile.Position))
            {
                DiffractionProfile2 dif = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1];
                if (dif.ImageArray != null)
                {
                    var bmp = new Bitmap(pictureBoxMain.Width - OriginPos.X, pictureBoxMain.Height - OriginPos.Y, PixelFormat.Format24bppRgb);

                    //bmpをロック
                    BitmapData bmpData;
                    try { bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); }
                    catch { return; }
                    int width = bmp.Width;
                    int height = bmp.Height;
                    byte* p = (byte*)(void*)bmpData.Scan0;
                    int nResidual = bmpData.Stride - bmp.Width * 3;

                    double endX = dif.Profile.Pt[^1].X;
                    double startX = dif.Profile.Pt[0].X;
                    bool negative = comboBoxGradient.SelectedIndex == 1;
                    double maxInt = (double)numericUpDownMaxInt.Value;
                    double minInt = (double)numericUpDownMinInt.Value;

                    for (int h = 0; h < height; h++)
                    {
                        int y = (int)((double)dif.ImageHeight * (double)h / (double)height);
                        for (int w = 0; w < width; w++)
                        {

                            double realX = LowerX + (double)w / (double)width * (UpperX - LowerX);
                            int x = (int)(dif.ImageWidth * (realX - startX) / (endX - startX) + 0.5);
                            if (x >= 0 && x < dif.ImageWidth)
                            {
                                int index =
                                (int)((dif.ImageArray[x + y * dif.ImageWidth] - minInt) / (maxInt - minInt) * 65535 + 0.5);
                                if (index > 65535) index = 65535;
                                if (index < 0) index = 0;
                                if (negative) index = 65535 - index;

                                (p[0], p[1], p[2]) = scale[index];
                            }
                            p += 3;
                        }
                        p += nResidual;
                    }
                    bmp.UnlockBits(bmpData);
                    gMain.DrawImage(bmp, OriginPos.X, 0);
                }
            }
    }

    private void DrawMaskedRange()
    {
        if (bindingSourceProfile.Position >= 0 && MaskingMode && formProfile.Visible && formProfile.checkBoxShowMaskedRange.Checked)
        {
            var ranges = formProfile.GetMaskRanges();
            if (ranges == null) return;
            int startIndex = 0, endIndex = 0;
            for (int i = 0; i < ranges.Length; i++)
            {
                Brush b = formProfile.SelectedMaskIndex == i ? new SolidBrush(Color.FromArgb(224, Color.Pink)) : new SolidBrush(Color.FromArgb(128, Color.Pink));
                Pen pen = formProfile.SelectedMaskIndex == i ? new Pen(Color.Purple, 2) : pen = new Pen(Color.Purple, 1);
                pen.LineJoin = LineJoin.Round;

                float zero;//描画範囲の最低強度位置のピクセル
                if (formCrystal.checkBoxShowPeakUnderProfile.Checked)
                    zero = pictureBoxMain.Height - OriginPos.Y - dataSet.DataTableCrystal.CheckedItems.Count * (HeightOfBottomPeaks + 4);
                else
                    zero = pictureBoxMain.Height - OriginPos.Y;

                float top = ConvToPicBoxCoord(0, UpperY).Y;

                double startX = ConvToPicBoxCoord(ranges[i].Minimum, 0).X;
                double endX = ConvToPicBoxCoord(ranges[i].Maximum, 0).X;
                if (startX > OriginPos.X)
                    gMain.DrawLine(pen, startX, top, startX, zero);
                if (endX > OriginPos.X)
                    gMain.DrawLine(pen, endX, top, endX, zero);
                gMain.FillRectangle(b, Math.Max(startX, OriginPos.X), top, endX - Math.Max(startX, OriginPos.X), zero - top);

                var dp = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1];
                var original = new List<PointF>();
                float basePosition = bindingSourceProfile.Position * IntervalOfProfiles;
                for (int j = endIndex; j < dp.ConvertedProfile.Pt.Count && dp.ConvertedProfile.Pt[j].X < ranges[i].Maximum; j++)
                {
                    startIndex = j;
                    if (dp.Profile.Pt[j].X > ranges[i].Minimum)
                        for (; j < dp.ConvertedProfile.Pt.Count && dp.ConvertedProfile.Pt[j].X < ranges[i].Maximum; j++)
                        {
                            original.Add(ConvToPicBoxCoord(dp.ConvertedProfile.Pt[j].X, dp.ConvertedProfile.Pt[j].Y + basePosition));
                            endIndex = j;
                        }
                }
                startIndex--; endIndex++;
                b = formProfile.SelectedMaskIndex == i ? new SolidBrush(Color.FromArgb(128, Color.Pink)) : new SolidBrush(Color.FromArgb(64, Color.Pink));
                startX = ConvToPicBoxCoord(dp.Profile.Pt[Math.Max(startIndex - dp.InterpolationPoints, 0)].X, 0).X;
                endX = ConvToPicBoxCoord(dp.Profile.Pt[startIndex].X, 0).X;
                gMain.FillRectangle(b, Math.Max(startX, OriginPos.X), top, endX - Math.Max(startX, OriginPos.X), zero - top);

                startX = ConvToPicBoxCoord(dp.Profile.Pt[endIndex].X, 0).X;
                endX = ConvToPicBoxCoord(dp.Profile.Pt[Math.Min(endIndex + dp.InterpolationPoints, dp.Profile.Pt.Count - 1)].X, 0).X;
                gMain.FillRectangle(b, Math.Max(startX, OriginPos.X), top, endX - Math.Max(startX, OriginPos.X), zero - top);


                pen = new Pen(Color.FromArgb(128, Color.FromArgb((int)dp.ColorARGB)), 1) { DashStyle = DashStyle.Dash };
                if (original.Count > 1)
                    gMain.DrawLines(pen, original.ToArray());
            }
        }

    }

    readonly object lockObj = new();
    //プロファイルの描画
    private void DrawProfile()
    {
        var rect = new RectangleD(LowerX, LowerY, UpperX - LowerX, UpperY - LowerY);
        var profiles = new List<(Pen pen, PointF[] points)>();

        Parallel.For(0, dataSet.DataTableProfile.CheckedItems.Count, j =>
        {
            var dp = dataSet.DataTableProfile.CheckedItems[j];
            var srcPts = dp.Profile.Pt.Select(p => new PointD(p.X, p.Y + IntervalOfProfiles * j)).ToArray();
            if (srcPts.Length > 2)
            {
                var pen = new Pen(Color.FromArgb(dp.ColorARGB.Value), dp.LineWidth) { LineJoin = LineJoin.Round };

                foreach (var trimmedPts in Geometry.GetPointsWithinRectangle(srcPts, rect).Where(pts => pts.Length > 1))
                {
                    var finalPts = ConvToPicBoxCoord(trimmedPts);
                    lock (lockObj)
                        profiles.Add((pen, finalPts));
                }

                //エラーバー描画
                if (checkBoxErrorBar.Checked && dp.SourceProfile.Err != null && dp.SourceProfile.Err.Count == dp.Profile.Pt.Count)
                {
                    var penErr = new Pen(Color.FromArgb((int)(pen.Color.R * 0.5), (int)(pen.Color.G * 0.5), (int)(pen.Color.B * 0.5)), pen.Width);
                    var errbarWidth = Math.Abs(ConvToPicBoxCoord(srcPts[0]).X - ConvToPicBoxCoord(srcPts[1]).X) / 4;
                    for (int i = 0; i < srcPts.Length; i++)
                        if (!double.IsNaN(dp.SourceProfile.Err[i].Y) && rect.IsInsde(srcPts[i]))
                        {
                            var maxErr = ConvToPicBoxCoord(srcPts[i].X, srcPts[i].Y + dp.SourceProfile.Err[i].Y);
                            var minErr = ConvToPicBoxCoord(srcPts[i].X, srcPts[i].Y - dp.SourceProfile.Err[i].Y);
                            lock (lockObj)
                            {
                                profiles.Add((penErr, new[] { maxErr, minErr }));
                                profiles.Add((penErr, new[] { new PointF(maxErr.X + errbarWidth, maxErr.Y), new PointF(maxErr.X - errbarWidth, maxErr.Y) }));
                                profiles.Add((penErr, new[] { new PointF(minErr.X + errbarWidth, minErr.Y), new PointF(minErr.X - errbarWidth, minErr.Y) }));
                            }
                        }
                }
            }
        });

        profiles.ForEach(p =>
        {
            if (p.points.Length > 2)
                gMain.DrawLines(p.pen, p.points);
        });
    }


    //バックグラウンドとBgControl位置の描画
    private void DrawProfile_Bg()
    {
        float maxX = pictureBoxMain.Width;
        float minX = OriginPos.X;
        float maxY = pictureBoxMain.Height - OriginPos.Y;
        if (formCrystal != null && formCrystal.checkBoxShowPeakUnderProfile.Checked)
            maxY -= ((int)(formCrystal.numericUpDownHeightOfBottomPeak.Value) + 4) * dataSet.DataTableCrystal.CheckedItems.Count;
        float minY = 0;

        if (!ShowBackgroundProfile) return;
        if (BackGroundPointSelectMode)
            gMain.DrawString("Background Control Points Select Mode", new Font("Tahoma", 8), new SolidBrush(Color.Black), new PointF(50, 0));
        if (bindingSourceProfile.Position >= 0 && dataSet.DataTableProfile.GetItemChecked(bindingSourceProfile.Position))
        {
            DiffractionProfile2 dp = (DiffractionProfile2)dataSet.DataTableProfile.Items[bindingSourceProfile.Position];
            if (dp.SubtractBackground && ShowBackgroundProfile)
            {
                var color = Color.FromArgb(dp.ColorARGB.Value);
                var pen = new Pen(Color.FromArgb((255 - (int)((255 - color.R) * 0.5)), (255 - (int)((255 - color.G) * 0.5)), (255 - (int)((255 - color.B) * 0.5))), 1);

                PointD[] pt;
                if (BackGroundPointSelectMode)
                {

                    pt = dp.ConvertSrcToDest(dp.BgPoints);
                    for (int i = 0; i < pt.Length; i++)
                    {
                        PointF p = ConvToPicBoxCoord(pt[i]);
                        if (p.X > minX - 0.1 && p.X < maxX + 0.1 && p.Y > minY - 0.1 && p.Y < maxY + 0.1)//範囲内であれば
                            gMain.FillEllipse(new SolidBrush(color), p.X - 5, p.Y - 5, 10, 10);
                    }
                }
                pt = [.. dp.BackgroundProfile.Pt];
                if (pt.Length > 2)
                    for (int i = 0; i < pt.Length - 1; i++)
                    {
                        gMain.DrawLine(pen, ConvToPicBoxCoord(pt[i]), ConvToPicBoxCoord(pt[i + 1]));
                    }
                for (int i = 0; i < dp.BackgroundProfile.Pt.Count - 1; i++)
                {
                    gMain.DrawLine(pen, ConvToPicBoxCoord(dp.BackgroundProfile.Pt[i].X, dp.BackgroundProfile.Pt[i].Y + dp.Profile.Pt[i].Y),
                        ConvToPicBoxCoord(dp.BackgroundProfile.Pt[i + 1].X, dp.BackgroundProfile.Pt[i + 1].Y + dp.Profile.Pt[i + 1].Y));
                }
            }
        }
    }

    //結晶の計算上のピーク位置の描画
    private void DrawProfile_diffraction()
    {
        Pen pen;

        //チェックしている結晶の描画位置を計算
        foreach (int i in dataSet.DataTableCrystal.CheckedIndices)
        {
            var cry = dataSet.DataTableCrystal.Items[i];
            if (!blinkFlag || !blinkingCrystals.Contains(i))
                if (cry.Plane != null)
                {
                    if (formCrystal.checkBoxVariableRatioOfIntensity.Checked && cry.DiffractionPeakIntensity == -1)//強度変化があって初期化されていないとき
                        cry.DiffractionPeakIntensity = UpperY;

                    var font = new Font("Tahoma", 8);
                    var br = new SolidBrush(Color.FromArgb(cry.Argb));
                    var JustBeforePt = new PointF(-10, -10);
                    int shiftY = 40;
                    for (int j = 0; j < cry.Plane.Count; j++)
                    {
                        cry.Plane[j].XCalc = HorizontalAxisConverter.ConvertFromD(cry.Plane[j].d, HorizontalAxisProperty);

                        if (cry.Plane[j].XCalc > LowerX && cry.Plane[j].XCalc < UpperX)
                        {
                            //ここから線の部分
                            pen = i == bindingSourceCrystal.Position ?
                                 new Pen(Color.FromArgb(cry.Argb), j == SelectedPlaneIndex ? 5f : 3f) :
                                 new Pen(Color.FromArgb(cry.Argb), 1f);

                            if (!double.IsNaN(cry.Plane[j].XCalc))
                            {
                                if (!formCrystal.checkBoxInvisibleWeakPeak.Checked || (double)formCrystal.numericUpDownThresholdIntesity.Value * 0.01 < cry.Plane[j].Intensity)
                                {
                                    if (formCrystal.checkBoxShowPeakOverProfiles.Checked)
                                    {
                                        float zero = formCrystal.checkBoxShowPeakUnderProfile.Checked ?//描画範囲の最低強度位置のピクセル
                                            pictureBoxMain.Height - OriginPos.Y - dataSet.DataTableCrystal.CheckedItems.Count * (HeightOfBottomPeaks + 4) :
                                            pictureBoxMain.Height - OriginPos.Y;

                                        float top = 0;
                                        float xPos = ConvToPicBoxCoord(cry.Plane[j].XCalc, 0).X;

                                        if (cry.FlexibleMode)//flexibleCrystal選択時
                                            top = ConvToPicBoxCoord(cry.Plane[j].XCalc, UpperY).Y;
                                        else if (formCrystal.checkBoxCalculateIntensity.Checked && cry.Plane[j].Intensity >= 0)
                                        {
                                            if (formCrystal.checkBoxVariableRatioOfIntensity.Checked)//強度変化があるとき
                                                top = ConvToPicBoxCoord(cry.Plane[j].XCalc, cry.Plane[j].Intensity * cry.DiffractionPeakIntensity).Y;
                                            else //強度変化がない時
                                                top = (float)((1 - cry.Plane[j].Intensity) * zero);
                                        }
                                        else //強度の計算がない時
                                            top = ConvToPicBoxCoord(cry.Plane[j].XCalc, UpperY).Y;

                                        if (top < zero)
                                            gMain.DrawLine(pen, xPos, zero, xPos, top);

                                        //字の部分
                                        if (bindingSourceCrystal.Position != 0 && formCrystal.checkBoxShowPeakIndices.Checked && (formCrystal.radioButtonAllCheckedCrystals.Checked || i == bindingSourceCrystal.Position))
                                        {
                                            if (!formCrystal.checkBoxInvisibleWeakPeak.Checked || (double)formCrystal.numericUpDownThresholdIntesity.Value * 0.01 < cry.Plane[j].Intensity)
                                            {
                                                var pt = new PointF(xPos, top);
                                                if (pt.Y < 0)
                                                    pt.Y = 0;
                                                if (pt.X - JustBeforePt.X < 6 && pt.Y - JustBeforePt.Y < 20 && pt.Y - JustBeforePt.Y > -40)//字がかぶらないようにするための措置
                                                {
                                                    pt.Y += shiftY;
                                                    shiftY += 40;
                                                }
                                                else
                                                    shiftY = 40;
                                                if (cry.Plane[j].strHKL != null)
                                                {
                                                    if (pt.Y + cry.Plane[j].strHKL.Length * 5.5 > pictureBoxMain.Height - OriginPos.Y)
                                                        pt.Y = pictureBoxMain.Height - OriginPos.Y - cry.Plane[j].strHKL.Length * 5.5f;

                                                    gMain.DrawString(cry.Plane[j].strHKL, font, br, pt, new StringFormat(StringFormatFlags.DirectionVertical));
                                                }
                                                JustBeforePt = pt;
                                            }
                                        }
                                    }
                                }

                                if (formCrystal.checkBoxShowPeakUnderProfile.Checked)
                                {
                                    int n = dataSet.DataTableCrystal.ConvertRawIndexToCheckedIndex(i);
                                    gMain.DrawLine(pen,
                                        ConvToPicBoxCoord(cry.Plane[j].XCalc, 0).X, pictureBoxMain.Height - (HeightOfBottomPeaks + 4) * n - 1 - OriginPos.Y,
                                        ConvToPicBoxCoord(cry.Plane[j].XCalc, 0).X, pictureBoxMain.Height - (HeightOfBottomPeaks + 4) * (n + 1) + 3 - OriginPos.Y);
                                }
                            }
                        }
                    }
                }

        }
    }

    //フィッティング曲線の描画
    private void DrawProfile_Fitting()
    {
        if ((ShowBackgroundProfile && BackGroundPointSelectMode)
            || bindingSourceCrystal.Position < 0 || bindingSourceProfile.Position < 0
            || !dataSet.DataTableProfile.GetItemChecked(bindingSourceProfile.Position)
            || !toolStripButtonFittingParameter.Checked)
            return;
        double step = ConvToRealCoord(1, 0).X - ConvToRealCoord(0, 0).X;

        //現在のフィッティング対象のプロファイルを探して下駄を計算する
        float basePosition = dataSet.DataTableProfile.ConvertRawIndexToCheckedIndex(bindingSourceProfile.Position) * IntervalOfProfiles;
        if (basePosition < 0) return;

        var dp = (DiffractionProfile2)dataSet.DataTableProfile.Rows[bindingSourceProfile.Position][1];

        var color = Color.FromArgb(dp.ColorARGB.Value);
        var penSubtraction = new Pen(Color.FromArgb((255 - (int)((255 - color.R) * 0.3)), (255 - (int)((255 - color.G) * 0.3)), (255 - (int)((255 - color.B) * 0.3))), dp.LineWidth);
        penSubtraction.LineJoin = LineJoin.Round;


        var planeList = new List<Plane>();

        //先ず、fittigチェックの結晶面を探す。
        for (int c = 0; c < dataSet.DataTableCrystal.CheckedItems.Count; c++)
            planeList.AddRange(dataSet.DataTableCrystal.CheckedItems[c].Plane.Where(p => p.IsFittingChecked).ToArray());

        //simpleモードのものだけ抜き出して、描画
        foreach (Plane p in planeList.Where(p => p.SerchOption == PeakFunctionForm.Simple && !p.simpleParameter.IsNaN && !double.IsNaN(p.simpleParameter.X)))
        {
            PointF pt = ConvToPicBoxCoord(p.simpleParameter.X, p.simpleParameter.Y + basePosition);
            gMain.FillEllipse(new SolidBrush(p.peakFunction.Color), pt.X - 4, pt.Y - 8, 8, 8);
        }

        //シンプルモードじゃないやつを抜き出す
        Plane[] planeList2 = planeList.Where(p => p.SerchOption != PeakFunctionForm.Simple).ToArray();
        if (planeList2.Length == 0)
            return;

        for (int i = 0; i < planeList2.Length; i++)
            planeList2[i].peakFunction.RenewParameter();

        try
        {
            //グループごとに描画
            for (int i = planeList2.Min(p => p.peakFunction.GroupIndex); i < planeList2.Max(p => p.peakFunction.GroupIndex) + 1; i++)
            {
                //i番目のグループを抜き出す。
                Plane[] planeList3 = planeList.Where(p => p.peakFunction.GroupIndex == i).ToArray();

                if (planeList3.Length != 0)
                {
                    //まず、バックグラウンドと、減算プロファイルを描く
                    var subtraction = new List<PointF>();
                    var background = new List<PointF>();
                    double minX = Math.Max(planeList3.Min(p => p.XCalc - p.SerchRange * formFitting.SerchRangeFactor), ConvToRealCoord(OriginPos.X, 0).X);
                    double maxX = Math.Min(planeList3.Max(p => p.XCalc + p.SerchRange * formFitting.SerchRangeFactor), ConvToRealCoord(pictureBoxMain.Width, 0).X);

                    for (int k = 0; k < dp.Profile.Pt.Count && dp.Profile.Pt[k].X < maxX; k++)
                        if (dp.Profile.Pt[k].X > minX)
                        {
                            if (!double.IsNaN(planeList3[0].peakFunction.X))
                                background.Add(ConvToPicBoxCoord(dp.Profile.Pt[k].X, planeList3[0].peakFunction.B1 + planeList3[0].peakFunction.B2 * (dp.Profile.Pt[k].X - planeList3[0].peakFunction.X) + basePosition));

                            double y = 0;
                            for (int j = 0; j < planeList3.Length; j++)
                                y += planeList3[j].peakFunction.GetValue(dp.Profile.Pt[k].X, false);
                            if (!double.IsNaN(y))
                                subtraction.Add(ConvToPicBoxCoord(dp.Profile.Pt[k].X, dp.Profile.Pt[k].Y - y + basePosition));
                        }

                    if (subtraction.Count > 1)
                        gMain.DrawLines(penSubtraction, subtraction.ToArray());

                    if (background.Count > 1)
                        gMain.DrawLines(penSubtraction, background.ToArray());

                    //個々のフィッティングカーブを描く
                    foreach (Plane p in planeList3)
                    {
                        var penPeak = new Pen(p.peakFunction.Color, 2f);
                        var peaks = new List<PointF>();
                        var startTheta = Math.Max(p.XCalc - p.SerchRange * formFitting.SerchRangeFactor, ConvToRealCoord(OriginPos.X, 0).X);
                        var endTheta = Math.Min(p.XCalc + p.SerchRange * formFitting.SerchRangeFactor, ConvToRealCoord(pictureBoxMain.Width, 0).X);
                        if (ConvToPicBoxCoord(startTheta, 0).X < pictureBoxMain.Width || ConvToPicBoxCoord(endTheta, 0).X > 0)
                        {
                            if (p.peakFunction.Hk != 0 && !double.IsNaN(p.peakFunction.X))
                            {
                                for (double k = startTheta; k < endTheta; k += step)
                                    peaks.Add(ConvToPicBoxCoord(k, p.peakFunction.GetValue(k, false) + p.peakFunction.B1 + p.peakFunction.B2 * (k - p.peakFunction.X) + basePosition));
                                if (peaks.Count > 1)
                                    gMain.DrawLines(penPeak, peaks.ToArray());
                            }
                        }
                    }
                }
            }
        }
        catch { }
    }

    //目盛りを描画する部分
    private void DrawGradiation()
    {
        if (UpperX - LowerX <= 0) return;

        double AngleGradiation = 1;//ここより角度目盛りの描画
        double d = (UpperX - LowerX);
        int maxDivisionNumber = (pictureBoxMain.Width) / (d > 0.1 ? 40 : 60) + 1;
        if (maxDivisionNumber < 1 || double.IsNaN(maxDivisionNumber)) return;
        double unit = Math.Pow(10, Math.Floor(Math.Log10(d / maxDivisionNumber)));

        if (d / unit < maxDivisionNumber) AngleGradiation = unit;
        else if (d / unit / 2 < maxDivisionNumber) AngleGradiation = unit * 2;
        else if (d / unit / 5 < maxDivisionNumber) AngleGradiation = unit * 5;
        else AngleGradiation = unit * 10;

        string format = "0.";
        int decimalPlaces = AngleGradiation >= 1 ? 0 : Math.Abs((int)Math.Floor((Math.Log10(AngleGradiation))));
        for (int i = 0; i < decimalPlaces; i++) format += "0";


        var pen = new Pen(colorControlScaleLine.Color, 1);

        gMain.DrawLine(pen, OriginPos.X, pictureBoxMain.Height - OriginPos.Y, pictureBoxMain.Width, pictureBoxMain.Height - OriginPos.Y);
        using Font strFont = new(new FontFamily("tahoma"), 8);
        for (int i = (int)(LowerX / AngleGradiation) + 1; i < UpperX / AngleGradiation; i++)
        {
            pen = new Pen(colorControlScaleLine.Color, 1);
            float x = ConvToPicBoxCoord(i * AngleGradiation, 0).X;
            if (x > pictureBoxMain.Width || x < 0) break;
            gMain.DrawLine(pen, x, pictureBoxMain.Height - OriginPos.Y, x, pictureBoxMain.Height - OriginPos.Y + 5);
            if (i * AngleGradiation > 1000)
                format = "#," + format;
            gMain.DrawString(Math.Round(i * AngleGradiation, 5).ToString(format), strFont, new SolidBrush(colorControlScaleText.Color), x - 2, pictureBoxMain.Height - OriginPos.Y + 5);
            pen = new Pen(colorControlScaleLine.Color, 1);
            if (checkBoxShowScaleLine.Checked)
                gMain.DrawLine(pen, ConvToPicBoxCoord(i * AngleGradiation, 0).X, pictureBoxMain.Height - OriginPos.Y, x, 0);
        }

        double IntensityGradiation = 1;//ここより強度目盛りの描画

        d = (UpperY - LowerY);
        maxDivisionNumber = (pictureBoxMain.Height - 20) / 30 + 1;
        if (maxDivisionNumber < 1 || double.IsNaN(maxDivisionNumber)) return;
        unit = Math.Pow(10, Math.Floor(Math.Log10(d / maxDivisionNumber)));

        if (d / unit < maxDivisionNumber) IntensityGradiation = unit;
        else if (d / unit / 2 < maxDivisionNumber) IntensityGradiation = unit * 2;
        else if (d / unit / 5 < maxDivisionNumber) IntensityGradiation = unit * 5;
        else IntensityGradiation = unit * 10;

        if (double.IsInfinity(IntensityGradiation)) return;

        decimalPlaces = IntensityGradiation >= 1 ? 0 : Math.Abs((int)Math.Floor((Math.Log10(IntensityGradiation))));
        format = "0.";
        for (int i = 0; i < decimalPlaces; i++) format += "0";

        pen = new Pen(colorControlScaleLine.Color, 1);
        gMain.DrawLine(pen, OriginPos.X, 0, OriginPos.X, pictureBoxMain.Height - OriginPos.Y);

        for (int i = (int)(LowerY / IntensityGradiation) + 1; i < UpperY / IntensityGradiation; i++)
        {
            pen = new Pen(colorControlScaleLine.Color, 1);
            float y = ConvToPicBoxCoord(0, i * IntensityGradiation).Y;
            if (y > pictureBoxMain.Height || y < 0) break;
            gMain.DrawLine(pen, OriginPos.X - 8, y, OriginPos.X, y);
            if (i * IntensityGradiation > 1000)
                format = "#," + format;
            gMain.DrawString((i * IntensityGradiation).ToString(format), strFont, new SolidBrush(colorControlScaleText.Color), 0, y - 6);
            pen = new Pen(colorControlScaleLine.Color, 1);
            if (checkBoxShowScaleLine.Checked)
                gMain.DrawLine(pen, OriginPos.X - 8, y, pictureBoxMain.Width, y);
        }
    }
    #endregion

    #region 各結晶の描画範囲内の回折線の位置計算

    //各結晶の描画範囲内の回折線の位置計算
    public void InitializeCrystalPlane()
    {
        //nm単位
        double dMin = 1, dMax = 1;

        var val1 = HorizontalAxisConverter.ConvertToD(MinimalX, HorizontalAxisProperty);
        var val2 = HorizontalAxisConverter.ConvertToD(MaximalX, HorizontalAxisProperty);

        dMin = Math.Min(val1, val2);
        dMin = Math.Max(dMin, 0.01);

        dMax = Math.Max(val1, val2);
        if (dMax < 0)
            dMax = 1000;

        for (int i = 1; i < dataSet.DataTableCrystal.Items.Count; i++)
        {
            if (dataSet.DataTableCrystal.GetItemChecked(i))
            {
                Crystal cry = dataSet.DataTableCrystal.Items[i];

                if (formCrystal.radioButtonAngleThreshold.Checked)
                    cry.SetPlanes(dMax, dMin, true, true, false, formCrystal.checkBoxCombineSameDspacingPeaks.Checked, HorizontalAxis.Angle,
                        (double)formCrystal.numericUpDownAngleThreshold.Value / 180 * Math.PI, horizontalAxisUserControl.WaveLength);
                else if (formCrystal.radioButtonEnergyThreshold.Checked)
                    cry.SetPlanes(dMax, dMin, true, true, false, formCrystal.checkBoxCombineSameDspacingPeaks.Checked, HorizontalAxis.EnergyXray,
                       (double)formCrystal.numericUpDownEnergyThreshold.Value, horizontalAxisUserControl.TakeoffAngle);

                if (formCrystal.checkBoxVariableRatioOfIntensity.Checked == false)
                    cry.DiffractionPeakIntensity = UpperY;
                cry.SetPeakIntensity(WaveSource, WaveColor, WaveLength, null);
            }
        }
    }

    #endregion

    #region 座標変換関数
    private PointF ConvToPicBoxCoord(double x, double y)
    {//プロファイル座標をピクチャーボックスの座標系に変換
        return new PointF(
            (float)((pictureBoxMain.Width - OriginPos.X) / (UpperX - LowerX) * (x - LowerX)) + OriginPos.X,
            (float)(pictureBoxMain.Height - OriginPos.Y - BottomMargin - (pictureBoxMain.Height - OriginPos.Y - BottomMargin) * (y - LowerY) / (UpperY - LowerY)));
    }
    private PointF ConvToPicBoxCoord(PointD p)
    {//プロファイル座標をピクチャーボックスの座標系に変換
        return new PointF(
            (float)((pictureBoxMain.Width - OriginPos.X) / (UpperX - LowerX) * (p.X - LowerX)) + OriginPos.X,
            (float)((pictureBoxMain.Height - OriginPos.Y - BottomMargin) * (1 - (p.Y - LowerY) / (UpperY - LowerY))));
    }
    private PointF[] ConvToPicBoxCoord(PointD[] p)
    {//プロファイル座標をピクチャーボックスの座標系に変換 (配列から配列へ)
        var coeffX1 = (pictureBoxMain.Width - OriginPos.X) / (UpperX - LowerX);
        var coeffX2 = -coeffX1 * LowerX + OriginPos.X;
        var coeffY1 = pictureBoxMain.Height - OriginPos.Y - BottomMargin;
        var coeffY2 = -coeffY1 / (UpperY - LowerY);
        var coeffY3 = coeffY1 - coeffY2 * LowerY;
        return p.Select(e => new PointF((float)(coeffX1 * e.X + coeffX2), (float)(coeffY3 + coeffY2 * e.Y))).ToArray();
    }


    private PointD ConvToRealCoord(int x, int y)
    {//ピクチャーボックスの座標系をプロファイル座標に変換
        return new PointD(
            (double)(x - OriginPos.X) / (pictureBoxMain.Width - OriginPos.X) * (UpperX - LowerX) + LowerX,
            (double)(pictureBoxMain.Height - y - OriginPos.Y - BottomMargin) / (pictureBoxMain.Height - OriginPos.Y - BottomMargin) * (UpperY - LowerY) + LowerY);
    }
    /// <summary>
    /// プロファイル座標の横軸をd値(nm)に変換( 縦軸はそのまま)
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public PointD ConvToDspacing(PointD pt)
    {
        //if (AxisMode == HorizontalAxis.Angle)
        //    pt.X = WaveLength / 2 / Math.Sin(pt.X / 360 * Math.PI);
        //else if (AxisMode == HorizontalAxis.EnergyXray)
        //    pt.X = HorizontalAxisConverter.XrayEnergyToD(pt.X, TakeoffAngle);
        //else if (AxisMode == HorizontalAxis.NeutronTOF)
        //    pt.X = HorizontalAxisConverter.NeutronTofToD(pt.X, TofAngle, TofLength);
        //else if (AxisMode == HorizontalAxis.d)
        //    pt.X = pt.X / 10;

        pt.X = HorizontalAxisConverter.ConvertToD(pt.X, HorizontalAxisProperty);
        return pt;
    }

    #endregion

    #region マウス操作
    //マウスボタンが押されたとき
    private void pictureBoxMain_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        pictureBoxMain.Focus();
        var pt = ConvToRealCoord(e.X, e.Y);

        #region Bg点モード
        if (ShowBackgroundProfile && BackGroundPointSelectMode && formProfile.Visible)//Bg点モードのとき
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && bindingSourceProfile.Position >= 0)
            {//左ダブルクリックのときはBg点追加
                DiffractionProfile2 dp = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1];
                dp.AddBgPoints(pt);
                dp.SetBackGroundProfile();
                Draw();
            }
            else if (e.Button == MouseButtons.Left && e.Clicks == 1 && bindingSourceProfile.Position >= 0)
            { //左シングルクリックのときBg点選択
                DiffractionProfile2 dp = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1];
                double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
                int i = SearchPt(new PointD(e.X, e.Y), dp.ConvertSrcToDest(dp.BgPoints), 3);
                if (i >= 0)
                {
                    SelectedBgPtIndex = i;
                    IsBgPtSelected = true;
                    return;
                }
            }
            else if (e.Button == MouseButtons.Right && e.Clicks == 1 && bindingSourceProfile.Position >= 0)
            {//右シングルでかつバックグラウンド設定モードのとき
                DiffractionProfile2 dp = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1];
                int i = SearchPt(new PointD(e.X, e.Y), dp.ConvertSrcToDest(dp.BgPoints), 5);
                if (i >= 0)
                {
                    dp.DeleteBgPoints(i);
                    dp.SetBackGroundProfile();
                    Draw();
                    return;
                }
            }
        }//Bg点モード終了
        #endregion

        //Diffractionモード
        else if (e.Button == MouseButtons.Left && e.Clicks == 1 && SelectedCrystalIndex > 0)
        {
            var cry = (Crystal)((DataRowView)bindingSourceCrystal.Current).Row[1];
            int i;
            double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
            if (formCrystal.checkBoxCalculateIntensity.Checked && cry.Plane != null && cry.Plane.Count > 0 && cry.Plane[0].Intensity > 0)
                i = SearchPlaneNo(pt.X, pt.Y, cry, dev);//強度計算している場合
            else
                i = SearchPlaneNo(pt.X, cry, dev);//強度計算していない場合
            if (i >= 0)
            {
                SelectedPlaneIndex = i;
                IsPlaneSelected = true;
                if (formFitting.Visible)
                    formFitting.SelectedPlaneIndex = i;
                Draw();
                return;
            }
        }
        else if (SelectedCrystalIndex == 0 && dataSet.DataTableCrystal.GetItemChecked(0))//flexibleCrystalを選択時
        {
            var cry = (Crystal)((DataRowView)bindingSourceCrystal.Current).Row[1];
            if (e.Button == MouseButtons.Left && e.Clicks == 1)//選択
            {
                double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
                var i = SearchPlaneNo(pt.X, cry, dev);//強度計算していない場合
                if (i >= 0)
                {
                    SelectedPlaneIndex = i;
                    IsPlaneSelected = true;
                    if (formFitting.Visible)
                        formFitting.SelectedPlaneIndex = i;
                    Draw();
                    return;
                }
            }
            //追加.
            if (e.Button == MouseButtons.Left && e.Clicks == 2)//何もないところでダブルクリックした場合
            {
                cry.Plane.Add(new Plane
                {
                    XCalc = pt.X,
                    d = ConvToDspacing(pt).X,
                    Intensity = 1,
                    SerchOption = PeakFunctionForm.PseudoVoigt
                });
                cry.Plane.Sort();

                formFitting.ChangeCrystalFromMainForm();

                var i = SearchPlaneNo(pt.X, cry, 0.0001);//強度計算していない場合
                if (i >= 0)
                {
                    SelectedPlaneIndex = i;
                    IsPlaneSelected = true;
                    if (formFitting.Visible)
                        formFitting.SelectedPlaneIndex = i;
                }

                Draw();
                return;
            }
            //削除
            if (e.Button == MouseButtons.Right & e.Clicks == 1)
            {
                double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
                int i = SearchPlaneNo(pt.X, cry, dev);//強度計算していない場合
                if (i >= 0)
                {
                    cry.Plane.RemoveAt(i);
                    cry.Plane.Sort();
                    formFitting.ChangeCrystalFromMainForm();
                    Draw();
                    return;
                }
            }
            Draw();
        }

      
        if (e.Button == MouseButtons.Right)
        {
            MouseRangingMode = true;
            mouseRangeStart = new Point(e.X, e.Y);
            mouseRangeEnd = new Point(e.X, e.Y);
            return;
        }

        if (MaskingMode && formProfile.Visible && formProfile.checkBoxShowMaskedRange.Checked && e.Button == MouseButtons.Left)
        {
            double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
            int[] i = SearchMaskBoundary(pt.X, formProfile.GetMaskRanges(), dev);//強度計算していない場合
            if (i[0] < 0)
            {
                double x = ConvToRealCoord(e.X, 0).X;
                formProfile.AddMaskRange(new DiffractionProfile2.MaskingRange(x, x));
                formProfile.SortMaskRanges();
                i = SearchMaskBoundary(pt.X, formProfile.GetMaskRanges(), dev);
            }
            if (i[0] >= 0)
                SelectedMaskingBoundaryIndex = i;
            formProfile.SelectedMaskIndex = SelectedMaskingBoundaryIndex[0];
            return;
        }


        if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Left)
        {
            MouseMovingMode = true;
            mouseMovingStartPt = pt;
            pictureBoxMain.Cursor = Cursors.SizeAll;
            return;
        }

    }


    //マウスの右クリックを連打して描画範囲を広げる時のカウンター
    int rightClickCounter = 0;
    readonly Stopwatch rightClickStopWatch = new();

    /// <summary>
    /// マウスボタンがあがったとき
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void pictureBoxMain_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (IsPlaneSelected)
        {
            InitializeCrystalPlane();

            SetFormEOS();
            SetFormCrystal(false);
            formFitting.ChangeCrystalFromMainForm();

            Draw();
        }

        IsPlaneSelected = false;
        IsBgPtSelected = false;
        MouseMovingMode = false;

        if (MaskingMode)
        {
            if (SelectedMaskingBoundaryIndex[0] >= 0)
            {
                var ranges = formProfile.GetMaskRanges();
                if (ranges[SelectedMaskingBoundaryIndex[0]].Maximum == ranges[SelectedMaskingBoundaryIndex[0]].Minimum)
                    formProfile.DeleteMaskRange(SelectedMaskingBoundaryIndex[0]);
            }
            SelectedMaskingBoundaryIndex = [-1, -1];
            Draw();
        }

        if (MouseRangingMode)
        {
            MouseRangingMode = false;
            mouseRangeEnd = new Point(e.X, e.Y);
            if (Math.Abs(mouseRangeEnd.X - mouseRangeStart.X) < 3 || Math.Abs(mouseRangeEnd.Y - mouseRangeStart.Y) < 3)
            {//選択範囲が小さかったら縮小
                double tempLowerX = LowerX, tempUpperX = UpperX, tempLowerY = LowerY, tempUpperY = UpperY;

                LowerX = Math.Max(MinimalX, tempLowerX * 1.5 - tempUpperX * 0.5);
                UpperX = Math.Min(MaximalX, tempUpperX * 1.5 - tempLowerX * 0.5);
                LowerY = Math.Max(MinimalY, (tempLowerY * 1.5 - tempUpperY * 0.5));
                UpperY = Math.Min(MaximalY, (tempUpperY * 1.5 - tempLowerY * 0.5));
                if (LowerY > UpperY)
                {
                    LowerY = tempLowerY - 0.000001;
                    UpperY = tempUpperY + 0.000001;
                }

                if (!formCrystal.checkBoxVariableRatioOfIntensity.Checked)
                    foreach (Crystal crystal in dataSet.DataTableCrystal.CheckedItems)
                        crystal.DiffractionPeakIntensity = UpperY;

                if (LowerX == MinimalX && UpperX == MaximalX && LowerY == MinimalY && UpperY == MaximalY)
                {
                    long elapsedMilliseconds = rightClickStopWatch.ElapsedMilliseconds;
                    rightClickStopWatch.Restart();
                    if (elapsedMilliseconds < 200 && rightClickCounter++ > 3)
                    {
                        rightClickCounter = 0;
                        MaximalX *= 1.2;
                        InitializeCrystalPlane();
                    }
                }

                Draw();
                // SetRangeTextBox();
            }
            else if (Math.Abs(mouseRangeEnd.X - mouseRangeStart.X) < 10 || Math.Abs(mouseRangeEnd.Y - mouseRangeStart.Y) < 10)
            {//選択範囲が中途半端だったら
                MouseRangingMode = false;
                pictureBoxMain.Refresh();
            }
            else //拡大
            {
                var xmax = ConvToRealCoord(Math.Max(mouseRangeStart.X, mouseRangeEnd.X), 1).X;
                var xmin = ConvToRealCoord(Math.Min(mouseRangeStart.X, mouseRangeEnd.X), 1).X;
                var ymin = ConvToRealCoord(1, Math.Max(mouseRangeStart.Y, mouseRangeEnd.Y)).Y;
                var ymax = ConvToRealCoord(1, Math.Min(mouseRangeStart.Y, mouseRangeEnd.Y)).Y;
                if (xmax - xmin < 0.000001 || ymax - ymin < 0.00001) return;
                if (xmax > MaximalX) xmax = MaximalX;
                if (xmin < MinimalX) xmin = MinimalX;
                if (ymax > MaximalY) ymax = MaximalY;
                if (ymin < MinimalY) ymin = MinimalY;

                LowerX = xmin; UpperX = xmax; LowerY = ymin; UpperY = ymax;
                if (!formCrystal.checkBoxVariableRatioOfIntensity.Checked)
                    foreach (Crystal crystal in dataSet.DataTableCrystal.CheckedItems)
                        crystal.DiffractionPeakIntensity = UpperY;
                Draw();
            }
        }

    }

    PointD justBeforePt = new(0, 0);
    private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
    {
        //タブコントロールの表示/非表示設定
        if (splitContainer1.Panel1.Controls.GetChildIndex(tabControl) < splitContainer1.Panel1.Controls.GetChildIndex(pictureBoxMain))
        {
            if (e.X > tabControl.Width + tabControl.Location.X - pictureBoxMain.Location.X ||
               e.X < tabControl.Location.X - pictureBoxMain.Location.X ||
               e.Y > tabControl.Height + tabControl.Location.Y - pictureBoxMain.Location.Y ||
               e.Y < tabControl.Location.Y - pictureBoxMain.Location.Y)
                pictureBoxMain.BringToFront();
        }
        if (splitContainer1.Panel1.Controls.GetChildIndex(tabControl1) < splitContainer1.Panel1.Controls.GetChildIndex(pictureBoxMain))
        {
            if (e.X > tabControl1.Width + tabControl1.Location.X - pictureBoxMain.Location.X ||
                e.X < tabControl1.Location.X - pictureBoxMain.Location.X ||
                e.Y > tabControl1.Height + tabControl1.Location.Y - pictureBoxMain.Location.Y ||
                e.Y < tabControl1.Location.Y - pictureBoxMain.Location.Y)
                pictureBoxMain.BringToFront();
        }

        //マウス位置情報の更新
        PointD pt = ConvToRealCoord(e.X, e.Y);

        

        #region 横軸と縦軸の単位の設定
        labelTwoTheta.Text = AxisMode switch
        {
            HorizontalAxis.Angle => "2θ: ",
            HorizontalAxis.d => "d: ",
            HorizontalAxis.EnergyXray => "Energy: ",
            HorizontalAxis.NeutronTOF => "TOF: ",
            HorizontalAxis.WaveNumber => "q: ",
            _ => ""
        };
        labelTwoTheta.Text += pt.X < 10000 ? pt.X.ToString("g6") : pt.X.ToString("#,0");


        labelTwoTheta.Text += AxisMode switch
        {
            HorizontalAxis.Angle => " " + AxisProperty.TwoThetaUnitText,
            HorizontalAxis.d => " " + AxisProperty.DspacingUnitText,
            HorizontalAxis.EnergyXray => " " + AxisProperty.EnegyUnitText,
            HorizontalAxis.NeutronTOF => " " + AxisProperty.TofTimeUnitText,
            HorizontalAxis.WaveNumber => " " + AxisProperty.WaveNumberUnitText,
            _ => ""
        };
        #endregion

        var d = HorizontalAxisConverter.ConvertToD(pt.X, HorizontalAxisProperty) * 10;

        //var d = AxisMode switch
        //{
        //    HorizontalAxis.Angle => 10 * WaveLength / 2 / Math.Sin(pt.X / 360 * Math.PI),
        //    HorizontalAxis.EnergyXray => 10 * HorizontalAxisConverter.XrayEnergyToD(pt.X, TakeoffAngle),
        //    HorizontalAxis.d => pt.X,
        //    HorizontalAxis.NeutronTOF => 10 * HorizontalAxisConverter.NeutronTofToD(pt.X, TofAngle, TofLength),
        //    HorizontalAxis.WaveNumber => HorizontalAxisConverter.WaveNumberToD(pt.X),
        //    _ => pt.X
        //};

        labelD.Text = $"d: {d:g5} Å";
        labelQ.Text = $"q: {2 * Math.PI / d:g5} Å⁻¹";

        labelIntensity.Text = $"Int: {pt.Y:g6}";

        //Application.DoEvents();

        #region マウスカーソルの設定
        double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
        if (ShowBackgroundProfile && BackGroundPointSelectMode)//bg点選択モードのときは
            pictureBoxMain.Cursor = Cursors.Default;

        else if (MaskingMode && formProfile.Visible && formProfile.checkBoxShowMaskedRange.Checked && bindingSourceProfile.Position >= 0)//MaskRange選択時
        {
            DiffractionProfile2 dp = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1];
            int[] i = SearchMaskBoundary(pt.X, formProfile.GetMaskRanges(), dev);
            if (i[0] >= 0)
                pictureBoxMain.Cursor = Cursors.VSplit;
            else//範囲選択モードのときは
                pictureBoxMain.Cursor = Cursors.Arrow;
        }
        else if (MouseMovingMode)//マウスで移動モードのとき
            pictureBoxMain.Cursor = Cursors.NoMove2D;
        else
        {
            int i = -1;
            if (bindingSourceCrystal.Position > -1)
            {
                Crystal cry = (Crystal)(((DataRowView)bindingSourceCrystal.Current).Row[1]);
                if (formCrystal.checkBoxCalculateIntensity.Checked && cry.Plane != null && cry.Plane.Count > 0 && cry.Plane[0].Intensity > 0)
                    i = SearchPlaneNo(pt.X, pt.Y, cry, dev);//強度計算している場合
                else
                    i = SearchPlaneNo(pt.X, cry, dev);//強度計算していない場合
            }
            if (i >= 0)//面選択モードが可能なときは
                pictureBoxMain.Cursor = Cursors.VSplit;
            else//範囲選択モードのときは
                pictureBoxMain.Cursor = Cursors.Arrow;
        }
        #endregion 

        if (ShowBackgroundProfile && BackGroundPointSelectMode && IsBgPtSelected == true && e.Button == MouseButtons.Left)
        {//Bgモードで、Bg点を選択していて、左ドラッグのとき
            if (bindingSourceProfile.Position >= 0)
            {
                var dp = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1];
                var newBgPoint = dp.ConvertDestToSrc(pt);
                if (!double.IsNaN(newBgPoint.X) && !double.IsInfinity(newBgPoint.X))
                {
                    dp.BgPoints[SelectedBgPtIndex] = newBgPoint;
                    dp.SetBackGroundProfile();
                    Draw();
                }
            }
        }
        else if (!ShowBackgroundProfile || !BackGroundPointSelectMode)
        {
            if (SelectedCrystalIndex == 0 && IsPlaneSelected && e.Button == MouseButtons.Left)//flexibleCrystalのPlane選択モードのとき
            {
                Crystal cry = (Crystal)((DataRowView)bindingSourceCrystal.Current).Row[1];
                cry.Plane[SelectedPlaneIndex].d = HorizontalAxisConverter.ConvertToD(pt.X, HorizontalAxisProperty); //ConvToDspacing(pt).X;
                cry.Plane.Sort();
                Draw();
            }
            else if (IsPlaneSelected && e.Button == MouseButtons.Left)//通常結晶のPlane選択モードのとき
            {
                Crystal cry = (Crystal)((DataRowView)bindingSourceCrystal.Current).Row[1];
                var mag = HorizontalAxisConverter.ConvertToD(pt.X, HorizontalAxisProperty) / cry.Plane[SelectedPlaneIndex].d;
                cry.A *= mag; cry.B *= mag; cry.C *= mag;

                //VariableRatioOfIntensityがTrueのとき
                if (formCrystal.checkBoxVariableRatioOfIntensity.Checked)
                    cry.DiffractionPeakIntensity *= pt.Y / justBeforePt.Y;

                cry.SetAxis();
                cry.SetPlanes();
                SetFormEOS();
                SetFormCrystal(true);
                Draw();
                justBeforePt = pt;

            }
        }

        //範囲選択モードのとき
        if (MouseRangingMode)
        {
            mouseRangeEnd = new Point(e.X, e.Y);
            pictureBoxMain.Refresh();
        }
        //マウスで移動モードのとき
        else if (MouseMovingMode)
        {
            //MouseRangingStartが現在の中心位置に来るように設定を治す
            double devX = -pt.X + mouseMovingStartPt.X;
            double devY = -pt.Y + mouseMovingStartPt.Y;

            if (devX + UpperX < MaximalX && devX + LowerX > MinimalX)
            {
                UpperX += devX;
                LowerX += devX;
            }
            if (devY + UpperY < MaximalY && devY + LowerY > MinimalY)
            {
                UpperY += devY;
                LowerY += devY;
            }
            pt = ConvToRealCoord(e.X, e.Y);
            mouseMovingStartPt = pt;
            // SetRangeTextBox();
            Draw();
        }
        //マスキングモードのとき
        else if (MaskingMode && SelectedMaskingBoundaryIndex[0] >= 0)
        {
            formProfile.SetMaskRange(SelectedMaskingBoundaryIndex, ConvToRealCoord(e.X, 0).X);
            if (formProfile.SortMaskRanges())
                SelectedMaskingBoundaryIndex = SearchMaskBoundary(pt.X, formProfile.GetMaskRanges(), dev);
            DiffractionProfile2 dp = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1];
            dp.SetMaskingProfile();
            Draw();
        }
    }

    #endregion

    #region マウスクリック位置に近い回折線、Bg点、MaskRangeを返す関数群

    //もっともptに近いpts配列内の要素番号を返す。その差がdev以下が必須条件
    public int SearchPt(PointD clientPt, PointD[] pts, double dev)
    {
        double R2 = double.PositiveInfinity;
        double temp;
        int n = -1;
        PointF p;
        for (int i = 0; i < pts.Length; i++)
        {
            p = ConvToPicBoxCoord(pts[i]);
            if ((temp = (clientPt.X - p.X) * (clientPt.X - p.X) + (clientPt.Y - p.Y) * (clientPt.Y - p.Y)) < R2)
            {
                R2 = temp;
                n = i;
            }
        }
        if (R2 < dev * dev) return n;
        else return -1;
    }

    /// <summary>
    /// もっともdに近いcry.Planeの要素番号を返す。その差がdev以下が必須条件
    /// </summary>
    /// <param name="x"></param>
    /// <param name="cry"></param>
    /// <param name="dev"></param>
    /// <returns></returns>
    public static int SearchPlaneNo(double x, Crystal cry, double dev)
    {
        if (cry == null || cry.Plane == null) return -1;
        double temp = double.PositiveInfinity;
        int n = 0;
        for (int i = 0; i < cry.Plane.Count; i++)
        {
            if (Math.Abs(cry.Plane[i].XCalc - x) < temp)
            {
                temp = Math.Abs(cry.Plane[i].XCalc - x);
                n = i;
            }
        }
        if (temp < dev) return n;
        else return -1;
    }

    /// <summary>
    /// もっともdに近く、y以下強度のpt配列内の要素番号を返す。その差がdev以下が必須条件
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="cry"></param>
    /// <param name="dev"></param>
    /// <returns></returns>
    public int SearchPlaneNo(double x, double y, Crystal cry, double dev)
    {
        if (cry.Plane == null) return -1;
        double temp = double.PositiveInfinity;
        int n = 0;
        double Intensity;
        for (int i = 0; i < cry.Plane.Count; i++)
        {
            if (formCrystal.checkBoxVariableRatioOfIntensity.Checked)//強度比を変えているとき(画面に固定されていないとき)
                Intensity = cry.Plane[i].Intensity * cry.DiffractionPeakIntensity;
            else
                Intensity = cry.Plane[i].Intensity * (UpperY - LowerY) + LowerY;

            if (Math.Abs(cry.Plane[i].XCalc - x) < temp && y < Intensity)
            {
                temp = Math.Abs(cry.Plane[i].XCalc - x);
                n = i;
            }

        }
        if (temp < dev) return n;
        else return -1;
    }

    public static int[] SearchMaskBoundary(double x, DiffractionProfile2.MaskingRange[] ranges, double dev)
    {
        if (ranges == null) return [-1, -1];
        int index1 = 0;
        int index2 = 0;
        double temp = double.PositiveInfinity;
        for (int i = 0; i < ranges.Length; i++)
            for (int j = 0; j < ranges[i].X.Length; j++)
                if (Math.Abs(ranges[i].X[j] - x) < temp)
                {
                    index1 = i;
                    index2 = j;
                    temp = Math.Abs(ranges[i].X[j] - x);
                }
        if (temp < dev)
            return [index1, index2];
        return [-1, -1];
    }
    #endregion

    #region FormFittingからの呼び出し
    //formFiitingから呼び出されたとき
    public void ChangeCrystalFromFitting(/*Crystal cry*/)
    {
        InitializeCrystalPlane();
        SetFormCrystal(false);
        SetFormEOS();

        formFitting.ChangeCrystalFromMainForm();

        Draw();
    }
    #endregion

    #region 子フォームの起動終了チェックボックスイベント

    private void toolStripButtonCrystalParameter_Click(object sender, EventArgs e)
      => checkBoxCrystalParameter.Checked = !checkBoxCrystalParameter.Checked;

    private void toolStripButtonProfileParameter_Click(object sender, EventArgs e)
        => checkBoxProfileParameter.Checked = !checkBoxProfileParameter.Checked;

    private void checkBoxProfileParameter_CheckedChanged(object sender, EventArgs e)
    {
        toolStripButtonProfileParameter.Checked = checkBoxProfileParameter.Checked;

        formProfile.Visible = checkBoxProfileParameter.Checked;
        if (formProfile.Visible)
        {
            formProfile.BringToFront();
            formProfile.WindowState = FormWindowState.Normal;
            WindowLocation.Adjust(formProfile);
        }
        Draw();
    }
    //Crystalボタンチェック変化時
    private void checkBoxCrystalParameter_CheckedChanged(object sender, EventArgs e)
    {
        toolStripButtonCrystalParameter.Checked = checkBoxCrystalParameter.Checked;

        formCrystal.Visible = checkBoxCrystalParameter.Checked;
        if (formCrystal.Visible)
        {
            formCrystal.BringToFront();
            formCrystal.WindowState = FormWindowState.Normal;
            WindowLocation.Adjust(formCrystal);

        }
    }

    //EOSチェックボックスチェック変化時
    private void toolStripButtonEquationOfState_CheckedChanged(object sender, EventArgs e)
    {
        if (toolStripButtonEquationOfState.Checked == false && formEOS.WindowState == FormWindowState.Minimized)
            toolStripButtonEquationOfState.Checked = true;
        else
        {
            formEOS.Visible = toolStripButtonEquationOfState.Checked;
            if (formEOS.Visible)
            {
                formEOS.BringToFront();
                formEOS.WindowState = FormWindowState.Normal;
                WindowLocation.Adjust(formEOS);

            }
        }
    }

    //Fittingチェックボックスチェック変更時
    private void toolStripButtonFittingParameter_CheckedChanged(object sender, EventArgs e)
    {
        if (toolStripButtonFittingParameter.Checked == false && formFitting.WindowState == FormWindowState.Minimized)
            toolStripButtonFittingParameter.Checked = true;
        else
        {
            formFitting.Visible = toolStripButtonFittingParameter.Checked;
            if (formFitting.Visible)
            {
                formFitting.BringToFront();
                formFitting.WindowState = FormWindowState.Normal;
                WindowLocation.Adjust(formFitting);
            }
        }
    }

    private void toolStripButtonLPO_CheckedChanged(object sender, EventArgs e)
    {
        if (toolStripButtonLPO.Checked == false && formLPO.WindowState == FormWindowState.Minimized)
            toolStripButtonLPO.Checked = true;
        else
        {
            formLPO.Visible = toolStripButtonLPO.Checked;
            if (formLPO.Visible)
            {
                formLPO.BringToFront();
                formLPO.WindowState = FormWindowState.Normal;
                WindowLocation.Adjust(formLPO);
            }
        }
    }

    private void toolStripButtonCellFinder_CheckedChanged(object sender, EventArgs e)
    {
        if (toolStripButtonCellFinder.Checked == false && formCellFinder.WindowState == FormWindowState.Minimized)
            toolStripButtonCellFinder.Checked = true;
        else
        {
            formCellFinder.Visible = toolStripButtonCellFinder.Checked;
            if (formCellFinder.Visible)
            {
                formCellFinder.BringToFront();
                formCellFinder.WindowState = FormWindowState.Normal;
                WindowLocation.Adjust(formCellFinder);
            }
        }
    }


    private void toolStripButtonAtomicPositonFinder_CheckedChanged(object sender, EventArgs e)
    {
        if (toolStripButtonAtomicPositonFinder.Checked == false && formAtomicPositionFinder.WindowState == FormWindowState.Minimized)
            toolStripButtonAtomicPositonFinder.Checked = true;
        else
        {
            formAtomicPositionFinder.Visible = toolStripButtonAtomicPositonFinder.Checked;
            if (formAtomicPositionFinder.Visible)
            {
                formAtomicPositionFinder.BringToFront();
                formAtomicPositionFinder.WindowState = FormWindowState.Normal;
                WindowLocation.Adjust(formAtomicPositionFinder);
            }
        }
    }


    private void toolStripButtonStressAnalysis_CheckedChanged(object sender, EventArgs e)
    {
        if (toolStripButtonSequentialAnalysis.Checked == false && formSequentialAnalysis.WindowState == FormWindowState.Minimized)
            toolStripButtonSequentialAnalysis.Checked = true;
        else
        {
            formSequentialAnalysis.Visible = toolStripButtonSequentialAnalysis.Checked;
            if (formSequentialAnalysis.Visible)
            {
                formSequentialAnalysis.BringToFront();
                formSequentialAnalysis.WindowState = FormWindowState.Normal;
                WindowLocation.Adjust(formSequentialAnalysis);

            }
        }
    }
    #endregion

    #region 子フォームのセット
    /// <summary>
    /// FormEOSをセット 
    /// </summary>
    public void SetFormEOS()//FormEOSをセット
    {
        if (!toolStripButtonEquationOfState.Checked) return;


        formEOS.skipTextChangeEvent = true;
        // if(dataSet.DataTableCrystal.

        //Au
        if (formEOS.checkBoxGold.Checked = dataSet.DataTableCrystal.GetItemChecked(1))
            formEOS.numericalTextBoxGoldA.Text = (dataSet.DataTableCrystal.Items[1].A * 10).ToString("f5");
        //Pt
        if (formEOS.checkBoxPlatinum.Checked = dataSet.DataTableCrystal.GetItemChecked(2))
            formEOS.numericalTextBoxPtA.Text = (dataSet.DataTableCrystal.Items[2].A * 10).ToString("f5");

        //NaCl B1
        if (formEOS.checkBoxNaClB1.Checked = dataSet.DataTableCrystal.GetItemChecked(3))
            formEOS.numericalTextBoxNaClB1A.Text = (dataSet.DataTableCrystal.Items[3].A * 10).ToString("f5");

        //NaCl B2
        if (formEOS.checkBoxNaClB2.Checked = dataSet.DataTableCrystal.GetItemChecked(4))
            formEOS.numericalTextBoxNaClB2A.Text = (dataSet.DataTableCrystal.Items[4].A * 10).ToString("f5");

        //MgO
        if (formEOS.checkBoxPericlase.Checked = dataSet.DataTableCrystal.GetItemChecked(5))
            formEOS.numericalTextBoxMgOA.Text = (dataSet.DataTableCrystal.Items[5].A * 10).ToString("f5");

        //Corundum
        if (formEOS.checkBoxCorundum.Checked = dataSet.DataTableCrystal.GetItemChecked(6))
            formEOS.numericalTextBoxColundumV.Text = (dataSet.DataTableCrystal.Items[6].Volume * 1000).ToString("f5");

        //Ar
        if (formEOS.checkBoxAr.Checked = dataSet.DataTableCrystal.GetItemChecked(7))
            formEOS.numericalTextBoxArA.Text = (dataSet.DataTableCrystal.Items[7].A * 10).ToString("f5");

        //Re
        if (formEOS.checkBoxRe.Checked = dataSet.DataTableCrystal.GetItemChecked(8))
            formEOS.numericBoxReV.Text = (dataSet.DataTableCrystal.Items[8].Volume * 1000).ToString("f5");

        //Mo
        if (formEOS.checkBoxMo.Checked = dataSet.DataTableCrystal.GetItemChecked(9))
            formEOS.numericBoxMoV.Text = (dataSet.DataTableCrystal.Items[9].Volume * 1000).ToString("f5");

        //Pb
        if (formEOS.checkBoxPb.Checked = dataSet.DataTableCrystal.GetItemChecked(10))
            formEOS.numericBoxPbA.Text = (dataSet.DataTableCrystal.Items[10].A * 10).ToString("f5");

        formEOS.skipTextChangeEvent = false;
        formEOS.numericalTextBox_ValueChanged(new object(), new EventArgs());
    }

    /// <summary>
    /// FormCrystalをセット
    /// </summary>
    /// <param name="ReCalcDensity">格子定数のみを変更する場合はTrue</param>
    public void SetFormCrystal(bool changeCellConstantsOnly = false)
    {
        if (SelectedCrystalIndex < 0) return;
        if (formCrystal.crystalControl != null)
        {
            var c = dataSet.DataTableCrystal.Items[bindingSourceCrystal.Position];
            c.GetFormulaAndDensity();
            if (changeCellConstantsOnly)
                formCrystal.crystalControl.CellConstants = c.CellValue;
            else
                formCrystal.crystalControl.Crystal = c;

            formCrystal.crystalControl.CalculateEOS();//これを入れておかないと、EOS有効の時に反映されない
        }
    }

    /// <summary>
    /// FormFittingをセット
    /// </summary>
    public void SetFormFitting()
    {
    }
    #endregion

    #region プロファイルのファイル読み込み関連

    public void menuItemFileRead_Click(object sender, System.EventArgs e)
    {
        var dlg = new OpenFileDialog
        {
            Filter = "Powder Pattern File (WinPIP[*.csv]; Fit2D[*.chi]; PDI[*.pdi,pdi2], EDX profile[*.rpt, *.npd, *.nxs])|*.csv;*.chi;*.pdi;*.pdi2;*.rpt;*.npd;*.nxs"
            + "|Any format(Auto[*.*])|*.*",
            Multiselect = true,
            FilterIndex = FilterIndex
        };
        if (InitialDirectory != "")
            dlg.InitialDirectory = InitialDirectory;

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            readProfile(dlg.FileNames);
            InitialDirectory = Path.GetDirectoryName(dlg.FileName);
        }
    }

    public void readProfile(string[] fileNames)
    {
        stopwatch.Restart();
        var showFormDataConverter = true;
        Array.Sort(fileNames, StringComparer.OrdinalIgnoreCase);

        for (int i = 0; i < fileNames.Length - 1; i++)
        {
            readProfile(fileNames[i], true, true, true, true);

            if (i % 10 == 0 && fileNames.Length > 1 && !fileNames[i].EndsWith(".pdi"))
            {
                if (MessageBox.Show("Now loading multiple profiles. Do you use this setting for the following profiles?", "Option", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    stopwatch.Restart();
                    showFormDataConverter = false;
                    SkipDrawing = skipAxisPropertyChangedEvent = true;
                    for (i = i + 1; i < fileNames.Length - 1; i++)
                    {
                        readProfile(fileNames[i], showFormDataConverter, true, false, false);
                        Application.DoEvents();
                    }
                }
            }
        }
        SkipDrawing = skipAxisPropertyChangedEvent = false;

        readProfile(fileNames[^1], showFormDataConverter);

        if (fileNames.Length > 1)
            bindingSourceProfile.Position -= fileNames.Length - 1;

        toolStripStatusLabel1.Text = $"Time taken to read profiles: {stopwatch.ElapsedMilliseconds / 1000.0:f1} sec.";
    }

    public void readProfile(string fileName, bool showFormDataConverter = true, bool isChecked = true, bool isDrawn = true, bool changePos = true)
    {
        if (InvokeRequired)//別スレッド(ファイル更新監視スレッド)から呼び出されたとき Invokeして呼びなおす
        {
            Invoke(new Action(() => readProfile(fileName, showFormDataConverter, isChecked, isDrawn)));
            return;
        }

        formDataConverter.textBox.Text = "";
        var ext = Path.GetExtension(fileName).ToLower().Remove(0, 1);

        var fileTypeNum = ext switch
        {
            "csv" => (int)FileType.CSV,
            "ras" => (int)FileType.RAS,
            "nxs" => (int)FileType.NXS,
            "chi" => (int)FileType.CHI,
            "xbm" => (int)FileType.XBM,
            "rpt" => (int)FileType.RPT,
            "npd" => (int)FileType.NPD,
            "xy" => (int)FileType.XY,
            _ => (int)FileType.OTHRES,
        };


        //pdi, ras, nxs 形式の時. csvは拡張の場合
        if (ext == "pdi" || ext == "pdi2" || ext == "ras" || ext == "csv" || ext == "nxs")
        {
            var dp = new List<DiffractionProfile2>();
            if (ext == "pdi" || ext == "pdi2")
            #region pdi形式のとき
            {
                dp.AddRange(XYFile.ReadPdi2File(fileName, ext == "pdi" ? 1 : 2));
                if (dp.Count == 0)
                    return;
                for (int i = 0; i < dp.Count; i++)
                {
                    if (dp[i].SrcProperty.WaveSource == WaveSource.Xray && dp[i].SrcProperty.WaveLength > 1)
                        dp[i].SrcProperty.WaveLength = UniversalConstants.Convert.EnergyToXrayWaveLength(dp[i].SrcProperty.WaveLength * 10000);
                    dp[i].SubtractBackground = false;
                    for (int j = 0; j < dp[i].SourceProfile.Pt.Count; j++)
                        if (dp[i].SourceProfile.Pt[j].Y == 0)
                            dp[i].SourceProfile.Pt.RemoveAt(j--);
                        else break;

                    for (int j = dp[i].SourceProfile.Pt.Count - 1; j >= 0; j--)
                        if (dp[i].SourceProfile.Pt[j].Y == 0)
                            dp[i].SourceProfile.Pt.RemoveAt(j);
                        else break;
                }
            }
            #endregion

            else
            #region RAS, CSV, NXSのいずれか
            {
                var detectorNum = 1;

                if (ext == "nxs")//NXSファイルの場合は事前にチャンネル数を確認
                {
                    var nxs = new Crystallography.HDF(fileName);
                    nxs.Move("/entry/instrument/xspress3");
                    detectorNum = nxs.GetGroups().Length;
                }

                formDataConverter.EDXDetectorNumber = detectorNum;
                formDataConverter.SetProperty(FileProperties[fileTypeNum]);

                if (!showFormDataConverter || formDataConverter.ShowDialog() == DialogResult.OK)
                {
                    FileProperties[fileTypeNum] = formDataConverter.GetProperty();

                    if (ext == "ras")
                        dp.AddRange(XYFile.ReadRasFile(fileName));
                    else if (ext == "csv")
                        dp.AddRange(XYFile.ReadCSVFile(fileName));
                    else if (ext == "nxs")
                    {
                        var nxs = new Crystallography.HDF(fileName);
                        nxs.Move("/entry/instrument/xspress3");
                        int n = 0;
                        foreach (var channel in nxs.GetGroups())
                        {
                            if (formDataConverter.EDXDetectorValid[n])
                            {
                                double a0 = formDataConverter.EGC[n][0], a1 = formDataConverter.EGC[n][1], a2 = formDataConverter.EGC[n][2];
                                var (data, result) = nxs.GetValue2<int>(channel + "/histogram");
                                if (result && data.Length > 0)
                                {
                                    var diffProf = new DiffractionProfile2 { Name = $"{Path.GetFileNameWithoutExtension(fileName)} - {channel}" };

                                    var sumData = new int[data[0].Length];
                                    foreach (var d in data)
                                        for (int i = 0; i < sumData.Length; i++)
                                            sumData[i] += d[i];

                                    var pts = sumData.Select((y, x) => new PointD(a0 + a1 * x + a2 * x * x, y)).Where(p => p.X > 0).ToList();

                                    if (formDataConverter.LowEnergyCutoff)
                                        pts = pts.Where(p => p.X < formDataConverter.LowEnergyCutoffValue).ToList();

                                    pts.RemoveAt(pts.Count - 1);
                                    diffProf.SourceProfile.Pt = pts;
                                    dp.Add(diffProf);
                                }
                            }
                            n++;
                        }
                    }

                    if (dp.Count > 0)
                        for (int i = 0; i < dp.Count; i++)
                        {
                            dp[i].SrcProperty = formDataConverter.HorizontalAxisProperty;
                            dp[i].ExposureTime = formDataConverter.ExposureTime;
                            dp[i].SubtractBackground = false;
                        }
                }
            }

            #endregion

            if (dp.Count > 0)
            {
                //処理時間短縮のために、最後から一つ手前のDiffractionProfileまでを一気に入力
                skipAxisPropertyChangedEvent = true;
                for (int i = 0; i < dp.Count - 1; i++)
                    AddProfileToCheckedListBox(dp[i], checkBoxAll.Checked, false, false);
                skipAxisPropertyChangedEvent = false;
                AddProfileToCheckedListBox(dp[^1], checkBoxAll.Checked, true, false);

                Text = $"PDIndexer   {Version.VersionAndDate}   {dp[^1].Name}";
                formFitting.ChangeHorizontalAxis();
                return;
            }
        }
        //pdi,ras, csv, nxs 形式ではないとき. csvは通常の場合はこちらに入ってくる
        if (ext != "pdi" && ext != "ras" && ext != "nxs")
        {
            var strList = new List<string>();
            using (var reader = new StreamReader(fileName, Encoding.UTF8))
                while (!reader.EndOfStream)
                    strList.Add(reader.ReadLine());


            if (strList.Count <= 3)
                return;

            var diffProf = new DiffractionProfile2();
            formDataConverter.textBox.Lines = [.. strList];

            #region Fit2Dデータ
            if (ext == "chi")
            {
                formDataConverter.SetProperty(FileProperties[(int)FileType.CHI]);

                if (!showFormDataConverter || formDataConverter.ShowDialog() == DialogResult.OK)
                {
                    FileProperties[(int)FileType.CHI] = formDataConverter.GetProperty();

                    for (int i = 4; i < strList.Count; i++)
                    {
                        var str = strList[i].Split(' ', true);
                        if (str.Length == 4)
                        {
                            var str1 = str[1];
                            var str3 = str[3];
                            if (Miscellaneous.IsDecimalPointComma)
                            {
                                str1 = str1.Replace('.', ',');
                                str3 = str3.Replace('.', ',');
                            }
                            diffProf.SourceProfile.Pt.Add(new PointD(Convert.ToDouble(str1), Convert.ToDouble(str3)));
                        }
                        else
                            break;
                    }
                }
                else return;
            }
            #endregion

            #region XBM形式 SP8_BL4B2のデータらしい
            else if (fileName.ToLower().EndsWith("xbm"))
            {
                formDataConverter.SetProperty(FileProperties[(int)FileType.XBM]);

                using var br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));
                var getString = new Func<int, int, string>((position, count) =>
                {
                    char[] temp = new char[count];
                    br.BaseStream.Position = position;
                    br.Read(temp, 0, temp.Length);
                    return new string(temp).TrimEnd();
                });

                var getDouble = new Func<int, double>((position) =>
                {
                    br.BaseStream.Position = position;
                    return br.ReadDouble();
                });

                var getInt16 = new Func<int, short>((position) =>
                {
                    br.BaseStream.Position = position;
                    return br.ReadInt16();
                });

                diffProf.Comment = "Sample name: " + getString(0x4, 64);
                diffProf.Comment += "\r\nProfile number: " + getString(0x44, 64);
                diffProf.Comment += "\r\nDate,Time,Span: " + getString(0x84, 8) + ", " + getString(0x8c, 6) + ", " + getString(0x92, 6);
                diffProf.Comment += "\r\nOperator name: " + getString(0x98, 30);
                diffProf.Comment += "\r\nComment: " + getString(0xB6, 100);
                diffProf.Comment += "\r\nEGC1,2,3: " + getDouble(0x59A) + ", " + getDouble(0x5A2) + ", " + getDouble(0x5AA);
                diffProf.Comment += "\r\n2Theta(deg): " + getDouble(0x05B2);
                diffProf.Comment += "\r\nLive/Real time (sec): " + getDouble(0x05F4) + "/" + getDouble(0x05EC);
                diffProf.Comment += "\r\nDead time (%): " + getDouble(0x0686);
                diffProf.Comment += "\r\nTemperature (degC): " + getDouble(0x05D2);
                diffProf.Comment += "\r\nRing current (mA): " + getDouble(0x05C2) * 10;
                diffProf.Comment += "\r\nCounting rate: " + getDouble(0x05E2);
                diffProf.Comment += "\r\nPress conditions X:NA, Y:NA, Z:NA, Phi(deg): " + getDouble(0x0616);
                diffProf.Comment += "\r\nIncident slit conditions (mm) V: " + getDouble(0x068E) + ", H: " + getDouble(0x0696);
                diffProf.Comment += "\r\nReceiving slit conditions (mm) V: " + getDouble(0x06B6) + ", H: " + getDouble(0x06BE) + ", Collimator:NA";
                diffProf.Comment += "\r\nHeating conditions  V(V): " + getDouble(0x05BA) + ", C(A): " + getDouble(0x06E6) + ", P(W): " + getDouble(0x066E) + ", R(OHM): " + getDouble(0x0676);

                formDataConverter.TakeoffAngleText = getDouble(0x05B2).ToString();
                formDataConverter.ExposureTime = getDouble(0x05F4);

                double[][] egc = [[0.0, 0.0, 0.0]];
                egc[0][0] = getDouble(0x59A);
                egc[0][1] = getDouble(0x5A2);
                egc[0][2] = getDouble(0x5AA);
                formDataConverter.EGC = egc;

                formDataConverter.VisibleEDXSetting = true;

                int length = getInt16(0x814);
                br.BaseStream.Position = 0x816;

                if (!showFormDataConverter || formDataConverter.ShowDialog() == DialogResult.OK)
                {
                    FileProperties[(int)FileType.XBM] = formDataConverter.GetProperty();
                    for (int n = 1; n < length; n++)
                    {
                        double x = (formDataConverter.EGC[0][0] + formDataConverter.EGC[0][1] * n + formDataConverter.EGC[0][2] * n * n) * 1000;
                        double y = br.ReadUInt32();
                        if (!formDataConverter.LowEnergyCutoff || x > formDataConverter.LowEnergyCutoffValue / 1000)
                            diffProf.SourceProfile.Pt.Add(new PointD(x, y));
                    }
                }
                else
                    return;
            }
            #endregion

            #region RPT形式 (gennie file)
            else if (ext == "rpt")
            {
                formDataConverter.SetProperty(FileProperties[(int)FileType.RPT]);

                //TakeoffAngle
                formDataConverter.TakeoffAngleText = strList[^4].Split(',', true)[0];
                formDataConverter.ExposureTime = Convert.ToDouble(strList[^5].Split(' ', true)[1]);

                formDataConverter.EDXDetectorNumber = 1;
                double[][] egc = [[0.0, 0.0, 0.0]];
                egc[0][0] = Convert.ToDouble(strList[^1].Split(',', true)[0]);
                egc[0][1] = Convert.ToDouble(strList[^1].Split(',', true)[1]);
                formDataConverter.EGC = egc;

                if (!showFormDataConverter || formDataConverter.ShowDialog() == DialogResult.OK)
                {
                    FileProperties[(int)FileType.RPT] = formDataConverter.GetProperty();
                    int n = 1;
                    for (int i = 1; i < strList.Count - 6; i++)
                    {
                        var str = strList[i].Split(' ', true);
                        for (int j = 0; j < str.Length; j++)
                        {
                            double x = (formDataConverter.EGC[0][0] + formDataConverter.EGC[0][1] * n) * 1000;
                            n++;
                            if (!formDataConverter.LowEnergyCutoff || x > formDataConverter.LowEnergyCutoffValue / 1000)
                                diffProf.SourceProfile.Pt.Add(new PointD(x, Convert.ToDouble(str[j])));
                        }
                    }
                }
                else
                    return;
            }
            #endregion

            #region npd形式
            else if (ext == "npd")
            {
                formDataConverter.SetProperty(FileProperties[(int)FileType.NPD]);

                formDataConverter.EDXDetectorNumber = 1;
                formDataConverter.EnergyUnit = EnergyUnitEnum.eV;

                double[][] egc = [[0.0, 0.0, 0.0]];
                for (int i = 0; i < strList.Count || i < 25; i++)
                {
                    if (strList[i].StartsWith("EGC0"))
                        egc[0][0] = strList[i].Split(',', true)[1].ToDouble();
                    if (strList[i].StartsWith("EGC1"))
                        egc[0][1] = strList[i].Split(',', true)[1].ToDouble();
                    if (strList[i].StartsWith("EGC2"))
                        egc[0][2] = strList[i].Split(',', true)[1].ToDouble();
                    if (strList[i].StartsWith("2Theta"))
                        formDataConverter.TakeoffAngleText = strList[i].Split(',', true)[1];
                    if (strList[i].StartsWith("Live time"))
                        formDataConverter.ExposureTime = strList[i].Split(',', true)[1].ToDouble();
                }
                formDataConverter.EGC = egc;

                if (!showFormDataConverter || formDataConverter.ShowDialog() == DialogResult.OK)
                {
                    FileProperties[(int)FileType.NPD] = formDataConverter.GetProperty();
                    for (int i = 0; i < strList.Count; i++)
                    {
                        int length = 0;
                        if (strList[i].StartsWith("Data length"))
                        {
                            length = strList[i].Split(',', true)[1].ToInt();

                            for (int j = i + 2; j < i + 2 + length; j++)
                            {
                                var x = Convert.ToDouble(strList[j].Split(',', true)[1]) * 1000;
                                var y = Convert.ToDouble(strList[j].Split(',', true)[2]);
                                if (!formDataConverter.LowEnergyCutoff || x > formDataConverter.LowEnergyCutoffValue / 1000)
                                    diffProf.SourceProfile.Pt.Add(new PointD(x, y));
                            }
                            break;
                        }
                    }

                }
                else
                    return;
            }
            #endregion

            #region 中性子TOFデータ
            else if (strList[0].StartsWith("**  MPLOT FILE **"))//中性子TOFデータの時
            {
                formDataConverter.WaveSource = WaveSource.Neutron;
                formDataConverter.WaveColor = WaveColor.FlatWhite;
                formDataConverter.AxisMode = HorizontalAxis.NeutronTOF;

                formDataConverter.SetProperty(FileProperties[(int)FileType.TOF]);
                if (!showFormDataConverter || formDataConverter.ShowDialog() == DialogResult.OK)
                {
                    FileProperties[(int)FileType.TOF] = formDataConverter.GetProperty();

                    for (int i = 0; i < strList.Count; i++)
                        if (strList[i].StartsWith("-----------------------------------------------"))
                        {
                            for (int j = i + 1; j < strList.Count - 1; j++)
                            {
                                var str = strList[j].Split(" ", true);
                                var x = Convert.ToDouble(str[0]);
                                var y = Convert.ToDouble(str[1]);
                                var err = Convert.ToDouble(str[2]);
                                diffProf.SourceProfile.Pt.Add(new PointD(x, y));
                                diffProf.SourceProfile.Err.Add(new PointD(x, err));
                            }
                            break;
                        }

                    for (int i = 0; i < strList.Count; i++)
                    {
                        if (strList[i].StartsWith("\"\"\""))
                        {
                            var sb = new StringBuilder();
                            for (int j = i + 1; j < strList.Count; j++)
                            {
                                if (!strList[j].StartsWith("\"\"\""))
                                    sb.AppendLine(strList[j]);
                                else
                                {
                                    i = strList.Count;
                                    break;
                                }
                            }
                            diffProf.Comment = sb.ToString();
                        }
                    }
                }
            }
            #endregion

            #region xy形式 
            else if (ext == "xy" && strList[0] == "# == pyFAI calibration ==")
            {
                if (double.TryParse(strList[15].Split(" ")[2], out var wave))
                {
                    formDataConverter.SetProperty(FileProperties[(int)FileType.XY]);

                    formDataConverter.WaveSource = WaveSource.Xray;
                    formDataConverter.Wavelength = wave * 1e9;

                    if (!showFormDataConverter || formDataConverter.ShowDialog() == DialogResult.OK)
                    {
                        FileProperties[(int)FileType.XY] = formDataConverter.GetProperty();

                        for (int i = 23; i < strList.Count; i++)
                        {
                            var str = strList[i].Split(' ', true);
                            if (str.Length == 2)
                            {
                                if (Miscellaneous.IsDecimalPointComma)
                                {
                                    str[0] = str[0].Replace('.', ',');
                                    str[1] = str[1].Replace('.', ',');
                                }
                                diffProf.SourceProfile.Pt.Add(new PointD(Convert.ToDouble(str[0]), Convert.ToDouble(str[1])));
                            }
                            else
                                break;
                        }
                    }
                    else return;
                }
            }
            #endregion

            #region そのほかのファイル形式のとき
            else//
            {
                formDataConverter.SetProperty(FileProperties[(int)FileType.OTHRES]);
                if (!showFormDataConverter || formDataConverter.ShowDialog() == DialogResult.OK)
                {
                    FileProperties[(int)FileType.OTHRES] = formDataConverter.GetProperty();

                    if ((diffProf = XYFile.ConvertUnknownFileToProfileData(fileName, ',')) == null)
                        if ((diffProf = XYFile.ConvertUnknownFileToProfileData(fileName, ' ')) == null)
                            if ((diffProf = XYFile.ConvertUnknownFileToProfileData(fileName, '\t')) == null)
                                return;
                }
            }
            #endregion


            diffProf.SrcProperty = formDataConverter.HorizontalAxisProperty;

            diffProf.ExposureTime =  formDataConverter.ExposureTime;

            diffProf.Name = fileName.Remove(0, fileName.LastIndexOf('\\') + 1);

            //線源が白色X線で、単位がkevの場合、eVに変換
            if (formDataConverter.WaveSource == Crystallography.WaveSource.Xray
                       && formDataConverter.WaveColor == WaveColor.FlatWhite
                       && formDataConverter.AxisMode == HorizontalAxis.EnergyXray
                       && formDataConverter.EnergyUnit == EnergyUnitEnum.KeV)
            {
                //for (int i = 0; i < diffProf.SourceProfile.Pt.Count; i++)
                //    diffProf.SourceProfile.Pt[i] = new PointD(1000 * diffProf.SourceProfile.Pt[i].X, diffProf.SourceProfile.Pt[i].Y);
            }

            if (diffProf.SourceProfile.Pt.Count > 0)
            {
                if (diffProf.SrcProperty.AxisMode == HorizontalAxis.NeutronTOF)
                    if (diffProf.SrcProperty.TofTimeUnit == TimeUnitEnum.NanoSecond)//単位を変換する必要がある場合は
                        for (int i = 0; i < diffProf.SourceProfile.Pt.Count; i++)
                            diffProf.SourceProfile.Pt[i] = new PointD(diffProf.SourceProfile.Pt[i].X / 1000, diffProf.SourceProfile.Pt[i].Y);

                AddProfileToCheckedListBox(diffProf, isChecked, isDrawn, changePos);
            }

            Text = $"PDIndexer   {Version.VersionAndDate}   {Path.GetFileName(fileName)}";
        }
        formFitting.ChangeHorizontalAxis();
    }

    #endregion

    #region プロファイルのチェックボックスへの追加

    /// <summary>
    /// 新しいDiffractionProfileをチェックリストボックスに加える
    /// </summary>
    /// <param name="dp">加えるDiffractionProfile</param>
    /// <param name="isCheked">チェックした状態にするか</param>
    /// <param name="isDrawn">描画範囲をリセットし描画するか</param>
    /// <param name="changePos">チェックリストボックスの選択を変更するか</param>
    /// <param name="isRenewOtherProfiles"></param>
    public void AddProfileToCheckedListBox(DiffractionProfile2 dp, bool isCheked, bool isDrawn, bool changePos = true)
    {
        if (dp.Mode == DiffractionProfileMode.Concentric)
        {//ConcentricModeのとき
         //dp.CopyParameter(defaultDP);
            if (checkBoxChangeHorizontalAppearance.Checked)
            {
                if (WaveColor != dp.SrcProperty.WaveColor) WaveColor = dp.SrcProperty.WaveColor;
                if (WaveSource != dp.SrcProperty.WaveSource) WaveSource = dp.SrcProperty.WaveSource;
                if (AxisMode != dp.SrcProperty.AxisMode) AxisMode = dp.SrcProperty.AxisMode;
             
                if (WaveLength != dp.SrcProperty.WaveLength) WaveLength = dp.SrcProperty.WaveLength;
                if (WaveSource == WaveSource.Xray)
                {
                    if (WaveColor == WaveColor.Monochrome)
                    {
                        if (XraySourceElementNumber != dp.SrcProperty.XrayElementNumber) XraySourceElementNumber = dp.SrcProperty.XrayElementNumber;
                        if (XraySourceLine != dp.SrcProperty.XrayLine) XraySourceLine = dp.SrcProperty.XrayLine;
                    }
                }

                if (TakeoffAngle != dp.SrcProperty.EnergyTakeoffAngle) TakeoffAngle = dp.SrcProperty.EnergyTakeoffAngle;
                if (TofAngle != dp.SrcProperty.TofAngle) TofAngle = dp.SrcProperty.TofAngle;
                if (TofLength != dp.SrcProperty.TofLength) TofLength = dp.SrcProperty.TofLength;

                if (AxisMode == HorizontalAxis.d && horizontalAxisUserControl.DspacingUnit != dp.SrcProperty.DspacingUnit)
                    horizontalAxisUserControl.DspacingUnit = dp.SrcProperty.DspacingUnit;
                if (AxisMode == HorizontalAxis.EnergyXray || AxisMode == HorizontalAxis.EnergyElectron || AxisMode== HorizontalAxis.EnergyNeutron )
                if(horizontalAxisUserControl.EnergyUnit != dp.SrcProperty.EnergyUnit)
                    horizontalAxisUserControl.EnergyUnit = dp.SrcProperty.EnergyUnit;
                
                if(AxisMode== HorizontalAxis.Angle && horizontalAxisUserControl.TwoThetaUnit != dp.SrcProperty.TwoThetaUnit)
                    horizontalAxisUserControl.TwoThetaUnit = dp.SrcProperty.TwoThetaUnit;
                if (AxisMode == HorizontalAxis.WaveNumber && horizontalAxisUserControl.WaveNumberUnit != dp.SrcProperty.WaveNumberUnit)
                    horizontalAxisUserControl.WaveNumberUnit = dp.SrcProperty.WaveNumberUnit;
            }
            dp.SetConvertedProfile(HorizontalAxisProperty);

            //マルチパターンモードかつChangeColorモードのときは
            if (dp.ColorARGB == null)
                if (radioButtonMultiProfileMode.Checked && checkBoxChangeColor.Checked)
                    dp.ColorARGB = generateRandomColor().ToArgb();
                else//デフォルトカラーを設定
                    dp.ColorARGB = Color.Blue.ToArgb();

            var bmp = new Bitmap(18, 18);
            using (var g = Graphics.FromImage(bmp))
                g.Clear(Color.FromArgb((int)dp.ColorARGB));

            if (radioButtonSingleProfileMode.Checked)//シングルパターンモードのとき
                dataSet.DataTableProfile.Rows.Clear();

            dataSet.DataTableProfile.Rows.Add([isCheked, dp, bmp]);
            if (changePos)
                bindingSourceProfile.Position = dataSet.DataTableProfile.Items.Count - 1;

            if (isDrawn)
            {
                SetDrawRangeLimit();//描画範囲の上限、下限を設定
                ResetDrawRange(); //描画範囲をリセット
                InitializeCrystalPlane(); //描画する結晶面の設定	
                Draw();                     //プロファイル描画
                SetFormEOS();           //EOS画面の描画
                formFitting.ChangeCrystalFromMainForm();//formFittingの更新
                SetFormCrystal(false);
            }
        }
        else
        {//RadialModeのとき
            if (checkBoxChangeHorizontalAppearance.Checked)
            {
                AxisMode = HorizontalAxis.None;
                XraySourceElementNumber = dp.SrcProperty.XrayElementNumber;
                XraySourceLine = dp.SrcProperty.XrayLine;
                if (XraySourceElementNumber == 0)
                    WaveLength = dp.SrcProperty.WaveLength;
                TakeoffAngle = dp.SrcProperty.EnergyTakeoffAngle;
            }
            dp.SetConvertedProfile(HorizontalAxisProperty);

            //マルチパターンモードかつChangeColorモードのときは
            if (dp.ColorARGB == null)
                if (radioButtonMultiProfileMode.Checked && checkBoxChangeColor.Checked)
                    dp.ColorARGB = generateRandomColor().ToArgb();
                else//デフォルトカラーを設定
                    dp.ColorARGB = Color.Blue.ToArgb();

            var bmp = new Bitmap(18, 18);
            using (var g = Graphics.FromImage(bmp))
                g.Clear(Color.FromArgb((int)dp.ColorARGB));

            if (radioButtonSingleProfileMode.Checked)//シングルパターンモードのとき
                dataSet.DataTableProfile.Rows.Clear();//消去

            dataSet.DataTableProfile.Rows.Add([isCheked, dp, bmp]);//新しいプロファイルを追加
            if (changePos)
                bindingSourceProfile.Position = dataSet.DataTableProfile.Items.Count - 1;

            if (isDrawn)
            {
                SetDrawRangeLimit();//描画範囲の上限、下限を設定
                ResetDrawRange(); //描画範囲をリセット
                Draw();                     //プロファイル描画
            }
        }
    }

    public Color generateRandomColor()
    {
        var r = new Random();
        var max = 192 + r.Next(64);
        var mid1 = r.Next(128);
        var mid2 = r.Next(128);
        if (dataSet.DataTableProfile.Items.Count == 0)//直前のプロファイルがない時はR>G>Bの色を返す
            return Color.FromArgb(max, mid1, mid2);
        else//直前のプロファイルがある時はその色となるべく違う色を返す  
        {
            int red = Color.FromArgb(dataSet.DataTableProfile.Items[^1].ColorARGB.Value).R;
            int green = Color.FromArgb(dataSet.DataTableProfile.Items[^1].ColorARGB.Value).G;
            int blue = Color.FromArgb(dataSet.DataTableProfile.Items[^1].ColorARGB.Value).B;

            if (red >= green && red >= blue)//直前が赤優勢のとき
                return Color.FromArgb(mid1, max, mid2);//緑優勢を返す

            else if (green >= red && green >= blue) //直前が緑優勢のとき
                return Color.FromArgb(mid1, mid2, max);//青優勢を返す

            else  //直前が青優勢のとき
                return Color.FromArgb(max, mid1, mid2);//赤優勢を返す
        }
    }


    #endregion

    #region 結晶データ読み書き
    //結晶データのセーブ
    public void menuItemSaveCrystalData_Click(object sender, System.EventArgs e)
    {
        var cry = new List<Crystal>();
        for (int i = 0; i < dataSet.DataTableCrystal.Count; i++)
            cry.Add(dataSet.DataTableCrystal.Items[i]);

        var formCrystalSelection = new FormCrystalSelection { LoadMode = false };
        formCrystalSelection.SetCrystalList(cry);
        if (formCrystalSelection.ShowDialog() == DialogResult.OK && formCrystalSelection.CheckedCrystalList.Length > 0)
        {
            var Dlg = new SaveFileDialog() { Filter = "xml|*.Xml" };
            if (Dlg.ShowDialog() == DialogResult.OK)
                try
                {
                    ConvertCrystalData.SaveCrystalListXml(formCrystalSelection.CheckedCrystalList, Dlg.FileName);
                }
                catch
                {
                    MessageBox.Show("ファイルが書き込みません");
                }
        }
    }

    public void saveCrystal(string filename, Crystal[] crystals = null)
    {
        try
        {
            if (crystals == null)
            {
                var cry = new List<Crystal>();
                for (int i = 0; i < dataSet.DataTableCrystal.Count; i++)
                    cry.Add(dataSet.DataTableCrystal.Items[i]);
                crystals = [.. cry];
            }
            if (!filename.ToLower().EndsWith(".xml"))
                filename += ".xml";

            ConvertCrystalData.SaveCrystalListXml(crystals, filename);
        }
        catch
        {
            MessageBox.Show("ファイルが書き込みません");
        }

    }

    //結晶データの読み込み
    public void menuItemReadCrystalData_Click(object sender, System.EventArgs e)
    {
        var Dlg = new OpenFileDialog() { Filter = "xml|*.Xml" };
        if (Dlg.ShowDialog() == DialogResult.OK)
            readCrystal(Dlg.FileName, true, true);
    }
    private void readAndAddToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var Dlg = new OpenFileDialog() { Filter = "xml|*.Xml" };
        if (Dlg.ShowDialog() == DialogResult.OK)
            readCrystal(Dlg.FileName, true, false);
    }

    public void readCrystal(string fileName, bool showSelectionDialog, bool clearPresentData)
    {

        var sb = new StringBuilder();
        var sr = new StreamReader(fileName, Encoding.UTF8);
        while (sr.Peek() > -1)
            sb.AppendLine(sr.ReadLine());
        sr.Close();

        var sw = new StreamWriter(fileName, false, Encoding.UTF8);
        sw.WriteLine(sb);
        sw.Close();


        var crystalArray = new List<Crystal>();


        crystalArray.AddRange(ConvertCrystalData.ConvertToCrystalList(fileName));


        if (crystalArray.Count == 0) return;

        if (showSelectionDialog)
        {
            var formCrystalSelection = new FormCrystalSelection { LoadMode = true };
            formCrystalSelection.SetCrystalList(crystalArray);

            if (formCrystalSelection.ShowDialog() == DialogResult.OK)//セレクションダイアログを表示
            {
                crystalArray.Clear();
                crystalArray.AddRange(formCrystalSelection.CheckedCrystalList);
            }
            else return;
        }

        if (clearPresentData)
        {
            for (int i = 0; i < dataSet.DataTableCrystal.Rows.Count; i++)
                if (!((Crystal)dataSet.DataTableCrystal.Rows[i][1]).Reserved)
                    dataSet.DataTableCrystal.Rows.RemoveAt(i--);
        }


        //何らかの原因で同一のReserved結晶が存在する場合は、片方(大きなインデックス)を削除
        for (int j = 0; j < dataSet.DataTableCrystal.Rows.Count; j++)
        {
            var c1 = (Crystal)dataSet.DataTableCrystal.Rows[j][1];
            if (c1.Reserved)
                for (int i = j + 1; i < dataSet.DataTableCrystal.Rows.Count; i++)
                {
                    var c2 = (Crystal)dataSet.DataTableCrystal.Rows[i][1];
                    if (c2.Reserved && c2.Name == c1.Name && c2.Journal == c1.Journal)
                        dataGridViewCrystals.Rows.RemoveAt(i);
                }
        }



        //もし読み込んだ結晶リストにReservedされたCrystalがあれば入れ替える
        crystalArray[0].FlexibleMode = true;
        for (int j = 0; j < dataSet.DataTableCrystal.Rows.Count; j++)
        {
            var c = (Crystal)dataSet.DataTableCrystal.Rows[j][1];
            if (c.Reserved)
                for (int i = 0; i < crystalArray.Count; i++)
                {
                    if (crystalArray[i].Name == c.Name && crystalArray[i].Journal == c.Journal)
                    {
                        crystalArray[i].Reserved = true;
                        dataSet.DataTableCrystal.Rows[j][1] = crystalArray[i];
                        crystalArray.RemoveAt(i);
                        //break;
                    }
                }
        }

        foreach (Crystal c in crystalArray)
        {
            var bmp = new Bitmap(22, 22);
            var g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(c.Argb));
            dataSet.DataTableCrystal.Rows.Add([false, c, bmp]);
        }

        dataGridViewCrystals.Rows[0].DefaultCellStyle = cellStyle1;

        for (int i = 1; i < dataGridViewCrystals.Rows.Count; i++)
            if (((Crystal)dataSet.DataTableCrystal.Rows[i][1]).Reserved)
                dataGridViewCrystals.Rows[i].DefaultCellStyle = cellStyle2;

        if (bindingSourceCrystal.List.Count > 0)
            bindingSourceCrystal.Position = 0;
        InitializeCrystalPlane(); //描画する結晶面の設定					
        Draw();                     //プロファイル描画
    }

    #endregion

    #region 印刷関係
    //MenuItemから印刷処理
    private void menuItemPrint_Click(object sender, System.EventArgs e)
    {
        var pdlg = new PrintDialog { Document = printDocument };
        if (pdlg.ShowDialog() == DialogResult.OK)
            printDocument.Print();
    }

    private void menuItemPrintPreview_Click(object sender, System.EventArgs e)
    {
        // 印刷プレビューを表示
        printPreviewDialog.ShowDialog();
    }
    private void menuItemPrintPageSetup_Click(object sender, System.EventArgs e)
    {
        pageSetupDialog1.Document = printDocument;
        if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
        {
            printDocument.PrinterSettings = pageSetupDialog1.PrinterSettings;
        }
    }

    private void pd_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        DrawPrint(ref e);
        e.HasMorePages = false;
    }
    #endregion

    #region マクロメニュー関連
    private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        => FormMacro.Visible = true;

    public void SetMacroToMenu(string[] name)
    {
        if (macroToolStripMenuItem.DropDownItems.Count == 1)
            macroToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
        for (int i = macroToolStripMenuItem.DropDownItems.Count - 1; i > 1; i--)
            macroToolStripMenuItem.DropDownItems.RemoveAt(i);


        for (int i = 0; i < name.Length; i++)
        {
            var item = new ToolStripMenuItem(name[i]) { Name = name[i] };
            item.Click += macroMenuItem_Click;
            macroToolStripMenuItem.DropDownItems.Add(item);
        }
    }
    void macroMenuItem_Click(object sender, EventArgs e)
        => FormMacro.RunMacroName(((ToolStripMenuItem)sender).Name, false);

    #endregion

    #region ToolStrip メニュー

    /// <summary>
    /// 選択中の結晶をCIFファイルへ変換
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripMenuItemExportCIF_Click(object sender, EventArgs e)
         => formCrystal.crystalControl.exportThisCrystalAsCIFToolStripMenuItem_Click(sender, e);

    /// <summary>
    /// 言語変更
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void languageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        englishToolStripMenuItem.Checked = ((ToolStripMenuItem)sender).Name.Contains("english");
        japaneseToolStripMenuItem.Checked = !englishToolStripMenuItem.Checked;
        Thread.CurrentThread.CurrentUICulture = englishToolStripMenuItem.Checked ? new System.Globalization.CultureInfo("en") : new System.Globalization.CultureInfo("ja");
        Language.Change(this);
    }

    /// <summary>
    /// クリップボード監視
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void watchReadClipboardToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        ChangeClipboardChain(this.Handle, NextHandle);//とりあえず切って
        if (watchReadClipboardToolStripMenuItem.Checked)//必要であればつなげる
            NextHandle = SetClipboardViewer(this.Handle);

    }
    private void resetClipboardViewer()
    {
        ChangeClipboardChain(this.Handle, NextHandle);//とりあえず切って
        Thread.Sleep(100);
        NextHandle = SetClipboardViewer(this.Handle);
    }

    /// <summary>
    /// ディレクトリ監視
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripTextBoxDirectoryToWatch_TextChanged(object sender, EventArgs e)
    {
        if (toolStripTextBoxDirectoryToWatch.Text != "")
        {
            watcher.Path = toolStripTextBoxDirectoryToWatch.Text;
            watchReadANewProfileToolStripMenuItem_CheckedChanged(new object(), new EventArgs());
        }
    }

    private void watchReadANewProfileToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        watcher.EnableRaisingEvents = watchReadANewProfileToolStripMenuItem.Checked && Directory.Exists(watcher.Path);
    }

    private void setDirectoryToTheWatchToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dlg = new FolderBrowserDialog();
        if (dlg.ShowDialog() == DialogResult.OK)
            toolStripTextBoxDirectoryToWatch.Text = dlg.SelectedPath;
    }

    /// <summary>
    /// ツールチップ 有効/無効
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolTipToolStripMenuItem_Click(object sender, EventArgs e)
        => toolTip.Active = toolTipToolStripMenuItem.Checked;

    //MenuItemから終了処理
    private void menuItemClose_Click(object sender, EventArgs e) => this.Close();

    private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e) => new FormAboutMe().ShowDialog();

    //結晶データをリセットする
    private void resetInitialCrystalDataToolStripMenuItem_Click(object sender, EventArgs e)
        => readCrystal(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\default.Xml", false, true);

    //プロファイル保存
    public void savePatternProfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataSet.DataTableProfile.Items.Count > 0)
        {
            var dialog = new SaveFileDialog { Filter = "*.pdi2|*.pdi2" };
            if (dialog.ShowDialog() == DialogResult.OK)
                SaveProfile(dialog.FileName);
        }
    }

    public void SaveProfile(string filename)
    {
        if (dataSet.DataTableProfile.Items.Count > 0)
        {
            var dp = new List<DiffractionProfile2>();
            for (int i = 0; i < dataSet.DataTableProfile.Items.Count; i++)
                dp.Add(dataSet.DataTableProfile.Items[i]);
            if (!filename.ToLower().EndsWith(".pdi2"))
                filename += ".pdi2";

            XYFile.SavePdi2File([.. dp], filename);
        }
    }

    /// <summary>
    /// ヘルプ
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void helpwebToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            var fn = "\\doc\\PDIndexerManual(" + (japaneseToolStripMenuItem.Checked ? "ja" : "en") + ").pdf";
            var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var f = new FormPDF(appPath + fn) { Text = "PDIndexer manual" };
            f.Show();
        }
        catch { }
    }


    private void toolStripMenuItemImport_Click(object sender, EventArgs e)
    {
        var dlg = new OpenFileDialog { Filter = "cif, amc file | *.amc;*.cif" };
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            var c = ConvertCrystalData.ConvertToCrystal(dlg.FileName);
            if (c != null)
                formCrystal.AddCrystal(c);
        }
    }





    private void hintToolStripMenuItem_Click(object sender, EventArgs e)
    {
        initialDialog.DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.Hint;
        initialDialog.Visible = true;
    }

    public void toolStripMenuItemSaveMetafile_Click(object sender, EventArgs e)
    {
        var dlg = new SaveFileDialog { Filter = "*.emf|*.emf" };
        if (dlg.ShowDialog() == DialogResult.OK)
            saveMetafile(dlg.FileName);
    }
    public void saveMetafile(string filename)
    {
        try
        {
            using var grfx = CreateGraphics();
            var ipHdc = grfx.GetHdc();
            using var ms = new MemoryStream();
            using var mf = new Metafile(ms, ipHdc, EmfType.EmfPlusDual);
            grfx.ReleaseHdc(ipHdc);
            grfx.Dispose();
            DrawMetafile(mf);

            if (!filename.ToLower().EndsWith(".emf"))
                filename += ".emf";

            using (var fsm = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                fsm.Write(ms.GetBuffer(), 0, (int)ms.Length);
                fsm.Close();
            }

            mf.Dispose();
        }
        catch { }
    }



    #endregion

    #region プロファイルをメタファイルで出力
    private void copyAsMetafileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var grfx = CreateGraphics();
        var ipHdc = grfx.GetHdc();
        using var ms = new MemoryStream();
        using var mf = new Metafile(ms, ipHdc, EmfType.EmfPlusDual);
        grfx.ReleaseHdc(ipHdc);
        grfx.Dispose();
        DrawMetafile(mf);
        ClipboardMetafileHelper.PutEnhMetafileOnClipboard(this.Handle, mf);
    }

    /* http://classicalprogrammer.wikidot.com/copy-gdi-drawing-to-clipboard */
    public class ClipboardMetafileHelper
    {
        [DllImport("user32.dll")]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll")]
        static extern bool EmptyClipboard();
        [DllImport("user32.dll")]
        static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        [DllImport("user32.dll")]
        static extern bool CloseClipboard();
        [DllImport("gdi32.dll")]
        static extern IntPtr CopyEnhMetaFile(IntPtr hemfSrc, IntPtr hNULL);
        [DllImport("gdi32.dll")]
        static extern bool DeleteEnhMetaFile(IntPtr hemf);

        // Metafile mf is set to an invalid state inside this function
        static public bool PutEnhMetafileOnClipboard(IntPtr hWnd, Metafile mf)
        {
            bool bResult = false;
            IntPtr hEMF, hEMF2;
            hEMF = mf.GetHenhmetafile(); // invalidates mf
            if (!hEMF.Equals(IntPtr.Zero))
            {
                hEMF2 = CopyEnhMetaFile(hEMF, new IntPtr(0));
                if (!hEMF2.Equals(IntPtr.Zero) && OpenClipboard(hWnd) && EmptyClipboard())
                {
                    IntPtr hRes = SetClipboardData(14 /*CF_ENHMETAFILE*/, hEMF2);
                    bResult = hRes.Equals(hEMF2);
                    CloseClipboard();
                }
                DeleteEnhMetaFile(hEMF);
            }
            return bResult;
        }
    }
    #endregion

    #region export関連
    private void toolStripMenuItemExportCSVFile_Click(object sender, EventArgs e)
    {
        if (dataSet.DataTableProfile.Items.Count == 0) return;

        var s = ((ToolStripMenuItem)sender).Name.Contains("CSV") ? "," : "\t";
        var dlg = new SaveFileDialog { Filter = s == "," ? "*.csv|*.csv" : "*.tsv|*.tsv" };

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            var merge = true;
            var result = MessageBox.Show("Merge the profiles to one file? \r\n(if select No, each profiles will be saved separately \r\nwith the name of the input filename plus 'Profile Name'.)", "Export option", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.No)
                merge = false;
            else if (result == DialogResult.Cancel)
                return;

            var dp = dataSet.DataTableProfile.CheckedItems;

            if (merge)//ひとつのファイルにマージする場合
                using (var writer = new StreamWriter(dlg.FileName))
                {
                    dp.ForEach(d => writer.Write($"{d.Name}{s}{s}{s}")); //一行目
                    writer.Write("\r\n");
                    dp.ForEach(d => writer.Write($"X{s}Y{s}{s}"));//二行目
                    writer.Write("\r\n");

                    for (int j = 0, max = dp.Max(d => d.Profile.Pt.Count); j < max; j++)//三行目以降
                    {
                        for (int i = 0; i < dp.Count; i++)
                            writer.Write(j < dp[i].Profile.Pt.Count ?
                                 $"{dp[i].Profile.Pt[j].X}{s}{dp[i].Profile.Pt[j].Y}{s}{s}" :
                                 $"{s}{s}{s}");
                        writer.Write("\r\n");
                    }
                }
            else//個別のファイルに分ける場合
                dp.ForEach(d =>
                {
                    var filename = $"{dlg.FileName[0..^4]} + {d.Name}{(s == "," ? ".csv" : ".tsv")}";
                    using var writer = new StreamWriter(filename);
                    writer.WriteLine($"X{s}Y");//一行目
                    for (int i = 0; i < d.Profile.Pt.Count; i++)
                        writer.WriteLine($"{d.Profile.Pt[i].X}{s}{d.Profile.Pt[i].Y}");
                });
        }
    }

    //プロファイルをGSASフォーマットとしてエクスポート
    private void exportGSASFormatToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (bindingSourceProfile.Position < 0) return;

        var dlg = new SaveFileDialog { Filter = "*.gsa|*.gsa" };
        var dp = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1]; ;
        dlg.FileName = Path.GetFileNameWithoutExtension(dp.Name);
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            using var writer = new StreamWriter(dlg.FileName);
            double div = AxisMode == HorizontalAxis.NeutronTOF ? 1 : 100;

            //一行目
            writer.WriteLine(dp.Name);

            //二行目
            var ptCount = dp.Profile.Pt.Count;
            var startAngle = dp.Profile.Pt[0].X * div;
            var stepAngle = (dp.Profile.Pt[1].X - dp.Profile.Pt[0].X) * div;
            writer.WriteLine("BANK 1 " + ptCount.ToString() + " " + ptCount.ToString() + " CONST " + startAngle.ToString("f2") + " " + stepAngle.ToString("f2") + " 0 0 FXYE");

            //errが有効なデータかどうかを判定
            bool validErr = true;
            if (dp.Profile.Err != null && dp.Profile.Err.Count == dp.Profile.Pt.Count)
            {
                for (int i = 0; i < ptCount; i++)
                    if (dp.Profile.Err[i].IsNaN)
                        validErr = false;
            }
            else
                validErr = false;

            for (int i = 0; i < ptCount; i++)
            {
                var value = new string[3];
                value[0] = (dp.Profile.Pt[i].X * div).ToString("g12");
                value[1] = dp.Profile.Pt[i].Y.ToString("g12");
                if (validErr)
                    value[2] = dp.Profile.Err[i].Y.ToString("g12");
                else
                    value[2] = Math.Sqrt(dp.Profile.Pt[i].Y).ToString("g12");

                var y = dp.Profile.Pt[i].Y.ToString("g7");

                for (int j = 0; j < value.Length; j++)
                {
                    if (value[j].Length > 11)
                        value[j] = value[j][..11];
                    if (value[j].EndsWith("."))
                        value[j] = string.Concat(" ", y.AsSpan(0, 10));
                    while (value[j].Length < 11)
                        value[j] = " " + value[j];
                }
                writer.WriteLine($" {value[0]} {value[1]} {value[2]}");
            }
            writer.Close();
        }
    }
    #endregion

    #region Horizontal Axis タブ
    bool skipAxisPropertyChangedEvent { get; set; } = false;
    /// <summary>
    /// 軸モードが変更されたときに呼び出される
    /// </summary>
    public void horizontalAxisUserControl_AxisPropertyChanged()
    {
        if (AxisMode == HorizontalAxis.Angle)
            labelX.Text = "2θ ("+ AxisProperty.TwoThetaUnitText + "): ";
        else if (AxisMode == HorizontalAxis.d)
            labelX.Text = "d (" +AxisProperty.DspacingUnitText +  "): ";
        else if (AxisMode == HorizontalAxis.WaveNumber)
            labelX.Text = "q (" + AxisProperty.WaveNumberUnitText +  "):";
        else if (AxisMode == HorizontalAxis.EnergyXray || AxisMode == HorizontalAxis.EnergyElectron || AxisMode == HorizontalAxis.EnergyNeutron)
            labelX.Text = "Energy (" + AxisProperty.EnegyUnitText +  "): ";
        else if (AxisMode == HorizontalAxis.NeutronTOF)
            labelX.Text = "TOF (" +AxisProperty.TofTimeUnitText + "): ";

        if (skipAxisPropertyChangedEvent) return;

        for (int i = 0; i < dataSet.DataTableProfile.Items.Count; i++)
        {
            var d = dataSet.DataTableProfile.Items[i];
            d.SetConvertedProfile(HorizontalAxisProperty);
        }
        SetDrawRangeLimit();
        ResetDrawRange();
        InitializeCrystalPlane();
        Draw();

        //formFittingにも知らせる
        formFitting.ChangeHorizontalAxis();
        if (formFitting.Visible)
            formFitting.Fitting();
    }
    #endregion

    #region Appearance & Single/Multi タブ

    private void tabControl_Click(object sender, EventArgs e)
        => tabControl.BringToFront();

    private void checkBoxShowScaleLine_CheckedChanged_1(object sender, EventArgs e) => Draw();

    private void radioButtonMultiProfileMode_CheckChanged(object sender, EventArgs e)
    {
        radioButtonSingleProfileMode.Checked = !radioButtonMultiProfileMode.Checked;

        if (numeriBoxIncreasingPixels.Value > float.MaxValue)
            numeriBoxIncreasingPixels.Value = numeriBoxIncreasingPixels.Value;

        IntervalOfProfiles = (float)numeriBoxIncreasingPixels.Value;
        //checkedListBoxProfiles.Enabled = radioButtonMultiProfileMode.Checked;
        //formProfile.checkedListBoxProfiles.Enabled = radioButtonMultiProfileMode.Checked;
        SetDrawRangeLimit();
        Draw();

        formProfile.Refresh();
    }
    private void numericUpDownIncreasingPixels_ValueChanged(object sender, EventArgs e)
    {
        if (numericUpDownIncreasingPixels.Value == -1)
            numeriBoxIncreasingPixels.Value = 0.5;
        else if (numericUpDownIncreasingPixels.Value == -2)
            numeriBoxIncreasingPixels.Value = 0.1;
        else if (numericUpDownIncreasingPixels.Value == -3)
            numeriBoxIncreasingPixels.Value = 0.05;
        else if (numericUpDownIncreasingPixels.Value == -4)
            numeriBoxIncreasingPixels.Value = 0.01;
        else if (numericUpDownIncreasingPixels.Value == -5)
            numeriBoxIncreasingPixels.Value = 0;
        else
            numeriBoxIncreasingPixels.Value = Math.Pow(2, (double)numericUpDownIncreasingPixels.Value);

        if (numeriBoxIncreasingPixels.Value > float.MaxValue)
            numeriBoxIncreasingPixels.Value = numeriBoxIncreasingPixels.Value;
        radioButtonMultiProfileMode_CheckChanged(new object(), new EventArgs());
    }

    private void radioButtonRawCounts_CheckedChanged(object sender, EventArgs e)
    {

        InitializeCrystalPlane();
        for (int i = 0; i < dataSet.DataTableProfile.Items.Count; i++)
        {
            var d = dataSet.DataTableProfile.Items[i];
            d.IsCPS = radioButtonCountsPerStep.Checked;
            d.IsLogIntensity = radioButtonLogarithm.Checked;
            d.SetConvertedProfile(HorizontalAxisProperty);
        }
        SetDrawRangeLimit();
        ResetDrawRange();
        Draw();

        formFitting.ChangeHorizontalAxis();
    }

    #endregion

    #region UnrolledImage関連
    public void setFrequencyProfile()
    {
        if (dataSet.DataTableProfile.GetItemChecked(bindingSourceProfile.Position))
        {

            var dif = (DiffractionProfile2)((DataRowView)bindingSourceProfile.Current).Row[1];
            if (dif.ImageArray != null)
            {
                tabControl1.Visible = true;
                Ring.Intensity.Clear();
                Ring.Intensity.AddRange(dif.ImageArray);
                Ring.CalcFreq();

                var frequencyProfile = new Profile { Pt = [] };

                for (int i = 0; i < Ring.Frequency.Count; i++)
                    frequencyProfile.Pt.Add(new PointD(Ring.Frequency.Keys[i], Ring.Frequency[Ring.Frequency.Keys[i]]));
                graphControlFrequency.Profile = frequencyProfile;
                graphControlFrequency.VerticalLines = [new PointD(0, double.NaN), new PointD((double)frequencyProfile.Pt[^1].X, double.NaN)];
                graphControlFrequency.Draw();
                uint max = uint.MinValue;
                foreach (uint u in dif.ImageArray.Select(v => (uint)v))
                    max = Math.Max(u, max);
                numericUpDownMaxInt.Maximum = (decimal)max;
                numericUpDownMinInt.Maximum = (decimal)max - 1;
                numericUpDownMaxInt.Minimum = 0;
                numericUpDownMinInt.Minimum = 0;

                setScale();
            }
            else
                tabControl1.Visible = false;
        }
        else
            tabControl1.Visible = false;

    }


    private void numericUpDownMinInt_ValueChanged(object sender, EventArgs e)
    {
        if (numericUpDownMaxInt.Value <= numericUpDownMinInt.Value)
        {
            numericUpDownMaxInt.Value = numericUpDownMinInt.Value + 1;
            return;
        }
        if (graphControlFrequency.VerticalLines != null && graphControlFrequency.VerticalLines.Length == 2)
        {
            graphControlFrequency.VerticalLines[graphControlFrequency.VerticalLines[0].X < graphControlFrequency.VerticalLines[1].X ? 0 : 1].X = (double)numericUpDownMinInt.Value;
            graphControlFrequency.Draw();
        }
        Draw();
    }

    private void numericUpDownMaxInt_ValueChanged(object sender, EventArgs e)
    {
        if (numericUpDownMaxInt.Value <= numericUpDownMinInt.Value)
        {
            numericUpDownMinInt.Value = numericUpDownMaxInt.Value - 1;
            return;
        }
        if (graphControlFrequency.VerticalLines != null && graphControlFrequency.VerticalLines.Length == 2)
        {
            graphControlFrequency.VerticalLines[graphControlFrequency.VerticalLines[0].X < graphControlFrequency.VerticalLines[1].X ? 1 : 0].X = (double)numericUpDownMaxInt.Value;
            graphControlFrequency.Draw();
        }
        Draw();
    }

    private void toolStripComboBoxScale_SelectedIndexChanged(object sender, EventArgs e) => setScale();
    private void toolStripComboBoxScale2_SelectedIndexChanged(object sender, EventArgs e) => setScale();
    private void toolStripComboBoxGradient_SelectedIndexChanged(object sender, EventArgs e) => setScale();

    private (byte R, byte G, byte B)[] scale;
    private void setScale()
    {
        //スケールをセット
        if (comboBoxScale1.SelectedIndex == 0)//ログスケール
        {
            if (comboBoxScale2.SelectedIndex == 0)//グレー
                scale = PseudoBitmap.ColorScaleGrayLog;
            else
                scale = PseudoBitmap.ColorScaleColdWarmLog;
        }
        else//リニア
        {
            if (comboBoxScale2.SelectedIndex == 0)//グレー
                scale = PseudoBitmap.ColorScaleGrayLiner;
            else//color
                scale = PseudoBitmap.ColorScaleColdWarmLiner;
        }

        Draw();
    }
    private void checkBoxShowUnrolledImage_CheckedChanged(object sender, EventArgs e) => Draw();

    private void tabControl1_Click(object sender, EventArgs e) => tabControl1.BringToFront();

    private void graphControlFrequency_LinePositionChanged()
    {
        if (graphControlFrequency.VerticalLines.Length == 2)
        {
            decimal max = (decimal)((int)Math.Max(graphControlFrequency.VerticalLines[0].X, graphControlFrequency.VerticalLines[1].X));
            if (numericUpDownMaxInt.Maximum <= max)
                numericUpDownMaxInt.Value = numericUpDownMaxInt.Maximum;
            else if (numericUpDownMaxInt.Minimum >= max)
                numericUpDownMaxInt.Value = numericUpDownMaxInt.Minimum;
            else
                numericUpDownMaxInt.Value = max;

            decimal min = (decimal)((int)Math.Min(graphControlFrequency.VerticalLines[0].X, graphControlFrequency.VerticalLines[1].X));
            if (numericUpDownMinInt.Maximum <= min)
                numericUpDownMinInt.Value = numericUpDownMinInt.Maximum;
            else if (numericUpDownMinInt.Minimum >= min)
                numericUpDownMinInt.Value = numericUpDownMinInt.Minimum;
            else
                numericUpDownMinInt.Value = min;
        }
    }

    #endregion

    #region DataGridViewCrystal関係のイベント

    public void dataGridViewCrystals_KeyDown(object sender, KeyEventArgs e)
    {
        e.SuppressKeyPress = true;
        if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
        {
            int index = SelectedCrystalIndex;
            if (e.KeyCode == Keys.Down && bindingSourceCrystal.Position < bindingSourceCrystal.Count)
                index = bindingSourceCrystal.Position = SelectedCrystalIndex + 1;
            else if (e.KeyCode == Keys.Up && bindingSourceCrystal.Position > 0)
                index = bindingSourceCrystal.Position = SelectedCrystalIndex - 1;
            if (index != SelectedCrystalIndex)
                dataGridViewCrystals_CellMouseClick(new object(),
                    new DataGridViewCellMouseEventArgs(1, SelectedCrystalIndex, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)));
        }
        else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
        {
            dataGridViewCrystals_CellMouseClick(new object(),
                    new DataGridViewCellMouseEventArgs(0, SelectedCrystalIndex, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)));
        }
    }

    readonly List<int> blinkingCrystals = [];
    bool blinkFlag = false;
    public void dataGridViewCrystals_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        //チェックボックスが直接クリックされた場合か、セレクションを変更せずに結晶の名前をクリックしたとき、現在チェック状況を逆転させる。
        //if(sender != formFitting)
        if (e.Button == MouseButtons.Left)
        {
            if ((e.ColumnIndex == 0 && e.RowIndex >= 0) || (e.ColumnIndex != 0 && e.RowIndex >= 0 && SelectedCrystalIndex == bindingSourceCrystal.Position))
                ((DataRowView)bindingSourceCrystal.Current).Row[0] = !(bool)((DataRowView)bindingSourceCrystal.Current).Row[0];
        }

        //Blinkingのセッティング
        if (e.RowIndex >= 0 && e.Button == System.Windows.Forms.MouseButtons.Right && e.Clicks == 2)
        {
            if (blinkingCrystals.Contains(e.RowIndex))
            {
                blinkingCrystals.Remove(e.RowIndex);
                dataGridViewCrystals.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor = Color.White;
                dataGridViewCrystals.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
            }
            else
                blinkingCrystals.Add(e.RowIndex);
        }
        if (blinkingCrystals.Count > 0)
            timerBlinkDiffraction.Start();

        //クリックによってセレクションが変更された場合
        bool crystalChanged = SelectedCrystalIndex != bindingSourceCrystal.Position;
        if (crystalChanged)
        {
            SelectedCrystalIndex = bindingSourceCrystal.Position;
            SelectedPlaneIndex = -1;
        }

        if (formCrystal.checkBoxShowPeakUnderProfile.Checked)
            BottomMargin = (HeightOfBottomPeaks + 4) * dataSet.DataTableCrystal.CheckedItems.Count;
        else
            BottomMargin = 0;
        InitializeCrystalPlane();

        SetFormCrystal();
        SetFormEOS();
        formFitting.ChangeCrystalFromMainForm(crystalChanged);
        Draw();

        formFitting.SetPlanes(true);
    }

    private void timerBlinkDiffraction_Tick(object sender, EventArgs e)
    {
        if (blinkingCrystals.Count > 0)
        {
            blinkFlag = !blinkFlag;
            foreach (int i in blinkingCrystals)
            {
                dataGridViewCrystals.Rows[i].Cells[2].Style.SelectionForeColor = blinkFlag ? Color.LightGray : Color.White;
                dataGridViewCrystals.Rows[i].Cells[2].Style.ForeColor = !blinkFlag ? Color.DarkGray : Color.Black;
            }
            Draw();
        }
        else
            timerBlinkDiffraction.Stop();
    }

    public bool StopCycling { get; set; } = false;

    #endregion

    #region dataGridViewProfiles関連のイベント

    public void dataGridViewProfiles_KeyDown(object sender, KeyEventArgs e)
    {
        e.SuppressKeyPress = true;
        if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
        {
            int index = SelectedProfileIndex;
            if (e.KeyCode == Keys.Down && bindingSourceProfile.Position < bindingSourceProfile.Count)
                index = bindingSourceProfile.Position = SelectedProfileIndex + 1;
            else if (e.KeyCode == Keys.Up && bindingSourceProfile.Position > 0)
                index = bindingSourceProfile.Position = SelectedProfileIndex - 1;
            if (index != SelectedProfileIndex)
                dataGridViewProfiles_CellClick(new object(), new DataGridViewCellEventArgs(1, index));
        }
        else if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
        {
            dataGridViewProfiles_CellClick(new object(), new DataGridViewCellEventArgs(0, SelectedProfileIndex));
        }
    }

    public void dataGridViewProfiles_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //チェックボックスが直接クリックされた場合か、セレクションを変更せずにプロファイルの名前をクリックしたとき、現在チェック状況を逆転させる。
        if ((e.ColumnIndex == 0 && e.RowIndex >= 0) || (e.ColumnIndex != 0 && e.RowIndex >= 0 && SelectedProfileIndex == bindingSourceProfile.Position))
            ((DataRowView)bindingSourceProfile.Current).Row[0] = !(bool)((DataRowView)bindingSourceProfile.Current).Row[0];

        //クリックによってセレクションが変更された場合
        if (SelectedProfileIndex != bindingSourceProfile.Position)
            SelectedProfileIndex = bindingSourceProfile.Position;

        skipProfileCheckedEvent = true;
        if (dataSet.DataTableProfile.AllChecked)
            checkBoxAll.CheckState = CheckState.Checked;
        else if (dataSet.DataTableProfile.AllUnchecked)
            checkBoxAll.CheckState = CheckState.Unchecked;
        else
            checkBoxAll.CheckState = CheckState.Indeterminate;
        skipProfileCheckedEvent = false;

        Draw();
    }

    bool skipProfileCheckedEvent = false;
    /// <summary>
    /// Check All Profilesが押されたとき
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        if (skipProfileCheckedEvent) return;
        if (checkBoxAll.Checked)
            dataSet.DataTableProfile.AllChecked = true;
        else
            dataSet.DataTableProfile.AllUnchecked = true;

        Draw();
    }

    #endregion

    #region プログラムアップデート
    private void programUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        (var Title, var Message, var NeedUpdate, var URL, var Path) = ProgramUpdates.Check(Version.Software, Version.VersionAndDate);

        if (!NeedUpdate)
            MessageBox.Show(Message, Title, MessageBoxButtons.OK);
        else if (MessageBox.Show(Message, Title, MessageBoxButtons.YesNo) == DialogResult.Yes)
            using (var wc = new WebClient())
            {
                long counter = 1;
                wc.DownloadProgressChanged += (s, ev) =>
                {
                    if (counter++ % 10 == 0)
                        ip.Report(ProgramUpdates.ProgressMessage(ev, stopwatch));
                };

                wc.DownloadFileCompleted += (s, ev) =>
                {
                    if (ProgramUpdates.Execute(Path))
                        Close();
                    else
                        MessageBox.Show($"Failed to downlod {Path}. \r\nSorry!", "Error!");
                };
                stopwatch.Restart();
                try
                {
                    wc.DownloadFileAsync(new Uri(URL), Path);
                }
                catch
                {
                    MessageBox.Show("Failed update check. \r\nServer may be down. \r\nAccess https://github.com/seto77/PDindexer/releases/latest", "Error");
                }
            }
    }


    private bool skipProgressEvent { get; set; } = false;
    /// <summary>
    /// 進捗状況を更新
    /// </summary>
    /// <param name="current"></param>
    /// <param name="total"></param>
    /// <param name="elapsedMilliseconds">経過時間</param>
    /// <param name="message">メッセージ</param>
    /// <param name="interval">何回に一回更新するか</param>
    /// <param name="sleep"></param>
    /// <param name="showPercentage"></param>
    /// <param name="showEllapsedTime"></param>
    /// <param name="showRemainTime"></param>
    /// <param name="digit"></param>
    private void reportProgress(long current, long total, long elapsedMilliseconds, string message,
        int sleep = 0, bool showPercentage = true, bool showEllapsedTime = true, bool showRemainTime = true, int digit = 1)
    {
        if (skipProgressEvent || current > total)
            return;
        skipProgressEvent = true;
        try
        {
            toolStripProgressBar.Maximum = int.MaxValue;
            var ratio = (double)current / total;
            toolStripProgressBar.Value = (int)(ratio * toolStripProgressBar.Maximum);
            var ellapsedSec = elapsedMilliseconds / 1000.0;
            var format = $"f{digit}";

            if (showPercentage) message += $" Completed: {(ratio * 100).ToString(format)} %.";
            if (showEllapsedTime) message += $" Elappsed time: {ellapsedSec.ToString(format)} sec.";
            if (showRemainTime) message += $" Remaining time: {(ellapsedSec / current * (total - current)).ToString(format)} sec.";

            //toolStripStatusLabel.Text = message;

            Application.DoEvents();

            if (sleep != 0) Thread.Sleep(sleep);
        }
        catch (Exception e)
        {

        }
        skipProgressEvent = false;
    }

    private void reportProgress((long current, long total, long elapsedMilliseconds, string message) o)
         => reportProgress(o.current, o.total, o.elapsedMilliseconds, o.message);





    #endregion プログラムアップデート

    #region その他イベント
    //pictureBoxの再描画時に呼び出される
    private void pictureBoxMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        if (MouseRangingMode)
        {
            var pen = new Pen(Brushes.Gray) { DashStyle = DashStyle.Dash };
            e.Graphics.DrawRectangle(pen, Math.Min(mouseRangeStart.X, mouseRangeEnd.X), Math.Min(mouseRangeStart.Y, mouseRangeEnd.Y),
                Math.Abs(mouseRangeStart.X - mouseRangeEnd.X), Math.Abs(mouseRangeStart.Y - mouseRangeEnd.Y));
        }
    }

    private void FormMain_DragDrop(object sender, DragEventArgs e)
    {
        var fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        //ListBoxに追加する
        if (fileName.Length == 1)
        {
            if (fileName[0].ToLower().EndsWith("xml"))
                readCrystal(fileName[0], true, false);
            else if (fileName[0].ToLower().EndsWith("cif") || fileName[0].ToLower().EndsWith("amc"))
            {
                if (formCrystal.Visible == false)
                    checkBoxCrystalParameter.Checked = true;
                formCrystal.crystalControl.FormCrystal_DragDrop(sender, e);

            }
            else
                readProfile(fileName);
        }
        else
            readProfile(fileName);
    }

    /// <summary>
    /// ドラッグされたデータ形式を調べ、ファイルのときはコピーとする. ファイル以外は受け付けない.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FormMain_DragEnter(object sender, DragEventArgs e)
        => e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

    /// <summary>
    /// KeyDownイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void FormMain_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && !e.Shift && e.KeyCode == Keys.C && this.pictureBoxMain.Focused)
            copyAsMetafileToolStripMenuItem_Click(new object(), new EventArgs());

        if (e.Control && e.Shift && e.KeyCode == Keys.C)
            checkBoxCrystalParameter.Checked = !checkBoxCrystalParameter.Checked;
        else if (e.Control && e.Shift && e.KeyCode == Keys.E)
            toolStripButtonEquationOfState.Checked = !toolStripButtonEquationOfState.Checked;
        else if (e.Control && e.Shift && e.KeyCode == Keys.F)
            toolStripButtonFittingParameter.Checked = !toolStripButtonFittingParameter.Checked;
        else if (e.Control && e.Shift && e.KeyCode == Keys.D)
        {
            if (!formCrystal.checkBoxShowPeakOverProfiles.Checked)
            {
                formCrystal.checkBoxShowPeakOverProfiles.Checked = true;
                formCrystal.checkBoxCalculateIntensity.Checked = false;
            }
            else if (formCrystal.checkBoxShowPeakOverProfiles.Checked && !formCrystal.checkBoxCalculateIntensity.Checked)
                formCrystal.checkBoxCalculateIntensity.Checked = true;
            else if (formCrystal.checkBoxShowPeakOverProfiles.Checked && formCrystal.checkBoxCalculateIntensity.Checked)
                formCrystal.checkBoxShowPeakOverProfiles.Checked = false;
        }
        else if (e.Control && e.Shift && e.KeyCode == Keys.S)
            formSequentialAnalysis.Visible = !formSequentialAnalysis.Visible;
        else if (e.Control && e.Shift && e.KeyCode == Keys.Space)
        {
            if (bindingSourceCrystal.Current != null && bindingSourceCrystal.Position >= 0)
                ((DataRowView)bindingSourceCrystal.Current).Row[0] = !(bool)((DataRowView)bindingSourceCrystal.Current).Row[0];
        }
        else if (e.Control && e.Alt && e.KeyCode == Keys.Space && formFitting.Visible)
        {
            if (formFitting.bindingSourcePlanes.Current != null && formFitting.bindingSourcePlanes.Position >= 0)
                ((DataRowView)formFitting.bindingSourcePlanes.Current).Row[0] = !(bool)((DataRowView)formFitting.bindingSourcePlanes.Current).Row[0];
        }
        else if (e.Control && e.Shift && e.KeyCode == Keys.V)//クリップボードから、プロファイルや結晶を貼り付け
        {
            if (((IDataObject)Clipboard.GetDataObject()).GetDataPresent(typeof(string)))
            {
                IDataObject data = Clipboard.GetDataObject();
                string str = (string)data.GetData(typeof(string));
                //StreamWriter
                var sw = new StreamWriter("clipbord.txt");
                sw.Write(str);
                sw.Close();
                readProfile("clipbord.txt");
                File.Delete("clipboard.txt");
            }
        }
    }
    #endregion

}
