using Microsoft.AspNetCore.Mvc.Rendering;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class PrikazivanjeDodajVM
    {
        public Prikazivanje Prikazivanje { get; set; }

        public List<SelectListItem> Predstavae { get; set; }

        public List<SelectListItem> Sale { get; set; }
    }
}
