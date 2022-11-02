using JobsForAll.Contracts;
using JobsForAll.Library.Contracts;
using JobsForAll.Library.Models;
using JobsForAll.Library.Models.Authentication;
using JobsForAll.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(
            IRepository repository,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<ServiceResponse<bool, string>> CompleteUserProfile(CompleteUserProfile completeUserProfile, ApplicationUser user)
        {
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
                    //todo: repository.Entry(user).State = EntityState.Modified;

                    await repository.SaveUserChangesAsync(user);
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
                serviceResponse.ResponseError = Constants.NULL_USER;
                serviceResponse.ResponseOk = false;
            }
            return serviceResponse;
        }

        public async Task<bool> ConfirmUser(ConfirmUserRequest confirmUserRequest)
        {
            return await repository.ConfirmUser(confirmUserRequest.Email, confirmUserRequest.ConfirmationToken).ConfigureAwait(false);//doar in servicii
                                                                                                                                      //nu in puncte de intrare
        }

        public async Task<ServiceResponse<LoginResponse, string>> Login(LoginRequest loginRequest)
        {
            var serviceResponse = new ServiceResponse<LoginResponse, string>();
            var user = repository.GetUserByEmail(loginRequest.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: configuration["Jwt:Site"],
                  audience: configuration["Jwt:Site"],
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
            var result = await userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                serviceResponse.ResponseOk = new RegisterResponse { ConfirmationToken = user.SecurityStamp };
                return serviceResponse;
            }

            serviceResponse.ResponseError = result.Errors;
            return serviceResponse;
        }

        //

        private readonly IRepository repository;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
    }
}
