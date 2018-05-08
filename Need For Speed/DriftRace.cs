 
public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizepool) : base(length, route, prizepool)
    {
    }

    public override int CalculatePerformance(Car car)
    {
        return car.Suspension + car.Durability;
    }
}

