
using ProducerConsumerDesignPattern;
using System.Text;
using System;
using System.Runtime.CompilerServices;

public class Programm
{
    static async Task Main(string[] args)
    {
        int workers = 3;

        var _producerConsumer = new ChannelProducerConsumer<string>(new StringOperation().ToUpper, 1);

        var cancelTokenSource = new CancellationTokenSource();

        var token = cancelTokenSource.Token;

        // Run Consumer Tasks
        async Task RunConsumer()
        {
            await _producerConsumer.ConsumeAsync<string>(token);
        }
        Enumerable.Range(0, workers).Select(_ => RunConsumer()).ToArray();


        // Run Produce Threads
        async Task RunProduce()
        {
            while (true)
            {
               await Task.Delay(100);

               _producerConsumer.Produce(RandomString(50));
            }
        }
        Enumerable.Range(0, 1).Select(_ => RunProduce()).ToArray();


        //Stop after 20 seconds
        await Task.Delay(20000);

        cancelTokenSource.Cancel();

        cancelTokenSource.Dispose();
    }

    private static string RandomString(int length)
    {
        Random random = new Random();

        const string pool = "abcdefghijklmnopqrstuvwxyz0123456789 ";

        var chars = Enumerable.Range(0, length)
            .Select(x => pool[random.Next(0, pool.Length)]);

        return new string(chars.ToArray());
    }




}



