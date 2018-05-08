using System;

public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput) : base(id, energyOutput)
    {
    }

    public override string ToString()
    {
        return $"Solar Provider - {Id}" + Environment.NewLine + base.ToString();
    }
}

