using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.Util.Auth.Extensions;
using System.Linq;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1/Tenant")]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private readonly Repository.ITenant _tenantRepository;
        private readonly Repository.IMisc _miscRepository;

        public BillController(ILogger<BillController> logger,
                              Repository.ITenant tenantRepository,
                              Repository.IMisc miscRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
            this._miscRepository = miscRepository;
        }

        [HttpGet]
        [Route("Bills")]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetBillsInCurrentPeriod()
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
            var currentBillingPeriod = await _miscRepository.GetCurrentBillingPeriod();
            var bills = await _tenantRepository.GetBills((int)tenantId, currentBillingPeriod);
            var flatBills = bills.Select(b => new DTO.FlatBill(b)).ToList();

            return new ObjectResult(flatBills);
        }

        [HttpGet]
        [Route("Bills/{billingPeriodId}")]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetBillsByPeriod(int billingPeriodId)
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
            var bills = await _tenantRepository.GetBills((int)tenantId, billingPeriodId);
            var flatBills = bills.Select(b => new DTO.FlatBill(b)).ToList();
            return new ObjectResult(bills);
        }

        [HttpGet]
        [Route("Bill/Resource")]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetBillsByResource(ResourceType resource)
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

            var billingPeriod = await _miscRepository.GetCurrentBillingPeriod();
            var bill = await _tenantRepository.GetBill((int)tenantId, resource, billingPeriod);
            var flatBill = new DTO.FlatBill(bill);

            return new ObjectResult(flatBill);
        }

        [HttpPost]
        [Route("Bill")]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> PostBill(DataModel.PayBill bill)
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

            var paid = await _tenantRepository.PayBill((int)tenantId, bill.Amount, bill.Resource, bill.BillingPeriodId);

            var billingPeriod = await _miscRepository.BillingPeriodFromId(bill.BillingPeriodId);

            var newBill = await _tenantRepository.GetBill((int)tenantId, bill.Resource, billingPeriod);
            var flatBill = new DTO.FlatBill(newBill);

            return new ObjectResult(flatBill);
        }
    }
}