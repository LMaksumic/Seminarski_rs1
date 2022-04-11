using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pozoriste;
using Pozoriste.EntityModels;
using Pozoriste_Seminarski_.Models;

namespace Pozoriste_Seminarski_.Controllers
{
    public class GlumacController : Controller
    {

        public readonly IHostingEnvironment _hostingEnvironment;

        public GlumacController(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Prikazi(string search)
        {
            MyContext db = new MyContext();
            GlumacPrikaziVM model = new GlumacPrikaziVM()
            {
                lista = db.Glumac.Select(x => new GlumacPrikaziVM.Row()
                {
                    Id = x.GlumacID,
                    adresaaSlike = x.AdresaSlike,
                    BrojUgovora = x.BrojUgovora,
                    DatumRodjenja = x.DatumRodjenja,
                    Email = x.Email,
                    Ime = x.Ime,
                    Prezime = x.Prezime
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();

            GlumacDodajVM model = new GlumacDodajVM()
            {
                Glumac = new Glumac()
            };
            return View(model);
        }
        public IActionResult Snimi(GlumacDodajVM model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                string uniqueFileName = null;
                if (model.Photo != null)
                {

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Glumac g = new Glumac
                {
                    AdresaSlike = uniqueFileName,
                    BrojUgovora = model.Glumac.BrojUgovora,
                    DatumRodjenja = model.Glumac.DatumRodjenja,
                    Email = model.Glumac.Email,
                    Ime = model.Glumac.Ime,
                    Prezime = model.Glumac.Prezime
                };
                db.Glumac.Add(g);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi");
            }
            return View("Dodaj");
        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Glumac g = db.Glumac.Find(id);

            List<GlumacPredstava> gplist = db.GlumacPredstava.Where(x => x.GlumacID == id).ToList();
            foreach (var gp in gplist)
            {
                db.GlumacPredstava.Remove(gp);
            }

            db.Glumac.Remove(g);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Glumac g = db.Glumac.Where(x => x.GlumacID == id).FirstOrDefault();

            GlumacUrediVM model = new GlumacUrediVM()
            {
                id = g.GlumacID,
                adresaaSlike = g.AdresaSlike,
                BrojUgovora = g.BrojUgovora,
                DatumRodjenja = g.DatumRodjenja,
                Email = g.Email,
                Ime = g.Ime,
                Prezime = g.Prezime

            };
            db.Dispose();
            return View(model);
        }
        public IActionResult UrediSnimi(GlumacUrediVM model)
        {
            if (ModelState.IsValid)
            {
                MyContext db = new MyContext();
                Glumac glumac = db.Glumac.Where(x => x.GlumacID == model.id).FirstOrDefault();
                if (model.adresaaSlike != null)
                {
                    glumac.AdresaSlike = model.adresaaSlike;
                }

                string uniqueFileName = null;
                IFormFile slika = model.Photo;
                if (slika != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    glumac.AdresaSlike = uniqueFileName;
                }
                glumac.GlumacID = model.id;
                glumac.DatumRodjenja = model.DatumRodjenja;
                glumac.BrojUgovora = model.BrojUgovora;
                glumac.Email = model.Email;
                glumac.Ime = model.Ime;
                glumac.Prezime = model.Prezime;
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Prikazi");
            }
            return View("Uredi");
        }

    } 
}