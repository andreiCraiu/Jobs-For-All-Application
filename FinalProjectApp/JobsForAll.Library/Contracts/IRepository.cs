using JobsForAll.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobsForAll.Library.Contracts
{
    public interface IRepository
    {
        void AddMessages(Message message);
        IEnumerable<MessageViewModel> GetMessages();
        ApplicationUser? GetApplicationUsers(string id);
        Task SaveUserChangesAsync(ApplicationUser user);
        ApplicationUser? GetUserByEmail(string email);
        ApplicationUser? GetUserById(string userId);
        Task SaveComents(Comment comment, UserComment userComment);
        IEnumerable<Comment> GetUserCommentsById(string id);
        Job GetJobById(int id);
        Task AddJobs(Job job, JobRequester jobRequester);
        void RemoveJobRequestsAndJob(Job job);
        IEnumerable<Job> GetJobsByUserId(string userId);
        Task<bool> ConfirmUser(string email, string confirmationToken);
        IEnumerable<ApplicationUser> GetUsersByUserName(string filterString);
        IEnumerable<ApplicationUser> GetAllUsers();
    }
}
