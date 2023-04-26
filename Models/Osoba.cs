using System.Text.Json.Serialization;

namespace MessageAPI.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? EmailId{ get; set; }

        [JsonIgnore]
        public Email? Email{ get; set; }
    }
}
