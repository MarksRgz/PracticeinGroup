using ArquitecturaModerna.Module;
using Beneficia.BusArquitectura.Buss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArquitecturaModerna.Controllers
{
    [RoutePrefix("api/arquitectura")]
    public class ApiGitPracticeController : ApiController
    {
        //API SLIDER
        [Route(""), BasicAuthorize]

        public HttpResponseMessage GetSliders()
        {
            var lst = new BusGlobal().GetSliders();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route("{idp}")]
        public HttpResponseMessage GetSlider(int idp)
        {
            var lst = new BusGlobal().GetSliders();
            Slider slider = lst.FirstOrDefault(s => s.id_slider == idp);
            if (lst == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, slider);
        }

        [HttpPut, Route("")]
        public HttpResponseMessage PutSlider(int idp, Slider slider)
        {
            int slid = new BusGlobal().UpdateSlider(slider);
            if (slid > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, slid);
            }
            return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }

        [HttpPost, Route(""), BasicAuthorize]
        public HttpResponseMessage PostSlider(Slider slider)
        {
            Slider slid = new BusGlobal().CreateSlider(slider);
            if (slid != null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, slid);
            }
            return Request.CreateResponse(HttpStatusCode.OK, false);
        }

        [HttpDelete, Route("")]
        public HttpResponseMessage DeleteSlider(int idp)
        {
            int slider = new BusGlobal().DeleteSlider(idp);
            if (slider > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, slider);
            }
            return Request.CreateResponse(HttpStatusCode.Conflict, false);
        }

        //API PROYECTO
        [Route("Proyecto"), BasicAuthorize]
        public HttpResponseMessage GetProyectos()
        {
            var lst = new BusGlobal().GetProyectos();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route("Proyecto"), BasicAuthorize]
        public HttpResponseMessage GetProyecto(int idp)
        {
            var lst = new BusGlobal().GetProyectos();
            Proyecto proye = lst.FirstOrDefault(s => s.id_proyecto == idp);
            if (lst == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, proye);
        }

        [HttpPut, Route("Proyecto")]
        public HttpResponseMessage PutProyecto(int idp, Proyecto proye)
        {
            int proyecto = new BusGlobal().UpdateProyecto(proye);
            if (proyecto > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, proyecto);
            }
            return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }

        [HttpPost, Route("Proyecto"), BasicAuthorize]
        public HttpResponseMessage PostProyecto(Proyecto proye)
        {
            Proyecto proyecto= new BusGlobal().CreateProyecto(proye);
            if (proyecto != null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, proyecto);
            }
            return Request.CreateResponse(HttpStatusCode.OK, false);
        }

        [HttpDelete, Route("Proyecto")]
        public HttpResponseMessage DeleteProyecto(int idp)
        {
            int proyecto = new BusGlobal().DeleteProyecto(idp);
            if (proyecto > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, proyecto);
            }
            return Request.CreateResponse(HttpStatusCode.Conflict, false);
        }

        //API SERVICIO
        [Route("Servicio"), BasicAuthorize]
        public HttpResponseMessage GetServicios()
        {
            var lst = new BusGlobal().GetServicios();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route("Servicio"), BasicAuthorize]
        public HttpResponseMessage GetServicio(int idp)
        {
            var lst = new BusGlobal().GetServicios();
            Servicio serv= lst.FirstOrDefault(s => s.id_serv == idp);
            if (lst == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, serv);
        }

        [HttpPut, Route("Servicio")]
        public HttpResponseMessage PutServicio(int idp, Servicio serv)
        {
            var servicio = new BusGlobal().UpdateServicio(serv);
            if (servicio > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, servicio);
            }
            return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }

        [HttpPost, Route("Servicio"), BasicAuthorize]
        public HttpResponseMessage PostServicio(Servicio serv)
        {
           Servicio servicio= new BusGlobal().CreateServicio(serv);
            if (servicio!= null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, servicio);
            }
            return Request.CreateResponse(HttpStatusCode.OK, false);
        }

        [HttpDelete, Route("Servicio")]
        public HttpResponseMessage DeleteServicio(int idp)
        {
            int servicio = new BusGlobal().DeleteServicio(idp);
            if (servicio > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, servicio);
            }
            return Request.CreateResponse(HttpStatusCode.Conflict, false);
        }
    }
}
