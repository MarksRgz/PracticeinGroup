using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cars.Models;



namespace Cars.Controllers
{
    public class CarroEFController : Controller
    {
        private CarrosEF db = new CarrosEF();

        // GET: CarroEF
        public ActionResult Index()
        {
            var carro = db.Carro.Include(c => c.Marca).Include(c => c.Modelo);
            return View(carro.ToList());
        }

        // GET: CarroEF/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: CarroEF/Create
        public ActionResult Create()
        {
            ViewBag.id_marca_car = new SelectList(db.Marca, "id_marca", "nombre_marca");
            ViewBag.id_modelo_car = new SelectList(db.Modelo, "id_modelo", "nombre_modelo");
            return View();
        }

        // POST: CarroEF/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_car,id_marca_car,id_modelo_car,descripcion_car,imagen_car")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Carro.Add(carro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_marca_car = new SelectList(db.Marca, "id_marca", "nombre_marca", carro.id_marca_car);
            ViewBag.id_modelo_car = new SelectList(db.Modelo, "id_modelo", "nombre_modelo", carro.id_modelo_car);
            return View(carro);
        }

        // GET: CarroEF/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_marca_car = new SelectList(db.Marca, "id_marca", "nombre_marca", carro.id_marca_car);
            ViewBag.id_modelo_car = new SelectList(db.Modelo, "id_modelo", "nombre_modelo", carro.id_modelo_car);
            return View(carro);
        }

        // POST: CarroEF/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_car,id_marca_car,id_modelo_car,descripcion_car,imagen_car")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_marca_car = new SelectList(db.Marca, "id_marca", "nombre_marca", carro.id_marca_car);
            ViewBag.id_modelo_car = new SelectList(db.Modelo, "id_modelo", "nombre_modelo", carro.id_modelo_car);
            return View(carro);
        }

        // GET: CarroEF/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: CarroEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.Carro.Find(id);
            db.Carro.Remove(carro);
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
