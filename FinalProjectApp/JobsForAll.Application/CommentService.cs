using JobsForAll.Application.Interfaces;
using JobsForAll.Data.Context;
using JobsForAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForAll.Application
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context ;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
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

                    await _context.Comments.AddAsync(comment);
                    await _context.UserComments.AddAsync(userComment);
                    await _context.SaveChangesAsync();
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
            var comentsList = new List<Comment>();

            var userComments = from comment in _context.UserComments
                               where comment.ApplicationUser.Id == id
                               select comment.Comment;
            
            if (userComments != null)
            {
                serviceResponse.ResponseOk = userComments.ToList();
                return serviceResponse;
            }
            else
            {
                serviceResponse.ResponseError = Exception.NULL_USER;
            }
            return serviceResponse;
        }
    }
    }