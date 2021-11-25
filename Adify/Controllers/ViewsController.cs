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
    public class ViewsController : ControllerBase
    {
        private readonly DbContext _context;

        public ViewsController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Views
        [HttpGet]
        public async Task<ActionResult<IEnumerable<View>>> GetView()
        {
            return await _context.View.ToListAsync();
        }

        // GET: api/Views/5
        [HttpGet("{id}")]
        public async Task<ActionResult<View>> GetView(string id)
        {
            var view = await _context.View.FindAsync(id);

            if (view == null)
            {
                return NotFound();
            }

            return view;
        }

        // PUT: api/Views/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutView(string id, View view)
        {
            if (id != view.Id)
            {
                return BadRequest();
            }

            _context.Entry(view).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewExists(id))
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

        // POST: api/Views
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<View>> PostView(View view)
        {
            _context.View.Add(view);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ViewExists(view.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetView", new { id = view.Id }, view);
        }

        // DELETE: api/Views/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<View>> DeleteView(string id)
        {
            var view = await _context.View.FindAsync(id);
            if (view == null)
            {
                return NotFound();
            }

            _context.View.Remove(view);
            await _context.SaveChangesAsync();

            return view;
        }

        private bool ViewExists(string id)
        {
            return _context.View.Any(e => e.Id == id);
        }
    }
}
