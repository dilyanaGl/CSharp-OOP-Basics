public abstract class Bender
{
    protected string name;
    protected int power;

    public Bender(string name, int power)
    {
        this.name = name;
        this.power = power;
    }

    public abstract double GetPower();
    public override string ToString()
    {
        return "";
    }
}

