using Microsoft.Extensions.Hosting;

using ShopifyConsole;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConsoleServiceCollectionExtensions
    {
        public static void ConfigureServices(HostBuilderContext hostBuilder, IServiceCollection services)
        {
            services.AddScoped<IMain, Main>();

            services.AddShopifyClient((o, s) => { o.ApiKey = string.Empty; });
        }
    }
}
