using Brachi.Bussines.BusPractica;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            Brachi.Bussines.BusPractica.Usuario user = (Brachi.Bussines.BusPractica.Usuario)Session["Usuario"];
            if (user != null)
            {
                ViewBag.GrupodeProducto = new SelectList(new BusCars().GetGrupos(), "id_grup", "nombre_grup");
                List<Marca> marca = new List<Marca>();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                List<Producto> producto = new List<Producto>();
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
                ViewBag.GrupodeProductohtml = new SelectList(new BusCars().GetGrupos(), "id_grup", "nombre_grup");
                List<Brachi.Bussines.BusPractica.Carro> lst = new BusCars().GetCarros();
                return View(lst);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult Index(string GrupodeProducto, string MarcadeProducto)
        {
            if (!string.IsNullOrEmpty(GrupodeProducto) && !string.IsNullOrEmpty(MarcadeProducto))
            {
                int idgpo = Convert.ToInt32(GrupodeProducto);
                ViewBag.GrupodeProducto = new SelectList(new BusCars().GetGrupos(), "id_grup", "nombre_grup");
                List<MarcaProd> marca = new BusCars().GetMarcasProd().Where(m => m.id_grup_marca == idgpo).ToList();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                int idmar = Convert.ToInt32(MarcadeProducto);
                List<Producto> producto = (new BusCars().GetProductos().Where(p => p.id_marca_prod == idmar).ToList());
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
                ViewBag.GrupodeProductohtml = new SelectList(new BusCars().GetGrupos(), "id_grup", "nombre_grup");
            }
            else if (!string.IsNullOrEmpty(GrupodeProducto) && string.IsNullOrEmpty(MarcadeProducto))
            {

                int idgpo = Convert.ToInt32(GrupodeProducto);
                ViewBag.GrupodeProducto = new SelectList(new BusCars().GetGrupos(), "id_grup", "nombre_grup");
                List<MarcaProd> marca = new BusCars().GetMarcasProd().Where(m => m.id_grup_marca == idgpo).ToList();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                ViewBag.GrupodeProductohtml = new SelectList(new BusCars().GetGrupos(), "id_grup", "nombre_grup");

                List<Producto> producto = new BusCars().GetProductos();
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
            }
            else
            {
                ViewBag.GrupodeProducto = new SelectList(new BusCars().GetGrupos(), "id_grup", "nombre_grup");
                List<MarcaProd> marca =new BusCars().GetMarcasProd();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                List<Producto> producto = new BusCars().GetProductos();
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
                ViewBag.GrupodeProductohtml = new SelectList(new BusCars().GetGrupos(), "id_grup", "nombre_grup");
            }
            List<Brachi.Bussines.BusPractica.Carro> lst = new BusCars().GetCarros();
            return View(lst);

        }
        public ActionResult GetGrupos(int id)
        {
            //return Json(new BusCars().GetMarcasProd().Where(m => m.id_grup_marca == id).ToList(), JsonRequestBehavior.AllowGet);
            var marca = new BusCars().GetMarcasProd().Where(m => m.id_grup_marca == id).Select(n => new { id_marca = n.id_marca, nombre_marca = n.nombre_marca }).ToList();

            return Json(marca, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetMarcas(int id)
        {
            var prod = new BusCars().GetProductos().Where(p => p.id_marca_prod == id).Select(n => new { id_prod = n.id_prod, nombre_prod = n.nombre_prod}).ToList();

            return Json(prod, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About(int id)
        {
            List<Brachi.Bussines.BusPractica.Carro> lst = new BusCars().GetCarros();
            Brachi.Bussines.BusPractica.Carro car = lst.FirstOrDefault(l => l.id_car == id);
            return View(car);
        }
        [HttpPost]
        public ActionResult Create(Carro car)
        {
            if (car.id_car == 0)
            {
                var archivo = Request.Files[1];
                archivo.SaveAs(Server.MapPath("~/images/" + archivo.FileName));
                Carro carro = new BusCars().CreateCarro(car);
            }
            else
            {
                var archivos = Request.Files;
                if (archivos.Count > 0)
                {
                    var archivo = Request.Files[0];
                    archivo.SaveAs(Server.MapPath("~/images/" + archivo.FileName));
                }
                Carro carro = new BusCars().CreateCarro(car);

            }
            Response.StatusCode = 200;
            Response.StatusDescription = "Objeto Creado";
            return Json(car, "application/jason", JsonRequestBehavior.AllowGet);
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
            Usuario usuario = new BusCars().GetUsuario(user.nombre_usua, user.pass_usua);
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
    }
}