
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


namespace FinalProjectApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public JobsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
         ApplicationDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("addJob")]
     //   [Authorize(new[] { Role.JobRequester, Role.Both })]
        public async Task<ActionResult> AddJob(Job job)
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
         
         
            if (job != null && user != null)
            {
                var jobRequester = new JobRequester();
                jobRequester.ApplicationUser = user;
                jobRequester.Job = job;
                await _context.Jobs.AddAsync(job);
                await _context.JobRequesters.AddAsync(jobRequester);
               await _context.SaveChangesAsync();
             return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("getJobs")]
        public IActionResult GetJobs()
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            if(user != null)
            {
                var jobRequesters = from jobRequester in _context.JobRequesters
                                    where jobRequester.ApplicationUser.Id == user.Id
                                    select jobRequester;
                var jobs = jobRequesters.Select(job => job.Job);
                return Ok(jobs.ToList());
            }

            return BadRequest();
      
        }

        [HttpDelete]
        [Route("deleteJob/{id}")]
        public IActionResult DeleteJob(int id)
        {
            var job = _context.Jobs.FirstOrDefault(x => x.ID == id);

            var jobRequester = _context.JobRequesters.FirstOrDefault(jobsRequests => Object.Equals(jobsRequests.Job, job));
            if (job == null)
                return BadRequest();
            _context.JobRequesters.Remove((JobRequester)jobRequester);
            _context.Jobs.Remove(job);
            _context.SaveChanges();
            return Ok();
        }

    }


}
