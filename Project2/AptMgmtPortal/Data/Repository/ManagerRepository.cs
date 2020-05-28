using AptMgmtPortal.DataModel;
using AptMgmtPortal.Entity;
using AptMgmtPortal.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AptMgmtPortal.Data;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.Repository
{
    public class ManagerRepository : IManager
    {
        private readonly AptMgmtDbContext _context;

        public ManagerRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        
        public async Task<Unit> GetUnit(string unitNumber)
        {
            return await _context.Units
                                 .Where(u => u.UnitNumber == unitNumber)
                                 .Select(u => u)
                                 .FirstOrDefaultAsync();
        }

        public async Task<bool> AssignTenantToUnit(int tenantId, string unitNumber)
        {
            var unit = await GetUnit(unitNumber);

            if (unit.TenantId != null) return false;

            unit.TenantId = tenantId;

            return await _context.SaveChangesAsync() > 0;

        }

        public Task<bool> CloseMaintenanceRequest(int UserId, MaintenanceCloseReason reason, string resolutionNotes)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MaintenanceRequest>> GetOutstandingMaintenanceRequests()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bill>> GetOverdueBills(int tenantId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bill>> GetOverdueBills(int tenantId, BillingPeriod period)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bill>> GetOverdueBills(int tenantId, ResourceType resource)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bill>> GetOverdueBills(int tenantId, ResourceType resource, BillingPeriod period)
        {
            throw new NotImplementedException();
        }


        public Task<MaintenanceRequest> OpenMaintenanceRequest(int userId, MaintenanceRequestType requestType, string openNotes, string unitNumber, string internalNotes)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTenantFromUnit(int tenantId)
        {
            throw new NotImplementedException();
        }
    }
}
