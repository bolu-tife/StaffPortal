using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffPortal.Models;
using StaffPortal.Interface;
using StaffPortal.Entities;
using StaffPortal.Dtos;
using Microsoft.AspNetCore.Identity;
using StaffPortal.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StaffPortal.Controllers
{
    public class AccountController : BaseController
    {

        private readonly IAccount _account;

        private readonly SignInManager<ApplicationUser> _signInManager;

        //private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(IAccount account, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _account = account;
            _signInManager = signInManager;
            //_userManager = userManager;

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "UserName/Password is incorrect");
                return View();
            }

            var signin = await _account.LoginIn(login);

            if (signin)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();



        }
        //public async Task<IActionResult> UserProfile()
        //{

        //    var model = await _account.GetAll();

        //    if (model != null)
        //        return View(model);
        //    return View();
        //}
        
        //public IActionResult Signup()
        //{
        //    return View();
        //}

       

        [HttpPost]
        public async Task<IActionResult> Signup( SigninViewModel signupmodel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = signupmodel.UserName,
                Email = signupmodel.Email
            };

            var sign = await _account.CreateUser(user, signupmodel.Password);
            if (sign)
            {
                
                return RedirectToAction("Index", "Home");

            }
            Alert("Account not created!", NotificationType.error);
            return View();
        

        }

        //[HttpPost]
        //public async Task<IActionResult> Index(ApplicationUser userdetails)
        //{
        //    ApplicationUser _userprofile = await _userManager.FindByEmailAsync(userdetails.Email);
        //    if (_userprofile != null)
        //    {
        //        _userprofile.FirstName = userdetails.FirstName;
        //        _userprofile.LastName = userdetails.LastName;
        //    }
        //    var x = await _userManager.UpdateAsync(_userprofile);
        //    if (x.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        //ApplicationUser appUser = _userManager.FindByIdAsync(userid).Result;
        //        return View(userdetails);
        //    }
        //}



        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var userid = _userManager.GetUserId(User);
        //    if (userid == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    else
        //    {
        //        ApplicationUser appUser = _userManager.FindByIdAsync(userid).Result;
        //        return View(appUser);
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");


        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
