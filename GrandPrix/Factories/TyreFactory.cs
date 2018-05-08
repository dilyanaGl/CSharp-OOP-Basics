public class TyreFactory
{
    public Tyre CreateTyre(string type, string[] arr)
    {
        switch (type)
        {
            case "Hard":
                return new HardTyre(double.Parse(arr[0]));
            case "Ultrasoft":
                return new UltrasoftTyre(double.Parse(arr[0]), double.Parse(arr[1]));
            default:
                return null;
        }
    }
}

