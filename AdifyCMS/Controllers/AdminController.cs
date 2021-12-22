using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdifyCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace AdifyCMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbContext _context;

        public AdminController(DbContext context)
        {
            _context = context;
        }
        // GET: AdminController
        public async Task<ActionResult> Index()
        {
            List<Ad> ads = await _context.Ad
                .Include(p => p.Analytics)
                .Include(p => p.Analytics).ThenInclude(p => p.Clicks)
                .Include(p => p.Analytics).ThenInclude(p => p.Views)
                .ToListAsync();
            return View(ads);
        }

        public async Task<ActionResult> ToggleReview(int id)
        {
            Ad ad = await _context.Ad.Where(p => p.Id == id).FirstOrDefaultAsync();
            ad.DidPass = !ad.DidPass;
            await _context.SaveChangesAsync();
            List<Ad> ads = await _context.Ad
                .Include(p => p.Analytics)
                .Include(p => p.Analytics).ThenInclude(p => p.Clicks)
                .Include(p => p.Analytics).ThenInclude(p => p.Views)
                .ToListAsync();
            return RedirectToAction("Index", "Admin", ads);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
