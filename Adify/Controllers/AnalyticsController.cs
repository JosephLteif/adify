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
    public class AnalyticsController : ControllerBase
    {
        private readonly DbContext _context;

        public AnalyticsController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Analytics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analytics>>> GetAnalytics()
        {
            return await _context.Analytics.ToListAsync();
        }

        // GET: api/Analytics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Analytics>> GetAnalytics(string id)
        {
            var analytics = await _context.Analytics.FindAsync(id);

            if (analytics == null)
            {
                return NotFound();
            }

            return analytics;
        }

        // PUT: api/Analytics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalytics(string id, Analytics analytics)
        {
            if (id != analytics.Id)
            {
                return BadRequest();
            }

            _context.Entry(analytics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalyticsExists(id))
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

        // POST: api/Analytics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Analytics>> PostAnalytics(Analytics analytics)
        {
            _context.Analytics.Add(analytics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnalyticsExists(analytics.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnalytics", new { id = analytics.Id }, analytics);
        }

        // DELETE: api/Analytics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Analytics>> DeleteAnalytics(string id)
        {
            var analytics = await _context.Analytics.FindAsync(id);
            if (analytics == null)
            {
                return NotFound();
            }

            _context.Analytics.Remove(analytics);
            await _context.SaveChangesAsync();

            return analytics;
        }

        private bool AnalyticsExists(string id)
        {
            return _context.Analytics.Any(e => e.Id == id);
        }
    }
}
