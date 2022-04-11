using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Kupac
    {
        [Key]
        public int KupacID { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Ime može da sadrži samo  slova")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Prezime može da sadrži samo slova")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Broj je obavezno polje")]
        public string BrojTelefona { get; set; }

        [Required(ErrorMessage = "Grad je obavezno polje")]
        public int GradID { get; set; }
        public Grad Grad { get; set; }
        public string Email { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public int KorisnickiNalogID { get; set; }
    }
}
