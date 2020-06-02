using Microsoft.Extensions.DependencyInjection;

namespace AptMgmtPortalAPI.Util
{
    public static class RepositorySetupExtensions
    {
        public static void SetupRepositories(this IServiceCollection services)
        {
            services.AddScoped<Repository.ITenant, Repository.TenantRepository>();
            services.AddScoped<Repository.IManager, Repository.ManagerRepository>();
            services.AddScoped<Repository.IMisc, Repository.MiscRepository>();
            services.AddScoped<Repository.IUser, Repository.UserRepository>();
            services.AddScoped<Repository.IAgreement, Repository.AgreementRepository>();
            services.AddScoped<Repository.IMaintenance, Repository.MaintenanceRepository>();
        }
    }
}