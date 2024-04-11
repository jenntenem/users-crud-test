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

        // GET: cargos/5
        [HttpGet]
        [Route("{id}")]
        public dynamic getCargoById(int Id)
        {
            return Ok();
        }

        // POST: cargos/
        [HttpPost]
        [Route("")]
        [ValidateAntiForgeryToken]
        public dynamic CreateCargo(IFormCollection collection)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: cargos/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult EditCargos(int id)
        {
            return Ok();
        }

        // DELETE: UsuarioController/5
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCargos(int id)
        {
            return Ok();
        }

    }
}
