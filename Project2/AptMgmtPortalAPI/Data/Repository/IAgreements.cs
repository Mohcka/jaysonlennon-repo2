using AptMgmtPortalAPI.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Repository
{
    /// <summary>
    /// Repository interface for querying the database from the tenant's viewpoint.
    /// </summary>
    public interface IAgreement
    {
        Task<IEnumerable<DataModel.Agreement>> GetAgreements();
        Task<IEnumerable<DataModel.Agreement>> GetAgreements(int tenantId);
        Task<DataModel.Agreement> GetAgreement(int agreementId);
        Task<Agreement> UpdateAgreement(Agreement updated);
    }
}