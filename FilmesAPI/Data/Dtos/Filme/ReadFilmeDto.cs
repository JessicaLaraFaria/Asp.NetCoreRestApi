using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Diretor é obrigatório.")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Gênero deve conter até 30 caracteres.")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "Duração deve ser mínino 1 e máximo de 600.")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
