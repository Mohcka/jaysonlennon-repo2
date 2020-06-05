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
        [Route("Tenants")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetTenants()
        {
            if (this.UserInRole(Role.Admin) || this.UserInRole(Role.Manager))
            {
                var tenants = await _tenantRepository.GetTenants();
                var tenantDTOs = new List<DTO.TenantInfoDTO>();

                foreach (var tenant in tenants)
                {
                    var unit = await _tenantRepository.UnitFromTenantId(tenant.TenantId);
                    var unitNumber = unit == null ? "" : unit.UnitNumber;
                    var tenantDTO = new DTO.TenantInfoDTO(tenant, unitNumber);
                    tenantDTOs.Add(tenantDTO);
                }

                return new ObjectResult(tenantDTOs);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                 .Message("You are not authorized to view tenant lists.")
                                 .Code(403)
                                 .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("Tenant/{tenantId}")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetTenantById(int tenantId)
        {
            if (this.UserInRole(Role.Admin) || this.UserInRole(Role.Manager))
            {
                var tenant = await _tenantRepository.TenantFromId(tenantId);
                if (tenant == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Tenant not found.")
                                    .Code(404)
                                    .Build();
                    return err;
                }

                var unit = await _tenantRepository.UnitFromTenantId(tenant.TenantId);
                var unitNumber = unit == null ? "" : unit.UnitNumber;
                var tenantDTO = new DTO.TenantInfoDTO(tenant, unitNumber);

                return new ObjectResult(tenantDTO);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                 .Message("You are not authorized to view tenants by ID.")
                                 .Code(403)
                                 .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("Tenant")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetTenant()
        {
            if (this.UserInRole(Role.Tenant))
            {
                var userId = this.UserIdFromApiKey();
                var tenant = await _tenantRepository.TenantFromUserId(userId);
                if (tenant == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not a tenant")
                                    .Code(400)
                                    .Build();
                    return err;
                }

                var unit = await _tenantRepository.UnitFromTenantId(tenant.TenantId);
                var unitNumber = unit == null ? "" : unit.UnitNumber;
                var tenantDTO = new DTO.TenantInfoDTO(tenant, unitNumber);
                return new ObjectResult(tenantDTO);
            }
            else if (this.UserInRole(Role.Admin) || this.UserInRole(Role.Manager))
            {
                var err = new DTO.ErrorBuilder()
                                 .Message("This route is for tenants only.")
                                 .Code(400)
                                 .Build();
                return new ObjectResult(err);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                 .Message("You are not authorized to view tenant info.")
                                 .Code(403)
                                 .Build();
                return new ObjectResult(err);

            }
        }


        [HttpPost]
        [Route("Tenant")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> UpdateTenantInfo(DTO.TenantInfoDTO info)
        {
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

                var unitNumber = await _tenantRepository.UnitFromTenantId((int)tenantId);
                if (unitNumber == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Not assigned to a unit")
                                    .Code(400)
                                    .Build();
                    return err;
                }

                // Prevent user from changing their own unit number.
                info.UnitNumber = unitNumber.UnitNumber;

                var tenant = await _tenantRepository.UpdateTenantInfo((int)tenantId, info);
                if (tenant == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Tenant already exists with that login information.")
                                    .Code(409)
                                    .Build();
                    return err;
                }
                return new ObjectResult(tenant);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var tenant = await _tenantRepository.UpdateTenantInfo(info.TenantId, info);
                if (tenant == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Tenant already exists with that login information.")
                                    .Code(409)
                                    .Build();
                    return err;
                }
                return new ObjectResult(tenant);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("Not authorized to edit tenant information.")
                                .Code(403)
                                .Build();
                return err;

            }

        }

    }
}