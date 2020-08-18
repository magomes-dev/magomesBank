using MagomesBank.Application.Interfaces;
using MagomesBank.Application.Services;
using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Services;
using MagomesBank.Domain.Services.Jobs;
using MagomesBank.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MagomesBank.Infra.Cross.IOC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IAplServiceContaCorrente, AplServiceContaCorrente>();
            services.AddScoped<IAplServiceHistoricoMovimento, AplServiceHistoricoMovimento>();
            services.AddScoped<IAplServiceUsuario, AplServiceUsuario>();

            // Domain - Services
            services.AddScoped<IServiceContaCorrente, ServiceContaCorrente>();
            services.AddScoped<IServiceHistoricoMovimento, ServiceHistoricoMovimento>();
            services.AddScoped<IServiceUsuario, ServiceUsuario>();
            services.AddScoped<IServiceRendimentoDiario, ServiceRendimentoDiario>();

            // Domain - Services - Jobs
            //services.AddScoped<IHostedService, ServiceRendimentoDiarioJob>();

            // Infra - Data - Repository
            services.AddScoped<IRepositoryContaCorrente, RepositoryContaCorrente>();
            services.AddScoped<IRepositoryHistoricoMovimento, RepositoryHistoricoMovimento>();
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
        }
    }
}
