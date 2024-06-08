
using ProducerConsumerDesignPattern;
using System.Text;
using System;

public class Programm
{
    static async Task Main(string[] args)
    {

        var _producerConsumer = new ChannelProducerConsumer<string>(new StringOperation().ToUpper, 1);

        // Run Consumer Threads
        async Task RunConsumer()
        {
            await _producerConsumer.ConsumeAsync<string>();
        }
        Enumerable.Range(0, 10).Select(_ => RunConsumer()).ToArray();


        // Run Produce Threads
        async Task RunProduce()
        {
            while (true)
            {
                Thread.Sleep(100);
               await _producerConsumer.ProduceAsync(RandomString(50));
            }
        }
        Enumerable.Range(0, 1).Select(_ => RunProduce()).ToArray();
       

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



