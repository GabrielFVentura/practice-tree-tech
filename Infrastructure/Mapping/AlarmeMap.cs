using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class AlarmeMap : IEntityTypeConfiguration<Alarme>
    {
        public void Configure(EntityTypeBuilder<Alarme> builder)
        {
            builder.ToTable("Alarme");

            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(p => p.TipoAlarme).IsRequired();
            builder.Property(p => p.Ativo).IsRequired();
            builder.Property(p => p.DataCadastro).IsRequired();

            builder.HasOne(a => a.Equipamento)
                .WithMany(e => e.Alarmes)
                .HasForeignKey(e => e.IdEquipamento);
        }
    }
}