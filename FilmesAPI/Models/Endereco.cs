using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }


        //Precisa configurar o UseLazyLoadingProxies() no "Program.cs"
        //Usa a palavra "virtual" para retornar as informações de entidades relacionadas no momento de uma consulta.
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
