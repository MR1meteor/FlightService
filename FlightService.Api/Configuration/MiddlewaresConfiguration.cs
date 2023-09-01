using FlightService.Api.Middlewares;

namespace FlightService.Api.Configuration
{
    public static class MiddlewaresConfiguration
    {
        public static void ConfigureMiddlewares(this WebApplication app)
        {
            ConfigureDevelopmentMiddlewares(app);
            ConfigureProductionMiddlewares(app);
        }

        private static void ConfigureDevelopmentMiddlewares(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
                return;

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }

        private static void ConfigureProductionMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsProduction())
                return;

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
