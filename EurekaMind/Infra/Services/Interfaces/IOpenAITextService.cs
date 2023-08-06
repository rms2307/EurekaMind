using EurekaMind.Infra.OpenAI.Models;

namespace EurekaMind.Infra.Services.Interfaces
{
    public interface IOpenAITextService
    {
        Task<OpenAIResponse> CompletePrompt(OpenAIRequest request);
    }
}
