using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IgpFramework.Data.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IGP_MENU",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordUserId = table.Column<int>(nullable: false),
                    RecordDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true),
                    AnaId = table.Column<int>(nullable: true),
                    MenuAdi = table.Column<string>(type: "varchar(100)", nullable: false),
                    Url = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IGP_MENU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IGP_USER",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordUserId = table.Column<int>(nullable: false),
                    RecordDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true),
                    Adi = table.Column<string>(type: "varchar(200)", nullable: false),
                    Soyadi = table.Column<string>(type: "varchar(200)", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "varchar(200)", nullable: false),
                    Sifresi = table.Column<string>(type: "varchar(200)", nullable: false),
                    CepTelefonu = table.Column<string>(type: "varchar(20)", nullable: true),
                    Eposta = table.Column<string>(type: "varchar(50)", nullable: true),
                    TcKimlikNo = table.Column<decimal>(type: "decimal(11)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "date", nullable: true),
                    Cinsiyeti = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IGP_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IGP_USER_MENU_PERMISSIONS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordUserId = table.Column<int>(nullable: false),
                    RecordDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IGP_USER_MENU_PERMISSIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IGP_USER_MENU_PERMISSIONS_IGP_MENU_MenuId",
                        column: x => x.MenuId,
                        principalTable: "IGP_MENU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IGP_USER_MENU_PERMISSIONS_IGP_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "IGP_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IGP_USER_PASSWORDS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordUserId = table.Column<int>(nullable: false),
                    RecordDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IGP_USER_PASSWORDS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IGP_USER_PASSWORDS_IGP_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "IGP_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IGP_USER_SESSIONS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecordUserId = table.Column<int>(nullable: false),
                    RecordDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateUserId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    SessionId = table.Column<string>(type: "varchar(50)", nullable: true),
                    LoginDate = table.Column<DateTime>(type: "date", nullable: false),
                    LogoutDate = table.Column<DateTime>(type: "date", nullable: false),
                    Test = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IGP_USER_SESSIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IGP_USER_SESSIONS_IGP_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "IGP_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IGP_USER_MENU_PERMISSIONS_MenuId",
                table: "IGP_USER_MENU_PERMISSIONS",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_IGP_USER_MENU_PERMISSIONS_UserId",
                table: "IGP_USER_MENU_PERMISSIONS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IGP_USER_PASSWORDS_UserId",
                table: "IGP_USER_PASSWORDS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IGP_USER_SESSIONS_UserId",
                table: "IGP_USER_SESSIONS",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IGP_USER_MENU_PERMISSIONS");

            migrationBuilder.DropTable(
                name: "IGP_USER_PASSWORDS");

            migrationBuilder.DropTable(
                name: "IGP_USER_SESSIONS");

            migrationBuilder.DropTable(
                name: "IGP_MENU");

            migrationBuilder.DropTable(
                name: "IGP_USER");
        }
    }
}
