using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class UlaznicaPrikaziVM
    {
        public List<Row> lista { get; set; }
        public int kupacId { get; set; }

        public class Row
        {
            public string ImePrezime { get; set; }
            public string predstava { get; set; }
            public string prikazivanje { get; set; }
            public string sjediste { get; set; }
            public int ulaznicaId { get; set; }
            public decimal Cijena { get; set; }


        }
    }
}
