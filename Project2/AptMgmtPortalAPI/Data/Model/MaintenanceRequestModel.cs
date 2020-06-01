using System;
using System.Linq;
using System.Threading.Tasks;
using AptMgmtPortalAPI.Repository;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.DataModel {
    public class MaintenanceRequestModel {
        public int MaintenanceRequestId { get; set; }
        public bool Closed { get; set; }
        public string MaintenanceRequestType { get; set; }
        public string OpenNotes { get; set; }
    }
}
