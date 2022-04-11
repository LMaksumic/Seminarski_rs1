using Microsoft.EntityFrameworkCore;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pozoriste
{
    public partial class MyContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KorisnickiNalog>().HasData(
                new KorisnickiNalog { KorisnickiNalogID = 1, Username = "admin", Password = "admin" },
                new KorisnickiNalog { KorisnickiNalogID = 2, Username = "test", Password = "test" }
                );

            modelBuilder.Entity<Admin>().HasData
            (
                new Admin { AdminID = 1, Ime = "Admin", Prezime = "Admin", KorisnickiNalogID = 1 }
                );

            modelBuilder.Entity<Kupac>().HasData(

                new Kupac { KupacID = 1, Ime = "Ime1", Prezime = "Prezime1", BrojTelefona = "061111111", GradID = 2, Email = "prezime1.ime1@gmail.com", KorisnickiNalogID = 2 },
                new Kupac { KupacID = 2, Ime = "Ime2", Prezime = "Prezime2", BrojTelefona = "061222111", GradID = 3, Email = "prezime2.ime2@gmail.com", KorisnickiNalogID = 2 },
                new Kupac { KupacID = 3, Ime = "Ime3", Prezime = "Prezime3", BrojTelefona = "061223331", GradID = 4, Email = "prezime3.ime4@gmail.com", KorisnickiNalogID = 2 },
                new Kupac { KupacID = 4, Ime = "Ime4", Prezime = "Prezime4", BrojTelefona = "061222331", GradID = 8, Email = "prezime4.ime4@gmail.com", KorisnickiNalogID = 2 }
                );

            modelBuilder.Entity<Grad>().HasData(
             new Grad { GradID = 1, Naziv = "Sarajevo" },
             new Grad { GradID = 2, Naziv = "Zagreb" },
             new Grad { GradID = 3, Naziv = "Mostar" },
             new Grad { GradID = 4, Naziv = "Bihac" },
             new Grad { GradID = 5, Naziv = "Split" },
             new Grad { GradID = 6, Naziv = "Konjic" },
             new Grad { GradID = 7, Naziv = "Tuzla" },
             new Grad { GradID = 8, Naziv = "Sanski most" },
             new Grad { GradID = 9, Naziv = "Livno" },
             new Grad { GradID = 10, Naziv = "Trebinje" },
             new Grad { GradID = 11, Naziv = "Banja luka" });

            modelBuilder.Entity<Sala>().HasData(
                 new Sala { SalaID = 1, Naziv = "Sala 1", Kapacitet = 50, Klimatizacija = true },
                 new Sala { SalaID = 2, Naziv = "Sala 2", Kapacitet = 70, Klimatizacija = false },
                 new Sala { SalaID = 3, Naziv = "Sala 3", Kapacitet = 80, Klimatizacija = true },
                 new Sala { SalaID = 4, Naziv = "Sala 3", Kapacitet = 30, Klimatizacija = true },
                 new Sala { SalaID = 5, Naziv = "Sala 3", Kapacitet = 100, Klimatizacija = false });

            modelBuilder.Entity<Zanr>().HasData(
            new Zanr { ZanrID = 1, Naziv = "Drame" },
            new Zanr { ZanrID = 2, Naziv = "Lutkarske" },
            new Zanr { ZanrID = 3, Naziv = "Klasicne" },
            new Zanr { ZanrID = 4, Naziv = "Tragične" },
            new Zanr { ZanrID = 5, Naziv = "Mjuzikli" });

            modelBuilder.Entity<Sjediste>().HasData(
           new Sjediste { SjedisteID = 1, Red = 1, Kolona = 1, SalaID = 1 },
           new Sjediste { SjedisteID = 2, Red = 1, Kolona = 2, SalaID = 1 },
           new Sjediste { SjedisteID = 3, Red = 2, Kolona = 3, SalaID = 2 },
           new Sjediste { SjedisteID = 4, Red = 3, Kolona = 5, SalaID = 2 },
           new Sjediste { SjedisteID = 5, Red = 4, Kolona = 4, SalaID = 3 },
           new Sjediste { SjedisteID = 6, Red = 5, Kolona = 7, SalaID = 4 },
           new Sjediste { SjedisteID = 7, Red = 7, Kolona = 3, SalaID = 5 },
           new Sjediste { SjedisteID = 8, Red = 5, Kolona = 2, SalaID = 4 });


            modelBuilder.Entity<Glumac>().HasData(
       new Glumac { GlumacID = 1, Ime = "Šerif", Prezime = "Aljić", BrojUgovora = "1234", Email = "sefif@gmail.com" },
       new Glumac { GlumacID = 2, Ime = "Amela", Prezime = "Kreso", BrojUgovora = "1233", Email = "amela@gmail.com" },
       new Glumac { GlumacID = 3, Ime = "Bojan", Prezime = "Beribaka", BrojUgovora = "3344", Email = "bojan@gmail.com" },
       new Glumac { GlumacID = 4, Ime = "Maja", Prezime = "Zećo", BrojUgovora = "4455", Email = "maja@gmail.com" },
       new Glumac { GlumacID = 5, Ime = "Emir", Prezime = "Spahić", BrojUgovora = "5577", Email = "emir@gmail.com" },
       new Glumac { GlumacID = 6, Ime = "Goran", Prezime = "Lazo", BrojUgovora = "9933", Email = "goran@gmail.com" },
       new Glumac { GlumacID = 7, Ime = "Vedran", Prezime = "Vedran", BrojUgovora = "4567", Email = "vedran@gmail.com" });

            modelBuilder.Entity<Predstava>().HasData(
                  new Predstava
                  {
                      PredstavaID = 8,
                      Naziv = "dervis i smrt",
                      Opis = "Opis",
                      Reziser = "Reziser",
                      Trajanje = 60,
                      ZanrID = 2
                  }


                );
            modelBuilder.Entity<Komentar>().HasData(
      new Komentar { KomentarID = 1, Sadrzaj = "Super", KupacID = 2, PredstavaID = 1002, Odobren = true, VrijemeKreiranja = DateTime.Now },
      new Komentar { KomentarID = 2, Sadrzaj = "Lose", KupacID = 3, PredstavaID = 8, Odobren = true, VrijemeKreiranja = DateTime.Now }
   );
        }




    }
}
