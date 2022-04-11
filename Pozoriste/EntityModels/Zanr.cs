using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pozoriste.EntityModels
{
    public class Zanr
    {
        [Key]
        public int ZanrID { get; set; }
        public string Naziv { get; set; }

    }
}
