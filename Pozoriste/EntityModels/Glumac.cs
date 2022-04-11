using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Glumac
    {
        [Key]
        public int GlumacID { get; set; }

        [Required(ErrorMessage = "Ime je obavezno polje")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Ime sadrži samo  slova")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno polje")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Broj ugovora je obavezno polje")]
        public string BrojUgovora { get; set; }

        [Required(ErrorMessage = "Email je obavezno polje")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Datum rođenja je obavezno polje")]
        public DateTime DatumRodjenja { get; set; }
        public string AdresaSlike { get; set; }


    }
}
