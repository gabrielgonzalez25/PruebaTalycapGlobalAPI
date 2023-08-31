using Microsoft.AspNetCore.Mvc;
using PruebaTalycapGlobal.Models;
using System.Diagnostics;
using PruebaTalycapGlobalAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
namespace PruebaTalycapGlobal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpGet]
        public IActionResult CreateCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearClientes(Clientes cliente)
        {
            List<Clientes> clientes = new List<Clientes>();
            string apiUrl = "https://localhost:7093/api/Clientes";

            HttpClient client = new HttpClient();
            // HttpResponseMessage response = client.PostAsync(apiUrl + "/" + usuario.ToString()).Result);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PostAsync(apiUrl, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Mensaje"] = "El Cliente se creo correctamente";
                    return RedirectToAction("Index", "Home");
                }
            }


            return View();
        }

        [HttpGet]
        public IActionResult PutClientes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clientes usuarios = new Clientes();
            string apiUrl = "https://localhost:7093/api/Clientes";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl + "/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                usuarios = JsonConvert.DeserializeObject<Clientes>(response.Content.ReadAsStringAsync().Result);
                //users = usuarios.ToList();
            }

            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> EditarClientes(Clientes clientes)
        {
            Clientes usuarios = new Clientes();
            string apiUrl = "https://localhost:7093/api/Clientes";

            HttpClient client = new HttpClient();
            // HttpResponseMessage response = client.PostAsync(apiUrl + "/" + usuario.ToString()).Result);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(clientes), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PutAsync(apiUrl + "/" + clientes.IdCliente.ToString(), httpContent);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Mensaje"] = "El Cliente se edito correctamente";
                    return RedirectToAction("Index", "Home");
                }
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerClientes()
        {
            List<Clientes> usuarios = new List<Clientes>();
            string apiUrl = "https://localhost:7093/api/Clientes";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                usuarios = JsonConvert.DeserializeObject<List<Clientes>>(response.Content.ReadAsStringAsync().Result);

                //users = usuarios.ToList();
            }

            var permanenciaVehiculo = 0;




            return View(usuarios);
        }

        [HttpDelete]
        public async Task<IActionResult> BorrarClientes(int? IdCliente)
        {
            List<Clientes> usuarios = new List<Clientes>();
            string apiUrl = "https://localhost:7093/api/Clientes";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.DeleteAsync(apiUrl + "/" + IdCliente.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "El control vehicular se borro correctamente";
                return RedirectToAction("Index", "Home");
            }

            return View();

        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CreateLogisticaMaritima()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearLogisticaMaritima(LogisticaMaritima logisticaMaritima)
        {
            if (ModelState.IsValid)
            {
                if (logisticaMaritima.CantidadProducto > 10)
                {
                    logisticaMaritima.PrecioEnvioNormal = logisticaMaritima.PrecioEnvio;
                    double desc = logisticaMaritima.PrecioEnvio * 0.03;
                    logisticaMaritima.PrecioEnvio = logisticaMaritima.PrecioEnvio - desc;
                    logisticaMaritima.Descuento = desc;
                    
                }

                List<LogisticaMaritima> logisticaMaritimas = new List<LogisticaMaritima>();
                string apiUrl = "https://localhost:7093/api/LogisticaMaritima";

                HttpClient client = new HttpClient();
                // HttpResponseMessage response = client.PostAsync(apiUrl + "/" + usuario.ToString()).Result);
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(logisticaMaritima), Encoding.UTF8);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await httpClient.PostAsync(apiUrl, httpContent);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Mensaje"] = " se creo correctamente";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocurrió un error interno en el servidor.");
                        return View("CreateLogisticaMaritima", logisticaMaritima);
                    }
                }
            }
            else
            {
                return View("CreateLogisticaMaritima", logisticaMaritima);
            }
            
        }

        [HttpGet]
        public IActionResult PutLogisticaMaritima(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LogisticaMaritima usuarios = new LogisticaMaritima();
            string apiUrl = "https://localhost:7093/api/LogisticaMaritima";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl + "/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                usuarios = JsonConvert.DeserializeObject<LogisticaMaritima>(response.Content.ReadAsStringAsync().Result);
                //users = usuarios.ToList();
            }

            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> EditarLogisticaMaritima(LogisticaMaritima logisticaMaritima)
        {
            LogisticaMaritima usuarios = new LogisticaMaritima();
            string apiUrl = "https://localhost:7093/api/LogisticaMaritima";

            HttpClient client = new HttpClient();
            // HttpResponseMessage response = client.PostAsync(apiUrl + "/" + usuario.ToString()).Result);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(logisticaMaritima), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PutAsync(apiUrl + "/" + logisticaMaritima.NumeroGuia, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Mensaje"] = "El control se edito correctamente";
                    return RedirectToAction("Index", "Home");
                }
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerLogisticaMaritima()
        {
            List<LogisticaMaritima> usuarios = new List<LogisticaMaritima>();
            string apiUrl = "https://localhost:7093/api/LogisticaMaritima";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                usuarios = JsonConvert.DeserializeObject<List<LogisticaMaritima>>(response.Content.ReadAsStringAsync().Result);

                //users = usuarios.ToList();
            }

            var permanenciaVehiculo = 0;




            return View(usuarios);
        }

        [HttpDelete]
        public async Task<IActionResult> BorrarLogisticaMaritima(int? NumeroGuia)
        {
            List<LogisticaMaritima> usuarios = new List<LogisticaMaritima>();
            string apiUrl = "https://localhost:7093/api/LogisticaMaritima";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.DeleteAsync(apiUrl + "/" + NumeroGuia.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "El control vehicular se borro correctamente";
                return RedirectToAction("Index", "Home");
            }

            return View();

        }

        [HttpGet]
        public IActionResult CreateLogisticaTerrestre()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearLogisticaTerrestre(LogisticaTerrestre logisticaTerrestre)
        {
            if (ModelState.IsValid)
            {
                if (logisticaTerrestre.CantidadProducto > 10)
                {
                    logisticaTerrestre.PrecioEnvioNormal = logisticaTerrestre.PrecioEnvio;
                    double desc = logisticaTerrestre.PrecioEnvio * 0.03;
                    logisticaTerrestre.PrecioEnvio = logisticaTerrestre.PrecioEnvio - desc;
                    logisticaTerrestre.Descuento = desc;

                }
                List<LogisticaTerrestre> logisticaTerrestres = new List<LogisticaTerrestre>();
                string apiUrl = "https://localhost:7093/api/LogisticaTerrestre";

                HttpClient client = new HttpClient();
                // HttpResponseMessage response = client.PostAsync(apiUrl + "/" + usuario.ToString()).Result);
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(logisticaTerrestre), Encoding.UTF8);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await httpClient.PostAsync(apiUrl, httpContent);
                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Mensaje"] = " se creo correctamente";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocurrió un error interno en el servidor.");
                        return View("CreateLogisticaTerrestre", logisticaTerrestre);
                    }
                }
            }
            else
            {
                return View("CreateLogisticaTerrestre", logisticaTerrestre);
            }
        }

        [HttpGet]
        public IActionResult PutLogisticaTerrestre(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LogisticaTerrestre usuarios = new LogisticaTerrestre();
            string apiUrl = "https://localhost:7093/api/LogisticaTerrestre";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl + "/" + id.ToString()).Result;

            if (response.IsSuccessStatusCode)
            {
                usuarios = JsonConvert.DeserializeObject<LogisticaTerrestre>(response.Content.ReadAsStringAsync().Result);
                //users = usuarios.ToList();
            }

            if (usuarios == null)
            {
                return NotFound();
            }

            return View(usuarios);
        }

        [HttpPost]
        public async Task<IActionResult> EditarLogisticaTerrestre(LogisticaTerrestre logisticaTerrestre)
        {
            LogisticaTerrestre usuarios = new LogisticaTerrestre();
            string apiUrl = "https://localhost:7093/api/LogisticaTerrestre";

            HttpClient client = new HttpClient();
            // HttpResponseMessage response = client.PostAsync(apiUrl + "/" + usuario.ToString()).Result);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(logisticaTerrestre), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PutAsync(apiUrl + "/" + logisticaTerrestre.NumeroGuia.ToString(), httpContent);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Mensaje"] = "El control se edito correctamente";
                    return RedirectToAction("Index", "Home");
                }
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerLogisticaTerrestre()
        {
            List<LogisticaTerrestre> usuarios = new List<LogisticaTerrestre>();
            string apiUrl = "https://localhost:7093/api/LogisticaTerrestre";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                usuarios = JsonConvert.DeserializeObject<List<LogisticaTerrestre>>(response.Content.ReadAsStringAsync().Result);

                //users = usuarios.ToList();
            }

            var permanenciaVehiculo = 0;




            return View(usuarios);
        }

        [HttpDelete]
        public async Task<IActionResult> BorrarLogisticaTerrestre(int? NumeroGuia)
        {
            List<LogisticaTerrestre> usuarios = new List<LogisticaTerrestre>();
            string apiUrl = "https://localhost:7093/api/LogisticaTerrestre";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.DeleteAsync(apiUrl + "/" + NumeroGuia.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "El control vehicular se borro correctamente";
                return RedirectToAction("Index", "Home");
            }

            return View();

        }

    }
}