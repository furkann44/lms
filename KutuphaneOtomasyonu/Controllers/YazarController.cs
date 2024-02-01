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
    public class YazarController : Controller
    {
        private readonly YazarService _yazarService;

        public YazarController(IConfiguration configuration)
        {
            _yazarService = new YazarService(configuration);
        }

        public IActionResult Index()
        {
            return View(_yazarService.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                _yazarService.Add(yazar);
                return RedirectToAction("Index");
            }
            return View(yazar);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Yazar y = _yazarService.FindById(id.Value);
            if(y == null)
            {
                return NotFound();
            }
            return View(y);
        }

        [HttpPost]
        public IActionResult Edit(Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                _yazarService.Update(yazar);
                return RedirectToAction("Index");
            }
            return View(yazar);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            _yazarService.Remove(id.Value);
            return RedirectToAction("Index");
        }

    }
}