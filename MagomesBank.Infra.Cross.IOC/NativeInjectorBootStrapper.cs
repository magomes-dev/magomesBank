using MagomesBank.Application.Interfaces;
using MagomesBank.Application.Services;
using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Services;
using MagomesBank.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MagomesBank.Infra.Cross.IOC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IAplServiceUsuario, AplServiceUsuario>();
            services.AddScoped<IAplServiceHistoricoMovimento, AplServiceHistoricoMovimento>();
            services.AddScoped<IAplServiceUsuario, AplServiceUsuario>();

            // Domain - Services
            services.AddScoped<IServiceContaCorrente, ServiceContaCorrente>();
            services.AddScoped<IServiceHistoricoMovimento, ServiceHistoricoMovimento>();
            services.AddScoped<IServiceUsuario, ServiceUsuario>();

            // Infra - Data - Repository
            services.AddScoped<IRepositoryContaCorrente, RepositoryContaCorrente>();
            services.AddScoped<IRepositoryHistoricoMovimento, RepositoryHistoricoMovimento>();
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
        }
    }
}
