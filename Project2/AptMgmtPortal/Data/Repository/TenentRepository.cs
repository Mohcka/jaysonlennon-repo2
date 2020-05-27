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
    public class TenentRepository : ITenant
    {
        private readonly AptMgmtDbContext _context;

        public TenentRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }
        public async Task<bool> CancelMaintenanceRequest(int userId, string resolutionNotes)
        {
            try
            {
                User user = new User 
                {
                    UserId = userId
                };
                var userType = user.UserAccountType;


                MaintenanceRequest maintenanceRequest = new MaintenanceRequest
                {
                    ClosingUser = user,
                    ResolutionNotes = resolutionNotes,
                    CloseReason = userType == UserAccountType.Admin ? MaintenanceCloseReason.CanceledByManagement : MaintenanceCloseReason.CanceledByTenant,
                    TimeClosed = DateTimeOffset.Now,

                };
                _context.Update(maintenanceRequest);
                var result = await _context.SaveChangesAsync();
                return result > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> EditPersonalInfo(int tenantId, string email, string phoneNumber)
        {
            try
            {
                Tenant tenant = new Tenant
                {
                    TenantId = tenantId,
                    Email = email,
                    PhoneNumber = phoneNumber
                };
                _context.Tenants.Update(tenant);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        //
        public async Task<Bill> GetBill(int tenantId, int billId)
        {
            try
            {
                // blocking bits => Resource and BillingPeriod
                return await _context.Payments
                    .Include(p => p.BillingPeriods)
                    .Include(p=>p.Tenent)
                    .Where(p => p.TenentId == tenantId && p.PaymentId == billId)
                     .Select(p =>
                    new Bill()
                    {
                        Period = p.BillingPeriods,
                        Resource = p.ResourceType,
                        // confused about how to get Usage and rate.
                        
                    })
                 .AsNoTracking()
                 .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Bill>> GetBills(int tenantId, ResourceType resource, BillingPeriod period)
        {
            // need a way to cycle throguh resources, Perhaps a foreach loop ? 
            try
            {
                return await _context.Payments.Include(p => p.BillingPeriods)
                    .Where(p => p.TenentId == tenantId)
                     .Select(p =>
                    new Bill()
                    {

                    })
                 .AsNoTracking()
                 .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<IEnumerable<Bill>> GetBills(int tenantId, BillingPeriod period)
        {
            // same as above ?? 
            // just to make it build for now
            return null; 
        }

        // Todo: Billing Period
        public async Task<IEnumerable<MaintenanceRequest>> GetMaintenanceRequests(int userId, BillingPeriod period)
        {
            try
            {
                return await _context.MaintenanceRequests
                    .Include(m => m.OpeningUser)
                    .Where(m=>m.OpeningUserId == userId)
                    .AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<MaintenanceRequest>> GetOutstandingMaintenanceRequests(int userId)
        {
            try
            {
                return await _context.MaintenanceRequests
                    .Include(m => m.OpeningUser)
                    .Where(m => m.OpeningUserId == userId && m.ClosingUserId == null)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<Payment> GetPayment(int tenantId, int paymentId)
        {
            try
            {
                return await _context.Payments
              .Include(p => p.Tenent)
              .Where(p => p.TenentId == tenantId && p.PaymentId == paymentId)
              .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        // todo : Billing Period
        public async Task<IEnumerable<Payment>> GetPayments(int tenantId, ResourceType resource, BillingPeriod period)
        {
            try
            {
               return await _context.Payments
              .Include(p => p.Tenent)
              .Where(p => p.TenentId == tenantId && p.ResourceType == resource)
              .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        // todo : Billing Period
        public async Task<TenantResourceUsageSummary> GetResourceUsage(int tenantId, ResourceType resource, BillingPeriod period)
        {
            try
            {
                return await _context.TenantResourceUsages.Include(t => t.Tenent)
                 .Where(t => t.TenantId == tenantId)
                 .Select(t =>
                    new TenantResourceUsageSummary()
                    {
                        ResourceType = resource,
                        Usage = t.UsageAmount
                    })
                 .AsNoTracking()
                 .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        // todo : Billing Period (Incomplete) 
        public async Task<IEnumerable<TenantResourceUsageSummary>> GetResourceUsage(int tenantId, BillingPeriod period)
        {
            try
            {
                // iterate over every resource type ? 

                return from r in _context.TenantResourceUsages.Include(t => t.Tenent).Where(t => t.TenantId == tenantId)
                       select new TenantResourceUsageSummary
                       {
                           // todo: stuff
                       };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MaintenanceRequest> OpenMaintenanceRequest(int userId, MaintenanceRequestType requestType, string openNotes, string unitNumber)
        {
            try
            {
                var user = await _context.Users.Where(u => u.UserId == userId).AsNoTracking().FirstOrDefaultAsync();

                MaintenanceRequest maintenanceRequest = new MaintenanceRequest
                {
                    OpeningUser = user,
                    TimeOpened = DateTimeOffset.Now,
                    // I am assuming we are getting object of type MaintenanceRequestType
                    MaintenanceRequestType = requestType,
                    OpenNotes = openNotes,
                    UnitNumber = unitNumber
                };

                _context.MaintenanceRequests.Add(maintenanceRequest);
                await _context.SaveChangesAsync();
                return maintenanceRequest;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> PayBill(int tenantId, decimal amount, ResourceType resource)
        {
            //Todo: logic to calculate days/30 for new tenant

            // Gives first/last day of the month ? 
            //  https://stackoverflow.com/questions/24245523/getting-the-first-and-last-day-of-a-month-using-a-given-datetime-object
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // constructs new BillingPeriod object 
            BillingPeriod billingPeriod = new BillingPeriod
            {
                PeriodStart = firstDayOfMonth,
                PeriodEnd = lastDayOfMonth
            };

            // Brings in Tenent through tenentId
            var tenant = await TenantFromId(tenantId);

            // Constructs object of Payment type
            Payment newPayment = new Payment
            {
                Amount = amount,
                ResourceType = resource,
                Tenent = tenant,
                Timepaid = DateTimeOffset.UtcNow,
                BillingPeriods = billingPeriod

            };

            // inserts newPayment into database 
            _context.Payments.Add(newPayment);
            var result = await _context.SaveChangesAsync();

            return result>0;
        }

        public async Task<Tenant> TenantFromId(int tenantId)
        {
            try
            {
                return await _context.Tenants
              .Include(t => t.User)
              .Where(t => t.TenantId == tenantId)
              .AsNoTracking()
              .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Tenant> TenantFromUserId(int userId)
        {
            try
            {
                return await _context.Tenants
               .Include(t => t.User)
               .Where(t => t.UserId == userId)
               .AsNoTracking()
               .FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<int> TenantIdFromUserId(int userId)
        {
            try
            {
                var user = await _context.Tenants
               .Include(t => t.User)
               .Where(t => t.UserId == userId).AsNoTracking()
               .FirstOrDefaultAsync();
                return user.UserId;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
