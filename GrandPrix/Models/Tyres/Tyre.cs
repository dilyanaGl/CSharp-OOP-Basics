using System;
using System.Security;

public abstract class Tyre
{
    private double degradation;
    private double hardness;
    private string name;

    protected Tyre(double hardness)
    {
        this.hardness = hardness;
        this.Degradation = 100;
    }

    public abstract string Name { get; }

    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public double Hardness
    {
        get => this.hardness;
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}

