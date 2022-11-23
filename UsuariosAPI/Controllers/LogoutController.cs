using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController: ControllerBase
    {
        private LogoutService logoutService;

        public LogoutController(LogoutService logoutService)
        {
            this.logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario()
        {
            Result resultado = logoutService.DeslogaUsuario();
            if (resultado.IsFailed) return Unauthorized(resultado.Errors.Select(x=>x.Message));
            return Ok(resultado.Successes);
        }
    }
}
