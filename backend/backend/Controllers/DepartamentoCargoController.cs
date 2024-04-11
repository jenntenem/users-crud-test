using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("departamento")]
    public class DepartamentoController : AdministradorController
    {
    }

    [ApiController]
    [Route("cargo")]
    public class CargoController : AdministradorController
    {
    }
}
