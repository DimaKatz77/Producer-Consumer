namespace ProducerConsumerDesignPattern.Actions
{
    public abstract class BaseAction
    {
        public void Log(string msg = "") =>
            Console.WriteLine($"Log operation - {msg} >> T({Thread.CurrentThread.ManagedThreadId})");
    }
}
