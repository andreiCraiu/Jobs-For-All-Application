using JobsForAll.Contracts;
using JobsForAll.Library.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobsForAll.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly IUserService _userService;
        public RegisterUserController(IAuthService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterRequest registerRequest)
        {
            var registerServiceResult = await _authenticationService.RegisterUser(registerRequest);
            if (registerServiceResult.ResponseError != null)
            {
                return BadRequest(registerServiceResult.ResponseError);
            }

            return Ok(registerServiceResult.ResponseOk);
        }



        [Route("completeUserProfile/{email}")]
        [HttpPost]
        public async Task<ActionResult> CompleteUserProfile(CompleteUserProfile completeUserProfile, string email)
        {
            var user = _userService.GetUserByEmail(email).Result.ResponseOk;

            var isUserProfileCompletedResponse = _authenticationService.CompleteUserProfile(completeUserProfile, user);
            return isUserProfileCompletedResponse.Result.ResponseOk == true ? Ok(isUserProfileCompletedResponse.Result.ResponseOk) : BadRequest();
        }
    }
}
