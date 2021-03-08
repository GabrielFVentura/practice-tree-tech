using Domain.Entities;
using Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public class TreeTechContext : DbContext
    {
        public TreeTechContext(DbContextOptions<TreeTechContext> options) : base(options){}
        
        public DbSet<Alarme> Alarmes { get; set; }
        public DbSet<Alarme> Equipamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alarme>(new AlarmeMap().Configure);
            modelBuilder.Entity<Equipamento>(new EquipamentoMap().Configure);
        }
    }
}