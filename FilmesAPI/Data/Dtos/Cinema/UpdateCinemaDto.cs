using System.ComponentModel.DataAnnotations;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateCinemaDto
    {
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
