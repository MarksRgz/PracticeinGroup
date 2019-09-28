using Beneficia.BusArquitectura.Buss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArquitecturaModerna.Controllers
{
    public class ArquitecturaController : Controller
    {
        // GET: Arquitectura
        public ActionResult Index()
        {
            IndexModelo lst = new BusGlobal().GetModeloIndex();
            return View(lst);
        }
        public ActionResult About()
        {
            List<Testimonio> lst = new BusGlobal().GetTestimonios();
            return View(lst);
        }
        public ActionResult Proyectos()
        {
            List<Proyecto> lst = new BusGlobal().GetProyectos();
            return View(lst);
        }
        public ActionResult Servicios()
        {
            List<Servicio> lst = new BusGlobal().GetServicios();
            return View(lst);
        }
        public ActionResult Blog()
        {
            List<Blog> lst = new BusGlobal().GetBlogs();
            return View(lst);
        }
    }
}