using MailKit.Net.Smtp;
using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        private IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
            var mensagemDeEmail = CriaCorpoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using (var client = new SmtpClient())
            {
                    try
                    {
                        var host = configuration.GetSection("EmailSettings:SmtpServer").Value;
                        string? port = configuration.GetSection("EmailSettings:Port").Value;
                        var user = configuration.GetSection("EmailSettings:From").Value;
                        var senha = configuration.GetSection("EmailSettings:Password").Value;

                        client.Connect(host,int.Parse(port), true);
                        client.AuthenticationMechanisms.Remove("XOUATH2");
                        client.Authenticate(user,senha);
                        client.Send(mensagemDeEmail);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }
            }
        }

        private MimeMessage CriaCorpoEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("",configuration.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemDeEmail;
        }
    }
}
