using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    private int goldTime;
    private List<string> medal = new List<string>()
        { "Gold", "Silver", "Bronze"};

    public TimeLimitRace(int length, string route, int prizepool, int goldTime) : base(length, route, prizepool)
    {
        this.goldTime = goldTime;
    }

    public override int CalculatePerformance(Car car)
    {
        return this.length * ((car.HorsePower / 100) * car.Acceleration);
    }

    public override string Start()
    {
        Car car = this.participants.First();
        var sb = new StringBuilder();
        sb.AppendLine($"{route} - {length}");
        int[] prizes = new[] { prizepool, (prizepool * 50) / 100, (prizepool * 30) / 100 };
        int index = 2;
        int time = CalculatePerformance(car);
        if (time <= goldTime)
        {
            index = 0;
        }
        else if (time <= goldTime + 15)
        {
            index = 1;
        }

        sb.AppendLine($"{car.DisplayWinner()} - {time} s.")
            .AppendLine($"{medal[index]} Time, ${ prizes[index]}.");

        return sb.ToString().Trim();
    }
}

