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
    public class SalaController : Controller
    {
        public IActionResult Prikazi(string search)
        {
            MyContext db = new MyContext();

            return View(db.Sala.Where(x => x.Naziv.ToLower().StartsWith(search) || x.Naziv.ToUpper().StartsWith(search) || search == null).ToList());
        }
        public IActionResult Dodaj()
        {
            SalaDodajVM model = new SalaDodajVM()
            {
                Sala = new Sala()
            };
            return View(model);
        }
        public IActionResult Snimi(SalaDodajVM model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Sala sala = model.Sala;
                db.Sala.Add(sala);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi");
            }
            return View("Dodaj");
        }


        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Sala s = db.Sala.Find(id);
            db.Sala.Remove(s);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Sala s = db.Sala.Where(x => x.SalaID == id).FirstOrDefault();
            db.Dispose();
            return View(s);
        }

        public IActionResult UrediSnimi(Sala model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Sala sala = db.Sala.Where(x => x.SalaID == model.SalaID).FirstOrDefault();
                sala.SalaID = model.SalaID;

                sala.Naziv = model.Naziv;
                sala.Kapacitet = model.Kapacitet;
                sala.Klimatizacija = model.Klimatizacija;

                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi");
            }
            return View("Uredi");
        }
    }
}