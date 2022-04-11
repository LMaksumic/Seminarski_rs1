using Microsoft.AspNetCore.Mvc.Rendering;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class RegistracijaIndexVM
    {
        public KorisnickiNalog KorisnickiNalog { get; set; }
        public Kupac Kupac { get; set; }
        public List<SelectListItem> gradovi { get; set; }
    }
}
