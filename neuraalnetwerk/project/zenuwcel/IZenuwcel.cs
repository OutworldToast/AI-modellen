namespace Neuron;

using Connection;

public interface IZenuwcel{
    Guid Id { get; }
    double VorigeAfgeleide { get; set; }

    List<IConnectie> Inputs { get; set; }
    List<IConnectie> Outputs { get; set; }
    public double BerekenOutput();
    public void VoegInputZenuwcelToe(IZenuwcel zenuwcel);
    public void VoegOutputZenuwcelToe(IZenuwcel zenuwcel);
    public void VoegInputConnectieToe(IConnectie connectie);

    public void PushWaardeNaarInput(double inputwaarde);

}