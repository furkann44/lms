using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KutuphaneOtomasyonu.Context;
using KutuphaneOtomasyonu.Models;
using KutuphaneOtomasyonu.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReflectionIT.Mvc.Paging;

namespace KutuphaneOtomasyonu.Controllers
{
    public class KitapController : Controller
    {
        private readonly KitapService _kitapService;
        private readonly YazarService _yazarService;
        private readonly KategoriService _kategoriService;
        private readonly dbKutuphaneContext _context;
        private readonly YayinEviService _yayinEviService;
        private readonly PaginationSearchService<Models.Kitap> paginationSearchService;
        private int page = 1;
        private int pageSize = 10;
        private int pageCount;


        public KitapController(IConfiguration configuration, dbKutuphaneContext context)
        {
            _kitapService = new KitapService(configuration);
            _yazarService = new YazarService(configuration);
            _kategoriService = new KategoriService(configuration);
            _yayinEviService = new YayinEviService(configuration);
            paginationSearchService = new PaginationSearchService<Models.Kitap>(configuration);
            _context = context;
        }

        public async Task<IActionResult> Index(string filter, int page = 1,string sort="Ad")
        {
            var kitap = _kitapService.FindAll();
            if (!String.IsNullOrEmpty(filter))
            {
                kitap = _kitapService.Search(filter);
            }
              
            if (!String.IsNullOrEmpty(filter))
            {
                kitap = _kitapService.Search(filter);
            }
            var list = _context.Kitap.Include(k => k.Kategori).Include(k => k.Yayinevi).Include(k => k.Yazar).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                list = list.Where(k => k.Ad.Contains(filter)).AsQueryable().OrderBy(a => a.Id);
            }
            var model = await PagingList.CreateAsync(list, 10, page, sort, "Ad");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }

        public IActionResult Create()
        {
            ViewData["YayinEviId"] = new SelectList(_yayinEviService.FindAll(), "Id", "Ad");
            ViewData["YazarId"] = new SelectList(_yazarService.FindAll(), "Id", "AdSoyad");
            ViewData["KategoriId"] = new SelectList(_kategoriService.FindAll(), "Id", "Ad");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _kitapService.Add(kitap);
                return RedirectToAction("Index");
            }
            ViewData["YayinEviId"] = new SelectList(_yayinEviService.FindAll(), "Id", "Ad", kitap.yayineviid);
            ViewData["YazarId"] = new SelectList(_yazarService.FindAll(), "Id", "AdSoyad", kitap.yazarid);
            ViewData["KategoriId"] = new SelectList(_kategoriService.FindAll(), "Id", "Ad", kitap.kategoriid);
            return View(kitap);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Models.Kitap k = _kitapService.FindById(id.Value);
            if (k == null)
            {
                return NotFound();
            }
            ViewData["YayinEviId"] = new SelectList(_yayinEviService.FindAll(), "Id", "Ad", k.yayineviid);
            ViewData["YazarId"] = new SelectList(_yazarService.FindAll(), "Id", "AdSoyad", k.yazarid);
            ViewData["KategoriId"] = new SelectList(_kategoriService.FindAll(), "Id", "Ad", k.kategoriid);
            return View(k);
        }

        [HttpPost]
        public IActionResult Edit(Models.Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _kitapService.Update(kitap);
                return RedirectToAction("Index");
            }
            ViewData["YayinEviId"] = new SelectList(_yayinEviService.FindAll(), "Id", "Ad", kitap.yayineviid);
            ViewData["YazarId"] = new SelectList(_yazarService.FindAll(), "Id", "AdSoyad", kitap.yazarid);
            ViewData["KategoriId"] = new SelectList(_kategoriService.FindAll(), "Id", "Ad", kitap.kategoriid);
            return View(kitap);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _kitapService.Remove(id.Value);
            return RedirectToAction("Index");
        }

        public void next()
        {
            if(this.Page == this.PageCount)
            {
                 this.page = 1;
            }
            else
            {
                this.page++;
            }
        }
        public void previous()
        {
            if (this.Page == 1)
            {
                this.page = this.PageCount;
            }
            else
            {
                this.page--;
            }
        }

        public int Page
        {
            get {
                return page;
            } 
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            } 
        }

        public int PageCount
        {
            get
            {
                return pageCount = (int) Math.Ceiling(10/(double) pageSize);
            } 
        }

    }
}