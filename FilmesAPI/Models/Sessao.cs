using System.ComponentModel.DataAnnotations;
using Castle.Components.DictionaryAdapter;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
