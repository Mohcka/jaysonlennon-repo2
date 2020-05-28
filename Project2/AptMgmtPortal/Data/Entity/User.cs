using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AptMgmtPortal.Data;

namespace AptMgmtPortal.Entity {
    public class User
    {
        public User() { }
        public int UserId { get; set; }
        public UserAccountType UserAccountType { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
    }
}