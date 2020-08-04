using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffPortal.Entities;

namespace StaffPortal.Inteface
{
    public interface ISalary
    {
        //void Add(Salary sal);
        //Task<bool> AddAsync(Salary sal);
        Task<bool> Update(Salary dept);
        Task<IEnumerable<Salary>> GetAll();
        Task<Salary> GetById(int Id);
        int GetIdByEmail(string email);
        Task<bool> Delete(int Id);
    }
}
