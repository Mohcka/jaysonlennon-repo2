using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.DataModel;

namespace AptMgmtPortalAPI.Repository
{
    public class TenantRepository : ITenant
    {
        private readonly AptMgmtDbContext _context;

        public TenantRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        public async Task<Tenant> AddTenant(Types.TenantInfo info)
        {
            if (info == null) return null;

            var tenant = new Tenant();
            tenant.FirstName = info.FirstName;
            tenant.LastName = info.LastName;
            tenant.Email = info.Email;
            tenant.PhoneNumber = info.PhoneNumber;
            tenant.UserId = info.UserId;

            _context.Add(tenant);
            await _context.SaveChangesAsync();
            return tenant;
        }


        public async Task<bool> EditPersonalInfo(int tenantId, Types.TenantInfo info)
        {
            if (info == null) return false;

            var tenant = await TenantFromId(tenantId);
            tenant.FirstName = info.FirstName;
            tenant.LastName = info.LastName;
            tenant.Email = info.Email;
            tenant.PhoneNumber = info.PhoneNumber;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Tenant> TenantFromId(int tenantId)
        {
            return await _context.Tenants
                                 .Where(t => t.TenantId == tenantId)
                                 .Select(t => t)
                                 .FirstOrDefaultAsync();
        }

        public async Task<Tenant> TenantFromUserId(int userId)
        {
            return await _context.Tenants
                                 .Where(t => t.UserId == userId)
                                 .Select(t => t)
                                 .FirstOrDefaultAsync();
        }

        public async Task<int?> TenantIdFromUserId(int userId)
        {
            return await _context.Tenants
                                 .Where(t => t.UserId == userId)
                                 .Select(t => t.TenantId)
                                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tenant>> FindTenantWithFirstName(string firstName)
        {
            if (String.IsNullOrEmpty(firstName)) return new List<Tenant>();

            firstName = firstName.ToLower();
            return await _context.Tenants
                        .Where(t => t.FirstName.ToLower().Contains(firstName))
                        .Select(t => t)
                        .ToListAsync();
        }

        public async Task<string> GetUnitNumber(int tenantId)
        {
            return await _context.Units
                .Where(u => u.TenantId == tenantId)
                .Select(u => u.UnitNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<Tenant> UpdateTenantInfo(int tenantId, DTO.TenantInfoDTO newInfo)
        {
            var tenant = await TenantFromId(tenantId);

            if (tenant == null) return null;

            tenant.FirstName = newInfo.FirstName;
            tenant.LastName = newInfo.LastName;
            tenant.Email = newInfo.Email;
            tenant.PhoneNumber = newInfo.PhoneNumber;

            await _context.SaveChangesAsync();

            return tenant;
        }
    }
}