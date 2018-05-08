using System;
using System.Linq;

public class Program
{
    private static CarManager manager = new CarManager();
    public static void Main()
    {
        string command;
        while ((command = Console.ReadLine()) != "Cops Are Here")
        {
            ParseCommand(command);
        }
    }

    private static void ParseCommand(string command)
    {
        var line = command.Split(' ');

        switch (line[0])
        {
            case "register":
                int id = int.Parse(line[1]);
                string type = line[2];
                string brand = line[3];
                string model = line[4];
                int yearOfProduction = int.Parse(line[5]);
                int horsepower = int.Parse(line[6]);
                int acceleration = int.Parse(line[7]);
                int suspension = int.Parse(line[8]);
                int durability = int.Parse(line[9]);
                manager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            case "check":
                Console.WriteLine(manager.Check(int.Parse(line[1])));
                break;
            case "open":
                var input = line.Skip(1).ToList();
                manager.Open(input);
                break;
            case "participate":
                int carId = int.Parse(line[1]);
                int raceIds = int.Parse(line[2]);
                manager.Participate(carId, raceIds);
                break;
            case "start":
                Console.WriteLine(manager.Start(int.Parse(line[1])));
                break;
            case "unpark":
                manager.Unpark(int.Parse(line[1]));
                break;
            case "park":
                manager.Park(int.Parse(line[1]));
                break;
            case "tune":
                int tuneIndex = int.Parse(line[1]);
                string addon = line[2];
                manager.Tune(tuneIndex, addon);
                break;
        }
    }
}

