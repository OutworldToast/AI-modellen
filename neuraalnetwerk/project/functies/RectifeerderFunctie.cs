using Functions;

public class RectifeerderFunctie : IActivatieFunctie
{
    public double BerekenOutput(double input)
    {
        return Math.Max(0, input);
    }
}