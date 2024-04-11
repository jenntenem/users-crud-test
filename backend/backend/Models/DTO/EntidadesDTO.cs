namespace backend.Models
{
    public class EntidadesDTO
    {
        public class UsuarioDto
        {
            public string usuario { get; set; }
            public string primerNombre { get; set; }
            public string segundoNombre { get; set; }
            public string primerApellido { get; set; }
            public string segundoApellido { get; set; }
            public int idDepartamento { get; set; }
            public int idCargo { get; set; }
        }

        public class AdministradorDto
        {
            public string codigo { get; set; }
            public string nombre { get; set; }
            public Boolean activo { get; set; }
            public string idUsuarioCreacion { get; set; }
        }

        public class DepartamentoDto: AdministradorDto { }
        public class CargoDto : AdministradorDto { }
    }
}

