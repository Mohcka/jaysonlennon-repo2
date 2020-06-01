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
    [Route("api/v1/Tenant/Tenant")]
    public class TenantController : ControllerBase
    {
        private readonly ILogger<TenantController> _logger;
        private readonly Repository.ITenant _tenantRepository;

        public TenantController(ILogger<TenantController> logger, Repository.ITenant tenantRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
        }

        [HttpGet]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetTenantInfo()
        {
            var userId = this.UserIdFromApiKey();
            var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
            if (tenantId == null) {
                var err = new DTO.ErrorBuilder()
                                 .Message("Not a tenant")
                                 .Code(400)
                                 .Build();
                return err;
            }

            var tenant = await _tenantRepository.TenantFromId(userId);
            var unitNumber = await _tenantRepository.GetUnitNumber((int)tenantId);

            var tenantInfo = new DTO.TenantInfoDTO(tenant, unitNumber);

            return new ObjectResult(tenantInfo);
        }

        [HttpPost]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> UpdateTenantInfo(DTO.TenantInfoDTO info)
        {
            var userId = this.UserIdFromApiKey();
            var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
            if (tenantId == null) {
                var err = new DTO.ErrorBuilder()
                                 .Message("Not a tenant")
                                 .Code(400)
                                 .Build();
                return err;
            }

            var tenant = await _tenantRepository.UpdateTenantInfo((int)tenantId, info);
            var unitNumber = await _tenantRepository.GetUnitNumber((int)tenantId);

            var tenantInfo = new DTO.TenantInfoDTO(tenant, unitNumber);

            return new ObjectResult(tenantInfo);
        }
    }
}