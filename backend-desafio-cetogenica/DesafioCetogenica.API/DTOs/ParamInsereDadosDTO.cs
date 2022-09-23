using System.Text.Json.Serialization;

namespace DesafioCetogenica.API.DTOs
{
    public class ParamInsereDadosDTO
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("telefone")]
        public string Telefone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}