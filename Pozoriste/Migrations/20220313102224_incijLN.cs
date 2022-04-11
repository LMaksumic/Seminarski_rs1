using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pozoriste.Migrations
{
    public partial class incijLN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Glumac",
                columns: table => new
                {
                    GlumacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojUgovora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdresaSlike = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glumac", x => x.GlumacID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.KorisnickiNalogID);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    SalaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    Klimatizacija = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.SalaID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ZanrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.ZanrID);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admin_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickiNalogID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacID);
                    table.ForeignKey(
                        name: "FK_Kupac_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Kupac_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "KorisnickiNalogID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sjediste",
                columns: table => new
                {
                    SjedisteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Red = table.Column<int>(type: "int", nullable: false),
                    Kolona = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjediste", x => x.SjedisteID);
                    table.ForeignKey(
                        name: "FK_Sjediste_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Predstava",
                columns: table => new
                {
                    PredstavaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reziser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trajanje = table.Column<int>(type: "int", nullable: false),
                    ProsjecnaOcjena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ZanrID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstava", x => x.PredstavaID);
                    table.ForeignKey(
                        name: "FK_Predstava_Zanr_ZanrID",
                        column: x => x.ZanrID,
                        principalTable: "Zanr",
                        principalColumn: "ZanrID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Novosti",
                columns: table => new
                {
                    NovostiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KratkiSadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumVrijemeObjave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdresaSlike = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novosti", x => x.NovostiID);
                    table.ForeignKey(
                        name: "FK_Novosti_Admin_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "GlumacPredstava",
                columns: table => new
                {
                    GlumacPredstavaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlumacID = table.Column<int>(type: "int", nullable: false),
                    PredstavaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlumacPredstava", x => x.GlumacPredstavaID);
                    table.ForeignKey(
                        name: "FK_GlumacPredstava_Glumac_GlumacID",
                        column: x => x.GlumacID,
                        principalTable: "Glumac",
                        principalColumn: "GlumacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GlumacPredstava_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    KomentarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VrijemeKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odobren = table.Column<bool>(type: "bit", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    PredstavaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.KomentarID);
                    table.ForeignKey(
                        name: "FK_Komentar_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Komentar_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PredstavaKupac",
                columns: table => new
                {
                    PredstavaKupacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocjena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PredstavaID = table.Column<int>(type: "int", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredstavaKupac", x => x.PredstavaKupacID);
                    table.ForeignKey(
                        name: "FK_PredstavaKupac_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PredstavaKupac_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Prikazivanje",
                columns: table => new
                {
                    PrikazivanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPrikazivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PredstavaID = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prikazivanje", x => x.PrikazivanjeID);
                    table.ForeignKey(
                        name: "FK_Prikazivanje_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Prikazivanje_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odobrena = table.Column<bool>(type: "bit", nullable: false),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    PrikazivanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Prikazivanje_PrikazivanjeID",
                        column: x => x.PrikazivanjeID,
                        principalTable: "Prikazivanje",
                        principalColumn: "PrikazivanjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ulaznica",
                columns: table => new
                {
                    UlaznicaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(type: "int", nullable: false),
                    SjedisteID = table.Column<int>(type: "int", nullable: false),
                    RezervacijaID = table.Column<int>(type: "int", nullable: false),
                    PrikazivanjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulaznica", x => x.UlaznicaID);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Prikazivanje_PrikazivanjeID",
                        column: x => x.PrikazivanjeID,
                        principalTable: "Prikazivanje",
                        principalColumn: "PrikazivanjeID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "RezervacijaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Sjediste_SjedisteID",
                        column: x => x.SjedisteID,
                        principalTable: "Sjediste",
                        principalColumn: "SjedisteID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "GradID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Sarajevo" },
                    { 2, "Zagreb" }
                });

            migrationBuilder.InsertData(
                table: "KorisnickiNalog",
                columns: new[] { "KorisnickiNalogID", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "admin", "admin" },
                    { 2, "test", "test" }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminID", "Ime", "KorisnickiNalogID", "Prezime" },
                values: new object[] { 1, "Admin", 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Kupac",
                columns: new[] { "KupacID", "BrojTelefona", "Email", "GradID", "Ime", "KorisnickiNalogID", "Prezime" },
                values: new object[] { 1, "061-111-111", "prezime.ime@gmail.com", 2, "ImeKupca", 1, "PrezimeKupca" });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_KorisnickiNalogID",
                table: "Admin",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_GlumacPredstava_GlumacID",
                table: "GlumacPredstava",
                column: "GlumacID");

            migrationBuilder.CreateIndex(
                name: "IX_GlumacPredstava_PredstavaID",
                table: "GlumacPredstava",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_KupacID",
                table: "Komentar",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_PredstavaID",
                table: "Komentar",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_GradID",
                table: "Kupac",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnickiNalogID",
                table: "Kupac",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Novosti_AdminID",
                table: "Novosti",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Predstava_ZanrID",
                table: "Predstava",
                column: "ZanrID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaKupac_KupacID",
                table: "PredstavaKupac",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_PredstavaKupac_PredstavaID",
                table: "PredstavaKupac",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prikazivanje_PredstavaID",
                table: "Prikazivanje",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Prikazivanje_SalaID",
                table: "Prikazivanje",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KupacID",
                table: "Rezervacija",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_PrikazivanjeID",
                table: "Rezervacija",
                column: "PrikazivanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sjediste_SalaID",
                table: "Sjediste",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_KupacID",
                table: "Ulaznica",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_PrikazivanjeID",
                table: "Ulaznica",
                column: "PrikazivanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_RezervacijaID",
                table: "Ulaznica",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaznica_SjedisteID",
                table: "Ulaznica",
                column: "SjedisteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlumacPredstava");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "Novosti");

            migrationBuilder.DropTable(
                name: "PredstavaKupac");

            migrationBuilder.DropTable(
                name: "Ulaznica");

            migrationBuilder.DropTable(
                name: "Glumac");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Sjediste");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Prikazivanje");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Predstava");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Zanr");
        }
    }
}
