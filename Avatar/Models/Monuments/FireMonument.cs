public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string type, string name, int affinity) : base(type, name, affinity)
    {
        this.fireAffinity = affinity;
    }
}

