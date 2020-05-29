using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Entity
{
    public class MaintenanceRequest
    {
        [Key]
        public int MaintenanceRequestId { get; set; }
      
        [Column(TypeName="NVARCHAR(48)")]
        public DateTime TimeOpened { get; set; }

        [Column(TypeName="NVARCHAR(48)")]
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
