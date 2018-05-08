using System;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.sonicFactor = sonicFactor;
        this.EnergyRequirement /= sonicFactor;
    }

    public override string ToString()
    {
        return $"Sonic Harvester - {Id}" + Environment.NewLine + base.ToString();
    }
}

