using FinalProjectApp.Data;
using FinalProjectApp.Models;
using JobsForAll.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Application
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ApplicationUser>, string>> FilterUsers(string filterString)
        {
            var serviceResponse = new ServiceResponse<List<ApplicationUser>, string>();
            var users = _context.ApplicationUsers.Where(user => user.UserName.Contains(filterString)).ToList();
            if (users != null)
            {
                serviceResponse.ResponseOk = users;
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Exception.NULL_USER;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ApplicationUser>, string>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<ApplicationUser>, string>();
            var users = _context.ApplicationUsers.ToList();
            if(users!= null)
            {
                serviceResponse.ResponseOk = users;
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Exception.NULL_USER;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ApplicationUser, string>> GetUserByEmail(string email)
        {
            var serviceResponse = new ServiceResponse<ApplicationUser, string>();
            var user = _context.ApplicationUsers.FirstOrDefault(user => user.Email == email);
            if (user != null)
            {
                serviceResponse.ResponseOk = user;
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Exception.NULL_USER;
            }
            return serviceResponse;
        }


        public async Task<ServiceResponse<ApplicationUser, string>> GetUserById(string id)
        {
            var serviceResponse = new ServiceResponse<ApplicationUser, string>();
            var user = _context.ApplicationUsers.FirstOrDefault(user => user.Id == id);
            if (user != null)
            {
                serviceResponse.ResponseOk = user;
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Exception.NULL_USER;
            }
            return serviceResponse;
        }
    }
}
