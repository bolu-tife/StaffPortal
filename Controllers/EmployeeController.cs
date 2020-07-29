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


        public EmployeeController( IGrade grade, IFaculty faculty, IDepartment department, StaffPortalDataContext context)
        {
            _grade = grade;
            _faculty = faculty;
            _dept = department;
            _context = context;
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
            if(ViewBag.gradeLevel == 6)
            {

                salary.BasicSalary = 1000;
                salary.Tax = 0.1 * salary.BasicSalary;
                salary.Housing = 0.1 * salary.BasicSalary;
                salary.Lunch = 0.1 * salary.BasicSalary;
                salary.Transport = 0.1 * salary.BasicSalary;
                salary.Medical = 0.1 * salary.BasicSalary;
                salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
                    + salary.Transport + salary.Medical - salary.Tax;
                ////var sal = 2000;
                ////float _house = 10 / 100 * sal;
                ////float _lunch = 10 / 100 * 2000;
                ////salary.BasicSalary = sal;
                ////salary.Tax = 20;
                //////var _tax = salary.Tax;

                ////salary.Housing = _house;
                ////salary.Lunch = _lunch;

                ////salary.Transport = 10 / 100 * sal;
                ////var _trans = salary.Transport;
                ////salary.Medical = 10 / 100 * sal;
                ////var _med = salary.Medical;
                ////var net = _house + _lunch + _med + _trans ;
                ////salary.NetSalary = net; 
            }
            else
            {
                salary.BasicSalary = 1000;
                salary.Tax = 0.5* salary.BasicSalary;
                salary.Housing = 0.5 * salary.BasicSalary;
                salary.Lunch = 0.5 * salary.BasicSalary;
                salary.Transport = 0.5 * salary.BasicSalary;
                salary.Medical = 0.5 * salary.BasicSalary;
                salary.NetSalary = salary.BasicSalary + salary.Housing + salary.Lunch
                    + salary.Transport + salary.Medical - salary.Tax;

            }
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