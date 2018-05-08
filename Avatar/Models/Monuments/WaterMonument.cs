public class WaterMonument : Monument
{
    private int waterAffinity;
    
    public WaterMonument(string type, string name, int affinity) : base(type, name, affinity)
    {
        this.waterAffinity = affinity;
    }
}

