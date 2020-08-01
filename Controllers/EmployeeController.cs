using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffPortal.Models;
using Microsoft.AspNetCore.Mvc;
using StaffPortal.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using StaffPortal.Data;

namespace StaffPortal.Controllers
{
    public class EmployeeController : BaseController
    {
        private StaffPortalDataContext _context;


        private IGrade _grade;
        private IFaculty _faculty;
        private IDepartment _dept;
        private IAccount _account;


        public EmployeeController(IGrade grade, IFaculty faculty, IDepartment department, IAccount account, StaffPortalDataContext context)
        {
            _grade = grade;
            _faculty = faculty;
            _dept = department;
            _context = context;
            _account = account;
        }

        public async Task<IActionResult> Index()
        {
            /* var grade = await _grade.GetAll();
             var gradeList = grade.Select(a => new SelectListItem()
             {
                 Value = a.Id.ToString(),
                 Text = a.Level.ToString()                 
             });
             */
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
            //ViewBag.faculty = facultyList;
            //ViewBag.grade = gradeList;

            return View(new Salary());
        }

        [HttpPost]
        public IActionResult Index(Salary salary)
        {
            //ViewBag.gradeLevel
            //var lev = salary.Grade.Level;
            //var lev2 = salary.Grade;
            var lev3 = salary.GradeId;
          //  var lev4 = salary.Grade.Step;
            //var lev5 = ViewBag.Grade.Step;
            //var lev6 = ViewBag.gradeListLevel;

            if (salary.GradeId == 1)
            {

                salary.BasicSalary = 5000;

                //FOR TAX
                salary.Tax = 0.1 * salary.BasicSalary;
                salary.TaxPercent = 10;
                salary.TaxItemType = "Deduction";

                //FOR HOUSING
                salary.Housing = 0.1 * salary.BasicSalary;
                salary.HousingPercent = 10;
                salary.HousingItemType = "Allowance";

                //FOR LUNCH
                salary.Lunch = 0.1 * salary.BasicSalary;
                salary.LunchPercent = 10;
                salary.LunchItemType = "Allowance";

                //FOR TRANSPORT
                salary.Transport = 0.1 * salary.BasicSalary;
                salary.TransportPercent = 10;
                salary.TransportItemType = "Allowance";

                //FOR MEDICAL
                salary.Medical = 0.1 * salary.BasicSalary;
                salary.MedicalPercent = 10;
                salary.MedicalItemType = "Allowance";

                //TOTAL SALARY
                salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
                    + salary.Transport + salary.Medical - salary.Tax;
               
            }
            else
            {
                // Basic Salary
                salary.BasicSalary = 1000;

                //For Tax
                salary.Tax = 0.5 * salary.BasicSalary;
                salary.TaxPercent = 5;
                salary.TaxItemType = "Deduction";

                //For Housing
                salary.Housing = 0.5 * salary.BasicSalary;
                salary.HousingPercent = 5;
                salary.HousingItemType = "Allowance"; 

                //FOR LUNCH
                salary.Lunch = 0.5 * salary.BasicSalary;
                salary.LunchPercent = 5;
                salary.LunchItemType = "Allowance";

                //FOR TRANSPORT
                salary.Transport = 0.5 * salary.BasicSalary;
                salary.TransportPercent = 5;
                salary.TransportItemType = "Allowance";

                //FOR MEDICAL
                salary.Medical = 0.5 * salary.BasicSalary;
                salary.MedicalPercent = 5;
                salary.MedicalItemType = "Allowance";

                //FOR TOTAL SALARY
                salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
                    + salary.Transport + salary.Medical - salary.Tax;

            }
            _context.Add(salary);
            _context.SaveChanges();

            return View(salary);
        }


       
    }
}