using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffPortal.Entities
{
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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

        

    }
}



