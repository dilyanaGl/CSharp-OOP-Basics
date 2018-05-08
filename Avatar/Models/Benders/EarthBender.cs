public class EarthBender : Bender
{
    private double groundSaturation;

    public double GroundSaturation
    {
        get => this.groundSaturation;
        set => this.groundSaturation = value;
    }

    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public override double GetPower()
    {
        return this.power * this.GroundSaturation;
    }

    public override string ToString()
    {
        return $"Earth Bender: {name}, Power: {power}, Ground Saturation: {groundSaturation:f2}";
    }
}

