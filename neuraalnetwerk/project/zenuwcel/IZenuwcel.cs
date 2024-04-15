namespace Zenuwcel;

using Connectie;

public interface IZenuwcel{
    double BerekenOutput();
    void voegInputZenuwcelToe(IZenuwcel zenuwcel);
    void VoegOutputConnectieToe(IConnectie connectie);
    void VoegInputConnectieToe(IConnectie connectie);
}