using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KutuphaneOtomasyonu.Models;
using KutuphaneOtomasyonu.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KutuphaneOtomasyonu.Controllers
{
    public class AdresController : Controller
    {
        private readonly AdresService _adresService;

        public AdresController (IConfiguration configuration)
        {
            _adresService = new AdresService(configuration);
        }

        public IActionResult Index()
        {
            return View(_adresService.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Adres adres)
        {
            if (ModelState.IsValid)
            {
                _adresService.Add(adres);
                return RedirectToAction("Index");
            }
            return View(adres);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Adres a = _adresService.FindById(id.Value);
            if(a == null)
            {
                return NotFound();
            }
            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(Adres adres)
        {
            if (ModelState.IsValid)
            {
                _adresService.Update(adres);
                return RedirectToAction("Index");
            }
            return View(adres);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            _adresService.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}