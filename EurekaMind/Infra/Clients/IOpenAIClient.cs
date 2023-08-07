using EurekaMind.Infra.OpenAI.Models;
using Refit;

namespace EurekaMind.Infra.Clients
{
    public interface IOpenAIClient
    {
        [Post("/chat/completions")]
        Task<OpenAIResponse> CompletePrompt(OpenAIRequest request);
    }
}
