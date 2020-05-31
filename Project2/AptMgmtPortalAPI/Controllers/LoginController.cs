using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using AptMgmtPortalAPI.Util.Auth;
using AptMgmtPortalAPI.Types;

namespace AptMgmtPortalAPI.Controllers.User
{
    [ApiController]
    [Route("/api/v1/Login")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly Repository.IUser _userRepository;
        private readonly Repository.ITenant _tenantRepository;

        public LoginController(ILogger<LoginController> logger,
                              Repository.IUser userRepository,
                              Repository.ITenant tenantRepository)
        {
            this._logger = logger;
            this._userRepository = userRepository;
            this._tenantRepository = tenantRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(DataModel.Login loginInfo)
        {
            var user = await _userRepository.Login(loginInfo.UserName, loginInfo.Password);

            if (user != null) {
                var loginOkDTO = new DTO.LoginOk(user);
                return new ObjectResult(loginOkDTO);
            } else {
                var error = new DTO.ErrorBuilder()
                                   .Message("Invalid credentials")
                                   .Code(401)
                                   .Build();
                return error;
            }
        }
    }
}