using Microsoft.EntityFrameworkCore;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pozoriste
{
    public partial class MyContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; }

        public DbSet<Glumac> Glumac { get; set; }

        public DbSet<GlumacPredstava> GlumacPredstava { get; set; }

        public DbSet<Grad> Grad { get; set; }

        public DbSet<Kupac> Kupac { get; set; }

        public DbSet<Predstava> Predstava { get; set; }

        public DbSet<Prikazivanje> Prikazivanje { get; set; }

        public DbSet<Rezervacija> Rezervacija { get; set; }

        public DbSet<Sala> Sala { get; set; }

        public DbSet<Sjediste> Sjediste { get; set; }

        public DbSet<Ulaznica> Ulaznica { get; set; }

        public DbSet<Zanr> Zanr { get; set; }

        public DbSet<PredstavaKupac> PredstavaKupac { get; set; }

        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }

        public DbSet<Novosti> Novosti { get; set; }

        public DbSet<Komentar> Komentar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=.;Database=Pozoriste_Seminarski_;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}