using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Util.Auth.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1")]
    public class AgreementTemplateController : ControllerBase
    {
        private readonly ILogger<AgreementTemplateController> _logger;
        private readonly Repository.IUser _userRepository;
        private readonly Repository.ITenant _tenantRepository;
        private readonly Repository.IAgreementTemplate _agreementTemplateRepository;
        public AgreementTemplateController(ILogger<AgreementTemplateController> logger,
                                   Repository.IAgreementTemplate agreementTemplateRepository)
        {
            this._logger = logger;
            this._agreementTemplateRepository = agreementTemplateRepository;
        }

        [HttpGet]
        [Route("AgreementTemplates")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetAgreementTemplates()
        {
            if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var templates = await _agreementTemplateRepository.GetAll();
                return new ObjectResult(templates);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view agreement templates.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpPost]
        [Route("AgreementTemplate")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> UpdateAgreementTemplate(Entity.AgreementTemplate agreement)
        {
            if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var updatedTemplate = await _agreementTemplateRepository.UpdateAgreementTemplate(agreement);
                return new ObjectResult(updatedTemplate);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to update agreement templates.")
                                .Code(403)
                                .Build();
                return err;
            }
        }
    }
}

