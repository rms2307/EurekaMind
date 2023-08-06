namespace EurekaMind.Infra.OpenAI.Models
{
    public class OpenAIError
    {
        public string Message { get; set; }
        public string Type { get; set; }
        public object Param { get; set; }
        public object code { get; set; }
    }
}