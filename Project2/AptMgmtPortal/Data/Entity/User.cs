using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AptMgmtPortal.Data;

namespace AptMgmtPortal.Entity {
    public class User
    {
        public User()
        {
            this.OpeningMaintenanceRequests = new HashSet<MaintenanceRequest>();
            this.ClosingMaintenanceRequests = new HashSet<MaintenanceRequest>();
            this.Tenents = new HashSet<Tenant>();
        }
        public int UserId { get; set; }
        public UserAccountType UserAccountType { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }

        [InverseProperty(nameof(MaintenanceRequest.OpeningUser))]
        public ICollection<MaintenanceRequest> OpeningMaintenanceRequests { get; set; }

        [InverseProperty(nameof(MaintenanceRequest.ClosingUser))]
        public ICollection<MaintenanceRequest> ClosingMaintenanceRequests { get; set; }

        public ICollection<Tenant> Tenents { get; set; }
    }
}