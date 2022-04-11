using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Prikazivanje
    {
        [Key]
        public int PrikazivanjeID { get; set; }

        public DateTime DatumPrikazivanja { get; set; }

        [ForeignKey("Predstava")]
        public int PredstavaID { get; set; }
        public Predstava Predstava { get; set; }

        [ForeignKey("Sala")]
        public int SalaID { get; set; }
        public Sala Sala { get; set; }
        public decimal Cijena { get; set; }

    }
}
