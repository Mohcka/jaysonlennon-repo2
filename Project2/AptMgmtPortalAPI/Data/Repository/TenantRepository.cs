using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Repository
{
    public class TenantRepository : ITenant
    {
        private readonly AptMgmtDbContext _context;

        public TenantRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        public async Task<DTO.TenantInfoDTO> AddTenant(DTO.TenantInfoDTO info)
        {
            var emailAlreadyExists = await _context.Tenants
                .Where(t => t.Email.ToLower() == info.Email.ToLower())
                .CountAsync() > 0;

            if (emailAlreadyExists) return null;

            if (info == null) return null;

            var tenant = new Tenant();
            tenant.FirstName = info.FirstName;
            tenant.LastName = info.LastName;
            tenant.Email = info.Email;
            tenant.PhoneNumber = info.PhoneNumber;

            _context.Add(tenant);
            await _context.SaveChangesAsync();

            await AssignToUnit(tenant.TenantId, info.UnitNumber);

            await _context.SaveChangesAsync();
            return new DTO.TenantInfoDTO(tenant, info.UnitNumber);
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

        public async Task<Unit> UnitFromTenantId(int tenantId)
        {
            return await _context.Units
                .Where(u => u.TenantId == tenantId)
                .Select(u => u)
                .FirstOrDefaultAsync();
        }

        public async Task<DTO.TenantInfoDTO> UpdateTenantInfo(int tenantId, DTO.TenantInfoDTO newInfo)
        {
            var emailAlreadyExists = await _context.Tenants
                .Where(t => t.Email.ToLower() == newInfo.Email.ToLower())
                .Where(t => t.TenantId != tenantId)
                .CountAsync() > 0;

            if (emailAlreadyExists) return null;

            var tenant = await TenantFromId(tenantId);

            if (tenant == null) return await AddTenant(newInfo);

            tenant.FirstName = newInfo.FirstName;
            tenant.LastName = newInfo.LastName;
            tenant.Email = newInfo.Email;
            tenant.PhoneNumber = newInfo.PhoneNumber;

            var unit = await AssignToUnit(tenantId, newInfo.UnitNumber);

            await _context.SaveChangesAsync();

            if (unit == null)
            {
                return new DTO.TenantInfoDTO(tenant, null);
            }
            else
            {
                return new DTO.TenantInfoDTO(tenant, unit.UnitNumber);
            }
        }

        public async Task<IEnumerable<Tenant>> GetTenants()
        {
            return await _context.Tenants
                .Select(t => t)
                .ToListAsync();
        }

        public async Task<Unit> AssignToUnit(int tenantId, string unitNumber)
        {
            Unit unit;
            if (String.IsNullOrEmpty(unitNumber))
            {
                unit = await _context.Units
                    .Where(u => u.TenantId == tenantId)
                    .Select(u => u)
                    .FirstOrDefaultAsync();

                if (unit == null) return null;

                unit.TenantId = null;
            }
            else
            {
                unit = await _context.Units
                    .Where(u => u.UnitNumber.ToLower() == unitNumber.ToLower())
                    .Select(u => u)
                    .FirstOrDefaultAsync();

                if (unit == null) return null;

                unit.TenantId = tenantId;
            }

            await _context.SaveChangesAsync();

            return unit;
        }

        public async Task<Unit> GetUnit(int unitId)
        {
            return await _context.Units
                .Where(u => u.UnitId == unitId)
                .Select(u => u)
                .FirstOrDefaultAsync();
        }

        public async Task<Unit> QueryUnitByNumber(string unitNumber)
        {
            return await _context.Units
                .Where(u => u.UnitNumber.ToLower() == unitNumber.ToLower())
                .Select(u => u)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Unit>> GetUnits()
        {
            return await _context.Units.Select(u => u).ToListAsync();
        }

        public async Task<Unit> UpdateUnit(Unit unit)
        {
            var existingUnit = await _context.Units
                .Where(u => u.UnitId == unit.UnitId)
                .Select(u => u)
                .FirstOrDefaultAsync();

            if (existingUnit == null)
            {
                await _context.AddAsync(unit);
            }
            else
            {
                existingUnit.UnitNumber = unit.UnitNumber;
                existingUnit.TenantId = unit.TenantId;
            }

            await _context.SaveChangesAsync();

            return unit;
        }

        public async Task<bool> DeleteUnit(int unitId)
        {
            // We need to query the unit from the database before deleting it.
            var unit = await _context.Units.Where(u => u.UnitId == unitId).FirstOrDefaultAsync();

            // If we can't find it, then return false since we didn't delete anything.
            if (unit == null) return false;

            // Schedule unit for deletion.
            _context.Remove(unit);

            // If something goes wrong, this will return false so the caller will
            // know to retry the request.
            return await _context.SaveChangesAsync() > 0;
        }
    }
}