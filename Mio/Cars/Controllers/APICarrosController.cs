using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cars.Models;

namespace Cars.Controllers
{
    [RoutePrefix("api/carros")]
    public class APICarrosController : ApiController
    {
        private CarrosEF db = new CarrosEF();
        [Route("")]
        public HttpResponseMessage GetCarros()
        {
            try
            {
                var lst = db.Carro.Select(c => new { id_car = c.id_car, descripcion_car = c.descripcion_car }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, lst);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
