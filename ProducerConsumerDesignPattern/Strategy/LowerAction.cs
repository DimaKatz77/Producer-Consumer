

namespace ProducerConsumerDesignPattern.Strategy
{
    public class LowerAction : BaseAction, IAction
    {

        public async Task Execute(string input)
        {
            Log(input.ToLower());
        }
    }
}
