using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class KomentarPrikaziVM
    {
        public List<Row> lista { get; set; }
        public string predstava { get; set; }
        public int predstavaId { get; set; }

        public class Row
        {
            public int Id { get; set; }
            public string Sadrzaj { get; set; }
            public bool Odobren { get; set; }
            public string kupac { get; set; }
            public string predstava { get; set; }
            public DateTime VrijemeKreiranja { get; set; }
        }
    }
}
