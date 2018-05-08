using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.SqlServer.Server;

public class RaceTower
{
    private int currentLap;
    private int totalLaps;
    private List<Driver> participats;
    private int length;
    private Dictionary<Driver, string> failedDrivers;
    private DriverFactory driverFactory;
    private string weather;
    private TyreFactory tyreFactory;
    public bool IsThisTheEnd;

    public RaceTower()
    {
        this.participats = new List<Driver>();
        this.failedDrivers = new Dictionary<Driver, string>();
        this.currentLap = 0;
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.weather = "Sunny";
        IsThisTheEnd = false;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLaps = lapsNumber;
        this.length = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        Driver driver;
        try
        {
            driver = driverFactory.CreateDriver(commandArgs);
            participats.Add(driver);
        }
        catch (NoNullAllowedException)
        {

        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];
        Driver driver = this.participats.FirstOrDefault(p => p.Name == driverName);
        driver.TotalTime += 20;
        string tyreOtFuel = commandArgs[2];
        var tyreInfo = commandArgs.Skip(3).ToArray();

        switch (reasonToBox)
        {
            case "Refuel":
                double fuel = double.Parse(tyreOtFuel);
                driver.Car.Refuel(fuel);
                break;
            case "ChangeTyres":
                var tyre = tyreFactory.CreateTyre(tyreOtFuel, tyreInfo);
                driver.Car.ChangeTyre(tyre);
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int laps = int.Parse(commandArgs[0]);
        var sb = new StringBuilder();
        if (laps + currentLap > totalLaps)
        {
            sb.AppendLine($"There is no time! On lap {this.currentLap}.");
        }
        else
        {
            CompleteTheseLaps(laps, sb);

            if (this.currentLap == totalLaps)
            {
                IsThisTheEnd = true;
            }
        }

        return sb.ToString().Trim();
    }

    private void CompleteTheseLaps(int laps, StringBuilder sb)
    {
        for (int i = 0; i < laps; i++)
        {
            ReduceResources();
            RemoveFailedDrivers();
            this.currentLap++;
            var drivers = participats.OrderByDescending(p => p.TotalTime).ToList();
            CheckForOvertaking(drivers, sb);
        }
    }

    private void CheckForOvertaking(List<Driver> drivers, StringBuilder sb)
    {
        for (int i = 0; i < drivers.Count - 1; i++)
        {
            Driver currentDriver = drivers[i];
            var nextDriver = drivers[i + 1];
            var currentTime = currentDriver.TotalTime;
            var nextTime = nextDriver.TotalTime;
            int interval = 2;
            bool isThereSpecialCondition = CheckFOrSpecialConditios(currentDriver, ref interval);
            if (currentTime - nextTime < interval)
            {
                if (isThereSpecialCondition)
                {
                    failedDrivers.Add(currentDriver, "Crashed");
                    this.participats.Remove(currentDriver);

                }
                else
                {
                    currentDriver.TotalTime -= interval;
                    nextDriver.TotalTime += interval;
                    sb.AppendLine($"{currentDriver.Name} has overtaken {nextDriver.Name} on lap {this.currentLap}.");
                }
            }
        }
    }

    private bool CheckFOrSpecialConditios(Driver currentDriver, ref int interval)

    {
        if (currentDriver.GetType().Name == "AggressiveDriver" && currentDriver.Car.Tyre.Name == "Ultrasoft")
        {
            interval = 3;
            if (weather == "Foggy")
            {
                return true;
            }
        }

        if (currentDriver.GetType().Name == "EnduranceDriver" && currentDriver.Car.Tyre.Name == "Hard")
        {
            interval = 3;
            if (weather == "Rainy")
            {
                return true;
            }
        }

        return false;
    }

    private void RemoveFailedDrivers()
    {
        this.participats.RemoveAll(p => failedDrivers.Keys.Contains(p));
    }

    private void ReduceResources()
    {
        for (int j = 0; j < participats.Count; j++)
        {
            var currentDriver = participats[j];
            try
            {
                currentDriver.TotalTime += 60 / (this.length / currentDriver.Speed);
                currentDriver.ReduceFuel(this.length);
                currentDriver.Car.Tyre.ReduceDegradation();
            }
            catch (ArgumentException ex)
            {
                this.failedDrivers.Add(currentDriver, ex.Message);
            }
        }
    }

    public string GetLeaderboard()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Lap {currentLap}/{totalLaps}");
        int position = 1;
        var drivers = this.participats.OrderBy(p => p.TotalTime).ToList();
        drivers.ForEach(p => sb.AppendLine($"{position++} {p.Name} {p.TotalTime:f3}"));
        foreach (var driver in this.failedDrivers.Reverse())
        {
            sb.AppendLine($"{position++} {driver.Key.Name} {driver.Value}");
        }

        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    public string DisplayWinner()
    {
        var winner = this.participats.OrderBy(p => p.TotalTime).First();
        return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
    }
}



