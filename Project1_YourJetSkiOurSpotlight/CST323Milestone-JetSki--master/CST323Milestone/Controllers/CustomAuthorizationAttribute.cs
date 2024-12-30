
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CST323Milestone.Controllers {
    internal class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter {
        /// <summary>
        /// method from IAuthorizationFilter interface that will redirect to the given route if custom authorization filter is applied to a method
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? username = context.HttpContext.Session.GetString("username");
            //Sends the user back to the home page if the username is not found in our database
            if (username == null)
            {
                context.Result = new RedirectResult("/login");
            }
        }
    }
}