﻿using System;
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
        [Route("")]
        // GET: api/GitPractice
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GitPractice/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GitPractice
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GitPractice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GitPractice/5
        public void Delete(int id)
        {
        }
    }
}
