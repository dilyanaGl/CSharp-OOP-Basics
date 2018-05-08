using System;

public class Car
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;
    private const int maxCapacity = 160;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.hp = hp;
        this.tyre = tyre;
        FuelAmount = fuelAmount;
    }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            if (value > maxCapacity)
            {
                value = maxCapacity;
            }

            this.fuelAmount = value;
        }
    }

    public int Hp { get => this.hp; }

    public Tyre Tyre
    {
        get => this.tyre;
        private set => this.tyre = value;
    }

    public void Refuel(double liters)
    {
        this.FuelAmount += liters;
    }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void ReduceFuel(double fuelCosumption, int length)
    {
        this.FuelAmount -= (length * fuelCosumption);
    }
}

