using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Crystallography;
using System.IO;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace PDIndexer
{
    public partial class FormCellFinder : Form
    {
        public FormMain formMain;
        List<Candidate> Candidates = new List<Candidate>();

        public struct FindCondition
        {
            public double MaxA, MaxB, MaxC, MinA, MinB, MinC;
            public double MaxAlpha, MaxBeta, MaxGamma, MinAlpha, MinBeta, MinGamma;
            public int CrystalSystem;
            public double[] High;//信頼性の高いd値
            public double[] Medium;//信頼性の普通d値
            public double[] Low;//信頼性の低いd値

            public double[] D; //信頼性の高い順に並べたd値配列
            public Plane[] SortedD; //大きい順に並べたd値配列がX、その信頼度(high:1, medium: 0.5, low: 0.1)がY
            public int[] DtoSortedD;//DとSortedDの対応表
            public double WaveLength;
            public double TotalWeight;
            public FindCondition
                (double maxA, double maxB, double maxC, double minA, double minB, double minC,
                double maxAlpha, double maxBeta, double maxGamma, double minAlpha, double minBeta, double minGamma,
                int crystalSystem, double[] high, double[] medium, double[] low, double wavelength)
            {
                MaxA = maxA; MaxB = maxB; MaxC = maxC;
                MaxAlpha = maxAlpha; MaxBeta = maxBeta; MaxGamma = maxGamma;
                MinA = minA; MinB = minB; MinC = minC;
                MinAlpha = minAlpha; MinBeta = minBeta; MinGamma = minGamma;
                CrystalSystem = crystalSystem;

                High = high;
                Medium = medium;
                Low = low;

                //配列dに信頼が高い順番にd値を格納する
                D = new double[high.Length + medium.Length + low.Length];
                for (int i = 0; i < high.Length; i++) D[i] = high[i];
                for (int i = 0; i < medium.Length; i++) D[i + high.Length] = medium[i];
                for (int i = 0; i < low.Length; i++) D[i + high.Length + medium.Length] = low[i];

                WaveLength=wavelength;

                SortedD = new Plane[D.Length];
                for (int i = 0; i < high.Length; i++) SortedD[i] = new Plane(high[i],0,0,0, 1,1 / Math.Pow((Math.Asin(wavelength/2/high[i])*2),2) );
                for (int i = 0; i < medium.Length; i++) SortedD[i + high.Length] = new Plane(medium[i], 0, 0, 0, 0.5, 1 / Math.Pow((Math.Asin(wavelength / 2 / medium[i]) * 2), 2));
                for (int i = 0; i < low.Length; i++) SortedD[i + high.Length + medium.Length] = new Plane(low[i], 0, 0, 0, 0.1, 1 / Math.Pow((Math.Asin(wavelength / 2 / low[i]) * 2), 2));
                Array.Sort(SortedD);
                Array.Reverse(SortedD);

                TotalWeight = 0;
                for (int i = 0; i < SortedD.Length; i++)
                    TotalWeight += SortedD[i].Weight;

                //対応表を作る
                DtoSortedD = new int[D.Length];
                for (int i = 0; i < D.Length; i++)
                    for (int j = 0; j < SortedD.Length; j++)
                        if (D[i] == SortedD[j].D)
                            DtoSortedD[i] = j;
            }
        }

        public struct Candidate : IComparable
        {
            public double A, B, C, Alpha, Beta, Gamma;
            public double Volume, R, SigmaDQ;
            public Plane[] Planes;

            public Candidate(double a, double b, double c, double alpha, double beta, double gamma, double volume, double sigmaDQ, double r, Plane[] planes)
            {
                A = a; B = b; C = c; Alpha = alpha; Beta = beta; Gamma = gamma; Volume = volume; R = r; SigmaDQ = sigmaDQ; Planes = planes;
            }
            public object[] GenerateRow()
            {
                return new object[] { A * 10, B * 10, C * 10, Alpha / Math.PI * 180, Beta / Math.PI * 180, Gamma / Math.PI * 180, Volume * 1000, SigmaDQ, R, Planes };
            }

            #region IComparable メンバ

            public int CompareTo(object obj)
            {
                return R.CompareTo(((Candidate)obj).R);
            }

            #endregion
        }

        public struct Plane : IComparable
        {
            public double D;
            public int H, K, L;
            public double Reliability;
            public double Weight;
            public Plane(double d,  int h, int k, int l, double reliability,double weight)
            {
                D = d; H = h; K = k; L = l;Reliability=reliability;Weight=weight;
            }
            #region IComparable メンバ
            public int CompareTo(object obj)
            {
                return D.CompareTo(((Plane)obj).D);
            }
            #endregion
        }
        public Color[] color = new Color[65536];
        public FormCellFinder()
        {
            InitializeComponent();
            comboBoxReliability.SelectedIndex = 0;
            comboBoxCrystalSystem.SelectedIndex = 0;
            comboBoxX.SelectedIndex = 0;
            comboBoxY.SelectedIndex = 1;

            distributionGraphControl1.BackgroundColor = Color.Gray;
            distributionGraphControl1.DivisionLineColor = Color.Black;

            int[][] c = new int[][] { new int[] { 0, 0, 0, 0 }, new int[] { 5376, 0, 0, 255 }, new int[] { 16256, 0, 191, 191 }, new int[] { 27136, 0, 255, 0 }, new int[] { 38016, 255, 255, 0 }, new int[] { 48896, 255, 0, 0 }, new int[] { 59904, 255, 0, 255 }, new int[] { 65535, 255, 255, 255 } };

            for (int i = 0; i < 65536; i++)
            {
                for (int j = 0; j < 7; j++)
                    if (c[j][0] <= i && c[j + 1][0] >= i)
                    {
                        double a1 = (double)(c[j + 1][0] - i) / (c[j + 1][0] - c[j][0]), a2 = (double)(i - c[j][0]) / (c[j + 1][0] - c[j][0]);
                        color[i] = Color.FromArgb((byte)(c[j][1] * a1 + c[j + 1][1] * a2), (byte)(c[j][2] * a1 + c[j + 1][2] * a2), (byte)(c[j][3] * a1 + c[j + 1][3] * a2));
                    }
            }
        }

        private void buttonAddPeak_Click(object sender, EventArgs e)
        {
            dataSet1.Tables[0].Rows.Add(new object[] { numericalTextBox1.Value,comboBoxReliability.Text,true });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "Delete")
                dgv.Rows.RemoveAt(e.RowIndex);
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (buttonFind.Text == "Find!")
            {
                //まずクリアする
                dataSet1.Tables[1].Clear();
                Candidates.Clear();

                //まずHigh,Medium,Low別にd値を抜き出す。
                List<double> high = new List<double>();
                List<double> medium = new List<double>();
                List<double> low = new List<double>();
                for (int i = 0; i < dataSet1.Tables[0].Rows.Count; i++)
                    if ((bool)dataSet1.Tables[0].Rows[i][2] == true)
                    {
                        if ((string)dataSet1.Tables[0].Rows[i][1] == "High")
                            high.Add((double)dataSet1.Tables[0].Rows[i][0] / 10.0);
                        else if ((string)dataSet1.Tables[0].Rows[i][1] == "Medium")
                            medium.Add((double)dataSet1.Tables[0].Rows[i][0] / 10.0);
                        else if ((string)dataSet1.Tables[0].Rows[i][1] == "Low")
                            low.Add((double)dataSet1.Tables[0].Rows[i][0] / 10.0);
             
                    }
                high.Sort(); medium.Sort(); low.Sort();
                high.Reverse(); medium.Reverse(); low.Reverse();

                int unk = 0;
                switch (comboBoxCrystalSystem.SelectedIndex)
                {
                    case 0: unk = 6; break; //triclinic
                    case 1: unk = 4; break;//monoclinic
                    case 2: unk = 3; break; //orthorhombic
                    case 3: unk = 2; break; //tetragonal
                    case 4: unk = 2; break; //trigonal
                    case 5: unk = 2; break; //hexagonal
                    case 6: unk = 1; break; //cubic
                }
                if (unk > high.Count + medium.Count + low.Count)
                    return;
                buttonFind.Text = "Stop!";


                backgroundWorker.RunWorkerAsync(new FindCondition(
                    (double)numericUpDownMaxA.Value / 10.0, (double)numericUpDownMaxB.Value / 10.0, (double)numericUpDownMaxC.Value / 10.0,
                    (double)numericUpDownMinA.Value / 10.0, (double)numericUpDownMinB.Value / 10.0, (double)numericUpDownMinC.Value / 10.0,
                      (double)numericUpDownMaxAlpha.Value / 180 * Math.PI, (double)numericUpDownMaxBeta.Value / 180 * Math.PI, (double)numericUpDownMaxGamma.Value / 180 * Math.PI,
                    (double)numericUpDownMinAlpha.Value / 180 * Math.PI, (double)numericUpDownMinBeta.Value / 180 * Math.PI, (double)numericUpDownMinGamma.Value / 180 * Math.PI,
                    comboBoxCrystalSystem.SelectedIndex, high.ToArray(), medium.ToArray(), low.ToArray(), waveLengthControl1.WaveLength
                    ));
            }
            else
            {
                buttonFind.Text = "Find!";
                backgroundWorker.CancelAsync();
            }
        }

        int threadTotal = 1;
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FindCondition condition = (FindCondition)e.Argument;

            GetCandidatesDelegate[] d = new GetCandidatesDelegate[threadTotal];
            IAsyncResult[] ar = new IAsyncResult[threadTotal];
            Candidate[][] c = new Candidate[threadTotal][];
            for (int i = 0; i < threadTotal; i++)
                d[i] = new GetCandidatesDelegate(GetCandidatesForThread);

            int counter = 0;
            int lastCounter = 0;
            Random r = new Random();
            int tryNumber = 1000;
            while (!backgroundWorker.CancellationPending)
            {
                counter += threadTotal * tryNumber;
                for (int i = 0; i < threadTotal; i++)
                    ar[i] = d[i].BeginInvoke(condition,r.Next(), tryNumber,ref c[i], null, null);//各スレッド起動転送
                for (int i = 0; i < threadTotal; i++)//スレッド終了待ち
                {
                    d[i].EndInvoke(ref c[i], ar[i]);

                    for (int j = 0; j < c[i].Length; j++)
                        Candidates.Add(c[i][j]);
                }
                
                if (counter - lastCounter > 20000 || Candidates.Count>1200)
                {
                    lastCounter = counter;
                    Candidates.Sort();
                    for (int i = 0; i < Candidates.Count - 1; i++)
                        if (Candidates[i].A == Candidates[i + 1].A && Candidates[i].B == Candidates[i + 1].B && Candidates[i].C == Candidates[i + 1].C
                            && Candidates[i].Alpha == Candidates[i + 1].Alpha && Candidates[i].Beta == Candidates[i + 1].Beta && Candidates[i].Gamma == Candidates[i + 1].Gamma)
                            Candidates.RemoveAt(i-- + 1);
                    if (Candidates.Count > 300)
                        Candidates.RemoveRange(300, Candidates.Count - 300);
                    backgroundWorker.ReportProgress(counter, Candidates.ToArray());
                }
            }
        }

        delegate void GetCandidatesDelegate(FindCondition condition, int seed, int tryNumber, ref Candidate[] c);
        private void GetCandidatesForThread(FindCondition condition, int seed, int tryNumber, ref Candidate[] c)
        {
            c = GetCandidates(condition, seed, tryNumber);
        }

        private Candidate[] GetCandidates(FindCondition condition, int seed, int tryNumber)
        {
            Random r = new Random(seed);
            List<Candidate> c = new List<Candidate>();
            for (int i = 0; i < tryNumber && !backgroundWorker.CancellationPending; i++)
            {
                Candidate temp = FindCellParameter(condition, r.Next());
                if(temp.R<1000)
                    c.Add(temp);
            }
            return c.ToArray();
        }
        
        private Candidate FindCellParameter(FindCondition condition, int seed)
        {
            Random r = new Random(seed);
            int unk = 0;
            switch (condition.CrystalSystem)
            {
                case 0: unk = 6; break; //triclinic
                case 1: unk = 4; break;//monoclinic
                case 2: unk = 3; break; //orthorhombic
                case 3: unk = 2; break; //tetragonal
                case 4: unk = 2; break; //trigonal
                case 5: unk = 2; break; //hexagonal
                case 6: unk = 1; break; //cubic
            }
            if (unk > condition.DtoSortedD.Length)
                return new Candidate();

            Plane[] planes = new Plane[unk];
            
            //まず対象となるピークをunk本選ぶ 
            List<int> targetPeak = new List<int>();
            for (int j = 0; j < unk; j++)
            {
                targetPeak.Sort();
                int tempTarget =r.Next(r.Next(condition.DtoSortedD.Length / 2));
                for (int n = 0; n < targetPeak.Count; n++) //0からtempTargetの間で既に選ばれている指数を検索し、tempTargetから外す
                    if (tempTarget >= targetPeak[n])
                        tempTarget++;
                targetPeak.Add(tempTarget);
            }
            targetPeak.Sort();
            //ピーク選定おわり

            //次にピークに指数を与える
            for (int j = 0; j < targetPeak.Count; j++)
            {
                //指数を生成する  orthoは h,k,lすべて >= 0 指数の上限は　ピークの順番(何番目の要素か)の値に6を足したもの
                int h = 0, k = 0, l = 0;
                while (h == 0 && l == 0 && k == 0)
                {
                    switch (condition.CrystalSystem)
                    {
                        case 0://triclinic
                            h = r.Next(r.Next(0, condition.DtoSortedD[j] + 3) + 1);
                            k = r.Next(-(k = r.Next(0, condition.DtoSortedD[j] + 3)), k + 1);
                            l = r.Next(-(l = r.Next(0, condition.DtoSortedD[j] + 3)), l + 1);
                            break;
                        case 1://monoclinic
                            h = r.Next(r.Next(0, condition.DtoSortedD[j] + 4) + 1);
                            k = r.Next(r.Next(0, condition.DtoSortedD[j] + 4) + 1);
                            l = r.Next(-(l = r.Next(0, condition.DtoSortedD[j] + 4)), l + 1);
                            break;
                        case 2://ortho
                            h = r.Next(r.Next(0, condition.DtoSortedD[j] + 4) + 1);
                            k = r.Next(r.Next(0, condition.DtoSortedD[j] + 4) + 1);
                            l = r.Next(r.Next(0, condition.DtoSortedD[j] + 4) + 1);
                            break;
                        default://tetra
                            h = r.Next(r.Next(0, condition.DtoSortedD[j] + 4) + 1);
                            k = r.Next(r.Next(0, condition.DtoSortedD[j] + 4) + 1);
                            l = r.Next(r.Next(0, condition.DtoSortedD[j] + 4) + 1);
                            break;
                    }
                }
                planes[j] = new Plane(condition.D[targetPeak[j]], h, k, l, 1, 1);
            }
            Candidate c = RefineCellParameter(condition.CrystalSystem, planes);

            if (double.IsInfinity( c.SigmaDQ)) return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);
            
            //軸を組み替える
            if (condition.CrystalSystem == 2)//orthoのとき
            {
                if (c.A < c.B) { double temp = c.A; c.A = c.B; c.B = temp; }
                if (c.B < c.C) { double temp = c.B; c.B = c.C; c.C = temp; }
                if (c.A < c.B) { double temp = c.A; c.A = c.B; c.B = temp; }
            }
            if (condition.CrystalSystem == 1)//monoclinicのとき
            {//βがもっとも90°に近くなるように
               // c.A = 0.9737;
               // c.C = 0.5242;
               // c.Beta = 105.7 / 180.0 * Math.PI;
                
                PointD u = new PointD(c.A, 0);
                PointD v = new PointD(c.C * Math.Cos(c.Beta), c.C * Math.Sin(c.Beta));
                double area = c.A * c.C * Math.Sin(c.Beta);
                List<PointD> p = new List<PointD>();
                for (int i = -2; i <= 2; i++)
                    for (int j = -2; j <= 2; j++)
                        if (!(i == 0 && j == 0))
                            p.Add(i * u + j * v);
                PointD temp1 = new PointD(0, 0), temp2 = new PointD(0, 0);
                double tempBeta = double.MaxValue;
                for(int i= 0 ; i<p.Count ; i++)
                    for (int j = i + 1; j < p.Count; j++)
                        if (Math.Abs(area - Math.Abs( p[i].X * p[j].Y - p[i].Y * p[j].X)) < 0.0000001)
                        {
                            double beta = Math.Acos((p[i].X * p[j].X + p[i].Y * p[j].Y) / p[i].Length / p[j].Length);
                            if (beta >= Math.PI / 2 && tempBeta > beta)
                            {
                                temp1 = p[i];
                                temp2 = p[j];
                                tempBeta = beta;
                            }
                        }
                c.A = temp1.Length;
                c.C = temp2.Length;
                c.Beta = tempBeta;
                
                if (c.A < c.C) { double temp = c.A; c.A = c.C; c.C = temp; }
            }
            if (condition.MaxA >= c.A && condition.MinA <= c.A && condition.MaxB >= c.B && condition.MinB <= c.B && condition.MaxC >= c.C && condition.MinC <= c.C
             && condition.MaxAlpha >= c.Alpha && condition.MinAlpha <= c.Alpha && condition.MaxBeta >= c.Beta && condition.MinBeta <= c.Beta && condition.MaxGamma >= c.Gamma && condition.MinGamma <= c.Gamma)
                return GetResidualValue(c, condition, r.Next());
            else
                return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);
        }

        private Candidate GetResidualValue(Candidate c, FindCondition condition, int seed)
        {
            Random r = new Random(seed);
            double SinAlpha = Math.Sin(c.Alpha); double SinBeta = Math.Sin(c.Beta); double SinGamma = Math.Sin(c.Gamma);
            double CosAlpha = Math.Cos(c.Alpha); double CosBeta = Math.Cos(c.Beta); double CosGamma = Math.Cos(c.Gamma);
            double a2 = c.A * c.A; double b2 = c.B * c.B; double c2 = c.C * c.C;
            double sigma11 = b2 * c2 * SinAlpha * SinAlpha;
            double sigma22 = c2 * a2 * SinBeta * SinBeta;
            double sigma33 = a2 * b2 * SinGamma * SinGamma;
            double sigma23 = a2 * c.B * c.C * (CosBeta * CosGamma - CosAlpha);
            double sigma31 = c.A * b2 * c.C * (CosGamma * CosAlpha - CosBeta);
            double sigma12 = c.A * c.B * c2 * (CosAlpha * CosBeta - CosGamma);
            double CellVolumeSqure = a2 * b2 * c2 * (1 - CosAlpha * CosAlpha - CosBeta * CosBeta - CosGamma * CosGamma + 2 * CosAlpha * CosBeta * CosGamma);

            //検索する指数範囲を設定
            int hMax = Math.Min((int)(c.A / (condition.SortedD[^1].D * 0.9)), 30);
            int kMax = Math.Min((int)(c.B / (condition.SortedD[^1].D * 0.9)), 30);
            int lMax = Math.Min((int)(c.C / (condition.SortedD[^1].D * 0.9)), 30);

            Plane[] obs = new Plane[condition.SortedD.Length];
            for (int i = 0; i < obs.Length; i++)
                obs[i] = condition.SortedD[i];

            //計算上のd値を格納するリストを定義
            List<Plane> calcPlanes = new List<Plane>();

            //観測値が計算値のどの配列位置か対応付ける整数配列を定義
            int[] obsToCalcIndex = new int[condition.SortedD.Length];

            //まず結晶系を判定
            switch (condition.CrystalSystem)
            {
                case 0://triclinic
                    for (int h = 0; h <= hMax; h++)
                        for (int k = -kMax; k <= kMax; k++)
                            for (int l = -lMax; l <= lMax; l++)
                                if (!(h == 0 && k == 0 && l == 0))
                                    calcPlanes.Add(new Plane(Math.Sqrt(1.0 / (h * h * sigma11 + k * k * sigma22 + l * l * sigma33 + 2 * k * l * sigma23 + 2 * l * h * sigma31 + 2 * h * k * sigma12) * CellVolumeSqure), h, k, l, 0, 0));
                    break;

                case 1: //monoclinic
                    for (int h = 0; h <= hMax; h++)
                        for (int k = 0; k <= kMax; k++)
                            for (int l = h == 0 ? 0 : -lMax; l <= lMax; l++)
                                if (!(h == 0 && k == 0 && l == 0))
                                    calcPlanes.Add(new Plane(Math.Sqrt(1.0 / (h * h * sigma11 + k * k * sigma22 + l * l * sigma33 + 2 * k * l * sigma23 + 2 * l * h * sigma31 + 2 * h * k * sigma12) * CellVolumeSqure), h, k, l, 0, 0));
                    break;

                case 2: //orthorhombic
                    for (int h = 0; h <= hMax; h++)
                        for (int k = 0; k <= kMax; k++)
                            for (int l = h + k == 0 ? 1 : 0; l <= lMax; l++)
                                calcPlanes.Add(new Plane(Math.Sqrt(1.0 / (h * h * sigma11 + k * k * sigma22 + l * l * sigma33 + 2 * k * l * sigma23 + 2 * l * h * sigma31 + 2 * h * k * sigma12) * CellVolumeSqure), h, k, l, 0, 0));
                    break;
                case 3: //tetragonal
                    for (int h = 0; h <= hMax; h++)
                        for (int k = h; k <= kMax; k++)
                            for (int l = h + k == 0 ? 1 : 0; l <= lMax; l++)
                                calcPlanes.Add(new Plane(Math.Sqrt(1.0 / (h * h * sigma11 + k * k * sigma22 + l * l * sigma33 + 2 * k * l * sigma23 + 2 * l * h * sigma31 + 2 * h * k * sigma12) * CellVolumeSqure), h, k, l, 0, 0));
                    break;
                case 4: //trigonal
                    for (int h = 0; h < hMax; h++)
                        for (int k = h; k < kMax; k++)
                            for (int l = h + k == 0 ? 1 : 0; l < lMax; l++)
                                calcPlanes.Add(new Plane(Math.Sqrt(1.0 / (h * h * sigma11 + k * k * sigma22 + l * l * sigma33 + 2 * k * l * sigma23 + 2 * l * h * sigma31 + 2 * h * k * sigma12) * CellVolumeSqure), h, k, l, 0, 0));
                    break;

                case 5: //hexagonal
                    for (int h = 0; h <= hMax; h++)
                        for (int k = h; k <= kMax; k++)
                            for (int l = h + k == 0 ? 1 : 0; l <= lMax; l++)
                                calcPlanes.Add(new Plane(Math.Sqrt(1.0 / (h * h * sigma11 + k * k * sigma22 + l * l * sigma33 + 2 * k * l * sigma23 + 2 * l * h * sigma31 + 2 * h * k * sigma12) * CellVolumeSqure), h, k, l, 0, 0));
                    break;

                case 6: //cubic
                    for (int h = 0; h <= hMax; h++)
                        for (int k = h; k <= kMax; k++)
                            for (int l = h + k == 0 ? 1 : k; l <= lMax; l++)
                                calcPlanes.Add(new Plane(Math.Sqrt(1.0 / (h * h * sigma11 + k * k * sigma22 + l * l * sigma33 + 2 * k * l * sigma23 + 2 * l * h * sigma31 + 2 * h * k * sigma12) * CellVolumeSqure), h, k, l, 0, 0));
                    break;
            }
            calcPlanes.Sort();
            for (int i = 0; i < calcPlanes.Count - 1; i++)
                if (Math.Abs(calcPlanes[i].D - calcPlanes[i + 1].D) < 10E-9)
                    calcPlanes.RemoveAt(i-- + r.Next(2));

            //planes と d とを関連付ける
            double[] diff = new double[obs.Length];
            double temp;

            for (int i = 0; i < obs.Length; i++)
                diff[i] = double.MaxValue;
            for (int i = 0; i < obs.Length; i++)
                for (int j = 0; j < calcPlanes.Count; j++)
                    if ((temp = (obs[i].D - calcPlanes[j].D) * (obs[i].D - calcPlanes[j].D)) < diff[i])
                    {
                        diff[i] = temp;
                        obsToCalcIndex[i] = j;
                    }
            double diffMax = double.NegativeInfinity;
            for (int i = 0; i < obs.Length; i++)
                if (diffMax < diff[i])
                    diffMax = diff[i];
            if (diffMax > 0.0004) return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);

            //obsToCalcに重複がないかどうかチェック
            int retry = 0, retryMax = 20; //重複チェック回数(retry)がretryMax回数を超えると失敗
            for (int i = 0; i < obsToCalcIndex.Length - 1; i++)
            {
                if (obsToCalcIndex[i] == obsToCalcIndex[i + 1])//重複があったら
                {
                    if (retry++ > retryMax) return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);
                    
                    if (r.Next(2) == 1)//さいころを振って選ばれたほうを残す
                    {
                        if (obsToCalcIndex[i] > 0)
                            obsToCalcIndex[i] -= 1;
                        else if (obsToCalcIndex[i + 1] < calcPlanes.Count - 1)
                            obsToCalcIndex[i + 1] += 1;
                    }
                    else
                    {
                        if (obsToCalcIndex[i + 1] < calcPlanes.Count - 1)
                            obsToCalcIndex[i + 1] += 1;
                        else if (obsToCalcIndex[i] > 0)
                            obsToCalcIndex[i] -= 1;
                    }
                    i = -1;//値を戻してやり直し
                }
            }

            //重複チェックをくぐり抜けたら指数を配当
            for (int i = 0; i < condition.SortedD.Length; i++)
            {
                obs[i].H = calcPlanes[obsToCalcIndex[i]].H;
                obs[i].K = calcPlanes[obsToCalcIndex[i]].K;
                obs[i].L = calcPlanes[obsToCalcIndex[i]].L;
            }

            //最小2乗法によるフィッティング。
            c = RefineCellParameter(condition.CrystalSystem, obs);
            c.R = Math.Sqrt(c.SigmaDQ / condition.TotalWeight) * calcPlanes.Count / condition.SortedD.Length;

            //最後にobs.Dを計算しなおす
            SinAlpha = Math.Sin(c.Alpha); SinBeta = Math.Sin(c.Beta); SinGamma = Math.Sin(c.Gamma);
            CosAlpha = Math.Cos(c.Alpha); CosBeta = Math.Cos(c.Beta); CosGamma = Math.Cos(c.Gamma);
            a2 = c.A * c.A; b2 = c.B * c.B; c2 = c.C * c.C;
            sigma11 = b2 * c2 * SinAlpha * SinAlpha;
            sigma22 = c2 * a2 * SinBeta * SinBeta;
            sigma33 = a2 * b2 * SinGamma * SinGamma;
            sigma23 = a2 * c.B * c.C * (CosBeta * CosGamma - CosAlpha);
            sigma31 = c.A * b2 * c.C * (CosGamma * CosAlpha - CosBeta);
            sigma12 = c.A * c.B * c2 * (CosAlpha * CosBeta - CosGamma);
            CellVolumeSqure = a2 * b2 * c2 * (1 - CosAlpha * CosAlpha - CosBeta * CosBeta - CosGamma * CosGamma + 2 * CosAlpha * CosBeta * CosGamma);
            for (int i = 0; i < obs.Length; i++)
                obs[i].D = Math.Sqrt(1.0 / (obs[i].H * obs[i].H * sigma11 + obs[i].K * obs[i].K * sigma22 + obs[i].L * obs[i].L * sigma33 + 2 * obs[i].K * obs[i].L * sigma23 + 2 * obs[i].L * obs[i].H * sigma31 + 2 * obs[i].H * obs[i].K * sigma12) * CellVolumeSqure);

            return c;
        }

        private Candidate RefineCellParameter(int system, Plane[] p)
        {
           
            double a = 0, b = 0, c = 0, alpha = 0, beta = 0, gamma = 0, V = 0;
            double sigmaDQ = double.PositiveInfinity;
            int column = p.Length;
            Matrix<double> inv;

            int unk = 0;
            switch (system)
            {
                case 0: unk = 6; break; //triclinic
                case 1: unk = 4; break;//monoclinic
                case 2: unk = 3; break; //orthorhombic
                case 3: unk = 2; break; //tetragonal
                case 4: unk = 2; break; //trigonal
                case 5: unk = 2; break; //hexagonal
                case 6: unk = 1; break; //cubic
            }
            var Q = new DenseMatrix(column, unk);
            var A = new DenseMatrix(column, 1);
            var W = new DenseMatrix(column, column);
            Matrix<double> C = new DenseMatrix(column,1);

            switch (system)
            {
                case 0://
                    #region triclinic
                    for (int i = 0; i < column; i++)
                    {
                        Q[i, 0] = p[i].H * p[i].H;
                        Q[i, 1] = p[i].K * p[i].K;
                        Q[i, 2] = p[i].L * p[i].L;
                        Q[i, 3] = p[i].K * p[i].L;
                        Q[i, 4] = p[i].L * p[i].H;
                        Q[i, 5] = p[i].H * p[i].K;
                        A[i, 0] = 1 / p[i].D / p[i].D;
                        W[i, i] = p[i].Weight * p[i].Reliability;
                    }

                    if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                        return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);

                    C = inv * Q.Transpose() * W * A;
                    
                    double a_star = Math.Sqrt(C[0, 0]);
                    double b_star = Math.Sqrt(C[1, 0]);
                    double c_star = Math.Sqrt(C[2, 0]);
                    double CosAlf_star = C[3, 0] / (2 * b_star * c_star);
                    double CosBet_star = C[4, 0] / (2 * c_star * a_star);
                    double CosGam_star = C[5, 0] / (2 * a_star * b_star);
                    double Alf_star = Math.Acos(CosAlf_star);
                    double Bet_star = Math.Acos(CosBet_star);
                    double Gam_star = Math.Acos(CosGam_star);
                    double V_star = a_star * b_star * c_star
                        * Math.Sqrt(1 - CosAlf_star * CosAlf_star - CosBet_star * CosBet_star - CosGam_star * CosGam_star + 2 * CosAlf_star * CosBet_star * CosGam_star);

                    V = 1 / V_star;

                    a = b_star * c_star * Math.Sin(Alf_star) / V_star;
                    b = c_star * a_star * Math.Sin(Bet_star) / V_star;
                    c = a_star * b_star * Math.Sin(Gam_star) / V_star;
                    alpha = Math.Asin(a_star / b / c / V_star);
                    beta = Math.Asin(b_star / c / a / V_star);
                    gamma = Math.Asin(c_star / a / b / V_star);


                    if (Math.Abs(CosAlf_star - (Math.Cos(beta) * Math.Cos(gamma) - Math.Cos(alpha)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                      && Math.Abs(CosBet_star - (Math.Cos(gamma) * Math.Cos(alpha) - Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alpha))) < 0.0000000001
                      && Math.Abs(CosGam_star - (Math.Cos(alpha) * Math.Cos(beta) - Math.Cos(gamma)) / (Math.Sin(alpha) * Math.Sin(beta))) < 0.0000000001)
                    {

                    }
                    else if (Math.Abs(CosAlf_star - (Math.Cos(beta) * Math.Cos(gamma) + Math.Cos(alpha)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                      && Math.Abs(CosBet_star - (-Math.Cos(gamma) * Math.Cos(alpha) - Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alpha))) < 0.0000000001
                      && Math.Abs(CosGam_star - (-Math.Cos(alpha) * Math.Cos(beta) - Math.Cos(gamma)) / (Math.Sin(alpha) * Math.Sin(beta))) < 0.0000000001)
                    {
                        alpha = Math.PI - alpha;
                    }
                    else if (Math.Abs(CosAlf_star - (-Math.Cos(beta) * Math.Cos(gamma) - Math.Cos(alpha)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                        && Math.Abs(CosBet_star - (Math.Cos(gamma) * Math.Cos(alpha) + Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alpha))) < 0.0000000001
                        && Math.Abs(CosGam_star - (-Math.Cos(alpha) * Math.Cos(beta) - Math.Cos(gamma)) / (Math.Sin(alpha) * Math.Sin(beta))) < 0.0000000001)
                    {
                        beta = Math.PI - beta;
                    }
                    else if (Math.Abs(CosAlf_star - (-Math.Cos(beta) * Math.Cos(gamma) - Math.Cos(alpha)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                        && Math.Abs(CosBet_star - (-Math.Cos(gamma) * Math.Cos(alpha) - Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alpha))) < 0.0000000001
                        && Math.Abs(CosGam_star - (Math.Cos(alpha) * Math.Cos(beta) + Math.Cos(gamma)) / (Math.Sin(alpha) * Math.Sin(beta))) < 0.0000000001)
                    {
                        gamma = Math.PI - gamma;
                    }
                    else if (Math.Abs(CosAlf_star - (Math.Cos(beta) * Math.Cos(gamma) - Math.Cos(alpha)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                        && Math.Abs(CosBet_star - (-Math.Cos(gamma) * Math.Cos(alpha) + Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alpha))) < 0.0000000001
                        && Math.Abs(CosGam_star - (-Math.Cos(alpha) * Math.Cos(beta) + Math.Cos(gamma)) / (Math.Sin(alpha) * Math.Sin(beta))) < 0.0000000001)
                    {
                        beta = Math.PI - beta; gamma = Math.PI - gamma;
                    }
                    else if (Math.Abs(CosAlf_star - (-Math.Cos(beta) * Math.Cos(gamma) + Math.Cos(alpha)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                        && Math.Abs(CosBet_star - (Math.Cos(gamma) * Math.Cos(alpha) - Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alpha))) < 0.0000000001
                        && Math.Abs(CosGam_star - (-Math.Cos(alpha) * Math.Cos(beta) + Math.Cos(gamma)) / (Math.Sin(alpha) * Math.Sin(beta))) < 0.0000000001)
                    {
                        alpha = Math.PI - alpha; gamma = Math.PI - gamma;
                    }
                    else if (Math.Abs(CosAlf_star - (-Math.Cos(beta) * Math.Cos(gamma) + Math.Cos(alpha)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                        && Math.Abs(CosBet_star - (-Math.Cos(gamma) * Math.Cos(alpha) + Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alpha))) < 0.0000000001
                        && Math.Abs(CosGam_star - (Math.Cos(alpha) * Math.Cos(beta) - Math.Cos(gamma)) / (Math.Sin(alpha) * Math.Sin(beta))) < 0.0000000001)
                    {
                        alpha = Math.PI - alpha; beta = Math.PI - beta;
                    }
                    else if (Math.Abs(CosAlf_star - (Math.Cos(beta) * Math.Cos(gamma) + Math.Cos(alpha)) / (Math.Sin(beta) * Math.Sin(gamma))) < 0.0000000001
                        && Math.Abs(CosBet_star - (Math.Cos(gamma) * Math.Cos(alpha) + Math.Cos(beta)) / (Math.Sin(gamma) * Math.Sin(alpha))) < 0.0000000001
                        && Math.Abs(CosGam_star - (Math.Cos(alpha) * Math.Cos(beta) + Math.Cos(gamma)) / (Math.Sin(alpha) * Math.Sin(beta))) < 0.0000000001)
                    {
                        alpha = Math.PI - alpha; beta = Math.PI - beta; gamma = Math.PI - gamma;
                    }
                    break;
                    #endregion

                case 1: //
                    #region monoclinic
                    for (int i = 0; i < column; i++)
                    {
                        Q[i, 0] = p[i].H * p[i].H;
                        Q[i, 1] = p[i].K * p[i].K;
                        Q[i, 2] = p[i].L * p[i].L;
                        Q[i, 3] = p[i].L * p[i].H;
                        A[i, 0] = 1 / p[i].D / p[i].D;
                        W[i, i] = p[i].Weight * p[i].Reliability;
                    }

                   if(! (Q.Transpose() * W * Q).TryInverse(out inv))
                        return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);

                    C = inv * Q.Transpose() * W * A;
                    
                    beta = Math.Acos(-C[3, 0] / 2 / Math.Sqrt(C[0, 0] * C[2, 0]));
                    a = Math.Sqrt(1 / C[0, 0]) / Math.Sin(beta);
                    b = Math.Sqrt(1 / C[1, 0]);
                    c = Math.Sqrt(1 / C[2, 0]) / Math.Sin(beta);
                    alpha = gamma = Math.PI / 2;
                    V = a * b * c * Math.Sin(beta);
                    break;
                    #endregion

                case 2: //
                    #region orthorhombic
                    for (int i = 0; i < column; i++)
                    {
                        Q[i, 0] = p[i].H * p[i].H;
                        Q[i, 1] = p[i].K * p[i].K;
                        Q[i, 2] = p[i].L * p[i].L;
                        A[i, 0] = 1 / p[i].D / p[i].D;
                        W[i, i] = p[i].Weight * p[i].Reliability;
                    }
                    if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                        return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);
                    C = inv * Q.Transpose() * W * A;

                    a = Math.Sqrt(1 / C[0, 0]);
                    b = Math.Sqrt(1 / C[1, 0]);
                    c = Math.Sqrt(1 / C[2, 0]);
                    alpha = beta = gamma = Math.PI / 2;
                    V = a * b * c;
                    break;
                    #endregion

                case 3:
                    #region tetragonal
                    for (int i = 0; i < column; i++)
                    {
                        Q[i, 0] = p[i].H * p[i].H + p[i].K * p[i].K;
                        Q[i, 1] = p[i].L * p[i].L;
                        A[i, 0] = 1 / p[i].D / p[i].D;
                        W[i, i] = p[i].Weight * p[i].Reliability;
                    }

                    if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                        return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);
                    C = inv * Q.Transpose() * W * A;

                    a = b = Math.Sqrt(1 / C[0, 0]);
                    c = Math.Sqrt(1 / C[1, 0]);
                    alpha = beta = gamma = Math.PI / 2;
                    V = a * a * c;
                    break;
                    #endregion

                case 4://trigonal
                    #region trigonal
                    for (int i = 0; i < column; i++)
                    {
                        Q[i, 0] = 4.0 / 3.0 * (p[i].H * p[i].H + p[i].K * p[i].K + p[i].H * p[i].K);
                        Q[i, 1] = p[i].L * p[i].L;
                        A[i, 0] = 1 / p[i].D / p[i].D;
                        W[i, i] = p[i].Weight * p[i].Reliability;
                    }
                    if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                        return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);
                    C = inv * Q.Transpose() * W * A;
                    
                    a = b = Math.Sqrt(1 / C[0, 0]);
                    c = Math.Sqrt(1 / C[1, 0]);
                    alpha = beta = Math.PI / 2;
                    gamma = Math.PI / 1.5;
                    V = a * a * c * Math.Sqrt(3) / 2;
                    break;
                    #endregion

                case 5://hexagonal
                    #region hexagonal
                    for (int i = 0; i < column; i++)
                    {
                        Q[i, 0] = 4.0 / 3.0 * (p[i].H * p[i].H + p[i].K * p[i].K + p[i].H * p[i].K);
                        Q[i, 1] = p[i].L * p[i].L;
                        A[i, 0] = 1 / p[i].D / p[i].D;
                        W[i, i] = p[i].Weight * p[i].Reliability;
                    }
                    if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                        return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);
                    C = inv * Q.Transpose() * W * A;

                    a = b = Math.Sqrt(1 / C[0, 0]);
                    c = Math.Sqrt(1 / C[1, 0]);
                    alpha = beta = Math.PI / 2;
                    gamma = Math.PI / 1.5;
                    V = a * a * c * Math.Sqrt(3) / 2;
                    break;
                    #endregion

                case 6://cubic
                    #region cubic
                    for (int i = 0; i < column; i++)
                    {
                        Q[i, 0] = p[i].H * p[i].H + p[i].K * p[i].K + p[i].L * p[i].L;
                        A[i, 0] = 1 / p[i].D / p[i].D;
                        W[i, i] = p[i].Weight * p[i].Reliability;
                    }
                    if (!(Q.Transpose() * W * Q).TryInverse(out inv))
                        return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);
                    C = inv * Q.Transpose() * W * A;

                    a = b = c = Math.Sqrt(1 / C[0, 0]);
                    alpha = beta = gamma = Math.PI / 2;
                    V = a * a * a;
                    break;
                    #endregion
            }
            if (double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) || double.IsNaN(alpha) || double.IsNaN(beta) || double.IsNaN(gamma) || double.IsNaN(V))
                return new Candidate(0, 0, 0, 0, 0, 0, 0, double.PositiveInfinity, double.PositiveInfinity, null);
            else
            {
                sigmaDQ = ((C.Transpose() * Q.Transpose() - A.Transpose()) * W * (Q * C - A))[0, 0];
                return new Candidate(a, b, c, alpha, beta, gamma, V, sigmaDQ, 0, p);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //TableOutputの情報を元に図を描画する

            Candidate[] candidates = ((Candidate[])e.UserState);
            
            dataSet1.Tables[1].Rows.Clear();
            for (int i = 0; i < candidates.Length; i++)
                dataSet1.Tables[1].Rows.Add(candidates[i].GenerateRow());

            toolStripStatusLabelTryNumber.Text = "Try Number: " + e.ProgressPercentage.ToString();
            DrawDistributionMap();
            //this.Refresh();
            Application.DoEvents();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader reader = new StreamReader(dlg.FileName, Encoding.GetEncoding("UTF-8"));
                    List<string> strList = new List<string>();
                    string tempstr;
                    while ((tempstr = reader.ReadLine()) != null)
                        strList.Add(tempstr);
                    reader.Close();

                    dataSet1.Tables[0].Rows.Clear();
                    Candidates.Clear();
                    for (int i = 3; i < strList.Count; i++)
                        dataSet1.Tables[0].Rows.Add(new object[] { Convert.ToDouble(strList[i]), "High", true });
                }
                catch { }
            }

        }



        private void dataGridViewResult_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Plane[] p = (Plane[])(dataSet1.Tables[1].Rows[e.RowIndex][9]);
                for (int i = 0; i < dataSet1.Tables[0].Rows.Count; i++)
                {
                    dataSet1.Tables[0].Rows[i][3] = p[i].H;
                    dataSet1.Tables[0].Rows[i][4] = p[i].K;
                    dataSet1.Tables[0].Rows[i][5] = p[i].L;
                    dataSet1.Tables[0].Rows[i][6] = p[i].D*10;
                    dataSet1.Tables[0].Rows[i][7] = (double)dataSet1.Tables[0].Rows[i][0] - p[i].D*10;
                }
                Application.DoEvents();
            }

            DrawDistributionMap();
            distributionGraphControl1.SelectedIndex = e.RowIndex;
        }
        private void comboBoxX_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawDistributionMap();
        }

        private void comboBoxY_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawDistributionMap();
        }




        private void DrawDistributionMap()
        {
            if (dataSet1.Tables[1].Rows.Count < 1) return;
            double minR = (double)dataSet1.Tables[1].Rows[0][8];

            double maxR = (double)dataSet1.Tables[1].Rows[dataSet1.Tables[1].Rows.Count - 1][8];

            //pictureBoxに分布を描く
            distributionGraphControl1.ClearData();
            for (int i = dataSet1.Tables[1].Rows.Count-1; i >=0; i--)
            {
                double x = 0, y = 0;
                switch (comboBoxX.Text)
                {
                    case "a": x = (double)dataSet1.Tables[1].Rows[i][0]; break;
                    case "b": x = (double)dataSet1.Tables[1].Rows[i][1]; break;
                    case "c": x = (double)dataSet1.Tables[1].Rows[i][2]; break;
                    case "α": x = (double)dataSet1.Tables[1].Rows[i][3]; break;
                    case "β": x = (double)dataSet1.Tables[1].Rows[i][4]; break;
                    case "γ": x = (double)dataSet1.Tables[1].Rows[i][5]; break;
                }
                switch (comboBoxY.Text)
                {
                    case "a": y = (double)dataSet1.Tables[1].Rows[i][0]; break;
                    case "b": y = (double)dataSet1.Tables[1].Rows[i][1]; break;
                    case "c": y = (double)dataSet1.Tables[1].Rows[i][2]; break;
                    case "α": y = (double)dataSet1.Tables[1].Rows[i][3]; break;
                    case "β": y = (double)dataSet1.Tables[1].Rows[i][4]; break;
                    case "γ": y = (double)dataSet1.Tables[1].Rows[i][5]; break;
                }
                double r = (double)dataSet1.Tables[1].Rows[i][8];
                int index =(int)(65535 * ((maxR - r) / (maxR-minR)));
                if(index<1)index=0;
                if(index>65535) index = 65535;

                distributionGraphControl1.AddData(new PointD(x, y), 5, 5, color[index], color[index], 0, false);

            }
            distributionGraphControl1.Initialize();
            distributionGraphControl1.Draw();
        }

        private void buttonSendToAtomicPositionFinder_Click(object sender, EventArgs e)
        {

        }

        private void FormCellFinder_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            formMain.toolStripButtonCellFinder.Checked = false;

        }

    }
}
