using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffPortal.Data;
using StaffPortal.Entities;
using Microsoft.EntityFrameworkCore;
using StaffPortal.Interface;

namespace StaffPortal.Services
{
    public class StateService : IState
    {
        private StaffPortalDataContext _context;
        public StateService(StaffPortalDataContext context)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<State>> GetAll() //GetAll
        {

            return await _context.NgStates.ToListAsync();
        }

        public async Task<State> GetById(int Id) //GetById
        {
            var _state = await _context.NgStates.FindAsync(Id);

            return _state;
        }
        
       

    }
}
