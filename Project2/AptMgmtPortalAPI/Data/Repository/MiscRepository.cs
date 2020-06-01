using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Entity;
using Microsoft.EntityFrameworkCore;
using AptMgmtPortalAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Repository
{
    public class MiscRepository : IMisc
    {
        private readonly AptMgmtDbContext _context;

        public MiscRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        public async Task<BillingPeriod> BillingPeriodFromId(int billingPeriodId)
        {
            return await _context.BillingPeriods
                .Where(p => p.BillingPeriodId == billingPeriodId)
                .Select(p => p)
                .FirstOrDefaultAsync();
        }

        public async Task<BillingPeriod> GetCurrentBillingPeriod()
        {
            return await _context.BillingPeriods
                .OrderByDescending(p => p.PeriodStart)
                .Select(p => p)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ResourceUsageRate>> GetResourceUsageRates(BillingPeriod period)
        {
            return await _context.ResourceUsageRates
                .Where(r => r.PeriodStart <= period.PeriodStart
                            && r.PeriodEnd >= period.PeriodEnd)
                .Select(r => r)
                .ToListAsync();
        }
    }
}
