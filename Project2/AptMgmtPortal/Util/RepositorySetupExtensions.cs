using Microsoft.Extensions.DependencyInjection;

namespace AptMgmtPortal.Util
{
    public static class RepositorySetupExtensions
    {
        public static void SetupRepositories(this IServiceCollection services)
        {
            services.AddScoped<Repository.ITenant, Repository.TenantRepository>();
            services.AddScoped<Repository.IManager, Repository.ManagerRepository>();
            services.AddScoped<Repository.IMisc, Repository.MiscRepository>();
            services.AddScoped<Repository.IUser, Repository.UserRepository>();
        }
    }
}