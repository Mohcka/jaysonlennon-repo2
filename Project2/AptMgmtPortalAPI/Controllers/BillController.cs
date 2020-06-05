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
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private readonly Repository.ITenant _tenantRepository;
        private readonly Repository.IBill _billRepository;

        public BillController(ILogger<BillController> logger,
                              Repository.ITenant tenantRepository,
                              Repository.IBill billRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
            this._billRepository = billRepository;
        }

        [HttpGet]
        [Route("Bills")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetBillsInCurrentPeriod()
        {
            var currentBillingPeriod = await _billRepository.GetCurrentBillingPeriod();
            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }
                var bills = await _billRepository.GetBills((int)tenantId, currentBillingPeriod);
                var billDTOs = bills.Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var bills = await _billRepository.GetBills(currentBillingPeriod);
                var billDTOs = bills.Select(b => new DTO.BillDTO(b)).ToList();
                return new ObjectResult(billDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view billing information.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("Bills/{billingPeriodId}")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetBillsByPeriod(int billingPeriodId)
        {
            var billingPeriod = await _billRepository.BillingPeriodFromId(billingPeriodId);
            if (billingPeriod == null)
            {
                var err = new DTO.ErrorBuilder()
                                .Message("Billing period not found.")
                                .Code(404)
                                .Build();
                return err;
            }

            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }
                var bills = await _billRepository.GetBills((int)tenantId, billingPeriod);
                var billDTOs = bills.Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var bills = await _billRepository.GetBills(billingPeriod);
                var billDTOs = bills.Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view billing information.")
                                .Code(403)
                                .Build();
                return err;
            }
        }


        [HttpGet]
        [Route("Bills/Unpaid")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetUnpaidBillsInCurrentPeriod()
        {
            var currentBillingPeriod = await _billRepository.GetCurrentBillingPeriod();
            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }
                var bills = await _billRepository.GetBills((int)tenantId, currentBillingPeriod);
                var billDTOs = bills
                    .Where(b => b.Owed() > 0)
                    .Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var bills = await _billRepository.GetBills(currentBillingPeriod);
                var billDTOs = bills
                    .Where(b => b.Owed() > 0)
                    .Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view billing information.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("Bills/Paid")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetPaidBillsInCurrentPeriod()
        {
            var currentBillingPeriod = await _billRepository.GetCurrentBillingPeriod();

            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }
                var bills = await _billRepository.GetBills((int)tenantId, currentBillingPeriod);
                var billDTOs = bills
                    .Where(b => b.Owed() <= 0)
                    .Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var bills = await _billRepository.GetBills(currentBillingPeriod);
                var billDTOs = bills
                    .Where(b => b.Owed() <= 0)
                    .Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view billing information.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("Bills/Unpaid/{billingPeriodId}")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetUnpaidBillsInPeriod(int billingPeriodId)
        {
            var billingPeriod = await _billRepository.BillingPeriodFromId(billingPeriodId);
            if (billingPeriod == null)
            {
                var err = new DTO.ErrorBuilder()
                                .Message("Billing period not found.")
                                .Code(404)
                                .Build();
                return err;
            }

            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }
                var bills = await _billRepository.GetBills((int)tenantId, billingPeriod);
                var billDTOs = bills
                    .Where(b => b.Owed() > 0)
                    .Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var bills = await _billRepository.GetBills(billingPeriod);
                var billDTOs = bills
                    .Where(b => b.Owed() > 0)
                    .Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view billing information.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("Bills/Paid/{billingPeriodId}")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetPaidBillsInPeriod(int billingPeriodId)
        {
            var billingPeriod = await _billRepository.BillingPeriodFromId(billingPeriodId);
            if (billingPeriod == null)
            {
                var err = new DTO.ErrorBuilder()
                                .Message("Billing period not found.")
                                .Code(404)
                                .Build();
                return err;
            }

            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }
                var bills = await _billRepository.GetBills((int)tenantId, billingPeriod);
                var billDTOs = bills
                    .Where(b => b.Owed() <= 0)
                    .Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var bills = await _billRepository.GetBills(billingPeriod);
                var billDTOs = bills
                    .Where(b => b.Owed() <= 0)
                    .Select(b => new DTO.BillDTO(b)).ToList();

                return new ObjectResult(billDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view billing information.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpPost]
        [Route("Bill")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> PostBill(DataModel.PayBill bill)
        {
            var billingPeriod = await _billRepository.BillingPeriodFromId(bill.BillingPeriodId);
            if (billingPeriod == null)
            {
                var err = new DTO.ErrorBuilder()
                                .Message("Billing period not found.")
                                .Code(404)
                                .Build();
                return err;
            }

            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }

                var paid = await _billRepository.PayBill((int)tenantId, bill.Amount, bill.Resource, bill.BillingPeriodId);
                var flatBill = new DTO.BillDTO(paid);
                return new ObjectResult(flatBill);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var paid = await _billRepository.PayBill(bill.TenantId, bill.Amount, bill.Resource, bill.BillingPeriodId);
                var flatBill = new DTO.BillDTO(paid);
                return new ObjectResult(flatBill);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to make bill payments.")
                                .Code(403)
                                .Build();
                return err;
            }
        }
    }
}