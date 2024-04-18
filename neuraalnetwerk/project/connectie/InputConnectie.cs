using Neuron;

namespace Connection;
public class InputConnectie : IConnectie{

    public IZenuwcel _outputZenuwcel;
    public double Output { get; set; }
    public double Gewicht { get; set; }
    public double VorigeGewicht { get; set; }

    public InputConnectie(IZenuwcel outputZenuwcel, double outputWaarde){
        _outputZenuwcel = outputZenuwcel;
        Output = outputWaarde;
        Gewicht = 1.0;
        VorigeGewicht = 1.0;
    }

    public double GetOutput(){
        return Output;
    }

    public bool IsVanZenuwcel(Guid VanZenuwcelID){
        return false;
    }
    public void UpdateGewicht(double leerCurve, double delta){
        throw new Exception("InputConnectie kan geen gewicht updaten");
    }

}