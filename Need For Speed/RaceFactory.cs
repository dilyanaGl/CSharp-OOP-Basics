using System.CodeDom;
using System.Collections.Generic;

public class RaceFactory
{
    public Race CreateRace(List<string> line)
    {
        string type = line[0];
        int length = int.Parse(line[1]);
        string route = line[2];
        int prizePool = int.Parse(line[3]);
        switch (type)
        {
            case "Casual":
                return new CasualRace(length, route, prizePool);
            case "Drift":
                return new DriftRace(length, route, prizePool);
            case "Drag":
                return new DragRace(length, route, prizePool);
            case "TimeLimit":
                return new TimeLimitRace(length, route, prizePool, int.Parse(line[4]));
            case "Circuit":
                return new CircuitRace(length, route, prizePool, int.Parse(line[4]));
            default:
                return null;
        }
    }
}

