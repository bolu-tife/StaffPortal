using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StaffPortal.Data;
using StaffPortal.Entities;
using StaffPortal.Inteface;
using Microsoft.EntityFrameworkCore;

namespace StaffPortal.Services
{
    public class SalaryService :ISalary
    {
        private StaffPortalDataContext _context;
        public SalaryService(StaffPortalDataContext context)
        {
            _context = context;
        }
/*
        public void Add(Salary s)
        {
           
            _context.Add(s);
            _context.SaveChanges();
        }
        public async Task<bool> AddAsync(Salary salary)
        {
            try
            {
              
                await _context.AddAsync(salary);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        */
        public async Task<bool> Delete(int Id)
        {
            // find the entity/object
            var s = await _context.Salaries.FindAsync(Id);

            if (s != null)
            {
                _context.Salaries.Remove(s);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Salary>> GetAll()
        {
            return await _context.Salaries.Include(g=>g.Grade).Include(u => u.ApplicationUser).ToListAsync();
        }

        public async Task<Salary> GetById(int Id)
        {
            var s = await _context.Salaries.FindAsync(Id);

            return s;
        }

        public async Task<bool> Update(Salary salary)
        {
            var s = await _context.Salaries.FindAsync(salary.ID);
            if (s != null)
            {
                s.GradeId = salary.ID;
                s.BasicSalary = salary.BasicSalary;
                s.LunchPercent = salary.LunchPercent;
                salary.TaxPercent = salary.TaxPercent;
                s.TransportPercent = salary.TransportPercent;
                s.HousingPercent = salary.HousingPercent;
                s.MedicalPercent = salary.MedicalPercent;


                //s.TaxPayItem = salary.PayItem;
                //s.PayItemType = salary.PayItem;
                //s.Amount = salary.Amount;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
