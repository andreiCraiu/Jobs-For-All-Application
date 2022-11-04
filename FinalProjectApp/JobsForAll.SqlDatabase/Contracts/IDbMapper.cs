using JobsForAll.Library.Models;
using JobsForAll.SqlDatabase.Models;

namespace JobsForAll.SqlDatabase.Contracts
{
    internal interface IDbMapper
    {
        ApplicationUser MapToApplicationUser(DbApplicationUser model);
        Comment MapToComment(DbComment model);
        Job MapToJob(DbJob model);
        DbMessage MapToDbMessage(Message message);
        MessageViewModel MapToMessage(DbMessage model);
        DbJob MapToDbJob(Job model);
    }
}
