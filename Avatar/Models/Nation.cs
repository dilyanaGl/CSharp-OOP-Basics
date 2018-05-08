using System.Collections.Generic;
using System.Linq;
using System.Text;

class Nation
{
    private List<string> typeList = new List<string>() { "Fire", "Air", "Earth", "Water" };

    public List<Bender> benders;
    public List<Monument> monuments;
    private string type;

    public Nation(string type)
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
        this.type = type;
    }

    public double CalculateTotalPower()
    {
        double sum = this.benders.Sum(p => p.GetPower());
        double affinity = this.monuments.Sum(p => p.affinity);
        return sum + (sum / 100) * affinity;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{type} Nation");

        if (this.benders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
            this.benders.ForEach(p => sb.AppendLine($"###{p.ToString()}"));
        }

        if (this.monuments.Count == 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            this.monuments.ForEach(p => sb.AppendLine($"###{p.ToString()}"));
        }

        return sb.ToString().Trim();
    }
}

