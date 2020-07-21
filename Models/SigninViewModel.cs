//using System;
using System.ComponentModel.DataAnnotations;

namespace StaffPortal.Models
{
    public class SigninViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        //[DataType(DataType.Text)]
        public string UserName { get; set; }

        //[Required]
        ////[DataType(DataType.Text)]
        //public string FirstName { get; set; }

        //[Required]
        ////[DataType(DataType.Text)]
        //public string LastName { get; set; }

        //[Required]
        ////[DataType(DataType.Text)]
        //public int FacultyId { get; set; }

        //[Required]
        ////[DataType(DataType.Text)]
        //public int DepartmentId { get; set; }

        //[Required]
        ////[DataType(DataType.Text)]
        //public int StateId { get; set; }

        //[Required]
        ////[DataType(DataType.Text)]
        //public string LocalId { get; set; }

        //[Required]
        ////[DataType(DataType.Text)]
        //public string Country { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
