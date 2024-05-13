using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Emp_Travel_Booking_Sys.Models;

namespace Emp_Travel_Booking_Sys.Controllers
{
    public class LoginAccountController : Controller
    {
        Employee_Travel_Booking_SystemEntities1 ETB = new Employee_Travel_Booking_SystemEntities1();

        // GET: LoginAccount
        [HttpGet]
        public ActionResult Login_Meth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login_Meth(int Id, string password)
        {
            // Validate the login credentials
            if (IsValidAdmin(Id, password))
            {
                // Redirect to the appropriate page based on user role
                return RedirectToAction("Admin");
            }
            //else if (IsValidEmployee(Id, password))
            //{
            //    // Redirect to the appropriate page based on user role
            //    return RedirectToAction("Employee");
            //}
            else if (IsValidTravelAgent(Id, password))
            {
                // Redirect to the appropriate page based on user role
                return RedirectToAction("TravelAgent");
            }
            else if (IsValidManager(Id, password))
            {
                // Store manager's ID in session
                Session["ManagerId"] = Id;

                // Redirect to the appropriate page based on user role
                return RedirectToAction("managerpage","Manager");
            }
            else
            {
                ViewBag.InvalidLogin = "Invalid ID or password.";
                return View();
            }
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Employee()
        {
            return View();
        }

        public ActionResult TravelAgent()
        {
            return View();
        }

        public ActionResult Manager()
        {
            return View();
        }

        private bool IsValidAdmin(int Id, string password)
        {
            var admin = ETB.admins.FirstOrDefault(u => u.adminid == Id && u.admin_password == password);
            return admin != null;
        }

        //private bool IsValidEmployee(int Id, string password)
        //{
        //    var employee = ETB.employees.FirstOrDefault(u => u.employeeid == Id && u.emp_password == password);
        //    return employee != null;
        //}

        private bool IsValidTravelAgent(int Id, string password)
        {
            var travelAgent = ETB.travelagents.FirstOrDefault(u => u.agentid == Id && u.travel_agent_password == password);
            return travelAgent != null;
        }

        private bool IsValidManager(int Id, string password)
        {
            var manager = ETB.managers.FirstOrDefault(u => u.managerid == Id && u.mgr_password == password);
            return manager != null;
        }
    }
}
