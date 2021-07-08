using AutoMapper.Configuration;
using FinalProjectApp.Data;
using FinalProjectApp.Models;
using FinalProjectApp.ViewModels.Authentication;
using FinalProjectApp.ViewModels.Authenticatoin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var user = new ApplicationUser
            {
                Email = registeRequest.Email,
                UserName = registeRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, registeRequest.Password);

            if (result.Succeeded)
            {
                return Ok(new RegisterResponse { ConfirmationToken = user.SecurityStamp });
            }

            return BadRequest();
        }



        [Route("completeUserProfile")]
        [HttpPost]
        public async Task<ActionResult> CompleteUserProfile(CompleteUserProfile completeUserProfile)
        {
            var user = (ApplicationUser)HttpContext.Items["User"];


            if (user != null)
            {
                user.PhoneNumber = completeUserProfile.PhoneNumber;
                user.Address = completeUserProfile.Address;
                user.Postcode = completeUserProfile.PostCode;
                user.Profession = completeUserProfile.MainProfession + "Secundary: " + completeUserProfile.SecundaryProfession;
                user.Details = "Like: " + completeUserProfile.Hobby + ", " + completeUserProfile.FunFact;

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
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
