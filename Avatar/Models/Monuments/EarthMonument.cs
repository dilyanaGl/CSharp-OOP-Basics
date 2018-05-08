public class EarthMonument : Monument
{
    private int earthAffinity;
    
    public EarthMonument(string type, string name, int affinity) : base(type, name, affinity)
    {
        this.earthAffinity = affinity;
    }
}

