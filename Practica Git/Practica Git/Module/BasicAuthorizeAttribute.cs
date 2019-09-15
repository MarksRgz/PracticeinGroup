using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

namespace Practica_Git.Module
{
    public class BasicAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var encabezados = actionContext.Request.Headers;
            string credenciales;
            string decodecredenciales;
            string[] credencialesarray;
            if (encabezados.Authorization != null)
            {
                credenciales = encabezados.Authorization.Parameter;
                decodecredenciales = Encoding.UTF8.GetString(Convert.FromBase64String(credenciales));
                credencialesarray = decodecredenciales.Split(':');
            }
            else
            {
                credencialesarray = new String[2] { "Hola", "mundo" };
            }
            if (!EsUsuarioValido(credencialesarray))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Es necesario enviar credenciales validas");
            }
            base.OnAuthorization(actionContext);
        }

        private bool EsUsuarioValido(string[] credenciales)
        {
            if ((credenciales[0] == "Subnet" && credenciales[1] == "6789"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}