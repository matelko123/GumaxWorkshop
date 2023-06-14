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

                switch (contextFeature.Error)
                {
                    case ValidationException exception:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.Response.WriteAsJsonAsync(exception.Failures);
                        break;
                    
                    case NotFoundException exception:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await context.Response.WriteAsync(JsonSerializer.Serialize(exception.Message));
                        break;
                    
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var errorMessage = contextFeature.Error.GetBaseException().Message;
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorMessage));
                        break;
                }
                
            });
        });
        return app;
    }
}