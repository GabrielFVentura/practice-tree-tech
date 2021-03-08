﻿// <auto-generated />
using System;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TreeTechContext))]
    partial class TreeTechContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Alarme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<Guid>("IdEquipamento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TipoAlarme")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipamento");

                    b.ToTable("Alarme");
                });

            modelBuilder.Entity("Domain.Entities.AlarmeAtuado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdAlarme")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeEquipamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoAlarme")
                        .HasColumnType("int");

                    b.Property<int>("TipoEquipamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAlarme");

                    b.ToTable("AlarmeAtuado");
                });

            modelBuilder.Entity("Domain.Entities.Equipamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataCadastro")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeEquipamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoEquipamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("Domain.Entities.Alarme", b =>
                {
                    b.HasOne("Domain.Entities.Equipamento", "Equipamento")
                        .WithMany("Alarmes")
                        .HasForeignKey("IdEquipamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.AlarmeAtuado", b =>
                {
                    b.HasOne("Domain.Entities.Alarme", "Alarme")
                        .WithMany("AlarmesAtuado")
                        .HasForeignKey("IdAlarme")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
