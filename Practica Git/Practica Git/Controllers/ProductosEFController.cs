using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica_Git.Models;

namespace Practica_Git.Controllers
{
    public class ProductosEFController : Controller
    {
        private ProductosWellEntities db = new ProductosWellEntities();

        // GET: ProductosEF
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Grupo).Include(p => p.Marca);
            return View(producto.ToList());
        }

        // GET: ProductosEF/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: ProductosEF/Create
        public ActionResult Create()
        {
            ViewBag.id_grup_prod = new SelectList(db.Grupo, "id_grup", "nombre_grup");
            ViewBag.id_marca_prod = new SelectList(db.Marca, "id_marca", "nombre_marca");
            return View();
        }

        // POST: ProductosEF/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prod,nombre_prod,id_marca_prod,id_grup_prod")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_grup_prod = new SelectList(db.Grupo, "id_grup", "nombre_grup", producto.id_grup_prod);
            ViewBag.id_marca_prod = new SelectList(db.Marca, "id_marca", "nombre_marca", producto.id_marca_prod);
            return View(producto);
        }

        // GET: ProductosEF/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_grup_prod = new SelectList(db.Grupo, "id_grup", "nombre_grup", producto.id_grup_prod);
            ViewBag.id_marca_prod = new SelectList(db.Marca, "id_marca", "nombre_marca", producto.id_marca_prod);
            return View(producto);
        }

        // POST: ProductosEF/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prod,nombre_prod,id_marca_prod,id_grup_prod")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_grup_prod = new SelectList(db.Grupo, "id_grup", "nombre_grup", producto.id_grup_prod);
            ViewBag.id_marca_prod = new SelectList(db.Marca, "id_marca", "nombre_marca", producto.id_marca_prod);
            return View(producto);
        }

        // GET: ProductosEF/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: ProductosEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
