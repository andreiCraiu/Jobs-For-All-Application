using JobsForAll.Contracts;
using JobsForAll.Library.Contracts;
using JobsForAll.Library.Models;
using JobsForAll.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsForAll.Services
{
    public class UserService : IUserService
    {
        public UserService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ServiceResponse<List<ApplicationUser>, string>> FilterUsers(string filterString)
        {
            var serviceResponse = new ServiceResponse<List<ApplicationUser>, string>();
            var users = repository.GetUsersByUserName(filterString).ToList();
            if (users != null)
            {
                serviceResponse.ResponseOk = users;
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Constants.NULL_USER;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ApplicationUser>, string>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<ApplicationUser>, string>();
            var users = repository.GetAllUsers();
            if (users != null)
            {
                serviceResponse.ResponseOk = users.ToList();
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Constants.NULL_USER;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ApplicationUser, string>> GetUserByEmail(string email)
        {
            var serviceResponse = new ServiceResponse<ApplicationUser, string>();
            var user = repository.GetUserByEmail(email);
            if (user != null)
            {
                serviceResponse.ResponseOk = user;
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Constants.NULL_USER;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ApplicationUser, string>> GetUserById(string id)
        {
            var serviceResponse = new ServiceResponse<ApplicationUser, string>();
            var user = repository.GetUserById(id);
            if (user != null)
            {
                serviceResponse.ResponseOk = user;
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Constants.NULL_USER;
            }
            return serviceResponse;
        }

        //

        private readonly IRepository repository;
    }
}
