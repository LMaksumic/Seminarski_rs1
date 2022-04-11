using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Sjediste
    {
        [Key]
        public int SjedisteID { get; set; }

        [Required(ErrorMessage = "Red je obavezno polje")]
        [RegularExpression(@"[^0]+", ErrorMessage = "Ne može biti 0!")]
        public int Red { get; set; }

        [Required(ErrorMessage = "Kolona je obavezno polje")]
        [RegularExpression(@"[^0]+", ErrorMessage = "Ne može biti 0!")]
        public int Kolona { get; set; }

        [ForeignKey("Sala")]
        [Required(ErrorMessage = "Sala je obavezno polje")]
        public int SalaID { get; set; }
        public Sala Sala { get; set; }

    }
}
