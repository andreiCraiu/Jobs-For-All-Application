using FinalProjectApp.Models;
using JobsForAll.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobsForAll.Controllers
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
