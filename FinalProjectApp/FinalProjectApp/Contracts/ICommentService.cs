using JobsForAll.Library.Models;
using JobsForAll.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobsForAll.Contracts
{
    public interface ICommentService
    {
        Task<ServiceResponse<bool, string>> AddComment(Comment comment, ApplicationUser user, ApplicationUser commentedUser);
        Task<ServiceResponse<List<Comment>, string>> GetComments(string userId);

    }
}
