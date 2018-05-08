using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBender
{
    private static BenderFactory benderFactory = new BenderFactory();
    private static MonumentFactory monumentFactory = new MonumentFactory();
    private static List<string> warIssuers = new List<string>();

    private Dictionary<string, Nation> nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation("Air")},
            { "Fire", new Nation("Fire")},
            { "Water", new Nation("Water")},
            { "Earth", new Nation("Earth")}
        };

    public void AssignBender(string[] line)
    {
        var bender = benderFactory.CreateBender(line);
        nations[line[1]].benders.Add(bender);
    }

    public void AssignMonument(string[] line)
    {
        var monument = monumentFactory.CreateMonument(line);
        nations[line[1]].monuments.Add(monument);
    }

    public string GetStatus(string type)
    {
        return nations[type].ToString();
    }

    public void IssueWar(string nationsType)
    {
        warIssuers.Add(nationsType);
        Nation winner = nations.Values
            .OrderByDescending(p => p.CalculateTotalPower())
            .First();

        foreach (var n in nations)
        {
            if (!n.Value.Equals(winner))
            {
                n.Value.monuments.Clear();
                n.Value.benders.Clear();
            }
        }
    }

    public string GetWarsRecord()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < warIssuers.Count; i++)
        {
            sb.AppendLine($"War {i + 1} issued by {warIssuers[i]}");
        }

        return sb.ToString().Trim();
    }
}

