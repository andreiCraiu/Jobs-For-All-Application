
using FinalProjectApp.Data;
using FinalProjectApp.Models;
using FinalProjectApp.ViewModels;
using FinalProjectApp.ViewModels.Authentication;
using FinalProjectApp.ViewModels.Authenticatoin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
         ApplicationDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
        }


        [HttpGet]
        [Route("getCurrentUser")]
        public IActionResult GetCurrentUser()
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            if(user != null)
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