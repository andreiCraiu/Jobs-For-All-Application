using JobsForAll.Application.Interfaces;
using JobsForAll.Data.Context;
using JobsForAll.Domain.Models;
using JobsForAll.Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace JobsForAll.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
         ApplicationDbContext context, IConfiguration configuration, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet]
        [Route("getUser/{id}")]
        public IActionResult GetUser(string id)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(user => user.Id == id);
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
            var users = _userService.FilterUsers(filterString).Result.ResponseOk;
            if (users != null)
                return Ok(users);
            return BadRequest();
        }

        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers().Result.ResponseOk;
            if (users != null)
                return Ok(users);
            return BadRequest();
        }

        [HttpGet]
        [Route("getUserByEmail/{email}")]
        public async Task<ActionResult> GetUserByEmail(string email)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(user => user.Email == email);

            if (user != null)
                return Ok(user);
            return BadRequest();
        }

        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult DeleteUSer()
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            if (user != null)
                return Ok(user);
            return BadRequest();

            _context.Remove(user);
            _context.SaveChanges();
            return Ok();
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

                _context.Entry(user).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
            if (updateUser == null)
            {
                return BadRequest();
            }
        }
    }


}