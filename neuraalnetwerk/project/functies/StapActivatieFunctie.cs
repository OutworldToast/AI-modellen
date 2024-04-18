using Functions;
namespace Functies;

public class StapActivatieFunctie : IActivatieFunctie{
    private double _drempel;

    public StapActivatieFunctie(double drempel)
    {
        _drempel = drempel;
    }

    public double BerekenOutput(double input)
    {
        return Convert.ToDouble(input > _drempel);
    }
}