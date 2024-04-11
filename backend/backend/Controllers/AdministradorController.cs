using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    public class AdministradorController : ControllerBase
    {
        // GET: Usuario
        [HttpGet]
        [Route("")]
        public dynamic GetAdministradores()
        {
            return Ok();
        }

        // GET: Usuario/5
        [HttpGet]
        [Route("{id}")]
        public dynamic GetAdministrador(int Id)
        {
            return Ok();
        }


        // POST: Usuario/Create
        [HttpPost]
        [Route("")]
        [ValidateAntiForgeryToken]
        public dynamic CreateUser(IFormCollection collection)
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

        // PUT: Usuario/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult EditUser(int id)
        {
            return Ok();
        }

        // DELETE: UsuarioController/5
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteUser(int id)
        {
            return Ok();
        }
    }
}
