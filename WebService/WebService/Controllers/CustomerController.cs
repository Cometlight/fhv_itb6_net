using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Domain;
using Service;

namespace WebService.Controllers
{
    public class CustomerController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            return Ok(new CrudService<Customer>().Get(id));
        }
    }
}