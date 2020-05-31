using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.Util.Auth.Extensions;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1/Tenant")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository.ITenant _tenantRepository;
        private readonly Repository.IMisc _miscRepository;

        public HomeController(ILogger<HomeController> logger,
                              Repository.ITenant tenantRepository,
                              Repository.IMisc miscRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
            this._miscRepository = miscRepository;
        }

        [HttpGet]
        [Route("Home")]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetBills()
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

            var rentDueDate = _tenantRepository.GetBill((int)tenantId, ResourceType.Rent, currentBillingPeriod);

            return new ObjectResult(rentDueDate);
        }
    }
}