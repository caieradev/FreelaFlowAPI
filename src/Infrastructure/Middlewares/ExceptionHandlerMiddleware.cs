using System.Text.Json;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Exceptions;
using FreelaFlowApi.Application.Extensions;

namespace FreelaFlowApi.Infrastructure.Middlewares;
public class ExceptionHandlerMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context) {
        try 
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            switch (ex) {
                case MessageException:
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new ResponseDTO 
                        { 
                            displayMessage = ex.Message, 
                            debugMessage = $"{ex.GetCompleteMessage()} -- {ex.StackTrace}" 
                        }));
                    break;
                default:
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new ResponseDTO 
                        {
                            displayMessage = "Desculpe, ocorreu um problema com a sua solicitação, tente novamente mais tarde",
                            debugMessage = $"{(ex is DebugMessageException exception ? (exception.DebugMessage + " -- ") : String.Empty)}{ex.GetCompleteMessage()} -- {ex.StackTrace}"
                        }));
                    break;
            }
        }
    }

}