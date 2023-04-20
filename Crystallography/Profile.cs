using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Crystallography;

[Serializable]
public class Profile : ICloneable
{
    #region �v���p�e�B�A�t�B�[���h
    public string text;

    public List<PointD> Pt;
    public List<PointD> Err;

    public Color Color = Color.Blue;

    public float LineWidth = 1f;

    public RectangleD Range => new RectangleD(new PointD(Pt.Min(p => p.X), Pt.Min(p => p.Y)), new PointD(Pt.Max(p => p.X), Pt.Max(p => p.Y)));
    public double MaxX => Pt.Max(p => p.X);
    public double MinX => Pt.Min(p => p.X);
    public double MaxY => Pt.Max(p => p.Y);
    public double MinY => Pt.Min(p => p.Y);

    #endregion

    #region �R���X�g���N�^
    public Profile()
    {
        Pt = new List<PointD>();
        Err = new List<PointD>();
    }

    public Profile(IEnumerable<PointD> pt) : this()
    {
        Pt.AddRange(pt);
    }

    public Profile(Color color) : this()
    {
        Color = color;
    }

    public Profile(IEnumerable<PointD> pt, Color color) : this()
    {
        Pt.AddRange(pt);
        Color = color;
    }
    #endregion

    #region �N���A�A�\�[�g�A�R�s�[
    public void Clear()
    {
        Pt = new List<PointD>();
        Err = new List<PointD>();
    }

    public void Sort()
    {
        Pt.Sort();
        Err.Sort();
    }
    public object Clone()
    {
        Profile p = (Profile)this.MemberwiseClone();
        p.Pt = new List<PointD>(Pt.ToArray());
        return p;
    }
    public Profile CopyTo()
    {
        Profile p = new Profile();

        p.Pt = new List<PointD>();
        p.Err = new List<PointD>();
        for (int i = 0; i < Pt.Count; i++)
            p.Pt.Add(Pt[i]);

        for (int i = 0; i < Err.Count; i++)
            p.Err.Add(Err[i]);

        p.text = text;
        return p;
    }
    #endregion

    #region �e�탁�\�b�h

    public override string ToString() => text == null ? "" : text.ToString();

    #region GetErr �w�肳�ꂽx�̒l�ɑ΂���err��Ԃ�
    /// <summary>
    /// �w�肳�ꂽx�̒l�ɑ΂���err��Ԃ�
    /// </summary>
    /// <param name="x"></param>
    /// <param name="pointNum"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    public double GetErr(double x)
    {
        if (Err.Count != Pt.Count)
            return 0;

        //�܂��_�̈ʒu��T��
        if (Err[0].X > x)
            return Err[0].Y;
        else if (Err[^1].X < x)
            return Err[^1].Y;
        else
        {
            for (int i = 0; i < Err.Count - 1; i++)
                if (Err[i].X == x)
                    return Err[i].Y;
                else if (Err[i].X <= x && x <= Err[i + 1].X)
                    return (Err[i].Y + Err[i + 1].Y) / 2;
        }
        return 0;
    }
    #endregion

    #region  GetValue �w�肳�ꂽx�̒l�ɑ΂���order���֐��ŕ�Ԃ����l��Ԃ�
    /// <summary>
    /// �w�肳�ꂽx�̒l�ɑ΂���order���֐��ŕ�Ԃ����l��Ԃ�
    /// </summary>
    /// <param name="x"></param>
    /// <param name="pointNum"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    public double GetValue(double x, int pointNum, int order, bool eachside = false)
    {
        if (pointNum == 2 && order == 1)//�T������_����2, �I�[�_�[��1�̎��́A�������̂��߈ȉ��̃��[�`����
        {
            int pos = 0;//���̒l�ƁA���̒l+1�̊Ԃ�index��x�����݂���
            if (x > Pt[Pt.Count * 3 / 4].X)
                pos = Pt.Count * 3 / 4;
            else if (x > Pt[Pt.Count / 2].X)
                pos = Pt.Count / 2;
            else if (x > Pt[Pt.Count / 4].X)
                pos = Pt.Count / 4;

            if (x <= Pt[0].X)
                return (Pt[0].Y - Pt[1].Y) / (Pt[0].X - Pt[1].X) * (x - Pt[1].X) + Pt[1].Y;
            else if (Pt[^1].X < x)
                return (Pt[^2].Y - Pt[^1].Y) / (Pt[^2].X - Pt[^1].X) * (x - Pt[^1].X) + Pt[^1].Y;
            else
                for (; pos < Pt.Count - 1; pos++)
                {
                    if (Pt[pos].X < x && x < Pt[pos + 1].X)
                        return (Pt[pos].Y - Pt[pos + 1].Y) / (Pt[pos].X - Pt[pos + 1].X) * (x - Pt[pos + 1].X) + Pt[pos + 1].Y;
                    else if (Pt[pos + 1].X == x)
                        return Pt[pos + 1].Y;
                }
            return (Pt[pos].Y - Pt[pos + 1].Y) / (Pt[pos].X - Pt[pos + 1].X) * (x - Pt[pos + 1].X) + Pt[pos + 1].Y;
        }

        return GetValues(new double[] { x }, pointNum, order, eachside, false)[0];
    }
    #endregion

    #region GetValues�@�w�肳�ꂽx�̒l�ɑ΂���order���֐��ŕ�Ԃ����l��Ԃ�
    /// <summary>
    /// �w�肳�ꂽx�̒l�ɑ΂���order���֐��ŕ�Ԃ����l��Ԃ�
    /// </summary>
    /// <param name="x"></param>
    /// <param name="pointNum">�T������_��</param>
    /// <param name="order">�t�B�b�e�B���O���鎟��</param>
    /// <param name="eachside">���T�C�h�łȂ�ׂ��ϓ��ȓ_�����̗p</param>
    /// <param name="shareSameFunction"></param>
    /// <returns></returns>
    public double[] GetValues(double[] x, int pointNum, int order, bool eachside = false, bool shareSameFunction = false)
    {
        if (pointNum < 2) pointNum = 2;
        if (order > pointNum - 1) order = pointNum - 1;
        double[] value = new double[x.Length];

        /*   var srcPts = new List<List<PointD>>(); //X�ɓ����l���܂܂�Ă���ꍇ(�z���[�̂悤�ȕs�A���ȃv���t�@�C��)���l�����āA�������Ă���
           for (int i=0; i< Pt.Count; i++)
           {
               var temp = new List<PointD>();
               for (int j = i; j < Pt.Count; j++)
                   if (j == 0 || Pt[j - 1].X != Pt[j].X)
                       temp.Add(Pt[j]);
                   else
                       break;
           }
           */

        for (int n = 0; n < x.Length; n++)
        {
            bool flag = true;
            //�܂��_�̈ʒu��T��
            int position = 0;//���̒l�� ���̒l+1�̊Ԃ�index��x�����݂���
            if (Pt[0].X > x[n])
                position = -1;
            else if (Pt[^1].X < x[n])
                position = Pt.Count - 1;
            else
                for (int i = 0; i < Pt.Count - 1; i++)
                    if (Pt[i + 1].X == x[n])
                    {
                        value[n] = Pt[i + 1].Y;
                        flag = false;
                        break;
                    }
                    else if (Pt[i].X <= x[n] && x[n] <= Pt[i + 1].X)
                    {
                        position = i;
                        break;
                    }
            if (flag)
            {
                //���ɁA���̓_����O���PointNum�����߂��_��T��
                var pt = new List<PointD>();

                if (eachside)//�����łȂ�ׂ��ϓ��ȓ_�����ق����Ƃ�
                {
                    int i = 1;
                    while (pt.Count < pointNum)
                    {
                        if (position - i + 1 >= 0)
                            pt.Add(Pt[position - i + 1]);
                        if (position + i < Pt.Count)
                            pt.Add(Pt[position + i]);
                        i++;
                    }
                }
                else//�Ƃɂ����߂��_��������Ƃ�
                {
                    for (int i = Math.Max(position - pointNum, 0); i < Math.Min(position + pointNum + 1, Pt.Count); i++)
                        pt.Add(Pt[i]);
                    while (pt.Count > pointNum)
                        pt.RemoveAt(Math.Abs(pt[0].X - x[n]) > Math.Abs(pt[^1].X - x[n]) ? 0 : pt.Count - 1);
                }

                if (pt.Count < pointNum)
                {
                    pointNum = pt.Count;
                    if (order > pointNum - 1)
                        order = pointNum - 1;
                }

                //�v�Z���x�̂��߁Ax�͈̔͂�1����+2�ɕϊ����� ���� X = c1 x + c2;
                double c1 = 1.0 / (pt[^1].X - pt[0].X);
                double c2 = 1 - pt[0].X * c1;

                var m = new DenseMatrix(pointNum, order + 1);
                var y = new DenseMatrix(pointNum, 1);
                for (int j = 0; j < pointNum; j++)
                {
                    y[j, 0] = pt[j].Y;
                    for (int i = 0; i < order + 1; i++)
                        m[j, i] = Math.Pow(c1 * pt[j].X + c2, i);
                }

                var a = (m.TransposeThisAndMultiply(m)).Inverse() * m.TransposeThisAndMultiply(y);
                if (a == null || a.ColumnCount == 0)
                    value[n] = pt[position >= 0 ? position : 0].Y;
                else
                {
                    if (shareSameFunction)
                    {
                        for (int i = 0; i < value.Length; i++)
                            for (int j = 0; j < order + 1; j++)
                                value[i] += a[j, 0] * Math.Pow(c1 * x[i] + c2, j);
                        return value;
                    }
                    value[n] = 0;
                    for (int j = 0; j < order + 1; j++)
                        value[n] += a[j, 0] * Math.Pow(c1 * x[n] + c2, j);
                }
            }
        }
        return value;
    }
    #endregion

    #region SmoothingSavitzkyGolay():  Savitzky and Golay Smoothing�̌��ʂ�Ԃ�
    /// <summary>
    /// Savitzky and Golay Smoothing�̌��ʂ�Ԃ�
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public Profile SmoothingSavitzkyGolay(int m, int n)
    {
        Profile p = Smoothing.SavitzkyGolay(this, m, n);
        p.Color = this.Color;
        p.text = this.text;
        return p;
    }
    #endregion

    #region Differential: n�K�����̌��ʂ�������
    /// <summary>
    /// n�K�����̌��ʂ�������
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public Profile Differential(int n)
    {
        Profile p = new Profile();
        p.Color = this.Color;
        p.text = this.text;
        if (n < 1)
            return p;
        else
        {
            for (int i = 0; i < Pt.Count - 1; i++)
            {
                if (double.IsInfinity((Pt[i + 1].Y - Pt[i].Y) / (Pt[i + 1].X - Pt[i].X)) || double.IsNaN((Pt[i + 1].Y - Pt[i].Y) / (Pt[i + 1].X - Pt[i].X)))
                    p.Pt.Add(new PointD((Pt[i].X + Pt[i + 1].X) / 2.0, 0));
                else
                    p.Pt.Add(new PointD((Pt[i].X + Pt[i + 1].X) / 2.0, (Pt[i + 1].Y - Pt[i].Y) / (Pt[i + 1].X - Pt[i].X)));
            }
            if (n == 1)
                return p;
            else
                return p.Differential(n - 1);
        }
    }
    #endregion

    public PointD[][] GetPointsWithinRectangle(RectangleD rect) => Geometriy.GetPointsWithinRectangle(this.Pt, rect);

    #region ToGSAS: GSAS�`���ɕϊ�����
    /// <summary>
    /// GSAS�`���ɕϊ�
    /// </summary>
    /// <param name="name"></param>
    /// <param name="profile"></param>
    /// <param name="axis"></param>
    /// <returns></returns>
    public static string[] ToGSAS(string name, Profile profile, HorizontalAxis axis)
    {
        var sb = new List<string>();
        double div = axis == HorizontalAxis.NeutronTOF ? 1 : 100;

        //��s��
        sb.Add(name);

        //��s��
        var ptCount = profile.Pt.Count;
        var startAngle = profile.Pt[0].X * div;
        var stepAngle = (profile.Pt[1].X - profile.Pt[0].X) * div;
        sb.Add($"BANK 1 {ptCount} {ptCount} CONST {startAngle:f2} {stepAngle:f2} 0 0 FXYE");

        //err���L���ȃf�[�^���ǂ����𔻒�
        bool validErr = true;
        if (profile.Err != null && profile.Err.Count == profile.Pt.Count)
        {
            for (int i = 0; i < ptCount; i++)
                if (profile.Err[i].IsNaN)
                    validErr = false;
        }
        else
            validErr = false;

        for (int i = 0; i < ptCount; i++)
        {
            var value = new string[3];
            value[0] = (profile.Pt[i].X * div).ToString("g12");
            value[1] = profile.Pt[i].Y.ToString("g12");
            if (validErr)
                value[2] = profile.Err[i].Y.ToString("g12");
            else
                value[2] = Math.Sqrt(profile.Pt[i].Y).ToString("g12");

            var y = profile.Pt[i].Y.ToString("g7");

            for (int j = 0; j < value.Length; j++)
            {
                if (value[j].Length > 11)
                    value[j] = value[j][..11];
                if (value[j].EndsWith("."))
                    value[j] = " " + y[..10];
                while (value[j].Length < 11)
                    value[j] = " " + value[j];
            }
            sb.Add($" {value[0]} {value[1]} {value[2]}");
        }

        return sb.ToArray();
    }
    #endregion

    #endregion
}

#region �e���
/// <summary>
/// �����̎�� (Angle, d, WaveNumber, Length, EnergyXray, EnergyElectron, EnergyNeutron, NeutronTOF, none)
/// </summary>
[Serializable]
public enum HorizontalAxis{    Angle, d, WaveNumber, Length, EnergyXray, EnergyElectron, EnergyNeutron, NeutronTOF, None}

/// <summary>
/// �g�̎�� (Xray, Electron, Neutron, None)
/// </summary>
[Serializable]
public enum WaveSource{    Xray, Electron, Neutron, None}

/// <summary>
/// �g�̐F (Monochrome, FlatWhite, CustomWhite, None)
/// </summary>
[Serializable]
public enum WaveColor{    Monochrome, FlatWhite, CustomWhite, None}

/// <summary>
/// �v���t�@�C�����[�h (Concentric, Radial)
/// </summary>
[Serializable]
public enum DiffractionProfileMode{    Concentric, Radial}

/// <summary>
/// �o�b�N�O�����h���[�h (BSplineCurve, ReferrenceProfile)
/// </summary>
[Serializable]
public enum BackgroundMode{    BSplineCurve, ReferrenceProfile}

#endregion

[Serializable]
public class DiffractionProfile : ICloneable
{
    #region �}�X�N�֘A��������
    [Serializable]
    public class MaskingRange
    {
        public double[] X = new double[2];

        public MaskingRange() => X[0] = X[1] = 0;

        public MaskingRange(double x1, double x2)
        {
            X[0] = x1;
            X[1] = x2;
        }

        public double Maximum => Math.Max(X[0], X[1]);

        public double Minimum => Math.Min(X[0], X[1]);

        public override string ToString()
            => X[0] < X[1] ? $"{X[0]:g8} - {X[1]:g8}" : $"{X[1]:g8} - {X[0]:g8}";
    }

    public List<MaskingRange> maskingRanges = new List<MaskingRange>();

    public bool SortMaskRanges()
    {
        bool flag = false;
        for (int i = 0; i < maskingRanges.Count - 1; i++)
            if (Math.Max(maskingRanges[i].X[0], maskingRanges[i].X[1]) > Math.Min(maskingRanges[i + 1].X[0], maskingRanges[i + 1].X[1]))
                flag = true;

        if (flag)
        {
            List<double> temp = new List<double>();
            for (int i = 0; i < maskingRanges.Count; i++)
            {
                temp.Add(maskingRanges[i].X[0]);
                temp.Add(maskingRanges[i].X[1]);
            }
            temp.Sort();
            for (int i = 0; i < maskingRanges.Count; i++)
            {
                if (maskingRanges[i].X[0] != temp[i * 2]) maskingRanges[i].X[0] = temp[i * 2];
                if (maskingRanges[i].X[1] != temp[i * 2 + 1]) maskingRanges[i].X[1] = temp[i * 2 + 1];
            }
        }
        return flag;
    }

    public void SetMaskRange(int[] index, double x)
    {
        if (index != null && index.Length == 2 && index[0] >= 0 && index[0] < maskingRanges.Count && index[1] >= 0 && index[1] < 2)
            maskingRanges[index[0]].X[index[1]] = x;
    }

    public void DeleteMaskRange(int index)
    {
        if (maskingRanges.Count < index)
            maskingRanges.RemoveAt(index);
    }

    private int interpolationOrder = 2;

    public int InterpolationOrder
    {
        set
        {
            if (value > 0)
            {
                interpolationOrder = value;
            }
        }
        get => interpolationOrder;
    }

    private int interpolationPoints = 20;

    public int InterpolationPoints
    {
        set
        {
            if (value > 0)
            {
                interpolationPoints = value;
            }
        }
        get => interpolationPoints;
    }

    public bool DoesMaskAndInterpolate = false;
    #endregion

    public object Clone()
    {
        var dp = (DiffractionProfile)this.MemberwiseClone();
        dp.SourceProfile = (Profile)this.SourceProfile.Clone();
        dp.Profile = (Profile)this.Profile.Clone();
        dp.InterpolatedProfile = (Profile)this.InterpolatedProfile.Clone();
        dp.SmoothedProfile = (Profile)this.SmoothedProfile.Clone();
        dp.Kalpha2RemovedProfile = (Profile)this.Kalpha2RemovedProfile.Clone();
        dp.ConvertedProfile = (Profile)this.ConvertedProfile.Clone();
        dp.BackgroundProfile = (Profile)this.BackgroundProfile.Clone();
        return dp;
    }

    #region �v���p�e�B

    #region �v���t�@�C��
    /// <summary>
    /// �\�[�X�v���t�@�C�� ()
    /// </summary>
    public Profile SourceProfile;

    public PointD[] BgPoints;

    /// <summary>
    /// ���ϊ���̃v���t�@�C��. SetConvertedProfile()���Ăяo�����ƂŐ��������.
    /// </summary>
    [XmlIgnore]
    public Profile ConvertedProfile;

    /// <summary>
    /// �⊮���ꂽ�v���t�@�C��. ConvertedProfile�̌�ɐ��������B
    /// </summary>
    [XmlIgnore]
    public Profile InterpolatedProfile;

    /// <summary>
    /// �X���[�W���O���ꂽ�v���t�@�C��. InterpolatedProfile�̌�ɐ��������.
    /// </summary>
    [XmlIgnore]
    public Profile SmoothedProfile;

    /// <summary>
    /// Kalpha2���������ꂽ�v���t�@�C��. SmoothedProfile�̌�ɐ��������.
    /// </summary>
    [XmlIgnore]
    public Profile Kalpha2RemovedProfile;

    /// <summary>
    /// �o�b�N�O�����h�v���t�@�C��. Kalpha2RemovedProfile�̌�ɐ��������.
    /// </summary>
    [XmlIgnore]
    public Profile BackgroundProfile;

    /// <summary>
    /// �ŏI�v���t�@�C��. Kalpha2RemovedProfile�̌�ɐ��������.
    /// </summary>
    [XmlIgnore]
    public Profile Profile;
    #endregion

    /// <summary>
    /// �v���t�@�C�����[�h
    /// </summary>
    public DiffractionProfileMode Mode = DiffractionProfileMode.Concentric;

    #region �\�[�X�v���t�@�C���Ɋւ���v���p�e�B

    /// <summary>
    /// �\�[�X�v���t�@�C���̉����̎��
    /// </summary>
    public HorizontalAxis SrcAxisMode;
    /// <summary>
    /// �\�[�X�̓��˔g�̎��
    /// </summary>
    public WaveSource SrcWaveSource;
    /// <summary>
    /// �\�[�X�v���t�@�C���̓��˔g�̐F
    /// </summary>
    public WaveColor SrcWaveColor;
    /// <summary>
    /// �\�[�X�v���t�@�C�������m�N���̎��̓��˔g�̔g�� (nm�P��)
    /// </summary>
    public double SrcWaveLength;

    /// <summary>
    /// �\�[�X�v���t�@�C��������X���̎��̃^�[�Q�b�g���q�ԍ� (0�̓J�X�^��)
    /// </summary>
    public int SrcXrayElementNumber;
    /// <summary>
    /// �\�[�X�v���t�@�C��������X���̎��̃��C��
    /// </summary>
    public XrayLine SrcXrayLine;

    /// <summary>
    /// �\�[�X�v���t�@�C����2�Ƃ̎��̒P��
    /// </summary>
    public AngleUnit SrcTwoThetaUnit = AngleUnit.Degree;
    /// <summary>
    /// �\�[�X�v���t�@�C����D�l�̎��̒P��
    /// </summary>
    public LengthUnitEnum SrcDspacingUnit = LengthUnitEnum.Angstrom;
    /// <summary>
    /// �\�[�X�v���t�@�C�����g��(2��/d) �̎��̒P��
    /// </summary>
    public LengthUnitEnum SrcWaveNumberUnit = LengthUnitEnum.AngstromInverse;

    /// <summary>
    /// �\�[�X�v���t�@�C�����d�q���̏ꍇ�̉����d��
    /// </summary>
    public double SrcElectronAccVolatage;

    /// <summary>
    /// �\�[�X�v���t�@�C�������F�̎��̃G�l���M�[�̒P��
    /// </summary>
    public EnergyUnitEnum SrcEnergyUnit = EnergyUnitEnum.eV;
    /// <summary>
    /// �\�[�X�v���t�@�C�������F�̎��� Takeoff angle (radian)
    /// </summary>
    public double SrcEnergyTakeoffAngle;

    /// <summary>
    /// �\�[�X�v���t�@�C�������FTOF���̊p�x
    /// </summary>
    public double SrcTofAngle;
    /// <summary>
    /// �\�[�X�v���t�@�C�������FTOF���̌��o�틗��
    /// </summary>
    public double SrcTofLength;
    /// <summary>
    /// �\�[�X�v���t�@�C�������FTOF���� ���ԒP��
    /// </summary>
    public TimeUnitEnum SrcTofTimeUnit = TimeUnitEnum.MicroSecond;

    #endregion

    #region �ŏI�v���t�@�C���̃v���p�e�B
    /// <summary>
    /// �ŏI�v���t�@�C���̉����̎��
    /// </summary>
    public HorizontalAxis DstAxisMode;
    /// <summary>
    /// �ŏI�v���t�@�C���̓��˔g�̎��
    /// </summary>
    public WaveSource DstWaveSource;
    /// <summary>
    /// �ŏI�v���t�@�C���̓��˔g�̐F
    /// </summary>
    public WaveColor DstWaveColor;
    /// <summary>
    /// �ŏI�v���t�@�C�������m�N���̎��̓��˔g�̔g�� (nm�P��)
    /// </summary>
    public double DstWaveLength;

    /// <summary>
    /// �ŏI�v���t�@�C��������X���̎��̃^�[�Q�b�g���q�ԍ� (0�̓J�X�^��)
    /// </summary>
    public int DstXrayElementNumber;
    /// <summary>
    /// �ŏI�v���t�@�C��������X���̎��̃��C��
    /// </summary>
    public XrayLine DstXrayLine;

    /// <summary>
    /// �ŏI�v���t�@�C����2�Ƃ̎��̒P��
    /// </summary>
    public AngleUnit DstTwoThetaUnit = AngleUnit.Degree;
    /// <summary>
    /// �ŏI�v���t�@�C����D�l�̎��̒P��
    /// </summary>
    public LengthUnitEnum DstDspacingUnit = LengthUnitEnum.Angstrom;
    /// <summary>
    /// �ŏI�v���t�@�C�����g��(2��/d) �̎��̒P��
    /// </summary>
    public LengthUnitEnum DstWaveNumberUnit = LengthUnitEnum.AngstromInverse;

    /// <summary>
    /// �ŏI�v���t�@�C�����d�q���̏ꍇ�̉����d��
    /// </summary>
    public double DstElectronAccVolatage;

    /// <summary>
    /// �ŏI�v���t�@�C�������F�̎��̃G�l���M�[�̒P��
    /// </summary>
    public EnergyUnitEnum DstEnergyUnit = EnergyUnitEnum.eV;
    /// <summary>
    /// �ŏI�v���t�@�C�������F�̎��� Takeoff angle (radian)
    /// </summary>
    public double DstEnergyTakeoffAngle;
    /// <summary>
    /// �ŏI�v���t�@�C�������FTOF���̊p�x
    /// </summary>
    public double DstTofAngle;
    /// <summary>
    /// �ŏI�v���t�@�C�������FTOF���̌��o�틗��
    /// </summary>
    public double DstTofLength;
    /// <summary>
    /// �ŏI�v���t�@�C�������FTOF���� ���ԒP��
    /// </summary>
    public TimeUnitEnum DstTofTimeUnit = TimeUnitEnum.MicroSecond;

    #endregion

    #region �m�[�}���C�Y�֘A
    /// <summary>
    /// ���x�̃m�[�}���C�Y�����邩�ǂ���
    /// </summary>
    public bool DoesNormarizeIntensity = false;

    /// <summary>
    /// �c���ɂ�����W��
    /// </summary>
    public double NormarizeRangeStart = 0;

    public double NormarizeRangeEnd = 180;
    public bool NormarizeAsAverage = true;
    public double NormarizeIntensity = 1000;
    #endregion

    #region �X���[�W���O�֘A
    public bool DoesSmoothing = false;

    public int SazitkyGorayM = 3, SazitkyGorayN = 3;
    #endregion

    #region 2�ƃV�t�g
    public bool DoesTwoThetaOffset = false;

    public double TwoThetaOffsetCoeff0 = 0, TwoThetaOffsetCoeff1 = 0, TwoThetaOffsetCoeff2 = 0;
    #endregion

    #region Kalpha2����
    //Kalpha2������������
    public bool DoesRemoveKalpha2 = false;

    public double Kalpha1 = 0, Kalpha2 = 0;
    #endregion

    #region �V�t�g
    //shift�֘A
    public bool IsShiftX = false;

    public double ShiftX = 0;
    #endregion

    #region FFT
    //FFT�֘A
    public bool DoesBandpassFilter = false;

    public bool DoesLowPath = false, DoesHighPath = false;
    public double LowPathLimit = double.NaN, HighPathLimit = double.NaN;
    #endregion

    /// <summary>
    /// count per second ���[�h���ǂ���
    /// </summary>
    public bool IsCPS = true;

    /// <summary>
    /// �I�o����
    /// </summary>
    public double ExposureTime = 1;

    /// <summary>
    /// �c�������O�X�P�[���ɂ��邩�ǂ���
    /// </summary>
    public bool IsLogIntensity = false;

    //�`����̐ݒ�
    public float LineWidth = 1f;

    public int? ColorARGB;

    #region /�o�b�N�O�����h�ݒ�֘A
    public int BgPointsNumber = 15;

    public bool SubtractBackground = false;
    public BackgroundMode BgMode = BackgroundMode.BSplineCurve;
    public Profile BackgroundReferrenceProfile = null;
    public double BackgroundReferrenceScale = 1;
    #endregion

    public string Name;

    public string Comment { get; set; }

    public bool IsLPOmain = false;
    public bool IsLPOchild = false;

    #region �C���[�W�֘A
    public double[] ImageArray = null;
    public double ImageScale = 0;
    public int ImageWidth = 0, ImageHeight = 0;
    #endregion

    public override string ToString() => Name;

    #endregion

    #region �R���X�g���N�^
    public DiffractionProfile()
    {
        BgPoints = Array.Empty<PointD>();

        SourceProfile = new Profile();
        ConvertedProfile = new Profile();
        SmoothedProfile = new Profile();
        Kalpha2RemovedProfile = new Profile();
        InterpolatedProfile = new Profile();
        Profile = new Profile();
        BackgroundProfile = new Profile();
        SrcAxisMode = HorizontalAxis.Angle;

        SrcWaveSource = WaveSource.Xray;

        SrcXrayElementNumber = 0;
        SrcXrayLine = XrayLine.Ka1;

        SrcElectronAccVolatage = 200;

        ColorARGB = null;
    }
    #endregion

    public void CopyParameter(DiffractionProfile defaultDP)
    {
        DoesSmoothing = defaultDP.DoesSmoothing;
        SazitkyGorayM = defaultDP.SazitkyGorayM;
        SazitkyGorayN = defaultDP.SazitkyGorayN;
        SubtractBackground = defaultDP.SubtractBackground;
    }

    #region �o�b�N�O���E���h����_�̒ǉ�/�폜
    /// <summary>
    /// �N���C�A���g���W��pt������A�I���W�i�����W�ɕϊ����Ēǉ�����
    /// </summary>
    /// <param name="pt"></param>
    public void AddBgPoints(PointD pt)
    {
        var profile = new Profile(BgPoints);

        PointD newPt = ConvertDestToSrc(pt);
        if (!double.IsNaN(newPt.X) && !double.IsInfinity(newPt.X))
            profile.Pt.Add(newPt);
        profile.Sort();
        BgPoints = profile.Pt.ToArray();
    }

    public void DeleteBgPoints(int index)
    {
        var profile = new Profile(BgPoints);
        profile.Pt.RemoveAt(index);
        BgPoints = profile.Pt.ToArray();
    }
    #endregion


 

    /// <summary>
    /// ���������͂��̂܂܂ŁA�c���m�[�}���C�Y���{��OriginalProfile����ConvertedProfile�𐶐�����B
    /// </summary>
    public void SetConvertedProfile()
    {
        SetConvertedProfile(SrcAxisMode, SrcWaveLength, SrcEnergyTakeoffAngle, SrcTofAngle, SrcTofLength);
    }

    #region ��A�̕ϊ� SourceProfile => MaskingProfile => SmoothingProfile =>  Kalpha2RemovedProfile => BackgroundProfile & Profile

    /// <summary>
    /// �����ϊ�����яc���m�[�}���C�Y���{��OriginalProfile����ConvertedProfile�𐶐�����B�Ō��SetMaskingProfile()�����s����.
    /// </summary>
    public void SetConvertedProfile(HorizontalAxis destAxisMode, double destWavelength, double destTakeoffAngle, double destTofAngle, double destTofLength)
    {
        DstAxisMode = destAxisMode;
        DstWaveLength = destWavelength;
        DstEnergyTakeoffAngle = destTakeoffAngle;
        DstTofAngle = destTofAngle;
        DstTofLength = destTofLength;

        ConvertedProfile.Clear();

        PointD[] pt = ConvertSrcToDest(SourceProfile.Pt.ToArray());
        PointD[] err = ConvertSrcToDest(SourceProfile.Err.ToArray());

        //��������A2ThetaOffset����
        if (IsShiftX)
        {
            for (int i = 0; i < pt.Length; i++)
                pt[i] = new PointD(pt[i].X + ShiftX, pt[i].Y);
            for (int i = 0; i < err.Length; i++)
                err[i] = new PointD(err[i].X + ShiftX, err[i].Y);
        }

        if (DoesTwoThetaOffset && destAxisMode == HorizontalAxis.Angle)
        {
            for (int i = 0; i < pt.Length; i++)
            {
                var tan = Math.Tan(pt[i].X / 360.0 * Math.PI);
                pt[i] = new PointD(pt[i].X + TwoThetaOffsetCoeff0 + TwoThetaOffsetCoeff1 * tan + TwoThetaOffsetCoeff2 * tan * tan, pt[i].Y);
            }
            for (int i = 0; i < err.Length; i++)
            {
                var tan = Math.Tan(err[i].X / 360.0 * Math.PI);
                err[i] = new PointD(err[i].X + TwoThetaOffsetCoeff0 + TwoThetaOffsetCoeff1 * tan + TwoThetaOffsetCoeff2 * tan * tan, err[i].Y);
            }
        }

        //�����܂�

        ConvertedProfile.Pt.AddRange(pt);
        ConvertedProfile.Err.AddRange(err);

        ConvertedProfile.Sort();//�����܂Ńv���t�@�C���\�[�g������

        SetMaskingProfile();
    }

    /// <summary>
    /// Mask���ꂽ�̈��⊮���AConvertedProfile����InterpolatedProfile���쐬����. �Ō��SetSmoothingProfile()�����s����B
    /// </summary>
    public void SetMaskingProfile()
    {
        InterpolatedProfile.Clear();
        for (int i = 0; i < ConvertedProfile.Pt.Count; i++)
            InterpolatedProfile.Pt.Add(ConvertedProfile.Pt[i]);
        for (int i = 0; i < ConvertedProfile.Err.Count; i++)
            InterpolatedProfile.Err.Add(ConvertedProfile.Err[i]);

        if (DoesMaskAndInterpolate && maskingRanges.Count > 0)
        {
            var x = new List<List<double>>();
            for (int i = 0; i < maskingRanges.Count; i++)
            {
                x.Add(new List<double>());
                for (int j = 0; j < InterpolatedProfile.Pt.Count && InterpolatedProfile.Pt[j].X < maskingRanges[i].Maximum; j++)
                    if (InterpolatedProfile.Pt[j].X > maskingRanges[i].Minimum)
                    {
                        x[i].Add(InterpolatedProfile.Pt[j].X);
                        InterpolatedProfile.Pt.RemoveAt(j);
                        j--;
                    }
            }
            var y = new List<List<double>>();
            for (int i = 0; i < x.Count; i++)
            {
                y.Add(new List<double>());
                y[i].AddRange(InterpolatedProfile.GetValues(x[i].ToArray(), InterpolationPoints * 2, InterpolationOrder, true, true));
            }
            for (int i = 0; i < x.Count; i++)
                for (int j = 0; j < x[i].Count; j++)
                    InterpolatedProfile.Pt.Add(new PointD(x[i][j], y[i][j]));
            InterpolatedProfile.Sort();
        }
        SetSmoothingProfile();
    }

    /// <summary>
    /// �X���[�W���O��FFT���{��InterpolatedProfile����SmoothedProfile���쐬����B�Ō��SetKalpha2RemovedProfile()�����s����B
    /// </summary>
    public void SetSmoothingProfile()
    {
        SmoothedProfile.Clear();
        //�X���[�W���O����
        if (DoesSmoothing)
            SmoothedProfile = Smoothing.SavitzkyGolay(InterpolatedProfile, SazitkyGorayM, SazitkyGorayN);
        else
            for (int i = 0; i < InterpolatedProfile.Pt.Count; i++)
                SmoothedProfile.Pt.Add(InterpolatedProfile.Pt[i]);

        for (int i = 0; i < InterpolatedProfile.Err.Count; i++)
            SmoothedProfile.Err.Add(InterpolatedProfile.Err[i]);

        if (DoesBandpassFilter && SmoothedProfile.Pt.Count > 2)
        {
            Complex[] src = new Complex[SmoothedProfile.Pt.Count];
            for (int i = 0; i < src.Length; i++)
                src[i] = new Complex(SmoothedProfile.Pt[i].Y, 0);

            Complex[] fft = Fourier.FFT(src, FourierDirectionEnum.Forward);
            double center = fft.Length / 2.0;
            double unit = SmoothedProfile.Pt[1].X - SmoothedProfile.Pt[0].X;

            if (DoesHighPath && HighPathLimit > 0)//����̎��g���ȉ����J�b�g����
            {
                double length = HighPathLimit * src.Length * unit;
                for (int i = 1; i < center; i++)
                    if (i < length / 2)
                        fft[i] *= 0;
                    else if (i < length)
                        fft[i] *= (i - length / 2) / (length / 2);
            }

            if (DoesLowPath && LowPathLimit > 0)//����̎��g���ȏ���J�b�g����
            {
                double length = LowPathLimit * src.Length * unit;
                for (int i = 0; i < center; i++)
                    if (i > length * 2)
                        fft[i] *= 0;
                    else if (i > length)
                        fft[i] *= 1 - (i - length) / length;
            }

            for (int i = (int)(center + 1); i < src.Length; i++)
            {
                fft[i] = Complex.Conjugate(fft[src.Length - i]);
            }
            src = Fourier.FFT(fft, FourierDirectionEnum.Inverse);

            for (int i = 1; i < src.Length; i++)
            {
                // SmoothedProfile.Pt[i].Y = src[i].Magnitude;
                SmoothedProfile.Pt[i] = new PointD(SmoothedProfile.Pt[i].X, src[i].Magnitude);
            }
        }
        SetKalpha2RemovedProfile();
    }

    /// <summary>
    /// Kalpha2����������B�Ō��SetBackGroundProfile()�����s����B
    /// </summary>
    public void SetKalpha2RemovedProfile()
    {
        Kalpha2RemovedProfile.Clear();

        for (int i = 0; i < SmoothedProfile.Pt.Count; i++)
            Kalpha2RemovedProfile.Pt.Add(SmoothedProfile.Pt[i]);
        for (int i = 0; i < SmoothedProfile.Err.Count; i++)
            Kalpha2RemovedProfile.Err.Add(SmoothedProfile.Err[i]);

        if (DoesRemoveKalpha2 && SrcWaveSource == WaveSource.Xray && SrcXrayElementNumber != 0 && SrcXrayLine == XrayLine.Ka1)
        {
            double alpha1 = AtomStatic.CharacteristicXrayWavelength(SrcXrayElementNumber, XrayLine.Ka1);
            double alpha2 = AtomStatic.CharacteristicXrayWavelength(SrcXrayElementNumber, XrayLine.Ka2);
            double startY = Kalpha2RemovedProfile.Pt[0].Y * 2 / 3;

            var theta = new List<double>();
            for (int i = 0; i < Kalpha2RemovedProfile.Pt.Count; i++)
            {
                var d = alpha2 * 0.5 / Math.Sin(Kalpha2RemovedProfile.Pt[i].X / 360 * Math.PI);
                theta.Add(Math.Asin(alpha1 * 0.5 / d) * 360 / Math.PI);
            }
            for (int i = 0; i < Kalpha2RemovedProfile.Pt.Count; i++)
            {
                if (theta[i] < Kalpha2RemovedProfile.Pt[0].X)
                    //Kalpha2RemovedProfile.Pt[i].Y -= startY * 0.5;
                    Kalpha2RemovedProfile.Pt[i] = new PointD(Kalpha2RemovedProfile.Pt[i].X, Kalpha2RemovedProfile.Pt[i].Y - startY * 0.5);
                else
                    //    Kalpha2RemovedProfile.Pt[i].Y -= Kalpha2RemovedProfile.GetValue(theta[i], 2, 1) * 0.5;
                    Kalpha2RemovedProfile.Pt[i] = new PointD(Kalpha2RemovedProfile.Pt[i].X, Kalpha2RemovedProfile.Pt[i].Y - Kalpha2RemovedProfile.GetValue(theta[i], 2, 1) * 0.5);
            }
        }

        SetBackGroundProfile();
    }

    /// <summary>
    /// �o�b�N�O���E���h�������{��SmoothedProfile����BackGroundProfile�����Profile���쐬����B
    /// </summary>
    public void SetBackGroundProfile()
    {
        Profile.Clear();
        for (int i = 0; i < Kalpha2RemovedProfile.Pt.Count; i++)
            Profile.Pt.Add(Kalpha2RemovedProfile.Pt[i]);
        for (int i = 0; i < Kalpha2RemovedProfile.Err.Count; i++)
            Profile.Err.Add(Kalpha2RemovedProfile.Err[i]);

        //�K�v�ł���΁A�m�[�}���C�Y����
        Normarize();

        //�o�b�N�O���E���h����
        if (BackgroundProfile.Pt == null || BackgroundProfile.Pt.Count != Profile.Pt.Count)
        {
            BackgroundProfile.Pt = new List<PointD>();
            for (int i = 0; i < Profile.Pt.Count; i++)
                BackgroundProfile.Pt.Add(new PointD(Profile.Pt[i].X, 0));
        }
        if (SubtractBackground)
        {
            if (BgMode == BackgroundMode.BSplineCurve && BgPoints != null)
            {
                BackgroundProfile = Spline.GetSpline(ConvertSrcToDest(BgPoints), ConvertedProfile);
                for (int i = 0; i < Profile.Pt.Count; i++)
                    Profile.Pt[i] = new PointD(Profile.Pt[i].X, Profile.Pt[i].Y - BackgroundProfile.Pt[i].Y);
            }
            else if (BgMode == BackgroundMode.ReferrenceProfile && BackgroundReferrenceProfile != null)
            {
                for (int i = 0; i < Profile.Pt.Count; i++)
                {
                    double x = Profile.Pt[i].X;
                    double y = BackgroundReferrenceProfile.GetValue(x, 1, 0) * BackgroundReferrenceScale;
                    BackgroundProfile.Pt[i] = new PointD(x, y);
                    Profile.Pt[i] = new PointD(x, Profile.Pt[i].Y - y);
                }
            }
        }
        //�o�b�N�O���E���h���������܂�
    }
    #endregion

    #region �m�[�}���C�Y
    private void Normarize()
    {
        if (DoesNormarizeIntensity)
        {
            double temp = NormarizeAsAverage ? 0 : double.NegativeInfinity;
            int count = 0;
            for (int i = 0; i < Profile.Pt.Count && Profile.Pt[i].X < NormarizeRangeEnd; i++)
            {
                if (Profile.Pt[i].X > NormarizeRangeStart)
                {
                    if (NormarizeAsAverage)
                        temp += Profile.Pt[i].Y;
                    else if (temp < Profile.Pt[i].Y)
                        temp = Profile.Pt[i].Y;
                    count++;
                }
            }
            if (double.IsNegativeInfinity(temp) || count == 0) return;

            double factor = NormarizeAsAverage ? NormarizeIntensity / (temp / count) : NormarizeIntensity / temp;

            for (int i = 0; i < Profile.Pt.Count; i++)
                //Profile.Pt[i].Y *= factor;
                Profile.Pt[i] = new PointD(Profile.Pt[i].X, Profile.Pt[i].Y * factor);
            for (int i = 0; i < Profile.Err.Count; i++)
                //Profile.Err[i].Y *= factor;
                Profile.Err[i] = new PointD(Profile.Err[i].X, Profile.Err[i].Y * factor);
        }
    }
    #endregion

    #region �o�b�N�O�����h����_�̌���
    /// <summary>
    /// SmoothProfile��Ώۂ�BgPoints�������ŒT��
    /// </summary>
    public void getBgPointsAuto()
    {
        int i;
        Profile p0 = Smoothing.SavitzkyGolay(SmoothedProfile, 3, 3);

        //��K����
        Profile p1 = new Profile();
        for (i = 0; i < p0.Pt.Count - 1; i++)
            p1.Pt.Add(new PointD((p0.Pt[i].X + p0.Pt[i + 1].X) / 2, (p0.Pt[i + 1].Y - p0.Pt[i].Y) / (p0.Pt[i + 1].X - p0.Pt[i].X)));
        p1 = Smoothing.SavitzkyGolay(p1, 3, 3);

        //��K����
        Profile p2 = new Profile();
        List<double> y = new List<double>();
        for (i = 0; i < p1.Pt.Count - 1; i++)
            p2.Pt.Add(new PointD((p1.Pt[i].X + p1.Pt[i + 1].X) / 2, (p1.Pt[i + 1].Y - p1.Pt[i].Y) / (p1.Pt[i + 1].X - p1.Pt[i].X)));
        p2 = Smoothing.SavitzkyGolay(p2, 3, 3);

        for (i = 0; i < p2.Pt.Count; i++)
            y.Add(p2.Pt[i].Y);

        //p2��Y�l���K�i��
        double d = Statistics.Deviation(y.ToArray());
        for (i = 0; i < p2.Pt.Count; i++)
            y[i] /= d;

        //30�|�C���g�ȏ㏬���Ȓl�������āA���O��100�|�C���g�ȏ�͂Ȃ�Ă���|�C���g���������A
        double temp = 1;
        double tempMax = double.PositiveInfinity;
        int tempXindex = 0;
        List<double> X = new List<double>();
        List<int> Xindex = new List<int>();
        bool flag = true;
        int range = (int)(p1.Pt.Count / 3.0 / BgPointsNumber);
        do
        {
            tempMax = double.PositiveInfinity;
            for (i = 0; i < p2.Pt.Count - 30; i++)
            {
                temp = 0;
                flag = true;
                //����range�͈̔͂Ɋ���Xindex����������X�L�b�v����
                foreach (int xindex in Xindex)
                    if (Math.Abs(i - xindex) < range)
                    {
                        i = xindex + range;
                        flag = false;
                        break;
                    }
                if (flag)
                {
                    for (int j = 0; j < 30; j++)
                        temp += Math.Abs(y[i + j]);
                    if (temp < tempMax && temp < 2)
                    {
                        tempMax = temp;
                        tempXindex = i + 15;
                    }
                }
            }
            if (tempMax < 10)
            {
                X.Add(p2.Pt[tempXindex].X);
                Xindex.Add(tempXindex);
            }
        } while (X.Count < BgPointsNumber && tempMax < 10);

        if (X.Count < 3)
            return;
        else//�R�_�ȏ㌩����ꂽ��
        {
            List<PointD> bgPoints = new List<PointD>();
            X.Sort();
            double tempY;
            for (i = 0; i < X.Count; i++)
            {
                tempMax = double.PositiveInfinity;
                temp = 0;
                //�܂����̓_�ɍł��߂�p0���̓_��������
                int k = 0;
                for (int j = 0; j < p0.Pt.Count; j++)
                {
                    temp = Math.Abs(p0.Pt[j].X - X[i]);
                    if (temp < tempMax)
                    {
                        tempMax = temp;
                        k = j;
                    }
                }
                if (k != 0)//�������_�̎���5�|�C���g�̕��ς��o�b�N�O���E���h�Ƃ���
                {
                    tempY = 0;
                    for (int l = k - 5; l <= k + 5 && l < p0.Pt.Count; l++)
                        tempY += p0.Pt[l].Y / 11.0;
                    bgPoints.Add(new PointD(p0.Pt[k].X, tempY));
                }
            }

            double minimum = double.PositiveInfinity;
            for (i = 0; i < bgPoints.Count; i++)
                if (minimum > bgPoints[i].Y)
                    minimum = bgPoints[i].Y;

            BgPoints = ConvertDestToSrc(bgPoints.ToArray());
        }
    }
    #endregion

    #region Kalpha2����
    /// <summary>
    /// Ka2����������ÓI���\�b�h�B
    /// </summary>
    /// <param name="profile"></param>
    /// <param name="alpha1"></param>
    /// <param name="alpha2"></param>
    /// <param name="ratio"></param>
    /// <returns></returns>
    public static Profile RemoveKalpha2(Profile profile, double alpha1, double alpha2, double ratio)
    {
        var targetProfile = new Profile();
        for (int i = 0; i < profile.Pt.Count; i++)
            targetProfile.Pt.Add(new PointD(profile.Pt[i].X, profile.Pt[i].Y));

        double startY = profile.Pt[0].Y * 2 / 3;

        for (int i = 0; i < profile.Pt.Count; i++)
        {
            double d = alpha2 / 2 / Math.Sin(profile.Pt[i].X / 360 * Math.PI);
            double theta = Math.Asin(alpha1 / 2 / d) * 360 / Math.PI;

            if (theta < profile.Pt[0].X)
                //targetProfile.Pt[i].Y -= startY * ratio;
                targetProfile.Pt[i] -= new PointD(0, startY * ratio);

            if (theta > targetProfile.Pt[0].X)
                //targetProfile.Pt[i].Y -= targetProfile.GetValue(theta, 2, 1) * ratio;
                targetProfile.Pt[i] -= new PointD(0, targetProfile.GetValue(theta, 2, 1) * ratio);
        }
        return targetProfile;
    }
    #endregion


    #region ������ϊ����郁�\�b�h�Q

    #region X���̕ϊ� Src => Dest
    /// <summary>
    /// Src�̉�����Dest�̉����ɕϊ�����
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    private PointD convertSrcToDest(PointD pt)
    {
        var x = Convert(new[] { pt.X }, true)[0];
        var y = pt.Y;
        if (IsCPS && ExposureTime > 0)
            y /= ExposureTime;
        if (IsLogIntensity)
            y = Math.Log10(y);

        return new PointD(x, y);
    }

    public PointD[] ConvertSrcToDest(PointD[] pt)
    {
        var dest = new List<PointD>();
        for (int i = 0; i < pt.Length; i++)
        {
            var p = convertSrcToDest(pt[i]);
            if (!double.IsNaN(p.X) && !double.IsInfinity(p.X) && !double.IsNaN(p.Y) && !double.IsInfinity(p.Y))
                dest.Add(p);
        }
        #region ����?
        //���x�̃m�[�}���C�Y�@step�����l�łȂ��Ȃ������̑Ή�
        /*
        if (dest.Count> 0)
        {
            List<double> steps = new List<double>();
            for (int i = 0; i < dest.Count - 1; i++)
                steps.Add(Math.Abs(dest[i].X - dest[i + 1].X));
            steps.Add(steps[steps.Count - 1]);
            double average = steps.Average();
            for (int i = 0; i < dest.Count; i++)
                dest[i].Y *= average / steps[i];
        }
        */
        #endregion
        return dest.ToArray();
    }
    #endregion

    #region X���̕ϊ� Dest=>Src
    /// <summary>
    /// Dest�̉�����Src�̉����ɕϊ�����
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public PointD ConvertDestToSrc(PointD pt)
    {
        var x = Convert(new[] { pt.X }, false)[0];
        var y = pt.Y;
        if (IsCPS && ExposureTime != 0)
            y *= ExposureTime;
        if (IsLogIntensity)
            y = Math.Pow(10, y);
        return new PointD(x, y);
    }

    /// <summary>
    /// Dest�̉�����Src�̉����ɕϊ�����
    /// </summary>
    /// <param name="pt"></param>
    /// <returns></returns>
    public PointD[] ConvertDestToSrc(PointD[] pt)
    {
        var dest = new List<PointD>();
        for (int i = 0; i < pt.Length; i++)
        {
            var p = ConvertDestToSrc(pt[i]);
            if (!double.IsNaN(p.X) && !double.IsInfinity(p.X) && !double.IsNaN(p.Y) && !double.IsInfinity(p.Y))
                dest.Add(p);
        }
        return dest.ToArray();
    }
    #endregion


    public double[] Convert(double[] x, bool SrcToDst)
    {

        var (srcAxisMode, dstAxisMode) = SrcToDst ? (SrcAxisMode, DstAxisMode) : (DstAxisMode, SrcAxisMode);
        var (srcWaveLength, dstWaveLength) = SrcToDst ? (SrcWaveLength, DstWaveLength) : (DstWaveLength, SrcWaveLength);
        var (srcDspacingUnit, dstDspacingUnit) = SrcToDst ? (SrcDspacingUnit, DstDspacingUnit) : (DstDspacingUnit, SrcDspacingUnit);
        var (srcEnergyUnit, dstEnergyUnit) = SrcToDst ? (SrcEnergyUnit, DstEnergyUnit) : (DstEnergyUnit, SrcEnergyUnit);
        var (srcTakeoffAngle, dstTakeoffAngle) = SrcToDst ? (SrcEnergyTakeoffAngle, DstEnergyTakeoffAngle) : (DstEnergyTakeoffAngle, SrcEnergyTakeoffAngle);
        var (srcTofTimeUnit, dstTofTimeUnit) = SrcToDst ? (SrcTofTimeUnit, DstTofTimeUnit) : (DstTofTimeUnit, SrcTofTimeUnit);
        var (srcTofAngle, dstTofAngle) = SrcToDst ? (SrcTofAngle, DstTofAngle) : (DstTofAngle, SrcTofAngle);
        var (srcTofLength, dstTofLength) = SrcToDst ? (SrcTofLength, DstTofLength) : (DstTofLength, SrcTofLength);
        var (srcWaveNumberUnit, dstWaveNumberUnit) = SrcToDst ? (SrcWaveNumberUnit, DstWaveNumberUnit) : (DstWaveNumberUnit, SrcWaveNumberUnit);
        var (srcTwoThetaUnit, dstTwoThetaUnit) = SrcToDst ? (SrcTwoThetaUnit, DstTwoThetaUnit) : (DstTwoThetaUnit, SrcTwoThetaUnit);

        #region 

        //Src��Dst��Axis���[�h���������Ƃ�
        if (srcAxisMode == dstAxisMode)
        {
            //�������U���p�œ���X���̔g�����������Ƃ�
            if (srcAxisMode == HorizontalAxis.Angle && srcWaveLength == dstWaveLength)
            {
                if (srcTwoThetaUnit == dstTwoThetaUnit)
                    return x;
                else if (srcTwoThetaUnit == AngleUnit.Radian)
                    return x.Select(x => x / Math.PI * 180).ToArray();
                else
                    return x.Select(x => x * Math.PI / 180).ToArray();
            }

            //������d�l�̎�
            if (srcAxisMode == HorizontalAxis.d )
            {
                if (srcDspacingUnit == dstDspacingUnit)
                    return x;
                else if (srcDspacingUnit == LengthUnitEnum.Angstrom && dstDspacingUnit == LengthUnitEnum.NanoMeter)
                    return x.Select(x => x * 0.1).ToArray();
                else if(srcDspacingUnit == LengthUnitEnum.NanoMeter && dstDspacingUnit == LengthUnitEnum.Angstrom)
                    return x.Select(x => x * 10).ToArray();
            }

            //�������G�l���M�[��TakeoffAngle���������Ƃ�
            if ((srcAxisMode == HorizontalAxis.EnergyXray || srcAxisMode == HorizontalAxis.EnergyElectron || srcAxisMode == HorizontalAxis.EnergyNeutron) && dstTakeoffAngle == srcTakeoffAngle)
            {
                if (srcEnergyUnit == dstEnergyUnit)
                    return x;
                else if (srcEnergyUnit == EnergyUnitEnum.eV)
                    return dstEnergyUnit == EnergyUnitEnum.KeV ? x.Select(x => x / 1_000).ToArray() : x.Select(x => x / 1_000_000).ToArray();
                else if (srcEnergyUnit == EnergyUnitEnum.KeV)
                    return dstEnergyUnit == EnergyUnitEnum.eV ? x.Select(x => x * 1_000).ToArray() : x.Select(x => x / 1_000).ToArray();
                else if (srcEnergyUnit == EnergyUnitEnum.MeV)
                    return dstEnergyUnit == EnergyUnitEnum.eV ? x.Select(x => x * 1_000_000).ToArray() : x.Select(x => x * 1_000).ToArray();
            }

            //������Neutron TOF�ŁATOF�p�x��TOF�������������Ƃ�
            if (srcAxisMode == HorizontalAxis.NeutronTOF && srcTofAngle == dstTofAngle && srcTofLength == dstTofLength)
            {
                if (srcTofTimeUnit == dstTofTimeUnit)
                    return x;
                else if (srcTofTimeUnit == TimeUnitEnum.MicroSecond && dstTofTimeUnit == TimeUnitEnum.NanoSecond)
                    return x.Select(x => x * 1_000).ToArray();
                else if (srcTofTimeUnit == TimeUnitEnum.NanoSecond && dstTofTimeUnit == TimeUnitEnum.MicroSecond)
                    return x.Select(x => x / 1_000).ToArray();
            }

            //�������g���̎�
            if (srcAxisMode == HorizontalAxis.WaveNumber)
            {
                if (srcWaveNumberUnit == dstWaveNumberUnit)
                    return x;
                else if (srcWaveNumberUnit == LengthUnitEnum.AngstromInverse && dstWaveNumberUnit == LengthUnitEnum.NanoMeterInverse)
                    return x.Select(x => x * 10).ToArray();
                else if (srcWaveNumberUnit == LengthUnitEnum.NanoMeterInverse && dstWaveNumberUnit == LengthUnitEnum.AngstromInverse)
                    return x.Select(x => x * 0.1).ToArray();
            }
        }

        //�܂���U���ׂĂ�d�l(nm�P��)�ɕϊ�
        var d = Array.Empty<double>();
        if (srcAxisMode == HorizontalAxis.d)
        {
            if (srcDspacingUnit == LengthUnitEnum.Angstrom)
                d = x;
            else if (srcDspacingUnit == LengthUnitEnum.NanoMeter)
                d = x.Select(d => d * 0.1).ToArray();
        }

        else if (srcAxisMode == HorizontalAxis.Angle)
        {
            var twoTheta= Array.Empty<double>();
            if(srcTwoThetaUnit == AngleUnit.Degree)
                d = HorizontalAxisConverter.TwoThetaInDegreeToD(x, srcWaveLength);
            else 
                d = HorizontalAxisConverter.TwoThetaInRadianToD(x, srcWaveLength);
        }
        else if (srcAxisMode == HorizontalAxis.EnergyXray || srcAxisMode == HorizontalAxis.EnergyElectron || srcAxisMode == HorizontalAxis.EnergyNeutron)
        {
            var energy = Array.Empty<double>();
            if (srcEnergyUnit == EnergyUnitEnum.eV)
                energy = x;
            else if (srcEnergyUnit == EnergyUnitEnum.KeV)
                energy = x.Select(x => x * 1_000).ToArray();
            else if (srcEnergyUnit == EnergyUnitEnum.MeV)
                energy = x.Select(x => x * 1_000_000).ToArray();

            if (srcAxisMode == HorizontalAxis.EnergyXray)
                d = HorizontalAxisConverter.XrayEnergyToD(energy, srcTakeoffAngle);
            else if (srcAxisMode == HorizontalAxis.EnergyElectron)
                d = HorizontalAxisConverter.ElectronEnergyToD(energy, srcTakeoffAngle);
            else if (srcAxisMode == HorizontalAxis.EnergyNeutron)
                d = HorizontalAxisConverter.NeutronEnergyToD(energy, srcTakeoffAngle);
        }
        else if (srcAxisMode == HorizontalAxis.NeutronTOF)
        {
            var tof = Array.Empty<double>();
            if (srcTofTimeUnit == TimeUnitEnum.MicroSecond)
                tof = x;
            else if (srcTofTimeUnit == TimeUnitEnum.NanoSecond)
                tof = x.Select(x => x / 1000).ToArray();

            d = HorizontalAxisConverter.NeutronTofToD(tof, srcTofAngle, srcTofLength);
        }
        else if (srcAxisMode == HorizontalAxis.WaveNumber)
        {
            if (srcWaveNumberUnit == LengthUnitEnum.NanoMeterInverse)
                d = HorizontalAxisConverter.WaveNumberToD(x);
            else if (srcWaveNumberUnit == LengthUnitEnum.AngstromInverse)
                d = HorizontalAxisConverter.WaveNumberToD(x.Select(x => x * 10));
        }


        //�Ō��d�l(nm�P��)��ړI�̎��ɕϊ�
        if (dstAxisMode == HorizontalAxis.Angle)
            return HorizontalAxisConverter.DToTwoThetaInDegree(d, dstWaveLength);
        else if (dstAxisMode == HorizontalAxis.d)
            return dstDspacingUnit == LengthUnitEnum.NanoMeter ? d : d.Select(d => d * 10).ToArray();
        else if (dstAxisMode == HorizontalAxis.EnergyXray || dstAxisMode == HorizontalAxis.EnergyElectron || dstAxisMode == HorizontalAxis.EnergyNeutron)
        {
            double[] energy = Array.Empty<double>();
            if (dstAxisMode == HorizontalAxis.EnergyXray)
                energy = HorizontalAxisConverter.DToXrayEnergy(d, dstTakeoffAngle);
            else if (dstAxisMode == HorizontalAxis.EnergyElectron)
                energy = HorizontalAxisConverter.DToElectronEnergy(d, dstTakeoffAngle);
            else if (dstAxisMode == HorizontalAxis.EnergyNeutron)
                energy = HorizontalAxisConverter.DToNeutronEnergy(d, dstTakeoffAngle);

            if (dstEnergyUnit == EnergyUnitEnum.eV)
                return energy;
            else if (dstEnergyUnit == EnergyUnitEnum.KeV)
                return energy.Select(e => e / 1_000).ToArray();
            else if (dstEnergyUnit == EnergyUnitEnum.MeV)
                return energy.Select(e => e / 1_000_000).ToArray();
        }
        else if (dstAxisMode == HorizontalAxis.NeutronTOF)
        {
            d = HorizontalAxisConverter.DToTOF(d, dstTofAngle, dstTofLength);
            if (dstTofTimeUnit == TimeUnitEnum.MicroSecond)
                return d;
            else if (dstTofTimeUnit == TimeUnitEnum.NanoSecond)
                return d.Select(d => d * 1_000).ToArray();
        }
        else if (dstAxisMode == HorizontalAxis.WaveNumber)
        {
            d = HorizontalAxisConverter.DToWaveNumber(d);
            if (dstWaveNumberUnit == LengthUnitEnum.NanoMeterInverse)
                return d;
            else if (dstWaveNumberUnit == LengthUnitEnum.AngstromInverse)
                return d.Select(d => d / 10).ToArray();
        }

        return null;
    }



    #endregion

}

public static class HorizontalAxisConverter
{
    #region ������ϊ����郁�\�b�h�Q

    //public static double Convert(double x, 
    //    HorizontalAxis srcAxisMode, double srcWavelength, double srcTakeoffAngle, double srcTofAngle, double srcTofLength,
    //    LengthUnitEnum srcDspacingUnit, EnergyUnitEnum srcEnergyUnit, TimeUnitEnum srcTofTimeUnit,
    //    HorizontalAxis dstAxisMode, double dstWavelength, double dstTakeoffAngle, double dstTofAngle, double dstTofLength, 
    //    LengthUnitEnum dstDspacingUnit, EnergyUnitEnum dstEnergyUnit, TimeUnitEnum dstTofTimeUnit)
    //{
    //    //���o�͂������������炻�̂܂�

    //    if (srcAxisMode == HorizontalAxis.Angle && dstAxisMode == HorizontalAxis.Angle && srcWavelength == dstWavelength)
    //        return x;

    //    if (srcAxisMode == HorizontalAxis.d && dstAxisMode == HorizontalAxis.d)
    //    {
    //        if (srcDspacingUnit == dstDspacingUnit)
    //            return x;
    //    }   
    //    if(srcAxisMode == HorizontalAxis.EnergyXray && dstAxisMode == HorizontalAxis.EnergyXray && dstTakeoffAngle == srcTakeoffAngle)
    //    {
    //        if(srcEnergyUnit == dstEnergyUnit)
    //            return x;
    //    }
         
    //    if (srcAxisMode == HorizontalAxis.NeutronTOF && dstAxisMode == HorizontalAxis.NeutronTOF && srcTofAngle == dstTofAngle && srcTofLength == dstTofLength)
    //    {
    //        if (srcTofTimeUnit == dstTofTimeUnit)
    //            return x;
    //    }
         
    //    if(srcAxisMode == HorizontalAxis.WaveNumber && dstAxisMode == HorizontalAxis.WaveNumber)
    //        return x;


    //    //����ȊO�̏ꍇ�͈�U���ׂĂ�d�l�ɕϊ�
    //    double d = x;
    //    if (srcAxisMode == HorizontalAxis.Angle) d = TwoThetaToD(x / 180 * Math.PI, srcWavelength);
    //    else if (srcAxisMode == HorizontalAxis.EnergyXray) d = XrayEnergyToD(x, srcTakeoffAngle);
    //    else if (srcAxisMode == HorizontalAxis.NeutronTOF) d = NeutronTofToD(x, srcTofAngle, srcTofLength);
    //    else if (srcAxisMode == HorizontalAxis.WaveNumber) d = WaveNumberToD(x);

    //    if (dstAxisMode == HorizontalAxis.Angle)
    //        return DToTwoTheta(d, dstWavelength) / Math.PI * 180.0;
    //    else if (dstAxisMode == HorizontalAxis.d)
    //        return d * 10;
    //    else if (dstAxisMode == HorizontalAxis.EnergyXray)
    //        return DToXrayEnergy(d, dstTakeoffAngle);
    //    else if (dstAxisMode == HorizontalAxis.EnergyElectron)
    //        return DToElectronEnergy(d, dstTakeoffAngle);
    //    else if (dstAxisMode == HorizontalAxis.NeutronTOF)
    //        return DToTOF(d, dstTofAngle, dstTofLength);
    //    else if (dstAxisMode == HorizontalAxis.WaveNumber)
    //        return DToWaveNumber(d) / 10.0;
    //    else
    //        return double.NaN;
    //}

    /// <summary>
    /// d -> Wavenumber  d�l(nm)��^����ƁA�g��(2��/nm)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double DToWaveNumber(double d) => Math.PI * 2 / d;
    /// <summary>
    /// d -> Wavenumber  d�l(nm)��^����ƁA�g��(2��/nm)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static double[] DToWaveNumber(IEnumerable<double> d) => d.Select(e => Math.PI * 2 / e).ToArray();


    /// <summary>
    /// Wavenumber -> d   �g��(2��/nm)��^����ƁA���z�I��d�l(nm)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double WaveNumberToD(double wavenumber) => Math.PI * 2 / wavenumber;
    /// <summary>
    /// Wavenumber -> d   �g��(2��/nm)��^����ƁA���z�I��d�l(nm)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] WaveNumberToD(IEnumerable<double> wavenumber) =>wavenumber.Select(e=>  Math.PI * 2 / e).ToArray();


    /// <summary>
    /// TOF -> d   TOF(��s)�Ǝ��o���p(radian)�A����(m)��^����ƁA�u���b�O�����𖞂���d�l(nm)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double NeutronTofToD(double TOF, double angle, double length) => UniversalConstants.Convert.NeutronVelocityToWavelength(length / TOF) / Math.Sin(angle / 2) / 2.0;
    /// <summary>
    /// TOF -> d   TOF(��s)�Ǝ��o���p(radian)�A����(m)��^����ƁA�u���b�O�����𖞂���d�l(nm)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] NeutronTofToD(IEnumerable<double> TOF, double angle, double length) => TOF.Select(e => UniversalConstants.Convert.NeutronVelocityToWavelength(length / e) / Math.Sin(angle / 2) / 2.0).ToArray();


    /// <summary>
    /// d -> TOF   d�l(nm)�Ɖ��z�I�Ȏ��o���p(radian)�A����(m)��^����ƁA�u���b�O�����𖞂������z�I��TOF(��s)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double DToTOF(double d, double angle, double length) => length / UniversalConstants.Convert.WavelengthToNeutronVelocity(2.0 * d * Math.Sin(angle / 2));
    /// <summary>
    /// d -> TOF   d�l(nm)�Ɖ��z�I�Ȏ��o���p(radian)�A����(m)��^����ƁA�u���b�O�����𖞂������z�I��TOF(��s)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] DToTOF(IEnumerable<double> d, double angle, double length) => d.Select(e => length / UniversalConstants.Convert.WavelengthToNeutronVelocity(2.0 * e * Math.Sin(angle / 2))).ToArray();


    /// <summary>
    /// d -> E   �ʊԊud(nm)�Ɖ��z�I�Ȏ��o���p(2��)��^����ƃu���b�O�����𖞂������z�I�ȓd���g�̃G�l���M�[(eV)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double DToXrayEnergy(double d, double takeoffAngle) => UniversalConstants.Convert.WavelengthToXrayEnergy(2.0 * d * Math.Sin(takeoffAngle / 2.0));
    /// <summary>
    /// d -> E   �ʊԊud(nm)�Ɖ��z�I�Ȏ��o���p(2��)��^����ƃu���b�O�����𖞂������z�I�ȓd���g�̃G�l���M�[(eV)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] DToXrayEnergy(IEnumerable<double> d, double takeoffAngle) => d.Select(e => UniversalConstants.Convert.WavelengthToXrayEnergy(2.0 * e * Math.Sin(takeoffAngle / 2.0))).ToArray();


    /// <summary>
    /// d -> E   �ʊԊud(nm)�Ɖ��z�I�Ȏ��o���p(2��)��^����ƃu���b�O�����𖞂������z�I�ȓd�q�̃G�l���M�[(keV)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double DToElectronEnergy(double d, double takeoffAngle) => UniversalConstants.Convert.WaveLengthToElectronEnergy(2.0 * d * Math.Sin(takeoffAngle / 2.0)) * 1000;
    /// <summary>
    /// d -> E   �ʊԊud(nm)�Ɖ��z�I�Ȏ��o���p(2��)��^����ƃu���b�O�����𖞂������z�I�ȓd�q�̃G�l���M�[(keV)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] DToElectronEnergy(IEnumerable<double> d, double takeoffAngle) =>d.Select(e=> UniversalConstants.Convert.WaveLengthToElectronEnergy(2.0 * e * Math.Sin(takeoffAngle / 2.0)) * 1000).ToArray();


    /// <summary>
    /// d -> E   �ʊԊud(nm)�Ɖ��z�I�Ȏ��o���p(2��)��^����ƃu���b�O�����𖞂������z�I�Ȓ����q�̃G�l���M�[(eV)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double DToNeutronEnergy(double d, double takeoffAngle) => UniversalConstants.Convert.WaveLengthToNeutronEnergy(2.0 * d * Math.Sin(takeoffAngle / 2.0));
    /// <summary>
    /// d -> E   �ʊԊud(nm)�Ɖ��z�I�Ȏ��o���p(2��)��^����ƃu���b�O�����𖞂������z�I�Ȓ����q�̃G�l���M�[(eV)��Ԃ�
    /// </summary>
    /// <param name="d"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] DToNeutronEnergy(IEnumerable<double> d, double takeoffAngle) =>d.Select(e=> UniversalConstants.Convert.WaveLengthToNeutronEnergy(2.0 * e * Math.Sin(takeoffAngle / 2.0))).ToArray();


    /// <summary>
    /// E -> d  �d���g�̃G�l���M�[(eV)�Ǝ��o���p��^����ƃu���b�O�����𖞂����ʊԊud(nm)�̒l��Ԃ�
    /// </summary>
    /// <param name="energy"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double XrayEnergyToD(double energy, double takeoffAngle) => UniversalConstants.Convert.EnergyToXrayWaveLength(energy) / 2.0 / Math.Sin(takeoffAngle / 2.0);
    /// <summary>
    /// E -> d  �d���g�̃G�l���M�[(eV)�Ǝ��o���p��^����ƃu���b�O�����𖞂����ʊԊud(nm)�̒l��Ԃ�
    /// </summary>
    /// <param name="energy"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] XrayEnergyToD(IEnumerable<double> energy, double takeoffAngle) =>energy.Select(e=> UniversalConstants.Convert.EnergyToXrayWaveLength(e) / 2.0 / Math.Sin(takeoffAngle / 2.0)).ToArray();


    /// <summary>
    /// E -> d  �d�q�̃G�l���M�[(eV)�Ǝ��o���p��^����ƃu���b�O�����𖞂����ʊԊud(nm)�̒l��Ԃ�
    /// </summary>
    /// <param name="energy"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double ElectronEnergyToD(double energy, double takeoffAngle) => UniversalConstants.Convert.EnergyToElectronWaveLength(energy / 1000) / 2.0 / Math.Sin(takeoffAngle / 2.0);
    /// <summary>
    /// E -> d  �d�q�̃G�l���M�[(eV)�Ǝ��o���p��^����ƃu���b�O�����𖞂����ʊԊud(nm)�̒l��Ԃ�
    /// </summary>
    /// <param name="energy"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] ElectronEnergyToD(IEnumerable<double> energy, double takeoffAngle) =>energy.Select(e=> UniversalConstants.Convert.EnergyToElectronWaveLength(e / 1000) / 2.0 / Math.Sin(takeoffAngle / 2.0)).ToArray();


    /// <summary>
    /// E -> d  �����q�̃G�l���M�[(eV)�Ǝ��o���p��^����ƃu���b�O�����𖞂����ʊԊud(nm)�̒l��Ԃ�
    /// </summary>
    /// <param name="energy"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double NeutronEnergyToD(double energy, double takeoffAngle) => UniversalConstants.Convert.EnergyToNeutronWaveLength(energy) / 2.0 / Math.Sin(takeoffAngle / 2.0);
    /// <summary>
    /// E -> d  �����q�̃G�l���M�[(eV)�Ǝ��o���p��^����ƃu���b�O�����𖞂����ʊԊud(nm)�̒l��Ԃ�
    /// </summary>
    /// <param name="energy"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] NeutronEnergyToD(IEnumerable<double> energy, double takeoffAngle) => energy.Select(e => UniversalConstants.Convert.EnergyToNeutronWaveLength(e) / 2.0 / Math.Sin(takeoffAngle / 2.0)).ToArray();


   


    /// <summary>
    /// E -> 2��  �d���g�̃G�l���M�[(eV)�A���o���p(takeoffAngle)�A���z�I�ȓ��ː��̔g��(nm)��^����Ɖ��z�I�ȉ�܊p��Ԃ�
    /// </summary>
    /// <param name="energy"></param>
    /// <param name="waveLength"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double XrayEnergyToTwoTheta(double energy, double takeoffAngle, double waveLength) => 2 * Math.Asin(waveLength / 2.0 / XrayEnergyToD(energy, takeoffAngle));
    /// <summary>
    /// E -> 2��  �d���g�̃G�l���M�[(eV)�A���o���p(takeoffAngle)�A���z�I�ȓ��ː��̔g��(nm)��^����Ɖ��z�I�ȉ�܊p��Ԃ�
    /// </summary>
    /// <param name="energy"></param>
    /// <param name="waveLength"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] XrayEnergyToTwoTheta(IEnumerable<double> energy, double takeoffAngle, double waveLength) => energy.Select(e => 2 * Math.Asin(waveLength / 2.0 / XrayEnergyToD(e, takeoffAngle))).ToArray();


    /// <summary>
    ///  2�� -> E  �u���b�O�p�ƁA���ː��g��(nm)�A���z�I��EDX���o���p(takeoffAngle)����u���b�O�����𖞂������z�I�ȓd���g�g��(nm)��������
    /// </summary>
    /// <param name="twoTheta"></param>
    /// <param name="waveLength"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double TwoThetaToXrayEnergy(double twoTheta, double waveLength, double takeoffAngle) => DToXrayEnergy(waveLength / 2.0 / Math.Sin(twoTheta / 2.0), takeoffAngle);
    /// <summary>
    ///  2�� -> E  �u���b�O�p�ƁA���ː��g��(nm)�A���z�I��EDX���o���p(takeoffAngle)����u���b�O�����𖞂������z�I�ȓd���g�g��(nm)��������
    /// </summary>
    /// <param name="twoTheta"></param>
    /// <param name="waveLength"></param>
    /// <param name="takeoffAngle"></param>
    /// <returns></returns>
    public static double[] TwoThetaToXrayEnergy(IEnumerable<double> twoTheta, double waveLength, double takeoffAngle) => twoTheta.Select(e => DToXrayEnergy(waveLength / 2.0 / Math.Sin(e / 2.0), takeoffAngle)).ToArray();

    /// <summary>
    /// 2��(rad) -> d(nm)   �u���b�O�p(radian)�Ɠ��ː��g������u���b�O�����𖞂����ʊԊud(nm)��Ԃ�
    /// </summary>
    /// <param name="twoTheta"></param>
    /// <param name="waveLength"></param>
    /// <returns></returns>
    public static double TwoThetaInRadianToD(double twoTheta, double waveLength) => waveLength / Math.Sin(twoTheta / 2.0) / 2.0;
    /// <summary>
    /// 2��(rad) -> d(nm)   �u���b�O�p(radian)�Ɠ��ː��g������u���b�O�����𖞂����ʊԊud(nm)��Ԃ�
    /// </summary>
    /// <param name="twoTheta"></param>
    /// <param name="waveLength"></param>
    /// <returns></returns>
    public static double[] TwoThetaInRadianToD(IEnumerable<double> twoTheta, double waveLength) => twoTheta.Select(e => waveLength / Math.Sin(e / 2.0) / 2.0).ToArray();

    /// <summary>
    /// 2��(deg) -> d(nm)   �u���b�O�p(degree)�Ɠ��ː��g������u���b�O�����𖞂����ʊԊud(nm)��Ԃ�
    /// </summary>
    /// <param name="twoTheta"></param>
    /// <param name="waveLength"></param>
    /// <returns></returns>
    public static double TwoThetaInDegreeToD(double twoTheta, double waveLength) => waveLength / Math.Sin(twoTheta / 180.0 * Math.PI / 2.0) / 2.0;
    /// <summary>
    /// 2��(deg) -> d(nm)   �u���b�O�p(degree)�Ɠ��ː��g������u���b�O�����𖞂����ʊԊud(nm)��Ԃ�
    /// </summary>
    /// <param name="twoTheta"></param>
    /// <param name="waveLength"></param>
    /// <returns></returns>
    public static double[] TwoThetaInDegreeToD(IEnumerable<double> twoTheta, double waveLength) => twoTheta.Select(e => waveLength / Math.Sin(e / 180.0 * Math.PI / 2.0) / 2.0).ToArray();


    /// <summary>
    /// d(nm) -> 2��(rad) �ʊԊud(nm)�Ɖ��z�I�ȓ��ː��̔g��(nm)��^����ƃu���b�O�����𖞂������z�I�ȉ�܊p(2��)��Ԃ�
    /// </summary>
    /// <param name="wavelength"></param>
    /// <returns></returns>
    public static double DToTwoThetaInRadian(double d, double wavelength) => 2 * Math.Asin(wavelength / 2.0 / d);
    /// <summary>
    /// d(nm) -> 2��(rad) �ʊԊud(nm)�Ɖ��z�I�ȓ��ː��̔g��(nm)��^����ƃu���b�O�����𖞂������z�I�ȉ�܊p(2��)��Ԃ�
    /// </summary>
    /// <param name="wavelength"></param>
    /// <returns></returns>
    public static double[] DToTwoThetaInRadian(IEnumerable<double> d, double wavelength) => d.Select(e => 2 * Math.Asin(wavelength / 2.0 / e)).ToArray();
    /// <summary>
    /// d(nm) -> 2��(deg) �ʊԊud(nm)�Ɖ��z�I�ȓ��ː��̔g��(nm)��^����ƃu���b�O�����𖞂������z�I�ȉ�܊p(2��)��Ԃ�
    /// </summary>
    /// <param name="wavelength"></param>
    /// <returns></returns>
    public static double DToTwoThetaInDegree(double d, double wavelength) => 2 * Math.Asin(wavelength / 2.0 / d) / Math.PI * 180;
    /// <summary>
    /// d(nm) -> 2��(deg) �ʊԊud(nm)�Ɖ��z�I�ȓ��ː��̔g��(nm)��^����ƃu���b�O�����𖞂������z�I�ȉ�܊p(2��)��Ԃ�
    /// </summary>
    /// <param name="wavelength"></param>
    /// <returns></returns>
    public static double[] DToTwoThetaInDegree(IEnumerable<double> d, double wavelength) => d.Select(e => 2 * Math.Asin(wavelength / 2.0 / e) / Math.PI * 180).ToArray();


    #endregion ������ϊ����郁�\�b�h�Q
}
