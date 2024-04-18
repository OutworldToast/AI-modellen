
using Neuron;

namespace Connection;
public class Connectie : IConnectie{

    internal IZenuwcel _inputZenuwcel;
    internal IZenuwcel _outputZenuwcel;

    public double Gewicht { get; set; }
    public double VorigeGewicht { get; set; }

    public Connectie(IZenuwcel inputZenuwcel, IZenuwcel outputZenuwcel, double gewicht){
        _inputZenuwcel = inputZenuwcel;
        _outputZenuwcel = outputZenuwcel;   
         
        Gewicht = gewicht;
        VorigeGewicht = 0;
    }
    public Connectie(IZenuwcel inputZenuwcel, IZenuwcel outputZenuwcel){
        _inputZenuwcel = inputZenuwcel;
        _outputZenuwcel = outputZenuwcel;    

        var random = new Random();
        Gewicht = random.NextDouble();
        VorigeGewicht = 0;
    }

    public double GetOutput(){
        return 0.0;
    }

    public bool IsVanZenuwcel(Guid VanZenuwcelID){
        return false;
    }
    public void UpdateGewicht(double leerCurve, double delta){
    
    }

}