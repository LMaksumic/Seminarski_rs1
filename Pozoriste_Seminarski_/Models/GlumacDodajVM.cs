using Microsoft.AspNetCore.Http;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class GlumacDodajVM
    {
        public Glumac Glumac { get; set; }
        public IFormFile Photo { get; set; }
    }
}
