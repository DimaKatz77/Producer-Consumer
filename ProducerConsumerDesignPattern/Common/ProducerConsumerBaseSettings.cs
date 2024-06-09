using ProducerConsumerDesignPattern.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerConsumerDesignPattern.Common
{
    public class ProducerConsumerBaseSettings
    {
        public int ConsumersCount { get; set; } = 3;
        public int ProducersCount { get; set; } = 1;
        public int ChannelSize { get; set; } = 2; //(Queue maximum Size)
        public int WorkingTimeInSeconds { get; set; } = 20;
        public IAction Action { get; set; } = new LowerAction();

    }
}
