using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    protected readonly int length;

    protected readonly string route;

    protected readonly int prizepool;

    protected List<Car> participants;

    protected Race(int length, string route, int prizepool)
    {
        this.length = length;
        this.route = route;
        this.prizepool = prizepool;
        this.participants = new List<Car>();
    }

    public int Length { get => this.length; }

    public void AddParticipant(Car car)
    {
        this.participants.Add(car);
    }

    public bool IsCarAParticipant(Car car)
    {
        return this.participants.Contains(car);
    }

    public bool CheckParticipants()
    {
        return this.participants.Count > 0;
    }

    public void ClearParticipants()
    {
        this.participants.Clear();
    }

    public  virtual string Start()
    {
       List<Car> winners = this.participants.OrderByDescending(p => CalculatePerformance(p)).Take(3).ToList();
        var sb = new StringBuilder();
        sb.AppendLine($"{route} - {length}");
        int[] prizes = new[] { (this.prizepool * 50) / 100, (this.prizepool * 30) / 100, (this.prizepool* 20) / 100 };
   
        for (int i = 0; i < winners.Count; i++)
        {
           sb.AppendLine($"{i + 1}. {winners[i].DisplayWinner()} {CalculatePerformance(winners[i])}PP - ${prizes[i]}"); 
        }
         
        return sb.ToString().Trim();
    }

    public abstract int CalculatePerformance(Car car);
}

