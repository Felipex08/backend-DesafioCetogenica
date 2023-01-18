using System.Text.Json.Serialization;

namespace DesafioCetogenica.API.DTOs
{
    public class ParamInsereDadosInstagramDTO
    {
        [JsonPropertyName("instagram")]
        public string Instagram { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }
    }
}