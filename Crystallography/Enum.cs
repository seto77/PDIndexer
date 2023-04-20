namespace Crystallography
{
    //汎用性の高い列挙体をここで定義

    public enum PixelUnitEnum
    {
        None,
        MilliMeter,
        MicroMeter,
        NanoMeter,
        MicroMeterInv,
        NanoMeterInv
    }

    public enum FourierDirectionEnum
    {
        Forward,
        Inverse
    }

    public enum VH_DirectionEnum
    {
        Vertical,
        Horizontal
    }

    public enum EnergyUnitEnum
    {
        eV = 1,
        KeV = 10,
        MeV = 100
    }

    public enum TimeUnitEnum
    {
        Seccond,
        MilliSecond,
        MicroSecond,
        NanoSecond
    }

    internal class Enum
    {
    }
}