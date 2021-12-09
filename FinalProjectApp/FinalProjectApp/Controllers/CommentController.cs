
using FinalProjectApp.Data;
using FinalProjectApp.Models;
using FinalProjectApp.ViewModels.Authentication;
using FinalProjectApp.ViewModels.Authenticatoin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FinalProjectApp.Helpers;
using JobsForAll.Application;
using JobsForAll.Application.Interfaces;
using JobsForAll.Domain.Models;

namespace JobsForAll.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        public CommentController(ICommentService commentService, IUserService userService )
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
            if(commentList != null)
            {
                return Ok(commentList);
            }
            else
            {
                return BadRequest();            }
        }
    }



}
