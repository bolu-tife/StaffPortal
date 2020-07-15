using StaffPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffPortal.Interface
{
    public interface IGrade
    {
        void Add(Grade author);
        Task<bool> AddAsync(Grade grade);
        Task<bool> Update(Grade grade);
        Task<IEnumerable<Grade>> GetAll();
        Task<Grade> GetById(int Id);
        Task<bool> Delete(int Id);
    }
}
