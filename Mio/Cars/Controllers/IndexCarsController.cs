using Cars.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tek.Cars.BusCars;

namespace Cars.Controllers
{
    public class IndexCarsController : Controller
    {
        private CarrosEF db = new CarrosEF();
        private ProductosEFEntities dbp = new ProductosEFEntities();
        // GET: IndexCars
        public ActionResult Index()
        {
            ViewBag.GrupodeProducto = new SelectList(dbp.Grupo, "id_grup", "nombre_grup");
            List<Cars.Models.Marca> marca = new List<Cars.Models.Marca>();
            ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
            List<Cars.Models.Producto> producto = new List<Cars.Models.Producto>();
            ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
            List<Tek.Cars.BusCars.Carro> carros = new BusCars().GetCarros();
            ViewBag.GrupodeProductohtml = new SelectList(dbp.Grupo, "id_grup", "nombre_grup");
            return View(carros);
        }
        [HttpPost]
        public ActionResult Index(string GrupodeProducto, string MarcadeProducto)
        {
            if (!string.IsNullOrEmpty(GrupodeProducto) && !string.IsNullOrEmpty(MarcadeProducto))
            {
                int idgpo = Convert.ToInt32(GrupodeProducto);
                ViewBag.GrupodeProducto = new SelectList(dbp.Grupo, "id_grup", "nombre_grup");
                List<Cars.Models.Marca> marca = dbp.Marca.Where(m => m.id_grup_marca == idgpo).ToList();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                int idmar = Convert.ToInt32(MarcadeProducto);
                List<Cars.Models.Producto> producto = (dbp.Producto.Where(p => p.id_marca_prod == idmar).ToList());
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
                ViewBag.GrupodeProductohtml = new SelectList(dbp.Grupo, "id_grup", "nombre_grup");
            }
            else if (!string.IsNullOrEmpty(GrupodeProducto) && string.IsNullOrEmpty(MarcadeProducto))
            {

                int idgpo = Convert.ToInt32(GrupodeProducto);
                ViewBag.GrupodeProducto = new SelectList(dbp.Grupo, "id_grup", "nombre_grup");
                List<Cars.Models.Marca> marca = dbp.Marca.Where(m => m.id_grup_marca == idgpo).ToList();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                ViewBag.GrupodeProductohtml = new SelectList(dbp.Grupo, "id_grup", "nombre_grup");

                List<Cars.Models.Producto> producto = new List<Cars.Models.Producto>();
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
            }
            else
            {
                ViewBag.GrupodeProducto = new SelectList(dbp.Grupo, "id_grup", "nombre_grup");
                List<Cars.Models.Marca> marca = new List<Cars.Models.Marca>();
                ViewBag.MarcadeProducto = new SelectList(marca, "id_marca", "nombre_marca");
                List<Cars.Models.Producto> producto = new List<Cars.Models.Producto>();
                ViewBag.Producto = new SelectList(producto, "id_prod", "nombre_prod");
                ViewBag.GrupodeProductohtml = new SelectList(dbp.Grupo, "id_grup", "nombre_grup");
            }
            List<Tek.Cars.BusCars.Carro> carros = new BusCars().GetCarros();
            return View(carros);

        }
        public ActionResult GetGrupos(int id)
        {
            return Json(dbp.Marca.Where(m => m.id_grup_marca == id).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetMarcas(int id)
        {
            return Json(dbp.Producto.Where(p => p.id_marca_prod == id).ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            List<Tek.Cars.BusCars.Carro> carros = new BusCars().GetCarros();
            return View(carros);
        }
        [HttpPost]
        public ActionResult Create(Cars.Models.Carro car)
        {
            if (car.id_car == 0)
            {
                var archivo = Request.Files[0];
                archivo.SaveAs(Server.MapPath("~/images/" + archivo.FileName));
                db.Carro.Add(car);
                db.SaveChanges();
            }
            else
            {
                var archivos = Request.Files;
                if (archivos.Count > 0)
                {
                    var archivo = Request.Files[0];
                    archivo.SaveAs(Server.MapPath("~/images/" + archivo.FileName));
                }
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
            }
            Response.StatusCode = 200;
            Response.StatusDescription = "Objeto Creado";
            return Json(car, "application/jason", JsonRequestBehavior.AllowGet);
        }
    }
}
