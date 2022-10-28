using JobsForAll.Contracts;
using JobsForAll.Library.Contracts;
using JobsForAll.Library.Models;
using JobsForAll.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobsForAll.Services
{
    public class JobsService : IJobsService
    {
        public JobsService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ServiceResponse<bool, string>> AddJob(Job job, ApplicationUser user)
        {
            var serviceResponse = new ServiceResponse<bool, string>();
            if (job != null && user != null)
            {
                try
                {
                    var jobRequester = new JobRequester();
                    jobRequester.ApplicationUser = user;
                    jobRequester.Job = job;

                    await repository.AddJobs(job, jobRequester);
                    serviceResponse.ResponseOk = true;
                    return serviceResponse;

                }
                catch (IOException exception)
                {
                    serviceResponse.ResponseError = exception.Message;
                    serviceResponse.ResponseOk = false;
                }
            }
            var exceptionMessage = job == null ? Constants.NULL_JOB : Constants.NULL_USER;
            serviceResponse.ResponseError = exceptionMessage;
            return serviceResponse;
        }

        public async Task<ServiceResponse<bool, string>> DeleteJob(int id)
        {
            var serviceResponse = new ServiceResponse<bool, string>();
            var job = repository.GetJobById(id);
            if (job != null)
            {
                try
                {
                    repository.RemoveJobRequestsAndJob(job);
                    serviceResponse.ResponseOk = true;
                    return serviceResponse;
                }
                catch (IOException exception)
                {
                    serviceResponse.ResponseError = exception.Message;
                    serviceResponse.ResponseOk = false;
                }
            }
            else
            {
                serviceResponse.ResponseError = Constants.NULL_JOB;
                serviceResponse.ResponseOk = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Job>, string>> GetAllTasksForUser(ApplicationUser user)
        {

            var serviceResponse = new ServiceResponse<List<Job>, string>();

            if (user != null)
            {
                try
                {
                    var jobs = repository.GetJobsByUserId(user.Id);
                    serviceResponse.ResponseOk = jobs.ToList();
                    return serviceResponse;

                }
                catch (IOException exception)
                {
                    serviceResponse.ResponseError = exception.Message;
                }
            }
            serviceResponse.ResponseError = Constants.NULL_USER;
            return serviceResponse;
        }

        //

        private readonly IRepository repository;
    }
}

