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
        Task<DTO.TenantInfoDTO> AddTenant(DTO.TenantInfoDTO info);
        Task<Tenant> TenantFromId(int tenantId);
        Task<Tenant> TenantFromUserId(int userId);
        Task<int?> TenantIdFromUserId(int userId);

        Task<Unit> UnitFromTenantId(int tenantId);
        Task<Unit> AssignToUnit(int tenantId, string unitNumber);
        Task<Unit> GetUnit(int unitId);
        
        Task<Unit> QueryUnitByNumber(string unitNumber);
        Task<IEnumerable<Unit>> GetUnits();
        Task<Unit> UpdateUnit(Unit unit);
        Task<int> DeleteUnit(int unitId);
        Task<DTO.TenantInfoDTO> UpdateTenantInfo(int tenantId, DTO.TenantInfoDTO newInfo);

        Task<IEnumerable<Tenant>> GetTenants();
    }
}