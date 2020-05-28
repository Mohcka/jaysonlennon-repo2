using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortal.Entity;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.Repository
{
    /// <summary>
    /// Repository interface for querying the database from the tenant's viewpoint.
    /// </summary>
    public interface ITenant
    {
        Task<bool> RestEdit(TenantInfo info);
        Task<Tenant> AddTenant(TenantInfo info);
        Task<Tenant> TenantFromId(int tenantId);
        Task<Tenant> TenantFromUserId(int userId);
        Task<int> TenantIdFromUserId(int userId);

        // Maintenance info uses UserId since it's only possible to make a maintenance
        // request from within the application (either the tenant makes it, or a manager
        // makes it on the tenant's behalf).)
        Task<bool> CancelMaintenanceRequest(int userId,
                                            int maintenanceRequestId,
                                            string resolutionNotes);
        Task<MaintenanceRequest> OpenMaintenanceRequest(int userId,
                                                        string requestType,
                                                        string openNotes,
                                                        string unitNumber);
        Task<IEnumerable<MaintenanceRequest>> GetOutstandingMaintenanceRequests(int userId);
        Task<IEnumerable<MaintenanceRequest>> GetMaintenanceRequests(int userId,
                                                                     BillingPeriod period);

        // Bills require a tenantId, since they will be generated and used regardless
        // of whether or not a tenant has a user id.
        Task<bool> PayBill(int tenantId,
                           double amount,
                           ResourceType resource,
                           BillingPeriod period);
        Task<DataModel.Bill> GetBill(int tenantId,
                                                  ResourceType resource,
                                                  BillingPeriod period);
        Task<IEnumerable<DataModel.Bill>> GetBills(int tenantId, BillingPeriod period);
        Task<IEnumerable<DataModel.Bill>> GetBills(int tenantId, int billingPeriodId);
        Task<bool> EditPersonalInfo(int tenantId, TenantInfo info);

        // Payments require a tenantId, since they are relevant regardless of whether
        // or not a tenant has a user id.
        Task<Payment> GetPayment(int tenantId, int paymentId);
        Task<IEnumerable<Payment>> GetPayments(int tenantId,
                                               ResourceType resource,
                                               BillingPeriod period);

        // Resource usage requires a tenantId, since resources are consumed regardless
        // of whether or not the tenant has a user id.
        Task<DataModel.TenantResourceUsageSummary> GetResourceUsage(int tenantId,
                                                                    ResourceType resource,
                                                                    BillingPeriod period);
        Task<IEnumerable<DataModel.TenantResourceUsageSummary>> GetResourceUsage(int tenantId,
                                                                                 BillingPeriod period);
    }
}