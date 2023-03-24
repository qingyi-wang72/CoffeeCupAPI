using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeCupAPI.Models;

namespace CoffeeCupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeCupsController : ControllerBase
    {
        private readonly CoffeeCupContext _context;

        public CoffeeCupsController(CoffeeCupContext context)
        {
            _context = context;
        }

        // GET: api/CoffeeCups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeCup>>> GetCoffeeCups()
        {
            if (_context.CoffeeCups == null)
            {
                return NotFound();
            }
            return await _context.CoffeeCups.ToListAsync();
        }

        // GET: api/CoffeeCups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeCup>> GetCoffeeCup(int id)
        {
          if (_context.CoffeeCups == null)
          {
              return NotFound();
          }
            var coffeeCup = await _context.CoffeeCups.FindAsync(id);

            if (coffeeCup == null)
            {
                return NotFound();
            }

            return coffeeCup;
        }

        // PUT: api/CoffeeCups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoffeeCup(int id, CoffeeCup coffeeCup)
        {
            if (id != coffeeCup.Id)
            {
                return BadRequest();
            }

            _context.Entry(coffeeCup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeCupExists(id))
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

        // POST: api/CoffeeCups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoffeeCup>> PostCoffeeCup(CoffeeCup coffeeCup)
        {
          if (_context.CoffeeCups == null)
          {
              return Problem("Entity set 'CoffeeCupContext.CoffeeCups'  is null.");
          }
            _context.CoffeeCups.Add(coffeeCup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoffeeCup", new { id = coffeeCup.Id }, coffeeCup);
        }

        // DELETE: api/CoffeeCups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeCup(int id)
        {
            if (_context.CoffeeCups == null)
            {
                return NotFound();
            }
            var coffeeCup = await _context.CoffeeCups.FindAsync(id);
            if (coffeeCup == null)
            {
                return NotFound();
            }

            _context.CoffeeCups.Remove(coffeeCup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoffeeCupExists(int id)
        {
            return (_context.CoffeeCups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
