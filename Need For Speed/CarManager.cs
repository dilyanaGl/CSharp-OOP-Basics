using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private CarFactory carFactory;
    private RaceFactory raceFactory;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.carFactory = new CarFactory();
        this.raceFactory = new RaceFactory();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction,
        int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = carFactory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        if (car != null)
        {
            cars.Add(id, car);
        }
    }

    public string Check(int id)
    {
        if (cars.ContainsKey(id))
        {
            Car car = cars[id];
            return car.ToString();
        }

        return "";
    }

    public void Open(List<string> line)
    {
        var race = raceFactory.CreateRace(line.Skip(1).ToList());
        if (race != null)
        {
            int id = int.Parse(line[0]);
            races.Add(id, race);
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (cars.ContainsKey(carId) && races.ContainsKey(raceId))
        {
            var car = cars[carId];
            var race = races[raceId];
            if (!garage.IsCarThere(car))
            {
                race.AddParticipant(car);
            }
        }
    }

    public string Start(int id)
    {
        var race = races[id];

        if (race.CheckParticipants())
        {
            string result = race.Start();
            races.Remove(id);
            return result;
        }

        return "Cannot start the race with zero participants.";
    }

    public void Park(int id)
    {
        if (cars.ContainsKey(id))
        {
            var car = cars[id];

            if (!CheckIfCarIsParticipant(car))
            {
                garage.ParkCar(car);
            }
        }
    }

    private bool CheckIfCarIsParticipant(Car car)
    {
        foreach (var race in races)
        {
            if (race.Value.IsCarAParticipant(car))
            {
                return true;
            }
        }

        return false;
    }

    public void Unpark(int id)
    {
        garage.UnparkCar(cars[id]);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        garage.Tune(tuneIndex, addOn);
    }
}

