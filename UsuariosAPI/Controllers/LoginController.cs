using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService loginService;
        public LoginController(LoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public IActionResult LoginUsuario(LoginRequest request)
        {
            Result resultado = loginService.LoginUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors.Select(x => x.Message));
            return Ok(resultado.Successes.FirstOrDefault());
        }

        [HttpPost("/solicita-reset")]
        public IActionResult ResetSenha(ResetRequest request)
        {
            Result resultado = loginService.SolicitaReset(request);

            if(resultado.IsFailed) return Unauthorized(resultado.Errors.Select(x => x.Message));
            return Ok(resultado.Successes.FirstOrDefault());
        }

        [HttpPost("/reset-senha")]
        public IActionResult ResetSenha(EfetuaResetRequest request)
        {
            Result resultado = loginService.ResetSenha(request);

            if (resultado.IsFailed) return Unauthorized(resultado.Errors.Select(x => x.Message));
            return Ok(resultado.Successes.FirstOrDefault());
        }


    }
}
