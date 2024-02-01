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
    public class RaporController : Controller
    {
        private readonly RaporService raporService;
        private readonly EmanetService emanetService;
        private readonly KitapService kitapService;
        private readonly UyeService uyeService;

        public RaporController(IConfiguration configuration)
        {
            raporService = new RaporService(configuration);
            emanetService = new EmanetService(configuration);
            kitapService = new KitapService(configuration);
            uyeService = new UyeService(configuration);
        }

        public IActionResult Index()
        {
            var list = (from r in raporService.FindAll()
                        join e in emanetService.FindAll() on r.EmanetId equals e.Id
                        join k in kitapService.FindAll() on e.KitapId equals k.Id
                        join u in uyeService.FindAll() on e.UyeId equals u.Id 
                        select new Rapor
                        {
                            Id = r.Id,
                            Emanet = e,
                            Kitap = k,
                            Uye = u,
                        }).ToList();
            return View(list);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            raporService.Remove(id.Value);
            return RedirectToAction("Index");
        }

        public IActionResult AylikRapor()
        {  
            var list = (from r in raporService.FindAll()
                        join e in emanetService.FindAll() on r.EmanetId equals e.Id
                        join k in kitapService.FindAll() on e.KitapId equals k.Id
                        join u in uyeService.FindAll() on e.UyeId equals u.Id
                        where e.Month == DateTime.Now.Month
                        select new Rapor
                        {
                            Id = r.Id,
                            Emanet = e,
                            Kitap = k,
                            Uye = u,
                            
                        }).ToList();
            return View(list);
        }
        public IActionResult YillikRapor()
        {
            var list = (from r in raporService.FindAll()
                        join e in emanetService.FindAll() on r.EmanetId equals e.Id
                        join k in kitapService.FindAll() on e.KitapId equals k.Id
                        join u in uyeService.FindAll() on e.UyeId equals u.Id
                        where e.Year == DateTime.Now.Year
                        select new Rapor
                        {
                            Id = r.Id,
                            Emanet = e,
                            Kitap = k,
                            Uye = u
                        }).ToList();
            return View(list);
        }
    }
}