using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffPortal.Models;
using Microsoft.AspNetCore.Mvc;
using StaffPortal.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffPortal.Data;
using StaffPortal.Entities;
using Microsoft.AspNetCore.Identity;

namespace StaffPortal.Controllers
{
    public class EmployeeController : BaseController
    {
        private StaffPortalDataContext _context;
        //private readonly UserManager<ApplicationUser> _userManager;
        //UserManager<ApplicationUser> userManager,
        //            _userManager = userManager;


        private IAccount _account;
        private IGrade _grade;
        private readonly IFaculty _faculty;
        private readonly IDepartment _dept;


        public EmployeeController( IGrade grade, IFaculty faculty, IDepartment department, IAccount account, StaffPortalDataContext context)
        {
            _grade = grade;
            _faculty = faculty;
            _dept = department;
            _context = context;
            _account = account;
        }

        public async Task<IActionResult> Index()
        {
            var accountName = await _account.GetAll();
            var userListName = accountName.Select(g => new SelectListItem()
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

            ViewBag.accountName = userListName;
            ViewBag.gradeName = gradeListName;
            ViewBag.gradeLevel = gradeListLevel;
            ViewBag.gradeStep = gradeListStep;


          /*
            var fac = await _faculty.GetAll();
            var FacList = fac.Select(f => new SelectListItem()
            {
                Value = f.Id.ToString(),
                Text = f.Name
            });


            ViewBag.fac = FacList;

            var dept = await _dept.GetAll();
            var deptList = dept.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.DeptName
            });
            ViewBag.dept = deptList;
            ViewBag.faculty = FacList;
            */

            return View(new Salary());
        }

        [HttpPost]
        public IActionResult Index(Salary salary)
        {
            var level = ViewBag.gradeLevel;


            if (level == 6)
            {
                //BASIC SALARY
                salary.BasicSalary = 5000;

                //For Tax
                salary.Tax = 0.1 * salary.BasicSalary;
                salary.TaxPercent = 10.0;
                salary.TaxItemType = "Deduction";

                //For Housing
                salary.Housing = 0.1 * salary.BasicSalary;
                salary.HousingPercent = 10;
                salary.HousingItemType = "Allowance";

                //For Lunch
                salary.Lunch = 0.1 * salary.BasicSalary;
                salary.LunchPercent = 10;
                salary.LunchItemType = "Allowance";

                //For Transport
                salary.Transport = 0.1 * salary.BasicSalary;
                salary.TransportPercent = 10;
                salary.TransportItemType = "Allowance";

                //For Medical
                salary.Medical = 0.1 * salary.BasicSalary;
                salary.MedicalPercent = 10;
                salary.MedicalItemType = "Allowance";

                //NET SALARY
                salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
                    + salary.Transport + salary.Medical - salary.Tax;
               }
            else
            {
                salary.BasicSalary = 1000;
                //For Tax
                salary.Tax = 0.1 * salary.BasicSalary;
                salary.TaxPercent = 10.0;
                salary.TaxItemType = "Deduction";

                //For Housing
                salary.Housing = 0.1 * salary.BasicSalary;
                salary.HousingPercent = 10;
                salary.HousingItemType = "Allowance";

                //For Lunch
                salary.Lunch = 0.1 * salary.BasicSalary;
                salary.LunchPercent = 10;
                salary.LunchItemType = "Allowance";

                //For Transport
                salary.Transport = 0.1 * salary.BasicSalary;
                salary.TransportPercent = 10;
                salary.TransportItemType = "Allowance";

                //For Medical
                salary.Medical = 0.1 * salary.BasicSalary;
                salary.MedicalPercent = 10;
                salary.MedicalItemType = "Allowance";

                //NET SALARY
                salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
                    + salary.Transport + salary.Medical - salary.Tax;

                /*        salary.Tax = 0.5* salary.BasicSalary;
                        salary.Housing = 0.5 * salary.BasicSalary;
                        salary.Lunch = 0.5 * salary.BasicSalary;
                        salary.Transport = 0.5 * salary.BasicSalary;
                        salary.Medical = 0.5 * salary.BasicSalary;
                        salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
                            + salary.Transport + salary.Medical - salary.Tax;
        */
            }
            //_context.Add(salary.PayItemType);
            _context.Add(salary);
            _context.SaveChanges();

            return View(salary);
        }


        /*  if (salary.grade.Level == 6)
          {
              salary.BasicSalary = 2000;
              salary.Tax = (10 / 100) * 2000;
              salary.Housing = (10 / 100) * 2000;
              salary.Lunch = (10 / 100) * 2000;
              salary.Transport = (10 / 100) * 2000;
              salary.Medical = (10 / 100) * 2000;
              salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
                  + salary.Transport + salary.Medical - salary.Tax;

          }
          else
          {
              salary.BasicSalary = 1000;
              salary.Tax = 0.5 * salary.BasicSalary;
              salary.Housing = 0.5 * salary.BasicSalary;
              salary.Lunch = 0.5 * salary.BasicSalary;
              salary.Transport = 0.5 * salary.BasicSalary;
              salary.Medical = 0.5 * salary.BasicSalary;
              salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
                  + salary.Transport + salary.Medical - salary.Tax;

          }
          // return RedirectToAction("Index");
          return View(salary);
      }
      */
    }
}