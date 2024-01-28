using System;
using Microsoft.Extensions.DependencyInjection;
using StatsCounter.Services;

namespace StatsCounter.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddGitHubService(
            this IServiceCollection services,
            Uri baseApiUrl)
        {
            services.AddScoped<IGitHubService, GitHubService>();
            services.AddHttpClient<IGitHubService, GitHubService>(client =>
            {
                client.BaseAddress = baseApiUrl;
                // Set up any authentication or headers if required
            });

            return services; // TODO: add your code here
        }
    }
}