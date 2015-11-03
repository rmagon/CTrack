using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class Complaint
    {
        public int ID { get; set; }
        public int DepartmentID { get; set; }
        public int CompanyID { get; set; }
        public DateTime Date { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        [Display(Name = "Message")]
        public string Description { get; set; }
        public string ToDo { get; set; }
        public string Activities { get; set; }
    }

    //public class CTrackDBContext : DbContext
    //{
    //    public DbSet<Complaint> Complaints { get; set; }
    //    public DbSet<MvcMovie.Models.Company> Companies { get; set; }
    //}
}