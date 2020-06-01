using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Util.Auth.Extensions;
using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Controllers.Tenant
{
    [ApiController]
    [Route("api/v1")]
    public class AgreementController : ControllerBase
    {
        private readonly ILogger<AgreementController> _logger;
        private readonly Repository.IUser _userRepository;
        private readonly Repository.ITenant _tenantRepository;
        public AgreementController(ILogger<AgreementController> logger,
                                   Repository.IUser userRepository,
                                   Repository.ITenant tenantRepository)
        {
            this._logger = logger;
            this._userRepository = userRepository;
            this._tenantRepository = tenantRepository;
        }

        [HttpGet]
        [Route("Agreements")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetAgreements()
        {
            var userId = this.UserIdFromApiKey();
            var user = await _userRepository.UserFromId(userId);
            if (user == null)
            {
                var err = new DTO.ErrorBuilder()
                                 .Message("Not a user")
                                 .Code(400)
                                 .Build();
                return err;
            }

            var userDTO = new DTO.UserDTO(user);

            return new ObjectResult(userDTO);
        }

        [HttpPost]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> SetUserInfo(DTO.UserDTO userInfo)
        {
            if (this.HttpContext.User.IsInRole(Role.Manager))
            {
                if (userInfo.UserAccountType == UserAccountType.Admin)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("You do not have the proper authorization to edit Admin user accounts.")
                                    .Code(403)
                                    .Build();
                    return err;
                }
            }
            else if (this.HttpContext.User.IsInRole(Role.Tenant))
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You do not have the proper authorization to edit user accounts.")
                                .Code(403)
                                .Build();
                return err;
            }

            var user = await _userRepository.UpdateUserInfo(userInfo);

            var userDTO = new DTO.UserDTO(user);

            return new ObjectResult(userDTO);
        }
    }
}
