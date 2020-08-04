using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffPortal.Data;
using StaffPortal.Entities;
using Microsoft.EntityFrameworkCore;
using StaffPortal.Interface;
using Microsoft.AspNetCore.Identity;
using StaffPortal.Models;
using System.Linq;

namespace StaffPortal.Services
{
    public class UserProfileService : IUserProfile
    {
        private StaffPortalDataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfileService(StaffPortalDataContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public void Add(UserProfile userprofile) //Add
        {
            _context.Add(userprofile);
           
            _context.SaveChanges();
        }

        public async Task<bool> AddAsync(UserProfile userprofile) //AddAsync
        {
            try
            {
                await _context.AddAsync(userprofile);
               
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        public async Task<bool> Delete(int Id)//Delete
        {
           
            var _userprofile = await _context.UserProfiles.FindAsync(Id);

            if(_userprofile != null)
            {
                _context.UserProfiles.Remove(_userprofile);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        
       
        public async Task<IEnumerable<UserProfile>> GetAll()
        {

            return await _context.UserProfiles.Include(d => d.Department).Include(l => l.LGA).Include(s => s.NewState).ToListAsync();
            //return await _context.UserProfiles.Include(d => d.Department).ToListAsync();
        }

        public string FindNameByStateId(int id)
        {
            var name = _context.NewStates.First(n => n.Id == id);
            return name.Name;
        }

        public string FindNameByLocalId(int id)
        {
            var name = _context.LGAs.First(n => n.Id == id);
            return name.Name;
        }

        public string FindNameByDepartmentId(int id)
        {
            var name = _context.Departments.First(n => n.Id == id);
            return name.DeptName;
        }

        public async Task<UserProfile> GetById(int Id)
        {
            var _userprofile = await _context.UserProfiles.FindAsync(Id);

            return _userprofile;
        }

        public int GetIdByEmail(string Email)
        {
            
            try
            {
                var _user = _context.UserProfiles.First(u => u.Email == Email);
                
                return _user.Id;
            }
            catch (Exception)
            { return 0; }


        }


        //public async Task<IEnumerable<Local>> GetLocalByStateIdAsync(int id)
        //{
           
        //    try
        //    {
        //        return await _context.Locals.Where(u => u.States.Id == id);
        //        //var _user =await _userManager.FindByEmailAsync(Email);

        //        //var id = _context.UserProfiles.First(u => u.Email == _user.Email).Id;
        //        //return _user.Id;
        //    }
        //    catch (Exception)
        //    { return 0; }


        //}


        public async Task<bool> Update(UserProfile userprofile) //Update
        {
            var _userprofile = await _context.UserProfiles.FindAsync(userprofile.Id);
            if (_userprofile != null)
            {
                _userprofile.FirstName = userprofile.FirstName;
                _userprofile.LastName = userprofile.LastName;
                //_userprofile.Email = userprofile.Email;

                //_userprofile.Department.FacultyId = userprofile.Department.FacultyId;
                _userprofile.DepartmentId = userprofile.DepartmentId;

                _userprofile.NewStateId = userprofile.NewStateId;
                _userprofile.LGAId = userprofile.LGAId;
                _userprofile.Country = userprofile.Country;
                

                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<bool> UpdateUser(UserProfile userprofile) //Update
        {
            var _userprofile = await _context.UserProfiles.FindAsync(userprofile.Id);
            if (_userprofile != null)
            {
                _userprofile.FirstName = userprofile.FirstName;
                _userprofile.LastName = userprofile.LastName;
                //_userprofile.Email = userprofile.Email;

                //_userprofile.Department.FacultyId = userprofile.Department.FacultyId;
                _userprofile.DepartmentId = userprofile.DepartmentId;

                _userprofile.NewStateId = userprofile.NewStateId;
                _userprofile.LGAId = userprofile.LGAId;
                _userprofile.Country = userprofile.Country;


                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }


    }
}
