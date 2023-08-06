using System.Text.Json.Serialization;

namespace EurekaMind.Infra.OpenAI.Models
{
    public class OpenAIRequest
    {
        public OpenAIRequest(string question)
        {
            Model = "text-davinci-003";
            Prompt = question;
            Temperature = 0f;
            MaxTokens = 500;
        }

        [JsonPropertyName("model")]
        public string Model { get; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("temperature")]
        public float Temperature { get; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; }
    }
}
