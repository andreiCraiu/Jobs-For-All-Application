using JobsForAll.Library.Models;
using JobsForAll.Library.Models.Authentication;
using JobsForAll.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobsForAll.Contracts
{
    public interface IAuthService
    {
        Task<ServiceResponse<LoginResponse, string>> Login(LoginRequest loginRequest);
        Task<ServiceResponse<RegisterResponse, IEnumerable<IdentityError>>> RegisterUser(RegisterRequest registerRequest);
        Task<ServiceResponse<bool, string>> CompleteUserProfile(CompleteUserProfile completeUserProfile, ApplicationUser user);
        Task<bool> ConfirmUser(ConfirmUserRequest confirmUserRequest);
    }
}
