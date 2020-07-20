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
       
        public State State { get; set; }
        public Local Local { get; set; }
        public string country { get; set; }
        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }
        public int StateId { get; set; }
        public int LocalId { get; set; }

        public Department Department { get; set; }
        public Faculty Faculty { get; set; }


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
