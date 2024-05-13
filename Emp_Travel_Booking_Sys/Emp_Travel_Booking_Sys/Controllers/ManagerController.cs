using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emp_Travel_Booking_Sys.Models; 

namespace Emp_Travel_Booking_Sys.Controllers
{
    public class ManagerController : Controller
    {
        public Employee_Travel_Booking_SystemEntities1 db = new Employee_Travel_Booking_SystemEntities1();

        // GET: Manager
        public ActionResult managerpage()
        {
            return View();
        }
        public ActionResult Index()
        {
            // Get the manager's login ID from the session
            int? managerId = Session["ManagerId"] as int?;

            // Retrieve travel requests of employees reporting to this manager
            var pendingRequests = db.travelRequests.Where(r => r.approvalstatus == "pending" && r.employee.Reporting_Manager_Id == managerId).ToList();

            return View(pendingRequests);

        }

        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            // Retrieve the details of a specific travel request
            var request = db.travelRequests.FirstOrDefault(x => x.requestid == id);
            return View(request);
        }

        // POST: Manager/Approve/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve(int id)
        {
            // Update the status of the travel request to "Approved"
            var request = db.travelRequests.Find(id);
            request.approvalstatus = "Approved";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Manager/Reject/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject(int id)
        {
            // Update the status of the travel request to "Rejected"
            var request = db.travelRequests.Find(id);
            request.approvalstatus = "Rejected";
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RequestHistory()
        {
            // Get the manager's login ID from the session
            int? managerId = Session["ManagerId"] as int?;

            // Retrieve the history of travel requests made by reporting employees
            var requestHistory = db.travelRequests.Where(r => r.employeeid == r.employeeid && r.employee.Reporting_Manager_Id == managerId).ToList();
            return View(requestHistory);
        }
    }
}
