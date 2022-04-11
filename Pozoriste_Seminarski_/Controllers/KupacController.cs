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
    public class KupacController : Controller
    {
        public IActionResult Prikazi(int TrenutnaStranica = 1, int VelicinaStranice = 6)
        {
            MyContext db = new MyContext();

            KupacPrikaziVM model = new KupacPrikaziVM()
            {
                lista = db.Kupac.Select(x => new KupacPrikaziVM.Row()
                {
                    BrojTelefona = x.BrojTelefona,
                    Ime = x.Ime,
                    KupacID = x.KupacID,
                    NazivGrada = x.Grad.Naziv,
                    Prezime = x.Prezime,
                    Email = x.Email
                }).ToList()
            };
            TempData["trenutna"] = TrenutnaStranica;
            var items = model.lista.OrderBy(x => x.Ime).Skip((TrenutnaStranica - 1) * VelicinaStranice).Take(VelicinaStranice).ToList();
            //   db.Dispose();
            return PartialView(items);
        }
        public IActionResult Dodaj()
        {
            MyContext db = new MyContext();

            KupacDodajVM model = new KupacDodajVM()
            {
                Kupac = new Kupac(),
                grad = db.Grad.Select(x => new SelectListItem()
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),
            };
            return View(model);
        }
        public IActionResult Snimi(KupacDodajVM model)
        {

            MyContext db = new MyContext();

            KorisnickiNalog nalog = new KorisnickiNalog();
            db.KorisnickiNalog.Add(nalog);
            db.SaveChanges();

            Kupac k = model.Kupac;

            List<int> nalozi = db.KorisnickiNalog.Select(x => x.KorisnickiNalogID).ToList();

            k.KorisnickiNalogID = nalozi.LastOrDefault();

            db.Kupac.Add(k);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }

        public IActionResult Uredi(int id)
        {
            MyContext db = new MyContext();

            Kupac k = db.Kupac.Where(x => x.KupacID == id).Include(x => x.Grad).FirstOrDefault();
            KupacUrediVM model = new KupacUrediVM()
            {
                KupacID = id,
                Grad = db.Grad.Select(x => new SelectListItem()
                {
                    Value = x.GradID.ToString(),
                    Text = x.Naziv
                }).ToList(),
                BrojTelefona = k.BrojTelefona,
                gradid = k.GradID,
                Ime = k.Ime,
                Prezime = k.Prezime,
                Email = k.Email
            };
            db.Dispose();
            return View(model);
        }
        public IActionResult UrediSnimi(KupacUrediVM model)
        {

            MyContext db = new MyContext();
            Kupac k = db.Kupac.Where(x => x.KupacID == model.KupacID).Include(x => x.Grad).FirstOrDefault();

            k.KupacID = model.KupacID;
            k.Prezime = model.Prezime;
            k.Ime = model.Ime;
            k.GradID = model.gradid;
            k.BrojTelefona = model.BrojTelefona;
            k.Email = model.Email;
            List<SelectListItem> grad = db.Grad.Select(x => new SelectListItem()
            {
                Value = x.GradID.ToString(),
                Text = x.Naziv
            }).ToList();
            grad = model.Grad;
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
        public IActionResult Obrisi(int id)
        {
            MyContext db = new MyContext();
            Kupac k = db.Kupac.Find(id);

            List<PredstavaKupac> pkList = db.PredstavaKupac.Where(x => x.KupacID == id).ToList();
            foreach (var pk in pkList)
            {
                db.PredstavaKupac.Remove(pk);
            }

          
            List<Rezervacija> rList = db.Rezervacija.Where(x => x.KupacID == id).ToList();
            foreach (var r in rList)
            {
                var rez = r.RezervacijaID;
                List<Ulaznica> ul = db.Ulaznica.Where(x => x.RezervacijaID == rez).ToList();
                foreach (var yz in ul)
                {
                    db.Ulaznica.Remove(yz);
                }
                db.Rezervacija.Remove(r);
            }
            List<Komentar> komList = db.Komentar.Where(x => x.KupacID == id).ToList();
            foreach (var kom in komList)
            {
                db.Komentar.Remove(kom);
            }

            db.Kupac.Remove(k);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Prikazi");
        }
    }
}