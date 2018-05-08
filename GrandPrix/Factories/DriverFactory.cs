using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.SqlServer.Server;

public class DriverFactory
{
    TyreFactory tyreFactory = new TyreFactory();
    public Driver CreateDriver(List<string> args)
    {
        string type = args[0];
        string name = args[1];
        int hp = int.Parse(args[2]);
        double fuelAmount = double.Parse(args[3]);
        string tyreType = args[4];
        var tyreInfo = args.Skip(5).ToArray();

        Tyre tyre;
        try
        {
            tyre = tyreFactory.CreateTyre(tyreType, tyreInfo);
        }
        catch (NoNullAllowedException)
        {
            return null;
        }

        Car car;
        try
        {
            car = new Car(hp, fuelAmount, tyre);
        }
        catch(NoNullAllowedException)
        {
            return null;
        }

        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(name, car);
            case "Endurance":
                return new EnduranceDriver(name, car);
            default:
                return null;
        }
    }
}

