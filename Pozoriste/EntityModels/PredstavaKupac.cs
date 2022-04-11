using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class PredstavaKupac
    {
        [Key]
        public int PredstavaKupacID { get; set; }

        [Required(ErrorMessage = "Ocjena je obavezno polje!")]
        [RegularExpression("([1-9]|10)", ErrorMessage = "Možete unijeti broj u rasponu od 1-10")]
        public decimal Ocjena { get; set; }

        [ForeignKey("Predstava")]
        public int PredstavaID { get; set; }
        public Predstava Predstava { get; set; }

        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }

    }
}
