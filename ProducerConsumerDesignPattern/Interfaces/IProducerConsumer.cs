
namespace ProducerConsumerDesignPattern.Interfaces
{
    public interface IProducerConsumer
    {
        void Produce(string value);

        Task ConsumeAsync(CancellationToken token);
    }
}
