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
       
    }
}
