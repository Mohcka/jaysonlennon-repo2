using AptMgmtPortalAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Repository
{
    public interface IMaintenance
    {
        Task<MaintenanceRequest> CancelMaintenanceRequest(int userWhoCanceled,
                                            int maintenanceRequestId,
                                            string resolutionNotes);
        Task<MaintenanceRequest> OpenMaintenanceRequest(int userId,
                                                        DataModel.MaintenanceRequestModel data);
        Task<IEnumerable<MaintenanceRequest>> GetOpenMaintenanceRequests(string unitNumber);
        Task<IEnumerable<MaintenanceRequest>> GetMaintenanceRequests(string unitNumber);
        Task<IEnumerable<MaintenanceRequest>> GetMaintenanceRequests();
        Task<MaintenanceRequest> GetMaintenanceRequest(int requestId);
        Task<MaintenanceRequest> UpdateMaintenanceRequest(MaintenanceRequest original,
                                                          DataModel.MaintenanceRequestModel updated,
                                                          int userId);
    }
}