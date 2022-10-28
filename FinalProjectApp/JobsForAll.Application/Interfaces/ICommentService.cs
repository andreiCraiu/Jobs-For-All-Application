using JobsForAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Application.Interfaces
{
    public interface ICommentService
    {
        Task<ServiceResponse<bool, string>> AddComment(Comment comment, ApplicationUser user, ApplicationUser commentedUser);
        Task<ServiceResponse<List<Comment>, string>> GetComments(string userId);

    }
}
