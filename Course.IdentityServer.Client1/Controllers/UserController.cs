using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Course.IdentityServer.Client1.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            //no longer, we have a user in this scope 
            //User.Claims;
            //User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            //if we wants more info about users, we can use userInfo Endpoint
            
            return View();
        }
        public async Task LogOut()
        {
            await HttpContext.SignOutAsync("myCookies");
            await HttpContext.SignOutAsync("oidc");
        }
    }
}
