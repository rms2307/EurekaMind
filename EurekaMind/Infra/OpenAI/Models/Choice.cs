namespace EurekaMind.Infra.OpenAI.Models
{
    public class Choice
    {
        public string Text { get; set; }
        public int Index { get; set; }
        public object Logprobs { get; set; }
        public string FinishReason { get; set; }
    }
}