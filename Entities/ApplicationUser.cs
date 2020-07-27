using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StaffPortal.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public NewState NewState { get; set; }
        //public NewLocal NewLocal { get; set; }
        //public string Country { get; set; }
        //public int DepartmentId { get; set; }
        //public int FacultyId { get; set; }
        //public int NewStateId { get; set; }
        //public int NewLocalId { get; set; }

        //public Department Department { get; set; }
        //public Faculty Faculty { get; set; }




        [NotMapped]
        public string FullName
        {
            get
            {

                return this.FirstName + " " + this.LastName;
            }
        }
        
    }
}
