using PiscOn.Api.Classes.Repositories;

namespace PiscOn.Api.Classes.DI
{
    public static class ConfigRepositoriesExtesion
    {
        public static void RepositoriesDI(this IServiceCollection services)
        {
            services.AddScoped<ContatoRepository>();
        }
    }
}
