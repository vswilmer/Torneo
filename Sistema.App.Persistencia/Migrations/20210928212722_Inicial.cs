using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Torneos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estadios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estadios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estadios_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalId = table.Column<int>(type: "int", nullable: true),
                    VisitanteId = table.Column<int>(type: "int", nullable: true),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArbitroId = table.Column<int>(type: "int", nullable: true),
                    CanchaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidos_Estadios_CanchaId",
                        column: x => x.CanchaId,
                        principalTable: "Estadios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstadisticasPartidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidoJugadoId = table.Column<int>(type: "int", nullable: true),
                    Marcador = table.Column<int>(type: "int", nullable: false),
                    Gol = table.Column<int>(type: "int", nullable: false),
                    Amarilla = table.Column<int>(type: "int", nullable: false),
                    Roja = table.Column<int>(type: "int", nullable: false),
                    Minuto = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadisticasPartidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadisticasPartidos_Partidos_PartidoJugadoId",
                        column: x => x.PartidoJugadoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Desempenos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidoJugado = table.Column<int>(type: "int", nullable: false),
                    PartidoGanado = table.Column<int>(type: "int", nullable: false),
                    GolFavor = table.Column<int>(type: "int", nullable: false),
                    GolEnContra = table.Column<int>(type: "int", nullable: false),
                    PartidoEmpatado = table.Column<int>(type: "int", nullable: false),
                    Puntaje = table.Column<int>(type: "int", nullable: false),
                    ResultadoPartidoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desempenos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desempenos_EstadisticasPartidos_ResultadoPartidoId",
                        column: x => x.ResultadoPartidoId,
                        principalTable: "EstadisticasPartidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Escuela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosicionCancha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCamiseta = table.Column<int>(type: "int", nullable: true),
                    EquipoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtId = table.Column<int>(type: "int", nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: true),
                    TorneoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipos_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipos_Personas_DtId",
                        column: x => x.DtId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipos_Torneos_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desempenos_ResultadoPartidoId",
                table: "Desempenos",
                column: "ResultadoPartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_DtId",
                table: "Equipos",
                column: "DtId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_MunicipioId",
                table: "Equipos",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_TorneoId",
                table: "Equipos",
                column: "TorneoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estadios_MunicipioId",
                table: "Estadios",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadisticasPartidos_PartidoJugadoId",
                table: "EstadisticasPartidos",
                column: "PartidoJugadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_ArbitroId",
                table: "Partidos",
                column: "ArbitroId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_CanchaId",
                table: "Partidos",
                column: "CanchaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_LocalId",
                table: "Partidos",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_VisitanteId",
                table: "Partidos",
                column: "VisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EquipoId",
                table: "Personas",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Equipos_LocalId",
                table: "Partidos",
                column: "LocalId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Equipos_VisitanteId",
                table: "Partidos",
                column: "VisitanteId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Personas_ArbitroId",
                table: "Partidos",
                column: "ArbitroId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Equipos_EquipoId",
                table: "Personas",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Municipios_MunicipioId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Personas_DtId",
                table: "Equipos");

            migrationBuilder.DropTable(
                name: "Desempenos");

            migrationBuilder.DropTable(
                name: "EstadisticasPartidos");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Estadios");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Torneos");
        }
    }
}
