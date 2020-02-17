using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace casaDeShows.Migrations.ApplicationDbContextEntidadesMigrations
{
    public partial class CriandoEntidadesEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CasaDeShows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCasaDeShow = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasaDeShows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneroEventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Genero = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroEventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCasaDeShowsId = table.Column<int>(nullable: true),
                    IdGeneroDoEventoId = table.Column<int>(nullable: true),
                    NomeDoEvento = table.Column<string>(nullable: false),
                    Capacidade = table.Column<int>(nullable: false),
                    PrecoIngresso = table.Column<double>(nullable: false),
                    DataEvento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_CasaDeShows_IdCasaDeShowsId",
                        column: x => x.IdCasaDeShowsId,
                        principalTable: "CasaDeShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_GeneroEventos_IdGeneroDoEventoId",
                        column: x => x.IdGeneroDoEventoId,
                        principalTable: "GeneroEventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdCasaDeShowsId",
                table: "Eventos",
                column: "IdCasaDeShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdGeneroDoEventoId",
                table: "Eventos",
                column: "IdGeneroDoEventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "CasaDeShows");

            migrationBuilder.DropTable(
                name: "GeneroEventos");
        }
    }
}
