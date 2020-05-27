using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
