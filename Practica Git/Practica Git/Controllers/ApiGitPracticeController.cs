using Brachi.Bussines.BusPractica;
using Practica_Git.Models;
using Practica_Git.Module;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practica_Git.Controllers
{
    [RoutePrefix("api/carros")]
    public class ApiGitPracticeController : ApiController
    {
        private CarrosWellEntities dbw = new CarrosWellEntities();
        [Route(""), BasicAuthorize]
        // GET: api/APICarros
        public HttpResponseMessage GetCarros()
        {
            var lst = new BusCars().GetCarros();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }
        [Route("marcas")]
        public HttpResponseMessage GetMarcas()
        {
            var lst = new BusCars().GetMarcas();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }
        // GET: api/APICarros/5
        //[ResponseType(typeof(Carro))]
        [Route("{idp}")]
        public HttpResponseMessage GetCarro(int idp)
        {
            var lst = new BusCars().GetCarros();
            Brachi.Bussines.BusPractica.Carro car = lst.FirstOrDefault(l => l.id_car == idp);
            if (lst == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, car);
        }
        // PUT: api/APICarros/5
        //[ResponseType(typeof(void))]
        [HttpPut, Route("")]
        public HttpResponseMessage PutCarro(int idp, Brachi.Bussines.BusPractica.Carro carro)
        {
            var lst = new BusCars().GetCarros();
            Brachi.Bussines.BusPractica.Carro car = lst.FirstOrDefault(l => l.id_car == idp);
            if (idp != 1)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, car);
            }
            return Request.CreateResponse(HttpStatusCode.OK, car);
        }

        // POST: api/APICarros
        //[ResponseType(typeof(Carro))]
        [HttpPost, Route(""), BasicAuthorize]
        public HttpResponseMessage PostCarro(Brachi.Bussines.BusPractica.Carro carro)
        {
            var lst = dbw.Carro.Select(c => new { id_car = c.id_car, descripcion_car = c.descripcion_car }).FirstOrDefault(c => c.id_car == carro.id_car);
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
            var lst = dbw.Carro.Select(c => new { id_car = c.id_car, descripcion_car = c.descripcion_car }).FirstOrDefault(c => c.id_car == idp);
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
                dbw.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarroExists(int id)
        {
            return dbw.Carro.Count(e => e.id_car == id) > 0;
        }
    }
}
