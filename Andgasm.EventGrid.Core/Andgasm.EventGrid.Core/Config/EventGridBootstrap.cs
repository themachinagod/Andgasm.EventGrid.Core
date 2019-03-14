using Microsoft.Extensions.DependencyInjection;

namespace Andgasm.EventGrid.Core
{
    public static class EventGridBootstrap
    {
        public static void AddResourceEventGrid<T>(this IServiceCollection services, string endpoint, string key)
        {
            services.AddTransient(ctx => new EventGridService<T>(new EventGridSettings(endpoint, key)));
        }
    }
}
