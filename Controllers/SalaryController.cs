using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffPortal.Entities;
using StaffPortal.Inteface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffPortal.Enums;
using StaffPortal.Interface;
using StaffPortal.Data;

namespace StaffPortal.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class SalaryController : BaseController
    {
        private StaffPortalDataContext _context;
        private IGrade _grade;
        private IAccount _account;
        private ISalary _sal;
        private readonly UserManager<ApplicationUser> _userManager;
        public SalaryController(IGrade grade, IAccount account, ISalary sal,  StaffPortalDataContext context, UserManager<ApplicationUser> userManager)
        {
            _grade = grade;
            _account = account;
            _sal = sal;
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _sal.GetAll();
            if (model != null)
            {
                return View(model);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PersonalSalary()
        {

            var user = _userManager.GetUserName(User);
            var x = await _userManager.FindByNameAsync(user);

            var editsal = _sal.GetIdByEmail(x.Email);

            var usersal = await _sal.GetById(editsal);

            if (usersal == null)
            {
                return RedirectToAction("UserError");
            }
            else
            {
                return View(usersal);
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
            var accountName = await _account.GetAll();
            var accountListName = accountName.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.Email
            });

            var gradeName = await _grade.GetAll();
            var gradeListName = gradeName.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.GradeName
            });
            var gradeLevel = await _grade.GetAll();
            var gradeListLevel = gradeLevel.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.Level.ToString()
            });
            var gradeStep = await _grade.GetAll();
            var gradeListStep = gradeStep.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.Step.ToString()
            });
            //ViewBag.accountName = accountListName;
            ViewBag.gradeName = gradeListName;
            ViewBag.gradeLevel = gradeListLevel;
            ViewBag.gradeStep = gradeListStep;
            ViewBag.users = _context.Users.ToList();

            return View(new Salary());
        }

        [HttpPost]
        public IActionResult Create(Salary salary)
        {
            //FOR TAX
            salary.NetSalary = salary.BasicSalary;
            salary.Tax =  salary.TaxPercent * salary.BasicSalary;
            //salary.TaxItemType = "Deduction";
            if (salary.TaxItemType == "Allowance")
            {
                salary.NetSalary += salary.Tax;
            }
            else if(salary.TaxItemType == "Deduction")
                salary.NetSalary -= salary.Tax;
            //FOR HOUSING
            salary.Housing = salary.HousingPercent * salary.BasicSalary;
            //salary.HousingItemType = "Allowance";

            if (salary.HousingItemType == "Allowance")
            {
                salary.NetSalary += salary.Housing;
            }
            else if (salary.HousingItemType == "Deduction")
                salary.NetSalary -= salary.Housing;

            //FOR LUNCH
            salary.Lunch =  salary.LunchPercent * salary.BasicSalary;
            //salary.LunchItemType = "Allowance";
            if (salary.LunchItemType == "Allowance")
                salary.NetSalary += salary.Lunch;
           else if (salary.LunchItemType == "Deduction")
                salary.NetSalary -= salary.Lunch;

            //FOR TRANSPORT
            salary.Transport = salary.TransportPercent * salary.BasicSalary;
            //salary.TransportItemType = "Allowance";
            if (salary.TransportItemType == "Allowance")
                salary.NetSalary += salary.Transport;
            else if (salary.TransportItemType == "Deduction")
                salary.NetSalary -= salary.Transport;

            //FOR MEDICAL
            salary.Medical = salary.MedicalPercent * salary.BasicSalary;
            //salary.MedicalItemType = "Allowance";
            if (salary.MedicalItemType == "Allowance")
                salary.NetSalary += salary.Medical;
            else if (salary.MedicalItemType == "Deduction")
                salary.NetSalary -= salary.Medical;
            //TOTAL SALARY


            //salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
            //    + salary.Transport + salary.Medical - salary.Tax;

            //salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
            //    + salary.Transport + salary.Medical ;
            _context.Add(salary);
             _context.SaveChanges();

           //return View(salary);
            //var createUserProfile = await _userProfile.AddAsync(userProfile);

            if (salary != null)
            {
                Alert("UserProfile created successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            Alert("UserProfile not created!", NotificationType.error);
            return View(salary);

        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var editSalary = await _sal.GetById(id);


            if (editSalary == null)
            {
                return RedirectToAction("Index");
            }

            var accountName = await _account.GetAll();
            var accountListName = accountName.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.Email
            });

            var gradeName = await _grade.GetAll();
            var gradeListName = gradeName.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.GradeName
            });
            var gradeLevel = await _grade.GetAll();
            var gradeListLevel = gradeLevel.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.Level.ToString()
            });
            var gradeStep = await _grade.GetAll();
            var gradeListStep = gradeStep.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.Step.ToString()
            });
            ViewBag.accountName = accountListName;
            ViewBag.gradeName = gradeListName;
            ViewBag.gradeLevel = gradeListLevel;
            ViewBag.gradeStep = gradeListStep;

            
            return View(editSalary);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Salary s)
        {

            var editSalary = await _sal.Update(s);
            if (editSalary && ModelState.IsValid)
            {
                Alert("Salary Edited successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Salary not Edited!", NotificationType.error);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deleteSalary = await _sal.Delete(id);
            if (deleteSalary)
            {
                Alert("Salary Details Deleted successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("Salary Details not Deleted!", NotificationType.error);
            }
            return View();
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Salary");
        }
    }
}
