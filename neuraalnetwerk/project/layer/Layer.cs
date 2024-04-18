namespace NeuralLayer;

using Neuron;

public class Layer{
    public List<IZenuwcel> Zenuwcellen;

    public Layer()
    {
        Zenuwcellen = new List<IZenuwcel>();
    }

    public void ConnectLayers(Layer inputLayer)
    {
        var combos = Zenuwcellen.SelectMany(neuron => inputLayer.Zenuwcellen, (neuron, input) => new { neuron, input });
        combos.ToList().ForEach(x => x.neuron.voegInputZenuwcelToe(x.input));
    }
}
