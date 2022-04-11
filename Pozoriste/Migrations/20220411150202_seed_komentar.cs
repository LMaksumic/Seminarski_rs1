using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pozoriste.Migrations
{
    public partial class seed_komentar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Predstava",
                columns: new[] { "PredstavaID", "Naziv", "Opis", "ProsjecnaOcjena", "Reziser", "Trajanje", "ZanrID" },
                values: new object[] { 1, "dervis i smrt", "Opis", 0m, "Reziser", 60, 2 });

            migrationBuilder.InsertData(
                table: "Komentar",
                columns: new[] { "KomentarID", "KupacID", "Odobren", "PredstavaID", "Sadrzaj", "VrijemeKreiranja" },
                values: new object[] { 1, 2, true, 1, "Super", new DateTime(2022, 4, 11, 17, 2, 2, 127, DateTimeKind.Local).AddTicks(3835) });

            migrationBuilder.InsertData(
                table: "Komentar",
                columns: new[] { "KomentarID", "KupacID", "Odobren", "PredstavaID", "Sadrzaj", "VrijemeKreiranja" },
                values: new object[] { 2, 3, true, 1, "Lose", new DateTime(2022, 4, 11, 17, 2, 2, 129, DateTimeKind.Local).AddTicks(8864) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "KomentarID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "KomentarID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Predstava",
                keyColumn: "PredstavaID",
                keyValue: 1);
        }
    }
}
