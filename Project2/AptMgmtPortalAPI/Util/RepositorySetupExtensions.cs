using Microsoft.Extensions.DependencyInjection;

namespace AptMgmtPortalAPI.Util
{
    public static class RepositorySetupExtensions
    {
        public static void SetupRepositories(this IServiceCollection services)
        {
            services.AddScoped<Repository.ITenant, Repository.TenantRepository>();
            services.AddScoped<Repository.IBill, Repository.BillRepository>();
            services.AddScoped<Repository.IUser, Repository.UserRepository>();
            services.AddScoped<Repository.IAgreement, Repository.AgreementRepository>();
            services.AddScoped<Repository.IAgreementTemplate, Repository.AgreementTemplateRepository>();
            services.AddScoped<Repository.IMaintenance, Repository.MaintenanceRepository>();
        }
    }
}