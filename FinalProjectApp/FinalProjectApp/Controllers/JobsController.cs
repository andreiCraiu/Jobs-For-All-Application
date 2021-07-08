
using FinalProjectApp.Data;
using FinalProjectApp.Models;
using FinalProjectApp.ViewModels.Authentication;
using FinalProjectApp.ViewModels.Authenticatoin;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult> AddJob(Job job)
        { 
            if (job != null)
            {
                await _context.Jobs.AddAsync(job);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("getJobs")]
        public async Task<ActionResult<IEnumerable<Job>>> GetBooks()
        {
            var a = 3;
            var b = _context.Jobs.ToArrayAsync();
           
           
            return await b;
        }

    }


}
