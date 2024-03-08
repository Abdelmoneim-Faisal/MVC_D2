using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_D2.Models;
using MVC_D2.ViewModels;

namespace MVC_D2.Controllers
{
    public class EmployeeController : Controller
    {
        EmpContext empContext = new EmpContext();
        public IActionResult Index()
        {
            List<Employee> employees = empContext.Employees.ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            Employee emp = empContext.Employees.SingleOrDefault(e=>e.SSN==id);
            return View(emp);
        }
        [HttpGet]
        public IActionResult Add()
        {

            EmployeeVM employeeVM = new()
            {
                departments = new SelectList(empContext.Departments, nameof(Departments.Dnum), nameof(Departments.Dname))
            };
            return View(employeeVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EmployeeVM employee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee()
                {
                    Fname = employee.Fname,
                    Lname = employee.Lname,
                    Address = employee.Address,
                    Salary = employee.Salary,
                    Dno = employee.Dno,
                };
                empContext.Employees.Add(emp);
                empContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            List<Departments> departments = empContext.Departments.ToList();
            employee.departments = new SelectList(departments, nameof(Departments.Dnum), nameof(Departments.Dname));
            return View(employee);
        }
    }
}
