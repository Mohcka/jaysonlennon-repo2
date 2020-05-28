using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AptMgmtPortal.Util.Auth;
using AptMgmtPortal.Util.Auth.Extensions;
using System;
using System.Threading.Tasks;

namespace AptMgmtPortal.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class DatabaseTestController : ControllerBase
    {
        private readonly ILogger<DatabaseTestController> _logger;
        private readonly Repository.ITenant _tenantRepository;
        public DatabaseTestController(ILogger<DatabaseTestController> logger,
                                      Repository.ITenant tenantRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
        }

        [HttpPost]
        [Route("put")]
        public async Task<IActionResult> NewData(string data)
        {
            var info = new Types.TenantInfo();
            info.FirstName = data;
            var added = await _tenantRepository.AddTenant(info);
            if (added != null)
            {
                _logger.LogDebug("added data '{data}'");
            }
            else
            {

                _logger.LogDebug("failed to add new data");
            }
            return new ObjectResult(true);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetData(string data)
        {
            var tenants = await _tenantRepository.FindTenantWithFirstName(data);
            foreach (var tenant in tenants)
            {
                _logger.LogDebug($"located tenant: {tenant.FirstName}");
            }
            return new ObjectResult(tenants);
        }
    }
}

