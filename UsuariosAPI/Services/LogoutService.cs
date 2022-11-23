using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public Result DeslogaUsuario()
        {
            var resultadoIdentity = signInManager.SignOutAsync();
            if (resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Falha no Logout.");
        }
    }
}
