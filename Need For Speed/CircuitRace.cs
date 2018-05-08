using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

public class CircuitRace : Race
{
    private int laps;

    public CircuitRace(int length, string route, int prizepool, int laps) : base(length, route, prizepool)
    {
        this.laps = laps;
    }

    public int Laps { get => this.laps; }

    public override int CalculatePerformance(Car car)
    {
       return (car.HorsePower / car.Acceleration) + (car.Suspension + car.Durability);;
    }

    public override string Start()
    {
        this.participants.ForEach(p => p.ReduceDurability(this));
        List<Car> winners = this.participants.OrderByDescending(p => CalculatePerformance(p)).Take(4).ToList();
        var sb = new StringBuilder();
        sb.AppendLine($"{route} - {length * laps}");
        int[] prizes = new[] { (this.prizepool * 40) / 100, (this.prizepool * 30) / 100, (this.prizepool * 20) / 100, (this.prizepool * 10) / 100 };

        for (int i = 0; i < winners.Count; i++)
        {
            sb.AppendLine($"{i + 1}. {winners[i].DisplayWinner()} {CalculatePerformance(winners[i])}PP - ${prizes[i]}");
        }

        return sb.ToString().Trim();
    }
}

