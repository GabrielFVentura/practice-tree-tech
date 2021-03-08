using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class EquipamentoMap : IEntityTypeConfiguration<Equipamento>
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {
            builder.ToTable("Equipamento");

            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.NomeEquipamento)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.NumeroSerie).IsRequired();
            builder.Property(e => e.TipoEquipamento).IsRequired();
            builder.Property(e => e.DataCadastro).IsRequired();
        }
    }
}