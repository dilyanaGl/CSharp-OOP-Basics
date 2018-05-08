using System;
using System.Linq;

public class Program
{
    private static RaceTower raceTower = new RaceTower();

    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int length = int.Parse(Console.ReadLine());
        raceTower.SetTrackInfo(num, length);

        while (!raceTower.IsThisTheEnd)
        {
            var command = Console.ReadLine().Split(' ');
            var line = command.Skip(1).ToList();

            switch (command[0])
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(line);
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    var result = raceTower.CompleteLaps(line);

                    if (result != String.Empty)
                    {
                        Console.WriteLine(result);
                    }

                    if (raceTower.IsThisTheEnd)
                    {
                        Console.WriteLine(raceTower.DisplayWinner());
                        break;
                    }
                    break;
                case "Box":
                    raceTower.DriverBoxes(line);
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(line);
                    break;
            }
        }
    }
}

