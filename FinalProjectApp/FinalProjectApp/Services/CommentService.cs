using JobsForAll.Contracts;
using JobsForAll.Library.Contracts;
using JobsForAll.Library.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobsForAll.Services
{
    public class CommentService : ICommentService
    {
        public CommentService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ServiceResponse<bool, string>> AddComment(Comment comment, ApplicationUser user, ApplicationUser commentedUser)
        {
            var serviceResponse = new ServiceResponse<bool, string>();

            if (comment != null && user != null)
            {
                try
                {
                    var userComment = new UserComment();
                    comment.Author = user.UserName;
                    userComment.ApplicationUser = commentedUser;
                    userComment.Comment = comment;

                    await repository.SaveComents(comment, userComment);

                    serviceResponse.ResponseOk = true;
                    return serviceResponse;

                }
                catch (IOException exception)
                {
                    serviceResponse.ResponseError = exception.Message;
                    serviceResponse.ResponseOk = false;
                }
            }
            var exceptionMessage = comment == null ? Exception.NULL_COMMENT : Exception.NULL_USER;
            serviceResponse.ResponseError = exceptionMessage;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Comment>, string>> GetComments(string id)
        {
            var serviceResponse = new ServiceResponse<List<Comment>, string>();

            var userComments = repository.GetUserCommentsById(id);
            if (userComments != null)
            {
                serviceResponse.ResponseOk = Enumerable.ToList<Comment>(userComments);
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Exception.NULL_USER;
            }
            return serviceResponse;
        }

        //
        private readonly IRepository repository;
    }
}