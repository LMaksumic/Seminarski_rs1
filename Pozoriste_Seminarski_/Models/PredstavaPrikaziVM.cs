using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class PredstavaPrikaziVM
    {
        public List<Row> lista { get; set; }
        public string predstava { get; set; }
        public class Row
        {
            public int PredstavaID { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }
            public string Reziser { get; set; }
            public int Trajanje { get; set; }
            public string NazivZanra { get; set; }
            public decimal ProsjecnaOcjena { get; set; }
        }
    }
}