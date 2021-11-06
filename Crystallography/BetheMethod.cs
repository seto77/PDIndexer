﻿#region using
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using DMat = MathNet.Numerics.LinearAlgebra.Complex.DenseMatrix;
using DVec = MathNet.Numerics.LinearAlgebra.Complex.DenseVector;
using static System.Numerics.Complex;
using MathNet.Numerics;
using System.Xml.Serialization;
using OpenTK.Graphics.ES20;
using System.Windows.Forms;
using System.Buffers;
using System.Runtime.InteropServices;
#endregion

namespace Crystallography
{
    /// <summary>
    /// Bethe法による動力学計算を提供するクラス。すべて、単位はnm
    /// </summary>
    [Serializable]
    public class BetheMethod
    {
        #region static readonly field
        private static readonly Complex One = Complex.One;
        private static readonly double TwoPi = 2 * Math.PI;
        private static readonly Complex TwoPiI = TwoPi * ImaginaryOne;
        private static readonly Complex PiI = Math.PI * ImaginaryOne;
        private static readonly double PiSq = Math.PI * Math.PI;
        private static readonly Vector3DBase zNorm = new(0, 0, 1);
        public static readonly bool EigenEnabled;
        #endregion

        #region フィールド、プロパティ

        private double AccVoltage { get; set; }
        private Crystal Crystal { get;} 
        private Matrix3D BaseRotation { get; set; } = null;
        public double AlphaMax { get; set; }
        public double Cs { get; set; }
        public double Defocus { get; set; }
        public Matrix3D[] BeamRotations { get; set; }
        public int RotationArrayValidLength { get; set; } = 0;

        /// <summary>
        /// サンプル表面(から内部への)の法線単位ベクトル. ReciProの座標系は、画面右が+X、上が+Y,手前が+Zなので、初期値は(0,0,-1)
        /// </summary>
        public Vector3D Surface { get; set; } = new Vector3D(0, 0, -1);
        public int MaxNumOfBloch { get; set; }
        public double Thickness { get; set; }
        public double[] Thicknesses { get; set; }
        public enum Solver { Eigen_MKL, Eigen_Eigen, MtxExp_MKL, MtxExp_Eigen, Auto }

        public DVec EigenValues { get; set; }
        public DMat EigenVectors { get; set; }
        public Matrix<Complex> EigenVectorsInverse { get; set; }

        public DVec[] EigenValuesPED { get; set; }
        public DMat[] EigenVectorsPED { get; set; }
        public DMat[] EigenVectorsInversePED { get; set; }

        [NonSerialized]
        public Beam[][] BeamsPED;
        public double SemianglePED { get; set; }

        public bool IsBusy => bwCBED == null || bwCBED.IsBusy;

        /// <summary>
        /// Disks[Z_index][G_index]
        /// </summary>
        [XmlIgnore]
        public CBED_Disk[][] Disks { get; set; }

        [NonSerialized]
        public Beam[] Beams;

        [NonSerialized]
        private readonly BackgroundWorker bwCBED = new();

        public event ProgressChangedEventHandler CbedProgressChanged;

        public event RunWorkerCompletedEventHandler CbedCompleted;

        private readonly object lockObj1 = new();
        private readonly object lockObj2 = new();

        #endregion

        #region コンストラクタ

        static BetheMethod()
        {
            EigenEnabled = NativeWrapper.Enabled;
        }
        public BetheMethod(Crystal crystal)
        {
            Crystal = crystal;

            bwCBED = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };
            bwCBED.RunWorkerCompleted += Cbed_RunWorkerCompleted;
            bwCBED.ProgressChanged += Cbed_ProgressChanged;
            bwCBED.DoWork += cbed_DoWork;
        }
        #endregion

        #region CBED
        private void Cbed_ProgressChanged(object sender, ProgressChangedEventArgs e) => CbedProgressChanged?.Invoke(sender, e);

        private void Cbed_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => CbedCompleted?.Invoke(sender, e);

        public void CancelCBED()
        {
            if (bwCBED.IsBusy)
                bwCBED.CancelAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="maxNumOfBloch"></param>
        /// <param name="voltage">加速電圧(kV)</param>
        /// <param name="rotation">基準となる方位</param>
        /// <param name="thickness">厚みの配列</param>
        /// <param name="beamRotations">基準となる方位に乗算する方位配列</param>
        public void RunCBED(int maxNumOfBloch, double voltage, Matrix3D rotation, double[] thickness, Matrix3D[] beamRotations, Solver solver = Solver.Auto, int thread = 1)
        {
            MaxNumOfBloch = maxNumOfBloch;
            AccVoltage = voltage;
            //Wavelength = UniversalConstants.Convert.EnergyToElectronWaveLength(voltage);
            BaseRotation = new Matrix3D(rotation);
            BeamRotations = beamRotations;
            Thicknesses = thickness;
            var mkl = MathNet.Numerics.Control.TryUseNativeMKL();
            bwCBED.RunWorkerAsync(new object[] { solver, thread });
        }

        /// <summary>
        /// CBED計算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbed_DoWork(object sender, DoWorkEventArgs e)
        {
            //波数を計算
            var kvac = UniversalConstants.Convert.EnergyToElectronWaveNumber(AccVoltage);
            //U0を計算
            var u0 = getU(AccVoltage, (0, 0, 0), 0).Real.Real;
            //k0ベクトルを計算
            var vecK0 = getVecK0(kvac, u0);
            //計算対象のg-Vectorsを決める。indexが小さく、かつsg(励起誤差)の小さいg-vectorを抽出する
            Beams = Find_gVectors(BaseRotation, vecK0);

            //入射面での波動関数を定義
            var psi0 = new DVec(Enumerable.Range(0, Beams.Length).ToList().Select(g => g == 0 ? One : 0).ToArray());
            //ポテンシャルマトリックスを初期化
            uDictionary = new Dictionary<int, (Complex, Complex)>();
            var factorMatrix = getPotentialMatrix(Beams);
            //有効なRotationだけを選択
            int width = (int)Math.Sqrt(BeamRotations.Length);
            double radius = width / 2.0;
            bool inside(int i) => (i % width - radius + 0.5) * (i % width - radius + 0.5) + (i / width - radius + 0.5) * (i / width - radius + 0.5) <= radius * radius;
            var beamRotationsValid = BeamRotations.Where((rot, i) => inside(i)).ToList();

            RotationArrayValidLength = beamRotationsValid.Count;

            //進捗状況報告用の各種定数を初期化
            int count = 0;

            #region solver, thread の設定
            var solver = (Solver)((object[])e.Argument)[0];
            var thread = (int)((object[])e.Argument)[1];

            if (!EigenEnabled && (solver == Solver.Eigen_Eigen || solver == Solver.MtxExp_Eigen))
                solver = Solver.Auto;

            if (solver == Solver.Auto)
            {
                if (EigenEnabled)
                {
                    solver = Solver.MtxExp_Eigen;
                    thread = Environment.ProcessorCount;
                }
                else
                {
                    solver = Solver.Eigen_MKL;
                    thread = MathNet.Numerics.Control.TryUseNativeMKL() ? Math.Max(1, Environment.ProcessorCount / 4) : Environment.ProcessorCount;
                }

            }
            var reportString = $"{solver}{thread}";
            #endregion

            var len = Beams.Length;
            var beamRotationsP = beamRotationsValid.AsParallel().WithDegreeOfParallelism(thread);

            //ここからdiskValid[t][g]を計算.
            var diskAmplitudeValid = beamRotationsP.Select(beamRotation =>
            {
                if (bwCBED.CancellationPending) return null;
                var rotZ = beamRotation * zNorm;
                var coeff = 1.0 / rotZ.Z; // = 1/cosTau

                var vecK0 = getVecK0(kvac, u0, beamRotation);

                var beams = reset_gVectors(Beams, BaseRotation, vecK0);//BeamsのPやQをリセット
                var potentialMatrix = getEigenProblemMatrix(beams, factorMatrix);//ポテンシャル行列をセット //コスト高い

                Complex[][] result;

                //ポテンシャル行列の固有値、固有ベクトルを取得し、resultに格納

                //Eigen＿Eigenの場合
                if (solver == Solver.Eigen_Eigen && EigenEnabled)
                    result = NativeWrapper.CBEDSolver_Eigen(potentialMatrix, psi0.ToArray(), Thicknesses, coeff);
                //Eigen_MKL あるいは Eigen_Managedの場合    
                else if (solver == Solver.Eigen_MKL)
                {
                    var evd = new DMat(len, len, potentialMatrix).Evd(Symmetricity.Asymmetric);
                    var alpha = evd.EigenVectors.LU().Solve(psi0);
                    result = Thicknesses.Select(t =>
                    {
                        //ガンマの対称行列×アルファを作成
                        var gammmaAlpha = new DVec(evd.EigenValues.Select((ev, i) => Exp(TwoPiI * ev * t * coeff) * alpha[i]).ToArray());
                        //深さtにおけるψを求める
                        return evd.EigenVectors.Multiply(gammmaAlpha).ToArray();
                    }).ToArray();
                }
                //MtxExp_Eigenの場合
                else if (solver == Solver.MtxExp_Eigen && EigenEnabled)
                    result = NativeWrapper.CBEDSolver_MatExp(potentialMatrix, psi0.ToArray(), Thicknesses, coeff);
                //MtxExp_MKLの場合 
                else
                {
                    result = new Complex[Thicknesses.Length][];
                    var matExp = (DMat)(TwoPiI * coeff * Thicknesses[0] * new DMat(len, len, potentialMatrix)).Exponential();
                    var vec = matExp.Multiply(psi0);
                    result[0] = vec.ToArray();

                    if (Thicknesses.Length > 1)
                    {
                        if (Thicknesses[1] - Thicknesses[0] == Thicknesses[0])
                            matExp = (DMat)(TwoPiI * coeff * (Thicknesses[1] - Thicknesses[0]) * new DMat(len, len, potentialMatrix)).Exponential();
                        for (int i = 1; i < Thicknesses.Length; i++)
                        {
                            vec = (DVec)matExp.Multiply(vec);
                            result[i] = vec.ToArray();
                        }
                    }
                }
                bwCBED.ReportProgress(Interlocked.Increment(ref count), reportString);//進捗状況を報告
                return result;
            }).ToArray();

            //無効なRotationも再び組み込んでdisk[RotationIndex][Z_index][G_index]を構築
            var diskAmplitude = new List<Complex[][]>();
            for (int i = 0, j = 0; i < BeamRotations.Length; i++)
                diskAmplitude.Add(inside(i) ? diskAmplitudeValid[j++] : null);//有効(円内)のピクセルを追加し、無効なものにはnull

            count = 0;
            bwCBED.ReportProgress(0, "Compiling disks");
            //diskをコンパイルする
            Disks = new CBED_Disk[Thicknesses.Length][];
            Parallel.For(0, Thicknesses.Length, t =>
            {
                Disks[t] = new CBED_Disk[Beams.Length];
                for (int g = 0; g < Beams.Length; g++)
                {
                    var amplitudes = new Complex[BeamRotations.Length];
                    for (int r = 0; r < BeamRotations.Length; r++)
                        if (diskAmplitude[r] != null)
                            amplitudes[r] = diskAmplitude[r][t][g];

                    Disks[t][g] = new CBED_Disk(new[] { Beams[g].H, Beams[g].K, Beams[g].L }, Beams[g].Vec, Thicknesses[t], amplitudes);
                }
            });

            //ここから、diskの重なり合いを計算

            //まず、各ディスクを構成するピクセルの座標を計算
            var diskTemp = new (RectangleD Rect, PointD[] Pos)[Beams.Length];
            Parallel.For(0, Beams.Length, g =>
            {
                if (!bwCBED.CancellationPending)
                {
                    var pos = new PointD[BeamRotations.Length];
                    for (int r = 0; r < pos.Length; r++)
                    {
                        var vec = BeamRotations[r] * (new Vector3DBase(0, 0, kvac) - Disks[0][g].G);//Ewald球中心(試料)から見た、逆格子ベクトルの方向
                        pos[r] = new PointD(vec.X / vec.Z, vec.Y / vec.Z); //カメラ長 1 を想定した検出器上のピクセルの座標値を格納
                    }
                    diskTemp[g] = (new RectangleD(new PointD(pos.Min(p => p.X), pos.Min(p => p.Y)), new PointD(pos.Max(p => p.X), pos.Max(p => p.Y))), pos);
                }
            });

            //g1のディスク中のピクセル(r1)に対して、他のディスク(g2)の重なるピクセル(r2)を足し合わせていく。
            Parallel.For(0, Beams.Length, g1 =>
            {
                if (!bwCBED.CancellationPending)
                {
                    var intensities = new double[Thicknesses.Length][];
                    for (int t = 0; t < Thicknesses.Length; t++)
                        intensities[t] = Disks[t][g1].RawAmplitudes.Select(a => a.MagnitudeSquared()).ToArray();

                    for (int r1 = 0; r1 < BeamRotations.Length; r1++)
                    {
                        if (Disks[0][g1].RawAmplitudes[r1] != 0)
                        {
                            var pos = diskTemp[g1].Pos[r1];
                            for (int g2 = 0; g2 < Beams.Length; g2++)
                                if (g2 != g1 && diskTemp[g2].Rect.IsInsde(pos))
                                {
                                    var r2 = getIndex(pos, diskTemp[g2].Pos, width);
                                    if (r2 >= 0 && Disks[0][g2].RawAmplitudes[r2] != 0)
                                        for (int t = 0; t < Thicknesses.Length; t++)
                                            intensities[t][r1] += Disks[t][g2].RawAmplitudes[r2].MagnitudeSquared();
                                }
                        }
                    }

                    for (int t = 0; t < Thicknesses.Length; t++)
                        Disks[t][g1].Amplitudes = intensities[t].Select(intensity => new Complex(Math.Sqrt(intensity), 0)).ToArray();
                }
                bwCBED.ReportProgress(Interlocked.Increment(ref count)*1000/ Beams.Length, "Compiling disks");//進捗状況を報告
            });

            if (bwCBED.CancellationPending)
                e.Cancel = true;
        }

        /// <summary>
        /// EBSD計算用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbed_DoWork2(object sender, DoWorkEventArgs e)
        {
            //波数を計算
            var kvac = UniversalConstants.Convert.EnergyToElectronWaveNumber(AccVoltage);
            //U0を計算
            var u0 = getU(AccVoltage, (0, 0, 0), 0).Real.Real;
            int width = (int)Math.Sqrt(BeamRotations.Length);
            double radius = width / 2.0;
            bool inside(int i) => (i % width - radius + 0.5) * (i % width - radius + 0.5) + (i / width - radius + 0.5) * (i / width - radius + 0.5) <= radius * radius;
            //var beamRotationsValid = BeamRotations.Where((rot, i) => inside(i)).ToList();

            //RotationArrayValidLength = beamRotationsValid.Count;
            gDic.Clear();
            //進捗状況報告用の各種定数を初期化
            int count = 0;

            #region solver, thread の設定
            var solver = (Solver)((object[])e.Argument)[0];
            var thread = (int)((object[])e.Argument)[1];

            if (!EigenEnabled && (solver == Solver.Eigen_Eigen || solver == Solver.MtxExp_Eigen))
                solver = Solver.Auto;

            if (solver == Solver.Auto)
            {
                if (EigenEnabled)
                {
                    solver = Solver.MtxExp_Eigen;
                    thread = Environment.ProcessorCount;
                }
                else
                {
                    solver = Solver.Eigen_MKL;
                    thread = MathNet.Numerics.Control.TryUseNativeMKL() ? Math.Max(1, Environment.ProcessorCount / 4) : Environment.ProcessorCount;
                }

            }
            var reportString = $"{solver}{thread}";
            #endregion

            var beamRotationsP = BeamRotations.AsParallel().WithDegreeOfParallelism(thread);

            //diskAmplitude[r][t][g]
            var diskAmplitude = beamRotationsP.Select((beamRotation, i) =>
            {
                if (!inside(i)) return (null, null);

                if (bwCBED.CancellationPending) return (null, null);
                var rotZ = beamRotation * zNorm;
                var coeff = 1.0 / rotZ.Z; // = 1/cosTau

                var vecK0 = getVecK0(kvac, u0, beamRotation);

                var beams = Find_gVectors(BaseRotation, vecK0,MaxNumOfBloch,true);
                var potentialMatrix = getEigenProblemMatrix(beams);
                var len = beams.Length;
                //入射面での波動関数を定義
                var psi0 = new DVec(Enumerable.Range(0, len).ToList().Select(g => g == 0 ? One : 0).ToArray());

                Complex[][] result;

                //ポテンシャル行列の固有値、固有ベクトルを取得し、resultに格納
                #region 各ソルバーによる計算
                //Eigen＿Eigenの場合
                if (solver == Solver.Eigen_Eigen && EigenEnabled)
                    result = NativeWrapper.CBEDSolver_Eigen(potentialMatrix, psi0.ToArray(), Thicknesses, coeff);
                //Eigen_MKL あるいは Eigen_Managedの場合    
                else if (solver == Solver.Eigen_MKL)
                {
                    var evd = new DMat(len, len, potentialMatrix).Evd(Symmetricity.Asymmetric);
                    var alpha = evd.EigenVectors.LU().Solve(psi0);
                    result = Thicknesses.Select(t =>
                    {
                        //ガンマの対称行列×アルファを作成
                        var gammmaAlpha = new DVec(evd.EigenValues.Select((ev, i) => Exp(TwoPiI * ev * t * coeff) * alpha[i]).ToArray());
                        //深さtにおけるψを求める
                        return evd.EigenVectors.Multiply(gammmaAlpha).ToArray();
                    }).ToArray();
                }
                //MtxExp_Eigenの場合
                else if (solver == Solver.MtxExp_Eigen && EigenEnabled)
                    result = NativeWrapper.CBEDSolver_MatExp(potentialMatrix, psi0.ToArray(), Thicknesses, coeff);
                //MtxExp_MKLの場合 
                else
                {
                    result = new Complex[Thicknesses.Length][];
                    var matExp = (DMat)(TwoPiI * coeff * Thicknesses[0] * new DMat(len, len, potentialMatrix)).Exponential();
                    var vec = matExp.Multiply(psi0);
                    result[0] = vec.ToArray();

                    if (Thicknesses.Length > 1)
                    {
                        if (Thicknesses[1] - Thicknesses[0] == Thicknesses[0])
                            matExp = (DMat)(TwoPiI * coeff * (Thicknesses[1] - Thicknesses[0]) * new DMat(len, len, potentialMatrix)).Exponential();
                        for (int t = 1; t < Thicknesses.Length; t++)
                        {
                            vec = (DVec)matExp.Multiply(vec);
                            result[t] = vec.ToArray();
                        }
                    }
                }
                #endregion

                bwCBED.ReportProgress(Interlocked.Increment(ref count), reportString);//進捗状況を報告
                return (result, beams);
            }).ToArray();

            count = 0;
            bwCBED.ReportProgress(0, "Compiling disks");

            var directDiskIntensities = new double[Thicknesses.Length][];
            for (int t = 0; t < Thicknesses.Length; t++)
            {
                directDiskIntensities[t] = new double[BeamRotations.Length];
                for (int r = 0; r < directDiskIntensities[t].Length; r++)
                    if(diskAmplitude[r].result != null)
                        directDiskIntensities[t][r] = diskAmplitude[r].result[t][0].MagnitudeSquared();
            }

            var directDiskPositions = new PointD[BeamRotations.Length];
            for (int r = 0; r < BeamRotations.Length; r++)
            {
                var vec = BeamRotations[r] * new Vector3DBase(0, 0, kvac);//Ewald球中心(試料)から見た、逆格子ベクトルの方向
                directDiskPositions[r] = new PointD(vec.X / vec.Z, vec.Y / vec.Z); //カメラ長 1 を想定した検出器上のピクセルの座標値を格納
            }
            double xMax = directDiskPositions.Max(p => p.X), xMin = directDiskPositions.Min(p => p.X);
            double yMax = directDiskPositions.Max(p => p.Y), yMin = directDiskPositions.Min(p => p.Y);

            Parallel.For(0, BeamRotations.Length, r1 =>
            {
                if (diskAmplitude[r1].result != null)
                {
                    for (int g = 1; g < diskAmplitude[r1].beams.Length; g++)
                    {
                        var vec = BeamRotations[r1] * (new Vector3DBase(0, 0, kvac) - diskAmplitude[r1].beams[g].Vec);//Ewald球中心(試料)から見た、逆格子ベクトルの方向
                        double posX = vec.X / vec.Z, posY = vec.Y / vec.Z; //カメラ長 1 を想定した検出器上のピクセルの座標値を格納
                        if (posX < xMax && posX > xMin && posY < yMax && posY > yMin)
                        {
                            var r2 = getIndex(new PointD (posX, posY), directDiskPositions, width);
                            if (r2 >= 0 && directDiskIntensities[0][r2] != 0)
                                lock (lockObj1)
                                    for (int t = 0; t < Thicknesses.Length; t++)
                                        directDiskIntensities[t][r2] += diskAmplitude[r1].result[t][g].MagnitudeSquared();
                        }
                    }
                }
                bwCBED.ReportProgress(Interlocked.Increment(ref count) * 1000 / BeamRotations.Length, "Compiling disks");
            });
            
            Disks = new CBED_Disk[Thicknesses.Length][];
            for (int t = 0; t < Thicknesses.Length; t++)
            {
                Disks[t] = new[] { new CBED_Disk(new[] { 0, 0, 0 }, new Vector3DBase(0,0,0), Thicknesses[t],
                    directDiskIntensities[t].Select(intensity => new Complex(Math.Sqrt(intensity), 0)).ToArray()) };
                Disks[t][0].Amplitudes = Disks[t][0].RawAmplitudes;
            }

            if (bwCBED.CancellationPending)
                e.Cancel = true;
        }

        //与えられたposに最も近いインデックスを返す
        static int getIndex(PointD pos, PointD[] posList, int width)
        {
            var w2 = width * width;
            int i = w2 / 2, j = i - 1;//中心から、縦横に検索
            double min = (pos - posList[i]).Length2, temp = min;

            while (i != j)
            {
                j = i;
                if (i + 1 < w2 && (temp = (pos - posList[i + 1]).Length2) < min)
                    i++;
                else if (i - 1 >= 0 && (temp = (pos - posList[i - 1]).Length2) < min)
                    i--;
                min = Math.Min(min, temp);

                if (i + width < w2 && (temp = (pos - posList[i + width]).Length2) < min)
                    i += width;
                else if (i - width >= 0 && (temp = (pos - posList[i - width]).Length2) < min)
                    i -= width;
                min = Math.Min(min, temp);
            }
            if (i / width == 0 || i / width == width - 1 || i % width == 0 || i % width == width - 1)
                return -1;
            else
                return i;
        }

        #endregion

        #region 平行ビーム電子回折

        /// <summary>
        /// 平行ビームの電子回折計算
        /// </summary>
        /// <param name="maxNumOfBloch"></param>
        /// <param name="voltage"></param>
        /// <param name="rotation"></param>
        /// <param name="thickness"></param>
        /// <returns></returns>
        public Beam[] GetDifractedBeamAmpriltudes(int maxNumOfBloch, double voltage, Matrix3D rotation, double thickness)
        {

            var useEigen = !MathNet.Numerics.Control.TryUseNativeMKL();

            if (AccVoltage != voltage)
                uDictionary = new Dictionary<int, (Complex, Complex)>();

            //波数を計算
            var k_vac = UniversalConstants.Convert.EnergyToElectronWaveNumber(voltage);
            //U0を計算
            var u0 = getU(voltage, (0, 0, 0), 0).Real.Real;
            var vecK0 = getVecK0(k_vac, u0);

            int dim;
            if (MaxNumOfBloch != maxNumOfBloch || AccVoltage != voltage || EigenValues == null || EigenVectors == null || !rotation.Equals(BaseRotation))
            {
                MaxNumOfBloch = maxNumOfBloch;
                AccVoltage = voltage;
                BaseRotation = new Matrix3D(rotation);
                Thickness = thickness;

                //計算対象のg-Vectorsを決める。
                Beams = Find_gVectors(BaseRotation, vecK0);

                if (Beams == null || Beams.Length == 0) return Array.Empty<Beam>();

                var potentialMatrix = getEigenProblemMatrix(Beams);
                dim = Beams.Length;
                //A行列に関する固有値、固有ベクトルを取得 
                if (useEigen) { 
                    (EigenValues, EigenVectors) = NativeWrapper.EigenSolver(dim, potentialMatrix);
                    EigenVectorsInverse = NativeWrapper.Inverse(EigenVectors);
                }
                else
                {
                    var evd = new DMat(dim,dim, potentialMatrix).Evd(Symmetricity.Asymmetric);
                    EigenValues = evd.EigenValues.ToArray();
                    EigenVectors = (DMat)evd.EigenVectors;
                    EigenVectorsInverse = EigenVectors.Inverse();
                }
            }

            dim = Beams.Length;

            var psi0 = new DVec(new Complex[dim]) { [0] = 1 };//入射面での波動関数を定義

            var alpha = EigenVectorsInverse.Multiply(psi0);//アルファベクトルを求める

            //ガンマの対称行列×アルファを作成
            var gamma_alpha = new DVec(Enumerable.Range(0, dim).Select(n => Exp(TwoPiI * EigenValues[n] * thickness) * alpha[n]).ToArray());

            //出射面での境界条件を考慮した位相にするため、以下の1行を追加 (20190827)
            var p = new DiagonalMatrix(dim, dim, Beams.Select(b => Exp(PiI * (b.P - 2 * k_vac * Surface.Z) * thickness)).ToArray());

            //深さZにおけるψを求める
            var psi_atZ = p.Multiply( EigenVectors.Multiply(gamma_alpha));

            for (int i = 0; i < Beams.Length && i < dim; i++)
                Beams[i].Psi = psi_atZ[i];

            return Beams;
        }

        #endregion

        #region Precession electron diffraction

        /// <summary>
        /// PEDの計算
        /// </summary>
        /// <param name="maxNumOfBloch"></param>
        /// <param name="voltage"></param>
        /// <param name="baseRotation"></param>
        /// <param name="thickness"></param>
        /// <param name="semiangle"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public Beam[] GetPrecessionElectronDiffraction(int maxNumOfBloch, double voltage, Matrix3D baseRotation, double thickness, double semiangle, int step)
        {

            //波数を計算
            var kvac = UniversalConstants.Convert.EnergyToElectronWaveNumber(voltage);
            //U0を計算
            var u0 = getU(voltage, (0, 0, 0), 0).Real.Real;

            if (AccVoltage != voltage)
                uDictionary = new Dictionary<int, (Complex, Complex)>();

            var useEigen = EigenEnabled && maxNumOfBloch < 400;
            if (!MathNet.Numerics.Control.TryUseNativeMKL())
                useEigen = true;
            
            var stepP = Enumerable.Range(0, step).ToList().AsParallel().WithDegreeOfParallelism(useEigen ? Environment.ProcessorCount : Math.Max(1, Environment.ProcessorCount / 4));
            if (MaxNumOfBloch != maxNumOfBloch || AccVoltage != voltage || EigenValuesPED == null || EigenValuesPED.Length != step
                || EigenVectorsPED == null || EigenVectorsPED.Length != step || semiangle != SemianglePED || !baseRotation.Equals(BaseRotation))
            {
                MaxNumOfBloch = maxNumOfBloch;
                AccVoltage = voltage;
                BaseRotation = new Matrix3D(baseRotation);
                Thickness = thickness;
                SemianglePED = semiangle;

                EigenValuesPED = new DVec[step];
                EigenVectorsPED = new DMat[step];
                EigenVectorsInversePED = new DMat[step];
                BeamsPED = new Beam[step][];

                gDic.Clear();
                stepP.ForAll(k =>
                   {
                       var rotAngle = 2.0 * Math.PI * k / step;
                       var beamRotation = Matrix3D.Rot(new Vector3DBase(Math.Cos(rotAngle), Math.Sin(rotAngle), 0), SemianglePED);
                       //計算対象のg-Vectorsを決める。
                       var potentialMatrix = Array.Empty<Complex>();
                       var vecK0 = getVecK0(kvac, u0, beamRotation);
                       BeamsPED[k] = Find_gVectors(BaseRotation, vecK0,MaxNumOfBloch,true);
                       potentialMatrix = getEigenProblemMatrix(BeamsPED[k]);
                       var dim = BeamsPED[k].Length;
                       //A行列に関する固有値、固有ベクトルを取得 
                       if (useEigen)
                       {//Eigenを使う場合
                           (EigenValuesPED[k], EigenVectorsPED[k]) = NativeWrapper.EigenSolver(dim, potentialMatrix);
                           EigenVectorsInversePED[k] = NativeWrapper.Inverse(EigenVectorsPED[k]);
                       }
                       else
                       {//MKLを使う場合
                           var evd = new DMat(dim, dim, potentialMatrix).Evd(Symmetricity.Asymmetric);
                           EigenValuesPED[k] = (DVec)evd.EigenValues;
                           EigenVectorsPED[k] = (DMat)evd.EigenVectors;
                           EigenVectorsInversePED[k] = (DMat)EigenVectorsPED[k].Inverse();
                       }
                   });
            }

            //各方向でのbeamの振幅を求める
            stepP.ForAll(k =>
            {
                if (EigenValuesPED[k] != null)
                {
                    var len = EigenValuesPED[k].Count;
                    var psi0 = new DVec(new Complex[len]) { [0] = 1 };//入射面での波動関数を定義
                    var alpha = EigenVectorsInversePED[k].Multiply(psi0);//アルファベクトルを求める
                    //ガンマの対称行列×アルファを作成
                    var gamma_alpha = new DVec(Enumerable.Range(0, len).Select(n => Exp(TwoPiI * EigenValuesPED[k][n] * thickness) * alpha[n]).ToArray());
                    //深さZにおけるψを求める
                    var psi_atZ = EigenVectorsPED[k].Multiply(gamma_alpha);
                    for (int i = 0; i < BeamsPED[k].Length && i < len; i++)
                        BeamsPED[k][i].Psi = psi_atZ[i];
                }
            });

            //最後に全てのビームをまとめる
            var compiled = new Dictionary<(int h, int k, int l), Beam>();
            foreach (var beamsEach in BeamsPED.Where(beams => beams != null))
                foreach (var beam in beamsEach)
                {
                    if (!compiled.ContainsKey(beam.Index))
                    {
                        compiled.Add(beam.Index, beam);
                        compiled[beam.Index].intensity = beam.Psi.MagnitudeSquared() / step;
                    }
                    else
                        compiled[beam.Index].intensity += beam.Psi.MagnitudeSquared() / step;
                }

            //基準の方位でP,Q,Sなどを再セット
            var mat = BaseRotation * Crystal.MatrixInverse.Transpose();
            var beams = compiled.Values.ToList();
            for (int i = 0; i < beams.Count; i++)
            {
                var g = mat * beams[i].Index;
                var (Q, P) = getQP(g, kvac, u0);
                var psi = new Complex(Math.Sqrt(beams[i].intensity), 0);
                beams[i] = new Beam(beams[i].Index, g, (beams[i].Freal, beams[i].Fimag), (Q, P)) { Psi = psi };
            }

            //並び替え
            beams.Sort((a, b) =>
            {
                var c = a.Rating - b.Rating;
                return (c > 0) ? 1 : (c < 0) ? -1 : 0;
            });
            Beams = beams.ToArray();
            return Beams;
        }

        #endregion

        #region Image Simulation
        public double[][] GetPotentialImage(IEnumerable<Beam> beams, Size size, double res, bool phase = true)
        {
            int width = size.Width, height = size.Height;
            //gList[gNUm]を全て計算
            var gList = beams.Select(b => (b.Freal, b.Fimag, b.Vec.ToPointD)).ToList();
            //imagesを初期化
            
            var images = Enumerable.Range(0, 4).ToList().Select(d => new double[width * height]).ToArray();
            
            var shift = Crystal.RotationMatrix * (Crystal.A_Axis + Crystal.B_Axis + Crystal.C_Axis) / 2;
            double cX = width / 2.0 , cY = height / 2.0 ;
            Parallel.For(0, width * height, n =>
            {
                //単位格子軸の0.5倍だけシフトさせておく
                var r = new PointD(-(n % width - cX) * res + shift.X, -(height - 1 - n / width - cY) * res + shift.Y);
                var sums = new Complex[2];
                foreach (var (uCry, uTher, vec) in gList)
                {
                    var exp = Exp(vec * r * TwoPiI);
                    sums[0] += uCry * exp;
                    sums[1] += uTher * exp;
                }
                for (var i = 0; i < sums.Length; i++)
                {
                    images[i * 2][n] = phase ? sums[i].Magnitude : sums[i].Real;
                    images[i * 2 + 1][n] = phase ? sums[i].Phase : sums[i].Imaginary;
                }
            });
            return images;
        }



        /// <summary>
        /// HRTEMイメージをシミュレーションする
        /// </summary>
        /// <param name="beams"></param>
        /// <param name="size"></param>
        /// <param name="res"></param>
        /// <param name="cs">球面収差</param>
        /// <param name="aper"></param>
        /// <param name="beta">単位は rad</param>
        /// <param name="delta">Cc * ΔV/V 単位は nm</param>
        /// <param name="defocus">配列で与える. 単位はnm</param>
        /// <param name="quasiMode">trueの時はQuasi-coherent mode, falseの時はTransmission cross coefficient </param>
        /// <returns>double[defocusNum][pixels]</returns>
        public double[][] GetHRTEMImage(Beam[] beams, Size size, double res, double cs, double beta, double delta, double[] defocusses,
                                       bool quasiMode = true, bool native = true)
        {
            int width = size.Width, height = size.Height;
            double rambda = UniversalConstants.Convert.EnergyToElectronWaveLength(AccVoltage), rambdaSq = rambda * rambda;
            double deltaSq = delta * delta, betaSq = beta * beta;
            var k = new PointD(0, 0);//入射ベクトルKのXY成分
            var defLen = defocusses.Length;

            //gList[gNUm]を全て計算
            var gList = new List<(Complex Psi, PointD Vec, Complex[] Lenz)>();
            if (quasiMode)//Quasi-coherent modeの時
                foreach (var g in beams)
                {
                    var qSq = (k + g.Vec.ToPointD).Length2;
                    gList.Add((g.Psi, k + g.Vec.ToPointD, defocusses.Select(defocus =>
                        Exp(-PiI * rambda * qSq * (cs * rambdaSq * qSq / 2.0 + defocus))//球面収差
                        * Math.Exp(-PiSq * betaSq * qSq * (defocus + rambdaSq * cs * qSq) * (defocus + rambdaSq * cs * qSq))//Ec 時間的インコヒーレンス
                        * Math.Exp(-PiSq * rambdaSq * deltaSq * qSq * qSq / 2)//Es 空間的インコヒーレンス
                         ).ToArray()));
                }

            else//Transmission cross coefficient modelの時
            {
                var vecDic = new Dictionary<(int H, int K, int L), PointD>();
                for (var gNum = 0; gNum < beams.Length; gNum++)
                    for (var hNum = gNum; hNum < beams.Length; hNum++)
                    {
                        Beam g = beams[gNum], h = beams[hNum];
                        PointD q1 = k + g.Vec.ToPointD, q2 = k + h.Vec.ToPointD;
                        double q1Sq = q1.Length2, q2Sq = q2.Length2;
                        //gNum==hNumの時は、g.Psi.Magnitude2() が画素に伝わるだけなので、最後に強度を0~2^16に規格化する場合は、あってもなくても関係ない
                        var psi = gNum == hNum ? g.Psi.MagnitudeSquared() : 2 * g.Psi * Conjugate(h.Psi);

                        //indexが同じものがあるかどうかを検索し、無い場合のみvecを計算する
                        var index = (g.H - h.H, g.K - h.K, g.L - h.L);
                        if (!vecDic.TryGetValue(index, out var vec))
                        {
                            vec = (g.Vec - h.Vec).ToPointD;
                            vecDic.Add(index, vec);
                        }

                        var lenz = defocusses.Select(defocus =>
                            Exp(-PiI * rambda * q1Sq * (cs * rambdaSq * q1Sq / 2.0 + defocus)) *  //Kai1
                            Exp(PiI * rambda * q2Sq * (cs * rambdaSq * q2Sq / 2.0 + defocus)) *  //kai2
                            Math.Exp(-PiSq * betaSq * (defocus * (q1 - q2) + rambdaSq * cs * (q1Sq * q1 - q2Sq * q2)).Length2) *  //Es 空間的インコヒーレンス
                            Math.Exp(-PiSq * rambdaSq * deltaSq * (q1Sq - q2Sq) * (q1Sq - q2Sq) / 2.0) //Ec 時間的インコヒーレンス
                            ).ToArray();

                        gList.Add((psi, vec, lenz));
                    }
            }
            //gListを並び替え
            gList.Sort((g1, g2) =>
            {
                double x = g1.Vec.X - g2.Vec.X, y = g1.Vec.Y - g2.Vec.Y;
                return (y > 0 || (y == 0 && x > 0)) ? 1 : (y < 0 || (y == 0 && x < 0)) ? -1 : 0;
            });

            //imagesを初期化
            var images = defocusses.Select(d => new double[width * height]).ToArray();

            //各ピクセルの計算
            double cX = width / 2.0, cY = height / 2.0;
            var shift = Crystal.RotationMatrix * (Crystal.A_Axis + Crystal.B_Axis + Crystal.C_Axis) / 2;
            if (native && NativeWrapper.Enabled)//ネイティブC++で実行 3倍速い
            {
                var (gPsi, gVec, gLenz) = NativeWrapper.HRTEM_Helper(gList);
                int divTotal = Environment.ProcessorCount * 4, step = width * height / divTotal;
                Parallel.For(0, divTotal, div =>
                {
                    int start = step * div, count = div == divTotal - 1 ? width * height - start : step;
                    var rVec = Enumerable.Range(start, count).SelectMany(n => new[] { -res * (n % width - cX) + shift.X, -res * (height - n / width - 1 - cY) + shift.Y }).ToArray();
                    var results = NativeWrapper.HRTEM_Solver(gPsi, gVec, gLenz, rVec, quasiMode);
                    for (var i = 0; i < defLen; i++)
                        Array.Copy(results, i * count, images[i], start, count);
                });
            }
            else//Managed
            {
                Parallel.For(0, width * height, n =>
                {
                    PointD r = new(-(n % width - cX) * res + shift.X, -(height - n / width - 1 - cY) * res + shift.Y), _vec = new(double.NaN, double.NaN);
                    var sums = new Complex[defLen];
                    var exp = new Complex(0, 0);
                    foreach (var (Psi, Vec, Lenz) in gList)
                    {
                        if (_vec != Vec)
                            exp = Exp(Vec * r * TwoPiI);

                        for (var (i, f) = (0, Psi * exp); i < defLen; i++)
                            sums[i] += f * Lenz[i];

                        _vec = Vec;
                    }
                    for (var i = 0; i < defLen; i++)
                        images[i][n] = quasiMode ? sums[i].MagnitudeSquared() : Math.Abs(sums[i].Real);
                });
            }
            return images;
        }
        #endregion Image Simulation

        #region 構造因子 F
        /// <summary>
        /// 構造因子を求める. s2の単位は nm^-2
        /// </summary>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private (Complex Real, Complex Imag) getF(in (int H, int K, int L) index, in double s2)
        {
            Complex fReal = 0, fImag = 0;
            foreach (var atoms in Crystal.Atoms)
            {
                //var real = AtomConstants.ElectronScatteringEightGaussian[atoms.AtomicNumber].Factor(s2);
                var real = AtomStatic.ElectronScatteringPeng[atoms.AtomicNumber][atoms.SubNumberElectron].Factor(s2);
                // 等方散乱因子の時 あるいは非等方でg=0の時
                if (atoms.Dsf.UseIso || (index == (0, 0, 0)))
                {
                    var m =  atoms.Dsf.Biso;//Bisoの単位はnm^2
                    if (!atoms.Dsf.UseIso && double.IsNaN(m) && index == (0, 0, 0))// 非等方でg = 0、かつmがNaNの時 Acta Cryst. (1959). 12, 609 , Hamilton の式に従って、Bisoを計算
                    {
                        double a = Crystal.A, b = Crystal.B, c = Crystal.C;
                        m = (atoms.Dsf.B11 * a * a + atoms.Dsf.B22 * b * b + atoms.Dsf.B33 * c * c + 2 * atoms.Dsf.B12 * a * b + 2 * atoms.Dsf.B23 * b * c + 2 * atoms.Dsf.B31 * c * a) * 4.0 / 3.0;
                    }

                    if (double.IsNaN(m))
                        m = 0;
                    var t = Math.Exp(-m * s2);
                    //var imag = AtomConstants.ElectronScatteringEightGaussian[atoms.AtomicNumber].FactorImaginary(s2, m);//答えは無次元
                    var imag = AtomStatic.ElectronScatteringPeng[atoms.AtomicNumber][atoms.SubNumberElectron].FactorImaginary(s2, m);//答えは無次元
                    foreach (var atom in atoms.Atom)
                    {
                        var d = t * Exp(TwoPiI * (atom * index)) * atoms.Occ;
                        fReal += real * d;
                        fImag += imag * d;
                    }
                }
                //非等方散乱因子一般
                else
                {
                    foreach (var atom in atoms.Atom)
                    {
                        var (H, K, L) = atom.Operation.ConvertPlaneIndex(index);
                        var m = atoms.Dsf.B11 * H * H + atoms.Dsf.B22 * K * K + atoms.Dsf.B33 * L * L + 2 * atoms.Dsf.B12 * H * K + 2 * atoms.Dsf.B23 * K * L + 2 * atoms.Dsf.B31 * L * H;
                        //var imag = AtomConstants.ElectronScatteringEightGaussian[atoms.AtomicNumber].FactorImaginary(s2, m / s2);//答えは無次元

                        if (double.IsNaN(m)) m = 0;
                        var imag = AtomStatic.ElectronScatteringPeng[atoms.AtomicNumber][atoms.SubNumberElectron].FactorImaginary(s2, m / s2);//答えは無次元
                        var d = Math.Exp(-m) * Exp(TwoPiI * (atom * index)) * atoms.Occ;
                        fReal += real * d;
                        fImag += imag * d;
                    }
                }
            }
            return (fReal, fImag);
        }
        #endregion

        #region ポテンシャル U
        /// <summary>
        /// ポテンシャルを求める. s2の単位は nm^-2
        /// </summary>
        /// <param name="kV"></param>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private (Complex Real, Complex Imag) getU(in double kV, in (int H, int K, int L) index, in double s2)
        {
            var key = compose(index);
            if (!uDictionary.TryGetValue(key, out (Complex real, Complex imag) u))
            {
                var (fReal, fImag) = getF(index, s2);
                //Kirklandの教科書のp120参照
                var coeff1 = 1 / Math.PI / Crystal.Volume;
                //相対論補正
                var gamma = 1 + UniversalConstants.e0 * kV * 1E3 / UniversalConstants.m0 / UniversalConstants.c2;
                var beta = Math.Sqrt(1 - 1 / gamma / gamma);
                var coeff2 = 2 * UniversalConstants.h / UniversalConstants.m0 / beta / UniversalConstants.c * 1E9;
                u = (fReal * coeff1 * gamma, fImag * coeff1 * coeff2 * gamma);
                if (kV > 0)
                    lock (lockObj1)
                        uDictionary.TryAdd(key, u);
            }
            return u;
        }
        private (Complex Real, Complex Imag) getU(in (int H, int K, int L) index, in double s2) => getU(AccVoltage, index, s2);

        private Dictionary<int, (Complex, Complex)> uDictionary = new();
        #endregion

        #region ポテンシャルのマトリックス
        /// <summary>
        /// ポテンシャルマトリックスを求める. k0の単位はnm^-1. 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private Complex[,] getPotentialMatrix(Beam[] b)
        {
            var potentialMatrix = new Complex[b.Length, b.Length];//A行列確保
            //A行列を決定
            for (int j = 0; j < b.Length; j++) 
                for (int i = 0; i < b.Length; i++)
                {
                    var (Real, Imag) = getU((b[i].H - b[j].H, b[i].K - b[j].K, b[i].L - b[j].L), (b[i].Vec - b[j].Vec).Length2 / 4);
                    potentialMatrix[i, j] = i == j ? ImaginaryOne * Imag : Real + ImaginaryOne * Imag;
                }
            return potentialMatrix;
        }
        #endregion

        #region 固有値問題対象のマトリックス

        //private Complex[,] getEigenProblemMatrix(Beam[] b, Complex[,] potentialMatrix = null)
        //{
        //    if (potentialMatrix == null || potentialMatrix.GetLength(0) != b.Length)
        //        potentialMatrix = getPotentialMatrix(b);

        //    //A行列を決定
        //    var eigenProblemMatrix = new Complex[b.Length, b.Length];//A行列確保
        //    for (int i = 0; i < b.Length; i++)
        //    {
        //        for (int j = 0; j < b.Length; j++)
        //            eigenProblemMatrix[i, j] = potentialMatrix[i, j] / b[i].P;

        //        eigenProblemMatrix[i, i] += b[i].Q / b[i].P;

        //    }
        //    return eigenProblemMatrix;
        //}

        /// <summary>
        /// 固有値問題マトリックスを求める. k0の単位はnm^-1. パフォーマンス上の理由から、一次元配列にしている。
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        private Complex[] getEigenProblemMatrix(Beam[] b, Complex[,] potentialMatrix = null)
        {
            if (potentialMatrix == null || potentialMatrix.GetLength(0) != b.Length)
                potentialMatrix = getPotentialMatrix(b);

            var len = b.Length;
            //A行列を決定
            var eigenProblemMatrix = new Complex[b.Length * b.Length];//A行列確保
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                    eigenProblemMatrix[i* len+ j] = potentialMatrix[i, j] / b[i].P;

                eigenProblemMatrix[i* len+ i] += b[i].Q / b[i].P;

            }
            return eigenProblemMatrix;
        }
        #endregion

        #region 候補となるg vectorsの検索
        static readonly (int h, int k, int l)[] directionF = new[] { (1, 1, 1), (1, 1, -1), (1, -1, 1), (1, -1, -1), (-1, 1, 1), (-1, 1, -1), (-1, -1, 1), (-1, -1, -1) };
        static readonly (int h, int k, int l)[] directionA = new[] { (0, 1, 1), (0, 1, -1), (0, -1, 1), (0, -1, -1), (1, 0, 0), (-1, 0, 0) };
        static readonly (int h, int k, int l)[] directionB = new[] { (1, 0, 1), (1, 0, -1), (-1, 0, 1), (-1, 0, -1), (0, 1, 0), (0, -1, 0) };
        static readonly (int h, int k, int l)[] directionC = new[] { (1, 1, 0), (1, -1, 0), (-1, 1, 0), (-1, -1, 0), (0, 0, 1), (0, 0, -1) };
        static readonly (int h, int k, int l)[] directionI = new[] { (1, 1, 0), (1, -1, 0), (-1, 1, 0), (-1, -1, 0), (0, 1, 1), (0, 1, -1), (0, -1, 1), (0, -1, -1), (1, 0, 1), (1, 0, -1), (-1, 0, 1), (-1, 0, -1) };
        static readonly (int h, int k, int l)[] directionRH = new[] { (1, 0, 1), (0, -1, 1), (-1, 1, 1), (-1, 0, -1), (0, 1, -1), (1, -1, -1) };
        static readonly (int h, int k, int l)[] directionHex = new[] { (1, 0, 0), (-1, 0, 0), (0, 1, 0), (0, -1, 0), (1, -1, 0), (-1, 1, 0), (0, 0, 1), (0, 0, -1) };
        static readonly (int h, int k, int l)[] directionP = new[] { (1, 0, 0), (-1, 0, 0), (0, 1, 0), (0, -1, 0), (0, 0, 1), (0, 0, -1) };

        readonly Dictionary<int, Vector3DBase> gDic = new ();
        static int compose(in int h, in int k, in int l) => ((h + 255) << 20) + ((k + 255) << 10) + l + 255;
        static int compose(in (int h, int k, int l) index) => ((index.h + 255) << 20) + ((index.k + 255) << 10) + index.l + 255;
        static (int h, int k, int l) decompose(in int key) => ((key >> 20) - 255, ((key << 12) >> 22) - 255, ((key << 22) >> 22) - 255);

        /// <summary>
        /// 候補となるgVectorを検索する.
        /// </summary>
        /// <param name="baseRotation"></param>
        /// <param name="k0"></param>
        /// <returns></returns>
        public Beam[] Find_gVectors(Matrix3D baseRotation, Vector3DBase vecK0, int maxNumOfBloch = -1, bool use_gDictionary = false)
        {
            if (!use_gDictionary)
                gDic.Clear();

            if (maxNumOfBloch == -1)
                maxNumOfBloch = MaxNumOfBloch;
            var mat = baseRotation * Crystal.MatrixInverse.Transpose();
            var direction = Array.Empty<(int h, int k, int l)>();

            #region directionを初期化
            if (Crystal.Symmetry.LatticeTypeStr == "F") direction = directionF;
            else if (Crystal.Symmetry.LatticeTypeStr == "A") direction = directionA;
            else if (Crystal.Symmetry.LatticeTypeStr == "B") direction = directionB;
            else if (Crystal.Symmetry.LatticeTypeStr == "C") direction = directionC;
            else if (Crystal.Symmetry.LatticeTypeStr == "I") direction = directionI;
            else if (Crystal.Symmetry.LatticeTypeStr == "R" && Crystal.Symmetry.SpaceGroupHMsubStr == "H") direction = directionRH;
            else if (Crystal.Symmetry.CrystalSystemStr == "trigonal" || Crystal.Symmetry.CrystalSystemStr == "hexagonal") direction = directionHex;
            else direction = directionP;
            #endregion directionを初期化

            var (q0, p0) = getQP(new Vector3DBase(0, 0, 0), vecK0);
            var beams = new List<Beam>(maxNumOfBloch * 6) { { new Beam((0, 0, 0), new Vector3DBase(0, 0, 0), getU(AccVoltage, (0, 0, 0), 0), (q0, p0)) } };
            var outer = new List<(int key, double gLen)> { (compose(0, 0, 0), 0) };
            var whole = new HashSet<int> { compose(0, 0, 0) };

            var shift = direction.Select(dir => (mat * dir).Length).Max() * 1.01;

            double k0_2 = vecK0.Length2, k0 = vecK0.Length;
            double minR = (k0 - shift) * (k0 - shift), maxR = (k0 + shift) * (k0 + shift);
            double minR2 = (k0 - shift / 4) * (k0 - shift / 4), maxR2 = (k0 + shift / 4) * (k0 + shift / 4);
            Vector3DBase g;
            while (beams.Count < maxNumOfBloch * 4 && whole.Count < 1000000 && outer.Count > 0)
            {
                var min = outer[0].gLen + shift;
                int i = 0, count = outer.Count;
                for (; i < count && outer[i].gLen < min; i++)
                {
                    (int h1, int k1, int l1) = decompose(outer[i].key);
                    foreach ((int h2, int k2, int l2) in direction)
                    {
                        var index = (h1 + h2, k1 + k2, l1 + l2);
                        var key = compose(index);
                        if (!whole.Contains(key))
                        {
                            whole.Add(key);
                            if (!use_gDictionary)
                                g = mat * index;
                            else if (!gDic.TryGetValue(key, out g))
                            {
                                g = mat * index;
                                lock (lockObj2)
                                    gDic.TryAdd(key, g);
                            }

                            var v = g + vecK0;
                            var vLen2 = v.Length2;
                            if (vLen2 > minR && vLen2 < maxR)
                            {
                                if (vLen2 > minR2 && vLen2 < maxR2)
                                    beams.Add(new Beam(index, g, getU(AccVoltage, index, g.Length2 / 4), (k0_2 - vLen2, 2 * Surface * v)));
                                outer.Add((key, g.Length));
                            }

                        }
                    }
                }
                outer.RemoveRange(0, i);
                outer.Sort((o1, o2) => o1.gLen.CompareTo(o2.gLen));
            }

            //indexが小さく、かつQg(励起誤差)の小さいg-vectorを抽出する
            beams.Sort((a, b) => a.Rating.CompareTo(b.Rating));

            if (beams.Count > maxNumOfBloch + 1)
                beams.RemoveRange(maxNumOfBloch + 1, beams.Count - maxNumOfBloch - 1);

            //X,Y座標が同じものを削除
            for (int i = 0; i < beams.Count; i++)
            {
                var bi = beams[i];
                for (int j = i + 1; j < beams.Count; j++)
                {
                    var bj = beams[j];
                    if (Math.Abs(bi.Vec.X - bj.Vec.X) < 1E-6 && Math.Abs(bi.Vec.Y - bj.Vec.Y) < 1E-6)
                    {
                        if (Math.Abs(bi.S) > Math.Abs(bj.S))
                        {
                            beams.RemoveAt(i--);//iの方を除去
                            break;
                        }
                        else
                            beams.RemoveAt(j--);
                    }
                }
            }

            int n = beams.Count - 1;
            for (int i = beams.Count - 1; i >= 1; i--)
                if (Math.Abs(beams[i].Rating - beams[i - 1].Rating) > 1E-6)
                {
                    n = i;
                    break;
                }
            beams.RemoveRange(n, beams.Count - n);

            return beams.ToArray();
        }

        #endregion

        #region 絞りの内部にあるビームのみ選び取る (HRTEM シミュレータから呼ばれる)
        public static Beam[] ExtractInsideBeams(Beam[] beams, double acc, double radius, double shiftX, double shiftY)
        {
            if (double.IsInfinity(radius))
                return beams.ToArray();
            else
            {
                var rambda = UniversalConstants.Convert.EnergyToElectronWaveLength(acc);
                var center = new PointD(2 * Math.Sin(shiftX / 2) / rambda, 2 * Math.Sin(shiftY / 2) / rambda);
                var r = 2 * Math.Sin(radius / 2) / rambda;
                return beams.Where(b => (b.Vec.ToPointD- center).Length2 < r * r).ToArray();
            }
        }
        #endregion

        #region P, Q のリセットやゲット

        /// <summary>
        /// 引数のBeamsとrotationをもとに、PとQだけセットして返す。ほかのパラメータは放置. CBEDの時にみ呼ばれる。
        /// </summary>
        /// <param name="baseRotation"></param>
        /// <param name="k0"></param>
        /// <returns></returns>
        private Beam[] reset_gVectors(Beam[] beams, Matrix3D baseRotation, Vector3DBase vecK0)
        {
            var mat = baseRotation * Crystal.MatrixInverse.Transpose();
            var newBeams = new List<Beam>();
            for (int i = 0; i < beams.Length; i++)
            {
                var g = mat * beams[i].Index;
                var prms = getQP(g, vecK0);
                newBeams.Add(new Beam(prms));
            }
            return newBeams.ToArray();
        }

        private static double getQ(in Vector3DBase g, in Vector3DBase vecK0) => vecK0.Length2 - (vecK0 + g).Length2;

        private double getP(in Vector3DBase g, in Vector3DBase vecK0) => 2 * Surface * (vecK0 + g);

        private (double Q, double P) getQP(in Vector3DBase g, in Vector3DBase vecK0) => (getQ(g,vecK0), getP(g,vecK0));

        private (double Q, double P) getQP(in Vector3DBase g, double kvac, double u0, Matrix3D beamRotation = null)  => getQP(g, getVecK0(kvac, u0, beamRotation));

        #endregion

        #region K0ベクトルを求める
        /// <summary>
        /// K0ベクトルを求める。K0ベクトルは、XY方向を保存したままZ方向のみ変化する。
        /// </summary>
        /// <param name="beamRotation"></param>
        /// <param name="kvac"></param>
        /// <param name="u0"></param>
        /// <returns></returns>
        private Vector3DBase getVecK0(double kvac, double u0, Matrix3D beamRotation = null)
        {
            // |k0|^2 - |kvac|^2 = u0
            // vecK0 = vecKvac + x * vecSurface
            //   =>   x^2 + 2 vecSurface * vecKvac - u0 = 0
            // を満たすxを求めれば良い。
            var vecKvac = (beamRotation == null) ? new Vector3DBase(0, 0, -kvac) : beamRotation * new Vector3DBase(0, 0, -kvac);
            var b = Surface * vecKvac;
            var x = Math.Sqrt(b * b + u0) - b;
            return vecKvac + x * Surface;
        }

        #endregion

        #region Beamクラス

        public class Beam
        {
            /// <summary>
            /// 指数
            /// </summary>
            public int H => Index.H;
            public int K => Index.K;
            public int L => Index.L;

            /// <summary>
            /// 指数
            /// </summary>
            public (int H, int K, int L) Index;

            /// <summary>
            /// 逆格子ベクトル
            /// </summary>
            public Vector3DBase Vec;

            /// <summary>
            /// 励起誤差
            /// </summary>
            public double S => Math.Sqrt(P * P / 4 + Q) - P / 2;

            public Complex Freal;

            public Complex Fimag;

            /// <summary>
            /// k0^2 - (k0 + g)^2 = - g (2 k0 +g) (2 k0 S 励起誤差とわずかに定義が違う)
            /// </summary>
            public double Q;

            /// <summary>
            /// 2 n (k0 + g) 大塚さんの資料参考
            /// </summary>
            public double P;

            /// <summary>
            /// 振幅
            /// </summary>
            public Complex Psi;

            /// <summary>
            /// 強度を保存する(PED計算の時のみ使用)
            /// </summary>
            public double intensity = 0;


            /// <summary>
            /// レンズ関数 
            /// 球面収差関数 × 時間的インコヒーレンス包絡関数 × 空間的インコヒーレンス包絡関数 
            /// </summary>
            public Complex Lenz = new(1, 0);

            /// <summary>
            /// 評価値
            /// </summary>
            public double Rating=> Math.Sqrt(Vec.Length2) * Q * Q;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="hkl">指数</param>
            /// <param name="vec">逆格子ベクトル</param>
            /// <param name="s">励起誤差</param>
            public Beam(in (int H, int K, int L) index, Vector3DBase vec, in (Complex Real, Complex Imag) f, in (double Q, double P) prms)
            {
                Index = index;
                Vec = vec;
                Freal = f.Real;
                Fimag = f.Imag;
                Q = prms.Q;
                P = prms.P;
            }

            public Beam(double q, double p)
            {
                Q = q;
                P = p;
            }
            public Beam((double Q, double P) prms) : this(prms.Q, prms.P) { }

            public Vector3D ConvertToVector3D()
            {
                var g = new Vector3D(Vec.X, Vec.Y, Vec.Z);
                g.d = 1 / g.Length;
                g.Text = $"{H} {K} {L}";
                g.Index = (H, K, L);
                g.F = Psi;
                g.RawIntensity = Psi.MagnitudeSquared();
                g.Tag = S;
                g.Flag = true;
                g.Argb = Color.White.ToArgb();
                return g;
            }
        }

        #endregion

        #region CBED_Diskクラス
        public class CBED_Disk
        {
            /// <summary>
            /// 指数
            /// </summary>
            public readonly int H, K, L;

            /// <summary>
            /// 厚み
            /// </summary>
            public readonly double Thickness;

            public readonly Vector3DBase G;

            /// <summary>
            /// 振幅を格納した配列
            /// </summary>
            public Complex[] Amplitudes;

            public readonly Complex[] RawAmplitudes;

            public CBED_Disk(int[] hkl, Vector3DBase vec, double thickness, Complex[] amplitudes)
            {
                H = hkl[0];
                K = hkl[1];
                L = hkl[2];
                G = vec;
                Thickness = thickness;
                //Amplitudes = amplitudes;
                RawAmplitudes = amplitudes;
            }
        } 
        #endregion

    }
}