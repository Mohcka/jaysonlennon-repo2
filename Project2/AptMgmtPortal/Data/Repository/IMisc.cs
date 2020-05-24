using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortal.Entity;

namespace AptMgmtPortal.Repository
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