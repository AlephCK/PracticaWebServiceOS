﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServiceAppOS.Models;

namespace WebServiceAppOS.Data
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(@"Host=localhost; Database=Practica_0; Username=postgres; Password=asdf1234;");
            optionsBuilder.UseNpgsql(@"Host=localhost; Database=Practica_0; Username=postgres; Password=@dmin;");
            //optionsBuilder.UseNpgsql(@"Host=localhost; Database=Practica_0; Username=postgres; Password=admin;");
            base.OnConfiguring(optionsBuilder);

        }


    }
}
