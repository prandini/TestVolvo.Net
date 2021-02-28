using App.Volvo.Business.Interfaces;
using App.Volvo.Business.Notifications;
using App.Volvo.Business.Services;
using App.Volvo.Data.Context;
using App.Volvo.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace App.Volvo.Site.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppVolvoDbContext>();
            services.AddScoped<ICaminhaoRepository, CaminhaoRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();

            services.AddScoped<INotifier, Notifier>();

            services.AddScoped<ICaminhaoService, CaminhaoService>();
            services.AddScoped<IModeloService, ModeloService>();

            return services;
        }
    }
}
