public abstract class Monument
{
    protected string name;
    public int affinity;
    private string type;

    public Monument(string type, string name, int affinity)
    {
        this.name = name;
        this.affinity = affinity;
        this.type = type;
    }

    public override string ToString()
    {
        return $"{type} Monument: {name}, {type} Affinity: {affinity}";
    }
}

