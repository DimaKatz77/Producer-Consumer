
using ProducerConsumerDesignPattern;
using ProducerConsumerDesignPattern.Common;
using ProducerConsumerDesignPattern.Strategy;

public class Programm
{
    private ProducerConsumerBaseSettings _programParams;
    static async Task Main(string[] args)
    {
        //Init Program settings. You can to change it .
        ProducerConsumerBaseSettings _settings = new ProducerConsumerBaseSettings
        {
            Action = new MirrorAction(),//Can to change (LowerAction, UpperAction, MirrorAction)
            ChannelSize = 2,
            ConsumersCount = 3,
            ProducersCount = 1,
            WorkingTimeInSeconds = 30
        };

        //Init Class
        var _producerConsumer = new ChannelProducerConsumer(_settings.Action, _settings.ChannelSize);

        //Init CancellationToken
        var cancelTokenSource = new CancellationTokenSource();
        var token = cancelTokenSource.Token;

        // Run Consumer Tasks
        async Task RunConsumer()
        {
            await _producerConsumer.ConsumeAsync(token);
        }
        Enumerable.Range(0, _settings.ConsumersCount).Select(_ => RunConsumer()).ToArray();


        // Run Produce Tasks
        async Task RunProduce()
        {
            //The While loop created for non stop Produce Action
            while (true)
            {
               await Task.Delay(100);

               _producerConsumer.Produce(HelperMethods.RandomString(50));
            }
        }
        Enumerable.Range(0, _settings.ProducersCount).Select(_ => RunProduce()).ToArray();


        //Stop after 20 seconds
        await Task.Delay(_settings.WorkingTimeInSeconds * 1000);

        cancelTokenSource.Cancel();

        cancelTokenSource.Dispose();
    }




}



