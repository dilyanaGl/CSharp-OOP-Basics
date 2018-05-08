
public class AirBender : Bender
{
    private double aerialIntegrity;
    public double AerialIntegirty { get => this.aerialIntegrity; set => this.aerialIntegrity = value; }

    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        this.AerialIntegirty = aerialIntegrity;
    }

    public override double GetPower()
    {
        return this.power * aerialIntegrity;
    }

    public override string ToString()
    {
        return $"Air Bender: {name}, Power: {power}, Aerial Integrity: {aerialIntegrity:f2}";
    }
}

