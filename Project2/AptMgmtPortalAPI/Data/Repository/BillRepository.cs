using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.DataModel;
using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Repository
{
    public class BillRepository : IBill
    {
        private readonly AptMgmtDbContext _context;

        public BillRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }
        public async Task<DataModel.Bill> GetBill(int tenantId,
                                                  ResourceType resource,
                                                  BillingPeriod period)
        {
            if (period == null) return null;

            var billingRate = await _context.ResourceUsageRates
                                        .Where(r => r.ResourceType == resource)
                                        .Where(r => r.PeriodStart <= period.PeriodStart
                                                    && r.PeriodEnd >= period.PeriodEnd)
                                        .Select(r => r)
                                        .FirstOrDefaultAsync();

            var totalUsage = await _context.TenantResourceUsages
                                 .Where(u => u.TenantId == tenantId)
                                 .Where(u => u.ResourceType == resource)
                                 .Where(u => u.SampleTime >= period.PeriodStart
                                             && u.SampleTime <= period.PeriodEnd)
                                 .SumAsync(u => u.UsageAmount);

            var totalPaid = await _context.Payments
                                         .Where(p => p.TenantId == tenantId)
                                         .Where(p => p.ResourceType == resource)
                                         .Where(p => p.BillingPeriodId == period.BillingPeriodId)
                                         .SumAsync(p => p.Amount);

            var bill = new DataModel.Bill
            {
                Resource = resource,
                Period = period,
                Usage = totalUsage,
                Rate = billingRate.Rate,
                Paid = totalPaid,
                TenantId = tenantId,
            };

            return bill;
        }

        public async Task<IEnumerable<DataModel.Bill>> GetBills(BillingPeriod period)
        {
            if (period == null) return new List<DataModel.Bill>();

            var billingRates = await _context.ResourceUsageRates
                                        .Where(r => r.PeriodStart <= period.PeriodStart
                                                    && r.PeriodEnd >= period.PeriodEnd)
                                        .Select(r => r)
                                        .ToListAsync();

            var totalUsages = await _context.TenantResourceUsages
                                        .Where(u => u.SampleTime >= period.PeriodStart
                                                    && u.SampleTime <= period.PeriodEnd)
                                        .GroupBy(u => new { u.TenantId, u.ResourceType })
                                        .Select(gr => new
                                        {
                                            Resource = gr.Key.ResourceType,
                                            Usage = gr.Sum(u => u.UsageAmount),
                                            TenantId = gr.Key.TenantId
                                        })
                                        .ToListAsync();

            var totalPayments = await _context.Payments
                                        .Where(p => p.BillingPeriodId == period.BillingPeriodId)
                                        .GroupBy(p => new { p.TenantId, p.ResourceType })
                                        .Select(gr => new
                                        {
                                            Resource = gr.Key.ResourceType,
                                            Payment = gr.Sum(p => p.Amount),
                                            TenantId = gr.Key.TenantId
                                        })
                                        .ToListAsync();


            var bills = new List<DataModel.Bill>();

            foreach (var resourceUsage in totalUsages)
            {
                var rate = billingRates
                            .Where(r => r.ResourceType == resourceUsage.Resource)
                            .Select(r => r.Rate)
                            .FirstOrDefault();

                var payment = totalPayments
                                .Where(p => p.Resource == resourceUsage.Resource)
                                .Where(p => p.TenantId == resourceUsage.TenantId)
                                .Sum(p => p.Payment);

                var bill = new DataModel.Bill
                {
                    Resource = resourceUsage.Resource,
                    Period = period,
                    Usage = resourceUsage.Usage,
                    Rate = rate,
                    Paid = payment,
                    TenantId = resourceUsage.TenantId
                };

                bills.Add(bill);
            }

            return bills;
        }

        public async Task<IEnumerable<DataModel.Bill>> GetBills(int tenantId, BillingPeriod period)
        {
            if (period == null) return new List<DataModel.Bill>();

            var billingRates = await _context.ResourceUsageRates
                                        .Where(r => r.PeriodStart <= period.PeriodStart
                                                    && r.PeriodEnd >= period.PeriodEnd)
                                        .Select(r => r)
                                        .ToListAsync();

            var totalUsages = await _context.TenantResourceUsages
                                        .Where(u => u.TenantId == tenantId)
                                        .Where(u => u.SampleTime >= period.PeriodStart
                                                    && u.SampleTime <= period.PeriodEnd)
                                        .GroupBy(u => u.ResourceType)
                                        .Select(gr => new
                                        {
                                            Resource = gr.Key,
                                            Usage = gr.Sum(u => u.UsageAmount)
                                        })
                                        .ToListAsync();

            var totalPayments = await _context.Payments
                                        .Where(p => p.TenantId == tenantId)
                                        .Where(p => p.BillingPeriodId == period.BillingPeriodId)
                                        .GroupBy(p => p.ResourceType)
                                        .Select(gr => new
                                        {
                                            Resource = gr.Key,
                                            Payment = gr.Sum(p => p.Amount),
                                        })
                                        .ToListAsync();


            var bills = new List<DataModel.Bill>();

            foreach (var resourceUsage in totalUsages)
            {
                var rate = billingRates
                            .Where(r => r.ResourceType == resourceUsage.Resource)
                            .Select(r => r.Rate)
                            .FirstOrDefault();

                var payment = totalPayments
                                .Where(p => p.Resource == resourceUsage.Resource)
                                .Sum(p => p.Payment);

                var bill = new DataModel.Bill
                {
                    Resource = resourceUsage.Resource,
                    Period = period,
                    Usage = resourceUsage.Usage,
                    Rate = rate,
                    Paid = payment,
                    TenantId = tenantId,
                };

                bills.Add(bill);
            }

            return bills;
        }

        public async Task<Payment> GetPayment(int tenantId, int paymentId)
        {
            return await _context.Payments
                                 .Where(p => p.TenantId == tenantId)
                                 .Where(p => p.PaymentId == paymentId)
                                 .Select(p => p)
                                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Payment>> GetPayments(int tenantId,
                                                            ResourceType resource,
                                                            BillingPeriod period)
        {
            if (period == null) return new List<Payment>();

            return await _context.Payments
                                 .Where(p => p.TenantId == tenantId)
                                 .Where(p => p.ResourceType == resource)
                                 .Where(p => p.BillingPeriodId == period.BillingPeriodId)
                                 .Select(p => p)
                                 .ToListAsync();
        }

        public async Task<DataModel.Bill> PayBill(int tenantId,
                                                  double amount,
                                                  ResourceType resource,
                                                  BillingPeriod period)
        {
            if (period == null) return null;

            var payment = new Payment();
            payment.Amount = amount;
            payment.ResourceType = resource;
            payment.BillingPeriodId = period.BillingPeriodId;
            payment.TenantId = tenantId;
            payment.TimePaid = DateTime.Now;

            await _context.AddAsync(payment);
            await _context.SaveChangesAsync();

            return await GetBill(tenantId, resource, period);
        }

        public async Task<DataModel.Bill> PayBill(int tenantId,
                                        double amount,
                                        ResourceType resource,
                                        int billingPeriodId)
        {
            var billingPeriod = await _context.BillingPeriods
                                        .Where(p => p.BillingPeriodId == billingPeriodId)
                                        .Select(p => p)
                                        .FirstOrDefaultAsync();
            return await PayBill(tenantId, amount, resource, billingPeriod);
        }

        public async Task<IEnumerable<Bill>> GetBills(int tenantId, int billingPeriodId)
        {
            var billingPeriod = await _context.BillingPeriods
                                    .Where(p => p.BillingPeriodId == billingPeriodId)
                                    .FirstOrDefaultAsync();

            return await GetBills(tenantId, billingPeriod);
        }

        public async Task<DataModel.TenantResourceUsageSummary> GetResourceUsage(int tenantId,
                                                                 ResourceType resource,
                                                                 BillingPeriod period)
        {
            if (period == null) return null;

            var usage = await _context.TenantResourceUsages
                                 .Where(u => u.TenantId == tenantId)
                                 .Where(u => u.ResourceType == resource)
                                 .Where(u => u.SampleTime >= period.PeriodStart && u.SampleTime <= period.PeriodEnd)
                                 .SumAsync(u => u.UsageAmount);
            return new DataModel.TenantResourceUsageSummary
            {
                ResourceType = resource,
                Usage = usage,
            };
        }

        public async Task<IEnumerable<DataModel.TenantResourceUsageSummary>> GetResourceUsage(int tenantId,
                                                                                              BillingPeriod period)
        {
            if (period == null) return new List<DataModel.TenantResourceUsageSummary>();

            return await _context.TenantResourceUsages
                    .Where(u => u.TenantId == tenantId)
                    .Where(u => u.SampleTime >= period.PeriodStart && u.SampleTime <= period.PeriodEnd)
                    .GroupBy(u => u.ResourceType)
                    .Select(gr => new DataModel.TenantResourceUsageSummary
                    {
                        ResourceType = gr.Key,
                        Usage = gr.Sum(i => i.UsageAmount),
                    })
                    .ToListAsync();
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

        public async Task<IEnumerable<ProjectedResourceUsage>> GetProjectedResourceUsages(int tenantId, BillingPeriod period)
        {
            var usages = await GetResourceUsage(tenantId, period);
            var usageRates = await GetResourceUsageRates(period);

            var projections = new List<ProjectedResourceUsage>();

            foreach (var usage in usages)
            {
                var sampledDays = (DateTime.Now - period.PeriodStart).TotalDays + 1;

                var projectedUsageTotal = Util.ResourceProjection.TotalForPeriod(usage.Usage,
                                                                                 period.PeriodStart,
                                                                                 period.PeriodEnd,
                                                                                 DateTime.Now);

                var rate = usageRates
                    .Where(r => r.ResourceType == usage.ResourceType)
                    .Select(r => r)
                    .FirstOrDefault();
                if (rate == null) continue;

                var projected = new ProjectedResourceUsage
                {
                    TenantId = tenantId,
                    Resource = usage.ResourceType,
                    Period = period,
                    ActualUsage = usage.Usage,
                    ProjectedUsageTotal = projectedUsageTotal,
                    DaysRemainingInPeriod = (period.PeriodEnd - DateTime.Now).TotalDays,
                    AverageDailyUsage = usage.Usage / sampledDays,
                    Rate = rate.Rate,
                };

                projections.Add(projected);
            }

            return projections;
        }

        public async Task<ProjectedResourceUsage> GetProjectedResourceUsage(int tenantId, ResourceType resource, BillingPeriod period)
        {
            return (await GetProjectedResourceUsages(tenantId, period))
                .Where(p => p.Resource == resource)
                .Select(p => p)
                .FirstOrDefault();
        }

        public async Task<IEnumerable<MeteredResourceEntry>> GetDailyResourceUsage(int tenantId, ResourceType resource, BillingPeriod period)
        {
            return await _context.TenantResourceUsages
                .Where(u => u.TenantId == tenantId)
                .Where(u => u.ResourceType == resource)
                .Where(u => u.SampleTime >= period.PeriodStart
                            && u.SampleTime <= period.PeriodEnd)
                .OrderBy(u => u.SampleTime)
                .Select(u => new MeteredResourceEntry
                {
                    TenantId = tenantId,
                    SampleTime = u.SampleTime,
                    UsageAmount = u.UsageAmount,
                    ResourceType = u.ResourceType,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MeteredResourceEntry>> GetDailyResourceUsage(int tenantId, BillingPeriod period)
        {
            return await _context.TenantResourceUsages
                .Where(u => u.TenantId == tenantId)
                .Where(u => u.SampleTime >= period.PeriodStart
                            && u.SampleTime <= period.PeriodEnd)
                .OrderBy(u => u.SampleTime)
                .Select(u => new MeteredResourceEntry
                {
                    TenantId = tenantId,
                    SampleTime = u.SampleTime,
                    UsageAmount = u.UsageAmount,
                    ResourceType = u.ResourceType,
                })
                .ToListAsync();
        }
    }
}