using System;

public class UltrasoftTyre : Tyre
{
    private double grip;
    private double degradation;

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.grip = grip;
    }

    public override double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }

            this.degradation = value;
        }
    }

    public double Grip { get => this.grip; private set => this.grip = value; }

    public override string Name => "Ultrasoft";

    public override void ReduceDegradation()
    {
        this.Degradation -= (this.Hardness + this.grip);
    }
}

