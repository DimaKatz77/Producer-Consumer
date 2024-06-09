
using ProducerConsumerDesignPattern;
using ProducerConsumerDesignPattern.Common;
using ProducerConsumerDesignPattern.Strategy;

public class Programm
{
    static async Task Main(string[] args)
    {
        //Init Program settings. You can to change it .
        ProducerConsumerBaseSettings _settings = new ProducerConsumerBaseSettings
        {
            Action = new UpperAction(),//Can to change (LowerAction, UpperAction, MirrorAction)
            ChannelSize = 1,
            ConsumersCount = 3,
            ProducersCount = 1,
            WorkingTimeInSeconds = 10
        };

        //Init Class
        var _producerConsumer = new ChannelProducerConsumer(_settings.Action, _settings.ChannelSize);

        //Init Cancellation Token
        var cancelTokenSource = new CancellationTokenSource();
        var token = cancelTokenSource.Token;

        // Run Consumer Tasks
        async Task RunConsumer()
        {
            await _producerConsumer.ConsumeAsync(token);
        }
        Enumerable.Range(0, _settings.ConsumersCount).Select(_ => RunConsumer()).ToArray();


        // Run Produce Tasks //Add CancellationToken to not Insert new messages after stop of Consumers
        async Task RunProduce(CancellationToken token)
        {
            //The While loop created for non stop Produce Action
            while (true)
            {
                if (token.IsCancellationRequested)
                    break;
                await Task.Delay(100);

                _producerConsumer.Produce(HelperMethods.RandomString(50));
            }
        }
        Enumerable.Range(0, _settings.ProducersCount).Select(_ => RunProduce(token)).ToArray();


        //Stop after 20 seconds
        await Task.Delay(_settings.WorkingTimeInSeconds * 1000);

        cancelTokenSource.Cancel();

        cancelTokenSource.Dispose();

        Console.ReadLine();
    }




}



