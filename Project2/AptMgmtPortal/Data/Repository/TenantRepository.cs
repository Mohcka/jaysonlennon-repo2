using AptMgmtPortal.DataModel;
using AptMgmtPortal.Entity;
using AptMgmtPortal.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptMgmtPortal.Data.Repository
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
            var tenant = await TenantFromId(tenantId);
            tenant.FirstName = info.FirstName;
            tenant.LastName = info.LastName;
            tenant.Email = info.Email;
            tenant.PhoneNumber = info.PhoneNumber;

            return await _context.SaveChangesAsync() > 0;
        }

        public Task<Bill> GetBill(int tenantId, int billId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bill>> GetBills(int tenantId, ResourceType resource, BillingPeriod period)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bill>> GetBills(int tenantId, BillingPeriod period)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines if the maintenance request is for this specific user.
        /// </summary>
        public async Task<bool> IsMaintenanceRequestForUser(int userId, int maintenanceRequestId)
        {
            var tenantId = await TenantIdFromUserId(userId);
            Console.WriteLine($"tenantId = {tenantId}");
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

        public async Task<IEnumerable<Payment>> GetPayments(int tenantId, ResourceType resource, BillingPeriod period)
        {
            return await _context.Payments
                                 .Where(p => p.TenantId == tenantId)
                                 .Where(p => p.ResourceType == resource)
                                 .Where(p => p.BillingPeriodId == period.BillingPeriodId)
                                 .Select(p => p)
                                 .ToListAsync();
        }

        public async Task<TenantResourceUsageSummary> GetResourceUsage(int tenantId,
                                                                 ResourceType resource,
                                                                 BillingPeriod period)
        {
            var usage = await _context.TenantResourceUsages
                                 .Where(u => u.TenantId == tenantId)
                                 .Where(u => u.ResourceType == resource)
                                 .Where(u => u.SampleTime >= period.PeriodStart && u.SampleTime <= period.PeriodEnd)
                                 .SumAsync(u => u.UsageAmount);
            return new TenantResourceUsageSummary {
                ResourceType = resource,
                Usage = usage,
            };
        }

        public async Task<IEnumerable<TenantResourceUsageSummary>> GetResourceUsage(int tenantId, BillingPeriod period)
        {
            return await _context.TenantResourceUsages
                    .Where(u => u.TenantId == tenantId)
                    .Where(u => u.SampleTime >= period.PeriodStart && u.SampleTime <= period.PeriodEnd)
                    .GroupBy(u => u.ResourceType)
                    .Select(gr => new TenantResourceUsageSummary {
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

        public Task<bool> PayBill(int tenantId, decimal amount, ResourceType resource)
        {
            throw new NotImplementedException();
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

        public async Task<int> TenantIdFromUserId(int userId)
        {
            return await _context.Tenants
                                 .Where(t => t.UserId == userId)
                                 .Select(t => t.TenantId)
                                 .FirstOrDefaultAsync();
        }
    }
}