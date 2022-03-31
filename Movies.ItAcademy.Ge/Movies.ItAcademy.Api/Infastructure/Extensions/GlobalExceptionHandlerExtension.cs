using Microsoft.AspNetCore.Builder;
using Movies.ItAcademy.Api.Infastructure.Middlwares;

namespace Movies.ItAcademy.Api.Infastructure.Extensions
{
    public static class GlobalExceptionHandlerExtension
    {
        public static IApplicationBuilder MyExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandler>();
            return builder;
        }
    }
}
