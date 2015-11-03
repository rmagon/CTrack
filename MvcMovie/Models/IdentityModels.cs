using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcCTrack.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       public String Role { get; set; }
       public long companyid { get; set; }
       public long departmentId { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<MvcMovie.Models.Complaint> Complaints { get; set; }
        public DbSet<MvcMovie.Models.Company> Companies { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}