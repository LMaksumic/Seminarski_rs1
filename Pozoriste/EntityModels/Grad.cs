using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Grad
    {[Key]
          public int GradID { get; set; }

        [Required(ErrorMessage = "Naziv je obavezno polje")]
        public String Naziv { get; set; }
    }
}
