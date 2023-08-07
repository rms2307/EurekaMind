using EurekaMind.Infra.Clients;
using EurekaMind.Infra.OpenAI.Models;
using EurekaMind.Infra.Services.Interfaces;

namespace EurekaMind.Infra.Services
{
    public class OpenAITextService : IOpenAITextService
    {
        private readonly IOpenAIClient _openAIClient;

        public OpenAITextService(IOpenAIClient openAIClient)
        {
            _openAIClient = openAIClient;
        }

        public async Task<OpenAIResponse> CompletePrompt(OpenAIRequest request)
        {
            try
            {
                return await _openAIClient.CompletePrompt(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
