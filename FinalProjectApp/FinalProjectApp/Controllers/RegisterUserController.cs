using AutoMapper.Configuration;
using FinalProjectApp.Data;
using FinalProjectApp.Models;
using FinalProjectApp.ViewModels.Authentication;
using FinalProjectApp.ViewModels.Authenticatoin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
         ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _httpContextAccessor = accessor;
       
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterRequest registeRequest)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }



        [Route("completeUserProfile")]
        [HttpPost]
        public async Task<ActionResult> CompleteUserProfile(CompleteUserProfile completeUserProfile)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            var userId = _httpContextAccessor.HttpContext.User;
            if (completeUserProfile == null)
            {
                return BadRequest();
            }

            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
