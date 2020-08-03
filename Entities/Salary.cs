using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StaffPortal.Entities
{
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public Grade Grade { get; set; }

        public int GradeId { get; set; }

        public double BasicSalary { get; set; }

        public double Housing { get; set; }

        public string ApplicationUserId { get; set; }

        public double HousingPercent { get; set; }

        public string HousingItemType { get; set; }

        public double Tax { get; set; }

        public double TaxPercent { get; set; }

        public string TaxItemType { get; set; }

        public double Lunch { get; set; }

        public string LunchItemType { get; set; }

        public double LunchPercent { get; set; }

        public double Transport { get; set; }

        public double TransportPercent { get; set; }

        public string TransportItemType { get; set; }

        public double Medical { get; set; }

        public double MedicalPercent { get; set; }

        public string MedicalItemType { get; set; }

        public double NetSalary { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

       
    }
}
