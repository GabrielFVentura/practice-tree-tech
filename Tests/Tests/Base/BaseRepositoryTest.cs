using System;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Test.Tests.Base
{
    public class BaseRepositoryTest
    {
        public BaseRepositoryTest()
        {
            
        }

        public class DB_Teste : IDisposable
        {
            private string dataBaseName = $"TreeTechTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
            public ServiceProvider ServiceProvider { get; private set; }

            public DB_Teste()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddDbContext<TreeTechContext>(o =>
                    o.UseSqlServer($"Server=localhost;Database={dataBaseName};User ID=sa;Password=squadra@sqlserver"),
                    ServiceLifetime.Transient);

                ServiceProvider = serviceCollection.BuildServiceProvider();
                using (var context = ServiceProvider.GetService<TreeTechContext>())
                {
                    context.Database.EnsureCreated();
                }
            }

            public void Dispose()
            {
                using (var context = ServiceProvider.GetService<TreeTechContext>())
                {
                    context.Database.EnsureDeleted();
                }
            }
        }
    }
}