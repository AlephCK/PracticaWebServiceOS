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
            
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Acreditacion");
            HttpResponseMessage res2 = await client.GetAsync("api/Detalle");
            var result = res.Content.ReadAsStringAsync().Result;
            var result2 = res2.Content.ReadAsStringAsync().Result;

                var acreDetails = new AcreditacionDetalle
                {
                    acreditaciones = JsonConvert.DeserializeObject<List<Acreditacion>>(result),
                    detalles = JsonConvert.DeserializeObject<List<Detalle>>(result2)

                  };
                
                //acreditaciones = JsonConvert.DeserializeObject<List<Acreditacion>>(result);
            
            return View(acreDetails);
        }

        //public async Task<IActionResult> Detalle()
        //{
           
        //    HttpClient client = _api.Initial();
        //    HttpResponseMessage res = await client.GetAsync("api/Detalle");

        //    if (res.IsSuccessStatusCode)
        //    {

              

        //        //var result = res.Content.ReadAsStringAsync().Result;
        //        // detalles = JsonConvert.DeserializeObject<List<Detalle>>(result);
        //    }


        //    //return View(detalles);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Pipo()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Acreditacion acreditacion)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58022/api/Acreditacion");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Acreditacion>("acreditacion", acreditacion);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(acreditacion);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58022/api/Acreditacion");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("acreditacion/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult costoTotal(int Matricula, int cantidadCreditos)
        {
            var valorCreditos = 1500;

            return Content((valorCreditos * cantidadCreditos).ToString());


        }

    }
}
