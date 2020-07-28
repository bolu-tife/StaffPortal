using StaffPortal.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace StaffPortal.Models
{
    public class Salary
    {
        public int ID { get; set; }

        public string  EmployeeName { get; set; }

        public Department department { get; set; }

        public Grade grade { get; set; }

        public Faculty faculty { get; set; }

        public double BasicSalary { get; set; }

        public double Housing { get; set; }

        public double Tax { get; set; }

        public double Lunch { get; set; }

        public double Transport { get; set; }

        public double Medical { get; set; }

        public double NetSalary { get; set; }

                                           /*
                                                   public double Housing
                                                   {
                                                       get
                                                       {
                                                           return (5 / 100) * BasicSalary;
                                                       }
                                                   }

                                                   public double Tax
                                                   {
                                                       get
                                                       {
                                                           return (5 / 100) * BasicSalary;
                                                       }
                                                   }

                                                   public double Lunch
                                                   {
                                                       get
                                                       {
                                                           return (5 / 100) * BasicSalary;
                                                       }
                                                   }

                                                   public double Transport
                                                   {
                                                       get
                                                       {
                                                           return (5 / 100) * BasicSalary;
                                                       }
                                                   }

                                                   public double Medical
                                                   {
                                                       get
                                                       {
                                                           return (5 / 100) * BasicSalary;
                                                       }
                                                   }

                                                   public double NetSalary
                                                   {
                                                       get
                                                       {
                                                           return  BasicSalary + Housing + Lunch + 
                                                               Medical + Transport - Tax;
                                                       }
                                                   }


                                                   protected double radius;
                                                   public Circle()
                                                   {
                                                       radius = 0.0;
                                                   }

                                                   public double Area => radius * radius * Math.PI;


                                                   public double circumference
                                                   {
                                                       get {
                                                            return (radius * 2) * Math.PI;
                                                       }
                                                   }

                                                    */





    }
}
