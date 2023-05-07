using ApiSeguridad.Models;
using ApiSeguridad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSeguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private RepositoryEmpleado repo;

        public EmpleadosController(RepositoryEmpleado repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Empleado>>> GetEmpleados()
        {
            return await this.repo.GetEmpleadosAsync();
        }
    }
}
