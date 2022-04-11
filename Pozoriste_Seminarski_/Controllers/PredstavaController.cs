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
    public class PredstavaController : Controller
    {
        public IActionResult Prikazi(int TrenutnaStranica = 1, int VelicinaStranice = 4)
        {
            MyContext db = new MyContext();
            PredstavaPrikaziVM model = new PredstavaPrikaziVM()
            {
                lista = db.Predstava.Select(x => new PredstavaPrikaziVM.Row()
                {
                    PredstavaID = x.PredstavaID,
                    Naziv = x.Naziv,
                    NazivZanra = x.Zanr.Naziv,
                    Opis = x.Opis,
                    Reziser = x.Reziser,
                    Trajanje = x.Trajanje
                   
                }).ToList()
            };
            TempData["trenutna"] = TrenutnaStranica;
            var items = model.lista.OrderBy(x => x.Naziv).Skip((TrenutnaStranica - 1) * VelicinaStranice).Take(VelicinaStranice).ToList();

            //db.Dispose();
            return PartialView(items);
        }
        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();

            PredstavaDodajVM model = new PredstavaDodajVM()
            {
                Predstava = new Predstava(),
                Zanr = db.Zanr.Select(x => new SelectListItem
                {
                    Value = x.ZanrID.ToString(),
                    Text = x.Naziv
                }).ToList()
            };
            return View(model);
        }
        public IActionResult Detalji(int id)
        {
            MyContext db = new MyContext();
            Predstava s = db.Predstava.Where(x => x.PredstavaID == id).FirstOrDefault();
            return View(s);
        }



        public IActionResult Snimi(PredstavaDodajVM model)
        {

            MyContext db = new MyContext();
            Predstava p = model.Predstava;
            db.Predstava.Add(p);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }


        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Predstava p = db.Predstava.Find(id);

            List<Prikazivanje> pr = db.Prikazivanje.Where(x => x.PredstavaID == p.PredstavaID).ToList();
            List<PredstavaKupac> pk = db.PredstavaKupac.Where(x => x.PredstavaID == p.PredstavaID).ToList();
            List<Komentar> kom = db.Komentar.Where(x => x.PredstavaID == p.PredstavaID).ToList();
            List<GlumacPredstava> gp = db.GlumacPredstava.Where(x => x.PredstavaID == p.PredstavaID).ToList();
       
            foreach (var y in pr)
            {
                var prik = y.PrikazivanjeID;
                List<Rezervacija> r = db.Rezervacija.Where(x => x.PrikazivanjeID == prik).ToList();
                foreach (var z in r)
                {
                    var rez = z.RezervacijaID;
                    List<Ulaznica> ul = db.Ulaznica.Where(x => x.RezervacijaID == rez).ToList();
                    foreach (var yz in ul)
                    {
                        db.Ulaznica.Remove(yz);
                    }
                    db.Rezervacija.Remove(z);
                }
                db.Prikazivanje.Remove(y);
            }
            foreach (var y in pk)
            {
                db.PredstavaKupac.Remove(y);
            }
            foreach (var y in kom)
            {
                db.Komentar.Remove(y);
            }
            foreach (var y in gp)
            {
                db.GlumacPredstava.Remove(y);
            }
           

            db.Predstava.Remove(p);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }




        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Predstava p = db.Predstava.Where(x => x.PredstavaID == id).Include(x => x.Zanr).FirstOrDefault();
            PredstavaUrediVM model = new PredstavaUrediVM()
            {
                PredstavaID = id,
                Zanr = db.Zanr.Select(x => new SelectListItem()
                {
                    Value = x.ZanrID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                Naziv = p.Naziv,
                Opis = p.Opis,
                Reziser = p.Reziser,
                Trajanje = p.Trajanje,
                zanrId = p.ZanrID
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult DodajGlumce()
        {
            MyContext db = new MyContext();

            PredstavaGlumacDodajVM model = new PredstavaGlumacDodajVM()
            {
                GlumacPredstava = new GlumacPredstava(),
                Predstava = db.Predstava.Select(x => new SelectListItem
                {
                    Value = x.PredstavaID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                Glumac = db.Glumac.Select(x => new SelectListItem
                {
                    Value = x.GlumacID.ToString(),
                    Text = x.Ime + " " + x.Prezime
                }).ToList()
            };
            return View(model);
        }


        public IActionResult SnimiGlumca(PredstavaGlumacDodajVM model)
        {
            MyContext db = new MyContext();
            GlumacPredstava p = model.GlumacPredstava;

            db.GlumacPredstava.Add(p);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");

        }

        public IActionResult UrediSnimi(PredstavaUrediVM model)
        {
            MyContext db = new MyContext();
            Predstava p = db.Predstava.Where(x => x.PredstavaID == model.PredstavaID).Include(x => x.Zanr).FirstOrDefault();

            p.PredstavaID = model.PredstavaID;
            p.Reziser = model.Reziser;
            p.Naziv = model.Naziv;
            p.Opis = model.Opis;
            p.ZanrID = model.zanrId;
            List<SelectListItem> zanr = db.Zanr.Select(x => new SelectListItem()
            {
                Value = x.ZanrID.ToString(),
                Text = x.Naziv
            }).ToList();
            zanr = model.Zanr;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

    }
}