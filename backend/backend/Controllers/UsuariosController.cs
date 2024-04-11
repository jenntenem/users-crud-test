using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : Controller
    {
        // GET: usuarios/
        [HttpGet]
        [Route("")]
        public dynamic GetAllUsers()
        {
            return View();
        }

        // GET: usuarios/7
        [HttpGet]
        [Route("{id}")]
        public dynamic GetUserById(int id)
        {
            return View();
        }

        // POST: usuarios/
        [HttpPost]
        [Route("")]
        public dynamic createUser(dynamic user)
        {
            return View();
        }

        // PUT: usuarios/
        [HttpPut]
        [Route("{id}")]
        public dynamic updateUser(int id, dynamic user)
        {
            return View();
        }

        [HttpDelete]
        [Route("{id}")]
        public dynamic deleteUser(int id)
        {
            return View();
        }
    }
}
