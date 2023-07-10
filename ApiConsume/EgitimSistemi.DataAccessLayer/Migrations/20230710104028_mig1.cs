using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgitimSistemi.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoyAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yetki = table.Column<bool>(type: "bit", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Derslers",
                columns: table => new
                {
                    DersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DersBolum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BolumVideo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derslers", x => x.DersID);
                });

            migrationBuilder.CreateTable(
                name: "Ogrencis",
                columns: table => new
                {
                    OgrenciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OgrenciSoyAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Okul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayıtTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencis", x => x.OgrenciID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Derslers");

            migrationBuilder.DropTable(
                name: "Ogrencis");
        }
    }
}
