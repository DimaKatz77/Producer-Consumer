namespace ProducerConsumerDesignPattern.Interfaces
{
    public interface IStringOperation
    {
        string RemoveAllWhitespace(string source);
        string ToLower(string source);
        string ToUpper(string source);
    }
}
