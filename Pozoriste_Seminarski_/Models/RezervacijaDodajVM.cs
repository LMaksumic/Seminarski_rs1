using Microsoft.AspNetCore.Mvc.Rendering;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class RezervacijaDodajVM
    {

        public Rezervacija Rezervacija { get; set; }

        public List<SelectListItem> Kupci { get; set; }
        public List<SelectListItem> Prikazivanja { get; set; }
    }
}
