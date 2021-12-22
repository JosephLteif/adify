using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdifyCMS.Models;

namespace AdifyCMS.Controllers
{
    public class AdsController : Controller
    {
        private readonly DbContext _context;

        public AdsController(DbContext context)
        {
            _context = context;
        }

        // GET: Ads
        public async Task<IActionResult> Index()
        {
            var campaigns = await _context.Campaign.Include(p => p.Ads).Where(p => p.userid == TempData.Peek("userid")).ToListAsync();
            List<Ad> ads = new List<Ad>();
            foreach (var campaign in campaigns)
            {
                foreach (var ad in campaign.Ads)
                {
                Ad adtemp = await _context.Ad
                .Include(p => p.Analytics)
                .Include(p => p.Analytics).ThenInclude(p => p.Views)
                .Include(p => p.Analytics).ThenInclude(p => p.Clicks)
                .Where(p => p.Id == ad.Id)
                .FirstOrDefaultAsync();
                ads.Add(adtemp);
                }

            }
            return View(ads);
        }

        // GET: Ads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Ads/Create
        public async Task<IActionResult> Create()
        {
            var campaigns = _context.Campaign.Where(p => p.userid == TempData.Peek("userid")).ToList();
            ViewBag.Campaigns = campaigns;
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ImageUrl,AdUrl,CampaignId")] AdViewModel ad)
        {
            Ad adtemp = new Ad();
            adtemp.AdUrl = ad.AdUrl;
            adtemp.Id = ad.Id;
            int analyticsid;
            try
            {
                analyticsid = int.Parse(_context.Analytics
                            .OrderByDescending(a => a.Id)
                            .First().Id);
            }
            catch
            {
                analyticsid = 0;
            }

            adtemp.Analytics = new Analytics()
            {
                Id = (analyticsid + 1).ToString(),
            };
            adtemp.Description = ad.Description;
            adtemp.DidPass = false;
            adtemp.ImageUrl = ad.ImageUrl;
            adtemp.Title = ad.Title;
            if (ModelState.IsValid)
            {
                Campaign campaign = _context.Campaign.Where(p => p.Id == int.Parse(ad.CampaignId))
                    .Include(p => p.Ads).FirstOrDefault();
                campaign.Ads.Add(adtemp);
                _context.Add(adtemp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Campaigns");
            }
            return View(adtemp);
        }

        // GET: Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ad.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ImageUrl,AdUrl")] Ad ad)
        {
            if (id != ad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ad);
        }

        // GET: Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ad = await _context.Ad
                .Include(p => p.Analytics).Where(p => p.Id == id)
                .Include(p => p.Analytics).ThenInclude(p => p.Views)
                .Include(p => p.Analytics).ThenInclude(p => p.Clicks)
                .FirstOrDefaultAsync();
            foreach (var view in ad.Analytics.Views)
            {
                _context.View.Remove(view);
            }
            foreach (var click in ad.Analytics.Clicks)
            {
                _context.Click.Remove(click);
            }
            _context.Analytics.Remove(ad.Analytics);
            _context.Ad.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.Ad.Any(e => e.Id == id);
        }
    }
}
