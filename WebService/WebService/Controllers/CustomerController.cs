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

        public IHttpActionResult Get()
        {
            return Ok(new CrudService<Customer>().GetAll());
        }

        public IHttpActionResult Delete(int id)
        {
            new CrudService<Customer>().Delete(id);
            return Ok();
        }
    }
}