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
      
        public DateTimeOffset TimeOpened { get; set; }
        public DateTimeOffset? TimeClosed { get; set; }

        [ForeignKey(nameof(OpeningUser)), Column(Order = 0)]
        public int OpeningUserId { get; set; }
        public User OpeningUser { get; set; }
      
        [ForeignKey(nameof(ClosingUser)), Column(Order = 1)]
        public int ClosingUserId { get; set; }
        public User ClosingUser { get; set; }

        public int MaintenanceRequestTypeId { get; set; }
        public MaintenanceRequestType MaintenanceRequestType { get; set; }
        public MaintenanceCloseReason CloseReason { get; set; }

        public string OpenNotes { get; set; }
        public string ResolutionNotes { get; set; }
        public string InternalNotes { get; set; }
    }
}
