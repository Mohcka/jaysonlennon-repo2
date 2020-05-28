using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AptMgmtPortal.Entity;
using AptMgmtPortal.Data;
using AptMgmtPortal.Types;
using AptMgmtPortal.DataModel;

namespace AptMgmtPortal.Repository
{
    public class TenantRepository : ITenant
    {
        private readonly AptMgmtDbContext _context;

        public TenantRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        public async Task<Tenant> AddTenant(TenantInfo info)
        {
            if (info == null) return null;
            
            var tenant = new Tenant();
            tenant.FirstName = info.FirstName;
            tenant.LastName = info.LastName;
            tenant.Email = info.Email;
            tenant.PhoneNumber = info.PhoneNumber;
            tenant.UserId = info.UserId;

            _context.Add(tenant);
            await _context.SaveChangesAsync();
            return tenant;
        }

        /// <remarks>
        /// The userId supplied must be a user that is currently occupying the unit where the maintenanceRequestId is assigned.
        /// </remarks>
        /// <returns></returns>
        public async Task<bool> CancelMaintenanceRequest(int userId,
                                                         int maintenanceRequestId,
                                                         string resolutionNotes)
        {
            var maintenanceRequest = await GetMaintenanceRequest(userId, maintenanceRequestId);
            maintenanceRequest.ResolutionNotes = resolutionNotes;
            maintenanceRequest.TimeClosed = DateTime.Now;
            maintenanceRequest.ClosingUserId = userId;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EditPersonalInfo(int tenantId, TenantInfo info)
        {
            if (info == null) return false;

            var tenant = await TenantFromId(tenantId);
            tenant.FirstName = info.FirstName;
            tenant.LastName = info.LastName;
            tenant.Email = info.Email;
            tenant.PhoneNumber = info.PhoneNumber;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<DataModel.Bill> GetBill(int tenantId,
                                                  ResourceType resource,
                                                  BillingPeriod period)
        {
            if (period == null) return null;

            var billingRate = await _context.ResourceUsageRates
                                        .Where(r => r.ResourceType == resource)
                                        .Where(r => r.PeriodStart >= period.PeriodStart
                                                    && r.PeriodEnd <= period.PeriodEnd)
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
            };

            return bill;
        }

        public async Task<IEnumerable<DataModel.Bill>> GetBills(int tenantId, BillingPeriod period)
        {
            if (period == null) return null;

            var billingRates = await _context.ResourceUsageRates
                                        .Where(r => r.PeriodStart >= period.PeriodStart
                                                    && r.PeriodEnd <= period.PeriodEnd)
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
                };

                bills.Add(bill);
            }

            return bills;
        }

        /// <summary>
        /// Determines if the maintenance request is for this specific user.
        /// </summary>
        public async Task<bool> IsMaintenanceRequestForUser(int userId, int maintenanceRequestId)
        {
            var tenantId = await TenantIdFromUserId(userId);
            var unitNumber = await _context.Units
                                           .Where(u => u.TenantId == tenantId)
                                           .Select(u => u.UnitNumber)
                                           .FirstOrDefaultAsync();
            return await _context.MaintenanceRequests
                .Where(r => r.UnitNumber == unitNumber)
                .FirstOrDefaultAsync() != null;
        }

        public async Task<MaintenanceRequest> GetMaintenanceRequest(int userId, int maintenanceRequestId)
        {
            // Ensure that only maintenance requests for this user can be accessed.
            if (!await IsMaintenanceRequestForUser(userId, maintenanceRequestId)) return null;

            return await _context.MaintenanceRequests
                .Where(r => r.MaintenanceRequestId == maintenanceRequestId)
                .Select(r => r)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MaintenanceRequest>> GetMaintenanceRequests(int userId,
                                                                                  BillingPeriod period)
        {
            if (period == null) return null;

            return await _context.MaintenanceRequests
                .Where(m => m.OpeningUserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<MaintenanceRequest>> GetOutstandingMaintenanceRequests(int userId)
        {
            return await _context.MaintenanceRequests
                .Where(m => m.OpeningUserId == userId && m.ClosingUserId == null)
                .AsNoTracking()
                .ToListAsync();
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
            if (period == null) return null;

            return await _context.Payments
                                 .Where(p => p.TenantId == tenantId)
                                 .Where(p => p.ResourceType == resource)
                                 .Where(p => p.BillingPeriodId == period.BillingPeriodId)
                                 .Select(p => p)
                                 .ToListAsync();
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
            if (period == null) return null;

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

        public async Task<MaintenanceRequest> OpenMaintenanceRequest(int userId,
                                                                     string requestType,
                                                                     string openNotes,
                                                                     string unitNumber)
        {
            var user = await _context.Users
                                        .Where(u => u.UserId == userId)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

            MaintenanceRequest maintenanceRequest = new MaintenanceRequest
            {
                OpeningUserId = user.UserId,
                TimeOpened = DateTime.Now,
                // I am assuming we are getting object of type MaintenanceRequestType
                MaintenanceRequestType = requestType,
                OpenNotes = openNotes,
                UnitNumber = unitNumber
            };

            _context.MaintenanceRequests.Add(maintenanceRequest);
            await _context.SaveChangesAsync();
            return maintenanceRequest;
        }

        public async Task<bool> PayBill(int tenantId,
                                        double amount,
                                        ResourceType resource,
                                        BillingPeriod period)
        {
            if (period == null) return false;

            var payment = new Payment();
            payment.Amount = amount;
            payment.ResourceType = resource;
            payment.BillingPeriodId = period.BillingPeriodId;
            payment.TenantId = tenantId;
            payment.TimePaid = DateTime.Now;

            await _context.AddAsync(payment);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> PayBill(int tenantId,
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

        public async Task<Tenant> TenantFromId(int tenantId)
        {
            return await _context.Tenants
                                 .Where(t => t.TenantId == tenantId)
                                 .Select(t => t)
                                 .FirstOrDefaultAsync();
        }

        public async Task<Tenant> TenantFromUserId(int userId)
        {
            return await _context.Tenants
                                 .Where(t => t.UserId == userId)
                                 .Select(t => t)
                                 .FirstOrDefaultAsync();
        }

        public async Task<int?> TenantIdFromUserId(int userId)
        {
            return await _context.Tenants
                                 .Where(t => t.UserId == userId)
                                 .Select(t => t.TenantId)
                                 .FirstOrDefaultAsync();
        }

        public async Task<bool> RestEdit(TenantInfo info)
        {
            if (info == null) return false;

            var tenant = await TenantFromId(info.TenantId);
            tenant.FirstName = info.FirstName;
            tenant.LastName = info.LastName;
            tenant.Email = info.Email;
            tenant.PhoneNumber = info.PhoneNumber;
            tenant.UserId = info.UserId;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Bill>> GetBills(int tenantId, int billingPeriodId)
        {
            var billingPeriod = await _context.BillingPeriods
                                    .Where(p => p.BillingPeriodId == billingPeriodId)
                                    .FirstOrDefaultAsync();

            return await GetBills(tenantId, billingPeriod);
        }
    }
}