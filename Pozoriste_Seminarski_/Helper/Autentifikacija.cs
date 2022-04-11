using Microsoft.AspNetCore.Http;
using Pozoriste.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pozoriste;

namespace Pozoriste_Seminarski_.Helper
{
    public static class Autentifikacija
    {
        public static readonly string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, KorisnickiNalog korisnik)
        {

            context.Session.Set(LogiraniKorisnik, korisnik);

            MyContext db = context.RequestServices.GetService<MyContext>();

        }

       
        public static KorisnickiNalog GetLogiraniKorisnik(this HttpContext context)
        {
            return context.Session.Get<KorisnickiNalog>(LogiraniKorisnik);
         
        }
    }
    }
