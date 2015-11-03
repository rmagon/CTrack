using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCTrack.Models;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ComplaintController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Complaint/
        public ActionResult Index(long CompanyID = 0,long DepartmentID = -1)
        {
            ViewBag.CompanyID = CompanyID;
            ViewBag.DepartmentID = DepartmentID;
            return View(db.Complaints.ToList());
        }

        // GET: /Complaint/SelectDepartment
        public ActionResult SelectDepartment(long CompanyID = 0)
        {
            ViewBag.CompanyID = CompanyID;
            return View(db.Complaints.ToList());
        }

        // GET: /Complaint/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // GET: /Complaint/Create
        public ActionResult Create(long companyid, string companyname)
        {
            ViewBag.CompanyName = companyname;
            ViewBag.CompanyId = companyid;
            return View();
        }

        // POST: /Complaint/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "ID,DepartmentID,CompanyID,Date,Priority,Status,DueDate,Description,ToDo,Activities")] Complaint complaint, string companyname)
        {
            if (ModelState.IsValid)
            {
                db.Complaints.Add(complaint);
                db.SaveChanges();
                ViewBag.Success = 1;
                ViewBag.CompanyName = companyname;
                ViewBag.CompanyId = complaint.CompanyID;
                return View("CreateSuccess");
            }

            return View(complaint);
        }


        // GET: /Complaint/Edit/5
        public ActionResult Track(int? id,int success =0)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (success == 1)
            {
                ViewBag.Success = 1;
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: /Complaint/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Track([Bind(Include = "ID,DepartmentID,CompanyID,Date,Priority,Status,DueDate,Description,ToDo,Activities")] Complaint complaint, String NewDescription)
        {
            if (ModelState.IsValid)
            {
                complaint.Description = complaint.Description + "<br/>[User at " + DateTime.Now.ToString() + "]:" + NewDescription;
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Track", new { id = complaint.ID, success = 1 });
            }
            return View(complaint);
        }
        
        // GET: /Complaint/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: /Complaint/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "ID,DepartmentID,CompanyID,Date,Priority,Status,DueDate,Description,ToDo,Activities")] Complaint complaint, String NewDescription)
        {
            if (ModelState.IsValid)
            {
                complaint.Description = complaint.Description + "<br/>[Agent at " + DateTime.Now.ToString() + "]:" + NewDescription;
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", new { companyid = complaint.CompanyID, departmentid = complaint.DepartmentID });
            }
            return View(complaint);
        }

        // GET: /Complaint/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: /Complaint/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complaint complaint = db.Complaints.Find(id);
            db.Complaints.Remove(complaint);
            db.SaveChanges();
            return RedirectToAction("Index", new { companyid = complaint.CompanyID, departmentid = complaint.DepartmentID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
