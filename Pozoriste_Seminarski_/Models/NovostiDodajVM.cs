using Microsoft.AspNetCore.Http;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class NovostiDodajVM
    {
        public Novosti Novosti { get; set; }
        public IFormFile Photo { get; set; }
    }
}
