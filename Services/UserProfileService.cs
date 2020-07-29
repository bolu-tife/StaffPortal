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
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfileService(StaffPortalDataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public void Add(UserProfile userprofile) //Add
        //{
        //      _context.Add(userprofile);

        //    _context.SaveChanges();
        //}
        //public async Task<bool> AddAsync(UserProfile userprofile) //AddAsync
        //{
        //    try
        //    {
        //        await _context.AddAsync(userprofile);

        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public async Task<bool> Delete(int Id)//Delete
        //{
        //    // find the entity/object
        //    var _userprofile = await _context.UserProfiles.FindAsync(Id);

        //    if(_userprofile != null)
        //    {
        //        _context.UserProfiles.Remove(_userprofile);
        //        _context.SaveChanges();
        //        return true;
        //    }

        //    return false;
        //}

        ////public async Task<string> GetEmail() //GetById
        ////{
        ////    _userManager userm;
        ////    ApplicationUser user = await _userManager.FindByEmailAsync( userm.Email);
        ////    return user.Email;
        ////}

        //public async Task<IEnumerable<UserProfile>> GetAll() //GetAll
        //{

        //    return await _userManager.Include(s => s.NewState).Include(f => f.Faculty).Include(d => d.Department).ToListAsync();
        //}

        //public async Task<UserProfile> GetById(int Id) //GetById
        //{
        //    var _userprofile = await _context.UserProfiles.FindAsync(Id);

        //    return _userprofile;
        //}
        public async Task<bool> Update(ApplicationUser Apuser) //Update
        {

            //ApplicationUser _userprofile = await _userManager.FindByIdAsync(Apuser.Id);
            //ApplicationUser x = await _userManager.FindByEmailAsync(Apuser.Email);
            ////var _userprofile = await _context.AspNetUsers.FindAsync(Apuser.Id);
            //if (_userprofile != null)
            //{
            //    _userprofile.FirstName = Apuser.FirstName;
            //    _userprofile.LastName = Apuser.LastName;
            //    _userprofile.Email = Apuser.Email;
            //    //_userprofile. = Apuser.Email;
            //    //_userprofile.FacultyId = Apuser.FacultyId;
            //    //_userprofile.DepartmentId = Apuser.DepartmentId;
            //    //_userprofile.StateId = Apuser.StateId;
            //    //_userprofile.LocalId = Apuser.LocalId;
            //    //_userprofile.country = Apuser.country;


            await _context.SaveChangesAsync();
            //    return true;
            //}

            return false;

        }

        public Task<IEnumerable<UserProfile>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
