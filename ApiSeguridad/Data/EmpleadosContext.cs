using ApiSeguridad.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSeguridad.Data
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
