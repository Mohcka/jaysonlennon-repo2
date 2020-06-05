using AptMgmtPortalAPI.Types;
using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Util.Auth.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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

            var userDTO = new DTO.UserDTO(user);

            return new ObjectResult(userDTO);
        }

        [HttpGet]
        [Route("{userId}")]
        [Authorize(Policy = Policies.AnyLoggedIn)]
        public async Task<IActionResult> GetSpecificUserInfo(int userId)
        {
            if (this.HttpContext.User.IsInRole(Role.Admin) || this.HttpContext.User.IsInRole(Role.Manager))
            {
                var thisUserId = this.UserIdFromApiKey();

                var user = await _userRepository.UserFromId(userId);
                if (user == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("No user found with that ID")
                                    .Code(400)
                                    .Build();
                    return err;
                }

                var userDTO = new DTO.UserDTO(user);
                return new ObjectResult(userDTO);

            }
            else
            {
                var err = new DTO.ErrorBuilder()
                                .Message("You do not have the proper authorization to view user accounts.")
                                .Code(403)
                                .Build();
                return err;
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetUserInfo(DTO.UserDTO userInfo)
        {
            // When user already logged in...
            if (this.UserInRole(Role.Tenant))
            {
                var thisUserId = this.UserIdFromApiKey();
                // Ensure a tenant cannot updated information for another user.
                userInfo.UserId = thisUserId;

                var updatedUser = await _userRepository.UpdateUserInfo(userInfo);
                if (updatedUser == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("User already exists with that login information or user not found.")
                                    .Code(409)
                                    .Build();
                    return err;
                }
                return new ObjectResult(updatedUser);
            }
            else if (this.UserInRole(Role.Manager) || this.UserInRole(Role.Admin))
            {
                var updatedUser = await _userRepository.UpdateUserInfo(userInfo);
                if (updatedUser == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("User already exists with that login information or user not found.")
                                    .Code(409)
                                    .Build();
                    return err;
                }
                return new ObjectResult(updatedUser);
            }
            else
            {
                userInfo.UserAccountType = UserAccountType.Tenant;
                var newUser = await _userRepository.TryCreateAccount(userInfo);
                if (newUser == null)
                {
                    var err = new DTO.ErrorBuilder()
                                    .Message("Unable to create account, tenant information not found or already exists.")
                                    .Code(404)
                                    .Build();
                    return err;
                }
                newUser.Password = "(hashed)";
                return new ObjectResult(newUser);
            }
        }
    }
}
