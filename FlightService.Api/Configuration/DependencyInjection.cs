namespace FlightService.Api.Configuration
{
    public static class DependencyInjection
    {
        public static void ConfigureBuilder(this WebApplicationBuilder builder)
        {
            ConfigureInfrastructure(builder.Services);
            ConfigureServices(builder.Services);
            ConfigureRepositories(builder.Services);
        }

        private static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddControllers();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {

        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            
        }
    }
}
