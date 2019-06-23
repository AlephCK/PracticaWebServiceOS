using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceAppOS.Data;
using WebServiceAppOS.Models;

namespace WebServiceAppOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcreditacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AcreditacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Acreditacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acreditacion>>> GetAcreditaciones()
        {
            return await _context.Acreditaciones.ToListAsync();
        }

        // GET: api/Acreditacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Acreditacion>> GetAcreditacion(string id)
        {
            var acreditacion = await _context.Acreditaciones.FindAsync(id);

            if (acreditacion == null)
            {
                return NotFound();
            }

            return acreditacion;
        }

        // PUT: api/Acreditacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcreditacion(string id, Acreditacion acreditacion)
        {
            if (id != acreditacion.Matricula)
            {
                return BadRequest();
            }

            _context.Entry(acreditacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcreditacionExists(id))
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

        // POST: api/Acreditacion
        [HttpPost]
        public async Task<ActionResult<Acreditacion>> PostAcreditacion(Acreditacion acreditacion)
        {
            _context.Acreditaciones.Add(acreditacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcreditacion", new { id = acreditacion.Matricula }, acreditacion);
        }

        // DELETE: api/Acreditacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Acreditacion>> DeleteAcreditacion(string id)
        {
            var acreditacion = await _context.Acreditaciones.FindAsync(id);
            if (acreditacion == null)
            {
                return NotFound();
            }

            _context.Acreditaciones.Remove(acreditacion);
            await _context.SaveChangesAsync();

            return acreditacion;
        }

        private bool AcreditacionExists(string id)
        {
            return _context.Acreditaciones.Any(e => e.Matricula == id);
        }
    }
}
