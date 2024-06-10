using System.Text;

namespace ProducerConsumerDesignPattern.Actions
{
    public class MirrorAction : BaseAction, IAction
    {
        public async Task Execute(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }
            Log(sb.ToString());
        }
    }
}
