using System;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.brand = brand;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.HorsePower = horsepower;
        this.acceleration = acceleration;
        this.Suspension = suspension;
        this.durability = durability;
    }

    public int HorsePower { get => this.horsepower; protected set => this.horsepower = value; }
    public int Suspension { get => this.suspension; protected set => this.suspension = value; }
    public int Acceleration { get => this.acceleration; }
    public int Durability { get => this.durability; private set => this.durability = value; }

    public override string ToString()
    {
        return $"{this.brand} {this.model} {this.yearOfProduction}{Environment.NewLine}" +
               $"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s{Environment.NewLine}" +
               $"{this.Suspension} Suspension force, {this.Durability} Durability";
    }

    public string DisplayWinner()
    {
        return $"{this.brand} {this.model}";
    }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += (50 * tuneIndex) / 100;
    }

    public void ReduceDurability(CircuitRace race)
    {
        for (int i = 0; i < race.Laps; i++)
        {
            this.Durability -= (race.Length * race.Length);
        }
    }
}
