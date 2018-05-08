using System.Collections.Generic;

public class ProviderFactory
{
    public Provider CreateProvider(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double energyutput = double.Parse(args[2]);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyutput);
            case "Pressure":
                return new PressureProvider(id, energyutput);
            default:
                return null;
        }
    }
}

