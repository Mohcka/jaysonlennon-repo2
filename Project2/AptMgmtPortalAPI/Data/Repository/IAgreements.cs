using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Repository
{
    /// <summary>
    /// Repository interface for querying the database from the tenant's viewpoint.
    /// </summary>
    public interface IAgreement
    {
        Task<Agreement> AddAgreement(int tenantId,
                                           int agreementTemplateId,
                                           DateTime startDate,
                                           DateTime endDate);
        Task<IEnumerable<DataModel.Agreement>> GetAgreements();
        Task<IEnumerable<DataModel.Agreement>> GetAgreements(int tenantId);
        Task<DataModel.Agreement> GetAgreement(int agreementId);
        Task<Agreement> UpdateAgreement(Agreement updated);
    }
}