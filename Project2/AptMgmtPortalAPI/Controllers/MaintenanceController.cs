using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Util.Auth.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1")]
    public class MaintenanceController : ControllerBase
    {
        private readonly ILogger<MaintenanceController> _logger;
        private readonly Repository.ITenant _tenantRepository;
        private readonly Repository.IUser _userRepository;
        private readonly Repository.IMaintenance _maintenanceRepository;

        public MaintenanceController(ILogger<MaintenanceController> logger,
                              Repository.ITenant tenantRepository,
                              Repository.IUser userRepository,
                              Repository.IMaintenance maintenanceRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
            this._userRepository = userRepository;
            this._maintenanceRepository = maintenanceRepository;
        }

        private async Task<List<DTO.MaintenanceRequestDTO>> MakeDTORequests(IEnumerable<Entity.MaintenanceRequest> requests)
        {
            var flatRequests = new List<DTO.MaintenanceRequestDTO>();

            foreach (var req in requests)
            {
                var flat = await DTO.MaintenanceRequestDTO.Build(req, _userRepository);
                flatRequests.Add(flat);
            }
            return flatRequests;
        }

        [HttpGet]
        [Route("Maintenance")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetMaintenanceRequests(int limit)
        {
            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant.")
                                    .Code(400)
                                    .Build();
                    return err;
                }
                var unit = await _tenantRepository.UnitFromTenantId((int)tenantId);
                if (unit == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Tenant not assigned a unit.")
                                    .Code(400)
                                    .Build();
                    return err;
                }

                var requests = await _maintenanceRepository.GetMaintenanceRequests(unit.UnitNumber);
                var requestDTOs = await MakeDTORequests(requests);
                return new ObjectResult(requestDTOs);

            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var requests = await _maintenanceRepository.GetMaintenanceRequests();
                var requestDTOs = await MakeDTORequests(requests);
                return new ObjectResult(requestDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to view maintenance requests.")
                                .Code(403)
                                .Build();
                _logger.LogWarning($"Unauthorized access attempt to view maintenance requests.");
                return err;
            }
        }

        [HttpPost]
        [Route("Maintenance")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> UpdateMaintenanceRequest(DataModel.MaintenanceRequestModel model)
        {
            var userId = this.UserIdFromApiKey();
            if (this.UserInRole(Role.Tenant))
            {
                var tenantId = await _tenantRepository.TenantIdFromUserId(userId);
                if (tenantId == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant.")
                                    .Code(400)
                                    .Build();
                    return err;
                }

                var unit = await _tenantRepository.UnitFromTenantId((int)tenantId);
                if (unit == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Tenant not assigned a unit.")
                                    .Code(400)
                                    .Build();
                    return err;
                }

                // Set the unit number to the tenant's unit number so they cannot schedule maintenance for other
                // tenants.
                model.UnitNumber = unit.UnitNumber;

                var existingRequest = await _maintenanceRepository.GetMaintenanceRequest(model.MaintenanceRequestId);
                if (existingRequest != null)
                {
                    if (existingRequest.UnitNumber == unit.UnitNumber)
                    {
                        existingRequest = await _maintenanceRepository.UpdateMaintenanceRequest(existingRequest, model, userId);
                        var flatRequest = await DTO.MaintenanceRequestDTO.Build(existingRequest, _userRepository);
                        return new ObjectResult(flatRequest);
                    }
                    else
                    {
                        var err = new DTO.ErrorBuilder()
                                        .Message("Maintenance request does not exist for provided unit number.")
                                        .Code(404)
                                        .Build();
                        return err;
                    }
                }
                else
                {
                    var newRequest = await _maintenanceRepository.OpenMaintenanceRequest(userId, model);
                    var flatRequest = await DTO.MaintenanceRequestDTO.Build(newRequest, _userRepository);
                    return new ObjectResult(flatRequest);
                }
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var existingRequest = await _maintenanceRepository.GetMaintenanceRequest(model.MaintenanceRequestId);
                if (existingRequest != null)
                {
                    existingRequest = await _maintenanceRepository.UpdateMaintenanceRequest(existingRequest, model, userId);
                    var flatRequest = await DTO.MaintenanceRequestDTO.Build(existingRequest, _userRepository);
                    return new ObjectResult(flatRequest);
                }
                else
                {
                    var newRequest = await _maintenanceRepository.OpenMaintenanceRequest(userId, model);
                    var flatRequest = await DTO.MaintenanceRequestDTO.Build(newRequest, _userRepository);
                    return new ObjectResult(flatRequest);
                }
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You are not authorized to make maintenance requests.")
                                .Code(403)
                                .Build();
                _logger.LogWarning($"Unauthorized access attempt to make maintenance requests.");
                return err;
            }
        }
    }
}