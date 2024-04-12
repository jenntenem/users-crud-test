using backend.Data;
using Microsoft.AspNetCore.Mvc;
using static backend.Models.Entidades;

namespace backend.Controllers
{
    [ApiController]
    [Route("departamentos")]
    public class DepartamentosController : Controller
    {
        private readonly DBContext dbContext;

        public DepartamentosController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: departamentos/
        [HttpGet]
        [Route("")]
        public dynamic GetAllDepartments()
        {
            var dept = dbContext.Departamentos != null ? dbContext.Departamentos.ToList() : [];
            return Ok(dept);
        }

        // GET: departamentos/5
        [HttpGet]
        [Route("{id}")]
        public dynamic GetDepartmentById([FromRoute] int id)
        {
            var dept = dbContext.Departamentos.FirstOrDefault(dept => dept.Id == id);
            return dept != null ? Ok(dept) : NotFound();
        }

        // POST: departamentos/
        [HttpPost]
        [Route("")]
        public dynamic CreateDepartment([FromBody] Departamento body)
        {
            // Convert DTO to Domain Global
            var deptDomainModel = new Departamento
            {
                codigo = body.codigo,
                nombre = body.nombre,
                idUsuarioCreacion = body.idUsuarioCreacion,
            };

            try
            {
                // Use Domain Model to create Department
                dbContext.Departamentos.Add(deptDomainModel);
                dbContext.SaveChanges();

                return CreatedAtAction(nameof(GetDepartmentById), new { id = deptDomainModel.Id }, deptDomainModel);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: departamentos/5
        [HttpPut]
        [Route("{id}")]
        public ActionResult EditDepartment([FromRoute] int id, [FromBody] Departamento body)
        {
            try
            {
                var dept = dbContext.Departamentos.Find(id);

                // Use Domain Model to update Department
                dept.codigo = body.codigo;
                dept.nombre = body.nombre;
                dept.activo = body.activo;
                //dept.idUsuarioCreacion = body.idUsuarioCreacion; // The idUsuarioCreacion shouldn't be modifiable

                dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetDepartmentById), new { id = id }, dept);
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: departamentos/5
        [HttpDelete]
        [Route("{id}")]
        public dynamic DeleteDepartment([FromRoute] int id)
        {
            try
            {
                var dept = dbContext.Departamentos.Find(id);
                dept.activo = false;
                dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetDepartmentById), new { id = id }, dept);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
