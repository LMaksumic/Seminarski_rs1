using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class KomentarDodaj
    {
        public int id { get; set; }
        public string predstava { get; set; }
        public Komentar Komentar { get; set; }
    }
}
