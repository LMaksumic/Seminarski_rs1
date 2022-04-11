using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pozoriste;
using Pozoriste.EntityModels;
using Pozoriste_Seminarski_.Helper;
using Pozoriste_Seminarski_.Models;

namespace Pozoriste_Seminarski_.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = true
            });
        }

        public ActionResult Logout()
        {
            MyContext db = new MyContext();
            KorisnickiNalog nalog = HttpContext.GetLogiraniKorisnik();

            return RedirectToAction("Index");
        }

        public ActionResult Provjera(LoginVM Input)
        {
            MyContext _db = new MyContext();

            KorisnickiNalog korisnik = _db.KorisnickiNalog.SingleOrDefault(x => x.Username == Input.Username && x.Password == Input.Password);

            if (korisnik == null)
            {
                TempData["error_poruka"] = "pogresan username ili password";
                return View("Index", Input);
            }

            if (korisnik.KorisnickiNalogID <= 1)
            {
                HttpContext.SetLogiraniKorisnik(korisnik);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                HttpContext.SetLogiraniKorisnik(korisnik);

                return RedirectToAction("ONama", "Klijent");

            }
        }
    }
}