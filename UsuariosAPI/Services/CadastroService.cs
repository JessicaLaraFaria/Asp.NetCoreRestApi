using System.Web;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class CadastroService
    {
        private UserManager<CustomIdentityUser> userManager;
        private IMapper mapper;
        private EmailService emailService;

        public CadastroService(UserManager<CustomIdentityUser> userManager, IMapper mapper, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.emailService = emailService;
        }

        public Result CadastroUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = mapper.Map<Usuario>(createDto);
            CustomIdentityUser usuarioIdentity = mapper.Map<CustomIdentityUser>(usuario);
            var resultadoIdentity = userManager.CreateAsync(usuarioIdentity, createDto.Password).Result;
            userManager.AddToRoleAsync(usuarioIdentity, "regular");

            if (resultadoIdentity.Succeeded)
            {
                var code = userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);

                emailService.EnviarEmail(new[] {usuarioIdentity.Email}, "Link de Ativação", usuarioIdentity.Id, encodedCode);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao Cadastrar Usuário.");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = userManager.Users.FirstOrDefault(u => u.Id == request.UsuarioId);
            var identityResult = userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao).Result;
            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de Usuário.");
        }
    }
}
