using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_D2.Models;

namespace MVC_D2.Controllers
{
    public class WorksForController : Controller
    {
        EmpContext db;
        public WorksForController()
        {
            db = new EmpContext();
        }
        public IActionResult Index()
        {
            List<WorksFor> work = db.WorksFor.Include(e => e.employee).Include(p => p.project).ToList();
            ViewData["ColorValue"] = "red";
            return View(work);
        }
        public IActionResult Details(int id)
        {
            List<WorksFor> work = db.WorksFor.Include(e => e.employee).Include(p => p.project).Where(i=>i.ESSn==id).ToList();
            ViewData["ColorValue"] = "red";
            return View(work);
        }
        public IActionResult GetEmployees()
        {
            List<Employee> employees = db.Employees.ToList();
            return View(employees);
        }
        public IActionResult GetProjects(int id)
        {

            var Projects = db.WorksFor.Include(x => x.employee).Include(x => x.project).Where(x => x.ESSn == id).Select(x => new { x.project.Pnumber, x.project.Pname }).ToList();

            //  return View(Projects);
            return Json(Projects);
        }
        public IActionResult GetHours(int id, int pid)
        {

            var Projects = db.WorksFor.Where(x => x.ESSn == id && x.Pno == pid).Select(x => new { x.Hours }).SingleOrDefault();

            //  return View(Projects);
            return Json(Projects);
        }

        [HttpPost]
        public IActionResult EditHour(int eId, int pId, int hour)
        {
            var worksOn = db.WorksFor.FirstOrDefault(x => x.ESSn == eId && x.Pno == pId);
            if (worksOn == null)
            {
                var Employees = db.Employees.ToList();
                return View("GetEmployees", Employees);
            }
            else
            {
                worksOn.Hours = hour;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


        }
    }
}
