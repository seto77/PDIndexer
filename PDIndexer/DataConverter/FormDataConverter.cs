using Crystallography;
using Microsoft.Scripting.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PDIndexer
{
    public partial class FormDataConverter : Form
    {
        public FormDataConverter()
        {
            EGC = new[] { new[] { 0.0, 0.0, 0.0 } };
            EDXDetectorNumber = 1;

            InitializeComponent();
        }

        /// <summary>
        /// 露出時間
        /// </summary>
        public double ExposureTime { set => numericalTextBox1.Value = value; get => numericalTextBox1.Value; }

        public HorizontalAxis AxisMode
        {
            set
            {
                horizontalAxisUserControl.AxisMode = value;
                VisibleEDXSetting = HorizontalAxis.EnergyXray == value;
            }
            get => horizontalAxisUserControl.AxisMode;
        }

        public int XraySourceElementNumber { set => horizontalAxisUserControl.XrayWaveSourceElementNumber = value; get => horizontalAxisUserControl.XrayWaveSourceElementNumber; }

        public XrayLine XrayLine { set => horizontalAxisUserControl.XrayWaveSourceLine = value; get => horizontalAxisUserControl.XrayWaveSourceLine; }
        /// <summary>
        /// 電子線加速電圧(kV)を取得/設定
        /// </summary>
        public double ElectronAccVolatage { set => horizontalAxisUserControl.ElectronAccVoltage = value; get => horizontalAxisUserControl.ElectronAccVoltage; }

        public WaveSource WaveSource { set => horizontalAxisUserControl.WaveSource = value; get => horizontalAxisUserControl.WaveSource; }

        public WaveColor WaveColor { set => horizontalAxisUserControl.WaveColor = value; get => horizontalAxisUserControl.WaveColor; }
        /// <summary>
        /// nm単位の実数で取得/設定
        /// </summary>
        public double Wavelength { set => horizontalAxisUserControl.WaveLength = value; get => horizontalAxisUserControl.WaveLength; }
        /// <summary>
        /// EDXの取り出し角 ラジアン単位で取得/設定
        /// </summary>
        public double TakeoffAngle { set => horizontalAxisUserControl.TakeoffAngle = value; get => horizontalAxisUserControl.TakeoffAngle; }
        /// <summary>
        /// EDXの取り出し角 度単位で取得/設定
        /// </summary>
        public string TakeoffAngleText { set => horizontalAxisUserControl.TakeoffAngleText = value; get => horizontalAxisUserControl.TakeoffAngleText; }

        public EnergyUnitEnum EnergyUnit { set => horizontalAxisUserControl.EnergyUnit = value; get => horizontalAxisUserControl.EnergyUnit; }
        /// <summary>
        /// TOFの取り出し角 ラジアン単位で取得/設定
        /// </summary>
        public double TofAngle { set => horizontalAxisUserControl.TofAngle = value; get => horizontalAxisUserControl.TofAngle; }
        /// <summary>
        /// TOFの取り出し角 度単位で取得/設定
        /// </summary>
        public string TofAngleText { set => horizontalAxisUserControl.TofAngleText = value; get => horizontalAxisUserControl.TofAngleText; }
        /// <summary>
        /// TOFの検出距離 mm単位で取得/設定
        /// </summary>
        public double TofLength { set => horizontalAxisUserControl.TofLength = value; get => horizontalAxisUserControl.TofLength; }

        public bool TofUnitMicroSec { set => horizontalAxisUserControl.radioButtonTofUnitMicroSec.Checked = value; get => horizontalAxisUserControl.radioButtonTofUnitMicroSec.Checked; }

        public bool TofUnitNanoSec { set => horizontalAxisUserControl.radioButtonTofUnitNanoSec.Checked = value; get => horizontalAxisUserControl.radioButtonTofUnitNanoSec.Checked; }

        public double[][] EGC
        {
            get => EDXControls.Select(c => c.EGC).ToArray();
            set
            {
                for (int i = 0; i < EDXControls.Count && i < value.Length; i++)
                    EDXControls[i].EGC = value[i];
            }
        }

        public bool[] EDXDetectorValid
        {
            get => EDXControls.Select(c => c.Valid).ToArray();
            set
            {
                for (int i = 0; i < EDXControls.Count && i < value.Length; i++)
                    EDXControls[i].Valid = value[i];
            }
        }

        public List<EDXControl> EDXControls = new List<EDXControl>();
        public int EDXDetectorNumber
        {
            get => EDXControls.Count;
            set
            {
                if (value > 0 && flowLayoutPanelEDX!=null)
                {
                    if(value < EDXControls.Count)
                            EDXControls.RemoveRange(value, EDXControls.Count - value);
                    else if (value > EDXControls.Count)
                    {
                        flowLayoutPanelEDX.SuspendLayout();
                        while(value!=EDXControls.Count)
                        {
                            EDXControls.Add(new EDXControl() { DetectorName= $"#{EDXControls.Count}" });
                            flowLayoutPanelEDX.Controls.Add(EDXControls[^1]);
                        }
                        flowLayoutPanelEDX.ResumeLayout();
                    }

                    if (value == 1)
                    {
                        EDXControls[0].CheckBoxVisible = false;
                        EDXControls[0].Valid = true;
                    }
                }
            }
        }

        public double LowEnergyCutoffValue { set => numericBoxLowEnergyCutoff.Value = value; get => numericBoxLowEnergyCutoff.Value; }
        public bool LowEnergyCutoff { set => checkBoxLowEnergyCutoff.Checked = value; get => checkBoxLowEnergyCutoff.Checked; }

        public bool VisibleEDXSetting { set => groupBoxEDX.Visible = value; get => groupBoxEDX.Visible; }

        public bool VisibleTextBox { set => textBox.Visible = value; get => textBox.Visible; }

        //public bool RemoveKalpha2 { set => checkBoxRemoveKalpha2.Checked = value; get => checkBoxRemoveKalpha2.Checked; }

        private void horizontalAxisUserControl_AxisPropertyChanged()
        {
            groupBox1.Enabled = WaveSource == WaveSource.Xray && XrayLine == XrayLine.Ka;
            VisibleEDXSetting = WaveSource == WaveSource.Xray && WaveColor == WaveColor.FlatWhite;
        }

        public void SetProperty(FormMain.FileProperty property)
        {
            WaveSource = property.WaveSource;
            WaveColor = property.WaveColor;
            Wavelength = property.Wavelength;
            TakeoffAngle = property.TakeoffAngle;
            AxisMode = property.AxisMode;
            XraySourceElementNumber = property.XraySourceElementNumber;
            XrayLine = property.XrayLine;
            TofAngle = property.TofAngle;
            TofLength = property.TofLength;
            ExposureTime = property.ExposureTime;
            EGC = property.EGC;
            
        }
        public FormMain.FileProperty GetProperty()
        {
            return new FormMain.FileProperty()
            {
                Valid = true,
                WaveSource = this.WaveSource,
                WaveColor = this.WaveColor,
                Wavelength = this.Wavelength,
                TakeoffAngle = this.TakeoffAngle,
                AxisMode = this.AxisMode,

                XraySourceElementNumber = XraySourceElementNumber,
                XrayLine = XrayLine,
                TofAngle = TofAngle,
                TofLength = TofLength,
                ExposureTime = ExposureTime,
                EGC = EGC,
            };
        }
    }
}
