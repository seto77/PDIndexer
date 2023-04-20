namespace Crystallography
{
    //汎用性の高い列挙体をここで定義

    public enum LengthUnitEnum
    {
        None,
        
        Meter,
        CentiMeter,
        MilliMeter,
        MicroMeter,
        NanoMeter,
        Angstrom,
        PicoMeter,

        MeterInverse,
        CentiMeterInverse,
        MilliMeterInverse,
        MicroMeterInverse,
        NanoMeterInverse,
        AngstromInverse,
        PicoMeterInverse
    }

    public enum AngleUnit
    {
        Degree,
        Radian
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