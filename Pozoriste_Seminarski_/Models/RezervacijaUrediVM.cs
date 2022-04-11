using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class RezervacijaUrediVM
    {
        public List<SelectListItem> Kupac { get; set; }
        public List<SelectListItem> Prikazivanje { get; set; }
        public int kupacid { get; set; }
        public int prikazivanjeId { get; set; }
        public int RezervacijaID { get; set; }
        public DateTime datumRez { get; set; }
        public DateTime datumIst { get; set; }
        public bool Odobrena { get; set; }
    }
}
