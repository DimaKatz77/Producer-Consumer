
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
            bool flag = true;
            while (true)
            {
                if (token.IsCancellationRequested)
                    break;

                await _channel.Reader.WaitToReadAsync();
                {
                    T result;
                    _channel.Reader.TryRead(out result);

                    //After tests pls comment  next demonstration 2 Lines
                    if (result != null)
                           Console.WriteLine($"Read -----  {_operation(result)} - > ManagedThreadId {Thread.CurrentThread.ManagedThreadId}");

                }
            }
        }

        public void Produce<T1>(T1 value)
        {
            _channel.Writer.TryWrite(value as T);

            //After tests pls comment  Next demonstration Line
             Console.WriteLine($"Write ----- {value} - > ManagedThreadId {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
