using ApiSeguridad.Helpers;
using ApiSeguridad.Models;
using ApiSeguridad.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ApiSeguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryEmpleado repo;
        private HelperOAuthToken helper;

        public AuthController(RepositoryEmpleado repo,
            HelperOAuthToken helper)
        {
            this.repo = repo;
            this.helper = helper;
        }

        //NECESITAMOS UN METODO PARA VALIDAR A NUESTRO USUARIO
        //Y DEVOLVER EL TOKEN DE ACCESO
        //DICHO METODO SIEMPRE DEBE SER POST
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Login(LoginModel model)
        {
            Usuarios usuario=
                await this.repo.ExisteUsuariosAsync
                (int.Parse(model.Password), model.UserName);
            if (usuario == null)
            {
                return Unauthorized();
            }
            else
            {
                //DEBEMOS CREAR UNAS CREDENCIALES DENTRO
                //DEL TOKEN
                SigningCredentials credentials =
                    new SigningCredentials(this.helper.GetKeyToken()
                    , SecurityAlgorithms.HmacSha256);
                //EL TOKEN SE GENERA CON UNA CLASE Y DEBEMOS INDICAR
                //LOS DATOS QUE CONFORMAN DICHO TOKEN
                JwtSecurityToken token =
                    new JwtSecurityToken(
                        issuer: this.helper.Issuer,
                        audience: this.helper.Audience,
                        signingCredentials: credentials,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        notBefore: DateTime.UtcNow
                        );
                return Ok(new
                {
                    response =
                    new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
        }

    }
}
