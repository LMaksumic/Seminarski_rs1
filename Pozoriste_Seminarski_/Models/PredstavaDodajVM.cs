using Microsoft.AspNetCore.Mvc.Rendering;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class PredstavaDodajVM
    {
        public Predstava Predstava { get; set; }
        public List<SelectListItem> Zanr { get; set; }
    }
}
