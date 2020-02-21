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
                    CasaDeShowsId = table.Column<int>(nullable: false),
                    GeneroDoEventoId = table.Column<int>(nullable: false),
                    NomeDoEvento = table.Column<string>(nullable: false),
                    Capacidade = table.Column<int>(nullable: false),
                    PrecoIngresso = table.Column<double>(nullable: false),
                    DataEvento = table.Column<DateTime>(nullable: false),
                    HorarioEvento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_CasaDeShows_CasaDeShowsId",
                        column: x => x.CasaDeShowsId,
                        principalTable: "CasaDeShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_GeneroEventos_GeneroDoEventoId",
                        column: x => x.GeneroDoEventoId,
                        principalTable: "GeneroEventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_CasaDeShowsId",
                table: "Eventos",
                column: "CasaDeShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_GeneroDoEventoId",
                table: "Eventos",
                column: "GeneroDoEventoId");
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
