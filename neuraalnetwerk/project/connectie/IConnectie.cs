namespace Connection;
public interface IConnectie{

    public double Gewicht { get; set; }
    public double VorigeGewicht { get; set; }
    public double GetOutput();

    public bool IsVanZenuwcel(Guid VanZenuwcelID);
    public void UpdateGewicht(double leerCurve, double delta);

}