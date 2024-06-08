
namespace ProducerConsumerDesignPattern.Interfaces
{
    public interface IProducerConsumer
    {
        void Produce<T>(T value);
        Task ConsumeAsync<T>(CancellationToken token);
    }
}
