namespace ProducerConsumerDesignPattern.Actions
{
    public interface IAction
    {
        Task Execute(string input);
    }
}
