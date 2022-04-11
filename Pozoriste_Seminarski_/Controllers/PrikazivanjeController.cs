using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pozoriste;
using Pozoriste.EntityModels;
using Pozoriste_Seminarski_.Models;

namespace Pozoriste_Seminarski_.Controllers
{
    public class PrikazivanjeController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            PrikazivanjePrikaziVM model = new PrikazivanjePrikaziVM()
            {
                lista = db.Prikazivanje.Select(x => new PrikazivanjePrikaziVM.Row()
                {
                    DatumPrikazivanja = x.DatumPrikazivanja,
                    Predstave = x.Predstava.Naziv,
                    PrikazivanjeID = x.PrikazivanjeID,
                    Sale = x.Sala.Naziv,
                    Cijena = x.Cijena
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();

            List<Predstava> lista = db.Predstava.ToList();

            PrikazivanjeDodajVM model = new PrikazivanjeDodajVM()
            {
                Prikazivanje = new Prikazivanje(),
                Predstavae = db.Predstava.Select(x => new SelectListItem()
                {
                    Value = x.PredstavaID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                Sale = db.Sala.Select(x => new SelectListItem()
                {
                    Value = x.SalaID.ToString(),
                    Text = x.Naziv
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Snimi(PrikazivanjeDodajVM model)
        {
            MyContext db = new MyContext();
            Prikazivanje p = model.Prikazivanje;
            db.Prikazivanje.Add(p);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Prikazivanje p = db.Prikazivanje.Find(id);
            db.Prikazivanje.Remove(p);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Prikazivanje u = db.Prikazivanje.Where(x => x.PrikazivanjeID == id).Include(x => x.Sala).Include(x => x.Predstava).FirstOrDefault();

            PrikazivanjeUrediVM model = new PrikazivanjeUrediVM()
            {
                PrikazivanjeID = id,
                Sala = db.Sala.Select(x => new SelectListItem()
                {
                    Value = x.SalaID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                salaid = u.SalaID,
                Predstava = db.Predstava.Select(x => new SelectListItem()
                {
                    Value = x.PredstavaID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                predstavaid = u.PredstavaID,
                datumPrikazivanja = u.DatumPrikazivanja,
                Cijena = u.Cijena,
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult UrediSnimi(PrikazivanjeUrediVM model)
        {
            MyContext db = new MyContext();
            Prikazivanje u = db.Prikazivanje.Where(x => x.PrikazivanjeID == model.PrikazivanjeID).Include(x => x.Sala).Include(x => x.Predstava).FirstOrDefault();


            u.PrikazivanjeID = model.PrikazivanjeID;
            u.SalaID = model.salaid;
            u.PredstavaID = model.predstavaid;
            u.DatumPrikazivanja = model.datumPrikazivanja;
            u.Cijena = model.Cijena;
            List<SelectListItem> sala = db.Sala.Select(x => new SelectListItem()
            {
                Value = x.SalaID.ToString(),
                Text = x.Naziv
            }).ToList();
            sala = model.Sala;

            List<SelectListItem> predstava = db.Predstava.Select(x => new SelectListItem()
            {
                Value = x.PredstavaID.ToString(),
                Text = x.Naziv
            }).ToList();
            predstava = model.Predstava;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
    
     }
}