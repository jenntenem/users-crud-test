using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("cargos")]
    public class CargosController : ControllerBase
    {
        // GET: cargos
        [HttpGet]
        [Route("")]
        public dynamic GetCargos()
        {
            return Ok();
        }

    }
}
