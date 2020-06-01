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
    [Route("api/v1/User")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly Repository.IUser _userRepository;
        public UserController(ILogger<UserController> logger, Repository.IUser userRepository)
        {
            this._logger = logger;
            this._userRepository = userRepository;
        }

        [HttpGet]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetUserInfo()
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
