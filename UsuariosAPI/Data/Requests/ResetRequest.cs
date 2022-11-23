using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class ResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
