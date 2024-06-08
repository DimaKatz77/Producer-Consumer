using ProducerConsumerDesignPattern.Interfaces;

namespace ProducerConsumerDesignPattern
{
    public class StringOperation : IStringOperation
    {
        public string RemoveAllWhitespace(string source)
        {
            return source.Replace(" ","");
        }

        public string ToLower(string source)
        {
            return source.ToLower();
        }

        public string ToUpper(string source)
        {
            return source.ToUpper();
        }
    }
}
