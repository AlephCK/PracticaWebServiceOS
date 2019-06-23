using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebServiceAppOS.Data;
using WebServiceAppOS.Models;

namespace WebServiceAppOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        //Tratando de generar los datos falsos para que la api los devuelva como un json
        protected override void GenerateEmpleado(Data.ApplicationDbContext context)
        {
            Randomizer.Seed = new Random(381209);
            string digitos = "0123456789";
            List<Empleado> empleados = new List<Empleado>();

            Console.WriteLine("Generating fake Empleados...");

            for (int i = 0; i < 50; i++)
            {
                var empleado = new Faker<Empleado>()
                    .RuleFor(e => e.Cedula_Empleado, f => f.Random.String2(11, digitos))
                    .RuleFor(e => e.Cuenta_Empleado, f => f.Random.String2(10, digitos))
                    .RuleFor(e => e.Email, (f, u) => f.Internet.Email(u.Nombre, u.Apellido))
                    .RuleFor(e => e.Nombre, f => f.Name.FirstName())
                    .RuleFor(e => e.Apellido, f => f.Name.LastName())
                    .RuleFor(e => e.Sueldo, f => f.Finance.Amount(11000, 200000));

                empleados.Add(empleado.Generate());
            }

            _context.Empleados.AddRangeAsync(empleados);
            _context.SaveChangesAsync();
        }


        // GET: api/Empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleados
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.Id }, empleado);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empleado>> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
