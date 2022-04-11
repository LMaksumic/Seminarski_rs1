using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class AjaxGlumciPrikaziVM
    {
        public int PredstavaId { get; set; }
        public List<Row> lista { get; set; }
        public class Row
        {
            public int GlumacId { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string BrojUgovora { get; set; }
            public string Email { get; set; }
            public DateTime DatumRodjenja { get; set; }
        }
    }
}
