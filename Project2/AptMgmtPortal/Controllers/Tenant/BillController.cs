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
        private readonly Repository.ITenant TenantRepository;
        private readonly Repository.IMisc MiscRepository;

        public BillController(ILogger<BillController> logger,
                              Repository.ITenant tenantRepository,
                              Repository.IMisc miscRepository)
        {
            this._logger = logger;
            this.TenantRepository = tenantRepository;
            this.MiscRepository = miscRepository;
        }

        [HttpGet]
        [Route("Bills/{billingPeriodId}")]
        //[Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetBills(int billingPeriodId)
        {
            var bills = await TenantRepository.GetBills(0, billingPeriodId);
            return new ObjectResult(bills);
        }

        [HttpGet]
        [Route("Bill/{resourceType}")]
        //[Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetBills(ResourceType resource)
        {
            var billingPeriod = await MiscRepository.GetCurrentBillingPeriod();
            var bills = await TenantRepository.GetBill(0, resource, billingPeriod);
            return new ObjectResult(bills);
        }

        [HttpPost]
        [Route("Bill")]
        //[Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> PostBill(DataModel.PayBill bill)
        {
            var paid = await TenantRepository.PayBill(0, bill.Amount, bill.Resource, bill.BillingPeriodId);
            return new ObjectResult(paid);
        }
    }
}