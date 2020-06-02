
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.DataModel;

namespace AptMgmtPortalAPI.Repository
{
    public class MaintenanceRepository : IMaintenance
    {
        private readonly AptMgmtDbContext _context;

        public MaintenanceRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        public async Task<MaintenanceRequest> CancelMaintenanceRequest(int userWhoCanceled,
                                                         int maintenanceRequestId,
                                                         string resolutionNotes)
        {
            var maintenanceRequest = await GetMaintenanceRequest(maintenanceRequestId);

            if (maintenanceRequest == null) return null;
            maintenanceRequest.ResolutionNotes = resolutionNotes;
            maintenanceRequest.TimeClosed = DateTime.Now;
            maintenanceRequest.ClosingUserId = userWhoCanceled;

            await _context.SaveChangesAsync();

            return maintenanceRequest;
        }

        public async Task<MaintenanceRequest> GetMaintenanceRequest(int requestId)
        {
            return await _context.MaintenanceRequests
                .Where(r => r.MaintenanceRequestId == requestId)
                .Select(r => r)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MaintenanceRequest>> GetOpenMaintenanceRequests(string unitNumber)
        {
            return await _context.MaintenanceRequests
                .Where(r => r.UnitNumber.ToLower() == unitNumber.ToLower())
                .Where(r => r.TimeClosed != null)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaintenanceRequest>> GetMaintenanceRequests(string unitNumber)
        {
            return await _context.MaintenanceRequests
                .Where(r => r.UnitNumber.ToLower() == unitNumber.ToLower())
                .ToListAsync();
        }

        public async Task<MaintenanceRequest> OpenMaintenanceRequest(int userId,
                                                                     DataModel.MaintenanceRequestModel data)
        {
            if (data == null) return null;

            var user = await _context.Users
                                        .Where(u => u.UserId == userId)
                                        .FirstOrDefaultAsync();

            MaintenanceRequest maintenanceRequest = new MaintenanceRequest
            {
                OpeningUserId = user.UserId,
                TimeOpened = DateTime.Now,
                MaintenanceRequestType = data.MaintenanceRequestType,
                OpenNotes = data.OpenNotes,
                UnitNumber = data.UnitNumber,
            };

            _context.MaintenanceRequests.Add(maintenanceRequest);
            await _context.SaveChangesAsync();

            return maintenanceRequest;
        }

        public async Task<MaintenanceRequest> UpdateMaintenanceRequest(MaintenanceRequest original,
                                                                       MaintenanceRequestModel updated,
                                                                       int userId)
        {
            // Maintenance requests are immutable once closed.
            if (original.TimeClosed != null) return original;

            if (updated.Closed == true) {
                original.ClosingUserId = userId;
                original.TimeClosed = DateTime.Now;
                original.CloseReason = MaintenanceCloseReason.CanceledByTenant;
            }

            original.MaintenanceRequestType = updated.MaintenanceRequestType;
            original.OpenNotes = updated.OpenNotes;
            original.UnitNumber = updated.UnitNumber;

            await _context.SaveChangesAsync();

            return await GetMaintenanceRequest(original.MaintenanceRequestId);
        }

        public async Task<IEnumerable<MaintenanceRequest>> GetMaintenanceRequests()
        {
            return await _context.MaintenanceRequests
                .Select(r => r)
                .OrderByDescending(r => r.TimeOpened)
                .ToListAsync();
        }
    }
}