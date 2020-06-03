using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Util.Auth.Extensions;
using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1")]
    public class AgreementController : ControllerBase
    {
        private readonly ILogger<AgreementController> _logger;
        private readonly Repository.IUser _userRepository;
        private readonly Repository.ITenant _tenantRepository;
        private readonly Repository.IAgreement _agreementRepository;
        public AgreementController(ILogger<AgreementController> logger,
                                   Repository.IUser userRepository,
                                   Repository.ITenant tenantRepository,
                                   Repository.IAgreement agreementRepository)
        {
            this._logger = logger;
            this._userRepository = userRepository;
            this._tenantRepository = tenantRepository;
            this._agreementRepository = agreementRepository;
        }

        [HttpGet]
        [Route("AgreementTemplates")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetAgreementTemplates()
        {
            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("You are not a tenant of this property")
                                    .Code(403)
                                    .Build();
                    return err;
                }
                var allAgreements = await _agreementRepository.GetAllAgreements();
                return new ObjectResult(allAgreements);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var allAgreements = await _agreementRepository.GetAllAgreements();
                return new ObjectResult(allAgreements);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view agreements.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpPost]
        [Route("AgreementTemplate")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> UpdateAgreementTemplate(Entity.Agreement agreement)
        {
            if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var updatedAgreement = await _agreementRepository.UpdateAgreementTemplate(agreement);
                return new ObjectResult(updatedAgreement);
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

        [HttpGet]
        [Route("Agreements")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetAgreements()
        {
            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("You are not a tenant of this property")
                                    .Code(403)
                                    .Build();
                    return err;
                }

                var agreements = await _agreementRepository.GetSignedAgreements((int)tenantId);
                var agreementDTOs = agreements.Select(a => new DTO.AgreementDTO(a)).ToList();

                return new ObjectResult(agreementDTOs);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var allAgreements = await _agreementRepository.GetAllSignedAgreements();
                return new ObjectResult(allAgreements);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view agreements.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("Agreements/{tenantId}")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetAgreementsByTenant(int tenantId)
        {
            if (this.UserInRole(Role.Admin) || this.UserInRole(Role.Manager))
            {
                var agreements = await _agreementRepository.GetSignedAgreements((int)tenantId);
                if (agreements.Count() == 0)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("No agreements located for that tenant.")
                                    .Code(404)
                                    .Build();
                    return err;
                }
                var agreementDTOs = agreements.Select(a => new DTO.AgreementDTO(a)).ToList();
                return new ObjectResult(agreementDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to list agreements.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("Agreement/{agreementId}")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetAgreement(int agreementId)
        {
            var userId = this.UserIdFromApiKey();

            // Handle agreement query by tenant.
            if (this.UserInRole(Role.Tenant))
            {
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("You are not a tenant of this property.")
                                    .Code(403)
                                    .Build();
                    return err;
                }

                var agreements = await _agreementRepository.GetSignedAgreements((int)tenantId);
                // TODO: make this less terrible
                var targetAgreement = agreements.Where(a => a.AgreementId == agreementId).FirstOrDefault();
                if (targetAgreement == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Unable to find that agreement.")
                                    .Code(404)
                                    .Build();
                    return err;
                }

                var targetAgreementAsDTO = new DTO.AgreementDTO(targetAgreement);
                return new ObjectResult(targetAgreementAsDTO);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var agreement = await _agreementRepository.GetSignedAgreement(agreementId);
                if (agreement == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Unable to find that agreement.")
                                    .Code(404)
                                    .Build();
                    return err;
                }
                var agreementAsDTO = new DTO.AgreementDTO(agreement);
                return new ObjectResult(agreementAsDTO);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view agreements.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpPost]
        [Route("Agreement")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> SignAgreement(DTO.SignAgreementDTO signAgreement)
        {
            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("You are not a tenant of this property.")
                                    .Code(403)
                                    .Build();
                    return err;
                }

                var agreement = await _agreementRepository.SignAgreement((int)tenantId,
                    signAgreement.AgreementId,
                    signAgreement.StartDate,
                    signAgreement.EndDate);

                if (agreement == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Unable to find that agreement id.")
                                    .Code(404)
                                    .Build();
                    return err;
                }
                else
                {
                    var agreementDTO = new DTO.AgreementDTO(agreement);
                    return new ObjectResult(agreementDTO);
                }
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("Only tenants may sign agreements.")
                                .Code(400)
                                .Build();
                return err;
            }
        }
    }
}
