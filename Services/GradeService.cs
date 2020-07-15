using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffPortal.Data;
using StaffPortal.Entities;
using Microsoft.EntityFrameworkCore;
using StaffPortal.Interface;

namespace StaffPortal.Services
{
    public class GradeService : IGrade
    {
        private StaffPortalDataContext _context;
        public GradeService(StaffPortalDataContext context)
        {
            _context = context;
        }

        public void Add(Grade grade) //Add
        {
              _context.Add(grade);
           
            _context.SaveChanges();
        }
        public async Task<bool> AddAsync(Grade grade) //AddAsync
        {
            try
            {
                await _context.AddAsync(grade);
               
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
            // find the entity/object
            var _grade = await _context.Grades.FindAsync(Id);

            if(_grade != null)
            {
                _context.Grades.Remove(_grade);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Grade>> GetAll() //GetAll
        {

            return await _context.Grades.ToListAsync();
        }

        public async Task<Grade> GetById(int Id) //GetById
        {
            var _grade = await _context.Grades.FindAsync(Id);

            return _grade;
        }

        public async Task<bool> Update(Grade grade) //Update
        {
            var _grade = await _context.Grades.FindAsync(grade.Id);
            if(grade != null)
            {
                grade.GradeName = _grade.GradeName;
                grade.Level = _grade.Level;
                grade.Step = _grade.Step;


                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }


    }
}
