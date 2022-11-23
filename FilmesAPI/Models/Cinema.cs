using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Nome { get; set; }

        //Precisa configurar o UseLazyLoadingProxies() no "Program.cs"
        //Usa a palavra "virtual" para retornar as informações de entidades relacionadas no momento de uma consulta.
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

    }
}
