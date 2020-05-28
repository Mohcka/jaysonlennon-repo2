using AptMgmtPortal.Data;
using AptMgmtPortal.Entity;
using Microsoft.EntityFrameworkCore;
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
        private readonly AptMgmtDbContext _context;

        public MiscRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        public Task<BillingPeriod> FromId(int billingPeriodId)
        {
            throw new NotImplementedException();
        }

        public async Task<BillingPeriod> GetCurrentBillingPeriod()
        {
            return await _context.BillingPeriods
                .OrderByDescending(p => p.PeriodStart)
                .Select(p => p)
                .FirstOrDefaultAsync();
        }
    }
}
