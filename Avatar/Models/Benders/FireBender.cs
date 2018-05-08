public class FireBender : Bender
{
    private double heatAgression;

    public double HeatAgression { get => this.heatAgression; set => this.heatAgression = value; }

    public FireBender(string name, int power, double heatAgression) : base(name, power)
    {
        this.HeatAgression = heatAgression;
    }

    public override double GetPower()
    {
        return this.power * this.HeatAgression;
    }

    public override string ToString()
    {
        return $"Fire Bender: {name}, Power: {power}, Heat Aggression: {HeatAgression:f2}";
    }
}

