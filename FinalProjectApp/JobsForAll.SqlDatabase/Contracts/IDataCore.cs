using JobsForAll.SqlDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace JobsForAll.SqlDatabase.Contracts
{
    internal interface IDataCore
    {
        public DbSet<DbApplicationUser> ApplicationUsers { get; }
        public DbSet<DbJob> Jobs { get; }
        public DbSet<DbJobRequester> JobRequesters { get; }
        public DbSet<DbMessage> Messages { get; }
        public DbSet<DbUserComment> UserComments { get; }
        public DbSet<DbComment> Comments { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
