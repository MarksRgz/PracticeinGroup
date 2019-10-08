using ArquitecturaModerna.Module;
using AspNetWebApi.Extensions;
using Beneficia.BusArquitectura.Buss;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

    }

    [RoutePrefix("api/proyecto")]
    public class ApiGitProyectoController : ApiController
    {
        //API PROYECTO
        [Route(""), BasicAuthorize]
        public HttpResponseMessage GetProyectos()
        {
            var lst = new BusGlobal().GetProyectos();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route(""), BasicAuthorize]
        public HttpResponseMessage GetProyecto(int idp)
        {
            var lst = new BusGlobal().GetProyectos();
            Proyecto proye = lst.FirstOrDefault(s => s.id_proyecto == idp);
            if (proye == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, proye);
        }

        [HttpPut, Route("")]
        public HttpResponseMessage PutProyecto(int idp, Proyecto proye)
        {
            int proyecto = new BusGlobal().UpdateProyecto(proye);
            if (proyecto > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, proyecto);
            }
            return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }

        [HttpPost, Route(""), BasicAuthorize]
        public HttpResponseMessage PostProyecto(Proyecto proye)
        {
            Proyecto proyecto = new BusGlobal().CreateProyecto(proye);
            if (proyecto != null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, proyecto);
            }
            return Request.CreateResponse(HttpStatusCode.OK, false);
        }

        [HttpDelete, Route("")]
        public HttpResponseMessage DeleteProyecto(int idp)
        {
            int proyecto = new BusGlobal().DeleteProyecto(idp);
            if (proyecto > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, proyecto);
            }
            return Request.CreateResponse(HttpStatusCode.Conflict, false);
        }

    }

    [RoutePrefix("api/servicio")]
    public class ApiGitServicioController : ApiController
    {


        //API SERVICIO
        [Route(""), BasicAuthorize]
        public HttpResponseMessage GetServicios()
        {
            var lst = new BusGlobal().GetServicios();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route(""), BasicAuthorize]
        public HttpResponseMessage GetServicio(int idp)
        {
            var lst = new BusGlobal().GetServicios();
            Servicio serv = lst.FirstOrDefault(s => s.id_serv == idp);
            if (serv == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, serv);
        }

        [HttpPut, Route("")]
        public HttpResponseMessage PutServicio(int idp, Servicio serv)
        {
            var servicio = new BusGlobal().UpdateServicio(serv);
            if (servicio > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, servicio);
            }
            return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }

        [HttpPost, Route(""), BasicAuthorize]
        public HttpResponseMessage PostServicio(Servicio serv)
        {
            Servicio servicio = new BusGlobal().CreateServicio(serv);
            if (servicio != null)
            {
                return Request.CreateResponse(HttpStatusCode.Created, servicio);
            }
            return Request.CreateResponse(HttpStatusCode.OK, false);
        }

        [HttpDelete, Route("")]
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

    [RoutePrefix("api/blog")]
    public class ApiGitBlogController : ApiController
    {
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"\img";
        //API BLOG
        [Route(""), BasicAuthorize]
        public HttpResponseMessage GetBlogs()
        {
            var lst = new BusGlobal().GetBlogs();
            return Request.CreateResponse(HttpStatusCode.OK, lst);
        }

        [Route(""), BasicAuthorize]
        public HttpResponseMessage GetBlog(int idp)
        {
            var lst = new BusGlobal().GetBlogs();
            Blog blog = lst.FirstOrDefault(b => b.id_blog == idp);
            if (blog == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, blog);
        }

        [HttpPut, Route("")]
        public HttpResponseMessage PutBlog(int idp, Blog blog)
        {
            var blo = new BusGlobal().UpdateBlog(blog);
            if (blo > 0)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, blo);
            }
            return Request.CreateResponse(HttpStatusCode.NotModified, false);
        }

        [HttpPost, Route("new")]
        public async Task<IHttpActionResult> Add(Blog blog)
        {
            try
            {
                blog.fecha_blog = DateTime.Now;
                Blog newBlog = new BusGlobal().CreateBlog(blog);
                return Ok(new { newBlog });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        [HttpPost, Route("")]
        public async Task<HttpResponseMessage> PostBlog()
        {
            {
                // Check if the request contains multipart/form-data.
                if (!Request.Content.IsMimeMultipartContent("form-data"))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unsupported media type");
                }
                try
                {
                    var provider = new CustomMultipartFormDataStreamProvider(workingFolder);
                    //await Request.Content.ReadAsMultipartAsync(provider);
                    await Task.Run(async () => await Request.Content.ReadAsMultipartAsync(provider));

                    //                    var photos = new List<PhotoViewModel>();

                    foreach (var file in provider.FileData)
                    {
                        var fi = new FileInfo(file.LocalFileName);
                    }

                    //foreach (var item in provider.Contents)
                    //{
                    //    var atributo = item;
                    //}
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "OK" });
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
        }

        [HttpDelete, Route("")]
        public HttpResponseMessage DeleteBlog(int idp)
        {
            int blog = new BusGlobal().DeleteBlog(idp);
            if (blog > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, blog);
            }
            return Request.CreateResponse(HttpStatusCode.Conflict, false);
        }
    }
}
