using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_D2.Models;
using System;

namespace MVC_D2.Controllers
{
    public class ProjectsController : Controller
    {
        EmpContext db;
        public ProjectsController()
        {
            db = new EmpContext();
        }
        public IActionResult Index()
        {
            List<Project> projects = db.Projects.Include(d=>d.department).ToList();
            return View(projects);
        }
        public IActionResult Details(int id)
        {
            Project project = db.Projects.Include(d => d.department).SingleOrDefault(i => i.Pnumber == id);
            return View(project);
        }
        public IActionResult GetAddForm()
        {
            List<Departments> departments = db.Departments.ToList();
            ViewData["departments"] = departments;
            return View();
        }

        public IActionResult GetFormData(string Projname, string Projlocation, string city, int deptId)
        {
            Project project = new()
            {
                Pname = Projname,
                Plocation = Projlocation,
                City = city,
                Dnum = deptId
            };

            db.Projects.Add(project);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult GetEditForm(int id)
        {
            Project project = db.Projects.SingleOrDefault(i => i.Pnumber == id);
            List<Departments> departments = db.Departments.ToList();

            ViewData["departments"] = departments;
            return View(project);
        }
        public IActionResult Update(int Projnumber, string Projname, string Projlocation, string city, int deptId)
        {

            Project project = db.Projects.SingleOrDefault(i => i.Pnumber== Projnumber);
            project.Pname= Projname;
            project.Plocation= Projlocation;
            project.City= city;
            project.Dnum= deptId;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Project project = db.Projects.SingleOrDefault(i => i.Pnumber== id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
