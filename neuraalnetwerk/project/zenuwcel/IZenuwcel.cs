namespace Neuron;

using Connection;

public interface IZenuwcel{
    Guid Id { get; }
    double VorigeAfgeleide { get; set; }

    List<IZenuwcel> Inputs { get; set; }
    List<IZenuwcel> Outputs { get; set; }
    public double BerekenOutput();
    public void voegInputZenuwcelToe(IZenuwcel zenuwcel);
    public void VoegOutputZenuwcelToe(IConnectie connectie);
    public void VoegInputConnectieToe(IConnectie connectie);

    public void PushWaardeNaarInput(double inputwaarde);

}