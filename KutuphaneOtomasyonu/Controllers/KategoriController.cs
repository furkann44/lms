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
    public class KategoriController : Controller
    {
        private readonly KategoriService _kategoriService;

        public KategoriController (IConfiguration configuration)
        {
            _kategoriService = new KategoriService(configuration);
        }

        public IActionResult Index()
        {
            return View(_kategoriService.FindAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _kategoriService.Add(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Kategori k = _kategoriService.FindById(id.Value);
            if(k == null)
            {
                return NotFound();
            }
            return View(k);
        }

        [HttpPost]
        public IActionResult Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _kategoriService.Update(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            _kategoriService.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}