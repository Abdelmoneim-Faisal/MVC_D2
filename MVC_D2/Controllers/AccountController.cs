using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_D2.Models;

namespace MVC_D2.Controllers
{
    public class AccountController : Controller
    {
        EmpContext db;
        public AccountController()
        {
            db = new EmpContext();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginDB(string email, string password)
        {
            Employee employee = db.Employees.SingleOrDefault(i => i.Email== email && i.Password == password);

            if (employee != null)
            {
                HttpContext.Session.SetString("email", employee.Email);
                HttpContext.Session.SetString("password", employee.Password);
                return RedirectToAction("Index", "Projects");
            }
            return View("Login");
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}
