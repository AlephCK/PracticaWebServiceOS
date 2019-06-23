using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebServiceAppOS.Models;
using WebServiceAppOS.Data;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace WebServiceAppOS
{
    public class Program
    {
        private static readonly ApplicationDbContext _context = new ApplicationDbContext();

        public static void Main(string[] args)
        //static async Task Main(string[] args)
        {
            
            //await GenerateEmpleados();
            CreateWebHostBuilder(args).Build().Run();
        }


        //static async Task GenerateEmpleados()
        //{
        //    Randomizer.Seed = new Random(381209);
        //    string digitos = "0123456789";
        //    List<Empleado> empleados = new List<Empleado>();

        //    if (await _context.Empleados.AnyAsync())
        //        return;

        //    Console.WriteLine("Generating fake Empleados...");

        //    for (int i = 0; i < 50; i++)
        //    {
        //        var empleado = new Faker<Empleado>()
        //            .RuleFor(e => e.Cedula_Empleado, f => f.Random.String2(11, digitos))
        //            .RuleFor(e => e.Cuenta_Empleado, f => f.Random.String2(10, digitos))
        //            .RuleFor(e => e.Email, (f, u) => f.Internet.Email(u.Nombre, u.Apellido))
        //            .RuleFor(e => e.Nombre, f => f.Name.FirstName())
        //            .RuleFor(e => e.Apellido, f => f.Name.LastName())
        //            .RuleFor(e => e.Sueldo, f => f.Finance.Amount(11000, 200000));

        //        empleados.Add(empleado.Generate());
        //    }

        //    await _context.Empleados.AddRangeAsync(empleados);
        //    await _context.SaveChangesAsync();
        //}

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
