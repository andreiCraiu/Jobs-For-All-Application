using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsForAll.Domain.Models;

namespace JobsForAll.Application.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<List<ApplicationUser>, string>> GetAllUsers();
        Task<ServiceResponse<ApplicationUser, string>> GetUserByEmail(string email);
        Task<ServiceResponse<ApplicationUser, string>> GetUserById(string id);
        Task<ServiceResponse<List<ApplicationUser>, string>> FilterUsers(string filterString);
    }
}
