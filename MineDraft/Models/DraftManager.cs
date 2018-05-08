using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private double totalEnergy;
    private double totalMinedOre;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.mode = "Full";
        this.totalEnergy = 0d;
        this.totalMinedOre = 0d;
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var sb = new StringBuilder();
        try
        {
            var harvester = harvesterFactory.CreateHarvester(arguments);
            string type = arguments[0];
            this.harvesters.Add(harvester);
            sb.AppendLine($"Successfully registered {type} Harvester - {harvester.Id}");
        }
        catch (Exception ex)
        {
            sb.AppendLine($"Harvester is not registered, because of it's {ex.Message}");
        }

        return sb.ToString().Trim();
    }

    public string RegisterProvider(List<string> arguments)
    {
        var sb = new StringBuilder();
        try
        {
            var provider = providerFactory.CreateProvider(arguments);
            string type = arguments[0];
            this.providers.Add(provider);
            sb.AppendLine($"Successfully registered {type} Provider - {provider.Id}");
        }
        catch (ArgumentException ex)
        {
            sb.AppendLine($"Provider is not registered, because of it's {ex.Message}");
        }

        return sb.ToString().Trim();
    }

    public string Day()
    {
        var createdEnergy = this.providers.Sum(p => p.EnergyOutput);
        this.totalEnergy += createdEnergy;
        double neededEnergy = CalculateEnergyRequirement();
        double currentOre = 0;
        if (totalEnergy >= neededEnergy)
        {
            currentOre = StartMining();
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {createdEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {currentOre}");
        return sb.ToString().Trim();
    }

    private double StartMining()
    {
        double currentOre = 0;
        switch (mode)
        {
            case "Full":
                this.totalEnergy -= CalculateEnergyRequirement();
                currentOre = this.harvesters.Sum(p => p.OreOutput);
                break;
            case "Half":
                this.totalEnergy -= CalculateEnergyRequirement() * 0.6;
                currentOre = this.harvesters.Sum(p => p.OreOutput) * 0.5;
                break;
        }

        this.totalMinedOre += currentOre;
        return currentOre;
    }

    private double CalculateEnergyRequirement()
    {
        return this.harvesters.Sum(p => p.EnergyRequirement);
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        Worker worker = harvesters.FirstOrDefault(p => p.Id == id);
        if (worker == null)
        {
            worker = providers.FirstOrDefault(p => p.Id == id);
            if (worker == null)
            {
                return $"No element found with id - {id}";
            }
        }

        return worker.ToString();
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().Trim();
    }
}

