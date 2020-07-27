using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffPortal.Entities;

namespace StaffPortal.Interface
{
    public interface IUserProfile
    {
        //void Add(UserProfile userprofile);
        //Task<bool> AddAsync(UserProfile userprofile);
        Task<bool> Update(ApplicationUser ApUser);
        Task<IEnumerable<UserProfile>> GetAll();
        //Task<UserProfile> GetById(int Id);
        //Task<bool> Delete(int Id);
    }
}
