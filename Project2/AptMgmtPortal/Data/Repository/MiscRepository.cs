using AptMgmtPortal.Entity;
using AptMgmtPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortal.Repository
{
    public class MiscRepository : IMisc
    {
        public Task<BillingPeriod> FromId(int billingPeriodId)
        {
            throw new NotImplementedException();
        }

        public Task<BillingPeriod> GetCurrentBillingPeriod()
        {
            throw new NotImplementedException();
        }
    }
}
