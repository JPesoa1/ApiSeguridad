using ApiSeguridad.Data;
using ApiSeguridad.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSeguridad.Repositories
{
    public class RepositoryEmpleado
    {
        private EmpleadosContext context;

        public RepositoryEmpleado(EmpleadosContext context)
        {
            this.context = context;
        }

        public async Task<Usuarios> ExisteUsuariosAsync(int idusuario, string nombre)
        {
            return await this.context.Usuarios.
                FirstOrDefaultAsync(x => x.Id == idusuario && x.nombre == nombre);
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
            => await this.context.Empleados.ToListAsync();

    }
}
