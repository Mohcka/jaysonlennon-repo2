using System.Collections.Generic;
using System.Threading.Tasks;
using AptMgmtPortalAPI.Entity;

namespace AptMgmtPortalAPI.Repository
{
    public interface IAgreementTemplate
    {
        Task<IEnumerable<AgreementTemplate>> GetAll();
        Task<AgreementTemplate> UpdateAgreementTemplate(AgreementTemplate agreement);
    }
}