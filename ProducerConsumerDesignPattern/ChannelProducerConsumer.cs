
using ProducerConsumerDesignPattern.Interfaces;
using System;
using System.Threading.Channels;

namespace ProducerConsumerDesignPattern
{
    public class ChannelProducerConsumer<T> : IProducerConsumer where T : class
    {
        private Func<T, T> _operation;

        Channel<T> channel = Channel.CreateBounded<T>(1);

        public ChannelProducerConsumer(
            Func<T, T> operation,
            int messageLimit = 1)
        {
            _operation = operation;

            if (messageLimit > 1)
                channel = Channel.CreateBounded<T>(messageLimit);
        }

        public async Task ConsumeAsync<T1>()
        {
            while (true)
            {
                T result;
                await channel.Reader.WaitToReadAsync();
                {
                    if (channel.Reader.TryRead(out result))
                        if (result != null)
                        {
                            //Calculation Time
                            Thread.Sleep(500);

                            Console.WriteLine($"Read -----  {_operation(result)} - > ManagedThreadId {Thread.CurrentThread.ManagedThreadId}");
                        }
                }
            }
        }

        public async Task ProduceAsync<T1>(T1 value)
        {
            if (channel.Writer.TryWrite(value as T))
            {
                Console.WriteLine($"Write ----- {value} - > ManagedThreadId {Thread.CurrentThread.ManagedThreadId}");
            }
          
        }
    }
}
