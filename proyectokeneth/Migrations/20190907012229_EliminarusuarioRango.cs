using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace proyectokeneth.Migrations
{
    public partial class EliminarusuarioRango : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_USUARIOS_USUARIO",
                table: "INSTANCIAS_PLANTILLAS");

            migrationBuilder.DropForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_USUARIOS_USUARIO_ACCION",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE");

            migrationBuilder.DropForeignKey(
                name: "FK_PASOS_USUARIOS_DETALLE_USUARIOS_USUARIO",
                table: "PASOS_USUARIOS_DETALLE");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "RANGOS");

            migrationBuilder.DropIndex(
                name: "IX_PASOS_USUARIOS_DETALLE_USUARIO",
                table: "PASOS_USUARIOS_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_USUARIO_ACCION",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_USUARIO",
                table: "INSTANCIAS_PLANTILLAS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RANGOS",
                columns: table => new
                {
                    ID_RANGO = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NIVEL = table.Column<int>(nullable: false),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RANGOS", x => x.ID_RANGO);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    APELLIDOS = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    NOMBRES = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    RANGO = table.Column<int>(nullable: false),
                    USUARIO_EMAIL = table.Column<string>(type: "VARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID_USUARIO);
                    table.ForeignKey(
                        name: "FK_USUARIOS_RANGOS_RANGO",
                        column: x => x.RANGO,
                        principalTable: "RANGOS",
                        principalColumn: "ID_RANGO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_USUARIOS_DETALLE_USUARIO",
                table: "PASOS_USUARIOS_DETALLE",
                column: "USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_USUARIO_ACCION",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "USUARIO_ACCION");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_USUARIO",
                table: "INSTANCIAS_PLANTILLAS",
                column: "USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_RANGO",
                table: "USUARIOS",
                column: "RANGO");

            migrationBuilder.AddForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_USUARIOS_USUARIO",
                table: "INSTANCIAS_PLANTILLAS",
                column: "USUARIO",
                principalTable: "USUARIOS",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_USUARIOS_USUARIO_ACCION",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "USUARIO_ACCION",
                principalTable: "USUARIOS",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PASOS_USUARIOS_DETALLE_USUARIOS_USUARIO",
                table: "PASOS_USUARIOS_DETALLE",
                column: "USUARIO",
                principalTable: "USUARIOS",
                principalColumn: "ID_USUARIO",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
