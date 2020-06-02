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

        // Bills require a tenantId, since they will be generated and used regardless
        // of whether or not a tenant has a user id.
        Task<bool> PayBill(int tenantId,
                           double amount,
                           ResourceType resource,
                           BillingPeriod period);
        Task<bool> PayBill(int tenantId,
                           double amount,
                           ResourceType resource,
                           int billingPeriodId);
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

        Task<string> GetUnitNumber(int tenantId);

        Task<Tenant> UpdateTenantInfo(int tenantId, DTO.TenantInfoDTO newInfo);
    }
}