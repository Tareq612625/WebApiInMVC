using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> empList;
            HttpResponseMessage response = GobalVariable.WebApiClient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View(empList);
        }
        public ActionResult AddOrEdit(int Id = 0) {
            if (Id == 0)
            {
                return View(new mvcEmployeeModel());

            }
            else {
                HttpResponseMessage response = GobalVariable.WebApiClient.GetAsync("Employees/"+Id.ToString()).Result;
                return View(response.Content.ReadAsAsync< mvcEmployeeModel>().Result);

            }
        }
       [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel emp) {
            if (emp.Id == 0)
            {
                HttpResponseMessage response = GobalVariable.WebApiClient.PostAsJsonAsync("Employees", emp).Result;
                TempData["successMessage"] = "Save Successfully";
            }
            else { 
                 HttpResponseMessage response = GobalVariable.WebApiClient.PutAsJsonAsync("Employees/"+emp.Id, emp).Result;
                TempData["successMessage"] = "Update Successfully";

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete( int Id) { 
            HttpResponseMessage response = GobalVariable.WebApiClient.DeleteAsync("Employees/"+Id.ToString()).Result;
            TempData["successMessage"] = "Delete Successfully";
            return RedirectToAction("Index");
        }
    }
}