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
    }
}
