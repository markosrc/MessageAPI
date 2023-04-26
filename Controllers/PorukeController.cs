using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageAPI.Data;
using MessageAPI.Models;

namespace MessageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorukeController : ControllerBase
    {
        private readonly MessageContext _context;

        public PorukeController(MessageContext context)
        {
            _context = context;
        }

        // GET: api/Poruke
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poruka>>> GetPoruke()
        {
          if (_context.Poruke == null)
          {
              return NotFound();
          }
            return await _context.Poruke.Include(p=>p.EmailOd).Include(p => p.EmailPrema).ToListAsync();
        }

        // GET: api/Poruke/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poruka>> GetPoruka(int id)
        {
          if (_context.Poruke == null)
          {
              return NotFound();
          }
            var poruka = await _context.Poruke.FindAsync(id);

            if (poruka == null)
            {
                return NotFound();
            }

            return poruka;
        }

        // PUT: api/Poruke/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoruka(int id, Poruka poruka)
        {
            if (id != poruka.Id)
            {
                return BadRequest();
            }

            _context.Entry(poruka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PorukaExists(id))
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

        // POST: api/Poruke
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Poruka>> PostPoruka(Poruka poruka)
        {
          if (_context.Poruke == null)
          {
              return Problem("Entity set 'MessageContext.Poruke'  is null.");
          }
            _context.Poruke.Add(poruka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoruka", new { id = poruka.Id }, poruka);
        }

        // DELETE: api/Poruke/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoruka(int id)
        {
            if (_context.Poruke == null)
            {
                return NotFound();
            }
            var poruka = await _context.Poruke.FindAsync(id);
            if (poruka == null)
            {
                return NotFound();
            }

            _context.Poruke.Remove(poruka);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PorukaExists(int id)
        {
            return (_context.Poruke?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
