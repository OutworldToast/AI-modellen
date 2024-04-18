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
        return _activatieFunctie.BerekenOutput(_inputFunctie.BerekenInput(Inputs));
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
    public void VoegInputConnectieToe(double inputWaarde){
        var inputConnectie = new InputConnectie(this, inputWaarde);
        Inputs.Add(inputConnectie);
    }

    public void PushWaardeNaarInput(double inputWaarde){
        ((InputConnectie)Inputs.First()).Output = inputWaarde;
    }
}