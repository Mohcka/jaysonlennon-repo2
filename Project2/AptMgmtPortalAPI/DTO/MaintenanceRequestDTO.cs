using System;
using System.Linq;
using System.Threading.Tasks;
using AptMgmtPortalAPI.Repository;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DTO {
    public class MaintenanceRequestDTO {
        public int MaintenanceRequestId { get; set; }
        public DateTime TimeOpened { get; set; }
        public DateTime? TimeClosed { get; set; }
        public string OpenedBy { get; set; }
        public string ClosedBy { get; set; }
        public string MaintenanceRequestType { get; set; }
        public MaintenanceCloseReason? CloseReason { get; set; }

        public string OpenNotes { get; set; }
        public string ResolutionNotes { get; set; }
        public string UnitNumber { get; set; }

        public static async Task<MaintenanceRequestDTO> Build(Entity.MaintenanceRequest request, IUser userRepository) {
            var obj = new MaintenanceRequestDTO();
            obj.MaintenanceRequestId = request.MaintenanceRequestId;
            obj.TimeOpened = request.TimeOpened;
            obj.TimeClosed = request.TimeClosed;

            var openingUser = await userRepository.UserFromId(request.OpeningUserId);

            if (openingUser.UserAccountType == UserAccountType.Manager) {
                obj.OpenedBy = $"{openingUser.FirstName} (Manager)";
            } else if (openingUser.UserAccountType == UserAccountType.Admin) {
                obj.OpenedBy = $"{openingUser.FirstName} (Admin)";
            } else {
                obj.OpenedBy = $"{openingUser.FirstName}";
            }

            if (request.ClosingUserId != null)
            {
                var closingUser = await userRepository.UserFromId((int)request.ClosingUserId);
                if (closingUser != null)
                {
                    if (closingUser.UserAccountType == UserAccountType.Manager) {
                        obj.ClosedBy = $"{closingUser.FirstName} (Manager)";
                    } else if (closingUser.UserAccountType == UserAccountType.Admin) {
                        obj.ClosedBy = $"{closingUser.FirstName} (Admin)";
                    } else {
                        obj.ClosedBy = $"{closingUser.FirstName}";
                    }
                }
            }

            obj.MaintenanceRequestType = request.MaintenanceRequestType;
            obj.CloseReason = request.CloseReason;
            obj.OpenNotes = request.OpenNotes;
            obj.ResolutionNotes = request.ResolutionNotes;
            obj.UnitNumber = request.UnitNumber;

            return obj;
        }
    }
}