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
    public class ZanrController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();

            ZanrPrikaziVM model = new ZanrPrikaziVM()
            {
                lista = db.Zanr.Select(x => new ZanrPrikaziVM.Row()
                {
                    Id = x.ZanrID,
                    Naziv = x.Naziv,
                }).ToList()
            };

            return View(model);
        }

        public IActionResult Dodaj()
        {
            ZanrDodajVM model = new ZanrDodajVM()
            {
                Zanr = new Zanr()
            };
            return View(model);
        }


        public IActionResult Snimi(ZanrDodajVM model)
        {
            MyContext db = new MyContext();
            Zanr zanr = model.Zanr;
            db.Zanr.Add(zanr);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Zanr z = db.Zanr.Find(id);
            db.Zanr.Remove(z);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Zanr g = db.Zanr.Where(x => x.ZanrID == id).FirstOrDefault();
            db.Dispose();
            return View(g);
        }

        public IActionResult UrediSnimi(Zanr model)
        {
            MyContext db = new MyContext();
            Zanr g = db.Zanr.Where(x => x.ZanrID == model.ZanrID).FirstOrDefault();
            g.ZanrID = model.ZanrID;
            g.Naziv = model.Naziv;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
    }
}