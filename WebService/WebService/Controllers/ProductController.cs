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

        public IHttpActionResult Delete(int id)
        {
            new CrudService<Product>().Delete(id);
            return Ok();
        }
    }
}