using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("departamentos")]
    public class DepartamentosController : Controller
    {
        [HttpGet]
        [Route("")]
        public dynamic Index()
        {
            return Ok();
        }
    }
}
