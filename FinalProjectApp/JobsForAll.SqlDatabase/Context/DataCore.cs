using IdentityServer4.EntityFramework.Options;
using JobsForAll.SqlDatabase.Contracts;
using JobsForAll.SqlDatabase.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace JobsForAll.SqlDatabase.Context
{
    internal class DataCore : ApiAuthorizationDbContext<DbApplicationUser>, IDataCore
    {
        public DbSet<DbApplicationUser> ApplicationUsers { get; set; }
        public DbSet<DbJob> Jobs { get; set; }
        public DbSet<DbJobRequester> JobRequesters { get; set; }
        public DbSet<DbMessage> Messages { get; set; }
        public DbSet<DbUserComment> UserComments { get; set; }
        public DbSet<DbComment> Comments { get; set; }

        public DataCore(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
