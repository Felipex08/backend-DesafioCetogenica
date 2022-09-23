using System.Text.Json.Serialization;

namespace DesafioCetogenica.API
{
    public class StatusResult
    {
        [JsonPropertyName("sucesso")]
        public bool Sucesso { get; set; } = true;

        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }
        
        [JsonPropertyName("erros")]
        public List<string> Erros { get; set; }
    }
}