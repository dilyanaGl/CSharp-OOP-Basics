using System;
using System.Text;

public abstract class Provider : Worker
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value > 10_000)
            {
                throw new ArgumentException(nameof(EnergyOutput));
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Energy Output: {EnergyOutput}");
        return sb.ToString().Trim();
    }
}

