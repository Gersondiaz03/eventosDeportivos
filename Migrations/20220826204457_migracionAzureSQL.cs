using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eventosDeportivos.Migrations
{
    public partial class migracionAzureSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "colegioArbitral",
                columns: table => new
                {
                    colegioArbitralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    resolucion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    correo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colegioArbitral", x => x.colegioArbitralId);
                });

            migrationBuilder.CreateTable(
                name: "Entrenador",
                columns: table => new
                {
                    documento = table.Column<int>(type: "int", nullable: false),
                    equipoId = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenador", x => x.documento);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    municipioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.municipioId);
                });

            migrationBuilder.CreateTable(
                name: "Patrocinador",
                columns: table => new
                {
                    documento = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    tipoPersona = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrocinador", x => x.documento);
                });

            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    torneoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    municipioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.torneoId);
                    table.ForeignKey(
                        name: "FK_Torneo_Municipio_municipioId",
                        column: x => x.municipioId,
                        principalTable: "Municipio",
                        principalColumn: "municipioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    equipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    deporte = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    entrenadorForeignKey = table.Column<int>(type: "int", nullable: false),
                    patrocinadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.equipoId);
                    table.ForeignKey(
                        name: "FK_Equipo_Entrenador_entrenadorForeignKey",
                        column: x => x.entrenadorForeignKey,
                        principalTable: "Entrenador",
                        principalColumn: "documento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipo_Patrocinador_patrocinadorId",
                        column: x => x.patrocinadorId,
                        principalTable: "Patrocinador",
                        principalColumn: "documento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arbitro",
                columns: table => new
                {
                    documento = table.Column<int>(type: "int", nullable: false),
                    deporte = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    torneoId = table.Column<int>(type: "int", nullable: false),
                    colegioArbitralId = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitro", x => x.documento);
                    table.ForeignKey(
                        name: "FK_Arbitro_colegioArbitral_colegioArbitralId",
                        column: x => x.colegioArbitralId,
                        principalTable: "colegioArbitral",
                        principalColumn: "colegioArbitralId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arbitro_Torneo_torneoId",
                        column: x => x.torneoId,
                        principalTable: "Torneo",
                        principalColumn: "torneoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Escenario",
                columns: table => new
                {
                    escenarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    torneoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escenario", x => x.escenarioId);
                    table.ForeignKey(
                        name: "FK_Escenario_Torneo_torneoId",
                        column: x => x.torneoId,
                        principalTable: "Torneo",
                        principalColumn: "torneoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deportista",
                columns: table => new
                {
                    documento = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    RH = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    EPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    equipoId = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportista", x => x.documento);
                    table.ForeignKey(
                        name: "FK_Deportista_Equipo_equipoId",
                        column: x => x.equipoId,
                        principalTable: "Equipo",
                        principalColumn: "equipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipoTorneo",
                columns: table => new
                {
                    equiposequipoId = table.Column<int>(type: "int", nullable: false),
                    torneostorneoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoTorneo", x => new { x.equiposequipoId, x.torneostorneoId });
                    table.ForeignKey(
                        name: "FK_EquipoTorneo_Equipo_equiposequipoId",
                        column: x => x.equiposequipoId,
                        principalTable: "Equipo",
                        principalColumn: "equipoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipoTorneo_Torneo_torneostorneoId",
                        column: x => x.torneostorneoId,
                        principalTable: "Torneo",
                        principalColumn: "torneoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cancha",
                columns: table => new
                {
                    canchaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    disciplina = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    cantidadEspectadores = table.Column<int>(type: "int", nullable: false),
                    medidas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    escenarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancha", x => x.canchaId);
                    table.ForeignKey(
                        name: "FK_Cancha_Escenario_escenarioId",
                        column: x => x.escenarioId,
                        principalTable: "Escenario",
                        principalColumn: "escenarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arbitro_colegioArbitralId",
                table: "Arbitro",
                column: "colegioArbitralId");

            migrationBuilder.CreateIndex(
                name: "IX_Arbitro_torneoId",
                table: "Arbitro",
                column: "torneoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancha_escenarioId",
                table: "Cancha",
                column: "escenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Deportista_equipoId",
                table: "Deportista",
                column: "equipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_entrenadorForeignKey",
                table: "Equipo",
                column: "entrenadorForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_patrocinadorId",
                table: "Equipo",
                column: "patrocinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoTorneo_torneostorneoId",
                table: "EquipoTorneo",
                column: "torneostorneoId");

            migrationBuilder.CreateIndex(
                name: "IX_Escenario_torneoId",
                table: "Escenario",
                column: "torneoId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_nombre",
                table: "Municipio",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Torneo_municipioId",
                table: "Torneo",
                column: "municipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Torneo_nombre",
                table: "Torneo",
                column: "nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arbitro");

            migrationBuilder.DropTable(
                name: "Cancha");

            migrationBuilder.DropTable(
                name: "Deportista");

            migrationBuilder.DropTable(
                name: "EquipoTorneo");

            migrationBuilder.DropTable(
                name: "colegioArbitral");

            migrationBuilder.DropTable(
                name: "Escenario");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Torneo");

            migrationBuilder.DropTable(
                name: "Entrenador");

            migrationBuilder.DropTable(
                name: "Patrocinador");

            migrationBuilder.DropTable(
                name: "Municipio");
        }
    }
}
