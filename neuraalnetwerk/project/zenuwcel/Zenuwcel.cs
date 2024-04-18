namespace Neuron;

using Connection;
using Functions;

public class Zenuwcel : IZenuwcel{

    private IActivatieFunctie _activatieFunctie;
    private IInputFunctie _inputFunctie;
    
    public Guid Id { get; }
    public double VorigeAfgeleide { get; set; }

    public List<IConnectie> Inputs { get; set; }
    public List<IConnectie> Outputs { get; set; }

    public Zenuwcel(IActivatieFunctie activatieFunctie, IInputFunctie inputFunctie){
        Id = Guid.NewGuid();
        Inputs = new List<IConnectie>();
        Outputs = new List<IConnectie>();

        _activatieFunctie = activatieFunctie;
        _inputFunctie = inputFunctie;
    }


    public double BerekenOutput(){
        return 0.0;
    }
    public void VoegInputZenuwcelToe(IZenuwcel inputZenuwcel){
        var connectie = new Connectie(inputZenuwcel, this);
        Inputs.Add(connectie);
        inputZenuwcel.Outputs.Add(connectie);
    }

    public void VoegOutputZenuwcelToe(IZenuwcel outputZenuwcel){
        var connectie = new Connectie(this, outputZenuwcel);
        Outputs.Add(connectie);
        outputZenuwcel.Inputs.Add(connectie);
    }
    public void VoegInputConnectieToe(IConnectie connectie){

    }

    public void PushWaardeNaarInput(double inputwaarde){

    }
}