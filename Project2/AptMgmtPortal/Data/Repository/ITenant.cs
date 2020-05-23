using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortal.Entity;

namespace AptMgmtPortal.Repository
{
    public interface ITenant
    {
        Task<bool> CancelMaintenanceRequest(int UserId, string resolutionNotes);
        Task<MaintenanceRequest> OpenMaintenanceRequest(int userId,
                                                        MaintenanceRequestType requestType,
                                                        string openNotes);
        Task<IEnumerable<MaintenanceRequest>> GetOutstandingMaintenanceRequests(int userId);
        Task<IEnumerable<MaintenanceRequest>> GetMaintenanceRequests(int userId, Period period);
        Task<bool> PayBill(int UserId, double amount, ResourceType resource);
        Task<Bill> PayBill(int UserId, double amount, ResourceType resource);
        Task<bool> EditPersonalInto(int UserId, string email, string phoneNumber);
    }
}