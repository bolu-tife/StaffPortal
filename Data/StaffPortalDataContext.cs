using System;
using StaffPortal.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StaffPortal.Data
{
    public class StaffPortalDataContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public StaffPortalDataContext(DbContextOptions<StaffPortalDataContext> options) : base(options)
        {
        }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }



    }
}
