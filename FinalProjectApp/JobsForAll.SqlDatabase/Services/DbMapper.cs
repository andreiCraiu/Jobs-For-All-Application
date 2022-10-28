using JobsForAll.Library.Models;
using JobsForAll.SqlDatabase.Contracts;
using JobsForAll.SqlDatabase.Models;

namespace JobsForAll.SqlDatabase.Services
{
    internal class DbMapper : IDbMapper
    {
        public ApplicationUser MapToApplicationUser(DbApplicationUser model) => new ApplicationUser
        {
            Id = model.Id,
        };

        public Comment MapToComment(DbComment commentComment) => new Comment();
        public Job MapToJob(DbJob arg) => new Job()
        {

        };
    }
}
