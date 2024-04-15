
namespace Connection;
public class Connectie : IConnectie{
    public Connectie(){
    
        
    }

    public double Gewicht { get; set; }
    public double VorigeGewicht { get; set; }

    public double GetOutput(){
        return 0.0;
    }

    public bool IsVanZenuwcel(Guid VanZenuwcelID){
        return false;
    }
    public void UpdateGewicht(double leerCurve, double delta){
    
    }

}