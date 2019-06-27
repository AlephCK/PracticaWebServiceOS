using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientOS.Models;
using ClientOS.Helper;
using WebServiceAppOS.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace ClientOS.Controllers
{
    public class HomeController : Controller
    {

        AcreditacionAPI _api = new AcreditacionAPI();

        public async Task <IActionResult> Index()
        {
            List<Acreditacion> acreditaciones = new List<Acreditacion>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Acreditacion");

            if (res.IsSuccessStatusCode)
            {

                var result = res.Content.ReadAsStringAsync().Result;
                acreditaciones = JsonConvert.DeserializeObject<List<Acreditacion>>(result);
            }


            return View(acreditaciones);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
