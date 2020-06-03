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
using AptMgmtPortalAPI.DTO;

namespace AptMgmtPortalAPI.Repository
{
    public class AgreementRepository : IAgreement
    {
        private readonly AptMgmtDbContext _context;

        public AgreementRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        public async Task<IEnumerable<DataModel.Agreement>> GetAgreements()
        {
            return await _context.Agreements
                .Join(_context.AgreementTemplates,
                      signedAgreements => signedAgreements.AgreementTemplateId,
                      templates => templates.AgreementTemplateId,
                      (sa, ta) => new DataModel.Agreement {
                          AgreementId = sa.AgreementId,
                          AgreementTemplateId = ta.AgreementTemplateId,
                          TenantId = sa.TenantId,
                          Title = ta.Title,
                          Text = ta.Text,
                          SignedDate = sa.SignedDate,
                          StartDate = sa.StartDate,
                          EndDate = sa.EndDate,
                      })
                .OrderByDescending(a => a.SignedDate)
                .ToListAsync();
        }

        public async Task<DataModel.Agreement> GetAgreement(int agreementId)
        {
            return await _context.Agreements
                .Where(s => s.AgreementId == agreementId)
                .Join(_context.AgreementTemplates,
                      signedAgreements => signedAgreements.AgreementTemplateId,
                      templates => templates.AgreementTemplateId,
                      (sa, ta) => new DataModel.Agreement {
                          AgreementId = sa.AgreementId,
                          AgreementTemplateId = ta.AgreementTemplateId,
                          TenantId = sa.TenantId,
                          Title = ta.Title,
                          Text = ta.Text,
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
        public async Task<IEnumerable<DataModel.Agreement>> GetAgreements(int tenantId)
        {
            return await _context.Agreements
                .Where(s => s.TenantId == tenantId)
                .Join(_context.AgreementTemplates,
                      signedAgreements => signedAgreements.AgreementTemplateId,
                      templates => templates.AgreementTemplateId,
                      (sa, ta) => new DataModel.Agreement {
                          AgreementId = sa.AgreementId,
                          AgreementTemplateId = ta.AgreementTemplateId,
                          TenantId = sa.TenantId,
                          Title = ta.Title,
                          Text = ta.Text,
                          SignedDate = sa.SignedDate,
                          StartDate = sa.StartDate,
                          EndDate = sa.EndDate,
                      })
                .OrderByDescending(a => a.SignedDate)
                .ToListAsync();
        }

        public async Task<Entity.Agreement> UpdateAgreement(Entity.Agreement updated)
        {
            var existingAgreement = await _context.Agreements
                .Where(a => a.AgreementId == updated.AgreementId)
                .Select(a => a)
                .FirstOrDefaultAsync();

            if (existingAgreement == null) {
                await _context.AddAsync(updated);
                await _context.SaveChangesAsync();
                return updated;
            } else {
                existingAgreement.AgreementTemplateId = updated.AgreementTemplateId;
                existingAgreement.StartDate = updated.StartDate;
                existingAgreement.EndDate = updated.EndDate;
                existingAgreement.SignedDate = existingAgreement.SignedDate;
                existingAgreement.TenantId = existingAgreement.TenantId;
                await _context.SaveChangesAsync();
                return existingAgreement;
            }

        }

        public async Task<Entity.Agreement> AddAgreement(int tenantId, int agreementTemplateId, DateTime startDate, DateTime endDate)
        {
            var agreement = new Entity.Agreement();
            agreement.AgreementTemplateId = agreementTemplateId;
            agreement.TenantId = tenantId;
            agreement.StartDate = startDate;
            agreement.EndDate = endDate;

            await _context.AddAsync(agreement);
            await _context.SaveChangesAsync();

            return agreement;
        }
    }
}