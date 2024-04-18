namespace Functions;

using Connection;

public class GewichtenSomFunctie : IInputFunctie{
    public double BerekenInput(List<IConnectie> inputs) {
        return inputs.Select(x => x.Gewicht * x.GetOutput()).Sum();
    }
}