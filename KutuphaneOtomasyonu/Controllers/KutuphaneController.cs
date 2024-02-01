using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KutuphaneOtomasyonu.Models;
using KutuphaneOtomasyonu.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ReflectionIT.Mvc.Paging;

namespace KutuphaneOtomasyonu.Controllers
{
    public class KutuphaneController : Controller
    {
        private readonly KutuphaneService _kutuphaneService;
        private readonly AdresService _adresService;

        public KutuphaneController(IConfiguration configuration)
        {
            _kutuphaneService = new KutuphaneService(configuration);
            _adresService = new AdresService(configuration);
        }

        public async Task<IActionResult> Index(int? pageNumber = 1)
        {
            var list = (from k in _kutuphaneService.FindAll()
                        from a in _adresService.FindAll()
                        where k.AdresId == a.Id
                        select new Kutuphane
                        {
                            Id = k.Id,
                            Ad = k.Ad,
                            Adres = a
                        });
            var qry = list.OrderBy(p => p.Ad).AsQueryable();
            //var model = await PagingList.CreateAsync(qry, 10, pageNumber);
            return View(list);
        }

        public IActionResult Create()
        {
            ViewData["AdresId"] = new SelectList(_adresService.FindAll(), "Id", "Ilce");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kutuphane kutuphane)
        {
            if (ModelState.IsValid)
            {
                _kutuphaneService.Add(kutuphane);
                return RedirectToAction("Index");
            }
            ViewData["AdresId"] = new SelectList(_adresService.FindAll(), "Id", "Ilce", kutuphane.AdresId);
            return View(kutuphane);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Kutuphane k = _kutuphaneService.FindById(id.Value);
            if (k == null)
            {
                return NotFound();
            }
            ViewData["AdresId"] = new SelectList(_adresService.FindAll(), "Id", "Ilce", k.AdresId);
            return View(k);
        }

        [HttpPost]
        public IActionResult Edit(Kutuphane kutuphane)
        {
            if (ModelState.IsValid)
            {
                _kutuphaneService.Update(kutuphane);
                return RedirectToAction("Index");
            }
            ViewData["AdresId"] = new SelectList(_adresService.FindAll(), "Id", "Ilce", kutuphane.AdresId);
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _kutuphaneService.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}