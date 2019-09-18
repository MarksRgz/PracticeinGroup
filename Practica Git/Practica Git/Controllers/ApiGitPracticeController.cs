using Practica_Git.Models;
using Practica_Git.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practica_Git.Controllers
{
    [RoutePrefix("api/carros")]
    public class ApiGitPracticeController : ApiController
    {
        private CarrosEFEntities db = new CarrosEFEntities();
        private CarrosWellEntities dbc = new CarrosWellEntities();
        [Route(""), BasicAuthorize]
        // GET: api/APICarros
        public HttpResponseMessage GetCarros()
        {
            var lst = dbc.Carro.Select(c => new { id_car = c.id_car, descripcion_car = c.descripcion_car /*nombre_marca = c.nombre_marca, nombre_modelo = c.nombre_modelo*/}).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }
        [Route("marca")]
        public HttpResponseMessage GetMarca()
        {
            var lst = db.Marca.Select(m => new { id_marca = m.id_marca, nombre_marca = m.nombre_marca }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }
        // GET: api/APICarros/5
        //[ResponseType(typeof(Carro))]
        [Route("{idp}")]
        public HttpResponseMessage GetCarro(int idp)
        {
            //Carro carro = db.Carro.Find(idp);
            var lst = db.Carro.Select(c => new { id_car = c.id_car, descripcion_car = c.descripcion_car }).FirstOrDefault(c => c.id_car == idp);
            if (lst == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        // PUT: api/APICarros/5
        //[ResponseType(typeof(void))]
        [HttpPut, Route("")]
        public HttpResponseMessage PutCarro(int idp, Carro carro)
        {
            var lst = db.Carro.Select(c => new { id_car = c.id_car, descripcion_car = c.descripcion_car }).FirstOrDefault(c => c.id_car == idp);
            if (lst == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        // POST: api/APICarros
        //[ResponseType(typeof(Carro))]
        [HttpPost, Route(""), BasicAuthorize]
        public HttpResponseMessage PostCarro(Carro carro)
        {
            var lst = db.Carro.Select(c => new { id_car = c.id_car, descripcion_car = c.descripcion_car }).FirstOrDefault(c => c.id_car == carro.id_car);
            if (lst == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        // DELETE: api/APICarros/5
        //[ResponseType(typeof(Carro))]
        [HttpDelete, Route("")]
        public HttpResponseMessage DeleteCarro(int idp)
        {
            var lst = db.Carro.Select(c => new { id_car = c.id_car, descripcion_car = c.descripcion_car }).FirstOrDefault(c => c.id_car == idp);
            if (lst == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarroExists(int id)
        {
            return db.Carro.Count(e => e.id_car == id) > 0;
        }
    }
}
