using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerDesignPattern.Strategy
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
