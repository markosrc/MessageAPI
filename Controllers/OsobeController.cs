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
    public class OsobeController : ControllerBase
    {
        private readonly MessageContext _context;

        public OsobeController(MessageContext context)
        {
            _context = context;
        }

        // GET: api/Osobe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Osoba>>> GetOsobe()
        {
          if (_context.Osobe == null)
          {
              return NotFound();
          }
            return await _context.Osobe.Include(e=> e.Email).ToListAsync();
        }

        // GET: api/Osobe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Osoba>> GetOsoba(int id)
        {
          if (_context.Osobe == null)
          {
              return NotFound();
          }
            var osoba = await _context.Osobe.FindAsync(id);

            if (osoba == null)
            {
                return NotFound();
            }

            return osoba;
        }

        // PUT: api/Osobe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOsoba(int id, Osoba osoba)
        {
            if (id != osoba.Id)
            {
                return BadRequest();
            }

            _context.Entry(osoba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsobaExists(id))
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

        // POST: api/Osobe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Osoba>> PostOsoba(Osoba osoba)
        {
          if (_context.Osobe == null)
          {
              return Problem("Entity set 'MessageContext.Osobe'  is null.");
          }
            _context.Osobe.Add(osoba);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOsoba", new { id = osoba.Id }, osoba);
        }

        // DELETE: api/Osobe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOsoba(int id)
        {
            if (_context.Osobe == null)
            {
                return NotFound();
            }
            var osoba = await _context.Osobe.FindAsync(id);
            if (osoba == null)
            {
                return NotFound();
            }

            _context.Osobe.Remove(osoba);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OsobaExists(int id)
        {
            return (_context.Osobe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
