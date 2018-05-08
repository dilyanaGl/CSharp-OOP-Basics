 public abstract class Driver
 {
    private string name;
    private Car car;
     private double fuelCosumptioPerKm;
    double totalTime;

    protected Driver(string name, Car car, double fuelCosumptioPerKm)
    {
        this.name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelCosumptioPerKm;
        this.TotalTime = 0;
    }

    public double TotalTime { get => this.totalTime; set => this.totalTime = value; }

     public double FuelConsumptionPerKm { get => this.fuelCosumptioPerKm;
         protected set => this.fuelCosumptioPerKm = value; }

     public string Name { get => this.name; private set => this.name = value; }

     public Car Car { get => this.car; private set => this.car = value; }

    public virtual double Speed { get => (car.Hp + car.Tyre.Degradation) / car.FuelAmount; }

     public void ReduceFuel(int length)
     {
         this.Car.ReduceFuel(this.fuelCosumptioPerKm, length);
     }
}

