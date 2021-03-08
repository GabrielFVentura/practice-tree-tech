using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataContext
{
    public class ContextFactory : IDesignTimeDbContextFactory<TreeTechContext>
    {
        public static IConfiguration Configuration { get; set; }
        public string ConnectionString { get; set; }

        public TreeTechContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder();
            Configuration = builder.Build();
            ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];

            var optionsBuilder = new DbContextOptionsBuilder<TreeTechContext>();
            optionsBuilder.UseSqlServer(ConnectionString ??
                                        "Server=localhost;Database=TreeTech;User ID=sa;Password=squadra@sqlserver")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);


            return new TreeTechContext(optionsBuilder.Options);
        }
    }
}