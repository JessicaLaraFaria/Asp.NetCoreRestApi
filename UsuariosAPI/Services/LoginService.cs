using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> signInManager;
        private TokenService tokenService;
        public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
        {
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public Result LoginUsuario(LoginRequest request)
        {
            var resultadoIdentity = signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var CustomIdentityUser = signInManager.UserManager.Users
                    .FirstOrDefault(u => u.NormalizedUserName == request.UserName.ToUpper());
                Token token = tokenService
                    .CreateToken(CustomIdentityUser, signInManager.UserManager.GetRolesAsync(CustomIdentityUser)
                    .Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Falha no Login.");
        }

        public Result SolicitaReset(ResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            if(identityUser != null)
            {
                string codigoRecuperacao = signInManager.UserManager
                    .GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(codigoRecuperacao);
            }
            return Result.Fail("Falha ao Solicitar Redefinição da Senha");
        }

        public Result ResetSenha(EfetuaResetRequest request)
        {
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);
            IdentityResult resultadoIdentity = signInManager.UserManager
                .ResetPasswordAsync(identityUser, request.Token, request.Password)
                .Result;
           
            if (resultadoIdentity.Succeeded) return Result.Ok()
                    .WithSuccess("Senha Redefinida com Sucesso");
            return Result.Fail("Houve um Erro na Redefinição da Senha");
        }

        private CustomIdentityUser RecuperaUsuarioPorEmail(string email)
        {
            return signInManager.UserManager.Users
                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
