namespace FreelaFlowApi.Application.Exceptions;
public class DebugMessageException : Exception
{
    public string DebugMessage { get; set; }
    public DebugMessageException(string debugMessage) => this.DebugMessage = debugMessage;
    public DebugMessageException(string debugMessage, string message) : base(message) => this.DebugMessage = debugMessage;
}