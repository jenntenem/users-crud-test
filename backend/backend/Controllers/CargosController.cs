using backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static backend.Models.Entidades;

namespace backend.Controllers
{
    [ApiController]
    [Route("cargos")]
    public class CargosController : ControllerBase
    {
        private readonly DBContext dbContext;

        public CargosController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: cargos/
        [HttpGet]
        [Route("")]
        public dynamic GetAllWorkStations()
        {
            var wstn = dbContext.Cargos != null ? dbContext.Cargos.ToList() : [];
            return Ok(wstn);
        }
        
        // GET: cargos/5
        [HttpGet]
        [Route("{id}")]
        public dynamic GetWorkStationById([FromRoute] int id)
        {
            var wstn = dbContext.Cargos.FirstOrDefault(wstn => wstn.Id == id);
            return wstn != null ? Ok(wstn) : NotFound();
        }

        // POST: cargos/
        [HttpPost]
        [Route("")]
        public dynamic CreateDepartment([FromBody] Cargo body)
        {
            // Convert DTO to Domain Global
            var wstnDomainModel = new Cargo
            {
                codigo = body.codigo,
                nombre = body.nombre,
                idUsuarioCreacion = body.idUsuarioCreacion,
            };

            try
            {
                // Use Domain Model to create Department
                dbContext.Cargos.Add(wstnDomainModel);
                dbContext.SaveChanges();

                return CreatedAtAction(nameof(GetWorkStationById), new { id = wstnDomainModel.Id }, wstnDomainModel);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: cargos/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult EditDepartment([FromRoute] int id, [FromBody] Cargo body)
        {
            try
            {
                var wstn = dbContext.Cargos.Find(id);

                // Use Domain Model to update Department
                wstn.codigo = body.codigo;
                wstn.nombre = body.nombre;
                wstn.activo = body.activo;
                //wstn.idUsuarioCreacion = body.idUsuarioCreacion; // The idUsuarioCreacion shouldn't be modifiable

                dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetWorkStationById), new { id = id }, wstn);
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: cargos/5
        [HttpDelete]
        [Route("{id}")]
        public dynamic DeleteDepartment([FromRoute] int id)
        {
            try
            {
                var wstn = dbContext.Cargos.Find(id);
                wstn.activo = false;
                dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetWorkStationById), new { id = id }, wstn);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
