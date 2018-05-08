
public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string type, string name, int affinity) : base(type, name, affinity)
    {
        this.airAffinity = affinity;
    }
}

