using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_D2.Models;
using System;

namespace MVC_D2.Controllers
{
    public class DepartmentController : Controller
    {
        EmpContext db;
        public DepartmentController()
        {
            db = new EmpContext();
        }
        public IActionResult Index()
        {
            List<Departments> departments = db.Departments.Include(d => d.manager).ToList();
            return View(departments);
        }
        public IActionResult Add()
        {
            ViewBag.manager = db.Employees.Except(db.Departments.Select(d => d.manager));
            return View();
        }
        public IActionResult AddDB(Departments department) {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index", "Department");
        }
        public IActionResult Edit(int id) {
            Departments department = db.Departments.SingleOrDefault(i => i.Dnum== id);
            ViewBag.manager = db.Employees.Except(db.Departments.Where(i=>i.Dnum!=id).Select(d => d.manager));
            return View(department);
        }
        public IActionResult EditDB(Departments department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
        public IActionResult Delete(int id)
        {
            Departments department = db.Departments.SingleOrDefault(i => i.Dnum == id);
            db.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
    }
}
