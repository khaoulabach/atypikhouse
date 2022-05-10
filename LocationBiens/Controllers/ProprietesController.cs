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
    public class ProprietesController : ControllerBase
    {
        private readonly LocationBiensContext _context;

        public ProprietesController(LocationBiensContext context)
        {
            _context = context;
        }

        // GET: api/Proprietes
        //[HttpGet]
        //public IEnumerable<Propriete> GetProprietes()
        //{
        //    return _context.Proprietes.ToList();
        //}
        // GET: api/Proprietes
        [HttpGet]
        public JsonResult GetProprietes()

        {
            var biens = _context.Proprietes
                .Include(p=>p.TypeBien)
                .ToList()
                .Select(a => new
                {
                    a.Id,
                    a.Code,
                    a.Description,
                    a.IndObligatoire,
                    a.TypeBienId,
                });
            //.Where(a => a.Code.Equals("P01"));
            return new JsonResult(biens);
        }

        // GET: api/Proprietes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Propriete>> GetPropriete(int id)
        {
            var propriete = await _context.Proprietes.FindAsync(id);

            if (propriete == null)
            {
                return NotFound();
            }

            return propriete;
        }

        // PUT: api/Proprietes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropriete(int id, Propriete propriete)
        {
            if (id != propriete.Id)
            {
                return BadRequest();
            }

            _context.Entry(propriete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProprieteExists(id))
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

        // POST: api/Proprietes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Propriete>> PostPropriete(Propriete propriete)
        {
            _context.Proprietes.Add(propriete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPropriete", new { id = propriete.Id }, propriete);
        }

        // DELETE: api/Proprietes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Propriete>> DeletePropriete(int id)
        {
            var propriete = await _context.Proprietes.FindAsync(id);
            if (propriete == null)
            {
                return NotFound();
            }

            _context.Proprietes.Remove(propriete);
            await _context.SaveChangesAsync();

            return propriete;
        }

        private bool ProprieteExists(int id)
        {
            return _context.Proprietes.Any(e => e.Id == id);
        }
    }
}
