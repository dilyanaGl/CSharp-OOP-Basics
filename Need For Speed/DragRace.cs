public class DragRace : Race
{
    public DragRace(int length, string route, int prizepool) : base(length, route, prizepool)
    {
    }

    public override int CalculatePerformance(Car car)
    {
        return car.HorsePower / car.Acceleration;
    }
}

