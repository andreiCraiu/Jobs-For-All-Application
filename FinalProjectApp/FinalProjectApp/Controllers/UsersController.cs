using JobsForAll.Contracts;
using JobsForAll.Library.Contracts;
using JobsForAll.Library.Models;
using JobsForAll.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace JobsForAll.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IRepository repository,
            IConfiguration configuration,
            IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.repository = repository;
            this.configuration = configuration;
            this.userService = userService;
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public IActionResult GetUser(string id)
        {
            var user = repository.GetApplicationUsers(id);
            if (user != null)
                return Ok(user);
            return BadRequest();
        }

        [HttpGet]
        [Route("getCurrentUser")]
        public IActionResult GetCurrentUser()
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            if (user != null)
                return Ok(user);
            return BadRequest();
        }

        [HttpGet]
        [Route("getFilteredUsers/{filterString}")]
        public IActionResult FilterUsesr(string filterString)
        {
            var users = userService.FilterUsers(filterString).Result.ResponseOk;
            if (users != null)
                return Ok(users);
            return BadRequest();
        }

        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = userService.GetAllUsers().Result.ResponseOk;
            if (users != null)
                return Ok(users);
            return BadRequest();
        }

        [HttpGet]
        [Route("getUserByEmail/{email}")]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            var user = repository.GetUserByEmail(email);
            if (user != null)
                return Ok(user);
            return BadRequest();
        }

        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult DeleteUSer()
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            if (user == null)
                return BadRequest();

            repository.RemoveUser(user);
            return Ok(user);
        }

        [Route("updateUserProfile")]
        [HttpPost]
        public async Task<ActionResult> UpdateUser(UpdateUser updateUser)
        {
            var user = (ApplicationUser)HttpContext.Items["User"];


            if (user != null)
            {
                user.PhoneNumber = updateUser.PhoneNumber;
                user.Address = updateUser.Address;
                user.UserName = updateUser.FirstName + " " + updateUser.LastName;
                user.Address = updateUser.Address;
                user.Postcode = updateUser.Postcode;

                //todo: repository.Entry(user).State = EntityState.Modified;

                await repository.SaveUserChangesAsync(user);
                //todo: sa fie serviciu->baza de date
                return Ok();
            }
            return BadRequest();
        }

        //

        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repository;
        private readonly IConfiguration configuration;
        private readonly IUserService userService;
    }
}