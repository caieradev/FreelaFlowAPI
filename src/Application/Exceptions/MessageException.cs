namespace FreelaFlowApi.Application.Exceptions;
public class MessageException : Exception
{
    public MessageException(string message) : base(message) { }
    public MessageException(string message, System.Exception inner) : base(message, inner) { }
}