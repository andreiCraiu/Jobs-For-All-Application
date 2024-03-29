﻿using FinalProjectApp.Data;
using FinalProjectApp.Models;
using FinalProjectApp.ViewModels.Authentication;
using FinalProjectApp.ViewModels.Authenticatoin;
using JobsForAll.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Application
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<bool, string>> CompleteUserProfile(CompleteUserProfile completeUserProfile, ApplicationUser user)
        {
           // var user2 = await _userManager.FindByEmailAsync(loginRequest.Email);
            var serviceResponse = new ServiceResponse<bool, string>();
            if (user != null)
            {
                try
                {
                    user.PhoneNumber = completeUserProfile.PhoneNumber;
                    user.Address = completeUserProfile.Address;
                    user.Postcode = completeUserProfile.PostCode;
                    user.Profession = completeUserProfile.MainProfession + ", " + completeUserProfile.SecundaryProfession + "(Secundary)";
                    user.Details = "Hobby: " + completeUserProfile.Hobby + ", Fun fact: " + completeUserProfile.FunFact;
                    user.Role = completeUserProfile.Role;
                    _context.Entry(user).State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                    serviceResponse.ResponseOk = true;
                }
                catch (IOException exception)
                {
                    serviceResponse.ResponseError = exception.Message;
                    serviceResponse.ResponseOk = false;
                }
            }
            else
            {
                serviceResponse.ResponseError = Exception.NULL_USER;
                serviceResponse.ResponseOk = false;
            }
            return serviceResponse;
        }

        public async Task<bool> ConfirmUser(ConfirmUserRequest confirmUserRequest)
        {
            var toConfirm = _context.ApplicationUsers
                .Where(u => u.Email == confirmUserRequest.Email && u.SecurityStamp == confirmUserRequest.ConfirmationToken)
                .FirstOrDefault();
            if (toConfirm != null)
            {
                toConfirm.EmailConfirmed = true;
                _context.Entry(toConfirm).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }


        public async Task<ServiceResponse<LoginResponse, string>> Login(LoginRequest loginRequest)
        {
            var serviceResponse = new ServiceResponse<LoginResponse, string>();
            var user = _context.ApplicationUsers.FirstOrDefault(x => x.Email == loginRequest.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: _configuration["Jwt:Site"],
                  audience: _configuration["Jwt:Site"],
                  expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
                  claims: claims
                );

                serviceResponse.ResponseOk = new LoginResponse
                {
                    JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo,
                    Email = user.Email
                };
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<RegisterResponse, IEnumerable<IdentityError>>> RegisterUser(RegisterRequest registerRequest)
        {
            var user = new ApplicationUser
            {
                Email = registerRequest.Email,
                UserName = registerRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var serviceResponse = new ServiceResponse<RegisterResponse, IEnumerable<IdentityError>>();
            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                serviceResponse.ResponseOk = new RegisterResponse { ConfirmationToken = user.SecurityStamp };
                return serviceResponse;
            }

            serviceResponse.ResponseError = result.Errors;
            return serviceResponse;
        }
    }
}
