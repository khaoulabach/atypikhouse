using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noyau;

namespace LocationBiens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternautesController : ControllerBase
    {
        private readonly LocationBiensContext _context;

        public InternautesController(LocationBiensContext context)
        {
            _context = context;
        }
        // POST: api/Internautes
        [HttpPost("Login")]
        public IActionResult PostLogin([FromBody] User user)
        {
            var internaute = _context.Internautes
                .ToList()
                .Where(u => u.Login.Equals(user.Login) && u.Password.Equals(user.Password))
                .FirstOrDefault();
            if (internaute == null)
            {
                return Ok(null);
            }
            return Ok(internaute);
        }

        // GET: api/Internautes
        [HttpGet]
        public IEnumerable<Internaute> GetInternautes()
        {
            return _context.Internautes;
        }

        // GET: api/Internautes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Internaute>> GetInternaute(int id)
        {
            var internaute = await _context.Internautes.FindAsync(id);

            if (internaute == null)
            {
                return NotFound();
            }

            return internaute;
        }

        // PUT: api/Internautes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInternaute(int id, Internaute internaute)
        {
            if (id != internaute.Id)
            {
                return BadRequest();
            }

            _context.Entry(internaute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternauteExists(id))
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

        // POST: api/Internautes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Internaute>> PostInternaute(Internaute internaute)
        {
            _context.Internautes.Add(internaute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInternaute", new { id = internaute.Id}, internaute);
        }

        // DELETE: api/Internautes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Internaute>> DeleteInternaute(int id)
        {
            var internaute = await _context.Internautes.FindAsync(id);
            if (internaute == null)
            {
                return NotFound();
            }

            _context.Internautes.Remove(internaute);
            await _context.SaveChangesAsync();

            return internaute;
        }

        private bool InternauteExists(int id)
        {
            return _context.Internautes.Any(e => e.Id == id);
        }
    }
}
