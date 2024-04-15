namespace Neuron;

using Connection;

public interface IZenuwcel{
    public double BerekenOutput();
    public void voegInputZenuwcelToe(IZenuwcel zenuwcel);
    public void VoegOutputConnectieToe(IConnectie connectie);
    public void VoegInputConnectieToe(IConnectie connectie);
}