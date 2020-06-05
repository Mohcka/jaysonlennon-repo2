using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DataModel
{
    public class MaintenanceRequestModel
    {
        public int MaintenanceRequestId { get; set; }
        public MaintenanceCloseReason? CloseReason { get; set; }
        public string MaintenanceRequestType { get; set; }
        public string OpenNotes { get; set; }
        public string UnitNumber { get; set; }
    }
}
