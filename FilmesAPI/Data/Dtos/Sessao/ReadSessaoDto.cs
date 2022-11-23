using FilmesAPI.Models;

namespace FilmesAPI.Data.Dtos
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Filme Filme { get; set; }
        public Cinema Cinema { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
