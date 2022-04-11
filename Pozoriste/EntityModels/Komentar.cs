using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Komentar
    {
        [Key]
        public int KomentarID { get; set; }
        public string Sadrzaj { get; set; }
        public DateTime VrijemeKreiranja { get; set; }
        public bool Odobren { get; set; }

        [ForeignKey("Kupac")]
        public int KupacID { get; set; }
        public Kupac Kupac { get; set; }

        [ForeignKey("Predstava")]
        public int PredstavaID { get; set; }
        public Predstava Predstava { get; set; }


    }
}
