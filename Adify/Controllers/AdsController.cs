using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adify.Models;

namespace Adify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly DbContext _context;
        private IHttpContextAccessor _accessor;

        public AdsController(DbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        // GET: api/Ads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAd()
        {
            return await _context.Ad.ToListAsync();
        }

        // GET: api/Ads/sdk/getAd
        [HttpGet("sdk/getAd")]
        public async Task<ActionResult<Ad>> GetAdSDK()
        {
            var random = new Random();
            var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            List<Ad> ads = await _context.Ad
                .Include(p => p.Analytics).ThenInclude(p => p.Views)
                .Where(p => p.DidPass == true)
                .ToListAsync();
            int index = random.Next(ads.Count);
            Ad ad = ads[index];
            List<View> views = new List<View>();
            foreach (Ad Ad in ads)
            {
                views.AddRange(Ad.Analytics.Views);
            }
            //List<View> views = await _context.View.Include(p => p.).ToListAsync();
            int viewCount = views.Count;
            View view = new View()
            {
                Id = (viewCount+1).ToString(),
                IP = ip,
                ViewedTime = DateTime.Now,
            };
            ad.Analytics.Views.Add(view);
            _context.SaveChanges();
            return ads[index];
        }

        // GET: api/Ads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ad>> GetAd(int id)
        {
            var ad = await _context.Ad.FindAsync(id);

            if (ad == null)
            {
                return NotFound();
            }

            return ad;
        }

        // PUT: api/Ads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAd(int id, Ad ad)
        {
            if (id != ad.Id)
            {
                return BadRequest();
            }

            _context.Entry(ad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ad>> PostAd(Ad ad)
        {
            _context.Ad.Add(ad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAd", new { id = ad.Id }, ad);
        }

        // DELETE: api/Ads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ad>> DeleteAd(int id)
        {
            var ad = await _context.Ad.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }

            _context.Ad.Remove(ad);
            await _context.SaveChangesAsync();

            return ad;
        }

        private bool AdExists(int id)
        {
            return _context.Ad.Any(e => e.Id == id);
        }
    }
}
