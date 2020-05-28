using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AptMgmtPortal.Entity
{
    public class Agreement
    {
        public int AgreementId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
