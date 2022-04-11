using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pozoriste.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Glumac",
                columns: new[] { "GlumacID", "AdresaSlike", "BrojUgovora", "DatumRodjenja", "Email", "Ime", "Prezime" },
                values: new object[,]
                {
                    { 1, null, "1234", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sefif@gmail.com", "Šerif", "Aljić" },
                    { 2, null, "1233", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "amela@gmail.com", "Amela", "Kreso" },
                    { 3, null, "3344", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bojan@gmail.com", "Bojan", "Beribaka" },
                    { 4, null, "4455", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maja@gmail.com", "Maja", "Zećo" },
                    { 5, null, "5577", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emir@gmail.com", "Emir", "Spahić" },
                    { 6, null, "9933", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "goran@gmail.com", "Goran", "Lazo" },
                    { 7, null, "4567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vedran@gmail.com", "Vedran", "Vedran" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "GradID", "Naziv" },
                values: new object[,]
                {
                    { 11, "Banja luka" },
                    { 10, "Trebinje" },
                    { 8, "Sanski most" },
                    { 7, "Tuzla" },
                    { 9, "Livno" },
                    { 5, "Split" },
                    { 4, "Bihac" },
                    { 3, "Mostar" },
                    { 6, "Konjic" }
                });

            migrationBuilder.UpdateData(
                table: "Kupac",
                keyColumn: "KupacID",
                keyValue: 1,
                columns: new[] { "BrojTelefona", "Email", "Ime", "KorisnickiNalogID", "Prezime" },
                values: new object[] { "061111111", "prezime1.ime1@gmail.com", "Ime1", 2, "Prezime1" });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "SalaID", "Kapacitet", "Klimatizacija", "Naziv" },
                values: new object[,]
                {
                    { 1, 50, true, "Sala 1" },
                    { 2, 70, false, "Sala 2" },
                    { 3, 80, true, "Sala 3" },
                    { 4, 30, true, "Sala 3" },
                    { 5, 100, false, "Sala 3" }
                });

            migrationBuilder.InsertData(
                table: "Zanr",
                columns: new[] { "ZanrID", "Naziv" },
                values: new object[,]
                {
                    { 5, "Mjuzikli" },
                    { 1, "Drame" },
                    { 2, "Lutkarske" },
                    { 3, "Klasicne" },
                    { 4, "Tragične" }
                });

            migrationBuilder.InsertData(
                table: "Kupac",
                columns: new[] { "KupacID", "BrojTelefona", "Email", "GradID", "Ime", "KorisnickiNalogID", "Prezime" },
                values: new object[,]
                {
                    { 2, "061222111", "prezime2.ime2@gmail.com", 3, "Ime2", 2, "Prezime2" },
                    { 3, "061223331", "prezime3.ime4@gmail.com", 4, "Ime3", 2, "Prezime3" },
                    { 4, "061222331", "prezime4.ime4@gmail.com", 8, "Ime4", 2, "Prezime4" }
                });

            migrationBuilder.InsertData(
                table: "Sjediste",
                columns: new[] { "SjedisteID", "Kolona", "Red", "SalaID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 2, 2 },
                    { 4, 5, 3, 2 },
                    { 5, 4, 4, 3 },
                    { 6, 7, 5, 4 },
                    { 8, 2, 5, 4 },
                    { 7, 3, 7, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Glumac",
                keyColumn: "GlumacID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Glumac",
                keyColumn: "GlumacID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Glumac",
                keyColumn: "GlumacID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Glumac",
                keyColumn: "GlumacID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Glumac",
                keyColumn: "GlumacID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Glumac",
                keyColumn: "GlumacID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Glumac",
                keyColumn: "GlumacID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Kupac",
                keyColumn: "KupacID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kupac",
                keyColumn: "KupacID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kupac",
                keyColumn: "KupacID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sjediste",
                keyColumn: "SjedisteID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sjediste",
                keyColumn: "SjedisteID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sjediste",
                keyColumn: "SjedisteID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sjediste",
                keyColumn: "SjedisteID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sjediste",
                keyColumn: "SjedisteID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sjediste",
                keyColumn: "SjedisteID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sjediste",
                keyColumn: "SjedisteID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sjediste",
                keyColumn: "SjedisteID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Zanr",
                keyColumn: "ZanrID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zanr",
                keyColumn: "ZanrID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zanr",
                keyColumn: "ZanrID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zanr",
                keyColumn: "ZanrID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zanr",
                keyColumn: "ZanrID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grad",
                keyColumn: "GradID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "SalaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "SalaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "SalaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "SalaID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sala",
                keyColumn: "SalaID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Kupac",
                keyColumn: "KupacID",
                keyValue: 1,
                columns: new[] { "BrojTelefona", "Email", "Ime", "KorisnickiNalogID", "Prezime" },
                values: new object[] { "061-111-111", "prezime.ime@gmail.com", "ImeKupca", 1, "PrezimeKupca" });
        }
    }
}
