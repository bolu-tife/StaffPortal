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
        public string Email { get; set; }
        
        
      
        public string NewStates { get; set; }
        public string LGAs { get; set; }
        public string Country { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public string GradeLevel { get; set; }
        public string GradeStep { get; set; }
        public string GradeName { get; set; }


        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string FacultyName { get; set; }
        public Department Department { get; set; }

        public double NetPay { get; set; }
        public double TotDeduction { get; set; }
        public double TotAllowance { get; set; }


        public string CreatedBy { get; set; }
        private DateTime? dateCreated = null;
        public DateTime DateCreated
        {
            get
            {
                return dateCreated ?? DateTime.Now;
            }

            set { dateCreated = value; }
        }

    }
}



