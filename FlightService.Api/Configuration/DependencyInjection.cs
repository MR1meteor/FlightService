using AutoMapper;
using FlightService.Api.Helpers;
using FlightService.Core.Interfaces.Repositories;
using FlightService.Core.Interfaces.Services;
using FlightService.Data.Data;
using FlightService.Data.Repositories;
using FlightService.Services.Services;
using Microsoft.OpenApi.Models;

namespace FlightService.Api.Configuration
{
    public static class DependencyInjection
    {
        public static void ConfigureBuilder(this WebApplicationBuilder builder)
        {
            ConfigureInfrastructure(builder.Services);
            ConfigureServices(builder.Services);
            ConfigureRepositories(builder.Services);
            ConfigureAutomapper(builder.Services);
        }

        private static void ConfigureInfrastructure(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FlightService.Api",
                    Description = "Flight Service Api"
                });
            });
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IPassengerService, PassengerService>();
            services.AddScoped<ITicketService, TicketService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();

            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
        }

        private static void ConfigureAutomapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MappingProfile());
            });
            
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
