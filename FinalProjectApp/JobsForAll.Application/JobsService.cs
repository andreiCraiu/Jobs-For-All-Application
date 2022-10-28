using JobsForAll.Application.Interfaces;
using JobsForAll.Data.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsForAll.Domain.Models;

namespace JobsForAll.Application
{
    public class JobsService : IJobsService
    {
        private readonly ApplicationDbContext _context;
        public JobsService(ApplicationDbContext context)
        {
            _context = context;
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
                    await _context.Jobs.AddAsync(job);
                    await _context.JobRequesters.AddAsync(jobRequester);
                    await _context.SaveChangesAsync();
                    serviceResponse.ResponseOk = true;
                    return serviceResponse;

                }
                catch (IOException exception)
                {
                    serviceResponse.ResponseError = exception.Message;
                    serviceResponse.ResponseOk = false;
                }
            }
            var exceptionMessage = job == null ? Exception.NULL_JOB : Exception.NULL_USER;
            serviceResponse.ResponseError = exceptionMessage;
            return serviceResponse;
        }

        public async Task<ServiceResponse<bool, string>> DeleteJob(int id)
        {
            var serviceResponse = new ServiceResponse<bool, string>();
            var job = _context.Jobs.FirstOrDefault(x => x.ID == id);
            if (job != null)
            {
                try
                {
                    var jobRequester = _context.JobRequesters.FirstOrDefault(jobsRequests => Object.Equals(jobsRequests.Job, job));
                    _context.JobRequesters.Remove((JobRequester)jobRequester);
                    _context.Jobs.Remove(job);
                    _context.SaveChanges();
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
                serviceResponse.ResponseError = Exception.NULL_JOB;
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
                    var jobRequesters = from jobRequester in _context.JobRequesters
                                        where jobRequester.ApplicationUser.Id == user.Id
                                        select jobRequester;
                    var jobs = jobRequesters.Select(job => job.Job);
                    serviceResponse.ResponseOk = jobs.ToList();
                    return serviceResponse;

                }
                 catch (IOException exception)
                {
                    serviceResponse.ResponseError = exception.Message;
                }
            }
            serviceResponse.ResponseError = Exception.NULL_USER;
            return serviceResponse;
        }
    }
}

