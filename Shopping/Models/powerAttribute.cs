
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Shopping.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Shopping.Models
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false,
        Inherited = true)]
    public sealed class Power : Attribute, IActionFilter, IOrderedFilter
    {
        private readonly PermissionEnum permission;
       // private readonly UserManager<AppUser> userManager;

        public Power(PermissionEnum permission)
        {
            this.permission = permission;
           // this.userManager = userManager;
        }
        public int Order { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userManager = context.HttpContext.RequestServices.GetService<UserManager<AppUser>>();
            var user = userManager.GetUserAsync(context.HttpContext.User).GetAwaiter().GetResult();
           // var u=context.HttpContext.User.Identity.Name;
            var c = context.RouteData.Values["controller"].ToString();
            var powerBll = context.HttpContext.RequestServices.GetService<PowerServices>();
            var has = powerBll.HasPermission(permission, c, user.Id);
            var f = context.HttpContext.User.IsInRole("Admin");
            if(has == false&&f)
            {
                //context.Result = new JsonResult("You shall not Pass ,You donot have permission");
                context.Result = new RedirectResult("~/Home/pass");
            }
        }
    }
    public enum PermissionEnum
    {
        Show,
        Add,
        Edit,
        Delete
    }
}
