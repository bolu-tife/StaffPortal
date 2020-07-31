using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffPortal.Data;
using StaffPortal.Entities;
using Microsoft.EntityFrameworkCore;
using StaffPortal.Interface;
using Microsoft.AspNetCore.Identity;
using StaffPortal.Models;

namespace StaffPortal.Services
{
    public class UserProfileService : IUserProfile
    {
        private StaffPortalDataContext _context;
        
        public UserProfileService(StaffPortalDataContext context)
        {
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

            return await _context.UserProfiles.Include(f => f.Faculty).Include(d => d.Department).ToListAsync();
        }

        public async Task<UserProfile> GetById(int Id)
        {
            var _userprofile = await _context.UserProfiles.FindAsync(Id);

            return _userprofile;
        }
        public async Task<bool> Update(UserProfile userprofile) //Update
        {
            var _userprofile = await _context.UserProfiles.FindAsync(userprofile.Id);
            if (_userprofile != null)
            {
                _userprofile.FirstName = userprofile.FirstName;
                _userprofile.LastName = userprofile.LastName;
                _userprofile.Email = userprofile.Email;

                _userprofile.FacultyId = userprofile.FacultyId;
                _userprofile.DepartmentId = userprofile.DepartmentId;

                _userprofile.NewStates = userprofile.NewStates;
                _userprofile.LGAs = userprofile.LGAs;
                _userprofile.Country = userprofile.Country;
                

                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
       

    }
}
