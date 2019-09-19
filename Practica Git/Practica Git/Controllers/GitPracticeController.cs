using Brachi.Bussines.BusPractica;
using Practica_Git.Models;
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
        private EFProductosEntities db = new EFProductosEntities();
        private CarrosWellEntities dbw = new CarrosWellEntities();
        // GET: Home
        public ActionResult Index()
        {
            Practica_Git.Models.Usuario user = (Practica_Git.Models.Usuario)Session["Usuario"];
            if (user != null)
            {
                ViewBag.GrupodeProducto = new SelectList(db.Grupo, "id_grup", "nombre_grup");
                List<Practica_Git.Models.Marca> marca = new List<Practica_Git.Models.Marca>();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                List<Practica_Git.Models.Producto> producto = new List<Practica_Git.Models.Producto>();
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
                ViewBag.GrupodeProductohtml = new SelectList(db.Grupo, "id_grup", "nombre_grup");
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
                ViewBag.GrupodeProducto = new SelectList(db.Grupo, "id_grup", "nombre_grup");
                List<Practica_Git.Models.Marca> marca = db.Marca.Where(m => m.id_grup_marca == idgpo).ToList();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                int idmar = Convert.ToInt32(MarcadeProducto);
                List<Practica_Git.Models.Producto> producto = (db.Producto.Where(p => p.id_marca_prod == idmar).ToList());
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
                ViewBag.GrupodeProductohtml = new SelectList(db.Grupo, "id_grup", "nombre_grup");
            }
            else if (!string.IsNullOrEmpty(GrupodeProducto) && string.IsNullOrEmpty(MarcadeProducto))
            {

                int idgpo = Convert.ToInt32(GrupodeProducto);
                ViewBag.GrupodeProducto = new SelectList(db.Grupo, "id_grup", "nombre_grup");
                List<Practica_Git.Models.Marca> marca = db.Marca.Where(m => m.id_grup_marca == idgpo).ToList();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                ViewBag.GrupodeProductohtml = new SelectList(db.Grupo, "id_grup", "nombre_grup");

                List<Practica_Git.Models.Producto> producto = new List<Practica_Git.Models.Producto>();
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
            }
            else
            {
                ViewBag.GrupodeProducto = new SelectList(db.Grupo, "id_grup", "nombre_grup");
                List<Practica_Git.Models.Marca> marca = new List<Practica_Git.Models.Marca>();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                List<Practica_Git.Models.Producto> producto = new List<Practica_Git.Models.Producto>();
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
                ViewBag.GrupodeProductohtml = new SelectList(db.Grupo, "id_grup", "nombre_grup");
            }
            List<Brachi.Bussines.BusPractica.Carro> lst = new BusCars().GetCarros();
            return View(lst);

        }
        public ActionResult GetGrupos(int id)
        {
            //return Json(db.Marca.Where(m => m.id_grup_marca == id).ToList(), JsonRequestBehavior.AllowGet);
            List<Practica_Git.Models.Marca> marca = db.Marca.Where(m => m.id_grup_marca == id).ToList();
            return View(marca);
        }
        public ActionResult GetMarcas(int id)
        {
            return Json(db.Producto.Where(p => p.id_marca_prod == id).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult About(int id)
        {
            List<Brachi.Bussines.BusPractica.Carro> lst = new BusCars().GetCarros();
            Brachi.Bussines.BusPractica.Carro car = lst.FirstOrDefault(l => l.id_car == id);
            return View(car);
        }
        [HttpPost]
        public ActionResult Create(Practica_Git.Models.Carro car)
        {
            if (car.id_car == 0)
            {
                var archivo = Request.Files[1];
                archivo.SaveAs(Server.MapPath("~/images/" + archivo.FileName));
                //dbc.Carro.Add(car);
                dbw.SaveChanges();
            }
            else
            {
                var archivos = Request.Files;
                if (archivos.Count > 0)
                {
                    var archivo = Request.Files[0];
                    archivo.SaveAs(Server.MapPath("~/images/" + archivo.FileName));
                }
                dbw.Entry(car).State = EntityState.Modified;
                dbw.SaveChanges();
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
        public ActionResult Login(Practica_Git.Models.Usuario user)
        {
            Practica_Git.Models.Usuario usuario = db.Usuario.Where(u => u.nombre_usua == user.nombre_usua && u.pass_usua == user.pass_usua && u.estatus_usua == user.estatus_usua).FirstOrDefault();
            if (usuario != null && user.estatus_usua)
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