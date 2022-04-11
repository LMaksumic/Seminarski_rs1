using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class RezervacijaPrikaziVM
    {
        public List<Row> lista { get; set; }
        public int kupacId { get; set; }
        public int prikazivanjeId { get; set; }
        public class Row
        {
            public string ImePrezime { get; set; }
            public string prikazivanje { get; set; }
            public DateTime DatumRezervacije { get; set; }
            public DateTime DatumIsteka { get; set; }
            public bool Odobrena { get; set; }
            public int Id { get; set; }
        }
    }
}
