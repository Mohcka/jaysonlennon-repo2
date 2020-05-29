using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1/Tenant/Tenant")]
    public class TenantController : ControllerBase
    {
        private readonly ILogger<TenantController> _logger;
        private readonly Repository.ITenant tenantRepository;

        public TenantController(ILogger<TenantController> logger, Repository.ITenant tenantRepository)
        {
            this._logger = logger;
            this.tenantRepository = tenantRepository;
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetTenant(int id)
        {
            var tenant = await tenantRepository.TenantFromId(id);
            return new ObjectResult(tenant);
        }

        [HttpPost]
        //[Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> PostTenant(TenantInfo info)
        {
            await tenantRepository.RestEdit(info);
            return new ObjectResult(info);
        }

        [HttpGet]
        [Route("/agreement/{id}")]
        public async Task<IActionResult> ShowTenantAgreements(int id)
        {
            var agreement = await tenantRepository.GetAgreements(id);
            return new ObjectResult(agreement);
        }
    }
}