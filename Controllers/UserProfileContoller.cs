using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffPortal.Models;
using StaffPortal.Interface;
using StaffPortal.Entities;
using Microsoft.AspNetCore.Identity;
using StaffPortal.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffPortal.Data;
using Microsoft.EntityFrameworkCore;

namespace StaffPortal.Controllers
{
    public class UserProfileController : BaseController
    {
        private IUserProfile _userProfile;
        private IFaculty _faculty;
        private IDepartment _department;

        private readonly StaffPortalDataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        //private StaffPortalDataContext context = new StaffPortalDataContext();
        public UserProfileController(IUserProfile userProfile, IFaculty faculty, IDepartment department, UserManager<ApplicationUser> userManager, StaffPortalDataContext context)
        {
            _userProfile = userProfile;
            _faculty = faculty;
            _department = department;
            _context = context;

            _userManager = userManager;
        }

      
       
        [HttpPost]
        public async Task<IActionResult> Index(ApplicationUser userdetails)
        {
            ApplicationUser _userprofile = await _userManager.FindByEmailAsync(userdetails.Email);
            if (_userprofile != null)
            {
                _userprofile.FirstName = userdetails.FirstName;
                _userprofile.LastName = userdetails.LastName;
                //_userprofile.FacultyId = userdetails.FacultyId;
                //_userprofile.DepartmentId = userdetails.DepartmentId;
                //_userprofile.StateId = userdetails.StateId;
                //_userprofile.LocalId = userdetails.LocalId;
            }
            var x = await _userManager.UpdateAsync(_userprofile);
            if (x.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //ApplicationUser appUser = _userManager.FindByIdAsync(userid).Result;
                return View(userdetails);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userid = _userManager.GetUserId(User);
            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ApplicationUser appUser =  _userManager.FindByIdAsync(userid).Result;
                return View(appUser);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UserIndex(ApplicationUser userdetails)
        {
            
            ApplicationUser _userprofile = await _userManager.FindByEmailAsync(userdetails.Email);
            if (_userprofile != null)
            {
                _userprofile.FirstName = userdetails.FirstName;
                _userprofile.LastName = userdetails.LastName;
                //_userprofile.FacultyId = userdetails.FacultyId;
                //_userprofile.DepartmentId = userdetails.DepartmentId;
                //_userprofile.StateId = userdetails.StateId;
                //_userprofile.LocalId = userdetails.LocalId;
            }
            var x = await _userManager.UpdateAsync(_userprofile);
            if (x.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //ApplicationUser appUser = _userManager.FindByIdAsync(userid).Result;
                return View(userdetails);
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            var userid = _userManager.GetUserId(User);
            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                //var department = await _department.GetAll();
                //var faculty = await _faculty.GetAll();
                
                //var departmentList = department.Select(d => new SelectListItem()
                //{
                //    Value = d.Id.ToString(),
                //    Text = d.DeptName
                //});

                //var facultyList = faculty.Select(f => new SelectListItem()
                //{
                //    Value = f.Id.ToString(),
                //    Text = f.Name
                //});

               

                //ViewBag.department = departmentList;
                //ViewBag.faculty = facultyList;
               

                //List<State> statelist = new List<State>();
                //statelist = (from state in _context.State
                //             select state).ToList();

                //statelist.Insert(0, new State { Id = 0, Name = "Select" });

                //ViewBag.ListofStates = statelist;
                ApplicationUser appUser = _userManager.FindByIdAsync(userid).Result;
                return View(appUser);
            }
        }


        //public JsonResult GetLocal(int StateId)
        //{
        //    List<Local> locallist = new List<Local>();
        //    locallist = _context.Locals.Where(a => a.States.Id == StateId).ToList();

        //    locallist.Insert(0, new Local { Id = 0, Name = "Please Select State" });
        //    return Json(new SelectList(locallist, "Id", "Name"));

        //}
        [HttpGet]
        public IActionResult UserInfo()
        {

            return View();
        }
        [HttpGet]
        public IActionResult UserInfoEdit()
        {

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
