public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizepool) : base(length, route, prizepool)
    {
    }

    public override int CalculatePerformance(Car car)
    {
        return (int)(car.HorsePower / car.Acceleration) + (car.Suspension + car.Durability);
    }
}

