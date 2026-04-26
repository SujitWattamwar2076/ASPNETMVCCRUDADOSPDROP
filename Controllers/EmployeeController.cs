using ASPNETMVCCRUDADOSPDROP.DAL;
using ASPNETMVCCRUDADOSPDROP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETMVCCRUDADOSPDROP.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeRepository repo = new EmployeeRepository();


        // Search feature branch code
        public ActionResult Index()
        {
            return View(repo.GetEmployees());
        }

        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(repo.GetDepartments(), "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            repo.Insert(emp);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var emp = repo.GetEmployees().FirstOrDefault(x => x.EmpId == id);
            ViewBag.Departments = new SelectList(repo.GetDepartments(), "DepartmentId", "DepartmentName", emp.DepartmentId);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            repo.Update(emp);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var emp = repo.GetEmployees().FirstOrDefault(x=>x.EmpId == id);
            return View(emp);
        }
    }
}