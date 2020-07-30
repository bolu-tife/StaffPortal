using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaffPortal.Models;
using StaffPortal.Interface;
using StaffPortal.Entities;
using StaffPortal.Enums;
using Microsoft.AspNetCore.Identity;

namespace StaffPortal.Controllers
{
    public class DepartmentController : BaseController

    {
        private IDepartment _department;

        private readonly UserManager<ApplicationUser> _userManager;
        public DepartmentController(IDepartment department, UserManager<ApplicationUser> userManager)
        {
            _department = department;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _department.GetAll();

            if (model != null)
                return View(model);
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            department.CreatedBy = _userManager.GetUserName(User);
            department.DateCreated = DateTime.Now;
            var createAepartment = await _department.AddAsync(department);

            //if (createAepartment)
            //{
            //    return RedirectToAction("Index");
            //}

            if (createAepartment)
            {
                Alert("Aepartment created successfully😃.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Aepartment not created😔!", NotificationType.error);
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var editDepartment = await _department.GetById(id);

            if (editDepartment == null)
            {
                return RedirectToAction("Index");
            }
            return View(editDepartment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            department.CreatedBy = _userManager.GetUserName(User);
            department.DateCreated = DateTime.Now;
            var editAepartment = await _department.Update(department);

            if (editAepartment && ModelState.IsValid)
            {
                Alert("Aepartment edited successfully😃.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Aepartment not edited😔.", NotificationType.error);
            }
            return View();
        }


        public async Task<IActionResult> Delete(int id)
        {
            var deleteDepartment = await _department.Delete(id);
            if (deleteDepartment)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Department");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
