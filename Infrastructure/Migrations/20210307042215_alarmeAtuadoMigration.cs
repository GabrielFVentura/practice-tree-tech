using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class alarmeAtuadoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    NomeEquipamento = table.Column<string>(maxLength: 100, nullable: false),
                    NumeroSerie = table.Column<string>(nullable: false),
                    TipoEquipamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alarme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 60, nullable: false),
                    TipoAlarme = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    IdEquipamento = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarme_Equipamento_IdEquipamento",
                        column: x => x.IdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlarmeAtuado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    IdAlarme = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    TipoAlarme = table.Column<int>(nullable: false),
                    NomeEquipamento = table.Column<string>(nullable: true),
                    NumeroSerie = table.Column<string>(nullable: true),
                    TipoEquipamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmeAtuado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlarmeAtuado_Alarme_IdAlarme",
                        column: x => x.IdAlarme,
                        principalTable: "Alarme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarme_IdEquipamento",
                table: "Alarme",
                column: "IdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmeAtuado_IdAlarme",
                table: "AlarmeAtuado",
                column: "IdAlarme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmeAtuado");

            migrationBuilder.DropTable(
                name: "Alarme");

            migrationBuilder.DropTable(
                name: "Equipamento");
        }
    }
}
