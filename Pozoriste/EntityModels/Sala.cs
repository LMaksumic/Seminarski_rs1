using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Sala
    {
        [Key]
        public int SalaID { get; set; }

        [Required(ErrorMessage = "Naziv je obavezno polje")]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Kapacitet je obavezno polje")]
        public int Kapacitet { get; set; }
        public bool Klimatizacija { get; set; }
    }
}
