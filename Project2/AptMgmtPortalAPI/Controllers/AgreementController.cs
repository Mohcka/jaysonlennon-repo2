using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Util.Auth.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

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
                    _logger.LogWarning($"User {userId} attempted to access tenant information without being a tenant.");
                    return err;
                }

                var agreements = await _agreementRepository.GetAgreements((int)tenantId);

                return new ObjectResult(agreements);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var allAgreements = await _agreementRepository.GetAgreements();
                return new ObjectResult(allAgreements);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view agreements.")
                                .Code(403)
                                .Build();
                _logger.LogWarning($"Unauthorized access attempt to view agreements.");
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
                var agreements = await _agreementRepository.GetAgreements((int)tenantId);
                if (agreements.Count() == 0)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("No agreements located for that tenant.")
                                    .Code(404)
                                    .Build();
                    return err;
                }
                return new ObjectResult(agreements);
            }
            else if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var checkTenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (checkTenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("You are not a tenant of this property")
                                    .Code(403)
                                    .Build();
                    _logger.LogWarning($"Attempt by user {userId} to access tenant information without being a tenant.");
                    return err;
                }
                if ((int)checkTenantId != tenantId)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("No agreements found.")
                                    .Code(404)
                                    .Build();
                    return err;
                }

                var agreements = await _agreementRepository.GetAgreements(tenantId);
                return new ObjectResult(agreements);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to list agreements.")
                                .Code(403)
                                .Build();
                _logger.LogWarning($"Unauthorized access attempt to query agreements.");
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
                    _logger.LogWarning($"Attempt by user {userId} to access tenant information without being a tenant.");
                    return err;
                }

                var agreements = await _agreementRepository.GetAgreements((int)tenantId);
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

                return new ObjectResult(targetAgreement);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var agreement = await _agreementRepository.GetAgreement(agreementId);
                if (agreement == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Unable to find that agreement.")
                                    .Code(404)
                                    .Build();
                    return err;
                }
                return new ObjectResult(agreement);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view agreements.")
                                .Code(403)
                                .Build();
                _logger.LogWarning($"Unauthorized access attempt to query agreements.");
                return err;
            }
        }

        [HttpPost]
        [Route("Agreement")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> UpdateAgreement(Entity.Agreement newInfo)
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
                    _logger.LogWarning($"Attempt by user {userId} to access tenant information without being a tenant.");
                    return err;
                }

                var existingAgreement = await _agreementRepository.GetAgreement(newInfo.AgreementId);
                if (existingAgreement == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Agreement not found.(1)")
                                    .Code(404)
                                    .Build();
                    return err;
                }

                if (existingAgreement.TenantId != tenantId)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Agreement not found.(2)")
                                    .Code(404)
                                    .Build();
                    return err;
                }

                var updated = await _agreementRepository.UpdateAgreement(newInfo);

                return new ObjectResult(updated);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var updated = await _agreementRepository.UpdateAgreement(newInfo);
                if (updated == null) {
                var err = new DTO.ErrorBuilder()
                                .Message("An error occurred while updating the agreement.")
                                .Code(400)
                                .Build();
                    return err;
                }
                return new ObjectResult(updated);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to update agreements")
                                .Code(403)
                                .Build();
                _logger.LogWarning($"Unauthorized access attempt to update agreements.");
                return err;
            }
        }
    }
}
