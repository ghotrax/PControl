using Microsoft.EntityFrameworkCore.Migrations;

namespace proyectokeneth.Migrations
{
    public partial class Ndb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "INSTANCIAS_PLANTILLAS",
                newName: "FECHA");

            migrationBuilder.InsertData(
                table: "ACCIONES",
                columns: new[] { "ID_ACCION", "NOMBRE" },
                values: new object[] { 1, "En Espera" });

            migrationBuilder.InsertData(
                table: "ACCIONES",
                columns: new[] { "ID_ACCION", "NOMBRE" },
                values: new object[] { 2, "Iniciado" });

            migrationBuilder.InsertData(
                table: "ACCIONES",
                columns: new[] { "ID_ACCION", "NOMBRE" },
                values: new object[] { 3, "Finalizado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ACCIONES",
                keyColumn: "ID_ACCION",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ACCIONES",
                keyColumn: "ID_ACCION",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ACCIONES",
                keyColumn: "ID_ACCION",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "FECHA",
                table: "INSTANCIAS_PLANTILLAS",
                newName: "Fecha");
        }
    }
}
