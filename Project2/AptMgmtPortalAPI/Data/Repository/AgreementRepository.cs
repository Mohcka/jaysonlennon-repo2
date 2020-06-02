using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Entity;
using AptMgmtPortalAPI.Data;
using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.DataModel;

namespace AptMgmtPortalAPI.Repository
{
    public class AgreementRepository : IAgreement
    {
        private readonly AptMgmtDbContext _context;

        public AgreementRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        public async Task<IEnumerable<Entity.Agreement>> GetAllAgreements()
        {
            return await _context.Agreements.Select(a => a).ToListAsync();
        }

        public async Task<IEnumerable<DataModel.Agreement>> GetAllSignedAgreements()
        {
            return await _context.SignedAgreements
                .Join(_context.Agreements,
                      signedAgreements => signedAgreements.AgreementId,
                      agreements => agreements.AgreementId,
                      (sa, a) => new DataModel.Agreement {
                          AgreementId = sa.AgreementId,
                          Title = a.Title,
                          Text = a.Text,
                          SignedDate = sa.SignedDate,
                          StartDate = sa.StartDate,
                          EndDate = sa.EndDate,
                      })
                .OrderByDescending(a => a.SignedDate)
                .ToListAsync();
        }

        public async Task<DataModel.Agreement> GetSignedAgreement(int agreementId)
        {
            return await _context.SignedAgreements
                .Where(s => s.AgreementId == agreementId)
                .Join(_context.Agreements,
                      signedAgreements => signedAgreements.AgreementId,
                      agreements => agreements.AgreementId,
                      (sa, a) => new DataModel.Agreement {
                          AgreementId = sa.AgreementId,
                          Title = a.Title,
                          Text = a.Text,
                          SignedDate = sa.SignedDate,
                          StartDate = sa.StartDate,
                          EndDate = sa.EndDate,
                      })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retrieves tenant Agreements.
        /// </summary>
        /// <param name="tenantId">Tenant ID from which to get agreements.</param>
        /// <returns></returns>
        public async Task<IEnumerable<DataModel.Agreement>> GetSignedAgreements(int tenantId)
        {
            return await _context.SignedAgreements
                .Where(s => s.TenantId == tenantId)
                .Join(_context.Agreements,
                      signedAgreements => signedAgreements.AgreementId,
                      agreements => agreements.AgreementId,
                      (sa, a) => new DataModel.Agreement {
                          AgreementId = sa.AgreementId,
                          Title = a.Title,
                          Text = a.Text,
                          SignedDate = sa.SignedDate,
                          StartDate = sa.StartDate,
                          EndDate = sa.EndDate,
                      })
                .OrderByDescending(a => a.SignedDate)
                .ToListAsync();
        }

        /// <summary>
        /// Returns agreements, excluding the agreement text.
        /// </summary>
        /// <param name="tenantId">Tenant ID from which to retrieve the agreements.</param>
        /// <returns></returns>
        public async Task<IEnumerable<AgreementSummary>> GetSignedAgreementSummaries(int tenantId)
        {
            return await _context.SignedAgreements
                .Where(s => s.TenantId == tenantId)
                .Join(_context.Agreements,
                      signedAgreements => signedAgreements.AgreementId,
                      agreements => agreements.AgreementId,
                      (sa, a) => new DataModel.AgreementSummary {
                          AgreementId = sa.AgreementId,
                          Title = a.Title,
                          SignedDate = sa.SignedDate,
                          StartDate = sa.StartDate,
                          EndDate = sa.EndDate,
                      })
                .OrderByDescending(a => a.SignedDate)
                .ToListAsync();
        }

        public async Task<DataModel.Agreement> SignAgreement(int tenantId, int agreementId, DateTime startDate, DateTime endDate)
        {
            var agreement = await _context.Agreements
                .Where(a => a.AgreementId == agreementId)
                .FirstOrDefaultAsync();

            if (agreement == null) return null;

            var signedAgreement = new SignedAgreement();
            signedAgreement.TenantId = tenantId;
            signedAgreement.AgreementId = agreementId;
            signedAgreement.SignedDate = DateTime.Now;
            signedAgreement.StartDate = startDate;
            signedAgreement.EndDate = endDate;

            _context.Add(signedAgreement);
            await _context.SaveChangesAsync();

            return new DataModel.Agreement {
                AgreementId = signedAgreement.AgreementId,
                Title = agreement.Title,
                Text = agreement.Text,
                SignedDate = signedAgreement.SignedDate,
                StartDate = signedAgreement.StartDate,
                EndDate = signedAgreement.EndDate,
            };
        }
    }
}