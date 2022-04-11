using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Ulaznica
    {
        [Key]
        public int UlaznicaID { get; set; }

        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }

        [ForeignKey("Sjediste")]
        public int SjedisteID { get; set; }
        public Sjediste Sjediste { get; set; }

        [ForeignKey("Rezervacija")]
        public int RezervacijaID { get; set; }
        public Rezervacija Rezervacija { get; set; }

        [ForeignKey("Prikazivanje")]
        public int PrikazivanjeID { get; set; }
        public Prikazivanje Prikazivanje { get; set; }
    }
}
