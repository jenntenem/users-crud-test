using Microsoft.EntityFrameworkCore;
using static backend.Models.Entidades;

namespace backend.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
    }
}
