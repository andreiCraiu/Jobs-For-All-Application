using FinalProjectApp.Models;
using JobsForAll.Application.Interfaces;
using JobsForAll.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobsForAll.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        public CommentController(ICommentService commentService, IUserService userService)
        {
            _commentService = commentService;
            _userService = userService;
        }


        [HttpPost]
        [Route("addComment/{commentedUserId}")]

        public ActionResult AddComment(Comment comment, string commentedUserId)
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            var commentedUser = _userService.GetUserById(commentedUserId).Result.ResponseOk;
            var isCommentAdded = _commentService.AddComment(comment, user, commentedUser).Result.ResponseOk;
            return isCommentAdded ? Ok(isCommentAdded) : BadRequest();
        }

        [HttpGet]
        [Route("getComments/{id}")]

        public ActionResult GetComments(string id)
        {
            var user = (ApplicationUser)HttpContext.Items["User"];
            var commentList = _commentService.GetComments(id).Result.ResponseOk;
            if (commentList != null)
            {
                return Ok(commentList);
            }
            else
            {
                return BadRequest();
            }
        }
    }



}
