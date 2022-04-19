
using FinalProjectApp.Data;
using FinalProjectApp.Models;
using FinalProjectApp.ViewModels.Authentication;
using FinalProjectApp.ViewModels.Authenticatoin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FinalProjectApp.Helpers;
using JobsForAll.Application;
using JobsForAll.Application.Interfaces;
using System.Threading;

namespace FinalProjectApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;

        public JobsController(IJobsService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpPost]
        [Route("addJob")]
        //   [Authorize(new[] { Role.JobRequester, Role.Both })]
        public ActionResult AddJob(Job job)
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            var isJobAdded = _jobsService.AddJob(job, user).Result.ResponseOk;
            return isJobAdded ? Ok(isJobAdded) : BadRequest();
        }

        [HttpGet]
        [Route("getJobs")]
        public IActionResult GetJobs()
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            var jobs = _jobsService.GetAllTasksForUser(user);
            return jobs.Result.ResponseOk != null ? Ok(jobs.Result.ResponseOk) : BadRequest();
        }

        [HttpDelete]
        [Route("deleteJob/{id}")]
        public IActionResult DeleteJob(int id)
        {
            var isJobDeletedResponse = _jobsService.DeleteJob(id);
            return isJobDeletedResponse.Result.ResponseOk == true ? Ok(isJobDeletedResponse.Result.ResponseOk) : BadRequest();
        }
    }
}
