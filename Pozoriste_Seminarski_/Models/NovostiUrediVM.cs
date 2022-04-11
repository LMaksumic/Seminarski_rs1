using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class NovostiUrediVM
    {
        public int id { get; set; }
        public IFormFile Photo { get; set; }
        public string Naziv { get; set; }
        public string Tekst { get; set; }
        public string KratkiSadrzaj { get; set; }

        public DateTime DatumVrijemeObjave { get; set; }
        public string adresaaSlike { get; set; }
    }
}
