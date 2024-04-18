using Functions;

namespace Functies;

public class SigmoidFunctie : IActivatieFunctie
{
    private double _coeficient;

    public SigmoidFunctie(double coeficient)
    {
        _coeficient = coeficient;
    }

    public double BerekenOutput(double input)
    {
        return 1 / (1 + Math.Exp(-input * _coeficient));
    }
}