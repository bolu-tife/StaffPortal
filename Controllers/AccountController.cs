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
        

        public AccountController(IAccount account, SignInManager<ApplicationUser> signInManager)
        {
            _account = account;
            _signInManager = signInManager;
          

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
        public async Task<IActionResult> UserProfile()
        {

            var model = await _account.GetAll();

            if (model != null)
                return View(model);
            return View();
        }
        
        public IActionResult Signup()
        {
            return View();
        }

       

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
                //Alert("Account Created successfully", NotificationType.success);
                return RedirectToAction("Index", "Home");

            }
            Alert("Account not created!", NotificationType.error);
            return View();
            //ApplicationUser user = new ApplicationUser();



        }



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
