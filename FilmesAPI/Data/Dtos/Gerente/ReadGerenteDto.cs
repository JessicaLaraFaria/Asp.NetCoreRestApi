using System.ComponentModel.DataAnnotations;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos
{
    public class ReadGerenteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public object Cinemas { get; set; }
    }
}
