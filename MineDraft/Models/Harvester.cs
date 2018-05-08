using System;
using System.Text;

public abstract class Harvester : Worker
{
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(OreOutput));
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || value > 20_000)
            {
                throw new ArgumentException(nameof(EnergyRequirement));
            }
            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Ore Output: {OreOutput}");
        sb.AppendLine($"Energy Requirement: {EnergyRequirement}");
        return sb.ToString().Trim();
    }
}

