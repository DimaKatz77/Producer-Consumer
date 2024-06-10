
using ProducerConsumerDesignPattern.Actions;
using ProducerConsumerDesignPattern.Interfaces;
using System.Reflection.PortableExecutable;
using System.Threading.Channels;

namespace ProducerConsumerDesignPattern
{
    public class ChannelProducerConsumer : IProducerConsumer
    {
        private IAction _action;

        private Channel<string> _channel = Channel.CreateBounded<string>(1);

        public ChannelProducerConsumer(IAction action, int messageLimit = 1)
        {
            _action = action;

            if (messageLimit > 1)
                _channel = Channel.CreateBounded<string>(messageLimit);
        }

        public async Task ConsumeAsync(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                    break;

                await _channel.Reader.WaitToReadAsync();
                {
                    while (_channel.Reader.TryRead(out string result))
                    {
                        await _action.Execute(result);
                    }
                }
            }
        }

        public void Produce(string value)
        {

            if (_channel.Writer.TryWrite(value))
            {
                //After tests pls comment  Next demonstration Line
                Console.WriteLine($"Insert Message To Channel > ----- {value} - > ManagedThreadId {Thread.CurrentThread.ManagedThreadId}");

            }

        }
    }
}
