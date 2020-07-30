using StaffPortal.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace StaffPortal.Models
{
    public class Salary
    {
        public int ID { get; set; }

        public Grade Grade { get; set; }

        public int GradeId { get; set; }

        public double BasicSalary { get; set; }

        public double Housing { get; set; }

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

        public int ApplicationUserId { get; set; }

        public string PayItemType { get; set; }

    }
}
