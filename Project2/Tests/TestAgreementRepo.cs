
using System.Linq;
using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Repository;
using AptMgmtPortalAPI.Types;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace TestAptMgmtPortal
{
    public class TestAgreementRepo
    {
        [Fact]
        public async void GetsSignedAgreements()
        {
            var options = TestUtil.GetMemDbOptions("GetsSignedAgreements");

            Tenant tenant;
            AgreementTemplate agreement1;
            AgreementTemplate agreement2;
            Agreement signedAgreement1;
            Agreement signedAgreement2;
            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (ITenant)new TenantRepository(db);
                tenant = TestUtil.NewTenant(db);

                agreement1 = TestUtil.NewAgreement(db, "test-agreement1");
                agreement2 = TestUtil.NewAgreement(db, "test-agreement2");

                signedAgreement1 = TestUtil.SignAgreement(db, agreement1.AgreementTemplateId, tenant.TenantId);
                signedAgreement2 = TestUtil.SignAgreement(db, agreement2.AgreementTemplateId, tenant.TenantId);
            }

            using (var db = new AptMgmtDbContext(options))
            {
                var repo = (IAgreement)new AgreementRepository(db);
                var signedAgreements = await repo.GetAgreements(tenant.TenantId);
                Assert.Equal(2, signedAgreements.Count());

                var signed1 = signedAgreements.Where(a => a.AgreementTemplateId == agreement1.AgreementTemplateId).FirstOrDefault();
                Assert.Equal("test-agreement1", signed1.Title);

                var signed2 = signedAgreements.Where(a => a.AgreementTemplateId == agreement2.AgreementTemplateId).FirstOrDefault();
                Assert.Equal("test-agreement2", signed2.Title);
            }
        }

    }
}
