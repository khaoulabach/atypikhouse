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
    public class ProprietairesController : ControllerBase
    {
        private readonly LocationBiensContext _context;

        public ProprietairesController(LocationBiensContext context)
        {
            _context = context;
        }

        // GET: api/Proprietaires
        [HttpGet]
        public IEnumerable<Proprietaire> GetProprietaires()
        {
            return _context.Proprietaires.ToList();
        }

        // GET: api/Proprietaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proprietaire>> GetProprietaire(int id)
        {
            var proprietaire = await _context.Proprietaires.FindAsync(id);

            if (proprietaire == null)
            {
                return NotFound();
            }

            return proprietaire;
        }

        // PUT: api/Proprietaires/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProprietaire(int id, Proprietaire proprietaire)
        {
            if (id != proprietaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(proprietaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProprietaireExists(id))
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

        // POST: api/Proprietaires
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Proprietaire>> PostProprietaire(Proprietaire proprietaire)
        {
            _context.Proprietaires.Add(proprietaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProprietaire", new { id = proprietaire.Id }, proprietaire);
        }

        // DELETE: api/Proprietaires/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proprietaire>> DeleteProprietaire(int id)
        {
            var proprietaire = await _context.Proprietaires.FindAsync(id);
            if (proprietaire == null)
            {
                return NotFound();
            }

            _context.Proprietaires.Remove(proprietaire);
            await _context.SaveChangesAsync();

            return proprietaire;
        }

        private bool ProprietaireExists(int id)
        {
            return _context.Proprietaires.Any(e => e.Id == id);
        }
    }
}
