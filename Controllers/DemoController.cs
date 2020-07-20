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
using StaffPortal.Data;

namespace StaffPortal.Controllers
{
    public class DemoController : BaseController
    {

        private readonly StaffPortalDataContext _context;

        private readonly SignInManager<ApplicationUser> _signInManager;
       
        private IFaculty _faculty;
        private IDepartment _department;
        private IState _state;
        private ILocal _local;

        public DemoController(StaffPortalDataContext context, IFaculty faculty, IDepartment department, IState state,ILocal local,SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
            _faculty = faculty;
            _department = department;
            _state = state;
            _local = local;

        }
        public IActionResult Index()
        {
            List<State> statelist = new List<State>();
            statelist = (from state in _context.State
                         select state).ToList();

            statelist.Insert(0, new State { Id = 0, Name = "Select" });

            ViewBag.ListofStates = statelist;
            return View();
        }

        public JsonResult GetLocal(int StateId)
        {
            List<Local> locallist = new List<Local>();
            locallist = (from Local in _context.Local
                         where Local.StateId == StateId
                         select Local).ToList();
            locallist.Insert(0, new Local { Id = 0, Name = "Select" });

            return Json(new SelectList(locallist, "Id", "Name"));
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
