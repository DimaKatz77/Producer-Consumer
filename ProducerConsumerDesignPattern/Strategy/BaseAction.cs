
using System.Runtime.CompilerServices;

namespace ProducerConsumerDesignPattern.Strategy
{
    public abstract class BaseAction
    {
        public void Log(string msg = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0) =>
Console.WriteLine($"Read Param] {msg}>>>>>>>>>>>>>>>>>>T{Thread.CurrentThread.ManagedThreadId} :: {memberName} L{lineNumber} ");
    }
}
