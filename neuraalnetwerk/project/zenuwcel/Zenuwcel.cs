namespace Neuron;

using Connection;

public class Zenuwcel : IZenuwcel{

    
    public Guid Id { get; }
    public double VorigeAfgeleide { get; set; }

    public List<IZenuwcel> Inputs { get; set; }
    public List<IZenuwcel> Outputs { get; set; }
    public double BerekenOutput(){
        return 0.0;
    }
    public void voegInputZenuwcelToe(IZenuwcel zenuwcel){

    }
    public void VoegOutputZenuwcelToe(IConnectie connectie){

    }
    public void VoegInputConnectieToe(IConnectie connectie){

    }

    public void PushWaardeNaarInput(double inputwaarde){

    }
}