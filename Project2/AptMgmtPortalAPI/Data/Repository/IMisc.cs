using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Entity;

namespace AptMgmtPortalAPI.Repository
{
    /// <summary>
    /// Miscellanous queries such as billing periods and resource rate assignments.
    /// </summary>
    public interface IMisc
    {
        Task<BillingPeriod> GetCurrentBillingPeriod();
        Task<BillingPeriod> FromId(int billingPeriodId);
    }
}