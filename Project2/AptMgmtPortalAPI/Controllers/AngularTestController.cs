using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Util.Auth.Extensions;
using System;
using System.Threading.Tasks;

namespace AptMgmtPortalAPI.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AngularTestController : ControllerBase
    {
        private readonly ILogger<AngularTestController> _logger;
        private readonly Repository.ITenant _tenantRepository;
        public AngularTestController(ILogger<AngularTestController> logger,
                                      Repository.ITenant tenantRepository)
        {
            this._logger = logger;
            this._tenantRepository = tenantRepository;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Test(string data)
        {
            var sample = new {
                Message = "hi",
            };
            _logger.LogCritical("API hit");
            return new JsonResult(sample);
        }
    }
}

