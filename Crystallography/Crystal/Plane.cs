using System;
using System.Numerics;

namespace Crystallography
{
    /// <summary>
    /// Plane �̊T�v�̐����ł��B
    /// </summary>
    [Serializable()]
    public class Plane : System.IComparable
    {
        public PeakFunctionForm SerchOption;

        public double SerchRange = 0.10;
        public double FWHM = 0.10;
        public bool IsCombined;//�ق��̖ʂƌ���(������)�ł���Ƃ�True

                               //public int multi;//���d�x
        public int[] Multi = new int[1];//���d�x

        public bool IsRootIndex = false;//���̖ʎw�������Ƃ�

        public double MillimeterCalc, MillimeterObs;
        public double Intensity;//Conbine����Ă���Ƃ��͋��x�̘a
        public double RawIntensity;

        public double[] eachIntensity = new double[1];//Combine����Ă���Ƃ��͗v�f����2�ȏ�ɂȂ�
        public double observedIntensity;
        public PointD simpleParameter;
        public PeakFunction peakFunction = new PeakFunction();
        public double[] F2 = new double[1];//Combine����Ă���Ƃ��͗v�f����2�ȏ�ɂȂ�
        public Complex[] F = new Complex[1];
        public bool IsFittingSelected;
        public bool IsFittingChecked;
        public int DecompositionGroup;
        public int h, k, l;
        public int eH, eK, eL;
        public double d;
        public double dObs;
        public double XObs;
        public double XCalc;
        public double Weight;
        public string strHKL, strD;
        public string[] strCondition = new string[0];
        public string str;
        public int num;

        public double CosExpFactor;
        public double SinExpFactor;

        public int CompareTo(object obj)
        {
            if (d != ((Plane)obj).d)
                return -d.CompareTo(((Plane)obj).d);
            else if (h > ((Plane)obj).h || (h == ((Plane)obj).h && k > ((Plane)obj).k) || (h == ((Plane)obj).h && k == ((Plane)obj).k && l > ((Plane)obj).l))
                return -1;
            else
                return 0;
        }

        public override string ToString()
        {
            //return str.ToString();
            string s = (strHKL + "                            ").Remove(13);//�󔒂�}�����Ă���10�����ڈȍ~���J�b�g
            if (double.IsNaN(XCalc) || XCalc == 0)
                s += " " + "##.####";
            else
                s += " " + XCalc.ToString("00.0000");

            if (double.IsNaN(XObs) || XObs == 0)
                s += " " + "##.####";
            else
                s += " " + XObs.ToString("00.0000");

            if (double.IsNaN(XObs) || XObs == 0 || double.IsNaN(peakFunction.Hk) || peakFunction.Hk == 0 || double.IsInfinity(peakFunction.Hk))
                s += " " + "#.####";
            else
                s += " " + peakFunction.Hk.ToString("0.0000");

            if (double.IsNaN(XObs) || XObs == 0 || double.IsNaN(Weight) || Weight == 0 || double.IsInfinity(Weight))
                s += " " + "###.#";
            else
                s += " " + Weight.ToString("000.0");

            if (double.IsNaN(XObs) || XObs == 0 || double.IsNaN(observedIntensity) || observedIntensity == 0)
                s += " " + "#######";
            else
                s += " " + observedIntensity.ToString("000000");

            return s;
        }
    }
}