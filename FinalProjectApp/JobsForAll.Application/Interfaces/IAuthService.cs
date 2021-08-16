using FinalProjectApp.Models;
using FinalProjectApp.ViewModels.Authentication;
using FinalProjectApp.ViewModels.Authenticatoin;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<LoginResponse, string>> Login(LoginRequest loginRequest);
        Task<ServiceResponse<RegisterResponse, IEnumerable<IdentityError>>> RegisterUser(RegisterRequest registerRequest);
        Task<ServiceResponse<bool, string>> CompleteUserProfile(CompleteUserProfile completeUserProfile, ApplicationUser user);
        Task<bool> ConfirmUser(ConfirmUserRequest confirmUserRequest);
    }
}
