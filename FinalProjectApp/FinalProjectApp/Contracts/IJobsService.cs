using JobsForAll.Library.Models;
using JobsForAll.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobsForAll.Contracts
{
    public interface IJobsService
    {
        Task<ServiceResponse<bool, string>> AddJob(Job job, ApplicationUser user);
        Task<ServiceResponse<List<Job>, string>> GetAllTasksForUser(ApplicationUser user);
        Task<ServiceResponse<bool, string>> DeleteJob(int id);
    }
}
