using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class PrikazivanjePrikaziVM
    {
        public List<Row> lista { get; set; }
        public int predstavaID { get; set; }
        public string predstava { get; set; }
        public string opis { get; set; }


        public class Row
        {
            public int PrikazivanjeID { get; set; }
            public DateTime DatumPrikazivanja { get; set; }
            public decimal Cijena { get; set; }
            public string Predstave { get; set; }
            public string Sale { get; set; }
        }
    }
}
