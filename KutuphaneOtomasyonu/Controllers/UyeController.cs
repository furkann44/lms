using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using KutuphaneOtomasyonu.Models;
using KutuphaneOtomasyonu.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace KutuphaneOtomasyonu.Controllers
{
    public class UyeController : Controller
    {
        private readonly UyeService _uyeService;
        private readonly KutuphaneService _kutuphaneService;
        private IMemoryCache _cache;

        public UyeController(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _uyeService = new UyeService(configuration);
            _kutuphaneService = new KutuphaneService(configuration);
            _cache = memoryCache;
        }

        public IActionResult Index()
        {
            var list = (from u in _uyeService.FindAll()
                        join a in _kutuphaneService.FindAll() on u.KutuphaneId equals a.Id
                        select new Uye
                        {
                            AdSoyad = u.AdSoyad,
                            Cinsiyet = u.Cinsiyet,
                            Telefon = u.Telefon,
                            Kutuphane = a
                        }).ToList();
            return View(list);
        }

        public IActionResult Create(string ad)
        {

            if (ad != null)
            {
              
                TempData["AdSoyad"] = ad;
            }

            ViewData["KutuphaneId"] = new SelectList(_kutuphaneService.FindAll(), "Id", "Ad");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Uye uye)
        {
            if (ModelState.IsValid)
            {
                _uyeService.Add(uye);
                return RedirectToAction("Index");
            }
            ViewData["KutuphaneId"] = new SelectList(_kutuphaneService.FindAll(), "Id", "Ad", uye.KutuphaneId);
            return View(uye);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Uye u = _uyeService.FindById(id.Value);
            if (u == null)
            {
                return NotFound();
            }
            ViewData["KutuphaneId"] = new SelectList(_kutuphaneService.FindAll(), "Id", "Ad", u.KutuphaneId);
            return View(u);
        }

        [HttpPost]
        public IActionResult Edit(Uye uye)
        {
            if (ModelState.IsValid)
            {
                _uyeService.Update(uye);
                RedirectToAction("Index");
            }
            ViewData["KutuphaneId"] = new SelectList(_kutuphaneService.FindAll(), "Id", "Ad", uye.KutuphaneId);
            return View(uye);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _uyeService.Remove(id.Value);
            return RedirectToAction("Index");
        }

        //public void Memento(Uye u)
        //{
        //    Uye uye = new Uye();
        //    UyeCareTaker taker = new UyeCareTaker();

        //    taker.Memento = u.Kaydet();

        //    CacheTryGetValueSet(taker);
        //}

        //public IActionResult CacheTryGetValueSet(UyeCareTaker u)
        //{
        //    string ad;
        //    string cins;
        //    long tel;

        //    // Look for cache key.
        //    if (!_cache.TryGetValue(u.Memento.AdSoyad, out ad))
        //    {
        //        // Key not in cache, so get data.
        //        ad = u.Memento.AdSoyad;

        //        // Set cache options.
        //        var cacheEntryOptions = new MemoryCacheEntryOptions()
        //            // Keep in cache for this time, reset time if accessed.
        //            .SetSlidingExpiration(TimeSpan.FromSeconds(10));

        //        // Save data in cache.
        //        _cache.Set(u.Memento.AdSoyad, ad, cacheEntryOptions);
        //    }
        //    Create(ad);
        //    return View("Create", ad);
        //}

    }
}