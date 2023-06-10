using System.Net;
using System.Text.Json;
using GumaxWorkshop.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace GumaxWorkshop.API.Extensions;

public static class ErrorHandlerExtension
{
    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature == null) return;
                
                context.Response.StatusCode = contextFeature.Error switch
                {
                    ValidationException => (int) HttpStatusCode.BadRequest,
                    OperationCanceledException => (int) HttpStatusCode.ServiceUnavailable,
                    _ => (int) HttpStatusCode.InternalServerError
                };

                var errorResponse = new
                {
                    statusCode = context.Response.StatusCode,
                    message = contextFeature.Error.GetBaseException().Message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
        return app;
    }
}