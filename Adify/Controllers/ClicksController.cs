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
    public class ClicksController : ControllerBase
    {
        private readonly DbContext _context;

        public ClicksController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Clicks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Click>>> GetClick()
        {
            return await _context.Click.ToListAsync();
        }

        // GET: api/Clicks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Click>> GetClick(int id)
        {
            var click = await _context.Click.FindAsync(id);

            if (click == null)
            {
                return NotFound();
            }

            return click;
        }

        // PUT: api/Clicks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClick(int id, Click click)
        {
            if (id != click.Id)
            {
                return BadRequest();
            }

            _context.Entry(click).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClickExists(id))
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

        // POST: api/Clicks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Click>> PostClick(Click click)
        {
            _context.Click.Add(click);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClick", new { id = click.Id }, click);
        }

        // DELETE: api/Clicks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Click>> DeleteClick(int id)
        {
            var click = await _context.Click.FindAsync(id);
            if (click == null)
            {
                return NotFound();
            }

            _context.Click.Remove(click);
            await _context.SaveChangesAsync();

            return click;
        }

        private bool ClickExists(int id)
        {
            return _context.Click.Any(e => e.Id == id);
        }
    }
}
