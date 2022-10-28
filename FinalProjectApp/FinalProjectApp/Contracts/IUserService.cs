using JobsForAll.Library.Models;
using JobsForAll.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobsForAll.Contracts
{
    public interface IUserService
    {
        Task<ServiceResponse<List<ApplicationUser>, string>> GetAllUsers();
        Task<ServiceResponse<ApplicationUser, string>> GetUserByEmail(string email);
        Task<ServiceResponse<ApplicationUser, string>> GetUserById(string id);
        Task<ServiceResponse<List<ApplicationUser>, string>> FilterUsers(string filterString);
    }
}
