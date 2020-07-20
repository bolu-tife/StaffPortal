using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffPortal.Data;
using StaffPortal.Entities;
using Microsoft.EntityFrameworkCore;
using StaffPortal.Interface;

namespace StaffPortal.Services
{
    public class LocalService : ILocal
    {
        private StaffPortalDataContext _context;
        public LocalService(StaffPortalDataContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Local>> GetAll()
        //{
        //    return await _context.Locals.ToListAsync();
        //}

        //public async Task<Local> GetById(int Id)
        //{
        //    var _local = await _context.Locals.FindAsync(Id);

        //    return _local;
        //}
    }
}
