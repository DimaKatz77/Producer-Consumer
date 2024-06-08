
namespace ProducerConsumerDesignPattern.Interfaces
{
    public interface IProducerConsumer
    {
        Task ProduceAsync<T>(T value);
        Task ConsumeAsync<T>();
    }
}
