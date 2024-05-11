//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Emp_Travel_Booking_Sys;

//namespace Emp_Travel_Booking_Sys.Controllers
//{
//    public class AdminController : Controller
//    {
//        private Employee_Travel_Booking_SystemEntities db = new Employee_Travel_Booking_SystemEntities();

//        // GET: Admin
//        public ActionResult Index()
//        {
//            return View(db.admins.ToList());
//        }

//        // GET: Admin/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            admin admin = db.admins.Find(id);
//            if (admin == null)
//            {
//                return HttpNotFound();
//            }
//            return View(admin);
//        }

//        // GET: Admin/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Admin/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "adminid,name,email,admin_password")] admin admin)
//        {
//            if (ModelState.IsValid)
//            {
//                db.admins.Add(admin);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(admin);
//        }

//        // GET: Admin/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            admin admin = db.admins.Find(id);
//            if (admin == null)
//            {
//                return HttpNotFound();
//            }
//            return View(admin);
//        }

//        // POST: Admin/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "adminid,name,email,admin_password")] admin admin)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(admin).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(admin);
//        }

//        // GET: Admin/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            admin admin = db.admins.Find(id);
//            if (admin == null)
//            {
//                return HttpNotFound();
//            }
//            return View(admin);
//        }

//        // POST: Admin/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            admin admin = db.admins.Find(id);
//            db.admins.Remove(admin);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}

using System.Linq;
using System.Web.Mvc;
using Emp_Travel_Booking_Sys;
using Emp_Travel_Booking_Sys.Models;
using EmployeeTravelBookingSystem.Models;

namespace EmployeeTravelBookingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly Employee_Travel_Booking_SystemEntities1 db = new Employee_Travel_Booking_SystemEntities1();

        [HttpGet]
        public ActionResult AddEmployee()
        {
            // You can implement logic to fetch manager details here and pass it to the view
            // For simplicity, I'm assuming you have a list of managers
            var managers = db.employees.Where(e => e.position == "Manager").ToList();
            ViewBag.Managers = managers;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(employee emp)
        {
            if (ModelState.IsValid)
            {
                // Save the employee to the database
                db.employees.Add(emp);
                db.SaveChanges();

                return RedirectToAction("Index", "Home"); // Redirect to home page or any other page
            }

            // If model state is not valid, return the view with errors
            return View(emp);
        }

        // GET: Admin/AssignManager
        [HttpGet]
        public ActionResult AssignManager()
        {
            ViewBag.Employees = db.employees.ToList();
            ViewBag.Managers = db.managers.ToList();
            return View();
        }

        // POST: Admin/AssignManager
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignManager(int employeeId, int managerId)
        {
            var employee = db.employees.Find(employeeId);
            if (employee != null)
            {
                employee.Reporting_Manager_Id = managerId;
                db.SaveChanges();
            }
            return RedirectToAction("EmployeeList");
        }

        // GET: Admin/ChangeManager
        [HttpGet]
        public ActionResult ChangeManager()
        {
            ViewBag.Employees = db.employees.ToList();
            ViewBag.NewManagers = db.managers.ToList();
            return View();
        }

        // POST: Admin/ChangeManager
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeManager(int employeeId, int newManagerId)
        {
            var employee = db.employees.Find(employeeId);
            if (employee != null)
            {
                employee.Reporting_Manager_Id = newManagerId;
                db.SaveChanges();
            }
            return RedirectToAction("EmployeeList");
        }

        // GET: Admin/AddEditTravelAgent
        [HttpGet]
        public ActionResult AddEditTravelAgent()
        {
            ViewBag.TravelAgents = db.travelagents.ToList();
            return View();
        }

        // POST: Admin/AddEditTravelAgent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEditTravelAgent(travelagent travelAgent)
        {
            if (ModelState.IsValid)
            {
                if (travelAgent.agentid == 0)
                {
                    db.travelagents.Add(travelAgent);
                }
                else
                {
                    var existingAgent = db.travelagents.Find(travelAgent.agentid);
                    if (existingAgent != null)
                    {
                        existingAgent.name = travelAgent.name;
                        // Update other properties as needed
                    }
                }
                db.SaveChanges();
                return RedirectToAction("TravelAgentList");
            }
            return View(travelAgent);
        }
    }
}
