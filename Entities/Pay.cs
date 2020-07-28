using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StaffPortal.Entities
{
    public class Pay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GradeId { get; set; }
        public string PayItem { get; set; }
        public string PayItemType { get; set; }
        public int Amount { get; set; }
        public Grade Grade { get; set; }

        /* public int ID { get; set; }

         public string EmployeeName { get; set; }

         public Department department { get; set; }

         public Grade grade { get; set; }

         public Faculty faculty { get; set; }

         public float BasicSalary { get; set; }

         public float Housing { get; set; }

         public float Tax { get; set; }

         public float Lunch { get; set; }

         public float Transport { get; set; }

         public float Medical { get; set; }

         public float NetSalary { get; set; }
 */
    }
}
