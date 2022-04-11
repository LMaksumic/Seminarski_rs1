using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Models
{
    public class KupacUrediVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public List<SelectListItem> Grad { get; set; }
        public int gradid { get; set; }
        public int KupacID { get; set; }
        public string Email { get; set; }
    }
}
