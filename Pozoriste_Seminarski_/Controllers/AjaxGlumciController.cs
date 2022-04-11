using Microsoft.AspNetCore.Mvc;
using Pozoriste;
using Pozoriste_Seminarski_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Controllers
{
    public class AjaxGlumciController : Controller
    {
        public IActionResult Index(int id)
        {
            MyContext db = new MyContext();
            AjaxGlumciPrikaziVM model = new AjaxGlumciPrikaziVM()
            {
                PredstavaId = id,
                lista = db.GlumacPredstava.Where(x => x.PredstavaID == id).Select(x => new AjaxGlumciPrikaziVM.Row
                {
                    BrojUgovora = x.Glumac.BrojUgovora,
                    DatumRodjenja = x.Glumac.DatumRodjenja,
                    Email = x.Glumac.Email,
                    Ime = x.Glumac.Ime,
                    Prezime = x.Glumac.Prezime,
                    GlumacId = x.Glumac.GlumacID
                }).ToList()
            };
            return PartialView(model);
        }
    }
}
