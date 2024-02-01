using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KutuphaneOtomasyonu.Models;
using KutuphaneOtomasyonu.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KutuphaneOtomasyonu.Controllers
{
    public class EmanetController : Controller
    {
        private readonly EmanetService _emanetService;
        private readonly KitapService _kitapService;
        private readonly UyeService _uyeService;
        //private readonly EventLog eventLog; 
        private readonly LogBase _logBase;

        public EmanetController(IConfiguration configuration)
        {
            _emanetService = new EmanetService(configuration);
            _kitapService = new KitapService(configuration);
            _uyeService = new UyeService(configuration);
            //eventLog = new EventLog(configuration,_emanetService,_logger);
            //_logBase = logBase;
        }

        public IActionResult Index()
        {
            var list = (from e in _emanetService.FindAll()
                        join k in _kitapService.FindAll() on e.KitapId equals k.Id
                        join uye in _uyeService.FindAll() on e.UyeId equals uye.Id 
                        select new Emanet
                        {
                            Id = e.Id,
                            Kitap = k,
                            Uye = uye,
                            Month = e.Month = DateTime.Now.Month, 
                            Year = e.Year  = DateTime.Now.Year
                            //CreatedOn = e.CreatedOn ?? DateTime.Now
                        }).ToList();

            return View(list);
        }

        public IActionResult Create()
        {
            ViewData["KitapId"] = new SelectList(_kitapService.FindAll(), "Id", "Ad");
            ViewData["UyeId"] = new SelectList(_uyeService.FindAll(), "Id", "AdSoyad");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Emanet emanet)
        {
            if (ModelState.IsValid)
            {
                _emanetService.Add(emanet);
                ////eventLog.LogEkle(emanet);
                //int id = emanet.Id;
                //_logBase.LogEkle(id);
                //_logBase.LogEkle(id);
                return RedirectToAction("Index");
            }
            ViewData["KitapId"] = new SelectList(_kitapService.FindAll(), "Id", "Ad", emanet.KitapId);
            ViewData["UyeId"] = new SelectList(_uyeService.FindAll(), "Id", "AdSoyad", emanet.UyeId);
            return View(emanet);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Emanet e = _emanetService.FindById(id.Value);
            if (e == null)
            {
                return NotFound();
            }
            ViewData["KitapId"] = new SelectList(_kitapService.FindAll(), "Id", "Ad", e.KitapId);
            ViewData["UyeId"] = new SelectList(_uyeService.FindAll(), "Id", "AdSoyad", e.UyeId);
            return View(e);
        }

        [HttpPost]
        public IActionResult Edit(Emanet emanet)
        {
            if (ModelState.IsValid)
            {
                _emanetService.Update(emanet);
                return RedirectToAction("Index");
            }
            ViewData["KitapId"] = new SelectList(_kitapService.FindAll(), "Id", "Id", emanet.KitapId);
            ViewData["UyeId"] = new SelectList(_uyeService.FindAll(), "Id", "Id", emanet.UyeId);
            return View(emanet);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _emanetService.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}