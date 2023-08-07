using System.Text.Json.Serialization;

namespace EurekaMind.Infra.OpenAI.Models
{
    public class OpenAIRequest
    {
        public OpenAIRequest(List<Message> messages)
        {
            Model = "gpt-3.5-turbo";
            Messages = messages;
            Temperature = 0f;
            MaxTokens = 100;
        }

        [JsonPropertyName("model")]
        public string Model { get; }

        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }

        [JsonPropertyName("temperature")]
        public float Temperature { get; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; }
    }
}
