using System;

public class Program
{
    private static NationsBender controller = new NationsBender();

    public static void Main()
    {
        while (true)
        {
            string[] line = Console.ReadLine().Split();
            ParseCommands(line);
        }
    }

    private static void ParseCommands(string[] line)
    {
        switch (line[0])
        {
            case "Bender":
                controller.AssignBender(line);
                break;
            case "Monument":
                controller.AssignMonument(line);
                break;
            case "Status":
                Console.WriteLine(controller.GetStatus(line[1]));
                break;
            case "War":
                controller.IssueWar(line[1]);
                break;
            case "Quit":
                Console.WriteLine(controller.GetWarsRecord());
                Environment.Exit(0);
                break;
        }
    }
}

