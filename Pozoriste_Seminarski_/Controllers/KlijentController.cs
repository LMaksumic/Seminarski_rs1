using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pozoriste;
using Pozoriste.EntityModels;
using Pozoriste_Seminarski_.Helper;
using Pozoriste_Seminarski_.Models;

namespace Pozoriste_Seminarski_.Controllers
{
    public class KlijentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Novosti()
        {
            MyContext db = new MyContext();
            NovostiPrikaziVM model = new NovostiPrikaziVM()
            {

                lista = db.Novosti.Select(x => new NovostiPrikaziVM.Row()
                {
                    Id = x.NovostiID,
                    Naziv = x.Naziv,
                    DatumVrijemeObjave = x.DatumVrijemeObjave,
                    adresaaSlike = x.AdresaSlike,
                    KratkiSadrzaj = x.KratkiSadrzaj
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult NovostiOpsirnije(int id)
        {
            MyContext db = new MyContext();
            NovostiPrikaziVM model = new NovostiPrikaziVM()
            {
                lista = db.Novosti.Where(x => x.NovostiID == id).Select(x => new NovostiPrikaziVM.Row()
                {
                    Id = x.NovostiID,
                    Naziv = x.Naziv,
                    Tekst = x.Tekst,
                    DatumVrijemeObjave = x.DatumVrijemeObjave,
                    adresaaSlike = x.AdresaSlike
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }



        public IActionResult ONama()
        {
            return View();
        }

        public IActionResult Galerija()
        {
            return View();
        }


        public IActionResult MojeRezervacije(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            RezervacijaPrikaziVM model = new RezervacijaPrikaziVM()
            {
                kupacId = id,
                lista = db.Rezervacija.Where(x => x.Kupac.KorisnickiNalog.Username == korisnik.Username).Select(x => new RezervacijaPrikaziVM.Row()
                {
                    DatumIsteka = x.DatumIsteka,
                    DatumRezervacije = x.DatumRezervacije,
                    Id = x.RezervacijaID,
                    ImePrezime = x.Kupac.Ime + x.Kupac.Prezime,
                    Odobrena = x.Odobrena
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult MojeUlaznice(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            UlaznicaPrikaziVM model = new UlaznicaPrikaziVM()
            {
                kupacId = id,

                lista = db.Ulaznica.Where(x => x.Kupac.KorisnickiNalog.Username == korisnik.Username).Select(x => new UlaznicaPrikaziVM.Row()
                {
                    ulaznicaId = x.UlaznicaID,
                    ImePrezime = x.Kupac.Ime + x.Kupac.Prezime,
                    sjediste = "Red: " + x.Sjediste.Red + "; Kolona: " + x.Sjediste.Kolona,
                    prikazivanje = db.Rezervacija.Where(y => y.RezervacijaID == x.RezervacijaID).Include(y => y.Prikazivanje).ThenInclude(y => y.Predstava).Select(y => y.Prikazivanje.Predstava.Naziv + " / " + y.Prikazivanje.DatumPrikazivanja).FirstOrDefault(),
                    Cijena = db.Rezervacija.Where(y => y.RezervacijaID == x.RezervacijaID).Include(y => y.Prikazivanje).Select(y => y.Prikazivanje.Cijena).FirstOrDefault()
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult UlaznicaDetalji(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            UlaznicaPrikaziVM model = new UlaznicaPrikaziVM()
            {
                kupacId = id,

                lista = db.Ulaznica.Where(x => x.UlaznicaID == id).Select(x => new UlaznicaPrikaziVM.Row()
                {
                    ulaznicaId = x.UlaznicaID,
                    ImePrezime = x.Kupac.Ime + " " + x.Kupac.Prezime,
                    sjediste = "Red: " + x.Sjediste.Red + "; Kolona: " + x.Sjediste.Kolona,
                    prikazivanje = db.Rezervacija.Where(y => y.RezervacijaID == x.RezervacijaID).Include(y => y.Prikazivanje).ThenInclude(y => y.Predstava).Select(y => y.Prikazivanje.Predstava.Naziv + " / " + y.Prikazivanje.DatumPrikazivanja).FirstOrDefault(),
                    Cijena = db.Rezervacija.Where(y => y.RezervacijaID == x.RezervacijaID).Include(y => y.Prikazivanje).Select(y => y.Prikazivanje.Cijena).FirstOrDefault()
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Predstava()
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
                    Trajanje = x.Trajanje,
                    //ProsjecnaOcjena = ProsjecnaOcjena(x.PredstavaID)
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult Opsirnije(int id)
        {
            MyContext db = new MyContext();

            PrikazivanjePrikaziVM model = new PrikazivanjePrikaziVM()
            {
                predstava = db.Predstava.Where(x => x.PredstavaID == id).Select(x => x.Naziv).FirstOrDefault(),
                predstavaID = id,
                opis = db.Predstava.Where(x => x.PredstavaID == id).Select(x => x.Opis).FirstOrDefault(),
                lista = db.Prikazivanje.Where(x => x.PredstavaID == id).Select(x => new PrikazivanjePrikaziVM.Row()
                {
                    DatumPrikazivanja = x.DatumPrikazivanja,
                    PrikazivanjeID = x.PrikazivanjeID,
                    Sale = x.Sala.Naziv,
                    Cijena = x.Cijena
                }).ToList()
            };
            db.Dispose();
            return View(model);

        }











        public IActionResult Rezervacija(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();

            //int klijentid = korisnik.KorisnickiNalogID;
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.Username == korisnik.Username).FirstOrDefault();
            Rezervacija r = new Rezervacija()
            {
                DatumRezervacije = DateTime.Now,
                DatumIsteka = db.Prikazivanje.Where(x => x.PrikazivanjeID == id).FirstOrDefault().DatumPrikazivanja,
                Odobrena = false,
                KupacID = korisnik.KorisnickiNalogID,
                Kupac = db.Kupac.Where(x => x.KorisnickiNalogID == korisnik.KorisnickiNalogID).FirstOrDefault(),
                PrikazivanjeID = id,
                Prikazivanje = db.Prikazivanje.Find(id)
            };

            db.Rezervacija.Add(r);
            string kupac = db.Kupac.Where(x => x.KupacID == r.KupacID).Select(x => x.Ime + " " + x.Prezime).FirstOrDefault();
            string prikazivanje = db.Prikazivanje.Where(x => x.PrikazivanjeID == r.PrikazivanjeID).Select(x => x.Predstava.Naziv + "/" + x.DatumPrikazivanja).FirstOrDefault();

            db.SaveChanges();

            return RedirectToAction("MojeRezervacije");
        }
    
    public IActionResult OdaberiSjediste(int id)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();
            SjedistePrikaziVMKlijent model = new SjedistePrikaziVMKlijent()
            {
                lista = db.Sjediste.Select(x => new SjedistePrikaziVMKlijent.Row()
                {
                    SjedisteID = x.SjedisteID,
                    Kolona = x.Kolona,
                    Red = x.Red,
                    NazivSale = x.Sala.Naziv
                }).ToList()
            };
            db.Dispose();
            return View(model);

        }

        public decimal ProsjecnaOcjena(int id)
        {
            MyContext db = new MyContext();
            Predstava s = db.Predstava.Where(x => x.PredstavaID == id).FirstOrDefault();
            s.ProsjecnaOcjena = db.PredstavaKupac
                .Where(x => x.PredstavaID == s.PredstavaID)
                .Average(x => (decimal?)x.Ocjena) ?? new decimal();

            return s.ProsjecnaOcjena;
        }

        public IActionResult KupiUlaznicu(int id)
        {
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();

            Rezervacija r = db.Rezervacija.Where(x => x.RezervacijaID == id).FirstOrDefault();
            Prikazivanje p = db.Prikazivanje.Where(x => x.PrikazivanjeID == r.PrikazivanjeID).FirstOrDefault();
            List<Ulaznica> ul = db.Ulaznica.Where(x => x.PrikazivanjeID == p.PrikazivanjeID).Include(x => x.Sjediste).Include(x => x.Prikazivanje).ThenInclude(x => x.Sala)/*.Select(x=>x.SjedisteID)*/.ToList();
            Ulaznica u = db.Ulaznica.Where(x => x.PrikazivanjeID == p.PrikazivanjeID).FirstOrDefault();
            List<Sjediste> sjed = db.Sjediste.ToList();
            List<Sjediste> sjed2 = ul.Select(x => x.Sjediste).ToList();

            var lista = sjed.Except(sjed2);

            UlaznicaDodajVM model = new UlaznicaDodajVM()
            {
                Ulaznica = new Ulaznica()
                {
                    RezervacijaID = id
                },
                KupacId = korisnik.KorisnickiNalogID,
                Kupac = db.Kupac.Where(x => x.KorisnickiNalogID == korisnik.KorisnickiNalogID).Select(x => x.Ime + " " + x.Prezime).FirstOrDefault(),
                Prikazivanje = db.Rezervacija.Where(y => y.RezervacijaID == id).Include(y => y.Prikazivanje).ThenInclude(y => y.Predstava).Select(y => y.Prikazivanje.Predstava.Naziv + " / " + y.Prikazivanje.DatumPrikazivanja).FirstOrDefault(),
                Cijena = db.Rezervacija.Where(y => y.RezervacijaID == id).Include(y => y.Prikazivanje).Select(y => y.Prikazivanje.Cijena).FirstOrDefault(),
                Sjedista = lista.Select(m => new SelectListItem()
                {
                    Value = m.SjedisteID.ToString(),
                    Text =/*m.Sala.Naziv + ";*/ "Red: " + m.Red + " ; Kolona: " + m.Kolona
                }).ToList()

            };
            return View(model);
        }
        public IActionResult DodajKomentar(int id)
        {
            MyContext db = new MyContext();

            KomentarDodaj model = new KomentarDodaj()
            {
                id = id,
                predstava = db.Predstava.Where(x => x.PredstavaID == id).Select(x => x.Naziv).FirstOrDefault(),
                Komentar = new Komentar()
                {
                    PredstavaID = id
                }

            };
            return View(model);
        }

        public IActionResult SnimiKomentar(KomentarDodaj model)
        {

            KorisnickiNalog kupac = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();

            Komentar k = new Komentar
            {
                KupacID = kupac.KorisnickiNalogID,
                Kupac = db.Kupac.Where(x => x.KorisnickiNalogID == kupac.KorisnickiNalogID).FirstOrDefault(),
                PredstavaID = model.Komentar.PredstavaID,
                Odobren = false,
                Sadrzaj = model.Komentar.Sadrzaj,
                VrijemeKreiranja = DateTime.Now
            };
            db.Komentar.Add(k);
            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("Predstava");

        }

        public IActionResult PrikazKomentara(int id)
        {
            MyContext db = new MyContext();
            KomentarPrikaziVM model = new KomentarPrikaziVM()
            {
                predstavaId = id,
                predstava = db.Predstava.Where(x => x.PredstavaID == id).Select(x => x.Naziv).FirstOrDefault(),
                lista = db.Komentar.Where(x => x.PredstavaID == id).Select(x => new KomentarPrikaziVM.Row()
                {
                    predstava = db.Predstava.Where(y => y.PredstavaID == id).Select(y => y.Naziv).FirstOrDefault(),
                    kupac = x.Kupac.Ime + " " + x.Kupac.Prezime,
                    VrijemeKreiranja = x.VrijemeKreiranja,
                    Id = x.KomentarID,
                    Sadrzaj = x.Sadrzaj,
                    Odobren = x.Odobren
                }).ToList()
            };
            db.Dispose();
            return View(model);
        }


        public IActionResult SnimiUlaznicu(UlaznicaDodajVM model)
        {
            KorisnickiNalog kupac = HttpContext.GetLogiraniKorisnik();
            MyContext db = new MyContext();

            Kupac k = db.Kupac.Where(x => x.KorisnickiNalogID == kupac.KorisnickiNalogID).FirstOrDefault();
            Rezervacija r = db.Rezervacija.Where(x => x.RezervacijaID == model.Ulaznica.RezervacijaID).FirstOrDefault();
            Prikazivanje p = db.Prikazivanje.Where(x => x.PrikazivanjeID == r.PrikazivanjeID).FirstOrDefault();

            Ulaznica u = model.Ulaznica;
            u.KupacID = kupac.KorisnickiNalogID;
            u.Kupac = db.Kupac.Where(x => x.KorisnickiNalogID == kupac.KorisnickiNalogID).FirstOrDefault();
            u.RezervacijaID = model.Ulaznica.RezervacijaID;
            u.PrikazivanjeID = p.PrikazivanjeID;

            db.Ulaznica.Add(u);

            int cijena = Convert.ToInt32(p.Cijena);
           
         
                db.Kupac.Update(k);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("MojeUlaznice");
          
                return RedirectToAction("MojeUlaznice");
            
        }

        public IActionResult OtkaziRezervaciju(int id)
        {
            MyContext db = new MyContext();
            Rezervacija r = db.Rezervacija.Find(id);
            Prikazivanje p = db.Prikazivanje.Where(x => x.PrikazivanjeID == r.PrikazivanjeID).FirstOrDefault();
            if ((p.DatumPrikazivanja - DateTime.Now).TotalDays < 3)
            {
                TempData["error_poruka2"] = "Greška! Rezervaciju je moguće otkazati 3 dana prije prikazivanja!";
                return RedirectToAction("MojeRezervacije");
            }
            else
            {
                db.Rezervacija.Remove(r);
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("MojeRezervacije");
            }

        }

        public IActionResult UrediProfil(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.Username == korisnik.Username).FirstOrDefault();
            KorisnickiProfilVM model = new KorisnickiProfilVM()
            {
                KupacID = id,
                BrojTelefona = k.BrojTelefona,
                Ime = k.Ime,
                Prezime = k.Prezime,
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult SnimiProfil(KorisnickiProfilVM model)
        {

            MyContext db = new MyContext();
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.Username == korisnik.Username).FirstOrDefault();
           
            k.Prezime = model.Prezime;
            k.Ime = model.Ime;
            k.BrojTelefona = model.BrojTelefona;

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("ONama");
        }

        public IActionResult PromijeniLozinku(int id)
        {
            MyContext db = new MyContext();

            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.Username == korisnik.Username).Include(x => x.KorisnickiNalog).FirstOrDefault();
            LoginVM model = new LoginVM()
            {

                Username = k.KorisnickiNalog.Username,
                Password = k.KorisnickiNalog.Password
            };
            db.Dispose();
            return View(model);
        }

        public IActionResult PromijeniLozinkuSnimi(LoginVM model)
        {

            MyContext db = new MyContext();
            KorisnickiNalog korisnik = HttpContext.GetLogiraniKorisnik();
            Kupac k = db.Kupac.Where(x => x.KorisnickiNalog.Username == korisnik.Username).Include(x => x.KorisnickiNalog).FirstOrDefault();
            k.KorisnickiNalog.Username = model.Username;

            k.KorisnickiNalog.Password = model.Password;

            db.SaveChanges();
            db.Dispose();
            return RedirectToAction("ONama");
        }
    }
}