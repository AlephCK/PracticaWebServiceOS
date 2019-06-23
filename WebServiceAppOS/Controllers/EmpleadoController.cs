using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceAppOS.Data;
using WebServiceAppOS.Models;

namespace WebServiceAppOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     class EmpleadoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        //private static readonly ApplicationDbContext _context = new ApplicationDbContext();
        public EmpleadoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Empleado> Get()
        {
            return context.Empleados.ToList();
        }
    }
}