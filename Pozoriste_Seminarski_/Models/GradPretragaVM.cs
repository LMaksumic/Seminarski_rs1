using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class GradPretragaVM
    {
        public IQueryable<Grad> Grad { get; set; }
        public string Pretraga { get; set; }
    }

}
