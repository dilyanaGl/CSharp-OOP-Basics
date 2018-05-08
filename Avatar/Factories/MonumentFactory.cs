public class MonumentFactory
{
    public Monument CreateMonument(string[] input)
    {
        string type = input[1];
        string name = input[2];
        int affinity = int.Parse(input[3]);

        switch (type)
        {
            case "Fire":
                return new FireMonument(type, name, affinity);
            case "Water":
                return new WaterMonument(type, name, affinity);
            case "Air":
                return new AirMonument(type, name, affinity);
            case "Earth":
                return new EarthMonument(type, name, affinity);
            default:
                return null;
        }
    }
}

