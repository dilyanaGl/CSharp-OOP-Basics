using System;
using System.Collections.Generic;

public class PerformanceCar : Car
{
    private List<string> addOns;
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.addOns = new List<string>();
        this.HorsePower += (int)(50 * HorsePower) / 100;
        this.Suspension -= (int)(25 * base.Suspension) / 100;
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.addOns.Add(addOn);
    }

    public override string ToString()
    {
        if (this.addOns.Count == 0)
        {
            return base.ToString() + Environment.NewLine + "Add-ons: None";
        }
        else
        {
            return base.ToString() + Environment.NewLine + String.Format("Add-ons: {0}", string.Join(", ", this.addOns));
        }
    }
}

