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
    public class AgreementTemplateRepository : IAgreementTemplate
    {
        private readonly AptMgmtDbContext _context;

        public AgreementTemplateRepository(AptMgmtDbContext aptMgmtDbContext)
        {
            _context = aptMgmtDbContext;
        }

        public async Task<IEnumerable<Entity.AgreementTemplate>> GetAll()
        {
            return await _context.AgreementTemplates.Select(a => a).ToListAsync();
        }

        public async Task<Entity.AgreementTemplate> UpdateAgreementTemplate(Entity.AgreementTemplate agreement)
        {
            var existingTemplate = await _context.AgreementTemplates
                .Where(a => a.AgreementTemplateId == agreement.AgreementTemplateId)
                .Select(a => a)
                .FirstOrDefaultAsync();

            if (existingTemplate == null)
            {
                await _context.AddAsync(agreement);
                await _context.SaveChangesAsync();
                return agreement;
            }
            else
            {
                existingTemplate.Title = agreement.Title;
                existingTemplate.Title = agreement.Text;
                await _context.SaveChangesAsync();
                return existingTemplate;
            }
        }
    }
}
