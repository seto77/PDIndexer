using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Crystallography;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PDIndexer
{
    public partial class FormProfileSetting : Form
    {
        #region プロパティ、フィールド
        public double TwoThetaOffsetCoeff0 { set => numericBoxTwhoThetaOffsetCoeff0.Value = value; get => numericBoxTwhoThetaOffsetCoeff0.Value; }
        public double TwoThetaOffsetCoeff1 { set => numericBoxTwhoThetaOffsetCoeff1.Value = value; get => numericBoxTwhoThetaOffsetCoeff1.Value; }
        public double TwoThetaOffsetCoeff2 { set => numericBoxTwhoThetaOffsetCoeff2.Value = value; get => numericBoxTwhoThetaOffsetCoeff2.Value; }

        public int SelectedMaskIndex
        {
            set
            {
                if (listBoxMaskRanges.Items.Count > value && listBoxMaskRanges.SelectedIndex != value)
                    listBoxMaskRanges.SelectedIndex = value;
            }
            get => listBoxMaskRanges.SelectedIndex;
        }

        public FormMain formMain;
        #endregion

        public FormProfileSetting()
        {
            InitializeComponent();
            bindingSourceProfile.CurrentChanged += new EventHandler(bindingSource_CurrentChanged);
        }
        private void FormProfileSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            formMain.checkBoxProfileParameter.Checked = false;
        }

     


     


        //プロファイル削除ボタンが押されたとき
        private void buttonDeleteProfile_Click(object sender, EventArgs e)
        {
            if (bindingSourceProfile.Position >= 0)
                DeleteProfiles(bindingSourceProfile.Position);
        }
        public void DeleteProfiles(int n)
        {
            if (n >= 0 && n < bindingSourceProfile.Count)
            {
                skipEvent = true;
                dataSetProfile.DataTableProfile.Rows.RemoveAt(n);
                //if (dataSet.DataTableProfile.Rows.Count == 1)
                bindingSourceProfile.Position = 0;
                if (n < dataSetProfile.DataTableProfile.Rows.Count)
                    bindingSourceProfile.Position = n;
                else if (n - 1 >= 0 && n - 1 < dataSetProfile.DataTableProfile.Rows.Count)
                    bindingSourceProfile.Position = n - 1;
                skipEvent = false;
                bindingSource_CurrentChanged(new object(), new EventArgs());
                formMain.SetDrawRangeLimit();
                formMain.Draw();
            }
        }


        private void buttonDeleteAllProfiles_Click(object sender, EventArgs e) => DeleteAllProfiles();
        public void DeleteAllProfiles(bool alert = true)
        {
            if (alert && MessageBox.Show("Do you want to delete all profiles?", "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            bindingSourceProfile.Position = 0;
            //for (int i = 0; i < dataSetProfile.DataTableProfile.Items.Count; i++)
            //    dataSetProfile.DataTableProfile.RemoveItem(i--);
            dataSetProfile.DataTableProfile.Clear();
            formMain.SetDrawRangeLimit();
            formMain.Draw();
        }

        private void checkBoxSmoothing_CheckedChanged(object sender, EventArgs e)
        {
            panelSmoothing.Visible = checkBoxSmoothing.Checked;
            SetCurrentProfile();
            formMain.SetDrawRangeLimit();
        }
        private void checkBoxBandPassFilter_CheckedChanged(object sender, EventArgs e)
        {
            panelBandPassFilter.Visible = checkBoxBandPassFilter.Checked;
            if (bindingSourceProfile.Position >= 0)
            {
                DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                string unit = "";
                switch (dp.DestAxisMode)
                {
                    case HorizontalAxis.Angle: unit = "°"; break;
                    case HorizontalAxis.d: unit = "Å"; break;
                    case HorizontalAxis.EnergyXray: unit = "eV"; break;
                    case HorizontalAxis.NeutronTOF: unit = "ms"; break;
                }
 
                labelLowPath.Text = "= " + (1 / (double)numericUpDownLowPass.Value).ToString("f4") +" " + unit;
                labelHighPass.Text = "= " + (1 / (double)numericUpDownHighPass.Value).ToString("f4") + " " + unit;
            }

            SetCurrentProfile();
            formMain.SetDrawRangeLimit();
        }

        private void checkBoxMaskingMode_CheckedChanged(object sender, EventArgs e)
        {
            panelMaskingMode.Visible = checkBoxMaskingMode.Checked;

            if (checkBoxMaskingMode.Checked && checkBoxShowBackgroundProfile.Checked)
                checkBoxShowBackgroundProfile.Checked = false;

            formMain.MaskingMode = checkBoxMaskingMode.Checked;

            SetCurrentProfile();
            formMain.SetDrawRangeLimit();
        }

        private void checkBoxTwoThetaOffset_CheckedChanged(object sender, EventArgs e)
        {
            panelTwoThetaOffset.Visible = checkBoxTwoThetaOffset.Checked;
            if (!checkBoxTwoThetaOffset.Checked)
                formMain.formTwoThetaCalibration.Visible = false;

            SetCurrentProfile();
            formMain.SetDrawRangeLimit();
        }

        private void checkBoxBackgroundSubtraction_CheckedChanged(object sender, EventArgs e)
        {
            panelBackgroundSubtraction.Visible = checkBoxBackgroundSubtraction.Checked;
            panelBackgroundBSpline.Enabled = radioButtonBagkgroundBSpline.Checked;
            panelBackgroundReferrence.Enabled = radioButtonBackgroundReferrence.Checked;
            formMain.ShowBackgroundProfile = (checkBoxShowBackgroundProfile.Checked && checkBoxBackgroundSubtraction.Checked);
            formMain.BackGroundPointSelectMode = radioButtonBagkgroundBSpline.Checked;

            SetCurrentProfile();
            formMain.SetDrawRangeLimit();
        }
        private void checkBoxShiftHorizontalAxis_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownShiftHorizontalAxis.Enabled = checkBoxShiftHorizontalAxis.Checked;
            SetCurrentProfile();
            formMain.SetDrawRangeLimit();
        }

        private void checkBoxRemoveKalpha2_CheckedChanged(object sender, EventArgs e)
        {
            SetCurrentProfile();
            formMain.SetDrawRangeLimit();
        }

        private void checkBoxNormarizeIntensity_CheckStateChanged(object sender, EventArgs e)
        {
            panelNormarizeIntensity.Visible = checkBoxNormarizeIntensity.Checked;
            SetCurrentProfile();
            formMain.SetDrawRangeLimit();
        }

        private void buttonAutoDetectBG_Click(object sender, EventArgs e)
        {
            if (bindingSourceProfile.Position >= 0)
            {
                DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                dp.BgPointsNumber = (int)numericUpDownBgPointsNumber.Value;
                dp.getBgPointsAuto();
                dp.SetSmoothingProfile();
                formMain.Draw();
            }
        }

        //コメント欄が変更されたとき
        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            if (bindingSourceProfile.Position >= 0)
            {
                setCommentOption((DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1]);
            }
        }

        /// <summary>
        /// 現在選択中のプロファイルに対して、マスク、スムース、バンパス、バックグラウンド、ノーマライズ等の処理を行い、再描画する。
        /// </summary>
        public void SetCurrentProfile()
        {
            if (skipEvent) return;
            if (bindingSourceProfile.Position >= 0)
            {
                DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                setTwoThetaOffsetOption(dp);
                setMaskingOption(dp);
                setNormarizeOption(dp);
                setSmoothingOption(dp);
                setBandPassOption(dp);
                setRemoveKalpha2Option(dp);
                setBackgroundOption(dp);
                setShiftOption(dp);
                setCommentOption(dp);
                
                dp.SetConvertedProfile(formMain.AxisMode, formMain.WaveLength, formMain.TakeoffAngle, formMain.TofAngle, formMain.TofLength);

                formMain.SetDrawRangeLimit();
                formMain.Draw();
            }
        }
        private void buttonApplyAllProfiles_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataSetProfile.DataTableProfile.Rows.Count; i++)
            {
                DiffractionProfile dp = (DiffractionProfile)dataSetProfile.DataTableProfile.Rows[i][1];
                setMaskingOption(dp);
                setNormarizeOption(dp);
                setSmoothingOption(dp);
                setTwoThetaOffsetOption(dp);
                setBandPassOption(dp);
                setShiftOption(dp);
            }
            formMain.SetDrawRangeLimit();
            formMain.Draw();
        }
        private void setMaskingOption(DiffractionProfile dp)
        {
            dp.DoesMaskAndInterpolate = checkBoxMaskingMode.Checked;
            dp.InterpolationOrder = (int)numericUpDownInterpolationOrder.Value;
            dp.InterpolationPoints = (int)numericUpDownInterpolationPoints.Value;
        }
        private void setNormarizeOption(DiffractionProfile dp)
        {
            //ノーマライズ関連
            dp.DoesNormarizeIntensity = checkBoxNormarizeIntensity.Checked;
            dp.NormarizeAsAverage = radioButtonNormarizeAverage.Checked;
            dp.NormarizeRangeStart = (double)numericUpDownNormarizeRangeLow.Value;
            dp.NormarizeRangeEnd = (double)numericUpDownNormarizeRangeHigh.Value;
            dp.NormarizeIntensity = (double)numericUpDownNormarizeIntensity.Value;
        }
        private void setSmoothingOption(DiffractionProfile dp)
        {
            //smoothing関連
            dp.DoesSmoothing = checkBoxSmoothing.Checked;
            dp.SazitkyGorayM = (int)numericUpDownSmoothingSavitzkyAndGolayM.Value;
            dp.SazitkyGorayN = (int)numericUpDownSmoothingSavitzkyAndGolayN.Value;
        }
        private void setTwoThetaOffsetOption(DiffractionProfile dp)
        {
            dp.DoesTwoThetaOffset = checkBoxTwoThetaOffset.Checked;
            dp.TwoThetaOffsetCoeff0 = numericBoxTwhoThetaOffsetCoeff0.Value;
            dp.TwoThetaOffsetCoeff1 = numericBoxTwhoThetaOffsetCoeff1.Value;
            dp.TwoThetaOffsetCoeff2 = numericBoxTwhoThetaOffsetCoeff2.Value;
        }
        private void setRemoveKalpha2Option(DiffractionProfile dp)
        {
            dp.DoesRemoveKalpha2 = checkBoxRemoveKalpha2.Checked;
        }
        private void setBandPassOption(DiffractionProfile dp){

            //bandpass関連
            dp.DoesBandpassFilter = checkBoxBandPassFilter.Checked;
            dp.DoesHighPath = checkBoxHighPassFilter.Checked;
            dp.DoesLowPath = checkBoxLowPassFilter.Checked;
            dp.HighPathLimit = (double)numericUpDownHighPass.Value;
            dp.LowPathLimit = (double)numericUpDownLowPass.Value;
        }
        private void setBackgroundOption(DiffractionProfile dp)
        {

            //background関連
            dp.SubtractBackground = checkBoxBackgroundSubtraction.Checked;
            dp.BgMode = radioButtonBagkgroundBSpline.Checked ? BackgroundMode.BSplineCurve : BackgroundMode.ReferrenceProfile;
            if (comboBoxBackgroundReferrence.SelectedIndex >= 0 && comboBoxBackgroundReferrence.SelectedIndex != bindingSourceProfile.Position)
                dp.BackgroundReferrenceProfile = ((DiffractionProfile)dataSetProfile.DataTableProfile.Rows[comboBoxBackgroundReferrence.SelectedIndex][1]).Profile;
            else
                dp.BackgroundReferrenceProfile = null;
            dp.BackgroundReferrenceScale = (double)numericUpDownBackgroundReferrenceScale.Value;

        }
        private void setShiftOption(DiffractionProfile dp)
        {
            //shift関連
            dp.IsShiftX = checkBoxShiftHorizontalAxis.Checked;
            dp.ShiftX = (double)numericUpDownShiftHorizontalAxis.Value;

            dp.SetConvertedProfile(formMain.AxisMode, formMain.WaveLength, formMain.TakeoffAngle, formMain.TofAngle, formMain.TofLength);
        }

        private void setCommentOption(DiffractionProfile dp) => dp.Comment = textBoxComment.Text;

 

        private void buttonSetDefaultProfile_Click(object sender, EventArgs e)
        {
            //smoothingをするかどうか
            formMain.defaultDP.DoesSmoothing = checkBoxSmoothing.Checked;
            //SavitkyGolayをするかどうか
            formMain.defaultDP.SazitkyGorayM = (int)numericUpDownSmoothingSavitzkyAndGolayM.Value;
            formMain.defaultDP.SazitkyGorayN = (int)numericUpDownSmoothingSavitzkyAndGolayN.Value;
            //background減算をするかどうか
            formMain.defaultDP.SubtractBackground = checkBoxBackgroundSubtraction.Checked;
            formMain.defaultDP.BgPointsNumber = (int)numericUpDownBgPointsNumber.Value;
        }


        private void buttonUpper_Click(object sender, EventArgs e)
        {
            int n = bindingSourceProfile.Position;
            if (n < 1 ) return;
            dataSetProfile.DataTableProfile.MoveItem(n, n - 1);
            bindingSourceProfile.Position = n - 1;
        }

        private void buttonLower_Click(object sender, EventArgs e)
        {
            int n = bindingSourceProfile.Position;
            if (n < 0  || n >= dataSetProfile.DataTableProfile.Items.Count - 1) return;
            dataSetProfile.DataTableProfile.MoveItem(n, n + 1);
            bindingSourceProfile.Position = n + 1;

        }

        private void buttonChangeSouceXAxis_Click(object sender, EventArgs e)
        {
            if (bindingSourceProfile.Position >= 0)
            {
                DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                dp.SrcAxisMode = xAxisUserControl.AxisMode;
                dp.SrcTakeoffAngle = xAxisUserControl.TakeoffAngle;
                dp.SrcWaveLength = xAxisUserControl.WaveLength;
                dp.ExposureTime = numericalTextBoxExposureTime.Value;

                formMain.horizontalAxisUserControl_AxisPropertyChanged();
            }
        }

        private void dataGridViewProfile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxComment.Enabled = e.RowIndex >= 0;//コメント欄を有効にするかどうか
            formMain.dataGridViewProfiles_CellClick(sender, e);
        }

        bool skipEvent = false;
        public void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (skipEvent) return;
            if (bindingSourceProfile.Position >= 0)
            {
                skipEvent = true;
                DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
               colorControlLineColor.Color = Color.FromArgb(dp.ColorARGB.Value);

                //TwoThetaOffset関連
                checkBoxTwoThetaOffset.Checked = panelTwoThetaOffset.Visible = dp.DoesTwoThetaOffset;
                numericBoxTwhoThetaOffsetCoeff0.Value = dp.TwoThetaOffsetCoeff0;
                numericBoxTwhoThetaOffsetCoeff1.Value = dp.TwoThetaOffsetCoeff1;
                numericBoxTwhoThetaOffsetCoeff2.Value = dp.TwoThetaOffsetCoeff2;

                //MaskingRange関連
                checkBoxMaskingMode.Checked = panelMaskingMode.Visible = dp.DoesMaskAndInterpolate;
               listBoxMaskRanges.Items.Clear();
               listBoxMaskRanges.Items.AddRange(dp.maskingRanges.ToArray());
               numericUpDownInterpolationOrder.Value = (decimal)dp.InterpolationOrder;
               numericUpDownInterpolationPoints.Value = (decimal)dp.InterpolationPoints;

                //Smoothing関連
                checkBoxSmoothing.Checked = panelSmoothing.Visible = dp.DoesSmoothing;
                numericUpDownSmoothingSavitzkyAndGolayM.Value = dp.SazitkyGorayM;
                numericUpDownSmoothingSavitzkyAndGolayN.Value = dp.SazitkyGorayN;
                checkBoxSmoothing.Checked = panelSmoothing.Visible = dp.DoesSmoothing;

                checkBoxRemoveKalpha2.Checked = dp.DoesRemoveKalpha2;

                //ShiftX関連
                checkBoxShiftHorizontalAxis.Checked = numericUpDownShiftHorizontalAxis.Enabled = dp.IsShiftX;
                numericUpDownShiftHorizontalAxis.Value = (decimal)dp.ShiftX;

                //Background関連
                checkBoxBackgroundSubtraction.Checked = panelBackgroundSubtraction.Visible = dp.SubtractBackground;
                radioButtonBagkgroundBSpline.Checked = panelBackgroundBSpline.Enabled = dp.BgMode == BackgroundMode.BSplineCurve;
                radioButtonBackgroundReferrence.Checked = panelBackgroundReferrence.Enabled = dp.BgMode == BackgroundMode.ReferrenceProfile;

                //FFT関連
                checkBoxBandPassFilter.Checked = panelBandPassFilter.Visible = dp.DoesBandpassFilter;
                checkBoxHighPassFilter.Checked = dp.DoesHighPath;
                checkBoxLowPassFilter.Checked = dp.DoesLowPath;
                if (dp.Profile.Pt.Count > 2)
                {
                    double max = 1 / (dp.Profile.Pt[1].X - dp.Profile.Pt[0].X);
                    double min = 1 / (dp.Profile.Pt[dp.Profile.Pt.Count - 1].X - dp.Profile.Pt[0].X);
                    int decimalPlaces = min > 1 ? 0 : -(int)Math.Log10(min) + 1;

                    if (!double.IsInfinity(max) && !double.IsInfinity(min))
                    {
                        numericUpDownHighPass.Maximum = !double.IsInfinity(max) ? (decimal)max : numericUpDownHighPass.Maximum;
                        numericUpDownHighPass.Minimum = !double.IsInfinity(min) ? (decimal)min : numericUpDownHighPass.Minimum;
                        numericUpDownHighPass.DecimalPlaces = decimalPlaces;
                        numericUpDownHighPass.Increment = !double.IsInfinity(min) ? (decimal)min : numericUpDownHighPass.Increment;
                        if (double.IsNaN(dp.HighPathLimit) || dp.HighPathLimit > max || dp.HighPathLimit < min)
                            dp.HighPathLimit = min;
                        numericUpDownHighPass.Value = (decimal)dp.HighPathLimit;

                        numericUpDownLowPass.Maximum = !double.IsInfinity(max) ? (decimal)max : numericUpDownHighPass.Maximum;
                        numericUpDownLowPass.Minimum = (decimal)min;
                        numericUpDownLowPass.DecimalPlaces = decimalPlaces;
                        numericUpDownLowPass.Increment = !double.IsInfinity(max) ? (decimal)(max / 100) : (decimal)(numericUpDownHighPass.Maximum / 100);
                        if (double.IsNaN(dp.LowPathLimit) || dp.LowPathLimit > max || dp.LowPathLimit < min)
                            dp.LowPathLimit = max;
                        numericUpDownLowPass.Value = (decimal)dp.LowPathLimit;
                    }
                }
                //FFT関連ここまで

                //Normarize関連
                checkBoxNormarizeIntensity.Checked = panelNormarizeIntensity.Visible = dp.DoesNormarizeIntensity;
                radioButtonNormarizeAverage.Checked = dp.NormarizeAsAverage;
                radioButtonNormarizeMaximum.Checked = !dp.NormarizeAsAverage;
                numericUpDownNormarizeIntensity.Value = Math.Max(Math.Min(numericUpDownNormarizeIntensity.Maximum, (decimal)dp.NormarizeIntensity), numericUpDownNormarizeIntensity.Minimum);
                numericUpDownNormarizeRangeHigh.Value = (decimal)dp.NormarizeRangeEnd;
                numericUpDownNormarizeRangeLow.Value = (decimal)dp.NormarizeRangeStart;

                //露出時間
                numericalTextBoxExposureTime.Value = dp.ExposureTime;

                //横軸関連
                xAxisUserControl.AxisMode = dp.SrcAxisMode;
                xAxisUserControl.WaveSource = dp.WaveSource;
                xAxisUserControl.XrayWaveSourceElementNumber = dp.XrayElementNumber;
                xAxisUserControl.XrayWaveSourceLine = dp.XrayLine;
                if (dp.XrayElementNumber==0)
                    xAxisUserControl.WaveLength = dp.SrcWaveLength;
                xAxisUserControl.TakeoffAngle = dp.SrcTakeoffAngle;

             //   if(xAxisUserControl.WaveSource== WaveSource.Xray && xAxisUserControl.XrayWaveSourceElementNumber!=0 && xAxisUserControl.XrayWaveSourceLine == XrayLine.Ka)
             //       numericBoxKalpha1.Value = 

                textBoxProfileName.Text = dp.Name;
                numericUpDownLineWidth.Value = (decimal)dp.LineWidth;
                skipEvent = false;

                formMain.setFrequencyProfile();

                formMain.formFitting.RemovedProfileName = dp.Name + "_new";
                if (formMain.formFitting.Visible)
                    formMain.formFitting.Fitting();

                //コメント欄
                textBoxComment.Text = dp.Comment;
            }

           textBoxComment.Enabled =  bindingSourceProfile.Position >= 0;
           formMain.checkBoxAll.Enabled = bindingSourceProfile.Position >= 0;
            //formMain.Draw();

        }

        private void colorControlLineColor_ColorChanged(object sender, EventArgs e)
        {
            if (skipEvent) return;
            
            if (bindingSourceProfile.Position >= 0)
            {
                DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                dp.ColorARGB = colorControlLineColor.Color.ToArgb();

               Graphics g = Graphics.FromImage((Bitmap)dataSetProfile.DataTableProfile.Rows[bindingSourceProfile.Position][2]);
               g.Clear(colorControlLineColor.Color);
               dataGridViewProfile.Refresh();
               formMain.dataGridViewProfiles.Refresh();
               formMain.Draw();
            }
        }
        private void textBoxProfileName_TextChanged(object sender, EventArgs e)
        {
            if (skipEvent) return;
            bindingSource_ListChanged(new object(), new ListChangedEventArgs( ListChangedType.ItemChanged,0));
            if (bindingSourceProfile.Position >= 0)
            {
                DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                dp.Name = textBoxProfileName.Text;
                dataGridViewProfile.Refresh();
                formMain.dataGridViewProfiles.Refresh();
            }
        }

        private void numericUpDownLineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (skipEvent) return;
            if (bindingSourceProfile.Position >= 0)
            {
                DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
                dp.LineWidth = (float)numericUpDownLineWidth.Value;
            }
            formMain.Draw();
        }

     

        private void radioButtonAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAverage.Checked)
            {
                listBoxTwoProfiles2.Visible = false;
                flowLayoutPanelFourCalculator.Visible = false;
                listBoxTwoProfiles1.SelectionMode = SelectionMode.MultiExtended;
            }
            else if (radioButtonProfileAndValue.Checked)
            {
                listBoxTwoProfiles2.Visible = false;
                radioButtonDivision.Visible = false;
                radioButtonSubtraction.Visible = false;
                flowLayoutPanelFourCalculator.Visible = true;
                numericalTextBoxTargetValue.Visible = true;
                listBoxTwoProfiles1.SelectionMode = SelectionMode.One;

            }
            else if (radioButtonTwoProfiles.Checked)
            {
                listBoxTwoProfiles2.Visible = true;
                radioButtonDivision.Visible = true;
                radioButtonSubtraction.Visible = true;
                flowLayoutPanelFourCalculator.Visible = true;
                numericalTextBoxTargetValue.Visible = false;
                listBoxTwoProfiles1.SelectionMode = SelectionMode.One;
            }
        }


        public void bindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            listBoxTwoProfiles1.Items.Clear();
            listBoxTwoProfiles2.Items.Clear();
            try
            {
                for (int i = 0; i < dataSetProfile.DataTableProfile.Rows.Count; i++)
                {
                    string str = ((DiffractionProfile)dataSetProfile.DataTableProfile.Rows[i][1]).Name;
                    listBoxTwoProfiles1.Items.Add(str);
                    listBoxTwoProfiles2.Items.Add(str);
                }
            }
            catch { }
        }

        public void buttonCalculate_Click(object sender, EventArgs e)
        {
            var bmp = new Bitmap(18, 18);
            var g = Graphics.FromImage(bmp);
            var c = formMain.generateRandomColor();
            g.Clear(c);

            var p = new Profile();

            if (radioButtonAverage.Checked && listBoxTwoProfiles1.SelectedIndices.Count >= 1)
            {
                var baseIndex = 0;
                var max = double.NegativeInfinity;
                var dp = new DiffractionProfile[listBoxTwoProfiles1.SelectedIndices.Count];
                for (int i = 0; i < listBoxTwoProfiles1.SelectedIndices.Count; i++)
                {
                    dp[i] = (DiffractionProfile)dataSetProfile.DataTableProfile.Rows[listBoxTwoProfiles1.SelectedIndices[i]][1];
                    if (max < dp[i].Profile.Pt[dp[i].Profile.Pt.Count - 1].X - dp[i].Profile.Pt[0].X)
                    {
                        max = dp[i].Profile.Pt[dp[i].Profile.Pt.Count - 1].X - dp[i].Profile.Pt[0].X;
                        baseIndex = i;
                    }
                }
                for (int j = 0; j < dp[baseIndex].Profile.Pt.Count; j++)
                {
                    p.Pt.Add(new PointD(dp[baseIndex].Profile.Pt[j].X, 0));
                    p.Err.Add(new PointD(dp[baseIndex].Profile.Pt[j].X, 0));
                }
                //強度の積算
                for (int i = 0; i < dp.Length; i++)
                    for (int j = 0; j < p.Pt.Count; j++)
                        //p.Pt[j].Y += dp[i].Profile.GetValue(p.Pt[j].X, 2, 1) / dp.Length;
                        p.Pt[j] += new PointD(0, dp[i].Profile.GetValue(p.Pt[j].X, 2, 1) / dp.Length);
                 //誤差の計算
                        for (int j = 0; j < p.Pt.Count; j++)
                {
                    int n = 0;
                    for (int i = 0; i < dp.Length; i++)
                    {
                        double err = dp[i].Profile.GetErr(p.Pt[j].X);
                        if (err != 0)
                        {
                            n++;
                            //p.Err[j].Y += err * err;
                            p.Err[j] += new PointD(0, err * err);
                        }
                    }
                    if (n != 0)
                        //p.Err[j].Y =  Math.Sqrt(p.Err[j].Y) / n;
                        p.Err[j] = new PointD(p.Err[j].X, Math.Sqrt(p.Err[j].Y) / n);
                }
            }
            else if (radioButtonTwoProfiles.Checked
                && listBoxTwoProfiles1.SelectedIndex >= 0 && listBoxTwoProfiles2.SelectedIndex >= 0
                && listBoxTwoProfiles1.SelectedIndex != listBoxTwoProfiles2.SelectedIndex)
            {
                DiffractionProfile[] dp = new DiffractionProfile[]{
                    (DiffractionProfile)dataSetProfile.DataTableProfile.Rows[listBoxTwoProfiles1.SelectedIndex][1],
                    (DiffractionProfile)dataSetProfile.DataTableProfile.Rows[listBoxTwoProfiles2.SelectedIndex][1]};

                for (int j = 0; j < dp[0].Profile.Pt.Count; j++)
                {
                    p.Pt.Add(new PointD(dp[0].Profile.Pt[j].X, dp[0].Profile.Pt[j].Y));//参照渡しを避けるため
                    p.Err.Add(new PointD(dp[0].Profile.Pt[j].X, j < dp[0].Profile.Err.Count ? dp[0].Profile.Err[j].Y : 0));
                }

                for (int j = 0; j < p.Pt.Count; j++)
                    if (radioButtonAddition.Checked)//足し算
                    {
                        //p.Pt[j].Y = p.Pt[j].Y + dp[1].Profile.GetValue(p.Pt[j].X, 1, 0);
                        p.Pt[j] = new PointD(p.Pt[j].X, p.Pt[j].Y + dp[1].Profile.GetValue(p.Pt[j].X, 1, 0));

                        double err1 = p.Err[j].Y, err2 = dp[1].Profile.GetErr(p.Pt[j].X);
                        //p.Err[j].Y = Math.Sqrt(err1 * err1 + err2 * err2);
                        p.Err[j] =new PointD(p.Err[j].X, Math.Sqrt(err1 * err1 + err2 * err2));
                    }
                    else if (radioButtonSubtraction.Checked)//引き算
                    {
                        //p.Pt[j].Y = p.Pt[j].Y - dp[1].Profile.GetValue(p.Pt[j].X, 1, 0);
                        p.Pt[j] =new PointD(p.Pt[j].X, p.Pt[j].Y - dp[1].Profile.GetValue(p.Pt[j].X, 1, 0));
                        double err1 = p.Err[j].Y, err2 = dp[1].Profile.GetErr(p.Pt[j].X);
                        //p.Err[j].Y = Math.Sqrt(err1 * err1 + err2 * err2);
                        p.Err[j] = new PointD(p.Err[j].X, Math.Sqrt(err1 * err1 + err2 * err2));
                    }
                    else if (radioButtonMutiplication.Checked)//掛け算
                    {
                        //p.Pt[j].Y = p.Pt[j].Y * dp[1].Profile.GetValue(p.Pt[j].X, 1, 0);
                        p.Pt[j] = new PointD(p.Pt[j].X, p.Pt[j].Y * dp[1].Profile.GetValue(p.Pt[j].X, 1, 0));
                        double err1 = p.Err[j].Y / p.Err[j].Y, err2 = dp[1].Profile.GetErr(p.Pt[j].X) / dp[1].Profile.GetValue(p.Pt[j].X, 1, 0);
                        if (Math.Abs(err1) > 10E-10 && Math.Abs(err2) > 10E-10)
                            //p.Err[j].Y = p.Pt[j].Y * Math.Sqrt(err1 * err1 + err2 * err2);
                            p.Err[j] = new PointD(p.Err[j].X, p.Pt[j].Y * Math.Sqrt(err1 * err1 + err2 * err2));
                    }
                    else if (radioButtonDivision.Checked)
                    {
                        if (Math.Abs(dp[1].Profile.GetValue(p.Pt[j].X, 1, 0)) < 10E-10)
                        {
                            p.Pt.RemoveAt(j);
                            p.Err.RemoveAt(j);
                        }
                        else
                        {
                            //p.Pt[j].Y = p.Pt[j].Y / dp[1].Profile.GetValue(p.Pt[j].X, 1, 0);
                            p.Pt[j] = new PointD(p.Pt[j].X, p.Pt[j].Y / dp[1].Profile.GetValue(p.Pt[j].X, 1, 0));
                            double err1 = p.Err[j].Y / p.Err[j].Y, err2 = dp[1].Profile.GetErr(p.Pt[j].X) / dp[1].Profile.GetValue(p.Pt[j].X, 1, 0);
                            if (Math.Abs(err1) > 10E-10 && Math.Abs(err2) > 10E-10)
                                //p.Err[j].Y = p.Pt[j].Y * Math.Sqrt(err1 * err1 + err2 * err2);
                                p.Err[j] =new PointD(p.Err[j].X,  p.Pt[j].Y * Math.Sqrt(err1 * err1 + err2 * err2));
                        }
                    }
            }
            else if (radioButtonProfileAndValue.Checked && listBoxTwoProfiles1.SelectedIndex >= 0)
            {
                DiffractionProfile dp = (DiffractionProfile)dataSetProfile.DataTableProfile.Rows[listBoxTwoProfiles1.SelectedIndex][1];
                for (int j = 0; j < dp.Profile.Pt.Count; j++)
                {
                    p.Pt.Add(new PointD(dp.Profile.Pt[j].X, dp.Profile.Pt[j].Y));//参照渡しを避けるため
                    p.Err.Add(new PointD(dp.Profile.Pt[j].X, j < dp.Profile.Err.Count ? dp.Profile.Err[j].Y : 0));
                }

                for (int j = 0; j < p.Pt.Count; j++)
                    if (radioButtonAddition.Checked)
                        //p.Pt[j].Y = p.Pt[j].Y + numericalTextBoxTargetValue.Value;
                        p.Pt[j] = new PointD(p.Pt[j].X, p.Pt[j].Y + numericalTextBoxTargetValue.Value);
                    else if (radioButtonMutiplication.Checked)
                    {
                        //p.Pt[j].Y = p.Pt[j].Y * numericalTextBoxTargetValue.Value;
                        p.Pt[j] = new PointD(p.Pt[j].X, p.Pt[j].Y * numericalTextBoxTargetValue.Value);
                        // p.Err[j].Y = p.Err[j].Y * numericalTextBoxTargetValue.Value;
                        p.Err[j] = new PointD(p.Err[j].X, p.Err[j].Y * numericalTextBoxTargetValue.Value);
                    }
            }
            else
                return;

            DiffractionProfile output = new DiffractionProfile();
            output.OriginalProfile = p;
            output.Name = textBoxOutputFilename.Text;
            output.ColorARGB = c.ToArgb();

            output.WaveSource = formMain.WaveSource;
            output.WaveColor = formMain.WaveColor;
            output.SrcAxisMode = formMain.AxisMode;
            output.XrayElementNumber = formMain.XraySourceElementNumber;
            output.XrayLine = formMain.XraySourceLine;
            output.SrcWaveLength = formMain.WaveLength;
            output.SrcTakeoffAngle = formMain.TakeoffAngle;
            output.SrcTofAngle = formMain.TakeoffAngle;
            output.SrcTofLength = formMain.TofLength;

            formMain.AddProfileToCheckedListBox(output, true, true);

            try
            {
                int n = Convert.ToInt32(textBoxOutputFilename.Text.Substring(textBoxOutputFilename.Text.Length - 2));
                textBoxOutputFilename.Text = textBoxOutputFilename.Text.Substring(0, textBoxOutputFilename.Text.Length - 2) + (n + 1).ToString("00");
            }
            catch { }
        }

        #region マスク関連

        public void AddMaskRange(DiffractionProfile.MaskingRange range)
        {
            if (bindingSourceProfile.Position < 0) return;
            DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
            dp.maskingRanges.Add(range);
            listBoxMaskRanges.Items.Add(range);
        }
        public DiffractionProfile.MaskingRange[] GetMaskRanges()
        {
            if (bindingSourceProfile.Position < 0) return null;
            DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
            return dp.maskingRanges.ToArray();
        }
        public bool SortMaskRanges()
        {
            if (bindingSourceProfile.Position < 0) return false;
            DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
            bool flag = dp.SortMaskRanges();
            skipEvent = true;
            for (int i = 0; i < dp.maskingRanges.Count; i++)
                listBoxMaskRanges.Items[i] = dp.maskingRanges[i];
            skipEvent = false;
            return flag;
        }
        public void SetMaskRange(int[] index, double x)
        {
            skipEvent = true;
            if (index == null || index.Length != 2) return;
            if (bindingSourceProfile.Position < 0) return;
            DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
            if (index[0] >= 0 && index[0] < dp.maskingRanges.Count && index[1] >= 0 && index[1] < 2)
            {
                dp.maskingRanges[index[0]].X[index[1]] = x;
                listBoxMaskRanges.Items[index[0]] = dp.maskingRanges[index[0]];
            }
            skipEvent = false;
        }
        public void DeleteMaskRange(int index)
        {
            if (bindingSourceProfile.Position < 0) return;
            DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
            if (listBoxMaskRanges.Items.Count > index && dp.maskingRanges.Count > index)
            {
                dp.maskingRanges.RemoveAt(index);
                listBoxMaskRanges.Items.RemoveAt(index);
            }
        }
        private void buttonDeleteMask_Click(object sender, EventArgs e)
        {
            if (bindingSourceProfile.Position < 0 || listBoxMaskRanges.SelectedIndex < 0) return;
            var dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
            int n = listBoxMaskRanges.SelectedIndex;
            if (n >= 0)
            {
                listBoxMaskRanges.Items.RemoveAt(n);
                dp.maskingRanges.RemoveAt(n);
            }

            if (n < listBoxMaskRanges.Items.Count)
                listBoxMaskRanges.SelectedIndex = n;
            else
                listBoxMaskRanges.SelectedIndex = n - 1;
            SetCurrentProfile();
        }

        private void buttonDeleteAllMask_Click(object sender, EventArgs e)
        {
            if (bindingSourceProfile.Position < 0) return;
            var dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
            listBoxMaskRanges.Items.Clear();
            dp.maskingRanges.Clear();
            SetCurrentProfile();
        }

        private void listBoxMaskRanges_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skipEvent) return;
            formMain.Draw();
        }


        private void toolStripMenuItemSaveMaskingRange_Click(object sender, EventArgs e)
        {
            if(bindingSourceProfile.Position<0)return;
            DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
            if(dp.maskingRanges.Count<1)return;

            var dlg = new SaveFileDialog();
            dlg.Filter = "*.mas|*.mas";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                try
                {
                    using (Stream stream = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(stream, dp.InterpolationOrder);
                        formatter.Serialize(stream, dp.InterpolationPoints);
                        formatter.Serialize(stream, dp.maskingRanges.Count);
                        for (int i = 0; i < dp.maskingRanges.Count; i++)
                            formatter.Serialize(stream, dp.maskingRanges[i]);
                    }
                  
                }
                catch {  }
            }
        }

        private void toolStripMenuItemReadMaskingRange_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "*.mas|*.mas";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                readMaskingRanges(dlg.FileName);
        }
        private void readMaskingRanges(string filename)
        {
            if (bindingSourceProfile.Position < 0) return;
            DiffractionProfile dp = (DiffractionProfile)((DataRowView)bindingSourceProfile.Current).Row[1];
            try
            {
                buttonDeleteAllMask_Click(new object(), new EventArgs());
                using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    IFormatter formatter = new BinaryFormatter();
                    {
                        numericUpDownInterpolationOrder.Value = (int)formatter.Deserialize(stream);
                        numericUpDownInterpolationPoints.Value = (int)formatter.Deserialize(stream);
                        int count = (int)formatter.Deserialize(stream);

                        for (int i = 0; i < count; i++)
                        {
                            var range = (DiffractionProfile.MaskingRange)formatter.Deserialize(stream);
                            AddMaskRange(range);
                        }
                    }

                }
                formMain.Draw();
            }
            catch { }
        }

        private void listBoxMaskRanges_DragDrop(object sender, DragEventArgs e)
        {
            //コントロール内にドロップされたとき実行される
            //ドロップされたすべてのファイル名を取得する
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length == 1)
            {
                if (fileName[0].ToLower().EndsWith(".mas"))
                    readMaskingRanges(fileName[0]);
            }
        }

        private void listBoxMaskRanges_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            else
                e.Effect = DragDropEffects.None;//ファイル以外は受け付けない
        }
        #endregion
        private void buttonTwoThetaCalibration_Click(object sender, EventArgs e) 
            => formMain.formTwoThetaCalibration.Visible = !formMain.formTwoThetaCalibration.Visible;

        private void buttonTwoThetaOffsetReset_Click(object sender, EventArgs e)
            => TwoThetaOffsetCoeff0 = TwoThetaOffsetCoeff1 = TwoThetaOffsetCoeff2 = 0;

        private void panelNormarizeIntensity_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}