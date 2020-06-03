using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Repository
{
    public interface IBill
    {
        Task<BillingPeriod> GetCurrentBillingPeriod();
        Task<BillingPeriod> BillingPeriodFromId(int billingPeriodId);
        Task<DataModel.Bill> PayBill(int tenantId,
                           double amount,
                           ResourceType resource,
                           BillingPeriod period);
        Task<DataModel.Bill> PayBill(int tenantId,
                           double amount,
                           ResourceType resource,
                           int billingPeriodId);
        Task<DataModel.Bill> GetBill(int tenantId,
                                                  ResourceType resource,
                                                  BillingPeriod period);
        Task<IEnumerable<DataModel.Bill>> GetBills(int tenantId, BillingPeriod period);
        Task<IEnumerable<DataModel.Bill>> GetBills(BillingPeriod period);
        Task<IEnumerable<DataModel.Bill>> GetBills(int tenantId, int billingPeriodId);
        Task<Payment> GetPayment(int tenantId, int paymentId);
        Task<IEnumerable<Payment>> GetPayments(int tenantId,
                                               ResourceType resource,
                                               BillingPeriod period);

        // Resource usage requires a tenantId, since resources are consumed regardless
        // of whether or not the tenant has a user id.
        Task<DataModel.TenantResourceUsageSummary> GetResourceUsage(int tenantId,
                                                                    ResourceType resource,
                                                                    BillingPeriod period);
        Task<IEnumerable<DataModel.TenantResourceUsageSummary>> GetResourceUsage(int tenantId, BillingPeriod period);

        Task<IEnumerable<ResourceUsageRate>> GetResourceUsageRates(BillingPeriod period);

        Task<IEnumerable<DataModel.ProjectedResourceUsage>> GetProjectedResourceUsages(int tenantId, BillingPeriod period);
        Task<DataModel.ProjectedResourceUsage> GetProjectedResourceUsage(int tenantId, ResourceType resource, BillingPeriod period);
    }
}