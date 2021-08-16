using FinalProjectApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Application.Interfaces
{
    public interface IJobsService
    {
        Task<ServiceResponse<bool, string>> AddJob(Job job, ApplicationUser user);
        Task<ServiceResponse<List<Job>, string>> GetAllTasksForUser(ApplicationUser user);
        Task<ServiceResponse<bool, string>> DeleteJob(int id);
    }
}
