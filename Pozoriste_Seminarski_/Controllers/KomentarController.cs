using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pozoriste;
using Pozoriste.EntityModels;
using Pozoriste_Seminarski_.Models;

namespace Pozoriste_Seminarski_.Controllers
{
    public class KomentarController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            KomentarPrikaziVM model = new KomentarPrikaziVM()
            {
                lista = db.Komentar.Select(x => new KomentarPrikaziVM.Row()
                {
                    Sadrzaj = x.Sadrzaj,
                    Id = x.KomentarID,
                    Odobren = x.Odobren,
                    VrijemeKreiranja = x.VrijemeKreiranja,
                    kupac = db.Kupac.Where(m => m.KupacID == x.KupacID).Select(m => m.Ime).FirstOrDefault(),
                    predstava = db.Predstava.Where(m => m.PredstavaID == x.PredstavaID).Select(m => m.Naziv).FirstOrDefault()
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Komentar k = db.Komentar.Find(id);
            db.Komentar.Remove(k);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Odobri(int id)
        {
            MyContext db = new MyContext();
            Komentar k = db.Komentar.Find(id);
            if (k.Odobren == false)
            {
                k.Odobren = true;
            }
            db.SaveChanges();
            return RedirectToAction("Prikazi");

        }

    }
}