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
        public int GetIdByEmail(string Email)
        {

            try
            {
                var _user = _context.Salaries.First(u => u.Email == Email);

                return _user.ID;
            }
            catch (Exception)
            { return 0; }


        }

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

        //public string FindGradeByGradeId(int id)
        //{
        //    var name = _context.NewStates.First(n => n.Id == id);
        //    return name.Name;
        //}

        public async Task<IEnumerable<Salary>> GetAll()
        {
            return await _context.Salaries.Include(g=>g.Grade)/*.Include(u => u.ApplicationUser)*/.ToListAsync();
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
                s.GradeId = salary.GradeId;
                s.BasicSalary = salary.BasicSalary;
                s.LunchPercent = salary.LunchPercent;
                s.TaxPercent = salary.TaxPercent;
                s.TransportPercent = salary.TransportPercent;
                s.HousingPercent = salary.HousingPercent;
                s.MedicalPercent = salary.MedicalPercent;
                s.TaxItemType = salary.TaxItemType;
                s.TaxPercent = salary.TaxPercent;

                s.HousingItemType = salary.HousingItemType;
                s.HousingPercent = salary.HousingPercent;

                s.MedicalItemType = salary.MedicalItemType;
                s.MedicalPercent = salary.MedicalPercent;
                s.GradeLevel = salary.GradeLevel;
                s.GradeName = salary.GradeName;
                s.GradeStep = salary.GradeStep;

                //s.NetSalary = s.BasicSalary;
                s.Tax = s.TaxPercent * s.BasicSalary / 100; ;
                s.TotAllowance = 0.0;
                s.TotDeduction = 0.0;
                //salary.TaxItemType = "Deduction";
                if (s.TaxItemType == "Allowance")
                {
                    //s.NetSalary += s.Tax;
                    s.TotAllowance += s.Tax;
                }
                else if (s.TaxItemType == "Deduction")
                {
                    //s.NetSalary -= salary.Tax;
                    s.TotDeduction -= s.Tax;
                }
            
                //FOR HOUSING
                s.Housing = s.HousingPercent * s.BasicSalary / 100; ;
                //salary.HousingItemType = "Allowance";

                if (s.HousingItemType == "Allowance")
                {
                    //s.NetSalary += s.Housing;
                    s.TotAllowance += s.Housing;
                }
                else if (s.HousingItemType == "Deduction")
                {
                    //s.NetSalary -= s.Housing;
                    s.TotDeduction -= s.Housing;
                }
                    

                //FOR LUNCH
                s.Lunch = s.LunchPercent * s.BasicSalary / 100; ;
                //salary.LunchItemType = "Allowance";
                if (s.LunchItemType == "Allowance")
                {
                    //s.NetSalary += s.Lunch;
                    s.TotAllowance += s.Lunch;
                }
                else if (s.LunchItemType == "Deduction")
                {
                    //s.NetSalary -= s.Lunch;
                    s.TotDeduction -= s.Lunch;
                }
                    

                //FOR TRANSPORT
                s.Transport = s.TransportPercent * s.BasicSalary / 100; ;
                //s.TransportItemType = "Allowance";
                if (s.TransportItemType == "Allowance")
                {

                    //s.NetSalary += s.Transport;
                    s.TotAllowance += s.Transport;
                }
                else if (s.TransportItemType == "Deduction")
                {
                    //s.NetSalary -= s.Transport;
                    s.TotDeduction -= s.Transport;
                }

                //FOR MEDICAL
                s.Medical = s.MedicalPercent * s.BasicSalary / 100; ;
                //s.MedicalItemType = "Allowance";
                if (s.MedicalItemType == "Allowance")
                {
                    //s.NetSalary += s.Medical;
                    s.TotAllowance += s.Medical;
                }
                else if (s.MedicalItemType == "Deduction")
                {

                    //s.NetSalary -= s.Medical;
                    s.TotDeduction -= s.Medical;
                }

                s.NetSalary = s.BasicSalary + s.TotAllowance + s.TotDeduction;
                //s.TaxPayItem = s.PayItem;
                //s.PayItemType = s.PayItem;
                //s.Amount = s.Amount;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
