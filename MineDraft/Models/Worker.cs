public abstract class Worker
{
    private string id;

    protected Worker(string id)
    {
        Id = id;
    }

    public string Id { get => this.id; private set => this.id = value; }

    public override string ToString()
    {
        return base.ToString();
    }
}
