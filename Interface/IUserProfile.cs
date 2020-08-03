using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffPortal.Entities;

namespace StaffPortal.Interface
{
    public interface IUserProfile
    {
        void Add(UserProfile userprofile);
        Task<bool> AddAsync(UserProfile userprofile);
        Task<bool> Update(UserProfile userprofile);
        Task<bool> UpdateUser(UserProfile userprofile);
        Task<IEnumerable<UserProfile>> GetAll();
        int GetIdByEmail(string email);

        Task<UserProfile> GetById(int Id);
        Task<bool> Delete(int Id);
    }
}
