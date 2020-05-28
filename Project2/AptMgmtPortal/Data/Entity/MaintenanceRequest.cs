using System;
using System.ComponentModel.DataAnnotations;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.Entity
{
    public class MaintenanceRequest
    {
        [Key]
        public int MaintenanceRequestId { get; set; }
      
        public DateTime TimeOpened { get; set; }
        public DateTime? TimeClosed { get; set; }

        public int OpeningUserId { get; set; }
        public int? ClosingUserId { get; set; }

        public string MaintenanceRequestType { get; set; }
        public MaintenanceCloseReason? CloseReason { get; set; }

        public string OpenNotes { get; set; }
        public string ResolutionNotes { get; set; }
        public string InternalNotes { get; set; }
        public string UnitNumber { get; set; }
    }
}
