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
        {

            CreateWebHostBuilder(args).Build().Run();
        }




        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
