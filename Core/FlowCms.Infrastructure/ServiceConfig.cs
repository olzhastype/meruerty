using Microsoft.Extensions.DependencyInjection;

namespace FlowCms.Infrastructure
{
    public static class ServiceConfig
    {
        public static void AddInfrastucture(this ServiceCollection services)
        {
            services.AddTransient<ElasticSearchService>();
        }
    }
}