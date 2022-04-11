using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class KupacPrikaziVM
    {
        public List<Row> lista { get; set; }
        public class Row
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string BrojTelefona { get; set; }
            public int BrojTokena { get; set; }
            public string NazivGrada { get; set; }
            public string Email { get; set; }

            public int KupacID { get; set; }

        }
    }
}
