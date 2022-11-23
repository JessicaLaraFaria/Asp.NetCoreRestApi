using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService cadastroService;
        public CadastroController(CadastroService cadastroService)
        {
                this.cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastroUsuario(CreateUsuarioDto usuarioDto)
        {
            Result resultado = cadastroService.CadastroUsuario(usuarioDto);
            if (resultado.IsFailed) return StatusCode(500, resultado.Errors.Select(x => x.Message));
            return Ok(resultado.Successes.FirstOrDefault());
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery] AtivaContaRequest request)
        {
            Result resultado = cadastroService.AtivaContaUsuario(request);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes.FirstOrDefault());
        }
    }
}
