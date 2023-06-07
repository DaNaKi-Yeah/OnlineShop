using Microsoft.AspNetCore.Diagnostics;
using OnlineShop.API.Responses;
using System.Net;

namespace OnlineShop.API.Middlewares
{
    public static class ContainerExtentions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    //using IServiceScope scopeService = app.ApplicationServices.CreateScope();
                    //ILogger? logger = scopeService?.ServiceProvider?.GetService<ILogger>();
                    //logger?.LogError(contextFeature?.Error.Message);

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    if (contextFeature != null)
                    {
                        await context.Response
                            .WriteAsync(new BaseResponse(
                                context.Response.StatusCode,
                                contextFeature.Error.Message,
                                false)
                            .ToString());
                    }
                });
            });
        }
    }
}
