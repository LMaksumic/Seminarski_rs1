using Microsoft.AspNetCore.Mvc.Rendering;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class UlaznicaDodajVM
    {
        public Ulaznica Ulaznica { get; set; }

        public string Kupac { get; set; }
        public int KupacId { get; set; }
        public List<SelectListItem> Sjedista { get; set; }

        public decimal Cijena { get; set; }
        public string Prikazivanje { get; set; }
        public int RezervacijaId { get; set; }
        public bool zauzetoSjediste { get; set; }
    }
}
