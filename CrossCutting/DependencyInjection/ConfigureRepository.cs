using Domain.Interfaces.IRepository;
using Domain.Interfaces.IRepository.Base;
using Infrastructure.DataContext;
using Infrastructure.Repository;
using Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<TreeTechContext, TreeTechContext>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
            serviceCollection.AddScoped<IAlarmeRepository, AlarmeRepository>();
            serviceCollection.AddScoped<IAlarmeAtuadoRepository, AlarmeAtuadoRepository>();
            
            serviceCollection.AddDbContext<TreeTechContext>(opt =>
                opt.UseSqlServer("Server=localhost;Database=TreeTech;User ID=sa;Password=squadra@sqlserver"));
        }
    }
}