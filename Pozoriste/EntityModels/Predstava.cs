using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Predstava
    {
        [Key]
        public int PredstavaID { get; set; }
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public string Reziser { get; set; }

        public int Trajanje { get; set; }
        public decimal ProsjecnaOcjena { get; set; }

        [ForeignKey("Zanr")]

        public int ZanrID { get; set; }
        public Zanr Zanr { get; set; }
    }
}
