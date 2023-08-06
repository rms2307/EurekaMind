using EurekaMind.Handlers;
using EurekaMind.Infra.Clients;
using EurekaMind.Infra.Services.Interfaces;
using EurekaMind.Infra.Services;
using Refit;
using EurekaMind.Infra;

namespace EurekaMind.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOpenAITextService, OpenAITextService>();
        }

        public static void AddConfigs(this IServiceCollection services, IConfiguration configuration)
        {
           services.Configure<OpenAIConfigs>(configuration.GetSection("OpenAIConfigs"));
        }

        public static void AddClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<OpenAIHttpClientDelegatingHandler>();
            services.AddHttpClient("OpenAI", c =>
            {
                c.BaseAddress = new Uri(configuration["OpenAIConfigs:BaseAddress"]);
            }).AddTypedClient(c => RestService.For<IOpenAIClient>(c))
                .AddHttpMessageHandler<OpenAIHttpClientDelegatingHandler>();
        }
    }
}
