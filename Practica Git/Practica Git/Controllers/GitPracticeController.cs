using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica_Git.Controllers
{
    public class GitPracticeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Models.Carro> lst = new List<Models.Carro>();
            return View(lst);
        }
    }
}