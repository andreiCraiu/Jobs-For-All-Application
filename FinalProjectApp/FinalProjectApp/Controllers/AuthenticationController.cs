﻿
using FinalProjectApp.Data;
using FinalProjectApp.Models;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
         ApplicationDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("confirm")]
        public async Task<ActionResult> ConfirmUser(ConfirmUserRequest confirmUserRequest)
        {
            var toConfirm = _context.ApplicationUsers.Where(u => u.Email == confirmUserRequest.Email
                                && u.SecurityStamp == confirmUserRequest.ConfirmationToken).FirstOrDefault();

            if (toConfirm != null)
            {
                toConfirm.EmailConfirmed = true;
                _context.Entry(toConfirm).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

                var signinKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expirationInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiriyMinutes"]);
                var token = new JwtSecurityToken(
                 issuer: _configuration["Jwt:Site"],
                 audience: _configuration["Jwt:Site"],
                 expires: DateTime.UtcNow.AddMinutes(expirationInMinutes),
                 signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                 claims: claims
            );


                return Ok(
                    new LoginResponse
                    {
                        Email = user.Email,
                        ExpirationDate = token.ValidTo,
                        JwtToken = new JwtSecurityTokenHandler().WriteToken(token)
                    });

            }
            return Unauthorized();

        }


    }
}