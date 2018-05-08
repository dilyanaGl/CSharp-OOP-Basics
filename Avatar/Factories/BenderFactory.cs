public class BenderFactory
{
    public Bender CreateBender(string[] input)
    {
        string type = input[1];
        string name = input[2];
        int power = int.Parse(input[3]);
        double aerial = double.Parse(input[4]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, aerial);
            case "Water":
                return new WaterBender(name, power, aerial);
            case "Earth":
                return new EarthBender(name, power, aerial);
            case "Fire":
                return new FireBender(name, power, aerial);
            default:
                return null;
        }
    }
}
