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
    public class EmailsController : ControllerBase
    {
        private readonly MessageContext _context;

        public EmailsController(MessageContext context)
        {
            _context = context;
        }

        // GET: api/Emails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmails()
        {
          if (_context.Emails == null)
          {
              return NotFound();
          }
            return await _context.Emails.Include(o => o.Osoba).ToListAsync();
        }

        // GET: api/Emails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> GetEmail(int id)
        {
          if (_context.Emails == null)
          {
              return NotFound();
          }
            var email = await _context.Emails.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            return email;
        }

        // PUT: api/Emails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail(int id, Email email)
        {
            if (id != email.Id)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        // POST: api/Emails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
          if (_context.Emails == null)
          {
              return Problem("Entity set 'MessageContext.Emails'  is null.");
          }
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmail", new { id = email.Id }, email);
        }

        // DELETE: api/Emails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            if (_context.Emails == null)
            {
                return NotFound();
            }
            var email = await _context.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailExists(int id)
        {
            return (_context.Emails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
