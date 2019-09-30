using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace proyectokeneth.Migrations
{
    public partial class NuevaTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73724");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73727");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73730");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73733");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73736");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73739");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73746");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73749");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73752");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73755");

            migrationBuilder.CreateSequence(
                name: "ISEQ$$_73758");

            migrationBuilder.CreateTable(
                name: "ACCIONES",
                columns: table => new
                {
                    ID_ACCION = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCIONES", x => x.ID_ACCION);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DATO_TIPO",
                columns: table => new
                {
                    ID_DATO_TIPO = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DATO_TIPO", x => x.ID_DATO_TIPO);
                });

            migrationBuilder.CreateTable(
                name: "PASOS",
                columns: table => new
                {
                    ID_PASO = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "VARCHAR2(100)", nullable: false),
                    FECHA_INICIO = table.Column<DateTime>(nullable: false),
                    FECHA_FIN = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PASOS", x => x.ID_PASO);
                });

            migrationBuilder.CreateTable(
                name: "PASOS_INSTANCIAS",
                columns: table => new
                {
                    ID_PASOINSTANCIA = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PASOS_INSTANCIAS", x => x.ID_PASOINSTANCIA);
                });

            migrationBuilder.CreateTable(
                name: "PLANTILLAS",
                columns: table => new
                {
                    ID_PLANTILLA = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANTILLAS", x => x.ID_PLANTILLA);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INSTANCIAS_PLANTILLAS",
                columns: table => new
                {
                    ID_INSTANCIA_PLANTILLA = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NOMBRE = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    ASPNETUSER = table.Column<string>(nullable: false),
                    ESTADO = table.Column<string>(type: "CHAR(1)", nullable: false),
                    INICIADA = table.Column<string>(type: "CHAR(1)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "VARCHAR2(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTANCIAS_PLANTILLAS", x => x.ID_INSTANCIA_PLANTILLA);
                    table.ForeignKey(
                        name: "FK_INSTANCIAS_PLANTILLAS_AspNetUsers_ASPNETUSER",
                        column: x => x.ASPNETUSER,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PLANTILLAS_CAMPOS_DETALLE",
                columns: table => new
                {
                    ID_PLANTILLA_CAMPO = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PLANTILLA = table.Column<int>(nullable: false),
                    ID_DATO_TIPO = table.Column<int>(nullable: false),
                    NOMBRE_CAMPO = table.Column<string>(type: "VARCHAR2(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANTILLAS_CAMPOS_DETALLE", x => x.ID_PLANTILLA_CAMPO);
                    table.ForeignKey(
                        name: "FK_PLANTILLAS_CAMPOS_DETALLE_DATO_TIPO_ID_DATO_TIPO",
                        column: x => x.ID_DATO_TIPO,
                        principalTable: "DATO_TIPO",
                        principalColumn: "ID_DATO_TIPO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PLANTILLAS_CAMPOS_DETALLE_PLANTILLAS_PLANTILLA",
                        column: x => x.PLANTILLA,
                        principalTable: "PLANTILLAS",
                        principalColumn: "ID_PLANTILLA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PLANTILLAS_PASOS_DETALLE",
                columns: table => new
                {
                    ID_PLANTILLA_PASO = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PLANTILLA = table.Column<int>(nullable: false),
                    PASO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANTILLAS_PASOS_DETALLE", x => x.ID_PLANTILLA_PASO);
                    table.ForeignKey(
                        name: "FK_PLANTILLAS_PASOS_DETALLE_PASOS_PASO",
                        column: x => x.PASO,
                        principalTable: "PASOS",
                        principalColumn: "ID_PASO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PLANTILLAS_PASOS_DETALLE_PLANTILLAS_PLANTILLA",
                        column: x => x.PLANTILLA,
                        principalTable: "PLANTILLAS",
                        principalColumn: "ID_PLANTILLA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                columns: table => new
                {
                    ID_INSTANCIA_PLANTILLA_DATO = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    INSTANCIAPLANTILLA = table.Column<int>(nullable: false),
                    ID_DATO_TIPO = table.Column<int>(nullable: false),
                    NOMBRE_CAMPO = table.Column<string>(type: "VARCHAR2(50)", nullable: false),
                    DATO_TEXTO = table.Column<string>(type: "VARCHAR2(50)", nullable: true),
                    DATO_FECHA = table.Column<DateTime>(nullable: true),
                    DATO_NUMERICO = table.Column<long>(nullable: true),
                    DATO_DECIMAL = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTANCIAS_PLANTILLAS_DATOS_DETALLE", x => x.ID_INSTANCIA_PLANTILLA_DATO);
                    table.ForeignKey(
                        name: "FK_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_DATO_TIPO_ID_DATO_TIPO",
                        column: x => x.ID_DATO_TIPO,
                        principalTable: "DATO_TIPO",
                        principalColumn: "ID_DATO_TIPO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_INSTANCIAS_PLANTILLAS_INSTANCIAPLANTILLA",
                        column: x => x.INSTANCIAPLANTILLA,
                        principalTable: "INSTANCIAS_PLANTILLAS",
                        principalColumn: "ID_INSTANCIA_PLANTILLA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                columns: table => new
                {
                    ID_PLANTILLA_PASO_DETALLE = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    INSTANCIA_PLANTILLA = table.Column<int>(nullable: false),
                    PASO = table.Column<int>(nullable: false),
                    ESTADO = table.Column<int>(nullable: true),
                    ASPNETUSER = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSTANCIAS_PLANTILLAS_PASOS_DETALLE", x => x.ID_PLANTILLA_PASO_DETALLE);
                    table.ForeignKey(
                        name: "FK_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_AspNetUsers_ASPNETUSER",
                        column: x => x.ASPNETUSER,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_ACCIONES_ESTADO",
                        column: x => x.ESTADO,
                        principalTable: "ACCIONES",
                        principalColumn: "ID_ACCION",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_INSTANCIAS_PLANTILLAS_INSTANCIA_PLANTILLA",
                        column: x => x.INSTANCIA_PLANTILLA,
                        principalTable: "INSTANCIAS_PLANTILLAS",
                        principalColumn: "ID_INSTANCIA_PLANTILLA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_PASOS_INSTANCIAS_PASO",
                        column: x => x.PASO,
                        principalTable: "PASOS_INSTANCIAS",
                        principalColumn: "ID_PASOINSTANCIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PLANTILLAS_PASOS_USUARIOS_DETALLE",
                columns: table => new
                {
                    ID_PLANTILLAS_PASOS_USUARIOS = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PLANTILLA_PASO_DETALLE = table.Column<int>(nullable: false),
                    ASPNETUSER = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLANTILLAS_PASOS_USUARIOS_DETALLE", x => x.ID_PLANTILLAS_PASOS_USUARIOS);
                    table.ForeignKey(
                        name: "FK_PLANTILLAS_PASOS_USUARIOS_DETALLE_AspNetUsers_ASPNETUSER",
                        column: x => x.ASPNETUSER,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PLANTILLAS_PASOS_USUARIOS_DETALLE_PLANTILLAS_PASOS_DETALLE_PLANTILLA_PASO_DETALLE",
                        column: x => x.PLANTILLA_PASO_DETALLE,
                        principalTable: "PLANTILLAS_PASOS_DETALLE",
                        principalColumn: "ID_PLANTILLA_PASO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PASOS_INSTANCIAS_DATOS_DETALLE",
                columns: table => new
                {
                    ID_PASOS_INSTANCIAS_DATOS = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    INSTANCIA_PLANTILLA_DATO = table.Column<int>(nullable: false),
                    PASO = table.Column<int>(nullable: false),
                    SOLO_LECTURA = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PASOS_INSTANCIAS_DATOS_DETALLE", x => x.ID_PASOS_INSTANCIAS_DATOS);
                    table.ForeignKey(
                        name: "FK_PASOS_INSTANCIAS_DATOS_DETALLE_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_INSTANCIA_PLANTILLA_DATO",
                        column: x => x.INSTANCIA_PLANTILLA_DATO,
                        principalTable: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                        principalColumn: "ID_INSTANCIA_PLANTILLA_DATO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PASOS_INSTANCIAS_DATOS_DETALLE_PASOS_INSTANCIAS_PASO",
                        column: x => x.PASO,
                        principalTable: "PASOS_INSTANCIAS",
                        principalColumn: "ID_PASOINSTANCIA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PASOS_USUARIOS_DETALLE",
                columns: table => new
                {
                    ID_PASOS_USUARIOS = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    PLANTILLA_PASO_DETALLE = table.Column<int>(nullable: false),
                    ASPNETUSER = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PASOS_USUARIOS_DETALLE", x => x.ID_PASOS_USUARIOS);
                    table.ForeignKey(
                        name: "FK_PASOS_USUARIOS_DETALLE_AspNetUsers_ASPNETUSER",
                        column: x => x.ASPNETUSER,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PASOS_USUARIOS_DETALLE_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_PLANTILLA_PASO_DETALLE",
                        column: x => x.PLANTILLA_PASO_DETALLE,
                        principalTable: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                        principalColumn: "ID_PLANTILLA_PASO_DETALLE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DATO_TIPO",
                columns: new[] { "ID_DATO_TIPO", "NOMBRE" },
                values: new object[,]
                {
                    { 1, "Texto" },
                    { 2, "Fecha" },
                    { 3, "Entero" },
                    { 4, "Decimal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_ASPNETUSER",
                table: "INSTANCIAS_PLANTILLAS",
                column: "ASPNETUSER");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_ID_DATO_TIPO",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                column: "ID_DATO_TIPO");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_DATOS_DETALLE_INSTANCIAPLANTILLA",
                table: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE",
                column: "INSTANCIAPLANTILLA");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_ASPNETUSER",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "ASPNETUSER");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_ESTADO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "ESTADO");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_INSTANCIA_PLANTILLA",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "INSTANCIA_PLANTILLA");

            migrationBuilder.CreateIndex(
                name: "IX_INSTANCIAS_PLANTILLAS_PASOS_DETALLE_PASO",
                table: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE",
                column: "PASO");

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_INSTANCIAS_DATOS_DETALLE_INSTANCIA_PLANTILLA_DATO",
                table: "PASOS_INSTANCIAS_DATOS_DETALLE",
                column: "INSTANCIA_PLANTILLA_DATO");

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_INSTANCIAS_DATOS_DETALLE_PASO",
                table: "PASOS_INSTANCIAS_DATOS_DETALLE",
                column: "PASO");

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_USUARIOS_DETALLE_ASPNETUSER",
                table: "PASOS_USUARIOS_DETALLE",
                column: "ASPNETUSER");

            migrationBuilder.CreateIndex(
                name: "IX_PASOS_USUARIOS_DETALLE_PLANTILLA_PASO_DETALLE",
                table: "PASOS_USUARIOS_DETALLE",
                column: "PLANTILLA_PASO_DETALLE");

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_CAMPOS_DETALLE_ID_DATO_TIPO",
                table: "PLANTILLAS_CAMPOS_DETALLE",
                column: "ID_DATO_TIPO");

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_CAMPOS_DETALLE_PLANTILLA",
                table: "PLANTILLAS_CAMPOS_DETALLE",
                column: "PLANTILLA");

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_PASOS_DETALLE_PASO",
                table: "PLANTILLAS_PASOS_DETALLE",
                column: "PASO");

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_PASOS_DETALLE_PLANTILLA",
                table: "PLANTILLAS_PASOS_DETALLE",
                column: "PLANTILLA");

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_PASOS_USUARIOS_DETALLE_ASPNETUSER",
                table: "PLANTILLAS_PASOS_USUARIOS_DETALLE",
                column: "ASPNETUSER");

            migrationBuilder.CreateIndex(
                name: "IX_PLANTILLAS_PASOS_USUARIOS_DETALLE_PLANTILLA_PASO_DETALLE",
                table: "PLANTILLAS_PASOS_USUARIOS_DETALLE",
                column: "PLANTILLA_PASO_DETALLE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PASOS_INSTANCIAS_DATOS_DETALLE");

            migrationBuilder.DropTable(
                name: "PASOS_USUARIOS_DETALLE");

            migrationBuilder.DropTable(
                name: "PLANTILLAS_CAMPOS_DETALLE");

            migrationBuilder.DropTable(
                name: "PLANTILLAS_PASOS_USUARIOS_DETALLE");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "INSTANCIAS_PLANTILLAS_DATOS_DETALLE");

            migrationBuilder.DropTable(
                name: "INSTANCIAS_PLANTILLAS_PASOS_DETALLE");

            migrationBuilder.DropTable(
                name: "PLANTILLAS_PASOS_DETALLE");

            migrationBuilder.DropTable(
                name: "DATO_TIPO");

            migrationBuilder.DropTable(
                name: "ACCIONES");

            migrationBuilder.DropTable(
                name: "INSTANCIAS_PLANTILLAS");

            migrationBuilder.DropTable(
                name: "PASOS_INSTANCIAS");

            migrationBuilder.DropTable(
                name: "PASOS");

            migrationBuilder.DropTable(
                name: "PLANTILLAS");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73724");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73727");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73730");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73733");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73736");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73739");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73746");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73749");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73752");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73755");

            migrationBuilder.DropSequence(
                name: "ISEQ$$_73758");
        }
    }
}
