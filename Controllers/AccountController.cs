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
        //private readonly RoleManager<ApplicationRole> _roleManager;
        //string Message = "";

        //public AccountController(SignInManager<ApplicationUser> signInManager,
        //    RoleManager<ApplicationRole> roleManager,
        //    UserManager<ApplicationUser> userManager)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}
        private IFaculty _faculty;
        private IDepartment _department;
        private IState _state;
        private ILocal _local;

        public AccountController(IAccount account, IFaculty faculty, IDepartment department, IState state,ILocal local,SignInManager<ApplicationUser> signInManager)
        {
            _account = account;
            _signInManager = signInManager;
            _faculty = faculty;
            _department = department;
            _state = state;
            _local = local;

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
        [HttpGet]
        public async Task<IActionResult> Signup()
        {
            var faculty = await _faculty.GetAll();
            var department = await _department.GetAll();
            var state = await _state.GetAll();
            //var local = await _local.GetAll();

            var facultyList = faculty.Select(f => new SelectListItem()
            {
                Value = f.Id.ToString(),
                Text = f.Name
            });

            var departmentList = department.Select(d => new SelectListItem()
            {
                Value = d.Id.ToString(),
                Text = d.DeptName
            });

            var stateList = state.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });

            //var localList = local.Select(l => new SelectListItem()
            //{
            //    Value = l.Id.ToString(),
            //    Text = l.Name
            //});
            ViewBag.faculty = facultyList;
            ViewBag.department = departmentList;
            ViewBag.state = stateList;
            //ViewBag.local = localList;
            return View();
        }

        //public IActionResult Signup()
        //{
        //    return View();
        ////}
       
        [HttpPost]
        public async Task<IActionResult> Signup( SigninViewModel signupmodel)
        {
            ApplicationUser user = new ApplicationUser();

            user.UserName = signupmodel.UserName;
            user.Email = signupmodel.Email;
            user.FirstName = signupmodel.FirstName;
            user.LastName = signupmodel.LastName;
            user.country = signupmodel.Country;
            user.StateId = signupmodel.StateId;
            user.DepartmentId = signupmodel.DepartmentId;
            user.FacultyId = signupmodel.FacultyId;
            user.Email = signupmodel.Email;
            var sign = await _account.CreateUser(user, signupmodel.Password);
            if (sign)
            {
                //Alert("Account Created successfully", NotificationType.success);
                return RedirectToAction("Index", "Home");

            }
            Alert("Account not created!", NotificationType.error);
            return View();
           
          
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
