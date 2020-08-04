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
using Microsoft.AspNetCore.Authorization;

namespace StaffPortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserProfileController : BaseController
    {
        private IUserProfile _userProfile;
        private IFaculty _faculty;
        private ILocal _local;
        private IDepartment _department;
        private StaffPortalDataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProfileController(IUserProfile userProfile, IFaculty faculty, ILocal local, IDepartment department, StaffPortalDataContext context, UserManager<ApplicationUser> userManager)
        {
            _userProfile = userProfile;
            _faculty = faculty;
            _local = local;
            _department = department;
            _context = context;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var model = await _userProfile.GetAll();
           
            if (model != null)
            {
                
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserIndex()
        {
            
            var user = _userManager.GetUserName(User);
            var x = await _userManager.FindByNameAsync(user);
            
            var editUserProfile = _userProfile.GetIdByEmail(x.Email);

            var userprof = await _userProfile.GetById(editUserProfile);
          
            if (userprof == null)
            {
                return RedirectToAction("UserError");
            }
            else
            {
                return View(userprof);
            }
            
           
        }

        [HttpGet]
        public IActionResult UserError()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            
            //var locallist = await _local.GetLGAsById(_userProfile.)
            //var faculty = await _faculty.GetAll();
            var department = await _department.GetAll();
           

            //var facultyList = faculty.Select(f => new SelectListItem()
            //{
            //    Value = f.Id.ToString(),
            //    Text = f.Name
            //});

            var departmentList = department.Select(d => new SelectListItem()
            {
                Value = d.Id.ToString(),
                Text = d.DeptName
            });

            ViewBag.users =  _context.Users.ToList();
            //ViewBag.faculty = facultyList;
            ViewBag.department = departmentList;
            ViewBag.state = _context.NewStates.ToList();
            //ViewBag.local = _context.LGAs.Where(userProfile.NewState.Id = userProfile.LGA.NewState.Id)
            //    .Select(UserProfile => new { Id = userProfile.LGA.Id, Name = userProfile.LGA.Name }).ToList();
           
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(UserProfile userProfile)
        {
            //userProfile.NewStates = "state";
            //userProfile.LGAs = "Lga";
            userProfile.CreatedBy = _userManager.GetUserName(User);

            var createUserProfile = await _userProfile.AddAsync(userProfile);
           
            if (createUserProfile)
            {
                Alert("UserProfile created successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            Alert("UserProfile not created!", NotificationType.error);
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {


            //var user = _userManager.GetUserName(User);
            //var x = await _userManager.FindByNameAsync(user);

            //var userid = _userProfile.GetIdByEmail(x.Email);

            var editUserProfile = await _userProfile.GetById(id);

            //var editUserProfile = await _userProfile.GetById(id);

            if (editUserProfile == null)
            {
                return RedirectToAction("Index");
            }
            
            var department = await _department.GetAll();

            var departmentList = department.Select(d => new SelectListItem()
            {
                Value = d.Id.ToString(),
                Text = d.DeptName
            });

            ViewBag.users = _context.Users.ToList();
           
            ViewBag.department = departmentList;
            ViewBag.state = _context.NewStates.ToList();

           

            return View(editUserProfile);
        }

        

        [HttpPost]
        public async Task<IActionResult> Edit(UserProfile userProfile)
        {
            
            var editUserProfile = await _userProfile.UpdateUser(userProfile);

            if (editUserProfile && ModelState.IsValid)
            {
                
                Alert("UserProfile edited successfully.", NotificationType.success);
                return RedirectToAction("Index");
                
            }
            Alert("UserProfile not edited!", NotificationType.error);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditUser()
        {

            var user = _userManager.GetUserName(User);
            var x = await _userManager.FindByNameAsync(user);

            var id = _userProfile.GetIdByEmail(x.Email);

            //var editUserProfile = await _userProfile.GetById(editUserProfile);

            var editUserProfile = await _userProfile.GetById(id);

            if (editUserProfile == null)
            {
                return RedirectToAction("Index");
            }

            var department = await _department.GetAll();

            var departmentList = department.Select(d => new SelectListItem()
            {
                Value = d.Id.ToString(),
                Text = d.DeptName
            });

            ViewBag.users = _context.Users.ToList();

            ViewBag.department = departmentList;
            ViewBag.state = _context.NewStates.ToList();



            return View(editUserProfile);
        }



        [HttpPost]
        public async Task<IActionResult> EditUser(UserProfile userProfile)
        {
            var user = _userManager.GetUserName(User);
            var x = await _userManager.FindByNameAsync(user);

            userProfile.Id = _userProfile.GetIdByEmail(x.Email);
            var editUserProfile = await _userProfile.UpdateUser(userProfile);

            if (editUserProfile)
            {

                Alert("UserProfile edited successfully.", NotificationType.success);
                return RedirectToAction("UserIndex");

            }
            Alert("UserProfile not edited!", NotificationType.error);
            return View();
        }




        public async Task<IActionResult> Delete(int id)
        {
            var deleteUserProfile = await _userProfile.Delete(id);

            if (deleteUserProfile)
            {
                Alert("UserProfile deleted successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            Alert("UserProfile not deleted!", NotificationType.error);
            return View();
        }


        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "User");
        }

        public JsonResult GetLGA(int id)
        {
            int stateid = Convert.ToInt32(id);
            var local =  _local.GetLGAsById(stateid);


            var localList = local.Select(f => new SelectListItem()
            {
                Value = f.Id.ToString(),
                Text = f.Name
            });

            return Json(localList);
            //List<LGA> list = new List<LGA>();
            //list = _context.LGAs.Where(a => a.NewState.Id == NewStateId).ToList();
            //list.Insert(0, new LGA { Id = 0, Name = "Select Local Government" });
            ////return Json(new SelectList(list, "Id", "Name"));
            //return Json(list.Select(l => new SelectListItem()
            //{
            //    Value = l.Id.ToString(),
            //    Text = l.Name
            //}));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
