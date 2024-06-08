
using ProducerConsumerDesignPattern.Interfaces;
using System.Threading.Channels;

namespace ProducerConsumerDesignPattern
{
    public class ChannelProducerConsumer<T> : IProducerConsumer where T : class
    {
        private Func<T, T> _operation;

        private Channel<T> _channel = Channel.CreateBounded<T>(1);

        public ChannelProducerConsumer(
            Func<T, T> operation,
            int messageLimit = 1)
        {
            _operation = operation;

            if (messageLimit > 1)
                _channel = Channel.CreateBounded<T>(messageLimit);
        }

        public async Task ConsumeAsync<T1>(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                T result;
                await _channel.Reader.WaitToReadAsync();
                {
                    if (_channel.Reader.TryRead(out result))

                        if (result != null)
                            Console.WriteLine($"Read -----  {_operation(result)} - > ManagedThreadId {Thread.CurrentThread.ManagedThreadId}");

                }
            }
        }

        public void Produce<T1>(T1 value)
        {
            if (_channel.Writer.TryWrite(value as T))
                Console.WriteLine($"Write ----- {value} - > ManagedThreadId {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
