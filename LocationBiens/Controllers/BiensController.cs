using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noyau;

namespace LocationBiens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiensController : ControllerBase
    {
        private readonly LocationBiensContext _context;

        public static IHostingEnvironment _environment;
        public static IHostingEnvironment Environment { get => _environment; set => _environment = value; }

        public BiensController(LocationBiensContext context, IHostingEnvironment environment)
        {
            _context = context;
            Environment = environment;
        }

        // GET: api/Biens
        [HttpGet]
        public IEnumerable<Bien> GetBiens()
        {
            return _context.Biens;
            //.Include(b=> b.TypeBien); 
        }

        // GET: api/Biens
        //[HttpGet]
        //public JsonResult GetBiens()

        //{
        //    var biens = _context.Biens.ToList()
        //        .Select(a => new
        //        {
        //            a.Id,
        //            a.Code,
        //            a.Capacite,
        //            a.Prix,
        //            a.Statut
        //        });
        //        //.Where(a => a.Code.Equals("P01"));
        //    return new JsonResult(biens);
        //}

        //GET: api/Biens/Rechercher 
        [HttpPost("Rechercher")]
        public JsonResult PostBienRechercher(RechercheBien rechercheBien)
        {
            var biens = _context.Biens
                .Include(p => p.TypeBien)
                .Select(a => new
                {
                    a.Id,
                    a.Code,
                    a.Capacite,
                    a.Prix,
                    a.Titre,
                    a.Equipements,
                    a.Adresse,
                    a.Superficie,
                    a.Statut,
                    a.Image,
                    TypeBienId = a.TypeBien.Id,
                    TypeBien = a.TypeBien.Description,
                });

            if (rechercheBien.PrixMin != default)
            {
                biens = biens.Where(a => a.Prix >= rechercheBien.PrixMin);
            }
            if (rechercheBien.PrixMax != default)
            {
                biens = biens.Where(a => a.Prix <= rechercheBien.PrixMax);
            }
            if (rechercheBien.Type!= "")
            {
                biens = biens.Where(a => a.TypeBien.Contains(rechercheBien.Type));
            }

            return new JsonResult(biens);
        }
        // GET: api/Biens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bien>> GetBien(int id)
        {
            var bien = await _context.Biens.FindAsync(id);

            if (bien == null)
            {
                return NotFound();
            }

            return bien;
        }

        // PUT: api/Biens/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBien(int id, Bien bien)
        {
            if (id != bien.Id )
            {
                return BadRequest();
            }

            _context.Entry(bien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BienExists(id))
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

        // POST: api/Biens
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Bien>> PostBien(Bien bien)
        {
            bien.DateCreation = DateTime.Now;
            if (bien.Image != null)
            {
                var imagePath = ConvertImage(bien.Image, "Bien\\0000\\", bien.DateCreation.ToString());
                bien.Image = imagePath;
            }
            _context.Biens.Add(bien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBien", new { id = bien.Id }, bien);
        }

        // DELETE: api/Biens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bien>> DeleteBien(int id)
        {
            var bien = await _context.Biens.FindAsync(id);
            if (bien == null)
            {
                return NotFound();
            }

            _context.Biens.Remove(bien);
            await _context.SaveChangesAsync();

            return bien;
        }

        private bool BienExists(int id)
        {
            return _context.Biens.Any(e => e.Id == id);
        }


        public string ConvertImage(string image, string folderName, string fileNamePersonnel)
        {
            // var base64Data = Regex.Match(image, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            // var type = Regex.Match(image, @"data:image/(?<type>.+?),").Groups["data"].Value;
            var match = Regex.Match(image, @"data:image/(?<type>.+?);base64,(?<data>.+)");
            var base64Data = match.Groups["data"].Value;
            var contentType = match.Groups["type"].Value;
            System.Diagnostics.Debug.WriteLine(contentType);
            var bytes = Convert.FromBase64String(base64Data);
            //string folderName = "Photos";
            string webRootPath = Environment.WebRootPath;
            string pathToSave = Path.Combine(webRootPath, folderName);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            var fileName = fileNamePersonnel + "." + contentType;
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }
            return dbPath;
        }
    }
}
