using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortal.Entity;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.Repository
{
    /// <summary>
    /// Repository interface for querying the database from the manager's viewpoint.
    /// </summary>
    public interface IManager
    {
        // Maintenance info uses UserId since it's only possible to make a maintenance
        // request from within the application (either the tenant makes it, or a manager
        // makes it on the tenant's behalf).
        Task<bool> CloseMaintenanceRequest(int UserId,
                                           MaintenanceCloseReason reason,
                                           string resolutionNotes);
        Task<MaintenanceRequest> OpenMaintenanceRequest(int userId,
                                                        MaintenanceRequestType requestType,
                                                        string openNotes,
                                                        string unitNumber,
                                                        string internalNotes);
        Task<bool> AssignTenantToUnit(int tenantId, string unitNumber);
        Task<bool> RemoveTenantFromUnit(int tenantId);
        Task<Unit> GetUnit(string unitNumber);
        Task<IEnumerable<DataModel.Bill>> GetOverdueBills(int tenantId);
        Task<IEnumerable<DataModel.Bill>> GetOverdueBills(int tenantId, BillingPeriod period);
        Task<IEnumerable<DataModel.Bill>> GetOverdueBills(int tenantId, ResourceType resource);
        Task<IEnumerable<DataModel.Bill>> GetOverdueBills(int tenantId, ResourceType resource, BillingPeriod period);

        Task<IEnumerable<MaintenanceRequest>> GetOutstandingMaintenanceRequests();
    }
}