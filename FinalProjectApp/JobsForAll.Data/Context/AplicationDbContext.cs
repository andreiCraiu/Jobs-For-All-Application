using IdentityServer4.EntityFramework.Options;
using JobsForAll.Domain.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JobsForAll.Data.Context
{
    internal class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobRequester> JobRequesters { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}
