using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class AlarmeAtuadoMap : IEntityTypeConfiguration<AlarmeAtuado>
    {
        public void Configure(EntityTypeBuilder<AlarmeAtuado> builder)
        {
            builder.ToTable("AlarmeAtuado");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataCadastro).IsRequired();
            builder.Property(p => p.NomeEquipamento).IsRequired();
            builder.Property(p => p.NumeroSerie).IsRequired();
            builder.Property(p => p.TipoEquipamento).IsRequired();
            builder.Property(p => p.TipoAlarme).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();

            builder.HasOne(k => k.Alarme)
                .WithMany(e => e.AlarmesAtuado)
                .HasForeignKey(d => d.IdAlarme);
        }
    }
}