using JobsForAll.Library.Models;
using JobsForAll.SqlDatabase.Models;

namespace JobsForAll.SqlDatabase.Contracts
{
    internal interface IDbMapper
    {
        ApplicationUser MapToApplicationUser(DbApplicationUser model);
        Comment MapToComment(DbComment commentComment);
        Job MapToJob(DbJob arg);
    }
}
