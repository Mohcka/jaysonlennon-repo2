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
        Task<IEnumerable<DataModel.Agreement>> GetSignedAgreements(int tenantId);
        Task<DataModel.Agreement> GetSignedAgreement(int agreementId);
        Task<IEnumerable<DataModel.AgreementSummary>> GetSignedAgreementSummaries(int tenantId);
        Task<DataModel.Agreement> SignAgreement(int tenantId,
                                                int agreementId,
                                                DateTime startDate,
                                                DateTime endDate);
        Task<IEnumerable<Entity.Agreement>> GetAllAgreements();
        Task<IEnumerable<DataModel.Agreement>> GetAllSignedAgreements();
    }
}