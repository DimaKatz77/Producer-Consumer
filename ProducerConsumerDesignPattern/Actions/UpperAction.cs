namespace ProducerConsumerDesignPattern.Actions
{
    public class UpperAction : BaseAction, IAction
    {

        public async Task Execute(string input)
        {
            Log(input.ToUpper());
        }
    }
}
