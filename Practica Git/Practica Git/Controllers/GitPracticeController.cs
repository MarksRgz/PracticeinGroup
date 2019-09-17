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
        private CarrosEFEntities dbc = new CarrosEFEntities();
        private EFProductosEntities db = new EFProductosEntities();
        //private CarrosEFEntities dbc = new CarrosEFEntities();
        // GET: Home
        public ActionResult Index()
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
            return Json(db.Marca.Where(m => m.id_grup_marca == id).ToList(), JsonRequestBehavior.AllowGet);
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
        public ActionResult Create(Practica_Git.Models.Carro car)
        {
            if (car.id_car == 0)
            {
                var archivo = Request.Files[1];
                archivo.SaveAs(Server.MapPath("~/images/" + archivo.FileName));
                dbc.Carro.Add(car);
                dbc.SaveChanges();
            }
            else
            {
                var archivos = Request.Files;
                if (archivos.Count > 0)
                {
                    var archivo = Request.Files[0];
                    archivo.SaveAs(Server.MapPath("~/images/" + archivo.FileName));
                }
                dbc.Entry(car).State = EntityState.Modified;
                dbc.SaveChanges();
            }
            Response.StatusCode = 200;
            Response.StatusDescription = "Objeto Creado";
            return Json(car, "application/jason", JsonRequestBehavior.AllowGet);
        }
    }
}