using AptMgmtPortalAPI.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Repository
{
    public interface IAgreementTemplate
    {
        Task<IEnumerable<AgreementTemplate>> GetAll();
        Task<AgreementTemplate> UpdateAgreementTemplate(AgreementTemplate agreement);
    }
}