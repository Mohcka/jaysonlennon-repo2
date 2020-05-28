using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AptMgmtPortal.Util.Auth;

namespace AptMgmtPortal.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorizationTestController : ControllerBase
    {
        private readonly ILogger<AuthorizationTestController> _logger;
        public AuthorizationTestController(ILogger<AuthorizationTestController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        [Route("Anyone")]
        public IActionResult Anyone()
        {
            _logger.LogInformation("hello anyone");
            var message = $"Hello from anyone";
            return new ObjectResult(message);
        }

        [HttpGet]
        [Route("Tenants")]
        [Authorize(Policy = Policies.OnlyTenants)]
        public IActionResult OnlyTenants()
        {
            var message = $"Hello from only tenants";
            return new ObjectResult(message);
        }

        [HttpGet]
        [Route("Manager")]
        [Authorize(Policy = Policies.OnlyManagers)]
        public IActionResult OnlyManagers()
        {
            var message = $"Hello from only managers";
            return new ObjectResult(message);
        }

        [HttpGet]
        [Route("Admins")]
        [Authorize(Policy = Policies.OnlyAdmins)]
        public IActionResult OnlyAdmins()
        {
            var message = $"Hello from only admins";
            return new ObjectResult(message);
        }
    }
}