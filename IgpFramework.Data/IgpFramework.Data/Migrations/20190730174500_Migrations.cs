using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IgpFramework.Data.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IGP_KULLANICI_BILGILERI",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20)", nullable: false),
                    Adi = table.Column<string>(type: "varchar(200)", nullable: true),
                    Soyadi = table.Column<string>(type: "varchar(200)", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "varchar(200)", nullable: true),
                    Sifresi = table.Column<string>(type: "varchar(200)", nullable: true),
                    CepTelefonu = table.Column<string>(type: "varchar(20)", nullable: true),
                    Eposta = table.Column<string>(type: "varchar(50)", nullable: true),
                    TcKimlikNo = table.Column<decimal>(type: "decimal(11)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "date", nullable: false),
                    Cinsiyeti = table.Column<int>(type: "int(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IGP_KULLANICI_BILGILERI", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IGP_KULLANICI_BILGILERI");
        }
    }
}
