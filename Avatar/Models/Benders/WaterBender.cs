public class WaterBender : Bender
{
    private double waterClarity;
    public double WaterClarity { get => this.waterClarity; set => this.waterClarity = value; }

    public WaterBender(string name, int power, double waterClarity) : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public override double GetPower()
    {
        return this.power * this.WaterClarity;
    }

    public override string ToString()
    {
        return $"Water Bender: {name}, Power: {power}, Water Clarity: {WaterClarity:f2}";
    }
}

