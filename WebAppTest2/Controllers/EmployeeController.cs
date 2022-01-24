using MVC_BusinessEntities;
using MVC_DataAccessLayer2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTest2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
      
        public ActionResult Index()
        {
            DL_Employee dal = new DL_Employee();
            List<BE_Employee> employees = dal.Employees.ToList();
            return View(employees);
        }
    }
}