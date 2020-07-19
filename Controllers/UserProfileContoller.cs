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

namespace StaffPortal.Controllers
{
    public class UserProfileController : BaseController
    {
        private IUserProfile _userProfile;
        private IFaculty _faculty;
        private IDepartment _department;
        private IState _state;
        
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfileController(IUserProfile userProfile, IFaculty faculty, IDepartment department,IState state, UserManager<ApplicationUser> userManager)
        {
            _userProfile = userProfile;
            _faculty = faculty;
            _department = department;
            _state = state;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _userProfile.GetAll();

            if (model != null)
                return View(model);
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var faculty = await _faculty.GetAll();
            var department = await _department.GetAll();
            var state = await _state.GetAll();

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

            ViewBag.faculty = facultyList;
            ViewBag.department = departmentList;
            ViewBag.state = stateList;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(UserProfile userProfile)
        {
            //userProfile.CreatedBy = _userManager.GetUserName(User);

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
            
           
           
            

            var editUserProfile = await _userProfile.GetById(id);

            if (editUserProfile == null)
            {
                return RedirectToAction("Index");
            }
            var faculty = await _faculty.GetAll();
            
            var facultyList = faculty.Select(f => new SelectListItem()
            {
                Value = f.Id.ToString(),
                Text = f.Name
            });
            var department = await _department.GetAll();
          
            var departmentList = department.Select(d => new SelectListItem()
            {
                Value = d.Id.ToString(),
                Text = d.DeptName
            });
            var state = await _state.GetAll();

            var stateList = state.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });


            ViewBag.faculty = facultyList;
            ViewBag.department = departmentList;
            ViewBag.state = stateList;
            
            return View(editUserProfile);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserProfile userProfile)
        {
            //var editFaculty = await _faculty.GetById(id);
            var editUserProfile = await _userProfile.Update(userProfile);

            if (editUserProfile && ModelState.IsValid)
            {
                //    editFaculty.Name = faculty.Name;
                //    context.SaveChanges();
                Alert("UserProfile edited successfully.", NotificationType.success);
                return RedirectToAction("Index");
                //return RedirectToAction("Details", new { id = editFaculty.Id });
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
        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
