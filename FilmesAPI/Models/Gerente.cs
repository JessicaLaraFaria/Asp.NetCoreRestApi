using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Castle.Components.DictionaryAdapter;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace FilmesAPI.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
       public virtual List<Cinema> Cinemas { get; set; }

    }
}
