using backend.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static backend.Models.Entidades;

namespace backend.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly DBContext dbContext;

        public UsuariosController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: usuarios/
        [HttpGet]
        [Route("")]
        public dynamic GetAllUsers()
        {
            var users = dbContext.Usuarios != null? dbContext.Usuarios.ToList() : [];
            return Ok(users);
        }

        // GET: usuarios/5
        [HttpGet]
        [Route("{id}")]
        public dynamic GetUserById(int Id)
        {
            var user = dbContext.Usuarios.FirstOrDefault(user => user.Id == Id);
            return user != null ? Ok(user) : NotFound();
        }

        // POST: usuarios/
        [HttpPost]
        [Route("")]
        public dynamic CreateUser([FromBody] Usuario body)
        {
            // Convert DTO to Domain Global
            var userDomainModel = new Usuario
            {
                primerNombre = body.primerNombre,
                segundoNombre = body.segundoNombre,
                primerApellido = body.primerApellido,
                segundoApellido = body.segundoApellido,
                idDepartamento = body.idDepartamento,
                idCargo = body.idCargo,
            };

            try
            {
                // Use Domain Model to create User
                dbContext.Usuarios.Add(userDomainModel);
                dbContext.SaveChanges();

                return CreatedAtAction(nameof(GetUserById), new { id = userDomainModel.Id }, userDomainModel);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: usuarios/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult EditUser([FromRoute] int id, [FromBody] Usuario body)
        {
            try
            {
                var user = dbContext.Usuarios.Find(id);

                // Use Domain Model to update User
                user.usuario = body.usuario ?? user.usuario;
                user.primerNombre = body.primerNombre ?? user.primerNombre;
                user.segundoNombre = body.segundoNombre ?? user.segundoNombre;
                user.primerApellido = body.primerApellido ?? user.primerApellido;
                user.segundoApellido = body.segundoApellido ?? user.segundoApellido;
                user.idDepartamento = body.idDepartamento != 0 ? body.idDepartamento : user.idDepartamento;
                user.idCargo = body.idCargo != 0 ? body.idCargo : user.idCargo;

                dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetUserById), new { id = id }, user);
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: usuarios/5
        [HttpDelete]
        [Route("{id}")]
        public dynamic DeleteUser([FromRoute] int id)
        {
            try
            {
                var user = dbContext.Usuarios.Find(id);
                user.activo = false;
                dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetUserById), new { id = id }, user);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
