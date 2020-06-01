using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.Util.Auth.Extensions;
using System.Collections.Generic;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1/Tenant")]
    public class MaintenanceController : ControllerBase
    {
        private readonly ILogger<MaintenanceController> _logger;
        private readonly Repository.ITenant _tenantRepository;
        private readonly Repository.IMisc _miscRepository;
        private readonly Repository.IUser _userRepository;

        public MaintenanceController(ILogger<MaintenanceController> logger,
                              Repository.ITenant tenantRepository,
                              Repository.IMisc miscRepository,
                              Repository.IUser userRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
            this._miscRepository = miscRepository;
            this._userRepository = userRepository;
        }

        [HttpGet]
        [Route("Maintenance")]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> GetMaintenanceRequests(int limit)
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

            var requests = await _tenantRepository.GetMaintenanceRequests(userId, limit);
            var flatRequests = new List<DTO.MaintenanceRequestDTO>();

            foreach(var req in requests) {
                var flat = await DTO.MaintenanceRequestDTO.Build(req, _userRepository);
                flatRequests.Add(flat);
            }

            return new ObjectResult(flatRequests);
        }

        [HttpPost]
        [Route("Maintenance")]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> UpdateMaintenanceRequest(DataModel.MaintenanceRequestModel maintenanceRequestModel)
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

            var requestFromDb = await _tenantRepository.GetMaintenanceRequest(maintenanceRequestModel.MaintenanceRequestId);
            var updatedRequest = await _tenantRepository.UpdateMaintenanceRequest(requestFromDb, maintenanceRequestModel, userId);

            var flatRequest = await DTO.MaintenanceRequestDTO.Build(updatedRequest, _userRepository);

            return new ObjectResult(flatRequest);
        }

        [HttpPut]
        [Route("Maintenance")]
        [Authorize(Policy = Policies.OnlyTenants)]
        public async Task<IActionResult> CreateMaintenanceRequest(DataModel.MaintenanceRequestCreateModel model)
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

            var unitNumber = await _tenantRepository.GetUnitNumber((int)tenantId);

            var newRequest = await _tenantRepository.OpenMaintenanceRequest(userId,
                model.MaintenanceRequestType,
                model.OpenNotes,
                unitNumber);

            var flatRequest = await DTO.MaintenanceRequestDTO.Build(newRequest, _userRepository);

            return new ObjectResult(flatRequest);
        }
    }
}