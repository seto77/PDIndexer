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
using Microsoft.Win32;
using System.Reflection;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using IronPython.Hosting;

namespace PDIndexer
{
    /// <summary>
    /// PDIndexer の概要の説明です。
    /// </summary>
    /// 
    public partial class FormMain : System.Windows.Forms.Form
    {

        #region プロパティ

        public FormCrystal formCrystal;
        public FormEOS formEOS;
        public FormFitting formFitting;
        public FormProfileSetting formProfile;
        public FormLPO formLPO;
        public FormCellFinder formCellFinder;
        public FormAtomicPositionFinder formAtomicPositionFinder;
        public FormStressAnalysis formStressAnalysis;
        public FormMacro FormMacro;
        public FormTwoThetaCalibration formTwoThetaCalibration;

        public Mutex mutex; 

        bool clearRegistryFlag = false;

        WaitDlg initialDialog;

        
        public bool BackGroundPointSelectMode { get; set; } = false;
       

        private int[] selectedMaskingBoundaryIndex = new int[] { -1, -1 };
        public int[] SelectedMaskingBoundaryIndex
        {
            set { selectedMaskingBoundaryIndex = value; }
            get { return selectedMaskingBoundaryIndex; }
        }
        
        public bool MaskingMode { get; set; } = false;
        
        private Point mouseRangeStart, mouseRangeEnd;
        private bool mouseRangingMode=false;
        public bool MouseRangingMode
        {
            set { mouseRangingMode = value; }
            get { return mouseRangingMode; }
        }

        private PointD mouseMovingStartPt;
        public bool MouseMovingMode { set; get; } = false;

        public bool ShowBackgroundProfile = false;
        

        public FormDataConverter formDataConverter;

        public bool IsSkipCheckedListBoxEvent = false;
        
        public int SelectedCrysatlIndex { set; get; } = -1;

        public int SelectedPlaneIndex { set; get; } = -1;

        public bool IsPlaneSelected = false;

        public DiffractionProfile defaultDP = new DiffractionProfile();
        int filterIndex;
        string initialDirectory="";

        public double LowerX
        {
            set
            {
                numericBoxLowerX.Value =  value;
                if (UpperX <= LowerX) 
                    UpperX++;
            }
            get { return numericBoxLowerX.Value; }
        }
        public double UpperX
        {
            set { numericBoxUpperX.Value = value; if (UpperX <= LowerX)LowerX++; }
            get { return numericBoxUpperX.Value; }
        }
        public double LowerY
        {
            set { numericBoxLowerY.Value = value; if (UpperY <= LowerY)UpperY++; }
            get { return numericBoxLowerY.Value; }
        }
        public double UpperY
        {
            set { numericBoxUpperY.Value = value; if (UpperY <= LowerY)LowerY--; }
            get { return numericBoxUpperY.Value; }
        }

        public double MaximalX
        {
            set
            {
                if (numericBoxUpperX.Minimum > value)
                    numericBoxUpperX.Minimum = numericBoxLowerX.Minimum = value - 1;

                numericBoxUpperX.Maximum =  numericBoxLowerX.Maximum = value;
            }
            get
            {
                return numericBoxUpperX.Maximum;
            }
        }
        public double MinimalX
        {
            set
            {
                if (numericBoxUpperX.Maximum < value)
                    numericBoxUpperX.Maximum = numericBoxLowerX.Maximum = value + 1;

                numericBoxUpperX.Minimum =     numericBoxLowerX.Minimum = value;
            }
            get
            {
                return numericBoxLowerX.Minimum;
            }
        }
        public double MaximalY
        {
            set
            {
                if (numericBoxUpperY.Minimum > value)
                    numericBoxUpperY.Minimum = numericBoxLowerY.Minimum = value - 1;

                numericBoxUpperY.Maximum = numericBoxLowerY.Maximum = value;
            }
            get { return numericBoxUpperY.Maximum; }
        }
        public double MinimalY
        {
            set
            {
                if (numericBoxUpperY.Maximum < value)
                    numericBoxUpperY.Maximum = numericBoxLowerY.Maximum = value + 1;

                numericBoxUpperY.Minimum = numericBoxLowerY.Minimum = value;
            }
            get { return numericBoxLowerY.Minimum; }
        }
        
        public Bitmap BmpMain, BmpIntensity, BmpAngle;
        public Graphics gMain, gAngle, gIntensity;
        
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
            get { return horizontalAxisUserControl.WaveSource; }
        }
        /// <summary>
        /// 入射線の色
        /// </summary>
        public WaveColor WaveColor
        {
            set { if(horizontalAxisUserControl.WaveColor != value)
                horizontalAxisUserControl.WaveColor = value; }
            get { return horizontalAxisUserControl.WaveColor; }
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
            get { return horizontalAxisUserControl.WaveLength; }
        }
        //X線の元素
        public int XraySourceElementNumber
        {
            set { if (horizontalAxisUserControl.XrayWaveSourceElementNumber != value)
                horizontalAxisUserControl.XrayWaveSourceElementNumber = value; }
            get { return horizontalAxisUserControl.XrayWaveSourceElementNumber; }
        }
        //X線の元素
        public XrayLine XraySourceLine
        {
            set { if(horizontalAxisUserControl.XrayWaveSourceLine != value)
                horizontalAxisUserControl.XrayWaveSourceLine = value; }
            get { return horizontalAxisUserControl.XrayWaveSourceLine; }
        }

        //EDX取り出し角
        public double TakeoffAngle
        {
            set
            {
                if (horizontalAxisUserControl.TakeoffAngle != value)
                    horizontalAxisUserControl.TakeoffAngle = value;
            }
            get { return horizontalAxisUserControl.TakeoffAngle; }
        }

        //TOF取り出し角
        public double TofAngle
        {
            set
            {
                if (horizontalAxisUserControl.TofAngle != value)
                    horizontalAxisUserControl.TofAngle = value;
            }
            get { return horizontalAxisUserControl.TofAngle; }
        }

        //TOF取り出し距離
        public double TofLength
        {
            set
            {
                if (horizontalAxisUserControl.TofLength != value)
                    horizontalAxisUserControl.TofLength = value;
            }
            get { return horizontalAxisUserControl.TofLength; }
        }

        //軸の状態
        public HorizontalAxis AxisMode
        {
            set { if (horizontalAxisUserControl.AxisMode != value)
                horizontalAxisUserControl.AxisMode = value; }
            get { return horizontalAxisUserControl.AxisMode; }
        }

        public bool IsBgPtSelected = false;
        public int SelectedBgPtIndex = -1;
        public int SelectedProfileIndex = -1;

        public bool IsSkipTextBoxChange = false;

        Point OriginPos= new Point(40,24); //原点の位置
        public float IntervalOfProfiles = 0;
        public float HeightOfBottomPeaks = 0;
        public float BottomMargin = 0;


        public FileProperty[] FileProperties { get; set; } = new FileProperty[Enum.GetValues(typeof(FileType)).Length];

        #endregion

        public DataGridViewCellStyle cellStyle1 = new DataGridViewCellStyle();
        public DataGridViewCellStyle cellStyle2 = new DataGridViewCellStyle();
        public DataGridViewCellStyle cellStyleBlink = new DataGridViewCellStyle();

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

        public FormMain()
        {
            if (!this.DesignMode)
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\PDIndexer");
                try
                {
                    string culture = (string)regKey.GetValue("Culture", Thread.CurrentThread.CurrentUICulture.Name);
                    if (culture.ToLower().StartsWith("ja"))
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja");
                    else
                        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                }
                catch { }
            }

            InitializeComponent();

            if(!this.DesignMode)
                setScale();

            mutex = new Mutex(true, "PDIndexer");
       }

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new FormMain());
        }
        
        
        #region クリップボード監視
        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_DRAWCLIPBOARD:

                    using (Mutex clipboard = new Mutex(false, "ClipboardOperation"))
                    {
                        if (clipboard.WaitOne(500, false))
                        {
                            try
                            {
                                if (((IDataObject)Clipboard.GetDataObject()).GetDataPresent(typeof(DiffractionProfile)))
                                {
                                    IDataObject data = Clipboard.GetDataObject();
                                    DiffractionProfile dp = (DiffractionProfile)data.GetData(typeof(DiffractionProfile));
                                    clipboard.ReleaseMutex();
                                    if (dp != null)
                                        AddProfileToCheckedListBox(dp, true, true);
                                }
                                else if (((IDataObject)Clipboard.GetDataObject()).GetDataPresent(typeof(DiffractionProfile[])))
                                {
                                    IDataObject data = Clipboard.GetDataObject();
                                    DiffractionProfile[] dp = (DiffractionProfile[])data.GetData(typeof(DiffractionProfile[]));
                                    clipboard.ReleaseMutex();
                                    if (dp != null && dp.Length >= 1)
                                    {
                                        if (dp[0].Name.EndsWith("whole"))
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
                                                AddProfileToCheckedListBox(dp[dp.Length - 1], false, true);
                                                horizontalAxisUserControl_AxisPropertyChanged();
                                            }
                                        }
                                    }
                                }

                                else if ((Clipboard.GetDataObject()).GetDataPresent(typeof(Crystal2)) && formCrystal.Visible)
                                {
                                    IDataObject data = Clipboard.GetDataObject();
                                    var c2 = (Crystal2)data.GetData(typeof(Crystal2));
                                    formCrystal.crystalControl.Crystal = Crystal2.GetCrystal(c2);
                                    clipboard.ReleaseMutex();
                                }
                                else if ((Clipboard.GetDataObject()).GetDataPresent(typeof(MacroTriger)))
                                {
                                    MacroTriger trigger = (MacroTriger)Clipboard.GetDataObject().GetData(typeof(MacroTriger));
                                    clipboard.ReleaseMutex();
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
                                    clipboard.ReleaseMutex();
                                }
                                else
                                    clipboard.ReleaseMutex();

                            }
                            catch { MessageBox.Show("Failed to read clipboard information. Sorry."); }

                            if ((int)NextHandle != 0)
                                SendMessage(NextHandle, msg.Msg, msg.WParam, msg.LParam);
                        }
                        else//mutexを取るのに失敗していたら
                        {
                            resetClipboardViewer();
                        }
                        clipboard.Close();
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
        #endregion

        //ファイル更新監視ウォッチャー
        System.IO.FileSystemWatcher watcher;
        void watcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            if (e.FullPath.EndsWith("pdi"))
            {
                watcher.EnableRaisingEvents = false;
                do
                {
                    try
                    {
                        System.IO.FileStream fs = System.IO.File.Open(e.FullPath, System.IO.FileMode.Open);
                        fs.Close();
                        break;
                    }
                    catch { System.Threading.Thread.Sleep(100); }
                }
                while (true);

                readProfile(e.FullPath);
                watcher.EnableRaisingEvents = true;
            }
        }

        public string UserAppDataPath = new DirectoryInfo(Application.UserAppDataPath).Parent.FullName + @"\";

        #region フォームがロードまたはクローズしたとき
        //メインがロードされたときに実行
        private void FormMain_Load(object sender, System.EventArgs e)
        {
            if (this.DesignMode)
                return;

//#if !DEBUG
//            Ngen.Compile();
//#endif

            englishToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name != "ja";
            japaneseToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name == "ja";

            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\PDIndexer");
            if (regKey != null)
            {
                if ((int)regKey.GetValue("formMainLocationX", this.Location.X) >= 0)
                {
                    this.Width = (int)regKey.GetValue("formMainWidth", this.Width);
                    this.Height = (int)regKey.GetValue("formMainHeight", this.Height);
                    this.Location = new Point((int)regKey.GetValue("formMainLocationX", this.Location.X), (int)regKey.GetValue("formMainLocationY", this.Location.Y));
                }
            }

            initialDialog = new WaitDlg();
            initialDialog.ShowHints = false;
            initialDialog.Owner = this;
            initialDialog.Version = "PDIndexer  " + Version.VersionAndDate;
            initialDialog.Text = "Now Loading...";
            initialDialog.ShowVersion = true;
            initialDialog.Location = new Point(this.Location.X + this.Width / 2 - initialDialog.Width / 2, this.Location.Y + this.Height / 2 - initialDialog.Height / 2);
            if (Thread.CurrentThread.CurrentUICulture.ToString().Contains("ja"))
                initialDialog.Hint = Version.HintJa;
            else
                initialDialog.Hint = Version.HintEn;
              
            initialDialog.AutomaricallyClose = (string)regKey.GetValue("initialDialog.AutomaricallyClose", "True") == "True";
            initialDialog.Show();
            Application.DoEvents();

            initialDialog.Text = "Now Loading... Initializing 'Profile Parameter' form.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.1);
            formProfile = new FormProfileSetting();
            this.AddOwnedForm(formProfile);
            formProfile.formMain = this;
            formProfile.Visible = false;


            initialDialog.Text = "Now Loading... Initializing 'Crystal Parameter' form.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.25);
            formCrystal = new FormCrystal();
            this.AddOwnedForm(formCrystal);
            formCrystal.formMain = this;
            formCrystal.Visible = false;

            
            initialDialog.Text = "Now Loading... Initializing 'Equation of States' form.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.4);

            formEOS = new FormEOS();
            
            formEOS.formMain = this;
            formEOS.numericalTextBox_ValueChanged(new object(), new EventArgs());
            formEOS.Visible = false;
            this.AddOwnedForm(formEOS);

            initialDialog.Text = "Now Loading... Initializing 'Peak Fitting' form.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.45);
            formFitting = new FormFitting();
            this.AddOwnedForm(formFitting);
            formFitting.formMain = this;
            formFitting.Opacity = 0;
            formFitting.Visible=true;
            formFitting.Visible = false;
            formFitting.Opacity = 1;

            initialDialog.Text = "Now Loading... Initializing 'LPO' form.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.55);
            formLPO = new FormLPO();
            this.AddOwnedForm(formLPO);
            formLPO.formMain = this;
            formLPO.Visible = false;

            initialDialog.Text = "Now Loading... Initializing 'Cell Finder' form.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.65);
            formCellFinder = new FormCellFinder();
            this.AddOwnedForm(formCellFinder);
            formCellFinder.formMain = this;
            formCellFinder.Visible = false;

            initialDialog.Text = "Now Loading... Initializing 'Atomic Position Finder' form.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.75);
            formAtomicPositionFinder = new FormAtomicPositionFinder();
            this.AddOwnedForm(formAtomicPositionFinder);
            formAtomicPositionFinder.formMain = this;
            formAtomicPositionFinder.Visible = false;

            initialDialog.Text = "Now Loading... Initializing 'Stress Analysis' form.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.85);
            formStressAnalysis = new  FormStressAnalysis();
            this.AddOwnedForm(formStressAnalysis);
            formStressAnalysis.formMain = this;
            formStressAnalysis.Visible = false;

            initialDialog.Text = "Now Loading... Initializing '2θ calibration' form.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.87);
            formTwoThetaCalibration = new FormTwoThetaCalibration();
            this.AddOwnedForm(formTwoThetaCalibration);
            formTwoThetaCalibration.formMain = this;
            formStressAnalysis.Visible = false;


            initialDialog.Text = "Now Loading... Initializing 'Data Converter' form.";
            formDataConverter = new FormDataConverter();

            initialDialog.Text = "Now Loading... Initializing macro functions.";
            macro = new Macro(this);
            FormMacro = new FormMacro(Python.CreateEngine(), macro);
            FormMacro.Visible = false;

            this.Text = "PDIndexer   " + Version.VersionAndDate;
#if DEBUG
            this.Text += "(debug)";
#endif

            initialDialog.Text = "Now Loading... Reading default crystal lists.";
            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 0.90);

            //ユーザーパスにxmlファイルをコピー
            File.Copy("default.xml", UserAppDataPath + "initial.xml", true);
            if (!File.Exists(UserAppDataPath + "default.xml"))
                File.Copy("default.xml", UserAppDataPath + "default.xml", true);
            Directory.Delete(Application.UserAppDataPath, true);
            if (!File.Exists(UserAppDataPath + "PDIndexerSetup.msi"))
                File.Delete(UserAppDataPath + "PDIndexerSetup.msi");


            //結晶ファイル読み込み
            //  try { 
            readCrystal(UserAppDataPath + "default.Xml", false, true);
            //  }
            //  catch { }

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
            watcher = new System.IO.FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
            watcher.Created += new System.IO.FileSystemEventHandler(watcher_Created);
            watcher.Path = "";
            watcher.EnableRaisingEvents = false;

            initialDialog.progressBar.Value = (int)(initialDialog.progressBar.Maximum * 1.0);

            //SetRangeTextBox();

            initialDialog.Text = "Now Loading... Generating 'ReadMe.txt'.";


            /*ReadMeGenerator.WriteReadMeFile(
                "PDIndexer   " + Version.VersionAndDate,
                Version.Introduction,
                Version.Manual,
                Version.CopyRight,
                Version.Condition,
                Version.Exemption,
                Version.Adress,
                Version.Acknowledge,
                Version.History);
                */
            initialDialog.Text = "Now Loading... Initializing print function.";
            //プリント関係  
            printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);

            // PrintPreviewDialogオブジェクトの生成
            printPreviewDialog = new PrintPreviewDialog();
            // Documentプロパティの設定
            printPreviewDialog.Document = printDocument;

            initialDialog.Text = "Now Loading... Starting clipboard wather.";
            //クリップボード監視
            NextHandle = SetClipboardViewer(this.Handle);

            initialDialog.Text = "Now Loading... Bringing the main form to front.";
            pictureBoxMain.BringToFront();

            initialDialog.Text = "Now Loading... Reading registry.";
            ReadInitialRegistry();

            numericBoxUpperX.Value = 30;

            initialDialog.Text = "Now Loading... Reading registry.";
            if (dataGridViewCrystals.Columns.Count > 0)
            {
                dataGridViewCrystals_CellMouseClick(new object(), 
                    new DataGridViewCellMouseEventArgs(1, 2, 0, 0,new MouseEventArgs(MouseButtons.Left,1,0,0,0)));
                    //dataGridViewCrystals_CellContentClick(new object(), new DataGridViewCellEventArgs(1, 2));
            }

            //unrolled image関連
            comboBoxGradient.SelectedIndex = 1;
            comboBoxScale1.SelectedIndex = 1;
            comboBoxScale2.SelectedIndex = 0;

            initialDialog.Text = "Now Loading... Trying dummy mouse operation.";
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                programUpdatesToolStripMenuItem.Visible = false;//click onceの場合
                this.Text += "   Caution! ClickOnce vesion will be not maintained in the future.";
            }
            initialDialog.Text = "Initializing has been finished successfully. You can close this window.";
            if (initialDialog.AutomaricallyClose)
                initialDialog.Visible = false;

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerBlinkDiffraction.Stop();
            formFitting.Close();
            formCrystal.Close();
            formProfile.Close();
            formEOS.Close();
            e.Cancel = false;

            List<Crystal> cry = new List<Crystal>();
            for (int i = 0; i < dataSet.DataTableCrystal.Count; i++)
                cry.Add((Crystal)dataSet.DataTableCrystal.Items[i]);
            ConvertCrystalData.SaveCrystalListXml(cry.ToArray(), UserAppDataPath + "default.xml");

        }
        //フォームクローズ時
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //クリップボードを切る
            ChangeClipboardChain(this.Handle, NextHandle);
            if(!clearRegistryFlag)//Flagが立っていなければレジストリに書き込み
                SaveInitialRegistry();
        }
        #region レジストリ操作
        private void clearRegistryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.DeleteSubKey("Software\\Crystallography\\PDIndexer");
                clearRegistryFlag = true;
            }
            catch { MessageBox.Show("PDIndexerに関するRegistryは存在しません"); }
        }


        //レジストリの読み込み
        private void ReadInitialRegistry()
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\PDIndexer");
                if (regKey == null) return;

                if ((int)regKey.GetValue("formCrystalLocationX", this.formCrystal.Location.X) >= 0)
                {
                    this.formCrystal.Width = (int)regKey.GetValue("formCrystalWidth", this.formCrystal.Width);
                    this.formCrystal.Height = (int)regKey.GetValue("formCrystalHeight", this.formCrystal.Height);
                    this.formCrystal.Location = new Point((int)regKey.GetValue("formCrystalLocationX", this.formCrystal.Location.X),
                        (int)regKey.GetValue("formCrystalLocationY", this.formCrystal.Location.Y));
                }
                if ((int)regKey.GetValue("formEOSLocationY", this.formEOS.Location.Y) >= 0)
                {
                    this.formEOS.Width = (int)regKey.GetValue("formEOSWidth", this.formEOS.Width);
                    this.formEOS.Height = (int)regKey.GetValue("formEOSHeight", this.formEOS.Height);
                    this.formEOS.Location = new Point((int)regKey.GetValue("formEOSLocationX", this.formEOS.Location.X),
                        (int)regKey.GetValue("formEOSLocationY", this.formEOS.Location.Y));
                }
                if ((int)regKey.GetValue("formFittingLocationY", this.formFitting.Location.Y) >= 0)
                {
                    this.formFitting.Width = (int)regKey.GetValue("formFittingWidth", this.formFitting.Width);
                    this.formFitting.Height = (int)regKey.GetValue("formFittingHeight", this.formFitting.Height);
                    this.formFitting.Location = new Point((int)regKey.GetValue("formFittingLocationX", this.formFitting.Location.X),
                        (int)regKey.GetValue("formFittingLocationY", this.formFitting.Location.Y));
                }
                if ((int)regKey.GetValue("formProfileSettingLocationY", this.formProfile.Location.Y) >= 0)
                {
                    this.formProfile.Width = (int)regKey.GetValue("formProfileSettingWidth", this.formProfile.Width);
                    this.formProfile.Height = (int)regKey.GetValue("formProfileSettingHeight", this.formProfile.Height);
                    this.formProfile.Location = new Point((int)regKey.GetValue("formProfileSettingLocationX", this.formProfile.Location.X),
                    (int)regKey.GetValue("formProfileSettingLocationY", this.formProfile.Location.Y));
                }

                this.horizontalAxisUserControl.ElectronAccVoltageText = (string)regKey.GetValue("horizontalAxisUserControlElectronAccVoltageText", this.horizontalAxisUserControl.ElectronAccVoltageText);

                this.horizontalAxisUserControl.WaveLengthText = (string)regKey.GetValue("horizontalAxisUserControlWaveLengthText", this.horizontalAxisUserControl.WaveLengthText);
                this.horizontalAxisUserControl.TakeoffAngleText = (string)regKey.GetValue("horizontalAxisUserControlTakeoffAngleText", this.horizontalAxisUserControl.TakeoffAngleText);

                this.horizontalAxisUserControl.AxisMode = (HorizontalAxis)regKey.GetValue("horizontalAxisUserControlAxisMode", (int)this.horizontalAxisUserControl.AxisMode);
                this.horizontalAxisUserControl.WaveSource = (WaveSource)regKey.GetValue("horizontalAxisUserControl.WaveSource", (int)horizontalAxisUserControl.WaveSource);
                this.horizontalAxisUserControl.XrayWaveSourceElementNumber = (int)regKey.GetValue("horizontalAxisUserControlXrayWaveSourceElementNumber", (int)this.horizontalAxisUserControl.XrayWaveSourceElementNumber);
                this.horizontalAxisUserControl.XrayWaveSourceLine = (XrayLine)regKey.GetValue("horizontalAxisUserControlXrayWaveSourceLine", (int)this.horizontalAxisUserControl.XrayWaveSourceLine);


                this.numericalTextBoxIncreasingPixels.Text = (string)regKey.GetValue("numericalTextBoxIncreasingPixelsText", (string)this.numericalTextBoxIncreasingPixels.Text);
                if (numericalTextBoxIncreasingPixels.Value > 1)
                    numericUpDownIncreasingPixels.Value = (int)Math.Round(Math.Log(numericalTextBoxIncreasingPixels.Value, 2));
                else if (numericalTextBoxIncreasingPixels.Value >= 0.5)
                    numericUpDownIncreasingPixels.Value = -1;
                else if (numericalTextBoxIncreasingPixels.Value >= 0.1)
                    numericUpDownIncreasingPixels.Value = -2;
                else if (numericalTextBoxIncreasingPixels.Value >= 0.05)
                    numericUpDownIncreasingPixels.Value = -3;
                else if (numericalTextBoxIncreasingPixels.Value >= 0.01)
                    numericUpDownIncreasingPixels.Value = -4;
                else
                    numericUpDownIncreasingPixels.Value = -5;


                formCrystal.checkBoxShowPeakOverProfiles.Checked = (string)regKey.GetValue("formCrystal.checkBoxShowPeakOverProfiles.Checked", "True") == "True";
                formCrystal.checkBoxCalculateIntensity.Checked = (string)regKey.GetValue("formCrystal.checkBoxCalculateIntensity.Checked", "True") == "True";
                formCrystal.checkBoxVariableRatioOfIntensity.Checked = false;// (string)regKey.GetValue("formCrystal.checkBoxVariableRatioOfIntensity.Checked", "True") == "True";
                formCrystal.checkBoxShowPeakUnderProfile.Checked = (string)regKey.GetValue("formCrystal.checkBoxShowPeakUnderProfile.Checked", "False") == "True";
                formCrystal.radioButtonAllCheckedCrystals.Checked = (string)regKey.GetValue("formCrystal.radioButtonAllCheckedCrystals.Checked", "True") == "True";
                formCrystal.numericUpDownHeightOfBottomPeak.Value = Convert.ToDecimal(regKey.GetValue("formCrystal.numericUpDownHeightOfBottomPeak.Value", formCrystal.numericUpDownHeightOfBottomPeak.Value.ToString()));

                this.initialDirectory = (string)regKey.GetValue("initialDirectory", "");
                this.filterIndex = (int)regKey.GetValue("filterIndex", 0);

                colorControlBack.Color = Color.FromArgb((int)regKey.GetValue("colorControlBack.Color", colorControlBack.Color.ToArgb()));
                colorControlScaleLine.Color = Color.FromArgb((int)regKey.GetValue("colorControlScaleLine.Color", colorControlScaleLine.Color.ToArgb()));
                colorControlScaleText.Color = Color.FromArgb((int)regKey.GetValue("colorControlScaleText.Color", colorControlScaleText.Color.ToArgb()));

                FormMacro.ZippedMacros = (byte[])regKey.GetValue("Macro", new byte[0]);


                //ここからファイルタイプごとのパラメータ読み込み
                for (int i = 0; i < Enum.GetValues(typeof(FileType)).Length; i++)
                {
                    FileProperties[i].Valid = (string)regKey.GetValue("FileProperty.Valid" + i.ToString(), "False") == "True";

                    FileProperties[i].WaveSource = (WaveSource)Convert.ToInt32(regKey.GetValue("FileProperty.WaveSource" + i.ToString(), 0));
                    FileProperties[i].WaveColor = (WaveColor)Convert.ToInt32(regKey.GetValue("FileProperty.WaveColor" + i.ToString(), 0));
                    FileProperties[i].Wavelength = Convert.ToDouble((string)regKey.GetValue("FileProperty.Wavelength" + i.ToString(), "0"));
                    FileProperties[i].TakeoffAngle = Convert.ToDouble((string)regKey.GetValue("FileProperty.TakeoffAngle" + i.ToString(), "0"));

                    FileProperties[i].AxisMode = (HorizontalAxis)Convert.ToInt32(regKey.GetValue("FileProperty.AxisMode" + i.ToString(), 0));

                    FileProperties[i].XraySourceElementNumber = Convert.ToInt32(regKey.GetValue("FileProperty.XraySourceElementNumber" + i.ToString(), 0));
                    FileProperties[i].XrayLine = (XrayLine)Convert.ToInt32(regKey.GetValue("FileProperty.XrayLine" + i.ToString(), 0));

                    FileProperties[i].TofAngle = Convert.ToDouble((string)regKey.GetValue("FileProperty.TofAngle" + i.ToString(), "0"));
                    FileProperties[i].TofLength = Convert.ToDouble((string)regKey.GetValue("FileProperty.TofLength" + i.ToString(), "0"));

                    FileProperties[i].EGC0 = Convert.ToDouble((string)regKey.GetValue("FileProperty.EGC0" + i.ToString(), "0"));
                    FileProperties[i].EGC1 = Convert.ToDouble((string)regKey.GetValue("FileProperty.EGC1" + i.ToString(), "0"));
                    FileProperties[i].EGC2 = Convert.ToDouble((string)regKey.GetValue("FileProperty.EGC2" + i.ToString(), "0"));

                    FileProperties[i].ExposureTime = Convert.ToDouble((string)regKey.GetValue("FileProperty.ExposureTime" + i.ToString(), "1"));
                }
                #region  レジストリが存在しなかった場合あるいは無効な場合には、初期化
                var m = (int)FileType.CSV;
                if(!FileProperties[m].Valid)
                {
                    FileProperties[m].Valid = true;
                    FileProperties[m].WaveSource =  WaveSource.Xray;
                    FileProperties[m].WaveColor =  WaveColor.Monochrome;
                    FileProperties[m].Wavelength = 0.4;
                    FileProperties[m].AxisMode =  HorizontalAxis.Angle;
                }

                m = (int)FileType.RAS;
                if (!FileProperties[m].Valid)
                {
                    FileProperties[m].Valid = true;
                    FileProperties[m].WaveSource = WaveSource.Xray;
                    FileProperties[m].WaveColor = WaveColor.Monochrome;
                    FileProperties[m].AxisMode = HorizontalAxis.Angle;
                    FileProperties[m].XraySourceElementNumber = 29;
                    FileProperties[m].XrayLine = XrayLine.Ka1;
                }

                m = (int)FileType.NXS;
                if (!FileProperties[m].Valid)
                {
                    FileProperties[m].Valid = true;
                    FileProperties[m].WaveSource = WaveSource.Xray;
                    FileProperties[m].WaveColor = WaveColor.FlatWhite;
                    FileProperties[m].TakeoffAngle = 4.95/180*Math.PI;
                    FileProperties[m].AxisMode = HorizontalAxis.EnergyXray;
                    FileProperties[m].EGC1 = 66.6;
                }

                #endregion


                regKey.Close();
            }
            catch { }
        }

        //.iniファイルを書き込み
        private void SaveInitialRegistry()
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\PDIndexer");
            if (regKey == null) return;

            regKey.SetValue("Culture", Thread.CurrentThread.CurrentUICulture.Name);
            
            regKey.SetValue("formMainWidth", this.Width);
            regKey.SetValue("formMainHeight", this.Height);
            regKey.SetValue("formMainLocationX", this.Location.X);
            regKey.SetValue("formMainLocationY", this.Location.Y);
            regKey.SetValue("formCrystalWidth", this.formCrystal.Width);
            regKey.SetValue("formCrystalHeight", this.formCrystal.Height);
            regKey.SetValue("formCrystalLocationX", this.formCrystal.Location.X);
            regKey.SetValue("formCrystalLocationY", this.formCrystal.Location.Y);
            regKey.SetValue("formEOSWidth", this.formEOS.Width);
            regKey.SetValue("formEOSHeight", this.formEOS.Height);
            regKey.SetValue("formEOSLocationX", this.formEOS.Location.X);
            regKey.SetValue("formEOSLocationY", this.formEOS.Location.Y);
            regKey.SetValue("formFittingWidth", this.formFitting.Width);
            regKey.SetValue("formFittingHeight", this.formFitting.Height);
            regKey.SetValue("formFittingLocationX", this.formFitting.Location.X);
            regKey.SetValue("formFittingLocationY", this.formFitting.Location.Y);
            regKey.SetValue("formProfileSettingWidth", this.formProfile.Width);
            regKey.SetValue("formProfileSettingHeight", this.formProfile.Height);
            regKey.SetValue("formProfileSettingLocationX", this.formProfile.Location.X);
            regKey.SetValue("formProfileSettingLocationY", this.formProfile.Location.Y);

            regKey.SetValue("horizontalAxisUserControlWaveLengthText", this.horizontalAxisUserControl.WaveLengthText);
            regKey.SetValue("horizontalAxisUserControlTakeoffAngleText", this.horizontalAxisUserControl.TakeoffAngleText);


            regKey.SetValue("horizontalAxisUserControlAxisModeInt", (int)this.horizontalAxisUserControl.AxisMode);
            regKey.SetValue("horizontalAxisUserControl.WaveSource", (int)horizontalAxisUserControl.WaveSource);
            regKey.SetValue("horizontalAxisUserControlXrayWaveSourceElementNumber", (int)this.horizontalAxisUserControl.XrayWaveSourceElementNumber);
            regKey.SetValue("horizontalAxisUserControlXrayWaveSourceLine", (int)this.horizontalAxisUserControl.XrayWaveSourceLine);

            regKey.SetValue("horizontalAxisUserControlElectronAccVoltageText", this.horizontalAxisUserControl.ElectronAccVoltageText);

            regKey.SetValue("numericalTextBoxIncreasingPixelsText", this.numericalTextBoxIncreasingPixels.Text);

            regKey.SetValue("formCrystal.checkBoxShowPeakOverProfiles.Checked", formCrystal.checkBoxShowPeakOverProfiles.Checked);
            regKey.SetValue("formCrystal.checkBoxCalculateIntensity.Checked", formCrystal.checkBoxCalculateIntensity.Checked);
            regKey.SetValue("formCrystal.checkBoxVariableRatioOfIntensity.Checked", formCrystal.checkBoxVariableRatioOfIntensity.Checked);
            regKey.SetValue("formCrystal.checkBoxShowPeakUnderProfile.Checked", formCrystal.checkBoxShowPeakUnderProfile.Checked);
            regKey.SetValue("formCrystal.radioButtonAllCheckedCrystals.Checked", formCrystal.radioButtonAllCheckedCrystals.Checked);
            regKey.SetValue("formCrystal.numericUpDownHeightOfBottomPeak.Value", formCrystal.numericUpDownHeightOfBottomPeak.Value);

            regKey.SetValue("initialDirectory", initialDirectory);
            regKey.SetValue("filterIndex", filterIndex);

            regKey.SetValue("initialDialog.AutomaricallyClose", initialDialog.AutomaricallyClose);

            regKey.SetValue("colorControlBack.Color", colorControlBack.Color.ToArgb());
            regKey.SetValue("colorControlScaleLine.Color", colorControlScaleLine.Color.ToArgb());
            regKey.SetValue("colorControlScaleText.Color", colorControlScaleText.Color.ToArgb());

            regKey.SetValue("Macro", FormMacro.ZippedMacros);



            //ここからファイルタイプごとのパラメータ読み込み
            for (int i = 0; i < Enum.GetValues(typeof(FileType)).Length; i++)
            {
                regKey.SetValue("FileProperty.Valid" + i.ToString(), true);
                regKey.SetValue("FileProperty.WaveSource" + i.ToString(), (int)(FileProperties[i].WaveSource));
                regKey.SetValue("FileProperty.WaveColor" + i.ToString(), (int)(FileProperties[i].WaveColor));
                regKey.SetValue("FileProperty.Wavelength" + i.ToString(), FileProperties[i].Wavelength);
                regKey.SetValue("FileProperty.TakeoffAngle" + i.ToString(), FileProperties[i].TakeoffAngle);
                regKey.SetValue("FileProperty.AxisMode" + i.ToString(), (int)(FileProperties[i].AxisMode));
                regKey.SetValue("FileProperty.XraySourceElementNumber" + i.ToString(), FileProperties[i].XraySourceElementNumber);
                regKey.SetValue("FileProperty.XrayLine" + i.ToString(), (int)(FileProperties[i].XrayLine));
                regKey.SetValue("FileProperty.TofAngle" + i.ToString(), FileProperties[i].TofAngle);
                regKey.SetValue("FileProperty.TofLength" + i.ToString(), FileProperties[i].TofLength);
                regKey.SetValue("FileProperty.ExposureTime" + i.ToString(), FileProperties[i].ExposureTime);
                regKey.SetValue("FileProperty.EGC0" + i.ToString(), FileProperties[i].EGC0);
                regKey.SetValue("FileProperty.EGC1" + i.ToString(), FileProperties[i].EGC1);
                regKey.SetValue("FileProperty.EGC2" + i.ToString(), FileProperties[i].EGC2);
            }

            regKey.Close();
        }

        
        #endregion

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
                DiffractionProfile diffProf = (DiffractionProfile)dataSet.DataTableProfile.Items[n];
                if (diffProf.Profile.Pt.Count > 2)
                {
                    if (minimalX > diffProf.Profile.Pt[0].X)
                        minimalX = diffProf.Profile.Pt[0].X;
                    if (maximalX < diffProf.Profile.Pt[diffProf.Profile.Pt.Count - 1].X)
                        maximalX = diffProf.Profile.Pt[diffProf.Profile.Pt.Count - 1].X;
                    for (int i = 0; i < diffProf.Profile.Pt.Count; i++)
                    {
                        minimalY = Math.Min(minimalY, diffProf.Profile.Pt[i].Y + n * IntervalOfProfiles);
                        maximalY = Math.Max(maximalY, diffProf.Profile.Pt[i].Y + n * IntervalOfProfiles);
                    }
                }
            }
            if (double.IsInfinity(MinimalX)) return;

            MinimalX = minimalX;
            MaximalX = maximalX;
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
        public void Draw()
        {
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

            FormPrintOption formPrintOption = new FormPrintOption();

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
                        Font font = new Font("Tahoma", 8);
                        //まず字の最大長さ(pixel)を求める
                        SizeF maxSizeF = new SizeF(0, 0);
                        for (int i = dataSet.DataTableProfile.CheckedItems.Count - 1; i >= 0; i--)
                        {
                            maxSizeF.Width = Math.Max(maxSizeF.Width, gMain.MeasureString(dataSet.DataTableProfile.CheckedItems[i].ToString(), font).Width);
                            maxSizeF.Height = Math.Max(maxSizeF.Height, gMain.MeasureString(dataSet.DataTableProfile.CheckedItems[i].ToString(), font).Height);
                        }
                        PointF startPosition = new Point(0, 0);
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
                                font, new SolidBrush(Color.FromArgb(((DiffractionProfile)dataSet.DataTableProfile.CheckedItems[i]).ColorARGB.Value)),
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
                    DiffractionProfile dif = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                    if (dif.ImageArray != null)
                    {
                        Bitmap bmp = new Bitmap(pictureBoxMain.Width - OriginPos.X, pictureBoxMain.Height - OriginPos.Y, PixelFormat.Format24bppRgb);

                        //bmpをロック
                        BitmapData bmpData;
                        try { bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); }
                        catch { return; }
                        int width = bmp.Width;
                        int height = bmp.Height;
                        byte* p = (byte*)(void*)bmpData.Scan0;
                        int nResidual = bmpData.Stride - bmp.Width * 3;

                        double endX = dif.Profile.Pt[dif.Profile.Pt.Count - 1].X;
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

                                    p[0] = scaleB[index];
                                    p[1] = scaleG[index];
                                    p[2] = scaleR[index];
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
                    if(startX>OriginPos.X)
                    gMain.DrawLine(pen, startX, top, startX, zero);
                    if (endX > OriginPos.X)
                    gMain.DrawLine(pen, endX, top, endX, zero);
                    gMain.FillRectangle(b, Math.Max(startX, OriginPos.X), top, endX - Math.Max(startX, OriginPos.X), zero - top);

                    DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                    List<PointF> original = new List<PointF>();
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
                    endX = ConvToPicBoxCoord(dp.Profile.Pt[Math.Min(endIndex + dp.InterpolationPoints, dp.Profile.Pt.Count-1)].X, 0).X;
                    gMain.FillRectangle(b, Math.Max(startX, OriginPos.X), top, endX - Math.Max(startX, OriginPos.X), zero - top);


                    pen = new Pen(Color.FromArgb(128, Color.FromArgb((int)dp.ColorARGB)), 1);
                    pen.DashStyle = DashStyle.Dash;
                    if (original.Count > 1)
                        gMain.DrawLines(pen, original.ToArray());
                }
            }
            
        }

        //プロファイルの描画
        private void DrawProfile()
        {
            var rect = new RectangleD(LowerX, LowerY, UpperX - LowerX, UpperY - LowerY);
            for (int j = 0; j < dataSet.DataTableProfile.CheckedItems.Count; j++)
            {
                DiffractionProfile dp = dataSet.DataTableProfile.CheckedItems[j];
                PointD[] pt = dp.Profile.Pt.Select(p=> new PointD(p.X,p.Y + IntervalOfProfiles * j)).ToArray();
                if (pt.Length > 2)
                {
                    Pen pen = new Pen(Color.FromArgb(((DiffractionProfile)dataSet.DataTableProfile.CheckedItems[j]).ColorARGB.Value), ((DiffractionProfile)dataSet.DataTableProfile.CheckedItems[j]).LineWidth);
                    pen.LineJoin = LineJoin.Round;
                    foreach(var pts in Geometriy.GetPointsWithinRectangle(pt, rect))
                        if(pts.Count() > 1)
                            gMain.DrawLines(pen, pts.Select(p => ConvToPicBoxCoord(p)).ToArray());

                    //エラーバー描画
                    if (checkBoxErrorBar.Checked && dp.OriginalProfile.Err != null && dp.OriginalProfile.Err.Count == dp.Profile.Pt.Count)
                    {
                        Pen penErr = new Pen(Color.FromArgb((int)(pen.Color.R * 0.5), (int)(pen.Color.G * 0.5), (int)(pen.Color.B * 0.5)), pen.Width);
                        float errbarWidth = Math.Abs(ConvToPicBoxCoord(pt[0]).X - ConvToPicBoxCoord(pt[1]).X) / 4;
                        for (int i = 0; i < pt.Length; i++)
                            if (!double.IsNaN(dp.OriginalProfile.Err[i].Y) && rect.IsInsde(pt[i]))
                            {
                                PointF maxErr = ConvToPicBoxCoord(pt[i].X, pt[i].Y + dp.OriginalProfile.Err[i].Y);
                                PointF minErr = ConvToPicBoxCoord(pt[i].X, pt[i].Y - dp.OriginalProfile.Err[i].Y);
                                gMain.DrawLine(penErr, maxErr, minErr);
                                gMain.DrawLine(penErr, new PointF(maxErr.X + errbarWidth, maxErr.Y), new PointF(maxErr.X - errbarWidth, maxErr.Y));
                                gMain.DrawLine(penErr, new PointF(minErr.X + errbarWidth, minErr.Y), new PointF(minErr.X - errbarWidth, minErr.Y));
                            }
                    }

                
                }
            }
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
                DiffractionProfile dp = (DiffractionProfile)dataSet.DataTableProfile.Items[bindingSourceProfile.Position];
                if (dp.SubtractBackground && ShowBackgroundProfile)
                {
                    Color color = Color.FromArgb(dp.ColorARGB.Value);
                    Pen pen = new Pen(Color.FromArgb((255 - (int)((255 - color.R) * 0.5)), (255 - (int)((255 - color.G) * 0.5)), (255 - (int)((255 - color.B) * 0.5))), 1);

                    PointD[] pt;
                    if (BackGroundPointSelectMode)
                    {

                        pt = dp.ConvertSrcToDest(dp.BgPoints);
                        for (int i = 0; i < pt.Length; i++)
                        {
                           PointF p=  ConvToPicBoxCoord(pt[i]);
                            if (p.X > minX - 0.1 && p.X < maxX + 0.1 && p.Y > minY - 0.1 && p.Y < maxY + 0.1)//範囲内であれば
                                gMain.FillEllipse(new SolidBrush(color), p.X - 5, p.Y - 5, 10, 10);
                        }
                    }
                    pt = dp.BackgroundProfile.Pt.ToArray();
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
            Pen pen = new Pen(Brushes.Silver);

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
                            if (AxisMode == HorizontalAxis.Angle)
                                cry.Plane[j].XCalc = (2 * Math.Asin(WaveLength / 2 / cry.Plane[j].d) / Math.PI * 180);
                            else if (AxisMode == HorizontalAxis.d)
                                cry.Plane[j].XCalc = cry.Plane[j].d * 10;
                            else if (AxisMode == HorizontalAxis.EnergyXray)
                                cry.Plane[j].XCalc = HorizontalAxisConverter.DToXrayEnergy(cry.Plane[j].d, TakeoffAngle);
                            else if (AxisMode == HorizontalAxis.EnergyElectron)
                                cry.Plane[j].XCalc = HorizontalAxisConverter.DToElectronEnergy(cry.Plane[j].d, TakeoffAngle);
                            else if (AxisMode == HorizontalAxis.EnergyNeutron)
                                cry.Plane[j].XCalc = HorizontalAxisConverter.DToNeutronEnergy(cry.Plane[j].d, TakeoffAngle);
                            else if (AxisMode == HorizontalAxis.NeutronTOF)
                                cry.Plane[j].XCalc = HorizontalAxisConverter.DToTOF(cry.Plane[j].d, TofAngle, TofLength);
                            else if (AxisMode == HorizontalAxis.WaveNumber)
                                cry.Plane[j].XCalc = HorizontalAxisConverter.DToWaveNumber(cry.Plane[j].d) / 10.0;

                            if (cry.Plane[j].XCalc > LowerX && cry.Plane[j].XCalc < UpperX)
                            {
                                //ここから線の部分
                                if (i == bindingSourceCrystal.Position)
                                    pen = new Pen(Color.FromArgb(cry.Argb), j == SelectedPlaneIndex ? 5f : 3f);
                                else
                                    pen = new Pen(Color.FromArgb(cry.Argb), 1f);

                                if (!double.IsNaN(cry.Plane[j].XCalc))
                                {
                                    if (!formCrystal.checkBoxInvisibleWeakPeak.Checked || (double)formCrystal.numericUpDownThresholdIntesity.Value * 0.01 < cry.Plane[j].Intensity)
                                    {
                                        if (formCrystal.checkBoxShowPeakOverProfiles.Checked)
                                        {
                                            float zero;//描画範囲の最低強度位置のピクセル
                                            if (formCrystal.checkBoxShowPeakUnderProfile.Checked)
                                                zero = pictureBoxMain.Height - OriginPos.Y - dataSet.DataTableCrystal.CheckedItems.Count * (HeightOfBottomPeaks + 4);
                                            else
                                                zero = pictureBoxMain.Height - OriginPos.Y;

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

            DiffractionProfile dp = (DiffractionProfile)dataSet.DataTableProfile.Rows[bindingSourceProfile.Position][1];

            Color color = Color.FromArgb(dp.ColorARGB.Value);
            Pen penSubtraction = new Pen(Color.FromArgb((255 - (int)((255 - color.R) * 0.3)), (255 - (int)((255 - color.G) * 0.3)), (255 - (int)((255 - color.B) * 0.3))), dp.LineWidth);
            penSubtraction.LineJoin = LineJoin.Round;


            List<Plane> planeList = new List<Plane>();

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

            if (planeList2.Length != 0)
            {
                for (int i = 0; i < planeList2.Length; i++)
                    planeList2[i].peakFunction.RenewParameter();

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
                        {
                            try
                            {
                                gMain.DrawLines(penSubtraction, subtraction.ToArray());
                            }
                            catch { }
                        }
                        if (background.Count > 1)
                            gMain.DrawLines(penSubtraction, background.ToArray());

                        //個々のフィッティングカーブを描く
                        foreach (Plane p in planeList3)
                        {
                            try
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
                            catch { }

                        }
                    }
                }

            }
        }

        //目盛りを描画する部分
        private void DrawGradiation()
        {
            if (UpperX - LowerX <= 0) return;

            double AngleGradiation = 1;//ここより角度目盛りの描画
            double d = (UpperX - LowerX);
            int maxDivisionNumber = (pictureBoxMain.Width ) / (d > 0.1 ? 40 : 60) + 1;
            if (maxDivisionNumber < 1 || double.IsNaN(maxDivisionNumber)) return;
            double unit = Math.Pow(10, Math.Floor(Math.Log10(d / maxDivisionNumber)));

            if (d / unit < maxDivisionNumber) AngleGradiation = unit;
            else if (d / unit / 2 < maxDivisionNumber) AngleGradiation = unit * 2;
            else if (d / unit / 5 < maxDivisionNumber) AngleGradiation = unit * 5;
            else  AngleGradiation = unit * 10;

            string format = "0.";
            int decimalPlaces = AngleGradiation>=1 ? 0 : Math.Abs((int)Math.Floor((Math.Log10(AngleGradiation))));
            for (int i = 0; i < decimalPlaces; i++) format += "0";


            Pen pen = new Pen(colorControlScaleLine.Color, 1);

            gMain.DrawLine(pen, OriginPos.X, pictureBoxMain.Height - OriginPos.Y, pictureBoxMain.Width, pictureBoxMain.Height - OriginPos.Y);
            Font strFont = new Font(new FontFamily("tahoma"), 8);
            for (int i = (int)(LowerX / AngleGradiation) + 1; i < UpperX / AngleGradiation; i++)
            {
                pen = new Pen(colorControlScaleLine.Color, 1);
                float x = ConvToPicBoxCoord(i * AngleGradiation, 0).X;
                if (x > pictureBoxMain.Width || x < 0) break;
                gMain.DrawLine(pen, x, pictureBoxMain.Height - OriginPos.Y, x, pictureBoxMain.Height - OriginPos.Y + 5);
                if (i * AngleGradiation > 1000)
                    format = "#," + format;
                gMain.DrawString(Math.Round(i * AngleGradiation, 5).ToString(format), strFont, colorControlScaleText.SolidBrush, x - 2, pictureBoxMain.Height - OriginPos.Y + 5);
                pen = new Pen(colorControlScaleLine.Color, 1);
                if (checkBoxShowScaleLine.Checked)
                    gMain.DrawLine(pen, ConvToPicBoxCoord(i * AngleGradiation, 0).X, pictureBoxMain.Height - OriginPos.Y, x, 0);
            }

            double IntensityGradiation=1;//ここより強度目盛りの描画

            d = (UpperY - LowerY);
            maxDivisionNumber = (pictureBoxMain.Height-20) / 30 + 1;
            if (maxDivisionNumber < 1 || double.IsNaN(maxDivisionNumber)) return;
            unit = Math.Pow(10, Math.Floor(Math.Log10(d / maxDivisionNumber)));

            if (d / unit < maxDivisionNumber) IntensityGradiation = unit;
            else if (d / unit / 2 < maxDivisionNumber) IntensityGradiation = unit * 2;
            else if (d / unit / 5 < maxDivisionNumber) IntensityGradiation = unit * 5;
            else  IntensityGradiation = unit * 10;

            decimalPlaces =IntensityGradiation>=1 ? 0 :　 Math.Abs((int)Math.Floor((Math.Log10(IntensityGradiation))));
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
                if(i * IntensityGradiation>1000)
                    format = "#," + format;
                gMain.DrawString((i * IntensityGradiation).ToString(format), strFont, colorControlScaleText.SolidBrush, 0, y - 6);
                pen = new Pen(colorControlScaleLine.Color, 1);
                if (checkBoxShowScaleLine.Checked)
                    gMain.DrawLine(pen, OriginPos.X - 8, y, pictureBoxMain.Width, y);


            }
        }
        #endregion

        //各結晶の描画範囲内の回折線の位置計算
        public void InitializeCrystalPlane()
        {
            double dMin = 1, dMax = 1;
            if (AxisMode == HorizontalAxis.Angle)
            {
                dMin = WaveLength / 2 / Math.Sin(MaximalX / 360 * Math.PI);
                dMax = WaveLength / 2 / Math.Sin(MinimalX / 360 * Math.PI);
            }
            else if (AxisMode == HorizontalAxis.d)
            {
                dMax = MaximalX / 10;
                dMin = Math.Max(MinimalX / 10, 0.05);
            }
            else if (AxisMode == HorizontalAxis.EnergyXray)
            {
                dMax = HorizontalAxisConverter.XrayEnergyToD(MinimalX, TakeoffAngle);
                dMin = HorizontalAxisConverter.XrayEnergyToD(MaximalX, TakeoffAngle);
                if (dMax < 0)
                    dMax = 1000;

            }
            else if (AxisMode == HorizontalAxis.EnergyElectron)
            {
                dMax = HorizontalAxisConverter.ElectronEnergyToD(MinimalX, TakeoffAngle);
                dMin = HorizontalAxisConverter.ElectronEnergyToD(MaximalX, TakeoffAngle);

            }
            else if (AxisMode == HorizontalAxis.EnergyNeutron)
            {
                dMax = HorizontalAxisConverter.NeutronEnergyToD(MinimalX, TakeoffAngle);
                dMin = HorizontalAxisConverter.NeutronEnergyToD(MaximalX, TakeoffAngle);

            }
            else if (AxisMode == HorizontalAxis.NeutronTOF)
            {
                dMax = HorizontalAxisConverter.NeutronTofToD(MaximalX, TofAngle, TofLength);
                dMin = Math.Max(HorizontalAxisConverter.NeutronTofToD(MinimalX, TofAngle, TofLength), 0.02);
            }
            else if (AxisMode == HorizontalAxis.WaveNumber)
            {
                dMax = HorizontalAxisConverter.WaveNumberToD(MinimalX * 10);
                dMin = HorizontalAxisConverter.WaveNumberToD(MaximalX * 10);

            }

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

        //pictureBoxの再描画時に呼び出される
        private void pictureBoxMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (MouseRangingMode)
            {
                Pen pen = new Pen(Brushes.Gray);
                pen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, Math.Min(mouseRangeStart.X, mouseRangeEnd.X), Math.Min(mouseRangeStart.Y, mouseRangeEnd.Y),
                    Math.Abs(mouseRangeStart.X - mouseRangeEnd.X), Math.Abs(mouseRangeStart.Y - mouseRangeEnd.Y));
            }
        }


        #region 座標変換関係
        private PointF ConvToPicBoxCoord(double x, double y)
        {//プロファイル座標をピクチャーボックスの座標系に変換
            return new PointF(
                (float)((pictureBoxMain.Width - OriginPos.X) / (UpperX - LowerX) * (x - LowerX)) + OriginPos.X,
                (float)(pictureBoxMain.Height - OriginPos.Y - BottomMargin - (pictureBoxMain.Height - OriginPos.Y - BottomMargin) / (UpperY - LowerY) * (y - LowerY)));
        }
        private PointF ConvToPicBoxCoord(PointD p)
        {//プロファイル座標をピクチャーボックスの座標系に変換
            return new PointF((float)((pictureBoxMain.Width - OriginPos.X) / (UpperX - LowerX) * (p.X - LowerX)) + OriginPos.X,
                (float)(pictureBoxMain.Height - OriginPos.Y - BottomMargin - (pictureBoxMain.Height - OriginPos.Y - BottomMargin) / (UpperY - LowerY) * (p.Y - LowerY)));
        }
        private PointD ConvToRealCoord(int x, int y)
        {//ピクチャーボックスの座標系をプロファイル座標に変換
            return new PointD(
                (double)(x - OriginPos.X) / (pictureBoxMain.Width - OriginPos.X) * (UpperX - LowerX) + LowerX,
                (double)(pictureBoxMain.Height - y - OriginPos.Y - BottomMargin) / (pictureBoxMain.Height - OriginPos.Y - BottomMargin) * (UpperY - LowerY) + LowerY);
        }
        private PointD ConvToDspacing(PointD pt)
        {//プロファイル座標の横軸をd値に変換( 縦軸はそのまま)
            if (AxisMode == HorizontalAxis.Angle)
                pt.X = WaveLength / 2 / Math.Sin(pt.X / 360 * Math.PI);
            else if (AxisMode == HorizontalAxis.EnergyXray)
                pt.X = HorizontalAxisConverter.XrayEnergyToD(pt.X, TakeoffAngle);
            else if (AxisMode == HorizontalAxis.NeutronTOF)
                pt.X = HorizontalAxisConverter.NeutronTofToD(pt.X, TofAngle, TofLength);
            else if (AxisMode == HorizontalAxis.d)
                pt.X = pt.X / 10;
            return pt;
        }

        #endregion

        #region マウス操作
        //マウスボタンが押されたとき
        private void pictureBoxMain_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pictureBoxMain.Focus();
            PointD pt = ConvToRealCoord(e.X, e.Y);
            if (ShowBackgroundProfile && BackGroundPointSelectMode && formProfile.Visible)//Bg点モードのとき
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2 && bindingSourceProfile.Position >= 0)
                {//左ダブルクリックのときはBg点追加
                    DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                    dp.AddBgPoints(pt);
                    dp.SetBackGroundProfile();
                    Draw();
                }
                else if (e.Button == MouseButtons.Left && e.Clicks == 1 && bindingSourceProfile.Position >= 0)
                { //左シングルクリックのときBg点選択
                    DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
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
                    DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
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

            //Diffractionモード
            else if (e.Button == MouseButtons.Left && e.Clicks == 1 && SelectedCrysatlIndex > 0)
            {
                Crystal cry = (Crystal)((DataRowView)bindingSourceCrystal.Current).Row[1];
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
            else if (SelectedCrysatlIndex == 0 && dataSet.DataTableCrystal.GetItemChecked(0))//flexibleCrystalを選択時
            {
                Crystal cry = (Crystal)((DataRowView)bindingSourceCrystal.Current).Row[1];
                if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    int i;
                    double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
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
                if (e.Button == MouseButtons.Left && e.Clicks == 2)//何もないところでダブルクリックした場合
                {
                    PointD tempPt = ConvToDspacing(pt);
                    Plane p = new Plane();
                    p.d = tempPt.X;
                    p.SerchOption = PeakFunctionForm.PseudoVoigt;
                    cry.Plane.Add(p);
                    cry.Plane.Sort();
                    Draw();
                    return;
                }
                if (e.Button == MouseButtons.Right & e.Clicks == 1)
                {
                    double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
                    int i = SearchPlaneNo(pt.X, cry, dev);//強度計算していない場合
                    if (i >= 0)
                    {
                        cry.Plane.RemoveAt(i);
                        cry.Plane.Sort();
                        Draw();
                        return;
                    }
                }
                //formFitting.SetCheckedListBoxPlanes(false);
                Draw();
                formFitting.ChangeCrystalFromMainForm();
            }

            if (e.Button == MouseButtons.Middle)
            {
                MouseMovingMode = true;
                mouseMovingStartPt = pt;
                pictureBoxMain.Cursor = Cursors.SizeAll;
                return;
            }
            
            if (e.Button == MouseButtons.Right)
            {
                MouseRangingMode = true;
                mouseRangeStart = new Point(e.X, e.Y);
                mouseRangeEnd = new Point(e.X, e.Y);
                return;
            }

            if (MaskingMode && formProfile.Visible && formProfile.checkBoxShowMaskedRange.Checked && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
                int[] i = SearchMaskBoundary(pt.X, formProfile.GetMaskRanges(), dev);//強度計算していない場合
                if (i[0] < 0)
                {
                    double x = ConvToRealCoord(e.X, 0).X;
                    formProfile.AddMaskRange(new DiffractionProfile.MaskingRange(x, x));
                    formProfile.SortMaskRanges();
                    i = SearchMaskBoundary(pt.X, formProfile.GetMaskRanges(), dev);
                }
                if (i[0] >= 0)
                    SelectedMaskingBoundaryIndex = i;
                formProfile.SelectedMaskIndex = selectedMaskingBoundaryIndex[0];
            }
        }


        //マウスの右クリックを連打して描画範囲を広げる時のカウンター
        int rightClickCounter = 0;
        Stopwatch rightClickStopWatch = new Stopwatch();

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
                SetFormCrystal(true);
                //SetFormFitting();
                formFitting.ChangeCrystalFromMainForm();

                Draw();
            }

            IsPlaneSelected = false;
            IsBgPtSelected = false;
            MouseMovingMode = false;

            if (MaskingMode)
            {
                if (selectedMaskingBoundaryIndex[0] >= 0)
                {
                    var ranges = formProfile.GetMaskRanges();
                    if (ranges[selectedMaskingBoundaryIndex[0]].Maximum == ranges[selectedMaskingBoundaryIndex[0]].Minimum)
                        formProfile.DeleteMaskRange(selectedMaskingBoundaryIndex[0]);
                }
                selectedMaskingBoundaryIndex = new int[] { -1, -1 };
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
                    double xmax = ConvToRealCoord(Math.Max(mouseRangeStart.X, mouseRangeEnd.X), 1).X;
                    double xmin = ConvToRealCoord(Math.Min(mouseRangeStart.X, mouseRangeEnd.X), 1).X;
                    double ymin = ConvToRealCoord(1, Math.Max(mouseRangeStart.Y, mouseRangeEnd.Y)).Y;
                    double ymax = ConvToRealCoord(1, Math.Min(mouseRangeStart.Y, mouseRangeEnd.Y)).Y;
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
                  //  SetRangeTextBox();
                }
            }
            
        }

        PointD justBeforePt = new PointD(0, 0);
        private void pictureBoxMain_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
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
                if (e.X > tabControl1.Width + tabControl1.Location.X -pictureBoxMain.Location.X||
                    e.X < tabControl1.Location.X - pictureBoxMain.Location.X ||
                    e.Y > tabControl1.Height+ tabControl1.Location.Y -pictureBoxMain.Location.Y ||
                    e.Y < tabControl1.Location.Y - pictureBoxMain.Location.Y)
                    pictureBoxMain.BringToFront();
            }

            //マウス位置情報の更新
            PointD pt = ConvToRealCoord(e.X, e.Y);
            if (AxisMode == HorizontalAxis.Angle)
                labelTwoTheta.Text = "2θ: ";
            else if (AxisMode == HorizontalAxis.d)
                labelTwoTheta.Text = "d: ";
            else if (AxisMode == HorizontalAxis.EnergyXray)
                labelTwoTheta.Text = "Energy: ";
            else if (AxisMode == HorizontalAxis.NeutronTOF)
                labelTwoTheta.Text = "TOF: ";
            else if (AxisMode == HorizontalAxis.WaveNumber)
                labelTwoTheta.Text = "q: ";

            labelTwoTheta.Text += pt.X.ToString("g6");

            if (AxisMode == HorizontalAxis.Angle)
                labelTwoTheta.Text += " °";
            else if (AxisMode == HorizontalAxis.d)
                labelTwoTheta.Text += " Å";
            else if (AxisMode == HorizontalAxis.EnergyXray)
                labelTwoTheta.Text += " eV";
            else if (AxisMode == HorizontalAxis.NeutronTOF)
                labelTwoTheta.Text += " μs";
            else if (AxisMode == HorizontalAxis.WaveNumber)
                labelTwoTheta.Text += " /Å";

            if (AxisMode == HorizontalAxis.Angle)
                labelD.Text = "d: " + (10 * WaveLength / 2 / Math.Sin(pt.X / 360 * Math.PI)).ToString("g5") + " Å";
            else if (AxisMode == HorizontalAxis.EnergyXray)
                labelD.Text = "d: " + (10 * HorizontalAxisConverter.XrayEnergyToD(pt.X, TakeoffAngle)).ToString("g5") + " Å";
            else if (AxisMode == HorizontalAxis.d)
                labelD.Text = "";//"d: " + pt.X.ToString("g6");
            else if (AxisMode == HorizontalAxis.NeutronTOF)
                labelD.Text = "d: " + (10 * HorizontalAxisConverter.NeutronTofToD(pt.X, TofAngle, TofLength)).ToString("g5") + " Å";
            else if(AxisMode == HorizontalAxis.WaveNumber)
                labelD.Text = "d: " + HorizontalAxisConverter.WaveNumberToD(pt.X).ToString("g5") + " Å";
                

            labelIntensity.Text = "Int: " + pt.Y.ToString("g6");

            //Application.DoEvents();


             //マウスカーソルの設定
            double dev = pt.X - ConvToRealCoord(e.X - 3, e.Y).X;
             if (ShowBackgroundProfile && BackGroundPointSelectMode)//bg点選択モードのときは
                  pictureBoxMain.Cursor = Cursors.Default;

              else if (MaskingMode && formProfile.Visible && formProfile.checkBoxShowMaskedRange.Checked && bindingSourceProfile.Position >= 0)//MaskRange選択時
              {
                  DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
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

            if (ShowBackgroundProfile && BackGroundPointSelectMode && IsBgPtSelected == true && e.Button == MouseButtons.Left)
            {//Bgモードで、Bg点を選択していて、左ドラッグのとき
                if (bindingSourceProfile.Position >= 0)
                {
                    DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                    PointD newBgPoint = dp.ConvertDestToSrc(pt);
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
                if (SelectedCrysatlIndex == 0 && IsPlaneSelected && e.Button == MouseButtons.Left)//flexibleCrystalのPlane選択モードのとき
                {
                    Crystal cry = (Crystal)((DataRowView)bindingSourceCrystal.Current).Row[1];
                    cry.Plane[SelectedPlaneIndex].d = ConvToDspacing(pt).X;
                    cry.Plane.Sort();
                    Draw();
                }
                else if (IsPlaneSelected && e.Button == MouseButtons.Left)//通常結晶のPlane選択モードのとき
                {
                    Crystal cry = (Crystal)((DataRowView)bindingSourceCrystal.Current).Row[1];
                    double mag = 1;
                    if (AxisMode == HorizontalAxis.Angle)
                        mag = WaveLength / 2 / Math.Sin(pt.X / 360 * Math.PI) / cry.Plane[SelectedPlaneIndex].d;
                    else if (AxisMode == HorizontalAxis.d)
                        mag = pt.X / 10 / cry.Plane[SelectedPlaneIndex].d;
                    else if (AxisMode == HorizontalAxis.EnergyXray)
                        mag = HorizontalAxisConverter.XrayEnergyToD(pt.X, TakeoffAngle) / cry.Plane[SelectedPlaneIndex].d;
                    else if (AxisMode == HorizontalAxis.NeutronTOF)
                        mag = HorizontalAxisConverter.NeutronTofToD(pt.X, TofAngle, TofLength) / cry.Plane[SelectedPlaneIndex].d;
                    else if(AxisMode== HorizontalAxis.WaveNumber)
                        mag = HorizontalAxisConverter.WaveNumberToD(pt.X*10) / cry.Plane[SelectedPlaneIndex].d;

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
            else if (MaskingMode && selectedMaskingBoundaryIndex[0]>=0)
            {
                formProfile.SetMaskRange(selectedMaskingBoundaryIndex, ConvToRealCoord(e.X, 0).X);
                if (formProfile.SortMaskRanges())
                    selectedMaskingBoundaryIndex = SearchMaskBoundary(pt.X, formProfile.GetMaskRanges(), dev);
                DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                dp.SetMaskingProfile();
                Draw();
            }



          
        }

        #endregion

        #region FormFittingからの呼び出し
        //formFiitingから呼び出されたとき
        public void ChangeCrystalFromFitting(/*Crystal cry*/)
        {
            InitializeCrystalPlane();
            SetFormCrystal(true);
            SetFormEOS();

            formFitting.ChangeCrystalFromMainForm();

            Draw();
        }
        #endregion

        #region 子フォームの起動終了チェックボックスイベント

        private void checkBoxProfileParameter_CheckedChanged(object sender, EventArgs e)
        {
            toolStripButtonProfileParameter.Checked = checkBoxProfileParameter.Checked;

            formProfile.Visible = checkBoxProfileParameter.Checked;
            if (formProfile.Visible)
            {
                formProfile.BringToFront();
                formProfile.WindowState = FormWindowState.Normal;
            }
            Draw();
        }
        //Crystalボタンクリック時
        private void checkBoxCrystalParameter_CheckedChanged(object sender, EventArgs e)
        {
            toolStripButtonCrystalParameter.Checked = checkBoxCrystalParameter.Checked;

            formCrystal.Visible = checkBoxCrystalParameter.Checked;
            if (formCrystal.Visible)
            {
                formCrystal.BringToFront();
                formCrystal.WindowState = FormWindowState.Normal;
            }
        }

        //EOSチェックボックスクリック時
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
                }
            }
        }


        private void toolStripButtonStressAnalysis_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripButtonStressAnalysis.Checked == false && formStressAnalysis.WindowState == FormWindowState.Minimized)
                toolStripButtonStressAnalysis.Checked = true;
            else
            {
                formStressAnalysis.Visible = toolStripButtonStressAnalysis.Checked;
                if (formStressAnalysis.Visible)
                {
                    formStressAnalysis.BringToFront();
                    formStressAnalysis.WindowState = FormWindowState.Normal;
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

            if (formEOS.checkBoxNaClB2.Checked = dataSet.DataTableCrystal.GetItemChecked(4))
                formEOS.numericalTextBoxNaClB2A.Text = (dataSet.DataTableCrystal.Items[4].A * 10).ToString("f5");//NaCl B2

            if (formEOS.checkBoxPericlase.Checked = dataSet.DataTableCrystal.GetItemChecked(5))
                formEOS.numericalTextBoxMgOA.Text = (dataSet.DataTableCrystal.Items[5].A * 10).ToString("f5");//MgO

            if (formEOS.checkBoxCorundum.Checked = dataSet.DataTableCrystal.GetItemChecked(6))
                formEOS.numericalTextBoxColundumV.Text = (dataSet.DataTableCrystal.Items[6].Volume * 1000).ToString("f5");//Corundum

            if (formEOS.checkBoxAr.Checked = dataSet.DataTableCrystal.GetItemChecked(7))
                formEOS.numericalTextBoxArA.Text = (dataSet.DataTableCrystal.Items[7].A * 10).ToString("f5");//Ar

            if (formEOS.checkBoxRe.Checked = dataSet.DataTableCrystal.GetItemChecked(8))
                formEOS.numericalTextBoxReV.Text = (dataSet.DataTableCrystal.Items[8].Volume * 1000).ToString("f5");//Re


            formEOS.skipTextChangeEvent = false;
            formEOS.numericalTextBox_ValueChanged(new object(), new EventArgs());
        }

        /// <summary>
        /// FormCrystalをセット
        /// </summary>
        /// <param name="ReCalcDensity">密度などを計算する必要があるときはTrue</param>
        public void SetFormCrystal(bool ReCalcDensity)
        {
            if (SelectedCrysatlIndex < 0) return;
            if (ReCalcDensity)
                dataSet.DataTableCrystal.Items[bindingSourceCrystal.Position].GetFormulaAndDensity();
            if(formCrystal.crystalControl != null)
                formCrystal.crystalControl.Crystal = dataSet.DataTableCrystal.Items[bindingSourceCrystal.Position];
        }

        /// <summary>
        /// FormFittingをセット
        /// </summary>
        public void SetFormFitting()
        {	
        }
        #endregion

      
        #region プロファイルのファイル読み込み関連

        private void menuItemFileRead_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog Dlg = new OpenFileDialog();
            Dlg.Filter = "Powder Pattern File(WinPIP[*.csv];Fit2D[*.chi];PDI[*.pdi])|*.csv;*.chi;*.pdi"
                + "|EDX profile[*.rpt,*.npd]|*.rpt;*npd"
                + "|Powder Pattern File(Auto[*.*])|*.*";
            Dlg.FilterIndex = filterIndex;
            if (initialDirectory != "")
                Dlg.InitialDirectory = initialDirectory;
            if (Dlg.ShowDialog() == DialogResult.OK)
            {
                readProfile(Dlg.FileName);
                filterIndex = Dlg.FilterIndex;
                initialDirectory = Path.GetDirectoryName(Dlg.FileName);
            }
        }

        delegate void readProfileCallBack(string str);
        private void readProfile(string fileName)
        {
            if (this.InvokeRequired)//別スレッド(ファイル更新監視スレッド)から呼び出されたとき Invokeして呼びなおす
            {
                readProfileCallBack d = new readProfileCallBack(readProfile);
                this.Invoke(d, new object[] { fileName });
                return;
            }

            formDataConverter.textBox.Text = "";

            DiffractionProfile[] dp;

            if (fileName.EndsWith(".pdi"))
            #region pdi形式のとき
            {

                dp = XYFile.ReadPdiFile(fileName);

                for (int i = 0; i < dp.Length; i++)
                {
                    if (dp[i].WaveSource == Crystallography.WaveSource.Xray && dp[i].SrcWaveLength > 1)
                        dp[i].SrcWaveLength = UniversalConstants.Convert.EnergyToXrayWaveLength(dp[i].SrcWaveLength * 10000);
                    dp[i].SubtractBackground = false;
                    for (int j = 0; j < dp[i].OriginalProfile.Pt.Count; j++)
                        if (dp[i].OriginalProfile.Pt[j].Y == 0)
                            dp[i].OriginalProfile.Pt.RemoveAt(j--);
                        else break;

                    for (int j = dp[i].OriginalProfile.Pt.Count - 1; j >= 0; j--)
                        if (dp[i].OriginalProfile.Pt[j].Y == 0)
                            dp[i].OriginalProfile.Pt.RemoveAt(j);
                        else break;
                }

                if (dp.Length == 0)
                    return;
                else if (dp.Length > 1)

                    radioButtonMultiProfileMode.Checked = true;

                //処理時間短縮のために、最後から一つ手前のDiffractionProfileまでを一気に入力
                skipAxisPropertyChangedEvent = true;
                for (int i = 0; i < dp.Length - 1; i++)
                    AddProfileToCheckedListBox(dp[i], checkBoxAll.Checked, false);
                skipAxisPropertyChangedEvent = false;
                AddProfileToCheckedListBox(dp[dp.Length - 1], checkBoxAll.Checked, true);

                this.Text = "PDIndexer   " + Version.VersionAndDate + "   " + dp[dp.Length - 1].Name;


            }
            #endregion

            else if (fileName.EndsWith("ras"))
            #region RASファイル
            {
                formDataConverter.SetProperty(FileProperties[(int)FileType.RAS]);
                if (formDataConverter.ShowDialog() == DialogResult.OK)
                {
                    dp = XYFile.ReadRasFile(fileName);
                    if (dp.Length == 0)
                        return;

                    for (int i = 0; i < dp.Length; i++)
                    {
                        dp[i].WaveSource = formDataConverter.WaveSource;
                        dp[i].WaveColor = formDataConverter.WaveColor;
                        dp[i].SrcWaveLength = formDataConverter.Wavelength;
                        dp[i].SrcTakeoffAngle = formDataConverter.TakeoffAngle;
                        dp[i].SrcAxisMode = formDataConverter.AxisMode;
                        dp[i].XrayElementNumber = formDataConverter.XraySourceElementNumber;
                        dp[i].XrayLine = formDataConverter.XrayLine;
                        dp[i].ExposureTime = formDataConverter.ExposureTime;
                        dp[i].Name = fileName.Remove(0, fileName.LastIndexOf('\\') + 1) + " " + i.ToString("##");

                        //線源が特性X線で、Kα2を除去する場合
                        if (formDataConverter.WaveSource == Crystallography.WaveSource.Xray
                           && formDataConverter.horizontalAxisUserControl.XrayWaveSourceLine == XrayLine.Ka
                           && formDataConverter.RemoveKalpha2)
                            dp[i].RemoveKalpha2();

                        dp[i].SubtractBackground = false;
                    }

                    radioButtonMultiProfileMode.Checked = true;

                    //処理時間短縮のために、最後から一つ手前のDiffractionProfileまでを一気に入力
                    skipAxisPropertyChangedEvent = true;
                    for (int i = 0; i < dp.Length - 1; i++)
                        AddProfileToCheckedListBox(dp[i], checkBoxAll.Checked, false);
                    skipAxisPropertyChangedEvent = false;
                    AddProfileToCheckedListBox(dp[dp.Length - 1], checkBoxAll.Checked, true);

                    this.Text = "PDIndexer   " + Version.VersionAndDate + "   " + dp[dp.Length - 1].Name;

                    FileProperties[(int)FileType.RAS] = formDataConverter.GetProperty();
                }

            }
            #endregion

            else if (fileName.EndsWith("csv") && (dp = XYFile.ReadCSVFile(fileName)).Length > 0)
            #region CSV形式
            {
                formDataConverter.SetProperty(FileProperties[(int)FileType.CSV]);
                if (formDataConverter.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < dp.Length; i++)
                    {
                        dp[i].WaveSource = formDataConverter.WaveSource;
                        dp[i].WaveColor = formDataConverter.WaveColor;
                        dp[i].SrcWaveLength = formDataConverter.Wavelength;
                        dp[i].SrcTakeoffAngle = formDataConverter.TakeoffAngle;
                        dp[i].SrcAxisMode = formDataConverter.AxisMode;
                        dp[i].XrayElementNumber = formDataConverter.XraySourceElementNumber;
                        dp[i].XrayLine = formDataConverter.XrayLine;
                        dp[i].ExposureTime = formDataConverter.ExposureTime;
                        //dp[i].Name = fileName.Remove(0, fileName.LastIndexOf('\\') + 1) + " " + i.ToString("##");

                        dp[i].SubtractBackground = false;
                    }
                    radioButtonMultiProfileMode.Checked = true;

                    //処理時間短縮のために、最後から一つ手前のDiffractionProfileまでを一気に入力
                    skipAxisPropertyChangedEvent = true;
                    for (int i = 0; i < dp.Length - 1; i++)
                        AddProfileToCheckedListBox(dp[i], checkBoxAll.Checked, false);
                    skipAxisPropertyChangedEvent = false;
                    AddProfileToCheckedListBox(dp[dp.Length - 1], checkBoxAll.Checked, true);

                    this.Text = "PDIndexer   " + Version.VersionAndDate + "   " + dp[dp.Length - 1].Name;

                    FileProperties[(int)FileType.CSV] = formDataConverter.GetProperty();
                }
            }
            #endregion


            else if (fileName.EndsWith("nxs"))
            #region nxs形式 (DESY, Quantum Xspress 3 digital analyser & Ge-detectors, 2019/10/01 17:19のRobert Farlaさんのメール)
            {


                var nxs = new Crystallography.HDF(fileName);
                nxs.Move("/entry/instrument/xspress3");

                formDataConverter.SetProperty(FileProperties[(int)FileType.NXS]);


                if (formDataConverter.ShowDialog() == DialogResult.OK)
                {

                    double a0 = formDataConverter.EGC0, a1 = formDataConverter.EGC1, a2 = formDataConverter.EGC2;

                    foreach (var channel in nxs.GetGroups())
                    {
                        var (data, result) = nxs.GetValue2<int>(channel + "/histogram");
                        if (result && data.Length > 0)
                        {
                            DiffractionProfile diffProf = new DiffractionProfile
                            {
                                WaveSource = formDataConverter.WaveSource,
                                WaveColor = formDataConverter.WaveColor,
                                SrcWaveLength = formDataConverter.Wavelength,
                                SrcTakeoffAngle = formDataConverter.TakeoffAngle,
                                SrcAxisMode = formDataConverter.AxisMode,
                                XrayElementNumber = formDataConverter.XraySourceElementNumber,
                                XrayLine = formDataConverter.XrayLine,
                                ExposureTime = formDataConverter.ExposureTime,
                                Name = Path.GetFileNameWithoutExtension(fileName) + " - " + channel
                            };

                            var sumData = new int[data[0].Length];
                            foreach (var d in data)
                                for (int i = 0; i < sumData.Length; i++)
                                    sumData[i] += d[i];

                            var pts = sumData.Select((y, x) => new PointD(a0 + a1 * x + a2 * x * x, y)).ToList();
                            pts.RemoveAt(pts.Count - 1);
                            diffProf.OriginalProfile.Pt =pts;

                            AddProfileToCheckedListBox(diffProf, checkBoxAll.Checked, true);
                        }
                    }

                    FileProperties[(int)FileType.NXS] = formDataConverter.GetProperty();

                    this.Text = "PDIndexer   " + Version.VersionAndDate + "   " + Path.GetFileNameWithoutExtension(fileName);

                    formDataConverter.VisibleEDXSetting = true;
                    return;
                }
            }
            #endregion


            //pdi,ras形式ではないとき
            else
            {
                StreamReader reader = new StreamReader(fileName);
                List<string> strList = new List<string>();
                string tempstr;
                while ((tempstr = reader.ReadLine()) != null)
                    strList.Add(tempstr);
                reader.Close();
                if (strList.Count <= 3)
                    return;

                DiffractionProfile diffProf = new DiffractionProfile();
                formDataConverter.XraySourceElementNumber = XraySourceElementNumber;
                if (XraySourceElementNumber == 0)
                    formDataConverter.Wavelength = WaveLength;
                formDataConverter.TakeoffAngle = TakeoffAngle;
                formDataConverter.textBox.Lines = strList.ToArray();

                string[] str;

                #region Fit2Dデータ
                if (fileName.EndsWith(".chi"))
                {
                    formDataConverter.AxisMode = HorizontalAxis.Angle;
                    formDataConverter.WaveSource = Crystallography.WaveSource.Xray;
                    formDataConverter.WaveColor = Crystallography.WaveColor.Monochrome;


                    if (formDataConverter.ShowDialog() == DialogResult.OK)
                        for (int i = 4; i < strList.Count; i++)
                        {
                            str = strList[i].Split(' ');
                            if (str.Length == 4)
                            {
                                var str1 = str[1];
                                var str3 = str[3];
                                if (Miscellaneous.IsDecimalPointComma)
                                {
                                    str1 = str1.Replace('.', ',');
                                    str3 = str3.Replace('.', ',');
                                }
                                var x = Convert.ToDouble(str1);
                                var y = Convert.ToDouble(str3);

                                diffProf.OriginalProfile.Pt.Add(new PointD(Convert.ToDouble(str1), Convert.ToDouble(str3)));
                            }
                            else
                                break;
                        }
                    else return;
                }
                #endregion

                #region XBM形式 SP8_BL4B2のデータらしい
                else if (fileName.EndsWith("XBM") || fileName.EndsWith("xbm"))
                {
                    formDataConverter.AxisMode = HorizontalAxis.EnergyXray;
                    formDataConverter.WaveSource = Crystallography.WaveSource.Xray;
                    formDataConverter.WaveColor = Crystallography.WaveColor.FlatWhite;

                    BinaryReader br = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read));

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

                    formDataConverter.EGC0 = getDouble(0x59A);
                    formDataConverter.EGC1 = getDouble(0x5A2);
                    formDataConverter.EGC2 = getDouble(0x5AA);
                    formDataConverter.VisibleEDXSetting = true;

                    int length = getInt16(0x814);
                    br.BaseStream.Position = 0x816;

                    if (formDataConverter.ShowDialog() == DialogResult.OK)
                    {
                        for (int n = 1; n < length; n++)
                        {
                            double x = (formDataConverter.EGC0 + formDataConverter.EGC1 * n + formDataConverter.EGC2 * n * n) * 1000;
                            double y = br.ReadUInt32();
                            //    if (x > formDataConverter.LowEnergyCutoff)
                            diffProf.OriginalProfile.Pt.Add(new PointD(x, y));
                        }
                        formDataConverter.VisibleEDXSetting = false;
                        br.Close();
                    }
                    else
                    {
                        formDataConverter.VisibleEDXSetting = false;
                        br.Close();
                        return;
                    }
                }
                #endregion

                #region RPT形式 (gennie file)
                else if (fileName.EndsWith("RPT") || fileName.EndsWith("rpt"))
                {
                    formDataConverter.AxisMode = HorizontalAxis.EnergyXray;
                    formDataConverter.WaveSource = Crystallography.WaveSource.Xray;
                    formDataConverter.WaveColor = Crystallography.WaveColor.FlatWhite;
                    //TakeoffAngle
                    formDataConverter.TakeoffAngleText = strList[strList.Count - 4].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    formDataConverter.ExposureTime = Convert.ToDouble(strList[strList.Count - 5].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                    formDataConverter.EGC0 = Convert.ToDouble(strList[strList.Count - 1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    formDataConverter.EGC1 = Convert.ToDouble(strList[strList.Count - 1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    formDataConverter.VisibleEDXSetting = true;

                    // string[] s = strList[strList.Count - 5].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (formDataConverter.ShowDialog() == DialogResult.OK)
                    {
                        int n = 1;
                        for (int i = 1; i < strList.Count - 6; i++)
                        {
                            str = strList[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int j = 0; j < str.Length; j++)
                            {
                                double x = (formDataConverter.EGC0 + formDataConverter.EGC1 * n) * 1000;
                                n++;
                                if (x > formDataConverter.LowEnergyCutoff)
                                    diffProf.OriginalProfile.Pt.Add(new PointD(x, Convert.ToDouble(str[j])));
                            }
                        }
                        formDataConverter.VisibleEDXSetting = false;

                    }
                    else
                    {
                        formDataConverter.VisibleEDXSetting = false;
                        return;
                    }
                }
                #endregion


                #region npd形式
                else if (fileName.EndsWith("npd") || fileName.EndsWith("NPD"))
                {
                    formDataConverter.EGC0 = formDataConverter.EGC1 = formDataConverter.EGC2 = 0;
                    for (int i = 0; i < strList.Count || i < 25; i++)
                    {
                        if (strList[i].StartsWith("EGC0"))
                            formDataConverter.EGC0 = Convert.ToDouble(strList[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                        if (strList[i].StartsWith("EGC1"))
                            formDataConverter.EGC1 = Convert.ToDouble(strList[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                        if (strList[i].StartsWith("EGC2"))
                            formDataConverter.EGC2 = Convert.ToDouble(strList[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                        if (strList[i].StartsWith("2Theta"))
                            formDataConverter.TakeoffAngleText = strList[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1];
                        if (strList[i].StartsWith("Live time"))
                            formDataConverter.ExposureTime = Convert.ToDouble(strList[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                    }
                    formDataConverter.AxisMode = HorizontalAxis.EnergyXray;
                    formDataConverter.WaveSource = Crystallography.WaveSource.Xray;
                    formDataConverter.WaveColor = Crystallography.WaveColor.FlatWhite;
                    formDataConverter.VisibleEDXSetting = true;

                    if (formDataConverter.ShowDialog() == DialogResult.OK)
                    {
                        formDataConverter.VisibleEDXSetting = true;
                        for (int i = 0; i < strList.Count; i++)
                        {
                            int length = 0;
                            if (strList[i].StartsWith("Data length"))
                            {
                                length = Convert.ToInt32(strList[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]);

                                for (int j = i + 2; j < i + 2 + length; j++)
                                {

                                    double x = Convert.ToDouble(strList[j].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1]) * 1000;
                                    double y = Convert.ToDouble(strList[j].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[2]);
                                    if (x > formDataConverter.LowEnergyCutoff)
                                        diffProf.OriginalProfile.Pt.Add(new PointD(x, y));
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        formDataConverter.VisibleEDXSetting = true;
                        return;
                    }
                }
                #endregion

                #region 中性子TOFデータ
                else if (strList[0].StartsWith("**  MPLOT FILE **"))//中性子TOFデータの時
                {
                    formDataConverter.WaveSource = Crystallography.WaveSource.Neutron;
                    formDataConverter.WaveColor = Crystallography.WaveColor.FlatWhite;
                    formDataConverter.TakeoffAngleText = "90";
                    formDataConverter.TofLength = 26.5;
                    formDataConverter.horizontalAxisUserControl.AxisMode = HorizontalAxis.NeutronTOF;
                    if (formDataConverter.ShowDialog() == DialogResult.OK)
                    {
                        for (int i = 0; i < strList.Count; i++)
                            if (strList[i].StartsWith("-----------------------------------------------"))
                            {
                                for (int j = i + 1; j < strList.Count - 1; j++)
                                {
                                    str = strList[j].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                    double x = Convert.ToDouble(str[0]);
                                    double y = Convert.ToDouble(str[1]);
                                    double err = Convert.ToDouble(str[2]);
                                    diffProf.OriginalProfile.Pt.Add(new PointD(x, y));
                                    diffProf.OriginalProfile.Err.Add(new PointD(x, err));

                                }
                                break;
                            }

                        for (int i = 0; i < strList.Count; i++)
                        {
                            if (strList[i].StartsWith("\"\"\""))
                            {
                                StringBuilder sb = new StringBuilder();
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

                #region そのほかのファイル形式のとき
                else//
                {
                    if (formDataConverter.ShowDialog() == DialogResult.OK)
                    {
                        if ((diffProf = XYFile.ConvertUnknownFileToProfileData(fileName, ',')) == null)
                            if ((diffProf = XYFile.ConvertUnknownFileToProfileData(fileName, ' ')) == null)
                                if ((diffProf = XYFile.ConvertUnknownFileToProfileData(fileName, '\t')) == null)
                                    return;
                    }
                }
                #endregion


                diffProf.WaveSource = formDataConverter.WaveSource;
                diffProf.WaveColor = formDataConverter.WaveColor;
                diffProf.SrcWaveLength = formDataConverter.Wavelength;
                diffProf.SrcTakeoffAngle = formDataConverter.TakeoffAngle;
                diffProf.SrcAxisMode = formDataConverter.AxisMode;
                diffProf.XrayElementNumber = formDataConverter.XraySourceElementNumber;
                diffProf.XrayLine = formDataConverter.XrayLine;
                diffProf.SrcTofAngle = formDataConverter.TofAngle;
                diffProf.SrcTofLength = formDataConverter.TofLength;

                diffProf.ExposureTime = formDataConverter.ExposureTime;

                diffProf.Name = fileName.Remove(0, fileName.LastIndexOf('\\') + 1);

                //線源が白色X線で、単位がkevの場合、eVに変換
                if (formDataConverter.WaveSource == Crystallography.WaveSource.Xray
                           && formDataConverter.WaveColor == WaveColor.FlatWhite
                           && formDataConverter.AxisMode == HorizontalAxis.EnergyXray
                           && formDataConverter.EnergyUnit == EnergyUnitEnum.KeV)
                {
                    for (int i = 0; i < diffProf.OriginalProfile.Pt.Count; i++)
                        //diffProf.OriginalProfile.Pt[i].X *= 1000;
                        diffProf.OriginalProfile.Pt[i] = new PointD(1000 * diffProf.OriginalProfile.Pt[i].X, diffProf.OriginalProfile.Pt[i].Y);
                }

                if (diffProf.OriginalProfile.Pt.Count > 0)
                {
                    if (diffProf.SrcAxisMode == HorizontalAxis.NeutronTOF)
                        if (formDataConverter.TofUnitNanoSec)//単位を変換する必要がある場合は
                            for (int i = 0; i < diffProf.OriginalProfile.Pt.Count; i++)
                                //diffProf.OriginalProfile.Pt[i].X /= 1000;
                                diffProf.OriginalProfile.Pt[i] = new PointD(diffProf.OriginalProfile.Pt[i].X / 1000, diffProf.OriginalProfile.Pt[i].Y);

                    AddProfileToCheckedListBox(diffProf, true, true);

                }

                this.Text = "PDIndexer   " + Version.VersionAndDate + "   " + fileName.Remove(0, fileName.LastIndexOf('\\') + 1);
            }
        }


      


        /// <summary>
        /// 新しいDiffractionProfileをチェックリストボックスに加える
        /// </summary>
        /// <param name="dp">加えるDiffractionProfile</param>
        /// <param name="isChecked">チェックした状態にするか</param>
        /// <param name="isDraw">描画範囲をリセットし、</param>
        /// <param name="isRenewOtherProfiles"></param>
        public void AddProfileToCheckedListBox(DiffractionProfile dp, bool isChecked, bool isDraw)
        {
            if (dp.Mode == DiffractionProfileMode.Concentric)
            {//ConcentricModeのとき
                //dp.CopyParameter(defaultDP);
                if (checkBoxChangeHorizontalAppearance.Checked)
                {

                    if (WaveColor != dp.WaveColor) WaveColor = dp.WaveColor;
                    if (WaveSource != dp.WaveSource) WaveSource = dp.WaveSource;
                    if (AxisMode != dp.SrcAxisMode) AxisMode = dp.SrcAxisMode;
                    if (WaveLength != dp.SrcWaveLength) WaveLength = dp.SrcWaveLength;
                    if (WaveSource == Crystallography.WaveSource.Xray)
                    {
                        if (WaveColor == Crystallography.WaveColor.Monochrome)
                        {
                            if (XraySourceElementNumber != dp.XrayElementNumber) XraySourceElementNumber = dp.XrayElementNumber;
                           if( XraySourceLine != dp.XrayLine) XraySourceLine = dp.XrayLine;
                        }
                    }

                    if (TakeoffAngle != dp.SrcTakeoffAngle) TakeoffAngle = dp.SrcTakeoffAngle;
                    if (TofAngle != dp.SrcTofAngle) TofAngle = dp.SrcTofAngle;
                    if (TofLength != dp.SrcTofLength) TofLength = dp.SrcTofLength;
                }
                dp.SetConvertedProfile(AxisMode, WaveLength, TakeoffAngle, TofAngle, TofLength);

                //マルチパターンモードかつChangeColorモードのときは
                if (dp.ColorARGB == null)
                    if (radioButtonMultiProfileMode.Checked && checkBoxChangeColor.Checked)
                        dp.ColorARGB = generateRandomColor().ToArgb();
                    else//デフォルトカラーを設定
                        dp.ColorARGB = Color.Blue.ToArgb();

                Bitmap bmp = new Bitmap(18, 18);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.FromArgb((int)dp.ColorARGB));

                if (radioButtonSingleProfileMode.Checked)//シングルパターンモードのとき
                    dataSet.DataTableProfile.Rows.Clear();
                dataSet.DataTableProfile.Rows.Add(new object[] { isChecked, dp, bmp });
                bindingSourceProfile.Position = dataSet.DataTableProfile.Items.Count - 1;
               // if (radioButtonMultiProfileMode.Checked)//マルチパターンモードのとき
               // {
               //     if (dp.IsLPOchild)
               //         formProfile.checkedListBoxProfiles_SelectedIndexChanged(this, new EventArgs());
               // }

                if (isDraw)
                {
                    SetDrawRangeLimit();//描画範囲の上限、下限を設定
                    ResetDrawRange(); //描画範囲をリセット
                    InitializeCrystalPlane(); //描画する結晶面の設定	
                    Draw();						//プロファイル描画
                    SetFormEOS();			//EOS画面の描画
                    formFitting.ChangeCrystalFromMainForm();//formFittingの更新
                    SetFormCrystal(false);
                }
            }
            else
            {//RadialModeのとき
                if (checkBoxChangeHorizontalAppearance.Checked)
                {
                    AxisMode = HorizontalAxis.none;
                    XraySourceElementNumber = dp.XrayElementNumber;
                    XraySourceLine = dp.XrayLine;
                    if (XraySourceElementNumber == 0)
                        WaveLength = dp.SrcWaveLength;
                    TakeoffAngle = dp.SrcTakeoffAngle;
                }
                dp.SetConvertedProfile(AxisMode, WaveLength, TakeoffAngle, TofAngle, TofLength);

                //マルチパターンモードかつChangeColorモードのときは
                if (dp.ColorARGB == null)
                    if (radioButtonMultiProfileMode.Checked && checkBoxChangeColor.Checked)
                        dp.ColorARGB = generateRandomColor().ToArgb();
                    else//デフォルトカラーを設定
                        dp.ColorARGB = Color.Blue.ToArgb();

                Bitmap bmp = new Bitmap(18, 18);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.FromArgb((int)dp.ColorARGB));

                if (radioButtonSingleProfileMode.Checked)//シングルパターンモードのとき
                    dataSet.DataTableProfile.Rows.Clear();//消去

                dataSet.DataTableProfile.Rows.Add(new object[] { isChecked, dp, bmp });//新しいプロファイルを追加
                bindingSourceProfile.Position = dataSet.DataTableProfile.Items.Count - 1;

                if (isDraw)
                {
                    SetDrawRangeLimit();//描画範囲の上限、下限を設定
                    ResetDrawRange(); //描画範囲をリセット
                    Draw();						//プロファイル描画
                }
            }
        }

        public Color generateRandomColor()
        {
            Random r = new Random();
            int max = 192 + r.Next(64); 
            int mid1 = r.Next(128);             
            int mid2 = r.Next(128);
            if (dataSet.DataTableProfile.Items.Count == 0)//直前のプロファイルがない時はR>G>Bの色を返す
                return Color.FromArgb(max, mid1, mid2);
            else//直前のプロファイルがある時はその色となるべく違う色を返す  
            {
                int red = Color.FromArgb(((DiffractionProfile)(dataSet.DataTableProfile.Items[dataSet.DataTableProfile.Items.Count - 1])).ColorARGB.Value).R;
                int green = Color.FromArgb(((DiffractionProfile)(dataSet.DataTableProfile.Items[dataSet.DataTableProfile.Items.Count - 1])).ColorARGB.Value).G;
                int blue = Color.FromArgb(((DiffractionProfile)(dataSet.DataTableProfile.Items[dataSet.DataTableProfile.Items.Count - 1])).ColorARGB.Value).B;

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
        private void menuItemSaveCrystalData_Click(object sender, System.EventArgs e)
        {
            List<Crystal> cry = new List<Crystal>();
            for (int i = 0; i < dataSet.DataTableCrystal.Count; i++)
                cry.Add((Crystal)dataSet.DataTableCrystal.Items[i]);

            FormCrystalSelection formCrystalSelection = new FormCrystalSelection();
            formCrystalSelection.LoadMode = false;
            formCrystalSelection.SetCrystalList(cry);
            if (formCrystalSelection.ShowDialog() == DialogResult.OK && formCrystalSelection.CheckedCrystalList.Length>0)
            {
                SaveFileDialog Dlg = new SaveFileDialog();
                Dlg.Filter = "xml|*.Xml";
                try
                {
                    if (Dlg.ShowDialog() == DialogResult.OK)
                        ConvertCrystalData.SaveCrystalListXml(formCrystalSelection.CheckedCrystalList, Dlg.FileName);
                }
                catch
                {
                    MessageBox.Show("ファイルが書き込みません");
                }
            }
        }

        private void saveCrystal(string filename, Crystal[] crystals = null)
        {
            try
            {
                if (crystals == null)
                {
                    List<Crystal> cry = new List<Crystal>();
                    for (int i = 0; i < dataSet.DataTableCrystal.Count; i++)
                        cry.Add((Crystal)dataSet.DataTableCrystal.Items[i]);
                    crystals = cry.ToArray();
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
        private void menuItemReadCrystalData_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog Dlg = new OpenFileDialog();
            Dlg.Filter = "xml|*.Xml";
            if (Dlg.ShowDialog() == DialogResult.OK)
                readCrystal(Dlg.FileName, true, true);
        }
        private void readAndAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dlg = new OpenFileDialog();
            Dlg.Filter = "xml|*.Xml";
            if (Dlg.ShowDialog() == DialogResult.OK)
                readCrystal(Dlg.FileName,true,false);
        }

        private void readCrystal(string fileName, bool showSelectionDialog, bool clearPresentData)
        {

            StringBuilder sb = new StringBuilder();
            var sr = new StreamReader(fileName, Encoding.UTF8);
            while (sr.Peek()>-1)
                sb.AppendLine(sr.ReadLine());
            sr.Close();

            var sw = new StreamWriter(fileName, false, Encoding.UTF8);
            sw.WriteLine(sb);
            sw.Close();

            
            List<Crystal> crystalArray =  new List<Crystal>();


            crystalArray.AddRange(ConvertCrystalData.ConvertToCrystalList(fileName));


            if (crystalArray.Count == 0) return;

            if (showSelectionDialog)
            {
                FormCrystalSelection formCrystalSelection = new FormCrystalSelection();
                formCrystalSelection.LoadMode = true;
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

            //もし読み込んだ結晶リストにReservedされたCrystalがあれば入れ替える

            crystalArray[0].FlexibleMode = true;
            for (int j = 0; j < dataSet.DataTableCrystal.Rows.Count; j++)
            {
                Crystal c = (Crystal)dataSet.DataTableCrystal.Rows[j][1];
                if (c.Reserved)
                    for (int i = 0; i < crystalArray.Count; i++)
                    {
                        if (crystalArray[i].Name == c.Name && crystalArray[i].Journal == c.Journal)
                        {
                            crystalArray[i].Reserved = true;
                            dataSet.DataTableCrystal.Rows[j][1] = crystalArray[i];
                            crystalArray.RemoveAt(i);
                            break;
                        }
                    }
            }

            foreach (Crystal c in crystalArray)
            {
               Bitmap bmp = new Bitmap(22, 22);
               Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.FromArgb(c.Argb));
                dataSet.DataTableCrystal.Rows.Add(new object[] { false, c, bmp });
            }

            dataGridViewCrystals.Rows[0].DefaultCellStyle = cellStyle1;

            for (int i = 1; i < dataGridViewCrystals.Rows.Count; i++)
                if (((Crystal)dataSet.DataTableCrystal.Rows[i][1]).Reserved)
                    dataGridViewCrystals.Rows[i].DefaultCellStyle = cellStyle2;


            if (bindingSourceCrystal.List.Count > 0)
                  bindingSourceCrystal.Position = 0;
            InitializeCrystalPlane(); //描画する結晶面の設定					
            Draw();						//プロファイル描画
        }

        #endregion

        //MenuItemから終了処理
        private void menuItemClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #region 印刷関係
        //MenuItemから印刷処理
        private void menuItemPrint_Click(object sender, System.EventArgs e)
        {
            
            PrintDialog pdlg = new PrintDialog();
            pdlg.Document = printDocument;
            if (pdlg.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
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

        #region ピクチャーボックスのContextMenu
        private void menuItemScaleUp_Click(object sender, System.EventArgs e)
        {
            //拡大
            LowerX = LowerX * 0.75f + UpperX * 0.25f;
            //if(LowerAngleLimit<0) LowerAngleLimit=0;
            UpperX = UpperX * 0.75f + LowerX * 0.25f;
            //if(UpperAngleLimit>UppestAngleLimit)UpperAngleLimit=UppestAngleLimit;
            LowerY = (int)(LowerY * 0.25f + UpperY * 0.75f + 0.5f);
            //if(LowerIntensityLimit<0)LowerIntensityLimit=0;
            UpperY = (int)(UpperY * 0.25f + LowerY * 0.75f + 0.5f);
            //if(UpperIntensityLimit>UppestIntensityLimit)UpperIntensityLimit=UppestIntensityLimit;
            InitializeCrystalPlane();
            Draw();
            //SetRangeTextBox();
        }

        private void menuItemScaleDown_Click(object sender, System.EventArgs e)
        {
            //縮小
            LowerX = LowerX * 1.5f - UpperX * 0.5f;
            if (LowerX < 0) LowerX = 0;
            UpperX = UpperX * 1.5f - LowerX * 0.5f;
            if (UpperX > MaximalX) UpperX = MaximalX;
            LowerY = (int)(LowerY * 1.5f - UpperY * 0.5f + 0.5f);
            if (LowerY < 0) LowerY = 0;
            UpperY = (int)(UpperY * 1.5f - LowerY * 0.5f + 0.5f);
            if (UpperY > MaximalY) UpperY = MaximalY;
            InitializeCrystalPlane();
            Draw();
           // SetRangeTextBox();
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
        public int SearchPlaneNo(double x, Crystal cry, double dev)
        {
            if (cry==null || cry.Plane == null) return -1;
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

        public int[] SearchMaskBoundary(double x, DiffractionProfile.MaskingRange[] ranges, double dev)
        {
            if (ranges == null) return new int[] { -1, -1 };
            int index1 = 0;
            int index2 = 0;
            double temp = double.PositiveInfinity;
            for (int i = 0; i < ranges.Length; i++)
                for (int j = 0; j < ranges[i].X.Length; j++ )
                    if (Math.Abs(ranges[i].X[j] - x) < temp)
                    {
                        index1 = i;
                        index2 = j;
                        temp = Math.Abs(ranges[i].X[j] - x);
                    }
            if (temp < dev)
                return new int[]{index1,index2};
            return new int[]{-1,-1};
        }
        #endregion


        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAboutMe().ShowDialog();
        }

        private void textBoxNumOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '.' || e.KeyChar > '9') && e.KeyChar != '\b')
                e.Handled = true;
        }
        
        private void radioButtonMultiProfileMode_CheckChanged(object sender, EventArgs e)
        {
            radioButtonSingleProfileMode.Checked = !radioButtonMultiProfileMode.Checked;
           
            if (numericalTextBoxIncreasingPixels.Value > float.MaxValue)
                numericalTextBoxIncreasingPixels.Value = numericalTextBoxIncreasingPixels.Value;

            IntervalOfProfiles = (float)numericalTextBoxIncreasingPixels.Value;           
            //checkedListBoxProfiles.Enabled = radioButtonMultiProfileMode.Checked;
            //formProfile.checkedListBoxProfiles.Enabled = radioButtonMultiProfileMode.Checked;
            SetDrawRangeLimit(); 
            Draw();
            
            formProfile.Refresh();
        }
        private void numericUpDownIncreasingPixels_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownIncreasingPixels.Value ==-1)
                numericalTextBoxIncreasingPixels.Value = 0.5;
            else if (numericUpDownIncreasingPixels.Value == -2)
                numericalTextBoxIncreasingPixels.Value = 0.1;
            else if (numericUpDownIncreasingPixels.Value == -3)
                numericalTextBoxIncreasingPixels.Value = 0.05;
            else if (numericUpDownIncreasingPixels.Value == -4)
                numericalTextBoxIncreasingPixels.Value = 0.01;
            else if (numericUpDownIncreasingPixels.Value == -5)
                numericalTextBoxIncreasingPixels.Value = 0;
            else
                numericalTextBoxIncreasingPixels.Value = Math.Pow(2, (double)numericUpDownIncreasingPixels.Value);
         
            if (numericalTextBoxIncreasingPixels.Value > float.MaxValue)
                numericalTextBoxIncreasingPixels.Value = numericalTextBoxIncreasingPixels.Value;
            radioButtonMultiProfileMode_CheckChanged(new object(), new EventArgs());
        }

        private void checkBoxShowScaleLine_CheckedChanged(object sender, EventArgs e)
        {
            Draw();
        }

        private void savePatternProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataSet.DataTableProfile.Items.Count > 0)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "*.pdi|*.pdi";
                if (dialog.ShowDialog() == DialogResult.OK)
                    SaveProfile(dialog.FileName);
            }
        }

        private void SaveProfile(string filename)
        {
            if (dataSet.DataTableProfile.Items.Count > 0)
            {
                List<DiffractionProfile> dp = new List<DiffractionProfile>();
                for (int i = 0; i < dataSet.DataTableProfile.Items.Count; i++)
                    dp.Add((DiffractionProfile)dataSet.DataTableProfile.Items[i]);
                if (!filename.ToLower().EndsWith(".pdi"))
                    filename += ".pdi";

                XYFile.SavePdiFile(dp.ToArray(), filename);
            }

        }


        private void toolTipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolTip.Active = toolTipToolStripMenuItem.Checked;
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            //コントロール内にドロップされたとき実行される
            //ドロップされたすべてのファイル名を取得する
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
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
                    readProfile(fileName[0]);
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            else
                e.Effect = DragDropEffects.None;//ファイル以外は受け付けない
        }

        //結晶データをリセットする
        private void resetInitialCrystalDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readCrystal(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\default.Xml", false, true);
        }

        private void helpwebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (japaneseToolStripMenuItem.Checked)
                    System.Diagnostics.Process.Start("http://pmsl.planet.sci.kobe-u.ac.jp/~seto/software/PDIndexer/ja/PDIndexerHelp.html");
                else
                    System.Diagnostics.Process.Start("http://pmsl.planet.sci.kobe-u.ac.jp/~seto/software/PDIndexer/en/PDIndexerHelp.html");

            }
            catch { }
        }

        public void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Shift && e.KeyCode == Keys.C && this.pictureBoxMain.Focused)
                copyAsMetafileToolStripMenuItem_Click(new object(), new EventArgs());

            if (e.Control && e.Shift && e.KeyCode == Keys.C)
                checkBoxCrystalParameter.Checked = !checkBoxCrystalParameter.Checked;
            else if (e.Control && e.Shift&& e.KeyCode == Keys.E)
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
                {
                    formCrystal.checkBoxCalculateIntensity.Checked = true;
                }
                else if (formCrystal.checkBoxShowPeakOverProfiles.Checked && formCrystal.checkBoxCalculateIntensity.Checked)
                {
                    formCrystal.checkBoxShowPeakOverProfiles.Checked = false;
                }
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                formStressAnalysis.Visible = !formStressAnalysis.Visible;
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.Space)
            {
                if(bindingSourceCrystal.Current != null && bindingSourceCrystal.Position>=0)
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

        private void toolStripMenuItemImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "cif, amc file | *.amc;*.cif";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Crystal c = ConvertCrystalData.ConvertToCrystal(dlg.FileName);
                if (c != null)
                    formCrystal.AddCrystal(c);
            }
        }

        private void checkedListBoxCrystals_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }


        private void watchReadANewProfileToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (watchReadANewProfileToolStripMenuItem.Checked)
            {
                if (Directory.Exists(watcher.Path))
                    watcher.EnableRaisingEvents = true;
            }
            else
            {
                watcher.EnableRaisingEvents = false;
            }
        }

        private void setDirectoryToTheWatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            
            if (dlg.ShowDialog() == DialogResult.OK)
                toolStripTextBoxDirectoryToWatch.Text = dlg.SelectedPath;
            
        }

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

        private void toolStripTextBoxDirectoryToWatch_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBoxDirectoryToWatch.Text != "")
            {
                watcher.Path = toolStripTextBoxDirectoryToWatch.Text;
                watchReadANewProfileToolStripMenuItem_CheckedChanged(new object(), new EventArgs());
            }
        }


        private void tabControl_Click(object sender, EventArgs e)
        {
            tabControl.BringToFront();
        }



        #region export関連
        private void toolStripMenuItemExportCSVFile_Click(object sender, EventArgs e)
        {
            if (dataSet.DataTableProfile.Items.Count == 0) return;

            var s = ((ToolStripMenuItem)sender).Name.Contains("CSV") ? "," : "\t";
            var dlg = new SaveFileDialog();
            dlg.Filter = s == "," ? "*.csv|*.csv" : "*.tsv|*.tsv";

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
                    using (StreamWriter writer = new StreamWriter(dlg.FileName))
                    {
                        dp.ForEach(d => writer.Write(d.Name + s + s + s)); //一行目
                        writer.Write("\r\n");
                        dp.ForEach(d => writer.Write("X" + s + "Y" + s + s));//二行目
                        writer.Write("\r\n");

                        for (int j = 0, max = dp.Max(d => d.Profile.Pt.Count); j < max; j++)//三行目以降
                        {
                            for (int i = 0; i < dp.Count; i++)
                                writer.Write(j < dp[i].Profile.Pt.Count ?
                                     dp[i].Profile.Pt[j].X.ToString() + s + dp[i].Profile.Pt[j].Y.ToString() + s + s :
                                     s + s + s);
                            writer.Write("\r\n");
                        }
                    }
                else//個別のファイルに分ける場合
                    dp.ForEach(d =>
                    {
                        var filename = dlg.FileName.Substring(0, dlg.FileName.Length-4) + " + " + d.Name + (s == "," ? ".csv" : ".tsv");
                        using (StreamWriter writer = new StreamWriter(filename))
                        {
                            writer.WriteLine("X" + s + "Y");//一行目
                            for (int i = 0; i < d.Profile.Pt.Count; i++)
                                writer.WriteLine(d.Profile.Pt[i].X.ToString() + s + d.Profile.Pt[i].Y.ToString());
                        }
                    });
            }
        }

        //GSASフォーマットとして吐き出す
        private void exportGSASFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bindingSourceProfile.Position < 0) return;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.gsa|*.gsa";
            DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1]; ;
            dlg.FileName = Path.GetFileNameWithoutExtension(dp.Name);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);
                double div = AxisMode == HorizontalAxis.NeutronTOF ? 1 : 100;

                //一行目
                writer.WriteLine(dp.Name);

                //二行目
                int ptCount = dp.Profile.Pt.Count;
                double startAngle = dp.Profile.Pt[0].X * div;
                double stepAngle = (dp.Profile.Pt[1].X - dp.Profile.Pt[0].X) * div;
                writer.WriteLine( "BANK 1 " + ptCount.ToString() + " " + ptCount.ToString() + " CONST " + startAngle.ToString("f2") + " " + stepAngle.ToString("f2") + " 0 0 FXYE");

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
                    string[] value = new string[3];
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
                            value[j] = value[j].Substring(0, 11);
                        if (value[j].EndsWith("."))
                            value[j] = " " + y.Substring(0, 10);
                        while (value[j].Length < 11)
                            value[j] = " " + value[j];
                    }
                    writer.WriteLine(" " + value[0] + " " + value[1] + " " + value[2]);
                }
                writer.Close();
            }
        }
        #endregion

        private void toolStripButtonCrystalParameter_Click(object sender, EventArgs e)
        {
            checkBoxCrystalParameter.Checked = !checkBoxCrystalParameter.Checked;
        }

        private void toolStripButtonProfileParameter_Click(object sender, EventArgs e)
        {
            checkBoxProfileParameter.Checked = !checkBoxProfileParameter.Checked;
        }

        private void hintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialDialog.ShowProgressBar = false;
            initialDialog.Text = "Hint";
            initialDialog.Visible = true;
        }

        private void toolStripMenuItemSaveMetafile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.emf|*.emf";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                saveMetafile(dlg.FileName);
            }
        }
        private void saveMetafile(string filename)
        {
            try
            {
                Graphics grfx = CreateGraphics();
                IntPtr ipHdc = grfx.GetHdc();
                MemoryStream ms = new MemoryStream();
                Metafile mf = new Metafile(ms, ipHdc, EmfType.EmfPlusDual);
                grfx.ReleaseHdc(ipHdc);
                grfx.Dispose();
                DrawMetafile(mf);

                if (!filename.ToLower().EndsWith(".emf"))
                    filename += ".emf";

                FileStream fsm = new FileStream(filename, FileMode.Create, FileAccess.Write);
                fsm.Write(ms.GetBuffer(), 0, (int)ms.Length);
                fsm.Close();

                mf.Dispose();
            }
            catch { }
        }

        private void checkBoxShowScaleLine_CheckedChanged_1(object sender, EventArgs e)
        {
            Draw();
        }



        #region DataGridViewCrystal関係のイベント

          List<int> blinkingCrystals = new List<int>();
        bool blinkFlag = false;
        public void dataGridViewCrystals_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //チェックボックスが直接クリックされた場合か、セレクションを変更せずに結晶の名前をクリックしたとき、現在チェック状況を逆転させる。
            //if(sender != formFitting)
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if ((e.ColumnIndex == 0 && e.RowIndex >= 0) || (e.ColumnIndex != 0 && e.RowIndex >= 0 && SelectedCrysatlIndex == bindingSourceCrystal.Position))
                    ((DataRowView)bindingSourceCrystal.Current).Row[0] = !(bool)((DataRowView)bindingSourceCrystal.Current).Row[0];
            }

            //Blinkingのセッティング
            if (e.RowIndex >= 0 && e.Button == System.Windows.Forms.MouseButtons.Right && e.Clicks == 2)
            {
                if (blinkingCrystals.Contains(e.RowIndex))
                {
                    blinkingCrystals.Remove(e.RowIndex);
                    dataGridViewCrystals.Rows[e.RowIndex].Cells[2].Style.SelectionForeColor =  Color.White;
                    dataGridViewCrystals.Rows[e.RowIndex].Cells[2].Style.ForeColor = Color.Black;
                }
                else
                    blinkingCrystals.Add(e.RowIndex);
            }
            if (blinkingCrystals.Count > 0)
                timerBlinkDiffraction.Start();

            //クリックによってセレクションが変更された場合
            if (SelectedCrysatlIndex != bindingSourceCrystal.Position)
            {
                SelectedCrysatlIndex = bindingSourceCrystal.Position;
                SelectedPlaneIndex = -1;
            }

            if (formCrystal.checkBoxShowPeakUnderProfile.Checked)
                BottomMargin = (HeightOfBottomPeaks + 4) * dataSet.DataTableCrystal.CheckedItems.Count;
            else
                BottomMargin = 0;
            InitializeCrystalPlane();

            SetFormCrystal(false);
            SetFormEOS();
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
    
 


    
        public bool StopCycling = false;

         private void dataGridViewCrystals_KeyUp(object sender, KeyEventArgs e)
        {

            if (SelectedCrysatlIndex != bindingSourceCrystal.Position)
            {
                SelectedCrysatlIndex = bindingSourceCrystal.Position;
                SetFormCrystal(false);
                SelectedPlaneIndex = -1;
            }
            Draw();
        }


        #endregion

         private void numericUpDownLimitChange_MouseDown(object sender, MouseEventArgs e)
         {
             int x = ((NumericUpDown)sender).Width;
         }

         #region UnrolledImage関連
         public void setFrequencyProfile()
         {
             if (dataSet.DataTableProfile.GetItemChecked(bindingSourceProfile.Position))
             {
                 
                 var dif = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1]; 
                 if (dif.ImageArray != null)
                 {
                     tabControl1.Visible = true;
                     Ring.Intensity.Clear();
                     Ring.Intensity.AddRange(dif.ImageArray);
                     Ring.CalcFreq();

                     Profile frequencyProfile = new Profile();
                     frequencyProfile.Pt = new List<PointD>();

                     for (int i = 0; i < Ring.Frequency.Count; i++)
                         frequencyProfile.Pt.Add(new PointD(Ring.Frequency.Keys[i], Ring.Frequency[Ring.Frequency.Keys[i]]));
                     graphControlFrequency.Profile = frequencyProfile;
                     graphControlFrequency.LineList = new PointD[2] { new PointD((double)0, double.NaN), new PointD((double)frequencyProfile.Pt[frequencyProfile.Pt.Count - 1].X, double.NaN) };
                     graphControlFrequency.Draw();
                     uint max = uint.MinValue;
                     foreach (uint u in dif.ImageArray)
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

         private void graphControlFrequency_LinePositionChanged()
         {
             if (graphControlFrequency.LineList.Length == 2)
             {
                 decimal max = (decimal)((int)Math.Max(graphControlFrequency.LineList[0].X, graphControlFrequency.LineList[1].X));
                 if (numericUpDownMaxInt.Maximum <= max)
                     numericUpDownMaxInt.Value = numericUpDownMaxInt.Maximum;
                 else if (numericUpDownMaxInt.Minimum >= max)
                     numericUpDownMaxInt.Value = numericUpDownMaxInt.Minimum;
                 else
                     numericUpDownMaxInt.Value = max;

                 decimal min = (decimal)((int)Math.Min(graphControlFrequency.LineList[0].X, graphControlFrequency.LineList[1].X));
                 if (numericUpDownMinInt.Maximum <= min)
                     numericUpDownMinInt.Value = numericUpDownMinInt.Maximum;
                 else if (numericUpDownMinInt.Minimum >= min)
                     numericUpDownMinInt.Value = numericUpDownMinInt.Minimum;
                 else
                     numericUpDownMinInt.Value = min;
             }
         }

         private void numericUpDownMinInt_ValueChanged(object sender, EventArgs e)
         {
                 if (numericUpDownMaxInt.Value <= numericUpDownMinInt.Value)
                 {
                     numericUpDownMaxInt.Value = numericUpDownMinInt.Value + 1;
                     return;
                 }
                 if (graphControlFrequency.LineList != null && graphControlFrequency.LineList.Length == 2)
                 {
                     graphControlFrequency.LineList[graphControlFrequency.LineList[0].X < graphControlFrequency.LineList[1].X ? 0 : 1].X = (double)numericUpDownMinInt.Value;
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
                 if (graphControlFrequency.LineList != null && graphControlFrequency.LineList.Length == 2)
                 {
                     graphControlFrequency.LineList[graphControlFrequency.LineList[0].X < graphControlFrequency.LineList[1].X ? 1 : 0].X = (double)numericUpDownMaxInt.Value;
                     graphControlFrequency.Draw();
                 }
                 Draw();
         }

          private void toolStripComboBoxScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            setScale();
        }
        private void toolStripComboBoxScale2_SelectedIndexChanged(object sender, EventArgs e)
        {
            setScale();
        }
        private void toolStripComboBoxGradient_SelectedIndexChanged(object sender, EventArgs e)
        {
            setScale();
        }

        private byte[] scaleR,scaleG,scaleB;
        private void setScale()
        {
            //スケールをセット
            if (comboBoxScale1.SelectedIndex == 0)//ログスケール
                if (comboBoxScale2.SelectedIndex == 0)//グレー
                    scaleR = scaleG = scaleB = PseudoBitmap.BrightnessScaleLog;
                else
                {
                    scaleR = PseudoBitmap.BrightnessScaleLogColorR;
                    scaleG = PseudoBitmap.BrightnessScaleLogColorG;
                    scaleB = PseudoBitmap.BrightnessScaleLogColorB;
                }
            else//リニア
                if (comboBoxScale2.SelectedIndex == 0)//グレー
                    scaleR = scaleG = scaleB = PseudoBitmap.BrightnessScaleLiner;
                else//color
                {
                    scaleR = PseudoBitmap.BrightnessScaleLinerColorR;
                    scaleG = PseudoBitmap.BrightnessScaleLinerColorG;
                    scaleB = PseudoBitmap.BrightnessScaleLinerColorB;
                }

            Draw();
        }
        private void checkBoxShowUnrolledImage_CheckedChanged(object sender, EventArgs e)
        {
            Draw();
        }
        #endregion

        private void tabControl1_Click(object sender, EventArgs e)
        {
            tabControl1.BringToFront();
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = ((ToolStripMenuItem)sender).Name.Contains("english");
            japaneseToolStripMenuItem.Checked = !englishToolStripMenuItem.Checked;
            Thread.CurrentThread.CurrentUICulture = englishToolStripMenuItem.Checked ? new System.Globalization.CultureInfo("en") : new System.Globalization.CultureInfo("ja");
            Language.Change(this);
        }

        private void radioButtonRawCounts_CheckedChanged(object sender, EventArgs e)
        {

            InitializeCrystalPlane();
            for (int i = 0; i < dataSet.DataTableProfile.Items.Count; i++)
            {
                DiffractionProfile d = (DiffractionProfile)dataSet.DataTableProfile.Items[i];
                d.IsCPS = radioButtonCountsPerStep.Checked;
                d.IsLogIntensity = radioButtonLogarithm.Checked;
                d.SetConvertedProfile(AxisMode, WaveLength, TakeoffAngle, TofAngle, TofLength);
            }
            SetDrawRangeLimit();
            ResetDrawRange();
            Draw();

            formFitting.ChangeHorizontalAxis();
        }

        bool skipAxisPropertyChangedEvent = false;
        /// <summary>
        /// 軸モードが変更されたときに呼び出される
        /// </summary>
        public void horizontalAxisUserControl_AxisPropertyChanged()
        {
            if (AxisMode == HorizontalAxis.Angle)
                labelX.Text = "2θ(deg.): ";
            else if (AxisMode == HorizontalAxis.d)
                labelX.Text = "d (Å): ";
            else if (AxisMode == HorizontalAxis.WaveNumber)
                labelX.Text = "q (/Å)";
            else if (AxisMode == HorizontalAxis.EnergyXray|| AxisMode == HorizontalAxis.EnergyElectron|| AxisMode == HorizontalAxis.EnergyNeutron)
                labelX.Text = "Energy (eV): ";
            else if (AxisMode == HorizontalAxis.NeutronTOF)
                labelX.Text = "TOF (μs)";
            
            if (skipAxisPropertyChangedEvent) return;
            
            for (int i = 0; i < dataSet.DataTableProfile.Items.Count; i++)
            {
                DiffractionProfile d = dataSet.DataTableProfile.Items[i];
                d.SetConvertedProfile(AxisMode, WaveLength, TakeoffAngle, TofAngle, TofLength);
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



        private void toolStripMenuItemExportCIF_Click(object sender, EventArgs e)
        {
            formCrystal.crystalControl.exportThisCrystalAsCIFToolStripMenuItem_Click(sender, e);
        }

        private void ngenCompileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ngen.Compile();
        }

        

        private void programUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramUpdates.CheckUpdate(Version.Software, Version.VersionAndDate))
                Close();
        }

        private void copyAsMetafileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics grfx = CreateGraphics();
            IntPtr ipHdc = grfx.GetHdc();
            MemoryStream ms = new MemoryStream();
            Metafile mf = new Metafile(ms, ipHdc, EmfType.EmfPlusDual);
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

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMacro.Visible = true;
        }

        public void SetMacroToMenu(string[] name)
        {
            if (macroToolStripMenuItem.DropDownItems.Count == 1)
                macroToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            for (int i = macroToolStripMenuItem.DropDownItems.Count - 1; i > 1; i--)
                macroToolStripMenuItem.DropDownItems.RemoveAt(i);


            for (int i = 0; i < name.Length; i++)
            {
                var item = new ToolStripMenuItem(name[i]);
                item.Name = name[i];
                item.Click += macroMenuItem_Click;
                macroToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        void macroMenuItem_Click(object sender, EventArgs e)
        {
            FormMacro.RunMacroName(((ToolStripMenuItem)sender).Name, false);
        }


        public enum FileType
        {
            CSV,
            RAS,
            NXS
        }

        public struct FileProperty
        {
            public bool Valid;
            public WaveSource WaveSource;
            public WaveColor WaveColor;
            public double Wavelength;
            public double TakeoffAngle;
            public HorizontalAxis AxisMode;
            public int XraySourceElementNumber;
            public XrayLine XrayLine;
            public double TofAngle;
            public double TofLength;
            public double ExposureTime;
            public double EGC0, EGC1, EGC2;
        }



        /// <summary>
        /// PDIのマクロ操作を提供する
        /// </summary>
        public class Macro : MacroBase
        {
            private FormMain main;
            
            public DrawingClass Drawing;
            public ProfileClass Profile;
            public ProfileOperatorClass ProfileOperator;
            public FileClass File;
            public CrystalClass Crystal;

            public Macro(FormMain _main)
                : base(_main, "PDI")
            {
                main = _main;
                Drawing = new DrawingClass(this);
                Profile = new ProfileClass(this);
                ProfileOperator = new ProfileOperatorClass(this);
                File = new FileClass(this);
                Crystal = new CrystalClass(this);
                
                help.Add("PDI.Obj[] # Get object sent from other program.");
            }

            public void Sleep(int millisec)
            {
                Thread.Sleep(millisec);
            }

            public object[] Obj { get; set; }

            public class FileClass : MacroSub
            {
                private Macro p;
                public FileClass(Macro _p)
                    : base(_p.main)
                {
                    this.p = _p;
                    p.help.Add("PDI.File.GetFileName() # Get a file name.  \r\n Returned string is a full path of the selected file.");
                    p.help.Add("PDI.File.GetFileNames() # Get file names.  \r\n Returned value is a string array, \r\n  each of which is a full path of selected files.");
                    p.help.Add("IPA.File.GetDirectoryPath(string filename) # Get a directory path.\r\n Returned string is a full path to the filename.\r\n If filename is omitted, selection dialog will open.");

                    p.help.Add("PDI.File.ReadProfiles(string filename) # Read profile data. \r\n If filename is omitted, selection dialog will open.");
                    p.help.Add("PDI.File.SaveProfiles(string filename) # Save profile data. \r\n If filename is omitted, selection dialog will open.");
                    p.help.Add("PDI.File.ReadCrystals(string filename) # Read crystal data. \r\n If filename is omitted, selection dialog will open.");
                    p.help.Add("PDI.File.SaveCrystals(string filename) # Save crystal data. \r\n If filename is omitted, selection dialog will open.");
                    p.help.Add("PDI.File.SaveMetafile(string filename) # Save metafile object. \r\n If filename is omitted, selection dialog will open.");
                }

                public string GetDirectoryPath(string filename = "") { return Execute<string>(new Func<string>(() => getDirectoryPath(filename))); }
                private string getDirectoryPath(string filename = "")
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


                public string GetFileName() { return Execute<string>(() => getFileName()); }
                private string getFileName()
                {
                    var dlg = new OpenFileDialog();
                    return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : "";
                }

                public string[] GetFileNames() { return Execute<string[]>(new Func<string[]>(() => getFileNames())); }
                private string[] getFileNames()
                {
                    var dlg = new OpenFileDialog();
                    dlg.Multiselect = true;
                    return dlg.ShowDialog() == DialogResult.OK ? dlg.FileNames : new string[0];
                }

                public void ReadProfiles(string fileName = "") { Execute(() => readProfiles(fileName)); }
                private void readProfiles(string fileName = "")
                {
                    if (!System.IO.File.Exists(fileName))
                        p.main.menuItemFileRead_Click(new object(), new EventArgs());
                    else
                        p.main.readProfile(fileName);
                }


                public void SaveProfiles(string filename = "") { Execute(new Action(() => saveProfiles(filename))); }
                private void saveProfiles(string filename = "")
                {
                    if (filename == "")
                        p.main.savePatternProfileToolStripMenuItem_Click(new object(), new EventArgs());
                    else
                        p.main.SaveProfile(filename);
                }

                public void ReadCrystals(string filename = "") { Execute(new Action(() => readCrystals(filename))); }
                private void readCrystals(string filename = "")
                {
                    if (!System.IO.File.Exists(filename))
                        p.main.menuItemReadCrystalData_Click(new object(), new EventArgs());
                    else
                        p.main.readCrystal(filename, false, true);
                }

                public void SaveCrystals(string filename = "") { Execute(new Action(() => saveCrystals(filename))); }
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

            }

            public class DrawingClass : MacroSub
            {
                private Macro p;
                public DrawingClass(Macro _p): base(_p.main)
                {
                    this.p = _p;
                    p.help.Add("PDI.Drawing.SetBounds(int StartX, int EndX, int StartY, int EndY) # Set drawing bounds.");

                    p.help.Add("PDI.Drawing.StartX # Set/get starting (left-side) value of X in drawing bounds.");
                    p.help.Add("PDI.Drawing.EndX # Set/get ending (right-side) value of X in drawing bounds.");
                    p.help.Add("PDI.Drawing.StartY # Set/get starting (top) value of Y in drawing bounds.");
                    p.help.Add("PDI.Drawing.EndY # Set/get ending (bottom) value of Y in drawing bounds.");

                    p.help.Add("PDI.Drawing.MaximumX #Set/get maximum value of X,  \r\n which is settable limit (not drawing bounds");
                    p.help.Add("PDI.Drawing.MaximumY #Set/get maximum value of Y,  \r\n which is settable limit (not drawing bounds");
                    p.help.Add("PDI.Drawing.MinimumX #Set/get minimum value of X,  \r\n which is settable limit (not drawing bounds");
                    p.help.Add("PDI.Drawing.MinimumY #Set/get minimum value of Y,  \r\n which is settable limit (not drawing bounds");

                }

                public double MaxX { get { return Execute(new Func<double>(() => p.main.MaximalX)); } set { Execute(new Action(() => p.main.MaximalX = value)); } }
                public double MinX { get { return Execute(new Func<double>(() => p.main.MinimalX)); } set { Execute(new Action(() => p.main.MinimalX = value)); } }
                public double MaxY { get { return Execute(new Func<double>(() => p.main.MaximalY)); } set { Execute(new Action(() => p.main.MaximalY = value)); } }
                public double MinY { get { return Execute(new Func<double>(() => p.main.MinimalY)); } set { Execute(new Action(() => p.main.MinimalY = value)); } }

                public double EndX { get { return Execute(new Func<double>(() => p.main.UpperX)); } set { Execute(new Action(() => p.main.UpperX = value)); } }
                public double StartX { get { return Execute(new Func<double>(() => p.main.LowerX)); } set { Execute(new Action(() => p.main.LowerX = value)); } }
                public double EndY { get { return Execute(new Func<double>(() => p.main.UpperY)); } set { Execute(new Action(() => p.main.UpperY = value)); } }
                public double StartY { get { return Execute(new Func<double>(() => p.main.LowerY)); } set { Execute(new Action(() => p.main.LowerY = value)); } }

                public void SetBounds(double xStart, double xEnd, double yStart, double yEnd)
                {
                    StartX = xStart; EndX = xEnd; StartY = yStart; EndY = yEnd;
                }
            }

            public class CrystalClass:MacroSub
            {
                private Macro p;
                public CrystalClass(Macro _p):base(_p.main)
                {
                    p = _p;
                    p.help.Add("PDI.Crystal.Count # Get total count of crystals.");
                    p.help.Add("PDI.Crystal.SelectedName # Get name of a selected crystal.");
                    p.help.Add("PDI.Crystal.SelectedIndex # Set/get index of a selected crystal.");
                    p.help.Add("PDI.Crystal.Select(int index) # Set index of a selected crystal.");
                    p.help.Add("PDI.Crystal.Check(int index) # Check a crystal assigned by 'index'.");
                    p.help.Add("PDI.Crystal.Uncheck(int index) # Uncheck a crystal assigned by 'index'.");
                }
                public int Count { get { return Execute(new Func<int>(() =>  p.main.bindingSourceCrystal.Count)); } }
                public string SelectedName { get { return Execute(new Func<string>(() =>  (SelectedIndex >= 0) ? ((Crystal)((DataRowView)p.main.bindingSourceCrystal.Current).Row[1]).Name : "")); } }

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
                    get { return Execute(new Func<int>(() => p.main.bindingSourceCrystal.Position)); }
                }

                public void Select(int n) { Execute(() => select(n)); }
                private void select(int n)
                {
                    if (n >= 0 && n < p.main.bindingSourceCrystal.Count) 
                        p.main.bindingSourceCrystal.Position = n;
                }

                
                public void Check(int n) { Check(n, true); }
                public void Uncheck(int n) { Check(n, false); }

                public void Check(int n, bool checkState) { Execute(() => check(n, checkState)); }
                private void check(int n, bool checkState)
                {
                    if (n >= 0 && n < p.main.bindingSourceCrystal.Count)
                    {
                        ((DataRowView)p.main.bindingSourceCrystal[n]).Row[0] = checkState;
                        p.main.dataGridViewCrystals_CellMouseClick(new object(), new DataGridViewCellMouseEventArgs(-1, -1, 0, 0, new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, 0, 0, 0)));
                    }
                }
            }

            public class ProfileOperatorClass: MacroSub
            {
                private Macro p;
                public ProfileOperatorClass(Macro _p): base(_p.main)
                {
                    p = _p;
                    p.help.Add("PDI.ProfileOperator.Average(int[] indices, string output) # Get average profile. 'indices' is array of itegers (like iArray = 1,3,5,9),  \r\n and 'output' is the profile name of result");
                    p.help.Add("PDI.ProfileOperator.AddTwoProfiles(int index1, int index2, string output)      # Calculate profile1 + profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result");
                    p.help.Add("PDI.ProfileOperator.SubtractTwoProfiles(int index1, int index2, string output) # Calculate profile1 - profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result");
                    p.help.Add("PDI.ProfileOperator.MultiplyTwoProfiles(int index1, int index2, string output) # Calculate profile1 * profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result");
                    p.help.Add("PDI.ProfileOperator.DivideTwoProfiles(int index1, int index2, string output)   # Calculate profile1 / profile2. \r\n  Each profile is assingned by index.  \r\n 'output' is the profile name of result");
                    p.help.Add("PDI.ProfileOperator.AddValueToProfile(int index1, double value, string output)   # Calculate profile + value. \r\n  Profile is assingned by index.  \r\n 'output' is the profile name of result");
                    p.help.Add("PDI.ProfileOperator.MultiplyValueToProfile(int index1, double value, string output)   # Calculate profile * value. \r\n  Profile is assingned by index (integer), and .  \r\n 'out' is the profile name of result");
                }
               
                public void Average(int[] intArray, string outputName = "") { Execute(() => average(intArray, outputName)); }
                private void average(int[] intArray, string outputName="")
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

                private void Arithmetic(int index1, int index2,string outputName="")
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

            public class ProfileClass : MacroSub
            {
                private Macro p;
                public ProfileClass(Macro _p) : base(_p.main)
                {
                    p = _p;
                    p.help.Add("PDI.Profile.Conut # Get total count of profiles.");
                    p.help.Add("PDI.Profile.SelectedName # Get name of a selected profile.");
                    p.help.Add("PDI.Profile.SelectedIndex # Set/get index of a selected profile.");
                    p.help.Add("PDI.Profile.Select(int index) # Set index of a selected profile.");
                    p.help.Add("PDI.Profile.Check(int index) # Check a profile assigned by index.");
                    p.help.Add("PDI.Profile.Uncheck(int index) # Uncheck a profile assigned by index.");
                    p.help.Add("PDI.Profile.CheckAll() # Check all profiles.");
                    p.help.Add("PDI.Profile.UncheckAll() # Uncheck all profiles.");
                    p.help.Add("PDI.Profile.DeleteAll() # Delete all profiles.");
                    p.help.Add("PDI.Profile.Delete(int index) # Delete a profile assigned by index.");
                }

                public void DeleteAll()
                {
                    Execute(() => p.main.formProfile.DeleteAllProfiles(false));
                }
                public void Delete(int n)
                {
                    Execute(new Action(() =>
                    {
                        Select(n);
                        p.main.formProfile.DeleteProfiles(n);
                    }));
                }

                public int Count
                {
                    get
                    {
                        return Execute(new Func<int>(() =>
                            p.main.bindingSourceProfile.Count
                            ));
                    }
                }

                public string SelectedName
                {
                    get
                    {
                        return Execute(new Func<string>(() =>
                            (SelectedIndex >= 0) ? ((DiffractionProfile)((DataRowView)p.main.bindingSourceProfile.Current).Row[1]).Name : ""
                            ));
                    }
                }

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
                    get
                    {
                        return Execute(new Func<int>(() => p.main.bindingSourceProfile.Position));
                    }
                }

                public void Select(int n)
                {
                    Execute(new Action(() =>
                        {
                            if (n >= 0 && n < p.main.bindingSourceProfile.Count)
                                p.main.bindingSourceProfile.Position = n;
                        }));
                }


                public void Check(int n)
                {
                    Execute(new Action(() =>
                        Check(n, true)
                        ));
                }
                public void Uncheck(int n)
                {
                    Execute(new Action(() =>
                        Check(n, false)
                        ));
                }

                public void Check(int n, bool checkState) { Execute(() => check(n, checkState)); }
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
        }

  

    }
}
