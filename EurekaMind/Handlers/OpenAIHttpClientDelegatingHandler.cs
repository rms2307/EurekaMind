using EurekaMind.Infra;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace EurekaMind.Handlers
{
    public class OpenAIHttpClientDelegatingHandler : DelegatingHandler
    {
        private readonly IOptions<OpenAIConfigs> _openAIOptions;

        public OpenAIHttpClientDelegatingHandler(IOptions<OpenAIConfigs> openAIOptions)
        {
            _openAIOptions = openAIOptions;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _openAIOptions.Value.AuthSecret);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
