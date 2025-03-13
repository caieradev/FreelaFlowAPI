namespace FreelaFlowApi.Application.Extensions;
public static class ExceptionExtensions
{
    public static string GetCompleteMessage(this Exception ex) =>
        $"{ex.Message}{ex.AddInnerMessages()}";

    private static string AddInnerMessages(this Exception ex) =>
        ex.InnerException != null ?
            $" -> {ex.InnerException.Message}{ex.InnerException.AddInnerMessages()}" : String.Empty;
}