using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Repository
{
    /// <summary>
    /// Repository interface for querying the database from the tenant's viewpoint.
    /// </summary>
    public interface ITenant
    {
        Task<IEnumerable<Tenant>> FindTenantWithFirstName(string firstName);
        Task<Tenant> AddTenant(TenantInfo info);
        Task<Tenant> TenantFromId(int tenantId);
        Task<Tenant> TenantFromUserId(int userId);
        Task<int?> TenantIdFromUserId(int userId);

        Task<bool> EditPersonalInfo(int tenantId, TenantInfo info);

        Task<string> GetUnitNumber(int tenantId);

        Task<Tenant> UpdateTenantInfo(int tenantId, DTO.TenantInfoDTO newInfo);
    }
}