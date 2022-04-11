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
using Pozoriste_Seminarski_.Helper;
using Pozoriste_Seminarski_.Models;

namespace Pozoriste_Seminarski_.Controllers
{
    public class NovostiController : Controller
    {


        public readonly IHostingEnvironment _hostingEnvironment;

        public NovostiController(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;

        }
        public IActionResult Prikazi()
        {
            MyContext db = new MyContext();
            NovostiPrikaziVM model = new NovostiPrikaziVM()
            {
                lista = db.Novosti.Select(x => new NovostiPrikaziVM.Row()
                {
                    DatumVrijemeObjave = x.DatumVrijemeObjave,
                    Naziv = x.Naziv,
                    Id = x.NovostiID,
                    Tekst = x.Tekst,
                    adresaaSlike = x.AdresaSlike,
                    KratkiSadrzaj = x.KratkiSadrzaj
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }


        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();

            NovostiDodajVM model = new NovostiDodajVM()
            {
                Novosti = new Novosti()
            };
            return View(model);
        }

        public IActionResult Snimi(NovostiDodajVM model)
        {
            KorisnickiNalog admin = HttpContext.GetLogiraniKorisnik();


            MyContext db = new MyContext();
            string uniqueFileName = null;
            if (model.Photo != null)
            {

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Novosti n = new Novosti
            {
                AdresaSlike = uniqueFileName,
                DatumVrijemeObjave = DateTime.Now,
                Tekst = model.Novosti.Tekst,
                Naziv = model.Novosti.Naziv,
                AdminID = admin.KorisnickiNalogID,
                Admin = db.Admin.Where(x => x.KorisnickiNalogID == admin.KorisnickiNalogID).FirstOrDefault(),
                KratkiSadrzaj = model.Novosti.KratkiSadrzaj
            };
            db.Novosti.Add(n);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }

        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Novosti n = db.Novosti.Find(id);
            db.Novosti.Remove(n);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Novosti n = db.Novosti.Where(x => x.NovostiID == id).FirstOrDefault();

            NovostiUrediVM model = new NovostiUrediVM()
            {
                id = n.NovostiID,
                adresaaSlike = n.AdresaSlike,
                Naziv = n.Naziv,
                DatumVrijemeObjave = n.DatumVrijemeObjave,
                Tekst = n.Tekst,
                KratkiSadrzaj = n.KratkiSadrzaj
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult UrediSnimi(NovostiUrediVM model)
        {

            MyContext db = new MyContext();
            Novosti novosti = db.Novosti.Where(x => x.NovostiID == model.id).FirstOrDefault();


            string uniqueFileName = null;
            IFormFile slika = model.Photo;
            if (slika != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                novosti.AdresaSlike = uniqueFileName;
            }
            novosti.NovostiID = model.id;
            novosti.DatumVrijemeObjave = model.DatumVrijemeObjave;
            novosti.Naziv = model.Naziv;
            novosti.Tekst = model.Tekst;
            novosti.KratkiSadrzaj = model.KratkiSadrzaj;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
    }
}