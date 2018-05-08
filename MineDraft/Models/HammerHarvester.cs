using System;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += 2 * OreOutput;
        this.EnergyRequirement += EnergyRequirement;
    }

    public override string ToString()
    {
        return $"Hammer Harvester - {Id}" + Environment.NewLine + base.ToString();
    }
}

