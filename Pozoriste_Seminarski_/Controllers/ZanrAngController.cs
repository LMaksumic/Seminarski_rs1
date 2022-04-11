using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pozoriste;
using Pozoriste.EntityModels;
using Pozoriste_Seminarski_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pozoriste_Seminarski_.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]
        public class ZanrAngController : ControllerBase
        {
            private MyContext _context = new MyContext();
            [HttpGet]
            public ZanrPrikaziVM Ucitaj()
            {
                ZanrPrikaziVM model = new ZanrPrikaziVM()
                {
                    lista = _context.Zanr.Select(x => new ZanrPrikaziVM.Row()
                    {
                        Naziv = x.Naziv,
                        Id = x.ZanrID
                    }).ToList()
                };
                return model;
            }

            [HttpGet("{id}")]
            public ZanrViewModel UcitajPoId(int id)
            {
                var zanr = _context.Set<Zanr>().Find(id);
                var res = new ZanrViewModel()
                {
                    ZanrID = zanr.ZanrID,
                    Naziv = zanr.Naziv
                };
                return res;
            }

            [HttpPost]
            public async Task Dodaj(ZanrDodajViewModel model)
            {
                var zanr = new Zanr
                {
                    Naziv = model.Naziv
                };
                await _context.AddAsync(zanr);
                await _context.SaveChangesAsync();
            }

            [HttpPost("{id}")]
            public async Task Uredi(int id, ZanrUrediVM model)
            {
                var zanr = _context.Set<Zanr>().Find(id);
                zanr.Naziv = model.Naziv;
                await _context.SaveChangesAsync();
            }

            [HttpDelete("{id}")]
            public async Task Obrisi(int id)
            {
                var zanr = _context.Set<Zanr>().Find(id);
                _context.Remove(zanr);
                await _context.SaveChangesAsync();
            }
        }
}
