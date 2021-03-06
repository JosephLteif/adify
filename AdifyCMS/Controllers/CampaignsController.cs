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
    public class CampaignsController : Controller
    {
        private readonly DbContext _context;

        public CampaignsController(DbContext context)
        {
            _context = context;
        }

        // GET: Campaigns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campaign.Where(p => p.userid == TempData.Peek("userid")).ToListAsync());
        }

        // GET: Campaigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaign
                .Include(p => p.Ads).ThenInclude(p => p.Analytics)
                .Include(p => p.Ads).ThenInclude(p => p.Analytics).ThenInclude(p => p.Views)
                .Include(p => p.Ads).ThenInclude(p => p.Analytics).ThenInclude(p => p.Clicks)
                .Include(p => p.Ads)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (campaign == null)
            {
                return NotFound();
            }
            //foreach (var ad in campaign.Ads)
            //{
            //    if(ad.Analytics.Views == null)
            //    {
            //        ad.Analytics.Views = 0;
            //    }

            //}

            return View(campaign);
        }

        // GET: Campaigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DurationInDays,Budget")] Campaign campaign)
        {
            campaign.userid = TempData.Peek("userid").ToString();
            if (ModelState.IsValid)
            {
                _context.Add(campaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        // GET: Campaigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaign.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DurationInDays,Budget")] Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignExists(campaign.Id))
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
            return View(campaign);
        }

        // GET: Campaigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaign
                .FirstOrDefaultAsync(m => m.Id == id);

            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campaign = await _context.Campaign
                .Include(p => p.Ads).Where(p => p.Id == id)
                .Include(p => p.Ads).ThenInclude(p => p.Analytics)
                .Include(p => p.Ads).ThenInclude(p => p.Analytics).ThenInclude(p => p.Views)
                .Include(p => p.Ads).ThenInclude(p => p.Analytics).ThenInclude(p => p.Clicks)
                .FirstOrDefaultAsync();
            foreach(var ad in campaign.Ads)
            {
                _context.Ad.Remove(ad);
                foreach (var view in ad.Analytics.Views)
                {
                    _context.View.Remove(view);
                }
                foreach (var click in ad.Analytics.Clicks)
                {
                    _context.Click.Remove(click);
                }
                _context.Analytics.Remove(ad.Analytics);
            }
            _context.Campaign.Remove(campaign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignExists(int id)
        {
            return _context.Campaign.Any(e => e.Id == id);
        }
    }
}
