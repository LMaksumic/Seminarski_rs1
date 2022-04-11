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
    public class GradAngController : ControllerBase
    {
       
            private MyContext _context = new MyContext();
            [HttpGet]
            public GradPrikaziVM Ucitaj()
            {
                GradPrikaziVM model = new GradPrikaziVM()
                {
                    lista = _context.Grad.Select(x => new GradPrikaziVM.Row()
                    {
                        Naziv = x.Naziv,
                        Id = x.GradID
                    }).ToList()
                };
                return model;
            }

            [HttpGet("{id}")]
            public GradViewModel UcitajPoId(int id)
            {
                var grad = _context.Set<Grad>().Find(id);
                var res = new GradViewModel()
                {
                    GradID = grad.GradID,
                    Naziv = grad.Naziv
                };
                return res;
            }

            [HttpPost]
            public async Task Dodaj(GradDodajViewModel model)
            {
                var grad = new Grad
                {
                    Naziv = model.Naziv
                };
                await _context.AddAsync(grad);
                await _context.SaveChangesAsync();
            }

            [HttpPost("{id}")]
            public async Task Uredi(int id, GradUrediVM model)
            {
                var grad = _context.Set<Grad>().Find(id);
                grad.Naziv = model.Naziv;
                await _context.SaveChangesAsync();
            }

            [HttpDelete("{id}")]
            public async Task Obrisi(int id)
            {
                var grad = _context.Set<Grad>().Find(id);
                _context.Remove(grad);
                await _context.SaveChangesAsync();
            }
        }
    }

