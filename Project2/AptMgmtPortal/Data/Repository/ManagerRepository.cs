using AptMgmtPortal.DataModel;
using AptMgmtPortal.Entity;
using AptMgmtPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortal.Data.Repository
{
    public class ManagerRepository : IManager
    {
        public Task<bool> AssignTenantToUnit(int tenantId, string unitNumber)
        {
            throw new NotImplementedException();
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
