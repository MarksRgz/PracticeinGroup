using Brachi.Bussines.BusPractica;
using Practica_Git.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Carro = Brachi.Bussines.BusPractica.Carro;

namespace Practica_Git.Controllers
{
    [RoutePrefix("api/carros")]
    public class ApiGitPracticeController : ApiController
    {
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
        public HttpResponseMessage PutCarro(int idp, Carro carro)
        {
            int car1 = new BusCars().UpdateCarro(carro);
            if (car1 > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, true);
            }
            return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }
        // POST: api/APICarros
        //[ResponseType(typeof(Carro))]
        [HttpPost, Route(""), BasicAuthorize]
        public HttpResponseMessage PostCarro(Carro carro)
        {
            Carro car1 = new BusCars().CreateCarro(carro);
            if (car1 != null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, car1);
            }
            return Request.CreateResponse(HttpStatusCode.OK, false);
        }

        // DELETE: api/APICarros/5
        //[ResponseType(typeof(Carro))]
        [HttpDelete, Route("")]
        public HttpResponseMessage DeleteCarro(int idp)
        {
            int car1 = new BusCars().DeleteCarro(idp);
            if (car1 > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, true);
            }
            return Request.CreateResponse(HttpStatusCode.Conflict, false);
        }
    }
}
