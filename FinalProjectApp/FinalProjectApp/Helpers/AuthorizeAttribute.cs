using JobsForAll.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace JobsForAll.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public AuthorizeAttribute(Role[] roles)
        {
            _roles = new List<Role>();
            _roles.AddRange(roles);
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (ApplicationUser)context.HttpContext.Items["User"];
            if (user == null || (_roles != null && !_roles.Contains(user.Role)))
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        private readonly List<Role> _roles;
    }
}
