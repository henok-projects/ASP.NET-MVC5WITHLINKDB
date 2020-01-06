using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LINQCRUD.Models;

namespace LINQCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        //CReate Object of DataClasses1dataContext 
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            //Fetch Records from Employee Table
            var empdata = from emp in db.Employees select emp;
            return View(empdata);
        }

        //
        // GET: /Employee/Details/5
        public ActionResult Details(int id)
        {
            //Lambda Expression
         var empdetails = db.Employees.Single(x => x.empid == id);       

            return View(empdetails);
        }

        //
        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create
        [HttpPost]
        public ActionResult Create(Employee collection)
        {
            try
            {
                // TODO: Add insert logic here
                db.Employees.InsertOnSubmit(collection);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var empdetails = db.Employees.Single(x => x.empid == id);

            return View(empdetails);
       
        }

        //
        // POST: /Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee collection)
        {
            try
            {
                // TODO: Add update logic here
                Employee emp = db.Employees.Single(x => x.empid == id);
                emp.empname = collection.empname;
                emp.empfathername = collection.empfathername;
                emp.empsalary = collection.empsalary;
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var empdetails = db.Employees.Single(x => x.empid == id);

            return View(empdetails);
        }

        //
        // POST: /Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var empdetails = db.Employees.Single(x => x.empid == id);
                db.Employees.DeleteOnSubmit(empdetails);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
