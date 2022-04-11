using Microsoft.AspNetCore.Mvc.Rendering;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class KupacDodajVM
    {
        public Kupac Kupac { get; set; }
        public List<SelectListItem> grad { get; set; }
    }
}
