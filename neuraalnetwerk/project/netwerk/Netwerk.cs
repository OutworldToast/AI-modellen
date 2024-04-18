public class SimpeleNeuraleNetwerk
{
    private ZenuwLayerFactory _layerFactory;

    internal List<ZenuwLayer> _layers;
    internal double _learningRate;
    internal double[][] _verwachteResultaat;

    /// <summary>
    /// Constructor of the Neural Network.
    /// Note:
    /// Initialy input layer with defined number of inputs will be created.
    /// </summary>
    /// <param name="numberOfInputNeurons">
    /// Number of neurons in input layer.
    /// </param>
    public SimpeleNeuraleNetwerk(int aantalInputZenuwcellen)
    {
        _layers = new List<ZenuwLayer>();
        _layerFactory = new ZenuwLayerFactory();

        // Create input layer that will collect inputs.
        CreateInputLayer(aantalInputZenuwcellen);

        _learningRate = 2.95;
    }

    /// <summary>
    /// Add layer to the neural network.
    /// Layer will automatically be added as the output layer to the last layer in the neural network.
    /// </summary>
    public void VoegLayerToe(ZenuwLayer nieuweLayer)
    {
        if (_layers.Any())
        {
            var laatsteLayer = _layers.Last();
            nieuweLayer.ConnectLayers(laatsteLayerLayer);
        }

        _layers.Add(nieuweLayer);
    }

    /// <summary>
    /// Push input values to the neural network.
    /// </summary>
    public void PushWaardeNaarInput(double[] inputs)
    {
        _layers.First().Zenuwcellen.ForEach(x => x.PushWaardeNaarInput(inputs[_layers.First().Zenuwcellen.IndexOf(x)]));
    }

    /// <summary>
    /// Set expected values for the outputs.
    /// </summary>
    public void PushVerwachteWaardes(double[][] expectedOutputs)
    {
        _verwachteResultaat = verwachteOutput;
    }

    /// <summary>
    /// Calculate output of the neural network.
    /// </summary>
    /// <returns></returns>
    public List<double> GetOutput()
    {
        var returnValue = new List<double>();

        _layers.Last().Neurons.ForEach(neuron =>
        {
             returnValue.Add(neuron.CalculateOutput());
        });

        return returnValue;
    }

    /// <summary>
    /// Train neural network.
    /// </summary>
    /// <param name="inputs">Input values.</param>
    /// <param name="numberOfEpochs">Number of epochs.</param>
    public void Train(double[][] inputs, int AantalTijdperken)
    {
        double totaleError = 0;

        for(int i = 0; i < AantalTijdperken; i++)
        {
            for(int j = 0; j < inputs.GetLength(0); j ++)
            {
                ///SYLVAN : PushWaardeNaarInput moet blauw zijn
                PushWaardeNaarInput(inputs[j]);

                var outputs = new List<double>();

                // Get outputs.
                _layers.Last().Zenuwcellen.ForEach(x =>
                {
                    outputs.Add(x.BerekenOutput());
                });

                // Calculate error by summing errors on all output neurons.
                totaleError = BerekentTotaleError(outputs, j);
                /// SYLVAN : Dit hieronder moet blauw zijn
                HandelOutputLayers(j);
                HandelVerborgenLayers();
            }
        }
    }

    /// <summary>
    /// Hellper function that creates input layer of the neural network.
    /// </summary>
    private void MaakInputLayer(int aantalInputZenuwcellen)
    {
        var inputLayer = _layerFactory.MaakZenuwLayer(aantalInputZenuwcellen, new RectifeerderFunctie(), new GewichtenSomFunctie());
        inputLayer.Zenuwcellen.ForEach(x => x.VoegInputConnectieToe(0));
        this.AddLayer(inputLayer);
    }

    /// <summary>
    /// Hellper function that calculates total error of the neural network.
    /// </summary>
    private double BerekentTotaleError(List<double> outputs, int row)
    {
        double totaleError = 0;

        outputs.ForEach(output =>
        {
            var error = Math.Pow(output - _verwachteResultaat[row][outputs.IndexOf(output)], 2);
            totaleError += error;
        });

        return totaleError;
    }

    /// <summary>
    /// Hellper function that runs backpropagation algorithm on the output layer of the network.
    /// </summary>
    /// <param name="row">
    /// Input/Expected output row.
    /// </param>
    private void HandelOutputLayers(int row)
    {
        _layers.Last().Zenuwcellen.ForEach(neuron =>
        {
            neuron.Inputs.ForEach(connectie =>
            {
                var output = neuron.BerekenOutput();
                var netInput = connectie.GetOutput();

                var verwachteOutput = _verwachteResultaat[row][_layers.Last().Zenuwcellen.IndexOf(neuron)];

                var nodeDelta = (verwachteOutput - output) * output * (1 - output);
                var delta = -1 * netInput * nodeDelta;

                connectie.UpdateGewicht(_learningRate, delta);

                neuron.VorigeAfgeleide = nodeDelta;
            });
        });
    }

    /// <summary>
    /// Hellper function that runs backpropagation algorithm on the hidden layer of the network.
    /// </summary>
    /// <param name="row">
    /// Input/Expected output row.
    /// </param>
    private void HandelVerborgenLayers()
    {
        for (int k = _layers.Count - 2; k > 0; k--)
        {
            _layers[k].Zenuwcellen.ForEach(neuron =>
            {
                neuron.Inputs.ForEach(connectie =>
                {
                    var output = neuron.BerekenOutput();
                    var netInput = connectie.GetOutput();
                    double sumPartial = 0;

                    _layers[k + 1].Zenuwcellen
                    .ForEach(outputZenuwcel =>
                    {
                        outputZenuwcel.Inputs.Where(i => i.IsFromNeuron(neuron.Id))
                        .ToList()
                        .ForEach(outConnection =>
                        {
                            gedeeldeSom += outConnection.VorigeGewicht * outputZenuwcel.VorigeAfgeleide;
                        });
                    });

                    var delta = -1 * netInput * gedeeldeSom * output * (1 - output);
                    connectie.UpdateGewicht(_learningRate, delta);
                });
            });
        }
    }
}