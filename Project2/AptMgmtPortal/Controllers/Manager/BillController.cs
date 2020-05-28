using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortal.Util.Auth;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.Controllers.Manager
{
    [ApiController]
    [Route("api/v1/Manager/Bill")]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private readonly Repository.ITenant tenantRepository;

        public BillController(ILogger<BillController> logger, Repository.ITenant tenantRepository)
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

        [HttpGet]
        [Route("same")]
        [Authorize(Policy = Policies.OnlyManagers)]
        public async Task<IActionResult> PostTenantManager(TenantInfo info)
        {
            await tenantRepository.RestEdit(info);
            return new ObjectResult(info);
        }
    }
}