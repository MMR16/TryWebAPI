using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class testController : ApiController
    {
        public IHttpActionResult Get()
        {
            HttpResponseMessage msg = new HttpResponseMessage(HttpStatusCode.NotFound) 
            { 
             ReasonPhrase="Employee Not Found",Content=new StringContent("error ,employee not found !!!!!")
            };
            throw new HttpResponseException(msg);
        }
    }
}
