using System.Collections.Generic;

public class Garage
{
    private List<Car> parkedCars;

    public Garage()
    {
        this.parkedCars = new List<Car>();
    }

    public void ParkCar(Car car)
    {
        parkedCars.Add(car);
    }

    public void UnparkCar(Car car)
    {
        parkedCars.Remove(car);
    }

    public bool IsCarThere(Car car)
    {
        return parkedCars.Contains(car);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        this.parkedCars.ForEach(p => p.Tune(tuneIndex, addOn));
    }
}

