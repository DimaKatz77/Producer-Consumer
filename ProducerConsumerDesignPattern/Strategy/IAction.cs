

namespace ProducerConsumerDesignPattern.Strategy
{
    public interface IAction
    {
        Task Execute(string input);
    }
}
