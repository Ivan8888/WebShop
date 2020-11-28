using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser app_user = new AppUser
                {
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age
                    
                };

                IdentityResult result = _userManager.CreateAsync(app_user, model.Password).Result;
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false).Result;
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Ok("You need to login.");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return Ok("AccessDenied");
        }


    }
}