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
    public class GradController : Controller
    {
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            GradPrikaziVM model = new GradPrikaziVM()
            {
                lista = db.Grad.Select(x => new GradPrikaziVM.Row()
                {
                    Naziv = x.Naziv,
                    Id = x.GradID
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult Dodaj()
        {
            GradDodajVM model = new GradDodajVM()
            {
                Grad = new Grad()
            };
            return View(model);
        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Grad grad = db.Grad.Find(id);
            db.Grad.Remove(grad);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Snimi(GradDodajVM model)
        {
            if (ModelState.IsValid)
            {
          
                MyContext db = new MyContext();
                Grad g = model.Grad;
                db.Grad.Add(g);
                db.SaveChanges();
                db.Dispose();

                return RedirectToAction("Prikazi");
            }
            return View("Dodaj");
        }
        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Grad g = db.Grad.Where(x => x.GradID == id).FirstOrDefault();
            db.Dispose();
            return View(g);
        }
        public IActionResult UrediSnimi(Grad model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Grad g = db.Grad.Where(x => x.GradID == model.GradID).FirstOrDefault();
                g.GradID = model.GradID;
                g.Naziv = model.Naziv;
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi");
            }
            return View("Uredi");

        }
    }
}