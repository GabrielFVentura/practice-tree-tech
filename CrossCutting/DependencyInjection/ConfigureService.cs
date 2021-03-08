using Domain.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDepenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAlarmeService, AlarmeService>();
            serviceCollection.AddTransient<IAlarmeAtuadoService, AlarmeAtuadoService>();
            serviceCollection.AddTransient<IEquipamentoService, EquipamentoService>();
            serviceCollection.AddTransient<IEmailService, EmailService>();
        }
    }
}