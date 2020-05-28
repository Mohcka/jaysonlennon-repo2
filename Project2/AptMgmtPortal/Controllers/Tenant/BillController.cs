using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortal.Util.Auth;
using AptMgmtPortal.Types;

namespace AptMgmtPortal.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1/Tenant")]
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
        [Route("Bills/{billingPeriodId}")]
        //[Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetBills(int billingPeriodId)
        {
            var bills = await tenantRepository.GetBills(0, billingPeriodId);
            return new ObjectResult(bills);
        }
    }
}