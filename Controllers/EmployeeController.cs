using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirstApproach.Models;
using EFCodeFirstApproach.ViewModels;
//using EFCodeFirstApproach.ViewModels;

namespace EFCodeFirstApproach.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDbContext db;
        public EmployeeController()
        {
            db = new EmployeeDbContext();
        }
        // GET: Employee
        public ActionResult Index(string search="")
        {
            ViewBag.Depts = db.Departments.ToList();
            ViewBag.MngId = db.Managers.ToList();

            ViewBag.Search = search;
            var res = db.Employees.Where(r => r.EmpName.Contains(search)).ToList();

            return View(res);

        }
        public ActionResult Details(int id)
        {
            //ViewBag.Depts = db.Departments.ToList();
            //ViewBag.MngId = db.Managers.ToList();
            var OneEmp = db.Employees.Include(e => e.Department).SingleOrDefault(e => e.Id == id);
             OneEmp = db.Employees.Include(e => e.Manager).SingleOrDefault(e => e.Id == id);

            //Employee emp=db.Employees.Where(e => e.Id == id).FirstOrDefault();
            if(OneEmp==null)
            {
                return HttpNotFound();
            }
            
            return View(OneEmp);
           
            
        }
        public ActionResult AddEmp()
        {
            //var OneEmp = db.Employees.Include(e => e.Department).SingleOrDefault(e => e.Id == id);



            ////Employee emp=db.Employees.Where(e => e.Id == id).FirstOrDefault();
            //if (OneEmp == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(OneEmp);
            ViewBag.Depts = db.Departments.ToList();
            ViewBag.MngId = db.Managers.ToList();
            return View();
        }
        //public ActionResult AddEmp()
        //{
        //    var allDepts = db.Departments.ToList();
        //    var allmgrs = db.Managers.ToList();
        //    var viewModel = new EmpDeptViewModel
        //    {
        //        AllDepts = allDepts,
        //        AllManagers=allmgrs
        //        };
        //    return View(viewModel);
        //}
        [HttpPost]
        public ActionResult AddEmp(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddEmp");
            }
           

            else

            {
                ViewBag.Depts = db.Departments.ToList();
                ViewBag.MngId = db.Managers.ToList();
                db.Employees.Add(employee);
                db.SaveChanges();



                return RedirectToAction("Index");
            }
        }
        public ActionResult UpdateEmp(int id)
        {

            var depts = db.Departments.ToList();
            var mngrs = db.Managers.ToList();
            var emp = db.Employees.SingleOrDefault(e => e.Id == id);
            var viewModel = new NewEmpViewModel
            {
                Employee=emp,
                Departments=depts,
                Managers=mngrs
            };
            return View("UpdateEmp", viewModel);
            //ViewBag.Depts = db.Departments.ToList();
            //ViewBag.MngId = db.Managers.ToList();
            //var OneEmp = db.Employees.Include(e => e.Department).SingleOrDefault(e => e.Id == id);
            //OneEmp = db.Employees.Include(e => e.Manager).SingleOrDefault(e => e.Id == id);

            ////var empToUpdate = db.Employees.Where(e => e.Id == id).FirstOrDefault();
            ////return View(empToUpdate);
            //return View(OneEmp);
        }
        
        [HttpPost]
        public ActionResult UpdateEmp(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            else
            {
                var updatedEmp = db.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
                updatedEmp.EmpName = employee.EmpName;
                updatedEmp.Salary = employee.Salary;
                updatedEmp.ManagerId = employee.ManagerId;
                updatedEmp.DeptId = employee.DeptId;


                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var delEmp = db.Employees.Where(e => e.Id == id).FirstOrDefault();
            return View(delEmp);
        }
        [HttpPost]
        public ActionResult Delete(int id, Employee employeeTab)
        {
            var delEmp = db.Employees.Where(e => e.Id == id).FirstOrDefault();
            db.Employees.Remove(delEmp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}