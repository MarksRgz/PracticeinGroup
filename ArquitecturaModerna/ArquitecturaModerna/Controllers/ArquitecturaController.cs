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
        public ActionResult Index()
        {
            Usuario user = (Usuario) Session["Usuario"];
            if (user != null)
            {
                IndexModelo lst = new BusGlobal().GetModeloIndex();
                return View(lst);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        // GET: Arquitectura
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
        public ActionResult Login()
        {
            ViewBag.MostrarError = false;
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario user)
        {
            Usuario usuario = new BusGlobal().GetUsuario(user.nombre_usua, user.pass_usua);
            if (usuario != null && usuario.estatus_usua)
            {
                Session["Usuario"] = usuario;
                return RedirectToAction("Index");
            }
            else if (usuario != null)
            {
                ViewBag.MostrarError = true;
                ViewBag.Error = $"Tu cuenta {usuario.nombre_usua} ha sido des habilitada, contacta al administrador.";
                return View();
            }
            else
            {
                ViewBag.MostrarError = true;
                ViewBag.Error = $"Usuario y/o password no válido.";
                return View();
            }
        }
        public ActionResult Close()
        {
            Session.Remove("Usuario");
            Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpPost]
        public ActionResult CreateP(Proyecto p)
        {
            p.img_proyecto = "proye1.png";
            Proyecto proye = new BusGlobal().CreateProyecto(p);
            
            Response.StatusCode = 200;
            Response.StatusDescription = "Objeto creado";
            return Json(proye, "application/json", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateS(Servicio s)
        {
            Servicio serv = new BusGlobal().CreateServicio(s);
            Response.StatusCode = 200;
            Response.StatusDescription = "Objeto creado";
            return Json(s, "application/json", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateB(Blog b)
        {
            Blog blog = new BusGlobal().CreateBlog(b);
            Response.StatusCode = 200;
            Response.StatusDescription = "Objeto creado";
            return Json(b, "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}