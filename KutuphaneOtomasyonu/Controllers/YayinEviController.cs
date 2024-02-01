using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KutuphaneOtomasyonu.Models;
using KutuphaneOtomasyonu.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace KutuphaneOtomasyonu.Controllers
{
    public class YayinEviController : Controller
    {
        private readonly YayinEviService _yayinEviService;
        private readonly AdresService _adresService;

        public YayinEviController(IConfiguration configuration)
        {
            _yayinEviService = new YayinEviService(configuration);
            _adresService = new AdresService(configuration);
        }

        public IActionResult Index()
        {
            var list = (from y in _yayinEviService.FindAll()
                        from a in _adresService.FindAll()
                        where y.AdresId == a.Id
                        select new YayinEvi
                        {
                            Id = y.Id,
                            Ad = y.Ad,
                            Adres = a
                        }).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewData["AdresId"] = new SelectList(_adresService.FindAll(), "Id", "Ilce");
            return View();
        }

        [HttpPost]
        public IActionResult Create(YayinEvi yayinEvi)
        {
            if (ModelState.IsValid)
            {
                _yayinEviService.Add(yayinEvi);
                return RedirectToAction("Index");
            }
            ViewData["AdresId"] = new SelectList(_adresService.FindAll(), "Id", "Ilce",yayinEvi.AdresId);
            return View(yayinEvi);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            YayinEvi y = _yayinEviService.FindById(id.Value);
            if (y == null)
            {
                return NotFound();
            }
            ViewData["AdresId"] = new SelectList(_adresService.FindAll(), "Id", "Ilce",y.AdresId);
            return View(y);
        }

        [HttpPost]
        public IActionResult Edit (YayinEvi yayinEvi)
        {
            if (ModelState.IsValid)
            {
                _yayinEviService.Update(yayinEvi);
                return RedirectToAction("Index");
            }
            ViewData["AdresId"] = new SelectList(_adresService.FindAll(), "Id", "Ilce",yayinEvi.AdresId);
            return View(yayinEvi);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            _yayinEviService.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}