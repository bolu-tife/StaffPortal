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
        
        
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }


        public string NewStates { get; set; }
        public string LGAs { get; set; }
        public string Country { get; set; }
        public int NewStateId { get; set; }
        public int LGAId { get; set; }

        //public int ApplicationUserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
        public NewState NewState { get; set; }
        public LGA LGA { get; set; }
        public Department Department { get; set; }
        
        //public Salary Salary { get; set; }
        //public int SalaryID { get; set; }

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



