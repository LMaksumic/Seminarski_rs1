using Microsoft.AspNetCore.Mvc.Rendering;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class PredstavaGlumacDodajVM
    {
        public GlumacPredstava GlumacPredstava { get; set; }
        public List<SelectListItem> Glumac { get; set; }
        public List<SelectListItem> Predstava { get; set; }
    }
}
