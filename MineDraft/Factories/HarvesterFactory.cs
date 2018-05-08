using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);
        switch (type)
        {
            case "Sonic":
                return new SonicHarvester(id, oreOutput, energyRequirement, int.Parse(args[4]));
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            default:
                return null;
        }
    }
}

