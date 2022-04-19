using Cookies_Authentication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Cookies_Authentication.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserLogin([Bind] Users user)
        {
            var users = new Users();
            var allusers = users.GetUsers().FirstOrDefault();
            if (users.GetUsers().Any(x => x.UserName == user.UserName))
            {

                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, "anet@test.com"),
                };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }
            return View(user); 
        }
    }
}
