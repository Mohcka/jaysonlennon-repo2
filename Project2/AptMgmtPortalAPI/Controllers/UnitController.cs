using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Util.Auth.Extensions;
using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Types;
using System.Collections.Generic;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1")]
    public class UnitController : ControllerBase
    {
        private readonly ILogger<UnitController> _logger;
        private readonly Repository.ITenant _tenantRepository;

        public UnitController(ILogger<UnitController> logger, Repository.ITenant tenantRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
        }

        [HttpGet]
        [Route("Units")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetUnits()
        {
            if (this.UserInRole(Role.Admin) || this.UserInRole(Role.Manager))
            {
                var units = await _tenantRepository.GetUnits();
                return new ObjectResult(units);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                 .Message("You are not authorized to view units.")
                                 .Code(403)
                                 .Build();
                return err;
            }
        }

        [HttpGet]
        [Route("Unit")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetUnitById(int unitId)
        {
            if (this.UserInRole(Role.Admin) || this.UserInRole(Role.Manager))
            {
                var unit = await _tenantRepository.GetUnit(unitId);
                if (unit == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Unit not found.")
                                    .Code(404)
                                    .Build();
                    return err;
                }

                return new ObjectResult(unit);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                 .Message("You are not authorized to query units.")
                                 .Code(403)
                                 .Build();
                return err;
            }
        }

        [HttpPost]
        [Route("Unit")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> UpdateUnit(Entity.Unit unit)
        {
            if (this.UserInRole(Role.Admin) || this.UserInRole(Role.Manager))
            {
                var updatedUnit = await _tenantRepository.UpdateUnit(unit);
                return new ObjectResult(updatedUnit);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                 .Message("You are not authorized to update units.")
                                 .Code(403)
                                 .Build();
                return new ObjectResult(err);

            }
        }

        [HttpDelete]
        [Route("Unit")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> DeleteUnit(int unitId) 
        {
            if (this.UserInRole(Role.Admin) || this.UserInRole(Role.Manager)) 
            {
                var unit = await _tenantRepository.GetUnit(unitId);
                if (unit == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Unit not found.")
                                    .Code(404)
                                    .Build();
                    return err;
                }
                var deleted = _tenantRepository.DeleteUnit(unitId);
                return new ObjectResult(deleted);
            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                 .Message("You are not authorized to query units.")
                                 .Code(403)
                                 .Build();
                return err;
            }
        }
    }
}