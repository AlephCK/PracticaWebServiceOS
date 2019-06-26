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
    public class DetalleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetalleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Detalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle>>> GetDetalles()
        {
            return await _context.Detalles.ToListAsync();
        }

        // GET: api/Detalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalle>> GetDetalle(int id)
        {
            var detalle = await _context.Detalles.FindAsync(id);

            if (detalle == null)
            {
                return NotFound();
            }

            return detalle;
        }

        // PUT: api/Detalle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle(int id, Detalle detalle)
        {
            if (id != detalle.numEmision)
            {
                return BadRequest();
            }

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleExists(id))
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

        // POST: api/Detalle
        [HttpPost]
        public async Task<ActionResult<Detalle>> PostDetalle(Detalle detalle)
        {
            _context.Detalles.Add(detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalle", new { id = detalle.numEmision }, detalle);
        }

        // DELETE: api/Detalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Detalle>> DeleteDetalle(int id)
        {
            var detalle = await _context.Detalles.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.Detalles.Remove(detalle);
            await _context.SaveChangesAsync();

            return detalle;
        }

        private bool DetalleExists(int id)
        {
            return _context.Detalles.Any(e => e.numEmision == id);
        }
    }
}
