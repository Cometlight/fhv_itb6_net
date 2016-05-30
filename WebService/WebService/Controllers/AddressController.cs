using System.Web.Http;
using Domain;
using Service;

namespace WebService.Controllers
{
    public class AddressController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            return Ok(new CrudService<Address>().Get(id));
        }

        public IHttpActionResult Get()
        {
            return Ok(new CrudService<Address>().GetAll());
        }

        public IHttpActionResult Delete(int id)
        {
            new CrudService<Address>().Delete(id);
            return Ok();
        }
    }
}