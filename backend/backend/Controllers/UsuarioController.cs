using backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static backend.Models.Entidades;
using static backend.Models.EntidadesDTO;

namespace backend.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly DBContext dbContext;

        public UsuarioController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Usuario
        [HttpGet]
        [Route("")]
        public dynamic GetAllUsers()
        {
            var users = dbContext.Usuarios.ToList();
            return Ok(users);
        }

        // GET: Usuario/5
        [HttpGet]
        [Route("{id}")]
        public dynamic GetUser(int Id)
        {
            var user = dbContext.Usuarios.FirstOrDefault(user => user.Id == Id);
            return user != null ? Ok(user) : NotFound();
        }


        // POST: Usuario/
        [HttpPost]
        [Route("")]
        [ValidateAntiForgeryToken]
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

                return CreatedAtAction(nameof(GetUser), new { id = userDomainModel.Id }, userDomainModel);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: Usuario/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult EditUser(int id, [FromBody] Usuario body)
        {
            // Convert DTO to Domain Global
            var userDomainModel = new Usuario
            {
                primerNombre = body.primerNombre ?? ,
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

                return CreatedAtAction(nameof(GetUser), new { id = userDomainModel.Id }, userDomainModel);
            }
            catch
            {
                return NotFound();
            }
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
