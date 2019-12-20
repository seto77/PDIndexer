using System;
using System.Collections.Generic;
using System.Text;
using Crystallography;

namespace PDIndexer
{
    public static class HorizontalAxisConverter
    {
      /*  #region 横軸を変換するメソッド群
        /// <summary>
        /// d -> E   面間隔d(nm)と取り出し角(2Θ)を与えるとブラッグ条件を満たす電磁波のエネルギー(eV)を返す
        /// </summary>
        /// <param name="d"></param>
        /// <param name="takeoffAngle"></param>
        /// <returns></returns>
        public static double DToEnergy(double d, double takeoffAngle)
        {
            return UniversalConstants.ConvertWaveLengthToEnergy(2.0 * d * Math.Sin(takeoffAngle / 2.0));
        }

        /// <summary>
        /// E -> d  電磁波のエネルギー(eV)と取り出し角を与えるとブラッグ条件を満たす面間隔d(nm)の値を返す
        /// </summary>
        /// <param name="energy"></param>
        /// <param name="takeoffAngle"></param>
        /// <returns></returns>
        public static double EnergyToD(double energy, double takeoffAngle)
        {
            return UniversalConstants.ConvertEnergyToWaveLength(energy) / 2.0 / Math.Sin(takeoffAngle / 2.0);
        }

        /// <summary>
        /// d -> 2θ 仮想的な入射線の波長(nm)と面間隔d(nm)を与えるとブラッグ条件を満たす仮想的な回折角(2θ)を返す
        /// </summary>
        /// <param name="wavelength"></param>
        /// <returns></returns>
        public static double DToTwoTheta(double wavelength, double d)
        {
            return 2 * Math.Asin(wavelength / 2.0 / d);
        }

        /// <summary>
        /// E -> 2θ  電磁波のエネルギー(eV)、取り出し角(takeoffAngle)、仮想的な入射線の波長(nm)を与えると仮想的な回折角を返す
        /// </summary>
        /// <param name="energy"></param>
        /// <param name="waveLength"></param>
        /// <param name="takeoffAngle"></param>
        /// <returns></returns>
        public static double EnergyToTwoTheta(double energy, double waveLength, double takeoffAngle)
        {
            return 2 * Math.Asin(waveLength / 2.0 / EnergyToD(energy, takeoffAngle));
        }

        /// <summary>
        ///  2θ -> E  ブラッグ角と、入射線波長(nm)、EDX取り出し角(takeoffAngle)からブラッグ条件を満たす電磁波波長(nm)をかえす
        /// </summary>
        /// <param name="twoTheta"></param>
        /// <param name="waveLength"></param>
        /// <param name="takeoffAngle"></param>
        /// <returns></returns>
        public static double TwoThetaToEnergy(double twoTheta, double waveLength, double takeoffAngle)
        {
            return DToEnergy(waveLength / 2.0 / Math.Sin(twoTheta / 2.0), takeoffAngle);
        }

        /// <summary>
        /// 2θ -> d   ブラッグ角と入射線波長からブラッグ条件を満たす面間隔d(nm)を返す  
        /// </summary>
        /// <param name="twoTheta"></param>
        /// <param name="waveLength"></param>
        /// <returns></returns>
        public static double TwoThetaToD(double twoTheta, double waveLength)
        {
            return waveLength / Math.Sin(twoTheta / 2.0) / 2.0;
        }
        #endregion
        */
    }
}
