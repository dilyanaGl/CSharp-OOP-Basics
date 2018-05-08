using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        DraftManager manager = new DraftManager();
        while (true)
        {
            var command = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var args = command.Skip(1).ToList();

            switch (command[0])
            {
                case "RegisterHarvester":
                    Console.WriteLine(manager.RegisterHarvester(args));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(manager.RegisterProvider(args));
                    break;
                case "Day":
                    Console.WriteLine(manager.Day());
                    break;
                case "Check":
                    Console.WriteLine(manager.Check(args));
                    break;
                case "Mode":
                    Console.WriteLine(manager.Mode(args));
                    break;
                case "Shutdown":
                    Console.WriteLine(manager.ShutDown());
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

