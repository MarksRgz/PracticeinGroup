using Practica_Git.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Practica_Git.Controllers
{
    public class ConsumoController : Controller
    {
        // GET: Consumo
        public ActionResult Index()
        {
            var client = new RestClient("http://localhost/MyAPI/api/carros/3");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            Carro car = JsonConvert.DeserializeObject<Carro>(response.Content);
            return View(car);
        }
    }
}