namespace backend.Models
{
    public class Entidades
    {
        public class Usuario
        {
            public int Id { get; set; }
            public string usuario { get; set; }
            public string primerNombre { get; set; }
            public string? segundoNombre { get; set; }
            public string primerApellido { get; set; }
            public string? segundoApellido { get; set; }
            public int idDepartamento { get; set; }
            public int idCargo { get; set; }
            public Boolean activo {  get; set; }  = true;

        }

        public class Administracion
        {
            public int Id { get; set; }
            public string codigo { get; set; }
            public string nombre { get; set; }
            public Boolean activo { get; set; } = true;
            public int idUsuarioCreacion { get; set; }

        }

        public class Departamento: Administracion { }
        public class Cargo : Administracion { }
    }
}

