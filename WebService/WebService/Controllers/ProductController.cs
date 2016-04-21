using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Domain;
using Service;

namespace WebService.Controllers
{
    public class ProductController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            return Ok(new CrudService<Product>().Get(id));
        }

        public IHttpActionResult Get()
        {
            return Ok(new CrudService<Product>().GetAll());
        }
    }
}