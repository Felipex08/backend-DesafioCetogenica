using System.Text.Json.Serialization;

namespace DesafioCetogenica.API.DTOs
{
    public class ParamInsereDadosInstagramDTO
    {
        [JsonPropertyName("Instagram")]
        public string instagram { get; set; }
    }
}